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
    public partial class xiangmu2Add : System.Web.UI.Page
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

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;
                    FileUpload3.Visible = false;
                    FileUpload4.Visible = false;
                    FileUpload5.Visible = false;

                    Button4.Visible = false;
                    Button5.Visible = false;
                    Button6.Visible = false;
                    Button1.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = false;

                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = false;
                    LinkButton4.Visible = false;

                }

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txt合同名称.Attributes.Add("readOnly", "readOnly");
                        TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                        TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                        TextBox建设单位.Attributes.Add("readOnly", "readOnly");
                        TextBox施工单位.Attributes.Add("readOnly", "readOnly");
                        TextBox项目部.Attributes.Add("readOnly", "readOnly");
                        TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                        TextBox项目名称.Attributes.Add("readOnly", "readOnly");
                        TextBox项目编码.Attributes.Add("readOnly", "readOnly");
                        TextBox单项工程名称.Attributes.Add("readOnly", "readOnly");
                        TextBox结算金额不含税.Attributes.Add("readOnly", "readOnly");
                        TextBox税率1.Attributes.Add("readOnly", "readOnly");
                        TextBox税额1.Attributes.Add("readOnly", "readOnly");
                        TextBox结算金额含税.Attributes.Add("readOnly", "readOnly");
                        TextBox审定金额不含税.Attributes.Add("readOnly", "readOnly");
                        TextBox税率2.Attributes.Add("readOnly", "readOnly");
                        TextBox税额2.Attributes.Add("readOnly", "readOnly");
                        TextBox审定金额含税.Attributes.Add("readOnly", "readOnly");
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                        TextBox结算类型.Attributes.Add("readOnly", "readOnly");
                        TextBox开票金额.Attributes.Add("readOnly", "readOnly");
                        TextBox货物服务名称.Attributes.Add("readOnly", "readOnly");
                        TextBox发票类型.Attributes.Add("readOnly", "readOnly");
                        TextBox发票类别.Attributes.Add("readOnly", "readOnly");
                        TextBox税率.Attributes.Add("readOnly", "readOnly");
                        TextBox开票日期.Attributes.Add("readOnly", "readOnly");

                        txt合同名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox建设单位.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox施工单位.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox项目部.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox项目名称.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox项目编码.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox单项工程名称.Text = ds.Tables[0].Rows[0]["col10"].ToString();

                        TextBox结算金额不含税.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox税率1.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox税额1.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox结算金额含税.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox审定金额不含税.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox税率2.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox税额2.Text = ds.Tables[0].Rows[0]["col45"].ToString();
                        TextBox审定金额含税.Text = ds.Tables[0].Rows[0]["col46"].ToString();

                        TextBox结算类型.Text = ds.Tables[0].Rows[0]["col47"].ToString();

                        TextBox备注.Text = ds.Tables[0].Rows[0]["col48"].ToString();

                        TextBox开票金额.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        TextBox货物服务名称.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox发票类型.Text = ds.Tables[0].Rows[0]["col39"].ToString();
                        TextBox发票类别.Text = ds.Tables[0].Rows[0]["col40"].ToString();
                        TextBox税率.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox开票日期.Text = ds.Tables[0].Rows[0]["col42"].ToString();

                        TextBox发票扫描件.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        TextBox采购订单扫描件.Text = ds.Tables[0].Rows[0]["col34"].ToString();
                        TextBox完工结算证明扫描件.Text = ds.Tables[0].Rows[0]["col35"].ToString();
                        TextBox审计定案扫描件.Text = ds.Tables[0].Rows[0]["col36"].ToString();
                        TextBox竣工资料及图纸附件.Text = ds.Tables[0].Rows[0]["col37"].ToString();

                        //TextBox到账金额.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        //TextBox到账日期.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        //TextBox未到账金额.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        //TextBox项目状态.Text = ds.Tables[0].Rows[0]["col30"].ToString();
                        

                        //if (TextBox发票扫描件.Text != "")
                        //{
                        //    发票扫描件href.HRef = TextBox发票扫描件.Text;
                        //    发票扫描件href.Visible = true;
                        //}
                        //if (TextBox采购订单扫描件.Text != "")
                        //{
                        //    采购订单扫描件href.HRef = TextBox采购订单扫描件.Text;
                        //    采购订单扫描件href.Visible = true;
                        //}
                        //if (TextBox完工结算证明扫描件.Text != "")
                        //{
                        //    完工结算证明扫描件href.HRef = TextBox完工结算证明扫描件.Text;
                        //    完工结算证明扫描件href.Visible = true;
                        //}
                        //if (TextBox审计定案扫描件.Text != "")
                        //{
                        //    审计定案扫描件href.HRef = TextBox审计定案扫描件.Text;
                        //    审计定案扫描件href.Visible = true;
                        //}
                        //if (TextBox竣工资料及图纸附件.Text != "")
                        //{
                        //    竣工资料及图纸附件href.HRef = TextBox竣工资料及图纸附件.Text;
                        //    竣工资料及图纸附件href.Visible = true;
                        //}

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu21' and col1='" + id + "' ");
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

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu22' and col1='" + id + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu23' and col1='" + id + "' ");
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

                        DataSet ds24 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu24' and col1='" + id + "' ");
                        if (ds24 != null && ds24.Tables[0] != null && ds24.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件4.Value = ds24.Tables[0].Rows[0]["col2"].ToString();
                            GridView4.DataSource = ds24.Tables[0];
                            GridView4.DataBind();
                            ViewState["GridDataSource4"] = ds24.Tables[0];
                        }
                        else
                        {
                            HdCol2附件4.Value = "";
                            GridView4.DataSource = null;
                            GridView4.DataBind();
                        }

                        DataSet ds25 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu25' and col1='" + id + "' ");
                        if (ds25 != null && ds25.Tables[0] != null && ds25.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件5.Value = ds25.Tables[0].Rows[0]["col2"].ToString();
                            GridView5.DataSource = ds25.Tables[0];
                            GridView5.DataBind();
                            ViewState["GridDataSource5"] = ds25.Tables[0];
                        }
                        else
                        {
                            HdCol2附件5.Value = "";
                            GridView5.DataSource = null;
                            GridView5.DataBind();
                        }

                    }

                }
                if (model == "shenhe")
                {
                    div保存.Visible = false;
                    div返回.Visible = false;
                    div审核.Visible = true;
                    TextBox发票扫描件.Attributes.Add("readOnly", "readOnly");
                    TextBox采购订单扫描件.Attributes.Add("readOnly", "readOnly");
                    TextBox完工结算证明扫描件.Attributes.Add("readOnly", "readOnly");
                    TextBox审计定案扫描件.Attributes.Add("readOnly", "readOnly");
                    TextBox竣工资料及图纸附件.Attributes.Add("readOnly", "readOnly");
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;
                    FileUpload3.Visible = false;
                    FileUpload4.Visible = false;
                    FileUpload5.Visible = false;
                    this.GridView1.Enabled = false;
                    this.GridView2.Enabled = false;
                    this.GridView3.Enabled = false;
                    this.GridView4.Enabled = false;
                    this.GridView5.Enabled = false;
                   
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
                    if (dataSource.Rows[11]["col2"].ToString() == "1" && dataSource.Rows[11]["col1"].ToString() == "div0041")
                    {
                        dd0041.Visible = true;
                    }
                    else
                    {
                        dd0041.Visible = false;
                    }
                    if (dataSource.Rows[12]["col2"].ToString() == "1" && dataSource.Rows[12]["col1"].ToString() == "div0042")
                    {
                        dd0042.Visible = true;
                    }
                    else
                    {
                        dd0042.Visible = false;
                    }
                    if (dataSource.Rows[13]["col2"].ToString() == "1" && dataSource.Rows[13]["col1"].ToString() == "div0043")
                    {
                        dd0043.Visible = true;
                    }
                    else
                    {
                        dd0043.Visible = false;
                    }
                    if (dataSource.Rows[14]["col2"].ToString() == "1" && dataSource.Rows[14]["col1"].ToString() == "div0044")
                    {
                        dd0044.Visible = true;
                    }
                    else
                    {
                        dd0044.Visible = false;
                    }
                    if (dataSource.Rows[15]["col2"].ToString() == "1" && dataSource.Rows[15]["col1"].ToString() == "div0045")
                    {
                        dd0045.Visible = true;
                    }
                    else
                    {
                        dd0045.Visible = false;
                    }
                    if (dataSource.Rows[16]["col2"].ToString() == "1" && dataSource.Rows[16]["col1"].ToString() == "div0046")
                    {
                        dd0046.Visible = true;
                    }
                    else
                    {
                        dd0046.Visible = false;
                    }

                }

            }
            else
            {
                div0041.Visible = false;
                div0045.Visible = false;
                div0042.Visible = false;
                div0043.Visible = false;
                div0044.Visible = false;
                div0046.Visible = false;

            }


        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox合同编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同编号");
                return;
            }
            if (this.TextBox建设单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写建设单位");
                return;
            }
            if (this.TextBox施工单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工单位");
                return;
            }

            caiwu22List shichangList = new caiwu22List();
            //shichangList.col1 = txt合同名称.Text.Trim();
            //shichangList.col2 = TextBox合同编号.Text.Trim();
            //shichangList.col3 = TextBox合同金额.Text.Trim();
            //shichangList.col4 = TextBox建设单位.Text.Trim();
            //shichangList.col5 = TextBox施工单位.Text.Trim();
            //shichangList.col6 = TextBox项目部.Text.Trim();
            //shichangList.col7 = TextBox项目经理.Text.Trim();
            //shichangList.col8 = TextBox项目名称.Text.Trim();
            //shichangList.col9 = TextBox项目编码.Text.Trim();
            //shichangList.col10 = TextBox单项工程名称.Text.Trim();
            //shichangList.col11 = TextBox结算金额.Text.Trim();
            //shichangList.col12 = TextBox审定金额.Text.Trim();
            //shichangList.col13 = TextBox创建人.Text.Trim();
            //shichangList.col14 = TextBox创建日期.Text.Trim();
            //shichangList.col15 = TextBox备注.Text.Trim();

            //shichangList.col16 = TextBox开票金额.Text.Trim();
            //shichangList.col17 = TextBox货物服务名称.Text.Trim();
            //shichangList.col18 = TextBox发票类型.Text.Trim();
            //shichangList.col19 = TextBox发票类别.Text.Trim();
            //shichangList.col20 = TextBox税率.Text.Trim();
            //shichangList.col21 = TextBox开票日期.Text.Trim();

            //shichangList.col22 = TextBox发票扫描件.Text.Trim();
            //shichangList.col23 = TextBox采购订单扫描件.Text.Trim();
            //shichangList.col24 = TextBox完工结算证明扫描件.Text.Trim();
            //shichangList.col25 = TextBox审计定案扫描件.Text.Trim();
            //shichangList.col26 = TextBox竣工资料及图纸附件.Text.Trim();

            //shichangList.col27 = TextBox到账金额.Text.Trim();
            //shichangList.col28 = TextBox到账日期.Text.Trim();
            //shichangList.col29 = TextBox未到账金额.Text.Trim();
            //shichangList.col30 = TextBox项目状态.Text.Trim();
            //shichangList.col31 = TextBox结算类型.Text;
            //shichangList.col32 = "1";//资料上传
            if (this.GridView1.Rows.Count == 0)
            {
                shichangList.col33 = "0";
            }
            else
            {
                shichangList.col33 = "1";
            }

            if (this.GridView2.Rows.Count == 0)
            {
                shichangList.col34 = "0";
            }
            else
            {
                shichangList.col34 = "1";
            }

            if (this.GridView3.Rows.Count == 0)
            {
                shichangList.col35 = "0";
            }
            else
            {
                shichangList.col35 = "1";
            }
            if (this.GridView4.Rows.Count == 0)
            {
                shichangList.col36 = "0";
            }
            else
            {
                shichangList.col36 = "1";
            }
            if (this.GridView5.Rows.Count == 0)
            {
                shichangList.col37 = "0";
            }
            else
            {
                shichangList.col37 = "1";
            }
            //shichangList.col33 = TextBox发票扫描件.Text.Trim();
            //shichangList.col34 = TextBox采购订单扫描件.Text.Trim();
            //shichangList.col35 = TextBox完工结算证明扫描件.Text.Trim();
            //shichangList.col36 = TextBox审计定案扫描件.Text.Trim();
            //shichangList.col37 = TextBox竣工资料及图纸附件.Text.Trim();
            //if (TextBox发票扫描件.Text.Trim() != "" && TextBox采购订单扫描件.Text.Trim() != "" && TextBox完工结算证明扫描件.Text.Trim() != "" && TextBox审计定案扫描件.Text.Trim() != "" && TextBox竣工资料及图纸附件.Text.Trim() != "")
            //{
            //    shichangList.col38 = "1";//资料上传
            //}
            //else
            //{
            //    shichangList.col38 = "0";//资料上传
            //}
            if (shichangList.col33 == "1" && shichangList.col34 == "1" && shichangList.col35 == "1" && shichangList.col36 == "1" && shichangList.col37 == "1")
            {
                shichangList.col38 = "1";//资料上传
            }
            else
            {
                shichangList.col38 = "0";//资料上传
            }
           
            shichangList.col48 = TextBox备注.Text.Trim();
            //shichangList.col14 = TextBox创建人.Text;//资料上传
            //shichangList.col15 = TextBox创建日期.Text;//资料上传
           
            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());
                shichangList.UpdateDataziliao(shichangList.ID);
            }
            else
            {
                shichangList.InsertData();
            }

            base.Response.Redirect("xiangmu2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn提交_Click(object sender, EventArgs e)
        {
            if (this.txt合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox合同编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同编号");
                return;
            }
            if (this.TextBox建设单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写建设单位");
                return;
            }
            if (this.TextBox施工单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工单位");
                return;
            }

            if (this.GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传发票扫描件附件");
                return;
            }
            if (this.GridView2.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传采购订单扫描件附件");
                return;
            }
            if (this.GridView3.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传完工结算证明扫描件附件");
                return;
            }

            if (this.TextBox审定金额不含税.Text.Trim() != "")
            {
                if (this.GridView4.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传审计定案扫描件附件");
                    return;
                }
            }
            
            if (this.GridView5.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传竣工资料及图纸附件附件");
                return;
            }

            caiwu22List shichangList = new caiwu22List();
            
            if (this.GridView1.Rows.Count == 0)
            {
                shichangList.col33 = "0";
            }
            else
            {
                shichangList.col33 = "1";
            }

            if (this.GridView2.Rows.Count == 0)
            {
                shichangList.col34 = "0";
            }
            else
            {
                shichangList.col34 = "1";
            }

            if (this.GridView3.Rows.Count == 0)
            {
                shichangList.col35 = "0";
            }
            else
            {
                shichangList.col35 = "1";
            }
            if (this.GridView4.Rows.Count == 0)
            {
                shichangList.col36 = "0";
            }
            else
            {
                shichangList.col36 = "1";
            }
            if (this.GridView5.Rows.Count == 0)
            {
                shichangList.col37 = "0";
            }
            else
            {
                shichangList.col37 = "1";
            }
            //shichangList.col33 = TextBox发票扫描件.Text.Trim();
            //shichangList.col34 = TextBox采购订单扫描件.Text.Trim();
            //shichangList.col35 = TextBox完工结算证明扫描件.Text.Trim();
            //shichangList.col36 = TextBox审计定案扫描件.Text.Trim();
            //shichangList.col37 = TextBox竣工资料及图纸附件.Text.Trim();
            //if (TextBox发票扫描件.Text.Trim() != "" && TextBox采购订单扫描件.Text.Trim() != "" && TextBox完工结算证明扫描件.Text.Trim() != "" && TextBox审计定案扫描件.Text.Trim() != "" && TextBox竣工资料及图纸附件.Text.Trim() != "")
            //{
            //    shichangList.col38 = "1";//资料上传
            //}
            //else
            //{
            //    shichangList.col38 = "0";//资料上传
            //}
            if (shichangList.col33 == "1" && shichangList.col34 == "1" && shichangList.col35 == "1" && shichangList.col36 == "1" && shichangList.col37 == "1")
            {
                shichangList.col38 = "1";//资料上传
            }
            else
            {
                shichangList.col38 = "0";//资料上传
            }

            shichangList.col48 = TextBox备注.Text.Trim();
            //shichangList.col14 = TextBox创建人.Text;//资料上传
            //shichangList.col15 = TextBox创建日期.Text;//资料上传

            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());
                shichangList.UpdateDataziliao(shichangList.ID);
            }
            else
            {
                shichangList.InsertData();
            }

            base.Response.Redirect("xiangmu2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }


        protected void btn返回_Click(object sender, EventArgs e)
        {
            var model = base.Request.QueryString["model"];
            if (model == "shenhe")
            {
                base.Response.Redirect("xiangmu5.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            else
            {
                base.Response.Redirect("xiangmu2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            
        }

        protected void btn审核_Click(object sender, EventArgs e)
        {
            caiwu22List List = new caiwu22List();
            var model = base.Request.QueryString["model"];
            if (model == "shenhe")
            {
                List.ID = int.Parse(this.ViewState["ID"].ToString());
                List.col50 = "审核通过";
                List.UpdateData审核(List.ID);
            }

            base.Response.Redirect("xiangmu5.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload发票扫描件Button_Click(object sender, EventArgs e)
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

                发票扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox发票扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "xiangmu21";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu21' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload采购订单扫描件Button_Click(object sender, EventArgs e)
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

                采购订单扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox采购订单扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "xiangmu22";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu22' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload完工结算证明扫描件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload3.PostedFile.FileName;
                FileUpload3.SaveAs(filePath + fileName);

                完工结算证明扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox完工结算证明扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "xiangmu23";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu23' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload审计定案扫描件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload4.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload4.PostedFile.FileName;
                FileUpload4.SaveAs(filePath + fileName);

                审计定案扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox审计定案扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "xiangmu24";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件4.Value == "" ? CreateNext() : HdCol2附件4.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu24' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件4.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView4.DataSource = ds2.Tables[0];
                    GridView4.DataBind();
                    ViewState["GridDataSource4"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件4.Value = "";
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload竣工资料及图纸附件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload5.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload5.PostedFile.FileName;
                FileUpload5.SaveAs(filePath + fileName);

                竣工资料及图纸附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox竣工资料及图纸附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "xiangmu25";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件5.Value == "" ? CreateNext() : HdCol2附件5.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu25' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件5.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView5.DataSource = ds2.Tables[0];
                    GridView5.DataBind();
                    ViewState["GridDataSource5"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件5.Value = "";
                    GridView5.DataSource = null;
                    GridView5.DataBind();
                }

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox发票扫描件.Text = "";
                发票扫描件href.HRef = "";
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox采购订单扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox采购订单扫描件.Text = "";
                采购订单扫描件href.HRef = "";
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox完工结算证明扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox完工结算证明扫描件.Text = "";
                完工结算证明扫描件href.HRef = "";
            }
        }

        protected void btnAttach4_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox审计定案扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox审计定案扫描件.Text = "";
                审计定案扫描件href.HRef = "";
            }
        }

        protected void btnAttach5_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox竣工资料及图纸附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox竣工资料及图纸附件.Text = "";
                竣工资料及图纸附件href.HRef = "";
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
                        ((HyperLink)e.Row.FindControl("HyperLink1")).Attributes.Add("style", "word-break :break-all ; word-wrap:break-word");

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
                        //((HyperLink)e.Row.FindControl("HyperLink1")).Attributes.Add("style", "word-break :break-all ; word-wrap:break-word");
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

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource4"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView4.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView4.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource4"] = dtnew;
                this.GridView4.DataSource = dtnew;
                this.GridView4.DataBind();

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

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource5"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView5.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView5.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource5"] = dtnew;
                this.GridView5.DataSource = dtnew;
                this.GridView5.DataBind();

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



    }
}