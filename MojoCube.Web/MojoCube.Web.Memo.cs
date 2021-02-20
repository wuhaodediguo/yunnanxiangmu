using System;
using System.Data.OleDb;

namespace MojoCube.Web.Memo
{
    public class List
    {
        private int _pk_Memo;

        private int _fk_User;

        private int _fk_Department;

        private int _TypeID;

        private int _StatusID;

        private string _Title;

        private string _Description;

        private string _ImagePath;

        private string _FilePath;

        private string _UserList;

        private string _DepartmentList;

        private string _RoleList;

        private string _Url;

        private bool _IsStar;

        private string _Tags;

        private int _fk_Company;

        private int _CreateUser;

        private string _CreateDate;

        private int _ModifyUser;

        private string _ModifyDate;

        public int pk_Memo
        {
            get
            {
                return this._pk_Memo;
            }
            set
            {
                this._pk_Memo = value;
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

        public int StatusID
        {
            get
            {
                return this._StatusID;
            }
            set
            {
                this._StatusID = value;
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

        public string ImagePath
        {
            get
            {
                return this._ImagePath;
            }
            set
            {
                this._ImagePath = value;
            }
        }

        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this._FilePath = value;
            }
        }

        public string UserList
        {
            get
            {
                return this._UserList;
            }
            set
            {
                this._UserList = value;
            }
        }

        public string DepartmentList
        {
            get
            {
                return this._DepartmentList;
            }
            set
            {
                this._DepartmentList = value;
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

        public bool IsStar
        {
            get
            {
                return this._IsStar;
            }
            set
            {
                this._IsStar = value;
            }
        }

        public string Tags
        {
            get
            {
                return this._Tags;
            }
            set
            {
                this._Tags = value;
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
                string cmdText = "select * from Memo_List where pk_Memo=@pk_Memo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Memo", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Memo"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Memo = Convert.ToInt32(oleDbDataReader["pk_Memo"].ToString());
                    this._fk_User = Convert.ToInt32(oleDbDataReader["fk_User"].ToString());
                    this._fk_Department = Convert.ToInt32(oleDbDataReader["fk_Department"].ToString());
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._StatusID = Convert.ToInt32(oleDbDataReader["StatusID"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._Description = oleDbDataReader["Description"].ToString();
                    this._ImagePath = oleDbDataReader["ImagePath"].ToString();
                    this._FilePath = oleDbDataReader["FilePath"].ToString();
                    this._UserList = oleDbDataReader["UserList"].ToString();
                    this._DepartmentList = oleDbDataReader["DepartmentList"].ToString();
                    this._RoleList = oleDbDataReader["RoleList"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._IsStar = Convert.ToBoolean(oleDbDataReader["IsStar"].ToString());
                    this._Tags = oleDbDataReader["Tags"].ToString();
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
                string cmdText = "insert into Memo_List(fk_User,fk_Department,TypeID,StatusID,Title,Description,ImagePath,FilePath,UserList,DepartmentList,RoleList,Url,IsStar,Tags,fk_Company,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@fk_User,@fk_Department,@TypeID,@StatusID,@Title,@Description,@ImagePath,@FilePath,@UserList,@DepartmentList,@RoleList,@Url,@IsStar,@Tags,@fk_Company,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_User"].Value = this._fk_User;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Department", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Department"].Value = this._fk_Department;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusID", OleDbType.Integer));
                oleDbCommand.Parameters["@StatusID"].Value = this._StatusID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ImagePath"].Value = this._ImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FilePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@FilePath"].Value = this._FilePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@UserList", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@UserList"].Value = this._UserList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@DepartmentList", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@DepartmentList"].Value = this._DepartmentList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleList", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@RoleList"].Value = this._RoleList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsStar", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsStar"].Value = this._IsStar;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tags", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tags"].Value = this._Tags;
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
                string cmdText = "update Memo_List set fk_User=@fk_User,fk_Department=@fk_Department,TypeID=@TypeID,StatusID=@StatusID,Title=@Title,Description=@Description,ImagePath=@ImagePath,FilePath=@FilePath,UserList=@UserList,DepartmentList=@DepartmentList,RoleList=@RoleList,Url=@Url,IsStar=@IsStar,Tags=@Tags,fk_Company=@fk_Company,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_Memo=@pk_Memo";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_User", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_User"].Value = this._fk_User;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Department", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Department"].Value = this._fk_Department;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusID", OleDbType.Integer));
                oleDbCommand.Parameters["@StatusID"].Value = this._StatusID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ImagePath"].Value = this._ImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FilePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@FilePath"].Value = this._FilePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@UserList", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@UserList"].Value = this._UserList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@DepartmentList", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@DepartmentList"].Value = this._DepartmentList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleList", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@RoleList"].Value = this._RoleList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsStar", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsStar"].Value = this._IsStar;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tags", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tags"].Value = this._Tags;
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
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Memo", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Memo"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Memo_List where pk_Memo=" + id);
        }
    }
}
