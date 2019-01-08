using System.Data.SqlClient;

namespace TotDbs_ArchivierungsTool.Classes
{
    class Cls_TransferObjects
    {
        /// <summary>
        /// This Class transferd Objects(Views, Prosidures, Functions) from source to destination(ArchivScripts)
        /// </summary>
        public string _source_Server { get; set; }
        public string _source_Db { get; set; }
        public string _dest_Server { get; set; }
        public string _dest_Db { get; set; }

        public string _source_Schema { get; set; }
        public string _object_Type { get; set; }
        public string _object_Name { get; set; }
        public string _object_Script { get; set; }

        public string _result { get; set; }
        public Cls_TransferObjects()
        {

        }
        public Cls_TransferObjects(string source_Server, string source_Db, string dest_Server, string dest_Db, string source_Schema, string object_Type, string object_Name, string object_Script)
        {
            _result = "";
            if (string.IsNullOrEmpty(source_Server) || string.IsNullOrEmpty(source_Db) || string.IsNullOrEmpty(dest_Server) || string.IsNullOrEmpty(dest_Db))
            {
                return;
            }
            if (string.IsNullOrEmpty(source_Schema) || string.IsNullOrEmpty(object_Type) || string.IsNullOrEmpty(object_Name) || string.IsNullOrEmpty(object_Script))
            {
                return;
            }
            _source_Server = source_Server;
            _source_Db = source_Db;
            _dest_Server = dest_Server;
            _dest_Db = dest_Db;

            _source_Schema = source_Schema;
            _object_Type = object_Type;
            _object_Name = object_Name;
            _object_Script = object_Script;
        }
        public string save_objects()
        {
            _result = "No Change";
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string connString = "Data Source=" + _dest_Server + "; Integrated Security=True;Initial Catalog= " + _dest_Db + ";Connection Timeout=0";
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                "ArchivScript(src_server,src_db,src_schema,src_objectName,object_Type,object_Script) " +
                "     VALUES (@src_server,@src_db,@src_schema,@src_objectName,@object_Type,@object_Script)", con);
                cmd.Parameters.AddWithValue("@src_server", _source_Server);
                cmd.Parameters.AddWithValue("@src_db", _source_Db);
                cmd.Parameters.AddWithValue("@src_schema", _source_Schema);
                cmd.Parameters.AddWithValue("@src_objectName", _object_Name);
                cmd.Parameters.AddWithValue("@object_Type", _object_Type);
                cmd.Parameters.AddWithValue("@object_Script", "'" + _object_Script + "'");
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                _result = "Done";
            }
            return _result;
        }
    }
}
