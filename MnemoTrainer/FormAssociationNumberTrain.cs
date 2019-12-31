using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormAssociationNumberTrain : Form
    {
        private DoubleClickDefence defence;

        private TrainMachineAssociationNumber train;

        public FormAssociationNumberTrain()
        {
            InitializeComponent();

            defence = new DoubleClickDefence(this.components);

            train = new TrainMachineAssociationNumber();
            cBTimeForNumber.Checked = train.IsAutoNextQuestion;
            nUDTimeForNumber.Value = train.TimeShowing;
            nUDNumberCount.Value = train.NumbersCount;
            cBWithNumber.Checked = train.WithNumber;
            cBRandomPosition.Checked = train.RandomOrder;

            FillNetsComboBox();

            netCheckedListBox.ListBox.ItemCheck += new ItemCheckEventHandler(ListBox_ItemCheck);

            LoadFormConfiguration();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.TrainNewQuestion += new EventHandler(train_TrainNewQuestion);
            train.TrainTestEnd += new EventHandler(train_TrainTestEnd);
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
            btnStartStop.Text = "Проверка";

            lblNextWord.Text = "Конец!";
            lblNextWord.ForeColor = System.Drawing.Color.Red;

            tStStatusCounter.Text = string.Empty;
            tStStatusCounter.Visible = false;

            tSSTotalTimer.Stop();

            tSSTestTimer.Stop();
            tSSTestTimer.ClearTimerText();

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

        private void FillNetsComboBox()
        {
            foreach (Net item in train.SourceNets)
            {
                netCheckedListBox.ListBox.Items.Add(item, train.GetCheckState(item));
            }
        }

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            string text; decimal tmpDecimal;

            text = LocalConfiguration.LoadControlCustomParameter(nUDNumberCount, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDNumberCount.Value = tmpDecimal;
            }

            text = LocalConfiguration.LoadControlCustomParameter(nUDTimeForNumber, "Value");
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tmpDecimal))
            {
                nUDTimeForNumber.Value = tmpDecimal;
            }

            cBTimeForNumber.Checked = LocalConfiguration.LoadControlCustomParameter(cBTimeForNumber, "Checked") == "1";

            cBCounter.Checked = LocalConfiguration.LoadControlCustomParameter(cBCounter, "Checked") == "1";
            cBRandomPosition.Checked = LocalConfiguration.LoadControlCustomParameter(cBRandomPosition, "Checked") == "1";
            cBWithNumber.Checked = LocalConfiguration.LoadControlCustomParameter(cBWithNumber, "Checked") == "1";

            LocalConfiguration.LoadListCheckedItems(this, netCheckedListBox.ListBox);

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            LocalConfiguration.SaveControlCustomParameter(nUDNumberCount, "Value", nUDNumberCount.Value.ToString());
            LocalConfiguration.SaveControlCustomParameter(nUDTimeForNumber, "Value", nUDTimeForNumber.Value.ToString());

            LocalConfiguration.SaveControlCustomParameter(cBTimeForNumber, "Checked", cBTimeForNumber.Checked ? "1" : "0");

            LocalConfiguration.SaveControlCustomParameter(cBCounter, "Checked", cBCounter.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBRandomPosition, "Checked", cBRandomPosition.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(cBWithNumber, "Checked", cBWithNumber.Checked ? "1" : "0");

            LocalConfiguration.SaveListCheckedItems(this, netCheckedListBox.ListBox);

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region События отображения слова, начала нового теста.

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (defence.IsUnlocked())
            {
                if (train.Status == MachineStatus.NotStarted || train.Status == MachineStatus.WaitingAnswer)
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

        private void ShowNextWord()
        {
            if (defence.IsUnlocked())
            {
                train.MakeAction();

                defence.StartLock();
            }
        }

        #endregion События отображения слова, начала нового теста.

        #region Системные процедуры.

        private void AskCloseQuestion()
        {
            if (MessageBox.Show(this, "Вы действительно хотите прекратить тест?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                train.Stop();
            }
        }

        private void ShowQuestionList(Collection<AssociationQuestion> associationQuestions)
        {
            listBoxTestNumbers.Items.Clear();

            if (associationQuestions.Count > 0)
            {
                foreach (AssociationQuestion item in associationQuestions)
                {
                    listBoxTestNumbers.Items.Add(item);
                }

                listBoxTestNumbers.SelectedIndex = 0;
            }

            listBoxTestNumbers.Select();
        }

        #endregion Системные процедуры.

        #region События контролов и клавы.

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
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

        #endregion События контролов и клавы.

        #region Активация и дезактивация контролов.

        private void ActivateSetupControls()
        {
            gBTimeForNumber.Enabled = true;
            gBNumberCount.Enabled = true;
            gBNumberSetup.Enabled = true;

            gBNets.Enabled = true;
        }

        private void DeActivateSetupControls()
        {
            gBTimeForNumber.Enabled = false;
            gBNumberCount.Enabled = false;
            gBNumberSetup.Enabled = false;

            gBNets.Enabled = false;
        }

        #endregion Активация и дезактивация контролов.

        #region Изменение настроек.

        private void ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            train.SetCheckState(e.Index, e.NewValue == CheckState.Checked);
        }

        private void cBTimeForNumber_CheckedChanged(object sender, EventArgs e)
        {
            train.IsAutoNextQuestion = cBTimeForNumber.Checked;

            nUDTimeForNumber.ReadOnly = !cBTimeForNumber.Checked;
            nUDTimeForNumber.Enabled = cBTimeForNumber.Checked;

            nUDTimeForNumber.Refresh();
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

        private void nUDNumberCount_ValueChanged(object sender, EventArgs e)
        {
            train.NumbersCount = Convert.ToInt32(nUDNumberCount.Value);
        }

        private void nUDTimeForNumber_ValueChanged(object sender, EventArgs e)
        {
            train.TimeShowing = Convert.ToInt32(nUDTimeForNumber.Value);
        }

        private void cBRandomPosition_CheckedChanged(object sender, EventArgs e)
        {
            train.RandomOrder = cBRandomPosition.Checked;
        }

        #endregion Изменение настроек.
    }
}
