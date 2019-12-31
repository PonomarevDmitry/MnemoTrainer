using System;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineReading
    {
        private Timer timerNextBook;
        private Timer timerPause;

        //bool pauseIsGoing = false;

        private DateTime testStartTime;
        private ExerciseSerie currentSerie = new ExerciseSerie(new ExerciseTypeInterruptionReading());

        public TrainMachineReading()
        {
            timerNextBook = new Timer();
            timerNextBook.Interval = bookIntervals[0];
            timerNextBook.Tick += new EventHandler(timerNextBook_Tick);

            timerPause = new Timer();
            timerPause.Interval = 5000;
            timerPause.Tick += new EventHandler(timerPause_Tick);
        }

        #region Обработчики событий таймеров.

        void timerNextBook_Tick(object sender, EventArgs e)
        {
            timerNextBook.Stop();

            currentIndex++;
            if (currentIndex >= BookCount)
            {
                currentIndex = 0;
            }

            //pauseIsGoing = true;
            timerPause.Start();

            OnBookEnd(new EventArgs());
        }

        void timerPause_Tick(object sender, EventArgs e)
        {
            timerPause.Stop();
            //pauseIsGoing = false;

            StartNextBook();
        }

        #endregion Обработчики событий таймеров.

        #region Свойства.

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

        private int[] bookIntervals = new int[2] { 1 * 60 * 1000, 4 * 60 * 1000 };
        public int this[int index]
        {
            get { return bookIntervals[index]; }
            set
            {
                bookIntervals[index] = value;
                this.settingsIsChanged();
            }
        }

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return this.currentIndex; }
        }

        public int BookCount
        {
            get { return bookIntervals.Length; }
        }

        private int startIndex = 0;
        public int StartIndex
        {
            get { return this.startIndex; }
            set
            {
                if (value < 0 || value >= BookCount)
                {
                    throw new ArgumentOutOfRangeException("StartIndex");
                }

                this.startIndex = value;
                this.settingsIsChanged();
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

                this.timerPause.Interval = value;
                this.settingsIsChanged();
            }
        }

        private bool withInterruption = true;
        public bool WithInterruption
        {
            get { return this.withInterruption; }
            set
            {
                this.withInterruption = value;
                this.settingsIsChanged();
            }
        }

        #endregion Свойства.

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler BookBegin;

        public event EventHandler BookEnd;

        public event EventHandler TrainStoped;

        protected void OnTrainStarted(EventArgs args)
        {
            if (TrainStarted != null)
            {
                TrainStarted(this, args);
            }
        }

        protected void OnBookBegin(EventArgs args)
        {
            if (BookBegin != null)
            {
                BookBegin(this, args);
            }
        }

        protected void OnBookEnd(EventArgs args)
        {
            if (BookEnd != null)
            {
                BookEnd(this, args);
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

        public bool IsTrainEnabled
        {
            get { return this.status != MachineStatus.NotStarted; }
        }

        private void settingsIsChanged()
        {
            this.Stop();
        }

        public virtual void Start()
        {
            timerPause.Stop();
            timerNextBook.Stop();

            if (this.status == MachineStatus.NotStarted)
            {
                testStartTime = DateTime.Now;

                this.currentIndex = this.startIndex;

                this.status = MachineStatus.AutoShowing;

                OnTrainStarted(new EventArgs());

                if (this.withInterruption)
                {
                    StartNextBook();
                }
            }
        }

        public virtual void Stop()
        {
            timerPause.Stop();
            timerNextBook.Stop();

            if (status != MachineStatus.NotStarted)
            {
                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());

                DateTime dateEnd = DateTime.Now;

                double time = (dateEnd - testStartTime).TotalSeconds;

                ExerciseAttempt tmp = new ExerciseAttempt(TrainType.InterruptionReading, testStartTime, time, false, string.Empty, string.Empty, true, string.Empty);
                tmp.DateEnd = dateEnd;

                currentSerie.Attempts.Add(tmp);
            }
        }

        private void StartNextBook()
        {
            timerNextBook.Interval = bookIntervals[currentIndex];

            timerNextBook.Start();

            OnBookBegin(new EventArgs());
        }

        #region Логирование.

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

                currentSerie = new ExerciseSerie(new ExerciseTypeInterruptionReading());
            }
        }

        #endregion Логирование.
    }
}
