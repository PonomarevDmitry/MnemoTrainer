using System;
using System.IO;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormNumericAlphabetTrain : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineNumericAlphabet train;

        public FormNumericAlphabetTrain()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            train = new TrainMachineNumericAlphabet();
            train.TestType = TrainTypeNumericAlphaget.Number;

            lblTestWord.Text = string.Empty;
            lblTestWord.Visible = false;

            lblCheckResult.Text = string.Empty;
            lblCheckResult.Visible = false;

            cBDictionary.DataSource = WordDictionary.SourcesFile;
            cBDictionary.DisplayMember = "Name";
            cBDictionary.SelectedIndexChanged += new EventHandler(cBDictionary_SelectedIndexChanged);

            LoadFormConfiguration();

            if (string.IsNullOrEmpty(tStStatusWords.Text))
            {
                FillWordCount();
            }

            Common.SetTextBoxOnlyNumbers(tBTestWord);

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

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text = LocalConfiguration.LoadControlCustomParameter(nUDVisibleTime, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDVisibleTime.Value = temp;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeForAnswer, "Value");
            if (!string.IsNullOrEmpty(text) && int.TryParse(text, out temp))
            {
                nUDTimeForAnswer.Value = temp;
            }

            cBVisionTime.Checked = LocalConfiguration.LoadControlCustomParameter(cBVisionTime, "Checked") == "1";
            cBTimeForAnswer.Checked = LocalConfiguration.LoadControlCustomParameter(cBTimeForAnswer, "Checked") == "1";

            rbNumber.Checked = LocalConfiguration.LoadControlCustomParameter(rbNumber, "Checked") == "1";
            rbSum.Checked = LocalConfiguration.LoadControlCustomParameter(rbSum, "Checked") == "1";

            if (!rbSum.Checked && !rbNumber.Checked)
            {
                rbNumber.Checked = true;
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
            LocalConfiguration.SaveControlCustomParameter(nUDVisibleTime, "Value", nUDVisibleTime.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeForAnswer, "Value", nUDTimeForAnswer.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(cBVisionTime, "Checked", cBVisionTime.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBTimeForAnswer, "Checked", cBTimeForAnswer.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(rbNumber, "Checked", rbNumber.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbSum, "Checked", rbSum.Checked ? "1" : "0");

            if (cBDictionary.SelectedItem != null)
            {
                LocalConfiguration.SaveControlCustomParameter(cBDictionary, "SelectedItem", cBDictionary.SelectedItem.ToString());
            }

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

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

        private void FormNumericAlphabetTrain_KeyDown(object sender, KeyEventArgs e)
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

        private void cBVisionTime_CheckedChanged(object sender, EventArgs e)
        {
            train.IsHideQuestion = cBVisionTime.Checked;
            tBTestWord.Select();
        }

        private void cBTimeForAnswer_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoAnswer = cBTimeForAnswer.Checked;
            tBTestWord.Select();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNumber.Checked)
            {
                train.TestType = TrainTypeNumericAlphaget.Number;
            }
            else if (rbSum.Checked)
            {
                train.TestType = TrainTypeNumericAlphaget.Sum;
            }
        }

        #endregion Изменение настроек теста.
    }
}
