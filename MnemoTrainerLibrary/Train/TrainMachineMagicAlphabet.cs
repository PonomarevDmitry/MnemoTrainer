using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.QuestionGenerator;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachineMagicAlphabet
    {
        QuestionGeneratorMagicAlphabet generator = new QuestionGeneratorMagicAlphabet();

        private Collection<MagicLetter> questionCollection;

        private Timer timerTest;

        #region Свойства.

        private MachineStatus status = MachineStatus.NotStarted;
        public MachineStatus Status
        {
            get { return this.status; }
        }

        private int timeShowing = 2000;
        public virtual int TimeShowing
        {
            get { return this.timeShowing; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("TimeShowing");
                }

                this.timeShowing = value;
            }
        }

        public Order TestOrder
        {
            get { return this.generator.TestOrder; }
            set { this.generator.TestOrder = value; }
        }

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private int questionIndex = 0;
        public int QuestionIndex
        {
            get { return this.questionIndex + 1; }
        }

        #endregion Свойства.

        public TrainMachineMagicAlphabet()
        {
            timerTest = new Timer();
            timerTest.Interval = timeShowing;
            timerTest.Tick += new EventHandler(timerTest_Tick);
        }

        private void timerTest_Tick(object sender, EventArgs e)
        {
            if (status == MachineStatus.ShowingQuestion)
            {
                if (questionIndex == 0)
                {
                    timerTest.Stop();
                    timerTest.Interval = this.timeShowing;
                    timerTest.Start();
                }

                if (questionIndex >= questionCollection.Count)
                {
                    this.Stop();
                }
                else
                {
                    this.questionText = questionCollection[questionIndex].ToStringColumn();

                    OnTrainQuestionNew(new EventArgs());

                    questionIndex++;
                }
            }
        }

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

        public bool IsTrainEnabled()
        {
            return this.status != MachineStatus.NotStarted;
        }

        public virtual void Start()
        {
            if (status == MachineStatus.NotStarted)
            {
                status = MachineStatus.ShowingQuestion;

                questionIndex = 0;
                questionCollection = this.generator.GenerateAlphabet();

                OnTrainStarted(new EventArgs());

                Random rnd = new Random();

                int sleepTime = rnd.Next(500, 1500);
                timerTest.Interval = sleepTime;
                timerTest.Start();
            }
        }

        public virtual void Stop()
        {
            timerTest.Stop();

            this.questionText = string.Empty;

            if (status != MachineStatus.NotStarted)
            {
                status = MachineStatus.NotStarted;

                OnTrainStoped(new EventArgs());
            }
        }
    }
}
