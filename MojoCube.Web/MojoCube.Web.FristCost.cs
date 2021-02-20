using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace MojoCube.Web.FristCost
{
    public class FristCost
    {
        public DateTime TradeTime { set; get; }
        public string SendBillNo { set; get; }
        public string SettlementWeight { set; get; }
        public string Income { set; get; }
        public string Expenditure { set; get; }
        public string CostItem { set; get; }
        public string Remark { set; get; }
        public string SysRemark { set; get; }
        public DateTime CreatedDate { set; get; }
        public Int32 ID { get; set; }

        public string CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into FristCost([TradeTime],[SendBillNo],[SettlementWeight],[Income],[Expenditure],[CostItem],[Remark],[SysRemark],[CreatedDate]) values
                (@TradeTime,@SendBillNo,@SettlementWeight,@Income,@Expenditure,@CostItem,@Remark,@SysRemark,@CreatedDate)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TradeTime", OleDbType.Date));
                oleDbCommand.Parameters["@TradeTime"].Value = this.TradeTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SendBillNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SendBillNo"].Value = this.SendBillNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SettlementWeight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SettlementWeight"].Value = this.SettlementWeight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Income", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Income"].Value = this.Income;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Expenditure", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Expenditure"].Value = this.Expenditure;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CostItem", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@CostItem"].Value = this.CostItem;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SysRemark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SysRemark"].Value = this.SysRemark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreatedDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreatedDate"].Value = this.CreatedDate;

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
                                update FristCost set SettlementWeight=@SettlementWeight,Income=@Income,
                                [Expenditure]=@Expenditure,[CostItem]=@CostItem,[Remark]=@Remark,SysRemark=@SysRemark where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@SettlementWeight", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SettlementWeight"].Value = this.SettlementWeight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Income", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Income"].Value = this.Income;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Expenditure", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Expenditure"].Value = this.Expenditure;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CostItem", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@CostItem"].Value = this.CostItem;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Remark"].Value = this.Remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SysRemark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SysRemark"].Value = this.SysRemark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@id", OleDbType.Integer));
                oleDbCommand.Parameters["@id"].Value = id;
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
            Sql.SqlQuery("delete from FristCost where id=" + id);
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from FristCost where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.TradeTime = Convert.ToDateTime(oleDbDataReader["TradeTime"].ToString());
                    this.SendBillNo = oleDbDataReader["SendBillNo"].ToString();
                    this.SettlementWeight = oleDbDataReader["SettlementWeight"].ToString();
                    this.Income = oleDbDataReader["Income"].ToString();
                    this.Expenditure = oleDbDataReader["Expenditure"].ToString();
                    this.CostItem = oleDbDataReader["CostItem"].ToString();
                    this.Remark = oleDbDataReader["Remark"].ToString();
                    this.SysRemark = oleDbDataReader["SysRemark"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetData(string CustomerName, string StatementDate)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from FristCost where TradeTime=@TradeTime and SendBillNo=@SendBillNo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TradeTime", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@TradeTime"].Value = TradeTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SendBillNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@SendBillNo"].Value = SendBillNo;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.TradeTime = Convert.ToDateTime(oleDbDataReader["TradeTime"].ToString());
                    this.SendBillNo = oleDbDataReader["SendBillNo"].ToString();
                    this.SettlementWeight = oleDbDataReader["SettlementWeight"].ToString();
                    this.Income = oleDbDataReader["Income"].ToString();
                    this.Expenditure = oleDbDataReader["Expenditure"].ToString();
                    this.CostItem = oleDbDataReader["CostItem"].ToString();
                    this.Remark = oleDbDataReader["Remark"].ToString();
                    this.SysRemark = oleDbDataReader["SysRemark"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }
    }
}
