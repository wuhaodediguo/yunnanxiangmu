using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Data;
using System.Text;
using System.Collections;
using System.IO;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class print3 : System.Web.UI.Page
    {
        public decimal amount1 = 0;
        public string tempzhuangtai = "";
        public string txtquanxian = "";

        public decimal aomunt11 = 0;
        public decimal aomunt12 = 0;
        public decimal aomunt13 = 0;
        public decimal aomunt14 = 0;
        public decimal aomunt15 = 0;
        public decimal aomunt16 = 0;
        public decimal aomunt17 = 0;
        public string strcase = string.Empty;
        public string strUserName = string.Empty;
        public string strRoleValue = string.Empty;
        public string idno = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            strUserName = Request.QueryString["hdUserName"];
            strRoleValue = Request.QueryString["hdRoleValue"];
            Label155.Text = "打印日期：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            Label157.Text = "打印人：" + this.Session["FullName"].ToString();
            Label付款单号.Text = "付款单号：" + base.Request.QueryString["id"];
            idno = base.Request.QueryString["idno"];
            if (!base.IsPostBack)
            { 
                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu8 where ID = " + idno + " ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {

                    Label所属项目部.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                    Label项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                    Label总包合同名称.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                    Label总包合同编号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                    Label劳务合同名称.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                    Label劳务单位名称.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                    Label劳务合同编号.Text = ds.Tables[0].Rows[0]["col7"].ToString();

                    Label劳务合同结算依据.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                    Label收款人名称.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                    Label收款人银行账号.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                    Label收款人开户行.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                    Label已经支付金额小写.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                    Label已经支付金额大写.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                    Label本次申请支付发票金额小写.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                    Label本次申请支付发票金额大写.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                    Label本次申请支付实际金额小写.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                    Label本次申请支付实际金额大写.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                    Label本次申请支付发票号码.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                    Label付款依据.Text = ds.Tables[0].Rows[0]["col19"].ToString();

                    Label申请人.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                    Label申请日期.Text = ds.Tables[0].Rows[0]["col21"].ToString();

                    TextBox审批流程.Text = ds.Tables[0].Rows[0]["col32"].ToString();

                    zhuangtaiList list2 = new zhuangtaiList();
                    string sql2 = "select * from t_zhuangtai where col1='" + ds.Tables[0].Rows[0]["col29"].ToString() + "' ";
                    DataSet ds22 = Sql.SqlQueryDS(sql2);
                    if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < ds22.Tables[0].Rows.Count; k++)
                        {
                            TextBox审批流程.Text += ds22.Tables[0].Rows[k]["col2"].ToString() + @"
";
                            //if (k == ds22.Tables[0].Rows.Count - 1)
                            //{
                            //    tempzhuangtai = ds22.Tables[0].Rows[k]["col2"].ToString();
                            //}
                        }

                    }
                    else
                    {
                        TextBox审批流程.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                    }


                    DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu81 where col14 = '" + idno + "' ");
                    if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        amount1 = 0;
                        ViewState["GridDataSource"] = ds2.Tables[0];
                        this.GridView1.DataSource = ds2.Tables[0];
                        this.GridView1.DataBind();

                        Label已经支付金额小写.Text = aomunt11.ToString();
                        Label本次申请支付发票金额小写.Text = aomunt12.ToString();
                        Label本次申请支付实际金额小写.Text = aomunt13.ToString();

                    }
                
                }
            
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str01 = ((Label)e.Row.FindControl("lbl总包发票金额")).Text;
                string str02 = ((Label)e.Row.FindControl("lbl总包到账金额")).Text;
                string str03 = ((Label)e.Row.FindControl("lbl分包发票金额")).Text;
                string str04 = ((Label)e.Row.FindControl("lbl分包到账金额")).Text;
                string str05 = ((Label)e.Row.FindControl("lbl劳务单位开票金额")).Text;
                string str06 = ((Label)e.Row.FindControl("lbl已经支付金额")).Text;
                string str07 = ((Label)e.Row.FindControl("lbl本次申请支付金额")).Text;

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
                if (str04 == "" || str04 == "&nbsp;")
                {
                    str04 = "0";
                }
                if (str05 == "" || str05 == "&nbsp;")
                {
                    str05 = "0";
                }
                if (str06 == "" || str06 == "&nbsp;")
                {
                    str06 = "0";
                }
                if (str07 == "" || str07 == "&nbsp;")
                {
                    str07 = "0";
                }

                aomunt11 += Convert.ToDecimal(str01);
                aomunt12 += Convert.ToDecimal(str02);
                aomunt13 += Convert.ToDecimal(str03);
                aomunt14 += Convert.ToDecimal(str04);
                aomunt15 += Convert.ToDecimal(str05);
                aomunt16 += Convert.ToDecimal(str06);
                aomunt17 += Convert.ToDecimal(str07);

                //e.Row.Cells[1].Text = Server.HtmlDecode(e.Row.Cells[1].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "<span align='center'>合计:</span>";
                e.Row.Cells[4].Text = "<span align='center' >" + aomunt11 + "</span>";
                e.Row.Cells[5].Text = "<span align='center' >" + aomunt12 + "</span>";
                e.Row.Cells[6].Text = "<span align='center' >" + aomunt13 + "</span>";
                e.Row.Cells[7].Text = "<span align='center' >" + aomunt14 + "</span>";
                e.Row.Cells[8].Text = "<span align='center' >" + aomunt15 + "</span>";
                e.Row.Cells[9].Text = "<span align='center' >" + aomunt16 + "</span>";
                e.Row.Cells[10].Text = "<span align='center' >" + aomunt17 + "</span>";
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

    }
}