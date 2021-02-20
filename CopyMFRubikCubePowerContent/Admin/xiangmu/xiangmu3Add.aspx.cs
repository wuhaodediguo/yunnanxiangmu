using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class xiangmu3Add : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

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

                                    //youshuju = false;
                                    //for (int kk = 0; kk < ds2.Tables[0].Rows.Count; kk++)
                                    //{
                                    //    if (youshuju == true)
                                    //    {
                                    //        iiii++;
                                    //    }

                                    //    youshuju = true;
                                    //    //dr = dt.NewRow();
                                    //    //dr["A1"] = iiii + 1;
                                    //    //dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                                    //    //dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                                    //    //dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                                    //    //dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                                    //    //dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];

                                    //    dr = dt.NewRow();
                                    //    dr["A1"] = iiii + 1;
                                    //    dr["A11"] = ds02.Tables[0].Rows[kk]["col18"];
                                    //    dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                                    //    dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                                    //    dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                                    //    dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                                    //    dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];

                                    //    dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];

                                    //    if (ds2.Tables[0].Rows[kk]["col39"].ToString() != "")
                                    //    {


                                    //        //dr["A7"] = ds2.Tables[0].Rows[kk]["col2"];
                                    //        dr["A8"] = ds2.Tables[0].Rows[kk]["col39"];
                                    //        dr["A9"] = ds2.Tables[0].Rows[kk]["col40"];
                                    //        dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                    //        dt.Rows.Add(dr);
                                    //    }
                                    //    else
                                    //    {
                                    //        dt.Rows.Add(dr);
                                    //    }
                                    //    //dt.Rows.Add(dr);

                                    //    youshuju = true;
                                        
                                    //    if (ds2.Tables[0].Rows[kk]["col41"].ToString() != "")
                                    //    {
                                    //        dr = dt.NewRow();
                                    //        dr["A1"] = iiii + 1;
                                    //        dr["A11"] = ds02.Tables[0].Rows[kk]["col18"];
                                    //        dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                                    //        dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                                    //        dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                                    //        dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                                    //        dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];
                                    //        dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                    //        dr["A8"] = ds2.Tables[0].Rows[kk]["col41"];
                                    //        dr["A9"] = ds2.Tables[0].Rows[kk]["col42"];
                                    //        dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                    //        dt.Rows.Add(dr);
                                    //    }
                                       

                                    //    youshuju = true;
                                        
                                    //    if (ds2.Tables[0].Rows[kk]["col43"].ToString() != "")
                                    //    {
                                    //        dr = dt.NewRow();
                                    //        dr["A1"] = iiii + 1;
                                    //        dr["A11"] = ds02.Tables[0].Rows[kk]["col18"];
                                    //        dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                                    //        dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                                    //        dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                                    //        dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                                    //        dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];
                                    //        dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                    //        dr["A8"] = ds2.Tables[0].Rows[kk]["col43"];
                                    //        dr["A9"] = ds2.Tables[0].Rows[kk]["col44"];
                                    //        dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                    //        dt.Rows.Add(dr);
                                    //    }
                                       

                                    //    youshuju = true;
                                        
                                    //    if (ds2.Tables[0].Rows[kk]["col45"].ToString() != "")
                                    //    {
                                    //        dr = dt.NewRow();
                                    //        dr["A1"] = iiii + 1;
                                    //        dr["A11"] = ds02.Tables[0].Rows[kk]["col18"];
                                    //        dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                                    //        dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                                    //        dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                                    //        dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                                    //        dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];
                                    //        dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                    //        dr["A8"] = ds2.Tables[0].Rows[kk]["col45"];
                                    //        dr["A9"] = ds2.Tables[0].Rows[kk]["col46"];
                                    //        dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                    //        dt.Rows.Add(dr);
                                    //    }
                                      

                                    //    youshuju = true;
                                        
                                    //    if (ds2.Tables[0].Rows[kk]["col47"].ToString() != "")
                                    //    {
                                    //        dr = dt.NewRow();
                                    //        dr["A1"] = iiii + 1;
                                    //        dr["A11"] = ds02.Tables[0].Rows[kk]["col18"];
                                    //        dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                                    //        dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                                    //        dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                                    //        dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                                    //        dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];
                                    //        dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                    //        dr["A8"] = ds2.Tables[0].Rows[kk]["col47"];
                                    //        dr["A9"] = ds2.Tables[0].Rows[kk]["col48"];
                                    //        dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                    //        dt.Rows.Add(dr);
                                    //    }
                                       

                                    //}
                                }
                            }

                        }
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();

//                        string sql3 = @"select t_caiwu22.col8,t_caiwu22.col14,t_caiwu2.col2, t_caiwu2.col54, t_caiwu2.col5,  t_caiwu2.col7,
//                                         t_caiwu2.col39,t_caiwu2.col40,t_caiwu2.col41,t_caiwu2.col42,   t_caiwu2.col43,t_caiwu2.col44,
//                                         t_caiwu2.col45,t_caiwu2.col46,   t_caiwu2.col47,t_caiwu2.col48, t_caiwu2.col49
//                                        from t_caiwu22 inner join   t_caiwu2 on  t_caiwu22.col18 =  t_caiwu2.col53
//                                        where t_caiwu22.col43='" + id + "'  ";

                        //DataSet ds2 = Sql.SqlQueryDS(sql3);
                        //if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        //{
                           
                            
                        //    this.GridView1.DataSource = dt;
                        //    this.GridView1.DataBind();
                        //}


                    }

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


            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("xiangmu3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "");
        }


    }
}