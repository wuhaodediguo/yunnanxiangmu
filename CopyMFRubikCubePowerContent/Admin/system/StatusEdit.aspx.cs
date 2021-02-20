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
    public partial class Admin_System_StatusEdit : MyPage, IRequiresSessionState
    {
       protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.hlBack.NavigateUrl = "Status.aspx?active=" + base.Request.QueryString["active"];
			if (base.Request.QueryString["id"] != null)
			{
				this.ViewState["pk_StatusID"] = Security.DecryptString(base.Request.QueryString["id"]);
				StatusID statusID = new StatusID();
				statusID.GetData(int.Parse(this.ViewState["pk_StatusID"].ToString()));
				this.txtName.Text = statusID.StatusName_CHS;
				this.txtID.Text = statusID.ID.ToString();
				this.txtTableName.Text = statusID.TableName;
				this.txtVisual.Text = statusID.Visual;
				base.Title = "状态编辑：" + this.txtName.Text.Trim();
				return;
			}
			base.Title = "状态编辑";
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (this.txtName.Text.Trim() == "")
		{
			this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
			return;
		}
		StatusID statusID = new StatusID();
		if (this.ViewState["pk_StatusID"] != null)
		{
			statusID.GetData(int.Parse(this.ViewState["pk_StatusID"].ToString()));
			statusID.StatusName_CHS = this.txtName.Text.Trim();
			statusID.ID = MojoCube.Web.String.ToInt(this.txtID.Text.Trim());
			statusID.Visual = this.txtVisual.Text.Trim();
			statusID.TableName = this.txtTableName.Text.Trim();
			statusID.UpdateData(statusID.pk_StatusID);
		}
		else
		{
			statusID.StatusName_CHS = this.txtName.Text.Trim();
			statusID.StatusName_CHT = string.Empty;
			statusID.StatusName_EN = string.Empty;
			statusID.ID = MojoCube.Web.String.ToInt(this.txtID.Text.Trim());
			statusID.Visual = this.txtVisual.Text.Trim();
			statusID.TableName = this.txtTableName.Text.Trim();
			statusID.Description_CHS = string.Empty;
			statusID.Description_CHT = string.Empty;
			statusID.Description_EN = string.Empty;
			statusID.InsertData();
		}
		base.Response.Redirect("Status.aspx?active=" + base.Request.QueryString["active"]);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Status.aspx?active=" + base.Request.QueryString["active"]);
	}

    }
}