using System;
using System.Text;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainer.Properties;
using MnemoTrainerLibrary.Train;

namespace MnemoTrainer
{
    public partial class FormInterruptionReading : Form
    {
        private DateTime bookStartTime;
        private DateTime bookEndTime;
        private int bookInterval = 0;

        System.Media.SoundPlayer player;

        private TrainMachineReading train;

        public FormInterruptionReading()
        {
            player = new System.Media.SoundPlayer(Resources.Change);
            player.Load();

            InitializeComponent();

            train = new TrainMachineReading();
            dTPInerruptionTime1.Value = dTPInerruptionTime1.MinDate.Add(TimeSpan.FromMilliseconds(train[0]));
            dTPInerruptionTime2.Value = dTPInerruptionTime1.MinDate.Add(TimeSpan.FromMilliseconds(train[1]));
            chBWithInterruption.Checked = train.WithInterruption;

            for (int index = 0; index < train.BookCount; index++)
            {
                cbTimer.Items.Add("Книга " + (index + 1).ToString());
            }

            cbTimer.SelectedIndex = 0;

            LoadFormConfiguration();

            train.TrainStarted += new EventHandler(train_TrainStarted);
            train.BookBegin += new EventHandler(train_BookBegin);
            train.BookEnd += new EventHandler(train_BookEnd);
            train.TrainStoped += new EventHandler(train_TrainStoped);

            ClearLabelText();
        }

        void train_TrainStarted(object sender, EventArgs e)
        {
            DeactivateControls();

            if (train.WithInterruption)
            {
                SignalChangeBook(train.CurrentIndex + 1);
            }
            else
            {
                StartBookTimer();
            }

            tSSTotalTimer.StartNew();

#if !DEBUG
            this.Hide();
#endif
        }

        void train_BookBegin(object sender, EventArgs e)
        {
            this.bookStartTime = DateTime.Now;
            this.bookInterval = train[train.CurrentIndex];
            this.bookEndTime = bookStartTime.AddMilliseconds(this.bookInterval);

            DateTime time = new DateTime().AddMilliseconds(this.bookInterval);

            lblBook.Text = string.Format("Книга {0}  -  {1}", (train.CurrentIndex + 1).ToString(), time.ToString("m м.ss с."));

            progressBar.Value = 0;

            StartBookTimer();
        }

        void train_BookEnd(object sender, EventArgs e)
        {
            StopBookTimer();
            WriteFullTimerText();

            SignalChangeBook(train.CurrentIndex + 1);
            player.Play();

            lblBook.Text = string.Format("Пауза. Далее Книга {0}", (train.CurrentIndex + 1).ToString());

            progressBar.Value = 0;
            lblProc.Text = string.Empty;
        }

        void train_TrainStoped(object sender, EventArgs e)
        {
            tSSTotalTimer.Stop();
            StopBookTimer();

            ActivateControls();
        }

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string tempText;

            foreach (Control item in gBTimers.Controls)
            {
                if (item is DateTimePicker)
                {
                    DateTimePicker dtp = item as DateTimePicker;

                    tempText = LocalConfiguration.LoadControlCustomParameter(dtp, "Time");
                    if (!string.IsNullOrEmpty(tempText))
                    {
                        double lg;
                        if (double.TryParse(tempText, out lg))
                        {
                            TimeSpan span = TimeSpan.FromSeconds(lg);

                            dtp.Value = DateTime.Today.Add(span);
                        }
                    }
                }
            }

            tempText = LocalConfiguration.LoadControlCustomParameter(cbTimer, "SelectedIndex");
            if (!string.IsNullOrEmpty(tempText))
            {
                int ind = 0;
                if (int.TryParse(tempText, out ind))
                {
                    if (ind < cbTimer.Items.Count)
                    {
                        cbTimer.SelectedIndex = ind;
                    }
                }
            }

            tempText = LocalConfiguration.LoadControlCustomParameter(chBWithInterruption, "Checked");
            if (!string.IsNullOrEmpty(tempText))
            {
                chBWithInterruption.Checked = tempText == "1";
            }

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            LocalConfiguration.SaveControlCustomParameter(cbTimer, "SelectedIndex", cbTimer.SelectedIndex.ToString());

            foreach (Control item in gBTimers.Controls)
            {
                if (item is DateTimePicker)
                {
                    DateTimePicker dtp = item as DateTimePicker;

                    TimeSpan span = dtp.Value - dtp.Value.Date;

                    LocalConfiguration.SaveControlCustomParameter(dtp, "Time", span.TotalSeconds.ToString());
                }
            }

            LocalConfiguration.SaveControlCustomParameter(chBWithInterruption, "Checked", chBWithInterruption.Checked ? "1" : "0");

            train.SaveExeruciseSerie();

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        #region Действия клавиатуры и кнопки.

        private void FormInterruptionReading_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnStartStop.PerformClick();
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (train.IsTrainEnabled)
            {
                train.Stop();
            }
            else
            {
                train.Start();
            }
        }

        #endregion Действия клавиатуры и кнопки.

        #region Таймеры книг.

        private void StartBookTimer()
        {
            WriteTimerText();
            timerBookTime.Start();
        }

        private void StopBookTimer()
        {
            timerBookTime.Stop();
            WriteTimerText();
        }

        private void timerBookTime_Tick(object sender, EventArgs e)
        {
            WriteTimerText();
        }

        private void WriteTimerText()
        {
            if (train.WithInterruption)
            {
                gBTimePass.Visible = true;
                gBTimeRemain.Visible = true;

                DateTime time = DateTime.Now;
                DateTime timePass = new DateTime();
                DateTime timeRemain = new DateTime();
                DateTime timeFull = new DateTime().AddMilliseconds(this.bookInterval);

                if (time < bookEndTime)
                {
                    timeRemain = timeRemain.Add(bookEndTime - time);

                    TimeSpan spanPass = time - bookStartTime;
                    timePass = timePass.Add(spanPass);

                    int stage = Convert.ToInt32(progressBar.Maximum * spanPass.TotalMilliseconds / this.bookInterval);

                    if (stage > 0 && progressBar.Value != stage)
                    {
                        progressBar.Value = stage;

                        int proc = 100 * stage / progressBar.Maximum;

                        lblProc.Text = string.Format("{0}%", proc.ToString());
                    }
                }
                else
                {
                    timePass = timePass.AddMilliseconds(this.bookInterval);
                }

                lblTimeRemain.Text = timeRemain.ToString("m:ss,f");
                lblTimePass.Text = timePass.ToString("m:ss,f");

                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("Книга {0}.", (train.CurrentIndex + 1).ToString());

                if (timerBookTime.Enabled)
                {
                    strBuilder.AppendFormat(" Осталось {0}.", timeRemain.ToString("m:ss"));
                    strBuilder.AppendLine();
                    strBuilder.AppendFormat("Прошло {0} из {1}.", timePass.ToString("m:ss"), timeFull.ToString("m:ss"));
                    strBuilder.AppendLine();
                    strBuilder.Append(tSSTotalTimer.Text);
                }

                if (nIReading.Text != strBuilder.ToString())
                {
                    nIReading.Text = strBuilder.ToString();
                }
            }
            else
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("Чтение.");

                if (timerBookTime.Enabled)
                {
                    strBuilder.AppendLine();
                    strBuilder.Append(tSSTotalTimer.Text);
                }

                if (nIReading.Text != strBuilder.ToString())
                {
                    nIReading.Text = strBuilder.ToString();
                }
            }
        }

        private void WriteFullTimerText()
        {
            gBTimePass.Visible = true;
            gBTimeRemain.Visible = true;

            DateTime timeRemain = new DateTime();
            DateTime timePass = timeRemain.AddMilliseconds(this.bookInterval);

            lblTimeRemain.Text = timeRemain.ToString("m:ss,f");
            lblTimePass.Text = timePass.ToString("m:ss,f");
        }

        private void ClearLabelText()
        {
            lblTimePass.Text = string.Empty;
            lblTimeRemain.Text = string.Empty;
            lblBook.Text = string.Empty;
            lblProc.Text = string.Empty;

            gBTimePass.Visible = false;
            gBTimeRemain.Visible = false;
        }

        #endregion Таймеры книг.

        private void SignalChangeBook(int bookNumber)
        {
            nIReading.BalloonTipTitle = string.Format("Смена на {0}", bookNumber);
            nIReading.BalloonTipText = string.Format("\r\nВремя выбрать книгу {0}", bookNumber);

            nIReading.ShowBalloonTip(train.TimePause);

            nIReading.Text = string.Format("Книга {0}.", bookNumber.ToString());
        }

        private void nIReading_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
                this.Focus();
                this.Select();
                this.Activate();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Hide();
            }
        }

        private void DeactivateControls()
        {
            gBTimers.Enabled = false;
            nIReading.Visible = true;
            chBWithInterruption.Enabled = false;

            btnStartStop.Text = "Закончить";
        }

        private void ActivateControls()
        {
            gBTimers.Enabled = true;
            nIReading.Visible = false;
            chBWithInterruption.Enabled = true;

            btnStartStop.Text = "Начать";
            nIReading.Text = "Чтение с прерыванием.";
        }

        #region Изменение настроек.

        private void cbTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimer.SelectedIndex != -1)
            {
                train.StartIndex = cbTimer.SelectedIndex;
            }
        }

        private void dTPInerruptionTime1_ValueChanged(object sender, EventArgs e)
        {
            train[0] = (int)dTPInerruptionTime1.Value.TimeOfDay.TotalMilliseconds;
        }

        private void dTPInerruptionTime2_ValueChanged(object sender, EventArgs e)
        {
            train[1] = (int)dTPInerruptionTime2.Value.TimeOfDay.TotalMilliseconds;
        }

        private void chBWithInterruption_CheckedChanged(object sender, EventArgs e)
        {
            train.WithInterruption = chBWithInterruption.Checked;
        }

        #endregion Изменение настроек.
    }
}
