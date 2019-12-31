using System;
using System.Globalization;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormStepanovTrain : Form
    {
        private readonly float baseFontSize;

        private DoubleClickDefence defence;

        private TrainMachineStepanov train;

        public FormStepanovTrain()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            InitializeComponent();

            baseFontSize = lblTestWord.Font.Size;

            defence = new DoubleClickDefence(this.components);
            train = new TrainMachineStepanov();

            cBVisionTime.Checked = train.IsHideQuestion;
            cBTimeForAnswer.Checked = train.IsAutoAnswer;
            nUDVisibleTime.Value = train.TimeShowing;
            nUDTimeForAnswer.Value = train.TimeForAnswer;
            nUDSymbolsCount.Value = train.SymbolsCount;

            rbNumbers.Checked = train.TestType == TrainTypeStepanovAndRecentMemory.Numbers;
            rbNumbersAndSymbols.Checked = train.TestType == TrainTypeStepanovAndRecentMemory.NumbersAndSymbols;

            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            LoadFormConfiguration();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainTestBegin += new EventHandler(train_TrainTestBegin);
            train.TrainTestEnd += new EventHandler(train_TrainTestEnd);
            train.TrainAnswerAutoCheck += new AutoCheckEventHandler(train_TrainAnswerAutoCheck);
            train.TrainQuestionResult += new QuestionResultEventHandler(train_TrainQuestionResult);
            train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Обработчки событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;

            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tSSTotalTimer.StartNew();

            tBTestWord.Select();
        }

        void train_TrainTestBegin(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = true;
            tBTestWord.MaxLength = 2 * train.SymbolsCount;

            Common.SetLabelText(lblTestWord, baseFontSize, train.QuestionText);
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tSSTestTimer.ClearTimerText();

            tBTestWord.Select();
        }

        void train_TrainTestEnd(object sender, EventArgs e)
        {
            tBTestWord.ReadOnly = false;

            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            lblCheckResult.Visible = false;

            tBTestWord.Select();

            tSSTestTimer.StartNew();
        }

        void train_TrainAnswerAutoCheck(object sender, AutoCheckEventArgs e)
        {
            e.UserAnswer = tBTestWord.Text.Trim();
            defence.StartLock();
        }

        void train_TrainQuestionResult(object sender, QuestionResultEventArgs e)
        {
            tSSTestTimer.Stop();

            tBTestWord.Text = string.Empty;
            lblTestWord.Visible = true;
            lblCheckResult.Visible = true;

            double time = tSSTestTimer.TimeInterval().TotalSeconds;

            string timeString = "\r\n" + time.ToString("F1") + " с" + (e.IsAutoCheck ? " Авто" : "");

            Common.SetLabelText(lblTestWord, baseFontSize, e.Text);
            
            if (e.IsAnswerRight)
            {
                lblCheckResult.Text = "Правильно" + timeString;
                lblCheckResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                errorPictureBox.StartShowing();

                lblCheckResult.Text = "Неправильно!!!" + timeString;
                lblCheckResult.ForeColor = System.Drawing.Color.Red;

                defence.StartLock();
            }
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            StopCurrentTest();
            tBTestWord.Select();
        }

        #endregion Обработчки событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            int temp;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text = LocalConfiguration.LoadControlCustomParameter(nUDSymbolsCount, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDSymbolsCount.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeForAnswer, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDTimeForAnswer.Value = temp;
            }

            rbNumbers.Checked = LocalConfiguration.LoadControlCustomParameter(rbNumbers, "Checked") == "1";
            rbNumbersAndSymbols.Checked = LocalConfiguration.LoadControlCustomParameter(rbNumbersAndSymbols, "Checked") == "1";
            if (!rbNumbers.Checked && !rbNumbersAndSymbols.Checked)
            {
                rbNumbers.Checked = true;
            }

            cBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(cBVisionTime, "Checked") == "1";
            cBTimeForAnswer.Checked = LocalConfiguration.LoadControlCustomParameter(cBTimeForAnswer, "Checked") == "1";

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDSymbolsCount, "Value", nUDSymbolsCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeForAnswer, "Value", nUDTimeForAnswer.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(rbNumbers, "Checked", rbNumbers.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbNumbersAndSymbols, "Checked", rbNumbersAndSymbols.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(cBVisionTime, "Checked", cBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBTimeForAnswer, "Checked", cBTimeForAnswer.Checked ? "1" : "0");

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Действия в форме.

        private void tBTestWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (defence.IsUnlocked())
                {
                    string userAnswer = tBTestWord.Text.Trim();

                    train.MakeAction(userAnswer);

                    defence.StartLock();
                }
            }
        }

        private void StopCurrentTest()
        {
            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = false;

            errorPictureBox.StopShowing();

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();

            tSSTotalTimer.Stop();
            tSSTotalTimer.ClearTimerText();
        }

        #endregion Действия в форме.

        private void FormStepanovTrain_KeyDown(object sender, KeyEventArgs e)
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
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.KeyChar = '\b';
            }
        }

        #region Изменение настроек теста.

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void nUDTimeForAnswer_ValueChanged(object sender, EventArgs e)
        {
            train.TimeForAnswer = Convert.ToInt32(nUDTimeForAnswer.Value);
        }

        private void nUDSymbolsCount_ValueChanged(object sender, EventArgs e)
        {
            train.SymbolsCount = Convert.ToInt32(nUDSymbolsCount.Value);
        }

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            train.IsHideQuestion = cBVisionTime.Checked;
        }

        private void cBTimeForAnswer_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoAnswer = cBTimeForAnswer.Checked;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNumbers.Checked)
            {
                train.TestType = TrainTypeStepanovAndRecentMemory.Numbers;
            }
            else if (rbNumbersAndSymbols.Checked)
            {
                train.TestType = TrainTypeStepanovAndRecentMemory.NumbersAndSymbols;
            }
        }

        #endregion Изменение настроек теста.
    }
}
