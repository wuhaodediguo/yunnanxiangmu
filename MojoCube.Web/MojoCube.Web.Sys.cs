using System;
using System.Data.OleDb;

namespace MojoCube.Web.Sys
{
    public class Menu
    {
        private int _pk_Menu;

        private int _ParentID;

        private string _Name_CHS;

        private string _Name_CHT;

        private string _Name_EN;

        private string _Url;

        private string _Icon;

        private int _SortID;

        private int _LevelID;

        private int _TypeID;

        private bool _Visible;

        private string _Tag_CHS;

        private string _Tag_CHT;

        private string _Tag_EN;

        public int pk_Menu
        {
            get
            {
                return this._pk_Menu;
            }
            set
            {
                this._pk_Menu = value;
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

        public string Name_CHS
        {
            get
            {
                return this._Name_CHS;
            }
            set
            {
                this._Name_CHS = value;
            }
        }

        public string Name_CHT
        {
            get
            {
                return this._Name_CHT;
            }
            set
            {
                this._Name_CHT = value;
            }
        }

        public string Name_EN
        {
            get
            {
                return this._Name_EN;
            }
            set
            {
                this._Name_EN = value;
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

        public string Icon
        {
            get
            {
                return this._Icon;
            }
            set
            {
                this._Icon = value;
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

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }

        public string Tag_CHS
        {
            get
            {
                return this._Tag_CHS;
            }
            set
            {
                this._Tag_CHS = value;
            }
        }

        public string Tag_CHT
        {
            get
            {
                return this._Tag_CHT;
            }
            set
            {
                this._Tag_CHT = value;
            }
        }

        public string Tag_EN
        {
            get
            {
                return this._Tag_EN;
            }
            set
            {
                this._Tag_EN = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Sys_Menu where pk_Menu=@pk_Menu";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Menu"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Menu = Convert.ToInt32(oleDbDataReader["pk_Menu"].ToString());
                    this._ParentID = Convert.ToInt32(oleDbDataReader["ParentID"].ToString());
                    this._Name_CHS = oleDbDataReader["Name_CHS"].ToString();
                    this._Name_CHT = oleDbDataReader["Name_CHT"].ToString();
                    this._Name_EN = oleDbDataReader["Name_EN"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._Icon = oleDbDataReader["Icon"].ToString();
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._LevelID = Convert.ToInt32(oleDbDataReader["LevelID"].ToString());
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._Visible = Convert.ToBoolean(oleDbDataReader["Visible"].ToString());
                    this._Tag_CHS = oleDbDataReader["Tag_CHS"].ToString();
                    this._Tag_CHT = oleDbDataReader["Tag_CHT"].ToString();
                    this._Tag_EN = oleDbDataReader["Tag_EN"].ToString();
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
                string cmdText = "insert into Sys_Menu(ParentID,Name_CHS,Name_CHT,Name_EN,Url,Icon,SortID,LevelID,TypeID,Visible,Tag_CHS,Tag_CHT,Tag_EN) values (@ParentID,@Name_CHS,@Name_CHT,@Name_EN,@Url,@Icon,@SortID,@LevelID,@TypeID,@Visible,@Tag_CHS,@Tag_CHT,@Tag_EN)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Name_CHS", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Name_CHS"].Value = this._Name_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Name_CHT", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Name_CHT"].Value = this._Name_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Name_EN", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Name_EN"].Value = this._Name_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Icon", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Icon"].Value = this._Icon;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LevelID", OleDbType.Integer));
                oleDbCommand.Parameters["@LevelID"].Value = this._LevelID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tag_CHS", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tag_CHS"].Value = this._Tag_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tag_CHT", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tag_CHT"].Value = this._Tag_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tag_EN", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tag_EN"].Value = this._Tag_EN;
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
                string cmdText = "update Sys_Menu set ParentID=@ParentID,Name_CHS=@Name_CHS,Name_CHT=@Name_CHT,Name_EN=@Name_EN,Url=@Url,Icon=@Icon,SortID=@SortID,LevelID=@LevelID,TypeID=@TypeID,Visible=@Visible,Tag_CHS=@Tag_CHS,Tag_CHT=@Tag_CHT,Tag_EN=@Tag_EN where pk_Menu=@pk_Menu";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Name_CHS", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Name_CHS"].Value = this._Name_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Name_CHT", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Name_CHT"].Value = this._Name_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Name_EN", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Name_EN"].Value = this._Name_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Icon", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Icon"].Value = this._Icon;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LevelID", OleDbType.Integer));
                oleDbCommand.Parameters["@LevelID"].Value = this._LevelID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tag_CHS", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tag_CHS"].Value = this._Tag_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tag_CHT", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tag_CHT"].Value = this._Tag_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Tag_EN", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Tag_EN"].Value = this._Tag_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Menu"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Sys_Menu where pk_Menu=" + id);
        }
    }

    public class Notice
    {
        private int _pk_Notice;

        private int _TypeID;

        private int _StatusID;

        private string _Title;

        private string _Description;

        private int _RoleValue;

        private string _Url;

        private int _CreateUser;

        private string _CreateDate;

        private int _ModifyUser;

        private string _ModifyDate;

        public int pk_Notice
        {
            get
            {
                return this._pk_Notice;
            }
            set
            {
                this._pk_Notice = value;
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
                string cmdText = "select * from Sys_Notice where pk_Notice=@pk_Notice";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Notice", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Notice"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Notice = Convert.ToInt32(oleDbDataReader["pk_Notice"].ToString());
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._StatusID = Convert.ToInt32(oleDbDataReader["StatusID"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._Description = oleDbDataReader["Description"].ToString();
                    this._RoleValue = Convert.ToInt32(oleDbDataReader["RoleValue"].ToString());
                    this._Url = oleDbDataReader["Url"].ToString();
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
                string cmdText = "insert into Sys_Notice(TypeID,StatusID,Title,Description,RoleValue,Url,CreateUser,CreateDate,ModifyUser,ModifyDate) values (@TypeID,@StatusID,@Title,@Description,@RoleValue,@Url,@CreateUser,@CreateDate,@ModifyUser,@ModifyDate)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusID", OleDbType.Integer));
                oleDbCommand.Parameters["@StatusID"].Value = this._StatusID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleValue", OleDbType.Integer));
                oleDbCommand.Parameters["@RoleValue"].Value = this._RoleValue;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
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
                string cmdText = "update Sys_Notice set TypeID=@TypeID,StatusID=@StatusID,Title=@Title,Description=@Description,RoleValue=@RoleValue,Url=@Url,CreateUser=@CreateUser,CreateDate=@CreateDate,ModifyUser=@ModifyUser,ModifyDate=@ModifyDate where pk_Notice=@pk_Notice";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusID", OleDbType.Integer));
                oleDbCommand.Parameters["@StatusID"].Value = this._StatusID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@RoleValue", OleDbType.Integer));
                oleDbCommand.Parameters["@RoleValue"].Value = this._RoleValue;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUser", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUser"].Value = this._CreateUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUser", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUser"].Value = this._ModifyUser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Notice", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Notice"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Sys_Notice where pk_Notice=" + id);
        }
    }

    public class StatusID
    {
        private int _pk_StatusID;

        private string _StatusName_CHS;

        private string _StatusName_CHT;

        private string _StatusName_EN;

        private int _ID;

        private string _Visual;

        private string _TableName;

        private string _Description_CHS;

        private string _Description_CHT;

        private string _Description_EN;

        public int pk_StatusID
        {
            get
            {
                return this._pk_StatusID;
            }
            set
            {
                this._pk_StatusID = value;
            }
        }

        public string StatusName_CHS
        {
            get
            {
                return this._StatusName_CHS;
            }
            set
            {
                this._StatusName_CHS = value;
            }
        }

        public string StatusName_CHT
        {
            get
            {
                return this._StatusName_CHT;
            }
            set
            {
                this._StatusName_CHT = value;
            }
        }

        public string StatusName_EN
        {
            get
            {
                return this._StatusName_EN;
            }
            set
            {
                this._StatusName_EN = value;
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

        public string Visual
        {
            get
            {
                return this._Visual;
            }
            set
            {
                this._Visual = value;
            }
        }

        public string TableName
        {
            get
            {
                return this._TableName;
            }
            set
            {
                this._TableName = value;
            }
        }

        public string Description_CHS
        {
            get
            {
                return this._Description_CHS;
            }
            set
            {
                this._Description_CHS = value;
            }
        }

        public string Description_CHT
        {
            get
            {
                return this._Description_CHT;
            }
            set
            {
                this._Description_CHT = value;
            }
        }

        public string Description_EN
        {
            get
            {
                return this._Description_EN;
            }
            set
            {
                this._Description_EN = value;
            }
        }

        public static string GetStatusName(string tableName, string statusID, string language)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            string result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Visual,StatusName_" + language + " from Sys_StatusID where TableName=@TableName and ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = tableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = int.Parse(statusID);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    if (oleDbDataReader["Visual"].ToString().Trim() != "")
                    {
                        result = string.Concat(new string[]
						{
							"<span style=\"font-size:9pt; color:#fff; padding:2px 4px; border-radius:3px; background-color:",
							oleDbDataReader["Visual"].ToString(),
							"\">",
							oleDbDataReader["StatusName_" + language].ToString(),
							"</span>"
						});
                    }
                    else
                    {
                        result = oleDbDataReader["StatusName_" + language].ToString();
                    }
                }
                else
                {
                    result = string.Empty;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static string GetDescription(string tableName, string typeID, string language)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            string result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Description_" + language + " from Sys_StatusID where TableName=@TableName and ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = tableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = int.Parse(typeID);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    result = oleDbDataReader["Description_" + language].ToString();
                }
                else
                {
                    result = string.Empty;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static string GetVisual(string tableName, string typeID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            string result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Visual from Sys_StatusID where TableName=@TableName and ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = tableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = int.Parse(typeID);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    result = oleDbDataReader["Visual"].ToString();
                }
                else
                {
                    result = string.Empty;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Sys_StatusID where pk_StatusID=@pk_StatusID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_StatusID", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_StatusID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_StatusID = Convert.ToInt32(oleDbDataReader["pk_StatusID"].ToString());
                    this._StatusName_CHS = oleDbDataReader["StatusName_CHS"].ToString();
                    this._StatusName_CHT = oleDbDataReader["StatusName_CHT"].ToString();
                    this._StatusName_EN = oleDbDataReader["StatusName_EN"].ToString();
                    this._ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this._Visual = oleDbDataReader["Visual"].ToString();
                    this._TableName = oleDbDataReader["TableName"].ToString();
                    this._Description_CHS = oleDbDataReader["Description_CHS"].ToString();
                    this._Description_CHT = oleDbDataReader["Description_CHT"].ToString();
                    this._Description_EN = oleDbDataReader["Description_EN"].ToString();
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
                string cmdText = "insert into Sys_StatusID(StatusName_CHS,StatusName_CHT,StatusName_EN,ID,Visual,TableName,Description_CHS,Description_CHT,Description_EN) values (@StatusName_CHS,@StatusName_CHT,@StatusName_EN,@ID,@Visual,@TableName,@Description_CHS,@Description_CHT,@Description_EN)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusName_CHS", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@StatusName_CHS"].Value = this._StatusName_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusName_CHT", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@StatusName_CHT"].Value = this._StatusName_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusName_EN", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@StatusName_EN"].Value = this._StatusName_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = this._ID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visual", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Visual"].Value = this._Visual;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = this._TableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHS", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHS"].Value = this._Description_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHT", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHT"].Value = this._Description_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_EN", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_EN"].Value = this._Description_EN;
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
                string cmdText = "update Sys_StatusID set StatusName_CHS=@StatusName_CHS,StatusName_CHT=@StatusName_CHT,StatusName_EN=@StatusName_EN,ID=@ID,Visual=@Visual,TableName=@TableName,Description_CHS=@Description_CHS,Description_CHT=@Description_CHT,Description_EN=@Description_EN where pk_StatusID=@pk_StatusID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusName_CHS", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@StatusName_CHS"].Value = this._StatusName_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusName_CHT", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@StatusName_CHT"].Value = this._StatusName_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatusName_EN", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@StatusName_EN"].Value = this._StatusName_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = this._ID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visual", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Visual"].Value = this._Visual;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = this._TableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHS", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHS"].Value = this._Description_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHT", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHT"].Value = this._Description_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_EN", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_EN"].Value = this._Description_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_StatusID", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_StatusID"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Sys_StatusID where pk_StatusID=" + id);
        }
    }

    public class TypeID
    {
        private int _pk_TypeID;

        private string _TypeName_CHS;

        private string _TypeName_CHT;

        private string _TypeName_EN;

        private int _ID;

        private string _Visual;

        private string _TableName;

        private string _Description_CHS;

        private string _Description_CHT;

        private string _Description_EN;

        public int pk_TypeID
        {
            get
            {
                return this._pk_TypeID;
            }
            set
            {
                this._pk_TypeID = value;
            }
        }

        public string TypeName_CHS
        {
            get
            {
                return this._TypeName_CHS;
            }
            set
            {
                this._TypeName_CHS = value;
            }
        }

        public string TypeName_CHT
        {
            get
            {
                return this._TypeName_CHT;
            }
            set
            {
                this._TypeName_CHT = value;
            }
        }

        public string TypeName_EN
        {
            get
            {
                return this._TypeName_EN;
            }
            set
            {
                this._TypeName_EN = value;
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

        public string Visual
        {
            get
            {
                return this._Visual;
            }
            set
            {
                this._Visual = value;
            }
        }

        public string TableName
        {
            get
            {
                return this._TableName;
            }
            set
            {
                this._TableName = value;
            }
        }

        public string Description_CHS
        {
            get
            {
                return this._Description_CHS;
            }
            set
            {
                this._Description_CHS = value;
            }
        }

        public string Description_CHT
        {
            get
            {
                return this._Description_CHT;
            }
            set
            {
                this._Description_CHT = value;
            }
        }

        public string Description_EN
        {
            get
            {
                return this._Description_EN;
            }
            set
            {
                this._Description_EN = value;
            }
        }

        public static string GetTypeName(string tableName, string typeID, string language)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            string result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Visual,TypeName_" + language + " from Sys_TypeID where TableName=@TableName and ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = tableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = int.Parse(typeID);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    if (oleDbDataReader["Visual"].ToString().Trim() != "")
                    {
                        result = string.Concat(new string[]
						{
							"<span style=\"color:",
							oleDbDataReader["Visual"].ToString(),
							"\">",
							oleDbDataReader["TypeName_" + language].ToString(),
							"</span>"
						});
                    }
                    else
                    {
                        result = oleDbDataReader["TypeName_" + language].ToString();
                    }
                }
                else
                {
                    result = string.Empty;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static string GetDescription(string tableName, string typeID, string language)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            string result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Description_" + language + " from Sys_TypeID where TableName=@TableName and ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = tableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = int.Parse(typeID);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    result = oleDbDataReader["Description_" + language].ToString();
                }
                else
                {
                    result = string.Empty;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static string GetVisual(string tableName, string typeID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            string result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "select Visual from Sys_TypeID where TableName=@TableName and ID=@ID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = tableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = int.Parse(typeID);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    result = oleDbDataReader["Visual"].ToString();
                }
                else
                {
                    result = string.Empty;
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Sys_TypeID where pk_TypeID=@pk_TypeID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_TypeID"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_TypeID = Convert.ToInt32(oleDbDataReader["pk_TypeID"].ToString());
                    this._TypeName_CHS = oleDbDataReader["TypeName_CHS"].ToString();
                    this._TypeName_CHT = oleDbDataReader["TypeName_CHT"].ToString();
                    this._TypeName_EN = oleDbDataReader["TypeName_EN"].ToString();
                    this._ID = Convert.ToInt32(oleDbDataReader["ID"].ToString());
                    this._Visual = oleDbDataReader["Visual"].ToString();
                    this._TableName = oleDbDataReader["TableName"].ToString();
                    this._Description_CHS = oleDbDataReader["Description_CHS"].ToString();
                    this._Description_CHT = oleDbDataReader["Description_CHT"].ToString();
                    this._Description_EN = oleDbDataReader["Description_EN"].ToString();
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
                string cmdText = "insert into Sys_TypeID(TypeName_CHS,TypeName_CHT,TypeName_EN,ID,Visual,TableName,Description_CHS,Description_CHT,Description_EN) values (@TypeName_CHS,@TypeName_CHT,@TypeName_EN,@ID,@Visual,@TableName,@Description_CHS,@Description_CHT,@Description_EN)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeName_CHS", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TypeName_CHS"].Value = this._TypeName_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeName_CHT", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TypeName_CHT"].Value = this._TypeName_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeName_EN", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TypeName_EN"].Value = this._TypeName_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = this._ID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visual", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Visual"].Value = this._Visual;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = this._TableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHS", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHS"].Value = this._Description_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHT", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHT"].Value = this._Description_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_EN", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_EN"].Value = this._Description_EN;
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
                string cmdText = "update Sys_TypeID set TypeName_CHS=@TypeName_CHS,TypeName_CHT=@TypeName_CHT,TypeName_EN=@TypeName_EN,ID=@ID,Visual=@Visual,TableName=@TableName,Description_CHS=@Description_CHS,Description_CHT=@Description_CHT,Description_EN=@Description_EN where pk_TypeID=@pk_TypeID";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeName_CHS", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TypeName_CHS"].Value = this._TypeName_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeName_CHT", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TypeName_CHT"].Value = this._TypeName_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeName_EN", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TypeName_EN"].Value = this._TypeName_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ID", OleDbType.Integer));
                oleDbCommand.Parameters["@ID"].Value = this._ID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visual", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Visual"].Value = this._Visual;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TableName", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@TableName"].Value = this._TableName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHS", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHS"].Value = this._Description_CHS;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_CHT", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_CHT"].Value = this._Description_CHT;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description_EN", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@Description_EN"].Value = this._Description_EN;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_TypeID"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Sys_TypeID where pk_TypeID=" + id);
        }
    }
}
