using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Role;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Role
{
    public partial class Admin_Role_NameEdit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlBack.NavigateUrl = "Name.aspx?active=" + base.Request.QueryString["active"];
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["pk_Name"] = Security.DecryptString(base.Request.QueryString["id"]);
                    Name name = new Name();
                    name.GetData(int.Parse(this.ViewState["pk_Name"].ToString()));
                    this.txtName.Text = name.RoleName_CHS;
                    this.txtPowerValue.Text = name.PowerValue.ToString();
                    base.Title = "角色编辑：" + this.txtName.Text.Trim();
                    return;
                }
                base.Title = "角色编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            Name name = new Name();
            if (this.ViewState["pk_Name"] != null)
            {
                name.GetData(int.Parse(this.ViewState["pk_Name"].ToString()));
                name.RoleName_CHS = this.txtName.Text.Trim();
                name.PowerValue = MojoCube.Web.String.ToInt(this.txtPowerValue.Text.Trim());
                name.UpdateData(name.pk_Name);
            }
            else
            {
                name.RoleName_CHS = this.txtName.Text.Trim();
                name.RoleName_CHT = string.Empty;
                name.RoleName_EN = string.Empty;
                name.PowerValue = MojoCube.Web.String.ToInt(this.txtPowerValue.Text.Trim());
                name.fk_Company = 0;
                name.InsertData();
            }
            base.Response.Redirect("Name.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Name.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}