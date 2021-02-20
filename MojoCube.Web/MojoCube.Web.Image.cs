using System;
using System.Data.OleDb;

namespace MojoCube.Web.Image
{
    public class Category
    {
        private int _pk_Category;

        private string _CategoryName;

        private int _ParentID;

        private int _SortID;

        private bool _Visible;

        private string _CreateDate;

        private int _CreateUserID;

        private string _ModifyDate;

        private int _ModifyUserID;

        private string _Language;

        public int pk_Category
        {
            get
            {
                return this._pk_Category;
            }
            set
            {
                this._pk_Category = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this._CategoryName = value;
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

        public int CreateUserID
        {
            get
            {
                return this._CreateUserID;
            }
            set
            {
                this._CreateUserID = value;
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

        public int ModifyUserID
        {
            get
            {
                return this._ModifyUserID;
            }
            set
            {
                this._ModifyUserID = value;
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

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Image_Category where pk_Category=@pk_Category";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Category", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Category"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Category = Convert.ToInt32(oleDbDataReader["pk_Category"].ToString());
                    this._CategoryName = oleDbDataReader["CategoryName"].ToString();
                    this._ParentID = Convert.ToInt32(oleDbDataReader["ParentID"].ToString());
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._Visible = Convert.ToBoolean(oleDbDataReader["Visible"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._CreateUserID = Convert.ToInt32(oleDbDataReader["CreateUserID"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    if (oleDbDataReader["ModifyUserID"] != DBNull.Value)
                    {
                        this._ModifyUserID = Convert.ToInt32(oleDbDataReader["ModifyUserID"].ToString());
                    }
                    else
                    {
                        this._ModifyUserID = 0;
                    }
                    this._Language = oleDbDataReader["Language"].ToString();
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
                string cmdText = "insert into Image_Category(CategoryName,ParentID,SortID,Visible,CreateDate,CreateUserID,ModifyDate,ModifyUserID,[Language]) values (@CategoryName,@ParentID,@SortID,@Visible,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CategoryName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@CategoryName"].Value = this._CategoryName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
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
                string cmdText = "update Image_Category set CategoryName=@CategoryName,ParentID=@ParentID,SortID=@SortID,Visible=@Visible,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,[Language]=@Language where pk_Category=@pk_Category";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@CategoryName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@CategoryName"].Value = this._CategoryName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Category", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Category"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Image_Category where pk_Category=" + id);
        }
    }

    public class List
    {
        private int _pk_Image;

        private int _fk_Category;

        private string _FileName;

        private string _FilePath;

        private string _FileType;

        private int _FileSize;

        private int _Width;

        private int _Height;

        private string _Title;

        private string _CreateDate;

        private int _CreateUserID;

        private string _ModifyDate;

        private int _ModifyUserID;

        private string _Language;

        public int pk_Image
        {
            get
            {
                return this._pk_Image;
            }
            set
            {
                this._pk_Image = value;
            }
        }

        public int fk_Category
        {
            get
            {
                return this._fk_Category;
            }
            set
            {
                this._fk_Category = value;
            }
        }

        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                this._FileName = value;
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

        public string FileType
        {
            get
            {
                return this._FileType;
            }
            set
            {
                this._FileType = value;
            }
        }

        public int FileSize
        {
            get
            {
                return this._FileSize;
            }
            set
            {
                this._FileSize = value;
            }
        }

        public int Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
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

        public int CreateUserID
        {
            get
            {
                return this._CreateUserID;
            }
            set
            {
                this._CreateUserID = value;
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

        public int ModifyUserID
        {
            get
            {
                return this._ModifyUserID;
            }
            set
            {
                this._ModifyUserID = value;
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

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Image_List where pk_Image=@pk_Image";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Image", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Image"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Image = Convert.ToInt32(oleDbDataReader["pk_Image"].ToString());
                    this._fk_Category = Convert.ToInt32(oleDbDataReader["fk_Category"].ToString());
                    this._FileName = oleDbDataReader["FileName"].ToString();
                    this._FilePath = oleDbDataReader["FilePath"].ToString();
                    this._FileType = oleDbDataReader["FileType"].ToString();
                    this._FileSize = Convert.ToInt32(oleDbDataReader["FileSize"].ToString());
                    this._Width = Convert.ToInt32(oleDbDataReader["Width"].ToString());
                    this._Height = Convert.ToInt32(oleDbDataReader["Height"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._CreateUserID = Convert.ToInt32(oleDbDataReader["CreateUserID"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    if (oleDbDataReader["ModifyUserID"] != DBNull.Value)
                    {
                        this._ModifyUserID = Convert.ToInt32(oleDbDataReader["ModifyUserID"].ToString());
                    }
                    else
                    {
                        this._ModifyUserID = 0;
                    }
                    this._Language = oleDbDataReader["Language"].ToString();
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
                string cmdText = "insert into Image_List(fk_Category,FileName,FilePath,FileType,FileSize,Width,Height,Title,CreateDate,CreateUserID,ModifyDate,ModifyUserID,[Language]) values (@fk_Category,@FileName,@FilePath,@FileType,@FileSize,@Width,@Height,@Title,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Category", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Category"].Value = this._fk_Category;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@FileName"].Value = this._FileName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FilePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@FilePath"].Value = this._FilePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileType", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@FileType"].Value = this._FileType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileSize", OleDbType.Integer));
                oleDbCommand.Parameters["@FileSize"].Value = this._FileSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Width", OleDbType.Integer));
                oleDbCommand.Parameters["@Width"].Value = this._Width;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Height", OleDbType.Integer));
                oleDbCommand.Parameters["@Height"].Value = this._Height;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
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
                string cmdText = "update Image_List set fk_Category=@fk_Category,FileName=@FileName,FilePath=@FilePath,FileType=@FileType,FileSize=@FileSize,Width=@Width,Height=@Height,Title=@Title,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,[Language]=@Language where pk_Image=@pk_Image";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@fk_Category", OleDbType.Integer));
                oleDbCommand.Parameters["@fk_Category"].Value = this._fk_Category;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@FileName"].Value = this._FileName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FilePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@FilePath"].Value = this._FilePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileType", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@FileType"].Value = this._FileType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileSize", OleDbType.Integer));
                oleDbCommand.Parameters["@FileSize"].Value = this._FileSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Width", OleDbType.Integer));
                oleDbCommand.Parameters["@Width"].Value = this._Width;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Height", OleDbType.Integer));
                oleDbCommand.Parameters["@Height"].Value = this._Height;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Image", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Image"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Image_List where pk_Image=" + id);
        }
    }
}
