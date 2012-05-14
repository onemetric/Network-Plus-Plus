using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace NetworkPlusPlus
{
    public partial class ChangeProfiles : Form
    {

        Main frmMain;
        public About frmAbout;
        public Details frmDetails;

        public ChangeProfiles(Main parent)
        {
            InitializeComponent();
            frmMain = parent;
            frmDetails = new Details();
            frmAbout = new About();

            ToolTip ttSettings = new ToolTip();
            ttSettings.SetToolTip(imgSettings, "Settings");

            ToolTip ttAbout = new ToolTip();
            ttAbout.SetToolTip(imgAbout, "About");

            ToolTip ttClose = new ToolTip();
            ttClose.SetToolTip(imgClose, "Close");
            
        }

        private void formActivate(object sender, EventArgs e)
        {

            for (int i = 0; i < Interfaces.getInterfaceCount(); i++)
            {

                Button tmpButton = new Button();
                tmpButton.Text = Interfaces.getInterface(i).Name;
                tmpButton.AutoEllipsis = true;
                tmpButton.FlatAppearance.BorderColor = Color.FromArgb(137, 137, 137);
                tmpButton.FlatAppearance.BorderSize = 0;
                tmpButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(178, 178, 178);// System.Drawing.Color.PowderBlue;
                tmpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                tmpButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tmpButton.ForeColor = Color.FromArgb(67, 67, 67);
                tmpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                tmpButton.Location = new System.Drawing.Point(0, i * 71);
                tmpButton.Size = new System.Drawing.Size(275, 71);
                tmpButton.TabIndex = 1;
                tmpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                tmpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
                tmpButton.UseVisualStyleBackColor = true;
                
                if (Interfaces.getInterface(i).Name.Contains("Wireless") || Interfaces.getInterface(i).Name.Contains("802.11") || Interfaces.getInterface(i).Name.Contains("WLAN"))
                {
                    tmpButton.Image = global::NetworkPlusPlus.Properties.Resources.network_wireless_connected;
                }
                else
                {
                    tmpButton.Image = global::NetworkPlusPlus.Properties.Resources.network_wired;
                }

                tmpButton.Click += new EventHandler(interfaceButtonClick);

                this.Controls.Add(tmpButton);

                //lstInterfaces.Items.Add(Interfaces.getInterface(i).Name);
            }
            
        }

        private void changeFocus(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void imgSettings_Click(object sender, EventArgs e)
        {
            frmMain.Show();
            this.Hide();
        }

        private void interfaceButtonClick(object sender, EventArgs e)
        {

            Button btnSender = (Button)sender;

            frmDetails.showInterface(btnSender.Text);

        }

        private void imgSettings_Hover(object sender, EventArgs e)
        {
            imgSettings.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void imgSettings_MouseOut(object sender, EventArgs e)
        {
            imgSettings.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void imgAbout_Hover(object sender, EventArgs e)
        {
            imgAbout.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void imgAbout_MouseOut(object sender, EventArgs e)
        {
            imgAbout.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void imgClose_Hover(object sender, EventArgs e)
        {
            imgClose.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void imgClose_MouseOut(object sender, EventArgs e)
        {
            imgClose.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void imgClose_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to close Network Plus Plus", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                    
                Application.Exit();
            
            }

        }
        
        private void imgAbout_Click(object sender, EventArgs e)
        {
            frmAbout.Show();
            this.Hide();
        }

        private void ChangeProfiles_VisibleChanged(object sender, EventArgs e)
        {
            this.BringToFront();
        }


    }
}
