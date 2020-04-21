﻿namespace TiaTools
{
    partial class FormInput
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
            this.buttonImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.comboBoxSheetList = new System.Windows.Forms.ComboBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonImport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxFilePath);
            this.panel1.Controls.Add(this.comboBoxSheetList);
            this.panel1.Controls.Add(this.buttonSelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 80);
            this.panel1.TabIndex = 0;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(169, 46);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(150, 25);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Sheet";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(169, 8);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(150, 20);
            this.textBoxFilePath.TabIndex = 2;
            // 
            // comboBoxSheetList
            // 
            this.comboBoxSheetList.FormattingEnabled = true;
            this.comboBoxSheetList.Location = new System.Drawing.Point(13, 49);
            this.comboBoxSheetList.Name = "comboBoxSheetList";
            this.comboBoxSheetList.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSheetList.TabIndex = 1;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(13, 5);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(150, 25);
            this.buttonSelectFile.TabIndex = 0;
            this.buttonSelectFile.Text = "Select Excel file To Import";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 20);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewInput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 456);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInput.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.Size = new System.Drawing.Size(627, 456);
            this.dataGridViewInput.TabIndex = 0;
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInput";
            this.Text = "FormInput";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.ComboBox comboBoxSheetList;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewInput;
    }
}