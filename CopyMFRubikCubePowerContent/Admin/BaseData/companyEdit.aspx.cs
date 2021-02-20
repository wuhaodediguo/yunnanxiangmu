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
    public partial class companyEdit : MyPage, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
      
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();
                    minzuList minzuList = new minzuList();
                    minzuList.GetData(int.Parse(this.ViewState["ID"].ToString()));

                    txtpinming.Text = minzuList.guige;

                    div01.Visible = true;

                    //return;
                }
                //this.hlAdd.NavigateUrl = "yewustyleEdit.aspx?active=" + base.Request.QueryString["active"];
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
            minzuList minzuList = new minzuList();

            minzuList.guige = txtpinming.Text;


            if (this.ViewState["ID"] != null)
            {
                minzuList.ID = int.Parse(this.ViewState["ID"].ToString());
                if (minzuList.UpdateData() > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    //清空文本框
                    div01.Visible = false;

                    base.Response.Redirect("companyEdit.aspx?active=" + base.Request.QueryString["active"]);
                }
                
            }
            else
            {

                if (minzuList.InsertData() > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    //清空文本框
                    div01.Visible = false;

                    base.Response.Redirect("companyEdit.aspx?active=" + base.Request.QueryString["active"]);
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                }
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
            //AdminPager adminPager = new AdminPager(this.ListPager);
            //if (!string.IsNullOrEmpty(type))
            //    adminPager.PageSize = MojoCube.Web.String.PageSize(type);
            //else
            //    adminPager.PageSize = MojoCube.Web.String.PageSize();

            //adminPager.ConnStr = Connection.ConnString();
            //adminPager.TableName = "tb_yewustyle";
            //adminPager.strGetFields = "*";
            //StringBuilder where = new StringBuilder();
            //where.Append(" where 1=1 ");
            //ArrayList arrayList = new ArrayList();


            //adminPager.where = where.ToString();
            //adminPager.parameter = arrayList;
            //adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            //adminPager.OrderType = (bool)this.ViewState["OrderByType"];

            DataTable dataSource = new DataTable();

            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            sql = @"select * from minzu where 1=1 order by ID asc ";
            dataSource = oledbHelper.GetDataTable(sql);
            this.GridView1.DataSource = dataSource;
            this.GridView1.DataBind();

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

                string str = ((Label)e.Row.FindControl("lblID")).Text.Trim();
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "companyEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];

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
            minzuList minzuList = new minzuList();

            if (e.CommandName == "_delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                minzuList.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
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
            minzuList minzuList = new minzuList();

            foreach (GridViewRow r in GridView1.Rows)
            {
                if (((CheckBox)r.FindControl("uxDeleteCheckBox")).Checked)
                {
                    minzuList.DeleteData(int.Parse(((Label)r.FindControl("lblID")).Text.Trim()));
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