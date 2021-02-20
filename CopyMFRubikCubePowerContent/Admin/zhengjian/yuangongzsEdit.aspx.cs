using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.IO;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace CopyMFRubikCubePowerContent.Admin.zhengjian
{
    public partial class yuangongzsEdit : MyPage, IRequiresSessionState
    {
        private static string puserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (!base.IsPostBack)
            {
                getDrop职务();
                getDrop州市();
                getDrop所属项目部();
                getDrop专业();
                getDrop民族();

                puserID = base.Session["RoleValue"].ToString();
                this.hlBack.NavigateUrl = "yuangongzs.aspx?active=" + base.Request.QueryString["active"];
                this.hlBack2.NavigateUrl = "yuangongzs.aspx?active=" + base.Request.QueryString["active"];

                //TextBox个人基本资料储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox学历信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox劳动合同信息储存位置ht.Attributes.Add("readOnly", "readOnly");
                //TextBox通信类ABC证书信息储存位置ABC.Attributes.Add("readOnly", "readOnly");
                //TextBox通信类职称证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox通信类概预算证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox建筑类ABC证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox一级建造师证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox二级建造师证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox建筑类职称证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox建筑类技术工种证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox通信类技术工种证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox特种作业证书信息储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox其他证书1储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox其他证书2储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox其他证书3储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox其他证书4储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox其他证书5储存位置.Attributes.Add("readOnly", "readOnly");

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    string weizhi = "";
                    if (base.Request.QueryString["id"] != null)
                    {
                        weizhi = base.Request.QueryString["weizhi"].ToString();
                    }
                        
                    this.ViewState["pk_User"] = id;
                    DataSet ds = Sql.SqlQueryDS("select * from yuangongzs where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        if (ds.Tables[0].Rows[0]["ImagePath1"].ToString() != "")
                        {
                            string text = "../Files.aspx?image=" + Security.EncryptString(ds.Tables[0].Rows[0]["ImagePath1"].ToString());
                            this.lblThumbnail.Text = string.Concat(new string[]
				                {
					                "<a href=\"",
					                text,
					                "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"",
					                ds.Tables[0].Rows[0]["name"].ToString(),
					                "\"><img src=\"",
					                text,
					                "&cut=50,50\" class=\"img-circle\" style=\"width:100px; height:100px;\" /></a>"
				                });
                            this.imgPortrait.ImageUrl = string.Concat(new string[]
				                {
					                "<a href=\"",
					                text,
					                "\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"",
					                ds.Tables[0].Rows[0]["name"].ToString(),
					                "\"><img src=\"",
					                text,
					                "&cut=50,50\" class=\"img-circle\" style=\"width:100px; height:100px;\" /></a>"
				                });
                            this.imgPortrait.ImageUrl = "~/Files/" + ds.Tables[0].Rows[0]["ImagePath1"].ToString();
                            //this.imgPortrait.ImageUrl = "~/Files.aspx?image=" + ds.Tables[0].Rows[0]["ImagePath1"].ToString() + "&cut=200,200";
                        }
                       

                        TexttBox姓名.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        Drop州市.Text = ds.Tables[0].Rows[0]["zhousi"].ToString();
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["xiangmu"].ToString();
                        Drop职务.Text = ds.Tables[0].Rows[0]["zhiwu"].ToString();
                        Drop民族.Text = ds.Tables[0].Rows[0]["minzu"].ToString();
                        TextBox身份证号.Text = ds.Tables[0].Rows[0]["sno"].ToString();
                        TextBox出生日期.Text = ds.Tables[0].Rows[0]["sdate"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["sdate"].ToString()).ToString("yyyy-MM-dd");
                        TexttBox年龄.Text = ds.Tables[0].Rows[0]["nianli"].ToString();
                        TextBox户籍所在地.Text = ds.Tables[0].Rows[0]["address"].ToString();
                        Drop性别.Text = ds.Tables[0].Rows[0]["sex"].ToString();
                        TextBox有效日期.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["youxiaodate"].ToString()).ToString("yyyy-MM-dd");
                        TextBox个人基本资料储存位置.Text = ds.Tables[0].Rows[0]["shenfenweizhi"].ToString();

                        TextBox毕业院校.Text = ds.Tables[0].Rows[0]["school"].ToString();
                        Drop专业.Text = ds.Tables[0].Rows[0]["zhuanye"].ToString();
                        Drop学历.Text = ds.Tables[0].Rows[0]["xueli"].ToString();
                        TextBox毕业时间.Text = ds.Tables[0].Rows[0]["biyedate"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["biyedate"].ToString()).ToString("yyyy-MM-dd"); 

                        Dropdownlist学历真假.Text = ds.Tables[0].Rows[0]["xueliflag"].ToString();
                        Dropdownlist有无原件.Text = ds.Tables[0].Rows[0]["yuanjianflag"].ToString();
                        TextBox学历信息储存位置.Text = ds.Tables[0].Rows[0]["xueliweizhi"].ToString();

                        TextBox合同签订日期ht.Text = ds.Tables[0].Rows[0]["hetongcol1"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["hetongcol1"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox合同年限ht.Text = ds.Tables[0].Rows[0]["hetongcol2"].ToString();
                        TextBox合同到期日期ht.Text = ds.Tables[0].Rows[0]["hetongcol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["hetongcol3"].ToString()).ToString("yyyy-MM-dd");

                        TextBox续签日期ht.Text = ds.Tables[0].Rows[0]["hetongcol4"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["hetongcol4"].ToString()).ToString("yyyy-MM-dd");
                      
                        TextBox续签年限ht.Text = ds.Tables[0].Rows[0]["hetongcol5"].ToString();
                        Dropdownlist学历真假ht.Text = ds.Tables[0].Rows[0]["hetongcol6"].ToString();
                        Dropdownlist有无原件ht.Text = ds.Tables[0].Rows[0]["hetongcol7"].ToString();
                        TextBox劳动合同信息储存位置ht.Text = ds.Tables[0].Rows[0]["hetongweizhi"].ToString();

                        TextBox证书类型ABC.Text = ds.Tables[0].Rows[0]["txcol1"].ToString();
                        TextBox证书编号ABC.Text = ds.Tables[0].Rows[0]["txcol2"].ToString();
                        TextBox发证日期ABC.Text = ds.Tables[0].Rows[0]["txcol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txcol3"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox有效期ABC.Text = ds.Tables[0].Rows[0]["txcol4"].ToString();
                        TextBox到期时间ABC.Text = ds.Tables[0].Rows[0]["txcol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txcol5"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox发证机关ABC.Text = ds.Tables[0].Rows[0]["txcol6"].ToString();
                        Dropdownlist证书真假ABC.Text = ds.Tables[0].Rows[0]["txcol7"].ToString();
                        Dropdownlist有无原件ABC.Text = ds.Tables[0].Rows[0]["txcol8"].ToString();
                        TextBox通信类ABC证书信息储存位置ABC.Text = ds.Tables[0].Rows[0]["ABCweizhi"].ToString();

                        TextBox证书类型zc.Text = ds.Tables[0].Rows[0]["txzccol1"].ToString();
                        TextBox证书编号zc.Text = ds.Tables[0].Rows[0]["txzccol2"].ToString();
                        TextBox发证日期zc.Text = ds.Tables[0].Rows[0]["txzccol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txzccol3"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox有效期zc.Text = ds.Tables[0].Rows[0]["txzccol4"].ToString();
                        TextBox到期时间zc.Text = ds.Tables[0].Rows[0]["txzccol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txzccol5"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox发证机关zc.Text = ds.Tables[0].Rows[0]["txzccol6"].ToString();
                        Dropdownlist证书真假zc.Text = ds.Tables[0].Rows[0]["txzccol7"].ToString();
                        Dropdownlist有无原件zc.Text = ds.Tables[0].Rows[0]["txzccol8"].ToString();
                        TextBox通信类职称证书信息储存位置.Text = ds.Tables[0].Rows[0]["zhichengweizhi"].ToString();

                        TextBox证书类型ys.Text = ds.Tables[0].Rows[0]["txyscol1"].ToString();
                        TextBox证书编号ys.Text = ds.Tables[0].Rows[0]["txyscol2"].ToString();
                        TextBox发证日期ys.Text = ds.Tables[0].Rows[0]["txyscol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txyscol3"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox有效期ys.Text = ds.Tables[0].Rows[0]["txyscol4"].ToString();
                        TextBox到期时间ys.Text = ds.Tables[0].Rows[0]["txyscol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txyscol5"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox发证机关ys.Text = ds.Tables[0].Rows[0]["txyscol6"].ToString();
                        Dropdownlist证书真假ys.Text = ds.Tables[0].Rows[0]["txyscol7"].ToString();
                        Dropdownlist有无原件ys.Text = ds.Tables[0].Rows[0]["txyscol8"].ToString();
                        TextBox通信类概预算证书信息储存位置.Text = ds.Tables[0].Rows[0]["yusuanweizhi"].ToString();

                        TextBox证书类型jz.Text = ds.Tables[0].Rows[0]["jzABCcol1"].ToString();
                        TextBox证书编号jz.Text = ds.Tables[0].Rows[0]["jzABCcol2"].ToString();
                        TextBox发证日期jz.Text = ds.Tables[0].Rows[0]["jzABCcol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["jzABCcol3"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox有效期jz.Text = ds.Tables[0].Rows[0]["jzABCcol4"].ToString();
                        TextBox到期时间jz.Text = ds.Tables[0].Rows[0]["jzABCcol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["jzABCcol5"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox发证机关jz.Text = ds.Tables[0].Rows[0]["jzABCcol6"].ToString();
                        Dropdownlist证书真假jz.Text = ds.Tables[0].Rows[0]["jzABCcol7"].ToString();
                        Dropdownlist有无原件jz.Text = ds.Tables[0].Rows[0]["jzABCcol8"].ToString();
                        TextBox建筑类ABC证书信息储存位置.Text = ds.Tables[0].Rows[0]["jianzhuABCweizhi"].ToString();

                        TextBox证书类型yj.Text = ds.Tables[0].Rows[0]["yijicol1"].ToString();
                        TextBox证书编号yj.Text = ds.Tables[0].Rows[0]["yijicol2"].ToString();
                        TextBox发证日期yj.Text = ds.Tables[0].Rows[0]["yijicol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["yijicol3"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox有效期yj.Text = ds.Tables[0].Rows[0]["yijicol4"].ToString();
                        TextBox到期时间yj.Text = ds.Tables[0].Rows[0]["yijicol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["yijicol5"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox发证机关yj.Text = ds.Tables[0].Rows[0]["yijicol6"].ToString();
                        Dropdownlist证书真假yj.Text = ds.Tables[0].Rows[0]["yijicol7"].ToString();
                        Dropdownlist有无原件yj.Text = ds.Tables[0].Rows[0]["yijicol8"].ToString();
                        TextBox一级建造师证书信息储存位置.Text = ds.Tables[0].Rows[0]["yijizsweizhi"].ToString();

                        TextBox证书类型ej.Text = ds.Tables[0].Rows[0]["erjicol1"].ToString();
                        TextBox证书编号ej.Text = ds.Tables[0].Rows[0]["erjicol2"].ToString();
                        TextBox发证日期ej.Text = ds.Tables[0].Rows[0]["erjicol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["erjicol3"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox有效期ej.Text = ds.Tables[0].Rows[0]["erjicol4"].ToString();
                        TextBox到期时间ej.Text = ds.Tables[0].Rows[0]["erjicol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["erjicol5"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox发证机关ej.Text = ds.Tables[0].Rows[0]["erjicol6"].ToString();
                        Dropdownlist证书真假ej.Text = ds.Tables[0].Rows[0]["erjicol7"].ToString();
                        Dropdownlist有无原件ej.Text = ds.Tables[0].Rows[0]["erjicol8"].ToString();
                        TextBox二级建造师证书信息储存位置.Text = ds.Tables[0].Rows[0]["erjizsweizhi"].ToString();

                        TextBox证书类型jzzc.Text = ds.Tables[0].Rows[0]["jzzccol1"].ToString();
                        TextBox证书编号jzzc.Text = ds.Tables[0].Rows[0]["jzzccol2"].ToString();
                        TextBox发证日期jzzc.Text = ds.Tables[0].Rows[0]["jzzccol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["jzzccol3"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox有效期jzzc.Text = ds.Tables[0].Rows[0]["jzzccol4"].ToString();
                        TextBox到期时间jzzc.Text = ds.Tables[0].Rows[0]["jzzccol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["jzzccol5"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox发证机关jzzc.Text = ds.Tables[0].Rows[0]["jzzccol6"].ToString();
                        Dropdownlist证书真假jzzc.Text = ds.Tables[0].Rows[0]["jzzccol7"].ToString();
                        Dropdownlist有无原件jzzc.Text = ds.Tables[0].Rows[0]["jzzccol8"].ToString();
                        TextBox建筑类职称证书信息储存位置.Text = ds.Tables[0].Rows[0]["jzzccol9"].ToString();

                        TextBox证书类型jzjs.Text = ds.Tables[0].Rows[0]["jzjscol1"].ToString();
                        TextBox证书编号jzjs.Text = ds.Tables[0].Rows[0]["jzjscol2"].ToString();
                        TextBox发证日期jzjs.Text = ds.Tables[0].Rows[0]["jzjscol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["jzjscol3"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox有效期jzjs.Text = ds.Tables[0].Rows[0]["jzjscol4"].ToString();
                        TextBox到期时间jzjs.Text = ds.Tables[0].Rows[0]["jzjscol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["jzjscol5"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox发证机关jzjs.Text = ds.Tables[0].Rows[0]["jzjscol6"].ToString();
                        Dropdownlist证书真假jzjs.Text = ds.Tables[0].Rows[0]["jzjscol7"].ToString();
                        Dropdownlist有无原件jzjs.Text = ds.Tables[0].Rows[0]["jzjscol8"].ToString();
                        TextBox建筑类技术工种证书信息储存位置.Text = ds.Tables[0].Rows[0]["jzjscol9"].ToString();

                        TextBox证书类型txjs.Text = ds.Tables[0].Rows[0]["txjscol1"].ToString();
                        TextBox证书编号txjs.Text = ds.Tables[0].Rows[0]["txjscol2"].ToString();
                        TextBox发证日期txjs.Text = ds.Tables[0].Rows[0]["txjscol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txjscol3"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox有效期txjs.Text = ds.Tables[0].Rows[0]["txjscol4"].ToString();
                        TextBox到期时间txjs.Text = ds.Tables[0].Rows[0]["txjscol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["txjscol5"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox发证机关txjs.Text = ds.Tables[0].Rows[0]["txjscol6"].ToString();
                        Dropdownlist证书真假txjs.Text = ds.Tables[0].Rows[0]["txjscol7"].ToString();
                        Dropdownlist有无原件txjs.Text = ds.Tables[0].Rows[0]["txjscol8"].ToString();
                        TextBox通信类技术工种证书信息储存位置.Text = ds.Tables[0].Rows[0]["txjscol9"].ToString();

                        TextBox证书类型tz.Text = ds.Tables[0].Rows[0]["tzzycol1"].ToString();
                        TextBox证书编号tz.Text = ds.Tables[0].Rows[0]["tzzycol2"].ToString();
                        TextBox发证日期tz.Text = ds.Tables[0].Rows[0]["tzzycol3"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["tzzycol3"].ToString()).ToString("yyyy-MM-dd");
                       
                        TextBox有效期tz.Text = ds.Tables[0].Rows[0]["tzzycol4"].ToString();
                        TextBox到期时间tz.Text = ds.Tables[0].Rows[0]["tzzycol5"].ToString() == "" ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["tzzycol5"].ToString()).ToString("yyyy-MM-dd");
                        
                        TextBox发证机关tz.Text = ds.Tables[0].Rows[0]["tzzycol6"].ToString();
                        Dropdownlist证书真假tz.Text = ds.Tables[0].Rows[0]["tzzycol7"].ToString();
                        Dropdownlist有无原件tz.Text = ds.Tables[0].Rows[0]["tzzycol8"].ToString();
                        TextBox特种作业证书信息储存位置.Text = ds.Tables[0].Rows[0]["tzzycol9"].ToString();

                        TextBox其他证书1储存位置.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox其他证书2储存位置.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox其他证书3储存位置.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox其他证书4储存位置.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox其他证书5储存位置.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBoxremark.Text = ds.Tables[0].Rows[0]["remark"].ToString();

                        if (TextBox个人基本资料储存位置.Text != "")
                        {
                            个人基本资料href.HRef = TextBox个人基本资料储存位置.Text;
                            个人基本资料href.Visible = true;
                        }
                        if (TextBox学历信息储存位置.Text != "")
                        {
                            学历信息href.HRef = TextBox学历信息储存位置.Text;
                            学历信息href.Visible = true;
                        }
                        if (TextBox劳动合同信息储存位置ht.Text != "")
                        {
                            劳动合同信息href.HRef = TextBox劳动合同信息储存位置ht.Text;
                            劳动合同信息href.Visible = true;
                        }
                        if (TextBox通信类ABC证书信息储存位置ABC.Text != "")
                        {
                            员工通信类ABC证书信息附件href.HRef = TextBox通信类ABC证书信息储存位置ABC.Text;
                            员工通信类ABC证书信息附件href.Visible = true;
                        }

                        if (TextBox通信类职称证书信息储存位置.Text != "")
                        {
                            通信类职称证书信息href.HRef = TextBox通信类职称证书信息储存位置.Text;
                            通信类职称证书信息href.Visible = true;
                        }
                        if (TextBox通信类概预算证书信息储存位置.Text != "")
                        {
                            通信类概预算证书信息href.HRef = TextBox通信类概预算证书信息储存位置.Text;
                            通信类概预算证书信息href.Visible = true;
                        }
                        if (TextBox建筑类ABC证书信息储存位置.Text != "")
                        {
                            建筑类ABC证书信息href.HRef = TextBox建筑类ABC证书信息储存位置.Text;
                            建筑类ABC证书信息href.Visible = true;
                        }
                        if (TextBox一级建造师证书信息储存位置.Text != "")
                        {
                            一级建造师证书信息href.HRef = TextBox一级建造师证书信息储存位置.Text;
                            一级建造师证书信息href.Visible = true;
                        }
                        if (TextBox二级建造师证书信息储存位置.Text != "")
                        {
                            二级建造师证书信息href.HRef = TextBox二级建造师证书信息储存位置.Text;
                            二级建造师证书信息href.Visible = true;
                        }
                        if (TextBox建筑类职称证书信息储存位置.Text != "")
                        {
                            建筑类职称证书信息href.HRef = TextBox建筑类职称证书信息储存位置.Text;
                            建筑类职称证书信息href.Visible = true;
                        }
                        if (TextBox建筑类技术工种证书信息储存位置.Text != "")
                        {
                            建筑类技术工种证书信息href.HRef = TextBox建筑类技术工种证书信息储存位置.Text;
                            建筑类技术工种证书信息href.Visible = true;
                        }

                        if (TextBox通信类技术工种证书信息储存位置.Text != "")
                        {
                            通信类技术工种证书信息href.HRef = TextBox通信类技术工种证书信息储存位置.Text;
                            通信类技术工种证书信息href.Visible = true;
                        }
                        if (TextBox特种作业证书信息储存位置.Text != "")
                        {
                            特种作业证书信息href.HRef = TextBox特种作业证书信息储存位置.Text;
                            特种作业证书信息href.Visible = true;
                        }

                        if (TextBox其他证书1储存位置.Text != "")
                        {
                            其他证书1信息证件href.HRef = TextBox其他证书1储存位置.Text;
                            其他证书1信息证件href.Visible = true;
                        }
                        if (TextBox其他证书2储存位置.Text != "")
                        {
                            其他证书2信息证件href.HRef = TextBox其他证书2储存位置.Text;
                            其他证书2信息证件href.Visible = true;
                        }
                        if (TextBox其他证书3储存位置.Text != "")
                        {
                            其他证书3信息证件href.HRef = TextBox其他证书3储存位置.Text;
                            其他证书3信息证件href.Visible = true;
                        }
                        if (TextBox其他证书4储存位置.Text != "")
                        {
                            其他证书4信息证件href.HRef = TextBox其他证书4储存位置.Text;
                            其他证书4信息证件href.Visible = true;
                        }
                        if (TextBox其他证书5储存位置.Text != "")
                        {
                            其他证书5信息证件href.HRef = TextBox其他证书5储存位置.Text;
                            其他证书5信息证件href.Visible = true;
                        }

                        DataSet ds_1 = Sql.SqlQueryDS("select * from yuangongzs_1 where sid=" + id + "");
                        if (ds_1 != null && ds.Tables[0] != null && ds_1.Tables[0].Rows.Count > 0)
                        {
                            TextBox证书类型qita01.Text = ds_1.Tables[0].Rows[0]["qita1col1"].ToString();
                            TextBox证书编号qita01.Text = ds_1.Tables[0].Rows[0]["qita2col1"].ToString();
                            TextBox发证日期qita01.Text = ds_1.Tables[0].Rows[0]["qita3col1"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita3col1"].ToString()).ToString("yyyy-MM-dd");
                            
                            TextBox有效期qita01.Text = ds_1.Tables[0].Rows[0]["qita4col1"].ToString();
                            TextBox到期时间qita01.Text = ds_1.Tables[0].Rows[0]["qita5col1"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita5col1"].ToString()).ToString("yyyy-MM-dd");
                           
                            TextBox发证机关qita01.Text = ds_1.Tables[0].Rows[0]["qita6col1"].ToString();
                            Dropdownlist证书真假qita01.Text = ds_1.Tables[0].Rows[0]["qita7col1"].ToString();
                            Dropdownlist有无原件qita01.Text = ds_1.Tables[0].Rows[0]["qita8col1"].ToString();

                            TextBox证书类型qita02.Text = ds_1.Tables[0].Rows[0]["qita1col2"].ToString();
                            TextBox证书编号qita02.Text = ds_1.Tables[0].Rows[0]["qita2col2"].ToString();
                            TextBox发证日期qita02.Text = ds_1.Tables[0].Rows[0]["qita3col2"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita3col2"].ToString()).ToString("yyyy-MM-dd");
                           
                            TextBox有效期qita02.Text = ds_1.Tables[0].Rows[0]["qita4col2"].ToString();
                            TextBox到期时间qita02.Text = ds_1.Tables[0].Rows[0]["qita5col2"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita5col2"].ToString()).ToString("yyyy-MM-dd");
                            
                            TextBox发证机关qita02.Text = ds_1.Tables[0].Rows[0]["qita6col2"].ToString();
                            Dropdownlist证书真假qita02.Text = ds_1.Tables[0].Rows[0]["qita7col2"].ToString();
                            Dropdownlist有无原件qita02.Text = ds_1.Tables[0].Rows[0]["qita8col2"].ToString();

                            TextBox证书类型qita03.Text = ds_1.Tables[0].Rows[0]["qita1col3"].ToString();
                            TextBox证书编号qita03.Text = ds_1.Tables[0].Rows[0]["qita2col3"].ToString();
                            TextBox发证日期qita03.Text = ds_1.Tables[0].Rows[0]["qita3col3"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita3col3"].ToString()).ToString("yyyy-MM-dd");
                            
                            TextBox有效期qita03.Text = ds_1.Tables[0].Rows[0]["qita4col3"].ToString();
                            TextBox到期时间qita03.Text = ds_1.Tables[0].Rows[0]["qita5col3"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita5col3"].ToString()).ToString("yyyy-MM-dd");
                           
                            TextBox发证机关qita03.Text = ds_1.Tables[0].Rows[0]["qita6col3"].ToString();
                            Dropdownlist证书真假qita03.Text = ds_1.Tables[0].Rows[0]["qita7col3"].ToString();
                            Dropdownlist有无原件qita03.Text = ds_1.Tables[0].Rows[0]["qita8col3"].ToString();

                            TextBox证书类型qita04.Text = ds_1.Tables[0].Rows[0]["qita1col4"].ToString();
                            TextBox证书编号qita04.Text = ds_1.Tables[0].Rows[0]["qita2col4"].ToString();
                            TextBox发证日期qita04.Text = ds_1.Tables[0].Rows[0]["qita3col4"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita3col4"].ToString()).ToString("yyyy-MM-dd");
                           
                            TextBox有效期qita04.Text = ds_1.Tables[0].Rows[0]["qita4col4"].ToString();
                            TextBox到期时间qita04.Text = ds_1.Tables[0].Rows[0]["qita5col4"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita5col4"].ToString()).ToString("yyyy-MM-dd");
                           
                            TextBox发证机关qita04.Text = ds_1.Tables[0].Rows[0]["qita6col4"].ToString();
                            Dropdownlist证书真假qita04.Text = ds_1.Tables[0].Rows[0]["qita7col4"].ToString();
                            Dropdownlist有无原件qita04.Text = ds_1.Tables[0].Rows[0]["qita8col4"].ToString();


                            TextBox证书类型qita05.Text = ds_1.Tables[0].Rows[0]["qita1col5"].ToString();
                            TextBox证书编号qita05.Text = ds_1.Tables[0].Rows[0]["qita2col5"].ToString();
                            TextBox发证日期qita05.Text = ds_1.Tables[0].Rows[0]["qita3col5"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita3col5"].ToString()).ToString("yyyy-MM-dd");
                            
                            TextBox有效期qita05.Text = ds_1.Tables[0].Rows[0]["qita4col5"].ToString();
                            TextBox到期时间qita05.Text = ds_1.Tables[0].Rows[0]["qita5col5"].ToString() == "" ? "" : Convert.ToDateTime(ds_1.Tables[0].Rows[0]["qita5col5"].ToString()).ToString("yyyy-MM-dd");
                            
                            TextBox发证机关qita05.Text = ds_1.Tables[0].Rows[0]["qita6col5"].ToString();
                            Dropdownlist证书真假qita05.Text = ds_1.Tables[0].Rows[0]["qita7col5"].ToString();
                            Dropdownlist有无原件qita05.Text = ds_1.Tables[0].Rows[0]["qita8col5"].ToString();
                        }

                        

                        switch (weizhi)
                        {

                            case "lbtn身份证信息":
                                TextBox个人基本资料储存位置.Focus();
                                break;
                            case "lbtn学历信息":
                                TextBox学历信息储存位置.Focus();
                                break;
                            case "lbtn劳动合同信息":
                                TextBox劳动合同信息储存位置ht.Focus();
                                break;
                            case "lbtn通信类ABC证书信息":
                                TextBox通信类ABC证书信息储存位置ABC.Focus();
                                break;
                            case "lbtn通信类职称证书信息":
                                TextBox通信类职称证书信息储存位置.Focus();
                                break;
                            case "lbtn通信类概预算证书信息":
                                TextBox通信类概预算证书信息储存位置.Focus();
                                break;
                            case "lbtn建筑类ABC证书信息":
                                TextBox建筑类ABC证书信息储存位置.Focus();
                                break;
                            case "lbtn一级建造师证书信息":
                                TextBox一级建造师证书信息储存位置.Focus();
                                break;
                            case "lbtn二级建造师证书信息":
                                TextBox二级建造师证书信息储存位置.Focus();
                                break;
                            case "lbtn建筑类职称证书信息":
                                TextBox建筑类职称证书信息储存位置.Focus();
                                break;
                            case "lbtn建筑类技术工种证书信息":
                                TextBox建筑类技术工种证书信息储存位置.Focus();
                                break;
                            case "lbtn通信类技术工种证书信息":
                                TextBox通信类技术工种证书信息储存位置.Focus();
                                break;
                            case "lbtn特种作业证书信息":
                                TextBox特种作业证书信息储存位置.Focus();
                                break;
                            case "lbtn其他证书1信息":
                                TextBox其他证书1储存位置.Focus();
                                break;
                            case "lbtn其他证书2信息":
                                TextBox其他证书2储存位置.Focus();
                                break;
                            case "lbtn其他证书3信息":
                                TextBox其他证书3储存位置.Focus();
                                break;
                            case "lbtn其他证书4信息":
                                TextBox其他证书4储存位置.Focus();
                                break;
                            case "lbtn其他证书5信息":
                                TextBox其他证书5储存位置.Focus();
                                break;

                        }

                    }

                    if (puserID != "1")
                    {
                        TexttBox姓名.ReadOnly = true;
                        Drop州市.Enabled = false;
                        Drop所属项目部.Enabled = false;
                        Drop职务.Enabled = false;
                        Drop民族.Enabled = false;
                        TextBox身份证号.ReadOnly = true;
                        TextBox出生日期.Enabled = false;
                        TexttBox年龄.ReadOnly = true;
                        TextBox户籍所在地.ReadOnly = true;
                        Drop性别.Enabled = false;
                        TextBox有效日期.Enabled = false;
                        TextBox个人基本资料储存位置.ReadOnly = true;

                        TextBox毕业院校.ReadOnly = true;
                        Drop专业.Enabled = false;
                        Drop学历.Enabled = false;
                        TextBox毕业时间.Enabled = false;

                        Dropdownlist学历真假.Enabled = false;
                        Dropdownlist有无原件.Enabled = false;
                        TextBox学历信息储存位置.ReadOnly = true;

                        TextBox合同签订日期ht.Enabled = false;

                        TextBox合同年限ht.ReadOnly = true;
                        TextBox合同到期日期ht.Enabled = false;
                        TextBox续签日期ht.Enabled = false;
                        TextBox续签年限ht.ReadOnly = true;
                        Dropdownlist学历真假ht.Enabled = false;
                        Dropdownlist有无原件ht.Enabled = false;
                        TextBox劳动合同信息储存位置ht.ReadOnly = true;

                        TextBox证书类型ABC.ReadOnly = true;
                        TextBox证书编号ABC.ReadOnly = true;
                        TextBox发证日期ABC.Enabled = false;

                        TextBox有效期ABC.ReadOnly = true;
                        TextBox到期时间ABC.Enabled = false;

                        TextBox发证机关ABC.ReadOnly = true;
                        Dropdownlist证书真假ABC.Enabled = false;
                        Dropdownlist有无原件ABC.Enabled = false;
                        TextBox通信类ABC证书信息储存位置ABC.ReadOnly = true;

                        TextBox证书类型zc.ReadOnly = true;
                        TextBox证书编号zc.ReadOnly = true;
                        TextBox发证日期zc.Enabled = false;

                        TextBox有效期zc.ReadOnly = true;
                        TextBox到期时间zc.Enabled = false;

                        TextBox发证机关zc.ReadOnly = true;
                        Dropdownlist证书真假zc.Enabled = false;
                        Dropdownlist有无原件zc.Enabled = false;
                        TextBox通信类职称证书信息储存位置.ReadOnly = true;

                        TextBox证书类型ys.ReadOnly = true;
                        TextBox证书编号ys.ReadOnly = true;
                        TextBox发证日期ys.Enabled = false;

                        TextBox有效期ys.ReadOnly = true;
                        TextBox到期时间ys.Enabled = false;

                        TextBox发证机关ys.ReadOnly = true;
                        Dropdownlist证书真假ys.Enabled = false;
                        Dropdownlist有无原件ys.Enabled = false;
                        TextBox通信类概预算证书信息储存位置.ReadOnly = true;

                        TextBox证书类型jz.ReadOnly = true;
                        TextBox证书编号jz.ReadOnly = true;
                        TextBox发证日期jz.Enabled = false;
                        TextBox有效期jz.ReadOnly = true;
                        TextBox到期时间jz.Enabled = false;

                        TextBox发证机关jz.ReadOnly = true;
                        Dropdownlist证书真假jz.Enabled = false;
                        Dropdownlist有无原件jz.Enabled = false;
                        TextBox建筑类ABC证书信息储存位置.ReadOnly = true;

                        TextBox证书类型yj.ReadOnly = true;
                        TextBox证书编号yj.ReadOnly = true;
                        TextBox发证日期yj.Enabled = false;

                        TextBox有效期yj.ReadOnly = true;
                        TextBox到期时间yj.Enabled = false;

                        TextBox发证机关yj.ReadOnly = true;
                        Dropdownlist证书真假yj.Enabled = false;
                        Dropdownlist有无原件yj.Enabled = false;
                        TextBox一级建造师证书信息储存位置.ReadOnly = true;

                        TextBox证书类型ej.ReadOnly = true;
                        TextBox证书编号ej.ReadOnly = true;
                        TextBox发证日期ej.Enabled = false;

                        TextBox有效期ej.ReadOnly = true;
                        TextBox到期时间ej.Enabled = false;

                        TextBox发证机关ej.ReadOnly = true;
                        Dropdownlist证书真假ej.Enabled = false;
                        Dropdownlist有无原件ej.Enabled = false;
                        TextBox二级建造师证书信息储存位置.ReadOnly = true;

                        TextBox证书类型jzzc.ReadOnly = true;
                        TextBox证书编号jzzc.ReadOnly = true;
                        TextBox发证日期jzzc.Enabled = false;

                        TextBox有效期jzzc.ReadOnly = true;
                        TextBox到期时间jzzc.Enabled = false;

                        TextBox发证机关jzzc.ReadOnly = true;
                        Dropdownlist证书真假jzzc.Enabled = false;
                        Dropdownlist有无原件jzzc.Enabled = false;
                        TextBox建筑类职称证书信息储存位置.ReadOnly = true;

                        TextBox证书类型jzjs.ReadOnly = true;
                        TextBox证书编号jzjs.ReadOnly = true;
                        TextBox发证日期jzjs.Enabled = false;

                        TextBox有效期jzjs.ReadOnly = true;
                        TextBox到期时间jzjs.Enabled = false;

                        TextBox发证机关jzjs.ReadOnly = true;
                        Dropdownlist证书真假jzjs.Enabled = false;
                        Dropdownlist有无原件jzjs.Enabled = false;
                        TextBox建筑类技术工种证书信息储存位置.ReadOnly = true;

                        TextBox证书类型txjs.ReadOnly = true;
                        TextBox证书编号txjs.ReadOnly = true;
                        TextBox发证日期txjs.Enabled = false;

                        TextBox有效期txjs.ReadOnly = true;
                        TextBox到期时间txjs.Enabled = false;

                        TextBox发证机关txjs.ReadOnly = true;
                        Dropdownlist证书真假txjs.Enabled = false;
                        Dropdownlist有无原件txjs.Enabled = false;
                        TextBox通信类技术工种证书信息储存位置.ReadOnly = true;

                        TextBox证书类型tz.ReadOnly = true;
                        TextBox证书编号tz.ReadOnly = true;
                        TextBox发证日期tz.Enabled = false;

                        TextBox有效期tz.ReadOnly = true;
                        TextBox到期时间tz.Enabled = false;

                        TextBox发证机关tz.ReadOnly = true;
                        Dropdownlist证书真假tz.Enabled = false;
                        Dropdownlist有无原件tz.Enabled = false;
                        TextBox特种作业证书信息储存位置.ReadOnly = true;

                        TextBox其他证书1储存位置.ReadOnly = true;
                        TextBox其他证书2储存位置.ReadOnly = true;
                        TextBox其他证书3储存位置.ReadOnly = true;
                        TextBox其他证书4储存位置.ReadOnly = true;
                        TextBox其他证书5储存位置.ReadOnly = true;

                        TextBox证书类型qita01.ReadOnly = true;
                        TextBox证书编号qita01.ReadOnly = true;
                        TextBox发证日期qita01.Enabled = false;
                        TextBox有效期qita01.ReadOnly = true;
                        TextBox到期时间qita01.Enabled = false;
                        TextBox发证机关qita01.ReadOnly = true;
                        Dropdownlist证书真假qita01.Enabled = false;
                        Dropdownlist有无原件qita01.Enabled = false;

                        TextBox证书类型qita02.ReadOnly = true;
                        TextBox证书编号qita02.ReadOnly = true;
                        TextBox发证日期qita02.Enabled = false;
                        TextBox有效期qita02.ReadOnly = true;
                        TextBox到期时间qita02.Enabled = false;
                        TextBox发证机关qita02.ReadOnly = true;
                        Dropdownlist证书真假qita02.Enabled = false;
                        Dropdownlist有无原件qita02.Enabled = false;

                        TextBox证书类型qita03.ReadOnly = true;
                        TextBox证书编号qita03.ReadOnly = true;
                        TextBox发证日期qita03.Enabled = false;
                        TextBox有效期qita03.ReadOnly = true;
                        TextBox到期时间qita03.Enabled = false;
                        TextBox发证机关qita03.ReadOnly = true;
                        Dropdownlist证书真假qita03.Enabled = false;
                        Dropdownlist有无原件qita03.Enabled = false;

                        TextBox证书类型qita04.ReadOnly = true;
                        TextBox证书编号qita04.ReadOnly = true;
                        TextBox发证日期qita04.Enabled = false;
                        TextBox有效期qita04.ReadOnly = true;
                        TextBox到期时间qita04.Enabled = false;
                        TextBox发证机关qita04.ReadOnly = true;
                        Dropdownlist证书真假qita04.Enabled = false;
                        Dropdownlist有无原件qita04.Enabled = false;


                        TextBox证书类型qita05.ReadOnly = true;
                        TextBox证书编号qita05.ReadOnly = true;
                        TextBox发证日期qita05.Enabled = false;
                        TextBox有效期qita05.ReadOnly = true;
                        TextBox到期时间qita05.Enabled = false;
                        TextBox发证机关qita05.ReadOnly = true;
                        Dropdownlist证书真假qita05.Enabled = false;
                        Dropdownlist有无原件qita05.Enabled = false;
                        TextBoxremark.ReadOnly = true;
                        fuPortrait.Visible = false;
                        MyFileUpload.Visible = false;
                        Button1.Visible = false;
                        FileUpload学历信息.Visible = false;
                        Button2.Visible = false;
                        FileUpload劳动合同信息.Visible = false;
                        Button劳动合同信息证件.Visible = false;
                        FileUpload员工通信类ABC证书信息.Visible = false;
                        Button通信类ABC证书信息证件.Visible = false;
                        FileUpload通信类职称证书信息证件.Visible = false;
                        Button通信类职称证书信息.Visible = false;
                        FileUpload通信类概预算证书信息.Visible = false;
                        Button通信类概预算证书信息.Visible = false;
                        FileUpload建筑类ABC证书信息.Visible = false;
                        Button3.Visible = false;
                        FileUpload一级建造师证书信息.Visible = false;
                        Button4.Visible = false;
                        FileUpload二级建造师证书信息.Visible = false;
                        Button5.Visible = false;
                        FileUpload建筑类职称证书信息.Visible = false;
                        Button6.Visible = false;
                        FileUpload建筑类技术工种证书信息.Visible = false;
                        Button7.Visible = false;
                        FileUpload通信类技术工种证书信息.Visible = false;
                        Button8.Visible = false;
                        FileUpload特种作业证书信息.Visible = false;
                        Button9.Visible = false;
                        FileUpload其他证书1信息证件.Visible = false;
                        Button10.Visible = false;
                        FileUpload其他证书2信息证件.Visible = false;
                        Button1其他证书2信息证件.Visible = false;
                        FileUpload其他证书3信息证件.Visible = false;
                        Button1其他证书3信息证件.Visible = false;
                        FileUpload其他证书4信息证件.Visible = false;
                        Button其他证书4信息证件.Visible = false;
                        FileUpload其他证书5信息证件.Visible = false;
                        Button1其他证书5信息证件.Visible = false;

                        btnSave.Visible = false;
                        Button11.Visible = false;

                    }

 
                }
            }
        }

        protected void getDrop职务()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from tb_yewustyle where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop职务.DataTextField = "guige";
            Drop职务.DataValueField = "guige";
            Drop职务.DataSource = dataSource;
            Drop职务.DataBind();
            Drop职务.Items.Insert(0, "");

        }

        protected void getDrop州市()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,pinming  from tb_pinzhong where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop州市.DataTextField = "pinming";
            Drop州市.DataValueField = "pinming";
            Drop州市.DataSource = dataSource;
            Drop州市.DataBind();
            Drop州市.Items.Insert(0, "");

        }

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from tb_guige where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop所属项目部.DataTextField = "guige";
            Drop所属项目部.DataValueField = "guige";
            Drop所属项目部.DataSource = dataSource;
            Drop所属项目部.DataBind();
            Drop所属项目部.Items.Insert(0, "");

        }

        protected void getDrop专业()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from zhuanye where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop专业.DataTextField = "guige";
            Drop专业.DataValueField = "guige";
            Drop专业.DataSource = dataSource;
            Drop专业.DataBind();
            Drop专业.Items.Insert(0, "");

        }

        protected void getDrop民族()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from minzu where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop民族.DataTextField = "guige";
            Drop民族.DataValueField = "guige";
            Drop民族.DataSource = dataSource;
            Drop民族.DataBind();
            Drop民族.Items.Insert(0, "");

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.TexttBox姓名.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写姓名");
                return;
            }
            if (this.TextBox出生日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写出生日期");
                return;
            }
            if (this.TextBox身份证号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写身份证号");
                return;
            }
            if (this.TextBox有效日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写身份证号有效日期");
                return;
            }
            if (this.Drop州市.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写州市");
                return;
            }

            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写所属项目部");
                return;
            }
            //if (this.TextBox毕业院校.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写毕业院校");
            //    return;
            //}
            //if (this.Drop专业.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写专业");
            //    return;
            //}
            //if (this.Drop学历.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写学历");
            //    return;
            //}

            yuangongzsList list = new yuangongzsList();
            list.name = this.TexttBox姓名.Text.Trim();
            list.zhousi = this.Drop州市.Text.Trim();
            list.xiangmu = this.Drop所属项目部.Text.Trim();
            list.zhiwu = this.Drop职务.Text.Trim();
            list.minzu = this.Drop民族.Text.Trim();
            list.sno = this.TextBox身份证号.Text.Trim();
            list.sdate = this.TextBox出生日期.Text.Trim();
            list.nianli = this.TexttBox年龄.Text.Trim();
            list.address = this.TextBox户籍所在地.Text.Trim();
            list.sex = this.Drop性别.Text.Trim();
            list.shenfenweizhi = this.TextBox个人基本资料储存位置.Text.Trim();
            list.youxiaodate = TextBox有效日期.Text.Trim();

            list.school = this.TextBox毕业院校.Text.Trim();
            list.zhuanye = this.Drop专业.Text.Trim();
            list.xueli = this.Drop学历.Text.Trim();
            list.biyedate = this.TextBox毕业时间.Text.Trim();

            list.xueliflag = this.Dropdownlist学历真假.Text.Trim();
            list.yuanjianflag = this.Dropdownlist有无原件.Text.Trim();
            list.xueliweizhi = this.TextBox学历信息储存位置.Text.Trim();

            list.hetongcol1 = this.TextBox合同签订日期ht.Text.Trim();

            list.hetongcol2 = this.TextBox合同年限ht.Text.Trim();
            list.hetongcol3 = this.TextBox合同到期日期ht.Text.Trim();
            list.hetongcol4 = this.TextBox续签日期ht.Text.Trim();

            list.hetongcol5 = this.TextBox续签年限ht.Text.Trim();
            list.hetongcol6 = this.Dropdownlist学历真假ht.Text.Trim();
            list.hetongcol7 = this.Dropdownlist有无原件ht.Text.Trim();
            list.hetongweizhi = this.TextBox劳动合同信息储存位置ht.Text.Trim();

            list.txcol1 = this.TextBox证书类型ABC.Text.Trim();
            list.txcol2 = this.TextBox证书编号ABC.Text.Trim();
            list.txcol3 = this.TextBox发证日期ABC.Text.Trim();

            list.txcol4 = this.TextBox有效期ABC.Text.Trim();
            list.txcol5 = this.TextBox到期时间ABC.Text.Trim();

            list.txcol6 = this.TextBox发证机关ABC.Text.Trim();
            list.txcol7 = this.Dropdownlist证书真假ABC.Text.Trim();
            list.txcol8 = this.Dropdownlist有无原件ABC.Text.Trim();
            list.ABCweizhi = this.TextBox通信类ABC证书信息储存位置ABC.Text.Trim();

            list.txzccol1 = this.TextBox证书类型zc.Text.Trim();
            list.txzccol2 = this.TextBox证书编号zc.Text.Trim();
            list.txzccol3 = this.TextBox发证日期zc.Text.Trim();

            list.txzccol4 = this.TextBox有效期zc.Text.Trim();
            list.txzccol5 = this.TextBox到期时间zc.Text.Trim();

            list.txzccol6 = this.TextBox发证机关zc.Text.Trim();
            list.txzccol7 = this.Dropdownlist证书真假zc.Text.Trim();
            list.txzccol8 = this.Dropdownlist有无原件zc.Text.Trim();
            list.zhichengweizhi = this.TextBox通信类职称证书信息储存位置.Text.Trim();

            list.txyscol1 = this.TextBox证书类型ys.Text.Trim();
            list.txyscol2 = this.TextBox证书编号ys.Text.Trim();
            list.txyscol3 = this.TextBox发证日期ys.Text.Trim();

            list.txyscol4 = this.TextBox有效期ys.Text.Trim();
            list.txyscol5 = this.TextBox到期时间ys.Text.Trim();

            list.txyscol6 = this.TextBox发证机关ys.Text.Trim();
            list.txyscol7 = this.Dropdownlist证书真假ys.Text.Trim();
            list.txyscol8 = this.Dropdownlist有无原件ys.Text.Trim();
            list.yusuanweizhi = this.TextBox通信类概预算证书信息储存位置.Text.Trim();

            list.jzABCcol1 = this.TextBox证书类型jz.Text.Trim();
            list.jzABCcol2 = this.TextBox证书编号jz.Text.Trim();
            list.jzABCcol3 = this.TextBox发证日期jz.Text.Trim();
            list.jzABCcol4 = this.TextBox有效期jz.Text.Trim();
            list.jzABCcol5 = this.TextBox到期时间jz.Text.Trim();

            list.jzABCcol6 = this.TextBox发证机关jz.Text.Trim();
            list.jzABCcol7 = this.Dropdownlist证书真假jz.Text.Trim();
            list.jzABCcol8 = this.Dropdownlist有无原件jz.Text.Trim();
            list.jianzhuABCweizhi = this.TextBox建筑类ABC证书信息储存位置.Text.Trim();

            list.yijicol1 = this.TextBox证书类型yj.Text.Trim();
            list.yijicol2 = this.TextBox证书编号yj.Text.Trim();
            list.yijicol3 = this.TextBox发证日期yj.Text.Trim();

            list.yijicol4 = this.TextBox有效期yj.Text.Trim();
            list.yijicol5 = this.TextBox到期时间yj.Text.Trim();

            list.yijicol6 = this.TextBox发证机关yj.Text.Trim();
            list.yijicol7 = this.Dropdownlist证书真假yj.Text.Trim();
            list.yijicol8 = this.Dropdownlist有无原件yj.Text.Trim();
            list.yijizsweizhi = this.TextBox一级建造师证书信息储存位置.Text.Trim();

            list.erjicol1 = this.TextBox证书类型ej.Text.Trim();
            list.erjicol2 = this.TextBox证书编号ej.Text.Trim();
            list.erjicol3 = this.TextBox发证日期ej.Text.Trim();

            list.erjicol4 = this.TextBox有效期ej.Text.Trim();
            list.erjicol5 = this.TextBox到期时间ej.Text.Trim();

            list.erjicol6 = this.TextBox发证机关ej.Text.Trim();
            list.erjicol7 = this.Dropdownlist证书真假ej.Text.Trim();
            list.erjicol8 = this.Dropdownlist有无原件ej.Text.Trim();
            list.erjizsweizhi = this.TextBox二级建造师证书信息储存位置.Text.Trim();

            list.jzzccol1 = this.TextBox证书类型jzzc.Text.Trim();
            list.jzzccol2 = this.TextBox证书编号jzzc.Text.Trim();
            list.jzzccol3 = this.TextBox发证日期jzzc.Text.Trim();

            list.jzzccol4 = this.TextBox有效期jzzc.Text.Trim();
            list.jzzccol5 = this.TextBox到期时间jzzc.Text.Trim();

            list.jzzccol6 = this.TextBox发证机关jzzc.Text.Trim();
            list.jzzccol7 = this.Dropdownlist证书真假jzzc.Text.Trim();
            list.jzzccol8 = this.Dropdownlist有无原件jzzc.Text.Trim();
            list.jzzccol9 = this.TextBox建筑类职称证书信息储存位置.Text.Trim();

            list.jzjscol1 = this.TextBox证书类型jzjs.Text.Trim();
            list.jzjscol2 = this.TextBox证书编号jzjs.Text.Trim();
            list.jzjscol3 = this.TextBox发证日期jzjs.Text.Trim();

            list.jzjscol4 = this.TextBox有效期jzjs.Text.Trim();
            list.jzjscol5 = this.TextBox到期时间jzjs.Text.Trim();

            list.jzjscol6 = this.TextBox发证机关jzjs.Text.Trim();
            list.jzjscol7 = this.Dropdownlist证书真假jzjs.Text.Trim();
            list.jzjscol8 = this.Dropdownlist有无原件jzjs.Text.Trim();
            list.jzjscol9 = this.TextBox建筑类技术工种证书信息储存位置.Text.Trim();

            list.txjscol1 = this.TextBox证书类型txjs.Text.Trim();
            list.txjscol2 = this.TextBox证书编号txjs.Text.Trim();
            list.txjscol3 = this.TextBox发证日期txjs.Text.Trim();

            list.txjscol4 = this.TextBox有效期txjs.Text.Trim();
            list.txjscol5 = this.TextBox到期时间txjs.Text.Trim();

            list.txjscol6 = this.TextBox发证机关txjs.Text.Trim();
            list.txjscol7 = this.Dropdownlist证书真假txjs.Text.Trim();
            list.txjscol8 = this.Dropdownlist有无原件txjs.Text.Trim();
            list.txjscol9 = this.TextBox通信类技术工种证书信息储存位置.Text.Trim();

            list.tzzycol1 = this.TextBox证书类型tz.Text.Trim();
            list.tzzycol2 = this.TextBox证书编号tz.Text.Trim();
            list.tzzycol3 = this.TextBox发证日期tz.Text.Trim();

            list.tzzycol4 = this.TextBox有效期tz.Text.Trim();
            list.tzzycol5 = this.TextBox到期时间tz.Text.Trim();

            list.tzzycol6 = this.TextBox发证机关tz.Text.Trim();
            list.tzzycol7 = this.Dropdownlist证书真假tz.Text.Trim();
            list.tzzycol8 = this.Dropdownlist有无原件tz.Text.Trim();
            list.tzzycol9 = this.TextBox特种作业证书信息储存位置.Text.Trim();


            list.col1 = TextBox其他证书1储存位置.Text.Trim();
            list.col2 = TextBox其他证书2储存位置.Text.Trim();
            list.col3 = TextBox其他证书3储存位置.Text.Trim();
            list.col4 = TextBox其他证书4储存位置.Text.Trim();
            list.col5 = TextBox其他证书5储存位置.Text.Trim();
            list.hunyin = "";
            list.zhengzhi = "";
            list.remark = TextBoxremark.Text.Trim();
            list.ImagePath1 = string.Empty;

            Upload upload = new Upload();
            upload.FilePath = "User/";
            upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
            upload.DoFileUpload(this.fuPortrait);
            if (upload.IsUpload)
            {
                list.ImagePath1 = upload.OldFilePath;
            }
            else
            {
                list.ImagePath1 = this.imgPortrait.ImageUrl.Replace("~/Files/", "");
            }

            if (base.Request.QueryString["id"] != null)
            {

                list.ID = int.Parse(base.Request.QueryString["id"]);
                if (list.UpdateData() > 0)
                {
                    
                    yuangongzsList1 list1 = new yuangongzsList1();

                    list1.sID = list.ID;
                    list1.qita1col1 = TextBox证书类型qita01.Text.Trim();
                    list1.qita2col1 = TextBox证书编号qita01.Text.Trim();
                    list1.qita3col1 = TextBox发证日期qita01.Text.Trim();
                    list1.qita4col1 = TextBox有效期qita01.Text.Trim();
                    list1.qita5col1 = TextBox到期时间qita01.Text.Trim();
                    list1.qita6col1 = TextBox发证机关qita01.Text.Trim();
                    list1.qita7col1 = Dropdownlist证书真假qita01.Text.Trim();
                    list1.qita8col1 = Dropdownlist有无原件qita01.Text.Trim();
                    list1.qita1col2 = TextBox证书类型qita02.Text.Trim();
                    list1.qita2col2 = TextBox证书编号qita02.Text.Trim();
                    list1.qita3col2 = TextBox发证日期qita02.Text.Trim();
                    list1.qita4col2 = TextBox有效期qita02.Text.Trim();
                    list1.qita5col2 = TextBox到期时间qita02.Text.Trim();
                    list1.qita6col2 = TextBox发证机关qita02.Text.Trim();
                    list1.qita7col2 = Dropdownlist证书真假qita02.Text.Trim();
                    list1.qita8col2 = Dropdownlist有无原件qita02.Text.Trim();
                    list1.qita1col3 = TextBox证书类型qita03.Text.Trim();
                    list1.qita2col3 = TextBox证书编号qita03.Text.Trim();
                    list1.qita3col3 = TextBox发证日期qita03.Text.Trim();
                    list1.qita4col3 = TextBox有效期qita03.Text.Trim();
                    list1.qita5col3 = TextBox到期时间qita03.Text.Trim();
                    list1.qita6col3 = TextBox发证机关qita03.Text.Trim();
                    list1.qita7col3 = Dropdownlist证书真假qita03.Text.Trim();
                    list1.qita8col3 = Dropdownlist有无原件qita03.Text.Trim();
                    list1.qita1col4 = TextBox证书类型qita04.Text.Trim();
                    list1.qita2col4 = TextBox证书编号qita04.Text.Trim();
                    list1.qita3col4 = TextBox发证日期qita04.Text.Trim();
                    list1.qita4col4 = TextBox有效期qita04.Text.Trim();
                    list1.qita5col4 = TextBox到期时间qita04.Text.Trim();
                    list1.qita6col4 = TextBox发证机关qita04.Text.Trim();
                    list1.qita7col4 = Dropdownlist证书真假qita04.Text.Trim();
                    list1.qita8col4 = Dropdownlist有无原件qita04.Text.Trim();
                    list1.qita1col5 = TextBox证书类型qita05.Text.Trim();
                    list1.qita2col5 = TextBox证书编号qita05.Text.Trim();
                    list1.qita3col5 = TextBox发证日期qita05.Text.Trim();
                    list1.qita4col5 = TextBox有效期qita05.Text.Trim();
                    list1.qita5col5 = TextBox到期时间qita05.Text.Trim();
                    list1.qita6col5 = TextBox发证机关qita05.Text.Trim();
                    list1.qita7col5 = Dropdownlist证书真假qita05.Text.Trim();
                    list1.qita8col5 = Dropdownlist有无原件qita05.Text.Trim();

                    list1.UpdateData();

                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    //清空文本框

                    base.Response.Redirect("yuangongzs.aspx?active=" + base.Request.QueryString["active"]);
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                }
            }
            else
            {
                if (list.InsertData() > 0)
                {

                    string sqlnew = "SELECT max(ID) from yuangongzs";
                    OledbHelper oledbHelper = new OledbHelper();
                    DataTable dataSource = new   DataTable();

                    dataSource = oledbHelper.GetDataTable(sqlnew);

                    int newID = 0;
                    for (int j = 0; j < dataSource.Rows.Count;j++ )
                    {
                        newID = int.Parse(dataSource.Rows[0][0].ToString());
                    }

                    yuangongzsList1 list1 = new yuangongzsList1();

                    list1.sID = newID;
                    list1.qita1col1 = TextBox证书类型qita01.Text.Trim();
                    list1.qita2col1 = TextBox证书编号qita01.Text.Trim();
                    list1.qita3col1 = TextBox发证日期qita01.Text.Trim();
                    list1.qita4col1 = TextBox有效期qita01.Text.Trim();
                    list1.qita5col1 = TextBox到期时间qita01.Text.Trim();
                    list1.qita6col1 = TextBox发证机关qita01.Text.Trim();
                    list1.qita7col1 = Dropdownlist证书真假qita01.Text.Trim();
                    list1.qita8col1 = Dropdownlist有无原件qita01.Text.Trim();
                    list1.qita1col2 = TextBox证书类型qita02.Text.Trim();
                    list1.qita2col2 = TextBox证书编号qita02.Text.Trim();
                    list1.qita3col2 = TextBox发证日期qita02.Text.Trim();
                    list1.qita4col2 = TextBox有效期qita02.Text.Trim();
                    list1.qita5col2 = TextBox到期时间qita02.Text.Trim();
                    list1.qita6col2 = TextBox发证机关qita02.Text.Trim();
                    list1.qita7col2 = Dropdownlist证书真假qita02.Text.Trim();
                    list1.qita8col2 = Dropdownlist有无原件qita02.Text.Trim();
                    list1.qita1col3 = TextBox证书类型qita03.Text.Trim();
                    list1.qita2col3 = TextBox证书编号qita03.Text.Trim();
                    list1.qita3col3 = TextBox发证日期qita03.Text.Trim();
                    list1.qita4col3 = TextBox有效期qita03.Text.Trim();
                    list1.qita5col3 = TextBox到期时间qita03.Text.Trim();
                    list1.qita6col3 = TextBox发证机关qita03.Text.Trim();
                    list1.qita7col3 = Dropdownlist证书真假qita03.Text.Trim();
                    list1.qita8col3 = Dropdownlist有无原件qita03.Text.Trim();
                    list1.qita1col4 = TextBox证书类型qita04.Text.Trim();
                    list1.qita2col4 = TextBox证书编号qita04.Text.Trim();
                    list1.qita3col4 = TextBox发证日期qita04.Text.Trim();
                    list1.qita4col4 = TextBox有效期qita04.Text.Trim();
                    list1.qita5col4 = TextBox到期时间qita04.Text.Trim();
                    list1.qita6col4 = TextBox发证机关qita04.Text.Trim();
                    list1.qita7col4 = Dropdownlist证书真假qita04.Text.Trim();
                    list1.qita8col4 = Dropdownlist有无原件qita04.Text.Trim();
                    list1.qita1col5 = TextBox证书类型qita05.Text.Trim();
                    list1.qita2col5 = TextBox证书编号qita05.Text.Trim();
                    list1.qita3col5 = TextBox发证日期qita05.Text.Trim();
                    list1.qita4col5 = TextBox有效期qita05.Text.Trim();
                    list1.qita5col5 = TextBox到期时间qita05.Text.Trim();
                    list1.qita6col5 = TextBox发证机关qita05.Text.Trim();
                    list1.qita7col5 = Dropdownlist证书真假qita05.Text.Trim();
                    list1.qita8col5 = Dropdownlist有无原件qita05.Text.Trim();

                    list1.InsertData();

                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    //清空文本框
                    ClearTextBox();
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
        }
        private void ClearTextBox()
        {
           

        }



        
        protected void FileUploadButton_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (MyFileUpload.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = MyFileUpload.PostedFile.FileName;

                MyFileUpload.SaveAs(filePath + MyFileUpload.FileName);

                个人基本资料href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox个人基本资料储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
               
                MyFileUpload.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                MyFileUpload.Focus();
            }
        }

        protected void FileUpload学历信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload学历信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload学历信息.PostedFile.FileName;
                FileUpload学历信息.SaveAs(filePath + fileName);

                学历信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox学历信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
               
                FileUpload学历信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload学历信息.Focus();
            }
        }

        protected void FileUpload劳动合同信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload劳动合同信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload劳动合同信息.PostedFile.FileName;
                FileUpload劳动合同信息.SaveAs(filePath + fileName);

                劳动合同信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox劳动合同信息储存位置ht.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
               
                FileUpload劳动合同信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload劳动合同信息.Focus();
            }
        }

        protected void FileUpload员工通信类ABC证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload员工通信类ABC证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload员工通信类ABC证书信息.PostedFile.FileName;
                FileUpload员工通信类ABC证书信息.SaveAs(filePath + fileName);

                员工通信类ABC证书信息附件href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox通信类ABC证书信息储存位置ABC.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
               
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload员工通信类ABC证书信息.Focus();
            }
        }

        protected void FileUpload员工通信类职称证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload通信类职称证书信息证件.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload通信类职称证书信息证件.PostedFile.FileName;
                FileUpload通信类职称证书信息证件.SaveAs(filePath + fileName);

                通信类职称证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox通信类职称证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload通信类职称证书信息证件.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload通信类职称证书信息证件.Focus();
            }
        }

        protected void FileUpload员工通信类概预算证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload通信类概预算证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload通信类概预算证书信息.PostedFile.FileName;
                FileUpload通信类概预算证书信息.SaveAs(filePath + fileName);

                通信类概预算证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox通信类概预算证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload通信类概预算证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload通信类概预算证书信息.Focus();
            }
        }

        protected void FileUpload员工建筑类ABC证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload建筑类ABC证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload建筑类ABC证书信息.PostedFile.FileName;
                FileUpload建筑类ABC证书信息.SaveAs(filePath + fileName);

                建筑类ABC证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox建筑类ABC证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload建筑类ABC证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload建筑类ABC证书信息.Focus();
            }
        }

        protected void FileUpload一级建造师证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload一级建造师证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload一级建造师证书信息.PostedFile.FileName;
                FileUpload一级建造师证书信息.SaveAs(filePath + fileName);

                一级建造师证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox一级建造师证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload一级建造师证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload一级建造师证书信息.Focus();
            }
        }

        protected void FileUpload二级建造师证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload二级建造师证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload二级建造师证书信息.PostedFile.FileName;
                FileUpload二级建造师证书信息.SaveAs(filePath + fileName);

                二级建造师证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox二级建造师证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;


                FileUpload二级建造师证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload二级建造师证书信息.Focus();
            }
        }

        protected void FileUpload建筑类职称证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload建筑类职称证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload建筑类职称证书信息.PostedFile.FileName;
                FileUpload建筑类职称证书信息.SaveAs(filePath + fileName);

                建筑类职称证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox建筑类职称证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload建筑类职称证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload建筑类职称证书信息.Focus();
            }
        }

        protected void FileUpload建筑类技术工种证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload建筑类技术工种证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload建筑类技术工种证书信息.PostedFile.FileName;
                FileUpload建筑类技术工种证书信息.SaveAs(filePath + fileName);
                建筑类技术工种证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox建筑类技术工种证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload建筑类技术工种证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload建筑类技术工种证书信息.Focus();
            }
        }

        protected void FileUpload通信类技术工种证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload通信类技术工种证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload通信类技术工种证书信息.PostedFile.FileName;
                FileUpload通信类技术工种证书信息.SaveAs(filePath + fileName);

                通信类技术工种证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox通信类技术工种证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload通信类技术工种证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload通信类技术工种证书信息.Focus();
            }
        }

        protected void FileUpload特种作业证书信息Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload特种作业证书信息.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload特种作业证书信息.PostedFile.FileName;
                FileUpload特种作业证书信息.SaveAs(filePath + fileName);

                特种作业证书信息href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox特种作业证书信息储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload特种作业证书信息.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload特种作业证书信息.Focus();
            }
        }

        protected void FileUpload其他证书1信息证件Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload其他证书1信息证件.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload其他证书1信息证件.PostedFile.FileName;
                FileUpload其他证书1信息证件.SaveAs(filePath + fileName);

                其他证书1信息证件href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox其他证书1储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload其他证书1信息证件.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload其他证书1信息证件.Focus();
            }
        }

        protected void FileUpload其他证书2信息证件Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload其他证书2信息证件.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload其他证书2信息证件.PostedFile.FileName;
                FileUpload其他证书2信息证件.SaveAs(filePath + fileName);

                其他证书2信息证件href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox其他证书2储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload其他证书2信息证件.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload其他证书2信息证件.Focus();
            }
        }

        protected void FileUpload其他证书3信息证件Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload其他证书3信息证件.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload其他证书3信息证件.PostedFile.FileName;
                FileUpload其他证书3信息证件.SaveAs(filePath + fileName);

                其他证书3信息证件href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox其他证书3储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload其他证书3信息证件.Focus();
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload其他证书3信息证件.Focus();
            }
        }

        protected void FileUpload其他证书4信息证件Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload其他证书4信息证件.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload其他证书4信息证件.PostedFile.FileName;
                FileUpload其他证书4信息证件.SaveAs(filePath + fileName);

                其他证书4信息证件href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox其他证书4储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload其他证书4信息证件.Focus();

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload其他证书4信息证件.Focus();
            }
        }

        protected void FileUpload其他证书5信息证件Button_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            if (FileUpload其他证书5信息证件.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("员工个人信息证件/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload其他证书5信息证件.PostedFile.FileName;
                FileUpload其他证书5信息证件.SaveAs(filePath + fileName);

                其他证书5信息证件href.HRef = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;
                TextBox其他证书5储存位置.Text = "/Admin/zhengjian/员工个人信息证件/" + aaa + fileName;

                FileUpload其他证书5信息证件.Focus();
            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                FileUpload其他证书5信息证件.Focus();
            }
        }

        public bool CopyOldLabFilesToNewLab(string sourcePath, string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            #region //拷贝labs文件夹到savePath下
            try
            {
                string[] labDirs = Directory.GetDirectories(sourcePath);//目录
                string[] labFiles = Directory.GetFiles(sourcePath);//文件
                if (labFiles.Length > 0)
                {
                    for (int i = 0; i < labFiles.Length; i++)
                    {
                        if (Path.GetExtension(labFiles[i]) != ".lab")//排除.lab文件
                        {
                            File.Copy(sourcePath + "\\" + Path.GetFileName(labFiles[i]), savePath + "\\" + Path.GetFileName(labFiles[i]), true);
                        }
                    }
                }
                if (labDirs.Length > 0)
                {
                    for (int j = 0; j < labDirs.Length; j++)
                    {
                        Directory.GetDirectories(sourcePath + "\\" + Path.GetFileName(labDirs[j]));

                        //递归调用
                        CopyOldLabFilesToNewLab(sourcePath + "\\" + Path.GetFileName(labDirs[j]), savePath + "\\" + Path.GetFileName(labDirs[j]));
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            #endregion
            return true;
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "个人基本资料附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox个人基本资料储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "学历信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox学历信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "劳动合同信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox劳动合同信息储存位置ht.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "通信类ABC证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox通信类ABC证书信息储存位置ABC.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }


        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "通信类职称证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox通信类职称证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "通信类概预算证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox通信类概预算证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "建筑类ABC证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox建筑类ABC证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "一级建造师证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox一级建造师证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "二级建造师证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox二级建造师证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "建筑类职称证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox建筑类职称证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "建筑类技术工种证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox建筑类技术工种证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "通信类技术工种证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox通信类技术工种证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "特种作业证书信息附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox特种作业证书信息储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "其他证书1附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox其他证书1储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "其他证书2附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox其他证书2储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton16_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "其他证书3附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox其他证书3储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton17_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "其他证书4附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox其他证书4储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton18_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "其他证书5附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox其他证书5储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }



    }
}