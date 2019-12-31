using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainer
{
    public partial class FormCalculationSeriesTrain : Form
    {
        private DoubleClickDefence defence;

        Random rnd = new Random();

        private TestStatus status = TestStatus.NotStarted;
        private TestStatus globalStatus = TestStatus.NotStarted;

        private int indexLine = 0;
        private bool questionResult = false;

        public FormCalculationSeriesTrain()
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

            LoadFormConfiguration();
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

            cBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(cBVisionTime, "Checked") == "1";
            rbAddition.Checked = LocalConfiguration.LoadControlCustomParameter(rbAddition, "Checked") == "1";
            rbMultiplication.Checked = LocalConfiguration.LoadControlCustomParameter(rbMultiplication, "Checked") == "1";

            if (!rbAddition.Checked && !rbMultiplication.Checked)
            {
                rbAddition.Checked = true;
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

            LocalConfiguration.SaveControlCustomParameter(cBVisionTime, "Checked", cBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbAddition, "Checked", rbAddition.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbMultiplication, "Checked", rbMultiplication.Checked ? "1" : "0");

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

            globalStatus = TestStatus.NotStarted;
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

            globalStatus = TestStatus.IsGoing;
        }

        #endregion Активация и дезактивация настроект.

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (globalStatus == TestStatus.NotStarted)
            {
                DeactivateControls();

                globalStatus = TestStatus.IsGoing;

                btnStartStop.Text = "Закончить";

                FormTextBoxes();

                tBTestWord.Select();

                defence.StartLock();
            }
            else if (globalStatus == TestStatus.IsGoing)
            {
                ActivateControls();

                btnStartStop.Text = "Начать";

                globalStatus = TestStatus.NotStarted;

                defence.StartLock();
            }
        }

        private void FormTextBoxes()
        {
            for (int i = 0; i < Convert.ToInt32(nUDSeriesCount.Value); i++)
            {
                TextBox textBox = new TextBox();

                textBox.Font = new Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                textBox.ForeColor = Color.Green;
                textBox.Location = new Point(3, 3);
                textBox.Size = new Size(66, 30);
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
                    if (globalStatus == TestStatus.IsGoing)
                    {
                        if (status == TestStatus.NotStarted)
                        {
                            ShowNextQuestion();
                        }
                        else if (status == TestStatus.IsGoing)
                        {
                            HideQuestion();
                            defence.StartLock();
                        }
                        else if (!tBTestWord.ReadOnly && status == TestStatus.IsChecking)
                        {
                            CheckAnswer();
                        }
                    }
                }
            }
        }

        private void ShowNextQuestion()
        {
            for (int i = 0; i < panelCalculationSeries.Controls.Count; i++)
            {
                panelCalculationSeries.Controls[i].Text = string.Empty;
                panelCalculationSeries.Controls[i].BackColor = System.Drawing.SystemColors.Control;
            }

            indexLine = rnd.Next(panelCalculationSeries.Controls.Count);

            bool addition = true;

            if (rbAddition.Checked && rbMultiplication.Checked)
            {
                addition = rnd.Next(2) == 0;
            }
            else if (rbAddition.Checked)
            {
                addition = true;
            }
            else if (rbMultiplication.Checked)
            {
                addition = false;
            }

            int question = 0;

            do
            {
                if (addition)
                {
                    int value = Convert.ToInt32(nUDAdditionOption.Value);

                    question = rnd.Next(value * 2 + 1) - value;
                }
                else
                {
                    int minValue = Convert.ToInt32(nUDLeft.Value);
                    int maxValue = Convert.ToInt32(nUDRight.Value);

                    question = rnd.Next(maxValue - minValue + 1) + minValue;
                }
            } while (question == 0);


            TextBox textBox = (TextBox)panelCalculationSeries.Controls[indexLine];

            if (question > 0)
            {
                textBox.ForeColor = Color.Green;
                textBox.Text = "+";
            }
            else
            {
                textBox.ForeColor = Color.Red;
                textBox.Text = string.Empty;
            }

            textBox.BackColor = System.Drawing.SystemColors.Window;

            textBox.Tag = (int)textBox.Tag + question;

            textBox.Text += question.ToString();

            tBTestWord.Text = string.Empty;

            lblCheckResult.ForeColor = System.Drawing.Color.Green;
            if (!questionResult)
            {
                lblCheckResult.Visible = false;
            }

            if (cBVisionTime.Checked)
            {
                tBTestWord.ReadOnly = true;

                StartHideTimer();
            }
            else
            {
                tBTestWord.ReadOnly = false;

                status = TestStatus.IsChecking;
                defence.StartLock();
            }
        }

        private void HideQuestion()
        {
            tBTestWord.ReadOnly = false;
            lblCheckResult.Visible = false;

            status = TestStatus.IsChecking;
        }

        private void CheckAnswer()
        {
            string userAnswerText = tBTestWord.Text.Replace(" ", "");

            TextBox textBox = (TextBox)panelCalculationSeries.Controls[indexLine];

            string rightResult = textBox.Tag.ToString();

            questionResult = rightResult == userAnswerText;

            if (questionResult)
            {
                lblCheckResult.Text = "Правильно";
                lblCheckResult.ForeColor = System.Drawing.Color.Green;

                ShowNextQuestion();
            }
            else
            {
                textBox.Text = rightResult;
                textBox.ForeColor = Color.Blue;

                errorPictureBox.StartShowing();

                lblCheckResult.Text = "Неправильно!!!";
                lblCheckResult.ForeColor = System.Drawing.Color.Red;

                tBTestWord.Text = string.Empty;
                tBTestWord.ReadOnly = true;

                status = TestStatus.NotStarted;

                defence.StartLock();
            }

            lblCheckResult.Visible = true;
            tBTestWord.Text = string.Empty;
        }

        #endregion Действия в форме.

        #region Таймеры.

        private void timerHide_Tick(object sender, EventArgs e)
        {
            timerHide.Stop();

            HideQuestion();
        }

        private void StartHideTimer()
        {
            status = TestStatus.IsChecking;

            timerHide.Interval = Convert.ToInt32(nUDVisibleTime.Value);
            timerHide.Start();
        }

        #endregion Таймеры.

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
            if (!rbAddition.Checked && !rbMultiplication.Checked)
            {
                rbAddition.Checked = true;
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
    }
}
