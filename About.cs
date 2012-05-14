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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void rtAbout_TextChanged(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            rtAbout.Text = "Network Plus Plus is developed and maintained by http://www.onemetric.com.au. It is released under the GNU General Public License, version 2. You can view a copy of this license at www.gnu.org/licenses/gpl-2.0.html" + Environment.NewLine + Environment.NewLine;
            rtAbout.Text += "This program uses icons from the AwOken icon set developed by alecive. This icon set can be viewed and downloaded at http://alecive.deviantart.com/art/AwOken-163570862";


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void About_VisibleChanged(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void rtAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
