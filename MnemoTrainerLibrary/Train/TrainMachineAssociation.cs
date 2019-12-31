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
    public class TrainMachineAssociation
    {
        #region Внутренние поля.

        private DateTime testStartDate;
        private DateTime testEndDate;
        private DateTime wordStartDate;

        private Collection<AssociationQuestion> associationQuestions;

        private Timer timerNextQuestion;

        private QuestionGeneratorAssociation generator = new QuestionGeneratorAssociation();

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

        public FileInfo SelectedFile
        {
            get { return this.generator.SelectedFile; }
            set
            {
                if (value != null && !value.Exists)
                {
                    throw new ArgumentException("SelectedFile");
                }

                bool changed = this.generator.SelectedFile != value;

                this.generator.SelectedFile = value;
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

        public virtual bool WithRepeats
        {
            get { return this.generator.WithRepeats; }
            set
            {
                bool changed = this.generator.WithRepeats != value;

                this.generator.WithRepeats = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual bool WithNumber
        {
            get { return this.generator.WithNumber; }
            set
            {
                bool changed = this.generator.WithNumber != value;

                this.generator.WithNumber = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual bool RandomOrder
        {
            get { return this.generator.RandomOrder; }
            set
            {
                bool changed = this.generator.RandomOrder != value;

                this.generator.RandomOrder = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual bool WithoutOldWords
        {
            get { return this.generator.WithoutOldWords; }
            set
            {
                bool changed = this.generator.WithoutOldWords != value;

                this.generator.WithoutOldWords = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int OldWordsCount
        {
            get { return this.generator.OldWordsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("OldWordsCount");
                }

                bool changed = this.generator.OldWordsCount != value;

                this.generator.OldWordsCount = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineAssociation()
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

            if (questionIndex < this.generator.QuestionsCount)
            {
                {
                    AssociationQuestion nextQuestion = GetQuestionByShowPosition(questionIndex + 1);

                    if (nextQuestion != null)
                    {
                        if (this.WithNumber)
                        {
                            this.questionText = string.Format("{0}. {1}", nextQuestion.Number.ToString(), nextQuestion.Question);
                        }
                        else
                        {
                            this.questionText = nextQuestion.Question;
                        }
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

            ExerciseAttemptAssociationsСonsecutive attempt = new ExerciseAttemptAssociationsСonsecutive(testStartDate, testEndDate, testCheckDate, time, timeCheck);
            attempt.WithRepeats = this.WithRepeats;
            attempt.WithNumber = this.WithNumber;
            if (attempt.WithNumber)
            {
                attempt.Random = this.RandomOrder;
            }

            foreach (AssociationQuestion item in this.associationQuestions)
            {
                attempt.Questions.Add(item);
            }

            ExerciseSerie currentSerie = new ExerciseSerie(new ExerciseType(TrainType.ConsecutiveAssociations));
            currentSerie.Attempts.Add(attempt);

            LogExercise.AddNewExerciseSerie(currentSerie);
            LogExercise.SaveProgramsLogs();

            attempt.CreateTestTextFile();
        }

        #endregion Логирование упражнения.
    }
}
