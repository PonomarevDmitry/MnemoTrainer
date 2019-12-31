using System;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineSecondArrow
    {
        private DateTime dateStart;
        private ExerciseSerie currentSerie;

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

        public bool TestEnabled
        {
            get { return this.status != MachineStatus.NotStarted; }
        }

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainStoped;

        protected void OnTrainStarted(EventArgs args)
        {
            if (TrainStarted != null)
            {
                TrainStarted(this, args);
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

        #region Конструкторы.

        public TrainMachineSecondArrow()
        {
            currentSerie = new ExerciseSerie(new ExerciseTypeSecondArrowAttention());
        }

        #endregion Конструкторы.

        public virtual void Start()
        {
            if (status == MachineStatus.NotStarted)
            {
                dateStart = DateTime.Now;

                status = MachineStatus.ShowingQuestion;

                OnTrainStarted(new EventArgs());
            }
        }

        public virtual void Stop()
        {
            if (status != MachineStatus.NotStarted)
            {
                DateTime dateEnd = DateTime.Now;

                double time = (dateEnd - dateStart).TotalSeconds;

                ExerciseAttempt tmp = new ExerciseAttempt(TrainType.SecondArrowAttention, dateStart, time, false, string.Empty, string.Empty, true, string.Empty);
                tmp.DateEnd = dateEnd;

                currentSerie.Attempts.Add(tmp);

                status = MachineStatus.NotStarted;
                OnTrainStoped(new EventArgs());
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

                currentSerie = new ExerciseSerie(new ExerciseTypeSecondArrowAttention());
            }
        }
    }
}
