using System;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainSecondArrowAttention : Form
    {
        private TrainMachineSecondArrow train;

        public FormTrainSecondArrowAttention()
        {
            InitializeComponent();

            LoadFormConfiguration();

            train = new TrainMachineSecondArrow();
            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainStoped += new EventHandler(train_TrainStoped);

            clock.Select();
        }

        #region Обработчики событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            clock.Current = DateTime.Now;
            clock.Visible = true;

            timer.Start();
            tSSTestTimer.StartNew();
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            clock.Visible = false;

            timer.Stop();
            tSSTestTimer.Stop();
        }

        #endregion Обработчики событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Таймеры.

        private void timer_Tick(object sender, EventArgs e)
        {
            clock.Current = DateTime.Now;
        }

        #endregion Таймеры.

        private void FormSecondArrowAttentionTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (train.TestEnabled)
                {
                    train.Stop();
                }
                else
                {
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                PerformAction();
            }
        }

        private void clock_Click(object sender, EventArgs e)
        {
            PerformAction();
        }

        private void PerformAction()
        {
            if (train.TestEnabled)
            {
                train.Stop();
            }
            else
            {
                train.Start();
            }
        }
    }
}
