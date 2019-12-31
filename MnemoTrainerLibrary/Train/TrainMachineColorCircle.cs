using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineColorCircle
    {
        Random rnd = new Random();

        private Color[] baseColors = new Color[] 
        {   
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.DeepSkyBlue,
            Color.Blue, 
            Color.Purple,
            Color.Black,
            Color.White,
            Color.Gray,
            Color.HotPink,
            Color.Silver,
            Color.Brown
        };

        private Collection<Color> questionCollection = new Collection<Color>();

        private Timer timerHide;
        private Timer timerNextCircle;

        public TrainMachineColorCircle()
        {
            timerHide = new Timer();
            timerHide.Interval = 10000;
            timerHide.Tick += new EventHandler(timerHide_Tick);

            timerNextCircle = new Timer();
            timerNextCircle.Interval = 30000;
            timerNextCircle.Tick += new EventHandler(timerNextCircle_Tick);
        }

        #region Свойства.

        private Color currentColor;
        public Color CurrentColor
        {
            get { return this.currentColor; }
        }

        public int ColorCount
        {
            get { return baseColors.Length; }
        }

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return this.currentIndex + 1; }
        }

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

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

        private bool isAutoNextCircle = false;
        public bool IsAutoNextCircle
        {
            get { return this.isAutoNextCircle; }
            set
            {
                bool changed = this.isAutoNextCircle != value;

                this.isAutoNextCircle = value;
                if (changed)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public int TimeNextCircle
        {
            get { return this.timerNextCircle.Interval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeNextCircle");
                }

                bool changed = this.timerNextCircle.Interval != value;

                this.timerNextCircle.Interval = value;
                if (changed && this.isAutoNextCircle)
                {
                    this.settingsIsChanged();
                }
            }
        }

        public bool IsTrainEnabled
        {
            get { return this.status != MachineStatus.NotStarted; }
        }

        #endregion Свойства.

        #region События.

        public event EventHandler TrainStarted;

        public event EventHandler TrainQuestionShowed;

        public event EventHandler TrainQuestionHided;

        public event EventHandler TrainEnded;

        public event EventHandler TrainStoped;

        protected void OnTrainStarted(EventArgs args)
        {
            if (TrainStarted != null)
            {
                TrainStarted(this, args);
            }
        }

        protected void OnTrainQuestionHided(EventArgs args)
        {
            if (TrainQuestionHided != null)
            {
                TrainQuestionHided(this, args);
            }
        }

        protected void OnTrainQuestionShowed(EventArgs args)
        {
            if (TrainQuestionShowed != null)
            {
                TrainQuestionShowed(this, args);
            }
        }

        protected void OnTrainEnded(EventArgs args)
        {
            if (TrainEnded != null)
            {
                TrainEnded(this, args);
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

        void timerHide_Tick(object sender, EventArgs e)
        {
            ShowNextQuestion();
        }

        void timerNextCircle_Tick(object sender, EventArgs e)
        {
            ShowNextQuestion();
        }

        private void settingsIsChanged()
        {
            this.Stop();
        }

        public virtual void ShowNextQuestion()
        {
            timerHide.Stop();
            timerNextCircle.Stop();

            if (status == MachineStatus.NotStarted)
            {
                GenerateNewColorQuestions();

                status = MachineStatus.WaitingAnswer;

                currentIndex = -1;

                OnTrainStarted(new EventArgs());
            }

            if (status == MachineStatus.WaitingAnswer)
            {
                currentIndex++;

                if (currentIndex < questionCollection.Count)
                {
                    this.currentColor = questionCollection[currentIndex];

                    status = MachineStatus.ShowingQuestion;

                    OnTrainQuestionShowed(new EventArgs());

                    if (this.isHideQuestion)
                    {
                        timerHide.Start();
                    }
                }
                else
                {
                    status = MachineStatus.NotStarted;

                    OnTrainEnded(new EventArgs());
                }
            }
            else if (status == MachineStatus.ShowingQuestion)
            {
                status = MachineStatus.WaitingAnswer;

                OnTrainQuestionHided(new EventArgs());

                if (this.isAutoNextCircle)
                {
                    timerNextCircle.Start();
                }
            }
        }

        public virtual void Stop()
        {
            timerHide.Stop();
            timerNextCircle.Stop();

            if (status != MachineStatus.NotStarted)
            {
                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());
            }
        }

        private void GenerateNewColorQuestions()
        {
            questionCollection.Clear();

            Collection<Color> temp = new Collection<Color>();
            for (int i = 0; i < baseColors.Length; i++)
            {
                temp.Add(baseColors[i]);
            }

            while (temp.Count > 0)
            {
                int ind = rnd.Next(temp.Count);

                questionCollection.Add(temp[ind]);
                temp.RemoveAt(ind);
            }
        }
    }
}
