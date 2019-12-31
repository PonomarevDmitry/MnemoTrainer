using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;

namespace MnemoTrainer
{
    public partial class FormSelect : Form
    {
        private string clickedButton = string.Empty;

        public FormSelect()
        {
            InitializeComponent();

            LoadFormConfiguration();
        }

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            string text;

#if DEBUG
            text = ProgramConfiguraton.LoadFormCustomParameter(this, "LocalSettingFolder_Debug");
#else
            text = ProgramConfiguraton.LoadFormCustomParameter(this, "LocalSettingFolder");
#endif
            OperateLocalSettingsPath(text);

            text = ProgramConfiguraton.LoadFormCustomParameter(this, "ClickedButton");
            if (!string.IsNullOrEmpty(text))
            {
                Control[] controls = this.Controls.Find(text, true);
                if (controls.Length == 1 && controls[0] is Button)
                {
                    this.clickedButton = controls[0].Name;
                    controls[0].Select();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

#if DEBUG
            ProgramConfiguraton.SaveFormCustomParameter(this, "LocalSettingFolder_Debug", Config.LocalSettingFolder);
#else
            ProgramConfiguraton.SaveFormCustomParameter(this, "LocalSettingFolder", Config.LocalSettingFolder);
#endif

            ProgramConfiguraton.SaveFormCustomParameter(this, "ClickedButton", this.clickedButton);

            ProgramConfiguraton.SaveXmlConfig();

            base.OnFormClosed(e);
        }

        #endregion Инициализация.

        private void UpdateLabelsText()
        {
            //foreach (Control item in this.Controls)
            //{
            //    if (item is Label)
            //    {
            //        ((Label)item).Text = string.Empty;
            //    }
            //}

            Collection<ExerciseSerie> series = LogExercise.CreateSeriesForDate(DateTime.Now);

            Array trains = Enum.GetValues(typeof(TrainType));

            foreach (TrainType tr in trains)
            {
                if (tr != TrainType.None)
                {
                    Control[] controls = this.Controls.Find("lbl" + tr.ToString(), true);
                    if (controls.Length == 1 && controls[0] is Label)
                    {
                        Label lab = (Label)controls[0];

                        int totalCount = 0;
                        int totalErrors = 0;
                        double totalTime = 0;

                        foreach (ExerciseSerie ser in series)
                        {
                            if (ser.Type.Type == tr)
                            {
                                totalCount += ser.GetAttemptsCount;
                                totalErrors += ser.GetErrorsCount;
                                totalTime += ser.GetTimeTotal;
                            }
                        }

                        DateTime d = new DateTime();

                        if (totalTime != 0 && totalCount != 0)
                        {
                            d = d.AddSeconds(totalTime);

                            lab.Text = string.Format("{0} {1}({2})", d.ToLongTimeString(), totalCount.ToString(), totalErrors.ToString());
                        }
                        else
                        {
                            lab.Text = d.ToLongTimeString();
                        }

                        TimeSpan t = TimeSpan.FromSeconds(totalTime);
                        if (t.TotalMinutes < 15)
                        {
                            lab.ForeColor = Color.Black;
                        }
                        else
                        {
                            lab.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F9)
            {
                FormReport form = new FormReport();
                ShowChildForm(form);
            }
        }

        #region Отображение дочерних форм.

        private void ShowChildForm(Form form)
        {
            form.FormClosed += new FormClosedEventHandler(childForm_FormClosed);
            form.Show(this);
            form.Select();

            this.Hide();
            this.Enabled = false;
        }

        void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateLabelsText();

            Form childForm = sender as Form;
            childForm.Dispose();

            this.Enabled = true;
            this.Show();
            this.Select();
        }

        #endregion Отображение дочерних форм

        #region Все дочерние формы.

        private void btnAssociationTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainAssociation form = new FormTrainAssociation();
            ShowChildForm(form);
        }

        private void btnNetTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainNet form = new FormTrainNet();
            ShowChildForm(form);
        }

        private void btnNumberTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainAssociationNumber form = new FormTrainAssociationNumber();
            ShowChildForm(form);
        }

        private void btnStepanovTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainStepanov form = new FormTrainStepanov();
            ShowChildForm(form);
        }

        private void btnImpressionTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainImpression form = new FormTrainImpression();
            ShowChildForm(form);
        }

        private void btnDateTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainDate form = new FormTrainDate();
            ShowChildForm(form);
        }

        private void btnCalculateTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainCalculate form = new FormTrainCalculate();
            ShowChildForm(form);
        }

        private void btnMagicalphabetTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainMagicAlphabet form = new FormTrainMagicAlphabet();
            ShowChildForm(form);
        }

        private void btnNumericAlphabetTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainNumericAlphabet form = new FormTrainNumericAlphabet();
            ShowChildForm(form);
        }

        private void btnCalculationSeries_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainCalculationSeries form = new FormTrainCalculationSeries();
            ShowChildForm(form);
        }

        private void btnStrupTest_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainStrupTest form = new FormTrainStrupTest();
            ShowChildForm(form);
        }

        private void btnColorCircleTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainColorCircle form = new FormTrainColorCircle();
            ShowChildForm(form);
        }

        private void btnRecentMemoryTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainRecentMemory form = new FormTrainRecentMemory();
            ShowChildForm(form);
        }

        private void btnSecondArrowAttentionTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainSecondArrowAttention form = new FormTrainSecondArrowAttention();
            ShowChildForm(form);
        }

        private void btnNumberGenerator_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainNumberGenerator form = new FormTrainNumberGenerator();
            ShowChildForm(form);
        }

        private void btnClosedAssociationTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainAssociationClosed form = new FormTrainAssociationClosed();
            ShowChildForm(form);
        }

        private void btnAssociationPairTrain_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrainAssociationPair form = new FormTrainAssociationPair();
            ShowChildForm(form);
        }

        private void btnInterruptionReading_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormInterruptionReading form = new FormInterruptionReading();
            ShowChildForm(form);
        }

        private void btn100For100_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormTrain100For100 form = new FormTrain100For100();
            ShowChildForm(form);
        }


        private void btnSystemAccumulation_Click(object sender, EventArgs e)
        {
            this.clickedButton = (sender as Control).Name;

            FormSATester form = new FormSATester();
            ShowChildForm(form);
        }

        #endregion Все дочерние формы.

        #region Папка для настроек, списков и логов.

        private void btnChoseDictionary_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

            openFileDialog.SelectedPath = Config.LocalSettingFolder;

            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OperateLocalSettingsPath(openFileDialog.SelectedPath);
            }
        }

        private void OperateLocalSettingsPath(string pathName)
        {
            if (Directory.Exists(pathName))
            {
                Config.LocalSettingFolder = pathName;
            }

            LocalConfiguration.LoadXmlConfig();
            txtBDictionaryName.Text = Config.LocalSettingFolder;

            UpdateLabelsText();
        }

        #endregion Папка для настроек, списков и логов.
    }
}
