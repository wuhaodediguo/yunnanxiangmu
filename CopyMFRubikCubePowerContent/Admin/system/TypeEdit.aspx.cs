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
    public partial class Admin_System_TypeEdit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlBack.NavigateUrl = "Type.aspx?active=" + base.Request.QueryString["active"];
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["pk_TypeID"] = Security.DecryptString(base.Request.QueryString["id"]);
                    TypeID typeID = new TypeID();
                    typeID.GetData(int.Parse(this.ViewState["pk_TypeID"].ToString()));
                    this.txtName.Text = typeID.TypeName_CHS;
                    this.txtID.Text = typeID.ID.ToString();
                    this.txtTableName.Text = typeID.TableName;
                    this.txtVisual.Text = typeID.Visual;
                    this.txtDescription.Text = typeID.Description_CHS;
                    base.Title = "类型编辑：" + this.txtName.Text.Trim();
                    return;
                }
                base.Title = "类型编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            TypeID typeID = new TypeID();
            if (this.ViewState["pk_TypeID"] != null)
            {
                typeID.GetData(int.Parse(this.ViewState["pk_TypeID"].ToString()));
                typeID.TypeName_CHS = this.txtName.Text.Trim();
                typeID.ID = MojoCube.Web.String.ToInt(this.txtID.Text.Trim());
                typeID.Visual = this.txtVisual.Text.Trim();
                typeID.TableName = this.txtTableName.Text.Trim();
                typeID.Description_CHS = this.txtDescription.Text.Trim();
                typeID.UpdateData(typeID.pk_TypeID);
            }
            else
            {
                typeID.TypeName_CHS = this.txtName.Text.Trim();
                typeID.TypeName_CHT = string.Empty;
                typeID.TypeName_EN = string.Empty;
                typeID.ID = MojoCube.Web.String.ToInt(this.txtID.Text.Trim());
                typeID.Visual = this.txtVisual.Text.Trim();
                typeID.TableName = this.txtTableName.Text.Trim();
                typeID.Description_CHS = this.txtDescription.Text.Trim();
                typeID.Description_CHT = string.Empty;
                typeID.Description_EN = string.Empty;
                typeID.InsertData();
            }
            base.Response.Redirect("Type.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Type.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}