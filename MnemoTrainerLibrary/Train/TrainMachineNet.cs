using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineNet
    {
        #region Внутренние поля.

        DateTime testStartDate;

        private Timer timerHide;
        private Timer timerPause;

        private QuestionGeneratorNet generator = new QuestionGeneratorNet();

        #endregion Внутренние поля.

        public string AnswerText
        {
            get { return this.generator.AnswerText; }
        }

        public string QuestionText
        {
            get { return this.generator.QuestionText; }
        }

        private bool showingRightAnswer = false;

        public Color? ForeColor
        {
            get { return this.generator.ForeColor; }
        }

        public Color? BackColor
        {
            get { return this.generator.BackColor; }
        }

        public int NetTestCount
        {
            get { return this.generator.NetTestCount; }
        }

        public int LapsCount
        {
            get { return this.generator.LapsCount; }
        }

        public int AskedQuestionsCount
        {
            get { return this.generator.AskedQuestionsCount; }
        }

        public NetTestType CurrentElementTestType
        {
            get
            {
                if (this.generator.CurrentElement != null)
                {
                    return this.generator.CurrentElement.TestType;
                }
                else
                {
                    return NetTestType.None;
                }
            }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainQuestionNew;

        public event EventHandler TrainQuestionHided;

        public event EventHandler TrainShowRightAnswer;

        public event EventHandler TrainShowErrorMessage;

        public event EventHandler TrainStoped;

        public event EventHandler NetTestCountChanged;

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

        protected void OnTrainShowRightAnswer(EventArgs args)
        {
            if (TrainShowRightAnswer != null)
            {
                TrainShowRightAnswer(this, args);
            }
        }

        protected void OnTrainShowErrorMessage(EventArgs args)
        {
            if (TrainShowErrorMessage != null)
            {
                TrainShowErrorMessage(this, args);
            }
        }

        protected void OnTrainStoped(EventArgs args)
        {
            if (TrainStoped != null)
            {
                TrainStoped(this, args);
            }
        }

        protected void OnNetTestCountChanged(EventArgs args)
        {
            if (NetTestCountChanged != null)
            {
                NetTestCountChanged(this, args);
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

        public NetTestType TestType
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

        public virtual bool WithCalculations
        {
            get { return this.generator.WithCalculations; }
            set
            {
                bool changed = this.generator.WithCalculations != value;

                this.generator.WithCalculations = value;
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
            int index = QuestionGeneratorNet.SourceNets.IndexOf(net);
            if (index != -1)
            {
                SetCheckState(index, state);
            }
        }

        public bool GetCheckState(Net net)
        {
            int index = QuestionGeneratorNet.SourceNets.IndexOf(net);
            if (index != -1)
            {
                return GetCheckState(index);
            }

            return false;
        }

        #endregion Сетки.

        #endregion Свойства.

        #region Конструкторы.

        public TrainMachineNet()
        {
            timerHide = new Timer();
            timerHide.Interval = 1000;
            timerHide.Tick += new EventHandler(timerHide_Tick);

            timerPause = new Timer();
            timerPause.Interval = 400;
            timerPause.Tick += new EventHandler(timerPause_Tick);

            currentSerie = new ExerciseSerie(GetTrainType());
        }

        static TrainMachineNet()
        {
            SourceNets = QuestionGeneratorNet.SourceNets;
        }

        #endregion Конструкторы.

        #region События таймеров.

        void timerHide_Tick(object sender, EventArgs e)
        {
            timerHide.Stop();

            PerformHideQuestion();
        }

        void timerPause_Tick(object sender, EventArgs e)
        {
            timerPause.Stop();

            GenerateNewQuestion();
        }

        private void PerformHideQuestion()
        {
            OnTrainQuestionHided(new EventArgs());

            StartWaitingAnswer();
        }

        private void StartWaitingAnswer()
        {
            testStartDate = DateTime.Now;
            status = MachineStatus.WaitingAnswer;
        }

        #endregion События таймеров.

        public void MakeAction(string userText)
        {
            if (CanGetNewQuestion)
            {
                GenerateNewQuestion();
            }
            else if (CanWriteAnswer)
            {
                CheckAnswer(userText);
            }
        }

        public void ShowRightAnswer()
        {
            if (CanWriteAnswer)
            {
                this.showingRightAnswer = true;
                this.status = MachineStatus.AutoShowing;

                OnTrainShowRightAnswer(new EventArgs());
            }
        }

        private void GenerateNewQuestion()
        {
            timerHide.Stop();
            timerPause.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                OnTrainStarted(new EventArgs());
            }

            showingRightAnswer = false;

            this.generator.CreateNewQuestion();

            OnTrainQuestionNew(new EventArgs());

            if (this.isHideQuestion)
            {
                status = MachineStatus.ShowingQuestion;
                timerHide.Start();
            }
            else
            {
                StartWaitingAnswer();
            }
        }

        private void CheckAnswer(string userAnswer)
        {
            timerHide.Stop();

            bool nextWord = this.showingRightAnswer;

            if (!nextWord)
            {
                if (this.generator.CurrentElement.TestType == NetTestType.Pattern)
                {
                    this.generator.CheckAnswer(userAnswer, out nextWord);
                }
                else
                {
                    nextWord = true;
                }
            }

            if (nextWord)
            {
                bool answerIsRight = !this.showingRightAnswer;

                DateTime testEndDate = DateTime.Now;

                double time = (testEndDate - testStartDate).TotalSeconds;

                string logQuestion = string.Empty;
                string logAnswer = string.Empty;

                if (this.generator.CurrentElement.TestType == NetTestType.Pattern)
                {
                    logQuestion = this.generator.CurrentElement.Answer;
                    logAnswer = this.generator.CurrentElement.Question;
                }
                else if (this.generator.CurrentElement.TestType == NetTestType.Number)
                {
                    logQuestion = this.generator.CurrentElement.Question;
                    logAnswer = this.generator.CurrentElement.Answer;
                }

                currentSerie.Attempts.Add(new ExerciseAttemptNetTrain(this.generator.CurrentElement.TestType, this.testStartDate, time, false, logQuestion, logAnswer, this.generator.CurrentElement.BaseUnit.NetName, answerIsRight, string.Empty));

                status = MachineStatus.Pause;

                if (this.generator.CurrentElement.TestType == NetTestType.Pattern)
                {
                    OnTrainShowRightAnswer(new EventArgs());
                    timerPause.Start();
                }
                else
                {
                    GenerateNewQuestion();
                }
            }
            else
            {
                OnTrainShowErrorMessage(new EventArgs());
            }
        }

        private bool CompareAnswers(string rightAnswer, string userAnswer)
        {
            return string.Compare(rightAnswer, userAnswer, true) == 0;
        }

        public virtual void Stop()
        {
            timerPause.Stop();
            timerHide.Stop();

            if (status != MachineStatus.NotStarted)
            {
                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());
            }
        }

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.AutoShowing || this.status == MachineStatus.NotStarted; }
        }

        public bool CanWriteAnswer
        {
            get { return this.status == MachineStatus.WaitingAnswer; }
        }

        private void settingsIsChanged()
        {
            this.Stop();

            this.generator.CreateQuestionCollection();

            OnNetTestCountChanged(new EventArgs());

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
            return new ExerciseTypeNetTrain();
        }

        #endregion Логирование упражнения.
    }
}
