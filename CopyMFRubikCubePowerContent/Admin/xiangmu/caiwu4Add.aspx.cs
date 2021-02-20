using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.IO;
using System.Data;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class caiwu4Add : System.Web.UI.Page
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
        public int memoryPage = 0;
        public decimal amount1 = 0;
        public decimal amount5 = 0;
        public decimal amount6 = 0;
        public decimal amount7 = 0;
        public decimal amount8 = 0;

        public decimal aomunt11 = 0;
        public decimal aomunt12 = 0;
        public decimal aomunt13 = 0;
        public decimal aomunt14 = 0;
        public int nums = 0;
        public decimal aomunt18 = 0;

        public decimal dscount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                TextBox开票人.Text = this.Session["FullName"].ToString();
                TextBox开票日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox发票状态.Attributes.Add("readOnly", "readOnly");
                TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                if (base.Request.QueryString["idno"] != null)
                {
                    string id = base.Request.QueryString["idno"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["idno"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txt发票单号.Attributes.Add("readOnly", "readOnly");
                        TextBox申请人.Attributes.Add("readOnly", "readOnly");
                        TextBox申请日期.Attributes.Add("readOnly", "readOnly");

                        TextBox所属项目部.Attributes.Add("readOnly", "readOnly");
                        TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                        TextBox申请发票类型.Attributes.Add("readOnly", "readOnly");
                        TextBox项目属性.Attributes.Add("readOnly", "readOnly");
                        TextBox申请发票类别.Attributes.Add("readOnly", "readOnly");
                        TextBox合同类型.Attributes.Add("readOnly", "readOnly");
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
                        TextBox本次开票金额合计不含税.Attributes.Add("readOnly", "readOnly");
                        TextBox税额合计.Attributes.Add("readOnly", "readOnly");
                        TextBox本次发票价税合计金额.Attributes.Add("readOnly", "readOnly");
                        TextBox税率.Attributes.Add("readOnly", "readOnly");

                        TextBox发票备注栏信息.Text = ds.Tables[0].Rows[0]["col49"].ToString();
                        TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                        TextBox开票人.Attributes.Add("readOnly", "readOnly");
                        TextBox开票日期.Attributes.Add("readOnly", "readOnly");
                        FileUpload3.Enabled = false;

                        txt发票单号.Text = ds.Tables[0].Rows[0]["col53"].ToString();
                        TextBox申请人.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox申请日期.Text = ds.Tables[0].Rows[0]["col2"].ToString();


                        TextBox合同名称.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        //TextBox跨区域涉税事项报验管理编号.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        //TextBox项目属性.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        //TextBox付款单位名称.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        //TextBox开票单位名称.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox申请发票类型.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox申请发票类别.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox所属项目部.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col4"].ToString();

                        //TextBox发票价税合计金额.Text = ds.Tables[0].Rows[0]["col54"].ToString();
                        TextBox增值税预缴税款方式.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox国税预缴金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox地税预缴金额.Text = ds.Tables[0].Rows[0]["col29"].ToString();

                        if (ds.Tables[0].Rows[0]["col31"].ToString() != "")
                        {
                            TextBox开票人.Text = ds.Tables[0].Rows[0]["col31"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["col32"].ToString() != "")
                        {
                            TextBox开票日期.Text = ds.Tables[0].Rows[0]["col32"].ToString();
                        }
                       
                        //TextBox发票状态.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        TextBox发票作废冲红说明.Text = ds.Tables[0].Rows[0]["col34"].ToString();
                        TextBox发票记账联扫描件.Text = ds.Tables[0].Rows[0]["col35"].ToString();
                        TextBox发票发票联扫描件.Text = ds.Tables[0].Rows[0]["col36"].ToString();
                        TextBox税票扫描件.Text = ds.Tables[0].Rows[0]["col37"].ToString();
                        TextBox发票作废冲红附件.Text = ds.Tables[0].Rows[0]["col38"].ToString();
                        //TextBox备注.Text = ds.Tables[0].Rows[0]["col49"].ToString();
                        TextBox缴税备注栏信息.Attributes.Add("readOnly", "readOnly");

                        TextBox审核人.Text = ds.Tables[0].Rows[0]["col63"].ToString();
                        TextBox缴税备注栏信息.Text = ds.Tables[0].Rows[0]["col65"].ToString();
                        
                        DataSet ds22 = Sql.SqlQueryDS("select * from t_caiwu22 where col18 = '" + txt发票单号.Text + "'");
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            ViewState["GridDataSource2"] = ds22.Tables[0];
                            this.GridView2.DataSource = ds22.Tables[0];
                            this.GridView2.DataBind();
                            TextBox本次开票金额合计不含税.Text = aomunt11.ToString();
                            TextBox税额合计.Text = aomunt12.ToString();
                            TextBox本次发票价税合计金额.Text = aomunt13.ToString();
                            //TextBox税率.Text = ((aomunt14 / ds22.Tables[0].Rows.Count) * 100).ToString("F0") + "%";
                            TextBox税率.Text = ((aomunt14) * 100).ToString("F0") + "%";
                        }

                        DataSet dsde = Sql.SqlQueryDS("select * from t_caiwu3 where col8='" + txt发票单号.Text + "' ");
                        if (dsde != null && dsde.Tables[0] != null && dsde.Tables[0].Rows.Count > 0)
                        {
                            this.GridView1.DataSource = dsde.Tables[0];
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = dsde.Tables[0];
                        }

                        TextBox发票状态.Text = ds.Tables[0].Rows[0]["col33"].ToString();

                        zhuangtaiList list2 = new zhuangtaiList();
                        string sql2 = "select * from t_zhuangtai where col1='" + txt发票单号.Text + "' ";
                        DataSet ds2 = Sql.SqlQueryDS(sql2);
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds2.Tables[0].Rows.Count;k++ )
                            {
                                TextBox审批状态.Text += ds2.Tables[0].Rows[k]["col2"].ToString() + @"
";
                            }
                            
                        }
                       

                        //if (TextBox发票记账联扫描件.Text != "")
                        //{
                        //    发票记账联扫描件href.HRef = TextBox发票记账联扫描件.Text;
                        //    发票记账联扫描件href.Visible = true;
                        //    var temp = TextBox发票记账联扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            发票记账联扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
                        //}
                        //if (TextBox发票发票联扫描件.Text != "")
                        //{
                        //    发票发票联扫描件href.HRef = TextBox发票发票联扫描件.Text;
                        //    发票发票联扫描件href.Visible = true;
                        //    var temp = TextBox发票发票联扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            发票发票联扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}
                        //if (TextBox税票扫描件.Text != "")
                        //{
                        //    税票扫描件href.HRef = TextBox税票扫描件.Text;
                        //    税票扫描件href.Visible = true;
                        //    var temp = TextBox税票扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            税票扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton2.Visible = true;
                        //}
                        //if (TextBox发票作废冲红附件.Text != "")
                        //{
                        //    发票作废冲红附件href.HRef = TextBox发票作废冲红附件.Text;
                        //    发票作废冲红附件href.Visible = true;
                        //    var temp = TextBox发票作废冲红附件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            发票作废冲红附件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton3.Visible = true;
                        //}
                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu32' and col1='" + this.ViewState["ID"].ToString() + "' ");
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

                        DataSet ds24 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu33' and col1='" + this.ViewState["ID"].ToString() + "' ");
                        if (ds24 != null && ds24.Tables[0] != null && ds24.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件4.Value = ds24.Tables[0].Rows[0]["col2"].ToString();
                            GridView4.DataSource = ds24.Tables[0];
                            GridView4.DataBind();
                            ViewState["GridDataSource3"] = ds24.Tables[0];
                        }
                        else
                        {
                            HdCol2附件4.Value = "";
                            GridView4.DataSource = null;
                            GridView4.DataBind();
                        }

                        DataSet ds25 = Sql.SqlQueryDS("select * from t_fujian where (flag = 'caiwu34' or flag = 'caiwu23') and col1='" + this.ViewState["ID"].ToString() + "' ");
                        if (ds25 != null && ds25.Tables[0] != null && ds25.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件5.Value = ds25.Tables[0].Rows[0]["col2"].ToString();
                            GridView5.DataSource = ds25.Tables[0];
                            GridView5.DataBind();
                            ViewState["GridDataSource3"] = ds25.Tables[0];
                        }
                        else
                        {
                            HdCol2附件5.Value = "";
                            GridView5.DataSource = null;
                            GridView5.DataBind();
                        }

                        DataSet ds26 = Sql.SqlQueryDS("select * from t_fujian where (flag = 'caiwu35' ) and col1='" + this.ViewState["ID"].ToString() + "' ");
                        if (ds26 != null && ds26.Tables[0] != null && ds26.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件6.Value = ds26.Tables[0].Rows[0]["col2"].ToString();
                            GridView6.DataSource = ds26.Tables[0];
                            GridView6.DataBind();
                            ViewState["GridDataSource3"] = ds26.Tables[0];
                        }
                        else
                        {
                            HdCol2附件6.Value = "";
                            GridView6.DataSource = null;
                            GridView6.DataBind();
                        }

                        string model = base.Request.QueryString["model"];
                        if (model == "view")
                        {
                            TextBox发票作废冲红说明.Attributes.Add("readOnly", "readOnly");
                            TextBox缴税备注栏信息.Attributes.Add("readOnly", "readOnly");
                            btnAttach.Visible = false;
                            LinkButton1.Visible = false;
                            LinkButton2.Visible = false;
                            LinkButton3.Visible = false;
                            FileUpload1.Visible= false;
                            Button4.Enabled = false;
                            FileUpload2.Visible = false;
                            Button5.Enabled = false;
                            FileUpload3.Visible = false;
                            Button6.Enabled = false;
                            FileUpload4.Visible = false;
                            Button1.Enabled = false;
                            FileUpload3.Visible = false;
                            Button3.Visible = false;
                            btn发票作废.Visible = false;
                            btn发票冲红.Visible = false;
                            for (int k = 0; k < GridView1.Rows.Count;k++ )
                            {
                                ((TextBox)GridView1.Rows[k].FindControl("txtcol12")).ReadOnly = true;
                                ((TextBox)GridView1.Rows[k].FindControl("txtcol13")).ReadOnly = true;
                                ((TextBox)GridView1.Rows[k].FindControl("txtcol14")).ReadOnly = true;
                                ((TextBox)GridView1.Rows[k].FindControl("txtcol15")).ReadOnly = true;
                                ((TextBox)GridView1.Rows[k].FindControl("txtcol16")).ReadOnly = true;
                                ((TextBox)GridView1.Rows[k].FindControl("txtcol17")).ReadOnly = true;
                            }
                            
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
            if (this.TextBox合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }

            if (this.GridView3.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传发票记账联扫描件");
                return;
            }
            if (this.GridView4.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传发票发票联扫描件");
                return;
            }
   
            caiwu2List List = new caiwu2List();

            List.col53 = txt发票单号.Text.Trim() == "" ? CreateNext() : txt发票单号.Text.Trim();
            
            //List.col14 = TextBox发票价税合计金额.Text.Trim();
            //List.col15 = TextBox增值税预缴税款方式.Text.Trim();
            //List.col16 = TextBox国税预缴金额.Text.Trim();
            //List.col17 = TextBox地税预缴金额.Text.Trim();
            //List.col18 = TextBox申请人.Text.Trim();
            //List.col19 = TextBox申请日期.Text.Trim();
            List.col31 = TextBox开票人.Text.Trim();
            List.col32 = TextBox开票日期.Text.Trim();
            List.col33 = TextBox发票状态.Text.Trim();
            List.col34 = TextBox发票作废冲红说明.Text.Trim();

            if (this.GridView3.Rows.Count == 0)
            {
                List.col35 = "0";
            }
            else
            {
                List.col35 = "1";
            }

            if (this.GridView4.Rows.Count == 0)
            {
                List.col36 = "0";
            }
            else
            {
                List.col36 = "1";
            }
            if (this.GridView5.Rows.Count == 0)
            {
                List.col37 = "0";
            }
            else
            {
                List.col37 = "1";
            }
            if (this.GridView6.Rows.Count == 0)
            {
                List.col38 = "0";
            }
            else
            {
                List.col38 = "1";
            }
            //List.col35 = TextBox发票记账联扫描件.Text.Trim();
            //List.col36 = TextBox发票发票联扫描件.Text.Trim();
            //List.col37 = TextBox税票扫描件.Text.Trim();
            //List.col38 = TextBox发票作废冲红附件.Text.Trim();
            //List.col49 = TextBox备注.Text.Trim();

            int ID = 0;
            if (this.ViewState["ID"] != null)
            {
                List.ID = int.Parse(this.ViewState["ID"].ToString());
                List.UpdateDatafapiao(List.ID);
                ID = List.ID;
            }
            else
            {
                ID = List.InsertData();
            }

            caiwu3List List3 = new caiwu3List();
            List3.DeleteData(txt发票单号.Text.Trim());

            if (GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "至少要有一条发票明细");
                return;
            }
            else
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    List3.col1 = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
                    List3.col2 = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString();
                    List3.col3 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString();
                    List3.col4 = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString() == "" ? "" : (Convert.ToDecimal(((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString().Replace("%", "")) /100).ToString();
                    List3.col5 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString();

                    List3.col6 = ((TextBox)GridView1.Rows[i].FindControl("txtcol16")).Text.ToString();
                    List3.col7 = ((TextBox)GridView1.Rows[i].FindControl("txtcol17")).Text.ToString();
                    List3.col8 = txt发票单号.Text.Trim();

                    List3.InsertData();
                }
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView3.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView3.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView4.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView5.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            for (int i = 0; i < GridView6.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView6.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();

                附件List.UpdateData(int.Parse(ID11));
            }

            base.Response.Redirect("caiwu4.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("caiwu4.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        string CreateNext3()
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


        protected void FileUpload发票记账联扫描件Button_Click(object sender, EventArgs e)
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

                发票记账联扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox发票记账联扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu32";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext3() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu32' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload发票发票联扫描件Button_Click(object sender, EventArgs e)
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

                发票发票联扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox发票发票联扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu33";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件4.Value == "" ? CreateNext3() : HdCol2附件4.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu33' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload税票扫描件Button_Click(object sender, EventArgs e)
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

                税票扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox税票扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu34";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件5.Value == "" ? CreateNext3() : HdCol2附件5.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu34' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload发票作废冲红附件Button_Click(object sender, EventArgs e)
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

                发票作废冲红附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox发票作废冲红附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu35";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件6.Value == "" ? CreateNext3() : HdCol2附件6.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu35' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件6.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView6.DataSource = ds2.Tables[0];
                    GridView6.DataBind();
                    ViewState["GridDataSource6"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件6.Value = "";
                    GridView6.DataSource = null;
                    GridView6.DataBind();
                }
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void btn发票作废_Click(object sender, EventArgs e)
        {
            if (this.TextBox发票作废冲红说明.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发票作废冲红说明");
                return;
            }
            zhuangtaiList list2 = new zhuangtaiList();
            string str1 = txt发票单号.Text;
            string str2 = TextBox开票人.Text + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日") + "发票作废";
            string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = str1;
                list2.col2 = str2;
                list2.col3 = TextBox发票作废冲红说明.Text.Trim();
                list2.InsertData();
            }
            caiwu2List List = new caiwu2List();
            List.col55 = str2;
            List.col33 = "发票作废";
            List.col34 = TextBox发票作废冲红说明.Text.Trim();
            List.col62 = this.Session["FullName"].ToString();
            List.col63 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            List.UpdateDatashenhe2(int.Parse(this.ViewState["ID"].ToString()));
            base.Response.Redirect("caiwu4.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn发票冲红_Click(object sender, EventArgs e)
        {
            if (this.TextBox发票作废冲红说明.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发票作废冲红说明");
                return;
            }
            zhuangtaiList list2 = new zhuangtaiList();
            string str1 = txt发票单号.Text;
            string str2 = TextBox开票人.Text + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日") + "发票冲红";
            string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = str1;
                list2.col2 = str2;
                list2.col3 = TextBox发票作废冲红说明.Text.Trim();
                list2.InsertData();
            }
            caiwu2List List = new caiwu2List();
            List.col55 = str2;
            List.col33 = "发票冲红";
            List.col34 = TextBox发票作废冲红说明.Text.Trim();
            List.col62 = this.Session["FullName"].ToString();
            List.col63 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            List.UpdateDatashenhe2(int.Parse(this.ViewState["ID"].ToString()));
            base.Response.Redirect("caiwu4.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                amount1++;
                amount5 += ((TextBox)e.Row.FindControl("txtcol13")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol13")).Text.Trim());

                if (((TextBox)e.Row.FindControl("txtcol14")).Text.Trim() != "")
                {
                    if (((TextBox)e.Row.FindControl("txtcol14")).Text.Trim().Contains("%"))
                    {
                        ((TextBox)e.Row.FindControl("txtcol14")).Text = (Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text.Replace("%", "")) / 100).ToString("F2");
                    }
                    else
                    {
                        ((TextBox)e.Row.FindControl("txtcol14")).Text = Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text).ToString("F2");
                    }
                }
                amount6 = ((TextBox)e.Row.FindControl("txtcol14")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text.Trim());
                if (amount6 > 1)
                {
                    amount6 = amount6 / 100;
                }
                amount7 += ((TextBox)e.Row.FindControl("txtcol15")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol15")).Text.Trim());
                amount8 += ((TextBox)e.Row.FindControl("txtcol16")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol16")).Text.Trim());
                decimal temp = ((TextBox)e.Row.FindControl("txtcol14")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text.Trim());
                if (temp > 1)
                {
                    temp = temp / 100;
                }
                ((TextBox)e.Row.FindControl("txtcol14")).Text = (100 * temp).ToString("N0") + "%";
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "<span align='center' style='font-weight:bold;'>合计</span>";
                e.Row.Cells[5].Text = "<span align='center'  style='font-weight:bold;color:red'>" + amount5 + "</span>";
                e.Row.Cells[6].Text = "<span align='center'  style='font-weight:bold;color:red'>" + (100 * amount6).ToString("F2") + "%" + "</span>";
                e.Row.Cells[7].Text = "<span align='center' style='font-weight:bold;color:red'>" + amount7 + "</span>";
                e.Row.Cells[8].Text = "<span align='center' color = 'blue' style='font-weight:bold;color:red'>" + amount8 + "</span>";

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                nums++;
              
                ((Label)e.Row.FindControl("lblcol31")).Width = ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol31")).Width : ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol32")).Width = ((Label)e.Row.FindControl("lblcol32")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol32")).Width : ((Label)e.Row.FindControl("lblcol32")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol33")).Width = ((Label)e.Row.FindControl("lblcol33")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol33")).Width : ((Label)e.Row.FindControl("lblcol33")).Text.Trim().Length * 6;

                ((Label)e.Row.FindControl("lblcol34")).Width = ((Label)e.Row.FindControl("lblcol34")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol34")).Width : ((Label)e.Row.FindControl("lblcol34")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol35")).Width = ((Label)e.Row.FindControl("lblcol35")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol35")).Width : ((Label)e.Row.FindControl("lblcol35")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol36")).Width = ((Label)e.Row.FindControl("lblcol36")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol36")).Width : ((Label)e.Row.FindControl("lblcol36")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol37")).Width = ((Label)e.Row.FindControl("lblcol37")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol37")).Width : ((Label)e.Row.FindControl("lblcol37")).Text.Trim().Length * 6;

                ((Label)e.Row.FindControl("lblcol38")).Width = ((Label)e.Row.FindControl("lblcol38")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol38")).Width : ((Label)e.Row.FindControl("lblcol38")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol39")).Width = ((Label)e.Row.FindControl("lblcol39")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol39")).Width : ((Label)e.Row.FindControl("lblcol39")).Text.Trim().Length * 6;

                //if (((HyperLink)e.Row.FindControl("HyperLink1")).Width.Value < 100)
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 100;
                //}
                if (((Label)e.Row.FindControl("lblcol32")).Width.Value < 70)
                {
                    ((Label)e.Row.FindControl("lblcol32")).Width = 70;
                }
                if (((Label)e.Row.FindControl("lblcol33")).Width.Value < 80)
                {
                    ((Label)e.Row.FindControl("lblcol33")).Width = 80;
                }
                if (((Label)e.Row.FindControl("lblcol34")).Width.Value < 90)
                {
                    ((Label)e.Row.FindControl("lblcol34")).Width = 90;
                }
                if (((Label)e.Row.FindControl("lblcol35")).Width.Value < 40)
                {
                    ((Label)e.Row.FindControl("lblcol35")).Width = 40;
                }
                if (((Label)e.Row.FindControl("lblcol36")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol36")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol37")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol37")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol38")).Width.Value < 160)
                {
                    ((Label)e.Row.FindControl("lblcol38")).Width = 160;
                }
                if (((Label)e.Row.FindControl("lblcol39")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol39")).Width = 100;
                }


                string str01 = ((Label)e.Row.FindControl("lblcol43")).Text;
                string str02 = ((Label)e.Row.FindControl("lblcol45")).Text;
                string str03 = ((Label)e.Row.FindControl("lblcol46")).Text;
                string str04 = ((Label)e.Row.FindControl("lblcol44")).Text;

                string str18 = ((Label)e.Row.FindControl("lblcol37")).Text;
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
                aomunt11 += Convert.ToDecimal(str01);
                aomunt12 += Convert.ToDecimal(str02);
                aomunt13 += Convert.ToDecimal(str03);
                aomunt18 += Convert.ToDecimal(str18);

                dscount++;
                if (nums == 1)
                {
                    if (str04 == "3%")
                    {
                        aomunt14 += Convert.ToDecimal(0.03);
                    }
                    else if (str04 == "6%")
                    {
                        aomunt14 = Convert.ToDecimal(0.06);
                    }
                    else if (str04 == "9%")
                    {
                        aomunt14 = Convert.ToDecimal(0.09);
                    }
                    else if (str04 == "10%")
                    {
                        aomunt14 = Convert.ToDecimal(0.1);
                    }
                    else if (str04 == "11%")
                    {
                        aomunt14 = Convert.ToDecimal(0.11);
                    }
                    else if (str04 == "13%")
                    {
                        aomunt14 = Convert.ToDecimal(0.13);
                    }
                    else if (str04 == "16%")
                    {
                        aomunt14 = Convert.ToDecimal(0.16);
                    }
                    else if (str04 == "17%")
                    {
                        aomunt14 = Convert.ToDecimal(0.17);
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int kk = int.Parse((dscount * 60).ToString());
                if (kk > 60)
                {
                    this.GridView2.Height = (Unit)60;
                    divGridView2.Attributes.Add("Height", "60");
                }
                else
                {
                    this.GridView2.Height = (Unit)int.Parse((dscount * 60).ToString());
                    divGridView2.Attributes.Add("Height", (dscount * 60 + 20).ToString());
                }
                e.Row.Cells[17].Text = "<span align='center' style='font-weight:bold;color:red' > " + aomunt18 + " </span>";
                e.Row.Cells[23].Text = "<span align='center' style='font-weight:bold;color:red'> " + aomunt11 + " </span>";
                e.Row.Cells[24].Text = "<span align='center' style='font-weight:bold;color:red'> " + (aomunt14 * 100).ToString("F0") + "%" + " </span>";
                e.Row.Cells[25].Text = "<span align='center' style='font-weight:bold;color:red'>" + aomunt12 + "</span>";
                e.Row.Cells[26].Text = "<span align='center' style='font-weight:bold;color:red'>" + aomunt13 + "</span>";
            }

        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票记账联扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox发票记账联扫描件.Text = "";
                发票记账联扫描件href.HRef = "";
                发票记账联扫描件href.InnerText = "";
                btnAttach.Visible = false;
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票发票联扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox发票发票联扫描件.Text = "";
                发票发票联扫描件href.HRef = "";
                发票发票联扫描件href.InnerText = "";
                LinkButton1.Visible = false;
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox税票扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox税票扫描件.Text = "";
                税票扫描件href.HRef = "";
                税票扫描件href.InnerText = "";
                LinkButton2.Visible = false;
            }
        }

        protected void btnAttach4_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票作废冲红附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox发票作废冲红附件.Text = "";
                发票作废冲红附件href.HRef = "";
                发票作废冲红附件href.InnerText = "";
                LinkButton3.Visible = false;
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

        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource6"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView6.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView6.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource6"] = dtnew;
                this.GridView6.DataSource = dtnew;
                this.GridView6.DataBind();

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



    }
}