using System;
using System.Drawing;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineStrup
    {
        QuestionGeneratorStrup generator = new QuestionGeneratorStrup();

        private Timer timerNextQuestion;

        private DateTime testStartTime;

        public TrainMachineStrup()
        {
            timerNextQuestion = new Timer();
            timerNextQuestion.Interval = 1000;
            timerNextQuestion.Tick += new EventHandler(timerNextQuestion_Tick);

            currentSerie = new ExerciseSerie(GetTrainType());
        }

        void timerNextQuestion_Tick(object sender, EventArgs e)
        {
            timerNextQuestion.Stop();
            PerformNextQuestion();
        }

        #region Свойства.

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

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
            get { return this.timerNextQuestion.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                bool changed = this.timerNextQuestion.Interval != value;

                this.timerNextQuestion.Interval = value;
                if (changed && this.isAutoShowing)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public string CurrentColorName
        {
            get { return this.generator.CurrentColorName; }
        }

        public Color? CurrentColor
        {
            get { return this.generator.CurrentColor; }
        }

        private int testCount = 0;
        public int TestCount
        {
            get { return this.testCount; }
        }

        #endregion Свойства.

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainQuestionNew;

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

        protected void OnTrainStoped(EventArgs args)
        {
            if (TrainStoped != null)
            {
                TrainStoped(this, args);
            }
        }

        #endregion События.

        public bool CanGetNewQuestion
        {
            get { return this.status == MachineStatus.ShowingQuestion || this.status == MachineStatus.NotStarted; }
        }

        public void ShowNextQuestion()
        {
            if (CanGetNewQuestion)
            {
                PerformNextQuestion();
            }
        }

        private void PerformNextQuestion()
        {
            timerNextQuestion.Stop();

            if (status == MachineStatus.NotStarted)
            {
                testCount = 0;
                testStartTime = DateTime.Now;
                OnTrainStarted(new EventArgs());
            }

            this.generator.CreateNewQuestion();

            testCount++;

            if (this.isAutoShowing)
            {
                status = MachineStatus.AutoShowing;

                timerNextQuestion.Start();
            }
            else
            {
                status = MachineStatus.ShowingQuestion;
            }

            OnTrainQuestionNew(new EventArgs());
        }

        private void settingsIsChanged()
        {
            this.Stop();

            UpdateExerciseSerie();
        }

        public void Stop()
        {
            timerNextQuestion.Stop();

            if (status != MachineStatus.NotStarted)
            {
                DateTime testEndDate = DateTime.Now;

                double time = (testEndDate - testStartTime).TotalSeconds;

                ExerciseAttempt tmp = new ExerciseAttempt(TrainType.Strup, testStartTime, time, false, string.Empty, string.Empty, true, string.Empty);
                tmp.DateEnd = testEndDate;
                tmp.TestCount = testCount;

                currentSerie.Attempts.Add(tmp);

                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());
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
            ExerciseTypeStrup type = new ExerciseTypeStrup();

            type.AutoShowingMode = this.isAutoShowing;

            if (type.AutoShowingMode)
            {
                type.ShowTime = this.timerNextQuestion.Interval;
            }

            return type;
        }

        #endregion Логирование упражнения.
    }
}
