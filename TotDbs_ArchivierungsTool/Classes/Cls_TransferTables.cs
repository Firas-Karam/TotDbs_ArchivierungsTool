using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TotDbs_ArchivierungsTool.Classes
{
    class Cls_TransferTables
    {
        /// <summary>
        /// This Class to transfer Tables From Source to Destination throgh 3 Steps:
        /// 1' Step: Read the Table-Schemas from Source (Columns Name, Primarry Key, Columns DataType .....)
        /// 2' Step: Create (if Not Exist) the new Table in the Destination DataBase.
        /// 3' Step: Move the Data from the Source-Table in the New-Table in Destination-Databse using SqlBulkCopy technology.
        /// </summary>
        public string _source_Server { get; set; }
        public string _source_Db { get; set; }
        public string _source_Schema { get; set; }
        public string _source_Table { get; set; }
        public string _dest_Server { get; set; }
        public string _dest_Db { get; set; }
        public string _dest_Schema { get; set; }
        public string _dest_Table { get; set; }
        private List<string> computedColumns_Name = new List<string>();
        private DataTable destTable_schema = new DataTable();
        public Cls_TransferTables()
        {

        }
        public Cls_TransferTables(string source_Server, string source_Db, string source_Schema, string source_Table, string dest_Server, string dest_Db, string dest_Schema, string dest_Table, string status)
        {
            if (string.IsNullOrEmpty(source_Server) || string.IsNullOrEmpty(source_Db) || string.IsNullOrEmpty(dest_Server) || string.IsNullOrEmpty(dest_Db))
            {
                return;
            }
            if (string.IsNullOrEmpty(source_Schema) || string.IsNullOrEmpty(source_Table) || string.IsNullOrEmpty(dest_Schema) || string.IsNullOrEmpty(dest_Table))
            {
                return;
            }
            _source_Server = source_Server;
            _source_Db = source_Db;
            _source_Schema = source_Schema;
            _source_Table = source_Table;
            _dest_Server = dest_Server;
            _dest_Db = dest_Db;
            _dest_Schema = dest_Schema;
            _dest_Table = dest_Table;
        }
        #region ****** Transfer data Methods 3 Steps ******
        //Step 1 : Build Source DataTable-Schema
        public string Fill_Source_DataTable()
        {
            string _result = "No Change";
            //try
            //{
            string source_connString = "Data Source=" + _source_Server + "; Integrated Security=True;Initial Catalog= " + _source_Db + ";Connection Timeout=0";
            computedColumns_Name = new List<string>();
            // Fill Datatable from Source Table
            using (SqlConnection source_con = new SqlConnection(source_connString))
            {
                source_con.Open();
                SqlCommand command = source_con.CreateCommand();
                command.CommandText = "SELECT * FROM " + _source_Schema + "." + _source_Table + " WHERE 1=2 ";
                command.CommandTimeout = 0;
                SqlDataReader rdr = command.ExecuteReader();
                destTable_schema = rdr.GetSchemaTable();
                rdr.Close();
            }
            ////////}
            _result = "Done";
            //}
            //catch (Exception ex)
            //{
            //    _result = "Error Fill_Source_DataTable: " + ex.Message;
            //}
            return _result;
        }
        //Step 2: Check for Destination Table, when not exist  => create it
        public string Create_Table()
        {
            string _result = "No Change";
            string dest_connString = "Data Source=" + _dest_Server + "; Integrated Security=True;Initial Catalog= " + _dest_Db + ";Connection Timeout=0";
            using (SqlConnection dest_con = new SqlConnection(dest_connString))
            {
                string cols = "", colSize = "", primrKey = "";
                double number;
                foreach (DataRow ro in destTable_schema.Rows)
                {
                    switch (ro["DataTypeName"].ToString())
                    {
                        case "binary":
                        case "char":
                        case "nchar":
                        case "varchar":
                        case "nvarchar":
                        case "datetime2":
                        case "datetimeoffset":
                        case "time":
                        case "varbinary":
                            colSize = " (" + ro["ColumnSize"].ToString() + ") ";
                            bool isNumeric = double.TryParse(ro["ColumnSize"].ToString(), out number);
                            if (isNumeric == true)
                            {
                                if (number > 8000) colSize = " (Max) ";
                            }
                            break;
                        case "decimal":
                        case "numeric":
                            colSize = " (" + ro["NumericPrecision"].ToString() + "," + ro["NumericScale"].ToString() + ") ";
                            break;
                        default:
                            colSize = " ";
                            break;
                    }
                    if (ro["AllowDBNull"].ToString() == "True")
                    {
                        colSize += " NULL";
                    }
                    else
                    {
                        colSize += " NOT NULL";
                    }

                    if (ro["IsIdentity"].ToString() == "True")
                    {
                        primrKey = " CONSTRAINT[PK_" + _dest_Table + "] PRIMARY KEY CLUSTERED( [" + ro["ColumnName"].ToString() + "] ASC) ";
                    }
                    cols += " [" + ro["ColumnName"].ToString() + "]" + " [" + ro["DataTypeName"].ToString() + "]" + colSize + ", ";
                }
                string str = "If not exists (select name from sys.objects where name = '" + _dest_Table + "') CREATE TABLE " + _dest_Schema + "." + _dest_Table + " (" + cols + primrKey + ")";
                using (SqlCommand cmd = new SqlCommand(str, dest_con))
                {
                    cmd.CommandText = str;
                    dest_con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            _result = "Done";
            //try
            //{

            //}
            //catch (Exception)
            //{
            //    _result = "Error Create_Table: " + e.Message;
            //}

            return _result;
        }
        //Step 3 : Save Destination Data.
        public string Save_Dest_data()
        {
            string _result = "No Change";
            string dest_connString = "Data Source=" + _dest_Server + "; Integrated Security=True;Initial Catalog= " + _dest_Db + ";Connection Timeout=0";
            SqlDataReader rdr;
            string source_connString = "Data Source=" + _source_Server + "; Integrated Security=True;Initial Catalog= " + _source_Db + ";Connection Timeout=0";
            string dset_strs = "SELECT * FROM " + _source_Schema + "." + _source_Table;
            computedColumns_Name = new List<string>();
            using (SqlConnection source_con = new SqlConnection(source_connString))
            {
                source_con.Open();
                SqlCommand command = source_con.CreateCommand();
                command.CommandText = dset_strs;
                command.CommandTimeout = 0;
                rdr = command.ExecuteReader();
                using (SqlConnection dest_con = new SqlConnection(dest_connString))
                {
                    dest_con.Open();
                    SqlTransaction transaction = dest_con.BeginTransaction("Destinition_Transaction");
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(dest_connString, SqlBulkCopyOptions.TableLock))
                    {
                        bulkCopy.BulkCopyTimeout = 0; // infinity
                        bulkCopy.DestinationTableName = _dest_Schema + "." + _dest_Table;
                        bulkCopy.WriteToServer(rdr);
                    }
                    // Attempt to commit the transaction.
                    transaction.Commit();
                    _result = "Done";
                    //}
                    //}
                    //catch (Exception e)
                    //{
                    // transaction.Rollback();
                    //    _result = "Error Save_Dest_data Method: " + e.Message;
                    //}

                    transaction.Dispose();
                } // Use dest_con
                rdr.Close();
            }
            return _result;
        }
        #endregion  ****** Transfer data Methods ******
    }
}
