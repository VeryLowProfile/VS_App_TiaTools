namespace TiaTools
{
    partial class FormStateMachines
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
            this.checkBoxTypes = new System.Windows.Forms.CheckBox();
            this.checkBoxDB = new System.Windows.Forms.CheckBox();
            this.textBoxExportFilePath = new System.Windows.Forms.TextBox();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.buttonSelectALL = new System.Windows.Forms.Button();
            this.checkBoxPhaseFC = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSMName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSMTotNb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSMNb = new System.Windows.Forms.TextBox();
            this.checkBoxSMFiles = new System.Windows.Forms.CheckBox();
            this.buttonCreateTIAFiles = new System.Windows.Forms.Button();
            this.checkBoxConstants = new System.Windows.Forms.CheckBox();
            this.checkBoxCommon = new System.Windows.Forms.CheckBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxImportFilePath = new System.Windows.Forms.TextBox();
            this.comboBoxSheetList = new System.Windows.Forms.ComboBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSM = new System.Windows.Forms.DataGridView();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.checkBoxHmi = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxHmi);
            this.panel1.Controls.Add(this.checkBoxAutoStart);
            this.panel1.Controls.Add(this.checkBoxTypes);
            this.panel1.Controls.Add(this.checkBoxDB);
            this.panel1.Controls.Add(this.textBoxExportFilePath);
            this.panel1.Controls.Add(this.buttonExportExcel);
            this.panel1.Controls.Add(this.buttonDeselectAll);
            this.panel1.Controls.Add(this.buttonSelectALL);
            this.panel1.Controls.Add(this.checkBoxPhaseFC);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxSMName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxSMTotNb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxSMNb);
            this.panel1.Controls.Add(this.checkBoxSMFiles);
            this.panel1.Controls.Add(this.buttonCreateTIAFiles);
            this.panel1.Controls.Add(this.checkBoxConstants);
            this.panel1.Controls.Add(this.checkBoxCommon);
            this.panel1.Controls.Add(this.buttonImport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxImportFilePath);
            this.panel1.Controls.Add(this.comboBoxSheetList);
            this.panel1.Controls.Add(this.buttonSelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 148);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxTypes
            // 
            this.checkBoxTypes.AutoSize = true;
            this.checkBoxTypes.Location = new System.Drawing.Point(533, 21);
            this.checkBoxTypes.Name = "checkBoxTypes";
            this.checkBoxTypes.Size = new System.Drawing.Size(55, 17);
            this.checkBoxTypes.TabIndex = 23;
            this.checkBoxTypes.Text = "Types";
            this.checkBoxTypes.UseVisualStyleBackColor = true;
            // 
            // checkBoxDB
            // 
            this.checkBoxDB.AutoSize = true;
            this.checkBoxDB.Location = new System.Drawing.Point(533, 37);
            this.checkBoxDB.Name = "checkBoxDB";
            this.checkBoxDB.Size = new System.Drawing.Size(41, 17);
            this.checkBoxDB.TabIndex = 22;
            this.checkBoxDB.Text = "DB";
            this.checkBoxDB.UseVisualStyleBackColor = true;
            // 
            // textBoxExportFilePath
            // 
            this.textBoxExportFilePath.Location = new System.Drawing.Point(161, 87);
            this.textBoxExportFilePath.Name = "textBoxExportFilePath";
            this.textBoxExportFilePath.Size = new System.Drawing.Size(150, 20);
            this.textBoxExportFilePath.TabIndex = 21;
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.Location = new System.Drawing.Point(7, 84);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(150, 25);
            this.buttonExportExcel.TabIndex = 20;
            this.buttonExportExcel.Text = "Export To Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = true;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Location = new System.Drawing.Point(161, 118);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(150, 25);
            this.buttonDeselectAll.TabIndex = 18;
            this.buttonDeselectAll.Text = "Deselect All";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // buttonSelectALL
            // 
            this.buttonSelectALL.Location = new System.Drawing.Point(7, 118);
            this.buttonSelectALL.Name = "buttonSelectALL";
            this.buttonSelectALL.Size = new System.Drawing.Size(150, 25);
            this.buttonSelectALL.TabIndex = 17;
            this.buttonSelectALL.Text = "Select All";
            this.buttonSelectALL.UseVisualStyleBackColor = true;
            this.buttonSelectALL.Click += new System.EventHandler(this.buttonSelectALL_Click);
            // 
            // checkBoxPhaseFC
            // 
            this.checkBoxPhaseFC.AutoSize = true;
            this.checkBoxPhaseFC.Location = new System.Drawing.Point(533, 69);
            this.checkBoxPhaseFC.Name = "checkBoxPhaseFC";
            this.checkBoxPhaseFC.Size = new System.Drawing.Size(72, 17);
            this.checkBoxPhaseFC.TabIndex = 16;
            this.checkBoxPhaseFC.Text = "Phase FC";
            this.checkBoxPhaseFC.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "SM Name";
            // 
            // textBoxSMName
            // 
            this.textBoxSMName.Location = new System.Drawing.Point(390, 84);
            this.textBoxSMName.Name = "textBoxSMName";
            this.textBoxSMName.Size = new System.Drawing.Size(128, 20);
            this.textBoxSMName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "SM Tot Nb";
            // 
            // textBoxSMTotNb
            // 
            this.textBoxSMTotNb.Location = new System.Drawing.Point(390, 58);
            this.textBoxSMTotNb.Name = "textBoxSMTotNb";
            this.textBoxSMTotNb.Size = new System.Drawing.Size(128, 20);
            this.textBoxSMTotNb.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "SM Nb";
            // 
            // textBoxSMNb
            // 
            this.textBoxSMNb.Location = new System.Drawing.Point(390, 32);
            this.textBoxSMNb.Name = "textBoxSMNb";
            this.textBoxSMNb.Size = new System.Drawing.Size(128, 20);
            this.textBoxSMNb.TabIndex = 10;
            // 
            // checkBoxSMFiles
            // 
            this.checkBoxSMFiles.AutoSize = true;
            this.checkBoxSMFiles.Location = new System.Drawing.Point(533, 53);
            this.checkBoxSMFiles.Name = "checkBoxSMFiles";
            this.checkBoxSMFiles.Size = new System.Drawing.Size(66, 17);
            this.checkBoxSMFiles.TabIndex = 9;
            this.checkBoxSMFiles.Text = "SM Files";
            this.checkBoxSMFiles.UseVisualStyleBackColor = true;
            // 
            // buttonCreateTIAFiles
            // 
            this.buttonCreateTIAFiles.Location = new System.Drawing.Point(472, 118);
            this.buttonCreateTIAFiles.Name = "buttonCreateTIAFiles";
            this.buttonCreateTIAFiles.Size = new System.Drawing.Size(150, 25);
            this.buttonCreateTIAFiles.TabIndex = 7;
            this.buttonCreateTIAFiles.Text = "Create TIA Files";
            this.buttonCreateTIAFiles.UseVisualStyleBackColor = true;
            this.buttonCreateTIAFiles.Click += new System.EventHandler(this.buttonCreateTIAFiles_Click);
            // 
            // checkBoxConstants
            // 
            this.checkBoxConstants.AutoSize = true;
            this.checkBoxConstants.Location = new System.Drawing.Point(533, 100);
            this.checkBoxConstants.Name = "checkBoxConstants";
            this.checkBoxConstants.Size = new System.Drawing.Size(73, 17);
            this.checkBoxConstants.TabIndex = 6;
            this.checkBoxConstants.Text = "Constants";
            this.checkBoxConstants.UseVisualStyleBackColor = true;
            // 
            // checkBoxCommon
            // 
            this.checkBoxCommon.AutoSize = true;
            this.checkBoxCommon.Location = new System.Drawing.Point(533, 5);
            this.checkBoxCommon.Name = "checkBoxCommon";
            this.checkBoxCommon.Size = new System.Drawing.Size(91, 17);
            this.checkBoxCommon.TabIndex = 5;
            this.checkBoxCommon.Text = "Common Files";
            this.checkBoxCommon.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(161, 47);
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
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Sheet";
            // 
            // textBoxImportFilePath
            // 
            this.textBoxImportFilePath.Location = new System.Drawing.Point(161, 9);
            this.textBoxImportFilePath.Name = "textBoxImportFilePath";
            this.textBoxImportFilePath.Size = new System.Drawing.Size(150, 20);
            this.textBoxImportFilePath.TabIndex = 2;
            // 
            // comboBoxSheetList
            // 
            this.comboBoxSheetList.FormattingEnabled = true;
            this.comboBoxSheetList.Location = new System.Drawing.Point(7, 50);
            this.comboBoxSheetList.Name = "comboBoxSheetList";
            this.comboBoxSheetList.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSheetList.TabIndex = 1;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(7, 6);
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
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "State Machines";
            // 
            // dataGridViewSM
            // 
            this.dataGridViewSM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSM.Location = new System.Drawing.Point(0, 20);
            this.dataGridViewSM.Name = "dataGridViewSM";
            this.dataGridViewSM.Size = new System.Drawing.Size(627, 388);
            this.dataGridViewSM.TabIndex = 3;
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(390, 9);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(67, 17);
            this.checkBoxAutoStart.TabIndex = 24;
            this.checkBoxAutoStart.Text = "autostart";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxHmi
            // 
            this.checkBoxHmi.AutoSize = true;
            this.checkBoxHmi.Location = new System.Drawing.Point(533, 84);
            this.checkBoxHmi.Name = "checkBoxHmi";
            this.checkBoxHmi.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHmi.TabIndex = 25;
            this.checkBoxHmi.Text = "Hmi Logic";
            this.checkBoxHmi.UseVisualStyleBackColor = true;
            // 
            // FormStateMachines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 556);
            this.Controls.Add(this.dataGridViewSM);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStateMachines";
            this.Text = "lo";
            this.Load += new System.EventHandler(this.FormStateMachines_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxSMFiles;
        private System.Windows.Forms.Button buttonCreateTIAFiles;
        private System.Windows.Forms.CheckBox checkBoxConstants;
        private System.Windows.Forms.CheckBox checkBoxCommon;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxImportFilePath;
        private System.Windows.Forms.ComboBox comboBoxSheetList;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSM;
        private System.Windows.Forms.CheckBox checkBoxPhaseFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSMName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSMTotNb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSMNb;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Button buttonSelectALL;
        private System.Windows.Forms.TextBox textBoxExportFilePath;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.CheckBox checkBoxDB;
        private System.Windows.Forms.CheckBox checkBoxTypes;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.CheckBox checkBoxHmi;
    }
}