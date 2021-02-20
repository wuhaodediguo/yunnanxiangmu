using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Data;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_List : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                string pk_menu = base.Request.QueryString["active"].Split(',')[1];
                MojoCube.Web.Role.List roleList = new MojoCube.Web.Role.List();
                roleList.GetData(Convert.ToInt32(base.Session["RoleValue"].ToString()), Convert.ToInt32(pk_menu));
                if (!roleList.IsAdmin)
                {
                    this.GridView1.Columns[6].Visible = false;
                }
                this.hlAdd.NavigateUrl = "Edit.aspx?active=" + base.Request.QueryString["active"];
                this.ViewState["OrderByKey"] = "pk_User";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                base.Title = "用户列表";
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


        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "View_User_List1";
            adminPager.strGetFields = "*";
            if (this.txtKeyword.Text.Trim() != "")
            {
                string value = CheckSql.Filter(this.txtKeyword.Text.Trim());
                string where = " where UserName like '%'+?+'%'";
                ArrayList arrayList = new ArrayList();
                arrayList.Add(value);
                adminPager.where = where;
                adminPager.parameter = arrayList;
            }
            else
            {
                adminPager.where = "";
            }
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
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "Edit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];
                if (((Label)e.Row.FindControl("lblThumbnail")).Text != "")
                {
                    string text = "../Files.aspx?image=" + Security.EncryptString(((Label)e.Row.FindControl("lblThumbnail")).Text);
                    ((Label)e.Row.FindControl("lblThumbnail")).Text = string.Concat(new string[]
				{
					"<a href=\"",
					text,
					"\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"",
					((Label)e.Row.FindControl("lblFullName")).Text,
					"\"><img src=\"",
					text,
					"&cut=50,50\" class=\"img-circle\" style=\"width:25px; height:25px;\" /></a>"
				});
                }
                else
                {
                    ((Label)e.Row.FindControl("lblThumbnail")).Text = "<a href=\"#\"><img src=\"../Images/user.png\" class=\"img-circle\" style=\"width:25px; height:25px;\" /></a>";
                }
                //if (((Label)e.Row.FindControl("lblWages")).Text != "")
                //{
                //    ((Label)e.Row.FindControl("lblWages")).Text = decimal.Parse(((Label)e.Row.FindControl("lblWages")).Text).ToString("F2");
                //}
                MojoCube.Web.String.ShowDel(e);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
            string[] controlList = new string[]
		{
			"gvDelete"
		};
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List list = new List();
            if (e.CommandName == "_delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                list.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            this.GridBind();
        }
    }
}