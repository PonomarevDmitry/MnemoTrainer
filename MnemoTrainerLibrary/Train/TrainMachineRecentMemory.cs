using System;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineRecentMemory
    {
        #region Внутренние поля.

        QuestionGeneratorRecentMemory generator = new QuestionGeneratorRecentMemory();

        DateTime testStartDate;

        private int questionIndex = 0;
        public int QuestionIndex
        {
            get { return this.questionIndex; }
        }

        private Timer timerCheckAnswer;
        private Timer timerNextSymbol;
        private Timer timerPause;

        #endregion Внутренние поля.

        public string QuestionText
        {
            get
            {
                if (questionIndex < 0 || questionIndex >= generator.QuestionCollection.Length)
                {
                    return string.Empty;
                }

                return this.generator.QuestionCollection[questionIndex].ToString();
            }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainTestBegin;

        public event EventHandler TrainQuestionNew;

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

        public virtual int TimeShowing
        {
            get { return this.timerNextSymbol.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                bool changed = this.timerNextSymbol.Interval != value;

                this.timerNextSymbol.Interval = value;
                if (changed)
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

        public TrainMachineRecentMemory()
        {
            timerNextSymbol = new Timer();
            timerNextSymbol.Interval = 1000;
            timerNextSymbol.Tick += new EventHandler(timerNextSymbol_Tick);

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

        void timerNextSymbol_Tick(object sender, EventArgs e)
        {
            PerformNextSymbol();
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

        private void PerformNextSymbol()
        {
            if (questionIndex < this.generator.QuestionCollection.Length)
            {
                OnTrainQuestionNew(new EventArgs());

                questionIndex++;
            }
            else
            {
                timerNextSymbol.Stop();

                StartWaitingAnswer();
            }
        }

        private void StartWaitingAnswer()
        {
            testStartDate = DateTime.Now;

            status = MachineStatus.WaitingAnswer;

            OnTrainTestEnd(new EventArgs());

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

        private void CheckAnswer(bool autoTimer, string userAnswer)
        {
            timerNextSymbol.Stop();
            timerCheckAnswer.Stop();

            DateTime testEndDate = DateTime.Now;

            double time = (testEndDate - testStartDate).TotalSeconds;

            bool isAnswerRight = false;
            string answerText = string.Empty;
            string userAnswerText = string.Empty;

            this.generator.CheckAnswer(userAnswer, out isAnswerRight, out answerText, out userAnswerText);

            currentSerie.Attempts.Add(new ExerciseAttempt(TrainType.RecentMemory, this.testStartDate, time, autoTimer, this.generator.QuestionText, string.Empty, isAnswerRight, userAnswerText));

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

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            return rightAnswer == answer;
        }

        public void ShowNextQuestion()
        {
            if (CanGetNewQuestion)
            {
                GenerateNewQuestion();
            }
        }

        private void GenerateNewQuestion()
        {
            questionIndex = 0;

            this.generator.CreateNewQuestion();

            timerNextSymbol.Stop();
            timerCheckAnswer.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                OnTrainStarted(new EventArgs());
            }

            OnTrainTestBegin(new EventArgs());

            status = MachineStatus.ShowingQuestion;
            timerNextSymbol.Start();
        }

        public bool CanWriteAnswer
        {
            get { return this.status == MachineStatus.WaitingAnswer; }
        }

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.ShowingError || this.status == MachineStatus.NotStarted; }
        }

        public void TryAnswer(string userAnswer)
        {
            if (CanWriteAnswer)
            {
                CheckAnswer(false, userAnswer);
            }
        }

        public virtual void Stop()
        {
            this.questionIndex = 0;

            timerPause.Stop();
            timerNextSymbol.Stop();
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
            ExerciseTypeStepanovAndRecentMemory type = new ExerciseTypeStepanovAndRecentMemory(TrainType.RecentMemory);

            type.TestType = this.TestType;

            type.SymbolsCount = this.SymbolsCount;

            type.ShowTime = this.TimeShowing;

            if (this.isAutoAnswer)
            {
                type.AutoAnswerCheckTime = this.TimeForAnswer;
            }

            return type;
        }

        #endregion Логирование упражнения.
    }
}
