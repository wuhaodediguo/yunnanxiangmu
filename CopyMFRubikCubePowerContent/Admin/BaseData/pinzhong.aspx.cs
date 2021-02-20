using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.CurrentExpenses;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections;
using System.Linq;

namespace CopyMFRubikCubePowerContent.Admin.BaseData
{
    public partial class pinzhong : MyPage, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                //string pk_menu = base.Request.QueryString["active"].Split(',')[1];
                //MojoCube.Web.Role.List roleList = new MojoCube.Web.Role.List();
                //roleList.GetData(Convert.ToInt32(base.Session["RoleValue"].ToString()), Convert.ToInt32(pk_menu));
                //if (!roleList.IsAdmin)
                //{
                //    this.Button2.Visible = false;
                //    this.btnDelete.Visible = false;
                //    this.GridView1.Columns[7].Visible = false;
                //    this.GridView1.Columns[8].Visible = false;
                //}
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();
                    pinzhongList pinzhongList = new pinzhongList();
                    pinzhongList.GetData(int.Parse(this.ViewState["ID"].ToString()));

                    txtpinming.Text = pinzhongList.pinzhong;
  
                    div01.Visible = true;


                    //return;
                }
                //this.hlAdd.NavigateUrl = "pinzhongEdit.aspx?active=" + base.Request.QueryString["active"];
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
         
                this.GridBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpinming.Text))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "不能为空，请正确填写");
                return;
            }
            pinzhongList pinzhongList = new pinzhongList();
            pinzhongList.pinzhong = txtpinming.Text;
            pinzhongList.remark = "";

            if (this.ViewState["ID"] != null)
            {
                pinzhongList.ID = int.Parse(this.ViewState["ID"].ToString());
                if (pinzhongList.UpdateData() > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    //清空文本框
                    div01.Visible = false;
                  
                    base.Response.Redirect("pinzhong.aspx?active=" + base.Request.QueryString["active"]);
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                }
            }
            else
            {

                if (pinzhongList.InsertData() > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    //清空文本框
                    div01.Visible = false;
                
                    base.Response.Redirect("pinzhong.aspx?active=" + base.Request.QueryString["active"]);
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                }
            }
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                if (dataSource.Rows[31]["col2"].ToString() == "1" && dataSource.Rows[31]["col1"].ToString() == "div0071")
                {
                    dd0071.Visible = true;
                }
                else
                {
                    dd0071.Visible = false;
                }
                if (dataSource.Rows[32]["col2"].ToString() == "1" && dataSource.Rows[32]["col1"].ToString() == "div0072")
                {
                    dd0072.Visible = true;
                }
                else
                {
                    dd0072.Visible = false;
                }
                if (dataSource.Rows[33]["col2"].ToString() == "1" && dataSource.Rows[33]["col1"].ToString() == "div0073")
                {
                    dd0073.Visible = true;
                }
                else
                {
                    dd0073.Visible = false;
                }
                if (dataSource.Rows[34]["col2"].ToString() == "1" && dataSource.Rows[34]["col1"].ToString() == "div0074")
                {
                    dd0074.Visible = true;
                }
                else
                {
                    dd0074.Visible = false;
                }
                if (dataSource.Rows[35]["col2"].ToString() == "1" && dataSource.Rows[35]["col1"].ToString() == "div0075")
                {
                    dd0075.Visible = true;
                }
                else
                {
                    dd0075.Visible = false;
                }
                if (dataSource.Rows[36]["col2"].ToString() == "1" && dataSource.Rows[36]["col1"].ToString() == "div0076")
                {
                    dd0076.Visible = true;
                }
                else
                {
                    dd0076.Visible = false;
                }
                if (dataSource.Rows[37]["col2"].ToString() == "1" && dataSource.Rows[37]["col1"].ToString() == "div0077")
                {
                    dd0077.Visible = true;
                }
                else
                {
                    dd0077.Visible = false;
                }

            }
            else
            {
                div0071.Visible = false;
                div0072.Visible = false;
                div0073.Visible = false;
                div0074.Visible = false;
                div0075.Visible = false;
                div0076.Visible = false;
                div0077.Visible = false;
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            div01.Visible = true;
        
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";

        }
        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            string str = dt.ToString("yyyyMMddhhmmss");
            str = str + ".xls";
            GridBind("download");
            DownloadHtmlExcelFile(GridView1, str, null);
        }

        private void GridBind(string type = null)
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            if (!string.IsNullOrEmpty(type))
                adminPager.PageSize = MojoCube.Web.String.PageSize(type);
            else
                adminPager.PageSize = MojoCube.Web.String.PageSize();

            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "tb_pinzhong";
            adminPager.strGetFields = "*";
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            ArrayList arrayList = new ArrayList();


            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];

            this.GridView1.DataSource = adminPager.GetTable();
            this.GridView1.DataBind();

            //DataTable dataSource = new DataTable();

            //OledbHelper oledbHelper = new OledbHelper();
            //string sql = string.Empty;
            //sql = @"select * from tb_guige where 1=1 order by ID asc ";
            //dataSource = oledbHelper.GetDataTable(sql);
            //this.GridView1.DataSource = dataSource;
            //this.GridView1.DataBind();

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            if (this.ViewState["OrderByKey"].ToString() == sortExpression)
            {
                if ((bool)this.ViewState["OrderByType"])
                {
                    this.ViewState["OrderByType"] = false;
                }
                else
                {
                    this.ViewState["OrderByType"] = true;
                }
            }
            else
            {
                this.ViewState["OrderByKey"] = e.SortExpression;
            }
            this.GridBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (((Label)e.Row.FindControl("lblColumn2")).Text.Trim() == "1")
                //{
                //    ((Label)e.Row.FindControl("lblColumn2")).Text = "销售使用";
                //}
                //else if (((Label)e.Row.FindControl("lblColumn2")).Text.Trim() == "2")
                //{
                //    ((Label)e.Row.FindControl("lblColumn2")).Text = "收购使用";
                //}
                //else if (((Label)e.Row.FindControl("lblColumn2")).Text.Trim() == "3")
                //{
                //    ((Label)e.Row.FindControl("lblColumn2")).Text = "不使用";
                //}

                //string str = ((Label)e.Row.FindControl("lblID")).Text.Trim();
                //((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "LogisticsEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];


                string str = ((Label)e.Row.FindControl("lblID")).Text.Trim();
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "pinzhong.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];

                MojoCube.Web.String.ShowDel(e);
            }

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string[] controlList = new string[]
        {
            "gvDelete"
        };
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            pinzhongList pinzhongList = new pinzhongList();

            if (e.CommandName == "_delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                
                pinzhongList.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            this.GridBind();
        }

        public static void DownloadHtmlExcelFile(GridView dataGrid, string filename, params int[] nonTextFormatColumns)
        {
            HttpResponse httpResponse = HttpContext.Current.Response;
            // Sets content type to Excel.
            httpResponse.Clear();
            //httpResponse.ContentType = "application/vnd.ms-excel"
            httpResponse.ContentType = "application/octet-stream";
            httpResponse.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlPathEncode(filename));

            // Disables the view state.
            // Me.EnableViewState = False

            // Clears controls within DataGrid.
            ClearControls(dataGrid);

            // Sets columns to text format
            bool textFormat = nonTextFormatColumns == null || nonTextFormatColumns.Length == 0 || Array.IndexOf(nonTextFormatColumns, -1) != -1;
            bool noTextFormat = dataGrid.Columns.Count == (nonTextFormatColumns != null ? nonTextFormatColumns.Length : 0);
            if (!noTextFormat)
                for (int row = 0; row <= dataGrid.Rows.Count - 1; row++)
                    for (int col = 0; col <= dataGrid.Rows[row].Cells.Count - 1; col++)
                        if (textFormat || Array.IndexOf(nonTextFormatColumns, col) == -1)
                            dataGrid.Rows[row].Cells[col].Attributes.Add("class", "text");

            // Outputs BOM for unicode files and enables Excel correctly parsing file content
            using (StreamWriter sw = new StreamWriter(httpResponse.OutputStream, Encoding.UTF8))
            {
                // Outputs CSS
                sw.Write("<style>.text {mso-number-format:\"\\@\";}</style>");
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                dataGrid.RenderControl(htw);
                sw.Flush();
            }

            // Terminates
            httpResponse.End();
        }
        private static void ClearControls(Control sourceControl)
        {
            if (sourceControl == null) return;
            for (int index = sourceControl.Controls.Count - 1; index >= 0; index += -1)
                ClearControls(sourceControl.Controls[index]);
            if (sourceControl is TableCell) return;
            Type sourceControlType = sourceControl.GetType();
            PropertyInfo propertyInfo = sourceControlType.GetProperty("SelectedItem");
            if (propertyInfo == null) propertyInfo = sourceControlType.GetProperty("Text");
            if (propertyInfo == null) return;
            Literal literal = new Literal();
            sourceControl.Parent.Controls.Add(literal);
            try
            {
                literal.Text = Convert.ToString(propertyInfo.GetValue(sourceControl, null));
            }
            catch
            {
                // suppress exception
            }
            sourceControl.Parent.Controls.Remove(sourceControl);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            pinzhongList pinzhongList = new pinzhongList();
            foreach (GridViewRow r in GridView1.Rows)
            {
                if (((CheckBox)r.FindControl("uxDeleteCheckBox")).Checked)
                {
                    pinzhongList.DeleteData(int.Parse(((Label)r.FindControl("lblID")).Text));
                   
                }
            }
            this.GridBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                CheckBox item = ((CheckBox)r.FindControl("uxDeleteCheckBox"));
                if (!item.Checked)
                {
                    item.Checked = true;
                }
            }
        }
   
    }
}