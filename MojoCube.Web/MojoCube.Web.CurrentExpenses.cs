using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;

namespace MojoCube.Web.CurrentExpenses
{


    public class Expenses
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _IETYPE;

        public string IETYPE
        {
            get { return _IETYPE; }
            set { _IETYPE = value; }
        }
        private string _CostItem;

        public string CostItem
        {
            get { return _CostItem; }
            set { _CostItem = value; }
        }
        private string _Column1;

        public string Column1
        {
            get { return _Column1; }
            set { _Column1 = value; }
        }
        private string _Column2;

        public string Column2
        {
            get { return _Column2; }
            set { _Column2 = value; }
        }
        private string _Column3;

        public string Column3
        {
            get { return _Column3; }
            set { _Column3 = value; }
        }
        private DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        private string _AccountType;

        public string AccountType
        {
            get { return _AccountType; }
            set { _AccountType = value; }
        }

        public Expenses()
        {
            _Column1 = string.Empty;
            _Column2 = string.Empty;
            _Column3 = string.Empty;
            _AccountType = string.Empty;
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Current_Expenses where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this._IETYPE = oleDbDataReader["IETYPE"].ToString();
                    this._CostItem = oleDbDataReader["CostItem"].ToString();
                    this._Column1 = oleDbDataReader["Column1"].ToString();
                    this._Column2 = oleDbDataReader["Column2"].ToString();
                    this._Column3 = oleDbDataReader["Column3"].ToString();
                    this._CreateDate = Convert.ToDateTime(oleDbDataReader["CreateDate"].ToString());
                    this._AccountType = oleDbDataReader["AccountType"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Current_Expenses(IETYPE,CostItem,Column1,Column2,Column3,CreateDate,AccountType) values (@IETYPE,@CostItem,@Column1,@Column2,@Column3,@CreateDate,@AccountType) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IETYPE", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@IETYPE"].Value = this._IETYPE;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CostItem", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CostItem"].Value = this._CostItem;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Column1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column1"].Value = this._Column1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Column2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column2"].Value = this._Column2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Column3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column3"].Value = this._Column3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AccountType", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@AccountType"].Value = this._AccountType;
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

        public bool CheckExists()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            bool result = false;
            try
            {
                oleDbConnection.Open();
                string cmdText = "SELECT COUNT(*) FROM Current_Expenses WHERE IETYPE=@IETYPE AND CostItem=@CostItem AND Column1=@Column1 AND Column2=@Column2 AND Column3=@Column3 AND CreateDate=@CreateDate";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IETYPE", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@IETYPE"].Value = this._IETYPE;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CostItem", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CostItem"].Value = this._CostItem;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Column1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column1"].Value = this._Column1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Column2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column2"].Value = this._Column2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Column3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column3"].Value = this._Column3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar()) > 0;
            }
            catch
            {
                result = false;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Current_Expenses set IETYPE=@IETYPE,CostItem=@CostItem,Column1=@Column1,Column2=@Column2,Column3=@Column3,CreateDate=@CreateDate,AccountType=@AccountType where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IETYPE", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@IETYPE"].Value = this._IETYPE;

                oleDbCommand.Parameters.Add(new OleDbParameter("@CostItem", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CostItem"].Value = this._CostItem;

                oleDbCommand.Parameters.Add(new OleDbParameter("@Column1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column1"].Value = this._Column1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@Column2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column2"].Value = this._Column2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@Column3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Column3"].Value = this._Column3;

                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;

                oleDbCommand.Parameters.Add(new OleDbParameter("@AccountType", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@AccountType"].Value = this._AccountType;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = this._ID;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Current_Expenses where ID=" + id);
        }
    }


    public class Offer
    {
        private int _ID;

        private string _CustomerName;

        private string _Destination;

        private string _FirstWeight;

        private string _FirstWeightPrice;

        private string _HeavyWeight;

        private string _HeavyWeightPrice;

        private string _Weight1;

        private string _Weight2;

        private DateTime _CreateDate;

        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this._CustomerName = value;
            }
        }

        public string Destination
        {
            get
            {
                return this._Destination;
            }
            set
            {
                this._Destination = value;
            }
        }

        public string FirstWeight
        {
            get
            {
                return this._FirstWeight;
            }
            set
            {
                this._FirstWeight = value;
            }
        }

        public string FirstWeightPrice
        {
            get
            {
                return this._FirstWeightPrice;
            }
            set
            {
                this._FirstWeightPrice = value;
            }
        }

        public string HeavyWeight
        {
            get
            {
                return this._HeavyWeight;
            }
            set
            {
                this._HeavyWeight = value;
            }
        }

        public string HeavyWeightPrice
        {
            get
            {
                return this._HeavyWeightPrice;
            }
            set
            {
                this._HeavyWeightPrice = value;
            }
        }

        public string Weight1
        {
            get
            {
                return this._Weight1;
            }
            set
            {
                this._Weight1 = value;
            }
        }

        public string Weight2
        {
            get
            {
                return this._Weight2;
            }
            set
            {
                this._Weight2 = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this._CreateDate = value;
            }
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from CustomerOffer where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this._CustomerName = oleDbDataReader["CustomerName"].ToString();
                    this._Destination = oleDbDataReader["Destination"].ToString();
                    this._FirstWeight = oleDbDataReader["FirstWeight"].ToString();
                    this._FirstWeightPrice = oleDbDataReader["FirstWeightPrice"].ToString();

                    this._HeavyWeightPrice = oleDbDataReader["HeavyWeightPrice"].ToString();
                    this._Weight1 = oleDbDataReader["Weight1"].ToString();
                    this._Weight2 = oleDbDataReader["Weight2"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetDataByCustPro(string customername, string province, string weight)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select top 1 * from CustomerOffer where CustomerName=@CustomerName and Destination=@Destination and CDbl(Weight1)<=@weight and CDbl(Weight2)>=@weight";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CustomerName", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CustomerName"].Value = CustomerName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Destination", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Destination"].Value = Destination;
                oleDbCommand.Parameters.Add(new OleDbParameter("@weight", OleDbType.Double));
                oleDbCommand.Parameters["@weight"].Value = Convert.ToDouble(weight);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this._CustomerName = oleDbDataReader["CustomerName"].ToString();
                    this._Destination = oleDbDataReader["Destination"].ToString();
                    this._FirstWeight = oleDbDataReader["FirstWeight"].ToString();
                    this._FirstWeightPrice = oleDbDataReader["FirstWeightPrice"].ToString();
                    //this._HeavyWeight = oleDbDataReader["HeavyWeight"].ToString();
                    this._HeavyWeightPrice = oleDbDataReader["HeavyWeightPrice"].ToString();
                }

            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into CustomerOffer(CustomerName,Destination,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2) values (@CustomerName,@Destination,@FirstWeight,@FirstWeightPrice,@HeavyWeightPrice,@Weight1,@Weight2) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CustomerName", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CustomerName"].Value = this._CustomerName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Destination", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Destination"].Value = this._Destination;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FirstWeight", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@FirstWeight"].Value = this._FirstWeight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FirstWeightPrice", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@FirstWeightPrice"].Value = this._FirstWeightPrice;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@HeavyWeight", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@HeavyWeight"].Value = this._HeavyWeight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@HeavyWeightPrice", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@HeavyWeightPrice"].Value = this._HeavyWeightPrice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Weight1"].Value = this._Weight1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Weight2"].Value = this._Weight2;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update CustomerOffer set CustomerName=@CustomerName,Destination=@Destination,FirstWeight=@FirstWeight,FirstWeightPrice=@FirstWeightPrice,Weight1=@Weight1,Weight2=@Weight2,HeavyWeightPrice=@HeavyWeightPrice where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CustomerName", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CustomerName"].Value = this._CustomerName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Destination", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Destination"].Value = this._Destination;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FirstWeight", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@FirstWeight"].Value = this._FirstWeight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FirstWeightPrice", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@FirstWeightPrice"].Value = this._FirstWeightPrice;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@HeavyWeight", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@HeavyWeight"].Value = this._HeavyWeight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@HeavyWeightPrice", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@HeavyWeightPrice"].Value = this._HeavyWeightPrice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Weight1"].Value = this._Weight1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Weight2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@Weight2"].Value = this._Weight2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from CustomerOffer where ID=" + id);
        }

        public void DeleteDetailData(string customer, string FirstWeight, string FirstWeightPrice, string HeavyWeightPrice, string Weight1, string Weight2)
        {
            Sql.SqlQuery("delete from CustomerOffer where CustomerName=  '" + customer.Trim() + "' and FirstWeight=  '" + FirstWeight.Trim() + "'and FirstWeightPrice=  '" + FirstWeightPrice.Trim() + "' and HeavyWeightPrice=  '" + HeavyWeightPrice.Trim() + "' and Weight1=  '" + Weight1.Trim() + "' and Weight2=  '" + Weight2.Trim() + "'");
        }
    }

    public class PayList
    {
        private int _ID;

        private string _Name;

        private string _BasePay;

        private string _Yieldradio;

        private string _Unitprice;

        private DateTime _CreateDate;

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public string BasePay
        {
            get
            {
                return this._BasePay;
            }
            set
            {
                this._BasePay = value;
            }
        }

        public string Yieldradio
        {
            get
            {
                return this._Yieldradio;
            }
            set
            {
                this._Yieldradio = value;
            }
        }

        public string Unitprice
        {
            get
            {
                return this._Unitprice;
            }
            set
            {
                this._Unitprice = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this._CreateDate = value;
            }
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from PayList where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this._Name = oleDbDataReader["name"].ToString();
                    this._BasePay = oleDbDataReader["basepay"].ToString();
                    this._Yieldradio = oleDbDataReader["yieldradio"].ToString();
                    this._Unitprice = oleDbDataReader["unitprice"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into PayList(name,basepay,yieldradio,unitprice,CreateDate) values (@name,@basepay,@yieldradio,@unitprice,@CreateDate) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@name"].Value = this._Name;
                oleDbCommand.Parameters.Add(new OleDbParameter("@basepay", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@basepay"].Value = this._BasePay;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yieldradio", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yieldradio"].Value = this._Yieldradio;
                oleDbCommand.Parameters.Add(new OleDbParameter("@unitprice", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@unitprice"].Value = this._Unitprice;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CreateDate"].Value = System.DateTime.Now;

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

        public void UpdateData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update PayList set basepay=@basepay,yieldradio=@yieldradio,unitprice=@unitprice where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@basepay", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@basepay"].Value = this._BasePay;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yieldradio", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yieldradio"].Value = this._Yieldradio;
                oleDbCommand.Parameters.Add(new OleDbParameter("@unitprice", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@unitprice"].Value = this._Unitprice;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int ID)
        {
            Sql.SqlQuery("delete from PayList where ID=" + ID);
        }
    }

    public class CostQuotationList
    {
        private string _PKID;

        private string _province;

        private string _CostQuotation;

        private string _subrate;

        private string _mainrate;


        public string province
        {
            get
            {
                return this._province;
            }
            set
            {
                this._province = value;
            }
        }

        public string CostQuotation
        {
            get
            {
                return this._CostQuotation;
            }
            set
            {
                this._CostQuotation = value;
            }
        }

        public string subrate
        {
            get
            {
                return this._subrate;
            }
            set
            {
                this._subrate = value;
            }
        }

        public string mainrate
        {
            get
            {
                return this._mainrate;
            }
            set
            {
                this._mainrate = value;
            }
        }

        public string PKID
        {
            get
            {
                return this._PKID;
            }
            set
            {
                this._PKID = value;
            }
        }

        public List<CostQuotationList> GetCostQuotation()
        {
            List<CostQuotationList> costQuotations = new List<CostQuotationList>();
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from CostQuotation";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();

                while (oleDbDataReader.Read())
                {
                    CostQuotationList item = new CostQuotationList();
                    item._PKID = oleDbDataReader["PKID"].ToString();
                    item._province = oleDbDataReader["province"].ToString();
                    item._CostQuotation = oleDbDataReader["CostQuotation"].ToString();
                    item._subrate = oleDbDataReader["subrate"].ToString();
                    item._mainrate = oleDbDataReader["mainrate"].ToString();
                    costQuotations.Add(item);
                }

                return costQuotations;
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetData(string PKID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from CostQuotation where PKID =@PKID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@PKID", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@PKID"].Value = PKID;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._PKID = oleDbDataReader["PKID"].ToString();
                    this._province = oleDbDataReader["province"].ToString();
                    this._CostQuotation = oleDbDataReader["CostQuotation"].ToString();
                    this._subrate = oleDbDataReader["subrate"].ToString();
                    this._mainrate = oleDbDataReader["mainrate"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void UpdateData(string PKID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update CostQuotation set CostQuotation=@CostQuotation,subrate=@subrate,mainrate=@mainrate where PKID =@PKID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@CostQuotation", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@CostQuotation"].Value = this._CostQuotation;
                oleDbCommand.Parameters.Add(new OleDbParameter("@subrate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@subrate"].Value = this._subrate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@mainrate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@mainrate"].Value = this._mainrate;

                oleDbCommand.Parameters.Add(new OleDbParameter("@PKID", OleDbType.Integer));
                oleDbCommand.Parameters["@PKID"].Value = PKID;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

    }

    public class AccountSumList
    {

        private string _column1;

        private string _column2;

        private string _column3;

        private string _column4;


        public string column1
        {
            get
            {
                return this._column1;
            }
            set
            {
                this._column1 = value;
            }
        }

        public string column2
        {
            get
            {
                return this._column2;
            }
            set
            {
                this._column2 = value;
            }
        }

        public string column3
        {
            get
            {
                return this._column3;
            }
            set
            {
                this._column3 = value;
            }
        }

        public string column4
        {
            get
            {
                return this._column4;
            }
            set
            {
                this._column4 = value;
            }
        }

        public void GetData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from AccountSum ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._column1 = oleDbDataReader["column1"].ToString();
                    this._column2 = oleDbDataReader["column2"].ToString();
                    this._column3 = oleDbDataReader["column3"].ToString();
                    this._column4 = oleDbDataReader["column4"].ToString();
                   
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData()
        {
            Sql.SqlQuery("delete from AccountSum ");
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into AccountSum(column1,column2,column3,column4) values (@column1,@column2,@column3,@column4) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@column1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@column1"].Value = this._column1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@column2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@column2"].Value = this._column2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@column3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@column3"].Value = this._column3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@column4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@column4"].Value = this._column4;
                
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


    }


    public class guigeList
    {
        public int ID { set; get; }
        public string guige { set; get; }
        public string col2 { set; get; }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_guige  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetData2(string guige)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_guige  where guige =@guige ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from tb_guige where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into tb_guige(guige,col2) values (@guige,@col2) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update tb_guige set guige=@guige,col2=@col2 where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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


    }


    public class xiangmujingliList
    {
        public int ID { set; get; }
        public string guige { set; get; }
        public string col2 { set; get; }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmujingli  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetData2(string str1, string str2)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmujingli  where guige=@guige and col2=@col2 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

       
        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_xiangmujingli where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into t_xiangmujingli(guige,col2) values (@guige,@col2) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                
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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update t_xiangmujingli set guige=@guige,col2=@col2 where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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


    }

    public class pinzhongList
    {
        private int _ID;
        private string _pinzhong;

        private string _shiyongbiaoji;

        private string _remark;

        private string _xiechefei;

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }


        public string pinzhong
        {
            get
            {
                return this._pinzhong;
            }
            set
            {
                this._pinzhong = value;
            }
        }

        public string shiyongbiaoji
        {
            get
            {
                return this._shiyongbiaoji;
            }
            set
            {
                this._shiyongbiaoji = value;
            }
        }

        public string remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        public string xiechefei
        {
            get
            {
                return this._xiechefei;
            }
            set
            {
                this._xiechefei = value;
            }
        }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_pinzhong  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this._pinzhong = oleDbDataReader["pinming"].ToString();
                    this._shiyongbiaoji = oleDbDataReader["shiyongbiaoji"].ToString();
                    this._remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_pinzhong ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this._pinzhong = oleDbDataReader["guige"].ToString();
                    this._shiyongbiaoji = oleDbDataReader["shiyongbiaoji"].ToString();
                    this._remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from tb_pinzhong where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into tb_pinzhong(pinming,remark) values (@pinzhong,@remark) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pinming", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@pinming"].Value = this._pinzhong;
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this._remark;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update tb_pinzhong set pinming=@pinming,remark=@remark where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@pinming", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@pinming"].Value = this._pinzhong;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this._remark;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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


    }

    public class yewustyleList
    {
        public int ID { set; get; }
        public string guige { set; get; }


        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_yewustyle  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_yewustyle ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from tb_yewustyle where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into tb_yewustyle(guige) values (@guige) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update tb_yewustyle set guige=@guige where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
                oleDbCommand.ExecuteNonQuery();
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


    }

    public class companyList
    {
        private int _ID;
        private string _companyname;

        private string _remark;

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }


        public string guige
        {
            get
            {
                return this._companyname;
            }
            set
            {
                this._companyname = value;
            }
        }

        public string remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }


        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_company  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this._companyname = oleDbDataReader["companyname"].ToString();
                    this._remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from tb_company ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this._companyname = oleDbDataReader["companyname"].ToString();
                    this._remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from tb_company ");
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into tb_company(companyname,remark) values (@companyname,@remark) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@companyname", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@companyname"].Value = this._companyname;
 
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this._remark;

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

        public int UpdateData()
        {
            int result;
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update tb_company set companyname=@companyname,remark=@remark where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@companyname", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@companyname"].Value = this._companyname;

                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this._remark;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
                oleDbCommand.ExecuteNonQuery();
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }


    }

    public class minzuList
    {
        public int ID { set; get; }
        public string guige { set; get; }


        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from minzu  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                   

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from minzu ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from minzu where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into minzu(guige) values (@guige) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

         

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update minzu set guige=@guige where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
                oleDbCommand.ExecuteNonQuery();
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


    }

    public class zhuanyeList
    {
        public int ID { set; get; }
        public string guige { set; get; }


        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from zhuanye  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();


                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from zhuanye ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from zhuanye where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into zhuanye(guige) values (@guige) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;



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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update zhuanye set guige=@guige where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
                oleDbCommand.ExecuteNonQuery();
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


    }


    public class messageList
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from te_message  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from te_message ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();


                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from te_message where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into kaoshi(col1,col2) values (@ziliaoname,@col2) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update te_message set col1=@col1,col2=@col2 where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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




    }

    public class PBLList
    {
        public int ID { set; get; }
        public string guige { set; get; }
        public string remark{ set; get; }


        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from PBL  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from PBL ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.guige = oleDbDataReader["guige"].ToString();
                    this.remark = oleDbDataReader["remark"].ToString();


                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from PBL where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into kaoshi(guige,remark) values (@guige,@remark) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update PBL set guige=@guige,remark=@remark where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@guige", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@guige"].Value = this.guige;

                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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




    }

    public class 
        
        companyzsList
    {
        public int ID { set; get; }
        public string style { set; get; }
        public string zsname { set; get; }
        public string zsno { set; get; }
        public string jiguan { set; get; }
        public DateTime fazdate { set; get; }
        public DateTime daqidate { set; get; }
        public string youxiaodate { set; get; }
        public string weizhi { set; get; }
        public string remark { set; get; }


        public string CheckUploadResult { set; get; }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from companyzs  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.style = oleDbDataReader["style"].ToString();
                    this.zsname = oleDbDataReader["zsname"].ToString();
                    this.zsno = oleDbDataReader["zsno"].ToString();
                    this.jiguan = oleDbDataReader["jiguan"].ToString();
                    this.fazdate = Convert.ToDateTime(oleDbDataReader["fazdate"].ToString());
                    this.daqidate = Convert.ToDateTime(oleDbDataReader["daqidate"].ToString());
                    this.youxiaodate = oleDbDataReader["youxiaodate"].ToString();
                    this.weizhi = oleDbDataReader["weizhi"].ToString();
                    this.remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from companyzs ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.style = oleDbDataReader["style"].ToString();
                    this.zsname = oleDbDataReader["zsname"].ToString();
                    this.zsno = oleDbDataReader["zsno"].ToString();
                    this.jiguan = oleDbDataReader["jiguan"].ToString();
                    this.fazdate = Convert.ToDateTime(oleDbDataReader["fazdate"].ToString());
                    this.daqidate = Convert.ToDateTime(oleDbDataReader["daqidate"].ToString());
                    this.youxiaodate = oleDbDataReader["youxiaodate"].ToString();
                    this.weizhi = oleDbDataReader["weizhi"].ToString();
                    this.remark = oleDbDataReader["remark"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from companyzs where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into companyzs(style,zsname,zsno,jiguan,fazdate,daqidate,youxiaodate,weizhi,remark) values (@style,@zsname,@zsno,@jiguan,@fazdate,@daqidate,@youxiaodate,@weizhi,@remark) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@style", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@style"].Value = this.style;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zsname", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zsname"].Value = this.zsname;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zsno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zsno"].Value = this.zsno;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jiguan", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jiguan"].Value = this.jiguan;

                oleDbCommand.Parameters.Add(new OleDbParameter("@fazdate", OleDbType.Date));
                oleDbCommand.Parameters["@fazdate"].Value = this.fazdate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@daqidate", OleDbType.Date));
                oleDbCommand.Parameters["@daqidate"].Value = this.daqidate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@youxiaodate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@youxiaodate"].Value = this.youxiaodate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@weizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@weizhi"].Value = this.weizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "update companyzs set style=@style,zsname=@zsname,zsno=@zsno,jiguan=@jiguan,fazdate=@fazdate,daqidate=@daqidate,youxiaodate=@youxiaodate,weizhi=@weizhi,remark=@remark where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@style", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@style"].Value = this.style;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zsname", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zsname"].Value = this.zsname;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zsno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zsno"].Value = this.zsno;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jiguan", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jiguan"].Value = this.jiguan;

                oleDbCommand.Parameters.Add(new OleDbParameter("@fazdate", OleDbType.Date));
                oleDbCommand.Parameters["@fazdate"].Value = this.fazdate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@daqidate", OleDbType.Date));
                oleDbCommand.Parameters["@daqidate"].Value = this.daqidate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@youxiaodate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@youxiaodate"].Value = this.youxiaodate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@weizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@weizhi"].Value = this.weizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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




    }

    public class yuangongzsList
    {
        public int ID { set; get; }
        public string zhousi { set; get; }
        public string xiangmu { set; get; }
        public string zhiwu { set; get; }
        public string name { set; get; }
        public string minzu { set; get; }
        public string sno { set; get; }
        public string sdate { set; get; }
        public string nianli { set; get; }
        public string address { set; get; }
        public string sex { set; get; }
        public string youxiaodate { set; get; }
        public string shenfenweizhi { set; get; }

        public string school { set; get; }
        public string zhuanye { set; get; }
        public string xueli { set; get; }
        public string biyedate { set; get; }
        public string xueliflag { set; get; }
        public string yuanjianflag { set; get; }
        public string xueliweizhi { set; get; }

        public string hetongcol1 { set; get; }
        public string hetongcol2 { set; get; }
        public string hetongcol3 { set; get; }
        public string hetongcol4 { set; get; }
        public string hetongcol5 { set; get; }
        public string hetongcol6 { set; get; }
        public string hetongcol7 { set; get; }
        public string hetongweizhi { set; get; }

        public string txcol1 { set; get; }
        public string txcol2 { set; get; }
        public string txcol3 { set; get; }
        public string txcol4 { set; get; }
        public string txcol5 { set; get; }
        public string txcol6 { set; get; }
        public string txcol7 { set; get; }
        public string txcol8 { set; get; }
        public string ABCweizhi { set; get; }

        public string txzccol1 { set; get; }
        public string txzccol2 { set; get; }
        public string txzccol3 { set; get; }
        public string txzccol4 { set; get; }
        public string txzccol5 { set; get; }
        public string txzccol6 { set; get; }
        public string txzccol7 { set; get; }
        public string txzccol8 { set; get; }
        public string zhichengweizhi { set; get; }

        public string txyscol1 { set; get; }
        public string txyscol2 { set; get; }
        public string txyscol3 { set; get; }
        public string txyscol4 { set; get; }
        public string txyscol5 { set; get; }
        public string txyscol6 { set; get; }
        public string txyscol7 { set; get; }
        public string txyscol8 { set; get; }
        public string yusuanweizhi { set; get; }

        public string jzABCcol1 { set; get; }
        public string jzABCcol2 { set; get; }
        public string jzABCcol3 { set; get; }
        public string jzABCcol4 { set; get; }
        public string jzABCcol5 { set; get; }
        public string jzABCcol6 { set; get; }
        public string jzABCcol7 { set; get; }
        public string jzABCcol8 { set; get; }
        public string jianzhuABCweizhi { set; get; }

        public string yijicol1 { set; get; }
        public string yijicol2 { set; get; }
        public string yijicol3 { set; get; }
        public string yijicol4 { set; get; }
        public string yijicol5 { set; get; }
        public string yijicol6 { set; get; }
        public string yijicol7 { set; get; }
        public string yijicol8 { set; get; }
        public string yijizsweizhi { set; get; }

        public string erjicol1 { set; get; }
        public string erjicol2 { set; get; }
        public string erjicol3 { set; get; }
        public string erjicol4 { set; get; }
        public string erjicol5 { set; get; }
        public string erjicol6 { set; get; }
        public string erjicol7 { set; get; }
        public string erjicol8 { set; get; }
        public string erjizsweizhi { set; get; }

        public string jzzccol1 { set; get; }
        public string jzzccol2 { set; get; }
        public string jzzccol3 { set; get; }
        public string jzzccol4 { set; get; }
        public string jzzccol5 { set; get; }
        public string jzzccol6 { set; get; }
        public string jzzccol7 { set; get; }
        public string jzzccol8 { set; get; }
        public string jzzccol9 { set; get; }

        public string jzjscol1 { set; get; }
        public string jzjscol2 { set; get; }
        public string jzjscol3 { set; get; }
        public string jzjscol4 { set; get; }
        public string jzjscol5 { set; get; }
        public string jzjscol6 { set; get; }
        public string jzjscol7 { set; get; }
        public string jzjscol8 { set; get; }
        public string jzjscol9 { set; get; }

        public string txjscol1 { set; get; }
        public string txjscol2 { set; get; }
        public string txjscol3 { set; get; }
        public string txjscol4 { set; get; }
        public string txjscol5 { set; get; }
        public string txjscol6 { set; get; }
        public string txjscol7 { set; get; }
        public string txjscol8 { set; get; }
        public string txjscol9 { set; get; }

        public string tzzycol1 { set; get; }
        public string tzzycol2 { set; get; }
        public string tzzycol3 { set; get; }
        public string tzzycol4 { set; get; }
        public string tzzycol5 { set; get; }
        public string tzzycol6 { set; get; }
        public string tzzycol7 { set; get; }
        public string tzzycol8 { set; get; }
        public string tzzycol9 { set; get; }

        public string remark { set; get; }
        
        public string col1 { set; get; }
       
        public string col2 { set; get; }
        
        public string col3 { set; get; }
       
        public string col4 { set; get; }
       
        public string col5 { set; get; }
        public string hunyin { set; get; }
        public string zhengzhi { set; get; }
        public string ImagePath1 { set; get; }

        public string CheckUploadResult { set; get; }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from yuangongzs  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.zhousi = oleDbDataReader["zhousi"].ToString();
                    this.xiangmu = oleDbDataReader["xiangmu"].ToString();
                    this.zhiwu = oleDbDataReader["zhiwu"].ToString();
                    this.name = oleDbDataReader["name"].ToString();
                    this.minzu = oleDbDataReader["minzu"].ToString();
                    this.sno = oleDbDataReader["sno"].ToString();
                    this.nianli = oleDbDataReader["nianli"].ToString();
                    this.sdate = oleDbDataReader["sdate"].ToString();
                    
                    this.address = oleDbDataReader["address"].ToString();
                    this.sex = oleDbDataReader["sex"].ToString();
                    this.minzu = oleDbDataReader["minzu"].ToString();
                    this.shenfenweizhi = oleDbDataReader["shenfenweizhi"].ToString();
                    this.youxiaodate = oleDbDataReader["youxiaodate"].ToString();

                    this.school = oleDbDataReader["school"].ToString();
                    this.zhuanye = oleDbDataReader["zhuanye"].ToString();
                    this.xueli = oleDbDataReader["xueli"].ToString();
                    this.biyedate = oleDbDataReader["biyedate"].ToString();
                    
                    this.xueliflag = oleDbDataReader["school"].ToString();
                    this.yuanjianflag = oleDbDataReader["yuanjianflag"].ToString();
                    this.xueliweizhi = oleDbDataReader["xueliweizhi"].ToString();
                    this.hetongcol1 = oleDbDataReader["hetongcol1"].ToString();
                   
                    this.hetongcol2 = oleDbDataReader["hetongcol2"].ToString();
                    this.hetongcol3 = oleDbDataReader["hetongcol3"].ToString();
                    this.hetongcol4 = oleDbDataReader["hetongcol4"].ToString();
                    
                    this.hetongcol5 = oleDbDataReader["hetongcol5"].ToString();
                    this.hetongcol6 = oleDbDataReader["hetongcol6"].ToString();
                    this.hetongcol7 = oleDbDataReader["hetongcol7"].ToString();
                    this.hetongweizhi = oleDbDataReader["hetongweizhi"].ToString();

                    this.txcol1 = oleDbDataReader["txcol1"].ToString();
                    this.txcol2 = oleDbDataReader["txcol2"].ToString();
                    this.txcol3 = oleDbDataReader["txcol3"].ToString();
                    this.txcol5 = oleDbDataReader["txcol5"].ToString();
                   
                    this.txcol4 = oleDbDataReader["txcol4"].ToString();
                   
                    this.txcol6 = oleDbDataReader["txcol6"].ToString();
                    this.txcol7 = oleDbDataReader["txcol7"].ToString();
                    this.txcol8 = oleDbDataReader["txcol8"].ToString();
                    this.ABCweizhi = oleDbDataReader["ABCweizhi"].ToString();

                    this.txzccol1 = oleDbDataReader["txzccol1"].ToString();
                    this.txzccol2 = oleDbDataReader["txzccol2"].ToString();
                    this.txzccol3 = oleDbDataReader["txzccol3"].ToString();
                    this.txzccol5 = oleDbDataReader["txzccol5"].ToString();
                    
                    this.txzccol4 = oleDbDataReader["txzccol4"].ToString();
                    
                    this.txzccol6 = oleDbDataReader["txzccol6"].ToString();
                    this.txzccol7 = oleDbDataReader["txzccol7"].ToString();
                    this.txzccol8 = oleDbDataReader["txzccol8"].ToString();
                    this.zhichengweizhi = oleDbDataReader["zhichengweizhi"].ToString();

                    this.txyscol1 = oleDbDataReader["txyscol1"].ToString();
                    this.txyscol2 = oleDbDataReader["txyscol2"].ToString();
                    this.txyscol3 = oleDbDataReader["txyscol3"].ToString();
                    this.txyscol5 = oleDbDataReader["txyscol5"].ToString();

                    this.txyscol4 = oleDbDataReader["txyscol4"].ToString();

                    this.txyscol6 = oleDbDataReader["txyscol6"].ToString();
                    this.txyscol7 = oleDbDataReader["txyscol7"].ToString();
                    this.txyscol8 = oleDbDataReader["txyscol8"].ToString();
                    this.yusuanweizhi = oleDbDataReader["yusuanweizhi"].ToString();

                    this.jzABCcol1 = oleDbDataReader["jzABCcol1"].ToString();
                    this.jzABCcol2 = oleDbDataReader["jzABCcol2"].ToString();
                    this.jzABCcol3 = oleDbDataReader["jzABCcol3"].ToString();
                    this.jzABCcol5 = oleDbDataReader["jzABCcol5"].ToString();

                    this.jzABCcol4 = oleDbDataReader["jzABCcol4"].ToString();
                   
                    this.jzABCcol6 = oleDbDataReader["jzABCcol6"].ToString();
                    this.jzABCcol7 = oleDbDataReader["jzABCcol7"].ToString();
                    this.jzABCcol8 = oleDbDataReader["jzABCcol8"].ToString();
                    this.jianzhuABCweizhi = oleDbDataReader["jianzhuABCweizhi"].ToString();

                    this.yijicol1 = oleDbDataReader["yijicol1"].ToString();
                    this.yijicol2 = oleDbDataReader["yijicol2"].ToString();
                    this.yijicol3 = oleDbDataReader["yijicol3"].ToString();
                    this.yijicol5 = oleDbDataReader["yijicol5"].ToString();

                    this.yijicol4 = oleDbDataReader["yijicol4"].ToString();

                    this.yijicol6 = oleDbDataReader["yijicol6"].ToString();
                    this.yijicol7 = oleDbDataReader["yijicol7"].ToString();
                    this.yijicol8 = oleDbDataReader["yijicol8"].ToString();
                    this.yijizsweizhi = oleDbDataReader["yijizsweizhi"].ToString();

                    this.erjicol1 = oleDbDataReader["erjicol1"].ToString();
                    this.erjicol2 = oleDbDataReader["erjicol2"].ToString();
                    this.erjicol3 = oleDbDataReader["erjicol3"].ToString();
                    this.erjicol5 = oleDbDataReader["erjicol5"].ToString();

                    this.erjicol4 = oleDbDataReader["erjicol4"].ToString();

                    this.erjicol6 = oleDbDataReader["erjicol6"].ToString();
                    this.erjicol7 = oleDbDataReader["erjicol7"].ToString();
                    this.erjicol8 = oleDbDataReader["erjicol8"].ToString();
                    this.erjizsweizhi = oleDbDataReader["erjizsweizhi"].ToString();

                    this.jzjscol1 = oleDbDataReader["jzjscol1"].ToString();
                    this.jzjscol2 = oleDbDataReader["jzjscol2"].ToString();
                    this.jzjscol3 = oleDbDataReader["jzjscol3"].ToString();
                    this.jzjscol5 = oleDbDataReader["jzjscol5"].ToString();

                    this.jzjscol4 = oleDbDataReader["jzjscol4"].ToString();

                    this.jzjscol6 = oleDbDataReader["jzjscol6"].ToString();
                    this.jzjscol7 = oleDbDataReader["jzjscol7"].ToString();
                    this.jzjscol8 = oleDbDataReader["jzjscol8"].ToString();
                    this.jzjscol9 = oleDbDataReader["jzjscol9"].ToString();

                    this.txjscol1 = oleDbDataReader["txjscol1"].ToString();
                    this.txjscol2 = oleDbDataReader["txjscol2"].ToString();
                    this.txjscol3 = oleDbDataReader["txjscol3"].ToString();
                    this.txjscol5 = oleDbDataReader["txjscol5"].ToString();

                    this.txjscol4 = oleDbDataReader["txjscol4"].ToString();

                    this.txjscol6 = oleDbDataReader["txjscol6"].ToString();
                    this.txjscol7 = oleDbDataReader["txjscol7"].ToString();
                    this.txjscol8 = oleDbDataReader["txjscol8"].ToString();
                    this.txjscol9 = oleDbDataReader["txjscol9"].ToString();

                    this.tzzycol1 = oleDbDataReader["tzzycol1"].ToString();
                    this.tzzycol2 = oleDbDataReader["tzzycol2"].ToString();
                    this.tzzycol3 = oleDbDataReader["tzzycol3"].ToString();
                    this.tzzycol5 = oleDbDataReader["tzzycol5"].ToString();

                    this.tzzycol4 = oleDbDataReader["tzzycol4"].ToString();

                    this.tzzycol6 = oleDbDataReader["tzzycol6"].ToString();
                    this.tzzycol7 = oleDbDataReader["tzzycol7"].ToString();
                    this.tzzycol8 = oleDbDataReader["tzzycol8"].ToString();
                    this.tzzycol9 = oleDbDataReader["tzzycol9"].ToString();

                    this.remark = oleDbDataReader["remark"].ToString();
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.hunyin = oleDbDataReader["hunyin"].ToString();
                    this.zhengzhi = oleDbDataReader["zhengzhi"].ToString();

                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from yuangongzs where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into yuangongzs( zhousi,xiangmu,zhiwu,[name],minzu,sno,sdate,nianli,address,sex,shenfenweizhi,youxiaodate,
                school,zhuanye,xueli,biyedate,xueliflag,yuanjianflag,xueliweizhi
,hetongcol1,hetongcol2,hetongcol3,hetongcol4,hetongcol5,hetongcol6,hetongcol7,hetongweizhi
,txcol1,txcol2,txcol3,txcol4,txcol5,txcol6,txcol7,txcol8,ABCweizhi
,txzccol1,txzccol2,txzccol3,txzccol4,txzccol5,txzccol6,txzccol7,txzccol8,zhichengweizhi
,txyscol1,txyscol2,txyscol3,txyscol4,txyscol5,txyscol6,txyscol7,txyscol8,yusuanweizhi
,jzABCcol1,jzABCcol2,jzABCcol3,jzABCcol4,jzABCcol5,jzABCcol6,jzABCcol7,jzABCcol8,jianzhuABCweizhi
,yijicol1,yijicol2,yijicol3,yijicol4,yijicol5,yijicol6,yijicol7,yijicol8,yijizsweizhi
,erjicol1,erjicol2,erjicol3,erjicol4,erjicol5,erjicol6,erjicol7,erjicol8,erjizsweizhi
,jzzccol1,jzzccol2,jzzccol3,jzzccol4,jzzccol5,jzzccol6,jzzccol7,jzzccol8,jzzccol9
,jzjscol1,jzjscol2,jzjscol3,jzjscol4,jzjscol5,jzjscol6,jzjscol7,jzjscol8,jzjscol9
,txjscol1,txjscol2,txjscol3,txjscol4,txjscol5,txjscol6,txjscol7,txjscol8,txjscol9
,tzzycol1,tzzycol2,tzzycol3,tzzycol4,tzzycol5,tzzycol6,tzzycol7,tzzycol8,tzzycol9
,remark,hunyin,zhengzhi,col1,col2,col3,col4,col5,ImagePath1

) 
                values ( @zhousi,@xiangmu,@zhiwu,@name,@minzu,@sno,@sdate,@nianli,@address,@sex,@shenfenweizhi ,@youxiaodate
,@school,@zhuanye,@xueli,@biyedate,@xueliflag,@yuanjianflag,@xueliweizhi
,@hetongcol1,@hetongcol2,@hetongcol3,@hetongcol4,@hetongcol5,@hetongcol6,@hetongcol7,@hetongweizhi
,@txcol1,@txcol2,@txcol3,@txcol4,@txcol5,@txcol6,@txcol7,@txcol8,@ABCweizhi
,@txzccol1,@txzccol2,@txzccol3,@txzccol4,@txzccol5,@txzccol6,@txzccol7,@txzccol8,@zhichengweizhi
,@txyscol1,@txyscol2,@txyscol3,@txyscol4,@txyscol5,@txyscol6,@txyscol7,@txyscol8,@yusuanweizhi
,@jzABCcol1,@jzABCcol2,@jzABCcol3,@jzABCcol4,@jzABCcol5,@jzABCcol6,@jzABCcol7,@jzABCcol8,@jianzhuABCweizhi
,@yijicol1,@yijicol2,@yijicol3,@yijicol4,@yijicol5,@yijicol6,@yijicol7,@yijicol8,@yijizsweizhi
,@erjicol1,@erjicol2,@erjicol3,@erjicol4,@erjicol5,@erjicol6,@erjicol7,@erjicol8,@erjizsweizhi
,@jzzccol1,@jzzccol2,@jzzccol3,@jzzccol4,@jzzccol5,@jzzccol6,@jzzccol7,@jzzccol8,@jzzccol9
,@jzjscol1,@jzjscol2,@jzjscol3,@jzjscol4,@jzjscol5,@jzjscol6,@jzjscol7,@jzjscol8,@jzjscol9
,@txjscol1,@txjscol2,@txjscol3,@txjscol4,@txjscol5,@txjscol6,@txjscol7,@txjscol8,@txjscol9
,@tzzycol1,@tzzycol2,@tzzycol3,@tzzycol4,@tzzycol5,@tzzycol6,@tzzycol7,@tzzycol8,@tzzycol9
,@remark,@hunyin,@zhengzhi,@col1,@col2,@col3,@col4,@col5,@ImagePath1

) ";

                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@zhousi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhousi"].Value = this.zhousi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xiangmu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xiangmu"].Value = this.xiangmu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhiwu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhiwu"].Value = this.zhiwu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@name"].Value = this.name;
                oleDbCommand.Parameters.Add(new OleDbParameter("@minzu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@minzu"].Value = this.minzu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@sno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@sno"].Value = this.sno;
                oleDbCommand.Parameters.Add(new OleDbParameter("@sdate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@sdate"].Value = this.sdate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@nianli", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@nianli"].Value = this.nianli;
                oleDbCommand.Parameters.Add(new OleDbParameter("@address", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@address"].Value = this.address;
                oleDbCommand.Parameters.Add(new OleDbParameter("@sex", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@sex"].Value = this.sex;
                oleDbCommand.Parameters.Add(new OleDbParameter("@shenfenweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@shenfenweizhi"].Value = this.shenfenweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@youxiaodate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@youxiaodate"].Value = this.youxiaodate;

                oleDbCommand.Parameters.Add(new OleDbParameter("@school", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@school"].Value = this.school;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhuanye", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhuanye"].Value = this.zhuanye;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xueli", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xueli"].Value = this.xueli;
                oleDbCommand.Parameters.Add(new OleDbParameter("@biyedate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@biyedate"].Value = this.biyedate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xueliflag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xueliflag"].Value = this.xueliflag;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yuanjianflag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yuanjianflag"].Value = this.yuanjianflag;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xueliweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xueliweizhi"].Value = this.xueliweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol1"].Value = this.hetongcol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol2"].Value = this.hetongcol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol3"].Value = this.hetongcol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol4"].Value = this.hetongcol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol5"].Value = this.hetongcol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol6"].Value = this.hetongcol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol7"].Value = this.hetongcol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongweizhi"].Value = this.hetongweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol1"].Value = this.txcol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol2"].Value = this.txcol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol3"].Value = this.txcol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol4"].Value = this.txcol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol5"].Value = this.txcol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol6"].Value = this.txcol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol7"].Value = this.txcol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol8"].Value = this.txcol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ABCweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@ABCweizhi"].Value = this.ABCweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol1"].Value = this.txzccol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol2"].Value = this.txzccol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol3"].Value = this.txzccol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol4"].Value = this.txzccol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol5"].Value = this.txzccol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol6"].Value = this.txzccol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol7"].Value = this.txzccol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol8"].Value = this.txzccol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhichengweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhichengweizhi"].Value = this.zhichengweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol1"].Value = this.txyscol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol2"].Value = this.txyscol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol3"].Value = this.txyscol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol4"].Value = this.txyscol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol5"].Value = this.txyscol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol6"].Value = this.txyscol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol7"].Value = this.txyscol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol8"].Value = this.txyscol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yusuanweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yusuanweizhi"].Value = this.yusuanweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol1"].Value = this.jzABCcol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol2"].Value = this.jzABCcol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol3"].Value = this.jzABCcol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol4"].Value = this.jzABCcol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol5"].Value = this.jzABCcol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol6"].Value = this.jzABCcol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol7"].Value = this.jzABCcol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol8"].Value = this.jzABCcol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jianzhuABCweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jianzhuABCweizhi"].Value = this.jianzhuABCweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol1"].Value = this.yijicol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol2"].Value = this.yijicol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol3"].Value = this.yijicol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol4"].Value = this.yijicol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol5"].Value = this.yijicol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol6"].Value = this.yijicol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol7"].Value = this.yijicol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol8"].Value = this.yijicol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijizsweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijizsweizhi"].Value = this.yijizsweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol1"].Value = this.erjicol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol2"].Value = this.erjicol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol3"].Value = this.erjicol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol4"].Value = this.erjicol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol5"].Value = this.erjicol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol6"].Value = this.erjicol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol7"].Value = this.erjicol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol8"].Value = this.erjicol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjizsweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjizsweizhi"].Value = this.erjizsweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol1"].Value = this.jzzccol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol2"].Value = this.jzzccol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol3"].Value = this.jzzccol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol4"].Value = this.jzzccol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol5"].Value = this.jzzccol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol6"].Value = this.jzzccol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol7"].Value = this.jzzccol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol8"].Value = this.jzzccol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol9"].Value = this.jzzccol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol1"].Value = this.jzjscol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol2"].Value = this.jzjscol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol3"].Value = this.jzjscol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol4"].Value = this.jzjscol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol5"].Value = this.jzjscol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol6"].Value = this.jzjscol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol7"].Value = this.jzjscol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol8"].Value = this.jzjscol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol9"].Value = this.jzjscol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol1"].Value = this.txjscol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol2"].Value = this.txjscol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol3"].Value = this.txjscol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol4"].Value = this.txjscol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol5"].Value = this.txjscol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol6"].Value = this.txjscol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol7"].Value = this.txjscol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol8"].Value = this.txjscol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol9"].Value = this.txjscol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol1"].Value = this.tzzycol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol2"].Value = this.tzzycol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol3"].Value = this.tzzycol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol4"].Value = this.tzzycol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol5"].Value = this.tzzycol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol6"].Value = this.tzzycol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol7"].Value = this.tzzycol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol8"].Value = this.tzzycol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol9"].Value = this.tzzycol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hunyin", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hunyin"].Value = this.hunyin;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhengzhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhengzhi"].Value = this.zhengzhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@ImagePath1"].Value = this.ImagePath1;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"update yuangongzs set zhousi=@zhousi,xiangmu=@xiangmu,zhiwu=@zhiwu,name=@name,minzu=@minzu,
sno=@sno,sdate=@sdate,nianli=@nianli,address=@address,sex=@sex,shenfenweizhi=@shenfenweizhi,youxiaodate=@youxiaodate
,school=@school,zhuanye=@zhuanye,xueli=@xueli,biyedate=@biyedate,xueliflag=@xueliflag,yuanjianflag=@yuanjianflag,xueliweizhi=@xueliweizhi
,hetongcol1=@hetongcol1,hetongcol2=@hetongcol2,hetongcol3=@hetongcol3,hetongcol4=@hetongcol4
,hetongcol5=@hetongcol5,hetongcol6=@hetongcol6,hetongcol7=@hetongcol7,hetongweizhi=@hetongweizhi
,txcol1=@txcol1,txcol2=@txcol2,txcol3=@txcol3,txcol4=@txcol4
,txcol5=@txcol5,txcol6=@txcol6,txcol7=@txcol7,txcol8=@txcol8,ABCweizhi=@ABCweizhi
,txzccol1=@txzccol1,txzccol2=@txzccol2,txzccol3=@txzccol3,txzccol4=@txzccol4
,txzccol5=@txzccol5,txzccol6=@txzccol6,txzccol7=@txzccol7,txzccol8=@txzccol8,zhichengweizhi=@zhichengweizhi
,txyscol1=@txyscol1,txyscol2=@txyscol2,txyscol3=@txyscol3,txyscol4=@txyscol4
,txyscol5=@txyscol5,txyscol6=@txyscol6,txyscol7=@txyscol7,txyscol8=@txyscol8,yusuanweizhi=@yusuanweizhi
,jzABCcol1=@jzABCcol1,jzABCcol2=@jzABCcol2,jzABCcol3=@jzABCcol3,jzABCcol4=@jzABCcol4
,jzABCcol5=@jzABCcol5,jzABCcol6=@jzABCcol6,jzABCcol7=@jzABCcol7,jzABCcol8=@jzABCcol8,jianzhuABCweizhi=@jianzhuABCweizhi
,yijicol1=@yijicol1,yijicol2=@yijicol2,yijicol3=@yijicol3,yijicol4=@yijicol4
,yijicol5=@yijicol5,yijicol6=@yijicol6,yijicol7=@yijicol7,yijicol8=@yijicol8,yijizsweizhi=@yijizsweizhi
,erjicol1=@erjicol1,erjicol2=@erjicol2,erjicol3=@erjicol3,erjicol4=@erjicol4
,erjicol5=@erjicol5,erjicol6=@erjicol6,erjicol7=@erjicol7,erjicol8=@erjicol8,erjizsweizhi=@erjizsweizhi
,jzzccol1=@jzzccol1,jzzccol2=@jzzccol2,jzzccol3=@jzzccol3,jzzccol4=@jzzccol4
,jzzccol5=@jzzccol5,jzzccol6=@jzzccol6,jzzccol7=@jzzccol7,jzzccol8=@jzzccol8,jzzccol9=@jzzccol9
,jzjscol1=@jzjscol1,jzjscol2=@jzjscol2,jzjscol3=@jzjscol3,jzjscol4=@jzjscol4
,jzjscol5=@jzjscol5,jzjscol6=@jzjscol6,jzjscol7=@jzjscol7,jzjscol8=@jzjscol8,jzjscol9=@jzjscol9
,txjscol1=@txjscol1,txjscol2=@txjscol2,txjscol3=@txjscol3,txjscol4=@txjscol4
,txjscol5=@txjscol5,txjscol6=@txjscol6,txjscol7=@txjscol7,txjscol8=@txjscol8,txjscol9=@txjscol9
,tzzycol1=@tzzycol1,tzzycol2=@tzzycol2,tzzycol3=@tzzycol3,tzzycol4=@tzzycol4
,tzzycol5=@tzzycol5,tzzycol6=@tzzycol6,tzzycol7=@tzzycol7,tzzycol8=@tzzycol8,tzzycol9=@tzzycol9
,remark=@remark,hunyin=@hunyin,zhengzhi=@zhengzhi,col1=@col1,col2=@col2,col3=@col3
,col4=@col4,col5=@col5,ImagePath1=@ImagePath1

where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@zhousi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhousi"].Value = this.zhousi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xiangmu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xiangmu"].Value = this.xiangmu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhiwu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhiwu"].Value = this.zhiwu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@name"].Value = this.name;
                oleDbCommand.Parameters.Add(new OleDbParameter("@minzu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@minzu"].Value = this.minzu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@sno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@sno"].Value = this.sno;
                oleDbCommand.Parameters.Add(new OleDbParameter("@sdate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@sdate"].Value = this.sdate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@nianli", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@nianli"].Value = this.nianli;
                oleDbCommand.Parameters.Add(new OleDbParameter("@address", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@address"].Value = this.address;
                oleDbCommand.Parameters.Add(new OleDbParameter("@sex", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@sex"].Value = this.sex;
                oleDbCommand.Parameters.Add(new OleDbParameter("@shenfenweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@shenfenweizhi"].Value = this.shenfenweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@youxiaodate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@youxiaodate"].Value = this.youxiaodate;

                oleDbCommand.Parameters.Add(new OleDbParameter("@school", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@school"].Value = this.school;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhuanye", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhuanye"].Value = this.zhuanye;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xueli", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xueli"].Value = this.xueli;
                oleDbCommand.Parameters.Add(new OleDbParameter("@biyedate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@biyedate"].Value = this.biyedate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xueliflag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xueliflag"].Value = this.xueliflag;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yuanjianflag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yuanjianflag"].Value = this.yuanjianflag;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xueliweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xueliweizhi"].Value = this.xueliweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol1"].Value = this.hetongcol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol2"].Value = this.hetongcol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol3"].Value = this.hetongcol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol4"].Value = this.hetongcol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol5"].Value = this.hetongcol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol6"].Value = this.hetongcol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongcol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongcol7"].Value = this.hetongcol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hetongweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hetongweizhi"].Value = this.hetongweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol1"].Value = this.txcol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol2"].Value = this.txcol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol3"].Value = this.txcol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol4"].Value = this.txcol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol5"].Value = this.txcol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol6"].Value = this.txcol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol7"].Value = this.txcol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txcol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txcol8"].Value = this.txcol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ABCweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@ABCweizhi"].Value = this.ABCweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol1"].Value = this.txzccol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol2"].Value = this.txzccol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol3"].Value = this.txzccol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol4"].Value = this.txzccol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol5"].Value = this.txzccol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol6"].Value = this.txzccol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol7"].Value = this.txzccol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txzccol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txzccol8"].Value = this.txzccol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhichengweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhichengweizhi"].Value = this.zhichengweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol1"].Value = this.txyscol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol2"].Value = this.txyscol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol3"].Value = this.txyscol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol4"].Value = this.txyscol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol5"].Value = this.txyscol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol6"].Value = this.txyscol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol7"].Value = this.txyscol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txyscol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txyscol8"].Value = this.txyscol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yusuanweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yusuanweizhi"].Value = this.yusuanweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol1"].Value = this.jzABCcol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol2"].Value = this.jzABCcol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol3"].Value = this.jzABCcol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol4"].Value = this.jzABCcol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol5"].Value = this.jzABCcol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol6"].Value = this.jzABCcol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol7"].Value = this.jzABCcol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzABCcol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzABCcol8"].Value = this.jzABCcol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jianzhuABCweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jianzhuABCweizhi"].Value = this.jianzhuABCweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol1"].Value = this.yijicol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol2"].Value = this.yijicol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol3"].Value = this.yijicol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol4"].Value = this.yijicol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol5"].Value = this.yijicol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol6"].Value = this.yijicol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol7"].Value = this.yijicol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijicol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijicol8"].Value = this.yijicol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@yijizsweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@yijizsweizhi"].Value = this.yijizsweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol1"].Value = this.erjicol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol2"].Value = this.erjicol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol3"].Value = this.erjicol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol4"].Value = this.erjicol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol5"].Value = this.erjicol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol6"].Value = this.erjicol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol7"].Value = this.erjicol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjicol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjicol8"].Value = this.erjicol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@erjizsweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@erjizsweizhi"].Value = this.erjizsweizhi;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol1"].Value = this.jzzccol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol2"].Value = this.jzzccol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol3"].Value = this.jzzccol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol4"].Value = this.jzzccol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol5"].Value = this.jzzccol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol6"].Value = this.jzzccol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol7"].Value = this.jzzccol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol8"].Value = this.jzzccol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzzccol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzzccol9"].Value = this.jzzccol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol1"].Value = this.jzjscol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol2"].Value = this.jzjscol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol3"].Value = this.jzjscol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol4"].Value = this.jzjscol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol5"].Value = this.jzjscol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol6"].Value = this.jzjscol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol7"].Value = this.jzjscol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol8"].Value = this.jzjscol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jzjscol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jzjscol9"].Value = this.jzjscol9;


                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol1"].Value = this.txjscol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol2"].Value = this.txjscol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol3"].Value = this.txjscol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol4"].Value = this.txjscol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol5"].Value = this.txjscol5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol6"].Value = this.txjscol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol7"].Value = this.txjscol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol8"].Value = this.txjscol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@txjscol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@txjscol9"].Value = this.txjscol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol1"].Value = this.tzzycol1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol2"].Value = this.tzzycol2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol3"].Value = this.tzzycol3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol4"].Value = this.tzzycol4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol5"].Value = this.tzzycol5;

                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol6"].Value = this.tzzycol6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol7"].Value = this.tzzycol7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol8"].Value = this.tzzycol8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@tzzycol9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@tzzycol9"].Value = this.tzzycol9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;
                oleDbCommand.Parameters.Add(new OleDbParameter("@hunyin", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@hunyin"].Value = this.hunyin;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhengzhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhengzhi"].Value = this.zhengzhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@ImagePath1"].Value = this.ImagePath1;

               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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




    }

    public class yuangongzsList1
    {
        public int ID { set; get; }
        public int sID { set; get; }

        public string sno { set; get; }

        public string qita1col1 { set; get; }
        public string qita2col1 { set; get; }
        public string qita3col1 { set; get; }
        public string qita4col1 { set; get; }
        public string qita5col1 { set; get; }
        public string qita6col1 { set; get; }
        public string qita7col1 { set; get; }
        public string qita8col1 { set; get; }
       
        public string qita1col2 { set; get; }
        public string qita2col2 { set; get; }
        public string qita3col2 { set; get; }
        public string qita4col2 { set; get; }
        public string qita5col2 { set; get; }
        public string qita6col2 { set; get; }
        public string qita7col2 { set; get; }
        public string qita8col2 { set; get; }
        
        public string qita1col3 { set; get; }
        public string qita2col3 { set; get; }
        public string qita3col3 { set; get; }
        public string qita4col3 { set; get; }
        public string qita5col3 { set; get; }
        public string qita6col3 { set; get; }
        public string qita7col3 { set; get; }
        public string qita8col3 { set; get; }
       
        public string qita1col4 { set; get; }
        public string qita2col4 { set; get; }
        public string qita3col4 { set; get; }
        public string qita4col4 { set; get; }
        public string qita5col4 { set; get; }
        public string qita6col4 { set; get; }
        public string qita7col4 { set; get; }
        public string qita8col4 { set; get; }
        
        public string qita1col5 { set; get; }
        public string qita2col5 { set; get; }
        public string qita3col5 { set; get; }
        public string qita4col5 { set; get; }
        public string qita5col5 { set; get; }
        public string qita6col5 { set; get; }
        public string qita7col5 { set; get; }
        public string qita8col5 { set; get; }
        
        public string CheckUploadResult { set; get; }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from yuangongzs_1  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());

                    this.qita1col1 = oleDbDataReader["qita1col1"].ToString();
                    this.qita2col1 = oleDbDataReader["qita2col1"].ToString();
                    this.qita3col1 = oleDbDataReader["qita3col1"].ToString();
                    this.qita4col1 = oleDbDataReader["qita4col1"].ToString();
                    this.qita5col1 = oleDbDataReader["qita5col1"].ToString();
                    this.qita6col1 = oleDbDataReader["qita6col1"].ToString();
                    this.qita7col1 = oleDbDataReader["qita7col1"].ToString();
                    this.qita8col1 = oleDbDataReader["qita8col1"].ToString();

                    this.qita1col2 = oleDbDataReader["qita1col2"].ToString();
                    this.qita2col2 = oleDbDataReader["qita2col2"].ToString();
                    this.qita3col2 = oleDbDataReader["qita3col2"].ToString();
                    this.qita4col2 = oleDbDataReader["qita4col2"].ToString();
                    this.qita5col2 = oleDbDataReader["qita5col2"].ToString();
                    this.qita6col2 = oleDbDataReader["qita6col2"].ToString();
                    this.qita7col2 = oleDbDataReader["qita7col2"].ToString();
                    this.qita8col2 = oleDbDataReader["qita8col2"].ToString();
                    this.qita1col3 = oleDbDataReader["qita1col3"].ToString();
                    this.qita2col3 = oleDbDataReader["qita2col3"].ToString();
                    this.qita3col3 = oleDbDataReader["qita3col3"].ToString();
                    this.qita4col3 = oleDbDataReader["qita4col3"].ToString();
                    this.qita5col3 = oleDbDataReader["qita5col3"].ToString();
                    this.qita6col3 = oleDbDataReader["qita6col3"].ToString();
                    this.qita7col3 = oleDbDataReader["qita7col3"].ToString();
                    this.qita8col3 = oleDbDataReader["qita8col3"].ToString();

                    this.qita1col4 = oleDbDataReader["qita1col4"].ToString();
                    this.qita2col4 = oleDbDataReader["qita2col4"].ToString();
                    this.qita3col4 = oleDbDataReader["qita3col4"].ToString();
                    this.qita4col4 = oleDbDataReader["qita4col4"].ToString();
                    this.qita5col4 = oleDbDataReader["qita5col4"].ToString();
                    this.qita6col4 = oleDbDataReader["qita6col4"].ToString();
                    this.qita7col4 = oleDbDataReader["qita7col4"].ToString();
                    this.qita8col4 = oleDbDataReader["qita8col4"].ToString();

                    this.qita1col5 = oleDbDataReader["qita1col5"].ToString();
                    this.qita2col5 = oleDbDataReader["qita2col5"].ToString();
                    this.qita3col5 = oleDbDataReader["qita3col5"].ToString();
                    this.qita4col5 = oleDbDataReader["qita4col5"].ToString();
                    this.qita5col5 = oleDbDataReader["qita5col5"].ToString();
                    this.qita6col5 = oleDbDataReader["qita6col5"].ToString();
                    this.qita7col5 = oleDbDataReader["qita7col5"].ToString();
                    this.qita8col5 = oleDbDataReader["qita8col5"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from yuangongzs_1 where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into yuangongzs_1( sID,qita1col1,qita2col1,qita3col1,qita4col1,qita5col1,qita6col1,qita7col1,qita8col1
,qita1col2,qita2col2,qita3col2,qita4col2,qita5col2,qita6col2,qita7col2,qita8col2
,qita1col3,qita2col3,qita3col3,qita4col3,qita5col3,qita6col3,qita7col3,qita8col3
,qita1col4,qita2col4,qita3col4,qita4col4,qita5col4,qita6col4,qita7col4,qita8col4
,qita1col5,qita2col5,qita3col5,qita4col5,qita5col5,qita6col5,qita7col5,qita8col5
) 
                values ( @sID,@qita1col1,@qita2col1,@qita3col1,@qita4col1,@qita5col1,@qita6col1,@qita7col1,@qita8col1
,@qita1col2,@qita2col2,@qita3col2,@qita4col2,@qita5col2,@qita6col2,@qita7col2,@qita8col2
,@qita1col3,@qita2col3,@qita3col3,@qita4col3,@qita5col3,@qita6col3,@qita7col3,@qita8col3
,@qita1col4,@qita2col4,@qita3col4,@qita4col4,@qita5col4,@qita6col4,@qita7col4,@qita8col4
,@qita1col5,@qita2col5,@qita3col5,@qita4col5,@qita5col5,@qita6col5,@qita7col5,@qita8col5
) ";

                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@sID", OleDbType.Integer));
                oleDbCommand.Parameters["@sID"].Value = sID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col1"].Value = this.qita1col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col1"].Value = this.qita2col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col1"].Value = this.qita3col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col1"].Value = this.qita4col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col1"].Value = this.qita5col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col1"].Value = this.qita6col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col1"].Value = this.qita7col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col1"].Value = this.qita8col1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col2"].Value = this.qita1col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col2"].Value = this.qita2col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col2"].Value = this.qita3col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col2"].Value = this.qita4col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col2"].Value = this.qita5col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col2"].Value = this.qita6col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col2"].Value = this.qita7col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col2"].Value = this.qita8col2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col3"].Value = this.qita1col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col3"].Value = this.qita2col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col3"].Value = this.qita3col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col3"].Value = this.qita4col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col3"].Value = this.qita5col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col3"].Value = this.qita6col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col3"].Value = this.qita7col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col3"].Value = this.qita8col3;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col4"].Value = this.qita1col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col4"].Value = this.qita2col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col4"].Value = this.qita3col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col4"].Value = this.qita4col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col4"].Value = this.qita5col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col4"].Value = this.qita6col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col4"].Value = this.qita7col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col4"].Value = this.qita8col4;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col5"].Value = this.qita1col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col5"].Value = this.qita2col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col5"].Value = this.qita3col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col5"].Value = this.qita4col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col5"].Value = this.qita5col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col5"].Value = this.qita6col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col5"].Value = this.qita7col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col5"].Value = this.qita8col5;



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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"update yuangongzs_1 set qita1col1=@qita1col1,qita2col1=@qita2col1,qita3col1=@qita3col1,qita4col1=@qita4col1
,qita5col1=@qita5col1,qita6col1=@qita6col1,qita7col1=@qita7col1,qita8col1=@qita8col1
,qita1col2=@qita1col2,qita2col2=@qita2col2,qita3col2=@qita3col2,qita4col2=@qita4col2
,qita5col2=@qita5col2,qita6col2=@qita6col2,qita7col2=@qita7col2,qita8col2=@qita8col2
,qita1col3=@qita1col3,qita2col3=@qita2col3,qita3col3=@qita3col3,qita4col3=@qita4col3
,qita5col3=@qita5col3,qita6col3=@qita6col3,qita7col3=@qita7col3,qita8col3=@qita8col3
,qita1col4=@qita1col4,qita2col4=@qita2col4,qita3col4=@qita3col4,qita4col4=@qita4col4
,qita5col4=@qita5col4,qita6col4=@qita6col4,qita7col4=@qita7col4,qita8col4=@qita8col4
,qita1col5=@qita1col5,qita2col5=@qita2col5,qita3col5=@qita3col5,qita4col5=@qita4col5
,qita5col5=@qita5col5,qita6col5=@qita6col5,qita7col5=@qita7col5,qita8col5=@qita8col5

where sID =@sID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col1"].Value = this.qita1col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col1"].Value = this.qita2col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col1"].Value = this.qita3col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col1"].Value = this.qita4col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col1"].Value = this.qita5col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col1"].Value = this.qita6col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col1"].Value = this.qita7col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col1"].Value = this.qita8col1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col2"].Value = this.qita1col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col2"].Value = this.qita2col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col2"].Value = this.qita3col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col2"].Value = this.qita4col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col2"].Value = this.qita5col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col2"].Value = this.qita6col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col2"].Value = this.qita7col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col2"].Value = this.qita8col2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col3"].Value = this.qita1col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col3"].Value = this.qita2col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col3"].Value = this.qita3col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col3"].Value = this.qita4col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col3"].Value = this.qita5col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col3"].Value = this.qita6col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col3"].Value = this.qita7col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col3"].Value = this.qita8col3;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col4"].Value = this.qita1col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col4"].Value = this.qita2col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col4"].Value = this.qita3col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col4"].Value = this.qita4col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col4"].Value = this.qita5col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col4"].Value = this.qita6col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col4"].Value = this.qita7col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col4"].Value = this.qita8col4;

                oleDbCommand.Parameters.Add(new OleDbParameter("@qita1col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita1col5"].Value = this.qita1col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita2col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita2col5"].Value = this.qita2col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita3col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita3col5"].Value = this.qita3col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita4col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita4col5"].Value = this.qita4col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita5col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita5col5"].Value = this.qita5col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita6col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita6col5"].Value = this.qita6col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita7col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita7col5"].Value = this.qita7col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@qita8col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@qita8col5"].Value = this.qita8col5;

                oleDbCommand.Parameters.Add(new OleDbParameter("@sID", OleDbType.Integer));
                oleDbCommand.Parameters["@sID"].Value = sID;
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




    }

    public class cheliangzsList
    {
        public int ID { set; get; }
        public string zhousi { set; get; }
        public string xiangmu { set; get; }
        public string chezhuname { set; get; }
        public string cheno { set; get; }
        public string fadongjino { set; get; }
        public string cheliangstyle { set; get; }
        public string pinpai { set; get; }
        public string zhizhaoshang { set; get; }
        public string gouzhinian { set; get; }

        public string jianchayouxiaodate { set; get; }
        public string jianchadaqi { set; get; }
        public string zuchedate { set; get; }
        public string zuchedaiqi { set; get; }
        public string xingchezhengweizhi { set; get; }
        public string cheliangzpweizhi { set; get; }
        public string zucheweizhi { set; get; }
        public string remark { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }

        public string CheckUploadResult { set; get; }

        public void GetData(int ID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from cheliangzs  where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.zhousi = oleDbDataReader["zhousi"].ToString();
                    this.xiangmu = oleDbDataReader["xiangmu"].ToString();
                    this.chezhuname = oleDbDataReader["chezhuname"].ToString();
                    this.cheno = oleDbDataReader["cheno"].ToString();
                    this.jianchayouxiaodate = oleDbDataReader["jianchayouxiaodate"].ToString();
                    this.jianchadaqi = oleDbDataReader["jianchadaqi"].ToString();
                    this.zuchedate = oleDbDataReader["zuchedate"].ToString();
                    this.zuchedaiqi = oleDbDataReader["zuchedaiqi"].ToString();
                    this.xingchezhengweizhi = oleDbDataReader["xingchezhengweizhi"].ToString();
                    this.cheliangzpweizhi = oleDbDataReader["cheliangzpweizhi"].ToString();
                    this.zucheweizhi = oleDbDataReader["zucheweizhi"].ToString();
                    this.remark = oleDbDataReader["remark"].ToString();

                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from cheliangzs ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = int.Parse(oleDbDataReader["ID"].ToString());
                    this.zhousi = oleDbDataReader["zhousi"].ToString();
                    this.xiangmu = oleDbDataReader["xiangmu"].ToString();
                    this.chezhuname = oleDbDataReader["chezhuname"].ToString();
                    this.cheno = oleDbDataReader["cheno"].ToString();
                    this.jianchayouxiaodate = oleDbDataReader["jianchayouxiaodate"].ToString();
                    this.jianchadaqi = oleDbDataReader["jianchadaqi"].ToString();
                    this.zuchedate = oleDbDataReader["zuchedate"].ToString();
                    this.zuchedaiqi = oleDbDataReader["zuchedaiqi"].ToString();
                    this.xingchezhengweizhi = oleDbDataReader["xingchezhengweizhi"].ToString();
                    this.cheliangzpweizhi = oleDbDataReader["cheliangzpweizhi"].ToString();
                    this.zucheweizhi = oleDbDataReader["zucheweizhi"].ToString();
                    this.remark = oleDbDataReader["remark"].ToString();
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from cheliangzs where ID =" + id);
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into cheliangzs(zhousi,xiangmu,chezhuname,cheno,jianchayouxiaodate,jianchadaqi,zuchedate,zuchedaiqi,xingchezhengweizhi,cheliangzpweizhi,zucheweizhi,remark,col1,col2,col3,col4,col5) 
                values (@zhousi,@xiangmu,@chezhuname,@cheno,@jianchayouxiaodate,@jianchadaqi,@zuchedate,@zuchedaiqi,@xingchezhengweizhi,@cheliangzpweizhi,@zucheweizhi,@remark,@col1,@col2,@col3,@col4,@col5) ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@zhousi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhousi"].Value = this.zhousi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xiangmu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xiangmu"].Value = this.xiangmu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@chezhuname", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@chezhuname"].Value = this.chezhuname;
                oleDbCommand.Parameters.Add(new OleDbParameter("@cheno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@cheno"].Value = this.cheno;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jianchayouxiaodate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jianchayouxiaodate"].Value = this.jianchayouxiaodate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jianchadaqi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jianchadaqi"].Value = this.jianchadaqi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zuchedate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zuchedate"].Value = this.zuchedate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zuchedaiqi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zuchedaiqi"].Value = this.zuchedaiqi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xingchezhengweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xingchezhengweizhi"].Value = this.xingchezhengweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@cheliangzpweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@cheliangzpweizhi"].Value = this.cheliangzpweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zucheweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zucheweizhi"].Value = this.zucheweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;

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

        public int UpdateData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"update cheliangzs set zhousi=@zhousi,xiangmu=@xiangmu,chezhuname=@chezhuname,cheno=@cheno,
jianchayouxiaodate=@jianchayouxiaodate,jianchadaqi=@jianchadaqi,zuchedate=@zuchedate,zuchedaiqi=@zuchedaiqi,
xingchezhengweizhi=@xingchezhengweizhi,cheliangzpweizhi=@cheliangzpweizhi,zucheweizhi=@zucheweizhi,remark=@remark
,col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5 where ID =@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@zhousi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zhousi"].Value = this.zhousi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xiangmu", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xiangmu"].Value = this.xiangmu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@chezhuname", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@chezhuname"].Value = this.chezhuname;
                oleDbCommand.Parameters.Add(new OleDbParameter("@cheno", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@cheno"].Value = this.cheno;

                oleDbCommand.Parameters.Add(new OleDbParameter("@jianchayouxiaodate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jianchayouxiaodate"].Value = this.jianchayouxiaodate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@jianchadaqi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@jianchadaqi"].Value = this.jianchadaqi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zuchedate", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zuchedate"].Value = this.zuchedate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zuchedaiqi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zuchedaiqi"].Value = this.zuchedaiqi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xingchezhengweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@xingchezhengweizhi"].Value = this.xingchezhengweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@cheliangzpweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@cheliangzpweizhi"].Value = this.cheliangzpweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@zucheweizhi", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@zucheweizhi"].Value = this.zucheweizhi;
                oleDbCommand.Parameters.Add(new OleDbParameter("@remark", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@remark"].Value = this.remark;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = ID;
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




    }


    public class shichangList
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }

        public string col23 { set; get; } //remark

        public string col24 { set; get; }
        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }
        public string col30 { set; get; }
        public string col31 { set; get; }
        public string col32 { set; get; }
        public string col33 { set; get; }
        public string col34 { set; get; }
        public string col35 { set; get; }
        public string col36 { set; get; }
        public string col37 { set; get; }
        public string col38 { set; get; }
        public string col39 { set; get; }
        public string col40 { set; get; }
        public string col41 { set; get; }
        public string col42 { set; get; }
        public string col43 { set; get; }
        public string col44 { set; get; }
        public string col45 { set; get; }

        public DateTime col51 { set; get; }

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_shichang where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();

                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();
                    this.col34 = oleDbDataReader["col34"].ToString();
                    this.col35 = oleDbDataReader["col35"].ToString();
                    this.col36 = oleDbDataReader["col36"].ToString();
                    this.col37 = oleDbDataReader["col37"].ToString();
                    this.col38 = oleDbDataReader["col38"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_shichang(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32,col33,col34,col35,col36,col37,col38,col39,col40,col41,col42,col43,col44,col45,col51) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32,@col33,@col34,@col35,@col36,@col37,@col38,@col39,@col40,@col41,@col42,@col43,@col44,@col45,@col51)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;


                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.Date));
                oleDbCommand.Parameters["@col51"].Value = this.col51;


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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_shichang set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29,col30=@col30
,col31=@col31,col32=@col32,col33=@col33,col34=@col34,col35=@col35,col36=@col36,col37=@col37,col38=@col38,col39=@col39
,col40=@col40,col41=@col41,col42=@col42,col43=@col43,col44=@col44,col45=@col45,col51=@col51 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.Date));
                oleDbCommand.Parameters["@col51"].Value = this.col51;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_shichang where ID=" + id);
        }


        public void UpdateDatacol51(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_shichang set col51=@col51 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.Date));
                oleDbCommand.Parameters["@col51"].Value = this.col51;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


    }

    public class keshangList
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
       
        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_keshang where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData2(string str1, string str2, string str3)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_keshang where 1= 1 and col1 = @col1 and col2 = @col2 and col3 = @col3    ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = str2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = str3;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_keshang(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_keshang set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
,col15=@col15,col16=@col16 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_keshang where ID=" + id);
        }


    }

    public class hetong1List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }
        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }

        public string col31 { set; get; }
        public string col32 { set; get; }
        public string col33 { set; get; }
        public string col34 { set; get; }
        public string col35 { set; get; }
        public string col36 { set; get; }
        public string col37 { set; get; }
        public string col38 { set; get; }
        public string col39 { set; get; }

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hetong where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col21"].ToString();
                    this.col23 = oleDbDataReader["col20"].ToString();
                    this.col24 = oleDbDataReader["col21"].ToString();
                    this.col25 = oleDbDataReader["col21"].ToString();
                    this.col26 = oleDbDataReader["col20"].ToString();
                    this.col27 = oleDbDataReader["col21"].ToString();
                    this.col28 = oleDbDataReader["col21"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hetong(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22
,col23,col24,col25,col26,col27,col28,col31,col32,col33,col34,col35,col36,col37,col38,col39) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22
,@col23,@col24,@col25,@col26,@col27,@col28,@col31,@col32,@col33,@col34,@col35,@col36,@col37,@col38,@col39)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hetong set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22
,col23=@col23,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col31=@col31,col32=@col32,col33=@col33
,col34=@col34,col35=@col35,col36=@col36,col37=@col37,col38=@col38,col39=@col39 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hetong where ID=" + id);
        }

        public void GetAllData2(string str1, string str2, string str3)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hetong where 1= 1 and col1 = @col1 and col2 = @col2    ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = str2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = str3;
                
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();


                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class hetong2List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }
        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }
        public string col30 { set; get; }
        public string col31 { set; get; }
        public string col32 { set; get; }
        public string col33 { set; get; }
        public string col34 { set; get; }
        public string col35 { set; get; }
        public string col36 { set; get; }
        public string col37 { set; get; }
        public string col38 { set; get; }
        public string col39 { set; get; }

        public string col40 { set; get; }

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hetong2 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetAllData2(string str1, string str2)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hetong2 where 1= 1 and col1 = @col1 and col2 = @col2    ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = str2;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col3"].Value = str3;

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hetong2(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32,col33,col34,col35,col36,col37,col38,col39,col40) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32,@col33,@col34,@col35,@col36,@col37,@col38,@col39,@col40)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hetong2 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29
,col30=@col30,col31=@col31,col32=@col32,col33=@col33
,col34=@col34,col35=@col35,col36=@col36,col37=@col37,col38=@col38,col39=@col39,col40=@col40 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hetong2 where ID=" + id);
        }


    }

    public class hetong3List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }
        public string col25 { set; get; }
        public string col26 { set; get; }
       
        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hetong3 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hetong3(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col22"].Value = this.col22;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col23"].Value = this.col23;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col24"].Value = this.col24;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col25"].Value = this.col25;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col26"].Value = this.col26;
                
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hetong3 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20
,col21=@col21 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col22"].Value = this.col22;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col23"].Value = this.col23;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col24"].Value = this.col24;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col25"].Value = this.col25;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col26"].Value = this.col26;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hetong3 where ID=" + id);
        }


    }

    public class xiangmu1List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }
        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }
        public string col30 { set; get; }
        public string col31 { set; get; } //Drop结算类型
        public string col32 { set; get; }
        public string col33 { set; get; } //合同id


        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu1 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();

                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_xiangmu1(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32,col33) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32,@col33)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;

                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu1 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19 ,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29,col30=@col30,col31=@col31,col32=@col32
,col33=@col33 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_xiangmu1 where ID=" + id);
        }

        //关闭
        public void UpdateData2(int id)
        {
            Sql.SqlQuery("update t_xiangmu1 set col30 = '关闭' where ID=" + id);
        }

        //开启
        public void UpdateData3(int id)
        {
            Sql.SqlQuery("update t_xiangmu1 set col30 = '开启' where ID=" + id);
        }


        public void GetAllData(string name)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu1 and col1 = @col1  ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = name;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();

                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void GetAllData2(string str1, string str2, string str3, string str4)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu1 where 1= 1 and col8 = @col8 and col9 = @col9 and col5 = @col5 and col31 = @col31  ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = str2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = str3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = str4;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();

                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class hezuo1List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hezuo1 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hezuo1(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hezuo1 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;


                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hezuo1 where ID=" + id);
        }

        public void GetAllData2(string str1)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_keshang where 1= 1 and col1 = @col1     ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
           

                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();


                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class hezuo2List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        //public string col19 { set; get; }
        //public string col20 { set; get; }
        //public string col21 { set; get; }
       
        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_hezuo2 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    //this.col19 = oleDbDataReader["col19"].ToString();
                    //this.col20 = oleDbDataReader["col20"].ToString();
                    //this.col21 = oleDbDataReader["col21"].ToString();
                   
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hezuo2(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
               
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hezuo2 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hezuo2 where ID=" + id);
        }


    }

    public class hezuo3List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        //public string col15 { set; get; }
        //public string col16 { set; get; }
        //public string col17 { set; get; }
        //public string col18 { set; get; }
        //public string col19 { set; get; }
        //public string col20 { set; get; }
        //public string col21 { set; get; }

        public string CheckUploadResult;

       
        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hezuo3(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col15"].Value = this.col15;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col16"].Value = this.col16;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col17"].Value = this.col17;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col18"].Value = this.col18;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col19"].Value = this.col19;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col20"].Value = this.col20;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col21"].Value = this.col21;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hezuo3 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col15"].Value = this.col15;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col16"].Value = this.col16;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col17"].Value = this.col17;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col18"].Value = this.col18;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col19"].Value = this.col19;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col20"].Value = this.col20;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col21"].Value = this.col21;


                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hezuo3 set col7=@col7 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hezuo3 where ID=" + id);
        }


    }

    public class hezuo4List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public int col22 { set; get; }

        public string col23 { set; get; }
        public string col24 { set; get; }
        public string col25 { set; get; }


        public string CheckUploadResult;


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hezuo4(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23,col24,col25) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23,@col24,@col25)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.Integer));
                oleDbCommand.Parameters["@col22"].Value = this.col22;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hezuo4 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col23=@col23,col24=@col24,col25=@col25 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.Integer));
                //oleDbCommand.Parameters["@col22"].Value = this.col22;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hezuo4 where col22=" + id);
        }


    }



    public class caiwu1List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }

        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }//remark

        public string col30 { set; get; } //hdxiangmuid

        public string col31 { set; get; } //纳税人属性

        public string col32 { set; get; } //到期判断

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu1 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    //this.col32 = oleDbDataReader["col32"].ToString();
                    //this.col33 = oleDbDataReader["col33"].ToString();
                    //this.col34 = oleDbDataReader["col34"].ToString();
                    //this.col35 = oleDbDataReader["col35"].ToString();
                    //this.col36 = oleDbDataReader["col36"].ToString();
                    //this.col37 = oleDbDataReader["col37"].ToString();
                    //this.col38 = oleDbDataReader["col38"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu1(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu1 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29,col30=@col30,col31=@col31,col32=@col32 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_caiwu1 where ID=" + id);
        }


    }

    public class caiwu2List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }

        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }//remark

        public string col30 { set; get; }
        public string col31 { set; get; }
        public string col32 { set; get; }
        public string col33 { set; get; }
        public string col34 { set; get; }
        public string col35 { set; get; }
        public string col36 { set; get; }
        public string col37 { set; get; }
        public string col38 { set; get; }
        public string col39 { set; get; }
        public string col40 { set; get; }
        public string col41 { set; get; }
        public string col42 { set; get; }
        public string col43 { set; get; }
        public string col44 { set; get; }
        public string col45 { set; get; }
        public string col46 { set; get; }
        public string col47 { set; get; }
        public string col48 { set; get; }
        public string col49 { set; get; }
        public string col50 { set; get; }
        public string col51 { set; get; }
        public string col52 { set; get; }
        public string col53 { set; get; }
        public string col54 { set; get; }
        public string col55 { set; get; }

        public string col59 { set; get; }
        public string col60 { set; get; }
        public string col61 { set; get; } //

        public string col62 { set; get; } //下个审核人员
        public string col63 { set; get; }

        public string col64 { set; get; }

        public string col65 { set; get; } // 缴税备注
        public string col66 { set; get; } // 审批说明情况

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu2 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();
                    this.col34 = oleDbDataReader["col34"].ToString();
                    this.col35 = oleDbDataReader["col35"].ToString();
                    this.col36 = oleDbDataReader["col36"].ToString();
                    this.col37 = oleDbDataReader["col37"].ToString();
                    this.col38 = oleDbDataReader["col38"].ToString();
                    this.col39 = oleDbDataReader["col39"].ToString();
                    this.col40 = oleDbDataReader["col40"].ToString();
                    this.col41 = oleDbDataReader["col41"].ToString();
                    this.col42 = oleDbDataReader["col42"].ToString();
                    this.col43 = oleDbDataReader["col43"].ToString();
                    this.col44 = oleDbDataReader["col44"].ToString();
                    this.col45 = oleDbDataReader["col45"].ToString();
                    this.col46 = oleDbDataReader["col46"].ToString();
                    this.col47 = oleDbDataReader["col47"].ToString();
                    this.col48 = oleDbDataReader["col48"].ToString();
                    this.col49 = oleDbDataReader["col49"].ToString();
                    this.col50 = oleDbDataReader["col50"].ToString();
                    this.col51 = oleDbDataReader["col51"].ToString();
                    this.col52 = oleDbDataReader["col52"].ToString();
                    this.col53 = oleDbDataReader["col53"].ToString();
                    this.col54 = oleDbDataReader["col54"].ToString();
                    this.col55 = oleDbDataReader["col55"].ToString();

                    this.col59 = oleDbDataReader["col59"].ToString();
                    this.col60 = oleDbDataReader["col60"].ToString();
                    this.col61 = oleDbDataReader["col61"].ToString();
                    this.col62 = oleDbDataReader["col62"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetData(string formno)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu2 where col53=@col53";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@col53", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col53"].Value = formno;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();
                    this.col34 = oleDbDataReader["col34"].ToString();
                    this.col35 = oleDbDataReader["col35"].ToString();
                    this.col36 = oleDbDataReader["col36"].ToString();
                    this.col37 = oleDbDataReader["col37"].ToString();
                    this.col38 = oleDbDataReader["col38"].ToString();
                    this.col39 = oleDbDataReader["col39"].ToString();
                    this.col40 = oleDbDataReader["col40"].ToString();
                    this.col41 = oleDbDataReader["col41"].ToString();
                    this.col42 = oleDbDataReader["col42"].ToString();
                    this.col43 = oleDbDataReader["col43"].ToString();
                    this.col44 = oleDbDataReader["col44"].ToString();
                    this.col45 = oleDbDataReader["col45"].ToString();
                    this.col46 = oleDbDataReader["col46"].ToString();
                    this.col47 = oleDbDataReader["col47"].ToString();
                    this.col48 = oleDbDataReader["col48"].ToString();
                    this.col49 = oleDbDataReader["col49"].ToString();
                    this.col50 = oleDbDataReader["col50"].ToString();
                    this.col51 = oleDbDataReader["col51"].ToString();
                    this.col52 = oleDbDataReader["col52"].ToString();
                    this.col53 = oleDbDataReader["col53"].ToString();
                    this.col54 = oleDbDataReader["col54"].ToString();
                    this.col55 = oleDbDataReader["col55"].ToString();

                    this.col59 = oleDbDataReader["col59"].ToString();
                    this.col60 = oleDbDataReader["col60"].ToString();
                    this.col61 = oleDbDataReader["col61"].ToString();
                    this.col62 = oleDbDataReader["col62"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu2(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32,col33,col34,col35,col36,col37,col38,col39,col40,col41
,col42,col43,col44,col45,col46,col47,col48,col49,col50,col51,col52,col53,col54,col55,col59,col60,col61,col62) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32,@col33,@col34,@col35,@col36,@col37,@col38
,@col39,@col40,@col41,@col42,@col43,@col44,@col45,@col46,@col47,@col48,@col49,@col50,@col51,@col52,@col53,@col54,@col55
,@col59,@col60,@col61,@col62)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col51"].Value = this.col51;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col52", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col52"].Value = this.col52;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col53", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col53"].Value = this.col53;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col54", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col54"].Value = this.col54;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col55", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col55"].Value = this.col55;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col59", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col59"].Value = this.col59;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col60", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col60"].Value = this.col60;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col61", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col61"].Value = this.col61;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col62", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col62"].Value = this.col62;

                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu2 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29
,col30=@col30,col31=@col31,col32=@col32,col33=@col33,col34=@col34,col35=@col35
,col36=@col36,col37=@col37,col38=@col38,col39=@col39,col40=@col40,col41=@col41
,col42=@col42,col43=@col43,col44=@col44,col45=@col45,col46=@col46,col47=@col47,col48=@col48,col49=@col49
,col50=@col50,col51=@col51,col52=@col52,col53=@col53,col54=@col54,col55=@col55,col61=@col61,col62=@col62,col65=@col65,col66=@col66   where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col51"].Value = this.col51;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col52", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col52"].Value = this.col52;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col53", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col53"].Value = this.col53;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col54", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col54"].Value = this.col54;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col55", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col55"].Value = this.col55;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col61", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col61"].Value = this.col61;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col62", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col62"].Value = this.col62;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col65", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col65"].Value = this.col65;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col66", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col66"].Value = this.col66;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_caiwu2 where ID=" + id);
        }

        public void UpdateDatashenhe(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu2 set col55=@col55,col33=@col33,col62=@col62,col63=@col63,col66=@col66 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col55", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col55"].Value = this.col55;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col62", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col62"].Value = this.col62;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col63", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col63"].Value = this.col63;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col66", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col66"].Value = this.col66;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateDatashenhe2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu2 set col55=@col55,col33=@col33,col34=@col34,col62=@col62,col63=@col63 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col55", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col55"].Value = this.col55;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col62", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col62"].Value = this.col62;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col63", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col63"].Value = this.col63;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void UpdateDatafapiao(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu2 set col31=@col31,col32=@col32,col34=@col34
,col35=@col35,col36=@col36,col37=@col37,col38=@col38 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateDatashoukuan(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu2 set col39=@col39,col40=@col40,col41=@col41,col42=@col42
,col43=@col43,col44=@col44,col45=@col45,col46=@col46,col47=@col47,col48=@col48,col59=@col59,col60=@col60,col64=@col64 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col59", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col59"].Value = this.col59;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col60", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col60"].Value = this.col60;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col64", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col64"].Value = this.col64;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateDatakaipiaoshijian(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu2 set col31=@col31,col32=@col32,col35=@col35,col36=@col36 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class caiwu22List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }
        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }
        public string col30 { set; get; }
        public string col31 { set; get; }
        public string col32 { set; get; } //保存状态
        public string col33 { set; get; } 
        public string col34 { set; get; }
        public string col35 { set; get; }
        public string col36 { set; get; }
        public string col37 { set; get; }
        public string col38 { set; get; } //上传资料
        public string col39 { set; get; }
        public string col40 { set; get; }
        public string col41 { set; get; }
        public string col42 { set; get; }
        public string col43 { set; get; } //id

        public string col45 { set; get; }
        public string col46 { set; get; }
        public string col47 { set; get; }
        public string col48 { set; get; }
        public string col49 { set; get; }
        public string col50 { set; get; }
        
        
        public string CheckUploadResult;

        public caiwu22List GetData(int id)
        {
            caiwu22List _obj = null;
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            oleDbConnection.Open();
            string cmdText = "select * from t_caiwu22 where id=@ID";
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
            oleDbCommand.Parameters["@ID"].Value = id;
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            if (oleDbDataReader.Read())
            {
                _obj = GetInfoClasFromDataReader(oleDbDataReader);
            }

            return _obj;


        }

        private caiwu22List GetInfoClasFromDataReader(IDataReader dr)
        {
            caiwu22List Obj = new caiwu22List();
            Obj.ID = Convert.ToInt32(dr["ID"].ToString());
            Obj.col1 = dr["col1"].ToString();
            Obj.col2 = dr["col2"].ToString();
            Obj.col3 = dr["col3"].ToString();
            Obj.col4 = dr["col4"].ToString();
            Obj.col5 = dr["col5"].ToString();
            Obj.col6 = dr["col6"].ToString();
            Obj.col7 = dr["col7"].ToString();
            Obj.col8 = dr["col8"].ToString();
            Obj.col9 = dr["col9"].ToString();
            Obj.col10 = dr["col10"].ToString();
            Obj.col11 = dr["col11"].ToString();
            Obj.col12 = dr["col12"].ToString();
            Obj.col13 = dr["col13"].ToString();
            Obj.col14 = dr["col14"].ToString();
            Obj.col15 = dr["col15"].ToString();
            Obj.col16 = dr["col16"].ToString();
            Obj.col17 = dr["col17"].ToString();
            Obj.col18 = dr["col18"].ToString();
            Obj.col19 = dr["col19"].ToString();
            Obj.col20 = dr["col20"].ToString();
            Obj.col21 = dr["col21"].ToString();
            Obj.col22 = dr["col22"].ToString();
            Obj.col23 = dr["col23"].ToString();
            Obj.col24 = dr["col24"].ToString();
            Obj.col25 = dr["col25"].ToString();
            Obj.col26 = dr["col26"].ToString();
            Obj.col27 = dr["col27"].ToString();
            Obj.col28 = dr["col28"].ToString();
            Obj.col29 = dr["col29"].ToString();
            Obj.col30 = dr["col30"].ToString();
            Obj.col31 = dr["col31"].ToString();
            Obj.col32 = dr["col32"].ToString();
            Obj.col33 = dr["col33"].ToString();
            Obj.col34 = dr["col34"].ToString();
            Obj.col35 = dr["col35"].ToString();
            Obj.col36 = dr["col36"].ToString();
            Obj.col37 = dr["col37"].ToString();
            Obj.col38 = dr["col38"].ToString();
            Obj.col39 = dr["col39"].ToString();
            Obj.col40 = dr["col40"].ToString();
            Obj.col41 = dr["col41"].ToString();
            Obj.col42 = dr["col42"].ToString();
            Obj.col43 = dr["col43"].ToString();
            
            Obj.col45 = dr["col45"].ToString();
            Obj.col46 = dr["col46"].ToString();
            Obj.col47 = dr["col47"].ToString();

            return Obj;
        }

      
        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu22(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20
,col21,col22,col23,col24,col25,col26,col27,col28,col29,col30,col31,col43,col45,col46,col47,col49) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20
,@col21,@col22,@col23,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col43,@col45,@col46,@col47,@col49)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu22 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19 ,col20=@col20
,col21=@col21,col22=@col22,col23=@col23,col24=@col24
                ,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29 ,col30=@col30 ,col31=@col31
,col43=@col43,col45=@col45,col46=@col46,col47=@col47 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(string col17)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu22 set col19=@col19,col20=@col20,col32=@col32
,col39=@col39,col40=@col40,col41=@col41,col42=@col42,col49=@col49  where col17=@col17 and col18=@col18 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        
        public void UpdateDataziliao(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu22 set col33=@col33,col34=@col34,col35=@col35,
    col36=@col36,col37=@col37,col38=@col38,col48=@col48  where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        //资料shenji
        public void UpdateDataziliaoshenji(string str1, string str2)
        {
            Sql.SqlQuery("update t_caiwu22 set col38 =  '" + str1 + "' where col43= '" + str2 + "' ");
        }

        //项目部更新金额 开票端也要更新
        public void UpdateData开票端()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();

                string cmdText = @"Update t_caiwu22 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6,col7=@col7,col8=@col8,col9=@col9,col10=@col10,
col11=@col11,col12=@col12,col13=@col13,
    col14=@col14,col15=@col15,col16=@col16,col45=@col45,col46=@col46,col47=@col47 where col43=@col43  ";

//                string cmdText = @"Update t_caiwu22 set col11=@col11,col12=@col12,col13=@col13,
//    col14=@col14,col15=@col15,col16=@col16,col45=@col45,col46=@col46 where col5=@col5 and col8=@col8 and col9=@col9 and col47=@col47  ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;

                //oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col5"].Value = this.col5;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col8"].Value = this.col8;

                //oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
            
        }

        //资料打回
        public void UpdateDataziliao2(int id)
        {
            Sql.SqlQuery("update t_caiwu22 set col38 = '0' where ID=" + id);
        }

        public void DeleteData(string id)
        {
            Sql.SqlQuery("delete from t_caiwu22 where col18='" + id + "' ");
        }

        public void DeleteData2(int id)
        {
            Sql.SqlQuery("delete from t_caiwu22 where id=" + id + " ");
        }

        //
        public void UpdateData审核(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu22 set col50=@col50  where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class xiangmu2List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }

        public string CheckUploadResult;


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_xiangmu2(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu2 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19 ,col20=@col20 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

       

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_xiangmu2 where ID=" + id);
        }


    }


    //发票
    public class caiwu3List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }

        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }//
        public string col30 { set; get; }
        public string col31 { set; get; }//remark

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu3 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    //this.col30 = oleDbDataReader["col30"].ToString();
                    //this.col31 = oleDbDataReader["col31"].ToString();
                    //this.col32 = oleDbDataReader["col32"].ToString();
                    //this.col33 = oleDbDataReader["col33"].ToString();
                    //this.col34 = oleDbDataReader["col34"].ToString();
                    //this.col35 = oleDbDataReader["col35"].ToString();
                    //this.col36 = oleDbDataReader["col36"].ToString();
                    //this.col37 = oleDbDataReader["col37"].ToString();
                    //this.col38 = oleDbDataReader["col38"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu3(col1,col2,col3,col4,col5,col6,col7,col8
) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col9"].Value = this.col9;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col10"].Value = this.col10;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col11"].Value = this.col11;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col12"].Value = this.col12;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col13"].Value = this.col13;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col14"].Value = this.col14;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col15"].Value = this.col15;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col16"].Value = this.col16;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col17"].Value = this.col17;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col18"].Value = this.col18;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col19"].Value = this.col19;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col20"].Value = this.col20;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col21"].Value = this.col21;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col22"].Value = this.col22;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col23"].Value = this.col23;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col24"].Value = this.col24;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col25"].Value = this.col25;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col26"].Value = this.col26;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col27"].Value = this.col27;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col28"].Value = this.col28;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col29"].Value = this.col29;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu3 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(string col8)
        {
            Sql.SqlQuery("delete from t_caiwu3 where col8= '" + col8 + "'");
        }


    }

    //收款
    public class caiwu4List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }

        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }//
        public string col30 { set; get; }
        public string col31 { set; get; }//remark

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu4 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    //this.col32 = oleDbDataReader["col32"].ToString();
                    //this.col33 = oleDbDataReader["col33"].ToString();
                    //this.col34 = oleDbDataReader["col34"].ToString();
                    //this.col35 = oleDbDataReader["col35"].ToString();
                    //this.col36 = oleDbDataReader["col36"].ToString();
                    //this.col37 = oleDbDataReader["col37"].ToString();
                    //this.col38 = oleDbDataReader["col38"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu4(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu4 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29,col30=@col30,col31=@col31 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_caiwu4 where ID=" + id);
        }


    }

    //结算
    public class caiwu5List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }

        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }//remark

        public string col30 { set; get; }
        public string col31 { set; get; }
        public string col32 { set; get; }
        public string col33 { set; get; }
        public string col34 { set; get; }
        public string col35 { set; get; }
        public string col36 { set; get; }
        public string col37 { set; get; }
        public string col38 { set; get; }
        public string col39 { set; get; }
        public string col40 { set; get; }
        public string col41 { set; get; }
        public string col42 { set; get; }
        public string col43 { set; get; }
        public string col44 { set; get; }
        public string col45 { set; get; }
        public string col46 { set; get; }
        public string col47 { set; get; }
        public string col48 { set; get; }
        public string col49 { set; get; }
        public string col50 { set; get; }
        public string col51 { set; get; }
        public string col52 { set; get; }
        public string col53 { set; get; }
        public string col54 { set; get; }
        public string col55 { set; get; }

        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu5 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();
                    this.col34 = oleDbDataReader["col34"].ToString();
                    this.col35 = oleDbDataReader["col35"].ToString();
                    this.col36 = oleDbDataReader["col36"].ToString();
                    this.col37 = oleDbDataReader["col37"].ToString();
                    this.col38 = oleDbDataReader["col38"].ToString();
                    this.col39 = oleDbDataReader["col39"].ToString();
                    this.col40 = oleDbDataReader["col40"].ToString();
                    this.col41 = oleDbDataReader["col41"].ToString();
                    this.col42 = oleDbDataReader["col42"].ToString();
                    this.col43 = oleDbDataReader["col43"].ToString();
                    this.col44 = oleDbDataReader["col44"].ToString();
                    this.col45 = oleDbDataReader["col45"].ToString();
                    this.col46 = oleDbDataReader["col46"].ToString();
                    this.col47 = oleDbDataReader["col47"].ToString();
                    this.col48 = oleDbDataReader["col48"].ToString();
                    this.col49 = oleDbDataReader["col49"].ToString();
                    this.col50 = oleDbDataReader["col50"].ToString();
                    this.col51 = oleDbDataReader["col51"].ToString();
                    this.col52 = oleDbDataReader["col52"].ToString();
                    //this.col53 = oleDbDataReader["col53"].ToString();
                    //this.col54 = oleDbDataReader["col54"].ToString();
                    //this.col55 = oleDbDataReader["col55"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu5(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32,col33,col34,col35,col36,col37,col38,col39,col40,col41
,col42,col43,col44,col45,col46,col47,col48,col49,col50,col51,col53) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32,@col33,@col34,@col35,@col36,@col37,@col38
,@col39,@col40,@col41,@col42,@col43,@col44,@col45,@col46,@col47,@col48,@col49,@col50,@col51,@col53)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col51"].Value = this.col51;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col52", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col52"].Value = this.col52;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col53", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col53"].Value = this.col53;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col54", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col54"].Value = this.col54;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col55", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col55"].Value = this.col55;

                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu5 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29
,col30=@col30,col31=@col31,col32=@col32,col33=@col33,col34=@col34,col35=@col35
,col36=@col36,col37=@col37,col38=@col38,col39=@col39,col40=@col40,col41=@col41
,col42=@col42,col43=@col43,col44=@col44,col45=@col45,col46=@col46,col47=@col47
,col48=@col48,col49=@col49,col50=@col50,col51=@col51,col53=@col53 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col35", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col35"].Value = this.col35;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col36", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col36"].Value = this.col36;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col37", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col37"].Value = this.col37;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col38", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col38"].Value = this.col38;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col39", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col39"].Value = this.col39;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col40", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col40"].Value = this.col40;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col41", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col41"].Value = this.col41;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col42", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col42"].Value = this.col42;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col44", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col44"].Value = this.col44;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col45", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col45"].Value = this.col45;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col46", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col46"].Value = this.col46;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col47", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col47"].Value = this.col47;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col51", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col51"].Value = this.col51;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col52", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col52"].Value = this.col52;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col53", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col53"].Value = this.col53;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col54", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col54"].Value = this.col54;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col55", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col55"].Value = this.col55;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_caiwu5 where ID=" + id);
        }

        public void UpdateDatashenhe(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu5 set col43=@col43,col48=@col48,col49=@col49,col50=@col50,col52=@col52,col54=@col54 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col52", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col52"].Value = this.col52;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col54", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col54"].Value = this.col54;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateDatashenhe2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu5 set col43=@col43,col48=@col48,col49=@col49,col50=@col50,col52=@col52,col54=@col54 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col43", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col43"].Value = this.col43;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col48", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col48"].Value = this.col48;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col49", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col49"].Value = this.col49;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col50", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col50"].Value = this.col50;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col52", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col52"].Value = this.col52;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col54", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col54"].Value = this.col54;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    //收款明细
    public class caiwu51List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
       

        public string CheckUploadResult;

       
        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu51(col1,col2,col3,col4,col5,col6,col7,col8) 
    values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
               
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu51 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu51 set col9=@col9 where col1=@col1 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                
                
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

       

    }


    public class caiwu55List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        //public string col12 { set; get; }
        //public string col13 { set; get; }
        //public string col14 { set; get; }
        //public string col15 { set; get; }
        //public string col16 { set; get; }
        //public string col17 { set; get; }
        //public string col18 { set; get; }
        //public string col19 { set; get; }
        //public string col20 { set; get; }

        public string CheckUploadResult;

        public void GetData(string id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu55 where col18=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    //this.col12 = oleDbDataReader["col12"].ToString();
                    //this.col13 = oleDbDataReader["col13"].ToString();
                    //this.col14 = oleDbDataReader["col14"].ToString();
                    //this.col15 = oleDbDataReader["col15"].ToString();
                    //this.col16 = oleDbDataReader["col16"].ToString();
                    //this.col17 = oleDbDataReader["col17"].ToString();
                    //this.col18 = oleDbDataReader["col18"].ToString();
                    //this.col19 = oleDbDataReader["col19"].ToString();
                    //this.col20 = oleDbDataReader["col20"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu55(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col12"].Value = this.col12;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col13"].Value = this.col13;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col14"].Value = this.col14;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col15"].Value = this.col15;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col16"].Value = this.col16;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col17"].Value = this.col17;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col18"].Value = this.col18;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col19"].Value = this.col19;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col20"].Value = this.col20;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu55 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(string col8)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu55 set col10=@col10,col11=@col11  where col8=@col8 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = col8;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_caiwu55 where ID=" + id);
        }


    }

    //t_quanxian
    public class quanxianList
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        //public string col5 { set; get; }
        //public string col6 { set; get; }
        //public string col7 { set; get; }
        //public string col8 { set; get; }
        //public string col9 { set; get; }
        //public string col10 { set; get; }
        //public string col11 { set; get; }
        //public string col12 { set; get; }
        //public string col13 { set; get; }
        //public string col14 { set; get; }
        //public string col15 { set; get; }
        //public string col16 { set; get; }
        //public string col17 { set; get; }
        //public string col18 { set; get; }
        //public string col19 { set; get; }
        //public string col20 { set; get; }

        public string CheckUploadResult;

        public void GetData(string col4)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_quanxian where col4=@col4";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.Integer));
                oleDbCommand.Parameters["@col4"].Value = col4;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    //this.col5 = oleDbDataReader["col5"].ToString();
                    //this.col6 = oleDbDataReader["col6"].ToString();
                    //this.col7 = oleDbDataReader["col7"].ToString();
                    //this.col8 = oleDbDataReader["col8"].ToString();
                    //this.col9 = oleDbDataReader["col9"].ToString();
                    //this.col10 = oleDbDataReader["col10"].ToString();
                    //this.col11 = oleDbDataReader["col11"].ToString();
                    //this.col12 = oleDbDataReader["col12"].ToString();
                    //this.col13 = oleDbDataReader["col13"].ToString();
                    //this.col14 = oleDbDataReader["col14"].ToString();
                    //this.col15 = oleDbDataReader["col15"].ToString();
                    //this.col16 = oleDbDataReader["col16"].ToString();
                    //this.col17 = oleDbDataReader["col17"].ToString();
                    //this.col18 = oleDbDataReader["col18"].ToString();
                    //this.col19 = oleDbDataReader["col19"].ToString();
                    //this.col20 = oleDbDataReader["col20"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_quanxian(col1,col2,col3,col4) 
values (@col1,@col2,@col3,@col4)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col5"].Value = this.col5;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col6"].Value = this.col6;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col7"].Value = this.col7;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col8"].Value = this.col8;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col9"].Value = this.col9;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col10"].Value = this.col10;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col11"].Value = this.col11;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col12"].Value = this.col12;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col13"].Value = this.col13;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col14"].Value = this.col14;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col15"].Value = this.col15;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col16"].Value = this.col16;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col17"].Value = this.col17;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col18"].Value = this.col18;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col19"].Value = this.col19;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col20"].Value = this.col20;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_quanxian set col1=@col1,col2=@col2,col3=@col3,col4=@col4  where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col5"].Value = this.col5;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col6"].Value = this.col6;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col7"].Value = this.col7;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col8"].Value = this.col8;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col9"].Value = this.col9;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col10"].Value = this.col10;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col11"].Value = this.col11;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(string col4)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_quanxian set col2=@col2 where col4=@col4 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = col4;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }




    }


    //t_zhuangtai
    public class zhuangtaiList
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        //public string col4 { set; get; }
        //public string col5 { set; get; }
        //public string col6 { set; get; }
        //public string col7 { set; get; }
        //public string col8 { set; get; }
        //public string col9 { set; get; }
        //public string col10 { set; get; }
        //public string col11 { set; get; }
        //public string col12 { set; get; }
        //public string col13 { set; get; }
        //public string col14 { set; get; }
        //public string col15 { set; get; }
        //public string col16 { set; get; }
        //public string col17 { set; get; }
        //public string col18 { set; get; }
        //public string col19 { set; get; }
        //public string col20 { set; get; }

        public string CheckUploadResult;

        public void GetData(string col1)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_zhuangtai where col1=@col1";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.Integer));
                oleDbCommand.Parameters["@col1"].Value = col1;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    //this.col4 = oleDbDataReader["col4"].ToString();
                    //this.col5 = oleDbDataReader["col5"].ToString();
                    //this.col6 = oleDbDataReader["col6"].ToString();
                    //this.col7 = oleDbDataReader["col7"].ToString();
                    //this.col8 = oleDbDataReader["col8"].ToString();
                    //this.col9 = oleDbDataReader["col9"].ToString();
                    //this.col10 = oleDbDataReader["col10"].ToString();
                    //this.col11 = oleDbDataReader["col11"].ToString();
                    //this.col12 = oleDbDataReader["col12"].ToString();
                    //this.col13 = oleDbDataReader["col13"].ToString();
                    //this.col14 = oleDbDataReader["col14"].ToString();
                    //this.col15 = oleDbDataReader["col15"].ToString();
                    //this.col16 = oleDbDataReader["col16"].ToString();
                    //this.col17 = oleDbDataReader["col17"].ToString();
                    //this.col18 = oleDbDataReader["col18"].ToString();
                    //this.col19 = oleDbDataReader["col19"].ToString();
                    //this.col20 = oleDbDataReader["col20"].ToString();

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_zhuangtai(col1,col2,col3) 
values (@col1,@col2,@col3)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col4"].Value = this.col4;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col5"].Value = this.col5;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col6"].Value = this.col6;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col7"].Value = this.col7;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col8"].Value = this.col8;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col9"].Value = this.col9;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col10"].Value = this.col10;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col11"].Value = this.col11;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col12"].Value = this.col12;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col13"].Value = this.col13;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col14"].Value = this.col14;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col15"].Value = this.col15;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col16"].Value = this.col16;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col17"].Value = this.col17;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col18"].Value = this.col18;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col19"].Value = this.col19;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col20"].Value = this.col20;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_zhuangtai set col1=@col1,col2=@col2  where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col3"].Value = this.col3;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col4"].Value = this.col4;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col5"].Value = this.col5;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col6"].Value = this.col6;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col7"].Value = this.col7;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col8"].Value = this.col8;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col9"].Value = this.col9;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col10"].Value = this.col10;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col11"].Value = this.col11;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(string col1)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_zhuangtai set col2=@col2 where col1=@col1 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = col1;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }




    }

    //项目部 项目经理
    public class hetong33List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public int col8 { set; get; }
        
        public string CheckUploadResult;

        public void GetData(string id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu22 where col18=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_hetong33(col1,col2,col3,col4,col5,col6,col7,col8) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.Integer));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hetong33 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
               

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(string col17)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_hetong33 set col5=@col5,col6=@col6,col7=@col7  where col4=@col4 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = col4;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_hetong33 where ID=" + id);
        }


    }


    //审核管理
    public class shenheList
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        
        public string CheckUploadResult;

       
        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_shenhe(col1,col2) 
values (@col1,@col2)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_shenhe set col1=@col1,col2=@col2 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(string col1, string col2)
        {
            Sql.SqlQuery("delete from t_shenhe where col1='" + col1 + "' and col2='" + col2 + "' ");
        }


    }

    //审核管理2
    public class shenhe2List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }

        public string CheckUploadResult;


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_shenhe2(col1,col2) 
values (@col1,@col2)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_shenhe2 set col1=@col1,col2=@col2 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(string col1, string col2)
        {
            Sql.SqlQuery("delete from t_shenhe2 where col1='" + col1 + "' and col2='" + col2 + "' ");
        }


    }

    //审核管理3
    public class shenhe3List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }

        public string CheckUploadResult;


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_shenhe3(col1,col2) 
values (@col1,@col2)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_shenhe3 set col1=@col1,col2=@col2 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(string col1, string col2)
        {
            Sql.SqlQuery("delete from t_shenhe3 where col1='" + col1 + "' and col2='" + col2 + "' ");
        }


    }


    //附件List
    public class 附件List
    {
        public int ID { set; get; }
        public string flag { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }

        public string CheckUploadResult;


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_fujian(flag,col1,col2,col3) 
values (@flag,@col1,@col2,@col3)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@flag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@flag"].Value = this.flag;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;

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

        public void DeleteData(int ID)
        {
            Sql.SqlQuery("delete from t_fujian where ID=" + ID + " ");
        }

        public void DeleteData2(string str1, string str2, string str3)
        {
            Sql.SqlQuery("delete from t_fujian where flag='" + str1 + "' and col1='" + str2 + "'  and col3='" + str3 + "' ");
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_fujian set col1=@col1 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData22(int id,string flag)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_fujian set col1=@col1 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public int InsertData2()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_fujian(flag,col1,col2,col3,col4,col5,col6,col7,col8) 
values (@flag,@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@flag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@flag"].Value = this.flag;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;

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

        public void UpdateData2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_fujian set col6=@col6,col7=@col7,col8=@col8 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData3()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_fujian set col9=@col9 where col1=@col1 and flag=@flag ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@flag", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@flag"].Value = this.flag;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData3()
        {
            Sql.SqlQuery("delete from t_fujian where flag='" + this.flag + "' and col1='" + this.col1 + "' ");
               
        }


    }

    // 批量下载
    public class DownLoadList
    {
        //批量下载
        
    }


    public class xiangmu3List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
       //合同id


        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu3 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_xiangmu3(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu3 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19 ,col20=@col20 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_xiangmu3 where ID=" + id);
        }

        public void GetAllData2(string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu3 where 1= 1 and col1 = @col1 and col2 = @col2 and col3 = @col3 and col4 = @col4 and col5 = @col5 and col6 = @col6 and col7 = @col7 and col8 = @col8 and col9 = @col9  ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = str2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = str3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = str4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = str5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = str6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = str7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = str8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = str9;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                   
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class xiangmu31List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        
        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu31 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_xiangmu31(col1,col2,col3,col4) 
values (@col1,@col2,@col3,@col4)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
               
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu31 set col1=@col1,col2=@col2,col3=@col3,col4=@col4 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu31 set col5=@col5 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }


        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_xiangmu31 where ID=" + id);
        }

        public void GetAllData2(string str1, string str2)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu31 where 1= 1 and col1 = @col1 and col2 = @col2  ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = str2;
               
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    public class xiangmu32List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        
        //合同id


        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu32 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_xiangmu32(col1,col2,col3,col4,col5,col6) 
values (@col1,@col2,@col3,@col4,@col5,@col6)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col7"].Value = this.col7;
                

                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu32 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                //oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                //oleDbCommand.Parameters["@col7"].Value = this.col7;
               

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_xiangmu32 set col7=@col7 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_xiangmu32 where ID=" + id);
        }

        public void GetAllData2(string str1, string str2, string str3, string str4)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_xiangmu32 where 1= 1 and col1 = @col1 and col2 = @col2 and col3 = @col3 and col4 = @col4  ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = str1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = str2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = str3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = str4;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    //this.col7 = oleDbDataReader["col7"].ToString();
                    
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    //付款
    public class caiwu8List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }
        public string col15 { set; get; }
        public string col16 { set; get; }
        public string col17 { set; get; }
        public string col18 { set; get; }
        public string col19 { set; get; }
        public string col20 { set; get; }
        public string col21 { set; get; }
        public string col22 { set; get; }
        public string col23 { set; get; }
        public string col24 { set; get; }

        public string col25 { set; get; }
        public string col26 { set; get; }
        public string col27 { set; get; }
        public string col28 { set; get; }
        public string col29 { set; get; }//remark

        public string col30 { set; get; }
        public string col31 { set; get; }
        public string col32 { set; get; }
        public string col33 { set; get; }
        public string col34 { set; get; }
       
        public string CheckUploadResult;

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from t_caiwu8 where ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this.ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this.col1 = oleDbDataReader["col1"].ToString();
                    this.col2 = oleDbDataReader["col2"].ToString();
                    this.col3 = oleDbDataReader["col3"].ToString();
                    this.col4 = oleDbDataReader["col4"].ToString();
                    this.col5 = oleDbDataReader["col5"].ToString();
                    this.col6 = oleDbDataReader["col6"].ToString();
                    this.col7 = oleDbDataReader["col7"].ToString();
                    this.col8 = oleDbDataReader["col8"].ToString();
                    this.col9 = oleDbDataReader["col9"].ToString();
                    this.col10 = oleDbDataReader["col10"].ToString();
                    this.col11 = oleDbDataReader["col11"].ToString();
                    this.col12 = oleDbDataReader["col12"].ToString();
                    this.col13 = oleDbDataReader["col13"].ToString();
                    this.col14 = oleDbDataReader["col14"].ToString();
                    this.col15 = oleDbDataReader["col15"].ToString();
                    this.col16 = oleDbDataReader["col16"].ToString();
                    this.col17 = oleDbDataReader["col17"].ToString();
                    this.col18 = oleDbDataReader["col18"].ToString();
                    this.col19 = oleDbDataReader["col19"].ToString();
                    this.col20 = oleDbDataReader["col20"].ToString();
                    this.col21 = oleDbDataReader["col21"].ToString();
                    this.col22 = oleDbDataReader["col22"].ToString();
                    this.col23 = oleDbDataReader["col23"].ToString();
                    this.col24 = oleDbDataReader["col24"].ToString();
                    this.col25 = oleDbDataReader["col25"].ToString();
                    this.col26 = oleDbDataReader["col26"].ToString();
                    this.col27 = oleDbDataReader["col27"].ToString();
                    this.col28 = oleDbDataReader["col28"].ToString();
                    this.col29 = oleDbDataReader["col29"].ToString();
                    this.col30 = oleDbDataReader["col30"].ToString();
                    this.col31 = oleDbDataReader["col31"].ToString();
                    this.col32 = oleDbDataReader["col32"].ToString();
                    this.col33 = oleDbDataReader["col33"].ToString();
                   

                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu8(col1,col2,col3,col4,col5,col6,col7,col8
,col9,col10,col11,col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23
,col24,col25,col26,col27,col28,col29,col30,col31,col32,col33) 
values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8
,@col9,@col10,@col11,@col12,@col13,@col14,@col15,@col16,@col17,@col18,@col19,@col20,@col21,@col22,@col23
,@col24,@col25,@col26,@col27,@col28,@col29,@col30,@col31,@col32,@col33)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
                
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu8 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10,col11=@col11,col12=@col12,col13=@col13,col14=@col14
                ,col15=@col15,col16=@col16,col17=@col17,col18=@col18,col19=@col19,col20=@col20,col21=@col21,col22=@col22,col23=@col23
,col24=@col24,col25=@col25,col26=@col26,col27=@col27,col28=@col28,col29=@col29
,col30=@col30,col31=@col31,col32=@col32,col33=@col33 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col15", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col15"].Value = this.col15;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col16", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col16"].Value = this.col16;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col17", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col17"].Value = this.col17;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col18", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col18"].Value = this.col18;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col19", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col19"].Value = this.col19;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col20", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col20"].Value = this.col20;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col21", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col21"].Value = this.col21;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col22", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col22"].Value = this.col22;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col23", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col23"].Value = this.col23;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col24", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col24"].Value = this.col24;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col27", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col27"].Value = this.col27;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col28", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col28"].Value = this.col28;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col29", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col29"].Value = this.col29;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from t_caiwu8 where ID=" + id);
        }

        public void UpdateDatashenhe(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu8 set col25=@col25,col30=@col30,col31=@col31,col32=@col32,col33=@col33 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col30", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col30"].Value = this.col30;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col31", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col31"].Value = this.col31;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col32", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col32"].Value = this.col32;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col33", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col33"].Value = this.col33;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateDatashenhe2(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu8 set col25=@col25,col26=@col26,col34=@col34 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col25", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col25"].Value = this.col25;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col26", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col26"].Value = this.col26;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col34", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col34"].Value = this.col34;
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }

    //付款明细
    public class caiwu81List
    {
        public int ID { set; get; }
        public string col1 { set; get; }
        public string col2 { set; get; }
        public string col3 { set; get; }
        public string col4 { set; get; }
        public string col5 { set; get; }
        public string col6 { set; get; }
        public string col7 { set; get; }
        public string col8 { set; get; }
        public string col9 { set; get; }
        public string col10 { set; get; }
        public string col11 { set; get; }
        public string col12 { set; get; }
        public string col13 { set; get; }
        public string col14 { set; get; }

        public string CheckUploadResult;


        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = @"insert into t_caiwu81(col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col11,col12,col13,col14) 
    values (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8,@col9,@col10,@col11,@col12,@col13,@col14)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col11", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col11"].Value = this.col11;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col12", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col12"].Value = this.col12;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col13", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col13"].Value = this.col13;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col14", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col14"].Value = this.col14;

                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
                this.ID = result;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu51 set col1=@col1,col2=@col2,col3=@col3,col4=@col4,col5=@col5,col6=@col6
                ,col7=@col7,col8=@col8,col9=@col9,col10=@col10 where ID=@ID ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col2", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col2"].Value = this.col2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col3", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col3"].Value = this.col3;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col4", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col4"].Value = this.col4;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col5", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col5"].Value = this.col5;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col6", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col6"].Value = this.col6;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col7", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col7"].Value = this.col7;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col8", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col8"].Value = this.col8;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;
                oleDbCommand.Parameters.Add(new OleDbParameter("@col10", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col10"].Value = this.col10;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = id;

                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData2()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"Update t_caiwu51 set col9=@col9 where col1=@col1 ";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@col9", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col9"].Value = this.col9;

                oleDbCommand.Parameters.Add(new OleDbParameter("@col1", OleDbType.VarChar, 255));
                oleDbCommand.Parameters["@col1"].Value = this.col1;


                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }



    }



}
