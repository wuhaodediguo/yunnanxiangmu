using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Sys;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.system
{
    public partial class Admin_System_Type : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlAdd.NavigateUrl = "TypeEdit.aspx?active=" + base.Request.QueryString["active"];
                this.GridBind();
                base.Title = "类型列表";
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
            dataSource = oledbHelper.GetDataTable("select * from Sys_TypeID where TypeName_CHS like '%'+?+'%' order by TableName asc,ID asc", new object[]
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
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "TypeEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];
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
            TypeID typeID = new TypeID();
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "_delete")
            {
                typeID.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            this.GridBind();
        }
    }
}