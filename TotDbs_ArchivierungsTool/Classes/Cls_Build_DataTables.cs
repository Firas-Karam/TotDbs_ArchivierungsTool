using System.Data;

namespace TotDbs_ArchivierungsTool.Classes
{
    class Cls_Build_DataTables
    {
        /// <summary>
        /// This Class Build DataTables for the Gridviews in the Wizard.
        /// </summary>
        /// <returns></returns>
        #region ***** Tables *****
        public DataTable Build_Tables()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Source Schema", typeof(string));
            dtbl.Columns.Add("Source Table", typeof(string));
            dtbl.Columns.Add("SourceTable Rows", typeof(string));
            dtbl.Columns.Add("DestTable Schema", typeof(string));
            dtbl.Columns.Add("Destination Table", typeof(string));
            dtbl.Columns.Add("DestTable Status", typeof(string));
            dtbl.Columns.Add("DestTable Rows", typeof(string));
            return dtbl;
        }
        public DataTable Build_TransferTables_DataTable()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Source Schema", typeof(string));
            dtbl.Columns.Add("Source Table", typeof(string));
            dtbl.Columns.Add("SourceTable Rows", typeof(string));
            dtbl.Columns.Add("DestTable Schema", typeof(string));
            dtbl.Columns.Add("Destination Table", typeof(string));
            dtbl.Columns.Add("DestTable Status", typeof(string));
            dtbl.Columns.Add("DestTable Rows", typeof(string));
            dtbl.Columns.Add("Transfering Steps", typeof(string));
            dtbl.Columns.Add("Transfer Status", typeof(string));
            dtbl.Columns.Add("Transfer Result", typeof(string));
            return dtbl;
        }
        #endregion ****** Tables ********
        #region ******* Objects *******
        public DataTable Build_datatable_Objects()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Source Schema", typeof(string));
            dtbl.Columns.Add("object Name", typeof(string));
            dtbl.Columns.Add("object Type", typeof(string));
            dtbl.Columns.Add("object Script", typeof(string));
            return dtbl;
        }
        public DataTable Build_TransferObjects_DataTable()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Source Schema", typeof(string));
            dtbl.Columns.Add("object Name", typeof(string));
            dtbl.Columns.Add("object Type", typeof(string));
            dtbl.Columns.Add("object Script", typeof(string));
            dtbl.Columns.Add("Transfering Steps", typeof(string));
            dtbl.Columns.Add("Transfer Status", typeof(string));
            dtbl.Columns.Add("Transfer Result", typeof(string));
            return dtbl;
        }
        #endregion ******* Objects *******
    }
}
