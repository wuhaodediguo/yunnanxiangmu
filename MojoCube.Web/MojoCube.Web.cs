using System;
using System.Configuration;
using System.Web;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System;
using System.Data;
using System.Web.UI.WebControls;
using MojoCube.Web.Site;
using System;
using System.Web;
using System;
using System.Data;
using System.Data.OleDb;
using MojoCube.Api.UI;
using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;



namespace MojoCube.Web
{
    public class Connection
    {
        public static string ConnString()
        {
            return ConfigurationManager.AppSettings["Conn"] + HttpContext.Current.Server.MapPath("~/") + "Data/McCMS_V5.mdb";
        }
        public static string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

    public class GetClass
    {
        public DataTable ClassDT;

        public string TableName = "";

        public string Where = "";

        public void BindClass()
        {
            this.ClassDT = new DataTable();
            this.ClassDT.Columns.Add("Indent");
            this.ClassDT.Columns.Add("pk_Category");
            this.ClassDT.Columns.Add("ParentID");
            this.ClassDT.Columns.Add("LevelID");
            this.ClassDT.Columns.Add("CategoryName");
            this.ClassDT.Columns.Add("IndexID");
            this.ClassDT.Columns.Add("Visible", typeof(bool));
            this.ClassDT.Columns.Add("SortID");
            DataTable dataTable = new DataTable();
            dataTable = Sql.SqlQueryDS("select * from " + this.TableName + " where ParentID=0" + this.Where).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = this.ClassDT.NewRow();
                dataRow["Indent"] = "╋";
                dataRow["pk_Category"] = dataTable.Rows[i]["pk_Category"].ToString();
                dataRow["ParentID"] = dataTable.Rows[i]["ParentID"].ToString();
                dataRow["LevelID"] = dataTable.Rows[i]["LevelID"].ToString();
                dataRow["CategoryName"] = dataTable.Rows[i]["CategoryName"].ToString();
                dataRow["IndexID"] = dataTable.Rows[i]["IndexID"].ToString();
                dataRow["Visible"] = dataTable.Rows[i]["Visible"].ToString();
                dataRow["SortID"] = dataTable.Rows[i]["SortID"].ToString();
                this.ClassDT.Rows.Add(dataRow);
                this.BindChild(dataTable.Rows[i]["pk_Category"].ToString(), "├──");
            }
        }

        public void BindChild(string ParentID, string separator)
        {
            DataTable dataTable = new DataTable();
            dataTable = Sql.SqlQueryDS("select * from " + this.TableName + " where ParentID=" + ParentID).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = this.ClassDT.NewRow();
                dataRow["Indent"] = separator;
                dataRow["pk_Category"] = dataTable.Rows[i]["pk_Category"].ToString();
                dataRow["ParentID"] = dataTable.Rows[i]["ParentID"].ToString();
                dataRow["LevelID"] = dataTable.Rows[i]["LevelID"].ToString();
                dataRow["CategoryName"] = dataTable.Rows[i]["CategoryName"].ToString();
                dataRow["IndexID"] = dataTable.Rows[i]["IndexID"].ToString();
                dataRow["Visible"] = dataTable.Rows[i]["Visible"].ToString();
                dataRow["SortID"] = dataTable.Rows[i]["SortID"].ToString();
                this.ClassDT.Rows.Add(dataRow);
                string separator2 = separator + "───";
                this.BindChild(dataTable.Rows[i]["pk_Category"].ToString(), separator2);
            }
        }

        public void BindClass(DropDownList ddl)
        {
            DataTable dataTable = new DataTable();
            dataTable = Sql.SqlQueryDS("select * from " + this.TableName + " where ParentID=0" + this.Where).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = "╋" + dataTable.Rows[i]["CategoryName"].ToString();
                listItem.Value = dataTable.Rows[i]["pk_Category"].ToString();
                ddl.Items.Add(listItem);
                this.BindChild(dataTable.Rows[i]["pk_Category"].ToString(), "├──", ddl);
            }
        }

        public void BindChild(string ParentID, string separator, DropDownList ddl)
        {
            DataTable dataTable = new DataTable();
            dataTable = Sql.SqlQueryDS("select * from " + this.TableName + " where ParentID=" + ParentID).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = separator + dataTable.Rows[i]["CategoryName"].ToString();
                listItem.Value = dataTable.Rows[i]["pk_Category"].ToString();
                ddl.Items.Add(listItem);
                string separator2 = separator + "───";
                this.BindChild(dataTable.Rows[i]["pk_Category"].ToString(), separator2, ddl);
            }
        }
    }

    public class IP
    {
        public static string Get()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static bool IsBound(string language)
        {
            bool result = false;
            if (bool.Parse(Cache.GetIsBoundIP(language)))
            {
                string a = IP.Get();
                string boundIP = Cache.GetBoundIP(language);
                string[] array = boundIP.Split(new char[]
				{
					'|'
				});
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (a == array[i])
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }
    }

    public class OledbHelper
    {
        public T ExecuteScalar<T>(string sql, params object[] args)
        {
            T result;
            using (OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString()))
            {
                result = (T)((object)this.MakeCommand(oleDbConnection, sql, args).ExecuteScalar());
            }
            return result;
        }

        public void ExecuteNonQuery(string sql, params object[] args)
        {
            using (OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString()))
            {
                this.MakeCommand(oleDbConnection, sql, args).ExecuteNonQuery();
            }
        }

        public IDataReader ExecuteReader(string sql, params object[] args)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            IDataReader result;
            try
            {
                OleDbCommand oleDbCommand = this.MakeCommand(oleDbConnection, sql, args);
                result = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                oleDbConnection.Close();
                throw;
            }
            return result;
        }

        public OleDbCommand MakeCommand(OleDbConnection conn, string sql, params object[] args)
        {
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            for (int i = 0; i < args.Length; i++)
            {
                oleDbCommand.Parameters.AddWithValue(i.ToString(), args[i]);
            }
            return oleDbCommand;
        }

        public DataTable GetDataTable(string sql, params object[] args)
        {
            DataTable dataTable = new DataTable();
            IDataReader dataReader = this.ExecuteReader(sql, args);
            dataTable.Load(dataReader);
            dataReader.Close();
            return dataTable;
        }
    }

    public class Sql
    {
        private string _TableName;

        private string _OrderByKey;

        private string _OrderByType;

        private string _Where;

        private string _pk_ID;

        private string _ParentID;

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

        public string OrderByKey
        {
            get
            {
                return this._OrderByKey;
            }
            set
            {
                this._OrderByKey = value;
            }
        }

        public string OrderByType
        {
            get
            {
                return this._OrderByType;
            }
            set
            {
                this._OrderByType = value;
            }
        }

        public string Where
        {
            get
            {
                return this._Where;
            }
            set
            {
                this._Where = value;
            }
        }

        public string pk_ID
        {
            get
            {
                return this._pk_ID;
            }
            set
            {
                this._pk_ID = value;
            }
        }

        public string ParentID
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

        public static void SqlQuery(string strSql)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            oleDbConnection.Open();
            OleDbTransaction oleDbTransaction = oleDbConnection.BeginTransaction();
            try
            {
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Transaction = oleDbTransaction;
                oleDbCommand.Connection = oleDbConnection;
                for (int i = 0; i < strSql.Split(new char[]
				{
					'|'
				}).Length; i++)
                {
                    oleDbCommand.CommandText = strSql.Split(new char[]
					{
						'|'
					})[i];
                    oleDbCommand.ExecuteNonQuery();
                }
                oleDbTransaction.Commit();
            }
            catch
            {
                oleDbTransaction.Rollback();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public static DataSet SqlQueryDS(string strSql)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            DataSet dataSet = new DataSet();
            try
            {
                oleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand();
                oleDbCommand.Connection = oleDbConnection;
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
                for (int i = 0; i < strSql.Split(new char[]
				{
					'|'
				}).Length; i++)
                {
                    oleDbCommand.CommandText = strSql.Split(new char[]
					{
						'|'
					})[i];
                    oleDbDataAdapter.SelectCommand = oleDbCommand;
                    oleDbDataAdapter.Fill(dataSet, i.ToString());
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return dataSet;
        }

        public static int GetResultCount(string tabeName, string where)
        {
            int result = -1;
            string text = "SELECT Count(*) as counts FROM " + tabeName;
            if (where != null && where.Trim().Length > 0)
            {
                text = text + " WHERE " + where;
            }
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            OleDbCommand oleDbCommand = new OleDbCommand(text, oleDbConnection);
            try
            {
                oleDbConnection.Open();
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    result = int.Parse(oleDbDataReader["counts"].ToString());
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static void AddClicks(string tableName, string where, int clicks)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update " + tableName + " set Clicks=@Clicks where " + where;
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Clicks", OleDbType.Integer));
                oleDbCommand.Parameters["@Clicks"].Value = clicks + 1;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public static void BindClass(DropDownList ddlCategory, string tableName)
        {
            ddlCategory.Items.Insert(0, new ListItem("不限分类", "0"));
            DataTable dataTable = new DataTable();
            dataTable = Sql.SqlQueryDS(string.Concat(new string[]
			{
				"select * from ",
				tableName,
				" where ParentID=0 and [Language]='",
				Language.GetLanguage(),
				"' and Visible=True order by SortID asc"
			})).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = "╋" + dataTable.Rows[i]["CategoryName"].ToString();
                listItem.Value = dataTable.Rows[i]["pk_Category"].ToString();
                ddlCategory.Items.Add(listItem);
                Sql.BindChild(ddlCategory, dataTable.Rows[i]["pk_Category"].ToString(), "├──", tableName);
            }
        }

        public static void BindChild(DropDownList ddlCategory, string ParentID, string separator, string tableName)
        {
            DataTable dataTable = new DataTable();
            dataTable = Sql.SqlQueryDS(string.Concat(new string[]
			{
				"select * from ",
				tableName,
				" where ParentID=",
				ParentID,
				" and Visible=True"
			})).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = separator + dataTable.Rows[i]["CategoryName"].ToString();
                listItem.Value = dataTable.Rows[i]["pk_Category"].ToString();
                ddlCategory.Items.Add(listItem);
                string separator2 = separator + "───";
                Sql.BindChild(ddlCategory, dataTable.Rows[i]["pk_Category"].ToString(), separator2, tableName);
            }
        }

        public static void DropDownListBind(DropDownList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType)
        {
            if (where != null)
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" where ",
					where,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            else
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            ddlList.DataTextField = dataText;
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
        }

        public static void ListBoxBind(ListBox ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType)
        {
            if (where != null)
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" where ",
					where,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            else
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            ddlList.DataTextField = dataText;
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
        }

        public static void CheckBoxListBind(CheckBoxList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType)
        {
            if (where != null)
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" where ",
					where,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            else
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            ddlList.DataTextField = dataText;
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
        }

        public static void DropDownListBind(DropDownList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType, ListItem listItem)
        {
            if (where != null)
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" where ",
					where,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            else
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					tableName,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            ddlList.DataTextField = dataText;
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
            if (listItem != null)
            {
                ddlList.Items.Insert(0, listItem);
            }
        }

        public static void DropDownListBind(DropDownList ddlList, string tableName, string dataText, string dataValue, string where, string orderByKey, string orderByType, ListItem listItem, int iSpace)
        {
            string text = "\u3000";
            for (int i = 0; i < iSpace; i++)
            {
                text += text;
            }
            if (where != null)
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select *,convert(nvarchar,'",
					text,
					"')+",
					dataText,
					" as newData from ",
					tableName,
					" where ",
					where,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            else
            {
                ddlList.DataSource = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select *,convert(nvarchar,'",
					text,
					"')+",
					dataText,
					" as newData from ",
					tableName,
					" order by ",
					orderByKey,
					" ",
					orderByType
				}));
            }
            ddlList.DataTextField = "newData";
            ddlList.DataValueField = dataValue;
            ddlList.DataBind();
            if (listItem != null)
            {
                ddlList.Items.Insert(0, listItem);
            }
        }

        public static void ddlFindByValue(DropDownList ddl, string value)
        {
            try
            {
                ddl.SelectedIndex = -1;
                ddl.Items.FindByValue(value).Selected = true;
            }
            catch
            {
            }
        }

        public static void ddlFindByText(DropDownList ddl, string text)
        {
            try
            {
                ddl.SelectedIndex = -1;
                ddl.Items.FindByText(text).Selected = true;
            }
            catch
            {
            }
        }

        public void TreeGridBind(GridView gridView)
        {
            DataTable dataTable = new DataTable();
            DataSet dataSet = new DataSet();
            if (this._Where != null)
            {
                dataSet = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					this._TableName,
					" where ",
					this._Where,
					" order by ",
					this._OrderByKey,
					" ",
					this._OrderByType
				}));
            }
            else
            {
                dataSet = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select * from ",
					this._TableName,
					" order by ",
					this._OrderByKey,
					" ",
					this._OrderByType
				}));
            }
            dataTable = dataSet.Tables[0].Clone();
            dataTable = this.CreateForest(dataSet, dataTable);
            gridView.AllowPaging = false;
            gridView.DataSource = dataTable;
            gridView.DataBind();
        }

        public DataTable CreateForest(DataSet CreateForestDS, DataTable CreateForestDT)
        {
            DataRow[] array = CreateForestDS.Tables[0].Select(this._ParentID + "=0");
            for (int i = 0; i < array.Length; i++)
            {
                DataRow dataRow = array[i];
                this.CreateTree(Convert.ToInt32(dataRow[this._pk_ID]), CreateForestDS, CreateForestDT);
            }
            return CreateForestDT;
        }

        public DataTable CreateTree(int pkID, DataSet CreateTreeDS, DataTable CreateTreeDT)
        {
            DataRow[] array = CreateTreeDS.Tables[0].Select(this.pk_ID + "=" + pkID);
            for (int i = 0; i < array.Length; i++)
            {
                DataRow dataRow = array[i];
                if (Convert.ToInt32(dataRow[this._ParentID]) == 0)
                {
                    CreateTreeDT.Rows.Add(dataRow.ItemArray);
                }
                DataRow[] array2 = CreateTreeDS.Tables[0].Select(this._ParentID + "=" + pkID);
                for (int j = 0; j < array2.Length; j++)
                {
                    DataRow dataRow2 = array2[j];
                    CreateTreeDT.Rows.Add(dataRow2.ItemArray);
                    this.CreateTree(Convert.ToInt32(dataRow2[this._pk_ID]), CreateTreeDS, CreateTreeDT);
                }
            }
            return CreateTreeDT;
        }

        public static void SetSortID(string tableName, string pkID, string id, int sortID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                int num = 0;
                DataTable dataTable = Sql.SqlQueryDS(string.Concat(new string[]
				{
					"select SortID from ",
					tableName,
					" where ",
					pkID,
					"=",
					id
				})).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    num = int.Parse(dataTable.Rows[0]["SortID"].ToString());
                }
                oleDbConnection.Open();
                string cmdText = string.Concat(new string[]
				{
					"update ",
					tableName,
					" set SortID=",
					(num + sortID).ToString(),
					" where ",
					pkID,
					"=",
					id
				});
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void SetSortID(string id, string sortID)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = string.Concat(new string[]
				{
					"update ",
					this._TableName,
					" set SortID=",
					sortID,
					" where ",
					this._pk_ID,
					"=",
					id
				});
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public static bool IsExist(string tableName, string columnName, string value)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            bool result;
            try
            {
                oleDbConnection.Open();
                string cmdText = string.Concat(new string[]
				{
					"select ",
					columnName,
					" from ",
					tableName,
					" where ",
					columnName,
					"=@",
					columnName
				});
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@" + columnName, OleDbType.VarChar));
                oleDbCommand.Parameters["@" + columnName].Value = value;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
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

        public static bool IsExist(string tableName, string columnName, string value, string where)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            bool result;
            try
            {
                oleDbConnection.Open();
                string cmdText = string.Concat(new string[]
				{
					"select ",
					columnName,
					" from ",
					tableName,
					" where ",
					where,
					" and ",
					columnName,
					"=@",
					columnName
				});
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@" + columnName, OleDbType.VarChar));
                oleDbCommand.Parameters["@" + columnName].Value = value;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
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

        public static bool IsExist(string tableName, string columnName, int value)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            bool result;
            try
            {
                oleDbConnection.Open();
                string cmdText = string.Concat(new string[]
				{
					"select ",
					columnName,
					" from ",
					tableName,
					" where ",
					columnName,
					"=@",
					columnName
				});
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@" + columnName, OleDbType.Integer));
                oleDbCommand.Parameters["@" + columnName].Value = value;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
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

        public static bool IsExist(string tableName, string columnName, int value, string where)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            bool result;
            try
            {
                oleDbConnection.Open();
                string cmdText = string.Concat(new string[]
				{
					"select ",
					columnName,
					" from ",
					tableName,
					" where ",
					where,
					" and ",
					columnName,
					"=@",
					columnName
				});
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@" + columnName, OleDbType.Integer));
                oleDbCommand.Parameters["@" + columnName].Value = value;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
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
    }

    public class String
    {
        public static string ShowAlert(string type, string content)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div class=\"alert alert-" + type + " alert-dismissable\">");
            stringBuilder.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");
            stringBuilder.Append(content);
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();
        }

        public static string ShowInformationMessage(string type, string content)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div class=\"alert alert-" + type + " alert-dismissable\">");
            stringBuilder.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");
            stringBuilder.Append(content);
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();
        }


        public static void ShowDel(GridViewRowEventArgs e)
        {
            string str = "删除该记录将不能恢复，确定删除吗？";
            ((LinkButton)e.Row.FindControl("gvDelete")).OnClientClick = "{return confirm('" + str + "');}";
        }

        public static int ToInt(string value)
        {
            int result;
            try
            {
                result = int.Parse(value);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static decimal ToDecimal(string value)
        {
            decimal result;
            try
            {
                result = decimal.Parse(value);
            }
            catch
            {
                result = 0m;
            }
            return result;
        }

        public static string GetChineseName(string text, bool isLastName)
        {
            text = text.Replace("~", "").Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("^", "").Replace("&", "").Replace("*", "").Replace("|", "");
            if (text == "")
            {
                text = "无名氏";
            }
            int length = text.Length;
            string text2 = "";
            string text3;
            switch (length)
            {
                case 1:
                    text3 = text.Substring(0, 1);
                    break;
                case 2:
                    text3 = text.Substring(0, 1);
                    text2 = text.Substring(1, 1);
                    break;
                case 3:
                    {
                        string a = text.Substring(0, 2);
                        if (a == "欧阳" || a == "慕容" || a == "上官" || a == "司马" || a == "东方" || a == "公孙" || a == "吕丘" || a == "诸葛" || a == "夏侯" || a == "东郭")
                        {
                            text3 = text.Substring(0, 2);
                            text2 = text.Substring(2, 1);
                        }
                        else
                        {
                            text3 = text.Substring(0, 1);
                            text2 = text.Substring(1, 2);
                        }
                        break;
                    }
                case 4:
                    text3 = text.Substring(0, 2);
                    text2 = text.Substring(2, 2);
                    break;
                case 5:
                    text3 = text.Substring(0, 2);
                    text2 = text.Substring(2, 3);
                    break;
                default:
                    text3 = text;
                    break;
            }
            string result;
            if (isLastName)
            {
                result = text3;
            }
            else
            {
                result = text2;
            }
            return result;
        }

        public static int PageSize()
        {
            return 10;
        }

        public static int PageSize(string type)
        {
            int result = 10;
            if (type != null)
            {
                if (!(type == "article"))
                {
                    if (!(type == "product"))
                    {
                        if (!(type == "download"))
                        {
                            if (!(type == "album"))
                            {
                                if (!(type == "download"))
                                {
                                    if (type == "comment")
                                    {
                                        result = 5;
                                    }
                                }
                                else
                                {
                                    result = 10;
                                }
                            }
                            else
                            {
                                result = 12;
                            }
                        }
                        else
                        {
                            result = 60000;
                        }
                    }
                    else
                    {
                        result = 12;
                    }
                }
                else
                {
                    result = 10;
                }
            }
            return result;
        }

        public static int GetNumericButtonCount()
        {
            return 5;
        }

        public static string GetBrowserInfo()
        {
            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            return browser.Browser + " " + browser.Version;
        }

        public static string GetUrl(int type)
        {
            string result = "";
            switch (type)
            {
                case 0:
                    {
                        string text = HttpContext.Current.Request.RawUrl;
                        string text2 = HttpContext.Current.Request.ApplicationPath;
                        if (text2 != "/")
                        {
                            text2 += "/";
                            text = text.Replace(text2, "");
                        }
                        result = text;
                        break;
                    }
                case 1:
                    result = HttpContext.Current.Request.FilePath;
                    break;
                case 2:
                    result = HttpContext.Current.Request.Path;
                    break;
                case 3:
                    result = HttpContext.Current.Request.Url.AbsoluteUri;
                    break;
                case 4:
                    result = HttpContext.Current.Request.Url.Host;
                    break;
                case 5:
                    result = HttpContext.Current.Request.Url.Port.ToString();
                    break;
                case 6:
                    result = HttpContext.Current.Request.Url.Authority;
                    break;
                case 7:
                    result = HttpContext.Current.Request.Url.Scheme;
                    break;
            }
            return result;
        }

        public static string GetRelativePath(string path)
        {
            path = HttpContext.Current.Request.ApplicationPath + "/" + path;
            path = path.Replace("///", "/").Replace("//", "/");
            return path;
        }

        public static string SubString(string text, int textLong)
        {
            if (text.Length > textLong)
            {
                text = text.Substring(0, textLong) + "...";
            }
            return text;
        }

        public static string BoolToString(bool value)
        {
            string result;
            if (value)
            {
                result = "1";
            }
            else
            {
                result = "0";
            }
            return result;
        }

        public static bool StringToBool(string value)
        {
            return !(value == "0");
        }

        public static string GetPageName()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public static string GetTitle(string title1, string title2)
        {
            return title1 + " | " + title2;
        }
    }
}
