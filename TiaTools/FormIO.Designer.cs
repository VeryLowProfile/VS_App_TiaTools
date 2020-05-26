namespace TiaTools
{
    partial class FormIO
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
            this.checkBoxFB = new System.Windows.Forms.CheckBox();
            this.checkBoxTypes = new System.Windows.Forms.CheckBox();
            this.checkBoxA_OUT = new System.Windows.Forms.CheckBox();
            this.checkBoxA_IN = new System.Windows.Forms.CheckBox();
            this.buttonCreateTIAFiles = new System.Windows.Forms.Button();
            this.checkBoxD_OUT = new System.Windows.Forms.CheckBox();
            this.checkBoxD_IN = new System.Windows.Forms.CheckBox();
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
            this.panel1.Controls.Add(this.checkBoxFB);
            this.panel1.Controls.Add(this.checkBoxTypes);
            this.panel1.Controls.Add(this.checkBoxA_OUT);
            this.panel1.Controls.Add(this.checkBoxA_IN);
            this.panel1.Controls.Add(this.buttonCreateTIAFiles);
            this.panel1.Controls.Add(this.checkBoxD_OUT);
            this.panel1.Controls.Add(this.checkBoxD_IN);
            this.panel1.Controls.Add(this.buttonImport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxFilePath);
            this.panel1.Controls.Add(this.comboBoxSheetList);
            this.panel1.Controls.Add(this.buttonSelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 74);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxFB
            // 
            this.checkBoxFB.AutoSize = true;
            this.checkBoxFB.Location = new System.Drawing.Point(496, 28);
            this.checkBoxFB.Name = "checkBoxFB";
            this.checkBoxFB.Size = new System.Drawing.Size(39, 17);
            this.checkBoxFB.TabIndex = 12;
            this.checkBoxFB.Text = "FB";
            this.checkBoxFB.UseMnemonic = false;
            this.checkBoxFB.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypes
            // 
            this.checkBoxTypes.AutoSize = true;
            this.checkBoxTypes.Location = new System.Drawing.Point(496, 10);
            this.checkBoxTypes.Name = "checkBoxTypes";
            this.checkBoxTypes.Size = new System.Drawing.Size(55, 17);
            this.checkBoxTypes.TabIndex = 11;
            this.checkBoxTypes.Text = "Types";
            this.checkBoxTypes.UseVisualStyleBackColor = true;
            // 
            // checkBoxA_OUT
            // 
            this.checkBoxA_OUT.AutoSize = true;
            this.checkBoxA_OUT.Location = new System.Drawing.Point(405, 28);
            this.checkBoxA_OUT.Name = "checkBoxA_OUT";
            this.checkBoxA_OUT.Size = new System.Drawing.Size(62, 17);
            this.checkBoxA_OUT.TabIndex = 9;
            this.checkBoxA_OUT.Text = "A_OUT";
            this.checkBoxA_OUT.UseVisualStyleBackColor = true;
            // 
            // checkBoxA_IN
            // 
            this.checkBoxA_IN.AutoSize = true;
            this.checkBoxA_IN.Location = new System.Drawing.Point(319, 28);
            this.checkBoxA_IN.Name = "checkBoxA_IN";
            this.checkBoxA_IN.Size = new System.Drawing.Size(50, 17);
            this.checkBoxA_IN.TabIndex = 8;
            this.checkBoxA_IN.Text = "A_IN";
            this.checkBoxA_IN.UseVisualStyleBackColor = true;
            // 
            // buttonCreateTIAFiles
            // 
            this.buttonCreateTIAFiles.Location = new System.Drawing.Point(317, 47);
            this.buttonCreateTIAFiles.Name = "buttonCreateTIAFiles";
            this.buttonCreateTIAFiles.Size = new System.Drawing.Size(150, 25);
            this.buttonCreateTIAFiles.TabIndex = 7;
            this.buttonCreateTIAFiles.Text = "Create TIA Files";
            this.buttonCreateTIAFiles.UseVisualStyleBackColor = true;
            this.buttonCreateTIAFiles.Click += new System.EventHandler(this.buttonCreateFiles_Click);
            // 
            // checkBoxD_OUT
            // 
            this.checkBoxD_OUT.AutoSize = true;
            this.checkBoxD_OUT.Location = new System.Drawing.Point(405, 10);
            this.checkBoxD_OUT.Name = "checkBoxD_OUT";
            this.checkBoxD_OUT.Size = new System.Drawing.Size(63, 17);
            this.checkBoxD_OUT.TabIndex = 6;
            this.checkBoxD_OUT.Text = "D_OUT";
            this.checkBoxD_OUT.UseVisualStyleBackColor = true;
            // 
            // checkBoxD_IN
            // 
            this.checkBoxD_IN.AutoSize = true;
            this.checkBoxD_IN.Location = new System.Drawing.Point(319, 10);
            this.checkBoxD_IN.Name = "checkBoxD_IN";
            this.checkBoxD_IN.Size = new System.Drawing.Size(51, 17);
            this.checkBoxD_IN.TabIndex = 5;
            this.checkBoxD_IN.Text = "D_IN";
            this.checkBoxD_IN.UseVisualStyleBackColor = true;
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
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(161, 9);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(150, 20);
            this.textBoxFilePath.TabIndex = 2;
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
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Output";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewInput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 462);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInput.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.Size = new System.Drawing.Size(627, 462);
            this.dataGridViewInput.TabIndex = 0;
            // 
            // FormIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormIO";
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
        private System.Windows.Forms.Button buttonCreateTIAFiles;
        private System.Windows.Forms.CheckBox checkBoxD_OUT;
        private System.Windows.Forms.CheckBox checkBoxD_IN;
        private System.Windows.Forms.CheckBox checkBoxA_OUT;
        private System.Windows.Forms.CheckBox checkBoxA_IN;
        private System.Windows.Forms.CheckBox checkBoxTypes;
        private System.Windows.Forms.CheckBox checkBoxFB;
    }
}