using System;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineStepanov
    {
        #region Внутренние поля.

        QuestionGeneratorStepanov generator = new QuestionGeneratorStepanov();

        DateTime testStartDate;

        private Timer timerCheckAnswer;
        private Timer timerHide;
        private Timer timerPause;

        #endregion Внутренние поля.

        public string QuestionText
        {
            get { return this.generator.QuestionText; }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainTestBegin;

        public event EventHandler TrainTestEnd;

        public event QuestionResultEventHandler TrainQuestionResult;

        public event AutoCheckEventHandler TrainAnswerAutoCheck;

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

        protected void OnTrainAnswerAutoCheck(AutoCheckEventArgs args)
        {
            if (TrainAnswerAutoCheck != null)
            {
                TrainAnswerAutoCheck(this, args);
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

        private bool isHideQuestion = false;
        public virtual bool IsHideQuestion
        {
            get { return this.isHideQuestion; }
            set
            {
                bool changed = this.isHideQuestion != value;

                this.isHideQuestion = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual int TimeShowing
        {
            get { return this.timerHide.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                bool changed = this.timerHide.Interval != value;

                this.timerHide.Interval = value;
                if (changed && this.isHideQuestion)
                {
                    this.settingsIsChanged();
                }
            }
        }

        private bool isAutoAnswer = false;
        public bool IsAutoAnswer
        {
            get { return this.isAutoAnswer; }
            set
            {
                bool changed = this.isAutoAnswer != value;

                this.isAutoAnswer = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int TimeForAnswer
        {
            get { return this.timerCheckAnswer.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeForAnswer");
                }

                bool changed = this.timerCheckAnswer.Interval != value;

                this.timerCheckAnswer.Interval = value;
                if (changed && this.isAutoAnswer)
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

        public TrainTypeStepanovAndRecentMemory TestType
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

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineStepanov()
        {
            timerHide = new Timer();
            timerHide.Interval = 1000;
            timerHide.Tick += new EventHandler(timerHide_Tick);

            timerCheckAnswer = new Timer();
            timerCheckAnswer.Interval = 20000;
            timerCheckAnswer.Tick += new EventHandler(timerCheckAnswer_Tick);

            timerPause = new Timer();
            timerPause.Interval = 800;
            timerPause.Tick += new EventHandler(timerPause_Tick);

            currentSerie = new ExerciseSerie(GetTrainType());
        }

        #endregion Конструкторы.

        #region События таймеров.

        void timerHide_Tick(object sender, EventArgs e)
        {
            timerHide.Stop();

            PerformHideQuestion();
        }

        void timerCheckAnswer_Tick(object sender, EventArgs e)
        {
            timerCheckAnswer.Stop();

            PerformAutoCheckAnswer();
        }

        void timerPause_Tick(object sender, EventArgs e)
        {
            timerPause.Stop();

            GenerateNewQuestion();
        }

        #endregion События таймеров.

        private void PerformHideQuestion()
        {
            OnTrainTestEnd(new EventArgs());

            StartWaitingAnswer();
        }

        private void StartWaitingAnswer()
        {
            testStartDate = DateTime.Now;

            status = MachineStatus.WaitingAnswer;

            if (this.isAutoAnswer)
            {
                timerCheckAnswer.Start();
            }
        }

        private void PerformAutoCheckAnswer()
        {
            this.status = MachineStatus.AutoCheckingAnswer;

            AutoCheckEventArgs args = new AutoCheckEventArgs();

            OnTrainAnswerAutoCheck(args);

            CheckAnswer(true, args.UserAnswer);
        }

        public void MakeAction(string userString)
        {
            if (CanGetNewQuestion)
            {
                GenerateNewQuestion();
            }
            else if (CanHideQuestion)
            {
                PerformHideQuestion();
            }
            else if (CanWriteAnswer)
            {
                CheckAnswer(false, userString);
            }
        }

        private void GenerateNewQuestion()
        {
            this.generator.CreateNewQuestion();

            timerHide.Stop();
            timerCheckAnswer.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                OnTrainStarted(new EventArgs());
            }

            OnTrainTestBegin(new EventArgs());

            status = MachineStatus.ShowingQuestion;

            if (this.isHideQuestion)
            {
                timerHide.Start();
            }
        }

        private void CheckAnswer(bool autoTimer, string userAnswer)
        {
            timerHide.Stop();
            timerCheckAnswer.Stop();

            DateTime testEndDate = DateTime.Now;

            double time = (testEndDate - testStartDate).TotalSeconds;

            bool isAnswerRight = false;
            string answerText = string.Empty;
            string userAnswerText = string.Empty;

            this.generator.CheckAnswer(userAnswer, out isAnswerRight, out answerText, out userAnswerText);

            currentSerie.Attempts.Add(new ExerciseAttempt(TrainType.Stepanov, this.testStartDate, time, autoTimer, this.generator.AnswerText, string.Empty, isAnswerRight, userAnswer));

            if (isAnswerRight)
            {
                status = MachineStatus.Pause;

                timerPause.Start();
            }
            else
            {
                status = MachineStatus.ShowingError;
            }

            OnTrainQuestionResult(new QuestionResultEventArgs(answerText, isAnswerRight, autoTimer));
        }

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.ShowingError || this.status == MachineStatus.NotStarted; }
        }

        public bool CanHideQuestion
        {
            get { return this.status == MachineStatus.ShowingQuestion; }
        }

        public bool CanWriteAnswer
        {
            get { return this.status == MachineStatus.WaitingAnswer; }
        }

        public virtual void Stop()
        {
            timerPause.Stop();
            timerHide.Stop();
            timerCheckAnswer.Stop();

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
            ExerciseTypeStepanovAndRecentMemory type = new ExerciseTypeStepanovAndRecentMemory(TrainType.Stepanov);

            type.TestType = this.TestType;

            type.SymbolsCount = this.SymbolsCount;

            if (this.isHideQuestion)
            {
                type.ShowTime = this.TimeShowing;
            }

            if (this.isAutoAnswer)
            {
                type.AutoAnswerCheckTime = this.TimeForAnswer;
            }

            return type;
        }

        #endregion Логирование упражнения.
    }
}
