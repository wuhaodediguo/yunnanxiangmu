using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MojoCube.Api.UI;
using System.Web.SessionState;
using MojoCube.Web;
using System.Text;
using System.Collections;
using MojoCube.Api.Text;
using System.IO;
using System.Reflection;

namespace CopyMFRubikCubePowerContent.Admin.SurfaceSingle
{
    public partial class SurfaceSingleManager : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string pk_menu = base.Request.QueryString["active"].Split(',')[1];
                MojoCube.Web.Role.List roleList = new MojoCube.Web.Role.List();
                roleList.GetData(Convert.ToInt32(base.Session["RoleValue"].ToString()), Convert.ToInt32(pk_menu));
                if (!roleList.IsAdmin)
                {
                    this.Button2.Visible = false;
                    this.btnDelete.Visible = false;
                    this.GridView1.Columns[7].Visible = false;
                    this.GridView1.Columns[8].Visible = false;
                }
                this.ViewState["OrderByKey"] = "CreateDate";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                base.Title = "面单管理";
            }
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
            MojoCube.Web.ReturnMoney.ReturnMoney returnMoneySum = new MojoCube.Web.ReturnMoney.ReturnMoney();
            AdminPager adminPager = new AdminPager(this.ListPager);
            if (!string.IsNullOrEmpty(type))
                adminPager.PageSize = MojoCube.Web.String.PageSize(type);
            else
                adminPager.PageSize = MojoCube.Web.String.PageSize();

            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = @" SurfaceSingle ";
            adminPager.strGetFields = "*";
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            ArrayList arrayList = new ArrayList();
            if (this.txtNo.Text.Trim() != "")
            {
                where.Append(" and ? between StartNo and EndNo");
                arrayList.Add(CheckSql.Filter(this.txtNo.Text.Trim()));
            }

            if (this.txtCustomer.Text.Trim() != "")
            {
                where.Append(" and Customer like '%' +?+'%' ");
                arrayList.Add(CheckSql.Filter(this.txtCustomer.Text.Trim()));
            }

            if (!string.IsNullOrEmpty(this.txtDateFrom.Text.ToString().Trim()))
            {
                where.Append(" and  CDate(CreateDate) >= CDate('" + this.txtDateFrom.Text.Trim() + "') ");
                //arrayList.Add(CheckSql.Filter(this.txtStartDate.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(this.txtDateEnd.Text.ToString().Trim()))
            {
                where.Append(" and CDate(CreateDate) <= CDate('" + this.txtDateEnd.Text + "') ");
                //arrayList.Add(CheckSql.Filter(this.txtEndDate.Text.Trim()));
            }

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable();
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
                string str = Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "SurfaceSingleMaintain.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];
            }


            string[] controlList = new string[]
            {
                "gvDelete"
            };
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MojoCube.Web.SurfaceSingle.SurfaceSingle SurfaceSingle = new MojoCube.Web.SurfaceSingle.SurfaceSingle();

            if (e.CommandName == "_delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                SurfaceSingle.DeleteDataById(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
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
            MojoCube.Web.SurfaceSingle.SurfaceSingle SurfaceSingle = new MojoCube.Web.SurfaceSingle.SurfaceSingle();
            foreach (GridViewRow r in GridView1.Rows)
            {
                if (((CheckBox)r.FindControl("uxDeleteCheckBox")).Checked)
                {
                    SurfaceSingle.DeleteDataById(int.Parse(((Label)r.FindControl("lblID")).Text));
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