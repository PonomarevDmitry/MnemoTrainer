using System;
using System.Drawing;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormStrupTest : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineStrup train;

        public FormStrupTest()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components) { Interval = 50 };

            train = new TrainMachineStrup();

            lblTestWord.Text = string.Empty;

            lblTestWord.Select();

            LoadFormConfiguration();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainStoped += new EventHandler(train_TrainStoped);
            train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);
        }

        #region Обработчики событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            tSSTotalTime.StartNew();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            lblTestWord.Text = train.CurrentColorName;
            if (train.CurrentColor.HasValue)
            {
                lblTestWord.ForeColor = train.CurrentColor.Value;
            }
            else
            {
                lblTestWord.ForeColor = Color.Green;
            }

            tSSLTestCount.Text = string.Format("Тестов: {0}.", train.TestCount.ToString());

            lblTestWord.Select();
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            lblTestWord.Text = string.Empty;
            lblTestWord.ForeColor = Color.Green;

            tSSLTestCount.Text = string.Empty;

            tSSTotalTime.Stop();
            tSSTotalTime.ClearTimerText();
        }

        #endregion Обработчики событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            string text;
            int temp;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            cBAutoShow.Checked = LocalConfiguration.LoadControlCustomParameter(cBAutoShow, "Checked") == "1";

            text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(cBAutoShow, "Checked", cBAutoShow.Checked ? "1" : "0");

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        private void FormStrupTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (train.Status == MachineStatus.NotStarted)
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
                PerformClick();
            }
        }

        private void FormStrupTest_MouseClick(object sender, MouseEventArgs e)
        {
            PerformClick();
        }

        private void lblTestWord_Click(object sender, EventArgs e)
        {
            PerformClick();
        }

        private void PerformClick()
        {
            if (train.CanGetNewQuestion)
            {
                if (defence.IsUnlocked())
                {
                    train.ShowNextQuestion();
                }
            }
        }

        #region Изменение настроек теста.

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void cBAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoShowing = cBAutoShow.Checked;
        }

        #endregion Изменение настроек теста.
    }
}
