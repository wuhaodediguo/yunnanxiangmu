using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MojoCube.Web;
using MojoCube.Web.CurrentExpenses;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class xiangmu9Add : System.Web.UI.Page
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
        public string temp8
        {
            get { return Request.Params.Get("temp8"); }
        }
        public string temp9
        {
            get { return Request.Params.Get("temp9"); }
        }
        public string caset
        {
            get { return Request.Params.Get("caset"); }
        }

        public string casetName;
        public string TFalgs;

  
        protected void Page_Load(object sender, EventArgs e)
        {
            Hdtemp1.Value = temp1.Trim() == "" ? "000" : temp1.Trim();
            Hdtemp2.Value = temp2.Trim() == "" ? "000" : temp2.Trim();
            Hdtemp3.Value = temp3.Trim() == "" ? "000" : temp3.Trim();
            Hdtemp4.Value = temp4.Trim() == "" ? "000" : temp4.Trim();
            Hdtemp5.Value = temp5.Trim() == "" ? "000" : temp5.Trim();
            Hdtemp6.Value = temp6.Trim() == "" ? "000" : temp6.Trim();
            Hdtemp7.Value = temp7.Trim() == "" ? "000" : temp7.Trim();
            Hdtemp8.Value = temp8.Trim() == "" ? "000" : temp8.Trim();
            Hdtemp9.Value = temp9.Trim() == "" ? "000" : temp9.Trim();
            Hdtcaset.Value = caset.Trim() == "" ? "000" : caset.Trim();
            switch (caset)
            {
                case "1":
                        casetName = "发票资料附件";
                        TFalgs = "xiangmu91";
                        lbltitle.Text = "发票资料附件管理列表►查看";
                        break;
                case "2":
                        casetName = "采购订单资料附件";
                        TFalgs = "xiangmu92";
                        lbltitle.Text = "采购订单资料附件管理列表►查看";
                        break;
                case "3":
                        casetName = "结算资料附件";
                        TFalgs = "xiangmu93";
                        lbltitle.Text = "结算资料附件管理列表►查看";
                        break;
                case "4":
                        casetName = "审计资料附件";
                        TFalgs = "xiangmu94";
                        lbltitle.Text = "审计资料附件管理列表►查看";
                        break;
                case "5":
                        casetName = "竣工资料附件";
                        TFalgs = "xiangmu95";
                        lbltitle.Text = "竣工资料附件管理列表►查看";
                        break;
                case "11":
                        casetName = "发票资料附件";
                        TFalgs = "xiangmu91";
                        lbltitle.Text = "发票资料附件管理列表►查看";
                        break;
                case "12":
                        casetName = "发票资料附件";
                        TFalgs = "xiangmu91";
                        lbltitle.Text = "发票资料附件管理列表►查看";
                        break;
                case "13":
                        casetName = "发票资料附件";
                        TFalgs = "xiangmu91";
                        lbltitle.Text = "发票资料附件管理列表►查看";
                        break;
                case "14":
                        casetName = "发票资料附件";
                        TFalgs = "xiangmu91";
                        lbltitle.Text = "发票资料附件管理列表►查看";
                        break;
                case "21":
                        casetName = "采购订单资料附件";
                        TFalgs = "xiangmu92";
                        lbltitle.Text = "采购订单资料附件管理列表►查看";
                        break;
                case "22":
                        casetName = "采购订单资料附件";
                        TFalgs = "xiangmu92";
                        lbltitle.Text = "采购订单资料附件管理列表►查看";
                        break;
                case "23":
                        casetName = "采购订单资料附件";
                        TFalgs = "xiangmu92";
                        lbltitle.Text = "采购订单资料附件管理列表►查看";
                        break;
                case "24":
                        casetName = "采购订单资料附件";
                        TFalgs = "xiangmu92";
                        lbltitle.Text = "采购订单资料附件管理列表►查看";
                        break;
                case "31":
                        casetName = "结算资料附件";
                        TFalgs = "xiangmu93";
                        lbltitle.Text = "结算资料附件管理列表►查看";
                        break;
                case "32":
                        casetName = "结算资料附件";
                        TFalgs = "xiangmu93";
                        lbltitle.Text = "结算资料附件管理列表►查看";
                        break;
                case "33":
                        casetName = "结算资料附件";
                        TFalgs = "xiangmu93";
                        lbltitle.Text = "结算资料附件管理列表►查看";
                        break;
                case "34":
                        casetName = "结算资料附件";
                        TFalgs = "xiangmu93";
                        lbltitle.Text = "结算资料附件管理列表►查看";
                        break;
                case "41":
                        casetName = "审计资料附件";
                        TFalgs = "xiangmu94";
                        lbltitle.Text = "审计资料附件管理列表►查看";
                        break;
                case "42":
                        casetName = "审计资料附件";
                        TFalgs = "xiangmu94";
                        lbltitle.Text = "审计资料附件管理列表►查看";
                        break;
                case "43":
                        casetName = "审计资料附件";
                        TFalgs = "xiangmu94";
                        lbltitle.Text = "审计资料附件管理列表►查看";
                        break;
                case "44":
                        casetName = "审计资料附件";
                        TFalgs = "xiangmu94";
                        lbltitle.Text = "审计资料附件管理列表►查看";
                        break;
                case "51":
                        casetName = "竣工资料附件";
                        TFalgs = "xiangmu95";
                        lbltitle.Text = "竣工资料附件管理列表►查看";
                        break;
                case "52":
                        casetName = "竣工资料附件";
                        TFalgs = "xiangmu95";
                        lbltitle.Text = "竣工资料附件管理列表►查看";
                        break;
                case "53":
                        casetName = "竣工资料附件";
                        TFalgs = "xiangmu95";
                        lbltitle.Text = "竣工资料附件管理列表►查看";
                        break;
                case "54":
                        casetName = "竣工资料附件";
                        TFalgs = "xiangmu95";
                        lbltitle.Text = "竣工资料附件管理列表►查看";
                        break;
            
            }
            HdcasetName.Value = casetName;
           
            //txtInput发票单号.Attributes.Add("readOnly", "readOnly");
            if (!base.IsPostBack)
            {
                quanxian();
                GridBind();

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        void GridBind()
        {
            if (base.Request.QueryString["id"] != null)
            {
                string id = base.Request.QueryString["id"].ToString();
                if (id == "")
                {
                    return;
                }
                this.ViewState["ID"] = base.Request.QueryString["id"].ToString();
                HdID.Value = base.Request.QueryString["id"].ToString();

                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu1 where id=" + id + "");
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
                    TextBox结算金额含税.Attributes.Add("readOnly", "readOnly");
                    TextBox审定金额不含税.Attributes.Add("readOnly", "readOnly");
                    TextBox审定金额含税.Attributes.Add("readOnly", "readOnly");
                    TextBox税率1.Attributes.Add("readOnly", "readOnly");
                    TextBox税额1.Attributes.Add("readOnly", "readOnly");
                    TextBox税率2.Attributes.Add("readOnly", "readOnly");
                    TextBox税额2.Attributes.Add("readOnly", "readOnly");

                    TextBox创建人.Attributes.Add("readOnly", "readOnly");
                    TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    TextBox结算类型.Attributes.Add("readOnly", "readOnly");

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
                    TextBox税额2.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                    TextBox审定金额含税.Text = ds.Tables[0].Rows[0]["col18"].ToString();

                    TextBox创建人.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                    TextBox创建日期.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                    TextBox备注.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                    TextBox结算类型.Text = ds.Tables[0].Rows[0]["col31"].ToString();

                    DataTable dt = new DataTable();
                    dt.Columns.Add("A1");
                    dt.Columns.Add("A11");
                    dt.Columns.Add("A12");
                    dt.Columns.Add("A2");
                    dt.Columns.Add("A3");
                    dt.Columns.Add("A4");
                    dt.Columns.Add("A5");
                    dt.Columns.Add("A6");
                    dt.Columns.Add("A7");
                    dt.Columns.Add("A8");
                    dt.Columns.Add("A9");
                    dt.Columns.Add("A10");
                    DataRow dr;
                    string fapiaono = string.Empty;
                    int iiii = 0;
                    Boolean youshuju = false;
                    DataSet ds02 = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + id + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
                    if (ds02 != null && ds02.Tables[0] != null && ds02.Tables[0].Rows.Count > 0)
                    {

                        for (int ii = 0; ii < ds02.Tables[0].Rows.Count; ii++)
                        {
                            iiii = iiii + 1;
                            fapiaono = ds02.Tables[0].Rows[ii]["col18"].ToString();
                            DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' and col55 like '%确定开票%' ");
                            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                            {
                                DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '1' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        dr = dt.NewRow();
                                        dr["A1"] = iiii;
                                        dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                        dr["A12"] = ds02.Tables[0].Rows[ii]["col28"];
                                        dr["A2"] = ds02.Tables[0].Rows[ii]["col31"];
                                        dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                        dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                        dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                        dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                        dr["A7"] = ds2.Tables[0].Rows[0]["col32"];
                                        dr["A8"] = ds1.Tables[0].Rows[kkk]["col6"];
                                        dr["A9"] = ds1.Tables[0].Rows[kkk]["col7"];
                                        dr["A10"] = "";
                                        dt.Rows.Add(dr);
                                    }

                                }
                                else
                                {
                                    dr = dt.NewRow();
                                    dr["A1"] = iiii;
                                    dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                    dr["A12"] = ds02.Tables[0].Rows[ii]["col28"];
                                    dr["A2"] = ds02.Tables[0].Rows[ii]["col31"];
                                    dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                    dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                    dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                    dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];

                                    dr["A7"] = ds2.Tables[0].Rows[0]["col32"];
                                    dt.Rows.Add(dr);
                                }

                                ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '2' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        dr = dt.NewRow();
                                        dr["A1"] = iiii;
                                        dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                        dr["A12"] = ds02.Tables[0].Rows[ii]["col28"];
                                        dr["A2"] = ds02.Tables[0].Rows[ii]["col31"];
                                        dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                        dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                        dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                        dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                        dr["A7"] = ds2.Tables[0].Rows[0]["col32"];
                                        dr["A8"] = ds1.Tables[0].Rows[kkk]["col6"];
                                        dr["A9"] = ds1.Tables[0].Rows[kkk]["col7"];
                                        dr["A10"] = "";
                                        dt.Rows.Add(dr);
                                    }

                                }
                                ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '3' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        dr = dt.NewRow();
                                        dr["A1"] = iiii;
                                        dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                        dr["A12"] = ds02.Tables[0].Rows[ii]["col28"];
                                        dr["A2"] = ds02.Tables[0].Rows[ii]["col31"];
                                        dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                        dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                        dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                        dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                        dr["A7"] = ds2.Tables[0].Rows[0]["col32"];
                                        dr["A8"] = ds1.Tables[0].Rows[kkk]["col6"];
                                        dr["A9"] = ds1.Tables[0].Rows[kkk]["col7"];
                                        dr["A10"] = "";
                                        dt.Rows.Add(dr);
                                    }

                                }
                                ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '4' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        dr = dt.NewRow();
                                        dr["A1"] = iiii;
                                        dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                        dr["A12"] = ds02.Tables[0].Rows[ii]["col28"];
                                        dr["A2"] = ds02.Tables[0].Rows[ii]["col31"];
                                        dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                        dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                        dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                        dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                        dr["A7"] = ds2.Tables[0].Rows[0]["col32"];
                                        dr["A8"] = ds1.Tables[0].Rows[kkk]["col6"];
                                        dr["A9"] = ds1.Tables[0].Rows[kkk]["col7"];
                                        dr["A10"] = "";
                                        dt.Rows.Add(dr);
                                    }

                                }
                                ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '5' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        dr = dt.NewRow();
                                        dr["A1"] = iiii;
                                        dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                        dr["A12"] = ds02.Tables[0].Rows[ii]["col28"];
                                        dr["A2"] = ds02.Tables[0].Rows[ii]["col31"];
                                        dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                        dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                        dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                        dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                        dr["A7"] = ds2.Tables[0].Rows[0]["col32"];
                                        dr["A8"] = ds1.Tables[0].Rows[kkk]["col6"];
                                        dr["A9"] = ds1.Tables[0].Rows[kkk]["col7"];
                                        dr["A10"] = "";
                                        dt.Rows.Add(dr);
                                    }

                                }

                            }
                        }

                    }
                    ViewState["GridDataSource"] = dt;
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();

                }


                if (base.Request.QueryString["chakanmodel"] == "chakan" || base.Request.QueryString["model"] == "view")
                {
                    this.GridView1.Enabled = false;
                    btn提交.Visible = false;
                    Hdchakanmodel.Value = "chakan";
                } 
                else if (base.Request.QueryString["chakanmodel"] == "chakan2")
                {
                    Hdchakanmodel.Value = "chakan2";
                    lbltitle.Text = lbltitle.Text.Replace("查看", "上传");
                    
                }
                else if (base.Request.QueryString["chakanmodel"] == "shenhe")
                {
                    //TextBox审核人.Text = this.Session["FullName"].ToString();
                    //TextBox审核人.Attributes.Add("ReadOnly", "ReadOnly");
                    //div审核人.Visible = true;
                    //div审核意见.Visible = true;
                    //div附件名称.Visible = false;
                    //GridView2.Enabled = false;
                    //div附件名称footer.Visible = true;
                    //div附件名称footer2.Visible = true;
                    
                    //GridView2.Enabled = false;
                    this.GridView1.Enabled = false;
                    lbltitle.Text = lbltitle.Text.Replace("查看","审核");
                    
                    Hdchakanmodel.Value = "shenhe";
                }

            }
        }

        //void GridBind2()
        //{
        //    DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + TFalgs + "' and col1='" + txtInput发票单号.Text.Trim() + "' ");
        //    if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
        //    {
        //        GridView2.DataSource = ds22.Tables[0];
        //        GridView2.DataBind();
        //        ViewState["GridDataSource2"] = ds22.Tables[0];
        //    }
        //    else
        //    {

        //        GridView2.DataSource = null;
        //        GridView2.DataBind();
        //    }

        //}

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


        //protected void FileUpload税票扫描件Button_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload0.HasFile)
        //    {

        //        string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
        //        string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = FileUpload0.PostedFile.FileName;
        //        FileUpload0.SaveAs(filePath + fileName);

        //        税票扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        TextBox税票扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        附件List 附件List = new 附件List();
        //        var Tflag = "";
        //        switch (caset)
        //        {
        //            case "1":
        //                Tflag = "xiangmu91";
        //                break;
        //            case "2":
        //                Tflag = "xiangmu92";
        //                break;
        //            case "3":
        //                Tflag = "xiangmu93";
        //                break;
        //            case "4":
        //                Tflag = "xiangmu94";
        //                break;
        //            case "5":
        //                Tflag = "xiangmu95";
        //                break;
        //            case "11":
        //                Tflag = "xiangmu91";
        //                break;
        //            case "12":
        //                Tflag = "xiangmu91";
        //                break;
        //            case "13":
        //                Tflag = "xiangmu91";
        //                break;
        //            case "14":
        //                Tflag = "xiangmu91";
        //                break;
        //            case "21":
        //                Tflag = "xiangmu92";
        //                break;
        //            case "22":
        //                Tflag = "xiangmu92";
        //                break;
        //            case "23":
        //                Tflag = "xiangmu92";
        //                break;
        //            case "24":
        //                Tflag = "xiangmu92";
        //                break;
        //            case "31":
        //                Tflag = "xiangmu93";
        //                break;
        //            case "32":
        //                Tflag = "xiangmu93";
        //                break;
        //            case "33":
        //                Tflag = "xiangmu93";
        //                break;
        //            case "34":
        //                Tflag = "xiangmu93";
        //                break;
        //            case "41":
        //                Tflag = "xiangmu94";
        //                break;
        //            case "42":
        //                Tflag = "xiangmu94";
        //                break;
        //            case "43":
        //                Tflag = "xiangmu94";
        //                break;
        //            case "44":
        //                Tflag = "xiangmu94";
        //                break;
        //            case "51":
        //                Tflag = "xiangmu95";
        //                break;
        //            case "52":
        //                Tflag = "xiangmu95";
        //                break;
        //            case "53":
        //                Tflag = "xiangmu95";
        //                break;
        //            case "54":
        //                Tflag = "xiangmu95";
        //                break;

        //        }
        //        附件List.flag =Tflag;
        //        附件List.col1 = txtInput发票单号.Text.Trim();
        //        附件List.col2 = "";
        //        附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
        //        附件List.col4 = this.Session["FullName"].ToString();
        //        附件List.col5 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        附件List.col6 = "";
        //        附件List.col7 = "";
        //        附件List.col8 = "";

        //        附件List.InsertData2();

        //        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + Tflag + "' and col1='" + txtInput发票单号.Text.Trim() + "' ");
        //        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
        //        {
        //            GridView2.DataSource = ds2.Tables[0];
        //            GridView2.DataBind();
        //            ViewState["GridDataSource2"] = ds2.Tables[0];
        //        }
        //        else
        //        {

        //            GridView2.DataSource = null;
        //            GridView2.DataBind();
        //        }

        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

        //    }
        //    else
        //    {
        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

        //    }
        //}

        //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        var temp = ((HyperLink)e.Row.FindControl("HyperLink1")).Text;
        //        if (temp != "")
        //        {
        //            var temps = temp.LastIndexOf("/");
        //            if (temps > 0)
        //            {
        //                var temps2 = temp.Substring(temps);
        //                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = temps2;
        //            }

        //        }
        //        string model = base.Request.QueryString["model"];
        //        if (model == "view")
        //        {
        //            ((LinkButton)e.Row.FindControl("gvDelete")).Visible = false;
        //        }

        //    }




        //}

        //protected void btn审核_Click(object sender, EventArgs e)
        //{
        //    //DataTable dt = (DataTable)ViewState["GridDataSource2"];
        //    //DataTable dtnew = dt.Clone();
        //    //DataRow dr;
        //    附件List 附件List = new 附件List();
        //    for (int i = 0; i < GridView2.Rows.Count; i++)
        //    {
        //        string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
        //        附件List.col6 = this.Session["FullName"].ToString();
        //        附件List.col7 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        附件List.col8 = TextBox审核意见.Text.Trim();

        //        附件List.UpdateData2(int.Parse(strNoID));
        //    }

        //    xiangmu1List xiangmu1List = new xiangmu1List();

        //    xiangmu1List.GetData(int.Parse(base.Request.QueryString["id"].ToString()));

        //    xiangmu1List.col27 = "1";

        //    xiangmu1List.UpdateData(int.Parse(base.Request.QueryString["id"].ToString()));

        //}

        //protected void btn审核不通过_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)ViewState["GridDataSource2"];
        //    DataTable dtnew = dt.Clone();
        //    DataRow dr;
        //    附件List 附件List = new 附件List();
        //    for (int i = 0; i < GridView2.Rows.Count; i++)
        //    {
        //        string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
        //        附件List.col6 = this.Session["FullName"].ToString();
        //        附件List.col7 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        附件List.col8 = TextBox审核意见.Text.Trim();

        //        附件List.UpdateData2(int.Parse(strNoID));
        //    }
        //}


        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    附件List 附件List = new 附件List();
        //    if (e.CommandName == "_delete")
        //    {
        //        GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
        //        string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
        //        string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
        //        string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

        //        DataTable dt = (DataTable)ViewState["GridDataSource2"];
        //        DataTable dtnew = dt.Clone();
        //        DataRow dr;
        //        for (int i = 0; i < GridView2.Rows.Count; i++)
        //        {
        //            string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID")).Text.ToString();
        //            if (rowIDs != strNoID)
        //            {
        //                dr = dt.Rows[i];
        //                dtnew.Rows.Add(dr.ItemArray);

        //            }
        //        }
        //        ViewState["GridDataSource2"] = dtnew;
        //        this.GridView2.DataSource = dtnew;
        //        this.GridView2.DataBind();

        //        string IDs = Convert.ToString(((Label)row.FindControl("lblID2")).Text);
        //        if (IDs != "")
        //        {
        //            附件List.DeleteData(int.Parse(IDs));

        //            var fileName = Server.MapPath("公司证件UploadFile/") + strlblcol2.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

        //            if (File.Exists(fileName))
        //            {
        //                File.Delete(fileName);
        //            }
        //        }

        //    }
        //}


        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string sortExpression = e.SortExpression;
            //if (this.ViewState["OrderByKey"].ToString() == sortExpression)
            //{
            //    if ((bool)this.ViewState["OrderByType"])
            //    {
            //        this.ViewState["OrderByType"] = false;
            //    }
            //    else
            //    {
            //        this.ViewState["OrderByType"] = true;
            //    }
            //}
            //else
            //{
            //    this.ViewState["OrderByKey"] = e.SortExpression;
            //}

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string FormNo = ((Label)e.Row.FindControl("lbl发票申请单号")).Text.Trim();
                //DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'xiangmu91' and col1='" + FormNo + "' order by ID DESC ");

                //if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                //    {
                //        ((TextBox)e.Row.FindControl("TextBox发票扫描件")).Text = ds2.Tables[0].Rows[0]["col3"].ToString();
                //        ((HyperLink)e.Row.FindControl("HyperLink发票资料管理")).NavigateUrl = ds2.Tables[0].Rows[0]["col3"].ToString();
                //        ((HyperLink)e.Row.FindControl("HyperLink发票资料管理")).Visible = true;
                //        ((LinkButton)e.Row.FindControl("btnAttach1")).Visible = true;
                //    }

                //}
                if (Hdtcaset.Value == "1")
                {
                    GridView1.Columns[12].HeaderText = "发票资料管理";
                }
                else if (Hdtcaset.Value == "2")
                {
                    GridView1.Columns[12].HeaderText = "采购订单资料管理";
                }
                else if (Hdtcaset.Value == "3")
                {
                    GridView1.Columns[12].HeaderText = "结算资料管理";
                }
                else if (Hdtcaset.Value == "4")
                {
                    GridView1.Columns[12].HeaderText = "审计资料管理";
                }
                else if (Hdtcaset.Value == "5")
                {
                    GridView1.Columns[12].HeaderText = "竣工资料管理";
                }
                else if (Hdtcaset.Value == "11")
                {
                    GridView1.Columns[12].HeaderText = "发票资料管理";
                }
                else if (Hdtcaset.Value == "12")
                {
                    GridView1.Columns[12].HeaderText = "发票资料管理";
                }
                else if (Hdtcaset.Value == "13")
                {
                    GridView1.Columns[12].HeaderText = "发票资料管理";
                }
                else if (Hdtcaset.Value == "14")
                {
                    GridView1.Columns[12].HeaderText = "发票资料管理";
                }
                else if (Hdtcaset.Value == "21")
                {
                    GridView1.Columns[12].HeaderText = "采购订单资料管理";
                }
                else if (Hdtcaset.Value == "22")
                {
                    GridView1.Columns[12].HeaderText = "采购订单资料管理";
                }
                else if (Hdtcaset.Value == "23")
                {
                    GridView1.Columns[12].HeaderText = "采购订单资料管理";
                }
                else if (Hdtcaset.Value == "24")
                {
                    GridView1.Columns[12].HeaderText = "采购订单资料管理";
                }
                else if (Hdtcaset.Value == "31")
                {
                    GridView1.Columns[12].HeaderText = "结算资料管理";
                }
                else if (Hdtcaset.Value == "32")
                {
                    GridView1.Columns[12].HeaderText = "结算资料管理";
                }
                else if (Hdtcaset.Value == "33")
                {
                    GridView1.Columns[12].HeaderText = "结算资料管理";
                }
                else if (Hdtcaset.Value == "34")
                {
                    GridView1.Columns[12].HeaderText = "结算资料管理";
                }
                else if (Hdtcaset.Value == "41")
                {
                    GridView1.Columns[12].HeaderText = "审计资料管理";
                }
                else if (Hdtcaset.Value == "42")
                {
                    GridView1.Columns[12].HeaderText = "审计资料管理";
                }
                else if (Hdtcaset.Value == "43")
                {
                    GridView1.Columns[12].HeaderText = "审计资料管理";
                }
                else if (Hdtcaset.Value == "44")
                {
                    GridView1.Columns[12].HeaderText = "审计资料管理";
                }
                else if (Hdtcaset.Value == "51")
                {
                    GridView1.Columns[12].HeaderText = "竣工资料管理";
                }
                else if (Hdtcaset.Value == "52")
                {
                    GridView1.Columns[12].HeaderText = "竣工资料管理";
                }
                else if (Hdtcaset.Value == "53")
                {
                    GridView1.Columns[12].HeaderText = "竣工资料管理";
                }
                else if (Hdtcaset.Value == "54")
                {
                    GridView1.Columns[12].HeaderText = "竣工资料管理";
                }


            }
        }

        protected void btn提交2_Click(object sender, EventArgs e)
        {
            this.GridBind();

        }

        protected void btn提交22_Click(object sender, EventArgs e)
        {
            //this.GridBind2();
            var Pdata = "<script>LinkPrintshow();</script>";

            ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata);//將結果傳到Cient Site.

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string rowIDs = Convert.ToString(((Label)row.FindControl("lbl发票申请单号")).Text);
            string fullname = this.Session["FullName"].ToString();
            string txtquanxian = "1";
            if (e.CommandName == "lbtn11")
            {
                var ttemp1 = temp1.Trim() == "" ? "000" : temp1.Trim();
                var ttemp2 = temp2.Trim() == "" ? "000" : temp2.Trim();
                var ttemp3 = temp3.Trim() == "" ? "000" : temp3.Trim();
                var ttemp4 = temp4.Trim() == "" ? "000" : temp4.Trim();
                var ttemp5 = temp5.Trim() == "" ? "000" : temp5.Trim();
                var ttemp6 = temp6.Trim() == "" ? "000" : temp6.Trim();
                var ttemp7 = temp7.Trim() == "" ? "000" : temp7.Trim();
                var ttemp8 = temp8.Trim() == "" ? "000" : temp8.Trim();
                var ttemp9 = temp9.Trim() == "" ? "000" : temp9.Trim();
                var tcaset = caset.Trim() == "" ? "000" : caset.Trim();
               
                //var Pdata = "<script> var  chakanmodel ='"
                //     + base.Request.QueryString["chakanmodel"] + "';fullname ='"
                //     + fullname + "';tickedFormNo ="
                //     + rowIDs + ";txtquanxian ="
                //     + txtquanxian + ";temp1 ="
                //     + ttemp1 + ";temp2 ="
                //     + ttemp2 + ";temp3 ="
                //     + ttemp3 + ";temp4 ="
                //     + ttemp4 + ";temp5 ="
                //     + ttemp5 + ";temp6 ="
                //     + ttemp6 + ";temp7 ="
                //     + ttemp7 + ";temp8 ="
                //     + ttemp8 + ";temp9 ="
                //     + ttemp9 + ";caset ="
                //     + tcaset + ";LinkPrintPage();</script>";

                //ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata);//將結果傳到Cient Site.

               
                var Pdata = "<script> var chakanmodel ='"
                    + base.Request.QueryString["chakanmodel"] + "';LinkPrintPage2();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata,true);//將結果傳到Cient Site.


                //FileUpload FileUpload1 = ((FileUpload)row.FindControl("FileUpload1"));
                //HyperLink 发票扫描件href = ((HyperLink)row.FindControl("HyperLink发票资料管理"));
                //TextBox TextBox发票扫描件 = ((TextBox)row.FindControl("TextBox发票扫描件"));

                //if (FileUpload1.HasFile)
                //{
                //    //string filePath = Server.MapPath("公司证件UploadFile/");
                //    string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                //    string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                //    if (!Directory.Exists(filePath))
                //    {
                //        Directory.CreateDirectory(filePath);
                //    }
                //    string fileName = FileUpload1.PostedFile.FileName;
                //    FileUpload1.SaveAs(filePath + fileName);

                //    发票扫描件href.NavigateUrl = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //    TextBox发票扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //    附件List 附件List = new 附件List();
                //    附件List.flag = "xiangmu91";
                //    附件List.col1 = rowIDs;
                //    附件List.col2 = CreateNext();
                //    附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //    附件List.InsertData();

                //    GridView1.DataSource = ViewState["GridDataSource"];
                //    GridView1.DataBind();

                //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

                //}
                //else
                //{
                //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

                //}

            }
            //if (e.CommandName == "btnAttach1")
            //{
            //    HyperLink 发票扫描件href = ((HyperLink)row.FindControl("HyperLink发票资料管理"));
            //    TextBox TextBox发票扫描件 = ((TextBox)row.FindControl("TextBox发票扫描件"));

            //    var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            //    if (File.Exists(fileName))
            //    {
            //        File.Delete(fileName);

            //        附件List 附件List = new 附件List();
            //        附件List.flag = "xiangmu91";
            //        附件List.col1 = rowIDs;
            //        附件List.col3 = TextBox发票扫描件.Text;

            //        附件List.DeleteData2(附件List.flag, 附件List.col1, 附件List.col3);
            //        TextBox发票扫描件.Text = "";
            //        发票扫描件href.NavigateUrl = "";

            //    }
            //}

        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "");
        }

        protected void btn提交_Click(object sender, EventArgs e)
        {
            var Tflag = "";
            switch (caset)
            {
                case "1":
                    Tflag = "xiangmu91";
                    break;
                case "2":
                    Tflag = "xiangmu92";
                    break;
                case "3":
                    Tflag = "xiangmu93";
                    break;
                case "4":
                    Tflag = "xiangmu94";
                    break;
                case "5":
                    Tflag = "xiangmu95";
                    break;
                case "11":
                    Tflag = "xiangmu91";
                    break;
                case "12":
                    Tflag = "xiangmu91";
                    break;
                case "13":
                    Tflag = "xiangmu91";
                    break;
                case "14":
                    Tflag = "xiangmu91";
                    break;
                case "21":
                    Tflag = "xiangmu92";
                    break;
                case "22":
                    Tflag = "xiangmu92";
                    break;
                case "23":
                    Tflag = "xiangmu92";
                    break;
                case "24":
                    Tflag = "xiangmu92";
                    break;
                case "31":
                    Tflag = "xiangmu93";
                    break;
                case "32":
                    Tflag = "xiangmu93";
                    break;
                case "33":
                    Tflag = "xiangmu93";
                    break;
                case "34":
                    Tflag = "xiangmu93";
                    break;
                case "41":
                    Tflag = "xiangmu94";
                    break;
                case "42":
                    Tflag = "xiangmu94";
                    break;
                case "43":
                    Tflag = "xiangmu94";
                    break;
                case "44":
                    Tflag = "xiangmu94";
                    break;
                case "51":
                    Tflag = "xiangmu95";
                    break;
                case "52":
                    Tflag = "xiangmu95";
                    break;
                case "53":
                    Tflag = "xiangmu95";
                    break;
                case "54":
                    Tflag = "xiangmu95";
                    break;

            }
            string id = base.Request.QueryString["id"].ToString();
            xiangmu1List xiangmu1List = new xiangmu1List();
           
            xiangmu1List.GetData(int.Parse(id));

            if (HiddenField1.Value == "" && base.Request.QueryString["chakanmodel"] == "shenhe" && (xiangmu1List.col27 == "" || xiangmu1List.col28 == ""))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请先点击审核通过或者不通过");
                return;
            }

            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {

                var k = i + 1;

                var FormNos = ((Label)GridView1.Rows[i].FindControl("lbl发票申请单号")).Text;
                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + Tflag + "' and col1='" + FormNos + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count <= 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传" + k + "行发票扫描件！");
                    return;
                }
              
            }
           
            //else if (HiddenField1.Value == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请至少有一笔附件");
            //    return;
            //}
            var shenhetongguo = false;
           
            if (base.Request.QueryString["caset"] == "1")
            {
                xiangmu1List.col22 = "1";
            }
            else if (base.Request.QueryString["caset"] == "2")
            {
                xiangmu1List.col23 = "1";
            }
            else if (base.Request.QueryString["caset"] == "3")
            {
                xiangmu1List.col24 = "1";
            }
            else if (base.Request.QueryString["caset"] == "4")
            {
                xiangmu1List.col25 = "1";
            }
            else if (base.Request.QueryString["caset"] == "5")
            {
                xiangmu1List.col26 = "1";
            }
            else if (base.Request.QueryString["caset"] == "11")
            {
                xiangmu1List.col22 = "1";
            }
            else if (base.Request.QueryString["caset"] == "12")
            {
                xiangmu1List.col22 = "1";
            }
            else if (base.Request.QueryString["caset"] == "13")
            {
                xiangmu1List.col22 = "1";
                shenhetongguo = true;
            }
            else if (base.Request.QueryString["caset"] == "14")
            {
                xiangmu1List.col22 = "1";
                
            }
            else if (base.Request.QueryString["caset"] == "21")
            {
                xiangmu1List.col23 = "1";
            }
            else if (base.Request.QueryString["caset"] == "22")
            {
                xiangmu1List.col23 = "1";
            }
            else if (base.Request.QueryString["caset"] == "23")
            {
                xiangmu1List.col23 = "1";
                shenhetongguo = true;
            }
            else if (base.Request.QueryString["caset"] == "24")
            {
                xiangmu1List.col23 = "1";
                
            }
            else if (base.Request.QueryString["caset"] == "31")
            {
                xiangmu1List.col24 = "1";
            }
            else if (base.Request.QueryString["caset"] == "32")
            {
                xiangmu1List.col24 = "1";
            }
            else if (base.Request.QueryString["caset"] == "33")
            {
                xiangmu1List.col24 = "1";
                shenhetongguo = true;
            }
            else if (base.Request.QueryString["caset"] == "34")
            {
                xiangmu1List.col24 = "1";
                
            }
            else if (base.Request.QueryString["caset"] == "41")
            {
                xiangmu1List.col25 = "1";
            }
            else if (base.Request.QueryString["caset"] == "42")
            {
                xiangmu1List.col25 = "1";
            }
            else if (base.Request.QueryString["caset"] == "43")
            {
                xiangmu1List.col25 = "1";
                shenhetongguo = true;
            }
            else if (base.Request.QueryString["caset"] == "44")
            {
                xiangmu1List.col25 = "1";
               
            }
            else if (base.Request.QueryString["caset"] == "51")
            {
                xiangmu1List.col26 = "1";
            }
            else if (base.Request.QueryString["caset"] == "52")
            {
                xiangmu1List.col26 = "1";
            }
            else if (base.Request.QueryString["caset"] == "53")
            {
                xiangmu1List.col26 = "1";
                shenhetongguo = true;
            }
            else if (base.Request.QueryString["caset"] == "54")
            {
                xiangmu1List.col26 = "1";
                
            }
            xiangmu1List.col28 = "";
           
            xiangmu1List.UpdateData(int.Parse(id));

            附件List 附件List = new 附件List();
            if (base.Request.QueryString["chakanmodel"] == "shenhe" && shenhetongguo == true)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string lbl发票申请单号 = ((Label)GridView1.Rows[i].FindControl("lbl发票申请单号")).Text.ToString();
                    附件List.col9 = "1";

                    附件List.flag = Tflag;
                    附件List.col1 = lbl发票申请单号;

                    附件List.UpdateData3();
                }
            }

            base.Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "");
        }


    }
}