using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrainImpression : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineImpression train;

        private readonly float baseFontSize;

        PointF labelDrawPoint;
        StringFormat labelStringFormat;

        public FormTrainImpression()
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            InitializeComponent();

            labelDrawPoint = new PointF((float)lblTestWord.Width / 2, (float)lblTestWord.Height / 2);
            labelStringFormat = new StringFormat();
            labelStringFormat.Alignment = StringAlignment.Center;
            labelStringFormat.LineAlignment = StringAlignment.Center;

            defence = new DoubleClickDefence(this.components);

            baseFontSize = lblTestWord.Font.Size;

            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            cBDictionary.DataSource = WordDictionary.SourcesFile;
            cBDictionary.DisplayMember = "Name";
            cBDictionary.SelectedIndexChanged += new EventHandler(cBDictionary_SelectedIndexChanged);

            train = new TrainMachineImpression();

            nUDVisibleTime.Value = train.TimeShowing;
            rbSymbols.Checked = train.TestType == TrainTypeImpression.Symbols;
            rbDictionary.Checked = train.TestType == TrainTypeImpression.Dictionary;
            cbRandomSymbols.Checked = train.WithRandomLiters;
            cBColor.Checked = train.WithColor;
            nUDSymbolsCount.Value = train.SymbolsCount;
            nUDWordsCount.Value = train.WordsCount;

            LoadFormConfiguration();

            if (string.IsNullOrEmpty(tStStatusWords.Text))
            {
                FillWordCount();
            }

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainTestBegin += new EventHandler(train_TrainTestBegin);
            train.TrainQuestionNew += new EventHandler(train_TrainQuestionNew);
            train.TrainTestEnd += new EventHandler(train_TrainTestEnd);
            train.TrainQuestionResult += new QuestionResultEventHandler(train_TrainQuestionResult);
            train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Обработчики событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            tBTestWord.Text = string.Empty;

            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tBTestWord.Select();
            tSSTotalTimer.StartNew();
        }

        void train_TrainTestBegin(object sender, EventArgs e)
        {
            Common.SetLabelText(lblTestWord, baseFontSize, string.Empty);
            lblTestWord.Visible = true;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            tBTestWord.Text = string.Empty;
            tBTestWord.ReadOnly = true;

            if (train.TestType == TrainTypeImpression.Symbols)
            {
                tBTestWord.MaxLength = train.SymbolsCount + (train.WithColor ? 1 : 0);
            }
            else
            {
                tBTestWord.MaxLength = 2000;
            }

            tBTestWord.Select();
        }

        void train_TrainQuestionNew(object sender, EventArgs e)
        {
            lblTestWord.Visible = true;

            Color color = Color.Green;

            if (train.WithColor)
            {
                color = train.QuestionColor.Value;
            }

            Brush labelBrush = new SolidBrush(color);

            Graphics graphics = lblTestWord.CreateGraphics();
            graphics.DrawString(train.QuestionText, lblTestWord.Font, labelBrush, labelDrawPoint, labelStringFormat);
            graphics.Dispose();

            Thread.Sleep(2);
        }

        void train_TrainTestEnd(object sender, EventArgs e)
        {
            lblTestWord.Visible = false;
            lblTestWord.Invalidate();

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

            Common.SetLabelText(lblTestWord, baseFontSize, e.Text);
            lblTestWord.ForeColor = Color.Green;

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

        #endregion Обработчики событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            decimal temp; string text;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            text = LocalConfiguration.LoadControlCustomParameter(nUDSymbolsCount, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out temp))
            {
                nUDSymbolsCount.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDWordsCount, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out temp))
            {
                nUDWordsCount.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(rbSymbols, "Checked");
            rbSymbols.Checked = text == "1";

            text = LocalConfiguration.LoadControlCustomParameter(rbDictionary, "Checked");
            rbDictionary.Checked = text == "1";

            cbRandomSymbols.Checked = LocalConfiguration.LoadControlCustomParameter(cbRandomSymbols, "Checked") == "1";

            cBColor.Checked = LocalConfiguration.LoadControlCustomParameter(cBColor, "Checked") == "1";

            if (!rbDictionary.Checked && !rbSymbols.Checked)
            {
                rbSymbols.Checked = true;
            }

            text = LocalConfiguration.LoadControlCustomParameter(cBDictionary, "SelectedItem");
            if (!string.IsNullOrEmpty(text))
            {
                foreach (var item in cBDictionary.Items)
                {
                    if (item.ToString() == text)
                    {
                        cBDictionary.SelectedItem = item;
                        break;
                    }
                }
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);
            LocalConfiguration.SaveControlCustomParameter(nUDSymbolsCount, "Value", nUDSymbolsCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDWordsCount, "Value", nUDWordsCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(rbSymbols, "Checked", rbSymbols.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbDictionary, "Checked", rbDictionary.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cbRandomSymbols, "Checked", cbRandomSymbols.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(cBColor, "Checked", cBColor.Checked ? "1" : "0");

            if (cBDictionary.SelectedItem != null)
            {
                LocalConfiguration.SaveControlCustomParameter(cBDictionary, "SelectedItem", cBDictionary.SelectedItem.ToString());
            }

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Действия тестов.

        private void tBTestWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (defence.IsUnlocked())
                {
                    string userText = tBTestWord.Text.Trim();

                    train.MakeAction(userText);

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

        #endregion Действия тестов.

        #region Работа со словарем.

        void cBDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillWordCount();
        }

        private void FillWordCount()
        {
            int wordsCount = 0;

            if (cBDictionary.SelectedItem != null)
            {
                FileInfo file = (FileInfo)cBDictionary.SelectedItem;

                wordsCount = WordDictionary.GetWordsCount(file.FullName);
            }

            tStStatusWords.Text = wordsCount == 0 ? "Словарь отсутствует." : string.Format("Всего слов: {0}.", wordsCount);

            train.SelectedFile = cBDictionary.SelectedItem as FileInfo;
        }

        #endregion Работа со словарем.

        #region События клавиатуры.

        private void FormImpressionTrain_KeyDown(object sender, KeyEventArgs e)
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

        private void tBTestWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' || e.KeyChar == '-')
            {
                e.KeyChar = '\b';
            }
        }

        #endregion События клавиатуры.

        #region Изменение настроек.

        private void nUDVisibleTime_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDVisibleTime.Value);
        }

        private void nUDSymbolsCount_ValueChanged(object sender, EventArgs e)
        {
            train.SymbolsCount = Convert.ToInt32(nUDSymbolsCount.Value);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSymbols.Checked)
            {
                train.TestType = TrainTypeImpression.Symbols;
            }
            else if (rbDictionary.Checked)
            {
                train.TestType = TrainTypeImpression.Dictionary;
            }
        }

        private void cBColor_CheckedChanged(object sender, EventArgs e)
        {
            train.WithColor = cBColor.Checked;
        }

        private void cbRandomSymbols_CheckedChanged(object sender, EventArgs e)
        {
            train.WithRandomLiters = cbRandomSymbols.Checked;
        }

        private void nUDWordsCount_ValueChanged(object sender, EventArgs e)
        {
            train.WordsCount = Convert.ToInt32(nUDWordsCount.Value);
        }

        #endregion Изменение настроек.
    }
}