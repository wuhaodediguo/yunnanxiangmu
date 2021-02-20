using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Role;
using MojoCube.Web.Sys;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Role
{
    public partial class Admin_Role_List : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlBack.NavigateUrl = "Name.aspx?active=" + base.Request.QueryString["active"];
                if (base.Request.QueryString["roleId"] != null)
                {
                    this.ViewState["pk_Name"] = Security.DecryptString(base.Request.QueryString["roleId"]);
                    Name name = new Name();
                    name.GetData(int.Parse(this.ViewState["pk_Name"].ToString()));
                    this.Label1.Text = (this.Label2.Text = name.RoleName_CHS);
                    base.Title = "角色管理：" + this.Label1.Text;
                }
                this.GridBind();
            }
        }

        private void GridBind()
        {
            new Sql
            {
                TableName = "Sys_Menu",
                OrderByKey = "SortID",
                OrderByType = "asc,pk_Menu asc",
                Where = null,
                pk_ID = "pk_Menu",
                ParentID = "ParentID"
            }.TreeGridBind(this.GridView1);
            List list = new List();
            int roleId = int.Parse(this.ViewState["pk_Name"].ToString());
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                list.pk_Role = 0;
                int menuId = int.Parse(((Label)this.GridView1.Rows[i].FindControl("lblID")).Text);
                list.GetData(roleId, menuId);
                if (list.pk_Role > 0)
                {
                    if (list.IsUse)
                    {
                        ((CheckBox)this.GridView1.Rows[i].FindControl("cbUse")).Checked = true;
                    }
                    if (list.IsAdmin)
                    {
                        ((CheckBox)this.GridView1.Rows[i].FindControl("cbAdmin")).Checked = true;
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblParentID")).Text == "0")
                {
                    e.Row.CssClass = "parent";
                }
                //((Label)e.Row.FindControl("lblType")).Text = TypeID.GetTypeName("Sys_Menu", ((Label)e.Row.FindControl("lblType")).Text, "CHS");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List list = new List();
            int num = int.Parse(this.ViewState["pk_Name"].ToString());
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                list.pk_Role = 0;
                int num2 = int.Parse(((Label)this.GridView1.Rows[i].FindControl("lblID")).Text);
                list.GetData(num, num2);
                if (list.pk_Role > 0)
                {
                    list.IsUse = ((CheckBox)this.GridView1.Rows[i].FindControl("cbUse")).Checked;
                    list.IsAdmin = ((CheckBox)this.GridView1.Rows[i].FindControl("cbAdmin")).Checked;
                    list.UpdateData(list.pk_Role);
                }
                else
                {
                    list.fk_RoleName = num;
                    list.fk_Menu = num2;
                    list.IsUse = ((CheckBox)this.GridView1.Rows[i].FindControl("cbUse")).Checked;
                    list.IsAdmin = ((CheckBox)this.GridView1.Rows[i].FindControl("cbAdmin")).Checked;
                    list.PowerList = "";
                    list.fk_Company = 0;
                    list.InsertData();
                }
            }
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Name.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}