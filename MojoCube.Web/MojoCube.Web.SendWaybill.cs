using System;
using System.Data.OleDb;
using System.Web;
using System.Collections;
using System.Data;

namespace MojoCube.Web.SendWaybill
{

    public class SendWaybillList
    {
        public string id { set; get; }
        public string pk_SendWaybill { set; get; }
        public DateTime SendTime { set; get; }
        public string MailDot { set; get; }
        public string SendCustomerName { set; get; }
        //public string PickerName { set; get; }
        //public string SendPhone { set; get; }
        public string ReceiveCustomerName { set; get; }
        //public string ReceivePhone { set; get; }
        public string AddressInfo { set; get; }
        public string Weight { set; get; }
        public string Count { set; get; }
        public string Province { set; get; }
        public string PayType { set; get; }
        public string Freight { set; get; }
        public string AmountCollected { set; get; }
        public string Remark { set; get; }
        public DateTime CreateTime { set; get; }
        public string ReturnNumber { set; get; }
        public string logisticsStatus { set; get; }
        public DateTime logisticsLastTime { set; get; }
        public string logisticsLastInfo { set; get; }


        public string  CheckUploadResult { set; get; }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from SendWaybill_List where pk_SendWaybill=@pk_SendWaybill";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_SendWaybill", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_SendWaybill"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.pk_SendWaybill = oleDbDataReader["pk_SendWaybill"].ToString();
                    this.SendTime = Convert.ToDateTime(oleDbDataReader["SendTime"].ToString());
                    this.MailDot = oleDbDataReader["MailDot"].ToString();
                    this.SendCustomerName = oleDbDataReader["SendCustomerName"].ToString();
                    //this.PickerName = oleDbDataReader["PickerName"].ToString();
                    //this.SendPhone = oleDbDataReader["SendPhone"].ToString();
                    this.ReceiveCustomerName = oleDbDataReader["ReceiveCustomerName"].ToString();
                    //this.ReceivePhone = oleDbDataReader["ReceivePhone"].ToString();
                    this.AddressInfo = oleDbDataReader["AddressInfo"].ToString();
                    this.Weight = oleDbDataReader["Weight"].ToString();
                    this.Count = oleDbDataReader["Count"].ToString();
                    this.Province = oleDbDataReader["Province"].ToString();
                    this.PayType = oleDbDataReader["PayType"].ToString();
                    this.Freight = oleDbDataReader["Freight"].ToString();
                    this.AmountCollected = oleDbDataReader["AmountCollected"].ToString();
                    this.Remark = oleDbDataReader["Remark"].ToString();
                    this.CreateTime =  Convert.ToDateTime(oleDbDataReader["CreateTime"].ToString());
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public DataTable GetSummaryData(string where, ArrayList arrayList)
        {
            DataTable dt = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            string sql = @"select SUM(CDBL(IIF(FREIGHT IS NULL,0,IIF(FREIGHT ='',0,FREIGHT)))) AS FREIGHT,
                        SUM(CDBL(IIF(AmountCollected IS NULL,0,IIF(AmountCollected ='',0,AmountCollected)))) AS AmountCollected
                        from SendWaybill_List " + where;
            if (arrayList.Count > 0)
                dt = oledbHelper.GetDataTable(sql, (string[])arrayList.ToArray(typeof(string)));
            else
                dt = oledbHelper.GetDataTable(sql);

            return dt;
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into SendWaybill_List(pk_SendWaybill,SendTime,MailDot,SendCustomerName,ReceiveCustomerName,AddressInfo,[Weight],[Count],Province,PayType,Freight,[CreateTime],ReturnNumber,logisticsStatus) 
values (@pk_SendWaybill,@SendTime,@MailDot,@SendCustomerName,@ReceiveCustomerName,@AddressInfo,@Weight,@Count,@Province,@PayType,@Freight,@CreateTime,@ReturnNumber,@logisticsStatus)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_SendWaybill", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_SendWaybill"].Value = this.pk_SendWaybill;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SendTime", OleDbType.Date));
                oleDbCommand.Parameters["@SendTime"].Value = this.SendTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MailDot", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@MailDot"].Value = this.MailDot;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SendCustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SendCustomerName"].Value = this.SendCustomerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@PickerName", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@PickerName"].Value = this.PickerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@SendPhone", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@SendPhone"].Value = this.SendPhone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ReceiveCustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ReceiveCustomerName"].Value = this.ReceiveCustomerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ReceivePhone", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@ReceivePhone"].Value = this.ReceivePhone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AddressInfo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@AddressInfo"].Value = this.AddressInfo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Weight"].Value = this.Weight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Count", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Count"].Value = this.Count;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Province", OleDbType.VarChar,200));
                oleDbCommand.Parameters["@Province"].Value = this.Province;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PayType", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@PayType"].Value = this.PayType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Freight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Freight"].Value = this.Freight;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@AmountCollected", OleDbType.VarChar,200));
                //oleDbCommand.Parameters["@AmountCollected"].Value = this.AmountCollected;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ReturnNumber", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ReturnNumber"].Value = this.ReturnNumber;
                oleDbCommand.Parameters.Add(new OleDbParameter("@logisticsStatus", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@logisticsStatus"].Value = this.logisticsStatus;
              
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
            int result = 0;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"update SendWaybill_List set pk_SendWaybill=@pk_SendWaybill,SendTime=@SendTime,MailDot=@MailDot,SendCustomerName=@SendCustomerName,ReceiveCustomerName=@ReceiveCustomerName,AddressInfo=@AddressInfo,[Weight]=@Weight,[Count]=@Count,Province=@Province,PayType=@PayType,Freight=@Freight,AmountCollected=@AmountCollected,Remark=@Remark,[CreateTime]=@CreateTime,ReturnNumber=@ReturnNumber where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_SendWaybill", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_SendWaybill"].Value = this.pk_SendWaybill;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SendTime", OleDbType.Date));
                oleDbCommand.Parameters["@SendTime"].Value = this.SendTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MailDot", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@MailDot"].Value = this.MailDot;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SendCustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SendCustomerName"].Value = this.SendCustomerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@PickerName", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@PickerName"].Value = this.PickerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@SendPhone", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@SendPhone"].Value = this.SendPhone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ReceiveCustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ReceiveCustomerName"].Value = this.ReceiveCustomerName;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@ReceivePhone", OleDbType.VarChar, 200));
                //oleDbCommand.Parameters["@ReceivePhone"].Value = this.ReceivePhone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AddressInfo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@AddressInfo"].Value = this.AddressInfo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Weight"].Value = this.Weight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Count", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Count"].Value = this.Count;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Province", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Province"].Value = this.Province;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PayType", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@PayType"].Value = this.PayType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Freight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Freight"].Value = this.Freight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AmountCollected", OleDbType.VarChar,200));
                oleDbCommand.Parameters["@AmountCollected"].Value = this.AmountCollected;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ReturnNumber", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ReturnNumber"].Value = this.ReturnNumber;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@id", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@id"].Value = this.id;
                result =oleDbCommand.ExecuteNonQuery();
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

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from SendWaybill_List where pk_SendWaybill=" + id);
        }

        public void DeleteDataById(int id)
        {
            Sql.SqlQuery("delete from SendWaybill_List where id=" + id);
        }

        public string GetReceiveCustomerName(double sendwaybillid)
        {
            string Customer = "";
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Customer from SurfaceSingle where CDbl(StartNo)<=@pk_SendWaybill and  CDbl(EndNo)>=@pk_SendWaybill";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_SendWaybill", OleDbType.Double));
                oleDbCommand.Parameters["@pk_SendWaybill"].Value = sendwaybillid;
                object objcustomer=oleDbCommand.ExecuteScalar();
                if (objcustomer != null)
                {
                    Customer = objcustomer.ToString();
                }
                return Customer;
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public DataTable GetSendWayBillCost(string where, ArrayList arrayList)
        {
            DataTable dt = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            string sql = @"select FRISTCOST.SENDBILLNO,SUM(IIF(FRISTCOST.EXPENDITURE IS NULL,0,IIF(FRISTCOST.EXPENDITURE='',0,FRISTCOST.EXPENDITURE))-IIF(FRISTCOST.Remark='退回',IIF(FRISTCOST.Income is null,0,IIF(FRISTCOST.INCOME='',0,FRISTCOST.INCOME)),0)) AS  CONTRACTEDFREIGHT 
                               from fristcost left join SendWaybill_List on SendWaybill_List.PK_SENDWAYBILL =FRISTCOST.SENDBILLNO " + where + " group by FRISTCOST.SENDBILLNO";
            if (arrayList.Count > 0)
                dt = oledbHelper.GetDataTable(sql, (string[])arrayList.ToArray(typeof(string)));
            else
                dt = oledbHelper.GetDataTable(sql);

            return dt;
        }
    }

}
