using System;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineCalculate
    {
        #region Внутренние поля.

        QuestionGeneratorCalculate generator = new QuestionGeneratorCalculate();

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

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

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

        public TrainTypeCalculate TestType
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

        #region Сумма цифр.

        public virtual bool WithNegativ
        {
            get { return this.generator.WithNegativ; }
            set
            {
                bool changed = this.generator.WithNegativ != value;

                this.generator.WithNegativ = value;
                if (changed && TestType == TrainTypeCalculate.Sum)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int SummandCount
        {
            get { return this.generator.SummandCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SummandCount");
                }

                bool changed = this.generator.SummandCount != value;

                this.generator.SummandCount = value;
                if (changed && this.TestType == TrainTypeCalculate.Sum)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Сумма цифр.

        #region Умножение и сложение.

        public int LeftMultiplyMin
        {
            get { return this.generator.LeftMultiplyMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("LeftMultiplyMin");
                }

                bool changed = this.generator.LeftMultiplyMin != value;

                this.generator.LeftMultiplyMin = value;
                if (changed && TestType != TrainTypeCalculate.Multiplication)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int LeftMultiplyMax
        {
            get { return this.generator.LeftMultiplyMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("LeftMultiplyMax");
                }

                bool changed = this.generator.LeftMultiplyMax != value;

                this.generator.LeftMultiplyMax = value;
                if (changed && TestType != TrainTypeCalculate.Multiplication)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int RightMultiplyMin
        {
            get { return this.generator.RightMultiplyMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RightMultiplyMin");
                }

                bool changed = this.generator.RightMultiplyMin != value;

                this.generator.RightMultiplyMin = value;
                if (changed && TestType != TrainTypeCalculate.Multiplication)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int RightMultiplyMax
        {
            get { return this.generator.RightMultiplyMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RightMultiplyMax");
                }

                bool changed = this.generator.RightMultiplyMax != value;

                this.generator.RightMultiplyMax = value;
                if (changed && TestType != TrainTypeCalculate.Multiplication)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Умножение и сложение.

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineCalculate()
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
            OnTrainQuestionHided(new EventArgs());

            testStartDate = DateTime.Now;

            StartWaitingAnswer();
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
            status = MachineStatus.WaitingAnswer;

            if (this.isAutoAnswer)
            {
                timerCheckAnswer.Start();
            }
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
            if (TestType == TrainTypeCalculate.Multiplication)
            {
                CheckMultiplicationConditions();
            }

            this.generator.CreateNewQuestion();

            timerHide.Stop();
            timerCheckAnswer.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                OnTrainStarted(new EventArgs());
            }

            OnTrainQuestionNew(new EventArgs());

            if (this.isHideQuestion)
            {
                status = MachineStatus.ShowingQuestion;
                timerHide.Start();
            }
            else
            {
                testStartDate = DateTime.Now;
                StartWaitingAnswer();
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

            currentSerie.Attempts.Add(new ExerciseAttempt(TrainType.Calculate, this.testStartDate, time, autoTimer, this.generator.QuestionText, this.generator.AnswerValue.ToString(), isAnswerRight, userAnswerText));

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

        private bool CompareAnswers(int rightAnswer, int? answer)
        {
            return answer.HasValue && rightAnswer == answer.Value;
        }

        public bool CanWriteAnswer
        {
            get { return this.status == MachineStatus.WaitingAnswer || this.status == MachineStatus.ShowingQuestion; }
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

        private void CheckMultiplicationConditions()
        {
            if (this.generator.LeftMultiplyMax > this.generator.LeftMultiplyMin)
            {
                this.generator.LeftMultiplyMin = 1;
                this.generator.LeftMultiplyMax = 99;
            }

            if (this.generator.RightMultiplyMax > this.generator.RightMultiplyMin)
            {
                this.generator.RightMultiplyMin = 1;
                this.generator.RightMultiplyMax = 99;
            }
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
            ExerciseTypeCalculate exerciseTypeDate = new ExerciseTypeCalculate();

            exerciseTypeDate.TestType = this.TestType;

            if (this.TestType == TrainTypeCalculate.Sum)
            {
                exerciseTypeDate.WithNegativ = this.WithNegativ;
                exerciseTypeDate.SummandCount = this.SummandCount;
            }

            if (this.isHideQuestion)
            {
                exerciseTypeDate.ShowTime = this.TimeShowing;
            }

            if (this.isAutoAnswer)
            {
                exerciseTypeDate.AutoAnswerCheckTime = this.TimeForAnswer;
            }

            return exerciseTypeDate;
        }

        #endregion Логирование упражнения.
    }
}
