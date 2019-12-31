using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineImpression
    {
        #region Внутренние поля.

        Random rnd = new Random();

        QuestionGeneratorImpression generator = new QuestionGeneratorImpression();

        DateTime testStartDate;

        private Timer timerTest;
        private Timer timerPause;

        #endregion Внутренние поля.

        public Color? QuestionColor
        {
            get
            {
                return this.generator.QuestionColor;
            }
        }

        public string QuestionText
        {
            get { return this.generator.QuestionText; }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainTestBegin;

        public event EventHandler TrainQuestionNew;

        public event EventHandler TrainTestEnd;

        public event QuestionResultEventHandler TrainQuestionResult;

        public event EventHandler TrainStoped;

        protected void OnTrainStarted(EventArgs args)
        {
            if (TrainStarted != null)
            {
                TrainStarted(this, args);
            }
        }

        protected void OnTrainTestBegin(EventArgs args)
        {
            if (TrainTestBegin != null)
            {
                TrainTestBegin(this, args);
            }
        }

        protected void OnTrainQuestionNew(EventArgs args)
        {
            if (TrainQuestionNew != null)
            {
                TrainQuestionNew(this, args);
            }
        }

        protected void OnTrainTestEnd(EventArgs args)
        {
            if (TrainTestEnd != null)
            {
                TrainTestEnd(this, args);
            }
        }

        protected void OnTrainQuestionResult(QuestionResultEventArgs args)
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

        private int timeShowing = 1000;
        public virtual int TimeShowing
        {
            get { return this.timeShowing; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                bool changed = this.timeShowing != value;

                this.timeShowing = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int TimePause
        {
            get { return this.timerPause.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimePause");
                }

                bool changed = this.timerPause.Interval != value;

                this.timerPause.Interval = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Свойства процесса.

        public TrainTypeImpression TestType
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

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

        public int WordsCount
        {
            get { return this.generator.WordsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("WordsCount");
                }

                bool changed = this.generator.WordsCount != value;

                this.generator.WordsCount = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int SymbolsCount
        {
            get { return this.generator.SymbolsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SymbolsCount");
                }

                bool changed = this.generator.SymbolsCount != value;

                this.generator.SymbolsCount = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public bool WithColor
        {
            get { return this.generator.WithColor; }
            set
            {
                bool changed = this.generator.WithColor != value;

                this.generator.WithColor = value;
                if (changed && this.TestType == TrainTypeImpression.Symbols)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual bool WithRandomLiters
        {
            get { return this.generator.WithRandomLiters; }
            set
            {
                bool changed = this.generator.WithRandomLiters != value;

                this.generator.WithRandomLiters = value;
                if (changed && this.TestType == TrainTypeImpression.Dictionary)
                {
                    this.settingsIsChanged();
                }
            }
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

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineImpression()
        {
            timerTest = new Timer();
            timerTest.Interval = 1000;
            timerTest.Tick += new EventHandler(timerTest_Tick);

            timerPause = new Timer();
            timerPause.Interval = 800;
            timerPause.Tick += new EventHandler(timerPause_Tick);

            currentSerie = new ExerciseSerie(GetTrainType());
        }

        #endregion Конструкторы.

        #region События таймеров.

        void timerTest_Tick(object sender, EventArgs e)
        {
            timerTest.Stop();

            PerformTest();
        }

        void timerPause_Tick(object sender, EventArgs e)
        {
            timerPause.Stop();

            GenerateNewQuestion();
        }

        #endregion События таймеров.

        private void PerformTest()
        {
            if (status == MachineStatus.AutoShowing)
            {
                OnTrainQuestionNew(new EventArgs());

                status = MachineStatus.ShowingQuestion;

                timerTest.Interval = this.TimeShowing;
                timerTest.Start();
            }
            else if (status == MachineStatus.ShowingQuestion)
            {
                status = MachineStatus.WaitingAnswer;
                testStartDate = DateTime.Now;

                OnTrainTestEnd(new EventArgs());
            }
        }

        private void CheckAnswer(string userAnswer)
        {
            timerTest.Stop();

            DateTime testEndDate = DateTime.Now;

            double time = (testEndDate - testStartDate).TotalSeconds;

            bool isAnswerRight = false;
            string answerText = string.Empty;
            string userAnswerText = string.Empty;

            this.generator.CheckAnswer(userAnswer, out isAnswerRight, out answerText, out userAnswerText);

            currentSerie.Attempts.Add(new ExerciseAttempt(TrainType.Impression, this.testStartDate, time, false, this.generator.QuestionText, this.generator.AnswerText, isAnswerRight, userAnswerText));

            if (isAnswerRight)
            {
                status = MachineStatus.Pause;

                timerPause.Start();
            }
            else
            {
                status = MachineStatus.ShowingError;
            }

            OnTrainQuestionResult(new QuestionResultEventArgs(answerText, isAnswerRight, false));
        }

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            return string.Compare(rightAnswer, answer, true) == 0;
        }

        public void MakeAction(string userText)
        {
            if (CanGetNewQuestion)
            {
                GenerateNewQuestion();
            }
            else if (CanWriteAnswer)
            {
                this.CheckAnswer(userText);
            }
        }

        private void GenerateNewQuestion()
        {
            timerTest.Stop();

            this.generator.CreateNewQuestion();

            if (this.status == MachineStatus.NotStarted)
            {
                OnTrainStarted(new EventArgs());
            }

            status = MachineStatus.AutoShowing;

            OnTrainTestBegin(new EventArgs());

            timerTest.Interval = rnd.Next(1000, 2000);
            timerTest.Start();
        }

        public bool CanWriteAnswer
        {
            get { return this.status == MachineStatus.WaitingAnswer; }
        }

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.ShowingError || this.status == MachineStatus.NotStarted; }
        }

        public virtual void Stop()
        {
            timerPause.Stop();
            timerTest.Stop();

            if (status != MachineStatus.NotStarted)
            {
                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());
            }
        }

        private void settingsIsChanged()
        {
            this.generator.Clear();

            this.Stop();

            UpdateExerciseSerie();
        }

        #region Логирование упражнения.

        private ExerciseSerie currentSerie;

        private void UpdateExerciseSerie()
        {
            ExerciseType type = GetTrainType();

            if (!currentSerie.Type.Equals(type))
            {
                SaveExeruciseSerie();

                currentSerie = new ExerciseSerie(type);
            }
        }

        public void SaveExeruciseSerie()
        {
            if (status != MachineStatus.NotStarted)
            {
                this.Stop();
            }

            if (currentSerie.Attempts.Count > 0)
            {
                LogExercise.AddNewExerciseSerie(currentSerie);
                LogExercise.SaveProgramsLogs();

                currentSerie = new ExerciseSerie(GetTrainType());
            }
        }

        private ExerciseType GetTrainType()
        {
            ExerciseTypeImpression type = new ExerciseTypeImpression();

            type.TestType = this.TestType;

            if (this.TestType == TrainTypeImpression.Dictionary)
            {
                type.WithRandomLiters = this.generator.WithRandomLiters;
            }
            else if (this.TestType == TrainTypeImpression.Symbols)
            {
                type.SymbolsCount = this.generator.SymbolsCount;

                type.WithColor = this.generator.WithColor;
            }

            type.ShowTime = this.TimeShowing;

            return type;
        }

        #endregion Логирование упражнения.
    }
}
