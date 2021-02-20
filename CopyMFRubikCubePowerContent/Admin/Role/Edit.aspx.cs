using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Data;
using System.Text;
using System.Collections;
using System.IO;
using System.Web.UI;


namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_Edit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                getDrop所属项目部();
                this.hlBack.NavigateUrl = "List.aspx?active=" + base.Request.QueryString["active"];
                //Sql.DropDownListBind(this.ddlDepartment, "User_Department", "DepartmentName", "pk_Department", "fk_Company=0", "SortID", "asc");
                //Sql.DropDownListBind(this.ddlPosition, "User_Position", "Title", "pk_Position", "fk_Company=0", "SortID", "desc");
                Sql.DropDownListBind(this.ddlRole, "Role_Name", "RoleName_CHS", "pk_Name", "fk_Company=0", "PowerValue", "desc");
                if (base.Request.QueryString["id"] != null)
                {
                    this.EditDiv.Visible = true;
                    this.ViewState["pk_User"] = Security.DecryptString(base.Request.QueryString["id"]);
                    List list = new List();
                    list.GetData(int.Parse(this.ViewState["pk_User"].ToString()));
                    this.txtName.Text = list.UserName;
                    this.txtPhone1.Text = list.Phone1;
                    //this.txtNickName.Text = list.NickName;
                    this.txtFullName.Text = list.FullName;
                    //this.txtEmail1.Text = list.Email1;
                    //this.txtAddress1.Text = list.Address1;
                    //this.txtEducation.Text = list.Education;
                    //this.txtSchool.Text = list.School;
                    //this.txtBankAccount.Text = list.BankAccount;
                    //this.txtIDNumber.Text = list.IDNumber;
                    //Sql.ddlFindByValue(this.ddlDepartment, list.fk_Department.ToString());
                    //Sql.ddlFindByValue(this.ddlPosition, list.Position.ToString());
                    Sql.ddlFindByValue(this.ddlRole, list.RoleValue.ToString());
                    //this.txtWages.Text = list.Wages.ToString("N2");
                    //this.txtEntryTime.Text = DateTime.Parse(list.EntryTime).ToString("yyyy-MM-dd");
                    //this.txtBirthday.Text = DateTime.Parse(list.Birthday).ToString("yyyy-MM-dd");
                    //Sql.ddlFindByValue(this.ddlSkin, list.Skin);
                    //Sql.ddlFindByValue(this.ddlSex, list.Sex.ToString());
                    //if (list.ImagePath1 != "")
                    //{
                    //    this.imgPortrait.ImageUrl = "~/Files.aspx?image=" + Security.EncryptString(list.ImagePath1) + "&cut=200,200";
                    //}
                    //else
                    //{
                    //    this.imgPortrait.ImageUrl = "~/Images/user.png";
                    //}
                    string str项目部 = list.xiangmu;
                    foreach (ListItem li in ListBox项目部.Items)
                    {
                        if (str项目部.Contains(li.Value.Trim()) == true)
                        {
                            li.Selected = true;
                        }
                    }
                    base.Title = "用户编辑：" + this.txtName.Text.Trim();
                    return;
                }
                //this.txtBankAccount.Text = "（工行）";
                //this.txtEntryTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                base.Title = "用户编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            List list = new List();
            string str项目部 = "";
            foreach (ListItem li in ListBox项目部.Items)
            {
                if (li.Selected == true)
                {
                    str项目部 += li.Value.Trim() + ",";
                }
            }
            if (this.ViewState["pk_User"] != null)
            {
                //Upload upload = new Upload();
                //upload.FilePath = "User/" + this.ViewState["pk_User"].ToString();
                //upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
                //upload.DoFileUpload(this.fuPortrait);
                list.GetData(int.Parse(this.ViewState["pk_User"].ToString()));
                if (this.cbResetPsw.Checked)
                {
                    list.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
                }
                //list.fk_Department = int.Parse(this.ddlDepartment.SelectedValue);
                list.RoleValue = int.Parse(this.ddlRole.SelectedValue);
                //list.RoleList = this.ddlRole.SelectedValue;
                //list.Position = int.Parse(this.ddlPosition.SelectedValue);
                list.UserName = this.txtName.Text.Trim();
                //list.NickName = this.txtNickName.Text.Trim();
                list.FullName = this.txtFullName.Text.Trim();
                //list.FirstName = MojoCube.Web.String.GetChineseName(this.txtFullName.Text.Trim(), false);
                //list.LastName = MojoCube.Web.String.GetChineseName(this.txtFullName.Text.Trim(), true);
                list.Phone1 = this.txtPhone1.Text.Trim();
                //list.Email1 = this.txtEmail1.Text.Trim();
                //list.Address1 = this.txtAddress1.Text.Trim();
                //list.Birthday = this.txtBirthday.Text.Trim();
                //list.Education = this.txtEducation.Text.Trim();
                //list.School = this.txtSchool.Text.Trim();
                //list.BankAccount = this.txtBankAccount.Text.Trim();
                //list.IDNumber = this.txtIDNumber.Text.Trim();
                //list.Wages = MojoCube.Web.String.ToDecimal(this.txtWages.Text.Trim());
                //list.EntryTime = this.txtEntryTime.Text.Trim();
                //list.Skin = this.ddlSkin.SelectedValue;
                //list.Sex = int.Parse(this.ddlSex.SelectedValue);
                //if (upload.IsUpload)
                //{
                //    list.ImagePath1 = upload.OldFilePath;
                //}
                //list.ModifyUser = int.Parse(this.Session["UserID"].ToString());
                //list.ModifyDate = DateTime.Now.ToString();
                
                list.xiangmu = str项目部;
                list.UpdateData(list.pk_User);
            }
            else
            {
                list.UserName = this.txtName.Text.Trim();
                list.Password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
                //list.TypeID = 0;
                //list.fk_Department = int.Parse(this.ddlDepartment.SelectedValue);
                list.RoleValue = int.Parse(this.ddlRole.SelectedValue);
                //list.RoleList = this.ddlRole.SelectedValue;
                //list.Position = int.Parse(this.ddlPosition.SelectedValue);
                //list.Number = string.Empty;
                //list.Skin = this.ddlSkin.SelectedValue;
                //list.Language = "CHS";
                //list.IsLock = false;
                list.LastLoginIP = string.Empty;
                //list.LastLoginTime = DateTime.Now.ToString();
                //list.NickName = this.txtNickName.Text.Trim();
                list.FullName = this.txtFullName.Text.Trim();
                //list.FirstName = MojoCube.Web.String.GetChineseName(this.txtFullName.Text.Trim(), false);
                //list.MiddleName = string.Empty;
                //list.LastName = MojoCube.Web.String.GetChineseName(this.txtFullName.Text.Trim(), true);
                list.Phone1 = this.txtPhone1.Text.Trim();
                //list.Phone2 = string.Empty;
                //list.Email1 = this.txtEmail1.Text.Trim();
                //list.Email2 = string.Empty;
                //list.Fax = string.Empty;
                //list.Line = string.Empty;
                //list.Wechat = string.Empty;
                //list.QQ = string.Empty;
                //list.Facebook = string.Empty;
                //list.Twitter = string.Empty;
                //list.Linkedin = string.Empty;
                //list.ZipCode = string.Empty;
                //list.Place = string.Empty;
                //list.Address1 = this.txtAddress1.Text.Trim();
                //list.Address2 = string.Empty;
                //list.Province = 0;
                //list.City = 0;
                //list.County = 0;
                //list.Zone = 0;
                //list.Sex = int.Parse(this.ddlSex.SelectedValue);
                //list.Height = 0;
                //list.Weight = 0;
                //list.Birthday = this.txtBirthday.Text.Trim();
                //list.Education = this.txtEducation.Text.Trim();
                //list.School = this.txtSchool.Text.Trim();
                list.ImagePath1 = string.Empty;
                //list.ImagePath2 = string.Empty;
                //list.IDCardPath = string.Empty;
                //list.ResumePath = string.Empty;
                //list.Wages = MojoCube.Web.String.ToDecimal(this.txtWages.Text.Trim());
                //list.BankAccount = this.txtBankAccount.Text.Trim();
                //list.IDNumber = this.txtIDNumber.Text.Trim();
                //list.Source = string.Empty;
                //list.Note = string.Empty;
                //list.Remark = string.Empty;
                //list.EntryTime = this.txtEntryTime.Text.Trim();
                //list.IsQuit = false;
                //list.QuitTime = DateTime.Now.ToString();
                //list.fk_Company = 0;
                //list.CreateUser = int.Parse(this.Session["UserID"].ToString());
                list.CreateDate = DateTime.Now.ToString();
                //list.ModifyUser = 0;
                //list.ModifyDate = DateTime.Now.ToString();
                list.xiangmu = str项目部;
                list.InsertData();
            }
            base.Response.Redirect("List.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from tb_guige where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox项目部.DataTextField = "guige";
            ListBox项目部.DataValueField = "guige";
            ListBox项目部.DataSource = dataSource;
            ListBox项目部.DataBind();
           
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("List.aspx?active=" + base.Request.QueryString["active"]);
        }
    }
}