using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary;
using SAClasses;
using SAClasses.Collections;
using SAClasses.Interators;

namespace MnemoTrainer
{
    public partial class FormSAConfig : Form
    {
        public FormSAConfig()
        {
            InitializeComponent();

            if (Engine.controller.SystemAccumulation != null)
            {
                CreateTreeBySA(Engine.controller.SystemAccumulation);
            }

            LoadFormConfiguration();
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

        #region Построение дерева СН.

        private void CreateTreeBySA(SA sA)
        {
            tVSA.BeginUpdate();
            tVSA.Nodes.Clear();

            TreeNode nodeSA = new TreeNode();
            nodeSA.Text = sA.Name;
            nodeSA.Tag = sA;
            nodeSA.Expand();

            nodeSA.ImageKey = nodeSA.SelectedImageKey = "SA";
            nodeSA.ContextMenuStrip = contMSTreeNode;

            foreach (SABlock block in sA.Blocks)
            {
                TreeNode nodeBlock = new TreeNode();
                nodeBlock.Text = block.ToString();
                nodeBlock.Tag = block;

                nodeBlock.ImageKey = nodeBlock.SelectedImageKey = "SABlock";
                nodeBlock.ContextMenuStrip = contMSTreeNode;

                nodeSA.Nodes.Add(nodeBlock);

                FillBlockContent(nodeBlock, block);
            }

            tVSA.Nodes.Add(nodeSA);
            tVSA.EndUpdate();
        }

        private void FillBlockContent(TreeNode nodeBlock, SABlock block)
        {
            if (block.Parts.Count > 0)
            {
                foreach (SABlockPart blockPart in block.Parts)
                {
                    TreeNode nodeBlockPart = new TreeNode();
                    nodeBlockPart.Text = blockPart.ToString();
                    nodeBlockPart.Tag = blockPart;

                    nodeBlockPart.ImageKey = nodeBlockPart.SelectedImageKey = "SABlockPart";
                    nodeBlockPart.ContextMenuStrip = contMSTreeNode;

                    nodeBlock.Nodes.Add(nodeBlockPart);

                    FillPoemCollection(nodeBlockPart, blockPart.Poems);
                }
            }
            else
            {
                FillPoemCollection(nodeBlock, block.Poems);
            }
        }

        private void FillPoemCollection(TreeNode parentNode, PoemCollection poemColl)
        {
            foreach (Poem poem in poemColl)
            {
                TreeNode nodePoem = new TreeNode();
                nodePoem.Text = poem.ToString();
                nodePoem.Tag = poem;

                nodePoem.ImageKey = nodePoem.SelectedImageKey = "Poem";
                nodePoem.ContextMenuStrip = contMSTreeNode;

                parentNode.Nodes.Add(nodePoem);

                FillPoemContent(nodePoem, poem);
            }
        }

        private void FillPoemContent(TreeNode nodePoem, Poem poem)
        {
            if (poem.Parts.Count > 0)
            {
                foreach (PoemPart poemPart in poem.Parts)
                {
                    TreeNode nodePoemPart = new TreeNode();
                    nodePoemPart.Text = poemPart.ToString();
                    nodePoemPart.Tag = poemPart;

                    nodePoemPart.ImageKey = nodePoemPart.SelectedImageKey = "PoemPart";
                    nodePoemPart.ContextMenuStrip = contMSTreeNode;

                    nodePoem.Nodes.Add(nodePoemPart);

                    FillPoemLineCollection(nodePoemPart, poemPart.Lines);
                }
            }
            else
            {
                FillPoemLineCollection(nodePoem, poem.Lines);
            }
        }

        private void FillPoemLineCollection(TreeNode parentNode, PoemLinesCollection lines)
        {
            foreach (PoemLine poemLine in lines)
            {
                TreeNode nodeLine = new TreeNode();
                nodeLine.Text = poemLine.ToString();
                nodeLine.Tag = poemLine;

                nodeLine.ImageKey = nodeLine.SelectedImageKey = "PoemLine";
                nodeLine.ContextMenuStrip = contMSTreeNode;

                parentNode.Nodes.Add(nodeLine);
            }
        }

        #endregion Построение дерева СН.

        #region Тестирование.


        private void TestSA(SA sA)
        {
            int errorsCount = 0;

            foreach (SABlock itemBlock in sA.Blocks)
            {
                if (itemBlock.ParentSA != sA)
                {
                    errorsCount++;
                }

                foreach (SABlockPart itemBlockPart in itemBlock.Parts)
                {
                    if (itemBlockPart.ParentBlock != itemBlock)
                    {
                        errorsCount++;
                    }

                    foreach (Poem itemPoem in itemBlockPart.Poems)
                    {
                        if (itemPoem.ParentBlock != itemBlock || itemPoem.ParentBlockPart != itemBlockPart)
                        {
                            errorsCount++;
                        }

                        foreach (PoemPart itemPoemPart in itemPoem.Parts)
                        {
                            if (itemPoemPart.ParentPoem != itemPoem)
                            {
                                errorsCount++;
                            }

                            foreach (PoemLine itemLine in itemPoemPart.Lines)
                            {
                                if (itemLine.ParentPoem != itemPoem || itemLine.ParentPoemPart != itemPoemPart)
                                {
                                    errorsCount++;
                                }
                            }
                        }
                    }
                }

                foreach (Poem itemPoem in itemBlock.Poems)
                {
                    if (itemPoem.ParentBlock != itemBlock || itemPoem.ParentBlockPart != null)
                    {
                        errorsCount++;
                    }

                    foreach (PoemPart itemPoemPart in itemPoem.Parts)
                    {
                        if (itemPoemPart.ParentPoem != itemPoem)
                        {
                            errorsCount++;
                        }

                        foreach (PoemLine itemLine in itemPoemPart.Lines)
                        {
                            if (itemLine.ParentPoem != itemPoem || itemLine.ParentPoemPart != itemPoemPart)
                            {
                                errorsCount++;
                            }
                        }
                    }
                }
            }

            MessageBox.Show(errorsCount.ToString());
        }

        private void TestController()
        {
            Controller saController = new Controller();
            saController.SystemAccumulation = Engine.controller.SystemAccumulation;

            IteratorSA iter = new IteratorSA();

            PoemLine firstLine = Engine.controller.SystemAccumulation.GetFirstLine();

            PoemLine curLine = firstLine;

            do
            {
                saController.SetCurrentLine(curLine);

                PoemLineIdentifier position = saController.GetCurrentLineID();

                saController.Clear();

                saController.SetCurrentLineByID(position);

                if (saController.CurrentLine != curLine)
                {
                    MessageBox.Show("Ошибка");
                }

                curLine = iter.GetNextLine(curLine, true);

            } while (curLine != firstLine);
        }

        #endregion Тестирование.

        #region Код кнопок меню.

        private void tSMILoadFromXml_Click(object sender, EventArgs e)
        {
            LoadFromXml();
        }

        private void tSMISaveIntoXml_Click(object sender, EventArgs e)
        {
            SaveInfoXml();
        }

        private void tSMIClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tSMILoadFromFolder_Click(object sender, EventArgs e)
        {
            LoadFromRtfFolder();
        }

        private void tSMILoadFromRtfFile_Click(object sender, EventArgs e)
        {
            LoadFromSingleRtfFile();
        }

        #endregion Код кнопок меню.

        #region Работа с файлами.

        private void LoadFromSingleRtfFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.FilterIndex = 1;
                dialog.Filter = "Текст в формате RTF (*.rtf)|*.rtf";
                dialog.RestoreDirectory = true;
                dialog.InitialDirectory = Config.SystemAccumulationRtfLibrary;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Engine.controller.SystemAccumulation = SAConstructor.CreateSAFromSingleRtfFile(dialog.FileName);

                    CreateTreeBySA(Engine.controller.SystemAccumulation);

                    //TestSA(this.mySA);
                }
            }
        }

        private void LoadFromRtfFolder()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = Config.SystemAccumulationRtfLibrary;
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DirectoryInfo directory = new DirectoryInfo(dialog.SelectedPath);

                    Engine.controller.SystemAccumulation = SAConstructor.CreateSAFromRFTFiles(directory);

                    CreateTreeBySA(Engine.controller.SystemAccumulation);
                }
            }
        }

        private void LoadFromXml()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.FilterIndex = 1;
                dialog.Filter = "Файлы XML (*.xml)|*.xml";
                dialog.RestoreDirectory = true;
                dialog.InitialDirectory = Config.LocalSettingFolder;
                dialog.FileName = Path.GetFileName(Config.SystemAccumulationFileName);

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Engine.controller.SystemAccumulation = SASerializer.CreateSAFromXml(dialog.FileName);

                    CreateTreeBySA(Engine.controller.SystemAccumulation);

                    //TestSA(this.mySA);
                }
            }
        }

        private void SaveInfoXml()
        {
            if (Engine.controller.SystemAccumulation != null)
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.FilterIndex = 1;
                    dialog.Filter = "Файлы XML (*.xml)|*.xml";
                    dialog.RestoreDirectory = true;
                    dialog.InitialDirectory = Config.LocalSettingFolder;
                    dialog.FileName = Path.GetFileName(Config.SystemAccumulationFileName);

                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        SASerializer.CreateSAFile(dialog.FileName, Engine.controller.SystemAccumulation);
                    }
                }
            }
        }

        #endregion Работа с файлами.

        #region Контекстное меню.

        TreeNode clickedNode = null;

        private void contMSSA_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;

            Point point = new Point(menu.Left, menu.Top);

            point = tVSA.PointToClient(point);

            TreeNode item = tVSA.GetNodeAt(point);

            clickedNode = item;

            EditRandomMenuList(clickedNode);
        }

        private void EditRandomMenuList(TreeNode clickedNode)
        {
            tSMIRandomBlock.Visible = tSMIRandomBlock.Enabled =
            tSMIRandomBlockPart.Visible = tSMIRandomBlockPart.Enabled =
            tSMIRandomPoem.Visible = tSMIRandomPoem.Enabled =
            tSMIRandomPoemPart.Visible = tSMIRandomPoemPart.Enabled =
            tSMIRandomLine.Visible = tSMIRandomLine.Enabled = false;

            if (clickedNode.Tag != null)
            {
                object obj = clickedNode.Tag;

                if (obj is SA)
                {
                    tSMIRandomBlock.Visible = tSMIRandomBlock.Enabled =
                    tSMIRandomPoem.Visible = tSMIRandomPoem.Enabled =
                    tSMIRandomLine.Visible = tSMIRandomLine.Enabled = true;
                }
                else if (obj is SABlock)
                {
                    tSMIRandomPoem.Visible = tSMIRandomPoem.Enabled =
                    tSMIRandomLine.Visible = tSMIRandomLine.Enabled = true;

                    if ((obj as SABlock).Parts.Count > 0)
                    {
                        tSMIRandomBlockPart.Visible = tSMIRandomBlockPart.Enabled = true;
                    }
                }
                else if (obj is SABlockPart)
                {
                    tSMIRandomPoem.Visible = tSMIRandomPoem.Enabled =
                    tSMIRandomLine.Visible = tSMIRandomLine.Enabled = true;
                }
                else if (obj is Poem)
                {
                    tSMIRandomLine.Visible = tSMIRandomLine.Enabled = true;

                    if ((obj as Poem).Parts.Count > 0)
                    {
                        tSMIRandomPoemPart.Visible = tSMIRandomPoemPart.Enabled = true;
                    }
                }
                else if (obj is PoemPart)
                {
                    tSMIRandomLine.Visible = tSMIRandomLine.Enabled = true;
                }
            }
        }

        private void tSMIBegin_Click(object sender, EventArgs e)
        {
            if (clickedNode != null)
            {
                NodeBegin(clickedNode);

                clickedNode = null;
            }
        }

        private void NodeBegin(TreeNode clickedNode)
        {
            if (clickedNode.Tag != null)
            {
                object obj = clickedNode.Tag;

                if (obj is SA)
                {
                    Engine.controller.SetCurrentLine(((SA)obj).GetFirstLine());
                    this.Close();
                }
                else if (obj is SABlock)
                {
                    Engine.controller.SetCurrentLine(((SABlock)obj));
                    this.Close();
                }
                else if (obj is SABlockPart)
                {
                    Engine.controller.SetCurrentLine(((SABlockPart)obj));
                    this.Close();
                }
                else if (obj is Poem)
                {
                    Engine.controller.SetCurrentLine(((Poem)obj));
                    this.Close();
                }
                else if (obj is PoemPart)
                {
                    Engine.controller.SetCurrentLine(((PoemPart)obj));
                    this.Close();
                }
                else if (obj is PoemLine)
                {
                    Engine.controller.SetCurrentLine(((PoemLine)obj));
                    this.Close();
                }
            }
        }

        private void tVSA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tVSA.SelectedNode != null)
                {
                    NodeBegin(tVSA.SelectedNode);
                }
            }
        }

        #region Случайный выбор.

        private void tSMIRandomBlock_Click(object sender, EventArgs e)
        {
            if (clickedNode != null && clickedNode.Tag != null && clickedNode.Tag is SA)
            {
                Engine.controller.GetRandomBlock();
                this.Close();
            }
        }

        private void tSMIRandomBlockPart_Click(object sender, EventArgs e)
        {
            if (clickedNode != null && clickedNode.Tag != null && clickedNode.Tag is SABlock)
            {
                SABlock block = (SABlock)clickedNode.Tag;

                if (block.Parts.Count > 0)
                {
                    Engine.controller.GetRandomBlockPart(block);
                    this.Close();
                }
            }
        }

        private void tSMIRandomPoem_Click(object sender, EventArgs e)
        {
            if (clickedNode.Tag != null)
            {
                object obj = clickedNode.Tag;

                if (obj is SA)
                {
                    Engine.controller.GetRandomPoem();
                    this.Close();
                }
                else if (obj is SABlock)
                {
                    Engine.controller.GetRandomPoem((SABlock)obj);
                    this.Close();
                }
                else if (obj is SABlockPart)
                {
                    Engine.controller.GetRandomPoem((SABlockPart)obj);
                    this.Close();
                }
            }
        }

        private void tSMIRandomPoemPart_Click(object sender, EventArgs e)
        {
            if (clickedNode != null && clickedNode.Tag != null && clickedNode.Tag is Poem)
            {
                Poem poem = (Poem)clickedNode.Tag;

                if (poem.Parts.Count > 0)
                {
                    Engine.controller.GetRandomPoemPart(poem);
                    this.Close();
                }
            }
        }

        private void tSMIRandomLine_Click(object sender, EventArgs e)
        {
            if (clickedNode.Tag != null)
            {
                object obj = clickedNode.Tag;

                if (obj is SA)
                {
                    Engine.controller.GetRandomLine();
                    this.Close();
                }
                else if (obj is SABlock)
                {
                    Engine.controller.GetRandomLine((SABlock)obj);
                    this.Close();
                }
                else if (obj is SABlockPart)
                {
                    Engine.controller.GetRandomLine((SABlockPart)obj);
                    this.Close();
                }
                else if (obj is Poem)
                {
                    Engine.controller.GetRandomLine((Poem)obj);
                    this.Close();
                }
                else if (obj is PoemPart)
                {
                    Engine.controller.GetRandomLine((PoemPart)obj);
                    this.Close();
                }
            }
        }

        #endregion Случайный выбор.

        #endregion Контекстное меню.

        public void SelectInTree(PoemLine line)
        {
            PoemPart poemPart = line.ParentPoemPart;
            Poem poem = line.ParentPoem;

            SABlockPart blockPart = poem.ParentBlockPart;
            SABlock block = poem.ParentBlock;

            SA sa = block.ParentSA;

            if (tVSA.Nodes.Count == 0)
            {
                return;
            }

            TreeNode nodeSA = tVSA.Nodes[0];

            if (nodeSA.Tag != sa)
            {
                return;
            }

            TreeNode nodeBlock = null;

            foreach (TreeNode item in nodeSA.Nodes)
            {
                if (item.Tag == block)
                {
                    nodeBlock = item;
                    break;
                }
            }

            if (nodeBlock == null)
            {
                return;
            }

            if (blockPart != null)
            {
                TreeNode nodeBlockPart = null;

                foreach (TreeNode item in nodeBlock.Nodes)
                {
                    if (item.Tag == blockPart)
                    {
                        nodeBlockPart = item;
                        break;
                    }
                }

                if (nodeBlockPart == null)
                {
                    return;
                }

                nodeBlock = nodeBlockPart;
            }

            TreeNode nodePoem = null;

            foreach (TreeNode item in nodeBlock.Nodes)
            {
                if (item.Tag == poem)
                {
                    nodePoem = item;
                    break;
                }
            }

            if (nodePoem == null)
            {
                return;
            }

            if (poemPart != null)
            {
                TreeNode nodePoemPart = null;

                foreach (TreeNode item in nodeBlock.Nodes)
                {
                    if (item.Tag == poemPart)
                    {
                        nodePoemPart = item;
                        break;
                    }
                }

                if (nodePoemPart == null)
                {
                    return;
                }

                nodePoem = nodePoemPart;
            }

            TreeNode nodeLine = null;

            foreach (TreeNode item in nodePoem.Nodes)
            {
                if (item.Tag == line)
                {
                    nodeLine = item;
                    break;
                }
            }

            if (nodeLine != null)
            {
                tVSA.BeginUpdate();

                tVSA.CollapseAll();
                tVSA.SelectedNode = nodeLine;
                nodeLine.EnsureVisible();

                tVSA.EndUpdate();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();

                if (this.Owner != null)
                {
                    this.Owner.Activate();
                    this.Owner.Show();
                }
            }
        }


    }
}
