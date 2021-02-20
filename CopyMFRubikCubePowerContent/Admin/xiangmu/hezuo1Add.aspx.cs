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
    public partial class hezuo1Add : System.Web.UI.Page
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

                    DataSet ds = Sql.SqlQueryDS("select * from t_hezuo1 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        TextBox合作单位名称.Attributes.Add("readOnly", "readOnly");
                        TextBox三证合一证号.Attributes.Add("readOnly", "readOnly");
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                        TextBox合作单位名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox三证合一证号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox合作单位法定代表人.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox合作单位法定代表人身份证号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox合作单位法定代表人电话.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        Drop合作单位属性.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        Drop合作单位性质.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox合作单位联系人.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox合作单位联系人职务.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox合作单位联系电话.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox合作单位纳税人识别号.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox合作单位电话.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox合作单位地址.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox合作单位开户银行.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox合作单位银行账号.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox合作单位证照资料.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox法定代表人资料.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox开户许可证资料.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col21"].ToString();


                        //if (TextBox合作单位证照资料.Text != "")
                        //{
                        //    合作单位证照资料href.HRef = TextBox合作单位证照资料.Text;
                        //    合作单位证照资料href.Visible = true;
                        //    var temp = TextBox合作单位证照资料.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            合作单位证照资料href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
                        //}

                        //if (TextBox法定代表人资料.Text != "")
                        //{
                        //    法定代表人资料href.HRef = TextBox法定代表人资料.Text;
                        //    法定代表人资料href.Visible = true;
                        //    var temp = TextBox法定代表人资料.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            法定代表人资料href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}
                        //if (TextBox开户许可证资料.Text != "")
                        //{
                        //    开户许可证资料href.HRef = TextBox开户许可证资料.Text;
                        //    开户许可证资料href.Visible = true;
                        //    var temp = TextBox开户许可证资料.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            开户许可证资料href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton2.Visible = true;
                        //}



                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo11' and col1='" + id + "' ");
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

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo12' and col1='" + id + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo13' and col1='" + id + "' ");
                        if (ds23 != null && ds23.Tables[0] != null && ds23.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件3.Value = ds23.Tables[0].Rows[0]["col2"].ToString();
                            GridView3.DataSource = ds23.Tables[0];
                            GridView3.DataBind();
                            ViewState["GridDataSource3"] = ds23.Tables[0];
                        }
                        else
                        {
                            HdCol2附件3.Value = "";
                            GridView3.DataSource = null;
                            GridView3.DataBind();
                        }

                    }

                }

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {

                    TextBox合作单位名称.Attributes.Add("readOnly", "readOnly");
                    TextBox三证合一证号.Attributes.Add("readOnly", "readOnly");

                    TextBox合作单位法定代表人.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位法定代表人身份证号.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位法定代表人电话.Attributes.Add("readOnly", "readOnly");
                    Drop合作单位属性.Enabled = false;
                    Drop合作单位性质.Enabled = false;
                    TextBox合作单位联系人.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位联系人职务.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位联系电话.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位纳税人识别号.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位电话.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位地址.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位开户银行.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位银行账号.Attributes.Add("readOnly", "readOnly");
                    TextBox创建人.Attributes.Add("readOnly", "readOnly");
                    TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                    TextBox合作单位证照资料.Attributes.Add("readOnly", "readOnly");
                    TextBox法定代表人资料.Attributes.Add("readOnly", "readOnly");
                    TextBox开户许可证资料.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");

                    Button5.Enabled = false;
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;
                    FileUpload3.Visible = false;
                    Button1.Enabled = false;
                    Button4.Enabled = false;
                    Button3.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;


                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    合作单位证照资料href.Visible = false;
                    法定代表人资料href.Visible = false;
                    开户许可证资料href.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                }
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
                    if (dataSource.Rows[18]["col2"].ToString() == "1" && dataSource.Rows[18]["col1"].ToString() == "div0051")
                    {
                        dd0051.Visible = true;
                    }
                    else
                    {
                        dd0051.Visible = false;
                    }
                    if (dataSource.Rows[19]["col2"].ToString() == "1" && dataSource.Rows[19]["col1"].ToString() == "div0052")
                    {
                        dd0052.Visible = true;
                    }
                    else
                    {
                        dd0052.Visible = false;
                    }
                    if (dataSource.Rows[20]["col2"].ToString() == "1" && dataSource.Rows[20]["col1"].ToString() == "div0053")
                    {
                        dd0053.Visible = true;
                    }
                    else
                    {
                        dd0053.Visible = false;
                    }
                    if (dataSource.Rows[21]["col2"].ToString() == "1" && dataSource.Rows[21]["col1"].ToString() == "div0054")
                    {
                        dd0054.Visible = true;
                    }
                    else
                    {
                        dd0054.Visible = false;
                    }
                    if (dataSource.Rows[22]["col2"].ToString() == "1" && dataSource.Rows[22]["col1"].ToString() == "div0055")
                    {
                        this.dd0055.Visible = true;
                    }
                    else
                    {
                        this.dd0055.Visible = false;
                    }

                }

            }
            else
            {
                div0051.Visible = false;
                div0052.Visible = false;
                div0053.Visible = false;
                div0054.Visible = false;
                div0055.Visible = false;
            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.TextBox合作单位名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位名称");
                return;
            }
            if (this.TextBox三证合一证号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写三证合一证号");
                return;
            }
            if (this.Drop合作单位属性.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位属性");
                return;
            }
            if (this.Drop合作单位性质.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位性质");
                return;
            }
            if (this.TextBox合作单位法定代表人.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位法定代表人");
                return;
            }
            if (this.TextBox合作单位法定代表人身份证号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位法人身份证号");
                return;
            }
            if (this.TextBox合作单位法定代表人电话.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位法人电话");
                return;
            }
            if (this.TextBox合作单位联系人.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位联系人");
                return;
            }
            if (this.TextBox合作单位联系人职务.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位联系人职务");
                return;
            }
            if (this.TextBox合作单位联系电话.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位联系电话");
                return;
            }
            if (this.TextBox合作单位纳税人识别号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位纳税人识别号");
                return;
            }
            if (this.TextBox合作单位电话.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位电话");
                return;
            }
            if (this.TextBox合作单位地址.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位地址");
                return;
            }
            if (this.TextBox合作单位开户银行.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合作单位开户银行");
                return;
            }

            hezuo1List List = new hezuo1List();
            List.col1 = TextBox合作单位名称.Text.Trim();
            List.col2 = TextBox三证合一证号.Text.Trim();
            List.col3 = TextBox合作单位法定代表人.Text.Trim();
            List.col4 = TextBox合作单位法定代表人身份证号.Text.Trim();
            List.col5 = TextBox合作单位法定代表人电话.Text.Trim();
            List.col6 = Drop合作单位属性.Text.Trim();
            List.col7 = Drop合作单位性质.Text.Trim();
            List.col8 = TextBox合作单位联系人.Text.Trim();
            List.col9 = TextBox合作单位联系电话.Text.Trim();
            List.col10 = TextBox合作单位联系人职务.Text.Trim();
            List.col11 = TextBox合作单位纳税人识别号.Text;
            List.col12 = TextBox合作单位地址.Text.Trim();
            List.col13 = TextBox合作单位电话.Text.Trim();
            List.col14 = TextBox合作单位开户银行.Text.Trim();
            List.col15 = TextBox合作单位银行账号.Text.Trim();
            List.col16 = TextBox创建人.Text.Trim();
            List.col17 = TextBox创建日期.Text.Trim();

            //if (this.GridView1.Rows.Count == 0)
            //{
            //    List.col18 = "0";
            //}
            //else
            //{
            //    List.col18 = "1";
            //}

            //if (this.GridView2.Rows.Count == 0)
            //{
            //    List.col19 = "0";
            //}
            //else
            //{
            //    List.col19 = "1";
            //}

            //if (this.GridView3.Rows.Count == 0)
            //{
            //    List.col20 = "0";
            //}
            //else
            //{
            //    List.col20 = "1";
            //}
            List.col18 = TextBox合作单位证照资料.Text.Trim();
            List.col19 = TextBox法定代表人资料.Text.Trim();
            List.col20 = TextBox开户许可证资料.Text.Trim();
            List.col21 = TextBox备注.Text.Trim();

            int ID = 0;
            if (this.ViewState["ID"] != null)
            {
                List.ID = int.Parse(this.ViewState["ID"].ToString());
                List.UpdateData(List.ID);
                ID = List.ID;
            }
            else
            {
                List.GetAllData2(List.col1);
                if (List.ID > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已存在合作单位名称一样的数据，请修改再保存。");
                    return;
                }
               ID = List.InsertData();
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView3.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView1.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }


            base.Response.Redirect("hezuo1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("hezuo1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload合作单位证照资料Button_Click(object sender, EventArgs e)
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

                合作单位证照资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox合作单位证照资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        合作单位证照资料href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo11";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo11' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload法定代表人资料Button_Click(object sender, EventArgs e)
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
                FileUpload2.SaveAs(filePath + fileName);

                法定代表人资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox法定代表人资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        法定代表人资料href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo12";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo12' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload开户许可证资料Button_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload3.PostedFile.FileName;
                FileUpload3.SaveAs(filePath + fileName);

                开户许可证资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox开户许可证资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        开户许可证资料href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo13";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo13' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件3.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView3.DataSource = ds2.Tables[0];
                    GridView3.DataBind();
                    ViewState["GridDataSource3"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件3.Value = "";
                    GridView3.DataSource = null;
                    GridView3.DataBind();
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
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox合作单位证照资料.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox合作单位证照资料.Text = "";
                合作单位证照资料href.HRef = "";
                合作单位证照资料href.InnerText = "";
                btnAttach.Visible = false;
               
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox法定代表人资料.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox法定代表人资料.Text = "";
                法定代表人资料href.HRef = "";
                法定代表人资料href.InnerText = "";
                LinkButton1.Visible = false;
               
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox开户许可证资料.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox开户许可证资料.Text = "";
                开户许可证资料href.HRef = "";
                开户许可证资料href.InnerText = "";
                LinkButton2.Visible = false;
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

                DataTable dt = (DataTable)ViewState["GridDataSource2"];
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

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource3"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView3.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView3.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource3"] = dtnew;
                this.GridView3.DataSource = dtnew;
                this.GridView3.DataBind();

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