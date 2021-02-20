using MojoCube.Api.Date;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Role;
using MojoCube.Web.Site;
using MojoCube.Web.User;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Commons
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string skin = "";

        public string skinCss = "";
        protected void Page_Init(object sender, EventArgs e)
        {
            MojoCube.Web.User.Login.ChkLogin();
            //this.hlLogo.NavigateUrl = "~/Admin/Dashboard/Default.aspx";
            //this.hlLogo.Text = ""; //"<span class=\"logo-mini\"><img src=\"http://cms.mojocube.com/Admin/images/logo_1.png\" /></span><span class=\"logo-lg\"><img src=\"http://cms.mojocube.com/Admin/images/logo.png\" /></span>";
            //this.MustDiv.InnerHtml = "<script src=\"../Skins/plugins/jQuery/jQuery-2.1.4.min.js\"></script>";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (this.Page.Title != "")
                {
                    //MojoCube.Web.User.Log.AddLog(this.Page.Title);
                }
                MojoCube.Web.User.List list = new MojoCube.Web.User.List();
                list.GetData(int.Parse(base.Session["UserID"].ToString()));
                this.lblFullName1.Text = list.FullName;

                this.lblYear.Text = DateTime.Now.Year.ToString();
                //this.hlCopyright.NavigateUrl = "http://www.wistarits.com/";
                this.hlCopyright.Text = "云南德凯通信工程有限公司  版权所有";
                //this.hlCopyright.Target = "_blank";
                //this.Welcome.InnerHtml = DateTime.Now.ToString("yyyy年MM月dd日") + ", " + Get.ChineseWeek();


                DataTable dataSource = new DataTable();
                OledbHelper oledbHelper = new OledbHelper();
                dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
                if (dataSource.Rows.Count > 0)
                {
                    if (dataSource.Rows[0]["col2"].ToString() == "1" && dataSource.Rows[0]["col1"].ToString() == "div001")
                    {
                        div001.Visible = true;
                    }
                    else
                    {
                        div0001.Visible = false;
                        div替换1.Visible = true;
                        div001.Visible = false;
                    }
                    if (dataSource.Rows[1]["col2"].ToString() == "1" && dataSource.Rows[1]["col1"].ToString() == "div002")
                    {
                        div002.Visible = true;
                    }
                    else
                    {
                        div0002.Visible = false;
                        div替换2.Visible = true;
                        div002.Visible = false;
                    }
                    if (dataSource.Rows[2]["col2"].ToString() == "1" && dataSource.Rows[2]["col1"].ToString() == "div0021")
                    {
                        div0021.Visible = true;
                    }
                    else
                    {
                        div0021.Visible = false;
                    }
                    if (dataSource.Rows[3]["col2"].ToString() == "1" && dataSource.Rows[3]["col1"].ToString() == "div0022")
                    {
                        div0022.Visible = true;
                    }
                    else
                    {
                        div0022.Visible = false;
                    }
                    if (dataSource.Rows[4]["col2"].ToString() == "1" && dataSource.Rows[4]["col1"].ToString() == "div0023")
                    {
                        div0023.Visible = true;
                    }
                    else
                    {
                        div0023.Visible = false;
                    }
                    if (dataSource.Rows[5]["col2"].ToString() == "1" && dataSource.Rows[5]["col1"].ToString() == "div003")
                    {
                        div003.Visible = true;
                    }
                    else
                    {
                        div0003.Visible = false;
                        div替换3.Visible = true;
                        div003.Visible = false;
                    }
                    if (dataSource.Rows[6]["col2"].ToString() == "1" && dataSource.Rows[6]["col1"].ToString() == "div0031")
                    {
                        div0031.Visible = true;
                    }
                    else
                    {
                        div0031.Visible = false;
                    }
                    if (dataSource.Rows[7]["col2"].ToString() == "1" && dataSource.Rows[7]["col1"].ToString() == "div0032")
                    {
                        div0032.Visible = true;
                    }
                    else
                    {
                        div0032.Visible = false;
                    }
                    if (dataSource.Rows[8]["col2"].ToString() == "1" && dataSource.Rows[8]["col1"].ToString() == "div0033")
                    {
                        div0033.Visible = true;
                    }
                    else
                    {
                        div0033.Visible = false;
                    }
                    if (dataSource.Rows[9]["col2"].ToString() == "1" && dataSource.Rows[9]["col1"].ToString() == "div0034")
                    {
                        div0034.Visible = true;
                    }
                    else
                    {
                        div0034.Visible = false;
                    }
                    if (dataSource.Rows[10]["col2"].ToString() == "1" && dataSource.Rows[10]["col1"].ToString() == "div004")
                    {
                        div004.Visible = true;
                    }
                    else
                    {
                        div0004.Visible = false;
                        div替换4.Visible = true;
                        div004.Visible = false;
                    }
                    if (dataSource.Rows[11]["col2"].ToString() == "1" && dataSource.Rows[11]["col1"].ToString() == "div0041")
                    {
                        div0041.Visible = true;
                    }
                    else
                    {
                        div0041.Visible = false;
                    }
                    if (dataSource.Rows[12]["col2"].ToString() == "1" && dataSource.Rows[12]["col1"].ToString() == "div0042")
                    {
                        div0042.Visible = true;
                    }
                    else
                    {
                        div0042.Visible = false;
                    }
                    if (dataSource.Rows[13]["col2"].ToString() == "1" && dataSource.Rows[13]["col1"].ToString() == "div0043")
                    {
                        div0043.Visible = true;
                    }
                    else
                    {
                        div0043.Visible = false;
                    }
                    if (dataSource.Rows[14]["col2"].ToString() == "1" && dataSource.Rows[14]["col1"].ToString() == "div0044")
                    {
                        div0044.Visible = true;
                    }
                    else
                    {
                        div0044.Visible = false;
                    }
                    if (dataSource.Rows[15]["col2"].ToString() == "1" && dataSource.Rows[15]["col1"].ToString() == "div0045")
                    {
                        div0045.Visible = true;
                    }
                    else
                    {

                        div0045.Visible = false;
                    }
                    if (dataSource.Rows[16]["col2"].ToString() == "1" && dataSource.Rows[16]["col1"].ToString() == "div0046")
                    {
                        div0046.Visible = true;
                    }
                    else
                    {
                        div0046.Visible = false;
                    }
                    if (dataSource.Rows[17]["col2"].ToString() == "1" && dataSource.Rows[17]["col1"].ToString() == "div005")
                    {
                        div005.Visible = true;
                    }
                    else
                    {
                        div005.Visible = false;
                    }
                    if (dataSource.Rows[18]["col2"].ToString() == "1" && dataSource.Rows[18]["col1"].ToString() == "div0051")
                    {
                        div0051.Visible = true;
                    }
                    else
                    {
                        div0051.Visible = false;
                    }
                    if (dataSource.Rows[19]["col2"].ToString() == "1" && dataSource.Rows[19]["col1"].ToString() == "div0052")
                    {
                        div0052.Visible = true;
                    }
                    else
                    {
                        div0005.Visible = false;
                        div替换5.Visible = true;
                        div0052.Visible = false;
                    }
                    if (dataSource.Rows[20]["col2"].ToString() == "1" && dataSource.Rows[20]["col1"].ToString() == "div0053")
                    {
                        div0053.Visible = true;
                    }
                    else
                    {
                        div0053.Visible = false;
                    }
                    if (dataSource.Rows[21]["col2"].ToString() == "1" && dataSource.Rows[21]["col1"].ToString() == "div0054")
                    {
                        div0054.Visible = true;
                    }
                    else
                    {
                        div0054.Visible = false;
                    }
                    if (dataSource.Rows[22]["col2"].ToString() == "1" && dataSource.Rows[22]["col1"].ToString() == "div0055")
                    {
                        div0055.Visible = true;
                    }
                    else
                    {
                        div0055.Visible = false;
                    }
                    if (dataSource.Rows[23]["col2"].ToString() == "1" && dataSource.Rows[23]["col1"].ToString() == "div006")
                    {
                        div006.Visible = true;
                    }
                    else
                    {
                        div006.Visible = false;
                    }
                    if (dataSource.Rows[24]["col2"].ToString() == "1" && dataSource.Rows[24]["col1"].ToString() == "div0061")
                    {
                        div0061.Visible = true;
                    }
                    else
                    {
                        div0061.Visible = false;
                    }
                    if (dataSource.Rows[25]["col2"].ToString() == "1" && dataSource.Rows[25]["col1"].ToString() == "div0062")
                    {
                        div0062.Visible = true;
                    }
                    else
                    {
                        div0062.Visible = false;
                    }
                    if (dataSource.Rows[26]["col2"].ToString() == "1" && dataSource.Rows[26]["col1"].ToString() == "div0063")
                    {
                        div0063.Visible = true;
                    }
                    else
                    {
                        div0063.Visible = false;
                    }

                    if (dataSource.Rows[27]["col2"].ToString() == "1" && dataSource.Rows[27]["col1"].ToString() == "div0064")
                    {
                        div0064.Visible = true;
                    }
                    else
                    {
                        div0064.Visible = false;
                    }
                    if (dataSource.Rows[28]["col2"].ToString() == "1" && dataSource.Rows[28]["col1"].ToString() == "div0065")
                    {
                        div0065.Visible = true;
                    }
                    else
                    {
                        div0065.Visible = false;
                    }
                    if (dataSource.Rows[29]["col2"].ToString() == "1" && dataSource.Rows[29]["col1"].ToString() == "div0067")
                    {
                        div0067.Visible = true;
                    }
                    else
                    {
                        div0067.Visible = false;
                    }

                    if (dataSource.Rows[30]["col2"].ToString() == "1" && dataSource.Rows[30]["col1"].ToString() == "div007")
                    {
                        div007.Visible = true;
                    }
                    else
                    {
                        div0007.Visible = false;
                        div替换7.Visible = true;
                        div007.Visible = false;
                    }
                    if (dataSource.Rows[31]["col2"].ToString() == "1" && dataSource.Rows[31]["col1"].ToString() == "div0071")
                    {
                        div0071.Visible = true;
                    }
                    else
                    {
                        div0071.Visible = false;
                    }
                    if (dataSource.Rows[32]["col2"].ToString() == "1" && dataSource.Rows[32]["col1"].ToString() == "div0072")
                    {
                        div0072.Visible = true;
                    }
                    else
                    {
                        div0072.Visible = false;
                    }
                    if (dataSource.Rows[33]["col2"].ToString() == "1" && dataSource.Rows[33]["col1"].ToString() == "div0073")
                    {
                        div0073.Visible = true;
                    }
                    else
                    {
                        div0073.Visible = false;
                    }
                    if (dataSource.Rows[34]["col2"].ToString() == "1" && dataSource.Rows[34]["col1"].ToString() == "div0074")
                    {
                        div0074.Visible = true;
                    }
                    else
                    {
                        div0074.Visible = false;
                    }
                    if (dataSource.Rows[35]["col2"].ToString() == "1" && dataSource.Rows[35]["col1"].ToString() == "div0075")
                    {
                        div0075.Visible = true;
                    }
                    else
                    {
                        div0075.Visible = false;
                    }
                    if (dataSource.Rows[36]["col2"].ToString() == "1" && dataSource.Rows[36]["col1"].ToString() == "div0076")
                    {
                        div0076.Visible = true;
                    }
                    else
                    {
                        div0076.Visible = false;
                    }
                    if (dataSource.Rows[37]["col2"].ToString() == "1" && dataSource.Rows[37]["col1"].ToString() == "div0077")
                    {
                        div0077.Visible = true;
                    }
                    else
                    {
                        div0077.Visible = false;
                    }

                   
                    //if (dataSource.Rows[38]["col2"].ToString() == "1" && dataSource.Rows[38]["col1"].ToString() == "div009")
                    //{
                    //    div009.Visible = true;
                    //}
                    //else
                    //{
                    //    div009.Visible = false;
                    //}
                    if (dataSource.Rows[39]["col2"].ToString() == "1" && dataSource.Rows[39]["col1"].ToString() == "div0091")
                    {
                        div0091.Visible = true;
                    }
                    else
                    {
                        div0091.Visible = false;
                    }
                    if (dataSource.Rows[40]["col2"].ToString() == "1" && dataSource.Rows[40]["col1"].ToString() == "div0092")
                    {
                        div0092.Visible = true;
                    }
                    else
                    {
                        div0092.Visible = false;
                    }
                    if (dataSource.Rows[41]["col2"].ToString() == "1" && dataSource.Rows[41]["col1"].ToString() == "div0093")
                    {
                        div0093.Visible = true;
                    }
                    else
                    {
                        div0093.Visible = false;
                    }
                    if (dataSource.Rows[42]["col2"].ToString() == "1" && dataSource.Rows[42]["col1"].ToString() == "div0094")
                    {
                        div0094.Visible = true;
                    }
                    else
                    {
                        div0094.Visible = false;
                    }
                    if (dataSource.Rows[43]["col2"].ToString() == "1" && dataSource.Rows[43]["col1"].ToString() == "div0095")
                    {
                        div0095.Visible = true;
                    }
                    else
                    {
                        div0095.Visible = false;
                    }
                    if (dataSource.Rows[44]["col2"].ToString() == "1" && dataSource.Rows[44]["col1"].ToString() == "div0096")
                    {
                        div0096.Visible = true;
                    }
                    else
                    {
                        div0096.Visible = false;
                    }
                    
                    
                    
                    //for (int i = 0; i < dataSource.Rows.Count; i++)
                    //{
                        


                    //}

                }
                else
                {
                    //div001.Visible = false;
                    div002.Visible = false;
                    div0021.Visible = false;
                    div0022.Visible = false;
                    div0023.Visible = false;
                    div003.Visible = false;
                    div0031.Visible = false;
                    div0032.Visible = false;
                    div0033.Visible = false;
                    div004.Visible = false;
                    div0041.Visible = false;
                    div0042.Visible = false;
                    div0043.Visible = false;
                    div0044.Visible = false;
                    div0045.Visible = false;
                    div005.Visible = false;
                    div0051.Visible = false;
                    div0052.Visible = false;
                    div0053.Visible = false;
                    div0054.Visible = false;
                    div006.Visible = false;
                    div0061.Visible = false;
                    div0062.Visible = false;
                    div0063.Visible = false;
                    div0064.Visible = false;
                    div0065.Visible = false;
                    //div0066.Visible = false;
                    div0067.Visible = false;
                    div007.Visible = false;
                    div0071.Visible = false;
                    div0072.Visible = false;
                    div0073.Visible = false;
                    div0074.Visible = false;
                    div0075.Visible = false;
                    div0076.Visible = false;
                    div0077.Visible = false;
                    //div0068.Visible = false;
                    div0055.Visible = false;
                    div0034.Visible = false;
                    div0046.Visible = false;

                    //div009.Visible = false;
                    div0091.Visible = false;
                    div0092.Visible = false;
                    div0093.Visible = false;
                    div0094.Visible = false;
                    div0095.Visible = false;
                    div0096.Visible = false;


                    div0001.Visible = false;
                    div0002.Visible = false;
                    div0003.Visible = false;
                    div0004.Visible = false;
                    div0005.Visible = false;
                    div0006.Visible = false;
                    div0007.Visible = false;
                    div替换1.Visible = true;
                    div替换2.Visible = true;
                    div替换3.Visible = true;
                    div替换4.Visible = true;
                    div替换5.Visible = true;
                    div替换6.Visible = true;

                }

                if (this.Session["RoleValue"].ToString() == "6")
                {
                    div0071.Visible = false;
                    div0072.Visible = false;
                    div0074.Visible = false;
                    div0075.Visible = false;
                    div0076.Visible = false;
                    div0077.Visible = false;
                }


            }
            this.Page.Title = "项目管理系统";

        }

        //private string CreateLanguage()
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    DataTable languageDT = MojoCube.Web.Site.Cache.GetLanguageDT();
        //    if (languageDT.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < languageDT.Rows.Count; i++)
        //        {
        //            if (languageDT.Rows[i]["name"].ToString() == MojoCube.Api.UI.Language.GetLanguage())
        //            {
        //                //this.imgLanguage.ImageUrl = "~/Images/flags/" + languageDT.Rows[i]["icon"].ToString();
        //            }
        //            stringBuilder.Append(string.Concat(new string[]
        //        {
        //            "<a href=\"../../Language.aspx?lang=",
        //            languageDT.Rows[i]["name"].ToString(),
        //            "&url=",
        //            base.Request.Url.ToString(),
        //            "\" class=\"btn btn-default btn-flat\" title=\"",
        //            languageDT.Rows[i]["title"].ToString(),
        //            "\"><img src=\"../../Images/flags/",
        //            languageDT.Rows[i]["icon"].ToString(),
        //            "\" alt=\"",
        //            languageDT.Rows[i]["title"].ToString(),
        //            "\" /></a>"
        //        }));
        //            stringBuilder.Append(" ");
        //        }
        //    }
        //    return stringBuilder.ToString();
        //}

        //private string CreateHistory(int showHistory)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    DataTable dataTable = new DataTable();
        //    dataTable = Sql.SqlQueryDS(string.Concat(new object[]
        //{
        //    "select top ",
        //    showHistory,
        //    " * from View_MyHistory where fk_User=",
        //    base.Session["UserID"].ToString(),
        //    " and TypeID=0 order by CreateDate desc"
        //})).Tables[0];
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            stringBuilder.Append("<li>");
        //            stringBuilder.Append("<a href=\"../../" + dataTable.Rows[i]["Url"].ToString() + "\">");
        //            stringBuilder.Append("<span class=\"control-sidebar-subheading\">" + dataTable.Rows[i]["Title"].ToString() + "</span>");
        //            stringBuilder.Append("<small>" + DateTime.Parse(dataTable.Rows[i]["CreateDate"].ToString()).ToString("MM-dd HH:mm") + "</small>");
        //            stringBuilder.Append("</a>");
        //            stringBuilder.Append("</li>");
        //        }
        //    }
        //    return stringBuilder.ToString();
        //}

        //protected void lnbSearch_Click(object sender, EventArgs e)
        //{
        //    this.LeftMenu.InnerHtml = this.CreateLeftMenu();
        //}

        //private string CreateLeftMenu()
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    DataTable dataTable = new DataTable();
        //    OledbHelper oledbHelper = new OledbHelper();
        //    dataTable = oledbHelper.GetDataTable("select * from View_Menu where fk_RoleName=? and IsUse=True and TypeID=0 and Visible=True and (Name_CHS like '%'+?+'%' or Tag_CHS like '%'+?+'%') order by SortID asc", new object[]
        //{
        //    base.Session["RoleValue"].ToString(),
        //    "",
        //    ""
        //});
        //    stringBuilder.Append("<ul class=\"sidebar-menu\">");
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        string a = "";
        //        string a2 = "";
        //        if (base.Request.QueryString["active"] != null)
        //        {
        //            try
        //            {
        //                string[] array = base.Request.QueryString["active"].ToString().Trim().Split(new char[]
        //            {
        //                ','
        //            });
        //                if (array.Length > 1)
        //                {
        //                    a = array[0];
        //                    a2 = array[1];
        //                }
        //                else
        //                {
        //                    a = array[0];
        //                }
        //            }
        //            catch
        //            {
        //            }
        //        }
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            if (dataTable.Rows[i]["ParentID"].ToString() == "0")
        //            {
        //                DataRow[] array2 = dataTable.Select("ParentID=" + dataTable.Rows[i]["pk_Menu"].ToString());
        //                if (array2.Length > 0)
        //                {
        //                    if (a == dataTable.Rows[i]["pk_Menu"].ToString())
        //                    {
        //                        stringBuilder.Append("<li class=\"active treeview\">");
        //                    }
        //                    else
        //                    {
        //                        stringBuilder.Append("<li class=\"treeview\">");
        //                    }
        //                    stringBuilder.Append(string.Concat(new string[]
        //                {
        //                    "<a href=\"../..",
        //                    dataTable.Rows[i]["Url"].ToString(),
        //                    "?active=",
        //                    dataTable.Rows[i]["pk_Menu"].ToString(),
        //                    "\"><i class=\"fa ",
        //                    dataTable.Rows[i]["Icon"].ToString(),
        //                    "\"></i> <span>",
        //                    dataTable.Rows[i]["Name_CHS"].ToString(),
        //                    "</span> <i class=\"fa fa-angle-left pull-right\"></i></a>"
        //                }));
        //                    stringBuilder.Append("<ul class=\"treeview-menu\">");
        //                    for (int j = 0; j < array2.Length; j++)
        //                    {
        //                        if (a2 == array2[j]["pk_Menu"].ToString())
        //                        {
        //                            stringBuilder.Append("<li class=\"active\">");
        //                        }
        //                        else
        //                        {
        //                            stringBuilder.Append("<li>");
        //                        }
        //                        stringBuilder.Append(string.Concat(new string[]
        //                    {
        //                        "<a href=\"../..",
        //                        array2[j]["Url"].ToString(),
        //                        "?active=",
        //                        array2[j]["ParentID"].ToString(),
        //                        ",",
        //                        array2[j]["pk_Menu"].ToString(),
        //                        "\"><i class=\"fa ",
        //                        array2[j]["Icon"].ToString(),
        //                        "\"></i> ",
        //                        array2[j]["Name_CHS"].ToString(),
        //                        "</a></li>"
        //                    }));
        //                    }
        //                    stringBuilder.Append("</ul>");
        //                    stringBuilder.Append("</li>");
        //                }
        //                else
        //                {
        //                    if (a == dataTable.Rows[i]["pk_Menu"].ToString())
        //                    {
        //                        stringBuilder.Append("<li class=\"active\">");
        //                    }
        //                    else
        //                    {
        //                        stringBuilder.Append("<li>");
        //                    }
        //                    stringBuilder.Append(string.Concat(new string[]
        //                {
        //                    "<a href=\"../..",
        //                    dataTable.Rows[i]["Url"].ToString(),
        //                    "?active=",
        //                    dataTable.Rows[i]["pk_Menu"].ToString(),
        //                    "\"><i class=\"fa ",
        //                    dataTable.Rows[i]["Icon"].ToString(),
        //                    "\"></i> <span>",
        //                    dataTable.Rows[i]["Name_CHS"].ToString(),
        //                    "</span></a></li>"
        //                }));
        //                }
        //            }
        //        }
        //    }
        //    stringBuilder.Append("</ul>");
        //    return stringBuilder.ToString();
        //}
    }
}