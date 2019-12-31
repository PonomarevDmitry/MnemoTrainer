using System;
using System.Globalization;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormNumberGenerator : Form
    {
        private readonly float baseFontSize;

        private DoubleClickDefence defence;

        private TrainMachineNumberGenerator train;

        public FormNumberGenerator()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            InitializeComponent();

            baseFontSize = lblTestWord.Font.Size;

            train = new TrainMachineNumberGenerator();

            FillNetsComboBox();

            defence = new DoubleClickDefence(this.components);

            #region Начальная инициализация.

            cBAutoShow.Checked = train.IsAutoShowing;
            cBTimeForAnswer.Checked = train.IsAutoAnswer;
            cbValueRange.Checked = train.IsRangeEnabled;

            nUDLeft.Value = train.MinNumber;
            nUDRight.Value = train.MaxNumber;

            nUDVisibleTime.Value = train.TimeShowing;
            nUDTimeForAnswer.Value = train.TimeForAnswer;

            nUDSymbolsCount.Value = train.SymbolsCount;

            #endregion Начальная инициализация.

            netCheckedListBox.ListBox.ItemCheck += new ItemCheckEventHandler(ListBox_ItemCheck);

            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            LoadFormConfiguration();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);
            train.TrainQuestionHided += new EventHandler(train_TrainQuestionHided);
            train.TrainAnswerAutoCheck += new AutoCheckEventHandler(train_TrainAnswerAutoCheck);
            train.TrainQuestionResult += new QuestionResultEventHandler(train_TrainQuestionResult);
            train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Обработчики событий.

        private void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;
            lblTestWord.Visible = true;
            lblCheckResult.Visible = true;

            tBTestWord.Select();
            tSSTotalTimer.StartNew();
        }

        private void train_TrainQuestionNew(object sender, EventArgs e)
        {
            lblTestWord.Text = this.train.QuestionText;
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = false;
            tBTestWord.Select();

            tBTestWord.ReadOnly = true;

            if (!train.IsAutoShowing)
            {
                tSSTestTimer.StartNew();
            }
        }

        private void train_TrainQuestionHided(object sender, EventArgs e)
        {
            lblTestWord.Visible = false;

            tBTestWord.ReadOnly = false;
            tBTestWord.Select();

            tSSTestTimer.StartNew();
        }

        private void train_TrainQuestionResult(object sender, QuestionResultEventArgs e)
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

        private void train_TrainAnswerAutoCheck(object sender, AutoCheckEventArgs e)
        {
            e.UserAnswer = tBTestWord.Text.Replace(" ", "");
            defence.StartLock();
        }

        private void train_TrainStoped(object sender, EventArgs e)
        {
            StopCurrentTest();
            tBTestWord.Select();
        }

        #endregion Обработчики событий.

        #region Инициализация.

        private void FillNetsComboBox()
        {
            foreach (Net item in TrainMachineNumberGenerator.SourceNets)
            {
                netCheckedListBox.ListBox.Items.Add(item);
            }
        }

        private void LoadFormConfiguration()
        {
            decimal tmpDecimal;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text = LocalConfiguration.LoadControlCustomParameter(nUDSymbolsCount, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDSymbolsCount.Value = tmpDecimal;
            }

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

            cbValueRange.Checked = LocalConfiguration.LoadControlCustomParameter(cbValueRange, "Checked") == "1";

            cBTimeForAnswer.Checked = LocalConfiguration.LoadControlCustomParameter(cBTimeForAnswer, "Checked") == "1";
            cBAutoShow.Checked = LocalConfiguration.LoadControlCustomParameter(cBAutoShow, "Checked") == "1";

            LocalConfiguration.LoadListCheckedItems(this, netCheckedListBox.ListBox);

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDSymbolsCount, "Value", nUDSymbolsCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeForAnswer, "Value", nUDTimeForAnswer.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(cBTimeForAnswer, "Checked", cBTimeForAnswer.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBAutoShow, "Checked", cBAutoShow.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(cbValueRange, "Checked", cbValueRange.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(nUDLeft, "Value", nUDLeft.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDRight, "Value", nUDRight.Value.ToString());

            LocalConfiguration.SaveListCheckedItems(this, netCheckedListBox.ListBox);

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Действия в форме.

        private void tBTestWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (defence.IsUnlocked())
                {
                    train.MakeAction(tBTestWord.Text.Replace(" ", ""));

                    defence.StartLock();
                }
            }
        }

        private void FormNumberGenerator_KeyDown(object sender, KeyEventArgs e)
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

        #endregion Действия в форме.

        private void StopCurrentTest()
        {
            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = false;

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();

            tSSTotalTimer.Stop();
            tSSTotalTimer.ClearTimerText();
        }

        #region Изменение настроек теста.

        private void ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            train.SetCheckState(e.Index, e.NewValue == CheckState.Checked);
        }

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void nUDTimeForAnswer_ValueChanged(object sender, EventArgs e)
        {
            train.TimeForAnswer = Convert.ToInt32(nUDTimeForAnswer.Value);
        }

        private void gbRange_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nUDRight.Value < nUDLeft.Value)
            {
                cbValueRange.Checked = false;
            }
        }

        private void cBAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoShowing = cBAutoShow.Checked;
            tBTestWord.Select();
        }

        private void cBTimeForAnswer_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoAnswer = cBTimeForAnswer.Checked;
            tBTestWord.Select();
        }

        private void nUDSymbolsCount_ValueChanged(object sender, EventArgs e)
        {
            train.SymbolsCount = Convert.ToInt32(nUDSymbolsCount.Value);
        }

        private void cbValueRange_CheckedChanged(object sender, EventArgs e)
        {
            train.IsRangeEnabled = cbValueRange.Checked;
            tBTestWord.Select();
        }

        private void nUDLeft_ValueChanged(object sender, EventArgs e)
        {
            train.MinNumber = Convert.ToInt32(nUDLeft.Value);
        }

        private void nUDRight_ValueChanged(object sender, EventArgs e)
        {
            train.MaxNumber = Convert.ToInt32(nUDRight.Value);
        }

        #endregion Изменение настроек теста.
    }
}
