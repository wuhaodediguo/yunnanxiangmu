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
    public partial class hezuo2Add : System.Web.UI.Page
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
                getDrop所属项目部();
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

                    DataSet ds = Sql.SqlQueryDS("select * from t_hezuo2 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        //TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                        //TextBox施工队长电话.Attributes.Add("readOnly", "readOnly");
                       
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                        TextBox施工队长姓名.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox施工队长电话.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox施工队长身份证号.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox施工队长出生日期.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox施工队长身份地址.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox施工区域.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox施工专业.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        getDrop所属项目经理();
                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox施工队成员.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        Radio施工能力.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox施工能力.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox施工队长身份证件.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox施工队长照片.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        

                        hd项目部.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        hd项目经理.Text = ds.Tables[0].Rows[0]["col9"].ToString();

                        zhuangtaiList list2 = new zhuangtaiList();
                        string sql2 = "select * from t_zhuangtai where col1='" + id + "' ";
                        DataSet ds22 = Sql.SqlQueryDS(sql2);
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds22.Tables[0].Rows.Count; k++)
                            {
                                TextBox施工能力修改记录.Text += ds22.Tables[0].Rows[k]["col2"].ToString() + @"
";
                            }

                        }

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo21' and col1='" + id + "' ");
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

                        DataSet ds222 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo22' and col1='" + id + "' ");
                        if (ds222 != null && ds222.Tables[0] != null && ds222.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件2.Value = ds222.Tables[0].Rows[0]["col2"].ToString();
                            GridView2.DataSource = ds222.Tables[0];
                            GridView2.DataBind();
                            ViewState["GridDataSource2"] = ds222.Tables[0];
                        }
                        else
                        {
                            HdCol2附件2.Value = "";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        }

                        //if (TextBox施工队长身份证件.Text != "")
                        //{
                        //    施工队长身份证件href.HRef = TextBox施工队长身份证件.Text;
                        //    施工队长身份证件href.Visible = true;
                        //    var temp = TextBox施工队长身份证件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            施工队长身份证件href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
                        //}
                       
                        //if (TextBox施工队长照片.Text != "")
                        //{
                        //    施工队长照片href.HRef = TextBox施工队长照片.Text;
                        //    施工队长照片href.Visible = true;
                        //    var temp = TextBox施工队长照片.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            施工队长照片href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}

                        if (this.Session["RoleValue"].ToString() != "1" && TextBox创建人.Text != this.Session["FullName"].ToString())
                        {
                            TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长电话.Attributes.Add("readOnly", "readOnly");

                            TextBox创建人.Attributes.Add("readOnly", "readOnly");
                            TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                            TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长电话.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长身份证号.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长出生日期.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长身份地址.Attributes.Add("readOnly", "readOnly");
                            TextBox施工区域.Attributes.Add("readOnly", "readOnly");
                            TextBox施工专业.Attributes.Add("readOnly", "readOnly");
                            Drop所属项目部.Enabled = false;
                            Drop项目经理.Enabled = false;
                            TextBox施工队成员.Attributes.Add("readOnly", "readOnly");
                            Radio施工能力.Attributes.Add("readOnly", "readOnly");
                            TextBox施工能力.Attributes.Remove("readOnly");
                            TextBox创建人.Attributes.Add("readOnly", "readOnly");
                            TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长身份证件.Attributes.Add("readOnly", "readOnly");
                            TextBox施工队长照片.Attributes.Add("readOnly", "readOnly");
                            TextBox备注.Attributes.Add("readOnly", "readOnly");
                            TextBox施工能力修改记录.Attributes.Add("readOnly", "readOnly");

                            Button5.Enabled = false;
                            FileUpload1.Visible = false;
                            FileUpload2.Visible = false;

                            Button4.Enabled = false;

                            btnAttach.Visible = false;
                            LinkButton1.Visible = false;
                        }

                    }

                }

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {

                    TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长电话.Attributes.Add("readOnly", "readOnly");

                    TextBox创建人.Attributes.Add("readOnly", "readOnly");
                    TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                    TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长电话.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长身份证号.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长出生日期.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长身份地址.Attributes.Add("readOnly", "readOnly");
                    TextBox施工区域.Attributes.Add("readOnly", "readOnly");
                    TextBox施工专业.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    TextBox施工队成员.Attributes.Add("readOnly", "readOnly");
                    Radio施工能力.Attributes.Add("readOnly", "readOnly");
                    //TextBox施工能力.Attributes.Add("readOnly", "readOnly");
                    TextBox创建人.Attributes.Add("readOnly", "readOnly");
                    TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长身份证件.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长照片.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    TextBox施工能力修改记录.Attributes.Add("readOnly", "readOnly");
                    Button5.Enabled = false;
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;

                    Button4.Enabled = false;
                    //Button3.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;

                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    施工队长身份证件href.Visible = false;
                    施工队长照片href.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
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

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("xiangmu");
            DataRow dr;

            //sql = "select ID,guige  from tb_guige where 1=1     ";
            sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
            dataSource = oledbHelper.GetDataTable(sql);
            string[] strxiangmu;
            if (dataSource.Rows.Count > 0)
            {
                strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                for (int k = 0; k < strxiangmu.Length; k++)
                {
                    if (strxiangmu[k].ToString().Trim() == "")
                    {
                        continue;
                    }
                    dr = dt.NewRow();
                    dr["xiangmu"] = strxiangmu[k];
                    dt.Rows.Add(dr);
                }

            }

            Drop所属项目部.DataTextField = "xiangmu";
            Drop所属项目部.DataValueField = "xiangmu";
            Drop所属项目部.DataSource = dt;
            Drop所属项目部.DataBind();
            Drop所属项目部.Items.Insert(0, "");

        }

        protected void getDrop所属项目经理()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部.Text + "'    ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop项目经理.DataTextField = "col2";
            Drop项目经理.DataValueField = "col2";
            Drop项目经理.DataSource = dataSource;
            Drop项目经理.DataBind();
            Drop项目经理.Items.Insert(0, "");

        }

        protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drop所属项目部.Text != "")
            {
                getDrop所属项目经理();
            }
            else
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理.DataTextField = "col2";
                Drop项目经理.DataValueField = "col2";
                Drop项目经理.DataSource = dataSource;
                Drop项目经理.DataBind();
                Drop项目经理.Items.Insert(0, "");
            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.TextBox施工队长姓名.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长姓名");
                return;
            }
            if (this.TextBox施工队长电话.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长电话");
                return;
            }
            if (this.TextBox施工队长身份证号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长身份证号");
                return;
            }
            if (this.TextBox施工队长出生日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长出生日期");
                return;
            }
            if (this.TextBox施工队长身份地址.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长身份地址");
                return;
            }
            if (this.TextBox施工区域.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工区域");
                return;
            }
            if (this.TextBox施工专业.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工专业");
                return;
            }
            if (this.Drop所属项目部.Text.Trim() == "" && hd项目部.Text == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目部");
                return;
            }
            if (this.Drop项目经理.Text.Trim() == "" && hd项目经理.Text == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理");
                return;
            }
            if (this.TextBox施工队成员.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队成员");
                return;
            }
            if (this.TextBox施工能力.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工能力");
                return;
            }
            //if (this.TextBox备注.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写备注");
            //    return;
            //}
            if (this.GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长身份证件");
                return;
            }
            if (this.GridView2.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长照片");
                return;
            }

            hezuo2List List = new hezuo2List();
            List.col1 = TextBox施工队长姓名.Text.Trim();
            List.col2 = TextBox施工队长电话.Text.Trim();
            List.col3 = TextBox施工队长身份证号.Text.Trim();
            List.col4 = TextBox施工队长出生日期.Text.Trim();
            List.col5 = TextBox施工队长身份地址.Text.Trim();
            List.col6 = TextBox施工区域.Text.Trim();
            List.col7 = TextBox施工专业.Text.Trim();
            List.col8 = Drop所属项目部.Text.Trim() == "" ? hd项目部.Text : Drop所属项目部.Text.Trim();
            List.col9 = Drop项目经理.Text.Trim() == "" ? hd项目经理.Text : Drop项目经理.Text.Trim();
            List.col10 = TextBox施工队成员.Text.Trim();
            List.col11 = Radio施工能力.Text;
            List.col12 = TextBox施工能力.Text.Trim();
            List.col13 = TextBox创建人.Text.Trim();
            List.col14 = TextBox创建日期.Text.Trim();

            if (this.GridView1.Rows.Count == 0)
            {
                List.col15 = "0";
            }
            else
            {
                List.col15 = "1";
            }
            if (this.GridView2.Rows.Count == 0)
            {
                List.col16 = "0";
            }
            else
            {
                List.col16 = "1";
            }
            //List.col15 = TextBox施工队长身份证件.Text.Trim();
            //List.col16 = TextBox施工队长照片.Text.Trim();
            List.col17 = TextBox备注.Text.Trim();

            string ID = string.Empty;
            if (this.ViewState["ID"] != null)
            {
                

                List.ID = int.Parse(this.ViewState["ID"].ToString());

                List.col18 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日") + "修改为:" +TextBox施工能力.Text.Trim();
                List.UpdateData(List.ID);

                zhuangtaiList list2 = new zhuangtaiList();
                string sql2 = "select * from t_zhuangtai where col1='" + List.ID + "'  ";
                DataSet ds2 = Sql.SqlQueryDS(sql2);
                list2.col1 = List.ID.ToString();
                list2.col2 = List.col18;
                list2.col3 = "";
                list2.InsertData();
                ID = list2.col1;
            }
            else
            {
                List.col18 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日") + "确定施工能力为:" + TextBox施工能力.Text.Trim();
                
                //List.InsertData();
                ID = List.InsertData().ToString();
            }

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
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

            base.Response.Redirect("hezuo2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("hezuo2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
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


        protected void FileUpload施工队长身份证件Button_Click(object sender, EventArgs e)
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

                施工队长身份证件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        施工队长身份证件href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo21";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo21' and col2='" + 附件List.col2 + "' ");
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
                

                TextBox施工队长身份证件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload施工队长照片Button_Click(object sender, EventArgs e)
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

                施工队长照片href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox施工队长照片.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        施工队长照片href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo22";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo22' and col2='" + 附件List.col2 + "' ");
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


        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox施工队长身份证件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox施工队长身份证件.Text = "";
                施工队长身份证件href.HRef = "";
                施工队长身份证件href.InnerText = "";
                btnAttach.Visible = false;
                
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox施工队长照片.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox施工队长照片.Text = "";
                施工队长照片href.HRef = "";
                施工队长照片href.InnerText = "";
                LinkButton1.Visible = false;
            }
        }


        

    }
}