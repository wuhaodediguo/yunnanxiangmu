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
    public partial class shenhecaozuo : System.Web.UI.Page
    {
        public string txtquanxian = "";
        public string fullname = "";
        public string tickedFormNo = "";
        private static string queryForm = "";
        public static string RK_WHFrom = "getid11";
        public static string shenherenyuan = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[RK_WHFrom] != null)
            {
                queryForm = Request.QueryString[RK_WHFrom];
                txtHideWHFrom.Text = queryForm;
                if (Request.QueryString["aaa"].ToString() == "1")
                {
                    Button1.Visible = true;
                }
                else if (Request.QueryString["aaa"].ToString() == "2")
                {
                    Button2.Visible = true;
                }
                else if (Request.QueryString["aaa"].ToString() == "3")
                {
                    Button3.Visible = true;
                    TextBox审核人员.Text = fullname;
                    span总包合同名称.Visible = false;
                    TextBox审核人员.Width = 400;
                }
            }
            fullname = Request.QueryString["fullname"].ToString();
            tickedFormNo = Request.QueryString["tickedFormNo"].ToString();
            txtquanxian = Request.QueryString["txtquanxian"].ToString();
            TextBoxquanxian.Text = txtquanxian;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu8 where col29 = " + tickedFormNo + " ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                shenherenyuan = ds.Tables[0].Rows[0]["col25"].ToString();
            }
        }

        //protected void getDropDownList审核人员()
        //{

        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    sql = "select col2,col1  from t_shenhe3 where 1=1     ";
        //    if (txtquanxian == "")
        //    {
        //        sql += "and col1 = '1' ";
        //    }
        //    if (txtquanxian == "1")
        //    {
        //        sql += "and col1 = '2' ";
        //    }
        //    else if (txtquanxian == "2")
        //    {
        //        sql += "and col1 = '3' ";
        //    }
        //    else if (txtquanxian == "3")
        //    {
        //        sql += "and col1 = '4' ";
        //    }
        //    else if (txtquanxian == "4")
        //    {
        //        sql += "and col1 = '5' ";
        //    }
        //    else if (txtquanxian == "5")
        //    {
        //        sql += "and col1 = '6' ";
        //    }
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    DropDownList审核人员.DataTextField = "col2";
        //    DropDownList审核人员.DataValueField = "col1";
        //    DropDownList审核人员.DataSource = dataSource;
        //    DropDownList审核人员.DataBind();
        //    DropDownList审核人员.Items.Insert(0, "");

        //}

        protected void btn提交2_Click(object sender, EventArgs e)
        {
            var tempszt = "已提交";
            if (this.TextBox审核人员.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核人员");
                return;
            }
            if (this.TextBox审核意见.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核意见");
                return;
            }
            caiwu8List List = new caiwu8List();
            List.GetData(int.Parse(tickedFormNo));

            List.col25 = fullname + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "已提交, " + TextBox审核人员.Text.Trim() + "未审批 ";

            List.col26 = this.Session["FullName"].ToString();

            List.col34 = tempszt; //状态
            List.UpdateDatashenhe2(int.Parse(tickedFormNo));

            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + List.col29 + "' and col2='" + List.col25 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = List.col29;
                list2.col2 = List.col25;
                list2.col3 = this.TextBox审核意见.Text.Trim();
                list2.InsertData();
            }

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

        }

        protected void btn审核通过_Click(object sender, EventArgs e)
        {
            OledbHelper oledbHelper = new OledbHelper();
            var tempszt = "已审核";
            if (this.TextBox审核人员.Text.Trim() == "")
            {
                string strsqls = string.Empty;
                strsqls = "select * from t_shenhe2 where 1=1 and col1 = '" + txtquanxian + "' ";
                DataTable dt审核人员 = oledbHelper.GetDataTable(strsqls);
                if (dt审核人员.Rows.Count > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核人员");
                    return;
                }
                else
                {
                    tempszt = "已完成";
                }
               
            }
            if (this.TextBox审核意见.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核意见");
                return;
            }
            if (!shenherenyuan.Trim().Contains(this.Session["FullName"].ToString() + "未审核"))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "只有审核人员" + this.Session["FullName"].ToString() + "可以审核！");
                return;
            }
            caiwu8List List = new caiwu8List();
            List.GetData(int.Parse(tickedFormNo));

            //审批状态
            
            string str审核人员 = string.Empty;
            string str新审核人员 = string.Empty;
            string sql审核人员 = "select * from t_shenhe3 where 1=1 and col2 = '" + this.Session["FullName"].ToString() + "' ";
            //DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            //if (dt审核人员.Rows.Count > 0)
            //{
            //    str审核人员 = dt审核人员.Rows[0]["col1"].ToString();
            //    int new审核 = int.Parse(str审核人员) + 1;
            //    sql审核人员 = "select * from t_shenhe2 where 1=1 and col1 = '" + new审核 + "' ";
            //    DataTable dt审核人员2 = oledbHelper.GetDataTable(sql审核人员);
            //    if (dt审核人员2.Rows.Count > 0)
            //    {
            //        str新审核人员 = dt审核人员2.Rows[0]["col2"].ToString();
            //    }
            //}
            string str新审核人员1 = TextBox审核人员.Text;
            if (str新审核人员1 != "")
            {
                str新审核人员1 = ";" + str新审核人员1 + "未审核";
                if (this.TextBox审核人员.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核人员");
                    return;
                }
            }

            List.col25 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "审核通过," + TextBox审核意见.Text.Trim() + ";" + str新审核人员1;

            List.col26 = this.Session["FullName"].ToString();

            List.col34 = tempszt; //状态
            List.UpdateDatashenhe2(int.Parse(tickedFormNo));

            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + List.col29 + "' and col2='" + List.col25 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);

            list2.col1 = List.col29;
            list2.col2 = List.col25;
            list2.col3 = this.TextBox审核意见.Text.Trim();
            list2.InsertData();
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                
            }

            List.col33 = TextBox审核人员value.Text;
            List.col30 = str新审核人员;
            List.col31 = TextBox审核人员.Text + "," + this.Session["FullName"].ToString();
            List.col32 = TextBox审核意见.Text.Trim();
            List.UpdateDatashenhe(int.Parse(tickedFormNo));

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

        }

        protected void btn审核不通过_Click(object sender, EventArgs e)
        {
            var tempszt = "已审核";
            if (this.TextBox审核人员.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核人员");
                return;
            }
            if (this.TextBox审核意见.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核意见");
                return;
            }
            if (!shenherenyuan.Trim().Contains(TextBox审核人员 + "未审核"))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "只有审核人员" + TextBox审核人员.Text + "可以审核！");
                return;
            }
            caiwu8List List = new caiwu8List();
            List.GetData(int.Parse(tickedFormNo));

            //审批状态
            OledbHelper oledbHelper = new OledbHelper();
            string str审核人员 = string.Empty;
            string str新审核人员 = string.Empty;
            string sql审核人员 = "select * from t_shenhe3 where 1=1 and col2 = '" + this.Session["FullName"].ToString() + "' ";
            //DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            //if (dt审核人员.Rows.Count > 0)
            //{
            //    str审核人员 = dt审核人员.Rows[0]["col1"].ToString();
            //    int new审核 = int.Parse(str审核人员) + 1;
            //    sql审核人员 = "select * from t_shenhe3 where 1=1 and col1 = '" + new审核 + "' ";
            //    DataTable dt审核人员2 = oledbHelper.GetDataTable(sql审核人员);
            //    if (dt审核人员2.Rows.Count > 0)
            //    {
            //        str新审核人员 = dt审核人员2.Rows[0]["col2"].ToString();
            //    }
            //}
            //string str新审核人员1 = string.Empty;
            //if (str新审核人员 != "")
            //{
            //    str新审核人员1 = ";" + str新审核人员 + "未审批";
            //    //if (this.TextBox审核人员.Text.Trim() == "")
            //    //{
            //    //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审核人员");
            //    //    return;
            //    //}
            //}

            List.col25 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "审核不通过，" + TextBox审核意见.Text.Trim() + ";" + fullname + "继续修改!";

            List.col26 = this.Session["FullName"].ToString();

            List.col34 = tempszt; //状态
            List.UpdateDatashenhe2(int.Parse(tickedFormNo));

            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + List.col29 + "' and col2='" + List.col25 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);

            list2.col1 = List.col29;
            list2.col2 = List.col25;
            list2.col3 = this.TextBox审核意见.Text.Trim();
            list2.InsertData();
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                
            }

            List.col33 = TextBox审核人员value.Text;
            List.col30 = str新审核人员;
            List.col31 = TextBox审核人员.Text + "," + this.Session["FullName"].ToString();
            List.col32 = TextBox审核意见.Text.Trim();
            List.UpdateDatashenhe(int.Parse(tickedFormNo));

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

        }



    }
}