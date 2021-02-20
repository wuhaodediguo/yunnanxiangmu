using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.IO;
using System.Data;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class hezuo3Add : System.Web.UI.Page
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
       
        public string temp7
        {
            get { return Request.Params.Get("temp7"); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hd用户.Text = this.Session["FullName"].ToString();
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop所属项目部();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长电话.Attributes.Add("readOnly", "readOnly");
                    TextBox施工队长身份证号.Attributes.Add("readOnly", "readOnly");
                    TextBox施工能力.Attributes.Add("readOnly", "readOnly");
                   
                    TextBox结算金额.Attributes.Add("readOnly", "readOnly");
                    TextBox收款人.Attributes.Add("readOnly", "readOnly");
                    TextBox开户行.Attributes.Add("readOnly", "readOnly");
                    TextBox银行卡号.Attributes.Add("readOnly", "readOnly");
                   
                    TextBox创建人.Attributes.Add("readOnly", "readOnly");
                    TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                    
                    TextBox备注.Attributes.Add("readOnly", "readOnly");

                    Button3.Visible = false;

                }

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_hezuo3 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                      
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        getDrop所属项目经理();
                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox施工队长姓名.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox施工队长电话.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox施工队长身份证号.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox施工能力.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox结算金额.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox收款人.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox开户行.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox银行卡号.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col13"].ToString();

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo31' and col1='" + id + "' ");
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

        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目部");
                return;
            }
            if (this.TextBox施工队长姓名.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长姓名");
                return;
            }
            if (this.TextBox施工队长身份证号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队长身份证号");
                return;
            }
            if (this.TextBox施工能力.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工能力");
                return;
            }
            if (this.TextBox收款人.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写收款人");
                return;
            }
            if (this.TextBox开户行.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开户行");
                return;
            }
            if (this.TextBox银行卡号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写银行卡号");
                return;
            }
            if (this.GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工队合同扫描件");
                return;
            }


            hezuo3List List = new hezuo3List();
            List.col1 = Drop所属项目部.SelectedItem.Text.Trim();
            List.col2 = Drop项目经理.Text.Trim();
            List.col3 = TextBox施工队长姓名.Text.Trim();
            List.col4 = TextBox施工队长电话.Text.Trim();
            List.col5 = TextBox施工队长身份证号.Text.Trim();
            List.col6 = TextBox施工能力.Text.Trim();
            List.col7 = TextBox结算金额.Text.Trim();
            List.col8 = TextBox收款人.Text.Trim();
            List.col9 = TextBox开户行.Text.Trim();
            List.col10 = TextBox银行卡号.Text.Trim();
            List.col11 = TextBox创建人.Text;
            List.col12 = TextBox创建日期.Text.Trim();
            List.col13 = TextBox备注.Text.Trim();
            if (this.GridView1.Rows.Count == 0)
            {
                List.col14 = "0";
            }
            else
            {
                List.col14 = "1";
            }

            string ID = string.Empty;
            if (this.ViewState["ID"] != null)
            {
                List.ID = int.Parse(this.ViewState["ID"].ToString());
                List.UpdateData(List.ID);
                ID = List.ID.ToString();
            }
            else
            {
                ID = List.InsertData().ToString();
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView1.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            base.Response.Redirect("hezuo3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("hezuo3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp7=" + temp7 + "");
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
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox施工队合同扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox施工队合同扫描件.Text = "";
                施工队合同扫描件href.HRef = "";
                施工队合同扫描件href.InnerText = "";
                btnAttach.Visible = false;

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

        protected void FileUpload施工队合同扫描件Button_Click(object sender, EventArgs e)
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

                施工队合同扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
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
                附件List.flag = "hezuo31";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo31' and col2='" + 附件List.col2 + "' ");
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


                TextBox施工队合同扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }


        //protected void FileUpload合作单位证照资料Button_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        //string filePath = Server.MapPath("公司证件UploadFile/");
        //        string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
        //        string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = FileUpload1.PostedFile.FileName;
        //        FileUpload1.SaveAs(filePath + fileName);

        //        合作单位证照资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        TextBox合作单位证照资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

        //    }
        //    else
        //    {
        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

        //    }
        //}

        //protected void FileUpload法定代表人资料Button_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload2.HasFile)
        //    {
        //        //string filePath = Server.MapPath("公司证件UploadFile/");
        //        string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
        //        string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = FileUpload2.PostedFile.FileName;
        //        FileUpload2.SaveAs(filePath + fileName);

        //        法定代表人资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        TextBox法定代表人资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

        //    }
        //    else
        //    {
        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

        //    }
        //}

        //protected void FileUpload开户许可证资料Button_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload3.HasFile)
        //    {
        //        //string filePath = Server.MapPath("公司证件UploadFile/");
        //        string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
        //        string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = FileUpload3.PostedFile.FileName;
        //        FileUpload3.SaveAs(filePath + fileName);

        //        开户许可证资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        TextBox开户许可证资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

        //    }
        //    else
        //    {
        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

        //    }
        //}



    }
}