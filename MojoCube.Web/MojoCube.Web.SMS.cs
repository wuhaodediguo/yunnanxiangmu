using System;
using System.Data.OleDb;
using System.Web;
using System.Collections;
using System.Collections.Generic;

namespace MojoCube.Web.SMS
{

    public class SMSList
    {
        public string id { set; get; }
        public string PhoneNum { set; get; }
        public string LogisticsNo { set; get; }
        public string Status { set; get; }
        public DateTime CreateTime { set; get; }

        public string  CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into SMSRecords(PhoneNum,LogisticsNo,[Status],[CreateTime]) values
(@PhoneNum,@LogisticsNo,@Status,@CreateTime)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@PhoneNum", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@PhoneNum"].Value = this.PhoneNum;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogisticsNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@LogisticsNo"].Value = this.LogisticsNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Status", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Status"].Value = this.Status;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
              
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

//        public int updateData()
//        {
//            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
//            int result;
//            try
//            {
//                oleDbConnection.Open();
//                string cmdText = @"
//update Logistics set pk_Logistics=@pk_Logistics,TakeTime=@TakeTime,Information=@Information,[CreateTime]=@CreateTime
//where id=@id";
//                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
//                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Logistics", OleDbType.VarChar, 200));
//                oleDbCommand.Parameters["@pk_Logistics"].Value = this.pk_Logistics;
//                oleDbCommand.Parameters.Add(new OleDbParameter("@TakeTime", OleDbType.Date));
//                oleDbCommand.Parameters["@TakeTime"].Value = this.TakeTime;
//                oleDbCommand.Parameters.Add(new OleDbParameter("@Information", OleDbType.VarChar,200));
//                oleDbCommand.Parameters["@Information"].Value = this.Information;
//                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
//                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
//                oleDbCommand.Parameters.Add(new OleDbParameter("@id", OleDbType.VarChar, 200));
//                oleDbCommand.Parameters["@id"].Value = this.id;
//                result = oleDbCommand.ExecuteNonQuery();
//            }
//            catch
//            {
//                result = 0;
//            }
//            finally
//            {
//                oleDbConnection.Close();
//            }
//            return result;
//        }

//        public void DeleteDataById(int id)
//        {
//            Sql.SqlQuery("delete from Logistics where id=" + id);
//        }

        //public IList<LogisticsList> GetLogisticsList(string LogisticsNo)
        //{
        //    IList<LogisticsList> result = new List<LogisticsList>();


        //    OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
        //    try
        //    {
        //        oleDbConnection.Open();
        //        string cmdText = @"select * from Logistics where pk_Logistics=@pk_Logistics order by TakeTime desc";
        //        OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
        //        oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Logistics", OleDbType.VarChar, 200));
        //        oleDbCommand.Parameters["@pk_Logistics"].Value = LogisticsNo;
        //        OleDbDataReader dr = oleDbCommand.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            result.Add(new LogisticsList() { id = dr["id"].ToString(), pk_Logistics = dr["pk_Logistics"].ToString(), TakeTime = Convert.ToDateTime(dr["TakeTime"]), Information = dr["Information"].ToString(), CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString()) });
        //        }
        //    }
        //    catch
        //    {
        //        result = null;
        //    }
        //    finally
        //    {
        //        oleDbConnection.Close();
        //    }


        //    return result;
        //}

    }
}
