using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Sys;
using MojoCube.Web.User;
using System;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_Online : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ViewState["OrderByKey"] = "pk_Online";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                base.Title = "在线用户";
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
            adminPager.TableName = "View_User_Online";
            adminPager.strGetFields = "*";
            string where = "";
            ArrayList arrayList = new ArrayList();
            if (this.txtKeyword.Text.Trim() != "")
            {
                string value = CheckSql.Filter(this.txtKeyword.Text.Trim());
                where = " where (UserName like '%'+?+'%' or FullName like '%'+?+'%' or DepartmentName like '%'+?+'%' or IPAddress like '%'+?+'%')";
                arrayList.Add(value);
                arrayList.Add(value);
                arrayList.Add(value);
                arrayList.Add(value);
            }
            adminPager.where = where;
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
                ((Label)e.Row.FindControl("lblType")).Text = TypeID.GetTypeName("User_Online", ((Label)e.Row.FindControl("lblType")).Text, "CHS");
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
            Online online = new Online();
            if (e.CommandName == "_delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                online.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            this.GridBind();
        }
    }
}