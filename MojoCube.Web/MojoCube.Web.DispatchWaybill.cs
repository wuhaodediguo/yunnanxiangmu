using System;
using System.Data.OleDb;
using System.Web;
using System.Data;
using System.Collections;

namespace MojoCube.Web.DispatchWaybill
{

    public class DispatchWaybillList
    {
        public string id { set; get; }
        public string pk_DispatchWaybill { set; get; }
        //public DateTime ArriveTime { set; get; }
        //public DateTime SigningTime { set; get; }
        public string DispatchMan { set; get; }
        //public string Province { set; get; }
        //public string AddressInfo { set; get; }
        //public string ReceiveCustomerName { set; get; }
        //public string ReceivePhone { set; get; }
        public string Weight { set; get; }
        //public string Count { set; get; }
        public string AmountCollected { set; get; }
        public string Remark { set; get; }
        public DateTime CreateTime { set; get; }
        public string Region { set; get; }
        public string Payment { set; get; }
        //public string DeliveryMoney { set; get; }
        public string PayType { set; get; }

        public string  CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
//                string cmdText = @"insert into DispatchWaybill_List(pk_DispatchWaybill,ArriveTime,SigningTime,DispatchMan,AddressInfo,ReceiveCustomerName,ReceivePhone,[Weight],[Count],[CreateTime]) values
//(@pk_DispatchWaybill,@ArriveTime,@SigningTime,@DispatchMan,@AddressInfo,@ReceiveCustomerName,@ReceivePhone,@Weight,@Count,@CreateTime)";
                string cmdText = @"insert into DispatchWaybill_List(pk_DispatchWaybill,DispatchMan,[Weight],[CreateTime],Region,Payment,PayType) values
                (@pk_DispatchWaybill,@DispatchMan,@Weight,@CreateTime,@Region,@Payment,@PayType)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_DispatchWaybill", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_DispatchWaybill"].Value = this.pk_DispatchWaybill;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ArriveTime", OleDbType.Date));
                //oleDbCommand.Parameters["@ArriveTime"].Value = this.ArriveTime;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@SigningTime", OleDbType.Date));
                //oleDbCommand.Parameters["@SigningTime"].Value = this.SigningTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@DispatchMan", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@DispatchMan"].Value = this.DispatchMan;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@Province", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@Province"].Value = this.Province;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@AddressInfo", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@AddressInfo"].Value = this.AddressInfo;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ReceiveCustomerName", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@ReceiveCustomerName"].Value = this.ReceiveCustomerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ReceivePhone", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@ReceivePhone"].Value = this.ReceivePhone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Weight"].Value = this.Weight;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@Count", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@Count"].Value = this.Count;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Region", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Region"].Value = this.Region;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Payment", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Payment"].Value = this.Payment;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@DeliveryMoney", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@DeliveryMoney"].Value = this.DeliveryMoney;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PayType", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@PayType"].Value = this.PayType;
              
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

        public int updateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"
update DispatchWaybill_List set pk_DispatchWaybill=@pk_DispatchWaybill,DispatchMan=@DispatchMan,
[Weight]=@Weight,AmountCollected=@AmountCollected,Remark=@Remark,Region=@Region,Payment=@Payment,PayType=@PayType
where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_DispatchWaybill", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_DispatchWaybill"].Value = this.pk_DispatchWaybill;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ArriveTime", OleDbType.Date));
                //oleDbCommand.Parameters["@ArriveTime"].Value = this.ArriveTime;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@SigningTime", OleDbType.Date));
                //oleDbCommand.Parameters["@SigningTime"].Value = this.SigningTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@DispatchMan", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@DispatchMan"].Value = this.DispatchMan;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@Province", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@Province"].Value = this.Province;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ReceiveCustomerName", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@ReceiveCustomerName"].Value = this.ReceiveCustomerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ReceivePhone", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@ReceivePhone"].Value = this.ReceivePhone;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@AddressInfo", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@AddressInfo"].Value = this.AddressInfo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Weight"].Value = this.Weight;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@Count", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@Count"].Value = this.Count;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AmountCollected", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@AmountCollected"].Value = this.AmountCollected;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Region", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Region"].Value = this.Region;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Payment", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Payment"].Value = this.Payment;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@DeliveryMoney", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@DeliveryMoney"].Value = this.DeliveryMoney;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PayType", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@PayType"].Value = this.PayType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@id", OleDbType.VarChar, 200));
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
            Sql.SqlQuery("delete from DispatchWaybill_List where id=" + id);
        }

        public DataTable GetSummaryData(string where, ArrayList arrayList)
        {
            DataTable dt = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            string sql = @"select SUM(CDBL(IIF(AmountCollected IS NULL,0,IIF(AmountCollected ='',0,AmountCollected)))) AS AmountCollected
                        from DispatchWaybill_List " + where;
            if (arrayList.Count > 0)
                dt = oledbHelper.GetDataTable(sql, (string[])arrayList.ToArray(typeof(string)));
            else
                dt = oledbHelper.GetDataTable(sql);

            return dt;
        }
    }
}
