using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotDbs_ArchivierungsTool.Forms
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Frm_Wizard frm = new Frm_Wizard();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Frm_Transferring_Report frm = new Frm_Transferring_Report();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }
    }
}
