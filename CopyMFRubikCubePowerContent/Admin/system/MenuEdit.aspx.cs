using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Sys;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace CopyMFRubikCubePowerContent.Admin.system
{
    public partial class Admin_System_MenuEdit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlBack.NavigateUrl = "Menu.aspx?active=" + base.Request.QueryString["active"];
                Sql.DropDownListBind(this.ddlType, "Sys_TypeID", "TypeName_CHS", "ID", "TableName='Sys_Menu'", "ID", "asc");
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["pk_Menu"] = Security.DecryptString(base.Request.QueryString["id"]);
                    MojoCube.Web.Sys.Menu menu = new MojoCube.Web.Sys.Menu();
                    menu.GetData(int.Parse(this.ViewState["pk_Menu"].ToString()));
                    this.txtName.Text = menu.Name_CHS;
                    this.txtIcon.Text = menu.Icon;
                    this.txtUrl.Text = menu.Url;
                    this.txtSortID.Text = menu.SortID.ToString();
                    this.cbVisible.Checked = menu.Visible;
                    this.txtTag.Text = menu.Tag_CHS;
                    Sql.ddlFindByValue(this.ddlType, menu.TypeID.ToString());
                    base.Title = "菜单编辑：" + this.txtName.Text.Trim();
                    return;
                }
                this.txtIcon.Text = "fa-circle-o";
                this.cbVisible.Checked = true;
                base.Title = "菜单编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            MojoCube.Web.Sys.Menu menu = new MojoCube.Web.Sys.Menu();
            if (this.ViewState["pk_Menu"] != null)
            {
                menu.GetData(int.Parse(this.ViewState["pk_Menu"].ToString()));
                menu.Name_CHS = this.txtName.Text.Trim();
                menu.Url = this.txtUrl.Text.Trim();
                menu.Icon = this.txtIcon.Text.Trim();
                menu.SortID = MojoCube.Web.String.ToInt(this.txtSortID.Text.Trim());
                menu.TypeID = int.Parse(this.ddlType.SelectedValue);
                menu.Visible = this.cbVisible.Checked;
                menu.Tag_CHS = this.txtTag.Text.Trim();
                menu.UpdateData(menu.pk_Menu);
            }
            else
            {
                if (base.Request.QueryString["parentId"] != null)
                {
                    menu.ParentID = int.Parse(Security.DecryptString(base.Request.QueryString["parentId"]));
                }
                else
                {
                    menu.ParentID = 0;
                }
                menu.Name_CHS = this.txtName.Text.Trim();
                menu.Name_CHT = string.Empty;
                menu.Name_EN = string.Empty;
                menu.Url = this.txtUrl.Text.Trim();
                menu.Icon = this.txtIcon.Text.Trim();
                menu.SortID = MojoCube.Web.String.ToInt(this.txtSortID.Text.Trim());
                menu.LevelID = 0;
                menu.TypeID = int.Parse(this.ddlType.SelectedValue);
                menu.Visible = this.cbVisible.Checked;
                menu.Tag_CHS = this.txtTag.Text.Trim();
                menu.Tag_CHT = string.Empty;
                menu.Tag_EN = string.Empty;
                menu.InsertData();
            }
            base.Response.Redirect("Menu.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Menu.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}