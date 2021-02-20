using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;

using MojoCube.Web.User;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ZedGraph;
using CopyMFRubikCubePowerContent.Admin.Controls;

namespace CopyMFRubikCubePowerContent.Admin.Dashboard
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            string language = MojoCube.Api.UI.Language.GetLanguage();
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append(string.Concat(new string[]
        //{
        //    "select count(pk_Log) as [Counter] from Site_Log where LogTime >=#",
        //    text,
        //    " 00:00:00# and LogTime <=#",
        //    text,
        //    " 23:59:59#"
        //}));
        //    stringBuilder.Append("|select count(pk_Article) as [Counter] from Article_List where Issue=True and [Language]='" + language + "'");
        //    stringBuilder.Append("|select count(pk_Product) as [Counter] from Product_List where Issue=True and [Language]='" + language + "'");
        //    stringBuilder.Append("|select count(pk_Comment) as [Counter] from Comment_List where Issue=True and StatusID=0");
        //    stringBuilder.Append(string.Concat(new string[]
        //{
        //    "|select top 5 Url,count(Url) as [Counter] from Site_Log where LogTime >=#",
        //    text,
        //    " 00:00:00# and LogTime <=#",
        //    text,
        //    " 23:59:59# group by Url order by count(Url) desc"
        //}));
        //    stringBuilder.Append("|select top 5 * from Memo_List where fk_User=" + this.Session["UserID"].ToString() + " order by IsStar desc,ModifyDate desc");
        //    DataSet dataSet = Sql.SqlQueryDS(stringBuilder.ToString());
        //    this.LogDiv.InnerHtml = this.CreateLog(dataSet.Tables[0]);
        //    this.ArticleDiv.InnerHtml = this.CreateArticle(dataSet.Tables[1]);
        //    this.ProductDiv.InnerHtml = this.CreateProduct(dataSet.Tables[2]);
        //    this.CommentDiv.InnerHtml = this.CreateComment(dataSet.Tables[3]);
        //    this.ServerDiv.InnerHtml = this.GetServerInfo();
        //    this.DrawLine();
        //    this.DrawPie(dataSet.Tables[4]);
        //    this.MemoDiv.InnerHtml = this.CreateMemo(dataSet.Tables[5]);
        }

        private string CreateLog(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                stringBuilder.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
            }
            else
            {
                stringBuilder.Append("<h3>0</h3>");
            }
            stringBuilder.Append("<p>今日浏览网站数</p>");
            return stringBuilder.ToString();
        }

        private string CreateArticle(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                stringBuilder.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
            }
            else
            {
                stringBuilder.Append("<h3>0</h3>");
            }
            stringBuilder.Append("<p>文章总数</p>");
            return stringBuilder.ToString();
        }

        private string CreateProduct(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                stringBuilder.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
            }
            else
            {
                stringBuilder.Append("<h3>0</h3>");
            }
            stringBuilder.Append("<p>产品总数</p>");
            return stringBuilder.ToString();
        }

        private string CreateComment(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                stringBuilder.Append("<h3>" + dt.Rows[0]["Counter"].ToString() + "</h3>");
            }
            else
            {
                stringBuilder.Append("<h3>0</h3>");
            }
            stringBuilder.Append("<p>未处理留言</p>");
            return stringBuilder.ToString();
        }

        private string GetServerInfo()
        {
            string text = "";
            try
            {
                text += "<div style=\"padding:10px 20px 20px 20px; border-top:solid 1px #eee; line-height:1.8em; color:#666;\">";
                text = text + "<font>服务器OS：</font>" + Environment.OSVersion.ToString() + "<br />";
                text = text + "<font>CPU核心数：</font>" + Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS") + "个核心<br />";
                text = text + "<font>CPU类型：</font>" + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") + "<br />";
                text = text + "<font>IIS版本：</font>" + base.Request.ServerVariables["SERVER_SOFTWARE"] + "<br />";
                text = text + "<font>服务器名：</font>" + base.Server.MachineName + "<br />";
                text = text + "<font>服务器域名：</font>" + base.Request.ServerVariables["SERVER_NAME"] + "<br />";
                text = text + "<font>虚拟服务绝对路径：</font>" + base.Request.ServerVariables["APPL_PHYSICAL_PATH"] + "<br />";
                text = text + "<font>.Net版本：</font>.NET CLR " + Environment.Version.ToString() + "<br />";
                text = text + "<font>脚本超时时间：</font>" + base.Server.ScriptTimeout.ToString() + "毫秒<br />";
                text = text + "<font>开机运行时长：</font>" + ((double)Environment.TickCount / 3600000.0).ToString("F2") + "小时<br />";
                text = text + "<font>Session总数：</font>" + this.Session.Contents.Count.ToString() + "<br />";
                text = text + "<font>Application总数：</font>" + base.Application.Contents.Count.ToString() + "<br />";
                text = text + "<font>应用程序缓存总数：</font>" + base.Cache.Count.ToString() + "<br />";
                text = text + "<font>本页执行时间：</font>" + base.Server.ScriptTimeout.ToString() + "毫秒";
                text += "</div>";
            }
            catch
            {
            }
            return text;
        }

  

        private string CreateMemo(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                MojoCube.Web.User.List list = new MojoCube.Web.User.List();
                list.GetData(int.Parse(this.Session["UserID"].ToString()));
                string str = "";
                //if (list.ImagePath1 != "")
                //{
                //    str = "../Files.aspx?image=" + Security.EncryptString(list.ImagePath1);
                //}
                //else
                //{
                //    str = "../Images/user.png";
                //}
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stringBuilder.Append("<div class=\"item\" style=\"border-top:dashed 1px #eee; padding-top:10px;\">");
                    //stringBuilder.Append("<img src=\"" + str + "\" class=\"online\">");
                    stringBuilder.Append("<p class=\"message\">");
                    stringBuilder.Append("<a href=\"../User/Profile.aspx\" class=\"name\">");
                    stringBuilder.Append("<small class=\"text-muted pull-right\"><i class=\"fa fa-clock-o\"></i> " + DateTime.Parse(dt.Rows[i]["ModifyDate"].ToString()).ToString("yyyy-MM-dd HH:mm") + "</small>");
                    if (dt.Rows[i]["Title"].ToString() != "")
                    {
                        stringBuilder.Append(dt.Rows[i]["Title"].ToString());
                    }
                    else
                    {
                        stringBuilder.Append("无标题");
                    }
                    stringBuilder.Append("</a>");
                    stringBuilder.Append(dt.Rows[i]["Description"].ToString());
                    stringBuilder.Append("</p>");
                    stringBuilder.Append("</div>");
                }
            }
            return stringBuilder.ToString();
        }

        protected void lnbSaveMemo_Click(object sender, EventArgs e)
        {
            //if (this.txtMemoContent.Text.Trim() != "")
            //{
            //    new MojoCube.Web.Memo.List
            //    {
            //        fk_User = int.Parse(this.Session["UserID"].ToString()),
            //        fk_Department = int.Parse(this.Session["DepartmentID"].ToString()),
            //        TypeID = 0,
            //        StatusID = 0,
            //        Title = string.Empty,
            //        Description = this.txtMemoContent.Text.Trim(),
            //        ImagePath = string.Empty,
            //        FilePath = string.Empty,
            //        UserList = string.Empty,
            //        DepartmentList = string.Empty,
            //        RoleList = string.Empty,
            //        Url = string.Empty,
            //        IsStar = false,
            //        Tags = string.Empty,
            //        fk_Company = 0,
            //        CreateUser = int.Parse(this.Session["UserID"].ToString()),
            //        CreateDate = DateTime.Now.ToString(),
            //        ModifyUser = 0,
            //        ModifyDate = DateTime.Now.ToString()
            //    }.InsertData();
            //}
            //base.Response.Redirect("Default.aspx");
        }
    }
}