using System.Data;
using System.Data.SqlClient;

namespace TotDbs_ArchivierungsTool.Classes
{
    public class Cls_ReadFromDb
    {
        /// <summary>
        /// This Class to read the objects (Tables, Views, Stored Procedures, Functions) from the DataBase
        /// </summary>
        public string _servername { get; set; }
        public string _DbName { get; set; }
        public string _schema { get; set; }
        public Cls_ReadFromDb(string serverName, string DbName, string schema)
        {
            _servername = serverName;
            _DbName = DbName;
            _schema = schema;
        }
        public DataTable GetTables()
        {
            DataTable dtb_tables = new DataTable();
            if (string.IsNullOrEmpty(_servername) || string.IsNullOrEmpty(_DbName))
            {
                return dtb_tables;
            }
            string connectionString = "Data Source=" + _servername + "; Integrated Security=True;Initial Catalog= " + _DbName;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string condition = "";
                if (!string.IsNullOrEmpty(_schema))
                {
                    condition = " WHERE sc.name='" + _schema + "' ";
                }
                string str = @" SELECT sc.name AS[Schema], 
                    T.name AS[Table Name], 
                    I.rows AS[Rowcount],
                    T.create_date AS[Create Date],
                    T.modify_date AS[Modify Date]  
                    FROM sys.tables AS T INNER JOIN sys.sysindexes AS I ON T.object_id = I.id AND I.indid < 2 INNER JOIN sys.schemas sc ON T.schema_id = sc.schema_id "
                    + condition + " ORDER BY [Schema], I.rows DESC ";
                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandTimeout = 0;
                    using (SqlDataAdapter adptr = new SqlDataAdapter(cmd))
                    {
                        adptr.Fill(dtb_tables);
                    }
                }
            }
            return dtb_tables;
        }
        public DataTable GetViews()
        {
            DataTable dtb_tables = new DataTable();
            if (string.IsNullOrEmpty(_servername) || string.IsNullOrEmpty(_DbName))
            {
                return dtb_tables;
            }
            string connectionString = "Data Source=" + _servername + "; Integrated Security=True;Initial Catalog= " + _DbName;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string condition = "";
                if (!string.IsNullOrEmpty(_schema))
                {
                    condition = " WHERE TABLE_SCHEMA='" + _schema + "' ";
                }
                string str = @"select TABLE_CATALOG AS[Database], 
                    TABLE_SCHEMA AS[Schema],
                    TABLE_NAME AS[View Name],
                    VIEW_DEFINITION AS[View Script] 
                    from INFORMATION_SCHEMA.views " + condition + " ORDER BY TABLE_SCHEMA,TABLE_NAME ";
                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandTimeout = 0;
                    using (SqlDataAdapter adptr = new SqlDataAdapter(cmd))
                    {
                        adptr.Fill(dtb_tables);
                    }
                }
            }
            return dtb_tables;
        }
        public DataTable GetProcedures()
        {
            DataTable dtb_tables = new DataTable();
            if (string.IsNullOrEmpty(_servername) || string.IsNullOrEmpty(_DbName))
            {
                return dtb_tables;
            }
            string connectionString = "Data Source=" + _servername + "; Integrated Security=True;Initial Catalog= " + _DbName;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string condition = "";
                if (!string.IsNullOrEmpty(_schema))
                {
                    condition = " AND ROUTINE_SCHEMA='" + _schema + "' ";
                }
                string str = "select ROUTINE_CATALOG AS[Database], ROUTINE_SCHEMA AS[Schema], ROUTINE_NAME AS[Procedure Name], ROUTINE_DEFINITION AS[Procedure Script], CREATED AS[Create Date], LAST_ALTERED AS[Last Alter]  from INFORMATION_SCHEMA.routines WHERE ROUTINE_TYPE='PROCEDURE' " + condition + "  ORDER BY ROUTINE_SCHEMA,ROUTINE_NAME";
                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandTimeout = 0;
                    using (SqlDataAdapter adptr = new SqlDataAdapter(cmd))
                    {
                        adptr.Fill(dtb_tables);
                    }
                }
            }
            return dtb_tables;
        }
        public DataTable GetFunctions()
        {
            DataTable dtb_tables = new DataTable();
            if (string.IsNullOrEmpty(_servername) || string.IsNullOrEmpty(_DbName))
            {
                return dtb_tables;
            }
            string connectionString = "Data Source=" + _servername + "; Integrated Security=True;Initial Catalog= " + _DbName;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string condition = "";
                if (!string.IsNullOrEmpty(_schema))
                {
                    condition = " AND ROUTINE_SCHEMA='" + _schema + "' ";
                }
                string str = "select ROUTINE_CATALOG AS[Database], ROUTINE_SCHEMA AS[Schema], ROUTINE_NAME AS[Function Name], ROUTINE_DEFINITION AS[Function Script], CREATED AS[Create Date], LAST_ALTERED AS[Last Alter]  from INFORMATION_SCHEMA.routines WHERE ROUTINE_TYPE='FUNCTION' " + condition + "  ORDER BY ROUTINE_SCHEMA,ROUTINE_NAME";
                using (SqlCommand cmd = new SqlCommand(str, con))
                {
                    cmd.CommandTimeout = 0;
                    using (SqlDataAdapter adptr = new SqlDataAdapter(cmd))
                    {
                        adptr.Fill(dtb_tables);
                    }
                }
            }
            return dtb_tables;
        }
    }
}