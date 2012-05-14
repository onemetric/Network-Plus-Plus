using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace NetworkPlusPlus
{
    public partial class Main : Form
    {

        private ChangeProfiles frmChange;
        private bool deleteDisabled = false;

        public Main()
        {
            InitializeComponent();
            Interfaces.findInterfaces();
            frmChange = new ChangeProfiles(this);
            loadProfiles();

            //setup the context menu for the taskbar notification
            ContextMenu mnuNotify = new ContextMenu();
            mnuNotify.MenuItems.Add(new MenuItem("&Settings", new System.EventHandler(Show_Settings)));
            mnuNotify.MenuItems.Add(new MenuItem("&About", new System.EventHandler(Show_About)));
            mnuNotify.MenuItems.Add(new MenuItem("&Exit", new System.EventHandler(Quit)));
            ntyIcon.ContextMenu = mnuNotify;
            ntyIcon.Visible = true;
            
            //setup the tooltips for the buttons
            ToolTip ttAdd = new ToolTip();
            ttAdd.SetToolTip(imgAdd, "Add Profile");

            ToolTip ttDelete = new ToolTip();
            ttDelete.SetToolTip(imgDelete, "Delete Profile");

            ToolTip ttClose = new ToolTip();
            ttClose.SetToolTip(imgClose, "Quit Network++");

        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            displayProfiles();

        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {

            frmAddProfile AddProfile = new frmAddProfile(this);
            AddProfile.Show();

        }

        public void displayProfiles()
        {

            lstProfiles.Items.Clear();

            for (int i = 0; i < Profiles.getProfileCount(); i++)
            {

                ListViewItem a = new ListViewItem();
                a.Text = Profiles.getProfile(i).Name;

                lstProfiles.Items.Add(Profiles.getProfile(i).Name);

            }
            
        }

        public void loadProfiles()
        {

            string configFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkPlusPlus", "config.xml");
            
            try
            {

                XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
                xmlDoc.Load(configFile);

                XmlNodeList profileslist = xmlDoc.GetElementsByTagName("Profile");

                for (int i = 0; i < profileslist.Count; i++)
                {

                    Profile tmpProfile = new Profile();
                    XmlNodeList nodelist = profileslist[i].ChildNodes;

                    for (int i2 = 0; i2 < nodelist.Count; i2++)
                    {

                        if (nodelist[i2].Name == "Name")
                        {
                            if (nodelist[i2].InnerText != null)
                            {
                                tmpProfile.Name = nodelist[i2].InnerText.ToString();
                            }
                        }

                        if (nodelist[i2].Name == "IPAddress")
                        {
                            if (nodelist[i2].InnerText != null)
                            {
                                tmpProfile.IP = nodelist[i2].InnerText.ToString();
                            }
                        }

                        if (nodelist[i2].Name == "Subnet")
                        {
                            if (nodelist[i2].InnerText != null)
                            {
                                tmpProfile.Subnet = nodelist[i2].InnerText.ToString();
                            }
                        }

                        if (nodelist[i2].Name == "Gateway")
                        {
                            if (nodelist[i2].InnerText != null)
                            {
                                tmpProfile.Gateway = nodelist[i2].InnerText.ToString();
                            }
                        }

                        if (nodelist[i2].Name == "PrimaryDNS")
                        {
                            if (nodelist[i2].InnerText != null)
                            {
                                tmpProfile.PrimaryDNS = nodelist[i2].InnerText.ToString();
                            }
                        }

                        if (nodelist[i2].Name == "SecondaryDNS")
                        {
                            if (nodelist[i2].InnerText != null)
                            {
                                tmpProfile.SecondaryDNS = nodelist[i2].InnerText.ToString();
                            }
                        }

                    }

                    Profiles.addProfile(tmpProfile);

                }
            }
            catch (Exception ex)
            {

                if (ex.Message.ToString().Trim().ToLower() != "root element is missing.") //Exculde problems where the config file is empty
                {
                    if (System.IO.File.Exists(configFile))
                    {
                        string profileBak = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkPlusPlus", "config" + DateTime.Now.ToString("ddMMyyHHmm") + ".xml.bak");

                        MessageBox.Show("The configuration file was found but is corrupt. Creating new configuration file. All profiles have been lost");
                        System.IO.File.Copy(configFile, profileBak, true);

                    }

                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkPlusPlus"));
                    System.IO.File.Create(configFile);
                }

            }

        }

        private void ntyIcon_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (frmChange.Visible)
                {
                    frmChange.Hide();
                }
                else
                {
                    frmChange.Show();
                    frmChange.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmChange.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - frmChange.Height - 5);
                }
            }

        }

        private void Show_Settings(Object sender, System.EventArgs e)
        {
            this.Visible = true;
        }

        private void Show_About(Object sender, System.EventArgs e)
        {
            frmChange.frmAbout.Visible = true;
        }

        private void Quit(Object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close Network Plus Plus", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
 
                Application.Exit();

            }
        }

        private void enableDeleteButton()
        {
            if (lstProfiles.SelectedIndex < 0)
            {
                deleteDisabled = true;
                imgDelete.BackColor = Color.FromArgb(90, 90, 90);
            }
            else
            {
                deleteDisabled = false;
                imgDelete.BackColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDeleteButton();
        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            enableDeleteButton();
            this.BringToFront();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);
        
        }

        private void imgAdd_MouseEnter(object sender, EventArgs e)
        {
            imgAdd.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void imgAdd_MouseLeave(object sender, EventArgs e)
        {
            imgAdd.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void imgDelete_MouseEnter(object sender, EventArgs e)
        {
            if (!deleteDisabled)
            {
                imgDelete.BackColor = Color.FromArgb(241, 241, 241);
            }
        }

        private void imgDelete_MouseLeave(object sender, EventArgs e)
        {
            if (!deleteDisabled)
            {
                imgDelete.BackColor = Color.FromArgb(77, 77, 77);
            }
        }

        private void imgClose_MouseEnter(object sender, EventArgs e)
        {
            imgClose.BackColor = Color.FromArgb(241, 241, 241);
        }

        private void imgClose_MouseLeave(object sender, EventArgs e)
        {
            imgClose.BackColor = Color.FromArgb(77, 77, 77);
        }

        private void imgAdd_Click(object sender, EventArgs e)
        {
            frmAddProfile AddProfile = new frmAddProfile(this);
            AddProfile.Show();
        }

        private void imgDelete_Click(object sender, EventArgs e)
        {

            if (lstProfiles.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the profile " + lstProfiles.SelectedItem.ToString(), "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //find the profile and remove it
                    Profiles.removeProfile(lstProfiles.SelectedItem.ToString());
                    Profiles.saveProfiles();
                    displayProfiles();
                    enableDeleteButton();

                }
            }
            else
            {
                MessageBox.Show("You must have a profile selected to delete it");
            }

        }

        private void imgClose_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to close Network Plus Plus", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.ExitThread();
            }

        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
