using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NetworkPlusPlus
{
    public partial class Details : Form
    {

        delegate void showActionCallback(String Message);
        delegate void hideActionCallback();
        delegate void setNameCallback(String Name);
        delegate void setDescriptionCallback(String Details);
        delegate void setDetailsCallback(String Details);
        delegate void setDisableButtonTextCallback(String Text);
        delegate void setRenewButtonEnabledCallback(bool state);
        delegate void changeProfileCallback(String profileName);
        delegate void disableControlsCallback();
        delegate void enableControlsCallback();
        delegate void reloadInterfaceCallback();
        delegate void disableBtnInterfaceStateCallback(bool state);

        static Interface currInterface;
        private string InterfaceName;
        static string strSelectedProfile = "";

        private bool btnDisableEnabled = true;
        private bool btnRenewEnabled = true;

        ToolTip ttDisable = new ToolTip();
        ToolTip ttRenew = new ToolTip();
        ToolTip ttReload = new ToolTip();

        public Details()
        {
            
            InitializeComponent();

            if (Environment.OSVersion.Version.Major < 6)
            {
                ttDisable.SetToolTip(imgDisable, "Not Supported in Windows XP");
                disableEnableBtn(true);
            }
            else
            {
                ttDisable.SetToolTip(imgDisable, "Disable Interface");
            }
            ttRenew.SetToolTip(imgRenew, "Renew/Release DHCP IP Address");
            ttReload.SetToolTip(btnReload, "Reload Interface");

        }

        public void showInterface(String interfaceName)
        {

            this.Show();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);
            showAction("Loading");

            InterfaceName = interfaceName;
            loadInterface(InterfaceName);

            //Display
            MethodInvoker mi = new MethodInvoker(displayDetails);
            mi.BeginInvoke(null, null);

            cbProfiles.Items.Clear();

            //Display all the profiles
            for (int i = 0; i < Profiles.getProfileCount(); i++)
            {

                cbProfiles.Items.Add(Profiles.getProfile(i).Name);

                //try work out if one of the profiles is selected already
                if (currInterface.DHCPEnabled)
                {
                    if (Profiles.getProfile(i).IP == "")
                    {
                        cbProfiles.SelectedIndex = cbProfiles.FindStringExact(Profiles.getProfile(i).Name);
                    }
                }
                else
                {
                    if (Profiles.getProfile(i).IP == currInterface.IPAddresses[0])
                    {
                        if (Profiles.getProfile(i).Subnet == currInterface.SubnetMasks[0])
                        {
                            if (Profiles.getProfile(i).Gateway == currInterface.DefaultGateway[0])
                            {
                                cbProfiles.SelectedIndex = cbProfiles.FindStringExact(Profiles.getProfile(i).Name);
                            }
                        }
                    }
                }

            }

            hideAction();

        }

        private void displayDetails()
        {

            String strDetails = "";

            //Populate the Details
            setName(currInterface.Name);
            setDescription(currInterface.Description);

            strDetails = "Manufacturer: " + currInterface.Manufacturer + Environment.NewLine;
            strDetails += "Mac Address: " + currInterface.MacAddress + Environment.NewLine;
            strDetails += "Hostname: " + currInterface.Hostname + "." + currInterface.DNSSuffix + Environment.NewLine;
            strDetails += "Connection Status: " + Interfaces.getConnectionStatus(currInterface.ConnectionStatus) + Environment.NewLine;

            if (!currInterface.Enabled)
            {
                strDetails += "Status: Disabled" + Environment.NewLine;
                setRenewButtonEnabled(false);
                disableBtnInterfaceState(true);
            }
            else
            {

                disableBtnInterfaceState(false);

                strDetails += "Status: Enabled" + Environment.NewLine;
                strDetails += Environment.NewLine;

                if (currInterface.DHCPEnabled)
                {
                    strDetails += "DHCP" + Environment.NewLine;
                    strDetails += "DHCP Server: " + currInterface.DHCPServer + Environment.NewLine;
                    strDetails += "Lease Start: " + currInterface.DHCPLeaseStarted + Environment.NewLine;
                    strDetails += "Lease Expires: " + currInterface.DHCPLeaseExpires + Environment.NewLine;
                    strDetails += Environment.NewLine;

                    setRenewButtonEnabled(true);

                }
                else
                {
                    setRenewButtonEnabled(false);
                }

                if (currInterface.DNSServers != null)
                {
                    if (currInterface.DNSServers.Count() > 0)
                    {
                        strDetails += "DNS" + Environment.NewLine;
                        for (int i = 0; i < currInterface.DNSServers.Count(); i++)
                        {
                            strDetails += "Server " + (i + 1) + ": " + currInterface.DNSServers[i] + Environment.NewLine;
                        }
                    }
                }

                //Add all the IP's
                if (currInterface.IPAddresses != null && currInterface.IPAddresses.Count() > 0)
                {

                    strDetails += Environment.NewLine;
                    strDetails += "IP Addresses" + Environment.NewLine;

                    for (int i = 0; i < currInterface.IPAddresses.Count(); i++)
                    {

                        strDetails += currInterface.IPAddresses[i] + "/" + currInterface.SubnetMasks[i] + Environment.NewLine;

                    }
                }
            }

            setDetails(strDetails);

        }

        private void changeFocus(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void renewIP()
        {
            showAction("Renewing IP");
            disableControls();
            Interfaces.renewDHCP(currInterface);
            currInterface.reloadInterface();
            enableControls();
            displayDetails();
            hideAction();
        }

        private void changeProfile()
        {

            showAction("Changing Profile");
            disableControls();
            lock (strSelectedProfile)
            {
                
                //change the profile
                Profile selectedProfile = Profiles.findProfilebyName(strSelectedProfile);
                currInterface.applyProfile(selectedProfile);
                currInterface.reloadInterface();

            }
            
            enableControls();
            displayDetails();
            
            hideAction();

        }

        private void btnChangeProfiles_Click(object sender, EventArgs e)
        {

            if (cbProfiles.SelectedItem != null)
            {
                strSelectedProfile = cbProfiles.SelectedItem.ToString();

                MethodInvoker mi = new MethodInvoker(changeProfile);
                mi.BeginInvoke(null, null);
            
            }
            
        }

        private void disableInterface()
        {

            if (Environment.OSVersion.Version.Major >= 6)
            {
                showAction("Disabling Interface");
                disableControls();
                currInterface.disableInterface();
                currInterface.reloadInterface();
                enableControls();
                disableBtnInterfaceState(false);
                displayDetails();
                hideAction();
            }
        }

        private void enableInterface()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                showAction("Enabling Interface");
                disableControls();
                currInterface.enableInterface();
                System.Threading.Thread.Sleep(2000); //give the interface a couple of seconds to come up
                currInterface.reloadInterface();
                enableControls();
                disableBtnInterfaceState(true);
                displayDetails();
                hideAction();
            }
        }


        private void showAction(String Message)
        {

            if (this.InvokeRequired)
            {
                showActionCallback cb = new showActionCallback(showAction);
                this.Invoke(cb, new object[] { Message });
            }
            else
            {
                ptbLoading.Visible = true;
                lblCurrentAction.Text = Message;
                lblCurrentAction.Visible = true;
            }

        }

        private void hideAction()
        {
            if (this.InvokeRequired)
            {
                hideActionCallback cb = new hideActionCallback(hideAction);
                this.Invoke(cb, null);
            }
            else
            {
                ptbLoading.Visible = false;
                lblCurrentAction.Visible = false;
            }
        }

        private void setName(String Name)
        {

            if (this.InvokeRequired)
            {
                setNameCallback cb = new setNameCallback(setName);
                this.Invoke(cb, new object[] { Name });
            }else{
                lblInterfaceName.Text = Name;
            }
        }

        private void setDescription(String Description)
        {

            if (this.InvokeRequired)
            {
                setDescriptionCallback cb = new setDescriptionCallback(setDescription);
                this.Invoke(cb, new object[] { Description });
            }
            else
            {
                lblInterfaceDescription.Text = Description;
            }
        }

        private void setDetails(String Details)
        {

            if (this.InvokeRequired)
            {
                setDetailsCallback cb = new setDetailsCallback(setDetails);
                this.Invoke(cb, new object[] { Details });
            }
            else
            {
                lblDetails.Text = Details;
            }
        }

        private void setRenewButtonEnabled(bool state)
        {

            if (this.InvokeRequired)
            {
                setRenewButtonEnabledCallback cb = new setRenewButtonEnabledCallback(setRenewButtonEnabled);
                this.Invoke(cb, new object[] { state });
            }
            else
            {

                disableRenewBtn(!state);

            }

        }

        private void loadInterface(String interfaceName)
        {

            showAction("Loading Interface");

            if (currInterface == null)
            {
                currInterface = Interfaces.findInterfacebyName(interfaceName);
            }else{
                lock (currInterface)
                {
                    currInterface = Interfaces.findInterfacebyName(interfaceName);
                }
            }

            hideAction();

        }

        private void reloadCurrentInterface()
        {
            if (currInterface != null)
            {
                lock (currInterface)
                {
                    currInterface.reloadInterface();
                }
            }
        }

        private void disableControls()
        {
            if (this.InvokeRequired)
            {
                disableControlsCallback cb = new disableControlsCallback(disableControls);
                this.Invoke(cb, null);
            }
            else
            {
                btnChangeProfiles.Enabled = false;
                btnReload.Enabled = false;
                cbProfiles.Enabled = false;
                disableEnableBtn(true);
                disableRenewBtn(true);
            }
        }

        private void enableControls()
        {
            if (this.InvokeRequired)
            {
                enableControlsCallback cb = new enableControlsCallback(enableControls);
                this.Invoke(cb, null);
            }
            else
            {
                btnChangeProfiles.Enabled = true;
                cbProfiles.Enabled = true;
                btnReload.Enabled = true;
                disableEnableBtn(false);
            }
        }

        private void reloadInterface()
        {
            
            showAction("Reloading Interface");
            disableControls();
            currInterface.reloadInterface();
            enableControls();
            displayDetails();
            hideAction();
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

            MethodInvoker mi = new MethodInvoker(reloadInterface);
            mi.BeginInvoke(null, null);
            
        }

        private void imgDisable_MouseEnter(object sender, EventArgs e)
        {
            if (btnDisableEnabled)
            {
                imgDisable.BackColor = Color.FromArgb(241, 241, 241);
            }
        }

        private void imgDisable_MouseLeave(object sender, EventArgs e)
        {
            if (btnDisableEnabled)
            {
                imgDisable.BackColor = Color.FromArgb(77, 77, 77);
            }
            else
            {
                imgDisable.BackColor = Color.FromArgb(90, 90, 90);
            }
        }

        private void imgRenew_MouseEnter(object sender, EventArgs e)
        {
            if (btnRenewEnabled)
            {
                imgRenew.BackColor = Color.FromArgb(241, 241, 241);
            }
        }

        private void imgRenew_MouseLeave(object sender, EventArgs e)
        {
            if (btnRenewEnabled)
            {
                imgRenew.BackColor = Color.FromArgb(77, 77, 77);
            }
            else
            {
                imgRenew.BackColor = Color.FromArgb(90, 90, 90);
            }
        }

        private void disableBtnInterfaceState(bool state)
        {

            if (this.InvokeRequired)
            {
                disableBtnInterfaceStateCallback cb = new disableBtnInterfaceStateCallback(disableBtnInterfaceState);
                this.Invoke(cb, new object[] { state });
            }
            else
            {

                if (!state)
                {
                    this.imgDisable.Image = global::NetworkPlusPlus.Properties.Resources.notification_network_ethernet_disconnected;
                    ttDisable.SetToolTip(imgDisable, "Disable Network Interface");
                }
                else
                {
                    this.imgDisable.Image = global::NetworkPlusPlus.Properties.Resources.notification_network_ethernet_connected;
                    ttDisable.SetToolTip(imgDisable, "Enable Network Interface");
                }
            }
            
        }

        private void disableEnableBtn(bool state)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                btnDisableEnabled = !state;
            }
            else
            {
                btnDisableEnabled = false;
            }
            
            if (btnDisableEnabled)
            {
                imgDisable.BackColor = Color.FromArgb(77, 77, 77);
            }
            else
            {
                imgDisable.BackColor = Color.FromArgb(90, 90, 90);
            }
            
        }

        private void disableRenewBtn(bool state)
        {
            btnRenewEnabled = !state;

            if (btnRenewEnabled)
            {
                imgRenew.BackColor = Color.FromArgb(77, 77, 77);
            }
            else
            {
                imgRenew.BackColor = Color.FromArgb(90, 90, 90);
            }

        }

        private void imgDisable_Click(object sender, EventArgs e)
        {
            if (btnDisableEnabled)
            {
                if (currInterface.Enabled)
                {
                    MethodInvoker mi = new MethodInvoker(disableInterface);
                    mi.BeginInvoke(null, null);
                }
                else
                {
                    MethodInvoker mi = new MethodInvoker(enableInterface);
                    mi.BeginInvoke(null, null);
                }
            }

        }

        private void imgRenew_Click(object sender, EventArgs e)
        {
            if (btnRenewEnabled)
            {
                MethodInvoker mi = new MethodInvoker(renewIP);
                mi.BeginInvoke(null, null);
            }
        }

        private void Details_VisibleChanged(object sender, EventArgs e)
        {
            this.BringToFront();
        }

    }
}
