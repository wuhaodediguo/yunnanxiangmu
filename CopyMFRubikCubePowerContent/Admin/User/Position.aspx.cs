using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_Position : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlAdd.NavigateUrl = "PositionEdit.aspx?active=" + base.Request.QueryString["active"];
                this.GridBind();
                base.Title = "职位列表";
            }
        }

        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from User_Position where Title like '%'+?+'%' order by LevelID asc", new object[]
		{
			this.txtKeyword.Text.Trim()
		});
            this.GridView1.DataSource = dataSource;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str = Security.EncryptString(((Label)e.Row.FindControl("lblID")).Text);
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "PositionEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];
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
            Position position = new Position();
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "_delete")
            {
                position.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            this.GridBind();
        }
    }
}