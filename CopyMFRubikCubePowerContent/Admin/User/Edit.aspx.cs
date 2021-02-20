﻿using MojoCube.Api.Text;
using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data;

namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop所属项目部();
                
                this.hlBack.NavigateUrl = "List.aspx?active=" + base.Request.QueryString["active"];
                //Sql.DropDownListBind(this.ddlDepartment, "User_Department", "DepartmentName", "pk_Department", "fk_Company=0", "SortID", "asc");
                //Sql.DropDownListBind(this.ddlPosition, "User_Position", "Title", "pk_Position", "fk_Company=0", "SortID", "desc");
                Sql.DropDownListBind(this.ddlRole, "Role_Name", "RoleName_CHS", "pk_Name", "fk_Company=0", "PowerValue", "asc");
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
                    //this.txtWages.Text = list.Wages.ToString("F2");
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

                    getListBox1(str项目部);

                    //foreach (ListItem li in ListBox项目部.Items)
                    //{
                    //    if (str项目部.Contains(li.Value.Trim()) == true)
                    //    {
                    //        li.Selected = true;
                    //    }
                    //}
                    base.Title = "用户编辑：" + this.txtName.Text.Trim();
                    return;
                }
                //this.txtBankAccount.Text = "（工行）";
                //this.txtEntryTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                base.Title = "用户编辑";
            }
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (this.Session["UserName"].ToString() == "蔡光明" || this.Session["RoleValue"].ToString() == "7")
            {
                Div2.Visible = true;
            }
            if (dataSource.Rows.Count > 0)
            {
                if (dataSource.Rows[32]["col2"].ToString() == "1" && dataSource.Rows[32]["col1"].ToString() == "div0071")
                {
                    dd0071.Visible = true;
                }
                else
                {
                    dd0071.Visible = false;
                }
                if (dataSource.Rows[33]["col2"].ToString() == "1" && dataSource.Rows[33]["col1"].ToString() == "div0072")
                {
                    dd0072.Visible = true;
                }
                else
                {
                    dd0072.Visible = false;
                }
                if (dataSource.Rows[34]["col2"].ToString() == "1" && dataSource.Rows[34]["col1"].ToString() == "div0073")
                {
                    dd0073.Visible = true;
                }
                else
                {
                    dd0073.Visible = false;
                }
                if (dataSource.Rows[35]["col2"].ToString() == "1" && dataSource.Rows[35]["col1"].ToString() == "div0074")
                {
                    dd0074.Visible = true;
                }
                else
                {
                    dd0074.Visible = false;
                }
                if (dataSource.Rows[36]["col2"].ToString() == "1" && dataSource.Rows[36]["col1"].ToString() == "div0075")
                {
                    dd0075.Visible = true;
                }
                else
                {
                    dd0075.Visible = false;
                }
                if (dataSource.Rows[37]["col2"].ToString() == "1" && dataSource.Rows[37]["col1"].ToString() == "div0076")
                {
                    dd0076.Visible = true;
                }
                else
                {
                    dd0076.Visible = false;
                }
                if (dataSource.Rows[38]["col2"].ToString() == "1" && dataSource.Rows[38]["col1"].ToString() == "div0077")
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写名称");
                return;
            }
            List list = new List();
            string str项目部 = "";
            foreach (ListItem li in ListBox1.Items)
            {
                str项目部 += li.Value.Trim() + ",";
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
                
                list.ImagePath1 = string.Empty;
                
                list.CreateDate = DateTime.Now.ToString();
              
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

        protected void getListBox1(string str)
        {
            string[] list1 = str.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("guige");
            DataRow dr;
            
            for(int i = 0;i < list1.Length;i++)
            {
                if (list1[i].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["guige"] = list1[i];
                    dt.Rows.Add(dr);
                }
                
            }

            ListBox1.DataTextField = "guige";
            ListBox1.DataValueField = "guige";
            ListBox1.DataSource = dt;
            ListBox1.DataBind();

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("List.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave11_Click(object sender, EventArgs e)
        {
            string str项目部 = "";
            foreach (ListItem li in ListBox1.Items)
            {
                str项目部 += li.Value.Trim() + ",";
            }
            for (int ii = 0; ii < ListBox项目部.Items.Count; ii++)
            {
                if (ListBox项目部.Items[ii].Selected == true)
                {
                    if (str项目部.Contains(ListBox项目部.Items[ii].Text))
                    {

                    }
                    else
                    {
                        ListBox1.Items.Add(ListBox项目部.Items[ii].Text);

                    }
                }
                
            }

        }

        protected void btndel11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox1.Items.Count;i++ )
            {
                if (ListBox1.Items[i].Selected == true)
                {
                    ListBox1.Items.Remove(ListBox1.Items[i]);
                    i--;
                }
            }
 
        }


    }
}