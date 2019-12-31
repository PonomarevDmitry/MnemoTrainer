using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineAssociationClosed
    {
        #region Внутренние поля.

        private DateTime testStartDate;
        private DateTime testEndDate;
        private DateTime wordStartDate;

        private Collection<AssociationQuestion> associationQuestions;

        private Timer timerNextQuestion;

        private QuestionGeneratorAssociationClosed generator = new QuestionGeneratorAssociationClosed();

        #endregion Внутренние поля.

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private int questionIndex = 0;
        public int QuestionIndex
        {
            get { return this.questionIndex; }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainNewQuestion;

        public event EventHandler TrainTestEnd;

        public event AssociationResultEventHandler TrainQuestionResult;

        public event EventHandler TrainStoped;

        protected void OnTrainStarted(EventArgs args)
        {
            if (TrainStarted != null)
            {
                TrainStarted(this, args);
            }
        }

        protected void OnTrainNewQuestion(EventArgs args)
        {
            if (TrainNewQuestion != null)
            {
                TrainNewQuestion(this, args);
            }
        }

        protected void OnTrainTestEnd(EventArgs args)
        {
            if (TrainTestEnd != null)
            {
                TrainTestEnd(this, args);
            }
        }

        protected void OnTrainQuestionResult(AssociationResultEventArgs args)
        {
            if (TrainQuestionResult != null)
            {
                TrainQuestionResult(this, args);
            }
        }

        protected void OnTrainStoped(EventArgs args)
        {
            if (TrainStoped != null)
            {
                TrainStoped(this, args);
            }
        }

        #endregion События.

        #region Свойства.

        #region Свойства процесса.

        private bool isAutoNextQuestion = false;
        public virtual bool IsAutoNextQuestion
        {
            get { return this.isAutoNextQuestion; }
            set
            {
                bool changed = this.isAutoNextQuestion != value;

                this.isAutoNextQuestion = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual int TimeShowing
        {
            get { return this.timerNextQuestion.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                bool changed = this.timerNextQuestion.Interval != value;

                this.timerNextQuestion.Interval = value;
                if (changed && this.isAutoNextQuestion)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Свойства процесса.

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

        public TrainTypeAssociationClosed TestType
        {
            get { return this.generator.TestType; }
            set
            {
                bool changed = this.generator.TestType != value;

                this.generator.TestType = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public FileInfo SelectedDictionary
        {
            get { return this.generator.SelectedDictionary; }
            set
            {
                if (value != null && !value.Exists)
                {
                    throw new ArgumentException("SelectedFile");
                }

                bool changed = this.generator.SelectedDictionary != value;

                this.generator.SelectedDictionary = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public ClosedList SelectedClosedList
        {
            get { return this.generator.SelectedClosedList; }
            set
            {
                bool changed = this.generator.SelectedClosedList != value;

                this.generator.SelectedClosedList = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int QuestionsCount
        {
            get { return this.generator.QuestionsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("QuestionsCount");
                }

                bool changed = this.generator.QuestionsCount != value;

                this.generator.QuestionsCount = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineAssociationClosed()
        {
            timerNextQuestion = new Timer();
            timerNextQuestion.Interval = 20000;
            timerNextQuestion.Tick += new EventHandler(timerNextQuestion_Tick);

            this.associationQuestions = new Collection<AssociationQuestion>();
        }

        #endregion Конструкторы.

        #region События таймеров.

        void timerNextQuestion_Tick(object sender, EventArgs e)
        {
            timerNextQuestion.Stop();

            PerformNextQuestion();
        }

        #endregion События таймеров.

        public void MakeAction()
        {
            if (CanGetNewQuestion)
            {
                PerformNextQuestion();
            }
            else if (CanGetAnswers)
            {
                GetAnswers();
            }
        }

        private void PerformNextQuestion()
        {
            timerNextQuestion.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                this.associationQuestions = this.generator.CreateNewQuestionList();

                questionIndex = -1;
                status = MachineStatus.ShowingQuestion;

                testStartDate = DateTime.Now;

                OnTrainStarted(new EventArgs());
            }

            questionIndex++;

            if (questionIndex < this.QuestionsCount)
            {
                {
                    AssociationQuestion nextQuestion = GetQuestionByShowPosition(questionIndex + 1);

                    if (nextQuestion != null)
                    {
                        this.questionText = nextQuestion.Question;
                    }
                    else
                    {
                        this.questionText = string.Empty;
                    }
                }

                DateTime lastWordStartDate = wordStartDate;
                wordStartDate = DateTime.Now;

                OnTrainNewQuestion(new EventArgs());

                if (questionIndex != 0)
                {
                    AssociationQuestion lastQuestion = GetQuestionByShowPosition(questionIndex);

                    if (lastQuestion != null)
                    {
                        lastQuestion.Time = (wordStartDate - lastWordStartDate).TotalSeconds;
                    }
                }

                if (this.isAutoNextQuestion)
                {
                    timerNextQuestion.Start();
                }
            }
            else
            {
                testEndDate = DateTime.Now;

                status = MachineStatus.WaitingAnswer;
                OnTrainTestEnd(new EventArgs());
            }
        }

        private AssociationQuestion GetQuestionByShowPosition(int showPosition)
        {
            foreach (AssociationQuestion item in this.associationQuestions)
            {
                if (item.ShowPosition == showPosition)
                {
                    return item;
                }
            }

            return null;
        }

        private void GetAnswers()
        {
            timerNextQuestion.Stop();

            Collection<AssociationQuestion> result = new Collection<AssociationQuestion>();

            foreach (AssociationQuestion item in this.associationQuestions)
            {
                result.Add(item);
            }

            this.status = MachineStatus.NotStarted;

            OnTrainQuestionResult(new AssociationResultEventArgs(result));

            SaveExeruciseSerie();
        }

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.NotStarted || this.status == MachineStatus.ShowingQuestion; }
        }

        public bool CanGetAnswers
        {
            get { return this.status == MachineStatus.WaitingAnswer; }
        }

        public virtual void Stop()
        {
            timerNextQuestion.Stop();

            if (status != MachineStatus.NotStarted)
            {
                this.questionIndex = -1;
                this.questionText = string.Empty;

                this.associationQuestions.Clear();

                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());
            }
        }

        private void settingsIsChanged()
        {
            this.Stop();
        }

        #region Логирование упражнения.

        private void SaveExeruciseSerie()
        {
            DateTime testCheckDate = DateTime.Now;
            double time = (testEndDate - testStartDate).TotalSeconds;
            double timeCheck = (testCheckDate - testEndDate).TotalSeconds;

            ExerciseAttemptAssociationsClosed attempt = new ExerciseAttemptAssociationsClosed(testStartDate, testEndDate, testCheckDate, time, timeCheck);
            foreach (AssociationQuestion item in this.associationQuestions)
            {
                attempt.Questions.Add(item);
            }

            if (this.TestType == TrainTypeAssociationClosed.WordDictionary)
            {
                attempt.FromDictionary = true;
            }
            else
            {
                attempt.ListName = this.SelectedClosedList.Name;
            }

            ExerciseSerie currentSerie = new ExerciseSerie(new ExerciseType(TrainType.ClosedAssociations));
            currentSerie.Attempts.Add(attempt);

            LogExercise.AddNewExerciseSerie(currentSerie);
            LogExercise.SaveProgramsLogs();

            attempt.CreateTestTextFile();
        }

        #endregion Логирование упражнения.
    }
}
