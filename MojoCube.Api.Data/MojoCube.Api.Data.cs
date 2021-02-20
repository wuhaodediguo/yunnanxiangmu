using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System;

namespace MojoCube.Api.Data
{
    public class Convert
    {
        public static DataSet ToDataSet(DataTable dt)
        {
            DataSet dataSet = new DataSet();
            DataTable table = dt.Copy();
            dataSet.Tables.Add(table);
            return dataSet;
        }
    }


    public class OledbHelper
    {
        private string _strconn;

        public OledbHelper(string strconn)
        {
            this._strconn = strconn;
        }

        public T ExecuteScalar<T>(string sql, params object[] args)
        {
            T result;
            using (OleDbConnection oleDbConnection = new OleDbConnection(this._strconn))
            {
                result = (T)((object)this.MakeCommand(oleDbConnection, sql, args).ExecuteScalar());
            }
            return result;
        }

        public void ExecuteNonQuery(string sql, params object[] args)
        {
            using (OleDbConnection oleDbConnection = new OleDbConnection(this._strconn))
            {
                this.MakeCommand(oleDbConnection, sql, args).ExecuteNonQuery();
            }
        }

        public IDataReader ExecuteReader(string sql, params object[] args)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(this._strconn);
            IDataReader result;
            try
            {
                OleDbCommand oleDbCommand = this.MakeCommand(oleDbConnection, sql, args);
                result = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                oleDbConnection.Close();
                throw;
            }
            return result;
        }

        public OleDbCommand MakeCommand(OleDbConnection conn, string sql, params object[] args)
        {
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            for (int i = 0; i < args.Length; i++)
            {
                oleDbCommand.Parameters.AddWithValue(i.ToString(), args[i]);
            }
            return oleDbCommand;
        }
    }


    public class Sql
    {
        private string _Connect;

        private string _Server;

        private string _UserID;

        private string _Password;

        private string _Database;

        private string _Error;

        public string Connect
        {
            get
            {
                return this._Connect;
            }
            set
            {
                this._Connect = value;
            }
        }

        public string Server
        {
            get
            {
                return this._Server;
            }
            set
            {
                this._Server = value;
            }
        }

        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }
        }

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        public string Database
        {
            get
            {
                return this._Database;
            }
            set
            {
                this._Database = value;
            }
        }

        public string Error
        {
            get
            {
                return this._Error;
            }
            set
            {
                this._Error = value;
            }
        }

        public void GetInfo(string conn)
        {
            this._Server = this.cut(conn, "server=", ";");
            this._UserID = this.cut(conn, "user id=", ";");
            this._Password = this.cut(conn, "password=", ";");
            this._Database = this.cut(conn, "database=", ";");
        }

        public string cut(string str, string bg, string ed)
        {
            string text = str.Substring(str.IndexOf(bg) + bg.Length);
            return text.Substring(0, text.IndexOf(";"));
        }

        public void CreateDB()
        {
            SqlConnection connection = new SqlConnection(this._Connect);
            SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE [" + this._Database + "] COLLATE Chinese_PRC_CI_AS;", connection);
            try
            {
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this._Error = ex.Message;
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
        }

        public bool BackupDB(string backupPath)
        {
            string str = this._Database + DateTime.Now.ToString("yyyyMMddHHmmss");
            SqlConnection sqlConnection = new SqlConnection(this._Connect);
            sqlConnection.Open();
            string cmdText = "sp_dropdevice";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter = sqlCommand.Parameters.Add("@logicalname", SqlDbType.VarChar, 20);
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameter.Value = this._Database;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this._Error = ex.Message;
            }
            cmdText = "sp_addumpdevice";
            SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlParameter = sqlCommand2.Parameters.Add("@devtype", SqlDbType.VarChar, 20);
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameter.Value = "disk";
            sqlParameter = sqlCommand2.Parameters.Add("@logicalname", SqlDbType.VarChar, 20);
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameter.Value = this._Database;
            sqlParameter = sqlCommand2.Parameters.Add("@physicalname", SqlDbType.NVarChar, 260);
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameter.Value = backupPath + str + ".bak";
            try
            {
                int num = sqlCommand2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this._Error = ex.Message;
            }
            string cmdText2 = string.Concat(new string[]
			{
				"BACKUP DATABASE ",
				this._Database,
				" TO ",
				this._Database,
				" WITH INIT"
			});
            SqlCommand sqlCommand3 = new SqlCommand(cmdText2, sqlConnection);
            sqlCommand3.CommandType = CommandType.Text;
            bool result;
            try
            {
                sqlCommand3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this._Error = ex.Message;
                result = false;
                return result;
            }
            finally
            {
                sqlConnection.Close();
            }
            result = true;
            return result;
        }

        public bool RestoreDB(string filePath)
        {
            SqlConnection sqlConnection = new SqlConnection(this._Connect);
            string cmdText = string.Format("use master ;declare @s varchar(8000);select @s=isnull(@s,'')+' kill '+rtrim(spID) from master..sysprocesses where dbid=db_id('{0}');select @s;exec(@s) ;RESTORE DATABASE {1} FROM DISK = N'{2}' with replace", this._Database, this._Database, filePath);
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            bool result;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                this._Error = ex.Message;
                result = false;
                return result;
            }
            finally
            {
                sqlConnection.Close();
            }
            result = true;
            return result;
        }
    }

   
}
