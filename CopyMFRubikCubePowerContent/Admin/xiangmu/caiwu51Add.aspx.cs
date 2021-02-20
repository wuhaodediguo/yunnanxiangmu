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


namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
	public partial class caiwu51Add: System.Web.UI.Page
	{
        public static string RK_txtFormNo = "_FormNo";
        public static string RK_txtcishu = "_cishu";
        public static string RK_txtjine = "_txtjine";
        public static string RK_txtdate = "_txtdate";

        public static string querytxtFormNo = "";
        public static string querytxtcishu = "";
        public static string querytxtjine = "";
        public static string querytxtdate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (Request.QueryString[RK_txtFormNo] != null)
                {
                    querytxtFormNo = Request.QueryString[RK_txtFormNo];
                }
                if (Request.QueryString[RK_txtcishu] != null)
                {
                    querytxtcishu = Request.QueryString[RK_txtcishu];
                }
                if (Request.QueryString[RK_txtjine] != null)
                {
                    querytxtjine = Request.QueryString[RK_txtjine];
                }
                if (Request.QueryString[RK_txtdate] != null)
                {
                    querytxtdate = Request.QueryString[RK_txtdate];
                }
                TextBox开票申请单号.Text = querytxtFormNo;
                TextBox收款次数.Text = querytxtcishu;
 

                DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + TextBox开票申请单号.Text + "' and col2 = '" + TextBox收款次数.Text + "' and col9 ='1'  ");
                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                {
                    ViewState["GridDataSource2"] = ds1.Tables[0];
                    this.GridView1.DataSource = ds1.Tables[0];
                    this.GridView1.DataBind();

                }
                else
                {
                    DataSet ds22 = Sql.SqlQueryDS("select '" + TextBox开票申请单号.Text + "' as col1,'" + TextBox收款次数.Text + "' as col2,col8 as col3,col9 as col4,col22 as col5,'' as col6,'' as col7,'' as col8 from t_caiwu22 where col18 = '" + TextBox开票申请单号.Text + "'");
                    if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                    {
                        ViewState["GridDataSource2"] = ds22.Tables[0];
                        this.GridView1.DataSource = ds22.Tables[0];
                        this.GridView1.DataBind();

                    }
                }


            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            caiwu51List List = new caiwu51List();
            decimal amount = 0;
            string strdate = "";

            string sql = "delete from t_caiwu51 where col1 = '" + TextBox开票申请单号.Text + "' and col2 = '" + TextBox收款次数.Text + "' ";

            Sql.SqlQuery(sql);
            
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                List.col1 = TextBox开票申请单号.Text;
                List.col2 = TextBox收款次数.Text;
                List.col3 = ((Label)GridView1.Rows[i].FindControl("lblcol3")).Text.ToString();
                List.col4 = ((Label)GridView1.Rows[i].FindControl("lblcol4")).Text.ToString();
                List.col5 = ((Label)GridView1.Rows[i].FindControl("lblcol5")).Text.ToString();
                List.col6 = ((TextBox)GridView1.Rows[i].FindControl("txtcol6")).Text.ToString();
                List.col7 = ((TextBox)GridView1.Rows[i].FindControl("txtcol7")).Text.ToString();
                List.col8 = ((TextBox)GridView1.Rows[i].FindControl("txtcol8")).Text.ToString();
                amount += List.col6 == "" ? 0 : Convert.ToDecimal(List.col6);
                if (strdate == "")
                {
                    strdate = List.col7;
                }
                
                List.InsertData();

            }

            string jscript = @"<script language=""javascript"" >
                                                    if(window.opener)
                                                    {
                                                        var objUserID = window.opener.document.getElementById('#querytxtjine');
                                                        if (objUserID)
                                                        {
                                                            objUserID.value = '#txtjine';
                                                            objUserID.innerHTML = '#txtjine';
                                                        };
                                                        var objUserID2 = window.opener.document.getElementById('#querytxtdate');
                                                        if (objUserID2)
                                                        {
                                                            objUserID2.value = '#txtdate';
                                                            objUserID2.innerHTML = '#txtdate';
                                                        };

                                                    }
                                                    else
                                                    {

                                                    }
tongji();
                                                </script>";

            jscript = jscript.Replace("#querytxtjine", querytxtjine).Replace("#txtjine", amount.ToString("F2"))
                             .Replace("#querytxtdate", querytxtdate).Replace("#txtdate", strdate);

            Response.Write(jscript);
            ClosePopUpWindow();


        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            ClosePopUpWindow();
        }

        public void ClosePopUpWindow()
        {
            try
            {
                string jscript = @"<script>window.close();</script>";
                Response.Write(jscript);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
	}
}