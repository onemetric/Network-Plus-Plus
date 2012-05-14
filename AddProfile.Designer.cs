namespace NetworkPlusPlus
{
    partial class frmAddProfile
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDefaultGateway = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubnetMask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdIPDHCP = new System.Windows.Forms.RadioButton();
            this.rdIPManual = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDNS2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDNS1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdDNSDHCP = new System.Windows.Forms.RadioButton();
            this.rdDNSManual = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDefaultGateway);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSubnetMask);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdIPDHCP);
            this.groupBox1.Controls.Add(this.rdIPManual);
            this.groupBox1.Location = new System.Drawing.Point(21, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDefaultGateway
            // 
            this.txtDefaultGateway.Location = new System.Drawing.Point(158, 122);
            this.txtDefaultGateway.Name = "txtDefaultGateway";
            this.txtDefaultGateway.Size = new System.Drawing.Size(149, 20);
            this.txtDefaultGateway.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Default Gateway:";
            // 
            // txtSubnetMask
            // 
            this.txtSubnetMask.Location = new System.Drawing.Point(158, 96);
            this.txtSubnetMask.Name = "txtSubnetMask";
            this.txtSubnetMask.Size = new System.Drawing.Size(149, 20);
            this.txtSubnetMask.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subnet Mask:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(158, 71);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(149, 20);
            this.txtIPAddress.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP Address:";
            // 
            // rdIPDHCP
            // 
            this.rdIPDHCP.AutoSize = true;
            this.rdIPDHCP.Location = new System.Drawing.Point(21, 14);
            this.rdIPDHCP.Name = "rdIPDHCP";
            this.rdIPDHCP.Size = new System.Drawing.Size(190, 17);
            this.rdIPDHCP.TabIndex = 3;
            this.rdIPDHCP.TabStop = true;
            this.rdIPDHCP.Text = "Obtain an IP Address Automatically";
            this.rdIPDHCP.UseVisualStyleBackColor = true;
            // 
            // rdIPManual
            // 
            this.rdIPManual.AutoSize = true;
            this.rdIPManual.Location = new System.Drawing.Point(21, 37);
            this.rdIPManual.Name = "rdIPManual";
            this.rdIPManual.Size = new System.Drawing.Size(163, 17);
            this.rdIPManual.TabIndex = 4;
            this.rdIPManual.TabStop = true;
            this.rdIPManual.Text = "Use the following IP Address:";
            this.rdIPManual.UseVisualStyleBackColor = true;
            this.rdIPManual.CheckedChanged += new System.EventHandler(this.rdIPManual_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(259, 20);
            this.txtName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDNS2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDNS1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.rdDNSDHCP);
            this.groupBox2.Controls.Add(this.rdDNSManual);
            this.groupBox2.Location = new System.Drawing.Point(23, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 127);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtDNS2
            // 
            this.txtDNS2.Location = new System.Drawing.Point(158, 96);
            this.txtDNS2.Name = "txtDNS2";
            this.txtDNS2.Size = new System.Drawing.Size(149, 20);
            this.txtDNS2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Secondary DNS Server:";
            // 
            // txtDNS1
            // 
            this.txtDNS1.Location = new System.Drawing.Point(158, 71);
            this.txtDNS1.Name = "txtDNS1";
            this.txtDNS1.Size = new System.Drawing.Size(149, 20);
            this.txtDNS1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Preferred DNS Server:";
            // 
            // rdDNSDHCP
            // 
            this.rdDNSDHCP.AutoSize = true;
            this.rdDNSDHCP.Location = new System.Drawing.Point(21, 14);
            this.rdDNSDHCP.Name = "rdDNSDHCP";
            this.rdDNSDHCP.Size = new System.Drawing.Size(240, 17);
            this.rdDNSDHCP.TabIndex = 3;
            this.rdDNSDHCP.TabStop = true;
            this.rdDNSDHCP.Text = "Obtain the DNS Server Address Automatically";
            this.rdDNSDHCP.UseVisualStyleBackColor = true;
            // 
            // rdDNSManual
            // 
            this.rdDNSManual.AutoSize = true;
            this.rdDNSManual.Location = new System.Drawing.Point(21, 37);
            this.rdDNSManual.Name = "rdDNSManual";
            this.rdDNSManual.Size = new System.Drawing.Size(210, 17);
            this.rdDNSManual.TabIndex = 4;
            this.rdDNSManual.TabStop = true;
            this.rdDNSManual.Text = "Use the following DNS Server Address:";
            this.rdDNSManual.UseVisualStyleBackColor = true;
            this.rdDNSManual.CheckedChanged += new System.EventHandler(this.rdDNSManual_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(197, 342);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(279, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 372);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddProfile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Profile";
            this.VisibleChanged += new System.EventHandler(this.frmAddProfile_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rdIPDHCP;
        private System.Windows.Forms.RadioButton rdIPManual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDefaultGateway;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubnetMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDNS2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDNS1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdDNSDHCP;
        private System.Windows.Forms.RadioButton rdDNSManual;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}