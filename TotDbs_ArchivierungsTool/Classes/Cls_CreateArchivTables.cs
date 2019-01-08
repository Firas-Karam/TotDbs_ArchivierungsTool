using System;
using System.Data.SqlClient;

namespace TotDbs_ArchivierungsTool.Classes
{
    class Cls_CreateArchivTables
    {
        /// <summary>
        /// This Class Create Tow Tables in the destination database,
        /// ArchivResult: for the Transfer-Results
        /// ArchivScript: for the Scripts-Code (Views, Stored Procedures, Functions) from the source Databse.
        /// Note: Databse Objects meaning: Tables, Views;Stored Procedure,Functions ..
        /// </summary>
        public string _result { get; set; }
        public string Create_ArchivResult_Table(string server, string db)
        {
            _result = "No Change";
            string connString = "Data Source=" + server + "; Integrated Security=True;Initial Catalog= " + db + ";Connection Timeout=0";
            string commandStr = @"If not exists (select name from sys.objects where name = 'ArchivResult') 
                CREATE TABLE ArchivResult([id] [int] IDENTITY(1,1) NOT NULL,
                [src_server] [nvarchar] (50) NULL,
                [src_db] [nvarchar] (150) NULL,
                [src_schema] [nvarchar] (100) NULL,
                [src_objectName] [nvarchar] (300) NULL,
                [src_rowsCount] [nvarchar] (20) NULL,
                [dst_server] [nvarchar] (50) NULL,
                [dst_db] [nvarchar] (150) NULL,
                [dst_schema] [nvarchar] (100) NULL,
                [dst_objectName] [nvarchar] (300) NULL,
                [dst_rowsCount] [nvarchar] (20) NULL,
                [object_Type] [nvarchar] (10) NULL,
                [trsf_status] [nvarchar] (20) NULL,
                [trsf_result] [nvarchar] (Max) NULL,
                [trsf_time] datetime,
                [trsf_user] [nvarchar] (Max) NULL,
                [trsf_period] [nvarchar] (20) NULL,
                CONSTRAINT [PK_ArchivResult] PRIMARY KEY CLUSTERED 
                ([id] ASC)
                WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
                ON [PRIMARY])";
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(commandStr, con))
                    {
                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();
                        _result = "Done"; // = entweder Exist oder Neu
                    }
                }
            }
            catch (Exception ex)
            {
                _result = "Error: Creating (ArchivResult) Table" + ex.Message;
                throw ex;
            }
            return _result;
        }
        public string Create_ArchivScript_Table(string server, string db)
        {
            _result = "No Change";
            string connString = "Data Source=" + server + "; Integrated Security=True;Initial Catalog= " + db + ";Connection Timeout=0";
            string commandStr = @"If not exists (select name from sys.objects where name = 'ArchivScript') 
                CREATE TABLE ArchivScript([id] [int] IDENTITY(1,1) NOT NULL,
                [src_server] [nvarchar] (50) NULL,
                [src_db] [nvarchar] (150) NULL,
                [src_schema] [nvarchar] (100) NULL,
                [src_objectName] [nvarchar] (300) NULL,
                [object_Type] [nvarchar] (10) NULL,
                [object_Script] [nvarchar] (Max) NULL,
                CONSTRAINT [PK_ArchivScript] PRIMARY KEY CLUSTERED 
                ([id] ASC)
                WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
                ON [PRIMARY])";
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(commandStr, con))
                    {
                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();
                        _result = "Done"; // = entweder Exist oder Neu
                    }
                }
            }
            catch (Exception ex)
            {
                _result = "Error: Creating (ArchivScript) Table" + ex.Message;
                throw;
            }
            return _result;
        }
    }
}
