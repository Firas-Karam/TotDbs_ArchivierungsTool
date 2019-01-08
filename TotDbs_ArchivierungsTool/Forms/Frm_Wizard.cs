using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TotDbs_ArchivierungsTool.Classes;

namespace TotDbs_ArchivierungsTool.Forms
{
    public partial class Frm_Wizard : Form
    {
        public Frm_Wizard()
        {
            InitializeComponent();
        }
        private void Frm_Wizard_Load(object sender, EventArgs e)
        {
            Cmb_FromKind.SelectedIndex = 0;
            Cmb_FromSchema.SelectedIndex = 0;
            Fill_Combos_WithServers();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.source_server_name.ToString()))
            {
                Cmb_FromServer.Text = Properties.Settings.Default.source_server_name.ToString();
                Cmb_FromDb_Enter(null, null);
                Cmb_FromDb.Text = Properties.Settings.Default.source_db_name.ToString();
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.dest_server_name.ToString()))
            {
                Cmb_ToServer.Text = Properties.Settings.Default.dest_server_name.ToString();
                Cmb_ToDb_Enter(null, null);
                Cmb_ToDb.Text = Properties.Settings.Default.dest_db_name.ToString();
            }
        }
        private void Frm_Wizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.source_server_name = Cmb_FromServer.Text.ToString();
            Properties.Settings.Default.source_db_name = Cmb_FromDb.Text.ToString();
            Properties.Settings.Default.dest_server_name = Cmb_ToServer.Text.ToString();
            Properties.Settings.Default.dest_db_name = Cmb_ToDb.Text.ToString();

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Reload();
        }
        private void wizardControl1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void wizardControl1_CancelClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Close();
        }
        #region ******** FillCombos ***************
        private void Fill_Combos_WithServers()
        {
            Cls_ReadServers readservers = new Cls_ReadServers();
            List<string> servers = readservers.listOfServers;
            Cmb_FromServer.Items.Clear();
            Cmb_ToServer.Items.Clear();
            Cmb_FromServer.Items.AddRange(servers.ToArray());
            Cmb_ToServer.Items.AddRange(servers.ToArray());
            if (Cmb_FromServer.Items.Count > 0) Cmb_FromServer.SelectedIndex = 0;
            if (Cmb_ToServer.Items.Count > 0) Cmb_ToServer.SelectedIndex = 0;
        }
        private void Cmb_FromServer_Enter(object sender, EventArgs e)
        {
            Cmb_FromDb.Items.Clear();
            Cmb_FromSchema.Items.Clear();
        }
        private void Cmb_FromDb_Enter(object sender, EventArgs e)
        {
            Cmb_FromDb.Items.Clear();
            string serverName = Cmb_FromServer.Text.ToString();
            try
            {
                Cls_ReadDataBases readDatabases = new Cls_ReadDataBases(serverName);
                List<string> dataBases = readDatabases.listOfDatabases;
                Cmb_FromDb.Items.AddRange(dataBases.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Error Reading Source DB");
            }
            Cmb_FromSchema.Items.Clear();
            Cmb_FromSchema.Items.Add(" All Schemas ....");
            Cmb_FromSchema.SelectedIndex = 0;
        }
        private void Cmb_FromSchema_Enter(object sender, EventArgs e)
        {
            Cmb_FromSchema.Items.Clear();
            string serverName = Cmb_FromServer.Text.ToString();
            string DbName = Cmb_FromDb.Text.ToString();
            Cls_ReadSchemas readschemas = new Cls_ReadSchemas(serverName, DbName);
            List<string> schemas = readschemas.listOfSchemas;
            Cmb_FromSchema.Items.AddRange(schemas.ToArray());
            Cmb_FromSchema.Items.Add(" All Schemas ....");
            Cmb_FromSchema.SelectedIndex = 0;
        }
        private void Cmb_ToServer_Enter(object sender, EventArgs e)
        {
            Cmb_ToDb.Items.Clear();
            cmbRep_DestSchema.Items.Clear();
            Cmb_DestSchema.Items.Clear();
        }
        private void Cmb_ToDb_Enter(object sender, EventArgs e)
        {
            Cmb_ToDb.Items.Clear();
            string serverName = Cmb_ToServer.Text.ToString();
            try
            {
                Cls_ReadDataBases readDatabases = new Cls_ReadDataBases(serverName);
                List<string> dataBases = readDatabases.listOfDatabases;
                Cmb_ToDb.Items.AddRange(dataBases.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Error Reading Destination DB");
            }
        }
        private void Cmb_ToDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill cmbRep_DestSchema(Grid Combo) and schema Combo
            if (Cmb_FromKind.Text == "Table")
            {
                string serverName = Cmb_ToServer.Text.ToString();
                string DbName = Cmb_ToDb.Text.ToString();
                Cls_ReadSchemas readschemas = new Cls_ReadSchemas(serverName, DbName);
                List<string> schemas = readschemas.listOfSchemas;
                cmbRep_DestSchema.Items.Clear();
                cmbRep_DestSchema.Items.AddRange(schemas.ToArray());

                Cmb_DestSchema.Items.Clear();
                Cmb_DestSchema.Items.AddRange(schemas.ToArray());
                string tableNameSource = "";
                for (int gridRo = 0; gridRo < grdview_Destination.RowCount; gridRo++)
                {
                    tableNameSource = grdview_Destination.GetRowCellValue(gridRo, "Source Table").ToString();
                    grdview_Destination.SetRowCellValue(gridRo, "Destination Table", "");
                    grdview_Destination.SetRowCellValue(gridRo, "DestTable Schema", "");
                    grdview_Destination.SetRowCellValue(gridRo, "DestTable Rows", "");
                    grdview_Destination.SetRowCellValue(gridRo, "Destination Table", tableNameSource);
                    grdview_Destination.SetRowCellValue(gridRo, "DestTable Status", "New");
                }
            }
        }
        #endregion  ********* FillCombos ***************

        #region ******** Wizard_SourcePage *********
        private void Cmb_FromKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByKind();
        }
        private void Cmb_FromSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByKind();
        }
        private void Cmb_FromDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByKind();
        }
        private void FilterByKind()
        {
            string kind = Cmb_FromKind.Text.ToString();
            string serverName = Cmb_FromServer.Text.ToString();
            string DbName = Cmb_FromDb.Text.ToString();
            string schema = Cmb_FromSchema.Text.ToString();
            if (schema == " All Schemas ....") schema = "";
            Cls_ReadFromDb readTables = new Cls_ReadFromDb(serverName, DbName, schema);
            Cntrl_Source.DataSource = null;
            grdview_Source.Columns.Clear();

            Cntrl_Destination.DataSource = null;
            grdview_Destination.Columns.Clear();

            cntrl_Transfer.DataSource = null;
            grdview_Transfer.Columns.Clear();
            switch (kind)
            {
                case "Select Kind .....":
                    Cntrl_Source.DataSource = null;
                    break;
                case "Table":
                    DataTable dtb_tablesInFromDb = new DataTable();
                    dtb_tablesInFromDb = readTables.GetTables();
                    Cntrl_Source.DataSource = dtb_tablesInFromDb;
                    break;
                case "View":
                    DataTable dtb_viewsInFromDb = new DataTable();
                    dtb_viewsInFromDb = readTables.GetViews();
                    Cntrl_Source.DataSource = dtb_viewsInFromDb;
                    break;
                case "Procedure":
                    DataTable dtb_proceduresInFromDb = new DataTable();
                    dtb_proceduresInFromDb = readTables.GetProcedures();
                    Cntrl_Source.DataSource = dtb_proceduresInFromDb;
                    break;
                case "Function":
                    DataTable dtb_functionsInFromDb = new DataTable();
                    dtb_functionsInFromDb = readTables.GetFunctions();
                    Cntrl_Source.DataSource = dtb_functionsInFromDb;
                    break;
            }
            lbl_RowsCount_Source.Text = grdview_Source.RowCount.ToString();
        }
        #endregion ******** Wizard_SourcePage *********

        #region ******** Wizard_DestinationPage   *********
        private void WelcomeWizardPage1_PageCommit(object sender, EventArgs e)
        {
            string kind = Cmb_FromKind.Text.ToString();
            lbl_src_server.Text = Cmb_FromServer.Text.ToString();
            lbl_src_db.Text = Cmb_FromDb.Text.ToString();
            switch (kind)
            {
                case "Table":
                    Cntrl_Destination.DataSource = null;
                    grdview_Destination.Columns.Clear();
                    Cls_Build_DataTables buildTable = new Cls_Build_DataTables();
                    DataTable dtb_Dest_Tables = buildTable.Build_Tables();
                    if (dtb_Dest_Tables == null || dtb_Dest_Tables.Columns.Count == 0) break;
                    foreach (int roNum in grdview_Source.GetSelectedRows())
                    {
                        DataRow destRo = dtb_Dest_Tables.NewRow();
                        destRo["Source Schema"] = grdview_Source.GetRowCellValue(roNum, "Schema").ToString();
                        destRo["Source Table"] = grdview_Source.GetRowCellValue(roNum, "Table Name").ToString();
                        destRo["SourceTable Rows"] = grdview_Source.GetRowCellValue(roNum, "Rowcount").ToString();
                        dtb_Dest_Tables.Rows.Add(destRo);
                    }
                    Cntrl_Destination.DataSource = dtb_Dest_Tables;
                    grdview_Destination.Columns["DestTable Schema"].ColumnEdit = cmbRep_DestSchema;
                    grdview_Destination.Columns["DestTable Status"].ColumnEdit = cmbRep_TableStatus;
                    Cmb_ToDb_SelectedIndexChanged(null, null);
                    pnl_toschema.Visible = true;
                    break;
                case "View":
                    pnl_toschema.Visible = false;
                    Cntrl_Destination.DataSource = null;
                    grdview_Destination.Columns.Clear();
                    Cls_Build_DataTables buildView_DataTable = new Cls_Build_DataTables();
                    DataTable dtb_Dest_Views = buildView_DataTable.Build_datatable_Objects();
                    if (dtb_Dest_Views == null || dtb_Dest_Views.Columns.Count == 0) break;
                    foreach (int roNum in grdview_Source.GetSelectedRows())
                    {
                        DataRow destRo = dtb_Dest_Views.NewRow();
                        destRo["Source Schema"] = grdview_Source.GetRowCellValue(roNum, "Schema").ToString();
                        destRo["object Name"] = grdview_Source.GetRowCellValue(roNum, "View Name").ToString();
                        destRo["object Type"] = "View";
                        destRo["object Script"] = grdview_Source.GetRowCellValue(roNum, "View Script").ToString();
                        dtb_Dest_Views.Rows.Add(destRo);
                    }
                    Cntrl_Destination.DataSource = dtb_Dest_Views;
                    break;
                case "Procedure":
                    pnl_toschema.Visible = false;
                    Cntrl_Destination.DataSource = null;
                    grdview_Destination.Columns.Clear();
                    Cls_Build_DataTables buildProc_DataTable = new Cls_Build_DataTables();
                    DataTable dtb_Dest_Proc = buildProc_DataTable.Build_datatable_Objects();
                    if (dtb_Dest_Proc == null || dtb_Dest_Proc.Columns.Count == 0) break;
                    foreach (int roNum in grdview_Source.GetSelectedRows())
                    {
                        DataRow destRo = dtb_Dest_Proc.NewRow();
                        destRo["Source Schema"] = grdview_Source.GetRowCellValue(roNum, "Schema").ToString();
                        destRo["object Name"] = grdview_Source.GetRowCellValue(roNum, "Procedure Name").ToString();
                        destRo["object Type"] = "Procedure";
                        destRo["object Script"] = grdview_Source.GetRowCellValue(roNum, "Procedure Script").ToString();
                        dtb_Dest_Proc.Rows.Add(destRo);
                    }
                    Cntrl_Destination.DataSource = dtb_Dest_Proc;
                    break;
                case "Function":
                    pnl_toschema.Visible = false;
                    Cntrl_Destination.DataSource = null;
                    grdview_Destination.Columns.Clear();
                    Cls_Build_DataTables buildFunc_DataTable = new Cls_Build_DataTables();
                    DataTable dtb_Dest_Func = buildFunc_DataTable.Build_datatable_Objects();
                    if (dtb_Dest_Func == null || dtb_Dest_Func.Columns.Count == 0) break;
                    foreach (int roNum in grdview_Source.GetSelectedRows())
                    {
                        DataRow destRo = dtb_Dest_Func.NewRow();
                        destRo["Source Schema"] = grdview_Source.GetRowCellValue(roNum, "Schema").ToString();
                        destRo["object Name"] = grdview_Source.GetRowCellValue(roNum, "Function Name").ToString();
                        destRo["object Type"] = "Function";
                        destRo["object Script"] = grdview_Source.GetRowCellValue(roNum, "Function Script").ToString();
                        dtb_Dest_Func.Rows.Add(destRo);
                    }
                    Cntrl_Destination.DataSource = dtb_Dest_Func;
                    break;
                default:
                    break;
            }
            lbl_RowsCount_Dest.Text = grdview_Destination.RowCount.ToString();
        }
        private void Cmb_DestSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            string servername = Cmb_ToServer.Text.ToString();
            string destDbname = Cmb_ToDb.Text.ToString();
            string schemaSource = "", tableNameSource = "";
            Cls_ReadFromDb readTables = new Cls_ReadFromDb(servername, destDbname, "");
            DataTable allTables = readTables.GetTables();
            for (int roNum = 0; roNum < grdview_Destination.RowCount; roNum++)
            {
                grdview_Destination.SetRowCellValue(roNum, "DestTable Schema", Cmb_DestSchema.Text.ToString());
                grdview_Destination.SetRowCellValue(roNum, "DestTable Status", "New");
                // check if the Table Exist
                schemaSource = grdview_Destination.GetRowCellValue(roNum, "Source Schema").ToString();
                tableNameSource = grdview_Destination.GetRowCellValue(roNum, "Source Table").ToString();
                DataRow[] roInAll = allTables.Select("[Table Name]='" + tableNameSource + "' AND Schema='" + Cmb_DestSchema.Text.ToString() + "' ");
                if (roInAll.Length > 0)
                {
                    grdview_Destination.SetRowCellValue(roNum, "DestTable Status", "Exist");
                    grdview_Destination.SetRowCellValue(roNum, "DestTable Schema", roInAll[0]["Schema"].ToString());
                    grdview_Destination.SetRowCellValue(roNum, "DestTable Rows", roInAll[0]["Rowcount"].ToString());
                }
            }
        }
        private void CmbRep_DestSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowHandle = grdview_Destination.FocusedRowHandle;
            // check if the Table Exist
            string servername = Cmb_ToServer.Text.ToString();
            string destDbname = Cmb_ToDb.Text.ToString();
            string schemaDest = "", tableNameSource = "";
            Cls_ReadFromDb readTables = new Cls_ReadFromDb(servername, destDbname, "");
            DataTable allTables = readTables.GetTables();
            DevExpress.XtraEditors.ComboBoxEdit cbo = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            schemaDest = cbo.Text.ToString();
            tableNameSource = grdview_Destination.GetRowCellValue(rowHandle, "Source Table").ToString();
            DataRow[] roInAll = allTables.Select("[Table Name]='" + tableNameSource + "' AND Schema='" + schemaDest + "' ");
            if (roInAll.Length > 0)
            {
                grdview_Destination.SetRowCellValue(rowHandle, "DestTable Status", "Exist");
                grdview_Destination.SetRowCellValue(rowHandle, "DestTable Rows", roInAll[0]["Rowcount"].ToString());
            }
            else
            {
                grdview_Destination.SetRowCellValue(rowHandle, "DestTable Status", "New");
                grdview_Destination.SetRowCellValue(rowHandle, "DestTable Rows", "0");
            }
        }
        private void Grdview_Destination_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (Cmb_FromKind.Text.ToString() == "Table")
                {
                    // Coloring Rows (New)
                    if (view.GetRowCellValue(e.RowHandle, "DestTable Status").ToString() == "New")
                        e.Appearance.BackColor = Color.LawnGreen;
                }
            }
        }
        #endregion **************    Wizard_DestinationPage   *********

        #region ******** Wizard Transfer **********
        private void WizardPage3_PageCommit(object sender, EventArgs e)
        {
            string kind = Cmb_FromKind.Text.ToString();
            lbl_fromServer.Text = Cmb_FromServer.Text.ToString();
            lbl_fromdataBase.Text = Cmb_FromDb.Text.ToString();
            lbl_toServer.Text = Cmb_ToServer.Text.ToString();
            lbl_todataBase.Text = Cmb_ToDb.Text.ToString();
            switch (kind)
            {
                case "Table":
                    Cls_Build_DataTables buildTable = new Cls_Build_DataTables();
                    DataTable dtb_Transfer = buildTable.Build_TransferTables_DataTable();
                    if (dtb_Transfer == null || dtb_Transfer.Columns.Count == 0) return;
                    for (int roNum = 0; roNum < grdview_Destination.RowCount; roNum++)
                    {
                        DataRow destRo = dtb_Transfer.NewRow();
                        destRo["Source Schema"] = grdview_Destination.GetRowCellValue(roNum, "Source Schema").ToString();
                        destRo["Source Table"] = grdview_Destination.GetRowCellValue(roNum, "Source Table").ToString();
                        destRo["SourceTable Rows"] = grdview_Destination.GetRowCellValue(roNum, "SourceTable Rows").ToString();
                        destRo["DestTable Schema"] = grdview_Destination.GetRowCellValue(roNum, "DestTable Schema").ToString();
                        destRo["Destination Table"] = grdview_Destination.GetRowCellValue(roNum, "Destination Table").ToString();
                        destRo["DestTable Status"] = grdview_Destination.GetRowCellValue(roNum, "DestTable Status").ToString();
                        destRo["DestTable Rows"] = grdview_Destination.GetRowCellValue(roNum, "DestTable Rows").ToString();
                        dtb_Transfer.Rows.Add(destRo);
                    }
                    cntrl_Transfer.DataSource = dtb_Transfer;
                    grdview_Transfer.Columns["Transfer Status"].Visible = false;
                    grdview_Transfer.Columns["Transfer Status"].OptionsColumn.ShowInCustomizationForm = false;
                    lbl_transfer_rowsCount.Text = dtb_Transfer.Rows.Count.ToString();
                    break;
                case "View":
                case "Procedure":
                case "Function":
                    Cls_Build_DataTables buildObjectsDataTable = new Cls_Build_DataTables();
                    DataTable dtb_TransferObjects = buildObjectsDataTable.Build_TransferObjects_DataTable();
                    if (dtb_TransferObjects == null || dtb_TransferObjects.Columns.Count == 0) return;
                    for (int roNum = 0; roNum < grdview_Destination.RowCount; roNum++)
                    {
                        DataRow destRo = dtb_TransferObjects.NewRow();
                        destRo["Source Schema"] = grdview_Destination.GetRowCellValue(roNum, "Source Schema").ToString();
                        destRo["object Name"] = grdview_Destination.GetRowCellValue(roNum, "object Name").ToString();
                        destRo["object Type"] = grdview_Destination.GetRowCellValue(roNum, "object Type").ToString();
                        destRo["object Script"] = grdview_Destination.GetRowCellValue(roNum, "object Script").ToString();
                        dtb_TransferObjects.Rows.Add(destRo);
                    }
                    cntrl_Transfer.DataSource = dtb_TransferObjects;
                    grdview_Transfer.Columns["Transfer Status"].Visible = false;
                    grdview_Transfer.Columns["Transfer Status"].OptionsColumn.ShowInCustomizationForm = false;
                    lbl_transfer_rowsCount.Text = dtb_TransferObjects.Rows.Count.ToString();
                    break;
                default:
                    break;
            }
        }
        private void Grdview_Transfer_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Transfering Steps")
            {
                rps_ProgressBar_step.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
                rps_ProgressBar_step.ShowTitle = true;
                rps_ProgressBar_step.PercentView = false;
                rps_ProgressBar_step.Minimum = 0;
                rps_ProgressBar_step.Maximum = 4;
                e.RepositoryItem = rps_ProgressBar_step;
            }
        }
        private void Rps_ProgressBar_step_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                int ro = grdview_Transfer.FocusedRowHandle;
                if (ro >= 0 && Cmb_FromKind.Text.ToString() == "Table")
                {
                    switch (grdview_Transfer.GetRowCellValue(ro, "Transfering Steps").ToString())
                    {
                        case "0":
                            if (e.DisplayText != "") e.DisplayText = "";
                            break;
                        case "1":
                            if (e.DisplayText != "") e.DisplayText = "Step (" + e.Value + "/3)  Build Source DataTable. ";
                            break;
                        case "2":
                            if (e.DisplayText != "") e.DisplayText = "Step (" + e.Value + "/3)  Check destination Table.";
                            break;
                        case "3":
                            if (e.DisplayText != "") e.DisplayText = "Step (" + e.Value + "/3)  Save destination Data. ";
                            break;
                    }
                }
                else
                {
                    e.DisplayText = "";
                }
            }
        }
        private void Grdview_Transfer_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                // Coloring Rows (Done)
                if (view.GetRowCellValue(e.RowHandle, "Transfer Status").ToString() == "Done")
                    e.Appearance.BackColor = Color.LawnGreen;
                // Coloring Rows (NotCompleteData) = before transfer
                if (view.GetRowCellValue(e.RowHandle, "Transfer Status").ToString() == "NotCompleteData")
                    e.Appearance.BackColor = Color.PaleVioletRed;
                // Coloring Rows (Error)
                if (view.GetRowCellValue(e.RowHandle, "Transfer Status").ToString() == "Error")
                    e.Appearance.BackColor = Color.OrangeRed;
                // Coloring Rows (Transferd Before)
                if (view.GetRowCellValue(e.RowHandle, "Transfer Status").ToString() == "Transferd Before")
                    e.Appearance.BackColor = Color.BlueViolet;
            }
        }

        private void Btn_doTransfer_Click(object sender, EventArgs e)
        {
            string _source_Server = lbl_fromServer.Text.ToString();
            string _source_Db = lbl_fromdataBase.Text.ToString();
            string _source_Schema = Cmb_FromSchema.Text.ToString();
            string _dest_Server = lbl_toServer.Text.ToString();
            string _dest_Db = lbl_todataBase.Text.ToString();
            string _dest_Schema = Cmb_DestSchema.Text.ToString();
            string kind = Cmb_FromKind.Text.ToString();

            int total_trns = 0;
            int success_trns = 0;
            int error_trns = 0;
            int notComplete_trns = 0;
            int before_trns = 0;

            string _error_items = " - ";
            string _notComplete_items = " - ";
            string _transferBefore_items = " - ";

            if (string.IsNullOrEmpty(_source_Server) || string.IsNullOrEmpty(_source_Db))
            {
                MessageBox.Show("(From Server) or (From Database) failed ... ");
                return;
            }
            if (string.IsNullOrEmpty(_dest_Server) || string.IsNullOrEmpty(_dest_Db))
            {
                MessageBox.Show("(To Server) or (To Database) failed ... ");
                return;
            }
            // 1- Create Archiv Tables
            Cls_CreateArchivTables CreatArchivTable = new Cls_CreateArchivTables();
            string archivRslt = CreatArchivTable.Create_ArchivResult_Table(lbl_toServer.Text, lbl_todataBase.Text);
            // 2- Transfer
            if (archivRslt == "Done") // ArchivTable Created Successfully oder is Exist
            {
                switch (kind)
                {
                    case "Table":
                        for (int i = 0; i < grdview_Transfer.RowCount; i++)
                        {
                            if (grdview_Transfer.GetRowCellValue(i, "DestTable Status").ToString() == "New")
                            {
                                grdview_Transfer.FocusedRowHandle = i;
                                Do_TransferTables(i);
                                // Mail parameteres.....
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "Done")
                                {
                                    success_trns += 1;
                                }
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "Error")
                                {
                                    error_trns += 1;
                                    _error_items = _error_items + "\r\n" + grdview_Transfer.GetRowCellValue(i, "Source Table").ToString();
                                }
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "NotCompleteData")
                                {
                                    notComplete_trns += 1;
                                    _notComplete_items = _notComplete_items + "\r\n" + grdview_Transfer.GetRowCellValue(i, "Source Table").ToString();
                                }
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "Transferd Before")
                                {
                                    before_trns += 1;
                                    _transferBefore_items = _transferBefore_items + "\r\n" + grdview_Transfer.GetRowCellValue(i, "Source Table").ToString();
                                }
                                total_trns += 1;
                            }
                        }
                        break;
                    case "View":
                    case "Procedure":
                    case "Function":
                        // Create Script Table
                        Cls_CreateArchivTables CreatArchivScriptTable = new Cls_CreateArchivTables();
                        string scriptTableRslt = CreatArchivScriptTable.Create_ArchivScript_Table(lbl_toServer.Text, lbl_todataBase.Text);

                        if (scriptTableRslt == "Done") // ArchivScrips Table is exist
                        {
                            for (int i = 0; i < grdview_Transfer.RowCount; i++)
                            {
                                //if (grdview_Transfer.GetRowCellValue(i, "DestTable Status").ToString() == "New")
                                //{
                                grdview_Transfer.FocusedRowHandle = i;
                                Do_TransferObjects(i);
                                // Mail parameteres.....
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "Done")
                                {
                                    success_trns += 1;
                                }
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "Error")
                                {
                                    error_trns += 1;
                                    _error_items = _error_items + "\r\n" + grdview_Transfer.GetRowCellValue(i, "object Name").ToString();
                                }
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "NotCompleteData")
                                {
                                    notComplete_trns += 1;
                                    _notComplete_items = _notComplete_items + "\r\n" + grdview_Transfer.GetRowCellValue(i, "object Name").ToString();
                                }
                                if (grdview_Transfer.GetRowCellValue(i, "Transfer Status").ToString() == "Transferd Before")
                                {
                                    before_trns += 1;
                                    _transferBefore_items = _transferBefore_items + "\r\n" + grdview_Transfer.GetRowCellValue(i, "object Name").ToString();
                                }
                                total_trns += 1;
                                //}
                            }
                        }
                        break;
                }

                string mailBody = @"From Server: " + _source_Server +
                "   From DB: " + _source_Db +
                "   From Schema: " + _source_Schema + "\r\n" +
                "To Server:   " + _dest_Server +
                "   To Db: " + _dest_Db +
                "   To Schema: " + _dest_Db + "\r\n" +
                "Object Type: " + kind + "\r\n" +
                "Total trn.: " + total_trns.ToString() + "\r\n" +
                "Success trn.: " + success_trns.ToString() + "\r\n" +
                "Error trn.: " + error_trns.ToString() + _error_items + "\r\n" +
                "NotCompleted Data: " + notComplete_trns.ToString() + _notComplete_items + "\r\n" +
                "Transfered Before: " + before_trns.ToString() + _transferBefore_items + "\r\n";
                Cls_SendEmail clsSendMail = new Cls_SendEmail();
                bool ifSendet = clsSendMail.SendMail(mailBody);

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(Application.StartupPath + @"\log\" + "mailsLog.txt", true))
                {
                    file.WriteLine("Report vom: " + DateTime.Now.ToString() + "\r\n" + mailBody + " SendMail Status: " + ifSendet.ToString() + "\r\n");
                }
            }
            else // Error by creating ArchivTable 
            {
                MessageBox.Show(archivRslt);
            }
        }
        private void Do_TransferTables(int gridRo)
        {
            string _source_Server = lbl_fromServer.Text;
            string _source_Db = lbl_fromdataBase.Text;
            string _source_Schema = grdview_Transfer.GetRowCellValue(gridRo, "Source Schema").ToString();
            string _source_Table = grdview_Transfer.GetRowCellValue(gridRo, "Source Table").ToString();

            string _dest_Server = lbl_toServer.Text;
            string _dest_Db = lbl_todataBase.Text;
            string _dest_Schema = grdview_Transfer.GetRowCellValue(gridRo, "DestTable Schema").ToString();
            string _dest_Table = grdview_Transfer.GetRowCellValue(gridRo, "Destination Table").ToString();
            string result_msg = "";
            // check Source Parameters ....
            if (string.IsNullOrEmpty(_source_Server) || string.IsNullOrEmpty(_source_Db) || string.IsNullOrEmpty(_source_Schema) || string.IsNullOrEmpty(_source_Table))
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", " Source-Parameteres Not Found in Row No.: " + gridRo.ToString());
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "NotCompleteData");
                MessageBox.Show(" Source Parameteres Not Found in Row No.: " + gridRo.ToString());
                return;
            }
            // check Destination Parameters ....
            if (string.IsNullOrEmpty(_dest_Server) || string.IsNullOrEmpty(_dest_Db) || string.IsNullOrEmpty(_dest_Schema) || string.IsNullOrEmpty(_dest_Table))
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", " Destinition-Parameteres Not Found in Row No.: " + gridRo.ToString());
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "NotCompleteData");
                MessageBox.Show(" Destinition Parameteres Not Found in Row No.: " + gridRo.ToString());
                return;
            }
            // check if Transferd Before ....
            string src_schema = grdview_Transfer.GetRowCellValue(gridRo, "Source Schema").ToString();
            string src_table = grdview_Transfer.GetRowCellValue(gridRo, "Source Table").ToString();
            string dest_schema = grdview_Transfer.GetRowCellValue(gridRo, "DestTable Schema").ToString();
            string dest_table = grdview_Transfer.GetRowCellValue(gridRo, "Destination Table").ToString();
            string idTransferd = IfTransferdBefore(src_schema, src_table, dest_schema, dest_table, "Table");
            if (idTransferd != "Not Transferd Before")
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Steps", idTransferd);
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", idTransferd);
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "Transferd Before");
                return;
            }

            // Begin Transfer Proccess 
            string TranResult = "";
            DateTime strt = DateTime.Now;
            grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 0);
            Application.DoEvents();
            DataTable source_Dt = new DataTable();
            Cls_TransferTables transfer_cls = new Cls_TransferTables(_source_Server, _source_Db, _source_Schema, _source_Table, _dest_Server, _dest_Db, _dest_Schema, _dest_Table, "New");
            //try
            //{
            grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 1);
            Application.DoEvents();
            //Step 1 : Build Source DataTable
            result_msg = transfer_cls.Fill_Source_DataTable();
            TranResult = "Step1: " + result_msg;
            grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", TranResult);
            grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 2);
            Application.DoEvents();
            if (result_msg == "Done")
            {
                //Step 2: Check Destination Table, when not exist => create it
                result_msg = transfer_cls.Create_Table();
                TranResult = TranResult + ", Step2: " + result_msg;
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", TranResult);
                grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 3);
                Application.DoEvents();
                if (result_msg == "Done")
                {
                    //Step 3 : Save Destination Data.
                    result_msg = transfer_cls.Save_Dest_data();
                    grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", "Transfer Done");
                    Application.DoEvents();
                    TranResult = TranResult + ", Step3: " + result_msg;
                    grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", TranResult);
                    grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "Done");
                }
            }
            Application.DoEvents();

            //}
            //catch (Exception ex)
            //{
            //    grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", "Error: " + ex.Message);
            //    grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "Error");
            //    throw ex;
            //}
            DateTime endt = DateTime.Now;
            var time_def = endt - strt;
            SaveTableTransfer_To_ArchivResult(gridRo, time_def.ToString());
        }
        private void Do_TransferObjects(int gridRo)
        {
            string _source_Server = lbl_fromServer.Text;
            string _source_Db = lbl_fromdataBase.Text;
            string _dest_Server = lbl_toServer.Text;
            string _dest_Db = lbl_todataBase.Text;

            string _source_Schema = grdview_Transfer.GetRowCellValue(gridRo, "Source Schema").ToString();
            string _object_Type = grdview_Transfer.GetRowCellValue(gridRo, "object Type").ToString();
            string _object_Name = grdview_Transfer.GetRowCellValue(gridRo, "object Name").ToString();
            string _object_Script = grdview_Transfer.GetRowCellValue(gridRo, "object Script").ToString();
            grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 0);

            string result_msg = "";
            // check Parameters ....
            if (string.IsNullOrEmpty(_source_Server) || string.IsNullOrEmpty(_source_Db) || string.IsNullOrEmpty(_source_Schema) || string.IsNullOrEmpty(_source_Schema) || string.IsNullOrEmpty(_object_Name) || string.IsNullOrEmpty(_object_Script))
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", " Source-Parameteres Not Found in Row No.: " + gridRo.ToString());
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "NotCompleteData");
                MessageBox.Show(" Source Parameteres Not Found in Row No.: " + gridRo.ToString());
                return;
            }
            // check Destination Parameters ....
            if (string.IsNullOrEmpty(_dest_Server) || string.IsNullOrEmpty(_dest_Db) || string.IsNullOrEmpty(_object_Type))
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", " Destinition-Parameteres Not Found in Row No.: " + gridRo.ToString());
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "NotCompleteData");
                MessageBox.Show(" Destinition Parameteres Not Found in Row No.: " + gridRo.ToString());
                return;
            }
            // check if Transferd Before ....
            string idTransferd = IfTransferdBefore(_source_Schema, _object_Name, "", _object_Name, _object_Type);
            if (idTransferd != "Not Transferd Before")
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Steps", idTransferd);
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", idTransferd);
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "Transferd Before");
                return;
            }

            // Begin Transfer Proccess 
            DateTime strt = DateTime.Now;
            grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 1);
            Application.DoEvents();
            Cls_TransferObjects transfer_cls = new Cls_TransferObjects(_source_Server, _source_Db, _dest_Server, _dest_Db, _source_Schema, _object_Type, _object_Name, _object_Script);
            //try
            //{
            grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", 4);
            ////////Save ObjectScript.
            result_msg = transfer_cls.save_objects();
            Application.DoEvents();
            if (result_msg == "Done")
            {
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Result", result_msg);
                grdview_Transfer.SetRowCellValue(gridRo, "Transfer Status", "Done");
                grdview_Transfer.SetRowCellValue(gridRo, "Transfering Steps", "Transfer Done");
                Application.DoEvents();
            }
            Application.DoEvents();
            DateTime endt = DateTime.Now;
            var time_def = endt - strt;




            SaveObject_To_ArchivResult(gridRo, Cmb_FromKind.Text.ToString(), time_def.ToString());
        }

        private string IfTransferdBefore(string src_schema, string src_table, string dest_schema, string dest_table, string objecttype)
        {
            string connString = "Data Source=" + lbl_toServer.Text + "; Integrated Security=True;Initial Catalog= " + lbl_todataBase.Text + ";Connection Timeout=0";
            string result = "Not Transferd Before";
            string commandStr = @"If exists(select name from sys.objects where name = 'ArchivResult') 
SELECT * FROM ArchivResult WHERE src_server=@src_server 
AND src_db=@src_db 
AND src_schema=@src_schema 
AND src_objectName=@src_objectName 
AND dst_server=@dst_server 
AND dst_db=@dst_db 
AND dst_schema=@dst_schema 
AND dst_objectName=@dst_objectName 
AND object_Type=@objType  
AND trsf_status='Done'";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(commandStr, con)
                {
                    CommandTimeout = 0
                };
                cmd.Parameters.AddWithValue("@src_server", lbl_fromServer.Text);
                cmd.Parameters.AddWithValue("@src_db", lbl_fromdataBase.Text);
                cmd.Parameters.AddWithValue("@src_schema", src_schema);
                cmd.Parameters.AddWithValue("@src_objectName", src_table);
                cmd.Parameters.AddWithValue("@dst_server", lbl_toServer.Text);
                cmd.Parameters.AddWithValue("@dst_db", lbl_todataBase.Text);
                cmd.Parameters.AddWithValue("@dst_schema", dest_schema);
                cmd.Parameters.AddWithValue("@dst_objectName", dest_table);
                cmd.Parameters.AddWithValue("@objType", objecttype);
                using (SqlDataAdapter adptr = new SqlDataAdapter(cmd))
                {
                    adptr.Fill(dt);
                }
            }
            if (dt.Rows.Count > 0)
            {
                int lastro = dt.Rows.Count - 1;
                result = "Transferd Before by: " + dt.Rows[lastro]["trsf_user"].ToString() + " at:" + dt.Rows[lastro]["trsf_time"].ToString();
            }
            return result;
        }
        private void SaveTableTransfer_To_ArchivResult(int gridro, string period)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string connString = "Data Source=" + lbl_toServer.Text + "; Integrated Security=True;Initial Catalog= " + lbl_todataBase.Text + ";Connection Timeout=0";
            string dest_RowsCount = "";
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string dest_schema = grdview_Transfer.GetRowCellValue(gridro, "DestTable Schema").ToString();
                    string dest_table = grdview_Transfer.GetRowCellValue(gridro, "Destination Table").ToString();
                    SqlCommand count_cmd = new SqlCommand("SELECT COUNT(*) FROM " + dest_schema + "." + dest_table, con);
                    dest_RowsCount = count_cmd.ExecuteScalar().ToString();
                    count_cmd.CommandTimeout = 0;
                    SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "ArchivResult(src_server,src_db, src_schema,src_objectName,src_rowsCount,dst_server,dst_db,dst_schema,dst_objectName,dst_rowsCount,object_Type,trsf_status,trsf_result,trsf_time,trsf_user,trsf_period ) " +
                    " VALUES (@src_server,@src_db,@src_schema,@src_objectName,@src_rowsCount,@dst_server,@dst_db,@dst_schema,@dst_objectName,@dst_rowsCount,@object_Type,@trsf_status,@trsf_result,@trsf_time,@trsf_user,@trsf_period)", con);
                    cmd.Parameters.AddWithValue("@src_server", lbl_fromServer.Text);
                    cmd.Parameters.AddWithValue("@src_db", lbl_fromdataBase.Text);
                    cmd.Parameters.AddWithValue("@src_schema", grdview_Transfer.GetRowCellValue(gridro, "Source Schema").ToString());
                    cmd.Parameters.AddWithValue("@src_objectName", grdview_Transfer.GetRowCellValue(gridro, "Source Table").ToString());
                    cmd.Parameters.AddWithValue("@src_rowsCount", grdview_Transfer.GetRowCellValue(gridro, "SourceTable Rows").ToString());
                    cmd.Parameters.AddWithValue("@dst_server", lbl_toServer.Text);
                    cmd.Parameters.AddWithValue("@dst_db", lbl_todataBase.Text);
                    cmd.Parameters.AddWithValue("@dst_schema", grdview_Transfer.GetRowCellValue(gridro, "DestTable Schema").ToString());
                    cmd.Parameters.AddWithValue("@dst_objectName", grdview_Transfer.GetRowCellValue(gridro, "Destination Table").ToString());
                    cmd.Parameters.AddWithValue("@dst_rowsCount", dest_RowsCount);
                    cmd.Parameters.AddWithValue("@object_Type", "Table");
                    cmd.Parameters.AddWithValue("@trsf_status", grdview_Transfer.GetRowCellValue(gridro, "Transfer Status").ToString()); // = Error Or Done
                    cmd.Parameters.AddWithValue("@trsf_result", grdview_Transfer.GetRowCellValue(gridro, "Transfer Result").ToString()); // = Steps.... Error details :::
                    cmd.Parameters.AddWithValue("@trsf_time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@trsf_user", userName);
                    cmd.Parameters.AddWithValue("@trsf_period", period);
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SaveObject_To_ArchivResult(int gridro, string objType, string period)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string connString = "Data Source=" + lbl_toServer.Text + "; Integrated Security=True;Initial Catalog= " + lbl_todataBase.Text + ";Connection Timeout=0";
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "ArchivResult(src_server,src_db, src_schema,src_objectName,src_rowsCount,dst_server,dst_db,dst_schema,dst_objectName,dst_rowsCount,object_Type,trsf_status,trsf_result,trsf_time,trsf_user,trsf_period ) " +
                    "     VALUES (@src_server,@src_db,@src_schema,@src_objectName,@src_rowsCount,@dst_server,@dst_db,@dst_schema,@dst_objectName,@dst_rowsCount,@object_Type,@trsf_status,@trsf_result,@trsf_time,@trsf_user,@trsf_period)", con);
                    cmd.Parameters.AddWithValue("@src_server", lbl_fromServer.Text);
                    cmd.Parameters.AddWithValue("@src_db", lbl_fromdataBase.Text);
                    cmd.Parameters.AddWithValue("@src_schema", grdview_Transfer.GetRowCellValue(gridro, "Source Schema").ToString());
                    cmd.Parameters.AddWithValue("@src_objectName", grdview_Transfer.GetRowCellValue(gridro, "object Name").ToString());
                    cmd.Parameters.AddWithValue("@src_rowsCount", "1");
                    cmd.Parameters.AddWithValue("@dst_server", lbl_toServer.Text);
                    cmd.Parameters.AddWithValue("@dst_db", lbl_todataBase.Text);
                    cmd.Parameters.AddWithValue("@dst_schema", "");
                    cmd.Parameters.AddWithValue("@dst_objectName", grdview_Transfer.GetRowCellValue(gridro, "object Name").ToString());
                    cmd.Parameters.AddWithValue("@dst_rowsCount", "1");
                    cmd.Parameters.AddWithValue("@object_Type", objType);
                    cmd.Parameters.AddWithValue("@trsf_status", grdview_Transfer.GetRowCellValue(gridro, "Transfer Status").ToString()); // = Error Or Done
                    cmd.Parameters.AddWithValue("@trsf_result", grdview_Transfer.GetRowCellValue(gridro, "Transfer Result").ToString()); // = Steps.... Error details :::
                    cmd.Parameters.AddWithValue("@trsf_time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@trsf_user", userName);
                    cmd.Parameters.AddWithValue("@trsf_period", period);
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion ********** Wizard Transfer **********

    }
}