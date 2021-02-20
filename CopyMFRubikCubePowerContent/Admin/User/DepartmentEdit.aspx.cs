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
    public partial class Admin_User_DepartmentEdit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.hlBack.NavigateUrl = "Department.aspx?active=" + base.Request.QueryString["active"];
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["pk_Department"] = Security.DecryptString(base.Request.QueryString["id"]);
                    Department department = new Department();
                    department.GetData(int.Parse(this.ViewState["pk_Department"].ToString()));
                    this.txtName.Text = department.DepartmentName;
                    this.txtPhone1.Text = department.Phone1;
                    this.txtFax.Text = department.Fax;
                    this.txtEmail.Text = department.Email;
                    this.txtAddress.Text = department.Address;
                    this.txtSortID.Text = department.SortID.ToString();
                    this.txtWorkTime.Text = department.Monday;
                    base.Title = "部门编辑：" + this.txtName.Text.Trim();
                    return;
                }
                base.Title = "部门编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            Department department = new Department();
            if (this.ViewState["pk_Department"] != null)
            {
                department.GetData(int.Parse(this.ViewState["pk_Department"].ToString()));
                department.DepartmentName = this.txtName.Text.Trim();
                department.Phone1 = this.txtPhone1.Text.Trim();
                department.Fax = this.txtFax.Text.Trim();
                department.Email = this.txtEmail.Text.Trim();
                department.Address = this.txtAddress.Text.Trim();
                department.SortID = MojoCube.Web.String.ToInt(this.txtSortID.Text.Trim());
                department.ModifyUser = int.Parse(this.Session["UserID"].ToString());
                department.ModifyDate = DateTime.Now.ToString();
                department.Monday = this.txtWorkTime.Text.Trim();
                department.Tuesday = this.txtWorkTime.Text.Trim();
                department.Wednesday = this.txtWorkTime.Text.Trim();
                department.Thursday = this.txtWorkTime.Text.Trim();
                department.Friday = this.txtWorkTime.Text.Trim();
                department.UpdateData(department.pk_Department);
            }
            else
            {
                department.DepartmentName = this.txtName.Text.Trim();
                department.Phone1 = this.txtPhone1.Text.Trim();
                department.Phone2 = string.Empty;
                department.Fax = this.txtFax.Text.Trim();
                department.Email = this.txtEmail.Text.Trim();
                department.Address = this.txtAddress.Text.Trim();
                if (base.Request.QueryString["parentId"] != null)
                {
                    department.ParentID = int.Parse(Security.DecryptString(base.Request.QueryString["parentId"]));
                    department.LevelID = 1;
                }
                else
                {
                    department.ParentID = 0;
                    department.LevelID = 0;
                }
                department.SortID = MojoCube.Web.String.ToInt(this.txtSortID.Text.Trim());
                department.TypeID = 0;
                department.Province = 0;
                department.City = 0;
                department.County = 0;
                department.Zone = 0;
                department.Manager = 0;
                department.fk_Company = 0;
                department.CreateUser = int.Parse(this.Session["UserID"].ToString());
                department.CreateDate = DateTime.Now.ToString();
                department.ModifyUser = 0;
                department.ModifyDate = DateTime.Now.ToString();
                department.Monday = this.txtWorkTime.Text.Trim();
                department.Tuesday = this.txtWorkTime.Text.Trim();
                department.Wednesday = this.txtWorkTime.Text.Trim();
                department.Thursday = this.txtWorkTime.Text.Trim();
                department.Friday = this.txtWorkTime.Text.Trim();
                department.Saturday = string.Empty;
                department.Sunday = string.Empty;
                department.InsertData();
            }
            base.Response.Redirect("Department.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Department.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}