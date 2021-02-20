using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Text;


namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class BASEQ04 : System.Web.UI.Page
    {
        #region Class Property and Field
        
        public string QueryPurpose
        {
            get
            {
                var queryPurpose = "";

                if (Request.QueryString["QueryPurpose"] != null)
                {
                    queryPurpose = Request.QueryString["QueryPurpose"];
                }

                return queryPurpose;
            }
        }

        public string QueryIdentity
        {
            get
            {
                var queryIdentity = "";

                if (Request.QueryString["QueryIdentity"] != null)
                {
                    queryIdentity = Request.QueryString["QueryIdentity"];
                }

                return queryIdentity;
            }
        }

        /// <summary>
        /// Decide if pre-load data when at the fisrt time
        /// </summary>
        public bool QueryPreload
        {
            get
            {
                var queryPreload = false;

                if (Request.QueryString["QueryPreload"] != null)
                {
                    bool flag;
                    Boolean.TryParse(Request.QueryString["QueryPreload"], out flag);

                    queryPreload = flag;
                }

                return queryPreload;
            }
        }

        public string QueryLimit
        {
            get
            {
                var queryLimit = "";

                if (Request.QueryString["QueryLimit"] != null)
                {
                    queryLimit = Server.UrlDecode(Request.QueryString["QueryLimit"]).ToString();
                }

                return queryLimit;
            }
        }

        public CommonQuery_BLL profile = new CommonQuery_BLL();

        #endregion

        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                profile.SetProfileProperty(this.QueryPurpose, this.QueryIdentity);

                if (!IsPostBack)
                {
                    lblTitle.Text = profile.Title;
                    lblCriteria.Text = profile.Criteria;
                    txtCriteria.ToolTip = profile.CriteriaToolTip;
                    txtCriteria.Attributes.Add("placeholder", profile.CriteriaToolTip);

                    #region 設定 gridview 的一頁筆數大小
                   
                    int _pageSize;
                    _pageSize = 25;
                    gvDataList.PageSize = _pageSize;

                    #endregion

                    #region 是否要預先載入資料

                    if (QueryPreload)
                    {
                        CallQueryMethod();
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        #endregion

        #region Button Event

        /// <summary>
        /// Search Button 執行的事件，會先呼叫 CheckBeforeQuery() 判斷是否要執行查詢
        /// 若未輸入任何搜尋字詞，將 Gridview 結果清空
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckBeforeQuery())
            {
                gvDataList.PageIndex = 0; //重新Search時要把GridView分頁指定回第一頁
                CallQueryMethod();
            }
            else
            {
                
                gvDataList.DataSource = null;
                gvDataList.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClosePopUpWindow();
        }

        #endregion

        #region GridView Event

        /// <summary>
        /// 透過觸發 RowCommand 事件來抓取 GridViewRow 的欄位值，並將欄位值透過 Javascript 語法傳出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDataList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Select":

                        if (((Control)e.CommandSource).Parent.Parent is GridViewRow)
                        {
                            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;

                            string jscript = profile.GetJSscript(row);
                            Response.Write(jscript);

                            ClosePopUpWindow();
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// gvDataList.DataBind() 就會觸發此事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDataList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    // 設定欄位顯示名稱
                    foreach (var o in profile.ColumnText)
                    {
                        e.Row.Cells[o.Key].Text = o.Value;
                        e.Row.Cells[o.Key].HorizontalAlign = HorizontalAlign.Center;
                        //e.Row.Cells[o.Key].Attributes.Add("HeaderStyle-CssClass", "text-center");
                    }
                   

                    // 設定欄位是否顯示，預設本就是 True，False 再隱藏
                    foreach (var o in profile.ColumnVisible)
                    {
                        if (o.Value == false)
                        {
                            e.Row.Cells[o.Key].Visible = o.Value;
                        }
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // 設定欄位值是否顯示，預設本就是 True，False 再隱藏
                    foreach (var o in profile.ColumnVisible)
                    {
                        if (o.Value == false)
                        {
                            e.Row.Cells[o.Key].Visible = o.Value;
                        }
                    }
                    e.Row.Font.Size = 12;
                    //for(int i = 0;i <gvDataList.Rows.Count;i++)
                    //{
                    //    e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    //}
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 基本換頁寫法
        /// </summary>
        protected void gvDataList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDataList.PageIndex = e.NewPageIndex;
            CallQueryMethod();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('YA!');", true);
        }

        #endregion

        #region Other Function

        /// <summary>
        /// Check if txtCriteria.Text is emply or null before execute CallQueryMethod()
        /// </summary>
        /// <returns></returns>
        public bool CheckBeforeQuery()
        {
            bool result;

            if (!string.IsNullOrEmpty(txtCriteria.Text))
            {
                result = true;
            }
            else
            {
                //result = false;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 執行查詢找出資料
        /// </summary>
        public void CallQueryMethod()
        {
            try
            {
                // 如果有傳進 Query 的代號才執行查詢
                if (!string.IsNullOrEmpty(this.QueryPurpose))
                {
                    var sharedQuery = new BASEQ04_SharedQuery();
                    var queryCriteria = HttpUtility.HtmlDecode(txtCriteria.Text.Trim()); // 統一由這邊做 Trim 掉前後空白的動作

                    MethodInfo info = sharedQuery.GetType().GetMethod(profile.QueryMethodName);
                    object result;

                    if (info != null)
                    {
                        int paraCount = info.GetParameters().Length;

                        if (paraCount == 1)
                        {
                            result = info.Invoke(sharedQuery, new object[] { queryCriteria });
                        }
                        else if (paraCount == 2)
                        {
                            result = info.Invoke(sharedQuery, new object[] { queryCriteria, this.QueryLimit });
                        }
                        else
                        {
                            
                            return;
                        }

                        BindData(result);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 將資料繫結到 GridView 上
        /// </summary>
        /// <param name="ObjectType"></param>
        /// <param name="DataList"></param>
        public void BindData(object queryResult)
        {
            try
            {
                var datalist = queryResult;
                var dataCount = 0;

                // 判斷型別取得資料筆數 (目前的資料查詢應只有這兩種型態)
                if (datalist is IList)
                {
                    dataCount = ((IList)datalist).Count;
                }
                if (datalist is DataTable)
                {
                    dataCount = ((DataTable)datalist).Rows.Count;
                }

                //根據資料筆數顯示資訊
                if (dataCount == 0)
                {
                   SetWarningMessage("没有找到数据");

                    gvDataList.DataSource = null;
                    gvDataList.DataBind();
                }
                else
                {
                    SetWarningMessage(dataCount + " 条数据");

                    gvDataList.DataSource = datalist;
                    gvDataList.DataBind();
                }

                txtCriteria.Focus();

            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 關閉視窗
        /// </summary>
        public void ClosePopUpWindow()
        {
            //string jscript = @"<script> window.close(); </script>";
            string jscript = @"<script> window.open(location, '_self').close(); </script>";
            
            Response.Write(jscript);
        }

        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("warning", message);
            return;
        }


        #endregion
    }

}