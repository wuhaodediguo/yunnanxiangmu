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

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class print1 : System.Web.UI.Page
    {
        public string strcase = string.Empty;
        public string strUserName = string.Empty;
        public string strRoleValue = string.Empty;

        public string role = "";
        public decimal aomunt1 = 0;
        public decimal aomunt2 = 0;
        public decimal aomunt3 = 0;
        public decimal aomunt4 = 0;
        public decimal dscount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            OledbHelper oledbHelper = new OledbHelper();
            DataTable dtshenhe = oledbHelper.GetDataTable("select * from t_shenhe where col2 = '" + this.Session["FullName"].ToString() + "' and col1 = '3' ");
            TextBox1.Text = "打印时间：" + System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            TextBox12.Text = "打印时间：" + System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            TextBox开票申请单号.Text = base.Request.QueryString["id"];
            TextBox开票申请单号2.Text = base.Request.QueryString["id"];

            if (!base.IsPostBack)
            {
               
                txt申请人.Attributes.Add("readOnly", "readOnly");
                TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                TextBox本次开票金额合计不含税.Attributes.Add("readOnly", "readOnly");
                TextBox税额合计.Attributes.Add("readOnly", "readOnly");
                TextBox本次发票价税合计金额.Attributes.Add("readOnly", "readOnly");
                TextBox税率.Attributes.Add("readOnly", "readOnly");

                string zihuamianid = string.Empty;
                string idno = string.Empty;
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    txt申请人.Attributes.Add("readOnly", "readOnly");
                    TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                    TextBox所属项目部.Enabled = false;
                    TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                    TextBox申请发票类型.Enabled = false;
                    TextBox申请发票类别.Enabled = false;
                    TextBox项目属性.Enabled = false;
                    TextBox合同类型.Enabled = false;
                    TextBox合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                    TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox跨区域经营地址.Attributes.Add("readOnly", "readOnly");
                    TextBox跨区域涉税事项报验管理编号.Attributes.Add("readOnly", "readOnly");
                    TextBox付款单位名称.Attributes.Add("readOnly", "readOnly");
                    TextBox开票单位名称.Attributes.Add("readOnly", "readOnly");
                    TextBox付款单位纳税人识别号.Attributes.Add("readOnly", "readOnly");
                    TextBox开票单位纳税人识别号.Attributes.Add("readOnly", "readOnly");
                    TextBox付款单位地址.Attributes.Add("readOnly", "readOnly");
                    TextBox开票单位地址.Attributes.Add("readOnly", "readOnly");
                    TextBox付款单位电话.Attributes.Add("readOnly", "readOnly");
                    TextBox开票单位电话.Attributes.Add("readOnly", "readOnly");
                    TextBox付款单位开户行.Attributes.Add("readOnly", "readOnly");
                    TextBox开票单位开户行.Attributes.Add("readOnly", "readOnly");
                    TextBox付款单位账号.Attributes.Add("readOnly", "readOnly");
                    TextBox开票单位账号.Attributes.Add("readOnly", "readOnly");
                    TextBox增值税预缴税款方式.Attributes.Add("readOnly", "readOnly");
                    TextBox增值税预缴税款地点.Attributes.Add("readOnly", "readOnly");
                    TextBox国税预缴金额.Attributes.Add("readOnly", "readOnly");
                    TextBox地税预缴金额.Attributes.Add("readOnly", "readOnly");
                    TextBox发票备注栏信息.Attributes.Add("readOnly", "readOnly");
                    TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                   
                    TextBox合同名称.Width = 955;
                    TextBox跨区域经营地址.Width = 380;
                    TextBox跨区域涉税事项报验管理编号.Width = 380;
                    TextBox付款单位名称.Width = 380;
                    TextBox开票单位名称.Width = 380;
                   
                    this.GridView1.Enabled = false;

                }

                if (base.Request.QueryString["role"] != null)
                {
                    role = base.Request.QueryString["role"].ToString();
                    if (role == "审核")
                    {

                        shdiv.Visible = true;
                       
                    }

                }
                if (base.Request.QueryString["idno"] != null )
                {

                    idno = base.Request.QueryString["idno"].ToString();

                    if (idno == "")
                    {
                        idno = "000000";
                    }
                    this.ViewState["IDNO"] = base.Request.QueryString["idno"].ToString();


                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where ID = " + idno + " ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (role == "审核")
                        {
                            txt申请人.Attributes.Add("readOnly", "readOnly");
                            TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                            TextBox所属项目部.Enabled = false;
                            TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                            TextBox申请发票类型.Enabled = false;
                            TextBox申请发票类别.Enabled = false;
                            TextBox项目属性.Enabled = false;
                            TextBox合同类型.Enabled = false;
                            TextBox增值税预缴税款方式.Enabled = false;
                            TextBox合同名称.Attributes.Add("readOnly", "readOnly");
                            TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                            TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                            TextBox跨区域经营地址.Attributes.Add("readOnly", "readOnly");
                            TextBox跨区域涉税事项报验管理编号.Attributes.Add("readOnly", "readOnly");
                            TextBox付款单位名称.Attributes.Add("readOnly", "readOnly");
                            TextBox开票单位名称.Attributes.Add("readOnly", "readOnly");
                            TextBox付款单位纳税人识别号.Attributes.Add("readOnly", "readOnly");
                            TextBox开票单位纳税人识别号.Attributes.Add("readOnly", "readOnly");
                            TextBox付款单位地址.Attributes.Add("readOnly", "readOnly");
                            TextBox开票单位地址.Attributes.Add("readOnly", "readOnly");
                            TextBox付款单位电话.Attributes.Add("readOnly", "readOnly");
                            TextBox开票单位电话.Attributes.Add("readOnly", "readOnly");
                            TextBox付款单位开户行.Attributes.Add("readOnly", "readOnly");
                            TextBox开票单位开户行.Attributes.Add("readOnly", "readOnly");
                            TextBox付款单位账号.Attributes.Add("readOnly", "readOnly");
                            TextBox开票单位账号.Attributes.Add("readOnly", "readOnly");
                            TextBox增值税预缴税款方式.Attributes.Add("readOnly", "readOnly");
                            TextBox增值税预缴税款地点.Attributes.Add("readOnly", "readOnly");
                            TextBox国税预缴金额.Attributes.Add("readOnly", "readOnly");
                            TextBox地税预缴金额.Attributes.Add("readOnly", "readOnly");
                            TextBox发票备注栏信息.Attributes.Add("readOnly", "readOnly");
                            TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                            
                            TextBox合同名称.Width = 955;
                            TextBox跨区域经营地址.Width = 380;
                            TextBox跨区域涉税事项报验管理编号.Width = 380;
                            TextBox付款单位名称.Width = 380;
                            TextBox开票单位名称.Width = 380;

                      
                            this.GridView1.Enabled = false;
                        }
                       
                        txt申请人.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox申请日期.Text = ds.Tables[0].Rows[0]["col2"].ToString();

                        this.TextBox所属项目部.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        //Drop所属项目部.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox申请发票类型.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox项目属性.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox申请发票类别.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox合同类型.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox合同名称.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox跨区域经营地址.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox跨区域涉税事项报验管理编号.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox付款单位名称.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox开票单位名称.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox付款单位纳税人识别号.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox开票单位纳税人识别号.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox付款单位地址.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox开票单位地址.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox付款单位电话.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox开票单位电话.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        TextBox付款单位开户行.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        TextBox开票单位开户行.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox付款单位账号.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox开票单位账号.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox增值税预缴税款方式.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox增值税预缴税款地点.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox国税预缴金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox地税预缴金额.Text = ds.Tables[0].Rows[0]["col29"].ToString();

                        TextBox发票备注栏信息.Text = ds.Tables[0].Rows[0]["col49"].ToString();
                        TextBoxbaocunnocol53.Text = ds.Tables[0].Rows[0]["col53"].ToString();

                        //TextBox开票申请表附件.Text = ds.Tables[0].Rows[0]["col50"].ToString();
                        //TextBox税票扫描件.Text = ds.Tables[0].Rows[0]["col37"].ToString();

                       
                        zhuangtaiList list2 = new zhuangtaiList();
                        string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol53.Text + "' ";
                        DataSet ds22 = Sql.SqlQueryDS(sql2);
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds22.Tables[0].Rows.Count; k++)
                            {
                                TextBox审批状态.Text += ds22.Tables[0].Rows[k]["col2"].ToString() + @"
";
                            }

                        }
                        else
                        {
                            TextBox审批状态.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        }
                        //string[] str审批状态 = ds.Tables[0].Rows[0]["col55"].ToString().Split(';');

                        //for (int k = 0; k < str审批状态.Length;k++ )
                        //{
                        //    if (str审批状态[k].ToString().Trim() == "")
                        //    {
                        //        continue;
                        //    }
                        //    TextBox审批状态.Text += str审批状态[k] + ";";
                        //}


                        //if (TextBox开票申请表附件.Text != "")
                        //{
                        //    开票申请表附件href.HRef = TextBox开票申请表附件.Text;
                        //    开票申请表附件href.Visible = true;
                        //}
                        //if (TextBox税票扫描件.Text != "")
                        //{
                        //    税票扫描件href.HRef = TextBox税票扫描件.Text;
                        //    税票扫描件href.Visible = true;
                        //}

                    }
                }
                if (base.Request.QueryString["id"] != null)
                {
                  
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        id = "000000";
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where col18 = '" + id + "'");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["GridDataSource"] = ds.Tables[0];
                        this.GridView1.DataSource = ds.Tables[0];
                        this.GridView1.DataBind();

                        TextBox本次开票金额合计不含税.Text = aomunt1.ToString();
                        TextBox税额合计.Text = aomunt2.ToString();
                        TextBox本次发票价税合计金额.Text = aomunt3.ToString();
                        TextBox税率.Text = ((aomunt4 / ds.Tables[0].Rows.Count) * 100).ToString("F0") + "%";

                    }
                    else
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;
                        dt.Columns.Add("id");
                        dt.Columns.Add("col17");
                        dt.Columns.Add("col18");
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col10");
                        dt.Columns.Add("col11");
                        dt.Columns.Add("col12");
                        dt.Columns.Add("col13");
                        dt.Columns.Add("col14");
                        dt.Columns.Add("col15");
                        dt.Columns.Add("col16");
                        dt.Columns.Add("col45");
                        dt.Columns.Add("col46");

                        dt.Columns.Add("col21");
                        dt.Columns.Add("col22");
                        dt.Columns.Add("col23");
                        dt.Columns.Add("col24");
                        dt.Columns.Add("col25");
                        dt.Columns.Add("col26");
                        dt.Columns.Add("col27");
                        dt.Columns.Add("col28");
                        dt.Columns.Add("col29");
                        dt.Columns.Add("col30");
                        dt.Columns.Add("col31");

                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }
                }

                if (idno == "")
                {
                    idno = "00000";
                }

                if (this.GridView1.Rows.Count > 0 && this.ViewState["ID"].ToString().Trim() != "")
                {
                    return;
                }
                DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu22 where col20 = '" + idno + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    ViewState["GridDataSource"] = ds2.Tables[0];
                    this.GridView1.DataSource = ds2.Tables[0];
                    this.GridView1.DataBind();

                }
                else
                {
                    DataTable dttep = (DataTable)ViewState["GridDataSource"];
                    if (dttep == null)
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;
                        dt.Columns.Add("id");
                        dt.Columns.Add("col17");
                        dt.Columns.Add("col18");
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col10");
                        dt.Columns.Add("col11");
                        dt.Columns.Add("col12");
                        dt.Columns.Add("col13");
                        dt.Columns.Add("col14");
                        dt.Columns.Add("col15");
                        dt.Columns.Add("col16");
                        dt.Columns.Add("col45");
                        dt.Columns.Add("col46");

                        dt.Columns.Add("col21");
                        dt.Columns.Add("col22");
                        dt.Columns.Add("col23");
                        dt.Columns.Add("col24");
                        dt.Columns.Add("col25");
                        dt.Columns.Add("col26");
                        dt.Columns.Add("col27");
                        dt.Columns.Add("col28");
                        dt.Columns.Add("col29");
                        dt.Columns.Add("col30");
                        dt.Columns.Add("col31");

                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }
                    else
                    {
                        if (dttep.Rows.Count == 0)
                        {
                            DataTable dt = new DataTable("column");
                            DataRow dr;
                            dt.Columns.Add("id");
                            dt.Columns.Add("col17");
                            dt.Columns.Add("col18");
                            dt.Columns.Add("col8");
                            dt.Columns.Add("col9");
                            dt.Columns.Add("col10");
                            dt.Columns.Add("col11");
                            dt.Columns.Add("col12");
                            dt.Columns.Add("col13");
                            dt.Columns.Add("col14");
                            dt.Columns.Add("col15");
                            dt.Columns.Add("col16");
                            dt.Columns.Add("col45");
                            dt.Columns.Add("col46");

                            dt.Columns.Add("col21");
                            dt.Columns.Add("col22");
                            dt.Columns.Add("col23");
                            dt.Columns.Add("col24");
                            dt.Columns.Add("col25");
                            dt.Columns.Add("col26");
                            dt.Columns.Add("col27");
                            dt.Columns.Add("col28");
                            dt.Columns.Add("col29");
                            dt.Columns.Add("col30");
                            dt.Columns.Add("col31");

                            dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            this.GridView1.DataSource = dt;
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = dt;
                        }
                    }

                }


            }
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                //((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol31")).Text;
                //((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2Add.aspx?id1=" + strid1 + "&id=" + hdNo.Text + "&idno=" + idno + "";
                //((HyperLink)e.Row.FindControl("HyperLink1")).Width = 200;
                //((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol31")).Width : ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12;

                ////((Label)e.Row.FindControl("lblcol31")).Width = ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol31")).Width : ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol32")).Width = ((Label)e.Row.FindControl("lblcol32")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol32")).Width : ((Label)e.Row.FindControl("lblcol32")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol33")).Width = ((Label)e.Row.FindControl("lblcol33")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol33")).Width : ((Label)e.Row.FindControl("lblcol33")).Text.Trim().Length * 12;

                //((Label)e.Row.FindControl("lblcol34")).Width = ((Label)e.Row.FindControl("lblcol34")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol34")).Width : ((Label)e.Row.FindControl("lblcol34")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol35")).Width = ((Label)e.Row.FindControl("lblcol35")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol35")).Width : ((Label)e.Row.FindControl("lblcol35")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol36")).Width = ((Label)e.Row.FindControl("lblcol36")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol36")).Width : ((Label)e.Row.FindControl("lblcol36")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol37")).Width = ((Label)e.Row.FindControl("lblcol37")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol37")).Width : ((Label)e.Row.FindControl("lblcol37")).Text.Trim().Length * 12;

                //((Label)e.Row.FindControl("lblcol38")).Width = ((Label)e.Row.FindControl("lblcol38")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol38")).Width : ((Label)e.Row.FindControl("lblcol38")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol39")).Width = ((Label)e.Row.FindControl("lblcol39")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol39")).Width : ((Label)e.Row.FindControl("lblcol39")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol40")).Width = ((Label)e.Row.FindControl("lblcol40")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol40")).Width : ((Label)e.Row.FindControl("lblcol40")).Text.Trim().Length * 12;

                //if (((HyperLink)e.Row.FindControl("HyperLink1")).Width.Value < 200)
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 200;
                //}
                //if (((Label)e.Row.FindControl("lblcol32")).Width.Value < 160)
                //{
                //    ((Label)e.Row.FindControl("lblcol32")).Width = 160;
                //}
                //if (((Label)e.Row.FindControl("lblcol33")).Width.Value < 160)
                //{
                //    ((Label)e.Row.FindControl("lblcol33")).Width = 160;
                //}
                //if (((Label)e.Row.FindControl("lblcol34")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol34")).Width = 100;
                //}
                //if (((Label)e.Row.FindControl("lblcol35")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol35")).Width = 100;
                //}
                //if (((Label)e.Row.FindControl("lblcol36")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol36")).Width = 100;
                //}
                //if (((Label)e.Row.FindControl("lblcol37")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol37")).Width = 100;
                //}
                //if (((Label)e.Row.FindControl("lblcol38")).Width.Value < 160)
                //{
                //    ((Label)e.Row.FindControl("lblcol38")).Width = 160;
                //}
                //if (((Label)e.Row.FindControl("lblcol39")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol39")).Width = 100;
                //}
                //if (((Label)e.Row.FindControl("lblcol40")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol40")).Width = 100;
                //}

                string str01 = ((Label)e.Row.FindControl("lblcol43")).Text;
                string str02 = ((Label)e.Row.FindControl("lblcol45")).Text;
                string str03 = ((Label)e.Row.FindControl("lblcol46")).Text;
                string str04 = ((Label)e.Row.FindControl("lblcol44")).Text;
                //string str01 = e.Row.Cells[17].Text;
                //string str02 = e.Row.Cells[19].Text;
                //string str03 = e.Row.Cells[20].Text;
                if (str01 == "" || str01 == "&nbsp;")
                {
                    str01 = "0";
                }
                if (str02 == "" || str02 == "&nbsp;")
                {
                    str02 = "0";
                }
                if (str03 == "" || str03 == "&nbsp;")
                {
                    str03 = "0";
                }
                aomunt1 += Convert.ToDecimal(str01);
                aomunt2 += Convert.ToDecimal(str02);
                aomunt3 += Convert.ToDecimal(str03);

                if (str04 == "3%")
                {
                    aomunt4 += Convert.ToDecimal(0.03);
                }
                else if (str04 == "6%")
                {
                    aomunt4 = Convert.ToDecimal(0.06);
                }
                else if (str04 == "10%")
                {
                    aomunt4 = Convert.ToDecimal(0.1);
                }
                else if (str04 == "16%")
                {
                    aomunt4 = Convert.ToDecimal(0.16);
                }
                dscount++;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[22].Text = "<span align='center' > " + aomunt1 + " </span>";
                e.Row.Cells[23].Text = "<span align='center' > " + ((aomunt4 / dscount) * 100).ToString("F0") + "%" + " </span>";
                e.Row.Cells[24].Text = "<span align='center' >" + aomunt2 + "</span>";
                e.Row.Cells[25].Text = "<span align='center' >" + aomunt3 + "</span>";
            }

        }

      

    }
}