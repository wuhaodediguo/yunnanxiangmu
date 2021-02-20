using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Sys;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.system
{
    public partial class Admin_System_Menu : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlAdd.NavigateUrl = "MenuEdit.aspx?active=" + base.Request.QueryString["active"];
                this.GridBind(null);
                base.Title = "菜单列表";
            }
        }

        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            string str = CheckSql.Filter(this.txtKeyword.Text.Trim());
            this.GridBind("Name_CHS like '%" + str + "%'");
        }

        private void GridBind(string where)
        {
            new Sql
            {
                TableName = "Sys_Menu",
                OrderByKey = "SortID",
                OrderByType = "asc,pk_Menu asc",
                Where = where,
                pk_ID = "pk_Menu",
                ParentID = "ParentID"
            }.TreeGridBind(this.GridView1);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str = Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "MenuEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];
                if (((Label)e.Row.FindControl("lblParentID")).Text == "0")
                {
                    e.Row.CssClass = "parent";
                    ((HyperLink)e.Row.FindControl("gvAdd")).Visible = true;
                    ((HyperLink)e.Row.FindControl("gvAdd")).NavigateUrl = "MenuEdit.aspx?parentId=" + str + "&active=" + base.Request.QueryString["active"];
                }
                ((Label)e.Row.FindControl("lblType")).Text = TypeID.GetTypeName("Sys_Menu", ((Label)e.Row.FindControl("lblType")).Text, "CHS");
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
            MojoCube.Web.Sys.Menu menu = new MojoCube.Web.Sys.Menu();
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "_delete")
            {
                menu.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            if (e.CommandName == "_up")
            {
                Sql.SetSortID("Sys_Menu", "pk_Menu", ((Label)this.GridView1.Rows[index].FindControl("lblID")).Text, -1);
            }
            if (e.CommandName == "_down")
            {
                Sql.SetSortID("Sys_Menu", "pk_Menu", ((Label)this.GridView1.Rows[index].FindControl("lblID")).Text, 1);
            }
            this.GridBind(null);
        }
    }
}