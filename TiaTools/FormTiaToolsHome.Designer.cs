namespace TiaTools
{
    partial class FormToolsHome
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToolsHome));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonMsq = new System.Windows.Forms.Button();
            this.buttonIO = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSM = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.Silver;
            this.panelMenu.Controls.Add(this.buttonSM);
            this.panelMenu.Controls.Add(this.buttonMsq);
            this.panelMenu.Controls.Add(this.buttonIO);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(211, 556);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonMsq
            // 
            this.buttonMsq.Location = new System.Drawing.Point(13, 63);
            this.buttonMsq.Name = "buttonMsq";
            this.buttonMsq.Size = new System.Drawing.Size(181, 23);
            this.buttonMsq.TabIndex = 1;
            this.buttonMsq.Text = "Messages";
            this.buttonMsq.UseVisualStyleBackColor = true;
            this.buttonMsq.Click += new System.EventHandler(this.buttonMsq_Click);
            // 
            // buttonIO
            // 
            this.buttonIO.Location = new System.Drawing.Point(13, 34);
            this.buttonIO.Name = "buttonIO";
            this.buttonIO.Size = new System.Drawing.Size(181, 23);
            this.buttonIO.TabIndex = 0;
            this.buttonIO.Text = "I/O";
            this.buttonIO.UseVisualStyleBackColor = true;
            this.buttonIO.Click += new System.EventHandler(this.buttonIO_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoScroll = true;
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(211, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(627, 556);
            this.panelChildForm.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(282, 235);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSM
            // 
            this.buttonSM.Location = new System.Drawing.Point(13, 92);
            this.buttonSM.Name = "buttonSM";
            this.buttonSM.Size = new System.Drawing.Size(181, 23);
            this.buttonSM.TabIndex = 2;
            this.buttonSM.Text = "State Machines";
            this.buttonSM.UseVisualStyleBackColor = true;
            this.buttonSM.Click += new System.EventHandler(this.buttonSM_Click);
            // 
            // FormToolsHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 556);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToolsHome";
            this.Text = "TiaTools";
            this.panelMenu.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonIO;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMsq;
        private System.Windows.Forms.Button buttonSM;
    }
}

