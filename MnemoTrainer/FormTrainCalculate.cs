using System;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainCalculate : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineCalculate train;

        public FormTrainCalculate()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            lblTestWord.Text = string.Empty;
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            this.train = new TrainMachineCalculate();

            chBVisionTime.Checked = train.IsHideQuestion;
            nUDVisibleTime.Value = train.TimeShowing;

            chBTimeForAnswer.Checked = train.IsAutoAnswer;
            nUDTimeForAnswer.Value = train.TimeForAnswer;

            rBAddition.Checked = train.TestType == TrainTypeCalculate.Addition;
            rbMultiplication.Checked = train.TestType == TrainTypeCalculate.Multiplication;
            rbSum.Checked = train.TestType == TrainTypeCalculate.Sum;

            nUDx1Left.Value = train.LeftMultiplyMin;
            nUDx1Right.Value = train.LeftMultiplyMax;

            nUDx2Left.Value = train.RightMultiplyMin;
            nUDx2Right.Value = train.RightMultiplyMax;

            nUDNumberCount.Value = train.SummandCount;

            chBAddMinus.Checked = train.WithNegativ;


            LoadFormConfiguration();

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
            decimal tmpDecimal;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDVisibleTime.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDNumberCount, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDNumberCount.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeForAnswer, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDTimeForAnswer.Value = tmpDecimal;
            }

            chBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(chBVisionTime, "Checked") == "1";

            rBAddition.Checked = LocalConfiguration.LoadControlCustomParameter(rBAddition, "Checked") == "1";
            rbSum.Checked = LocalConfiguration.LoadControlCustomParameter(rbSum, "Checked") == "1";
            rbMultiplication.Checked = LocalConfiguration.LoadControlCustomParameter(rbMultiplication, "Checked") == "1";

            chBTimeForAnswer.Checked = LocalConfiguration.LoadControlCustomParameter(chBTimeForAnswer, "Checked") == "1";

            chBAddMinus.Checked = LocalConfiguration.LoadControlCustomParameter(chBAddMinus, "Checked") == "1";

            if (!rbMultiplication.Checked && !rbSum.Checked && !rBAddition.Checked)
            {
                rBAddition.Checked = true;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDx1Left, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDx1Left.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDx1Right, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDx1Right.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDx2Left, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDx2Left.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDx2Right, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDx2Right.Value = tmpDecimal;
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(chBVisionTime, "Checked", chBVisionTime.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(rBAddition, "Checked", rBAddition.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbSum, "Checked", rbSum.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbMultiplication, "Checked", rbMultiplication.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(chBTimeForAnswer, "Checked", chBTimeForAnswer.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(chBAddMinus, "Checked", chBAddMinus.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(nUDNumberCount, "Value", nUDNumberCount.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(nUDTimeForAnswer, "Value", nUDTimeForAnswer.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(nUDx1Left, "Value", nUDx1Left.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDx1Right, "Value", nUDx1Right.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDx2Left, "Value", nUDx2Left.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDx2Right, "Value", nUDx2Right.Value.ToString());

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

        private void FormCalculateTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.train.Status == MachineStatus.NotStarted)
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
            if (e.KeyChar == '+')
            {
                e.KeyChar = '\b';
            }
        }

        #region Изменение настроек теста.

        private void nUDTimeForAnswer_ValueChanged(object sender, EventArgs e)
        {
            train.TimeForAnswer = Convert.ToInt32(nUDTimeForAnswer.Value);
        }

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            train.IsHideQuestion = chBVisionTime.Checked;
            tBTestWord.Select();
        }

        private void cBTimeForAnswer_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoAnswer = chBTimeForAnswer.Checked;
            tBTestWord.Select();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMultiplication.Checked)
            {
                train.TestType = TrainTypeCalculate.Multiplication;
            }
            else if (rbSum.Checked)
            {
                train.TestType = TrainTypeCalculate.Sum;
            }
            else if (rBAddition.Checked)
            {
                train.TestType = TrainTypeCalculate.Addition;
            }

            tBTestWord.Select();
        }

        private void nUDx1Left_ValueChanged(object sender, EventArgs e)
        {
            train.LeftMultiplyMin = Convert.ToInt32(nUDx1Left.Value);
        }

        private void nUDx1Right_ValueChanged(object sender, EventArgs e)
        {
            train.LeftMultiplyMax = Convert.ToInt32(nUDx1Right.Value);
        }

        private void nUDx2Left_ValueChanged(object sender, EventArgs e)
        {
            train.RightMultiplyMin = Convert.ToInt32(nUDx2Left.Value);
        }

        private void nUDx2Right_ValueChanged(object sender, EventArgs e)
        {
            train.RightMultiplyMax = Convert.ToInt32(nUDx2Right.Value);
        }

        private void cBAddMinus_CheckedChanged(object sender, EventArgs e)
        {
            train.WithNegativ = chBAddMinus.Checked;
            tBTestWord.Select();
        }

        private void nUDNumberCount_ValueChanged(object sender, EventArgs e)
        {
            train.SummandCount = Convert.ToInt32(nUDNumberCount.Value);
        }

        #endregion Изменение настроек теста.
    }
}