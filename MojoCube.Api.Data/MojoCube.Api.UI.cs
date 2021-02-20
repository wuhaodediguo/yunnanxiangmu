using MojoCube.Api.File;
using System;
using System.Web.UI.WebControls;
using MojoCube.Api.Data;
using MojoCube.Api.File;
using MojoCube.Api.Text;
using System;
using System.Collections;
using System.Data;
using System.Web;
using Wuqi.Webdiyer;
using System.Text;
using System.Web.UI;
using System.Globalization;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;

namespace MojoCube.Api.UI
{
    public class AdminGridView
    {
        public static void SetSortingRowCreated(GridViewRowEventArgs e, string strSortBy, bool strSortAscending, GridView GridView1)
        {
            if (e.Row != null && e.Row.RowType == DataControlRowType.Header)
            {
                string relativePath = MojoCube.Api.File.Function.GetRelativePath("Admin/Images/asc.gif");
                string relativePath2 = MojoCube.Api.File.Function.GetRelativePath("Admin/Images/desc.gif");
                string text = (!strSortAscending) ? ("<img src='" + relativePath + "' />") : ("<img src='" + relativePath2 + "' />");
                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    if (strSortBy == GridView1.Columns[i].SortExpression)
                    {
                        TableCell tableCell = e.Row.Cells[i];
                        Label label = new Label();
                        label.Text = text;
                        tableCell.CssClass = "sort";
                        tableCell.Controls.Add(label);
                    }
                }
            }
        }

        public static void SetDataRow(GridViewRowEventArgs e, string[] controlList)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && controlList.Length > 0)
            {
                for (int i = 0; i < controlList.Length; i++)
                {
                    ((LinkButton)e.Row.FindControl(controlList[i].ToString())).CommandArgument = e.Row.RowIndex.ToString();
                }
            }
        }

        public static void AddGridColumn(GridView gridView, string dataField, string headerText, string headerStyle, string itemStyle)
        {
            BoundField boundField = new BoundField();
            boundField.DataField = dataField;
            boundField.HeaderText = headerText;
            boundField.HeaderStyle.CssClass = headerStyle;
            boundField.ItemStyle.CssClass = itemStyle;
            gridView.Columns.Add(boundField);
        }
    }

    public class AdminPager
    {
        private AspNetPager _Pager;

        private int _PageSize;

        private string _ConnStr;

        private int _CurrentPageIndex;

        private string _TableName;

        private string _strGetFields;

        private string _fldName;

        private string _where;

        private bool _OrderType;

        private ArrayList _parameter;

        public bool ShowCustomInfo = true;

        public int PageSize
        {
            get
            {
                return this._PageSize;
            }
            set
            {
                this._PageSize = value;
            }
        }

        public string ConnStr
        {
            get
            {
                return this._ConnStr;
            }
            set
            {
                this._ConnStr = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return this._CurrentPageIndex;
            }
            set
            {
                this._CurrentPageIndex = value;
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

        public string strGetFields
        {
            get
            {
                return this._strGetFields;
            }
            set
            {
                this._strGetFields = value;
            }
        }

        public string fldName
        {
            get
            {
                return this._fldName;
            }
            set
            {
                this._fldName = value;
            }
        }

        public string where
        {
            get
            {
                return this._where;
            }
            set
            {
                this._where = value;
            }
        }

        public bool OrderType
        {
            get
            {
                return this._OrderType;
            }
            set
            {
                this._OrderType = value;
            }
        }

        public ArrayList parameter
        {
            get
            {
                return this._parameter;
            }
            set
            {
                this._parameter = value;
            }
        }

        public AdminPager(AspNetPager Pager)
        {
            string relativePath = MojoCube.Api.File.Function.GetRelativePath("Admin/Images/first.gif");
            string relativePath2 = MojoCube.Api.File.Function.GetRelativePath("Admin/Images/last.gif");
            string relativePath3 = MojoCube.Api.File.Function.GetRelativePath("Admin/Images/next.gif");
            string relativePath4 = MojoCube.Api.File.Function.GetRelativePath("Admin/Images/prev.gif");
            this._Pager = Pager;
            this._Pager.FirstPageText = "<span class=btnLink title='首页'><img src='" + relativePath + "' /></span>";
            this._Pager.LastPageText = "<span class=btnLink title='尾页'><img src='" + relativePath2 + "' /></span>";
            this._Pager.NextPageText = "<span class=btnLink title='下一页'><img src='" + relativePath3 + "' /></span>";
            this._Pager.NumericButtonTextFormatString = "<span class=Pager>{0}</span>";
            this._Pager.PrevPageText = "<span class=btnLink title='上一页'><img src='" + relativePath4 + "' /></span>";
            this._Pager.SubmitButtonText = "GO";
            this._Pager.CustomInfoClass = "CustomInfo";
            this._Pager.CssClass = "Pager";
            this._Pager.SubmitButtonClass = "PagerBtn";
            this._Pager.CurrentPageButtonClass = "CurrentPage";
            this._Pager.ShowCustomInfoSection = ShowCustomInfoSection.Left;
            this._Pager.AlwaysShow = true;
            this._Pager.UrlPaging = false;
            string text = RegexClass.ChkInt(HttpContext.Current.Request.QueryString["page"]);
            if (text != "0")
            {
                this._CurrentPageIndex = System.Convert.ToInt32(text);
            }
            else
            {
                this._CurrentPageIndex = this._Pager.CurrentPageIndex;
            }
            if (this._where == null)
            {
                this._where = "";
            }
        }

        public DataTable GetTable()
        {
            this.SetPagerInfo();
            
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" desc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" asc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" desc"
					}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }


        public DataTable GetTable(int memnoy)
        {
            this.SetPagerInfo();
            if (this._CurrentPageIndex < memnoy && memnoy <= this._Pager.PageCount)
            {
                this._CurrentPageIndex = memnoy;
            }
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" desc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" asc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" desc"
					}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    if (sql.Contains("col601,ID desc"))
                    {
                        sql = sql.Replace("col601,ID desc", "col601 desc,ID desc").Replace("col601,ID asc", "col601 asc,ID asc");
                    }
                    if (sql.Contains("col50,ID desc"))
                    {
                        sql = sql.Replace("col50,ID desc", "col50 desc,ID desc").Replace("col50,ID asc", "col50 asc,ID asc");
                    }
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        //add by wuhao start
        public DataTable GetTable2(int memnoy)
        {
            this.SetPagerInfo();
            if (this._CurrentPageIndex < memnoy && memnoy <= this._Pager.PageCount)
            {
                this._CurrentPageIndex = memnoy;
            }
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                //this.strGetFields = " CustomerName,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2 from ( select distinct CustomerName,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2  from CustomerOffer where 1=1 )";
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {

                    //arg = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ",
                    //    this._TableName,
                    //    this._where,
                    //    " order by order by col32 desc,id desc ",
                    //}), this._CurrentPageIndex * this._PageSize);
                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);

                    if (_CurrentPageIndex == 1)
                    {
                        sql = string.Format(string.Concat(new string[]
                        {
                            "select top 10 ",
                            this.strGetFields,
                            " from (select  * from caiwu1view where 1=1 order by col50 asc,id desc )   ",
                            this._where
                        }), this._CurrentPageIndex * this._PageSize);
                    }
                    else
                    {
                        sql = string.Format(string.Concat(new string[]
                        {
                            "select top {0} ",
							this.strGetFields,
							" from (select  * from caiwu1view where 1=1 order by col50 asc,id desc )   ",
							"  where id not in (select top {1} id from caiwu1view where 1=1 order by col50 asc,id desc)   ",
							this._where.Replace("where 1=1", "")
                        }), num,(this._CurrentPageIndex - 1) * this._PageSize);
                    }

                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        public DataTable GetTable33(int memnoy)
        {
            this.SetPagerInfo();
            if (this._CurrentPageIndex < memnoy && memnoy <= this._Pager.PageCount)
            {
                this._CurrentPageIndex = memnoy;
            }
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                //this.strGetFields = " CustomerName,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2 from ( select distinct CustomerName,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2  from CustomerOffer where 1=1 )";
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {

                    //arg = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ",
                    //    this._TableName,
                    //    this._where,
                    //    " order by order by col32 desc,id desc ",
                    //}), this._CurrentPageIndex * this._PageSize);
                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);

                    if (_CurrentPageIndex == 1)
                    {
                        sql = string.Format(string.Concat(new string[]
                        {
                            "select top 10 ",
                            this.strGetFields,
                            " from (select  * from t_shichangview where 1=1 order by col601 asc,id desc )   ",
                            this._where
                        }), this._CurrentPageIndex * this._PageSize);
                    }
                        else
                    {
                        sql = string.Format(string.Concat(new string[]
                        {
                            "select top {0} ",
							this.strGetFields,
							" from (select  * from t_shichangview where 1=1 order by col601 asc,id desc )   ",
							"  where id not in (select top {1} id from t_shichangview where 1=1 order by col601 asc,id desc)   ",
							this._where.Replace("where 1=1", "")
                        }), num,(this._CurrentPageIndex - 1) * this._PageSize);
                    }
                    //else
                    //{
                    //    sql = string.Format(string.Concat(new string[]
                    //    {
                    //        "select top 10 ",
                    //        this.strGetFields,
                    //        " from (select  * from t_shichang where 1=1 order by col45 desc,id desc )   ",
                    //        "  where id not in (select top {0} id from t_shichang where 1=1 order by col45 desc,id desc)   ",
                    //        this._where.Replace("where 1=1", "")
                    //    }), (this._CurrentPageIndex - 1) * this._PageSize);
                    //}

                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        public DataTable GetTable34(int memnoy)
        {
            this.SetPagerInfo();
            if (this._CurrentPageIndex < memnoy && memnoy <= this._Pager.PageCount)
            {
                this._CurrentPageIndex = memnoy;
            }
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                //this.strGetFields = " CustomerName,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2 from ( select distinct CustomerName,FirstWeight,FirstWeightPrice,HeavyWeightPrice,Weight1,Weight2  from CustomerOffer where 1=1 )";
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {

                    //arg = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ",
                    //    this._TableName,
                    //    this._where,
                    //    " order by order by col32 desc,id desc ",
                    //}), this._CurrentPageIndex * this._PageSize);
                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);

                    if (_CurrentPageIndex == 1)
                    {
                        sql = string.Format(string.Concat(new string[]
                        {
                            "select top 10 ",
                            this.strGetFields,
                            " from (select  * from t_shichangview2 where 1=1 order by col601 asc,id desc )   ",
                            this._where
                        }), this._CurrentPageIndex * this._PageSize);
                    }
                    else
                    {
                        sql = string.Format(string.Concat(new string[]
                        {
                            "select top {0} ",
							this.strGetFields,
							" from (select  * from t_shichangview2 where 1=1 order by col601 asc,id desc )   ",
							"  where id not in (select top {1} id from t_shichangview2 where 1=1 order by col601 asc,id desc)   ",
							this._where.Replace("where 1=1", "")
                        }), num, (this._CurrentPageIndex - 1) * this._PageSize);
                    }
                    //else
                    //{
                    //    sql = string.Format(string.Concat(new string[]
                    //    {
                    //        "select top 10 ",
                    //        this.strGetFields,
                    //        " from (select  * from t_shichang where 1=1 order by col45 desc,id desc )   ",
                    //        "  where id not in (select top {0} id from t_shichang where 1=1 order by col45 desc,id desc)   ",
                    //        this._where.Replace("where 1=1", "")
                    //    }), (this._CurrentPageIndex - 1) * this._PageSize);
                    //}

                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }


        public void SetPagerInfo2()
        {
            this._Pager.RecordCount = this.GetRecordCount2();
            this._Pager.PageSize = this._PageSize;
            if (this.ShowCustomInfo)
            {
                this._Pager.CustomInfoHTML = string.Concat(new object[]
				{
					"<div class='cleft'>共<span>",
					this._Pager.RecordCount,
					"</span>条 | 每页<span>",
					this._Pager.PageSize,
					"</span>条 | 共<span>",
					this._Pager.PageCount,
					"</span>页</div>"
				});
            }
        }

        public int GetRecordCount2()
        {
            OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
            string sql = @"select count(*) AS [Counter] from ( select distinct CustomerName,FirstWeight,FirstWeightPrice,
                HeavyWeightPrice,Weight1,Weight2  from CustomerOffer where 1=1 ) A";
            
            int result;
            if (this._where != null && this._where != "")
            {
                result = oledbHelper.ExecuteScalar<int>(sql, (string[])this.parameter.ToArray(typeof(string)));
            }
            else
            {
                result = oledbHelper.ExecuteScalar<int>(sql, new object[0]);
            }
            return result;
        }

        public DataTable GetTable3()
        {
            this.SetPagerInfo2();
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                this.strGetFields = " PKID,costquotation,subrate,mainrate from ( select distinct PKID,costquotation,subrate,mainrate from CostQuotation where 1=1 )";
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {
                    sql = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields
						
					}), this._CurrentPageIndex * this._PageSize);
                    //arg2 = string.Format(string.Concat(new string[]
                    //{
                    //    "select top {0} ",
                    //    this.strGetFields,
                    //    " from ({1}) order by ",
                    //    this.fldName,
                    //    " asc"
                    //}), num, arg);
                    //sql = string.Format(string.Concat(new string[]
                    //{
                    //    "select ",
                    //    this.strGetFields,
                    //    " from ({0}) order by ",
                    //    this.fldName,
                    //    " desc"
                    //}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        public void SetPagerInfo3()
        {
            this._Pager.RecordCount = this.GetRecordCount3();
            this._Pager.PageSize = this._PageSize;
            if (this.ShowCustomInfo)
            {
                this._Pager.CustomInfoHTML = string.Concat(new object[]
				{
					"<div class='cleft'>共<span>",
					this._Pager.RecordCount,
					"</span>条 | 每页<span>",
					this._Pager.PageSize,
					"</span>条 | 共<span>",
					this._Pager.PageCount,
					"</span>页</div>"
				});
            }
        }

        public int GetRecordCount3()
        {
            OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
            string sql = @"select count(*) AS [Counter] from ( select distinct PKID,costquotation,subrate,mainrate  from CostQuotation where 1=1 ) A";

            int result;
            if (this._where != null && this._where != "")
            {
                result = oledbHelper.ExecuteScalar<int>(sql, (string[])this.parameter.ToArray(typeof(string)));
            }
            else
            {
                result = oledbHelper.ExecuteScalar<int>(sql, new object[0]);
            }
            return result;
        }

        //add by wuhao end

        public int GetRecordCount()
        {
            OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
            string sql = string.Empty;
            sql = string.Concat(new string[]
			{
				"select count(",
				this.strGetFields,
				") as [Counter] from ",
				this._TableName,
				this._where
			});
            int result;
            if (this._where != null && this._where != "")
            {
                result = oledbHelper.ExecuteScalar<int>(sql, (string[])this.parameter.ToArray(typeof(string)));
            }
            else
            {
                result = oledbHelper.ExecuteScalar<int>(sql, new object[0]);
            }
            return result;
        }

        public void SetPagerInfo()
        {
            this._Pager.RecordCount = this.GetRecordCount();
            this._Pager.PageSize = this._PageSize;
            if (this.ShowCustomInfo)
            {
                this._Pager.CustomInfoHTML = string.Concat(new object[]
				{
					"<div class='cleft'>共<span>",
					this._Pager.RecordCount,
					"</span>条 | 每页<span>",
					this._Pager.PageSize,
					"</span>条 | 共<span>",
					this._Pager.PageCount,
					"</span>页</div>"
				});
            }
        }
    }

    public class AdminRadioButton
    {
        public static void CheckRBL(RadioButtonList rbl, bool bTure)
        {
            switch (bTure)
            {
                case false:
                    rbl.Items[0].Selected = true;
                    break;
                case true:
                    rbl.Items[1].Selected = true;
                    break;
            }
        }
    }

    public class ColorPicker
    {
        public static string MiniColorPicker(string visual)
        {
            StringBuilder stringBuilder = new StringBuilder();
            visual = visual.ToLower();
            string[] array = new string[]
			{
				"",
				"#008000",
				"#ff0000",
				"#0000ff",
				"#ffff00",
				"#ff00ff",
				"#000000"
			};
            for (int i = 0; i < array.Length; i++)
            {
                if (visual == array[i] && array[i] != string.Empty)
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<div style='float:left; width:15px; height:15px; margin:0 2px; cursor:pointer; border:solid 2px #666; background:",
						array[i],
						"' onclick=\"colorPicker(this,'",
						array[i],
						"')\"></div>"
					}));
                }
                else if (array[i] == string.Empty)
                {
                    stringBuilder.Append("<div id='Null' style='float:left; width:15px; height:15px; margin-right:2px; cursor:pointer;' onclick=\"colorPicker(this,'" + array[i] + "')\" title='无'></div>");
                }
                else
                {
                    stringBuilder.Append(string.Concat(new string[]
					{
						"<div style='float:left; width:15px; height:15px; margin:0 2px; cursor:pointer; background:",
						array[i],
						"' onclick=\"colorPicker(this,'",
						array[i],
						"')\"></div>"
					}));
                }
            }
            stringBuilder.Append("<input id='Binded' name='ColorPicker' type='hidden' value='" + visual + "' />");
            return stringBuilder.ToString();
        }
    }

    public class DropDown
    {
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
    }

    public class Language
    {
        public static void InitLanguage()
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies["MojoCube_Language"];
            string text = "";
            if (httpCookie == null)
            {
                Language language = new Language();
                DataTable dataTable = language.LanguageDT(HttpContext.Current.Server.MapPath("~/App_LocalResources/config.xml"));
                if (dataTable.Rows.Count > 0)
                {
                    text = dataTable.Rows[0]["name"].ToString();
                    language.ChangeLanguage(text);
                }
            }
            else
            {
                text = httpCookie.Value;
            }
            CultureInfo currentUICulture = new CultureInfo(text);
            System.Threading.Thread.CurrentThread.CurrentUICulture = currentUICulture;
        }

        public static string GetLanguage()
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies["MojoCube_Language"];
            string text = "";
            if (httpCookie == null)
            {
                Language language = new Language();
                DataTable dataTable = language.LanguageDT(HttpContext.Current.Server.MapPath("~/App_LocalResources/config.xml"));
                if (dataTable.Rows.Count > 0)
                {
                    text = dataTable.Rows[0]["name"].ToString();
                    language.ChangeLanguage(text);
                }
            }
            else
            {
                text = httpCookie.Value;
            }
            return text;
        }

        public void ChangeLanguage(string language)
        {
            HttpContext.Current.Response.Cookies["MojoCube_Language"].Value = language;
            HttpContext.Current.Response.Cookies["MojoCube_Language"].Expires = DateTime.Now.AddYears(1);
            CultureInfo currentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = currentUICulture;
        }

        public DataTable LanguageDT(string url)
        {
            DataTable result;
            try
            {
                DataTable dataTable = new DataTable();
                DataColumn column = new DataColumn("name", typeof(string));
                DataColumn column2 = new DataColumn("icon", typeof(string));
                DataColumn column3 = new DataColumn("title", typeof(string));
                dataTable.Columns.Add(column);
                dataTable.Columns.Add(column2);
                dataTable.Columns.Add(column3);
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(responseStream);
                XmlElement documentElement = xmlDocument.DocumentElement;
                XmlNodeList elementsByTagName = documentElement.GetElementsByTagName("language");
                foreach (XmlNode xmlNode in elementsByTagName)
                {
                    DataRow dataRow = dataTable.NewRow();
                    XmlNodeList elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("name");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["name"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["name"] = "";
                    }
                    elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("icon");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["icon"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["icon"] = "";
                    }
                    elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("title");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["title"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["title"] = "";
                    }
                    dataTable.Rows.Add(dataRow);
                }
                result = dataTable;
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }

    public class MyPage : Page
    {
        private PageStatePersister _pers;

        protected override PageStatePersister PageStatePersister
        {
            get
            {
                if (this._pers == null)
                {
                    this._pers = new SessionPageStatePersister(this);
                }
                return this._pers;
            }
        }
    }

    public class Script
    {
        public static void RunScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>" + script + "</script>");
        }

        public static void ScriptMessage(Page page, string text)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>alert('" + text + "');</script>");
        }

        public static void ShowAlert(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowAlert('" + msg + "');</script>");
        }

        public static void ShowError(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowError('" + msg + "');</script>");
        }

        public static void ShowWarning(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), "<script language = 'javascript'>ShowWarning('" + msg + "');</script>");
        }

        public static void ButtonClickDisabled(Button button, Page page, string text)
        {
            button.Attributes["onclick"] = page.GetPostBackEventReference(button) + ";this.disabled=true;this.value='" + text + "';";
        }

        public static void ButtonClickDisabled(LinkButton button, Page page, string text)
        {
            button.Attributes["onclick"] = page.GetPostBackEventReference(button) + ";this.disabled=true;this.innerText='" + text + "';";
        }

        public static string OpenFCKWin(string url)
        {
            return "javascript:var win=window.open('" + url + "','InsertImages','width=600,height=400,toolbar=0,location=0,directories=0,status=0,menuBar=0,scrollBars=yes,resizable=1');win.focus();";
        }
    }

    public class WebPage : Page
    {
        private PageStatePersister _pers;

        protected override PageStatePersister PageStatePersister
        {
            get
            {
                if (this._pers == null)
                {
                    this._pers = new SessionPageStatePersister(this);
                }
                return this._pers;
            }
        }
    }

    public class WebPager
    {
        private AspNetPager _Pager;

        private int _PageSize;

        private string _ConnStr;

        private int _CurrentPageIndex;

        private string _TableName;

        private string _strGetFields;

        private string _fldName;

        private string _where;

        private bool _OrderType;

        private string _Language;

        private ArrayList _parameter;

        public bool ShowCustomInfo = true;

        public int PageSize
        {
            get
            {
                return this._PageSize;
            }
            set
            {
                this._PageSize = value;
            }
        }

        public string ConnStr
        {
            get
            {
                return this._ConnStr;
            }
            set
            {
                this._ConnStr = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return this._CurrentPageIndex;
            }
            set
            {
                this._CurrentPageIndex = value;
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

        public string strGetFields
        {
            get
            {
                return this._strGetFields;
            }
            set
            {
                this._strGetFields = value;
            }
        }

        public string fldName
        {
            get
            {
                return this._fldName;
            }
            set
            {
                this._fldName = value;
            }
        }

        public string where
        {
            get
            {
                return this._where;
            }
            set
            {
                this._where = value;
            }
        }

        public bool OrderType
        {
            get
            {
                return this._OrderType;
            }
            set
            {
                this._OrderType = value;
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

        public ArrayList parameter
        {
            get
            {
                return this._parameter;
            }
            set
            {
                this._parameter = value;
            }
        }

        public WebPager(AspNetPager Pager)
        {
            this._Pager = Pager;
            this._Pager.SubmitButtonText = "GO";
            this._Pager.CustomInfoClass = "CustomInfo";
            this._Pager.CssClass = "Pager";
            this._Pager.SubmitButtonClass = "PagerBtn";
            this._Pager.CurrentPageButtonClass = "CurrentPage";
            this._Pager.ShowCustomInfoSection = ShowCustomInfoSection.Left;
            this._Pager.AlwaysShow = true;
            this._Pager.UrlPaging = true;
            string text = RegexClass.ChkInt(HttpContext.Current.Request.QueryString["page"]);
            if (text != "0")
            {
                this._CurrentPageIndex = System.Convert.ToInt32(text);
            }
            else
            {
                this._CurrentPageIndex = this._Pager.CurrentPageIndex;
            }
            if (this._where == null)
            {
                this._where = "";
            }
        }

        public DataTable GetTable()
        {
            this.SetPagerInfo();
            DataTable dataTable = new DataTable();
            if (this._CurrentPageIndex <= this._Pager.PageCount)
            {
                int num = this._PageSize;
                if (this._CurrentPageIndex == this._Pager.PageCount)
                {
                    int num2 = this._PageSize - this._CurrentPageIndex * this._PageSize + this._Pager.RecordCount;
                    if (num2 > 0)
                    {
                        num = num2;
                    }
                }
                OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
                string sql = string.Empty;
                string arg = string.Empty;
                string arg2 = string.Empty;
                if (this.OrderType)
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" desc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" asc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" desc"
					}), arg2);
                }
                else
                {
                    arg = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ",
						this._TableName,
						this._where,
						" order by ",
						this.fldName,
						" asc"
					}), this._CurrentPageIndex * this._PageSize);
                    arg2 = string.Format(string.Concat(new string[]
					{
						"select top {0} ",
						this.strGetFields,
						" from ({1}) order by ",
						this.fldName,
						" desc"
					}), num, arg);
                    sql = string.Format(string.Concat(new string[]
					{
						"select ",
						this.strGetFields,
						" from ({0}) order by ",
						this.fldName,
						" asc"
					}), arg2);
                }
                IDataReader dataReader;
                if (this._where != null && this._where != "")
                {
                    dataReader = oledbHelper.ExecuteReader(sql, (string[])this.parameter.ToArray(typeof(string)));
                }
                else
                {
                    dataReader = oledbHelper.ExecuteReader(sql, new object[0]);
                }
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        public int GetRecordCount()
        {
            OledbHelper oledbHelper = new OledbHelper(this.ConnStr);
            string sql = string.Empty;
            sql = string.Concat(new string[]
			{
				"select count(",
				this.strGetFields,
				") as [Counter] from ",
				this._TableName,
				this._where
			});
            int result;
            if (this._where != null && this._where != "")
            {
                result = oledbHelper.ExecuteScalar<int>(sql, (string[])this.parameter.ToArray(typeof(string)));
            }
            else
            {
                result = oledbHelper.ExecuteScalar<int>(sql, new object[0]);
            }
            return result;
        }

        public void SetPagerInfo()
        {
            this._Pager.RecordCount = this.GetRecordCount();
            this._Pager.PageSize = this._PageSize;
            if (this._Language == "zh-cn")
            {
                this._Pager.FirstPageText = "<span class=btnLink title='首页'>首页</span>";
                this._Pager.LastPageText = "<span class=btnLink title='尾页'>尾页</span>";
                this._Pager.NextPageText = "<span class=btnLink title='下一页'>下一页</span>";
                this._Pager.NumericButtonTextFormatString = "<span class=Pager>{0}</span>";
                this._Pager.PrevPageText = "<span class=btnLink title='上一页'>上一页</span>";
                if (this.ShowCustomInfo)
                {
                    this._Pager.CustomInfoHTML = string.Concat(new object[]
					{
						"<div class='cleft'>共<span>",
						this._Pager.RecordCount,
						"</span>条 | 每页<span>",
						this._Pager.PageSize,
						"</span>条 | 共<span>",
						this._Pager.PageCount,
						"</span>页</div>"
					});
                }
            }
            else if (this._Language == "zh-tw")
            {
                this._Pager.FirstPageText = "<span class=btnLink title='首頁'>首頁</span>";
                this._Pager.LastPageText = "<span class=btnLink title='尾頁'>尾頁</span>";
                this._Pager.NextPageText = "<span class=btnLink title='下一頁'>下一頁</span>";
                this._Pager.NumericButtonTextFormatString = "<span class=Pager>{0}</span>";
                this._Pager.PrevPageText = "<span class=btnLink title='上一頁'>上一頁</span>";
                if (this.ShowCustomInfo)
                {
                    this._Pager.CustomInfoHTML = string.Concat(new object[]
					{
						"<div class='cleft'>共<span>",
						this._Pager.RecordCount,
						"</span>條 | 每頁<span>",
						this._Pager.PageSize,
						"</span>條 | 共<span>",
						this._Pager.PageCount,
						"</span>頁</div>"
					});
                }
            }
            else
            {
                this._Pager.FirstPageText = "<span class=btnLink title='First'>First</span>";
                this._Pager.LastPageText = "<span class=btnLink title='Last'>Last</span>";
                this._Pager.NextPageText = "<span class=btnLink title='Next'>Next</span>";
                this._Pager.NumericButtonTextFormatString = "<span class=Pager>{0}</span>";
                this._Pager.PrevPageText = "<span class=btnLink title='Prev'>Prev</span>";
                if (this.ShowCustomInfo)
                {
                    this._Pager.CustomInfoHTML = string.Concat(new object[]
					{
						" Record Count:<span>",
						this._Pager.RecordCount,
						"</span> / Page Size:<span>",
						this._Pager.PageSize,
						"</span> / Page Count:<span>",
						this._Pager.PageCount,
						"</span>"
					});
                }
            }
        }
    }
}


