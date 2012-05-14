using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace NetworkPlusPlus
{
    public partial class frmAddProfile : Form
    {

        private Main m_parent;

        public frmAddProfile(Main frmMain)
        {
            InitializeComponent();

            //setup the default page
            rdIPDHCP.Checked = true;
            rdIPManual.Checked = false;
            rdDNSDHCP.Checked = true;
            rdDNSManual.Checked = false;

            txtIPAddress.Enabled = false;
            txtSubnetMask.Enabled = false;
            txtDefaultGateway.Enabled = false;

            DisableDNSEditing();

            m_parent = frmMain;

        }

        private void rdIPManual_CheckedChanged(object sender, EventArgs e)
        {

            if (rdIPManual.Checked)
            {

                txtIPAddress.Enabled = true;
                txtSubnetMask.Enabled = true;
                txtDefaultGateway.Enabled = true;

                rdDNSDHCP.Enabled = true;
                rdDNSManual.Enabled = true;

                EnableDNSEditing();

            }
            else
            {
                txtIPAddress.Enabled = false;
                txtSubnetMask.Enabled = false;
                txtDefaultGateway.Enabled = false;

                rdDNSManual.Enabled = true;
                rdDNSDHCP.Enabled = true;
                rdDNSManual.Checked = true;
                
            }

        }

        private void rdDNSManual_CheckedChanged(object sender, EventArgs e)
        {

            if (rdDNSManual.Checked)
            {
                txtDNS1.Enabled = true;
                txtDNS2.Enabled = true;
            }
            else
            {
                txtDNS1.Enabled = false;
                txtDNS2.Enabled = false;
            }

        }

        private void EnableDNSEditing()
        {


            if (rdIPManual.Checked)
            {
                rdDNSDHCP.Enabled = false;
                rdDNSManual.Enabled = false;
                rdDNSManual.Checked = true;
            }
            else
            {
                rdDNSDHCP.Enabled = true;
                rdDNSManual.Enabled = true;
            }

            if (rdDNSDHCP.Checked)
            {
                txtDNS1.Enabled = false;
                txtDNS2.Enabled = false;
            }
            else
            {
                txtDNS1.Enabled = true;
                txtDNS2.Enabled = true;
            }
        }

        private void DisableDNSEditing()
        {
            rdDNSDHCP.Enabled = false;
            rdDNSManual.Enabled = false;

            txtDNS1.Enabled = false;
            txtDNS2.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            bool blunique = true;

            //check if a profile already exists with this name
            for (int i = 0; i < Profiles.getProfileCount(); i++)
            {
                if (Profiles.getProfile(i).Name.ToLower() == txtName.Text.ToLower())
                {
                    blunique = false;
                    break;
                }
            }

            if (blunique)
            {

                System.Net.IPAddress ip = new System.Net.IPAddress(new byte[] {0, 0, 0, 0});
                System.Net.IPAddress subnet = new System.Net.IPAddress(new byte[] {0, 0, 0, 0});
                System.Net.IPAddress gateway = new System.Net.IPAddress(new byte[] {0, 0, 0, 0});
                System.Net.IPAddress DNS1;
                System.Net.IPAddress DNS2;
                bool Valid = true;
                Profile newProfile = new Profile();

                //validate all the fields
                if (txtName.Text.Trim() != "")
                {
                    newProfile.Name = txtName.Text;
                }
                else
                {
                    Valid = false;
                }

                if (!rdIPDHCP.Checked)
                {
                    if (System.Net.IPAddress.TryParse(txtIPAddress.Text, out ip))
                    {
                        newProfile.IP = ip.ToString();
                    }
                    else
                    {
                        Valid = false;
                    }

                    if (System.Net.IPAddress.TryParse(txtSubnetMask.Text, out subnet))
                    {
                        newProfile.Subnet = subnet.ToString();
                    }
                    else
                    {
                        Valid = false;
                    }

                    if (System.Net.IPAddress.TryParse(txtDefaultGateway.Text, out gateway))
                    {
                        newProfile.Gateway = gateway.ToString();
                    }
                    else
                    {
                        Valid = false;
                    }
                }

                if (!rdDNSDHCP.Checked)
                {
                    if (System.Net.IPAddress.TryParse(txtDNS1.Text, out DNS1))
                    {
                        newProfile.PrimaryDNS = DNS1.ToString();
                    }

                    if (System.Net.IPAddress.TryParse(txtDNS2.Text, out DNS2))
                    {
                        newProfile.SecondaryDNS = DNS2.ToString();
                    }
                }

                if (Valid)
                {

                    //check the subnet is correct
                    if (checkValidSubnet(subnet))
                    {

                        if(checkInSubnet(ip, gateway, subnet))
                        {

                            Profiles.addProfile(newProfile);
                            Profiles.saveProfiles();

                            m_parent.displayProfiles();
                            this.Dispose();

                        }else{
                            MessageBox.Show("The Gateway is not in the same subnet as the IP Address");
                        }

                    }
                    else
                    {
                        MessageBox.Show("The Subnet you have entered is not a valid subnet");
                    }
                    
                }
                else
                {
                   MessageBox.Show("Profile is not correct. Please ensure all fields are in the correct format");
                }
            }
            else
            {
                MessageBox.Show("A profile by that name already exists.");
            }

        }

        private void frmAddProfile_VisibleChanged(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private System.Net.IPAddress getNetworkAddress(System.Net.IPAddress ip, System.Net.IPAddress subnet)
        {
            //Based on the code by knom at http://blogs.msdn.com/b/knom/archive/2008/12/31/ip-address-calculations-with-c-subnetmasks-networks.aspx
            
            byte[] btsIP = ip.GetAddressBytes();
            byte[] btsSubnet = subnet.GetAddressBytes();

            byte[] btsBroadcast = new byte[btsIP.Length];
            for (int i = 0; i < btsBroadcast.Length; i++)
            {
                btsBroadcast[i] = (byte)(btsIP[i] & (btsSubnet[i]));
            }

            return new System.Net.IPAddress(btsBroadcast);

        }

        private bool checkInSubnet(System.Net.IPAddress ip1, System.Net.IPAddress ip2, System.Net.IPAddress subnet)
        {
            //Based on the code by knom at http://blogs.msdn.com/b/knom/archive/2008/12/31/ip-address-calculations-with-c-subnetmasks-networks.aspx

            System.Net.IPAddress network1 = getNetworkAddress(ip1, subnet);
            System.Net.IPAddress network2 = getNetworkAddress(ip2, subnet);

            if (network1.Equals(network2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool checkValidSubnet(System.Net.IPAddress subnet)
        {
            //No way is this the best way to do this but it gets the job done

            byte[] btssubnet = subnet.GetAddressBytes();
            bool subnetValid = true;
            bool endSubnet = false;

            for (int i = 0; i < btssubnet.Count(); i++)
            {

                if (btssubnet[i] == 0 || btssubnet[i] == 128 || btssubnet[i] == 192 || btssubnet[i] == 224 || btssubnet[i] == 240 || btssubnet[i] == 248 || btssubnet[i] == 252 || btssubnet[i] == 254 || btssubnet[i] == 255)
                {
                    if (endSubnet)
                    {
                        if (btssubnet[i] != 0)
                        {
                            subnetValid = false;

                            break;
                        }
                    }

                    if (btssubnet[i] == 0)
                    {
                        endSubnet = true;
                    }
                }
                else
                {
                    subnetValid = false;

                    break;
                }

            }

            return subnetValid;

        }

    }
}
