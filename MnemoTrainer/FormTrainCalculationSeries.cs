using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainCalculationSeries : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineCalculateSeries train;

        public FormTrainCalculationSeries()
        {
            InitializeComponent();

            panelCalculationSeries.ColumnStyles.Clear();
            for (int i = 0; i < 30; i++)
            {
                panelCalculationSeries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            }

            defence = new DoubleClickDefence(this.components);

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            this.train = new TrainMachineCalculateSeries();

            chBVisionTime.Checked = train.IsHideQuestion;
            nUDVisibleTime.Value = train.TimeShowing;

            chBAddition.Checked = train.WithAddition;
            chBMultiplication.Checked = train.WithMultiplication;
            nUDAdditionOption.Value = train.AdditionRange;
            nUDSeriesCount.Value = train.SeriesCount;

            nUDLeft.Value = train.MultiplyMin;
            nUDRight.Value = train.MultiplyMax;

            LoadFormConfiguration();

            this.train.TrainStarted += new EventHandler(train_TrainStarted);
            this.train.TrainQuestionHided += new EventHandler(train_TrainQuestionHided);
            this.train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);

            this.train.TrainQuestionResult += new QuestionResultEventHandler(train_TrainQuestionResult);
            this.train.TrainAnswerAutoCheck += new AutoCheckEventHandler(train_TrainAnswerAutoCheck);

            this.train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            int temp;

            ActivateControls();

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text = LocalConfiguration.LoadControlCustomParameter(nUDSeriesCount, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDSeriesCount.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDAdditionOption, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDAdditionOption.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDLeft, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDLeft.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDRight, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDRight.Value = temp;
            }

            chBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(chBVisionTime, "Checked") == "1";
            chBAddition.Checked = LocalConfiguration.LoadControlCustomParameter(chBAddition, "Checked") == "1";
            chBMultiplication.Checked = LocalConfiguration.LoadControlCustomParameter(chBMultiplication, "Checked") == "1";

            if (!chBAddition.Checked && !chBMultiplication.Checked)
            {
                chBAddition.Checked = true;
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDSeriesCount, "Value", nUDSeriesCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(nUDAdditionOption, "Value", nUDAdditionOption.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDLeft, "Value", nUDLeft.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDRight, "Value", nUDRight.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(chBVisionTime, "Checked", chBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(chBAddition, "Checked", chBAddition.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(chBMultiplication, "Checked", chBMultiplication.Checked ? "1" : "0");

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Действия в форме.

        #region Активация и дезактивация настроект.

        private void ActivateControls()
        {
            gbVisibleTime.Enabled = true;
            gBAdditionOptions.Enabled = true;
            gBMultiplicationOption.Enabled = true;
            gBSeriesCount.Enabled = true;
            gBTrainType.Enabled = true;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = true;

            panelCalculationSeries.Controls.Clear();

            lblCheckResult.Visible = false;
        }

        private void DeactivateControls()
        {
            gbVisibleTime.Enabled = false;
            gBAdditionOptions.Enabled = false;
            gBMultiplicationOption.Enabled = false;
            gBSeriesCount.Enabled = false;
            gBTrainType.Enabled = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = false;

            panelCalculationSeries.Controls.Clear();

            lblCheckResult.Visible = false;
        }

        #endregion Активация и дезактивация настроект.

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (this.train.Status == MachineStatus.NotStarted)
            {
                DeactivateControls();

                btnStartStop.Text = "Закончить";

                FormTextBoxes();

                tBTestWord.Select();

                defence.StartLock();

                this.train.ShowNextQuestion();
            }
            else if (this.train.Status != MachineStatus.NotStarted)
            {
                ActivateControls();

                btnStartStop.Text = "Начать";

                this.train.Stop();

                defence.StartLock();
            }
        }

        private void FormTextBoxes()
        {
            for (int i = 0; i < this.train.SeriesCount; i++)
            {
                TextBox textBox = new TextBox();

                textBox.Font = new Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                textBox.ForeColor = Color.Green;
                textBox.Location = new Point(3, 3);
                textBox.Size = new Size(90, 30);
                textBox.TabIndex = i;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.TextAlign = HorizontalAlignment.Center;

                textBox.ReadOnly = true;
                textBox.BackColor = SystemColors.Control;

                textBox.Anchor = AnchorStyles.Top;

                textBox.Tag = 0;

                panelCalculationSeries.Controls.Add(textBox);
                panelCalculationSeries.SetCellPosition(textBox, new TableLayoutPanelCellPosition(i / 10, i % 10));
            }
        }

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

        #endregion Действия в форме.

        #region Обработчики событий тренировки.

        void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;
            lblCheckResult.Visible = true;

            tBTestWord.Select();
            tSSTotalTimer.StartNew();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            foreach (TextBox tempBox in panelCalculationSeries.Controls)
            {
                tempBox.Text = string.Empty;
                tempBox.ForeColor = Color.Green;
                tempBox.BackColor = SystemColors.Control;
            }

            TextBox textBox = (TextBox)panelCalculationSeries.Controls[this.train.QuestionIndex];

            textBox.ForeColor = Color.Green;
            textBox.BackColor = SystemColors.Window;

            textBox.Text += this.train.QuestionText;

            tBTestWord.Text = string.Empty;

            lblCheckResult.ForeColor = Color.Green;
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
                defence.StartLock();
            }
        }

        void train_TrainQuestionHided(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)panelCalculationSeries.Controls[this.train.QuestionIndex];

            textBox.Text = string.Empty;
            textBox.ForeColor = Color.Green;
            textBox.BackColor = System.Drawing.SystemColors.Control;

            tBTestWord.ReadOnly = false;
            tBTestWord.Select();

            tSSTestTimer.StartNew();
        }

        void train_TrainQuestionResult(object sender, QuestionResultEventArgs e)
        {
            tSSTestTimer.Stop();

            tBTestWord.Text = string.Empty;
            lblCheckResult.Visible = true;

            double time = tSSTestTimer.TimeInterval().TotalSeconds;

            string timeString = "\r\n" + e.Text + "\r\n" + time.ToString("F1") + " с" + (e.IsAutoCheck ? " Авто" : "");

            TextBox textBox = (TextBox)panelCalculationSeries.Controls[this.train.QuestionIndex];

            textBox.Text = this.train.AnswerValue.ToString();
            textBox.ForeColor = Color.Blue;

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

        private void StopCurrentTest()
        {
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

        private void FormCalculationSeriesTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                e.KeyChar = '\b';
            }
        }

        private void gBTrainType_Validating(object sender, CancelEventArgs e)
        {
            if (!chBAddition.Checked && !chBMultiplication.Checked)
            {
                chBAddition.Checked = true;
            }
        }

        private void gBMultiplicationOption_Validating(object sender, CancelEventArgs e)
        {
            if (nUDLeft.Value > nUDRight.Value)
            {
                nUDLeft.Value = 1;
                nUDRight.Value = 99;
            }
        }

        #region Изменение настроек теста.

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            this.train.IsHideQuestion = chBVisionTime.Checked;
        }

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            this.train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void nUDSeriesCount_ValueChanged(object sender, EventArgs e)
        {
            this.train.SeriesCount = Convert.ToInt32(nUDSeriesCount.Value);
        }

        private void chBAddition_CheckedChanged(object sender, EventArgs e)
        {
            this.train.WithAddition = chBAddition.Checked;
        }

        private void chBMultiplication_CheckedChanged(object sender, EventArgs e)
        {
            this.train.WithMultiplication = chBMultiplication.Checked;
        }

        private void nUDAdditionOption_ValueChanged(object sender, EventArgs e)
        {
            this.train.AdditionRange = Convert.ToInt32(nUDAdditionOption.Value);
        }

        private void nUDLeft_ValueChanged(object sender, EventArgs e)
        {
            this.train.MultiplyMin = Convert.ToInt32(nUDLeft.Value);
        }

        private void nUDRight_ValueChanged(object sender, EventArgs e)
        {
            this.train.MultiplyMax = Convert.ToInt32(nUDRight.Value);
        }

        #endregion Изменение настроек теста.
    }
}
