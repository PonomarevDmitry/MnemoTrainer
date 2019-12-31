using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormTrain100For100 : Form
    {
        private DoubleClickDefence defence;

        private TrainMachine100For100 train;

        private readonly float baseFontSize;

        public FormTrain100For100()
        {
            InitializeComponent();

            baseFontSize = lblTestWord.Font.Size;

            defence = new DoubleClickDefence(this.components) { Interval = 40 };

            lblTestWord.Text = string.Empty;

            lblTestWord.Select();

            train = new TrainMachine100For100();

            rbRandom.Checked = train.RandomOrder;
            rbStraight.Checked = !train.RandomOrder;

            OperateLists();

            train.StartTest += new EventHandler(train_StartTest);
            train.StopTest += new EventHandler(train_StopTest);
            train.NextElement += new EventHandler(train_NextElement);

            LoadFormConfiguration();

            RefreshControlView();
        }

        void train_StartTest(object sender, EventArgs e)
        {
            tSSOneTestTimer.StartNew();
            tSSTotalTimer.StartNew();
        }

        void train_StopTest(object sender, EventArgs e)
        {
            tSSLElementCount.Text = string.Empty;
            tSSLCurrentIndex.Text = string.Empty;

            lblTestWord.Text = string.Empty;

            tSSOneTestTimer.Stop();
            tSSOneTestTimer.ClearTimerText();

            tSSTotalTimer.Stop();
            tSSTotalTimer.ClearTimerText();
        }

        void train_NextElement(object sender, EventArgs e)
        {
            Common.SetLabelText(lblTestWord, baseFontSize, train.Element);

            lblTestWord.Select();

            tSSOneTestTimer.StartNew();

            if (train.IsFileSource)
            {
                tSSLCurrentIndex.Text = string.Format("Элемент № {0}.", train.CurrentIndex.ToString());
            }
            else
            {
                tSSLCurrentIndex.Text = string.Empty;
            }

            defence.StartLock();
        }

        #region Инициализация.

        private void OperateLists()
        {
            cBList.DisplayMember = "Name";

            cBList.Items.Clear();

            cBList.Items.Add(string.Empty);

            foreach (FileInfo item in this.train.SourcesFile)
            {
                cBList.Items.Add(item);
            }

            cBList.SelectedIndex = 0;
        }

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            rbStraight.Checked = LocalConfiguration.LoadControlCustomParameter(rbStraight, "Checked") == "1";
            rbRandom.Checked = LocalConfiguration.LoadControlCustomParameter(rbRandom, "Checked") == "1";

            if (!rbStraight.Checked && !rbRandom.Checked)
            {
                rbStraight.Checked = true;
            }

            string text = LocalConfiguration.LoadControlCustomParameter(cBList, "SelectedItem");
            if (!string.IsNullOrEmpty(text))
            {
                foreach (var item in cBList.Items)
                {
                    if (item.ToString() == text)
                    {
                        cBList.SelectedItem = item;
                        break;
                    }
                }
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            LocalConfiguration.SaveControlCustomParameter(rbStraight, "Checked", rbStraight.Checked ? "1" : "0");
            LocalConfiguration.SaveControlCustomParameter(rbRandom, "Checked", rbRandom.Checked ? "1" : "0");

            if (cBList.SelectedItem != null)
            {
                LocalConfiguration.SaveControlCustomParameter(cBList, "SelectedItem", cBList.SelectedItem.ToString());
            }

            train.Stop();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        private void Form100For100_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                PerformClick();
            }
        }

        private void Form100For100_MouseClick(object sender, MouseEventArgs e)
        {
            PerformClick();
        }

        private void lblTestWord_Click(object sender, EventArgs e)
        {
            PerformClick();
        }

        private void PerformClick()
        {
            if (train.Status == MachineStatus.NotStarted || train.Status == MachineStatus.ShowingQuestion)
            {
                if (defence.IsUnlocked())
                {
                    train.ShowNextNumber();
                }
            }
        }

        #region Изменение настроек.

        private void cBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControlView();
        }

        private void RefreshControlView()
        {
            this.train.SelectedSource = cBList.SelectedIndex - 1;

            bool isFile = this.train.IsFileSource;

            if (isFile)
            {
                rbRandom.ForeColor = rbStraight.ForeColor = SystemColors.ControlText;
            }
            else
            {
                rbRandom.ForeColor = rbStraight.ForeColor = SystemColors.GradientInactiveCaption;
            }

            string elementCountText = string.Empty;

            if (cBList.SelectedItem is FileInfo)
            {
                FileInfo file = cBList.SelectedItem as FileInfo;

                if (file != null && file.Exists)
                {
                    ArrayList list = WordDictionary.GetWordsFromFile(file.FullName);

                    elementCountText = string.Format("Всего элементов: {0}.", list.Count.ToString());
                }
            }

            tSSLElementCount.Text = elementCountText;

            tSBClearList.Enabled = isFile;
            tSBOpenList.Enabled = isFile;
        }

        private void rbStraight_CheckedChanged(object sender, EventArgs e)
        {
            this.train.RandomOrder = rbStraight.Checked ? false : true;
        }

        #endregion Изменение настроек.

        #region Кнопки панели управления списками.

        private void tSBOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Config.Train100For100Folder);
            }
            catch (Exception) { }
        }

        private void tSBRefreshLists_Click(object sender, EventArgs e)
        {
            this.train.RefreshSourcesFiles();

            OperateLists();
        }

        private void tSBOpenList_Click(object sender, EventArgs e)
        {
            if (cBList.SelectedItem is FileInfo)
            {
                FileInfo file = cBList.SelectedItem as FileInfo;

                if (file != null && file.Exists)
                {
                    try
                    {
                        Process.Start(file.FullName);
                    }
                    catch (Exception) { }
                }
            }
        }

        private void tSBClearList_Click(object sender, EventArgs e)
        {
            if (cBList.SelectedItem is FileInfo)
            {
                FileInfo file = cBList.SelectedItem as FileInfo;

                if (file != null && file.Exists)
                {
                    ArrayList list = WordDictionary.GetWordsFromFile(file.FullName);

                    StringBuilder sb = new StringBuilder();
                    foreach (string item in list)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }

                        sb.Append(item);
                    }

                    using (FileStream stream = File.Open(file.FullName, FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(stream))
                        {
                            sw.Write(sb.ToString());
                        }
                    }

                    MessageBox.Show(this, "Очистка окончена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion Кнопки панели управления списками.
    }
}
