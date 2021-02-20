using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_PositionEdit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlBack.NavigateUrl = "Position.aspx?active=" + base.Request.QueryString["active"];
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["pk_Position"] = Security.DecryptString(base.Request.QueryString["id"]);
                    Position position = new Position();
                    position.GetData(int.Parse(this.ViewState["pk_Position"].ToString()));
                    this.txtName.Text = position.Title;
                    this.txtLevelID.Text = position.LevelID.ToString();
                    base.Title = "职位编辑：" + this.txtName.Text.Trim();
                    return;
                }
                base.Title = "职位编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            Position position = new Position();
            if (this.ViewState["pk_Position"] != null)
            {
                position.GetData(int.Parse(this.ViewState["pk_Position"].ToString()));
                position.Title = this.txtName.Text.Trim();
                position.LevelID = MojoCube.Web.String.ToInt(this.txtLevelID.Text.Trim());
                position.ModifyUser = int.Parse(this.Session["UserID"].ToString());
                position.ModifyDate = DateTime.Now.ToString();
                position.UpdateData(position.pk_Position);
            }
            else
            {
                position.Title = this.txtName.Text.Trim();
                position.ParentID = 0;
                position.LevelID = MojoCube.Web.String.ToInt(this.txtLevelID.Text.Trim());
                position.SortID = 0;
                position.fk_Company = 0;
                position.CreateUser = int.Parse(this.Session["UserID"].ToString());
                position.CreateDate = DateTime.Now.ToString();
                position.ModifyUser = 0;
                position.ModifyDate = DateTime.Now.ToString();
                position.InsertData();
            }
            base.Response.Redirect("Position.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Position.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}