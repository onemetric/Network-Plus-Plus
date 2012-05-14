namespace NetworkPlusPlus
{
    partial class ChangeProfiles
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
            this.imgClose = new System.Windows.Forms.PictureBox();
            this.imgAbout = new System.Windows.Forms.PictureBox();
            this.imgSettings = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgClose
            // 
            this.imgClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgClose.Image = global::NetworkPlusPlus.Properties.Resources.application_exit;
            this.imgClose.Location = new System.Drawing.Point(188, 447);
            this.imgClose.Name = "imgClose";
            this.imgClose.Size = new System.Drawing.Size(94, 60);
            this.imgClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgClose.TabIndex = 3;
            this.imgClose.TabStop = false;
            this.imgClose.Click += new System.EventHandler(this.imgClose_Click);
            this.imgClose.MouseEnter += new System.EventHandler(this.imgClose_Hover);
            this.imgClose.MouseLeave += new System.EventHandler(this.imgClose_MouseOut);
            // 
            // imgAbout
            // 
            this.imgAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgAbout.Image = global::NetworkPlusPlus.Properties.Resources.info;
            this.imgAbout.Location = new System.Drawing.Point(94, 447);
            this.imgAbout.Name = "imgAbout";
            this.imgAbout.Size = new System.Drawing.Size(94, 60);
            this.imgAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgAbout.TabIndex = 1;
            this.imgAbout.TabStop = false;
            this.imgAbout.Click += new System.EventHandler(this.imgAbout_Click);
            this.imgAbout.MouseEnter += new System.EventHandler(this.imgAbout_Hover);
            this.imgAbout.MouseLeave += new System.EventHandler(this.imgAbout_MouseOut);
            // 
            // imgSettings
            // 
            this.imgSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgSettings.Image = global::NetworkPlusPlus.Properties.Resources.applications_development;
            this.imgSettings.Location = new System.Drawing.Point(0, 447);
            this.imgSettings.Name = "imgSettings";
            this.imgSettings.Size = new System.Drawing.Size(94, 60);
            this.imgSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgSettings.TabIndex = 0;
            this.imgSettings.TabStop = false;
            this.imgSettings.Click += new System.EventHandler(this.imgSettings_Click);
            this.imgSettings.MouseEnter += new System.EventHandler(this.imgSettings_Hover);
            this.imgSettings.MouseLeave += new System.EventHandler(this.imgSettings_MouseOut);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 447);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 60);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ChangeProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(276, 506);
            this.ControlBox = false;
            this.Controls.Add(this.imgClose);
            this.Controls.Add(this.imgAbout);
            this.Controls.Add(this.imgSettings);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeProfiles";
            this.ShowInTaskbar = false;
            this.Text = "Select Interface";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.changeFocus);
            this.VisibleChanged += new System.EventHandler(this.ChangeProfiles_VisibleChanged);
            this.GotFocus += new System.EventHandler(this.formActivate);
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgSettings;
        private System.Windows.Forms.PictureBox imgAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox imgClose;

    }
}