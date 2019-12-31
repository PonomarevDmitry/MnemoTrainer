using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainRecentMemory : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineRecentMemory train;

        public FormTrainRecentMemory()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            train = new TrainMachineRecentMemory();
            nUDSymbolsCount.Value = train.SymbolsCount;
            nUDVisibleTime.Value = train.TimeShowing;
            cBTimeForAnswer.Checked = train.IsAutoAnswer;
            nUDTimeForAnswer.Value = train.TimeForAnswer;

            lblTestWord.Text = string.Empty;
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            LoadFormConfiguration();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainTestBegin += new EventHandler(train_TrainTestBegin);
            train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);
            train.TrainTestEnd += new EventHandler(train_TrainTestEnd);
            train.TrainAnswerAutoCheck += new AutoCheckEventHandler(train_TrainAnswerAutoCheck);
            train.TrainQuestionResult += new QuestionResultEventHandler(train_TrainQuestionResult);
            train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;

            lblTestWord.Text = string.Empty;
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tSSTotalTimer.StartNew();
        }

        void train_TrainTestBegin(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = true;
            tBTestWord.MaxLength = train.SymbolsCount;

            lblTestWord.Text = string.Empty;
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tSSTestTimer.ClearTimerText();

            tBTestWord.Select();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            lblTestWord.Text = train.QuestionText;
            if (train.QuestionIndex % 2 == 0)
            {
                lblTestWord.ForeColor = Color.Green;
            }
            else
            {
                lblTestWord.ForeColor = Color.RoyalBlue;
            }
        }

        void train_TrainTestEnd(object sender, EventArgs e)
        {
            tBTestWord.ReadOnly = false;

            lblTestWord.Text = string.Empty;
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
            lblTestWord.ForeColor = Color.Green;
            lblCheckResult.Visible = true;

            double time = tSSTestTimer.TimeInterval().TotalSeconds;

            string timeString = "\r\n" + time.ToString("F1") + " с" + (e.IsAutoCheck ? " Авто" : "");

            lblTestWord.Text = e.Text;

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

            rBEyesight.Checked = LocalConfiguration.LoadControlCustomParameter(rBEyesight, "Checked") == "1";
            rBHearing.Checked = LocalConfiguration.LoadControlCustomParameter(rBHearing, "Checked") == "1";
            if (!rBEyesight.Checked && !rBHearing.Checked)
            {
                rBEyesight.Checked = true;
            }

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

            LocalConfiguration.SaveControlCustomParameter(rBEyesight, "Checked", rBEyesight.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rBHearing, "Checked", rBHearing.Checked ? "1" : "0");

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
                    if (this.train.CanGetNewQuestion)
                    {
                        this.train.ShowNextQuestion();
                    }
                    else if (this.train.CanWriteAnswer)
                    {
                        string userAnswer = tBTestWord.Text.Trim();

                        this.train.TryAnswer(userAnswer);
                    }

                    defence.StartLock();
                }
            }
        }

        private void StopCurrentTest()
        {
            lblTestWord.Text = string.Empty;
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

        private void FormRecentMemoryTrain_KeyDown(object sender, KeyEventArgs e)
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

        private void cBTimeForAnswer_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoAnswer = cBTimeForAnswer.Checked;
        }

        private void nUDSymbolsCount_ValueChanged(object sender, EventArgs e)
        {
            train.SymbolsCount = Convert.ToInt32(nUDSymbolsCount.Value);
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
