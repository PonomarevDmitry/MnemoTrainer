using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormAssociationPairTrain : Form
    {
        private readonly float baseFontSize;

        private DoubleClickDefence defence;

        private TrainMachineAssociationPair train;

        public FormAssociationPairTrain()
        {
            InitializeComponent();

            baseFontSize = lblNextWord.Font.Size;

            defence = new DoubleClickDefence(this.components);

            train = new TrainMachineAssociationPair();
            cBTimeForWord.Checked = train.IsAutoNextQuestion;
            nUDTimeForWord.Value = train.TimeShowing;
            nUDQuestionCount.Value = train.QuestionsCount;
            nUDWordsInPair.Value = train.WordsInQuestion;
            cBWithNumber.Checked = train.WithNumber;
            cBRandomPosition.Checked = train.RandomOrder;

            cBDictionary.DataSource = WordDictionary.SourcesFile;
            cBDictionary.DisplayMember = "Name";
            cBDictionary.SelectedIndexChanged += new EventHandler(cBDictionary_SelectedIndexChanged);

            LoadFormConfiguration();

            if (string.IsNullOrEmpty(tStStatusWords.Text))
            {
                FillWordCount();    
            }

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainNewQuestion += new EventHandler(train_TrainNewQuestion);
            train.TrainTestEnd += new EventHandler(train_TrainTestEnd);
            train.TrainFirstWords += new FirstWordsEventHandler(train_TrainFirstWords);
            train.TrainQuestionResult += new AssociationResultEventHandler(train_TrainQuestionResult);
            train.TrainStoped += new EventHandler(train_TrainStoped);
        }

        #region Обработчики событий.

        void train_TrainStarted(object sender, EventArgs e)
        {
            btnStartStop.Text = "Стоп";

            DeActivateSetupControls();
            gBAnswers.Visible = false;
            lblNextWord.Visible = true;
            lblNextWord.ForeColor = System.Drawing.Color.Green;

            tStStatusCounter.Text = string.Empty;
            tStStatusCounter.Visible = cBCounter.Checked;

            lblNextWord.Select();

            tSSTotalTimer.StartNew();
        }

        void train_TrainNewQuestion(object sender, EventArgs e)
        {
            if (cBCounter.Checked)
            {
                tStStatusCounter.Text = string.Format("{0} из {1}.", (train.QuestionIndex + 1).ToString(), train.QuestionsCount.ToString());
            }

            lblNextWord.Text = train.QuestionText;

            if (train.QuestionIndex % 2 == 0)
            {
                lblNextWord.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblNextWord.ForeColor = System.Drawing.Color.RoyalBlue;
            }

            tSSTestTimer.StartNew();

            lblNextWord.Select();

            defence.StartLock();
        }

        void train_TrainTestEnd(object sender, EventArgs e)
        {
            if (train.WithNumber)
            {
                btnStartStop.Text = "Список";
            }
            else
            {
                btnStartStop.Text = "Проверка";
            }

            lblNextWord.Text = "Конец!";
            lblNextWord.ForeColor = System.Drawing.Color.Red;

            tStStatusCounter.Text = string.Empty;
            tStStatusCounter.Visible = false;

            tSSTotalTimer.Stop();

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();

            defence.StartLock();
        }

        void train_TrainFirstWords(object sender, FirstWordsEventArgs e)
        {
            btnStartStop.Text = "Проверка";

            gBAnswers.Visible = true;
            lblNextWord.Visible = false;
            lblNextWord.Text = string.Empty;

            ShowFirstQuestionList(e.FirstWords);

            defence.StartLock();
        }

        void train_TrainQuestionResult(object sender, AssociationResultEventArgs e)
        {
            btnStartStop.Text = "Новый тест";

            ActivateSetupControls();
            gBAnswers.Visible = true;
            lblNextWord.Visible = false;
            lblNextWord.Text = string.Empty;

            ShowQuestionList(e.Associations);
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            btnStartStop.Text = "Новый тест";
            tStStatusCounter.Text = string.Empty;

            ActivateSetupControls();
            gBAnswers.Visible = false;
            lblNextWord.Visible = false;

            tSSTotalTimer.Stop();
            tSSTotalTimer.ClearTimerText();

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();
        }

        #endregion Обработчики событий.

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            string text;
            decimal tmpDecimal;

            text = LocalConfiguration.LoadControlCustomParameter(nUDQuestionCount, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDQuestionCount.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDWordsInPair, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDWordsInPair.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeForWord, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDTimeForWord.Value = tmpDecimal;
            }

            cBTimeForWord.Checked = LocalConfiguration.LoadControlCustomParameter(cBTimeForWord, "Checked") == "1";

            cBCounter.Checked = LocalConfiguration.LoadControlCustomParameter(cBCounter, "Checked") == "1";
            cBRandomPosition.Checked = LocalConfiguration.LoadControlCustomParameter(cBRandomPosition, "Checked") == "1";
            cBWithNumber.Checked = LocalConfiguration.LoadControlCustomParameter(cBWithNumber, "Checked") == "1";

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
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            LocalConfiguration.SaveControlCustomParameter(nUDQuestionCount, "Value", nUDQuestionCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDWordsInPair, "Value", nUDWordsInPair.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeForWord, "Value", nUDTimeForWord.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(cBTimeForWord, "Checked", cBTimeForWord.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(cBCounter, "Checked", cBCounter.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBRandomPosition, "Checked", cBRandomPosition.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBWithNumber, "Checked", cBWithNumber.Checked ? "1" : "0");

            if (cBDictionary.SelectedItem != null)
            {
                LocalConfiguration.SaveControlCustomParameter(cBDictionary, "SelectedItem", cBDictionary.SelectedItem.ToString());
            }

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

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

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (defence.IsUnlocked())
            {
                if (train.Status == MachineStatus.NotStarted || train.Status == MachineStatus.WaitingAnswer || train.Status == MachineStatus.Pause)
                {
                    train.MakeAction();

                    defence.StartLock();
                }
                else if (train.Status == MachineStatus.ShowingQuestion)
                {
                    AskCloseQuestion();

                    defence.StartLock();
                }
            }
        }

        #region Системные процедуры.

        private void AskCloseQuestion()
        {
            if (MessageBox.Show(this, "Вы действительно хотите прекратить тест?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                train.Stop();
            }
        }

        private void ShowFirstQuestionList(Collection<string> firstWords)
        {
            lBTestWords.Items.Clear();

            if (firstWords.Count > 0)
            {
                foreach (string item in firstWords)
                {
                    lBTestWords.Items.Add(item);
                }

                lBTestWords.SelectedIndex = 0;
            }

            lBTestWords.Select();
        }

        private void ShowQuestionList(Collection<AssociationQuestion> associationQuestions)
        {
            lBTestWords.Items.Clear();

            if (associationQuestions.Count > 0)
            {
                foreach (AssociationQuestion item in associationQuestions)
                {
                    lBTestWords.Items.Add(item);
                }

                lBTestWords.SelectedIndex = 0;
            }

            lBTestWords.Select();
        }

        #endregion Системные процедуры.

        private void ShowNextWord()
        {
            if (defence.IsUnlocked())
            {
                train.MakeAction();

                defence.StartLock();
            }
        }

        private void FormAssociationPairTrain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (train.Status != MachineStatus.NotStarted)
                {
                    AskCloseQuestion();
                }
                else
                {
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                ShowNextWord();
            }
        }

        private void lblNextWord_MouseClick(object sender, MouseEventArgs e)
        {
            ShowNextWord();
        }

        #region Активация и дезактивация контролов.

        private void ActivateSetupControls()
        {
            gBTimeForWord.Enabled = true;
            gBWords.Enabled = true;
            gBNumberSetup.Enabled = true;
            gBDictionary.Enabled = true;
        }

        private void DeActivateSetupControls()
        {
            gBTimeForWord.Enabled = false;
            gBWords.Enabled = false;
            gBNumberSetup.Enabled = false;
            gBDictionary.Enabled = false;
        }

        #endregion Активация и дезактивация контролов.

        #region Изменение настроек.

        private void cBTimeForWord_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoNextQuestion = cBTimeForWord.Checked;

            nUDTimeForWord.Enabled = cBTimeForWord.Checked;
            nUDTimeForWord.ReadOnly = !cBTimeForWord.Checked;
            nUDTimeForWord.Refresh();
        }

        private void cBWithNumber_CheckedChanged(object sender, EventArgs e)
        {
            train.WithNumber = cBWithNumber.Checked;

            cBRandomPosition.Enabled = cBWithNumber.Checked;
            if (!cBWithNumber.Checked)
            {
                cBRandomPosition.Checked = false;
            }
        }

        private void nUDQuestionCount_ValueChanged(object sender, EventArgs e)
        {
            train.QuestionsCount = Convert.ToInt32(nUDQuestionCount.Value);
        }

        private void nUDWordsInPair_ValueChanged(object sender, EventArgs e)
        {
            train.WordsInQuestion = Convert.ToInt32(nUDWordsInPair.Value);
        }

        private void nUDTimeForWord_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDTimeForWord.Value);
        }

        private void cBRandomPosition_CheckedChanged(object sender, EventArgs e)
        {
            train.RandomOrder = cBRandomPosition.Checked;
        }

        #endregion Изменение настроек.
    }
}
