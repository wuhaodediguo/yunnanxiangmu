using System;
using System.Data.OleDb;

namespace MojoCube.Web.Role
{
    public class List
    {
        private int _pk_Role;

        private int _fk_RoleName;

        private int _fk_Menu;

        private bool _IsUse;

        private bool _IsAdmin;

        private string _PowerList;

        private int _fk_Company;

        public int pk_Role
        {
            get
            {
                return this._pk_Role;
            }
            set
            {
                this._pk_Role = value;
            }
        }

        public int fk_RoleName
        {
            get
            {
                return this._fk_RoleName;
            }
            set
            {
                this._fk_RoleName = value;
            }
        }

        public int fk_Menu
        {
            get
            {
                return this._fk_Menu;
            }
            set
            {
                this._fk_Menu = value;
            }
        }

        public bool IsUse
        {
            get
            {
                return this._IsUse;
            }
            set
            {
                this._IsUse = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return this._IsAdmin;
            }
            set
            {
                this._IsAdmin = value;
            }
        }

        public string PowerList
        {
            get
            {
                return this._PowerList;
            }
            set
            {
                this._PowerList = value;
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
                string cmdText = "select * from Role_List where pk_Role=@pk_Role";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Role", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Role"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Role = Convert.ToInt32(oleDbDataReader["pk_Role"].ToString());
                    this._fk_RoleName = Convert.ToInt32(oleDbDataReader["fk_RoleName"].ToString());
                    this._fk_Menu = Convert.ToInt32(oleDbDataReader["fk_Menu"].ToString());
                    this._IsUse = Convert.ToBoolean(oleDbDataReader["IsUse"].ToString());
                    this._IsAdmin = Convert.ToBoolean(oleDbDataReader["IsAdmin"].ToString());
                    this._PowerList = oleDbDataReader["PowerList"].ToString();
                    this._fk_Company = Convert.ToInt32(oleDbDataReader["fk_Company"].ToString());
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void GetData(int roleId, int menuId)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Role_List where fk_RoleName=@fk_RoleName and fk_Menu=@fk_Menu";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_RoleName", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_RoleName"].Value = roleId;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Menu"].Value = menuId;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Role = Convert.ToInt32(oleDbDataReader["pk_Role"].ToString());
                    this._fk_RoleName = Convert.ToInt32(oleDbDataReader["fk_RoleName"].ToString());
                    this._fk_Menu = Convert.ToInt32(oleDbDataReader["fk_Menu"].ToString());
                    this._IsUse = Convert.ToBoolean(oleDbDataReader["IsUse"].ToString());
                    this._IsAdmin = Convert.ToBoolean(oleDbDataReader["IsAdmin"].ToString());
                    this._PowerList = oleDbDataReader["PowerList"].ToString();
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
                string cmdText = "insert into Role_List(fk_RoleName,fk_Menu,IsUse,IsAdmin,PowerList,fk_Company) values (@fk_RoleName,@fk_Menu,@IsUse,@IsAdmin,@PowerList,@fk_Company)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_RoleName", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_RoleName"].Value = this._fk_RoleName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Menu"].Value = this._fk_Menu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsUse", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsUse"].Value = this._IsUse;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsAdmin", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsAdmin"].Value = this._IsAdmin;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PowerList", OleDbType.VarChar, 500));
                oleDbCommand.Parameters["@PowerList"].Value = this._PowerList;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Role_List set fk_RoleName=@fk_RoleName,fk_Menu=@fk_Menu,IsUse=@IsUse,IsAdmin=@IsAdmin,PowerList=@PowerList,fk_Company=@fk_Company where pk_Role=@pk_Role";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_RoleName", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_RoleName"].Value = this._fk_RoleName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Menu"].Value = this._fk_Menu;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsUse", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsUse"].Value = this._IsUse;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsAdmin", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsAdmin"].Value = this._IsAdmin;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PowerList", OleDbType.VarChar, 500));
                oleDbCommand.Parameters["@PowerList"].Value = this._PowerList;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Role", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Role"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Role_List where pk_Role=" + id);
        }
    }

    public class Name
    {
        private int _pk_Name;

        private string _RoleName_CHS;

        private string _RoleName_CHT;

        private string _RoleName_EN;

        private int _PowerValue;

        private int _fk_Company;

        public int pk_Name
        {
            get
            {
                return this._pk_Name;
            }
            set
            {
                this._pk_Name = value;
            }
        }

        public string RoleName_CHS
        {
            get
            {
                return this._RoleName_CHS;
            }
            set
            {
                this._RoleName_CHS = value;
            }
        }

        public string RoleName_CHT
        {
            get
            {
                return this._RoleName_CHT;
            }
            set
            {
                this._RoleName_CHT = value;
            }
        }

        public string RoleName_EN
        {
            get
            {
                return this._RoleName_EN;
            }
            set
            {
                this._RoleName_EN = value;
            }
        }

        public int PowerValue
        {
            get
            {
                return this._PowerValue;
            }
            set
            {
                this._PowerValue = value;
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
                string cmdText = "select * from Role_Name where pk_Name=@pk_Name";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Name", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Name"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Name = Convert.ToInt32(oleDbDataReader["pk_Name"].ToString());
                    this._RoleName_CHS = oleDbDataReader["RoleName_CHS"].ToString();
                    this._RoleName_CHT = oleDbDataReader["RoleName_CHT"].ToString();
                    this._RoleName_EN = oleDbDataReader["RoleName_EN"].ToString();
                    this._PowerValue = Convert.ToInt32(oleDbDataReader["PowerValue"].ToString());
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
                string cmdText = "insert into Role_Name(RoleName_CHS,RoleName_CHT,RoleName_EN,PowerValue,fk_Company) values (@RoleName_CHS,@RoleName_CHT,@RoleName_EN,@PowerValue,@fk_Company)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleName_CHS", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@RoleName_CHS"].Value = this._RoleName_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleName_CHT", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@RoleName_CHT"].Value = this._RoleName_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleName_EN", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@RoleName_EN"].Value = this._RoleName_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PowerValue", OleDbType.Integer));
                oleDbCommand.Parameters["@PowerValue"].Value = this._PowerValue;
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

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Role_Name set RoleName_CHS=@RoleName_CHS,RoleName_CHT=@RoleName_CHT,RoleName_EN=@RoleName_EN,PowerValue=@PowerValue,fk_Company=@fk_Company where pk_Name=@pk_Name";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleName_CHS", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@RoleName_CHS"].Value = this._RoleName_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleName_CHT", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@RoleName_CHT"].Value = this._RoleName_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleName_EN", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@RoleName_EN"].Value = this._RoleName_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@PowerValue", OleDbType.Integer));
                oleDbCommand.Parameters["@PowerValue"].Value = this._PowerValue;
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Company", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Company"].Value = this._fk_Company;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Name", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Name"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Role_Name where pk_Name=" + id);
        }
    }
}
