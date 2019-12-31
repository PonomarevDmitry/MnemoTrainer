namespace MnemoTrainer
{
    partial class FormSAConfig
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSAConfig));
            this.tVSA = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tSMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMILoadFromXml = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMISaveIntoXml = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRtfUtils = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMILoadFromRtfFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMILoadFromFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIClose = new System.Windows.Forms.ToolStripMenuItem();
            this.contMSTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMISABegin = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRandomBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRandomBlockPart = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRandomPoem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRandomPoemPart = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRandomLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.contMSTreeNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tVSA
            // 
            this.tVSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVSA.ImageKey = "none";
            this.tVSA.ImageList = this.imageList;
            this.tVSA.Location = new System.Drawing.Point(0, 24);
            this.tVSA.Name = "tVSA";
            this.tVSA.SelectedImageKey = "none";
            this.tVSA.Size = new System.Drawing.Size(748, 598);
            this.tVSA.TabIndex = 2;
            this.tVSA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tVSA_KeyDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "SABlockPart");
            this.imageList.Images.SetKeyName(1, "none");
            this.imageList.Images.SetKeyName(2, "Poem");
            this.imageList.Images.SetKeyName(3, "PoemLine");
            this.imageList.Images.SetKeyName(4, "PoemPart");
            this.imageList.Images.SetKeyName(5, "SABlock");
            this.imageList.Images.SetKeyName(6, "SA");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIFile,
            this.tSMIRtfUtils,
            this.tSMIClose});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(748, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tSMIFile
            // 
            this.tSMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMILoadFromXml,
            this.tSMISaveIntoXml});
            this.tSMIFile.Image = global::MnemoTrainer.Properties.Resources.XMLFileHS;
            this.tSMIFile.Name = "tSMIFile";
            this.tSMIFile.Size = new System.Drawing.Size(61, 20);
            this.tSMIFile.Text = "Файл";
            // 
            // tSMILoadFromXml
            // 
            this.tSMILoadFromXml.Image = global::MnemoTrainer.Properties.Resources.OpenFile;
            this.tSMILoadFromXml.Name = "tSMILoadFromXml";
            this.tSMILoadFromXml.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tSMILoadFromXml.Size = new System.Drawing.Size(210, 22);
            this.tSMILoadFromXml.Text = "Загрузить из xml";
            this.tSMILoadFromXml.Click += new System.EventHandler(this.tSMILoadFromXml_Click);
            // 
            // tSMISaveIntoXml
            // 
            this.tSMISaveIntoXml.Image = global::MnemoTrainer.Properties.Resources.saveHS;
            this.tSMISaveIntoXml.Name = "tSMISaveIntoXml";
            this.tSMISaveIntoXml.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tSMISaveIntoXml.Size = new System.Drawing.Size(210, 22);
            this.tSMISaveIntoXml.Text = "Сохранить в xml";
            this.tSMISaveIntoXml.Click += new System.EventHandler(this.tSMISaveIntoXml_Click);
            // 
            // tSMIRtfUtils
            // 
            this.tSMIRtfUtils.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMILoadFromRtfFile,
            this.tSMILoadFromFolder});
            this.tSMIRtfUtils.Image = global::MnemoTrainer.Properties.Resources.ico_00289;
            this.tSMIRtfUtils.Name = "tSMIRtfUtils";
            this.tSMIRtfUtils.Size = new System.Drawing.Size(97, 20);
            this.tSMIRtfUtils.Text = "Работа с Rtf";
            // 
            // tSMILoadFromRtfFile
            // 
            this.tSMILoadFromRtfFile.Image = global::MnemoTrainer.Properties.Resources.ActualSizeHS;
            this.tSMILoadFromRtfFile.Name = "tSMILoadFromRtfFile";
            this.tSMILoadFromRtfFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tSMILoadFromRtfFile.Size = new System.Drawing.Size(264, 22);
            this.tSMILoadFromRtfFile.Text = "Загрузить из одного файла";
            this.tSMILoadFromRtfFile.Click += new System.EventHandler(this.tSMILoadFromRtfFile_Click);
            // 
            // tSMILoadFromFolder
            // 
            this.tSMILoadFromFolder.Image = global::MnemoTrainer.Properties.Resources.ico_01923;
            this.tSMILoadFromFolder.Name = "tSMILoadFromFolder";
            this.tSMILoadFromFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tSMILoadFromFolder.Size = new System.Drawing.Size(264, 22);
            this.tSMILoadFromFolder.Text = "Загрузить из папки";
            this.tSMILoadFromFolder.Click += new System.EventHandler(this.tSMILoadFromFolder_Click);
            // 
            // tSMIClose
            // 
            this.tSMIClose.Name = "tSMIClose";
            this.tSMIClose.Size = new System.Drawing.Size(63, 20);
            this.tSMIClose.Text = "Закрыть";
            this.tSMIClose.Click += new System.EventHandler(this.tSMIClose_Click);
            // 
            // contMSTreeNode
            // 
            this.contMSTreeNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMISABegin,
            this.tSMIRandomBlock,
            this.tSMIRandomBlockPart,
            this.tSMIRandomPoem,
            this.tSMIRandomPoemPart,
            this.tSMIRandomLine});
            this.contMSTreeNode.Name = "contMSDirectory";
            this.contMSTreeNode.Size = new System.Drawing.Size(195, 136);
            this.contMSTreeNode.Opening += new System.ComponentModel.CancelEventHandler(this.contMSSA_Opening);
            // 
            // tSMISABegin
            // 
            this.tSMISABegin.Image = global::MnemoTrainer.Properties.Resources.MoveNextHS;
            this.tSMISABegin.Name = "tSMISABegin";
            this.tSMISABegin.Size = new System.Drawing.Size(194, 22);
            this.tSMISABegin.Text = "Начать";
            this.tSMISABegin.Click += new System.EventHandler(this.tSMIBegin_Click);
            // 
            // tSMIRandomBlock
            // 
            this.tSMIRandomBlock.Image = global::MnemoTrainer.Properties.Resources.SABlock;
            this.tSMIRandomBlock.Name = "tSMIRandomBlock";
            this.tSMIRandomBlock.Size = new System.Drawing.Size(194, 22);
            this.tSMIRandomBlock.Text = "Случайный блок";
            this.tSMIRandomBlock.Click += new System.EventHandler(this.tSMIRandomBlock_Click);
            // 
            // tSMIRandomBlockPart
            // 
            this.tSMIRandomBlockPart.Image = global::MnemoTrainer.Properties.Resources.SABlockPart;
            this.tSMIRandomBlockPart.Name = "tSMIRandomBlockPart";
            this.tSMIRandomBlockPart.Size = new System.Drawing.Size(194, 22);
            this.tSMIRandomBlockPart.Text = "Случайная часть блока";
            this.tSMIRandomBlockPart.Click += new System.EventHandler(this.tSMIRandomBlockPart_Click);
            // 
            // tSMIRandomPoem
            // 
            this.tSMIRandomPoem.Image = global::MnemoTrainer.Properties.Resources.Poem;
            this.tSMIRandomPoem.Name = "tSMIRandomPoem";
            this.tSMIRandomPoem.Size = new System.Drawing.Size(194, 22);
            this.tSMIRandomPoem.Text = "Случайный стих";
            this.tSMIRandomPoem.Click += new System.EventHandler(this.tSMIRandomPoem_Click);
            // 
            // tSMIRandomPoemPart
            // 
            this.tSMIRandomPoemPart.Image = global::MnemoTrainer.Properties.Resources.PoemPart;
            this.tSMIRandomPoemPart.Name = "tSMIRandomPoemPart";
            this.tSMIRandomPoemPart.Size = new System.Drawing.Size(194, 22);
            this.tSMIRandomPoemPart.Text = "Случайная часть стиха";
            this.tSMIRandomPoemPart.Click += new System.EventHandler(this.tSMIRandomPoemPart_Click);
            // 
            // tSMIRandomLine
            // 
            this.tSMIRandomLine.Image = global::MnemoTrainer.Properties.Resources.PoemLine;
            this.tSMIRandomLine.Name = "tSMIRandomLine";
            this.tSMIRandomLine.Size = new System.Drawing.Size(194, 22);
            this.tSMIRandomLine.Text = "Случайная строка";
            this.tSMIRandomLine.Click += new System.EventHandler(this.tSMIRandomLine_Click);
            // 
            // FormSAConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 622);
            this.Controls.Add(this.tVSA);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSAConfig";
            this.ShowInTaskbar = false;
            this.Text = "Система накопления - Источник";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contMSTreeNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tVSA;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSMIFile;
        private System.Windows.Forms.ToolStripMenuItem tSMILoadFromXml;
        private System.Windows.Forms.ToolStripMenuItem tSMISaveIntoXml;
        private System.Windows.Forms.ToolStripMenuItem tSMIClose;
        private System.Windows.Forms.ContextMenuStrip contMSTreeNode;
        private System.Windows.Forms.ToolStripMenuItem tSMISABegin;
        private System.Windows.Forms.ToolStripMenuItem tSMIRandomBlock;
        private System.Windows.Forms.ToolStripMenuItem tSMIRandomBlockPart;
        private System.Windows.Forms.ToolStripMenuItem tSMIRandomPoem;
        private System.Windows.Forms.ToolStripMenuItem tSMIRandomPoemPart;
        private System.Windows.Forms.ToolStripMenuItem tSMIRandomLine;
        private System.Windows.Forms.ToolStripMenuItem tSMIRtfUtils;
        private System.Windows.Forms.ToolStripMenuItem tSMILoadFromFolder;
        private System.Windows.Forms.ToolStripMenuItem tSMILoadFromRtfFile;
    }
}

