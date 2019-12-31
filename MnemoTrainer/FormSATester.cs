using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainer.Controls;
using MnemoTrainer.Properties;
using SAClasses;
using SAClasses.Collections;

namespace MnemoTrainer
{
    public partial class FormSATester : Form
    {
        Controller saController = Engine.controller;

        public FormSATester()
        {
            InitializeComponent();

            for (int i = 0; i < 20; i++)
            {
                tSCBLinesCount.Items.Add(i + 1);
            }

            tSCBLinesCount.SelectedItem = saController.SelectedLinesCount;

            saController.CurrentLineChanged += new EventHandler(saController_CurrentLineChanged);
            saController.CurrentSAChanged += new EventHandler(saController_CurrentSAChanged);
            saController.HistoryChanged += new EventHandler(saController_HistoryChanged);

            tSCBLinesCount.SelectedIndexChanged += new EventHandler(tSCBLinesCount_SelectedIndexChanged);

            OperateSA();

            LoadFormConfiguration();

            panelLines.Select();
        }

        void tSCBLinesCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            saController.SelectedLinesCount = (int)tSCBLinesCount.SelectedItem;
            panelLines.Select();
        }

        #region Инициализация.

        public void LoadFormConfiguration()
        {
            string tempString = string.Empty;

            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Maximized | ConfigFormOption.Size);

            tempString = LocalConfiguration.LoadFormCustomParameter(this, "LinesCount");
            if (!string.IsNullOrEmpty(tempString))
            {
                int tempInt;
                if (int.TryParse(tempString, out tempInt))
                {
                    if (tSCBLinesCount.Items.Contains(tempInt))
                    {
                        tSCBLinesCount.SelectedItem = tempInt;
                    }
                }
            }

            LocalConfiguration.LoadControllerConfiguration(this, saController);
        }

        public void SaveFormConfiguration()
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Maximized | ConfigFormOption.Size);

            LocalConfiguration.SaveControllerConfiguration(this, saController);

            LocalConfiguration.SaveFormCustomParameter(this, "LinesCount", tSCBLinesCount.SelectedItem.ToString());

            ProgramConfiguraton.SaveXmlConfig();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            SaveFormConfiguration();
        }

        #endregion Инициализация.

        void saController_CurrentSAChanged(object sender, EventArgs e)
        {
            OperateSA();
        }

        void saController_CurrentLineChanged(object sender, EventArgs e)
        {
            OperateLines();
        }

        void saController_HistoryChanged(object sender, EventArgs e)
        {
            OperateHistory();
        }

        private void OperateSA()
        {
            bool hasSA = saController.SystemAccumulation != null;

            tSMIRandomLine.Enabled = tSMIRandomPoem.Enabled = tSMIBlock.Enabled = tSMIBlockPart.Enabled =
                tSMIPoem.Enabled = tSMIPoemPart.Enabled = tSMIPoemLine.Enabled
                = tSMISearch.Enabled = hasSA;

            BeginUpdate();

            cmBSABlock.Items.Clear();

            if (hasSA)
            {
                foreach (SABlock item in saController.SystemAccumulation.Blocks)
                {
                    cmBSABlock.Items.Add(item);
                }
            }

            EndUpdate();
        }

        private void FormTester_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space || e.KeyData == Keys.Right || e.KeyData == Keys.Down)
            {
                e.SuppressKeyPress = true;
                saController.GoLineNext();
            }
            else if (e.KeyData == Keys.Left || e.KeyData == Keys.Up)
            {
                e.SuppressKeyPress = true;
                saController.GoLinePrevious();
            }
            else if (e.KeyData == (Keys.Down | Keys.Control) || e.KeyData == (Keys.Right | Keys.Control))
            {
                e.SuppressKeyPress = true;
                saController.GoPoemNext();
            }
            else if (e.KeyData == (Keys.Up | Keys.Control) || e.KeyData == (Keys.Left | Keys.Control))
            {
                e.SuppressKeyPress = true;
                saController.GoPoemPreviousOrBegining();
            }
            else if (e.KeyData == Keys.PageDown)
            {
                e.SuppressKeyPress = true;
                saController.GoBlockNext();
            }
            else if (e.KeyData == Keys.PageUp)
            {
                e.SuppressKeyPress = true;
                saController.GoBlockPreviousOrBegining();
            }
            else if (e.KeyData == Keys.Back || e.KeyData == (Keys.Left | Keys.Alt))
            {
                e.SuppressKeyPress = true;
                saController.MoveHistoryPreviousLine();
            }
            else if (e.KeyData == (Keys.Back | Keys.Shift) || e.KeyData == (Keys.Right | Keys.Alt))
            {
                e.SuppressKeyPress = true;
                saController.MoveHistoryNextLine();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
        }

        #region Передвижение по элементам СН.

        #region Код меню.

        private void tSMIRandomLine_Click(object sender, EventArgs e)
        {
            saController.GetRandomLine();
        }

        private void tSMIRandomPoem_Click(object sender, EventArgs e)
        {
            saController.GetRandomPoem();
        }

        private void tSMIBlockNext_Click(object sender, EventArgs e)
        {
            saController.GoBlockNext();
        }

        private void tSMIBlockBegining_Click(object sender, EventArgs e)
        {
            saController.GoBlockBegining();
        }

        private void tSMIBlockPrevious_Click(object sender, EventArgs e)
        {
            saController.GoBlockPrevious();
        }

        private void tSMIBlockPartNext_Click(object sender, EventArgs e)
        {
            saController.GoBlockPartNext();
        }

        private void tSMIBlockPartBegining_Click(object sender, EventArgs e)
        {
            saController.GoBlockPartBegining();
        }

        private void tSMIBlockPartPrevious_Click(object sender, EventArgs e)
        {
            saController.GoBlockPartPrevious();
        }

        private void tSBPoemNext_Click(object sender, EventArgs e)
        {
            saController.GoPoemNext();
        }

        private void tSMIPoemBegining_Click(object sender, EventArgs e)
        {
            saController.GoPoemBegining();
        }

        private void tSBPoemPrevious_Click(object sender, EventArgs e)
        {
            saController.GoPoemPrevious();
        }

        private void tSMIPoemPartNext_Click(object sender, EventArgs e)
        {
            saController.GoPoemPartNext();
        }

        private void tSMIPoemPartBegining_Click(object sender, EventArgs e)
        {
            saController.GoPoemPartBegining();
        }

        private void tSMIPoemPartPrevious_Click(object sender, EventArgs e)
        {
            saController.GoPoemPartPrevious();
        }

        private void tSMIPoemLineNext_Click(object sender, EventArgs e)
        {
            saController.GoLineNext();
        }

        private void tSMIPoemLinePrevious_Click(object sender, EventArgs e)
        {
            saController.GoLinePrevious();
        }

        #endregion Код меню.

        #region Код кнопок.

        private void btnBlockNext_Click(object sender, EventArgs e)
        {
            saController.GoBlockNext();
        }

        private void btnBlockPrevious_Click(object sender, EventArgs e)
        {
            saController.GoBlockPrevious();
        }

        private void btnBlockPartNext_Click(object sender, EventArgs e)
        {
            saController.GoBlockPartNext();
        }

        private void btnBlockPartPrevious_Click(object sender, EventArgs e)
        {
            saController.GoBlockPartPrevious();
        }

        private void btnPoemNext_Click(object sender, EventArgs e)
        {
            saController.GoPoemNext();
        }

        private void btnPoemPrevious_Click(object sender, EventArgs e)
        {
            saController.GoPoemPrevious();
        }

        private void btnPoemPartNext_Click(object sender, EventArgs e)
        {
            saController.GoPoemPartNext();
        }

        private void btnPoemPartPrevious_Click(object sender, EventArgs e)
        {
            saController.GoPoemPartPrevious();
        }

        private void btnBlockBegining_Click(object sender, EventArgs e)
        {
            saController.GoBlockBegining();
        }

        private void btnBlockPartBegining_Click(object sender, EventArgs e)
        {
            saController.GoBlockPartBegining();
        }

        private void btnPoemBegining_Click(object sender, EventArgs e)
        {
            saController.GoPoemBegining();
        }

        private void btnPoemPartBegining_Click(object sender, EventArgs e)
        {
            saController.GoPoemPartBegining();
        }

        #endregion Код кнопок.

        #endregion Передвижение по элементам СН.

        #region События выбора в комбобоксах.

        private void cmBSABlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsUpdating())
            {
                return;
            }

            SABlock block = cmBSABlock.SelectedItem as SABlock;

            if (block != null)
            {
                saController.SetCurrentLine(block);
            }
        }

        private void cmBSABlockPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsUpdating())
            {
                return;
            }

            SABlockPart blockPart = cmBSABlockPart.SelectedItem as SABlockPart;

            if (blockPart != null)
            {
                saController.SetCurrentLine(blockPart);
            }
        }

        private void cmBPoem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsUpdating())
            {
                return;
            }

            Poem poem = cmBPoem.SelectedItem as Poem;

            if (poem != null)
            {
                saController.SetCurrentLine(poem);
            }
        }

        private void cmBPoemPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsUpdating())
            {
                return;
            }

            PoemPart poemPart = cmBPoemPart.SelectedItem as PoemPart;

            if (poemPart != null)
            {
                saController.SetCurrentLine(poemPart);
            }
        }

        #endregion События выбора в комбобоксах.

        #region Процедуры блокировки выбора элементов из комбо-боксов.

        private int _initCount = 0;

        private void BeginUpdate()
        {
            _initCount++;
        }

        private void EndUpdate()
        {
            _initCount--;
        }

        private bool IsUpdating()
        {
            return _initCount > 0;
        }

        #endregion Процедуры блокировки выбора элементов из комбо-боксов.

        #region Изменение составов списков.

        private void OperateHistory()
        {
            tSBClearHistory.Enabled = saController.CanMoveHistoryNextLine || saController.CanMoveHistoryPreviousLine;

            tSBGoToNext.Enabled = saController.CanMoveHistoryNextLine;
            tSBGoToPrevious.Enabled = saController.CanMoveHistoryPreviousLine;

            tSBGoToPrevious.DropDownItems.Clear();
            foreach (PoemLine line in saController.HistoryPreviousLines)
            {
                ToolStripMenuItem newPreviousMI = new ToolStripMenuItem();

                Image img = Common.GetImageByLine(line);

                if (img != null)
                {
                    newPreviousMI.Image = img;
                }
                else
                {
                    newPreviousMI.Image = Resources.PoemLine;
                }

                newPreviousMI.Tag = line;
                newPreviousMI.Text = line.Line;
                newPreviousMI.ToolTipText = line.GetFullInfo();

                tSBGoToPrevious.DropDownItems.Add(newPreviousMI);
            }

            if (tSBGoToPrevious.DropDownItems.Count > 0)
            {
                tSBGoToPrevious.Text = string.Format("Назад: {0}", tSBGoToPrevious.DropDownItems.Count.ToString());
            }
            else
            {
                tSBGoToPrevious.Text = "Назад";
            }

            tSBGoToNext.DropDownItems.Clear();
            foreach (PoemLine line in saController.HistoryNextLines)
            {
                ToolStripMenuItem newNextMI = new ToolStripMenuItem();

                Image img = Common.GetImageByLine(line);

                if (img != null)
                {
                    newNextMI.Image = img;
                }
                else
                {
                    newNextMI.Image = Resources.PoemLine;
                }

                newNextMI.Tag = line;
                newNextMI.Text = line.Line;
                newNextMI.ToolTipText = line.GetFullInfo();

                tSBGoToNext.DropDownItems.Add(newNextMI);
            }

            if (tSBGoToNext.DropDownItems.Count > 0)
            {
                tSBGoToNext.Text = string.Format("Вперед: {0}", tSBGoToNext.DropDownItems.Count.ToString());
            }
            else
            {
                tSBGoToNext.Text = "Вперед";
            }
        }

        private void OperateLines()
        {
            if (saController.CurrentLine != null)
            {
                PoemLine curLine = saController.CurrentLine;

                PoemPart curPoemPart = curLine.ParentPoemPart;
                Poem curPoem = curLine.ParentPoem;

                SABlockPart curBlockPart = curPoem.ParentBlockPart;
                SABlock curBlock = curPoem.ParentBlock;

                if (cmBSABlock.Items.Contains(curBlock))
                {
                    if (cmBSABlock.SelectedItem != curBlock)
                    {
                        BeginUpdate();

                        cmBSABlock.SelectedItem = curBlock;

                        FillSABlockElements(curBlock);

                        EndUpdate();
                    }
                }

                if (curBlockPart != null)
                {
                    if (!cmBSABlockPart.Items.Contains(curBlockPart))
                    {
                        FillSABlockElements(curBlock);
                    }

                    if (cmBSABlockPart.SelectedItem != curBlockPart)
                    {
                        BeginUpdate();

                        cmBSABlockPart.SelectedItem = curBlockPart;

                        FillPoems(curBlockPart.Poems);

                        EndUpdate();
                    }
                }
                else
                {
                    cmBSABlockPart.Items.Clear();
                }

                {
                    if (!cmBPoem.Items.Contains(curPoem))
                    {
                        if (curBlockPart != null)
                        {
                            FillPoems(curBlockPart.Poems);
                        }
                        else
                        {
                            FillPoems(curBlock.Poems);
                        }
                    }

                    if (cmBPoem.SelectedItem != curPoem)
                    {
                        BeginUpdate();

                        cmBPoem.SelectedItem = curPoem;

                        EndUpdate();
                    }
                }

                if (curPoemPart != null)
                {
                    if (!cmBPoemPart.Items.Contains(curPoemPart))
                    {
                        FillPoemParts(curPoem.Parts);
                    }

                    if (cmBPoemPart.SelectedItem != curPoemPart)
                    {
                        BeginUpdate();

                        cmBPoemPart.SelectedItem = curPoemPart;

                        EndUpdate();
                    }
                }
                else
                {
                    cmBPoemPart.Items.Clear();
                }
            }
            else
            {
                cmBSABlock.SelectedIndex = -1;

                cmBSABlockPart.Items.Clear();
                cmBPoem.Items.Clear();
                cmBPoemPart.Items.Clear();
            }

            gBSABlockPart.Enabled = cmBSABlockPart.Items.Count > 0;
            gBPoem.Enabled = cmBPoem.Items.Count > 0;
            gBPoemPart.Enabled = cmBPoemPart.Items.Count > 0;

            {
                Collection<ControlPoemLine> controlsToDelete = new Collection<ControlPoemLine>();

                foreach (Control item in panelLines.Controls)
                {
                    ControlPoemLine controlPoemLine = item as ControlPoemLine;
                    if (controlPoemLine != null)
                    {
                        if (!saController.SelectedLines.Contains(controlPoemLine.PoemLine))
                        {
                            controlsToDelete.Add(controlPoemLine);
                        }
                    }
                }

                panelLines.SuspendLayout();

                foreach (ControlPoemLine item in controlsToDelete)
                {
                    panelLines.Controls.Remove(item);
                }

                foreach (PoemLine line in saController.SelectedLines)
                {
                    ControlPoemLine controlPoemLine = null;
                    foreach (Control item in panelLines.Controls)
                    {
                        ControlPoemLine searchControlPoemLine = item as ControlPoemLine;
                        if (searchControlPoemLine != null)
                        {
                            if (searchControlPoemLine.PoemLine == line)
                            {
                                controlPoemLine = searchControlPoemLine;
                                break;
                            }
                        }
                    }

                    if (controlPoemLine == null)
                    {
                        controlPoemLine = new ControlPoemLine(line);
                        controlPoemLine.Dock = DockStyle.Bottom;

                        panelLines.Controls.Add(controlPoemLine);
                    }

                    int childIndex = panelLines.Controls.GetChildIndex(controlPoemLine);
                    if (childIndex != saController.SelectedLines.IndexOf(line))
                    {
                        panelLines.Controls.SetChildIndex(controlPoemLine, saController.SelectedLines.IndexOf(line));
                    }
                }

                panelLines.ResumeLayout(true);
            }

            panelLines.Select();
        }

        private void FillSABlockElements(SABlock curBlock)
        {
            BeginUpdate();

            cmBSABlockPart.Items.Clear();

            foreach (SABlockPart item in curBlock.Parts)
            {
                cmBSABlockPart.Items.Add(item);
            }

            FillPoems(curBlock.Poems);

            EndUpdate();
        }

        private void FillPoems(PoemCollection poemColl)
        {
            BeginUpdate();

            cmBPoem.Items.Clear();

            foreach (Poem item in poemColl)
            {
                cmBPoem.Items.Add(item);
            }

            EndUpdate();
        }

        private void FillPoemParts(PoemPartCollection poemPartColl)
        {
            BeginUpdate();

            cmBPoemPart.Items.Clear();

            foreach (PoemPart item in poemPartColl)
            {
                cmBPoemPart.Items.Add(item);
            }

            EndUpdate();
        }

        #endregion Изменение составов списков.

        private void tSMISearch_Click(object sender, EventArgs e)
        {
            FormSASearch findForm = GetFindForm();

            findForm.Activate();
            findForm.Show();
        }

        private FormSASearch GetFindForm()
        {
            foreach (Form item in this.OwnedForms)
            {
                if (item is FormSASearch)
                {
                    return (FormSASearch)item;
                }
            }

            FormSASearch form = new FormSASearch(this);

            form.LineSelectionChanged += new SelectInTreeEventHandler(form_LineSelectionChanged);

            return form;
        }

        void form_LineSelectionChanged(object sender, SelectInTreeEventArgs e)
        {
            OpenFormSAConfig(e.Line);
        }

        private void tSMISA_Click(object sender, EventArgs e)
        {
            OpenFormSAConfig(Engine.controller.CurrentLine);
        }

        private void OpenFormSAConfig(PoemLine line)
        {
            FormSAConfig form = GetFormSAConfig();
            form.Owner = this;

            if (line != null)
            {
                form.SelectInTree(line);
            }

            form.Activate();
            form.Show();
        }

        private FormSAConfig GetFormSAConfig()
        {
            foreach (Form item in this.OwnedForms)
            {
                if (item is FormSAConfig)
                {
                    return (FormSAConfig)item;
                }
            }

            FormSAConfig form = new FormSAConfig();

            return form;
        }

        private void tSBGoToPrevious_Click(object sender, EventArgs e)
        {
            saController.MoveHistoryPreviousLine();
        }

        private void tSBGoToNext_Click(object sender, EventArgs e)
        {
            saController.MoveHistoryNextLine();
        }

        private void tSBGoToPrevious_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int itemIndex = tSBGoToPrevious.DropDownItems.IndexOf(e.ClickedItem);

            saController.MoveHistoryPreviousLineByIndex(itemIndex);
        }

        private void tSBGoToNext_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int itemIndex = tSBGoToNext.DropDownItems.IndexOf(e.ClickedItem);

            saController.MoveHistoryNextLineByIndex(itemIndex);
        }

        private void tSBClearHistory_Click(object sender, EventArgs e)
        {
            saController.ClearHistory();
        }
    }
}
