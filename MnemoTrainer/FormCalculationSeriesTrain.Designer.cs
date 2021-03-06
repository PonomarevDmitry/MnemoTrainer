﻿namespace MnemoTrainer
{
    partial class FormCalculationSeriesTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculationSeriesTrain));
            this.gBSeriesCount = new System.Windows.Forms.GroupBox();
            this.nUDSeriesCount = new System.Windows.Forms.NumericUpDown();
            this.tBTestWord = new System.Windows.Forms.TextBox();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.gbVisibleTime = new System.Windows.Forms.GroupBox();
            this.nUDVisibleTime = new System.Windows.Forms.NumericUpDown();
            this.cBVisionTime = new System.Windows.Forms.CheckBox();
            this.timerHide = new System.Windows.Forms.Timer(this.components);
            this.tempTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.gBMultiplicationOption = new System.Windows.Forms.GroupBox();
            this.nUDRight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDLeft = new System.Windows.Forms.NumericUpDown();
            this.gBAdditionOptions = new System.Windows.Forms.GroupBox();
            this.nUDAdditionOption = new System.Windows.Forms.NumericUpDown();
            this.gBTrainType = new System.Windows.Forms.GroupBox();
            this.rbMultiplication = new System.Windows.Forms.CheckBox();
            this.rbAddition = new System.Windows.Forms.CheckBox();
            this.panelCalculationSeries = new System.Windows.Forms.TableLayoutPanel();
            this.errorPictureBox = new MnemoTrainer.Controls.ErrorPictureBox(this.components);
            this.gBSeriesCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSeriesCount)).BeginInit();
            this.gbVisibleTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).BeginInit();
            this.gBMultiplicationOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).BeginInit();
            this.gBAdditionOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAdditionOption)).BeginInit();
            this.gBTrainType.SuspendLayout();
            this.panelCalculationSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBSeriesCount
            // 
            this.gBSeriesCount.Controls.Add(this.nUDSeriesCount);
            this.gBSeriesCount.Location = new System.Drawing.Point(212, 12);
            this.gBSeriesCount.Name = "gBSeriesCount";
            this.gBSeriesCount.Size = new System.Drawing.Size(59, 40);
            this.gBSeriesCount.TabIndex = 2;
            this.gBSeriesCount.TabStop = false;
            this.gBSeriesCount.Text = "Ряды";
            // 
            // nUDSeriesCount
            // 
            this.nUDSeriesCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDSeriesCount.Location = new System.Drawing.Point(3, 16);
            this.nUDSeriesCount.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nUDSeriesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDSeriesCount.Name = "nUDSeriesCount";
            this.nUDSeriesCount.Size = new System.Drawing.Size(53, 20);
            this.nUDSeriesCount.TabIndex = 0;
            this.nUDSeriesCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tBTestWord
            // 
            this.tBTestWord.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tBTestWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBTestWord.Location = new System.Drawing.Point(168, 462);
            this.tBTestWord.Name = "tBTestWord";
            this.tBTestWord.Size = new System.Drawing.Size(450, 29);
            this.tBTestWord.TabIndex = 6;
            this.tBTestWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBTestWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBTestWord_KeyDown);
            this.tBTestWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheckResult.ForeColor = System.Drawing.Color.Green;
            this.lblCheckResult.Location = new System.Drawing.Point(70, 513);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(646, 66);
            this.lblCheckResult.TabIndex = 14;
            this.lblCheckResult.Text = "Ответ";
            this.lblCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckResult.Visible = false;
            // 
            // gbVisibleTime
            // 
            this.gbVisibleTime.Controls.Add(this.nUDVisibleTime);
            this.gbVisibleTime.Controls.Add(this.cBVisionTime);
            this.gbVisibleTime.Location = new System.Drawing.Point(105, 12);
            this.gbVisibleTime.Name = "gbVisibleTime";
            this.gbVisibleTime.Size = new System.Drawing.Size(101, 40);
            this.gbVisibleTime.TabIndex = 1;
            this.gbVisibleTime.TabStop = false;
            this.gbVisibleTime.Text = "Время показа";
            // 
            // nUDVisibleTime
            // 
            this.nUDVisibleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDVisibleTime.Location = new System.Drawing.Point(18, 16);
            this.nUDVisibleTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDVisibleTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDVisibleTime.Name = "nUDVisibleTime";
            this.nUDVisibleTime.Size = new System.Drawing.Size(80, 20);
            this.nUDVisibleTime.TabIndex = 1;
            this.nUDVisibleTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // cBVisionTime
            // 
            this.cBVisionTime.AutoSize = true;
            this.cBVisionTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.cBVisionTime.Location = new System.Drawing.Point(3, 16);
            this.cBVisionTime.Name = "cBVisionTime";
            this.cBVisionTime.Size = new System.Drawing.Size(15, 21);
            this.cBVisionTime.TabIndex = 0;
            this.cBVisionTime.UseVisualStyleBackColor = true;
            // 
            // timerHide
            // 
            this.timerHide.Interval = 1000;
            this.timerHide.Tick += new System.EventHandler(this.timerHide_Tick);
            // 
            // tempTextBox
            // 
            this.tempTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tempTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.tempTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tempTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempTextBox.ForeColor = System.Drawing.Color.Blue;
            this.tempTextBox.Location = new System.Drawing.Point(183, 3);
            this.tempTextBox.Name = "tempTextBox";
            this.tempTextBox.Size = new System.Drawing.Size(66, 30);
            this.tempTextBox.TabIndex = 0;
            this.tempTextBox.Text = "10";
            this.tempTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Green;
            this.textBox1.Location = new System.Drawing.Point(183, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "+5";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(183, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 30);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "-3";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 12);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(87, 40);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Начать";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // gBMultiplicationOption
            // 
            this.gBMultiplicationOption.Controls.Add(this.nUDRight);
            this.gBMultiplicationOption.Controls.Add(this.label3);
            this.gBMultiplicationOption.Controls.Add(this.nUDLeft);
            this.gBMultiplicationOption.Location = new System.Drawing.Point(535, 12);
            this.gBMultiplicationOption.Name = "gBMultiplicationOption";
            this.gBMultiplicationOption.Size = new System.Drawing.Size(111, 40);
            this.gBMultiplicationOption.TabIndex = 5;
            this.gBMultiplicationOption.TabStop = false;
            this.gBMultiplicationOption.Text = "Умножение";
            this.gBMultiplicationOption.Validating += new System.ComponentModel.CancelEventHandler(this.gBMultiplicationOption_Validating);
            // 
            // nUDRight
            // 
            this.nUDRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDRight.Location = new System.Drawing.Point(63, 16);
            this.nUDRight.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDRight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDRight.Name = "nUDRight";
            this.nUDRight.Size = new System.Drawing.Size(45, 20);
            this.nUDRight.TabIndex = 2;
            this.nUDRight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(48, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDLeft
            // 
            this.nUDLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.nUDLeft.Location = new System.Drawing.Point(3, 16);
            this.nUDLeft.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nUDLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDLeft.Name = "nUDLeft";
            this.nUDLeft.Size = new System.Drawing.Size(45, 20);
            this.nUDLeft.TabIndex = 0;
            this.nUDLeft.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gBAdditionOptions
            // 
            this.gBAdditionOptions.Controls.Add(this.nUDAdditionOption);
            this.gBAdditionOptions.Location = new System.Drawing.Point(455, 12);
            this.gBAdditionOptions.Name = "gBAdditionOptions";
            this.gBAdditionOptions.Size = new System.Drawing.Size(74, 40);
            this.gBAdditionOptions.TabIndex = 4;
            this.gBAdditionOptions.TabStop = false;
            this.gBAdditionOptions.Text = "Сложение";
            // 
            // nUDAdditionOption
            // 
            this.nUDAdditionOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDAdditionOption.Location = new System.Drawing.Point(3, 16);
            this.nUDAdditionOption.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDAdditionOption.Name = "nUDAdditionOption";
            this.nUDAdditionOption.Size = new System.Drawing.Size(68, 20);
            this.nUDAdditionOption.TabIndex = 0;
            this.nUDAdditionOption.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // gBTrainType
            // 
            this.gBTrainType.Controls.Add(this.rbMultiplication);
            this.gBTrainType.Controls.Add(this.rbAddition);
            this.gBTrainType.Location = new System.Drawing.Point(277, 12);
            this.gBTrainType.Name = "gBTrainType";
            this.gBTrainType.Size = new System.Drawing.Size(172, 40);
            this.gBTrainType.TabIndex = 3;
            this.gBTrainType.TabStop = false;
            this.gBTrainType.Text = "Тип тренировки";
            this.gBTrainType.Validating += new System.ComponentModel.CancelEventHandler(this.gBTrainType_Validating);
            // 
            // rbMultiplication
            // 
            this.rbMultiplication.AutoSize = true;
            this.rbMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbMultiplication.Location = new System.Drawing.Point(80, 16);
            this.rbMultiplication.Name = "rbMultiplication";
            this.rbMultiplication.Size = new System.Drawing.Size(89, 21);
            this.rbMultiplication.TabIndex = 1;
            this.rbMultiplication.Text = "Умножение";
            this.rbMultiplication.UseVisualStyleBackColor = true;
            // 
            // rbAddition
            // 
            this.rbAddition.AutoSize = true;
            this.rbAddition.Checked = true;
            this.rbAddition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbAddition.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbAddition.Location = new System.Drawing.Point(3, 16);
            this.rbAddition.Name = "rbAddition";
            this.rbAddition.Size = new System.Drawing.Size(77, 21);
            this.rbAddition.TabIndex = 0;
            this.rbAddition.Text = "Сложение";
            this.rbAddition.UseVisualStyleBackColor = true;
            // 
            // panelCalculationSeries
            // 
            this.panelCalculationSeries.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelCalculationSeries.AutoScroll = true;
            this.panelCalculationSeries.ColumnCount = 1;
            this.panelCalculationSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCalculationSeries.Controls.Add(this.textBox2, 0, 2);
            this.panelCalculationSeries.Controls.Add(this.textBox1, 0, 1);
            this.panelCalculationSeries.Controls.Add(this.tempTextBox, 0, 0);
            this.panelCalculationSeries.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.panelCalculationSeries.Location = new System.Drawing.Point(177, 62);
            this.panelCalculationSeries.Name = "panelCalculationSeries";
            this.panelCalculationSeries.RowCount = 10;
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelCalculationSeries.Size = new System.Drawing.Size(432, 394);
            this.panelCalculationSeries.TabIndex = 3;
            // 
            // errorPictureBox
            // 
            this.errorPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.errorPictureBox.Location = new System.Drawing.Point(130, 459);
            this.errorPictureBox.Name = "errorPictureBox";
            this.errorPictureBox.Size = new System.Drawing.Size(32, 32);
            this.errorPictureBox.TabIndex = 17;
            // 
            // FormCalculationSeriesTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 591);
            this.Controls.Add(this.errorPictureBox);
            this.Controls.Add(this.gBTrainType);
            this.Controls.Add(this.gBAdditionOptions);
            this.Controls.Add(this.panelCalculationSeries);
            this.Controls.Add(this.gBMultiplicationOption);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.gbVisibleTime);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.tBTestWord);
            this.Controls.Add(this.gBSeriesCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormCalculationSeriesTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Тренировка \"Вычислительные ряды\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCalculationSeriesTrain_KeyDown);
            this.gBSeriesCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDSeriesCount)).EndInit();
            this.gbVisibleTime.ResumeLayout(false);
            this.gbVisibleTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVisibleTime)).EndInit();
            this.gBMultiplicationOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).EndInit();
            this.gBAdditionOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDAdditionOption)).EndInit();
            this.gBTrainType.ResumeLayout(false);
            this.gBTrainType.PerformLayout();
            this.panelCalculationSeries.ResumeLayout(false);
            this.panelCalculationSeries.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBSeriesCount;
        private System.Windows.Forms.NumericUpDown nUDSeriesCount;
        private System.Windows.Forms.TextBox tBTestWord;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.GroupBox gbVisibleTime;
        private System.Windows.Forms.NumericUpDown nUDVisibleTime;
        private System.Windows.Forms.CheckBox cBVisionTime;
        private System.Windows.Forms.Timer timerHide;
        private System.Windows.Forms.TextBox tempTextBox;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox gBMultiplicationOption;
        private System.Windows.Forms.NumericUpDown nUDRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDLeft;
        private System.Windows.Forms.GroupBox gBAdditionOptions;
        private System.Windows.Forms.NumericUpDown nUDAdditionOption;
        private System.Windows.Forms.GroupBox gBTrainType;
        private System.Windows.Forms.CheckBox rbAddition;
        private System.Windows.Forms.CheckBox rbMultiplication;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Controls.ErrorPictureBox errorPictureBox;
        private System.Windows.Forms.TableLayoutPanel panelCalculationSeries;
    }
}