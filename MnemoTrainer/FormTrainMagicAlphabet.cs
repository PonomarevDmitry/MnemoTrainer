using System;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainMagicAlphabet : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineMagicAlphabet train;

        public FormTrainMagicAlphabet()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            train = new TrainMachineMagicAlphabet();

            nUDVisibleTime.Value = train.TimeShowing;

            rbNormal.Checked = train.TestOrder == Order.Normal;
            rbInverse.Checked = train.TestOrder == Order.Inverse;
            rBRandom.Checked = train.TestOrder == Order.Random;

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);
            train.TrainStoped += new EventHandler(train_TrainStoped);

            lblTestWord.Text = string.Empty;
            lblTestWord.Select();

            LoadFormConfiguration();
        }

        void train_TrainStarted(object sender, EventArgs e)
        {
            tSSTotalTimer.ClearTimerText();

            DeactivateControls();
            lblTestWord.Text = string.Empty;
            tSSLCurrentIndex.Text = string.Empty;

            lblTestWord.Select();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            if (!tSSTotalTimer.IsTimerEnabled)
            {
                tSSTotalTimer.StartNew();
            }

            lblTestWord.Text = train.QuestionText;
            tSSLCurrentIndex.Text = string.Format("Элемент № {0}.", train.QuestionIndex.ToString());
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            tSSTotalTimer.Stop();

            ActivateControls();
            lblTestWord.Text = string.Empty;
            tSSLCurrentIndex.Text = string.Empty;
        }

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            int temp;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            rbNormal.Checked = LocalConfiguration.LoadControlCustomParameter(rbNormal, "Checked") == "1";
            rbInverse.Checked = LocalConfiguration.LoadControlCustomParameter(rbInverse, "Checked") == "1";
            rBRandom.Checked = LocalConfiguration.LoadControlCustomParameter(rBRandom, "Checked") == "1";

            if (!rbNormal.Checked && !rbInverse.Checked && !rBRandom.Checked)
            {
                rbNormal.Checked = true;
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(rbNormal, "Checked", rbNormal.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbInverse, "Checked", rbInverse.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rBRandom, "Checked", rBRandom.Checked ? "1" : "0");

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Действия в форме.

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            PerformAction();
        }

        private void PerformAction()
        {
            if (defence.IsUnlocked())
            {
                if (train.IsTrainEnabled())
                {
                    train.Stop();
                }
                else
                {
                    train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);

                    if (rbNormal.Checked)
                    {
                        train.TestOrder = Order.Normal;
                    }
                    else if (rbInverse.Checked)
                    {
                        train.TestOrder = Order.Inverse;
                    }
                    else if (rBRandom.Checked)
                    {
                        train.TestOrder = Order.Random;
                    }

                    train.Start();
                }

                defence.StartLock();
            }
        }

        #endregion Действия в форме.

        private void FormMagicAlphabetTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!train.IsTrainEnabled())
                {
                    this.Close();
                }
                else
                {
                    train.Stop();
                }
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                PerformAction();
            }
        }

        private void ActivateControls()
        {
            btnStartStop.Text = "Начать";

            gbVisibleTime.Enabled = true;
            gBOrderType.Enabled = true;
        }

        private void DeactivateControls()
        {
            btnStartStop.Text = "Стоп";

            gbVisibleTime.Enabled = false;
            gBOrderType.Enabled = false;
        }
    }
}
