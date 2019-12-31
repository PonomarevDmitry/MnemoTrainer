using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineNumberGenerator
    {
        #region Внутренние поля.

        Random rnd = new Random();

        DateTime testStartDate;

        private int testCount = 0;

        private Timer timerCheckAnswer;
        private Timer timerHideAndNextQuestion;
        private Timer timerPause;

        private QuestionGeneratorNumberGenerator generator = new QuestionGeneratorNumberGenerator();

        #endregion Внутренние поля.

        public string QuestionText
        {
            get { return this.generator.QuestionText; }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainQuestionNew;

        public event EventHandler TrainQuestionHided;

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

        protected void OnTrainQuestionNew(EventArgs args)
        {
            if (TrainQuestionNew != null)
            {
                TrainQuestionNew(this, args);
            }
        }

        protected void OnTrainQuestionHided(EventArgs args)
        {
            if (TrainQuestionHided != null)
            {
                TrainQuestionHided(this, args);
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

        private bool isAutoShowing = false;
        public virtual bool IsAutoShowing
        {
            get { return this.isAutoShowing; }
            set
            {
                bool changed = this.isAutoShowing != value;

                this.isAutoShowing = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual int TimeShowing
        {
            get { return this.timerHideAndNextQuestion.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                bool changed = this.timerHideAndNextQuestion.Interval != value;

                this.timerHideAndNextQuestion.Interval = value;
                if (changed && this.isAutoShowing)
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
                if (changed && !this.isAutoShowing)
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
                if (changed && this.isAutoAnswer && !this.isAutoShowing)
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

        #region Диапазон значений.

        public virtual bool IsRangeEnabled
        {
            get { return this.generator.IsRangeEnabled; }
            set
            {
                bool changed = this.generator.IsRangeEnabled != value;

                this.generator.IsRangeEnabled = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int MinNumber
        {
            get { return this.generator.MinNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MinNumber");
                }

                bool changed = this.generator.MinNumber != value;

                this.generator.MinNumber = value;
                if (changed && this.IsRangeEnabled)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int MaxNumber
        {
            get { return this.generator.MaxNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxNumber");
                }

                bool changed = this.generator.MaxNumber != value;

                this.generator.MaxNumber = value;
                if (changed && this.IsRangeEnabled)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Диапазон значений.

        #region Сетки.

        public static ReadOnlyCollection<Net> SourceNets { get; private set; }

        public void SetCheckState(int index, bool state)
        {
            this.generator.SetCheckState(index, state);
            settingsIsChanged();
        }

        public bool GetCheckState(int index)
        {
            return this.generator.GetCheckState(index);
        }

        public void SetCheckState(Net net, bool state)
        {
            int index = SourceNets.IndexOf(net);
            if (index != -1)
            {
                SetCheckState(index, state);
            }
        }

        public bool GetCheckState(Net net)
        {
            return this.generator.GetCheckState(net);
        }

        #endregion Сетки.

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineNumberGenerator()
        {
            timerHideAndNextQuestion = new Timer();
            timerHideAndNextQuestion.Interval = 1000;
            timerHideAndNextQuestion.Tick += new EventHandler(timerHideAndNextQuestion_Tick);

            timerCheckAnswer = new Timer();
            timerCheckAnswer.Interval = 20000;
            timerCheckAnswer.Tick += new EventHandler(timerCheckAnswer_Tick);

            timerPause = new Timer();
            timerPause.Interval = 800;
            timerPause.Tick += new EventHandler(timerPause_Tick);

            currentSerie = new ExerciseSerie(GetTrainType());
        }

        static TrainMachineNumberGenerator()
        {
            SourceNets = Net.FilteredNets;
        }

        #endregion Конструкторы.

        #region События таймеров.

        void timerHideAndNextQuestion_Tick(object sender, EventArgs e)
        {
            timerHideAndNextQuestion.Stop();

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

        private void PerformHideQuestion()
        {
            if (status == MachineStatus.ShowingQuestion)
            {
                OnTrainQuestionHided(new EventArgs());
                StartWaitingAnswer();
            }
            else if (status == MachineStatus.AutoShowing)
            {
                GenerateNewQuestion();
            }
        }

        private void PerformAutoCheckAnswer()
        {
            this.status = MachineStatus.AutoCheckingAnswer;

            AutoCheckEventArgs args = new AutoCheckEventArgs();

            OnTrainAnswerAutoCheck(args);

            CheckAnswer(true, args.UserAnswer);
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

        #endregion События таймеров.

        public void MakeAction(string userText)
        {
            if (CanGetNewQuestion)
            {
                GenerateNewQuestion();
            }
            if (CanWriteAnswer)
            {
                CheckAnswer(false, userText);
            }
        }

        private void GenerateNewQuestion()
        {
            this.generator.CreateNewQuestion();
            testCount++;

            timerHideAndNextQuestion.Stop();
            timerCheckAnswer.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                if (this.isAutoShowing)
                {
                    testStartDate = DateTime.Now;
                }

                OnTrainStarted(new EventArgs());
            }

            OnTrainQuestionNew(new EventArgs());

            if (this.isAutoShowing)
            {
                status = MachineStatus.AutoShowing;
            }
            else
            {
                status = MachineStatus.ShowingQuestion;
            }

            timerHideAndNextQuestion.Start();
        }

        private void CheckAnswer(bool autoTimer, string userAnswer)
        {
            timerHideAndNextQuestion.Stop();
            timerCheckAnswer.Stop();

            DateTime testEndDate = DateTime.Now;

            double time = (testEndDate - testStartDate).TotalSeconds;

            bool isAnswerRight = false;
            string answerText = string.Empty;
            string userAnswerText = string.Empty;

            this.generator.CheckAnswer(userAnswer, out isAnswerRight, out answerText, out userAnswerText);

            currentSerie.Attempts.Add(new ExerciseAttempt(TrainType.NumberGenerator, this.testStartDate, time, autoTimer, answerText, string.Empty, isAnswerRight, userAnswer));

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
            return string.Compare(rightAnswer, answer) == 0;
        }

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.ShowingError || this.status == MachineStatus.NotStarted; }
        }

        public bool CanWriteAnswer
        {
            get { return this.status == MachineStatus.WaitingAnswer; }
        }

        public virtual void Stop()
        {
            testCount = 0;

            timerPause.Stop();
            timerHideAndNextQuestion.Stop();
            timerCheckAnswer.Stop();

            if (status != MachineStatus.NotStarted)
            {
                if (status == MachineStatus.AutoShowing)
                {
                    DateTime dateEnd = DateTime.Now;

                    double time = (dateEnd - this.testStartDate).TotalSeconds;

                    ExerciseAttempt newAttept = new ExerciseAttempt(TrainType.NumberGenerator, this.testStartDate, time, false, string.Empty, string.Empty, true, string.Empty);
                    newAttept.DateEnd = dateEnd;
                    newAttept.TestCount = testCount;

                    currentSerie.Attempts.Add(newAttept);
                }

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
            ExerciseTypeNumberGenerator type = new ExerciseTypeNumberGenerator();

            type.SymbolsCount = this.SymbolsCount;
            type.AutoShowingMode = this.isAutoShowing;

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
