using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TotDbs_ArchivierungsTool.Classes;

namespace TotDbs_ArchivierungsTool.Forms
{
    public partial class Frm_Transferring_Report : Form
    {
        public Frm_Transferring_Report()
        {
            InitializeComponent();
        }
        private void Frm_Compare_Load(object sender, EventArgs e)
        {
            Cls_ReadServers readservers = new Cls_ReadServers();
            List<string> servers = readservers.listOfServers;
            Cmb_Server.Items.Clear();
            Cmb_Server.Items.AddRange(servers.ToArray());

            if (!string.IsNullOrEmpty(Properties.Settings.Default.archiv_server.ToString()))
            {
                Cmb_Server.Text = Properties.Settings.Default.archiv_server.ToString();
                Cmb_Db_Enter(null, null);
                Cmb_Db.Text = Properties.Settings.Default.archiv_db.ToString();
            }
            grdview_ReportDetails.ViewCaption = "";
        }
        private void Cmb_Server_Enter(object sender, EventArgs e)
        {
            Cmb_Db.Text = "";
            grdview_ReportDetails.ViewCaption = "";
        }
        private void Cmb_Db_Enter(object sender, EventArgs e)
        {
            Cmb_Db.Items.Clear();
            grdview_ReportDetails.ViewCaption = "";
            string serverName = Cmb_Server.Text.ToString();
            try
            {
                Cls_ReadDataBases readDatabases = new Cls_ReadDataBases(serverName);
                List<string> dataBases = readDatabases.listOfDatabases;
                Cmb_Db.Items.AddRange(dataBases.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Error Reading Source DB");
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Retrieve_Report();
            Retrieve_Statistics();
        }
        private void Retrieve_Report()
        {
            Cntrl_ReportDetails.DataSource = null;
            grdview_ReportDetails.Columns.Clear();
            string serverName = Cmb_Server.Text.ToString();
            string DbName = Cmb_Db.Text.ToString();

            Cls_RetrieveReport cls_report = new Cls_RetrieveReport(serverName, DbName);
            DataTable dt_report = cls_report.Archiv_Table();

            if (dt_report == null) return;
            Cntrl_ReportDetails.DataSource = dt_report;
            grdview_ReportDetails.ViewCaption = "Server Name: " + serverName + "    DataBase Name: " + DbName;
        }
        private void Retrieve_Statistics()
        {
            string serverName = Cmb_Server.Text.ToString();
            string DbName = Cmb_Db.Text.ToString();
            Cls_RetrieveReport cls_reports = new Cls_RetrieveReport(serverName, DbName);
            List<string> lstof_satatistics = new List<string>();
            lstof_satatistics = cls_reports.Archiv_Statistics();
            lstbox_Statistics.DataSource = lstof_satatistics;
        }
        private void Grdview_ReportDetails_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frm_Transferring_Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.archiv_server = Cmb_Server.Text.ToString();
            Properties.Settings.Default.archiv_db = Cmb_Db.Text.ToString();

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Reload();
        }
    }
}