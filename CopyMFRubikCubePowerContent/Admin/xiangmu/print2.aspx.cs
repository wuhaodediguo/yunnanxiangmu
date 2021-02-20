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
    public partial class print2 : System.Web.UI.Page
    {
        public string strcase = string.Empty;
        public string strUserName = string.Empty;
        public string strRoleValue = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            strUserName = Request.QueryString["hdUserName"];
            strRoleValue = Request.QueryString["hdRoleValue"];
            TextBox1.Text = "打印时间：" + System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            TextBox12.Text = "打印时间：" + System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            TextBox结算单号.Text = base.Request.QueryString["id"];
            TextBox结算单号2.Text = base.Request.QueryString["id"];

            if (!base.IsPostBack)
            {
  
                TextBox申请人.Attributes.Add("readOnly", "readOnly");
                TextBox申请日期.Attributes.Add("readOnly", "readOnly");

                TextBox总包合同编号.Attributes.Add("readOnly", "readOnly");
                TextBox总包合同金额.Attributes.Add("readOnly", "readOnly");
                TextBox建设单位名称.Attributes.Add("readOnly", "readOnly");
                TextBox施工单位名称.Attributes.Add("readOnly", "readOnly");

                TextBox分包合同名称.Attributes.Add("readOnly", "readOnly");
                TextBox分包合同结算依据.Attributes.Add("readOnly", "readOnly");
                TextBox分包单位.Attributes.Add("readOnly", "readOnly");
                TextBox分包合同金额.Attributes.Add("readOnly", "readOnly");
                TextBox分包合同签订日期.Attributes.Add("readOnly", "readOnly");
                TextBox分包合同结算比例.Attributes.Add("readOnly", "readOnly");
                TextBox分包合同编号.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同名称.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同结算依据.Attributes.Add("readOnly", "readOnly");
                TextBox劳务单位.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");
                string zihuamianid = string.Empty;
                string idno = string.Empty;

                string role = "";
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


                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu5 where ID = " + idno + " ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (role == "审核")
                        {
                            
                            TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                            TextBox总包合同名称.Attributes.Add("readOnly", "readOnly");
                            TextBox总包合同编号.Attributes.Add("readOnly", "readOnly");
                            TextBox总包合同金额.Attributes.Add("readOnly", "readOnly");
                            TextBox建设单位名称.Attributes.Add("readOnly", "readOnly");
                            TextBox施工单位名称.Attributes.Add("readOnly", "readOnly");

                            TextBox分包合同名称.Attributes.Add("readOnly", "readOnly");
                            TextBox分包合同结算依据.Attributes.Add("readOnly", "readOnly");
                            TextBox分包单位.Attributes.Add("readOnly", "readOnly");
                            TextBox分包合同金额.Attributes.Add("readOnly", "readOnly");
                            TextBox分包合同签订日期.Attributes.Add("readOnly", "readOnly");
                            TextBox分包合同结算比例.Attributes.Add("readOnly", "readOnly");
                            TextBox分包合同编号.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务合同名称.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务合同结算依据.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务单位.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");

                            TextBox总包项目名称.Attributes.Add("readOnly", "readOnly");
                            TextBox总包项目编码.Attributes.Add("readOnly", "readOnly");
                            TextBox总包到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox总包发票金额.Attributes.Add("readOnly", "readOnly");
                            TextBox分包发票金额.Attributes.Add("readOnly", "readOnly");
                            TextBox分包到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox劳务单位开票金额.Attributes.Add("readOnly", "readOnly");
                            TextBox申请人.Attributes.Add("readOnly", "readOnly");
                            TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                            //TextBox项目实施单位发票附件.Attributes.Add("readOnly", "readOnly");
                            //TextBox付款凭证.Attributes.Add("readOnly", "readOnly");
                            TextBox备注.Attributes.Add("readOnly", "readOnly");
                            TextBox审批状态.Attributes.Add("readOnly", "readOnly");
  
                            this.GridView1.Enabled = false;
                        }

                        this.TextBox所属项目部.Text = ds.Tables[0].Rows[0]["col1"].ToString();

                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox总包合同名称.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox总包合同编号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox总包合同金额.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox建设单位名称.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox施工单位名称.Text = ds.Tables[0].Rows[0]["col7"].ToString();

                        TextBox分包合同名称.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox分包合同结算依据.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox分包单位.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox分包合同金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox分包合同签订日期.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox分包合同结算比例.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox分包合同编号.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox劳务合同名称.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox劳务合同结算依据.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox劳务单位.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox劳务合同金额.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox劳务合同签订日期.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox劳务合同结算比例.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox劳务合同编号.Text = ds.Tables[0].Rows[0]["col21"].ToString();

                        TextBox总包项目名称.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        TextBox总包项目编码.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox总包发票金额.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox总包到账金额.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox分包发票金额.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox分包到账金额.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox劳务单位开票金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox申请人.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox申请日期.Text = ds.Tables[0].Rows[0]["col30"].ToString();

                        TextBox申请人2.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox申请日期2.Text = ds.Tables[0].Rows[0]["col30"].ToString();
                        //TextBox项目实施单位发票附件.Text = ds.Tables[0].Rows[0]["col41"].ToString();
                        //TextBox付款凭证.Text = ds.Tables[0].Rows[0]["col42"].ToString();
                        ////TextBox审批状态.Text = ds.Tables[0].Rows[0]["col43"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col44"].ToString();

                        TextBoxbaocunnocol45.Text = ds.Tables[0].Rows[0]["col45"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["col46"].ToString();

                        TextBox审核人.Text = ds.Tables[0].Rows[0]["col50"].ToString();
                        TextBox49.Text = ds.Tables[0].Rows[0]["col49"].ToString();

                        zhuangtaiList list2 = new zhuangtaiList();
                        string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol45.Text + "' ";
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
                            TextBox审批状态.Text = ds.Tables[0].Rows[0]["col43"].ToString();
                        }

                        TextBox审批状态2.Text = TextBox审批状态.Text;
                        //if (TextBox项目实施单位发票附件.Text != "")
                        //{
                        //    项目实施单位发票附件href.HRef = TextBox项目实施单位发票附件.Text;
                        //    项目实施单位发票附件href.Visible = true;
                        //}
                        //if (TextBox付款凭证.Text != "")
                        //{
                        //    付款凭证href.HRef = TextBox付款凭证.Text;
                        //    付款凭证href.Visible = true;
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

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu55 where col9 = '" + id + "'");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        amount1 = 0;
                        ViewState["GridDataSource"] = ds.Tables[0];
                        this.GridView1.DataSource = ds.Tables[0];
                        this.GridView1.DataBind();

                    }
                    else
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col1");
                        dt.Columns.Add("col2");
                        dt.Columns.Add("col3");
                        dt.Columns.Add("col4");
                        dt.Columns.Add("col5");
                        dt.Columns.Add("col6");
                        dt.Columns.Add("col7");

                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        amount1 = 0;
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }
                }

                if (idno == "")
                {
                    idno = "00000";
                }

                DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu55 where col11 = '" + idno + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    amount1 = 0;
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
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col1");
                        dt.Columns.Add("col2");
                        dt.Columns.Add("col3");
                        dt.Columns.Add("col4");
                        dt.Columns.Add("col5");
                        dt.Columns.Add("col6");
                        dt.Columns.Add("col7");

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
                            dt.Columns.Add("col8");
                            dt.Columns.Add("col9");
                            dt.Columns.Add("col1");
                            dt.Columns.Add("col2");
                            dt.Columns.Add("col3");
                            dt.Columns.Add("col4");
                            dt.Columns.Add("col5");
                            dt.Columns.Add("col6");
                            dt.Columns.Add("col7");

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


        public decimal amount1 = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                amount1 += Convert.ToDecimal(((Label)e.Row.FindControl("lblcol32")).Text == "" ? "0" : ((Label)e.Row.FindControl("lblcol32")).Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "<span align='center'>合计:</span>";
                e.Row.Cells[4].Text = "<span align='center' >" + amount1 + "</span>";

            }
        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string stridno = ((Label)e.Row.FindControl("lblcol53")).Text;
                //string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((Label)e.Row.FindControl("lblcol2")).Text = ((Label)e.Row.FindControl("lblcol2")).Text + "开票申请";
                //((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol2")).Text;
                //((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + strid + "&&id=" + stridno + "&role=审核";
                //if (strcase == "6")
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + strid + "&&id=" + stridno + "&model=view";
                //}

            }
        }



    }
}