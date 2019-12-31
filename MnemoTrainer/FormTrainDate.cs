using System;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainDate : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineDate train;

        public FormTrainDate()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            this.train = new TrainMachineDate();

            chBVisionTime.Checked = train.IsHideQuestion;
            nUDVisibleTime.Value = train.TimeShowing;

            chBTimeForAnswer.Checked = train.IsAutoAnswer;
            nUDTimeForAnswer.Value = train.TimeForAnswer;

            rBDayOfWeek.Checked = train.TestType == TrainTypeDate.DayOfWeek;
            rBMonth.Checked = train.TestType == TrainTypeDate.MonthDate;
            rBYear.Checked = train.TestType == TrainTypeDate.IndexOfYear;
            rBYear12.Checked = train.TestType == TrainTypeDate.IndexOf12;

            nUDLeft.Value = train.MinYear;
            nUDRight.Value = train.MaxYear;

            LoadFormConfiguration();

            Common.SetTextBoxOnlyNumbers(tBTestWord);

            this.train.TrainStarted += new EventHandler(train_TrainStarted);
            this.train.TrainQuestionHided += new EventHandler(train_TrainQuestionHided);
            this.train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);

            this.train.TrainQuestionResult += new QuestionResultEventHandler(train_TrainQuestionResult);
            this.train.TrainAnswerAutoCheck += new AutoCheckEventHandler(train_TrainAnswerAutoCheck);

            this.train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Обработчики событий тренировки.

        void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;
            lblTestWord.Visible = true;
            lblCheckResult.Visible = true;

            tBTestWord.Select();
            tSSTotalTimer.StartNew();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            lblTestWord.Text = this.train.QuestionText;
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = false;
            tBTestWord.Select();

            if (train.IsHideQuestion)
            {
                tBTestWord.ReadOnly = true;
            }
            else
            {
                tSSTestTimer.StartNew();
            }
        }

        void train_TrainQuestionHided(object sender, EventArgs e)
        {
            lblTestWord.Visible = false;

            tBTestWord.ReadOnly = false;
            tBTestWord.Select();

            tSSTestTimer.StartNew();
        }

        void train_TrainQuestionResult(object sender, QuestionResultEventArgs e)
        {
            tSSTestTimer.Stop();

            tBTestWord.Text = string.Empty;
            lblTestWord.Visible = true;
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

        void train_TrainAnswerAutoCheck(object sender, AutoCheckEventArgs e)
        {
            e.UserAnswer = tBTestWord.Text.Trim();
            defence.StartLock();
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            StopCurrentTest();
            tBTestWord.Select();
        }

        #endregion Обработчики событий тренировки.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            string text;
            decimal tmpDecimal;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDVisibleTime.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeForAnswer, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDTimeForAnswer.Value = tmpDecimal;
            }

            chBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(chBVisionTime, "Checked") == "1";
            chBTimeForAnswer.Checked = LocalConfiguration.LoadControlCustomParameter(chBTimeForAnswer, "Checked") == "1";

            rBDayOfWeek.Checked = LocalConfiguration.LoadControlCustomParameter(rBDayOfWeek, "Checked") == "1";
            rBYear.Checked = LocalConfiguration.LoadControlCustomParameter(rBYear, "Checked") == "1";
            rBYear12.Checked = LocalConfiguration.LoadControlCustomParameter(rBYear12, "Checked") == "1";
            rBMonth.Checked = LocalConfiguration.LoadControlCustomParameter(rBMonth, "Checked") == "1";

            if (!rBDayOfWeek.Checked && !rBYear.Checked && !rBYear12.Checked && !rBMonth.Checked)
            {
                rBDayOfWeek.Checked = true;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDRight, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDRight.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDLeft, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDLeft.Value = tmpDecimal;
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeForAnswer, "Value", nUDTimeForAnswer.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(nUDLeft, "Value", nUDLeft.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDRight, "Value", nUDRight.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(chBVisionTime, "Checked", chBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(chBTimeForAnswer, "Checked", chBTimeForAnswer.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(rBDayOfWeek, "Checked", rBDayOfWeek.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rBYear, "Checked", rBYear.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rBYear12, "Checked", rBYear12.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rBMonth, "Checked", rBMonth.Checked ? "1" : "0");

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

        private void FormDateTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.train.Status == MachineStatus.NotStarted)
                {
                    this.Close();
                }
                else
                {
                    this.train.Stop();
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.KeyChar = '\b';
            }
            else if (rBYear12.Checked)
            {
                if (e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9')
                {
                    e.KeyChar = '-';
                }
            }
        }

        private void gbRange_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nUDRight.Value <= nUDLeft.Value)
            {
                nUDLeft.Value = 1900;
                nUDRight.Value = 2080;
            }
        }

        #region Изменение настроек теста.

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            this.train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void nUDTimeForAnswer_ValueChanged(object sender, EventArgs e)
        {
            this.train.TimeForAnswer = Convert.ToInt32(nUDTimeForAnswer.Value);
        }

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            this.train.IsHideQuestion = chBVisionTime.Checked;
        }

        private void cBTimeForAnswer_CheckedChanged(object sender, EventArgs e)
        {
            this.train.IsAutoAnswer = chBTimeForAnswer.Checked;
        }

        private void rB_CheckedChanged(object sender, EventArgs e)
        {
            if (rBDayOfWeek.Checked)
            {
                train.TestType = TrainTypeDate.DayOfWeek;
            }
            else if (rBMonth.Checked)
            {
                train.TestType = TrainTypeDate.MonthDate;
            }
            else if (rBYear.Checked)
            {
                train.TestType = TrainTypeDate.IndexOfYear;
            }
            else if (rBYear12.Checked)
            {
                train.TestType = TrainTypeDate.IndexOf12;
            }
        }

        private void nUDLeft_ValueChanged(object sender, EventArgs e)
        {
            train.MinYear = Convert.ToInt32(nUDLeft.Value);
        }

        private void nUDRight_ValueChanged(object sender, EventArgs e)
        {
            train.MaxYear = Convert.ToInt32(nUDRight.Value);
        }

        #endregion Изменение настроек теста.

        private void dTPCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblTestWord.Text = train.GetNameDayOfWeekByDate(dTPCheck.Value);
                lblTestWord.Visible = true;
            }
        }

        private void nUD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tBTestWord.Select();
            }
        }
    }
}
