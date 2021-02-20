using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Memo;
using MojoCube.Web.User;
using System;
using System.Data;
using System.Collections;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_Profile : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                this.GridBind();
                MojoCube.Web.User.List list = new MojoCube.Web.User.List();
                list.GetData(int.Parse(this.Session["UserID"].ToString()));
                //this.lblFullName.Text = list.FullName;
                this.txtName.Text = list.UserName;
                this.txtPhone1.Text = list.Phone1;
                //this.txtNickName.Text = list.NickName;
                this.txtFullName.Text = list.FullName;
                txtPhone1.Attributes.Add("readOnly", "readOnly");
                txtName.Attributes.Add("readOnly", "readOnly");
                txtFullName.Attributes.Add("readOnly", "readOnly");
                //this.txtEmail1.Text = list.Email1;
                //this.txtAddress1.Text = list.Address1;
                //this.txtEducation.Text = list.Education;
                //this.txtSchool.Text = list.School;
                //this.txtBankAccount.Text = list.BankAccount;
                //this.txtIDNumber.Text = list.IDNumber;
                //this.txtBirthday.Text = DateTime.Parse(list.Birthday).ToString("yyyy-MM-dd");
                //this.txtNote.Text = list.Note;
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
                //Position position = new Position();
                //position.GetData(list.Position);
                //this.lblPosition.Text = position.Title;
                //Department department = new Department();
                //department.GetData(list.fk_Department);
                //this.lblDepartment.Text = department.DepartmentName;
                //this.lblEducation.Text = list.School + " " + list.Education;
                //this.lblPhone.Text = list.Phone1;
                //this.lblAddress.Text = list.Address1;
                //this.lblNote.Text = list.Note;
                base.Title = "用户面板";
            }
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                if (dataSource.Rows[31]["col2"].ToString() == "1" && dataSource.Rows[31]["col1"].ToString() == "div0071")
                {
                    dd0071.Visible = true;
                }
                else
                {
                    dd0071.Visible = false;
                }
                if (dataSource.Rows[32]["col2"].ToString() == "1" && dataSource.Rows[32]["col1"].ToString() == "div0072")
                {
                    dd0072.Visible = true;
                }
                else
                {
                    dd0072.Visible = false;
                }
                if (dataSource.Rows[33]["col2"].ToString() == "1" && dataSource.Rows[33]["col1"].ToString() == "div0073")
                {
                    dd0073.Visible = true;
                }
                else
                {
                    dd0073.Visible = false;
                }
                if (dataSource.Rows[34]["col2"].ToString() == "1" && dataSource.Rows[34]["col1"].ToString() == "div0074")
                {
                    dd0074.Visible = true;
                }
                else
                {
                    dd0074.Visible = false;
                }
                if (dataSource.Rows[35]["col2"].ToString() == "1" && dataSource.Rows[35]["col1"].ToString() == "div0075")
                {
                    dd0075.Visible = true;
                }
                else
                {
                    dd0075.Visible = false;
                }
                if (dataSource.Rows[36]["col2"].ToString() == "1" && dataSource.Rows[36]["col1"].ToString() == "div0076")
                {
                    dd0076.Visible = true;
                }
                else
                {
                    dd0076.Visible = false;
                }
                if (dataSource.Rows[37]["col2"].ToString() == "1" && dataSource.Rows[37]["col1"].ToString() == "div0077")
                {
                    dd0077.Visible = true;
                }
                else
                {
                    dd0077.Visible = false;
                }

            }
            else
            {
                div0071.Visible = false;
                div0072.Visible = false;
                div0073.Visible = false;
                div0074.Visible = false;
                div0075.Visible = false;
                div0076.Visible = false;
                div0077.Visible = false;
            }
        }


        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            //this.EmptyDiv.Visible = false;
            //AdminPager adminPager = new AdminPager(this.ListPager);
            //adminPager.PageSize = 5;
            //adminPager.ConnStr = Connection.ConnString();
            //adminPager.TableName = "Memo_List";
            //adminPager.strGetFields = "*";
            //string where = " where fk_User=?";
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(this.Session["UserID"].ToString());
            //adminPager.where = where;
            //adminPager.parameter = arrayList;
            //adminPager.fldName = "IsStar desc,ModifyDate";
            //adminPager.OrderType = true;
            //this.GridView1.DataSource = adminPager.GetTable();
            //this.GridView1.DataBind();
            //if (this.GridView1.Rows.Count == 0)
            //{
            //    this.EmptyDiv.Visible = true;
            //}
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((CheckBox)e.Row.FindControl("cbStar")).Checked)
                {
                    ((LinkButton)e.Row.FindControl("gvStar")).Text = "<i class=\"fa fa-star text-yellow\"></i>";
                }
                ((HyperLink)e.Row.FindControl("gvEdit")).Attributes.Add("onclick", string.Concat(new string[]
			{
				"editMemo('",
				((Label)e.Row.FindControl("lblID")).Text,
				"','",
				((Label)e.Row.FindControl("lblMemoTitle")).Text,
				"','",
				((Label)e.Row.FindControl("lblMemoDescription")).Text,
				"')"
			}));
                MojoCube.Web.String.ShowDel(e);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string[] controlList = new string[]
		{
			"gvStar",
			"gvDelete"
		};
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //MojoCube.Web.Memo.List list = new MojoCube.Web.Memo.List();
            //int index = Convert.ToInt32(e.CommandArgument);
            //if (e.CommandName == "_star")
            //{
            //    list.GetData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            //    if (list.IsStar)
            //    {
            //        list.IsStar = false;
            //    }
            //    else
            //    {
            //        list.IsStar = true;
            //    }
            //    list.UpdateData(list.pk_Memo);
            //}
            //if (e.CommandName == "_delete")
            //{
            //    list.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            //}
            //this.GridBind();
        }

        protected void lnbSaveMemo_Click(object sender, EventArgs e)
        {
            //if (this.txtMemoContent.Text.Trim() != "")
            //{
            //    MojoCube.Web.Memo.List list = new MojoCube.Web.Memo.List();
            //    if (this.txtMemoID.Text.Trim() != "")
            //    {
            //        list.GetData(int.Parse(this.txtMemoID.Text.Trim()));
            //        if (list.fk_User == int.Parse(this.Session["UserID"].ToString()))
            //        {
            //            list.Title = this.txtMemoTitle.Text.Trim();
            //            list.Description = this.txtMemoContent.Text.Trim();
            //            list.ModifyUser = int.Parse(this.Session["UserID"].ToString());
            //            list.ModifyDate = DateTime.Now.ToString();
            //            list.UpdateData(list.pk_Memo);
            //        }
            //    }
            //    else
            //    {
            //        list.fk_User = int.Parse(this.Session["UserID"].ToString());
            //        list.fk_Department = int.Parse(this.Session["DepartmentID"].ToString());
            //        list.TypeID = 0;
            //        list.StatusID = 0;
            //        list.Title = this.txtMemoTitle.Text.Trim();
            //        list.Description = this.txtMemoContent.Text.Trim();
            //        list.ImagePath = string.Empty;
            //        list.FilePath = string.Empty;
            //        list.UserList = string.Empty;
            //        list.DepartmentList = string.Empty;
            //        list.RoleList = string.Empty;
            //        list.Url = string.Empty;
            //        list.IsStar = false;
            //        list.Tags = string.Empty;
            //        list.fk_Company = 0;
            //        list.CreateUser = int.Parse(this.Session["UserID"].ToString());
            //        list.CreateDate = DateTime.Now.ToString();
            //        list.ModifyUser = 0;
            //        list.ModifyDate = DateTime.Now.ToString();
            //        list.InsertData();
            //    }
            //    base.Response.Redirect("Profile.aspx");
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtFullName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写真实姓名");
                return;
            }
            MojoCube.Web.User.List list = new MojoCube.Web.User.List();
            if (this.Session["UserID"] != null)
            {
                //Upload upload = new Upload();
                //upload.FilePath = "User/" + this.Session["UserID"].ToString();
                //upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
                //upload.DoFileUpload(this.fuPortrait);
                list.GetData(int.Parse(this.Session["UserID"].ToString()));
                if (this.txtPassword1.Text.Trim() != "")
                {
                    if (this.txtPassword1.Text.Trim().Length < 6)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请输入至少6位密码");
                        return;
                    }
                    if (this.txtPassword1.Text.Trim() != this.txtPassword2.Text.Trim())
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "两次输入密码不一致");
                        return;
                    }
                    list.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPassword1.Text.Trim(), "MD5").ToLower();
                }
                list.UserName = this.txtName.Text.Trim();
                //list.NickName = this.txtNickName.Text.Trim();
                list.FullName = this.txtFullName.Text.Trim();
                //list.FirstName = MojoCube.Web.String.GetChineseName(this.txtFullName.Text.Trim(), false);
                //list.LastName = MojoCube.Web.String.GetChineseName(this.txtFullName.Text.Trim(), true);
                list.Phone1 = this.txtPhone1.Text.Trim();
                //list.Email1 = this.txtEmail1.Text.Trim();
                //list.Address1 = this.txtAddress1.Text.Trim();
                //list.Education = this.txtEducation.Text.Trim();
                //list.School = this.txtSchool.Text.Trim();
                //list.BankAccount = this.txtBankAccount.Text.Trim();
                //list.IDNumber = this.txtIDNumber.Text.Trim();
                //list.Skin = this.ddlSkin.SelectedValue;
                //list.Sex = int.Parse(this.ddlSex.SelectedValue);
                //list.Birthday = this.txtBirthday.Text.Trim();
                //list.Note = this.txtNote.Text.Trim();
                //if (upload.IsUpload)
                //{
                //    list.ImagePath1 = upload.OldFilePath;
                //}
                //list.ModifyUser = int.Parse(this.Session["UserID"].ToString());
                list.CreateDate = DateTime.Now.ToString();
                list.UpdateData(list.pk_User);
                list.GetData(int.Parse(this.Session["UserID"].ToString()));
                //base.Response.Redirect("Profile.aspx");
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "修改保存成功");
                this.Session["password"] = list.Password;
                this.Session["CreateDate"] = list.CreateDate;

            }
        }
    }
}