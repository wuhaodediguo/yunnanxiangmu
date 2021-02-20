using System;
using System.Data.OleDb;
using System.Web;
using System.Collections;
using System.Collections.Generic;

namespace MojoCube.Web.TruckInfo
{

    public class TruckInfo
    {
        public string id { set; get; }
        public string plantno { set; get; }
        public int yewustyle { set; get; }
        public int pinzhong { set; get; }
        public double Grossweight { set; get; }
        public double Tareweight { set; get; }
        public double Netweight { set; get; }
        public double unitprice { set; get; }
        public double amount { set; get; }
        public DateTime weightTime { set; get; }
        public string CardNumber { set; get; }
        public int truckstatus { set; get; }
        public string CreateUser { set; get; }
        public string Handleman { set; get; }
        public string Receiver { set; get; }
        public DateTime Createtime { set; get; }
 
      

       // ID,plantno, yewustyle, pinzhong, Grossweight,Tareweight,  Netweight, unitprice, amount, weightTime, CardNumber,truckstatus(0:新增,1:保存), CreateUser, Handleman, Receiver, Createtime 

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into tb_TruckInfo(plantno,yewustyle,pinzhong,Grossweight,Tareweight,Netweight,unitprice,amount,weightTime,CardNumber,truckstatus,CreateUser,[CreateTime]) values
(@plantno,@yewustyle,@pinzhong,@Grossweight,@Tareweight,@Netweight,@unitprice,@amount,@weightTime,@CardNumber,@truckstatus,@CreateUser,@CreateTime)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@plantno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@plantno"].Value = this.plantno;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yewustyle", OleDbType.Integer));
                oleDbCommand.Parameters["@yewustyle"].Value = this.yewustyle;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pinzhong", OleDbType.Integer));
                oleDbCommand.Parameters["@pinzhong"].Value = this.pinzhong;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Grossweight", OleDbType.Double));
                oleDbCommand.Parameters["@Grossweight"].Value = this.Grossweight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tareweight", OleDbType.Double));
                oleDbCommand.Parameters["@Tareweight"].Value = this.Tareweight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Netweight", OleDbType.Double));
                oleDbCommand.Parameters["@Netweight"].Value = this.Netweight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@unitprice", OleDbType.Double));
                oleDbCommand.Parameters["@unitprice"].Value = this.unitprice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@amount", OleDbType.Double));
                oleDbCommand.Parameters["@amount"].Value = this.amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@weightTime", OleDbType.Date));
                oleDbCommand.Parameters["@weightTime"].Value = this.weightTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CardNumber", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CardNumber"].Value = this.CardNumber;
                oleDbCommand.Parameters.Add(new OleDbParameter("@truckstatus", OleDbType.Integer));
                oleDbCommand.Parameters["@truckstatus"].Value = this.truckstatus;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CreateUser"].Value = this.CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Createtime", OleDbType.Date));
                oleDbCommand.Parameters["@Createtime"].Value = this.Createtime;
              
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
update tb_TruckInfo set  Grossweight=@Grossweight, Tareweight=@Tareweight, Netweight=@Netweight,
 unitprice=@unitprice, amount=@amount, weightTime=@weightTime,CardNumber=@CardNumber,CreateUser=@CreateUser,
truckstatus=@truckstatus
where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@Grossweight", OleDbType.Double));
                oleDbCommand.Parameters["@Grossweight"].Value = this.Grossweight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tareweight", OleDbType.Double));
                oleDbCommand.Parameters["@Tareweight"].Value = this.Tareweight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Netweight", OleDbType.Double));
                oleDbCommand.Parameters["@Netweight"].Value = this.Netweight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@unitprice", OleDbType.Double));
                oleDbCommand.Parameters["@unitprice"].Value = this.unitprice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@amount", OleDbType.Double));
                oleDbCommand.Parameters["@amount"].Value = this.amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@weightTime", OleDbType.Date));
                oleDbCommand.Parameters["@weightTime"].Value = this.weightTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CardNumber", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CardNumber"].Value = this.CardNumber;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CreateUser"].Value = this.CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@truckstatus", OleDbType.Integer));
                oleDbCommand.Parameters["@truckstatus"].Value = this.truckstatus;

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
            Sql.SqlQuery("delete from tb_TruckInfo where id=" + id);
        }

    }

    public class TruckitemInfo
    {
        public string id { set; get; }
        public string truckinfoID { set; get; }
        public int pinzhong { set; get; }
        public int guige { set; get; }
        public int Qty { set; get; }
        public double UnitPrice { set; get; }
        public double Amount { set; get; }
        public int truckitemstatus { set; get; }
        public DateTime Createtime { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into tb_TruckitemInfo(truckinfoID,pinzhong,guige,Qty,UnitPrice,Amount,truckitemstatus,[CreateTime]) values
(@truckinfoID,@pinzhong,@guige,@Qty,@UnitPrice,@Amount,@truckitemstatus,@CreateTime)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@truckinfoID", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@truckinfoID"].Value = this.truckinfoID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pinzhong", OleDbType.Integer));
                oleDbCommand.Parameters["@pinzhong"].Value = this.pinzhong;
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.Integer));
                oleDbCommand.Parameters["@guige"].Value = this.guige;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Qty", OleDbType.Integer));
                oleDbCommand.Parameters["@Qty"].Value = this.Qty;
                oleDbCommand.Parameters.Add(new OleDbParameter("@UnitPrice", OleDbType.Double));
                oleDbCommand.Parameters["@UnitPrice"].Value = this.UnitPrice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Amount", OleDbType.Double));
                oleDbCommand.Parameters["@Amount"].Value = this.Amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@truckitemstatus", OleDbType.Integer));
                oleDbCommand.Parameters["@truckitemstatus"].Value = this.truckitemstatus;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Createtime", OleDbType.Date));
                oleDbCommand.Parameters["@Createtime"].Value = this.Createtime;

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
update tb_TruckitemInfo set pinzhong=@pinzhong,guige=@guige,Qty=@Qty,UnitPrice=@UnitPrice,Amount=@Amount,truckitemstatus=@truckitemstatus
where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pinzhong", OleDbType.Integer));
                oleDbCommand.Parameters["@pinzhong"].Value = this.pinzhong;
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.Integer));
                oleDbCommand.Parameters["@guige"].Value = this.guige;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Qty", OleDbType.Integer));
                oleDbCommand.Parameters["@Qty"].Value = this.Qty;
                oleDbCommand.Parameters.Add(new OleDbParameter("@UnitPrice", OleDbType.Double));
                oleDbCommand.Parameters["@UnitPrice"].Value = this.UnitPrice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Amount", OleDbType.Double));
                oleDbCommand.Parameters["@Amount"].Value = this.Amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@truckitemstatus", OleDbType.Integer));
                oleDbCommand.Parameters["@truckitemstatus"].Value = this.truckitemstatus;
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

        public int updatestatus()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"
update tb_TruckitemInfo set truckitemstatus=@truckitemstatus
where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@truckitemstatus", OleDbType.Integer));
                oleDbCommand.Parameters["@truckitemstatus"].Value = this.truckitemstatus;
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
            Sql.SqlQuery("delete from tb_TruckitemInfo where id=" + id);
        }

    }
}
