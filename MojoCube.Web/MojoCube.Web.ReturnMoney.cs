using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace MojoCube.Web.ReturnMoney
{
    public class ReturnMoney
    {
        public Int32 id { set; get; }
        public string CustomerName { set; get; }
        public string StatementDate { set; get; }
        public string GatheringAmount { set; get; }
        public string AccountType { set; get; }
        public string CheckUploadResult { set; get; }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into ReturnMoney([CustomerName],[StatementDate],[GatheringAmount],[AccountType]) values
                (@CustomerName,@StatementDate,@GatheringAmount,@AccountType)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@CustomerName"].Value = this.CustomerName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatementDate", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@StatementDate"].Value = this.StatementDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@GatheringAmount", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@GatheringAmount"].Value = this.GatheringAmount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AccountType", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@AccountType"].Value = this.AccountType;

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
                                update ReturnMoney set CustomerName=@CustomerName,StatementDate=@StatementDate,
                                [GatheringAmount]=@GatheringAmount,AccountType=@AccountType where id=@id";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@CustomerName"].Value = this.CustomerName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatementDate", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@StatementDate"].Value = this.StatementDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@GatheringAmount", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@GatheringAmount"].Value = this.GatheringAmount;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AccountType", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@AccountType"].Value = this.AccountType;
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
            Sql.SqlQuery("delete from ReturnMoney where id=" + id);
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from ReturnMoney where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.id = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.CustomerName = oleDbDataReader["CustomerName"].ToString();
                    this.StatementDate = oleDbDataReader["StatementDate"].ToString();
                    this.GatheringAmount = oleDbDataReader["GatheringAmount"].ToString();
                    //this.GatheringAmount = oleDbDataReader["AccountType"].ToString();
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
                string cmdText = "select * from ReturnMoney where CustomerName=@CustomerName and StatementDate=@StatementDate";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CustomerName", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@CustomerName"].Value = CustomerName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatementDate", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@StatementDate"].Value = StatementDate;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.id = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.CustomerName = oleDbDataReader["CustomerName"].ToString();
                    this.StatementDate = oleDbDataReader["StatementDate"].ToString();
                    this.GatheringAmount = oleDbDataReader["GatheringAmount"].ToString();
                    //this.GatheringAmount = oleDbDataReader["AccountType"].ToString();
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
            string sql = @"select SUM(BILLAMOUNT),SUM(GatheringAmount),SUM(wreckamount) FROM
(SELECT SENDWAY.SENDCUSTOMERNAME,SENDWAY.SENDTIME,IIF(RETURNM.GATHERINGAMOUNT IS NULL,0,IIF(RETURNM.GATHERINGAMOUNT ='',0,RETURNM.GATHERINGAMOUNT)) AS GATHERINGAMOUNT,IIF(SENDWAY.FREIGHT IS NULL,0,SENDWAY.FREIGHT) AS BILLAMOUNT,(IIF(SENDWAY.FREIGHT IS NULL,0,SENDWAY.FREIGHT)-IIF(RETURNM.GATHERINGAMOUNT IS NULL,0,IIF(RETURNM.GATHERINGAMOUNT ='',0,RETURNM.GATHERINGAMOUNT))) AS WRECKAMOUNT,CONTRACTEDFREIGHT FROM 
                                        (SELECT SENDCUSTOMERNAME,(YEAR(SENDTIME) & '-' &  MONTH(SENDTIME)) AS SENDTIME,SUM(CDBL(IIF(FREIGHT IS NULL,0,IIF(FREIGHT ='',0,FREIGHT)))) AS FREIGHT,SUM(CONTRACTEDFREIGHT) AS CONTRACTEDFREIGHT FROM ( SELECT A.SENDCUSTOMERNAME,A.SENDTIME,A.FREIGHT,(A.WEIGHT*A.COSTQUOTATION+A.COUNT*A.SUBRATE+MAINRATE+CONTRACTEDFREIGHT) AS CONTRACTEDFREIGHT FROM (    SELECT SENDWAY.SENDCUSTOMERNAME,SENDWAY.SENDTIME, SENDWAY.PK_SENDWAYBILL,SENDWAY.WEIGHT,SENDWAY.COUNT,SENDWAY.FREIGHT,COSTQUOTATION.PROVINCE,
                                           COSTQUOTATION.COSTQUOTATION,COSTQUOTATION.SUBRATE,COSTQUOTATION.MAINRATE,
                                           SUM(IIF(FRISTCOST.EXPENDITURE IS NULL,0,IIF(FRISTCOST.EXPENDITURE='',0,FRISTCOST.EXPENDITURE))-IIF(FRISTCOST.Remark='退回',IIF(FRISTCOST.Income is null,0,IIF(FRISTCOST.INCOME='',0,FRISTCOST.INCOME)),0)) AS  CONTRACTEDFREIGHT 
                                         FROM (SENDWAYBILL_LIST SENDWAY LEFT JOIN  FRISTCOST FRISTCOST ON SENDWAY.PK_SENDWAYBILL =FRISTCOST.SENDBILLNO) LEFT JOIN COSTQUOTATION COSTQUOTATION ON IIF(SENDWAY.PROVINCE = COSTQUOTATION.PROVINCE , SENDWAY.PROVINCE,'000') = COSTQUOTATION.PROVINCE
                                         WHERE SENDWAY.PAYTYPE='月结'    GROUP BY      SENDWAY.SENDCUSTOMERNAME,SENDWAY.SENDTIME, SENDWAY.PK_SENDWAYBILL,SENDWAY.WEIGHT,SENDWAY.COUNT,SENDWAY.FREIGHT, COSTQUOTATION.PROVINCE,
                                           COSTQUOTATION.COSTQUOTATION,COSTQUOTATION.SUBRATE,COSTQUOTATION.MAINRATE) A, (   SELECT SENDCUSTOMERNAME,SENDTIME, PK_SENDWAYBILL,WEIGHT,COUNT,MAX(PROVINCE) AS PROVINCE FROM  (SELECT SENDWAY.SENDCUSTOMERNAME,SENDWAY.SENDTIME, SENDWAY.PK_SENDWAYBILL,SENDWAY.WEIGHT,SENDWAY.COUNT,COSTQUOTATION.PROVINCE,
                                           COSTQUOTATION.COSTQUOTATION,COSTQUOTATION.SUBRATE,COSTQUOTATION.MAINRATE,  
                                           SUM(IIF(FRISTCOST.EXPENDITURE IS NULL,0,IIF(FRISTCOST.EXPENDITURE='',0,FRISTCOST.EXPENDITURE))) AS  CONTRACTEDFREIGHT 
                                         FROM (SENDWAYBILL_LIST SENDWAY LEFT JOIN  FRISTCOST FRISTCOST ON SENDWAY.PK_SENDWAYBILL =FRISTCOST.SENDBILLNO) LEFT JOIN COSTQUOTATION COSTQUOTATION ON IIF(SENDWAY.PROVINCE = COSTQUOTATION.PROVINCE , SENDWAY.PROVINCE,'000') = COSTQUOTATION.PROVINCE
                                         WHERE SENDWAY.PAYTYPE='月结'    GROUP BY      SENDWAY.SENDCUSTOMERNAME,SENDWAY.SENDTIME, SENDWAY.PK_SENDWAYBILL,SENDWAY.WEIGHT,SENDWAY.COUNT, COSTQUOTATION.PROVINCE,
                                           COSTQUOTATION.COSTQUOTATION,COSTQUOTATION.SUBRATE,COSTQUOTATION.MAINRATE ) GROUP BY SENDCUSTOMERNAME,SENDTIME, PK_SENDWAYBILL,WEIGHT,COUNT) B  WHERE A.PROVINCE=B.PROVINCE AND A.SENDCUSTOMERNAME =B.SENDCUSTOMERNAME AND A.SENDTIME=B.SENDTIME AND  A.PK_SENDWAYBILL = B.PK_SENDWAYBILL AND A.WEIGHT = B.WEIGHT AND  A.COUNT =B.COUNT
                                        )  GROUP BY  SENDCUSTOMERNAME ,(YEAR(SENDTIME) & '-' &  MONTH(SENDTIME))) SENDWAY   LEFT JOIN RETURNMONEY RETURNM
                                        ON SENDWAY.SENDCUSTOMERNAME = RETURNM.CUSTOMERNAME             
                                        AND YEAR(SENDWAY.SENDTIME) = YEAR(RETURNM.STATEMENTDATE)                            
                                        AND  MONTH(SENDWAY.SENDTIME)= MONTH(RETURNM.STATEMENTDATE))  " + where;
            if (arrayList.Count > 0)
                dt = oledbHelper.GetDataTable(sql, (string[])arrayList.ToArray(typeof(string)));
            else
                dt = oledbHelper.GetDataTable(sql);

            return dt;
        }
    }
}
