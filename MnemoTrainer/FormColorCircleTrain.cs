using System;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormColorCircleTrain : Form
    {
        private DoubleClickDefence defence;

        private TrainColorCircle train;

        public FormColorCircleTrain()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components) { Interval = 400 };

            train = new TrainColorCircle();
            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainQuestionShowed += new EventHandler(train_TrainQuestionShowed);
            train.TrainQuestionHided += new EventHandler(train_TrainQuestionHided);
            train.TrainEnded += new EventHandler(train_TrainEnded);
            train.TrainStoped += new EventHandler(train_TrainStoped);

            LoadFormConfiguration();

            colorCircle.Text = string.Empty;
            colorCircle.ShowCircle = false;

            colorCircle.Select();
        }

        #region Обработчки событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            colorCircle.Text = string.Empty;
            colorCircle.ShowCircle = false;

            tSSTotalTimer.StartNew();
        }

        void train_TrainQuestionShowed(object sender, EventArgs e)
        {
            colorCircle.CircleColor = train.CurrentColor;
            colorCircle.ShowCircle = true;

            tSSLCurrentIndex.Text = string.Format("Элемент № {0} из {1}.", train.CurrentIndex.ToString(), train.ColorCount.ToString());

            tSSTestTimer.StartNew();
        }

        void train_TrainQuestionHided(object sender, EventArgs e)
        {
            colorCircle.Text = string.Empty;
            colorCircle.ShowCircle = false;

            tSSTestTimer.StartNew();
        }

        void train_TrainEnded(object sender, EventArgs e)
        {
            colorCircle.Text = "Конец";
            colorCircle.ShowCircle = false;

            tSSLCurrentIndex.Text = string.Empty;

            tSSTestTimer.Stop();
            tSSTotalTimer.Stop();
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            colorCircle.Text = string.Empty;
            colorCircle.ShowCircle = false;

            tSSLCurrentIndex.Text = string.Empty;

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();

            tSSTotalTimer.Stop();
            tSSTotalTimer.ClearTimerText();
        }

        #endregion Обработчки событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            int temp;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            string text;

            text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeNextCircle, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDTimeNextCircle.Value = temp;
            }

            cBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(cBVisionTime, "Checked") == "1";
            cBNextCircle.Checked = LocalConfiguration.LoadControlCustomParameter(cBNextCircle, "Checked") == "1";

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeNextCircle, "Value", nUDTimeNextCircle.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(cBVisionTime, "Checked", cBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBNextCircle, "Checked", cBNextCircle.Checked ? "1" : "0");

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        private void FormColorCircleTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (train.IsTrainEnabled)
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
                PerformClick();
            }
        }

        private void colorCircle_MouseClick(object sender, MouseEventArgs e)
        {
            PerformClick();
        }

        private void PerformClick()
        {
            if (defence.IsUnlocked())
            {
                train.ShowNextQuestion();

                defence.StartLock();
            }
        }

        #region Изменение настроек теста.

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void nUDTimeNextCircle_ValueChanged(object sender, EventArgs e)
        {
            train.TimeNextCircle = Convert.ToInt32(nUDTimeNextCircle.Value);
        }

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            train.IsHideQuestion = cBVisionTime.Checked;
            colorCircle.Select();
        }

        private void cBNextCircle_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoNextCircle = cBNextCircle.Checked;
            colorCircle.Select();
        }

        #endregion Изменение настроек теста.
    }
}
