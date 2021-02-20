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
    public partial class caiwu2Add : System.Web.UI.Page
    {
        string t1 = string.Empty;
        string t2 = string.Empty;
        string t3 = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["t1"] != null)
                {
                    t1 = base.Request.QueryString["t1"].ToString();
                }
                if (base.Request.QueryString["t2"] != null)
                {
                    t2 = base.Request.QueryString["t2"].ToString();
                }
                if (base.Request.QueryString["t3"] != null)
                {
                    t3 = base.Request.QueryString["t3"].ToString();
                }
                txthetonglx.Text = t3;
                TextBoxlimit.Text = "xmb:" + t1 + ",xmjl:" + t2 + ",hetonglx:" + t3;
                quanxian();
                hdNo2.Text = CreateNext();
                TextBox项目编码.Attributes.Add("readOnly", "readOnly");
                Text单项工程名称.Attributes.Add("readOnly", "readOnly");
                TextBox结算金额不含税.Attributes.Add("readOnly", "readOnly");
                TextBox税率1.Attributes.Add("readOnly", "readOnly");
                TextBox税额1.Attributes.Add("readOnly", "readOnly");
                TextBox结算金额含税.Attributes.Add("readOnly", "readOnly");
                TextBox审定金额不含税.Attributes.Add("readOnly", "readOnly");
                TextBox税率2.Attributes.Add("readOnly", "readOnly");
                TextBox税额2.Attributes.Add("readOnly", "readOnly");
                TextBox审定金额含税.Attributes.Add("readOnly", "readOnly");
                TextBox结算类型.Attributes.Add("readOnly", "readOnly");
                TextBox已经开票金额.Attributes.Add("readOnly", "readOnly");
                //TextBox金额.Attributes.Add("readOnly", "readOnly");
                //TextBox税额.Attributes.Add("readOnly", "readOnly");
                //TextBox合计.Attributes.Add("readOnly", "readOnly");

                if (base.Request.QueryString["id"] != null)
                {
                    //GetDetail();
                    hdNo.Text = base.Request.QueryString["id"].ToString().Trim();
                }
                if (base.Request.QueryString["id1"] != null)
                { 
                    string id1 = base.Request.QueryString["id1"].ToString();
                   
                    if (id1 == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id1"].ToString();
                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where id=" + id1 + " ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txt项目名称.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox项目编码.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        Text单项工程名称.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox结算金额不含税.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox税率1.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox税额1.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox结算金额含税.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox审定金额不含税.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox税率2.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox税额2.Text = ds.Tables[0].Rows[0]["col45"].ToString();
                        TextBox审定金额含税.Text = ds.Tables[0].Rows[0]["col46"].ToString();
                        TextBox结算类型.Text = ds.Tables[0].Rows[0]["col47"].ToString();
                        TextBox已经开票金额.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        TextBox本次开票金额.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        Drop货物或应税劳务服务名称.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox规格型号.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox单位.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox数量.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox单价.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        Drop税率.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox税额.Text = ds.Tables[0].Rows[0]["col30"].ToString();
                        TextBox合计.Text = ds.Tables[0].Rows[0]["col31"].ToString();

                        txt项目名称.Attributes.Add("readOnly", "readOnly");
                        span项目名称.Visible = false;
                        txt项目名称.Width = 950;

                    }

                    decimal count1 = 0;
                    DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu22 where col43='" + id1 + "' and col49='" + txthetonglx.Text + "'  ");
                    //DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu22 where col43='" + id1 + "'  ");
                    if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        {
                            string formNo = ds2.Tables[0].Rows[i]["col18"].ToString();
                            DataSet ds已开票 = Sql.SqlQueryDS("select * from t_caiwu2 where col53='" + formNo + "'  and col55 like '%确定开票%'  ");
                            {
                                if (ds已开票 != null && ds已开票.Tables[0] != null && ds已开票.Tables[0].Rows.Count > 0)
                                {
                                    count1 += Convert.ToDecimal(ds2.Tables[0].Rows[i]["col22"].ToString() == "" ? "0" : ds2.Tables[0].Rows[i]["col22"].ToString());
                                }
                            }

                        }
                    }
                    TextBox已经开票金额.Text = count1.ToString();

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
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col17) as col17 from t_caiwu22 where 1=1 and col19 = '" + strdate + "' ";
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


        //private void GetDetail()
        //{
        //    string Message = string.Empty;
        //    DataTable dt = (DataTable)ViewState["GridDataSource"];
        //    DataTable dtnew = new DataTable();
        //    dtnew.Columns.Add("col30");
        //    dtnew.Columns.Add("col31");
        //    dtnew.Columns.Add("col32");
        //    dtnew.Columns.Add("col33");
        //    dtnew.Columns.Add("col34");
        //    dtnew.Columns.Add("col35");
        //    dtnew.Columns.Add("col341");
        //    dtnew.Columns.Add("col351");
        //    dtnew.Columns.Add("col342");
        //    dtnew.Columns.Add("col352");
        //    dtnew.Columns.Add("col343");
        //    dtnew.Columns.Add("col353");
        //    dtnew.Columns.Add("col36");
        //    dtnew.Columns.Add("col37");
        //    dtnew.Columns.Add("col38");
        //    dtnew.Columns.Add("col39");
        //    dtnew.Columns.Add("col40");
        //    dtnew.Columns.Add("col41");
        //    dtnew.Columns.Add("col42");
        //    dtnew.Columns.Add("col43");
        //    dtnew.Columns.Add("col44");
        //    dtnew.Columns.Add("col45");
        //    dtnew.Columns.Add("col46");
        //    DataRow dr;

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dr = dt.NewRow();
        //        dr["col30"] = i + 1;
        //        dr["col31"] = dt.Rows[i]["txtcol31"].ToString();
        //        dr["col32"] = dt.Rows[i]["txtcol32"].ToString();
        //        dr["col33"] = dt.Rows[i]["txtcol33"].ToString();
        //        dr["col34"] = dt.Rows[i]["txtcol34"].ToString();
        //        dr["col35"] = dt.Rows[i]["txtcol35"].ToString();
        //        dr["col341"] = dt.Rows[i]["txtcol34"].ToString();
        //        dr["col351"] = dt.Rows[i]["txtcol35"].ToString();
        //        dr["col342"] = dt.Rows[i]["txtcol34"].ToString();
        //        dr["col352"] = dt.Rows[i]["txtcol35"].ToString();
        //        dr["col343"] = dt.Rows[i]["txtcol34"].ToString();
        //        dr["col353"] = dt.Rows[i]["txtcol35"].ToString();

        //        dr["col36"] = dt.Rows[i]["txtcol36"].ToString();
        //        dr["col37"] = dt.Rows[i]["txtcol37"].ToString();
        //        dr["col38"] = dt.Rows[i]["txtcol38"].ToString();
        //        dr["col39"] = dt.Rows[i]["txtcol39"].ToString();
        //        dr["col40"] = dt.Rows[i]["txtcol40"].ToString();
        //        dr["col41"] = dt.Rows[i]["txtcol41"].ToString();
        //        dr["col42"] = dt.Rows[i]["txtcol42"].ToString();
        //        dr["col43"] = dt.Rows[i]["txtcol43"].ToString();
        //        dr["col44"] = dt.Rows[i]["txtcol44"].ToString();
        //        dr["col45"] = dt.Rows[i]["txtcol45"].ToString();
        //        dr["col46"] = dt.Rows[i]["txtcol46"].ToString();

        //        dt.Rows.Add(dr);
        //    }
        //    if (dt.Rows.Count == 0)
        //    {
        //        dr = dtnew.NewRow();
        //        dr["col30"] = 1;
        //        dr["col31"] = txt项目名称.Text.Trim();
        //        dr["col32"] = TextBox项目编码.Text.Trim();
        //        dr["col33"] = Text单项工程名称.Text.Trim();
        //        dr["col34"] = TextBox结算金额.Text.Trim();
        //        dr["col35"] = TextBox审定金额.Text.Trim();
        //        dr["col36"] = TextBox已经开票金额.Text.Trim();
        //        dr["col37"] = TextBox本次开票金额.Text.Trim();
        //        dr["col38"] = Drop货物或应税劳务服务名称.Text.Trim();
        //        dr["col39"] = TextBox规格型号.Text.Trim();
        //        dr["col40"] = TextBox单位.Text.Trim();
        //        dr["col41"] = TextBox数量.Text.Trim();
        //        dr["col42"] = TextBox单价.Text.Trim();
        //        dr["col43"] = TextBox金额.Text.Trim();
        //        dr["col44"] = Drop税率.Text.Trim();
        //        dr["col45"] = TextBox税额.Text.Trim();
        //        dr["col46"] = TextBox合计.Text.Trim();

        //        dtnew.Rows.Add(dr);

        //        dt = dtnew;
        //    }
        //    else
        //    {
        //        dr = dt.NewRow();
        //        dr["col30"] = 1;
        //        dr["col31"] = txt项目名称.Text.Trim();
        //        dr["col32"] = TextBox项目编码.Text.Trim();
        //        dr["col33"] = Text单项工程名称.Text.Trim();
        //        dr["col34"] = TextBox结算金额.Text.Trim();
        //        dr["col35"] = TextBox审定金额.Text.Trim();
        //        dr["col36"] = TextBox已经开票金额.Text.Trim();
        //        dr["col37"] = TextBox本次开票金额.Text.Trim();
        //        dr["col38"] = Drop货物或应税劳务服务名称.Text.Trim();
        //        dr["col39"] = TextBox规格型号.Text.Trim();
        //        dr["col40"] = TextBox单位.Text.Trim();
        //        dr["col41"] = TextBox数量.Text.Trim();
        //        dr["col42"] = TextBox单价.Text.Trim();
        //        dr["col43"] = TextBox金额.Text.Trim();
        //        dr["col44"] = Drop税率.Text.Trim();
        //        dr["col45"] = TextBox税额.Text.Trim();
        //        dr["col46"] = TextBox合计.Text.Trim();

        //        dt.Rows.Add(dr);
        //    }

        //    ViewState["GridDataSource"] = dt;

        //}

        protected void Loadxiangmu_Click(object sender, EventArgs e)
        {

            #region Step
            //Get

            if (TextBoxID.Text == "")
            {
                return;
            }
            DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu1 where id=" + TextBoxID.Text + "  ");

            decimal count1 = 0;
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                

                TextBox结算类型.Text = ds.Tables[0].Rows[0]["col31"].ToString();
                TextBox结算金额不含税.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                TextBox税率1.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                TextBox税额1.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                TextBox结算金额含税.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                TextBox审定金额不含税.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                TextBox税率2.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                TextBox税额2.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                TextBox审定金额含税.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                
            }

            DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu22 where col43='" + TextBoxID.Text + "' and col49='" + txthetonglx.Text + "'  ");
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    string formNo = ds2.Tables[0].Rows[i]["col18"].ToString();
                    DataSet ds已开票 = Sql.SqlQueryDS("select * from t_caiwu2 where col53='" + formNo + "' and col55 like '%确定开票%' ");
                    {
                        if (ds已开票 != null && ds已开票.Tables[0] != null && ds已开票.Tables[0].Rows.Count > 0)
                        {
                            count1 += Convert.ToDecimal(ds2.Tables[0].Rows[i]["col22"].ToString() == "" ? "0" : ds2.Tables[0].Rows[i]["col22"].ToString());
                        }
                    }
                    
                }
            }

            TextBox已经开票金额.Text = count1.ToString();

            #endregion
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt项目名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目名称");
                return;
            }
            if (this.TextBox本次开票金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写本次开票金额");
                return;
            }
            if (this.TextBox金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写金额");
                return;
            }
            if (this.Drop货物或应税劳务服务名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写货物或应税劳务服务名称");
                return;
            }

            decimal d1 = Convert.ToDecimal(TextBox本次开票金额.Text);
            decimal d2 = Convert.ToDecimal(TextBox已经开票金额.Text == "" ? "0" : TextBox已经开票金额.Text);
            decimal d3 = Convert.ToDecimal(TextBox结算金额含税.Text);
            if (d1 > d3 - d2)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "本次开票金额不能大于结算金额含税减去已经开票金额");
                return;
            }

            if (this.ViewState["ID"] != null)
            {
                caiwu22List List = new caiwu22List();

                List = List.GetData(int.Parse(this.ViewState["ID"].ToString()));

                List.col1 = List.col1;
                //List.col17 = hdNo2.Text;
                //List.col18 = hdNo.Text;
                //List.col19 = DateTime.Now.ToString("yyyyMMdd");
                //List.col20 = base.Request.QueryString["idno"];

                List.col21 = TextBox已经开票金额.Text.Trim();
                List.col22 = TextBox本次开票金额.Text.Trim();
                List.col23 = Drop货物或应税劳务服务名称.Text.Trim();
                List.col24 = TextBox规格型号.Text.Trim();
                List.col25 = TextBox单位.Text.Trim();
                List.col26 = TextBox数量.Text.Trim();
                List.col27 = TextBox单价.Text.Trim();
                List.col28 = TextBox金额.Text.Trim();
                List.col29 = Drop税率.Text.Trim();
                List.col30 = TextBox税额.Text.Trim();
                List.col31 = TextBox合计.Text.Trim();

                List.UpdateData(int.Parse(this.ViewState["ID"].ToString()));

            }
            else
            {
                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu1 where id=" + TextBoxID.Text + "");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    caiwu22List List = new caiwu22List();
                    List.col1 = ds.Tables[0].Rows[0]["col1"].ToString();
                    List.col2 = ds.Tables[0].Rows[0]["col2"].ToString();
                    List.col3 = ds.Tables[0].Rows[0]["col3"].ToString();
                    List.col4 = ds.Tables[0].Rows[0]["col4"].ToString();
                    List.col5 = ds.Tables[0].Rows[0]["col5"].ToString();
                    List.col6 = ds.Tables[0].Rows[0]["col6"].ToString();
                    List.col7 = ds.Tables[0].Rows[0]["col7"].ToString();
                    List.col8 = ds.Tables[0].Rows[0]["col8"].ToString();
                    List.col9 = ds.Tables[0].Rows[0]["col9"].ToString();
                    List.col10 = ds.Tables[0].Rows[0]["col10"].ToString();
                    List.col11 = ds.Tables[0].Rows[0]["col11"].ToString();
                    List.col12 = ds.Tables[0].Rows[0]["col12"].ToString();
                    List.col13 = ds.Tables[0].Rows[0]["col13"].ToString();
                    List.col14 = ds.Tables[0].Rows[0]["col14"].ToString();
                    List.col15 = ds.Tables[0].Rows[0]["col15"].ToString();
                    List.col16 = ds.Tables[0].Rows[0]["col16"].ToString();

                    List.col45 = ds.Tables[0].Rows[0]["col17"].ToString();
                    List.col46 = ds.Tables[0].Rows[0]["col18"].ToString();
                    List.col47 = ds.Tables[0].Rows[0]["col31"].ToString();
                    List.col49 = txthetonglx.Text;

                    List.col17 = hdNo2.Text;
                    List.col18 = hdNo.Text;
                    List.col19 = DateTime.Now.ToString("yyyyMMdd");
                    List.col20 = base.Request.QueryString["idno"];

                    List.col21 = TextBox已经开票金额.Text.Trim();
                    List.col22 = TextBox本次开票金额.Text.Trim();
                    List.col23 = Drop货物或应税劳务服务名称.Text.Trim();
                    List.col24 = TextBox规格型号.Text.Trim();
                    List.col25 = TextBox单位.Text.Trim();
                    List.col26 = TextBox数量.Text.Trim();
                    List.col27 = TextBox单价.Text.Trim();
                    List.col28 = TextBox金额.Text.Trim();
                    List.col29 = Drop税率.Text.Trim();
                    List.col30 = TextBox税额.Text.Trim();
                    List.col31 = TextBox合计.Text.Trim();
                    List.col43 = ds.Tables[0].Rows[0]["id"].ToString();

                    List.InsertData();
                }
            }

            

            

            Response.Redirect("caiwu2.aspx?id=" + hdNo.Text + "&idno=" + base.Request.QueryString["idno"], false);

        }

        



        protected void btn返回_Click(object sender, EventArgs e)
        {
            Response.Redirect("caiwu2.aspx?id=" + hdNo.Text + "&idno=" + base.Request.QueryString["idno"], false);
        }

     


    }
}