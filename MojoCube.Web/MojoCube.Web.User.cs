using System;
using System.Data.OleDb;
using System.Web;

namespace MojoCube.Web.User
{
    public class Department
    {
        private int _pk_Department;

        private string _DepartmentName;

        private string _Phone1;

        private string _Phone2;

        private string _Fax;

        private string _Email;

        private string _Address;

        private int _ParentID;

        private int _LevelID;

        private int _SortID;

        private int _TypeID;

        private int _Province;

        private int _City;

        private int _County;

        private int _Zone;

        private int _Manager;

        private int _fk_Company;

        private int _CreateUser;

        private string _CreateDate;

        private int _ModifyUser;

        private string _ModifyDate;

        private string _Monday;

        private string _Tuesday;

        private string _Wednesday;

        private string _Thursday;

        private string _Friday;

        private string _Saturday;

        private string _Sunday;

        public int pk_Department
        {
            get
            {
                return this._pk_Department;
            }
            set
            {
                this._pk_Department = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return this._DepartmentName;
            }
            set
            {
                this._DepartmentName = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this._ParentID = value;
            }
        }

        public int LevelID
        {
            get
            {
                return this._LevelID;
            }
            set
            {
                this._LevelID = value;
            }
        }

        public int SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                this._SortID = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public int Province
        {
            get
            {
                return this._Province;
            }
            set
            {
                this._Province = value;
            }
        }

        public int City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        public int County
        {
            get
            {
                return this._County;
            }
            set
            {
                this._County = value;
            }
        }

        public int Zone
        {
            get
            {
                return this._Zone;
            }
            set
            {
                this._Zone = value;
            }
        }

        public int Manager
        {
            get
            {
                return this._Manager;
            }
            set
            {
                this._Manager = value;
            }
        }

        public int fk_Company
        {
            get
            {
                return this._fk_Company;
            }
            set
            {
                this._fk_Company = value;
            }
        }

        public int CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                this._CreateUser = value;
            }
        }

        public string CreateDate
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

        public int ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                this._ModifyUser = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public string Monday
        {
            get
            {
                return this._Monday;
            }
            set
            {
                this._Monday = value;
            }
        }

        public string Tuesday
        {
            get
            {
                return this._Tuesday;
            }
            set
            {
                this._Tuesday = value;
            }
        }

        public string Wednesday
        {
            get
            {
                return this._Wednesday;
            }
            set
            {
                this._Wednesday = value;
            }
        }

        public string Thursday
        {
            get
            {
                return this._Thursday;
            }
            set
            {
                this._Thursday = value;
            }
        }

        public string Friday
        {
            get
            {
                return this._Friday;
            }
            set
            {
                this._Friday = value;
            }
        }

        public string Saturday
        {
            get
            {
                return this._Saturday;
            }
            set
            {
                this._Saturday = value;
            }
        }

        public string Sunday
        {
            get
            {
                return this._Sunday;
            }
            set
            {
                this._Sunday = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from User_Department where pk_Department=@pk_Department";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Department", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Department"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Department = Convert.ToInt32(oleDbDataReader["pk_Department"].ToString());
                    this._DepartmentName = oleDbDataReader["DepartmentName"].ToString();
                    this._Phone1 = oleDbDataReader["Phone1"].ToString();
                    this._Phone2 = oleDbDataReader["Phone2"].ToString();
                    this._Fax = oleDbDataReader["Fax"].ToString();
                    this._Email = oleDbDataReader["Email"].ToString();
                    this._Address = oleDbDataReader["Address"].ToString();
                    this._ParentID = Convert.ToInt32(oleDbDataReader["ParentID"].ToString());
                    this._LevelID = Convert.ToInt32(oleDbDataReader["LevelID"].ToString());
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._Province = Convert.ToInt32(oleDbDataReader["Province"].ToString());
                    this._City = Convert.ToInt32(oleDbDataReader["City"].ToString());
                    this._County = Convert.ToInt32(oleDbDataReader["County"].ToString());
                    this._Zone = Convert.ToInt32(oleDbDataReader["Zone"].ToString());
                    this._Manager = Convert.ToInt32(oleDbDataReader["Manager"].ToString());
                    this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
                    this._CreateUser = Convert.ToInt32(oleDbDataReader["CreateUser"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._ModifyUser = Convert.ToInt32(oleDbDataReader["ModifyUser"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    this._Monday = oleDbDataReader["Monday"].ToString();
                    this._Tuesday = oleDbDataReader["Tuesday"].ToString();
                    this._Wednesday = oleDbDataReader["Wednesday"].ToString();
                    this._Thursday = oleDbDataReader["Thursday"].ToString();
                    this._Friday = oleDbDataReader["Friday"].ToString();
                    this._Saturday = oleDbDataReader["Saturday"].ToString();
                    this._Sunday = oleDbDataReader["Sunday"].ToString();
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
                string cmdText = "insert into User_Department(DepartmentName,Phone1,Phone2,Fax,Email,Address,ParentID,LevelID,SortID,TypeID,Province,City,County,[Zone],Manager,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday) values (@DepartmentName,@Phone1,@Phone2,@Fax,@Email,@Address,@ParentID,@LevelID,@SortID,@TypeID,@Province,@City,@County,@Zone,@Manager,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday,@Sunday)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@DepartmentName", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@DepartmentName"].Value = this._DepartmentName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Phone1", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Phone1"].Value = this._Phone1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Phone2", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Phone2"].Value = this._Phone2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Fax", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Fax"].Value = this._Fax;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Email"].Value = this._Email;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Address", OleDbType.VarChar, 500));
                oleDbCommand.Parameters["@Address"].Value = this._Address;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LevelID", OleDbType.Integer));
                oleDbCommand.Parameters["@LevelID"].Value = this._LevelID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Province", OleDbType.Integer));
                oleDbCommand.Parameters["@Province"].Value = this._Province;
                oleDbCommand.Parameters.Add(new OleDbParameter("@City", OleDbType.Integer));
                oleDbCommand.Parameters["@City"].Value = this._City;
                oleDbCommand.Parameters.Add(new OleDbParameter("@County", OleDbType.Integer));
                oleDbCommand.Parameters["@County"].Value = this._County;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Zone", OleDbType.Integer));
                oleDbCommand.Parameters["@Zone"].Value = this._Zone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Manager", OleDbType.Integer));
                oleDbCommand.Parameters["@Manager"].Value = this._Manager;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUser"].Value = this._CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUser", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUser"].Value = this._ModifyUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Monday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Monday"].Value = this._Monday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tuesday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Tuesday"].Value = this._Tuesday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Wednesday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Wednesday"].Value = this._Wednesday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Thursday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Thursday"].Value = this._Thursday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Friday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Friday"].Value = this._Friday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Saturday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Saturday"].Value = this._Saturday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Sunday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Sunday"].Value = this._Sunday;
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
                string cmdText = "update User_Department set DepartmentName=@DepartmentName,Phone1=@Phone1,Phone2=@Phone2,Fax=@Fax,Email=@Email,Address=@Address,ParentID=@ParentID,LevelID=@LevelID,SortID=@SortID,TypeID=@TypeID,Province=@Province,City=@City,County=@County,[Zone]=@Zone,Manager=@Manager,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate,Monday=@Monday,Tuesday=@Tuesday,Wednesday=@Wednesday,Thursday=@Thursday,Friday=@Friday,Saturday=@Saturday,Sunday=@Sunday where pk_Department=@pk_Department";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@DepartmentName", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@DepartmentName"].Value = this._DepartmentName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Phone1", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Phone1"].Value = this._Phone1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Phone2", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Phone2"].Value = this._Phone2;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Fax", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Fax"].Value = this._Fax;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Email"].Value = this._Email;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Address", OleDbType.VarChar, 500));
                oleDbCommand.Parameters["@Address"].Value = this._Address;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LevelID", OleDbType.Integer));
                oleDbCommand.Parameters["@LevelID"].Value = this._LevelID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Province", OleDbType.Integer));
                oleDbCommand.Parameters["@Province"].Value = this._Province;
                oleDbCommand.Parameters.Add(new OleDbParameter("@City", OleDbType.Integer));
                oleDbCommand.Parameters["@City"].Value = this._City;
                oleDbCommand.Parameters.Add(new OleDbParameter("@County", OleDbType.Integer));
                oleDbCommand.Parameters["@County"].Value = this._County;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Zone", OleDbType.Integer));
                oleDbCommand.Parameters["@Zone"].Value = this._Zone;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Manager", OleDbType.Integer));
                oleDbCommand.Parameters["@Manager"].Value = this._Manager;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUser"].Value = this._CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUser", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUser"].Value = this._ModifyUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Monday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Monday"].Value = this._Monday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tuesday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Tuesday"].Value = this._Tuesday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Wednesday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Wednesday"].Value = this._Wednesday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Thursday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Thursday"].Value = this._Thursday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Friday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Friday"].Value = this._Friday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Saturday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Saturday"].Value = this._Saturday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Sunday", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Sunday"].Value = this._Sunday;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Department", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Department"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from User_Department where pk_Department=" + id);
        }
    }

    public class List
    {
        private int _pk_User;

        private string _UserName;

        private string _Password;

        private int _TypeID;

        private int _fk_Department;

        private int _RoleValue;

        private string _RoleList;

        private int _Position;

        private string _Number;

        private string _Skin;

        private string _Language;

        private bool _IsLock;

        private string _LastLoginIP;

        private string _LastLoginTime;

        private string _NickName;

        private string _FullName;

        private string _FirstName;

        private string _MiddleName;

        private string _LastName;

        private string _Phone1;

        private string _Phone2;

        private string _Email1;

        private string _Email2;

        private string _Fax;

        private string _Line;

        private string _Wechat;

        private string _QQ;

        private string _Facebook;

        private string _Twitter;

        private string _Linkedin;

        private string _ZipCode;

        private string _Place;

        private string _Address1;

        private string _Address2;
        private string _xiangmu;

        private int _Province;

        private int _City;

        private int _County;

        private int _Zone;

        private int _Sex;

        private int _Height;

        private int _Weight;

        private string _Birthday;

        private string _Education;

        private string _School;

        private string _ImagePath1;

        private string _ImagePath2;

        private string _IDCardPath;

        private string _ResumePath;

        private decimal _Wages;

        private string _BankAccount;

        private string _IDNumber;

        private string _Source;

        private string _Note;

        private string _Remark;

        private string _EntryTime;

        private bool _IsQuit;

        private string _QuitTime;

        private int _ShowHistory;

        private int _fk_Company;

        private int _CreateUser;

        private string _CreateDate;

        private int _ModifyUser;

        private string _ModifyDate;

        public int pk_User
        {
            get
            {
                return this._pk_User;
            }
            set
            {
                this._pk_User = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
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

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public int fk_Department
        {
            get
            {
                return this._fk_Department;
            }
            set
            {
                this._fk_Department = value;
            }
        }

        public int RoleValue
        {
            get
            {
                return this._RoleValue;
            }
            set
            {
                this._RoleValue = value;
            }
        }

        public string xiangmu
        {
            get
            {
                return this._xiangmu;
            }
            set
            {
                this._xiangmu = value;
            }
        }


        public string RoleList
        {
            get
            {
                return this._RoleList;
            }
            set
            {
                this._RoleList = value;
            }
        }

        public int Position
        {
            get
            {
                return this._Position;
            }
            set
            {
                this._Position = value;
            }
        }

        public string Number
        {
            get
            {
                return this._Number;
            }
            set
            {
                this._Number = value;
            }
        }

        public string Skin
        {
            get
            {
                return this._Skin;
            }
            set
            {
                this._Skin = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return this._IsLock;
            }
            set
            {
                this._IsLock = value;
            }
        }

        public string LastLoginIP
        {
            get
            {
                return this._LastLoginIP;
            }
            set
            {
                this._LastLoginIP = value;
            }
        }

        public string LastLoginTime
        {
            get
            {
                return this._LastLoginTime;
            }
            set
            {
                this._LastLoginTime = value;
            }
        }

        public string NickName
        {
            get
            {
                return this._NickName;
            }
            set
            {
                this._NickName = value;
            }
        }

        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {
                this._FullName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this._MiddleName;
            }
            set
            {
                this._MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string Email1
        {
            get
            {
                return this._Email1;
            }
            set
            {
                this._Email1 = value;
            }
        }

        public string Email2
        {
            get
            {
                return this._Email2;
            }
            set
            {
                this._Email2 = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public string Line
        {
            get
            {
                return this._Line;
            }
            set
            {
                this._Line = value;
            }
        }

        public string Wechat
        {
            get
            {
                return this._Wechat;
            }
            set
            {
                this._Wechat = value;
            }
        }

        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                this._QQ = value;
            }
        }

        public string Facebook
        {
            get
            {
                return this._Facebook;
            }
            set
            {
                this._Facebook = value;
            }
        }

        public string Twitter
        {
            get
            {
                return this._Twitter;
            }
            set
            {
                this._Twitter = value;
            }
        }

        public string Linkedin
        {
            get
            {
                return this._Linkedin;
            }
            set
            {
                this._Linkedin = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return this._ZipCode;
            }
            set
            {
                this._ZipCode = value;
            }
        }

        public string Place
        {
            get
            {
                return this._Place;
            }
            set
            {
                this._Place = value;
            }
        }

        public string Address1
        {
            get
            {
                return this._Address1;
            }
            set
            {
                this._Address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this._Address2;
            }
            set
            {
                this._Address2 = value;
            }
        }

        public int Province
        {
            get
            {
                return this._Province;
            }
            set
            {
                this._Province = value;
            }
        }

        public int City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        public int County
        {
            get
            {
                return this._County;
            }
            set
            {
                this._County = value;
            }
        }

        public int Zone
        {
            get
            {
                return this._Zone;
            }
            set
            {
                this._Zone = value;
            }
        }

        public int Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                this._Sex = value;
            }
        }

        public int Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this._Height = value;
            }
        }

        public int Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                this._Weight = value;
            }
        }

        public string Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this._Birthday = value;
            }
        }

        public string Education
        {
            get
            {
                return this._Education;
            }
            set
            {
                this._Education = value;
            }
        }

        public string School
        {
            get
            {
                return this._School;
            }
            set
            {
                this._School = value;
            }
        }

        public string ImagePath1
        {
            get
            {
                return this._ImagePath1;
            }
            set
            {
                this._ImagePath1 = value;
            }
        }

        public string ImagePath2
        {
            get
            {
                return this._ImagePath2;
            }
            set
            {
                this._ImagePath2 = value;
            }
        }

        public string IDCardPath
        {
            get
            {
                return this._IDCardPath;
            }
            set
            {
                this._IDCardPath = value;
            }
        }

        public string ResumePath
        {
            get
            {
                return this._ResumePath;
            }
            set
            {
                this._ResumePath = value;
            }
        }

        public decimal Wages
        {
            get
            {
                return this._Wages;
            }
            set
            {
                this._Wages = value;
            }
        }

        public string BankAccount
        {
            get
            {
                return this._BankAccount;
            }
            set
            {
                this._BankAccount = value;
            }
        }

        public string IDNumber
        {
            get
            {
                return this._IDNumber;
            }
            set
            {
                this._IDNumber = value;
            }
        }

        public string Source
        {
            get
            {
                return this._Source;
            }
            set
            {
                this._Source = value;
            }
        }

        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this._Note = value;
            }
        }

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }

        public string EntryTime
        {
            get
            {
                return this._EntryTime;
            }
            set
            {
                this._EntryTime = value;
            }
        }

        public bool IsQuit
        {
            get
            {
                return this._IsQuit;
            }
            set
            {
                this._IsQuit = value;
            }
        }

        public string QuitTime
        {
            get
            {
                return this._QuitTime;
            }
            set
            {
                this._QuitTime = value;
            }
        }

        public int ShowHistory
        {
            get
            {
                return this._ShowHistory;
            }
            set
            {
                this._ShowHistory = value;
            }
        }

        public int fk_Company
        {
            get
            {
                return this._fk_Company;
            }
            set
            {
                this._fk_Company = value;
            }
        }

        public int CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                this._CreateUser = value;
            }
        }

        public string CreateDate
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

        public int ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                this._ModifyUser = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from User_List where pk_User=@pk_User";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_User"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_User = Convert.ToInt32(oleDbDataReader["pk_User"].ToString());
                    this._UserName = oleDbDataReader["UserName"].ToString();
                    this._Password = oleDbDataReader["Password"].ToString();
                    //this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    //this._fk_Department = Convert.ToInt32(oleDbDataReader["fk_Department"].ToString());
                    this._RoleValue = Convert.ToInt32(oleDbDataReader["RoleValue"].ToString());
                    //this._RoleList = oleDbDataReader["RoleList"].ToString();
                    //this._Position = Convert.ToInt32(oleDbDataReader["Position"].ToString());
                    //this._Number = oleDbDataReader["Number"].ToString();
                    //this._Skin = oleDbDataReader["Skin"].ToString();
                    //this._Language = oleDbDataReader["Language"].ToString();
                    //this._IsLock = Convert.ToBoolean(oleDbDataReader["IsLock"].ToString());
                    this._LastLoginIP = oleDbDataReader["LastLoginIP"].ToString();
                    //this._LastLoginTime = oleDbDataReader["LastLoginTime"].ToString();
                    //this._NickName = oleDbDataReader["NickName"].ToString();
                    this._FullName = oleDbDataReader["FullName"].ToString();
                    //this._FirstName = oleDbDataReader["FirstName"].ToString();
                    //this._MiddleName = oleDbDataReader["MiddleName"].ToString();
                    //this._LastName = oleDbDataReader["LastName"].ToString();
                    this._Phone1 = oleDbDataReader["Phone1"].ToString();
                    this._xiangmu = oleDbDataReader["xiangmu"].ToString();
                    //this._Phone2 = oleDbDataReader["Phone2"].ToString();
                    //this._Email1 = oleDbDataReader["Email1"].ToString();
                    //this._Email2 = oleDbDataReader["Email2"].ToString();
                    //this._Fax = oleDbDataReader["Fax"].ToString();
                    //this._Line = oleDbDataReader["Line"].ToString();
                    //this._Wechat = oleDbDataReader["Wechat"].ToString();
                    //this._QQ = oleDbDataReader["QQ"].ToString();
                    //this._Facebook = oleDbDataReader["Facebook"].ToString();
                    //this._Twitter = oleDbDataReader["Twitter"].ToString();
                    //this._Linkedin = oleDbDataReader["Linkedin"].ToString();
                    //this._ZipCode = oleDbDataReader["ZipCode"].ToString();
                    //this._Place = oleDbDataReader["Place"].ToString();
                    //this._Address1 = oleDbDataReader["Address1"].ToString();
                    //this._Address2 = oleDbDataReader["Address2"].ToString();
                    //this._Province = Convert.ToInt32(oleDbDataReader["Province"].ToString());
                    //this._City = Convert.ToInt32(oleDbDataReader["City"].ToString());
                    //this._County = Convert.ToInt32(oleDbDataReader["County"].ToString());
                    //this._Zone = Convert.ToInt32(oleDbDataReader["Zone"].ToString());
                    //this._Sex = Convert.ToInt32(oleDbDataReader["Sex"].ToString());
                    //this._Height = Convert.ToInt32(oleDbDataReader["Height"].ToString());
                    //this._Weight = Convert.ToInt32(oleDbDataReader["Weight"].ToString());
                    //this._Birthday = oleDbDataReader["Birthday"].ToString();
                    //this._Education = oleDbDataReader["Education"].ToString();
                    //this._School = oleDbDataReader["School"].ToString();
                    this._ImagePath1 = oleDbDataReader["ImagePath1"].ToString();
                    //this._ImagePath2 = oleDbDataReader["ImagePath2"].ToString();
                    //this._IDCardPath = oleDbDataReader["IDCardPath"].ToString();
                    //this._ResumePath = oleDbDataReader["ResumePath"].ToString();
                    //this._Wages = Convert.ToDecimal(oleDbDataReader["Wages"].ToString());
                    //this._BankAccount = oleDbDataReader["BankAccount"].ToString();
                    //this._IDNumber = oleDbDataReader["IDNumber"].ToString();
                    //this._Source = oleDbDataReader["Source"].ToString();
                    //this._Note = oleDbDataReader["Note"].ToString();
                    //this._Remark = oleDbDataReader["Remark"].ToString();
                    //this._EntryTime = oleDbDataReader["EntryTime"].ToString();
                    //this._IsQuit = Convert.ToBoolean(oleDbDataReader["IsQuit"].ToString());
                    //this._QuitTime = oleDbDataReader["QuitTime"].ToString();
                    //this._ShowHistory = Convert.ToInt32(oleDbDataReader["ShowHistory"].ToString());
                    //this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
                    //this._CreateUser = Convert.ToInt32(oleDbDataReader["CreateUser"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    //this._ModifyUser = Convert.ToInt32(oleDbDataReader["ModifyUser"].ToString());
                    //this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
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
                string cmdText = @"insert into User_List(UserName,[Password],RoleValue,LastLoginIP,FullName,Phone1,ImagePath1,CreateDate,xiangmu)
                values (@UserName,@Password,@RoleValue,@LastLoginIP,@FullName,@Phone1,@ImagePath1,@CreateDate,@xiangmu)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@UserName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@UserName"].Value = this._UserName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Password", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Password"].Value = this._Password;

                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleValue", OleDbType.Integer));
                oleDbCommand.Parameters["@RoleValue"].Value = this._RoleValue;
             
                oleDbCommand.Parameters.Add(new OleDbParameter("@LastLoginIP", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@LastLoginIP"].Value = this._LastLoginIP;

                oleDbCommand.Parameters.Add(new OleDbParameter("@FullName", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@FullName"].Value = this._FullName;


                oleDbCommand.Parameters.Add(new OleDbParameter("@Phone1", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Phone1"].Value = this._Phone1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath1", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ImagePath1"].Value = this._ImagePath1;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@xiangmu", OleDbType.VarChar));
                oleDbCommand.Parameters["@xiangmu"].Value = this._xiangmu;
             
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
                string cmdText = @"update User_List set UserName=@UserName,[Password]=@Password,RoleValue=@RoleValue,LastLoginIP=@LastLoginIP,FullName=@FullName,Phone1=@Phone1,ImagePath1=@ImagePath1,xiangmu=@xiangmu,CreateDate=@CreateDate where pk_User=@pk_User";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@UserName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@UserName"].Value = this._UserName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Password", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Password"].Value = this._Password;
              
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleValue", OleDbType.Integer));
                oleDbCommand.Parameters["@RoleValue"].Value = this._RoleValue;


                oleDbCommand.Parameters.Add(new OleDbParameter("@LastLoginIP", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@LastLoginIP"].Value = this._LastLoginIP;

                oleDbCommand.Parameters.Add(new OleDbParameter("@FullName", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@FullName"].Value = this._FullName;

                oleDbCommand.Parameters.Add(new OleDbParameter("@Phone1", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Phone1"].Value = this._Phone1;
              
             
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath1", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ImagePath1"].Value = this._ImagePath1;

                oleDbCommand.Parameters.Add(new OleDbParameter("@xiangmu", OleDbType.VarChar));
                oleDbCommand.Parameters["@xiangmu"].Value = this._xiangmu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
              
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_User"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from User_List where pk_User=" + id);
        }
    }

    public class Log
    {
        private int _pk_Log;

        private string _IPAddress;

        private string _Url;

        private int _fk_User;

        private string _Browser;

        private int _TypeID;

        private string _LogTime;

        private string _Title;

        private string _Description;

        private string _SessionID;

        private int _fk_Company;

        public int pk_Log
        {
            get
            {
                return this._pk_Log;
            }
            set
            {
                this._pk_Log = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return this._IPAddress;
            }
            set
            {
                this._IPAddress = value;
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public int fk_User
        {
            get
            {
                return this._fk_User;
            }
            set
            {
                this._fk_User = value;
            }
        }

        public string Browser
        {
            get
            {
                return this._Browser;
            }
            set
            {
                this._Browser = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public string LogTime
        {
            get
            {
                return this._LogTime;
            }
            set
            {
                this._LogTime = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public string SessionID
        {
            get
            {
                return this._SessionID;
            }
            set
            {
                this._SessionID = value;
            }
        }

        public int fk_Company
        {
            get
            {
                return this._fk_Company;
            }
            set
            {
                this._fk_Company = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from User_Log where pk_Log=@pk_Log";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Log", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Log"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Log = Convert.ToInt32(oleDbDataReader["pk_Log"].ToString());
                    this._IPAddress = oleDbDataReader["IPAddress"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._fk_User = Convert.ToInt32(oleDbDataReader["fk_User"].ToString());
                    this._Browser = oleDbDataReader["Browser"].ToString();
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._LogTime = oleDbDataReader["LogTime"].ToString();
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._Description = oleDbDataReader["Description"].ToString();
                    this._SessionID = oleDbDataReader["SessionID"].ToString();
                    this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
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
                string cmdText = "insert into User_Log(IPAddress,Url,fk_User,Browser,TypeID,LogTime,Title,Description,SessionID,fk_Company) values (@IPAddress,@Url,@fk_User,@Browser,@TypeID,@LogTime,@Title,@Description,@SessionID,@fk_Company)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@IPAddress"].Value = this._IPAddress;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_User"].Value = this._fk_User;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = this._Browser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogTime", OleDbType.Date));
                oleDbCommand.Parameters["@LogTime"].Value = this._LogTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SessionID", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SessionID"].Value = this._SessionID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
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

        public static void AddLog(string title)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into User_Log(IPAddress,Url,fk_User,Browser,TypeID,LogTime,Title,Description,SessionID,fk_Company) values (@IPAddress,@Url,@fk_User,@Browser,@TypeID,@LogTime,@Title,@Description,@SessionID,@fk_Company)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@IPAddress"].Value = IP.Get();
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = String.GetUrl(0);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    oleDbCommand.Parameters["@fk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                }
                else
                {
                    oleDbCommand.Parameters["@fk_User"].Value = 0;
                }
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = String.GetBrowserInfo();
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = 0;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogTime", OleDbType.Date));
                oleDbCommand.Parameters["@LogTime"].Value = DateTime.Now;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = HttpContext.Current.Request.ServerVariables.Get("HTTP_USER_AGENT");
                oleDbCommand.Parameters.Add(new OleDbParameter("@SessionID", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SessionID"].Value = HttpContext.Current.Session.SessionID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = 0;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update User_Log set IPAddress=@IPAddress,Url=@Url,fk_User=@fk_User,Browser=@Browser,TypeID=@TypeID,LogTime=@LogTime,Title=@Title,Description=@Description,SessionID=@SessionID,fk_Company=@fk_Company where pk_Log=@pk_Log";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@IPAddress"].Value = this._IPAddress;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_User"].Value = this._fk_User;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = this._Browser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogTime", OleDbType.Date));
                oleDbCommand.Parameters["@LogTime"].Value = this._LogTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SessionID", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SessionID"].Value = this._SessionID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Log", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Log"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from User_Log where pk_Log=" + id);
        }
    }

    public class Login
    {
        private int _pk_User;

        private string _UserName;

        private string _Password;

        private int _TypeID;

        private int _fk_Department;

        private int _RoleValue;

        private string _RoleList;

        private int _Position;

        private string _Number;

        private string _Skin;

        private string _Language;

        private bool _IsLock;

        private string _LastLoginIP;

        private string _LastLoginTime;

        private string _NickName;

        private string _FullName;

        private string _FirstName;

        private string _MiddleName;

        private string _LastName;

        private string _Phone1;

        private string _Phone2;

        private string _Email1;

        private string _Email2;

        private string _Fax;

        private string _Line;

        private string _Wechat;

        private string _QQ;

        private string _Facebook;

        private string _Twitter;

        private string _Linkedin;

        private string _ZipCode;

        private string _Place;

        private string _Address1;

        private string _Address2;

        private int _Province;

        private int _City;

        private int _County;

        private int _Zone;

        private int _Sex;

        private int _Height;

        private int _Weight;

        private string _Birthday;

        private string _Education;

        private string _School;

        private string _ImagePath1;

        private string _ImagePath2;

        private string _IDCardPath;

        private string _ResumePath;

        private decimal _Wages;

        private string _BankAccount;

        private string _IDNumber;

        private string _Source;

        private string _Note;

        private string _Remark;

        private string _EntryTime;

        private bool _IsQuit;

        private string _QuitTime;

        private int _fk_Company;

        private int _CreateUser;

        private string _CreateDate;

        private int _ModifyUser;

        private string _ModifyDate;

        public int pk_User
        {
            get
            {
                return this._pk_User;
            }
            set
            {
                this._pk_User = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
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

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public int fk_Department
        {
            get
            {
                return this._fk_Department;
            }
            set
            {
                this._fk_Department = value;
            }
        }

        public int RoleValue
        {
            get
            {
                return this._RoleValue;
            }
            set
            {
                this._RoleValue = value;
            }
        }

        public string RoleList
        {
            get
            {
                return this._RoleList;
            }
            set
            {
                this._RoleList = value;
            }
        }

        public int Position
        {
            get
            {
                return this._Position;
            }
            set
            {
                this._Position = value;
            }
        }

        public string Number
        {
            get
            {
                return this._Number;
            }
            set
            {
                this._Number = value;
            }
        }

        public string Skin
        {
            get
            {
                return this._Skin;
            }
            set
            {
                this._Skin = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return this._IsLock;
            }
            set
            {
                this._IsLock = value;
            }
        }

        public string LastLoginIP
        {
            get
            {
                return this._LastLoginIP;
            }
            set
            {
                this._LastLoginIP = value;
            }
        }

        public string LastLoginTime
        {
            get
            {
                return this._LastLoginTime;
            }
            set
            {
                this._LastLoginTime = value;
            }
        }

        public string NickName
        {
            get
            {
                return this._NickName;
            }
            set
            {
                this._NickName = value;
            }
        }

        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {
                this._FullName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this._MiddleName;
            }
            set
            {
                this._MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string Email1
        {
            get
            {
                return this._Email1;
            }
            set
            {
                this._Email1 = value;
            }
        }

        public string Email2
        {
            get
            {
                return this._Email2;
            }
            set
            {
                this._Email2 = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public string Line
        {
            get
            {
                return this._Line;
            }
            set
            {
                this._Line = value;
            }
        }

        public string Wechat
        {
            get
            {
                return this._Wechat;
            }
            set
            {
                this._Wechat = value;
            }
        }

        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                this._QQ = value;
            }
        }

        public string Facebook
        {
            get
            {
                return this._Facebook;
            }
            set
            {
                this._Facebook = value;
            }
        }

        public string Twitter
        {
            get
            {
                return this._Twitter;
            }
            set
            {
                this._Twitter = value;
            }
        }

        public string Linkedin
        {
            get
            {
                return this._Linkedin;
            }
            set
            {
                this._Linkedin = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return this._ZipCode;
            }
            set
            {
                this._ZipCode = value;
            }
        }

        public string Place
        {
            get
            {
                return this._Place;
            }
            set
            {
                this._Place = value;
            }
        }

        public string Address1
        {
            get
            {
                return this._Address1;
            }
            set
            {
                this._Address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this._Address2;
            }
            set
            {
                this._Address2 = value;
            }
        }

        public int Province
        {
            get
            {
                return this._Province;
            }
            set
            {
                this._Province = value;
            }
        }

        public int City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        public int County
        {
            get
            {
                return this._County;
            }
            set
            {
                this._County = value;
            }
        }

        public int Zone
        {
            get
            {
                return this._Zone;
            }
            set
            {
                this._Zone = value;
            }
        }

        public int Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                this._Sex = value;
            }
        }

        public int Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this._Height = value;
            }
        }

        public int Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                this._Weight = value;
            }
        }

        public string Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this._Birthday = value;
            }
        }

        public string Education
        {
            get
            {
                return this._Education;
            }
            set
            {
                this._Education = value;
            }
        }

        public string School
        {
            get
            {
                return this._School;
            }
            set
            {
                this._School = value;
            }
        }

        public string ImagePath1
        {
            get
            {
                return this._ImagePath1;
            }
            set
            {
                this._ImagePath1 = value;
            }
        }

        public string ImagePath2
        {
            get
            {
                return this._ImagePath2;
            }
            set
            {
                this._ImagePath2 = value;
            }
        }

        public string IDCardPath
        {
            get
            {
                return this._IDCardPath;
            }
            set
            {
                this._IDCardPath = value;
            }
        }

        public string ResumePath
        {
            get
            {
                return this._ResumePath;
            }
            set
            {
                this._ResumePath = value;
            }
        }

        public decimal Wages
        {
            get
            {
                return this._Wages;
            }
            set
            {
                this._Wages = value;
            }
        }

        public string BankAccount
        {
            get
            {
                return this._BankAccount;
            }
            set
            {
                this._BankAccount = value;
            }
        }

        public string IDNumber
        {
            get
            {
                return this._IDNumber;
            }
            set
            {
                this._IDNumber = value;
            }
        }

        public string Source
        {
            get
            {
                return this._Source;
            }
            set
            {
                this._Source = value;
            }
        }

        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this._Note = value;
            }
        }

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }

        public string EntryTime
        {
            get
            {
                return this._EntryTime;
            }
            set
            {
                this._EntryTime = value;
            }
        }

        public bool IsQuit
        {
            get
            {
                return this._IsQuit;
            }
            set
            {
                this._IsQuit = value;
            }
        }

        public string QuitTime
        {
            get
            {
                return this._QuitTime;
            }
            set
            {
                this._QuitTime = value;
            }
        }

        public int fk_Company
        {
            get
            {
                return this._fk_Company;
            }
            set
            {
                this._fk_Company = value;
            }
        }

        public int CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                this._CreateUser = value;
            }
        }

        public string CreateDate
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

        public int ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                this._ModifyUser = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public bool IsUser(string userName, string password)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            bool result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from User_List where userName=@userName and [Password]=@Password";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@userName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@UserName"].Value = userName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Password", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Password"].Value = password;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_User = Convert.ToInt32(oleDbDataReader["pk_User"].ToString());
                    this._UserName = oleDbDataReader["UserName"].ToString();
                    this._Password = oleDbDataReader["Password"].ToString();
                    //this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    //this._fk_Department = Convert.ToInt32(oleDbDataReader["fk_Department"].ToString());
                    this._RoleValue = Convert.ToInt32(oleDbDataReader["RoleValue"].ToString());
                    //this._RoleList = oleDbDataReader["RoleList"].ToString();
                    //this._Position = Convert.ToInt32(oleDbDataReader["Position"].ToString());
                    //this._Number = oleDbDataReader["Number"].ToString();
                    //this._Skin = oleDbDataReader["Skin"].ToString();
                    //this._Language = oleDbDataReader["Language"].ToString();
                    //this._IsLock = Convert.ToBoolean(oleDbDataReader["IsLock"].ToString());
                    //this._LastLoginIP = oleDbDataReader["LastLoginIP"].ToString();
                    //this._LastLoginTime = oleDbDataReader["LastLoginTime"].ToString();
                    //this._NickName = oleDbDataReader["NickName"].ToString();
                    this._FullName = oleDbDataReader["FullName"].ToString();
                    //this._FirstName = oleDbDataReader["FirstName"].ToString();
                    //this._MiddleName = oleDbDataReader["MiddleName"].ToString();
                    //this._LastName = oleDbDataReader["LastName"].ToString();
                    this._Phone1 = oleDbDataReader["Phone1"].ToString();
                    //this._Phone2 = oleDbDataReader["Phone2"].ToString();
                    //this._Email1 = oleDbDataReader["Email1"].ToString();
                    //this._Email2 = oleDbDataReader["Email2"].ToString();
                    //this._Fax = oleDbDataReader["Fax"].ToString();
                    //this._Line = oleDbDataReader["Line"].ToString();
                    //this._Wechat = oleDbDataReader["Wechat"].ToString();
                    //this._QQ = oleDbDataReader["QQ"].ToString();
                    //this._Facebook = oleDbDataReader["Facebook"].ToString();
                    //this._Twitter = oleDbDataReader["Twitter"].ToString();
                    //this._Linkedin = oleDbDataReader["Linkedin"].ToString();
                    //this._ZipCode = oleDbDataReader["ZipCode"].ToString();
                    //this._Place = oleDbDataReader["Place"].ToString();
                    //this._Address1 = oleDbDataReader["Address1"].ToString();
                    //this._Address2 = oleDbDataReader["Address2"].ToString();
                    //this._Province = Convert.ToInt32(oleDbDataReader["Province"].ToString());
                    //this._City = Convert.ToInt32(oleDbDataReader["City"].ToString());
                    //this._County = Convert.ToInt32(oleDbDataReader["County"].ToString());
                    //this._Zone = Convert.ToInt32(oleDbDataReader["Zone"].ToString());
                    //this._Sex = Convert.ToInt32(oleDbDataReader["Sex"].ToString());
                    //this._Height = Convert.ToInt32(oleDbDataReader["Height"].ToString());
                    //this._Weight = Convert.ToInt32(oleDbDataReader["Weight"].ToString());
                    //this._Birthday = oleDbDataReader["Birthday"].ToString();
                    //this._Education = oleDbDataReader["Education"].ToString();
                    //this._School = oleDbDataReader["School"].ToString();
                    this._ImagePath1 = oleDbDataReader["ImagePath1"].ToString();
                    //this._ImagePath2 = oleDbDataReader["ImagePath2"].ToString();
                    //this._IDCardPath = oleDbDataReader["IDCardPath"].ToString();
                    //this._ResumePath = oleDbDataReader["ResumePath"].ToString();
                    //this._Wages = Convert.ToDecimal(oleDbDataReader["Wages"].ToString());
                    //this._BankAccount = oleDbDataReader["BankAccount"].ToString();
                    //this._IDNumber = oleDbDataReader["IDNumber"].ToString();
                    //this._Source = oleDbDataReader["Source"].ToString();
                    //this._Note = oleDbDataReader["Note"].ToString();
                    //this._Remark = oleDbDataReader["Remark"].ToString();
                    //this._EntryTime = oleDbDataReader["EntryTime"].ToString();
                    //this._IsQuit = Convert.ToBoolean(oleDbDataReader["IsQuit"].ToString());
                    //this._QuitTime = oleDbDataReader["QuitTime"].ToString();
                    //this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
                    //this._CreateUser = Convert.ToInt32(oleDbDataReader["CreateUser"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    //this._ModifyUser = Convert.ToInt32(oleDbDataReader["ModifyUser"].ToString());
                    //this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static void ChkLogin()
        {
            Login.WriteSession();
            //Login.HasLogin();
            //Login.HasRole();
        }

        public static bool IsLogin()
        {
            bool result;
            if (HttpContext.Current != null && HttpContext.Current.Session["UserID"] != null && HttpContext.Current.Session["UserName"] != null)
            {
                OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
                try
                {
                    oleDbConnection.Open();
                    string cmdText = "select pk_User,UserName from User_List where pk_User=@pk_User and UserName=@UserName";
                    OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                    oleDbCommand.Parameters.Add(new OleDbParameter("@pk_User", OleDbType.Integer));
                    oleDbCommand.Parameters["@pk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                    oleDbCommand.Parameters.Add(new OleDbParameter("@UserName", OleDbType.VarChar, 100));
                    oleDbCommand.Parameters["@UserName"].Value = HttpContext.Current.Session["UserName"].ToString();
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    if (oleDbDataReader.Read())
                    {
                        result = true;
                        return result;
                    }
                    result = false;
                    return result;
                }
                catch
                {
                    result = false;
                    return result;
                }
                finally
                {
                    oleDbConnection.Close();
                }
            }
            result = false;
            return result;
        }

        public static void HasLogin()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["UserID"] != null && HttpContext.Current.Session["UserName"] != null)
            {
                OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
                try
                {
                    oleDbConnection.Open();
                    string cmdText = "select pk_User,UserName,LastLoginIP from User_List where pk_User=@pk_User and UserName=@UserName";
                    OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                    oleDbCommand.Parameters.Add(new OleDbParameter("@pk_User", OleDbType.Integer));
                    oleDbCommand.Parameters["@pk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                    oleDbCommand.Parameters.Add(new OleDbParameter("@UserName", OleDbType.VarChar, 100));
                    oleDbCommand.Parameters["@UserName"].Value = HttpContext.Current.Session["UserName"].ToString();
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    if (oleDbDataReader.Read())
                    {
                        if (!(oleDbDataReader["LastLoginIP"].ToString() == IP.Get()))
                        {
                            HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                            HttpContext.Current.Response.End();
                        }
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                        HttpContext.Current.Response.End();
                    }
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                    HttpContext.Current.Response.End();
                }
                finally
                {
                    oleDbConnection.Close();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
                HttpContext.Current.Response.End();
            }
        }

        public static void HasRole()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["RoleValue"] != null)
            {
                string text = HttpContext.Current.Request.Path.ToString().ToLower();
                string text2 = HttpContext.Current.Request.ApplicationPath.ToLower();
                if (text2 != "/")
                {
                    text = text.Replace(text2, "");
                }
                OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
                try
                {
                    oleDbConnection.Open();
                    string cmdText = string.Concat(new string[]
					{
						"select * from View_Menu where fk_RoleName=",
						HttpContext.Current.Session["RoleValue"].ToString(),
						" and Url='",
						text,
						"' and IsUse=True"
					});
                    OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                    OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                    if (!oleDbDataReader.Read())
                    {
                        HttpContext.Current.Response.Redirect("~/Admin/Commons/Info.aspx?type=1");
                        HttpContext.Current.Response.End();
                    }
                }
                catch
                {
                    HttpContext.Current.Response.Redirect("~/Admin/Commons/Info.aspx?type=1");
                    HttpContext.Current.Response.End();
                }
                finally
                {
                    oleDbConnection.Close();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Admin/Commons/Info.aspx?type=1");
                HttpContext.Current.Response.End();
            }
        }

        public static void WriteSession()
        {
            if (HttpContext.Current.Session["UserID"] == null)
            {
                Login.ChkCookies("UserID");
                Login.ChkCookies("UserName");
                Login.ChkCookies("FullName");
                Login.ChkCookies("RoleValue");
                //Login.ChkCookies("DepartmentID");
            }
        }

        public static void ChkCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Session[name] = HttpContext.Current.Request.Cookies[name].Value;
            }
        }

        public static void SetLogin()
        {
            Login.SetLogin("UserID");
            Login.SetLogin("UserName");
            Login.SetLogin("FullName");
            Login.SetLogin("RoleValue");
            //Login.SetLogin("DepartmentID");
        }

        public static void SetLogin(string name)
        {
            HttpContext.Current.Response.Cookies[name].Value = HttpContext.Current.Session[name].ToString();
            HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddMonths(1);
        }

        public static void SetLogout()
        {
            Login.SetLogout("UserID");
            Login.SetLogout("UserName");
            Login.SetLogout("FullName");
            Login.SetLogout("RoleValue");
            //Login.SetLogout("DepartmentID");
        }

        public static void SetLogout(string name)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1.0);
        }

        public static void UpdateLastLogin(string id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update User_List set LastLoginIP=@LastLoginIP where pk_User=@pk_User";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@LastLoginIP", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@LastLoginIP"].Value = IP.Get();
                //oleDbCommand.Parameters.Add(new OleDbParameter("@LastLoginTime", OleDbType.Date));
                //oleDbCommand.Parameters["@LastLoginTime"].Value = DateTime.Now;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_User"].Value = int.Parse(id);
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }
    }

    public class Online
    {
        private int _pk_Online;

        private int _fk_User;

        private string _SessionID;

        private string _IPAddress;

        private string _Browser;

        private int _TypeID;

        private string _LoginTime;

        private int _fk_Company;

        public int pk_Online
        {
            get
            {
                return this._pk_Online;
            }
            set
            {
                this._pk_Online = value;
            }
        }

        public int fk_User
        {
            get
            {
                return this._fk_User;
            }
            set
            {
                this._fk_User = value;
            }
        }

        public string SessionID
        {
            get
            {
                return this._SessionID;
            }
            set
            {
                this._SessionID = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return this._IPAddress;
            }
            set
            {
                this._IPAddress = value;
            }
        }

        public string Browser
        {
            get
            {
                return this._Browser;
            }
            set
            {
                this._Browser = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public string LoginTime
        {
            get
            {
                return this._LoginTime;
            }
            set
            {
                this._LoginTime = value;
            }
        }

        public int fk_Company
        {
            get
            {
                return this._fk_Company;
            }
            set
            {
                this._fk_Company = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from User_Online where pk_Online=@pk_Online";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Online", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Online"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Online = Convert.ToInt32(oleDbDataReader["pk_Online"].ToString());
                    this._fk_User = Convert.ToInt32(oleDbDataReader["fk_User"].ToString());
                    this._SessionID = oleDbDataReader["SessionID"].ToString();
                    this._IPAddress = oleDbDataReader["IPAddress"].ToString();
                    this._Browser = oleDbDataReader["Browser"].ToString();
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._LoginTime = oleDbDataReader["LoginTime"].ToString();
                    this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
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
                string cmdText = "insert into User_Online(fk_User,SessionID,IPAddress,Browser,TypeID,LoginTime,fk_Company) values (@fk_User,@SessionID,@IPAddress,@Browser,@TypeID,@LoginTime,@fk_Company)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_User"].Value = this._fk_User;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SessionID", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SessionID"].Value = this._SessionID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@IPAddress"].Value = this._IPAddress;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = this._Browser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LoginTime", OleDbType.Date));
                oleDbCommand.Parameters["@LoginTime"].Value = this._LoginTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
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

        public static void AddOnline(int type)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into User_Online(fk_User,SessionID,IPAddress,Browser,TypeID,LoginTime,fk_Company) values (@fk_User,@SessionID,@IPAddress,@Browser,@TypeID,@LoginTime,@fk_Company)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    oleDbCommand.Parameters["@fk_User"].Value = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                }
                else
                {
                    oleDbCommand.Parameters["@fk_User"].Value = 0;
                }
                oleDbCommand.Parameters.Add(new OleDbParameter("@SessionID", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SessionID"].Value = HttpContext.Current.Session.SessionID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@IPAddress"].Value = IP.Get();
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = String.GetBrowserInfo();
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = type;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LoginTime", OleDbType.Date));
                oleDbCommand.Parameters["@LoginTime"].Value = DateTime.Now;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = 0;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update User_Online set fk_User=@fk_User,SessionID=@SessionID,IPAddress=@IPAddress,Browser=@Browser,TypeID=@TypeID,LoginTime=@LoginTime,fk_Company=@fk_Company where pk_Online=@pk_Online";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_User"].Value = this._fk_User;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SessionID", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SessionID"].Value = this._SessionID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@IPAddress"].Value = this._IPAddress;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = this._Browser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LoginTime", OleDbType.Date));
                oleDbCommand.Parameters["@LoginTime"].Value = this._LoginTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Online", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Online"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from User_Online where pk_Online=" + id);
        }
    }

    public class Position
    {
        private int _pk_Position;

        private string _Title;

        private int _ParentID;

        private int _LevelID;

        private int _SortID;

        private int _fk_Company;

        private int _CreateUser;

        private string _CreateDate;

        private int _ModifyUser;

        private string _ModifyDate;

        public int pk_Position
        {
            get
            {
                return this._pk_Position;
            }
            set
            {
                this._pk_Position = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this._ParentID = value;
            }
        }

        public int LevelID
        {
            get
            {
                return this._LevelID;
            }
            set
            {
                this._LevelID = value;
            }
        }

        public int SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                this._SortID = value;
            }
        }

        public int fk_Company
        {
            get
            {
                return this._fk_Company;
            }
            set
            {
                this._fk_Company = value;
            }
        }

        public int CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                this._CreateUser = value;
            }
        }

        public string CreateDate
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

        public int ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                this._ModifyUser = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from User_Position where pk_Position=@pk_Position";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Position", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Position"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Position = Convert.ToInt32(oleDbDataReader["pk_Position"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._ParentID = Convert.ToInt32(oleDbDataReader["ParentID"].ToString());
                    this._LevelID = Convert.ToInt32(oleDbDataReader["LevelID"].ToString());
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
                    this._CreateUser = Convert.ToInt32(oleDbDataReader["CreateUser"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._ModifyUser = Convert.ToInt32(oleDbDataReader["ModifyUser"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
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
                string cmdText = "insert into User_Position(Title,ParentID,LevelID,SortID,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@Title,@ParentID,@LevelID,@SortID,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LevelID", OleDbType.Integer));
                oleDbCommand.Parameters["@LevelID"].Value = this._LevelID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUser"].Value = this._CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUser", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUser"].Value = this._ModifyUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
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
                string cmdText = "update User_Position set Title=@Title,ParentID=@ParentID,LevelID=@LevelID,SortID=@SortID,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_Position=@pk_Position";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LevelID", OleDbType.Integer));
                oleDbCommand.Parameters["@LevelID"].Value = this._LevelID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUser"].Value = this._CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUser", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUser"].Value = this._ModifyUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Position", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Position"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from User_Position where pk_Position=" + id);
        }
    }
}
