using System.Drawing;

namespace NetworkPlusPlus
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.ntyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.imgClose = new System.Windows.Forms.PictureBox();
            this.imgAdd = new System.Windows.Forms.PictureBox();
            this.imgDelete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProfiles
            // 
            this.lstProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProfiles.FormattingEnabled = true;
            this.lstProfiles.ItemHeight = 20;
            this.lstProfiles.Location = new System.Drawing.Point(9, 7);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(255, 424);
            this.lstProfiles.TabIndex = 1;
            this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.lstProfiles_SelectedIndexChanged);
            // 
            // ntyIcon
            // 
            this.ntyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntyIcon.Icon")));
            this.ntyIcon.Text = "Network Plus Plus";
            this.ntyIcon.Visible = true;
            this.ntyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ntyIcon_MouseClick);
            // 
            // imgClose
            // 
            this.imgClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgClose.Image = global::NetworkPlusPlus.Properties.Resources.application_exit;
            this.imgClose.Location = new System.Drawing.Point(180, 450);
            this.imgClose.Name = "imgClose";
            this.imgClose.Size = new System.Drawing.Size(92, 50);
            this.imgClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgClose.TabIndex = 5;
            this.imgClose.TabStop = false;
            this.imgClose.Click += new System.EventHandler(this.imgClose_Click);
            this.imgClose.MouseEnter += new System.EventHandler(this.imgClose_MouseEnter);
            this.imgClose.MouseLeave += new System.EventHandler(this.imgClose_MouseLeave);
            // 
            // imgAdd
            // 
            this.imgAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgAdd.Image = global::NetworkPlusPlus.Properties.Resources.add;
            this.imgAdd.Location = new System.Drawing.Point(0, 450);
            this.imgAdd.Name = "imgAdd";
            this.imgAdd.Size = new System.Drawing.Size(90, 50);
            this.imgAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgAdd.TabIndex = 4;
            this.imgAdd.TabStop = false;
            this.imgAdd.Click += new System.EventHandler(this.imgAdd_Click);
            this.imgAdd.MouseEnter += new System.EventHandler(this.imgAdd_MouseEnter);
            this.imgAdd.MouseLeave += new System.EventHandler(this.imgAdd_MouseLeave);
            // 
            // imgDelete
            // 
            this.imgDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgDelete.Image = global::NetworkPlusPlus.Properties.Resources.insert_horizontal_rule;
            this.imgDelete.Location = new System.Drawing.Point(90, 450);
            this.imgDelete.Name = "imgDelete";
            this.imgDelete.Size = new System.Drawing.Size(90, 50);
            this.imgDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgDelete.TabIndex = 6;
            this.imgDelete.TabStop = false;
            this.imgDelete.Click += new System.EventHandler(this.imgDelete_Click);
            this.imgDelete.MouseEnter += new System.EventHandler(this.imgDelete_MouseEnter);
            this.imgDelete.MouseLeave += new System.EventHandler(this.imgDelete_MouseLeave);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(272, 500);
            this.ControlBox = false;
            this.Controls.Add(this.imgDelete);
            this.Controls.Add(this.imgClose);
            this.Controls.Add(this.imgAdd);
            this.Controls.Add(this.lstProfiles);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Network++";
            this.Deactivate += new System.EventHandler(this.Main_Deactivate);
            this.Load += new System.EventHandler(this.Main_Load);
            this.VisibleChanged += new System.EventHandler(this.Main_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstProfiles;
        public System.Windows.Forms.NotifyIcon ntyIcon;
        private System.Windows.Forms.PictureBox imgAdd;
        private System.Windows.Forms.PictureBox imgClose;
        private System.Windows.Forms.PictureBox imgDelete;
    }
}

