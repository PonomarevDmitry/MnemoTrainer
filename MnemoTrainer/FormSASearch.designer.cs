namespace MnemoTrainer
{
    partial class FormSASearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSASearch));
            this.tSActions = new System.Windows.Forms.ToolStrip();
            this.tSBBeginLine = new System.Windows.Forms.ToolStripButton();
            this.tSBOpenInTree = new System.Windows.Forms.ToolStripButton();
            this.gBBookSearch = new System.Windows.Forms.GroupBox();
            this.tBSearch = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.btnPerformSearch = new System.Windows.Forms.Button();
            this.lVSearchResult = new System.Windows.Forms.ListView();
            this.colHeadPoemLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadPoem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadBlock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contMSListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMIBeginLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIOpenInTree = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSLSearchResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.tSActions.SuspendLayout();
            this.gBBookSearch.SuspendLayout();
            this.contMSListView.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tSActions
            // 
            this.tSActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tSActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBBeginLine,
            this.tSBOpenInTree});
            this.tSActions.Location = new System.Drawing.Point(0, 0);
            this.tSActions.Name = "tSActions";
            this.tSActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tSActions.Size = new System.Drawing.Size(608, 25);
            this.tSActions.TabIndex = 1;
            this.tSActions.Text = "toolStrip1";
            // 
            // tSBBeginLine
            // 
            this.tSBBeginLine.Image = global::MnemoTrainer.Properties.Resources.MoveNextHS;
            this.tSBBeginLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBBeginLine.Name = "tSBBeginLine";
            this.tSBBeginLine.Size = new System.Drawing.Size(64, 22);
            this.tSBBeginLine.Text = "Начать";
            this.tSBBeginLine.Click += new System.EventHandler(this.tSMIBeginLine_Click);
            // 
            // tSBOpenInTree
            // 
            this.tSBOpenInTree.Image = global::MnemoTrainer.Properties.Resources.ZoomHS;
            this.tSBOpenInTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBOpenInTree.Name = "tSBOpenInTree";
            this.tSBOpenInTree.Size = new System.Drawing.Size(137, 22);
            this.tSBOpenInTree.Text = "Отобразить в дереве";
            this.tSBOpenInTree.Click += new System.EventHandler(this.tSMIOpenInTree_Click);
            // 
            // gBBookSearch
            // 
            this.gBBookSearch.Controls.Add(this.tBSearch);
            this.gBBookSearch.Controls.Add(this.label);
            this.gBBookSearch.Controls.Add(this.btnPerformSearch);
            this.gBBookSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBBookSearch.Location = new System.Drawing.Point(0, 0);
            this.gBBookSearch.Name = "gBBookSearch";
            this.gBBookSearch.Size = new System.Drawing.Size(608, 40);
            this.gBBookSearch.TabIndex = 0;
            this.gBBookSearch.TabStop = false;
            this.gBBookSearch.Text = "Поиск";
            // 
            // tBSearch
            // 
            this.tBSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBSearch.Location = new System.Drawing.Point(3, 16);
            this.tBSearch.Name = "tBSearch";
            this.tBSearch.Size = new System.Drawing.Size(528, 20);
            this.tBSearch.TabIndex = 0;
            this.tBSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBBookSearch_KeyDown);
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Right;
            this.label.Location = new System.Drawing.Point(531, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(3, 21);
            this.label.TabIndex = 2;
            // 
            // btnPerformSearch
            // 
            this.btnPerformSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPerformSearch.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPerformSearch.Location = new System.Drawing.Point(534, 16);
            this.btnPerformSearch.Name = "btnPerformSearch";
            this.btnPerformSearch.Size = new System.Drawing.Size(71, 21);
            this.btnPerformSearch.TabIndex = 1;
            this.btnPerformSearch.Text = "Найти";
            this.btnPerformSearch.UseVisualStyleBackColor = true;
            this.btnPerformSearch.Click += new System.EventHandler(this.btnPerformSearch_Click);
            // 
            // lVSearchResult
            // 
            this.lVSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadPoemLine,
            this.colHeadPoem,
            this.colHeadBlock});
            this.lVSearchResult.ContextMenuStrip = this.contMSListView;
            this.lVSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVSearchResult.LargeImageList = this.imageList;
            this.lVSearchResult.Location = new System.Drawing.Point(0, 25);
            this.lVSearchResult.MultiSelect = false;
            this.lVSearchResult.Name = "lVSearchResult";
            this.lVSearchResult.Size = new System.Drawing.Size(608, 381);
            this.lVSearchResult.SmallImageList = this.imageList;
            this.lVSearchResult.TabIndex = 2;
            this.lVSearchResult.UseCompatibleStateImageBehavior = false;
            this.lVSearchResult.View = System.Windows.Forms.View.Details;
            this.lVSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lVBookSearch_KeyDown);
            this.lVSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lVBookSearch_MouseDoubleClick);
            // 
            // colHeadPoemLine
            // 
            this.colHeadPoemLine.Text = "Строка";
            this.colHeadPoemLine.Width = 200;
            // 
            // colHeadPoem
            // 
            this.colHeadPoem.Text = "Стих";
            // 
            // colHeadBlock
            // 
            this.colHeadBlock.Text = "Блок";
            // 
            // contMSListView
            // 
            this.contMSListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIBeginLine,
            this.tSMIOpenInTree});
            this.contMSListView.Name = "contMSListView";
            this.contMSListView.Size = new System.Drawing.Size(196, 48);
            // 
            // tSMIBeginLine
            // 
            this.tSMIBeginLine.Image = global::MnemoTrainer.Properties.Resources.MoveNextHS;
            this.tSMIBeginLine.Name = "tSMIBeginLine";
            this.tSMIBeginLine.Size = new System.Drawing.Size(195, 22);
            this.tSMIBeginLine.Text = "Начать";
            this.tSMIBeginLine.Click += new System.EventHandler(this.tSMIBeginLine_Click);
            // 
            // tSMIOpenInTree
            // 
            this.tSMIOpenInTree.Image = global::MnemoTrainer.Properties.Resources.ZoomHS;
            this.tSMIOpenInTree.Name = "tSMIOpenInTree";
            this.tSMIOpenInTree.Size = new System.Drawing.Size(195, 22);
            this.tSMIOpenInTree.Text = "Отобразить в дереве";
            this.tSMIOpenInTree.Click += new System.EventHandler(this.tSMIOpenInTree_Click);
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
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLSearchResultCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 446);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(608, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // tSSLSearchResultCount
            // 
            this.tSSLSearchResultCount.Name = "tSSLSearchResultCount";
            this.tSSLSearchResultCount.Size = new System.Drawing.Size(0, 17);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lVSearchResult);
            this.panel.Controls.Add(this.tSActions);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 40);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(608, 406);
            this.panel.TabIndex = 4;
            // 
            // FormSASearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 468);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.gBBookSearch);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSASearch";
            this.ShowInTaskbar = false;
            this.Text = "Поиск строк";
            this.tSActions.ResumeLayout(false);
            this.tSActions.PerformLayout();
            this.gBBookSearch.ResumeLayout(false);
            this.gBBookSearch.PerformLayout();
            this.contMSListView.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tSActions;
        private System.Windows.Forms.ToolStripButton tSBBeginLine;
        private System.Windows.Forms.ToolStripButton tSBOpenInTree;
        private System.Windows.Forms.GroupBox gBBookSearch;
        private System.Windows.Forms.TextBox tBSearch;
        private System.Windows.Forms.Button btnPerformSearch;
        private System.Windows.Forms.ListView lVSearchResult;
        private System.Windows.Forms.ColumnHeader colHeadPoemLine;
        private System.Windows.Forms.ColumnHeader colHeadPoem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tSSLSearchResultCount;
        private System.Windows.Forms.ContextMenuStrip contMSListView;
        private System.Windows.Forms.ToolStripMenuItem tSMIBeginLine;
        private System.Windows.Forms.ToolStripMenuItem tSMIOpenInTree;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ColumnHeader colHeadBlock;
        private System.Windows.Forms.Panel panel;
    }
}