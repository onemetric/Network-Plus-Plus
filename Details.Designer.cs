namespace NetworkPlusPlus
{
    partial class Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details));
            this.lblInterfaceName = new System.Windows.Forms.Label();
            this.lblInterfaceDescription = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeProfiles = new System.Windows.Forms.Button();
            this.ptbLoading = new System.Windows.Forms.PictureBox();
            this.lblCurrentAction = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.imgDisable = new System.Windows.Forms.PictureBox();
            this.imgRenew = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDisable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRenew)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInterfaceName
            // 
            this.lblInterfaceName.AutoSize = true;
            this.lblInterfaceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterfaceName.Location = new System.Drawing.Point(3, 11);
            this.lblInterfaceName.Name = "lblInterfaceName";
            this.lblInterfaceName.Size = new System.Drawing.Size(119, 20);
            this.lblInterfaceName.TabIndex = 0;
            this.lblInterfaceName.Text = "Interface Name";
            // 
            // lblInterfaceDescription
            // 
            this.lblInterfaceDescription.AutoSize = true;
            this.lblInterfaceDescription.ForeColor = System.Drawing.Color.Black;
            this.lblInterfaceDescription.Location = new System.Drawing.Point(8, 42);
            this.lblInterfaceDescription.Name = "lblInterfaceDescription";
            this.lblInterfaceDescription.Size = new System.Drawing.Size(105, 13);
            this.lblInterfaceDescription.TabIndex = 1;
            this.lblInterfaceDescription.Text = "Interface Description";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDetails.Location = new System.Drawing.Point(8, 64);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(104, 16);
            this.lblDetails.TabIndex = 2;
            this.lblDetails.Text = "Interface Details";
            // 
            // cbProfiles
            // 
            this.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(4, 414);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(226, 28);
            this.cbProfiles.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Profile:";
            // 
            // btnChangeProfiles
            // 
            this.btnChangeProfiles.Location = new System.Drawing.Point(236, 413);
            this.btnChangeProfiles.Name = "btnChangeProfiles";
            this.btnChangeProfiles.Size = new System.Drawing.Size(32, 29);
            this.btnChangeProfiles.TabIndex = 7;
            this.btnChangeProfiles.Text = ">";
            this.btnChangeProfiles.UseVisualStyleBackColor = true;
            this.btnChangeProfiles.Click += new System.EventHandler(this.btnChangeProfiles_Click);
            // 
            // ptbLoading
            // 
            this.ptbLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ptbLoading.Image = ((System.Drawing.Image)(resources.GetObject("ptbLoading.Image")));
            this.ptbLoading.Location = new System.Drawing.Point(14, 360);
            this.ptbLoading.Name = "ptbLoading";
            this.ptbLoading.Size = new System.Drawing.Size(26, 23);
            this.ptbLoading.TabIndex = 9;
            this.ptbLoading.TabStop = false;
            this.ptbLoading.Visible = false;
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAction.Location = new System.Drawing.Point(40, 359);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(82, 24);
            this.lblCurrentAction.TabIndex = 10;
            this.lblCurrentAction.Text = "Saving...";
            this.lblCurrentAction.Visible = false;
            // 
            // btnReload
            // 
            this.btnReload.Image = global::NetworkPlusPlus.Properties.Resources.stock_repeat;
            this.btnReload.Location = new System.Drawing.Point(238, 5);
            this.btnReload.Margin = new System.Windows.Forms.Padding(0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(35, 35);
            this.btnReload.TabIndex = 11;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // imgDisable
            // 
            this.imgDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgDisable.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgDisable.Image = global::NetworkPlusPlus.Properties.Resources.notification_network_ethernet_disconnected;
            this.imgDisable.Location = new System.Drawing.Point(0, 448);
            this.imgDisable.Name = "imgDisable";
            this.imgDisable.Size = new System.Drawing.Size(139, 60);
            this.imgDisable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgDisable.TabIndex = 13;
            this.imgDisable.TabStop = false;
            this.imgDisable.Click += new System.EventHandler(this.imgDisable_Click);
            this.imgDisable.MouseEnter += new System.EventHandler(this.imgDisable_MouseEnter);
            this.imgDisable.MouseLeave += new System.EventHandler(this.imgDisable_MouseLeave);
            // 
            // imgRenew
            // 
            this.imgRenew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgRenew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.imgRenew.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgRenew.Image = global::NetworkPlusPlus.Properties.Resources.object_rotate_right;
            this.imgRenew.Location = new System.Drawing.Point(137, 448);
            this.imgRenew.Name = "imgRenew";
            this.imgRenew.Size = new System.Drawing.Size(139, 60);
            this.imgRenew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgRenew.TabIndex = 14;
            this.imgRenew.TabStop = false;
            this.imgRenew.Click += new System.EventHandler(this.imgRenew_Click);
            this.imgRenew.MouseEnter += new System.EventHandler(this.imgRenew_MouseEnter);
            this.imgRenew.MouseLeave += new System.EventHandler(this.imgRenew_MouseLeave);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(276, 506);
            this.ControlBox = false;
            this.Controls.Add(this.imgRenew);
            this.Controls.Add(this.imgDisable);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblCurrentAction);
            this.Controls.Add(this.ptbLoading);
            this.Controls.Add(this.btnChangeProfiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProfiles);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblInterfaceDescription);
            this.Controls.Add(this.lblInterfaceName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Details";
            this.ShowInTaskbar = false;
            this.Text = "Details";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.changeFocus);
            this.VisibleChanged += new System.EventHandler(this.Details_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDisable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRenew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInterfaceName;
        private System.Windows.Forms.Label lblInterfaceDescription;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeProfiles;
        private System.Windows.Forms.PictureBox ptbLoading;
        private System.Windows.Forms.Label lblCurrentAction;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.PictureBox imgDisable;
        private System.Windows.Forms.PictureBox imgRenew;
    }
}