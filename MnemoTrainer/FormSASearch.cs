using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using SAClasses;

namespace MnemoTrainer
{
    public partial class FormSASearch : Form
    {
        public FormSASearch(Form parentForm)
        {
            InitializeComponent();

            this.Owner = parentForm;

            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            LoadFormConfiguration();

            SetDefaultListViewColumnWidth();

            Engine.controller.CurrentSAChanged += new EventHandler(controller_CurrentSAChanged);
        }

        void controller_CurrentSAChanged(object sender, EventArgs e)
        {
            this.ClearSearchListView();
        }

        #region Инициализация.

        public void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);
        }

        public void SaveFormConfiguration()
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            ProgramConfiguraton.SaveXmlConfig();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            SaveFormConfiguration();
        }

        #endregion Инициализация.

        #region События.

        public event SelectInTreeEventHandler LineSelectionChanged;

        protected void OnLineSelectionChanged(PoemLine line)
        {
            if (LineSelectionChanged != null)
            {
                LineSelectionChanged(this, new SelectInTreeEventArgs(line));
            }
        }

        #endregion События.

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tBSearch.Select();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            tBSearch.Select();
        }

        #region Процедуры поиска в дереве по названию книги.

        private void tBBookSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
            }
        }

        private void btnPerformSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string searchPattern = tBSearch.Text.Replace(" ", "");
            if (!string.IsNullOrEmpty(searchPattern))
            {
                lVSearchResult.BeginUpdate();

                lVSearchResult.Items.Clear();

                Collection<PoemLine> result = new Collection<PoemLine>();

                if (Engine.controller.SystemAccumulation != null)
                {
                    result = Engine.controller.SystemAccumulation.Find(searchPattern);
                }

                FillResults(result);

                if (result.Count > 0)
                {
                    lVSearchResult.Items[0].Selected = true;

                    colHeadPoemLine.Width = -1;
                    colHeadPoem.Width = -1;
                    colHeadBlock.Width = -1;
                }
                else
                {
                    SetDefaultListViewColumnWidth();
                }

                lVSearchResult.EndUpdate();

                tSSLSearchResultCount.BorderSides = ToolStripStatusLabelBorderSides.Left;
                tSSLSearchResultCount.Text = string.Format("Найдено строк в системе накопления: {0}.", lVSearchResult.Items.Count);

                if (lVSearchResult.Items.Count == 0)
                {
                    MessageBox.Show(this, "Ничего не найдено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FillResults(Collection<PoemLine> result)
        {
            foreach (PoemLine item in result)
            {
                ListViewItem lvi = new ListViewItem(item.ToString(), "PoemLine");

                lvi.Tag = item;
                lvi.SubItems.Add(item.ParentPoem.ToString());
                lvi.SubItems.Add(item.ParentPoem.ParentBlock.ToString());

                lVSearchResult.Items.Add(lvi);
            }
        }

        private void SetDefaultListViewColumnWidth()
        {
            colHeadPoemLine.Width = 100;
            colHeadPoem.Width = 100;
            colHeadBlock.Width = -2;
        }

        #endregion Процедуры поиска в дереве по названию книги.

        #region События списка результатов поиска.

        private void lVBookSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lVSearchResult.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                BeginReadLine(item);
            }
        }

        private void BeginReadLine(ListViewItem item)
        {
            if (item.Tag != null && item.Tag is PoemLine)
            {
                this.Hide();

                Engine.controller.SetCurrentLine((PoemLine)item.Tag);

                this.Owner.Activate();
                this.Owner.Show();
            }
        }

        private void tSMIBeginLine_Click(object sender, EventArgs e)
        {
            if (lVSearchResult.SelectedItems.Count == 1)
            {
                ListViewItem item = lVSearchResult.SelectedItems[0];

                BeginReadLine(item);
            }
        }

        private void lVBookSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lVSearchResult.SelectedItems.Count == 1)
                {
                    ListViewItem item = lVSearchResult.SelectedItems[0];

                    BeginReadLine(item);
                }
            }
        }

        private void tSMIOpenInTree_Click(object sender, EventArgs e)
        {
            if (lVSearchResult.SelectedItems.Count == 1)
            {
                ListViewItem item = lVSearchResult.SelectedItems[0];

                PoemLine line = item.Tag as PoemLine;
                if (line != null)
                {
                    this.Hide();
                    OnLineSelectionChanged(line);
                }
            }
        }

        #endregion События списка результатов поиска.

        private void ClearSearchListView()
        {
            lVSearchResult.BeginUpdate();

            lVSearchResult.Items.Clear();
            SetDefaultListViewColumnWidth();

            lVSearchResult.EndUpdate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();

                this.Owner.Activate();
                this.Owner.Show();
            }
        }
    }
}
