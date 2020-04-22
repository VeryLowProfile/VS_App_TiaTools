﻿namespace TiaTools
{
    partial class FormMessages
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxExportFilePath = new System.Windows.Forms.TextBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxImportFilePath = new System.Windows.Forms.TextBox();
            this.comboBoxSheetList = new System.Windows.Forms.ComboBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewMsg = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 20);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Messages";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxExportFilePath);
            this.panel2.Controls.Add(this.buttonImport);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxImportFilePath);
            this.panel2.Controls.Add(this.comboBoxSheetList);
            this.panel2.Controls.Add(this.buttonSelectFile);
            this.panel2.Controls.Add(this.buttonExportExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 120);
            this.panel2.TabIndex = 1;
            // 
            // textBoxExportFilePath
            // 
            this.textBoxExportFilePath.Location = new System.Drawing.Point(159, 88);
            this.textBoxExportFilePath.Name = "textBoxExportFilePath";
            this.textBoxExportFilePath.Size = new System.Drawing.Size(150, 20);
            this.textBoxExportFilePath.TabIndex = 10;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(159, 47);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(150, 25);
            this.buttonImport.TabIndex = 9;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Sheet";
            // 
            // textBoxImportFilePath
            // 
            this.textBoxImportFilePath.Location = new System.Drawing.Point(159, 9);
            this.textBoxImportFilePath.Name = "textBoxImportFilePath";
            this.textBoxImportFilePath.Size = new System.Drawing.Size(150, 20);
            this.textBoxImportFilePath.TabIndex = 7;
            // 
            // comboBoxSheetList
            // 
            this.comboBoxSheetList.FormattingEnabled = true;
            this.comboBoxSheetList.Location = new System.Drawing.Point(3, 50);
            this.comboBoxSheetList.Name = "comboBoxSheetList";
            this.comboBoxSheetList.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSheetList.TabIndex = 6;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(3, 6);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(150, 25);
            this.buttonSelectFile.TabIndex = 5;
            this.buttonSelectFile.Text = "Select Excel file To Import";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.Location = new System.Drawing.Point(3, 86);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(150, 25);
            this.buttonExportExcel.TabIndex = 1;
            this.buttonExportExcel.Text = "Export To Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = true;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewMsg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 416);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewMsg
            // 
            this.dataGridViewMsg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMsg.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMsg.Name = "dataGridViewMsg";
            this.dataGridViewMsg.Size = new System.Drawing.Size(627, 416);
            this.dataGridViewMsg.TabIndex = 0;
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMessages";
            this.Text = "FormMessages";
            this.Load += new System.EventHandler(this.FormMessages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMsg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewMsg;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.TextBox textBoxExportFilePath;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxImportFilePath;
        private System.Windows.Forms.ComboBox comboBoxSheetList;
        private System.Windows.Forms.Button buttonSelectFile;
    }
}