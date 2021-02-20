using MojoCube.Web;
using MojoCube.Web.User;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MojoCube.Api.SMS;
using MojoCube.Web.CurrentExpenses;

namespace CopyMFRubikCubePowerContent.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private int sdkappid = Convert.ToInt32(Connection.GetConfigValue("sdkappid"));
        private string appkey = Connection.GetConfigValue("appkey");
        private int tmplId = Convert.ToInt32(Connection.GetConfigValue("fahuotmplId"));

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.btnLogin.Attributes["onclick"] = base.GetPostBackEventReference(this.btnLogin) + ";this.disabled=true;this.value='请稍等...';";
            if (!base.IsPostBack)
            {
                //getDrop();
            }
            
        }


        protected void getDrop()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "SELECT distinct col4 from t_quanxian  where 1=1 and col4 = 'admin'    ";
            dataSource = oledbHelper.GetDataTable(sql);
            for (int k = 0; k < dataSource.Rows.Count; k++)
            {
                quanxianList list = new quanxianList();
                list.col1 = "div0092";
                list.col2 = "1";
                list.col3 = "结算审核";
                list.col4 = dataSource.Rows[k]["col4"].ToString();
                list.InsertData();

                list.col1 = "div0094";
                list.col2 = "1";
                list.col3 = "付款申请";
                list.col4 = dataSource.Rows[k]["col4"].ToString();
                list.InsertData();

                list.col1 = "div0095";
                list.col2 = "1";
                list.col3 = "付款审核";
                list.col4 = dataSource.Rows[k]["col4"].ToString();
                list.InsertData();

                list.col1 = "div0096";
                list.col2 = "1";
                list.col3 = "付款管理";
                list.col4 = dataSource.Rows[k]["col4"].ToString();
                list.InsertData();

                list.col1 = "div009";
                list.col2 = "1";
                list.col3 = "结算付款管理";
                list.col4 = dataSource.Rows[k]["col4"].ToString();
                list.InsertData();
            }

        }

        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string text = this.txtUserName.Text.ToLower().Trim();
            string text2 = this.txtPassword.Text.Trim();
            string text3 = this.TextBox验证码.Text.Trim();

            if (text == "" || text2 == "" || text3 == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("info", "请填写完整信息");
                return;
            }
            text2 = FormsAuthentication.HashPasswordForStoringInConfigFile(text2, "MD5").ToLower().Trim();
            MojoCube.Web.User.Login login = new MojoCube.Web.User.Login();
            if (!login.IsUser(text, text2))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "用户名或密码错误");
                return;
            }

           
            //if (hd用户.Text.ToUpper() != text3.ToUpper())
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "验证码错误");
            //    return;
            //}

            //if (!login.IsLock)
            {
                MojoCube.Web.User.Login.UpdateLastLogin(login.pk_User.ToString());
                this.Session["UserID"] = login.pk_User.ToString();
                this.Session["UserName"] = login.UserName;
                this.Session["FullName"] = login.FullName;
                this.Session["RoleValue"] = login.RoleValue;
                //this.Session["DepartmentID"] = login.fk_Department;
                this.Session["CreateDate"] = login.CreateDate;
                this.Session["password"] = login.Password;

                //写入cookie
                Response.Cookies["UserID"].Value = login.pk_User.ToString();  //将值写入到客户端硬盘Cookie
                Response.Cookies["UserID"].Expires = DateTime.Now.AddMinutes(30);//设置Cookie过期时间
                Response.Cookies["UserName"].Value = login.UserName;//将值写入到客户端硬盘Cookie
                Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(30);//设置Cookie过期时间
                Response.Cookies["FullName"].Value = login.FullName; //将值写入到客户端硬盘Cookie
                Response.Cookies["FullName"].Expires = DateTime.Now.AddMinutes(30);//设置Cookie过期时间
                Response.Cookies["RoleValue"].Value = login.RoleValue.ToString(); //将值写入到客户端硬盘Cookie
                Response.Cookies["RoleValue"].Expires = DateTime.Now.AddMinutes(30);//设置Cookie过期时间
                //Online.AddOnline(0);
                base.Response.Redirect("xiangmu/shouye.aspx");
                return;
            }
           // this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "账号被锁定");
        }

        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            string text = this.txtUserName.Text.ToLower().Trim();
            string text2 = this.txtPassword.Text.Trim();
            

            if (text == "" || text2 == "" )
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("info", "请填写完整信息");
                return;
            }
            text2 = FormsAuthentication.HashPasswordForStoringInConfigFile(text2, "MD5").ToLower().Trim();
            MojoCube.Web.User.Login login = new MojoCube.Web.User.Login();
            if (!login.IsUser(text, text2))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "用户名或密码错误");
                return;
            }

           
            SmsSingleSenderResult singleResult;
            SmsSingleSender singleSender = new SmsSingleSender(sdkappid, appkey);

            List<string> templParams = new List<string>();

            string telno2 = login.Phone1;
            string logisticCode = GenerateCheckCode();
            templParams.Add(logisticCode);
            
            singleResult = singleSender.SendWithParam("86", telno2, tmplId, templParams, "", "", "");
            if (singleResult.errmsg == "OK")
            {
                hd用户.Text = logisticCode;
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "短信发送成功");
            }
            else
            {
                //...
            }



        }

        private string GenerateCheckCode()
        {
            string text = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int num = random.Next();
                char c;
                c = (char)(48 + (ushort)(num % 10));
                //if (num % 2 == 0)
                //{
                //    c = (char)(48 + (ushort)(num % 10));
                //}
                //else
                //{
                //    c = (char)(65 + (ushort)(num % 26));
                //}
                text += c.ToString();
            }
            this.Session["CheckCode"] = text;
            return text;
        }


    }
}