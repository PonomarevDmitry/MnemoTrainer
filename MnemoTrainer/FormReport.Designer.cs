namespace MnemoTrainer
{
    partial class FormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            this.cLBReportDates = new System.Windows.Forms.CheckedListBox();
            this.btnCreateDayTextReport = new System.Windows.Forms.Button();
            this.btnCreateDayExcelReport = new System.Windows.Forms.Button();
            this.cBMonth = new System.Windows.Forms.ComboBox();
            this.gBReportDay = new System.Windows.Forms.GroupBox();
            this.panelDay = new System.Windows.Forms.Panel();
            this.gBReportPeriod = new System.Windows.Forms.GroupBox();
            this.gBCreateNets = new System.Windows.Forms.GroupBox();
            this.btnCreateNetsFile = new System.Windows.Forms.Button();
            this.gBReportDay.SuspendLayout();
            this.panelDay.SuspendLayout();
            this.gBReportPeriod.SuspendLayout();
            this.gBCreateNets.SuspendLayout();
            this.SuspendLayout();
            // 
            // cLBReportDates
            // 
            this.cLBReportDates.CheckOnClick = true;
            this.cLBReportDates.ColumnWidth = 80;
            this.cLBReportDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cLBReportDates.FormattingEnabled = true;
            this.cLBReportDates.Location = new System.Drawing.Point(3, 48);
            this.cLBReportDates.MultiColumn = true;
            this.cLBReportDates.Name = "cLBReportDates";
            this.cLBReportDates.Size = new System.Drawing.Size(432, 482);
            this.cLBReportDates.TabIndex = 2;
            // 
            // btnCreateDayTextReport
            // 
            this.btnCreateDayTextReport.Location = new System.Drawing.Point(3, 3);
            this.btnCreateDayTextReport.Name = "btnCreateDayTextReport";
            this.btnCreateDayTextReport.Size = new System.Drawing.Size(145, 25);
            this.btnCreateDayTextReport.TabIndex = 0;
            this.btnCreateDayTextReport.Text = "Создать текстовый отчет";
            this.btnCreateDayTextReport.UseVisualStyleBackColor = true;
            this.btnCreateDayTextReport.Click += new System.EventHandler(this.btnCreateDayTextReport_Click);
            // 
            // btnCreateDayExcelReport
            // 
            this.btnCreateDayExcelReport.Location = new System.Drawing.Point(160, 3);
            this.btnCreateDayExcelReport.Name = "btnCreateDayExcelReport";
            this.btnCreateDayExcelReport.Size = new System.Drawing.Size(135, 25);
            this.btnCreateDayExcelReport.TabIndex = 1;
            this.btnCreateDayExcelReport.Text = "Создать Excel-отчет";
            this.btnCreateDayExcelReport.UseVisualStyleBackColor = true;
            // 
            // cBMonth
            // 
            this.cBMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMonth.FormatString = "yyyy MMMM";
            this.cBMonth.FormattingEnabled = true;
            this.cBMonth.Location = new System.Drawing.Point(6, 19);
            this.cBMonth.Name = "cBMonth";
            this.cBMonth.Size = new System.Drawing.Size(121, 21);
            this.cBMonth.TabIndex = 3;
            // 
            // gBReportDay
            // 
            this.gBReportDay.Controls.Add(this.cLBReportDates);
            this.gBReportDay.Controls.Add(this.panelDay);
            this.gBReportDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBReportDay.Location = new System.Drawing.Point(0, 98);
            this.gBReportDay.Name = "gBReportDay";
            this.gBReportDay.Size = new System.Drawing.Size(438, 533);
            this.gBReportDay.TabIndex = 4;
            this.gBReportDay.TabStop = false;
            this.gBReportDay.Text = "Отчет за день";
            // 
            // panelDay
            // 
            this.panelDay.Controls.Add(this.btnCreateDayTextReport);
            this.panelDay.Controls.Add(this.btnCreateDayExcelReport);
            this.panelDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDay.Location = new System.Drawing.Point(3, 16);
            this.panelDay.Name = "panelDay";
            this.panelDay.Size = new System.Drawing.Size(432, 32);
            this.panelDay.TabIndex = 3;
            // 
            // gBReportPeriod
            // 
            this.gBReportPeriod.Controls.Add(this.cBMonth);
            this.gBReportPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBReportPeriod.Location = new System.Drawing.Point(0, 48);
            this.gBReportPeriod.Name = "gBReportPeriod";
            this.gBReportPeriod.Size = new System.Drawing.Size(438, 50);
            this.gBReportPeriod.TabIndex = 5;
            this.gBReportPeriod.TabStop = false;
            this.gBReportPeriod.Text = "Отчет за период";
            // 
            // gBCreateNets
            // 
            this.gBCreateNets.Controls.Add(this.btnCreateNetsFile);
            this.gBCreateNets.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBCreateNets.Location = new System.Drawing.Point(0, 0);
            this.gBCreateNets.Name = "gBCreateNets";
            this.gBCreateNets.Size = new System.Drawing.Size(438, 48);
            this.gBCreateNets.TabIndex = 4;
            this.gBCreateNets.TabStop = false;
            this.gBCreateNets.Text = "Сетки";
            // 
            // btnCreateNetsFile
            // 
            this.btnCreateNetsFile.Location = new System.Drawing.Point(7, 20);
            this.btnCreateNetsFile.Name = "btnCreateNetsFile";
            this.btnCreateNetsFile.Size = new System.Drawing.Size(144, 23);
            this.btnCreateNetsFile.TabIndex = 0;
            this.btnCreateNetsFile.Text = "Скопировать сетки";
            this.btnCreateNetsFile.UseVisualStyleBackColor = true;
            this.btnCreateNetsFile.Click += new System.EventHandler(this.btnCreateNetsFile_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 631);
            this.Controls.Add(this.gBReportDay);
            this.Controls.Add(this.gBReportPeriod);
            this.Controls.Add(this.gBCreateNets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Создание отчетов и статистики";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormReport_KeyDown);
            this.gBReportDay.ResumeLayout(false);
            this.panelDay.ResumeLayout(false);
            this.gBReportPeriod.ResumeLayout(false);
            this.gBCreateNets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cLBReportDates;
        private System.Windows.Forms.Button btnCreateDayTextReport;
        private System.Windows.Forms.Button btnCreateDayExcelReport;
        private System.Windows.Forms.ComboBox cBMonth;
        private System.Windows.Forms.GroupBox gBReportDay;
        private System.Windows.Forms.Panel panelDay;
        private System.Windows.Forms.GroupBox gBReportPeriod;
        private System.Windows.Forms.GroupBox gBCreateNets;
        private System.Windows.Forms.Button btnCreateNetsFile;
    }
}