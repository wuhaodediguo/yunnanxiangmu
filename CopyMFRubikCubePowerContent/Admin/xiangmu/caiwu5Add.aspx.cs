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
    public partial class caiwu5Add : System.Web.UI.Page
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
                TextBox总计到账金额.Attributes.Add("readOnly", "readOnly");
                TextBox到账情况.Attributes.Add("readOnly", "readOnly");
                string model22 = base.Request.QueryString["model22"];

                if (model22 == "shouye" && this.Session["RoleValue"].ToString() != "1")
                {
                    Button3.Visible = false;
                }

                if (base.Request.QueryString["idno"] != null)
                {
                    string id = base.Request.QueryString["idno"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["idno"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2view2 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txt发票单号.Attributes.Add("readOnly", "readOnly");
                        TextBox合同类型.Attributes.Add("readOnly", "readOnly");
                        TextBox合同名称.Attributes.Add("readOnly", "readOnly");
                        TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                        TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                        TextBox付款单位名称.Attributes.Add("readOnly", "readOnly");
                        TextBox开票单位名称.Attributes.Add("readOnly", "readOnly");
                        TextBox发票类型.Attributes.Add("readOnly", "readOnly");
                        TextBox发票类别.Attributes.Add("readOnly", "readOnly");
                        TextBox项目属性.Attributes.Add("readOnly", "readOnly");
                        TextBox所属项目部.Attributes.Add("readOnly", "readOnly");
                        TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                        TextBox发票状态.Attributes.Add("readOnly", "readOnly");
                        TextBox申请人.Attributes.Add("readOnly", "readOnly");
                        TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                        TextBox开票人.Attributes.Add("readOnly", "readOnly");
                        TextBox开票日期.Attributes.Add("readOnly", "readOnly");
                        TextBox发票备注栏信息.Attributes.Add("readOnly", "readOnly");
                        TextBox发票价税合计金额.Attributes.Add("readOnly", "readOnly");

                        txt发票单号.Text = ds.Tables[0].Rows[0]["col53"].ToString();
                        TextBox合同类型.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox合同名称.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox付款单位名称.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox开票单位名称.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox发票类型.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox发票类别.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox项目属性.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox所属项目部.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox发票状态.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        TextBox申请人.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox申请日期.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox开票人.Text = ds.Tables[0].Rows[0]["col31"].ToString();
                        TextBox开票日期.Text = ds.Tables[0].Rows[0]["col32"].ToString();

                        TextBox发票价税合计金额.Text = ds.Tables[0].Rows[0]["col666"].ToString();

                        TextBox第一次到账金额.Text = ds.Tables[0].Rows[0]["col39"].ToString();
                        TextBox第一次到账日期.Text = ds.Tables[0].Rows[0]["col40"].ToString();
                        TextBox第二次到账金额.Text = ds.Tables[0].Rows[0]["col41"].ToString();
                        TextBox第二次到账日期.Text = ds.Tables[0].Rows[0]["col42"].ToString();
                        TextBox第三次到账金额.Text = ds.Tables[0].Rows[0]["col43"].ToString();
                        TextBox第三次到账日期.Text = ds.Tables[0].Rows[0]["col44"].ToString();
                        TextBox第四次到账金额.Text = ds.Tables[0].Rows[0]["col45"].ToString();
                        TextBox第四次到账日期.Text = ds.Tables[0].Rows[0]["col46"].ToString();
                        TextBox第五次到账金额.Text = ds.Tables[0].Rows[0]["col47"].ToString();
                        TextBox第五次到账日期.Text = ds.Tables[0].Rows[0]["col48"].ToString();
                        TextBox总计到账金额.Text = ds.Tables[0].Rows[0]["col59"].ToString();
                        TextBox到账情况.Text = ds.Tables[0].Rows[0]["col60"].ToString();
                        TextBox发票备注栏信息.Text = ds.Tables[0].Rows[0]["col49"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col64"].ToString();

                        string model = base.Request.QueryString["model"];
                        if (model == "view")
                        {
                            TextBox第一次到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox第一次到账日期.Attributes.Add("readOnly", "readOnly");
                            TextBox第二次到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox第二次到账日期.Attributes.Add("readOnly", "readOnly");
                            TextBox第三次到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox第三次到账日期.Attributes.Add("readOnly", "readOnly");
                            TextBox第四次到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox第四次到账日期.Attributes.Add("readOnly", "readOnly");
                            TextBox第五次到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox第五次到账日期.Attributes.Add("readOnly", "readOnly");
                            TextBox总计到账金额.Attributes.Add("readOnly", "readOnly");
                            TextBox到账情况.Attributes.Add("readOnly", "readOnly");
                            TextBox备注.Attributes.Add("readOnly", "readOnly");
                        }
                        
                    }

                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyy-MM-dd");
            sql = "select max(col1) as col1 from t_caiwu3 where 1=1  ";
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

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[24]["col2"].ToString() == "1" && dataSource.Rows[24]["col1"].ToString() == "div0061")
                    {
                        dd0061.Visible = true;
                    }
                    else
                    {
                        dd0061.Visible = false;
                    }
                    if (dataSource.Rows[25]["col2"].ToString() == "1" && dataSource.Rows[25]["col1"].ToString() == "div0062")
                    {
                        dd0062.Visible = true;
                    }
                    else
                    {
                        dd0062.Visible = false;
                    }
                    if (dataSource.Rows[26]["col2"].ToString() == "1" && dataSource.Rows[26]["col1"].ToString() == "div0063")
                    {
                        dd0063.Visible = true;
                    }
                    else
                    {
                        dd0063.Visible = false;
                    }

                    if (dataSource.Rows[27]["col2"].ToString() == "1" && dataSource.Rows[27]["col1"].ToString() == "div0064")
                    {
                        dd0064.Visible = true;
                    }
                    else
                    {
                        dd0064.Visible = false;
                    }
                    if (dataSource.Rows[28]["col2"].ToString() == "1" && dataSource.Rows[28]["col1"].ToString() == "div0065")
                    {
                        dd0065.Visible = true;
                    }
                    else
                    {
                        dd0065.Visible = false;
                    }
                    if (dataSource.Rows[29]["col2"].ToString() == "1" && dataSource.Rows[29]["col1"].ToString() == "div0067")
                    {
                        dd0067.Visible = true;
                    }
                    else
                    {
                        dd0067.Visible = false;
                    }
                    //if (dataSource.Rows[29]["col2"].ToString() == "1" && dataSource.Rows[29]["col1"].ToString() == "div0067")
                    //{
                    //    dd0067.Visible = true;
                    //}
                    //else
                    //{
                    //    dd0067.Visible = false;
                    //}
                    //if (dataSource.Rows[30]["col2"].ToString() == "1" && dataSource.Rows[30]["col1"].ToString() == "div0068")
                    //{
                    //    dd0068.Visible = true;
                    //}
                    //else
                    //{
                    //    dd0068.Visible = false;
                    //}
                    if (dataSource.Rows[39]["col2"].ToString() == "1" && dataSource.Rows[39]["col1"].ToString() == "div0091")
                    {
                        dd0091.Visible = true;
                    }
                    else
                    {
                        dd0091.Visible = false;
                    }
                    if (dataSource.Rows[40]["col2"].ToString() == "1" && dataSource.Rows[40]["col1"].ToString() == "div0092")
                    {
                        dd0092.Visible = true;
                    }
                    else
                    {
                        dd0092.Visible = false;
                    }
                    if (dataSource.Rows[41]["col2"].ToString() == "1" && dataSource.Rows[41]["col1"].ToString() == "div0093")
                    {
                        dd0093.Visible = true;
                    }
                    else
                    {
                        dd0093.Visible = false;
                    }

                    if (dataSource.Rows[42]["col2"].ToString() == "1" && dataSource.Rows[42]["col1"].ToString() == "div0094")
                    {
                        dd0094.Visible = true;
                    }
                    else
                    {
                        dd0094.Visible = false;
                    }
                    if (dataSource.Rows[43]["col2"].ToString() == "1" && dataSource.Rows[43]["col1"].ToString() == "div0095")
                    {
                        dd0095.Visible = true;
                    }
                    else
                    {
                        dd0095.Visible = false;
                    }
                    if (dataSource.Rows[44]["col2"].ToString() == "1" && dataSource.Rows[44]["col1"].ToString() == "div0096")
                    {
                        dd0096.Visible = true;
                    }
                    else
                    {
                        dd0096.Visible = false;
                    }

                }

            }
            else
            {
                div0061.Visible = false;
                div0062.Visible = false;
                div0063.Visible = false;
                div0064.Visible = false;
                div0065.Visible = false;
                //div0066.Visible = false;
                div0067.Visible = false;
                //div0068.Visible = false;
                div0091.Visible = false;
                div0092.Visible = false;
                div0093.Visible = false;
                div0094.Visible = false;
                div0095.Visible = false;
                div0096.Visible = false;
            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.TextBox第一次到账金额.Text.Trim() != "" && this.TextBox第一次到账日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写第一次到账日期");
                return;
            }
            if (this.TextBox第二次到账金额.Text.Trim() != "" && this.TextBox第二次到账日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写第二次到账日期");
                return;
            }
            if (this.TextBox第三次到账金额.Text.Trim() != "" && this.TextBox第三次到账日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写第三次到账日期");
                return;
            }
            if (this.TextBox第四次到账金额.Text.Trim() != "" && this.TextBox第四次到账日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写第四次到账日期");
                return;
            }
            if (this.TextBox第五次到账金额.Text.Trim() != "" && this.TextBox第五次到账日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写第五次到账日期");
                return;
            }
           
            caiwu2List List = new caiwu2List();

            List.col39 = TextBox第一次到账金额.Text.Trim();
            List.col40 = TextBox第一次到账日期.Text.Trim();
            List.col41 = TextBox第二次到账金额.Text.Trim();
            List.col42 = TextBox第二次到账日期.Text.Trim();
            List.col43 = TextBox第三次到账金额.Text.Trim();
            List.col44 = TextBox第三次到账日期.Text.Trim();
            List.col45 = TextBox第四次到账金额.Text.Trim();
            List.col46 = TextBox第四次到账日期.Text.Trim();
            List.col47 = TextBox第五次到账金额.Text.Trim();
            List.col48 = TextBox第五次到账日期.Text.Trim();
            List.col59 = TextBox总计到账金额.Text.Trim();
            List.col60 = TextBox到账情况.Text.Trim();
            List.col64 = TextBox备注.Text.Trim();


            if (this.ViewState["ID"] != null)
            {
                List.ID = int.Parse(this.ViewState["ID"].ToString());
                List.UpdateDatashoukuan(List.ID);
            }

            caiwu51List List2 = new caiwu51List();
            List2.col9 = "1";
            List2.col1 = txt发票单号.Text;
            List2.UpdateData2();

            base.Response.Redirect("caiwu5.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            string model22 = base.Request.QueryString["model22"];

            if (model22 == "shouye")
            {
                base.Response.Redirect("shouye.aspx");
            }
            else
            {
                base.Response.Redirect("caiwu5.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            
        }

       


    }
}