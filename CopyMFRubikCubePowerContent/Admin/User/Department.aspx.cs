using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_Department : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlAdd.NavigateUrl = "DepartmentEdit.aspx?active=" + base.Request.QueryString["active"];
                this.GridBind(null);
                base.Title = "部门列表";
            }
        }

        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            string str = CheckSql.Filter(this.txtKeyword.Text.Trim());
            this.GridBind("DepartmentName like '%" + str + "%'");
        }

        private void GridBind(string where)
        {
            new Sql
            {
                TableName = "User_Department",
                OrderByKey = "SortID",
                OrderByType = "asc,pk_Department asc",
                Where = where,
                pk_ID = "pk_Department",
                ParentID = "ParentID"
            }.TreeGridBind(this.GridView1);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str = Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "DepartmentEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];
                if (((Label)e.Row.FindControl("lblParentID")).Text == "0")
                {
                    e.Row.CssClass = "parent";
                    ((HyperLink)e.Row.FindControl("gvAdd")).Visible = true;
                    ((HyperLink)e.Row.FindControl("gvAdd")).NavigateUrl = "DepartmentEdit.aspx?parentId=" + str + "&active=" + base.Request.QueryString["active"];
                }
                MojoCube.Web.String.ShowDel(e);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string[] controlList = new string[]
		{
			"gvUp",
			"gvDown",
			"gvDelete"
		};
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Department department = new Department();
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "_delete")
            {
                department.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            if (e.CommandName == "_up")
            {
                Sql.SetSortID("User_Department", "pk_Department", ((Label)this.GridView1.Rows[index].FindControl("lblID")).Text, -1);
            }
            if (e.CommandName == "_down")
            {
                Sql.SetSortID("User_Department", "pk_Department", ((Label)this.GridView1.Rows[index].FindControl("lblID")).Text, 1);
            }
            this.GridBind(null);
        }
    }
}