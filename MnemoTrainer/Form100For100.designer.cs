namespace MnemoTrainer
{
    partial class Form100For100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form100For100));
            this.lblTestWord = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tSSLElementCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLCurrentIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.gBListOrder = new System.Windows.Forms.GroupBox();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.rbStraight = new System.Windows.Forms.RadioButton();
            this.gBLists = new System.Windows.Forms.GroupBox();
            this.cBList = new System.Windows.Forms.ComboBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tSBRefreshLists = new System.Windows.Forms.ToolStripButton();
            this.tSBOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.tSBOpenList = new System.Windows.Forms.ToolStripButton();
            this.tSBClearList = new System.Windows.Forms.ToolStripButton();
            this.tSSTotalTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.tSSOneTestTimer = new MnemoTrainer.Controls.ToolStripStatusTimer(this.components);
            this.statusStrip.SuspendLayout();
            this.gBListOrder.SuspendLayout();
            this.gBLists.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestWord
            // 
            this.lblTestWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestWord.ForeColor = System.Drawing.Color.Green;
            this.lblTestWord.Location = new System.Drawing.Point(0, 90);
            this.lblTestWord.Name = "lblTestWord";
            this.lblTestWord.Size = new System.Drawing.Size(786, 357);
            this.lblTestWord.TabIndex = 0;
            this.lblTestWord.Text = "1";
            this.lblTestWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestWord.Click += new System.EventHandler(this.lblTestWord_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSTotalTimer,
            this.tSSOneTestTimer,
            this.tSSLElementCount,
            this.tSSLCurrentIndex});
            this.statusStrip.Location = new System.Drawing.Point(0, 519);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(786, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tSSLElementCount
            // 
            this.tSSLElementCount.Name = "tSSLElementCount";
            this.tSSLElementCount.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSLCurrentIndex
            // 
            this.tSSLCurrentIndex.Name = "tSSLCurrentIndex";
            this.tSSLCurrentIndex.Size = new System.Drawing.Size(0, 17);
            // 
            // gBListOrder
            // 
            this.gBListOrder.Controls.Add(this.rbRandom);
            this.gBListOrder.Controls.Add(this.rbStraight);
            this.gBListOrder.Location = new System.Drawing.Point(351, 12);
            this.gBListOrder.Name = "gBListOrder";
            this.gBListOrder.Size = new System.Drawing.Size(151, 40);
            this.gBListOrder.TabIndex = 3;
            this.gBListOrder.TabStop = false;
            this.gBListOrder.Text = "Порядок";
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbRandom.Location = new System.Drawing.Point(68, 16);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(80, 21);
            this.rbRandom.TabIndex = 1;
            this.rbRandom.Text = "Случайный";
            this.rbRandom.UseVisualStyleBackColor = true;
            // 
            // rbStraight
            // 
            this.rbStraight.AutoSize = true;
            this.rbStraight.Checked = true;
            this.rbStraight.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbStraight.Location = new System.Drawing.Point(3, 16);
            this.rbStraight.Name = "rbStraight";
            this.rbStraight.Size = new System.Drawing.Size(65, 21);
            this.rbStraight.TabIndex = 0;
            this.rbStraight.TabStop = true;
            this.rbStraight.Text = "Прямой";
            this.rbStraight.UseVisualStyleBackColor = true;
            this.rbStraight.CheckedChanged += new System.EventHandler(this.rbStraight_CheckedChanged);
            // 
            // gBLists
            // 
            this.gBLists.Controls.Add(this.cBList);
            this.gBLists.Controls.Add(this.toolStrip);
            this.gBLists.Location = new System.Drawing.Point(12, 12);
            this.gBLists.Name = "gBLists";
            this.gBLists.Size = new System.Drawing.Size(333, 40);
            this.gBLists.TabIndex = 2;
            this.gBLists.TabStop = false;
            this.gBLists.Text = "Списки";
            // 
            // cBList
            // 
            this.cBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBList.FormattingEnabled = true;
            this.cBList.Location = new System.Drawing.Point(3, 16);
            this.cBList.Name = "cBList";
            this.cBList.Size = new System.Drawing.Size(201, 21);
            this.cBList.TabIndex = 0;
            this.cBList.SelectedIndexChanged += new System.EventHandler(this.cBList_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBRefreshLists,
            this.tSBOpenFolder,
            this.tSBOpenList,
            this.tSBClearList});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(204, 16);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(126, 21);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tSBRefreshLists
            // 
            this.tSBRefreshLists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBRefreshLists.Image = global::MnemoTrainer.Properties.Resources.RefreshArrow;
            this.tSBRefreshLists.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBRefreshLists.Name = "tSBRefreshLists";
            this.tSBRefreshLists.Size = new System.Drawing.Size(23, 18);
            this.tSBRefreshLists.Text = "Обновить списки";
            this.tSBRefreshLists.Click += new System.EventHandler(this.tSBRefreshLists_Click);
            // 
            // tSBOpenFolder
            // 
            this.tSBOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBOpenFolder.Image = global::MnemoTrainer.Properties.Resources.ZoomHS;
            this.tSBOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBOpenFolder.Name = "tSBOpenFolder";
            this.tSBOpenFolder.Size = new System.Drawing.Size(23, 18);
            this.tSBOpenFolder.Text = "Открыть папку списков";
            this.tSBOpenFolder.Click += new System.EventHandler(this.tSBOpenFolder_Click);
            // 
            // tSBOpenList
            // 
            this.tSBOpenList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBOpenList.Image = global::MnemoTrainer.Properties.Resources.ActualSizeHS;
            this.tSBOpenList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBOpenList.Name = "tSBOpenList";
            this.tSBOpenList.Size = new System.Drawing.Size(23, 18);
            this.tSBOpenList.Text = "Открыть список";
            this.tSBOpenList.Click += new System.EventHandler(this.tSBOpenList_Click);
            // 
            // tSBClearList
            // 
            this.tSBClearList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBClearList.Image = global::MnemoTrainer.Properties.Resources.Clear;
            this.tSBClearList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBClearList.Name = "tSBClearList";
            this.tSBClearList.Size = new System.Drawing.Size(23, 18);
            this.tSBClearList.Text = "Очистить от повторов";
            this.tSBClearList.Click += new System.EventHandler(this.tSBClearList_Click);
            // 
            // tSSTotalTimer
            // 
            this.tSSTotalTimer.Format = "Полное время теста: {0}.";
            this.tSSTotalTimer.Interval = 1000;
            this.tSSTotalTimer.Name = "tSSTotalTimer";
            this.tSSTotalTimer.Size = new System.Drawing.Size(0, 0);
            this.tSSTotalTimer.Type = MnemoTrainer.Controls.ToolStripStatusTimer.TimeStringType.Hours;
            // 
            // tSSOneTestTimer
            // 
            this.tSSOneTestTimer.Format = "Тест: {0} с.";
            this.tSSOneTestTimer.Name = "tSSOneTestTimer";
            this.tSSOneTestTimer.Size = new System.Drawing.Size(0, 0);
            // 
            // Form100For100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 541);
            this.Controls.Add(this.gBLists);
            this.Controls.Add(this.gBListOrder);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lblTestWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form100For100";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Упраженение \"100 за 100\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form100For100_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form100For100_MouseClick);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gBListOrder.ResumeLayout(false);
            this.gBListOrder.PerformLayout();
            this.gBLists.ResumeLayout(false);
            this.gBLists.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestWord;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox gBListOrder;
        private System.Windows.Forms.RadioButton rbRandom;
        private System.Windows.Forms.RadioButton rbStraight;
        private System.Windows.Forms.GroupBox gBLists;
        private System.Windows.Forms.ComboBox cBList;
        private Controls.ToolStripStatusTimer tSSOneTestTimer;
        private Controls.ToolStripStatusTimer tSSTotalTimer;
        private System.Windows.Forms.ToolStripStatusLabel tSSLElementCount;
        private System.Windows.Forms.ToolStripStatusLabel tSSLCurrentIndex;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tSBRefreshLists;
        private System.Windows.Forms.ToolStripButton tSBOpenFolder;
        private System.Windows.Forms.ToolStripButton tSBOpenList;
        private System.Windows.Forms.ToolStripButton tSBClearList;
    }
}