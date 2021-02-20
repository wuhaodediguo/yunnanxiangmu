using System;
using System.Data.OleDb;
using System.Web;
using System.Collections;
using System.Collections.Generic;

namespace MojoCube.Web.Logistics
{

    public class LogisticsList
    {
        public string id { set; get; }
        public string pk_Logistics { set; get; }
        public DateTime TakeTime { set; get; }
        public string Information { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime InputTime { set; get; }

        public string  CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into Logistics(pk_Logistics,TakeTime,[Information],[CreateTime]) values
(@pk_Logistics,@TakeTime,@Information,@CreateTime)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Logistics", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_Logistics"].Value = this.pk_Logistics;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TakeTime", OleDbType.Date));
                oleDbCommand.Parameters["@TakeTime"].Value = this.TakeTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Information", OleDbType.VarChar,200));
                oleDbCommand.Parameters["@Information"].Value = this.Information;
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

        public int updateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"
update Logistics set pk_Logistics=@pk_Logistics,TakeTime=@TakeTime,Information=@Information,[CreateTime]=@CreateTime
where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Logistics", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_Logistics"].Value = this.pk_Logistics;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TakeTime", OleDbType.Date));
                oleDbCommand.Parameters["@TakeTime"].Value = this.TakeTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Information", OleDbType.VarChar,200));
                oleDbCommand.Parameters["@Information"].Value = this.Information;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
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
            Sql.SqlQuery("delete from Logistics where id=" + id);
        }

        public IList<LogisticsList> GetLogisticsList(string LogisticsNo)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            IList<LogisticsList> result = new List<LogisticsList>();
            //首先获取ANELogistics是否有绑定信息
            List<string> bindLogistics = new List<string>();
            try
            {
                oleDbConnection.Open();
                string cmdText = @"select LogisticsID from ANELogistics where LogisticsID=@LogisticsNo or ANELogisticsID=@LogisticsNo
union                                                    
select ANELogisticsID as LogisticsID from ANELogistics where LogisticsID=@LogisticsNo or ANELogisticsID=@LogisticsNo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogisticsNo", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@LogisticsNo"].Value = LogisticsNo;
                OleDbDataReader dr = oleDbCommand.ExecuteReader();

                while (dr.Read())
                {
                    bindLogistics.Add(dr["LogisticsID"].ToString());
                }
            }
            catch
            {
            }
            finally
            {
                oleDbConnection.Close();
            }

            if (bindLogistics.Count > 0)
            {
                string insql = "";
                foreach(string item in bindLogistics)
                {
                    insql += "'" + item+"',";
                }
                insql=insql.TrimEnd(',');

                try
                {
                    oleDbConnection.Open();
                    string cmdText =@"SELECT Logistics.*     
FROM Logistics LEFT JOIN ANELogistics ON Logistics.pk_Logistics = ANELogistics.ANELogisticsID
where Logistics.pk_Logistics in (" + insql + ") and TakeTime<=now() order by TakeTime desc";
                    OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                    OleDbDataReader dr = oleDbCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        result.Add(new LogisticsList() { id = dr["id"].ToString(), pk_Logistics = dr["pk_Logistics"].ToString(), TakeTime = Convert.ToDateTime(dr["TakeTime"]), Information = dr["Information"].ToString(), CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString()) });
                    }
                }
                catch
                {
                    result = null;
                }
                finally
                {
                    oleDbConnection.Close();
                }
                return result;

            }

          
         
            try
            {
                oleDbConnection.Open();
                string cmdText = @"select * from Logistics where pk_Logistics=@pk_Logistics and TakeTime<=now() order by TakeTime desc";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Logistics", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pk_Logistics"].Value = LogisticsNo;
                OleDbDataReader dr = oleDbCommand.ExecuteReader();

                while (dr.Read())
                {
                    result.Add(new LogisticsList() { id = dr["id"].ToString(), pk_Logistics = dr["pk_Logistics"].ToString(), TakeTime = Convert.ToDateTime(dr["TakeTime"]), Information = dr["Information"].ToString(), CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString()) });
                }
            }
            catch
            {
                result = null;
            }
            finally
            {
                oleDbConnection.Close();
            }


            return result;
        }

    }

    public class ANELogisticsList
    {
        public string id { set; get; }
        public string LogisticsID { set; get; }
        public string ANELogisticsID { set; get; }
        public string Status { set; get; }
        public DateTime CreateTime { set; get; }//设置的绑定时间

        public string CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into ANELogistics(LogisticsID,ANELogisticsID,[Status],[CreateTime]) values
(@LogisticsID,@ANELogisticsID,@Status,@CreateTime)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogisticsID", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@LogisticsID"].Value = this.LogisticsID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ANELogisticsID", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ANELogisticsID"].Value = this.ANELogisticsID;
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

        public int updateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"
update ANELogistics set LogisticsID=@LogisticsID,ANELogisticsID=@ANELogisticsID,[CreateTime]=@CreateTime
where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogisticsID", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@LogisticsID"].Value = this.LogisticsID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ANELogisticsID", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ANELogisticsID"].Value = this.ANELogisticsID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateTime", OleDbType.Date));
                oleDbCommand.Parameters["@CreateTime"].Value = this.CreateTime;
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
            Sql.SqlQuery("delete from ANELogistics where id=" + id);
        }
    }

    public class damikucunList
    {
        public decimal swiftNo { set; get; }
        public string pinzhong { set; get; }
        public string guige { set; get; }
        public decimal amount { set; get; }
        public string remark { set; get; }
  
        public DateTime CreateDate { set; get; }
        public string operator1 { set; get; }
       
        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
//                string cmdText = @"insert into tb_damikucun(swiftNo,pinzhong,guige,amount,[CreateDate],operator) values
//                                (@swiftNo,@pinzhong,@guige,@amount,@CreateDate,@operator)";
                string cmdText = @"insert into tb_damikucun(swiftNo,pinzhong,guige,amount,CreateDate,operator) values
                                (@swiftNo,@pinzhong,@guige,@amount,@CreateDate,@operator)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@swiftNo", OleDbType.Decimal));
                oleDbCommand.Parameters["@swiftNo"].Value = this.swiftNo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pinzhong", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pinzhong"].Value = this.pinzhong;
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@guige"].Value = this.guige;
                oleDbCommand.Parameters.Add(new OleDbParameter("@amount", OleDbType.Decimal));
                oleDbCommand.Parameters["@amount"].Value = this.amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this.CreateDate;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                //oleDbCommand.Parameters["@CreateDate"].Value = DateTime.Now;
                oleDbCommand.Parameters.Add(new OleDbParameter("@operator", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@operator"].Value = this.operator1;
               

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
                            update tb_damikucun set pinzhong=@pinzhong,guige=@guige,amount=@amount,[CreateDate]=@CreateDate,operator=@operator
                            where swiftNo=@swiftNo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pinzhong", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@pinzhong"].Value = this.pinzhong;
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@guige"].Value = this.guige;
                oleDbCommand.Parameters.Add(new OleDbParameter("@amount", OleDbType.Decimal));
                oleDbCommand.Parameters["@amount"].Value = this.amount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this.CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@operator", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@operator"].Value = this.operator1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@swiftNo", OleDbType.Decimal));
                oleDbCommand.Parameters["@swiftNo"].Value = this.swiftNo;
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

        public int updateRemark()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"
                            update tb_damikucun set remark=@remark
                            where swiftNo=@swiftNo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@remark"].Value = this.remark;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@swiftNo", OleDbType.Decimal));
                oleDbCommand.Parameters["@swiftNo"].Value = this.swiftNo;
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


        public void DeleteDataById(decimal swiftNo)
        {
            Sql.SqlQuery("delete from tb_damikucun where swiftNo=" + swiftNo);
        }

        public void GetData(decimal swiftNo)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_damikucun  where swiftNo =@swiftNo ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@swiftNo", OleDbType.Decimal));
                oleDbCommand.Parameters["@swiftNo"].Value = swiftNo;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.swiftNo = Convert.ToDecimal(oleDbDataReader["swiftNo"].ToString());
                    this.pinzhong = oleDbDataReader["pinzhong"].ToString();
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.amount =Convert.ToDecimal(oleDbDataReader["guige"].ToString());

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public IList<damikucunList> GetdamikucunList(string swiftNo)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            IList<damikucunList> result = new List<damikucunList>();
            //首先获取ANELogistics是否有绑定信息
            List<string> damikucunList = new List<string>();
            try
            {
                oleDbConnection.Open();
                string cmdText = @"select * from tb_damikucun where swiftNo=@swiftNo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@swiftNo", OleDbType.Decimal));
                oleDbCommand.Parameters["@swiftNo"].Value = swiftNo;
                OleDbDataReader dr = oleDbCommand.ExecuteReader();

                while (dr.Read())
                {
                    damikucunList.Add(dr["LogisticsID"].ToString());
                }
            }
            catch
            {
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

    }



}
