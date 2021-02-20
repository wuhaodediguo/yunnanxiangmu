using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using System.IO;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class shenhefujian : System.Web.UI.Page
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
        public string temp8
        {
            get { return Request.Params.Get("temp8"); }
        }
        public string temp9
        {
            get { return Request.Params.Get("temp9"); }
        }
        public string caset
        {
            get { return Request.Params.Get("caset"); }
        }

        public string casetName;
        public string TFalgs;


        public string chakanmodel = "";
        public string fullname = "";
        public string tickedFormNo = "";
        public string HdID = "";
     
        protected void Page_Load(object sender, EventArgs e)
        {
            //fullname = Request.QueryString["fullname"].ToString();
            fullname = this.Session["FullName"].ToString();
            tickedFormNo = Request.QueryString["tickedFormNo"].ToString();
            chakanmodel = Request.QueryString["chakanmodel"].ToString();
            HdID = Request.QueryString["HdID"].ToString();
          
            switch (caset)
            {
                case "1":
                    casetName = "发票资料附件";
                    TFalgs = "xiangmu91";
                    break;
                case "2":
                    casetName = "采购订单资料附件";
                    TFalgs = "xiangmu92";
                    break;
                case "3":
                    casetName = "结算资料附件";
                    TFalgs = "xiangmu93";
                    break;
                case "4":
                    casetName = "审计资料附件";
                    TFalgs = "xiangmu94";
                    break;
                case "5":
                    casetName = "竣工资料附件";
                    TFalgs = "xiangmu95";
                    break;
                case "11":
                    casetName = "发票资料附件";
                    TFalgs = "xiangmu91";
                    break;
                case "12":
                    casetName = "发票资料附件";
                    TFalgs = "xiangmu91";
                    break;
                case "13":
                    casetName = "发票资料附件";
                    TFalgs = "xiangmu91";
                    break;
                case "14":
                    casetName = "发票资料附件";
                    TFalgs = "xiangmu91";
                    break;
                case "21":
                    casetName = "采购订单资料附件";
                    TFalgs = "xiangmu92";
                    break;
                case "22":
                    casetName = "采购订单资料附件";
                    TFalgs = "xiangmu92";
                    break;
                case "23":
                    casetName = "采购订单资料附件";
                    TFalgs = "xiangmu92";
                    break;
                case "24":
                    casetName = "采购订单资料附件";
                    TFalgs = "xiangmu92";
                    break;
                case "31":
                    casetName = "结算资料附件";
                    TFalgs = "xiangmu93";
                    break;
                case "32":
                    casetName = "结算资料附件";
                    TFalgs = "xiangmu93";
                    break;
                case "33":
                    casetName = "结算资料附件";
                    TFalgs = "xiangmu93";
                    break;
                case "34":
                    casetName = "结算资料附件";
                    TFalgs = "xiangmu93";
                    break;
                case "41":
                    casetName = "审计资料附件";
                    TFalgs = "xiangmu94";
                    break;
                case "42":
                    casetName = "审计资料附件";
                    TFalgs = "xiangmu94";
                    break;
                case "43":
                    casetName = "审计资料附件";
                    TFalgs = "xiangmu94";
                    break;
                case "44":
                    casetName = "审计资料附件";
                    TFalgs = "xiangmu94";
                    break;
                case "51":
                    casetName = "竣工资料附件";
                    TFalgs = "xiangmu95";
                    break;
                case "52":
                    casetName = "竣工资料附件";
                    TFalgs = "xiangmu95";
                    break;
                case "53":
                    casetName = "竣工资料附件";
                    TFalgs = "xiangmu95";
                    break;
                case "54":
                    casetName = "竣工资料附件";
                    TFalgs = "xiangmu95";
                    break;

            }
            HdcasetName.Value = casetName;

            txtInput发票单号.Attributes.Add("readOnly", "readOnly");
            if (!base.IsPostBack)
            {
                txtInput发票单号.Text = tickedFormNo;
                if (chakanmodel == "chakan" || chakanmodel == "")
                {
                    div提交.Visible = false;
                    div2.Attributes.Remove("class");
                    div2.Attributes.Add("class", "col-xs-12 col-md-12");
                    TextBox审核人.Text = this.Session["FullName"].ToString();
                    TextBox审核人.Attributes.Add("ReadOnly", "ReadOnly");
                    //div审核人.Visible = true;
                    //div审核意见.Visible = true;
                    div附件名称.Visible = false;
                    //GridView2.Enabled = false;
                    //div附件名称footer.Visible = true;
                    //div附件名称footer2.Visible = true;
                }
                else if (chakanmodel == "chakan2")
                {
                    div提交.Visible = true;
                }
                else if (chakanmodel == "shenhe")
                {
                    TextBox审核人.Text = this.Session["FullName"].ToString();
                    TextBox审核人.Attributes.Add("ReadOnly", "ReadOnly");
                    div审核人.Visible = true;
                    div审核意见.Visible = true;
                    div附件名称.Visible = false;
                    GridView2.Enabled = false;
                    div附件名称footer.Visible = true;
                    div附件名称footer2.Visible = true;
                    Hdchakanmodel.Value = "shenhe";
                    //GridView2.Enabled = false;
                    div提交.Visible = false;
                    div附件名称footer.Attributes.Remove("class");
                    div附件名称footer2.Attributes.Remove("class");
                    div2.Attributes.Remove("class");
                    div附件名称footer.Attributes.Add("class", "col-xs-4 col-md-4");
                    div附件名称footer2.Attributes.Add("class", "col-xs-4 col-md-4");
                    div2.Attributes.Add("class", "col-xs-4 col-md-4");
                }
                //if (base.Request.QueryString["caset"] == "14" || base.Request.QueryString["caset"] == "24" || base.Request.QueryString["caset"] == "34"
                //    || base.Request.QueryString["caset"] == "44" || base.Request.QueryString["caset"] == "54")
                //{
                //    GridView2.Enabled = false;
                //}
                this.GridBind2();

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        void GridBind2()
        {
            DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + TFalgs + "' and col1='" + txtInput发票单号.Text.Trim() + "' ");
            if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds22.Tables[0];
                GridView2.DataBind();
                ViewState["GridDataSource2"] = ds22.Tables[0];
            }
            else
            {

                GridView2.DataSource = null;
                GridView2.DataBind();
            }

        }


        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col2) as col1 from t_fujian where 1=1  ";
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


        protected void FileUpload税票扫描件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload0.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload0.PostedFile.FileName;
                FileUpload0.SaveAs(filePath + fileName);

                税票扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox税票扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List 附件List = new 附件List();
                var Tflag = "";
                switch (caset)
                {
                    case "1":
                        Tflag = "xiangmu91";
                        break;
                    case "2":
                        Tflag = "xiangmu92";
                        break;
                    case "3":
                        Tflag = "xiangmu93";
                        break;
                    case "4":
                        Tflag = "xiangmu94";
                        break;
                    case "5":
                        Tflag = "xiangmu95";
                        break;
                    case "11":
                        Tflag = "xiangmu91";
                        break;
                    case "12":
                        Tflag = "xiangmu91";
                        break;
                    case "13":
                        Tflag = "xiangmu91";
                        break;
                    case "14":
                        Tflag = "xiangmu91";
                        break;
                    case "21":
                        Tflag = "xiangmu92";
                        break;
                    case "22":
                        Tflag = "xiangmu92";
                        break;
                    case "23":
                        Tflag = "xiangmu92";
                        break;
                    case "24":
                        Tflag = "xiangmu92";
                        break;
                    case "31":
                        Tflag = "xiangmu93";
                        break;
                    case "32":
                        Tflag = "xiangmu93";
                        break;
                    case "33":
                        Tflag = "xiangmu93";
                        break;
                    case "34":
                        Tflag = "xiangmu93";
                        break;
                    case "41":
                        Tflag = "xiangmu94";
                        break;
                    case "42":
                        Tflag = "xiangmu94";
                        break;
                    case "43":
                        Tflag = "xiangmu94";
                        break;
                    case "44":
                        Tflag = "xiangmu94";
                        break;
                    case "51":
                        Tflag = "xiangmu95";
                        break;
                    case "52":
                        Tflag = "xiangmu95";
                        break;
                    case "53":
                        Tflag = "xiangmu95";
                        break;
                    case "54":
                        Tflag = "xiangmu95";
                        break;

                }
                附件List.flag = Tflag;
                附件List.col1 = txtInput发票单号.Text.Trim();
                附件List.col2 = "";
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List.col4 = this.Session["FullName"].ToString();
                附件List.col5 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                附件List.col6 = "";
                附件List.col7 = "";
                附件List.col8 = "";

                附件List.InsertData2();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + Tflag + "' and col1='" + txtInput发票单号.Text.Trim() + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds2.Tables[0];
                    GridView2.DataBind();
                    ViewState["GridDataSource2"] = ds2.Tables[0];
                }
                else
                {

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

                if (chakanmodel == "shenhe" || chakanmodel == "chakan" || chakanmodel == "")
                {
                    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = false;
                }
                //string model = base.Request.QueryString["model"];
                //if (model == "view")
                //{
                //    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = false;
                //}

            }




        }

        protected void btn审核_Click(object sender, EventArgs e)
        {
            if (TextBox审核意见.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核意见！");
                return;
            }
            if (this.GridView2.Rows.Count <= 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请至少上传一个附件！");
                return;
            }
            附件List 附件List = new 附件List();
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List.col6 = this.Session["FullName"].ToString();
                附件List.col7 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                附件List.col8 = TextBox审核意见.Text.Trim();

                附件List.UpdateData2(int.Parse(strNoID));
            }

            xiangmu1List xiangmu1List = new xiangmu1List();

            xiangmu1List.GetData(int.Parse(HdID));

            xiangmu1List.col27 = "1";
            xiangmu1List.col28 = "";

            xiangmu1List.UpdateData(int.Parse(HdID));

            string jscript = @"<script language=""javascript"" >
                                                    if(window.opener)
                                                    {
                                                       
                                                     window.opener.btnAddPartDetail();

                                                     
                                                        window.close();
                                                       
                                                    }
                                                    else
                                                    {

                                                    }
                                                </script>";


            Response.Write(jscript);
            //base.Response.Redirect("xiangmu9.aspx?temp1=" + temp1.Trim() == "000" ? "" : temp1.Trim() + "&temp2=" + temp2.Trim() == "000" ? "" : temp2.Trim() + "&temp3=" + temp3.Trim() == "000" ? "" : temp3.Trim() + "&temp4=" + temp4.Trim() == "000" ? "" : temp4.Trim() + "&temp5=" + temp5.Trim() == "000" ? "" : temp5.Trim() + "&temp6=" + temp6.Trim() == "000" ? "" : temp6.Trim() + "&temp7=" + temp7.Trim() == "000" ? "" : temp7.Trim() + "&temp8=" + temp8.Trim() == "000" ? "" : temp8.Trim() + "&temp9=" + temp9.Trim() == "000" ? "" : temp9.Trim() + "&caset=" + caset + "");
        
        }

        protected void btn审核不通过_Click(object sender, EventArgs e)
        {
            if (TextBox审核意见.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核意见！");
                return;
            }
            if (this.GridView2.Rows.Count <= 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请至少上传一个附件！");
                return;
            }
            附件List 附件List = new 附件List();
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List.col6 = this.Session["FullName"].ToString();
                附件List.col7 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                附件List.col8 = TextBox审核意见.Text.Trim();

                附件List.UpdateData2(int.Parse(strNoID));
            }
            xiangmu1List xiangmu1List = new xiangmu1List();

            xiangmu1List.GetData(int.Parse(HdID));

            xiangmu1List.col28 = "1";

            xiangmu1List.UpdateData(int.Parse(HdID));

            string jscript = @"<script language=""javascript"" >
                                                    if(window.opener)
                                                    {
                                                       
                                                     window.opener.btnAddPartDetail();

                                                     
                                                        window.close();
                                                       
                                                    }
                                                    else
                                                    {

                                                    }
                                                </script>";


            Response.Write(jscript);
            //base.Response.Redirect("xiangmu9.aspx?temp1=" + temp1.Trim() == "000" ? "" : temp1.Trim() + "&temp2=" + temp2.Trim() == "000" ? "" : temp2.Trim() + "&temp3=" + temp3.Trim() == "000" ? "" : temp3.Trim() + "&temp4=" + temp4.Trim() == "000" ? "" : temp4.Trim() + "&temp5=" + temp5.Trim() == "000" ? "" : temp5.Trim() + "&temp6=" + temp6.Trim() == "000" ? "" : temp6.Trim() + "&temp7=" + temp7.Trim() == "000" ? "" : temp7.Trim() + "&temp8=" + temp8.Trim() == "000" ? "" : temp8.Trim() + "&temp9=" + temp9.Trim() == "000" ? "" : temp9.Trim() + "&caset=" + caset + "");
        
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

        protected void btn提交_Click(object sender, EventArgs e)
        {
            xiangmu1List xiangmu1List = new xiangmu1List();
            if (this.GridView2.Rows.Count <= 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请至少上传一个附件！");
                return;
            }
            //string id = HdID;
            

            //xiangmu1List.GetData(int.Parse(id));

            //if (base.Request.QueryString["caset"] == "1")
            //{
            //    xiangmu1List.col22 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "2")
            //{
            //    xiangmu1List.col23 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "3")
            //{
            //    xiangmu1List.col24 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "4")
            //{
            //    xiangmu1List.col25 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "5")
            //{
            //    xiangmu1List.col26 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "11")
            //{
            //    xiangmu1List.col22 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "12")
            //{
            //    xiangmu1List.col22 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "13")
            //{
            //    xiangmu1List.col22 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "14")
            //{
            //    xiangmu1List.col22 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "21")
            //{
            //    xiangmu1List.col23 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "22")
            //{
            //    xiangmu1List.col23 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "23")
            //{
            //    xiangmu1List.col23 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "24")
            //{
            //    xiangmu1List.col23 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "31")
            //{
            //    xiangmu1List.col24 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "32")
            //{
            //    xiangmu1List.col24 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "33")
            //{
            //    xiangmu1List.col24 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "34")
            //{
            //    xiangmu1List.col24 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "41")
            //{
            //    xiangmu1List.col25 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "42")
            //{
            //    xiangmu1List.col25 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "43")
            //{
            //    xiangmu1List.col25 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "44")
            //{
            //    xiangmu1List.col25 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "51")
            //{
            //    xiangmu1List.col26 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "52")
            //{
            //    xiangmu1List.col26 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "53")
            //{
            //    xiangmu1List.col26 = "1";
            //}
            //else if (base.Request.QueryString["caset"] == "54")
            //{
            //    xiangmu1List.col26 = "1";
            //}

            //xiangmu1List.UpdateData(int.Parse(id));

            string jscript = @"<script language=""javascript"" >
                                                    if(window.opener)
                                                    {
                                                       
                                                     window.opener.btnAddPartDetail();
                                                     
                                                        window.close();
                                                       
                                                    }
                                                    else
                                                    {

                                                    }
                                                </script>";


            Response.Write(jscript);
            //base.Response.Redirect("~/xiangmu9.aspx?temp1=" + temp1.Trim() == "000" ? "" : temp1.Trim() + "&temp2=" + temp2.Trim() == "000" ? "" : temp2.Trim() + "&temp3=" + temp3.Trim() == "000" ? "" : temp3.Trim() + "&temp4=" + temp4.Trim() == "000" ? "" : temp4.Trim() + "&temp5=" + temp5.Trim() == "000" ? "" : temp5.Trim() + "&temp6=" + temp6.Trim() == "000" ? "" : temp6.Trim() + "&temp7=" + temp7.Trim() == "000" ? "" : temp7.Trim() + "&temp8=" + temp8.Trim() == "000" ? "" : temp8.Trim() + "&temp9=" + temp9.Trim() == "000" ? "" : temp9.Trim() + "&caset=" + caset + "");
        }

        protected void btn关闭_Click(object sender, EventArgs e)
        {
            string jscript = @"<script> window.close(); </script>";

            Response.Write(jscript);
        }
       
    }
}