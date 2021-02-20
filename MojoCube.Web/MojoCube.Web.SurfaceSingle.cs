using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace MojoCube.Web.SurfaceSingle
{
    public class SurfaceSingle
    {
        public Int32 id { set; get; }
        public string StartNo { set; get; }
        public string EndNo { set; get; }
        public string Amount { set; get; }
        public string Customer { set; get; }
        public string Remark { set; get; }
        public DateTime CreateDate { set; get; }


        public string CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into SurfaceSingle([StartNo],[EndNo],[Amount],[Customer],[Remark],[CreateDate]) values
                (@StartNo,@EndNo,@Amount,@Customer,@Remark,@CreateDate)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@StartNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@StartNo"].Value = this.StartNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@EndNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@EndNo"].Value = this.EndNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Amount", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Amount"].Value = this.Amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Customer", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Customer"].Value = this.Customer;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this.CreateDate;

                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public int updateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"
                                update SurfaceSingle set StartNo=@StartNo,EndNo=@EndNo,
                                [Amount]=@Amount,Customer=@Customer,Remark=@Remark where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@StartNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@StartNo"].Value = this.StartNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@EndNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@EndNo"].Value = this.EndNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Amount", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Amount"].Value = this.Amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Customer", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Customer"].Value = this.Customer;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@id", OleDbType.Integer));
                oleDbCommand.Parameters["@id"].Value = this.id;
                result = oleDbCommand.ExecuteNonQuery();
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void DeleteDataById(int id)
        {
            Sql.SqlQuery("delete from SurfaceSingle where id=" + id);
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from SurfaceSingle where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.id = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.StartNo = oleDbDataReader["StartNo"].ToString();
                    this.EndNo = oleDbDataReader["EndNo"].ToString();
                    this.Amount = oleDbDataReader["Amount"].ToString();
                    this.Customer = oleDbDataReader["Customer"].ToString();
                    this.Remark = oleDbDataReader["Remark"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public DataTable GetData(string StartNo, string EndNo)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                DataTable dt = new DataTable();
                oleDbConnection.Open();
                OledbHelper oledbHelper = new OledbHelper();
                string cmdText = "select * from SurfaceSingle where (StartNo between Cdbl(?) and Cdbl(?) OR EndNo between Cdbl(?) and Cdbl(?))";
                dt = oledbHelper.GetDataTable(cmdText, new object[]
		        {
			        StartNo,EndNo,StartNo,EndNo
		        });
                return dt;
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

    }
}
