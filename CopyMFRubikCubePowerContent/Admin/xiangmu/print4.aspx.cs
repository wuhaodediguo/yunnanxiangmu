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
    public partial class print4 : System.Web.UI.Page
    {
        public decimal amount1 = 0;
        public string tempzhuangtai = "";
        public string txtquanxian = "";

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
                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu5 where ID = " + idno + " ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {

                    Label所属项目部.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                    Label项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                    Label总包合同名称.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                    Label总包合同编号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                    Label总包合同金额.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                    Label建设单位名称.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                    Label施工单位名称.Text = ds.Tables[0].Rows[0]["col7"].ToString();

                    Label分包合同名称.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                    Label分包合同结算依据.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                    Label分包单位名称.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                    //Label分包合同金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                    //Label分包合同签订日期.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                    Label分包合同结算比例.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                    Label分包合同编号.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                    Label劳务合同名称.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                    Label劳务合同结算依据.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                    Label劳务单位名称.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                    //Label劳务合同金额.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                    //Label劳务合同签订日期.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                    Label劳务合同结算比例.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                    Label劳务合同编号.Text = ds.Tables[0].Rows[0]["col21"].ToString();

                    Label总包项目名称.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                    Label总包项目编码.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                    Label总包发票金额.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                    Label总包到账金额.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                    Label分包发票金额.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                    Label分包到账金额.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                    Label劳务单位开票金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                    Label申请人.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                    Label申请日期.Text = ds.Tables[0].Rows[0]["col30"].ToString();

                    TextBox审批流程.Text = ds.Tables[0].Rows[0]["col43"].ToString();

                    zhuangtaiList list2 = new zhuangtaiList();
                    string sql2 = "select * from t_zhuangtai where col1='" + ds.Tables[0].Rows[0]["col45"].ToString() + "' ";
                    DataSet ds22 = Sql.SqlQueryDS(sql2);
                    if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < ds22.Tables[0].Rows.Count; k++)
                        {
                            TextBox审批流程.Text += ds22.Tables[0].Rows[k]["col2"].ToString() + @"
";
                            if (k == ds22.Tables[0].Rows.Count - 1)
                            {
                                tempzhuangtai = ds22.Tables[0].Rows[k]["col2"].ToString();
                            }
                        }

                    }
                    else
                    {
                        TextBox审批流程.Text = ds.Tables[0].Rows[0]["col43"].ToString();
                    }


                }

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}