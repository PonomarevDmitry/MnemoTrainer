using System;
using System.Collections.Generic;
using System.Text;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.QuestionGenerator;
using System.Windows.Forms;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineCalculateSeries
    {
        #region Внутренние поля.

        QuestionGeneratorCalculateSeries generator = new QuestionGeneratorCalculateSeries();

        DateTime testStartDate;

        private Timer timerCheckAnswer;
        private Timer timerHide;

        #endregion Внутренние поля.

        public int QuestionIndex
        {
            get { return this.generator.QuestionIndex; }
        }

        public int AnswerValue
        {
            get { return this.generator.AnswerValue; }
        }

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

        #endregion Свойства процесса.

        public virtual bool WithAddition
        {
            get { return this.generator.WithAddition; }
            set
            {
                bool changed = this.generator.WithAddition != value;

                this.generator.WithAddition = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public virtual bool WithMultiplication
        {
            get { return this.generator.WithMultiplication; }
            set
            {
                bool changed = this.generator.WithMultiplication != value;

                this.generator.WithMultiplication = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int SeriesCount
        {
            get { return this.generator.SeriesCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SeriesCount");
                }

                bool changed = this.generator.SeriesCount != value;

                this.generator.SeriesCount = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #region Сложение.

        public int AdditionRange
        {
            get { return this.generator.AdditionRange; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("AdditionRange");
                }

                bool changed = this.generator.AdditionRange != value;

                this.generator.AdditionRange = value;
                if (changed && this.WithAddition)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Сложение.

        #region Умножение.

        public int MultiplyMin
        {
            get { return this.generator.MultiplyMin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MultiplyMin");
                }

                bool changed = this.generator.MultiplyMin != value;

                this.generator.MultiplyMin = value;
                if (changed && this.generator.WithMultiplication)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int MultiplyMax
        {
            get { return this.generator.MultiplyMax; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MultiplyMax");
                }

                bool changed = this.generator.MultiplyMax != value;

                this.generator.MultiplyMax = value;
                if (changed && this.WithMultiplication)
                {
                    this.settingsIsChanged();
                }
            }
        }

        #endregion Умножение.

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineCalculateSeries()
        {
            timerHide = new Timer();
            timerHide.Interval = 1000;
            timerHide.Tick += new EventHandler(timerHide_Tick);

            timerCheckAnswer = new Timer();
            timerCheckAnswer.Interval = 20000;
            timerCheckAnswer.Tick += new EventHandler(timerCheckAnswer_Tick);

            //currentSerie = new ExerciseSerie(GetTrainType());
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

        //public void MakeAction(string userString)
        //{
        //    if (CanGetNewQuestion)
        //    {
        //        GenerateNewQuestion();
        //    }
        //    //else if (CanHideQuestion)
        //    //{
        //    //    PerformHideQuestion();
        //    //}
        //    else if (CanWriteAnswer)
        //    {
        //        CheckAnswer(false, userString);
        //    }
        //}

        public void ShowNextQuestion()
        {
            if (CanGetNewQuestion)
            {
                GenerateNewQuestion();
            }
        }

        private void GenerateNewQuestion()
        {
            if (this.WithMultiplication)
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

            int? userAnswerInt = null;
            int tempInt = 0;

            if (int.TryParse(userAnswer, out tempInt))
            {
                userAnswerInt = tempInt;
            }

            bool isAnswerRight = false;
            string answerText = string.Empty;
            string userAnswerText = string.Empty;

            this.generator.CheckAnswer(userAnswer, out isAnswerRight, out answerText, out userAnswerText);

            //currentSerie.Attempts.Add(new ExerciseAttempt(TrainType.Calculate, this.testStartDate, time, autoTimer, this.generator.QuestionText, this.generator.AnswerValue.ToString(), isAnswerRight, userAnswerText));

            status = MachineStatus.Pause;

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
            get { return this.status == MachineStatus.Pause || this.status == MachineStatus.NotStarted; }
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
            this.generator.Clear();

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
            this.Stop();

            UpdateExerciseSerie();
        }

        private void CheckMultiplicationConditions()
        {
            if (this.generator.MultiplyMin > this.generator.MultiplyMax)
            {
                this.generator.MultiplyMin = 1;
                this.generator.MultiplyMax = 20;
            }
        }

        #region Логирование упражнения.

        //private ExerciseSerie currentSerie;

        private void UpdateExerciseSerie()
        {
            //ExerciseType type = GetTrainType();

            //if (!currentSerie.Type.Equals(type))
            //{
            //    SaveExeruciseSerie();

            //    currentSerie = new ExerciseSerie(type);
            //}
        }

        //public void SaveExeruciseSerie()
        //{
        //    if (status != MachineStatus.NotStarted)
        //    {
        //        this.Stop();
        //    }

        //    if (currentSerie.Attempts.Count > 0)
        //    {
        //        LogExercise.AddNewExerciseSerie(currentSerie);
        //        LogExercise.SaveProgramsLogs();

        //        currentSerie = new ExerciseSerie(GetTrainType());
        //    }
        //}

        //private ExerciseType GetTrainType()
        //{
        //    ExerciseTypeCalculate exerciseTypeDate = new ExerciseTypeCalculate();

        //    exerciseTypeDate.TestType = this.TestType;

        //    if (this.TestType == TrainTypeCalculate.Sum)
        //    {
        //        exerciseTypeDate.WithNegativ = this.WithAddition;
        //        exerciseTypeDate.SummandCount = this.SummandCount;
        //    }

        //    if (this.isHideQuestion)
        //    {
        //        exerciseTypeDate.ShowTime = this.TimeShowing;
        //    }

        //    if (this.isAutoAnswer)
        //    {
        //        exerciseTypeDate.AutoAnswerCheckTime = this.TimeForAnswer;
        //    }

        //    return exerciseTypeDate;
        //}

        #endregion Логирование упражнения.
    }
}
