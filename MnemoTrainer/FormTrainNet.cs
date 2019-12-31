using System;
using System.Drawing;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainNet : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineNet train;

        public FormTrainNet()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            train = new TrainMachineNet();
            train.NetTestCountChanged += new EventHandler(train_NetTestCountChanged);

            FillNetsComboBox();

            #region Начальная инициализация.
            
            chBVisionTime.Checked = train.IsHideQuestion;
            chbValueRange.Checked = train.IsRangeEnabled;
            nUDVisibleTime.Value = train.TimeShowing;
            nUDLeft.Value = train.MinNumber;
            nUDRight.Value = train.MaxNumber;

            if (train.TestType == NetTestType.All)
            {
                cBTestType.SelectedIndex = 0;
            }
            else if (train.TestType == NetTestType.Number)
            {
                cBTestType.SelectedIndex = 1;
            }
            else if (train.TestType == NetTestType.Pattern)
            {
                cBTestType.SelectedIndex = 2;
            }

            if (train.WithCalculations)
            {
                rBCalculation.Checked = true;
                rBNumber.Checked = false;
            }

            #endregion Начальная инициализация.

            netCheckedListBox.ListBox.ItemCheck += new ItemCheckEventHandler(ListBox_ItemCheck);

            cBTestType.SelectedIndex = 0;
            lblTestWord.Text = string.Empty;
            lblAnswer.Text = string.Empty;

            LoadFormConfiguration();

            tBTestWord.Select();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);
            train.TrainQuestionHided += new EventHandler(train_TrainQuestionHided);
            train.TrainShowRightAnswer += new EventHandler(train_TrainShowRightAnswer);
            train.TrainShowErrorMessage += new EventHandler(train_TrainShowErrorMessage);
            train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Обработчики событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;
            lblTestWord.Visible = true;
            lblAnswer.Visible = true;

            tBTestWord.Select();
            tSSTotalTimer.StartNew();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            ShowAskedQuestionCount();

            if (train.ForeColor.HasValue)
            {
                lblAnswer.ForeColor = train.ForeColor.Value;
            }
            else
            {
                lblAnswer.ForeColor = Color.Green;
            }

            if (train.BackColor.HasValue)
            {
                lblTestWord.BackColor = train.BackColor.Value;
            }
            else
            {
                lblTestWord.BackColor = SystemColors.Control;
            }

            lblTestWord.Text = this.train.QuestionText;
            lblTestWord.Visible = true;

            lblAnswer.Text = string.Empty;
            lblAnswer.Visible = false;

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

        void train_TrainShowRightAnswer(object sender, EventArgs e)
        {
            lblTestWord.Visible = true;

            lblAnswer.Text = train.AnswerText;
            lblAnswer.Visible = true;
        }

        void train_TrainShowErrorMessage(object sender, EventArgs e)
        {
            defence.StartLock();

            tBTestWord.Text = string.Empty;

            errorPictureBox.StartShowing();
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            StopCurrentTest();
            tBTestWord.Select();
        }

        void train_NetTestCountChanged(object sender, EventArgs e)
        {
            tStQuestionCount.Text = string.Format("Всего вопросов: {0}.", train.NetTestCount.ToString());
        }

        #endregion Обработчики событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            decimal tempDecimal;
            int tempInt;
            string tempString;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            LocalConfiguration.LoadListCheckedItems(this, netCheckedListBox.ListBox);

            tempString = LocalConfiguration.LoadControlCustomParameter(cBTestType, "SelectedIndex");
            if (!string.IsNullOrEmpty(tempString) && int.TryParse(tempString, out tempInt))
            {
                if (tempInt >= 0 && tempInt < cBTestType.Items.Count)
                {
                    cBTestType.SelectedIndex = tempInt;
                }
            }

            tempString = LocalConfiguration.LoadControlCustomParameter(nUDRight, "Value");
            if (!string.IsNullOrEmpty(tempString) && decimal.TryParse(tempString, out tempDecimal))
            {
                nUDRight.Value = tempDecimal;
            }

            tempString = LocalConfiguration.LoadControlCustomParameter(nUDLeft, "Value");
            if (!string.IsNullOrEmpty(tempString) && decimal.TryParse(tempString, out tempDecimal))
            {
                nUDLeft.Value = tempDecimal;
            }

            chbValueRange.Checked = LocalConfiguration.LoadControlCustomParameter(chbValueRange, "Checked") == "1";

            rBNumber.Checked = LocalConfiguration.LoadControlCustomParameter(rBNumber, "Checked") == "0";
            rBCalculation.Checked = LocalConfiguration.LoadControlCustomParameter(rBCalculation, "Checked") == "1";

            if (!rBNumber.Checked && !rBCalculation.Checked)
            {
                rBNumber.Checked = true;
            }

            chBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(chBVisionTime, "Checked") == "1";

            tempString = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(tempString) && decimal.TryParse(tempString, out tempDecimal))
            {
                nUDVisibleTime.Value = tempDecimal;
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        private void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            LocalConfiguration.SaveListCheckedItems(this, netCheckedListBox.ListBox);

            LocalConfiguration.SaveControlCustomParameter(cBTestType, "SelectedIndex", cBTestType.SelectedIndex.ToString());
            LocalConfiguration.SaveControlCustomParameter(chbValueRange, "Checked", chbValueRange.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(rBNumber, "Checked", rBNumber.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rBCalculation, "Checked", rBCalculation.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(nUDLeft, "Value", nUDLeft.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDRight, "Value", nUDRight.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(chBVisionTime, "Checked", chBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Работа со словарем.

        private void FillNetsComboBox()
        {
            foreach (Net item in TrainMachineNet.SourceNets)
            {
                netCheckedListBox.ListBox.Items.Add(item);
            }
        }

        #endregion Работа со словарем.

        #region Функция отображения следующего слова.

        private void StopCurrentTest()
        {
            tStStatusCounter.Text = string.Empty;

            lblTestWord.Text = string.Empty;
            lblTestWord.Visible = false;
            lblAnswer.Text = string.Empty;
            lblAnswer.Visible = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = false;

            errorPictureBox.StopShowing();

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();

            tSSTotalTimer.Stop();
            tSSTotalTimer.ClearTimerText();
        }

        private void ShowAskedQuestionCount()
        {
            tStStatusCounter.Text = string.Format("Кругов: {0}. Элементов: {1}.", this.train.LapsCount.ToString(), this.train.AskedQuestionsCount.ToString());
        }

        #endregion Функция отображения следующего слова.

        #region Код кнопок.

        private void tBTestWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (defence.IsUnlocked())
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    if (train.NetTestCount != 0)
                    {
                        train.MakeAction(tBTestWord.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show(this, "Не была сформирована коллекция вопросов по сетке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.Divide || e.KeyCode == Keys.Decimal)
            {
                if (train.CanWriteAnswer)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    train.ShowRightAnswer();
                }
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Add)
            {
                if (train.CanWriteAnswer && train.CurrentElementTestType == NetTestType.Number)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    train.ShowRightAnswer();
                }
            }
        }

        private void tBTestWord_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                e.IsInputKey = true;
            }
        }

        private void tBTestWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                e.KeyChar = '\b';
            }
            else if (e.KeyChar == '*' || e.KeyChar == '/')
            {
                e.Handled = true;
            }
        }

        private void FormNetTrain_KeyDown(object sender, KeyEventArgs e)
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

        #endregion Код кнопок.

        #region Изменение настроек.

        private void gbRange_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nUDRight.Value < nUDLeft.Value)
            {
                chbValueRange.Checked = false;
            }
        }

        private void nUDLeft_ValueChanged(object sender, EventArgs e)
        {
            train.MinNumber = Convert.ToInt32(nUDLeft.Value);
        }

        private void nUDRight_ValueChanged(object sender, EventArgs e)
        {
            train.MaxNumber = Convert.ToInt32(nUDRight.Value);
        }

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        void ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            train.SetCheckState(e.Index, e.NewValue == CheckState.Checked);
        }

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            train.IsHideQuestion = chBVisionTime.Checked;
            tBTestWord.Select();
        }

        private void cbValueRange_CheckedChanged(object sender, EventArgs e)
        {
            train.IsRangeEnabled = chbValueRange.Checked;
            tBTestWord.Select();
        }

        private void rBNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rBNumber.Checked)
            {
                train.WithCalculations = false;
            }
            else if (rBCalculation.Checked)
            {
                train.WithCalculations = true;
            }

            tBTestWord.Select();
        }

        private void cBTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBTestType.SelectedIndex == 0)
            {
                train.TestType = NetTestType.All;
            }
            else if (cBTestType.SelectedIndex == 1)
            {
                train.TestType = NetTestType.Number;
            }
            else if (cBTestType.SelectedIndex == 2)
            {
                train.TestType = NetTestType.Pattern;
            }

            tBTestWord.Select();
        }

        #endregion Изменение настроек
    }
}
