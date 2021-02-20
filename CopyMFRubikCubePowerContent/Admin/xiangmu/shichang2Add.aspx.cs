using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.IO;
using System.Data;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class shichang2Add : System.Web.UI.Page
    {

        public string temp1
        {
            get { return Request.Params.Get("temp1"); }
        }
        public string temp2
        {
            get { return Request.Params.Get("temp2"); }
        }
        public string temp3
        {
            get { return Request.Params.Get("temp3"); }
        }
        public string temp4
        {
            get { return Request.Params.Get("temp4"); }
        }
        public string temp5
        {
            get { return Request.Params.Get("temp5"); }
        }
        public string temp6
        {
            get { return Request.Params.Get("temp6"); }
        }
        public string temp7
        {
            get { return Request.Params.Get("temp7"); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                this.txt年份.Text = DateTime.Now.ToString("yyyy年");
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_shichang where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col40"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col41"].ToString();
                        txt年份.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox招标人.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox招标代理机构.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox招标项目名称.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox招标编号.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox招标方式.Text = ds.Tables[0].Rows[0]["col6"].ToString();

                        TextBox报名起止日期.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox开标日期.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox投标人.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox投标报名标段.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox缴纳报名费金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox报名费发票领取时间.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox缴纳投标保证金金额.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox缴纳投标保证金形式.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox缴纳投标保证金时间.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox投标保函开具银行.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox投标授权代表.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox投标保证金退还金额.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox投标保证金保函退还日期.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox招标文件.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox缴纳保证金保函.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        TextBox投标文件.Text = ds.Tables[0].Rows[0]["col22"].ToString();

                        TextBox中标人.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox中标公示日期.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox中标通知书领取日期.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox中标标段.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox缴纳中标服务费金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox缴纳中标服务费日期.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox中标服务费发票领取时间.Text = ds.Tables[0].Rows[0]["col30"].ToString();
                        TextBox缴纳履约保证金金额.Text = ds.Tables[0].Rows[0]["col31"].ToString();
                        TextBox缴纳履约保证金形式.Text = ds.Tables[0].Rows[0]["col32"].ToString();
                        TextBox缴纳履约保证金时间.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        TextBox履约保函开具银行.Text = ds.Tables[0].Rows[0]["col34"].ToString();
                        TextBox履约保证金退还金额.Text = ds.Tables[0].Rows[0]["col35"].ToString();
                        TextBox履约保证金保函退还日期.Text = ds.Tables[0].Rows[0]["col36"].ToString();
                        TextBox中标通知书.Text = ds.Tables[0].Rows[0]["col37"].ToString();
                        TextBox履约保证金保函.Text = ds.Tables[0].Rows[0]["col38"].ToString();
                        
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col23"].ToString();

                        TextBox缴纳履约保证金到期时间.Text = ds.Tables[0].Rows[0]["col43"].ToString();

                        //if (TextBox中标通知书.Text != "")
                        //{
                        //    中标通知书href.HRef = TextBox中标通知书.Text;
                        //    中标通知书href.Visible = true;
                        //}
                        //if (TextBox履约保证金保函.Text != "")
                        //{
                        //    履约保证金保函href.HRef = TextBox履约保证金保函.Text;
                        //    履约保证金保函href.Visible = true;
                        //}

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'shichang21' and col1='" + id + "' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                            GridView1.DataSource = ds2.Tables[0];
                            GridView1.DataBind();
                            ViewState["GridDataSource"] = ds2.Tables[0];
                        }
                        else
                        {
                            HdCol2附件1.Value = "";
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'shichang22' and col1='" + id + "' ");
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件2.Value = ds22.Tables[0].Rows[0]["col2"].ToString();
                            GridView2.DataSource = ds22.Tables[0];
                            GridView2.DataBind();
                            ViewState["GridDataSource2"] = ds22.Tables[0];
                        }
                        else
                        {
                            HdCol2附件2.Value = "";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        } 
                        

                    }

                    string model = base.Request.QueryString["model"];
                    if (model == "view")
                    {
                      
                        txt年份.Attributes.Add("readOnly", "readOnly");
                        TextBox招标人.Attributes.Add("readOnly", "readOnly");
                        TextBox招标代理机构.Attributes.Add("readOnly", "readOnly");
                        TextBox招标项目名称.Attributes.Add("readOnly", "readOnly");
                        TextBox招标编号.Attributes.Add("readOnly", "readOnly");
                        TextBox招标方式.Attributes.Add("readOnly", "readOnly");

                        TextBox报名起止日期.Attributes.Add("readOnly", "readOnly");
                        TextBox开标日期.Attributes.Add("readOnly", "readOnly");
                        TextBox投标人.Attributes.Add("readOnly", "readOnly");
                        TextBox投标报名标段.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳报名费金额.Attributes.Add("readOnly", "readOnly");
                        TextBox报名费发票领取时间.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳投标保证金金额.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳投标保证金形式.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳投标保证金时间.Attributes.Add("readOnly", "readOnly");
                        TextBox投标保函开具银行.Attributes.Add("readOnly", "readOnly");
                        TextBox投标授权代表.Attributes.Add("readOnly", "readOnly");
                        TextBox投标保证金退还金额.Attributes.Add("readOnly", "readOnly");
                        TextBox投标保证金保函退还日期.Attributes.Add("readOnly", "readOnly");
                        TextBox招标文件.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳保证金保函.Attributes.Add("readOnly", "readOnly");
                        TextBox投标文件.Attributes.Add("readOnly", "readOnly");

                        TextBox中标人.Attributes.Add("readOnly", "readOnly");
                        TextBox中标公示日期.Attributes.Add("readOnly", "readOnly");
                        TextBox中标通知书领取日期.Attributes.Add("readOnly", "readOnly");
                        TextBox中标标段.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳中标服务费金额.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳中标服务费日期.Attributes.Add("readOnly", "readOnly");
                        TextBox中标服务费发票领取时间.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳履约保证金金额.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳履约保证金形式.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳履约保证金时间.Attributes.Add("readOnly", "readOnly");
                        TextBox履约保函开具银行.Attributes.Add("readOnly", "readOnly");
                        TextBox履约保证金退还金额.Attributes.Add("readOnly", "readOnly");
                        TextBox履约保证金保函退还日期.Attributes.Add("readOnly", "readOnly");
                        TextBox中标通知书.Attributes.Add("readOnly", "readOnly");
                        TextBox履约保证金保函.Attributes.Add("readOnly", "readOnly");
                        TextBox备注.Attributes.Add("readOnly", "readOnly");
                        TextBox缴纳履约保证金到期时间.Attributes.Add("readOnly", "readOnly");
                        Button6.Visible = false;
                        FileUpload2.Visible = false;
                        FileUpload1.Visible = false;
                        Button2.Enabled = false;
                        Button4.Enabled = false;
                        btnAttach.Visible = false;
                        LinkButton1.Visible = false;
                   
                    }

                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[2]["col2"].ToString() == "1" && dataSource.Rows[2]["col1"].ToString() == "div0021")
                    {
                        dd0021.Visible = true;
                    }
                    else
                    {
                        dd0021.Visible = false;
                    }
                    if (dataSource.Rows[3]["col2"].ToString() == "1" && dataSource.Rows[3]["col1"].ToString() == "div0022")
                    {
                        dd0022.Visible = true;
                    }
                    else
                    {
                        dd0022.Visible = false;
                    }
                    if (dataSource.Rows[4]["col2"].ToString() == "1" && dataSource.Rows[4]["col1"].ToString() == "div0023")
                    {
                        dd0023.Visible = true;
                    }
                    else
                    {
                        dd0023.Visible = false;
                    }

                }

            }
            else
            {
                div0021.Visible = false;
                div0022.Visible = false;
                div0023.Visible = false;

            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt年份.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写年份");
                return;
            }
            if (this.TextBox招标人.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写招标人");
                return;
            }
            if (this.TextBox招标代理机构.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写招标代理机构");
                return;
            }
            if (this.TextBox招标项目名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写招标项目名称");
                return;
            }
            if (this.TextBox中标人.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写中标人");
                return;
            }
            if (this.TextBox招标编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写招标编号");
                return;
            }
            if (this.TextBox中标公示日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写中标公示日期");
                return;
            }
            if (this.TextBox招标方式.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写招标方式");
                return;
            }
            if (this.TextBox中标标段.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写中标标段");
                return;
            }

            if (this.GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传中标通知书");
                return;
            }
            if (this.GridView2.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传履约保证金保函");
                return;
            }
            //if (this.TextBox中标通知书.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写中标通知书");
            //    return;
            //}
            //if (this.TextBox履约保证金保函.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写履约保证金保函");
            //    return;
            //}

            shichangList shichangList = new shichangList();
            shichangList.col1 = txt年份.Text.Trim();
            shichangList.col2 = TextBox招标人.Text.Trim();
            shichangList.col3 = TextBox招标代理机构.Text.Trim();
            shichangList.col4 = TextBox招标项目名称.Text.Trim();
            shichangList.col5 = TextBox招标编号.Text.Trim();
            shichangList.col6 = TextBox招标方式.Text.Trim();
            shichangList.col24 = TextBox中标人.Text.Trim();
            shichangList.col25 = TextBox中标公示日期.Text.Trim();
            shichangList.col26 = TextBox中标通知书领取日期.Text.Trim();
            shichangList.col27 = TextBox中标标段.Text.Trim();
            shichangList.col28 = TextBox缴纳中标服务费金额.Text.Trim();
            shichangList.col29 = TextBox缴纳中标服务费日期.Text.Trim();
            shichangList.col30 = TextBox中标服务费发票领取时间.Text.Trim();
            shichangList.col31 = TextBox缴纳履约保证金金额.Text.Trim();
            shichangList.col32 = TextBox缴纳履约保证金形式.Text.Trim();
            shichangList.col33 = TextBox缴纳履约保证金时间.Text.Trim();
            shichangList.col34 = TextBox履约保函开具银行.Text.Trim();
            shichangList.col35 = TextBox履约保证金退还金额.Text.Trim();
            shichangList.col36 = TextBox履约保证金保函退还日期.Text.Trim();
            if (this.GridView1.Rows.Count == 0)
            {
                shichangList.col37 = "0";
            }
            else
            {
                shichangList.col37 = "1";
            }
            if (this.GridView2.Rows.Count == 0)
            {
                shichangList.col38 = "0";
            }
            else
            {
                shichangList.col38 = "1";
            }
            //shichangList.col37 = TextBox中标通知书.Text.Trim();
            //shichangList.col38 = TextBox履约保证金保函.Text.Trim();
            shichangList.col39 = "1";

            shichangList.col23 = TextBox备注.Text.Trim();
            shichangList.col40 = TextBox创建人.Text.Trim();
            shichangList.col41 = TextBox创建日期.Text.Trim();

            shichangList.col7 = "";
            shichangList.col8 = "";
            shichangList.col9 = "";
            shichangList.col10 = "";
            shichangList.col11 = "";
            shichangList.col12 = "";
            shichangList.col13 = "";
            shichangList.col14 = "";
            shichangList.col15 = "";
            shichangList.col16 = "";
            shichangList.col17 = "";
            shichangList.col18 = "";
            shichangList.col19 = "";
            shichangList.col20 = "";
            shichangList.col21 = "";
            shichangList.col22 = "";
            shichangList.col42 = "";
            shichangList.col43 = TextBox缴纳履约保证金到期时间.Text.Trim();
            shichangList.col44 = "";

            shichangList.col45 = "0";
            string strlblcol42 = shichangList.col43.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
            if (strlblcol42 == "")
            {
            }
            else
            {
                if (DateTime.Compare(Convert.ToDateTime(strlblcol42), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) <= 0)
                {
                    shichangList.col45 = "1";
                }
            }

            shichangList.col51 = TextBox缴纳履约保证金到期时间.Text.Trim() == "" ? DateTime.Now.AddYears(-3) : Convert.ToDateTime(TextBox缴纳履约保证金到期时间.Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim());


            int ssID = 0;
            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());
                shichangList.UpdateData(shichangList.ID);
                ssID = shichangList.ID;
            }
            else
            {
                ssID = shichangList.InsertData();
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string ID = ((Label)GridView1.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string ID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }


            base.Response.Redirect("shichang2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("shichang2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload中标通知书Button_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload2.PostedFile.FileName;

                //var Pdata = "<script> var  fileName = "
                //        + fileName + ";var  filePath = "
                //            + filePath + fileName + ";up();</script>";

                //ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata);//將結果傳到Cient Site.

                FileUpload2.SaveAs(filePath + fileName);

                中标通知书href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox中标通知书.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "shichang21";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'shichang21' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView1.DataSource = ds2.Tables[0];
                    GridView1.DataBind();
                    ViewState["GridDataSource"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件1.Value = "";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload履约保证金保函Button_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(filePath + fileName);

                履约保证金保函href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox履约保证金保函.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "shichang22";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'shichang22' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件2.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView2.DataSource = ds2.Tables[0];
                    GridView2.DataBind();
                    ViewState["GridDataSource2"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件2.Value = "";
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col2) as col1 from t_fujian where 1=1 and col2 like '%" + strdate + "%'  ";
            
            dataSource = oledbHelper.GetDataTable(sql);
            if (dataSource.Rows.Count > 0)
            {
                string number = dataSource.Rows[0][0].ToString();
                if (number != "" && number.Length > 8)
                {
                    number = dataSource.Rows[0][0].ToString().Substring(8, 4);
                    count = Convert.ToDecimal(number);
                }

            }
            return DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
        }


        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox中标通知书.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox中标通知书.Text = "";
                中标通知书href.HRef = "";
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox履约保证金保函.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox履约保证金保函.Text = "";
                履约保证金保函href.HRef = "";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var temp = ((HyperLink)e.Row.FindControl("HyperLink1")).Text;
                if (temp != "")
                {
                    var temps = temp.LastIndexOf("/");
                    if (temps > 0)
                    {
                        var temps2 = temp.Substring(temps);
                        ((HyperLink)e.Row.FindControl("HyperLink1")).Text = temps2;
                    }

                }
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = false;
                }

            }




        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView1.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource"] = dtnew;
                this.GridView1.DataSource = dtnew;
                this.GridView1.DataBind();

                string IDs = Convert.ToString(((Label)row.FindControl("lblID2")).Text);
                if (IDs != "")
                {
                    附件List.DeleteData(int.Parse(IDs));

                    var fileName = Server.MapPath("公司证件UploadFile/") + strlblcol2.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var temp = ((HyperLink)e.Row.FindControl("HyperLink1")).Text;
                if (temp != "")
                {
                    var temps = temp.LastIndexOf("/");
                    if (temps > 0)
                    {
                        var temps2 = temp.Substring(temps);
                        ((HyperLink)e.Row.FindControl("HyperLink1")).Text = temps2;
                    }

                }
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = false;
                }

            }




        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource2"] = dtnew;
                this.GridView2.DataSource = dtnew;
                this.GridView2.DataBind();

                string IDs = Convert.ToString(((Label)row.FindControl("lblID2")).Text);
                if (IDs != "")
                {
                    附件List.DeleteData(int.Parse(IDs));

                    var fileName = Server.MapPath("公司证件UploadFile/") + strlblcol2.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);  
                    }
                }

            }
        }







    }
}