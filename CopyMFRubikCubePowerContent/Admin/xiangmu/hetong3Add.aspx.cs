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
using System.Collections;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class hetong3Add : System.Web.UI.Page
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
                //getDrop所属项目部();
                //getDrop所属项目部2();
                //getDrop所属项目部3();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        string id2 = base.Request.QueryString["idno3"];
                        DataSet ds2 = Sql.SqlQueryDS("select * from t_hetong33 where col5 = '" + id2 + "'");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            ViewState["GridDataSource"] = ds2.Tables[0];
                            this.GridView1.DataSource = ds2.Tables[0];
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = ds2.Tables[0];
                        }
                        else
                        {
                            DataTable dt = new DataTable("column");
                            DataRow dr;

                            dt.Columns.Add("col1");
                            dt.Columns.Add("col2");
                            dt.Columns.Add("col3");
                            dt.Columns.Add("col4");

                            dt.Columns.Add("col5");


                            dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            this.GridView1.DataSource = dt;
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = dt;
                        }
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();
                   
                    DataSet ds = Sql.SqlQueryDS("select * from t_hetong3 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        txt采购合同名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox采购合同编号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox供货单位.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox订货单位.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox采购合同金额.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        DropDown采购合同发票类型.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox采购合同税率.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        DropDown采购合同类别.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox采购日期.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox供货单位联系人.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox供货单位联系电话.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        //Drop所属项目部.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        //getDrop所属项目经理();

                        //Drop项目经理.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        //TextBox项目经理金额.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox电子版合同.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox合同扫描件.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox合同其他附件.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col20"].ToString();

                        TextBoxbaocunnocol53.Text = hdNo3.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        //Drop所属项目部2.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        //Drop项目经理2.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        //TextBox项目经理金额2.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        //Drop所属项目部3.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        //Drop项目经理3.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        //TextBox项目经理金额3.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        
                        //getDrop所属项目经理2();
                        //getDrop所属项目经理3();

                        //if (TextBox电子版合同.Text != "")
                        //{
                        //    电子版合同href.HRef = TextBox电子版合同.Text;
                        //    电子版合同href.Visible = true;
                        //}
                        //if (TextBox合同扫描件.Text != "")
                        //{
                        //    合同扫描件href.HRef = TextBox合同扫描件.Text;
                        //    合同扫描件href.Visible = true;
                        //}
                        //if (TextBox合同其他附件.Text != "")
                        //{
                        //    合同其他附件href.HRef = TextBox合同其他附件.Text;
                        //    合同其他附件href.Visible = true;
                        //}

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_hetong33 where col5 = '" + ds.Tables[0].Rows[0]["col21"].ToString() + "'");
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            ViewState["GridDataSource"] = ds22.Tables[0];
                            this.GridView1.DataSource = ds22.Tables[0];
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = ds22.Tables[0];
                        }
                        else
                        {
                            DataTable dt = new DataTable("column");
                            DataRow dr;

                            dt.Columns.Add("col1");
                            dt.Columns.Add("col2");
                            dt.Columns.Add("col3");
                            dt.Columns.Add("col4");
                            dt.Columns.Add("col5");

                            dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            this.GridView1.DataSource = dt;
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = dt;
                        }



                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong31' and col1='" + id + "' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                            GridView2.DataSource = ds2.Tables[0];
                            GridView2.DataBind();
                            ViewState["GridDataSource2"] = ds2.Tables[0];
                        }
                        else
                        {
                            HdCol2附件1.Value = "";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        }

                        DataSet ds222 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong32' and col1='" + id + "' ");
                        if (ds222 != null && ds222.Tables[0] != null && ds222.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件2.Value = ds222.Tables[0].Rows[0]["col2"].ToString();
                            GridView3.DataSource = ds222.Tables[0];
                            GridView3.DataBind();
                            ViewState["GridDataSource3"] = ds222.Tables[0];
                        }
                        else
                        {
                            HdCol2附件2.Value = "";
                            GridView3.DataSource = null;
                            GridView3.DataBind();
                        }

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong33' and col1='" + id + "' ");
                        if (ds23 != null && ds23.Tables[0] != null && ds23.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件3.Value = ds23.Tables[0].Rows[0]["col2"].ToString();
                            GridView4.DataSource = ds23.Tables[0];
                            GridView4.DataBind();
                            ViewState["GridDataSource4"] = ds23.Tables[0];
                        }
                        else
                        {
                            HdCol2附件3.Value = "";
                            GridView4.DataSource = null;
                            GridView4.DataBind();
                        }


                    }

                    

                    string model = base.Request.QueryString["model"];
                    if (model == "view")
                    {

                        txt采购合同名称.Attributes.Add("readOnly", "readOnly");
                        TextBox采购合同编号.Attributes.Add("readOnly", "readOnly");
                        TextBox供货单位.Attributes.Add("readOnly", "readOnly");
                        TextBox订货单位.Attributes.Add("readOnly", "readOnly");
                        TextBox采购合同金额.Attributes.Add("readOnly", "readOnly");
                        DropDown采购合同发票类型.Enabled = false;
                        TextBox采购合同税率.Attributes.Add("readOnly", "readOnly");
                        DropDown采购合同类别.Enabled = false;
                        TextBox采购日期.Attributes.Add("readOnly", "readOnly");
                        TextBox供货单位联系人.Attributes.Add("readOnly", "readOnly");
                        TextBox供货单位联系电话.Attributes.Add("readOnly", "readOnly");
                        //Drop所属项目部.Enabled = false;
                        //Drop项目经理.Enabled = false;
                        //TextBox项目经理金额.Attributes.Add("readOnly", "readOnly");
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                        TextBox电子版合同.Attributes.Add("readOnly", "readOnly");
                        TextBox合同扫描件.Attributes.Add("readOnly", "readOnly");
                        TextBox合同其他附件.Attributes.Add("readOnly", "readOnly");
                        TextBox备注.Attributes.Add("readOnly", "readOnly");

                        //Drop所属项目部2.Attributes.Add("readOnly", "readOnly");
                        //Drop项目经理2.Attributes.Add("readOnly", "readOnly");
                        //TextBox项目经理金额2.Attributes.Add("readOnly", "readOnly");
                        //Drop所属项目部3.Attributes.Add("readOnly", "readOnly");
                        //Drop项目经理3.Attributes.Add("readOnly", "readOnly");
                        //TextBox项目经理金额3.Attributes.Add("readOnly", "readOnly");

                        Button5.Enabled = false;
                        FileUpload1.Visible = false;
                        FileUpload2.Visible = false;
                        FileUpload3.Visible = false;
                        Button6.Enabled = false;
                        Button4.Enabled = false;
                        Button3.Visible = false;
                        btnAttach.Visible = false;
                        LinkButton1.Visible = false;
                        LinkButton2.Visible = false;

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
                    if (dataSource.Rows[6]["col2"].ToString() == "1" && dataSource.Rows[6]["col1"].ToString() == "div0031")
                    {
                        dd0031.Visible = true;
                    }
                    else
                    {
                        dd0031.Visible = false;
                    }
                    if (dataSource.Rows[7]["col2"].ToString() == "1" && dataSource.Rows[7]["col1"].ToString() == "div0032")
                    {
                        dd0032.Visible = true;
                    }
                    else
                    {
                        dd0032.Visible = false;
                    }
                    if (dataSource.Rows[8]["col2"].ToString() == "1" && dataSource.Rows[8]["col1"].ToString() == "div0033")
                    {
                        dd0033.Visible = true;
                    }
                    else
                    {
                        dd0033.Visible = false;
                    }
                    if (dataSource.Rows[9]["col2"].ToString() == "1" && dataSource.Rows[9]["col1"].ToString() == "div0034")
                    {
                        dd0034.Visible = true;
                    }
                    else
                    {
                        dd0034.Visible = false;
                    }

                }

            }
            else
            {
                div0031.Visible = false;
                div0032.Visible = false;
                div0033.Visible = false;
                div0034.Visible = false;

            }
        }

        //protected void getDrop所属项目部()
        //{
        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("xiangmu");
        //    DataRow dr;

        //    //sql = "select ID,guige  from tb_guige where 1=1     ";
        //    sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    string[] strxiangmu;
        //    if (dataSource.Rows.Count > 0)
        //    {
        //        strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
        //        for (int k = 0; k < strxiangmu.Length; k++)
        //        {
        //            if (strxiangmu[k].ToString().Trim() == "")
        //            {
        //                continue;
        //            }
        //            dr = dt.NewRow();
        //            dr["xiangmu"] = strxiangmu[k];
        //            dt.Rows.Add(dr);
        //        }

        //    }

        //    Drop所属项目部.DataTextField = "xiangmu";
        //    Drop所属项目部.DataValueField = "xiangmu";
        //    Drop所属项目部.DataSource = dt;
        //    Drop所属项目部.DataBind();
        //    Drop所属项目部.Items.Insert(0, "");

        //}

        //protected void getDrop所属项目经理()
        //{
        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部.Text + "'    ";
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    Drop项目经理.DataTextField = "col2";
        //    Drop项目经理.DataValueField = "col2";
        //    Drop项目经理.DataSource = dataSource;
        //    Drop项目经理.DataBind();
        //    Drop项目经理.Items.Insert(0, "");

        //}

        //protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Drop所属项目部.Text != "")
        //    {
        //        getDrop所属项目经理();
        //    }
        //    else
        //    {
        //        OledbHelper oledbHelper = new OledbHelper();
        //        string sql = string.Empty;
        //        DataTable dataSource = new DataTable();
        //        sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
        //        dataSource = oledbHelper.GetDataTable(sql);
        //        Drop项目经理.DataTextField = "col2";
        //        Drop项目经理.DataValueField = "col2";
        //        Drop项目经理.DataSource = dataSource;
        //        Drop项目经理.DataBind();
        //        Drop项目经理.Items.Insert(0, "");
        //    }
        //}

        //protected void getDrop所属项目部2()
        //{
        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("xiangmu");
        //    DataRow dr;

        //    //sql = "select ID,guige  from tb_guige where 1=1     ";
        //    sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    string[] strxiangmu;
        //    if (dataSource.Rows.Count > 0)
        //    {
        //        strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
        //        for (int k = 0; k < strxiangmu.Length; k++)
        //        {
        //            if (strxiangmu[k].ToString().Trim() == "")
        //            {
        //                continue;
        //            }
        //            dr = dt.NewRow();
        //            dr["xiangmu"] = strxiangmu[k];
        //            dt.Rows.Add(dr);
        //        }

        //    }

        //    Drop所属项目部2.DataTextField = "xiangmu";
        //    Drop所属项目部2.DataValueField = "xiangmu";
        //    Drop所属项目部2.DataSource = dt;
        //    Drop所属项目部2.DataBind();
        //    Drop所属项目部2.Items.Insert(0, "");

        //}

        //protected void getDrop所属项目经理2()
        //{
        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部2.Text + "'    ";
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    Drop项目经理2.DataTextField = "col2";
        //    Drop项目经理2.DataValueField = "col2";
        //    Drop项目经理2.DataSource = dataSource;
        //    Drop项目经理2.DataBind();
        //    Drop项目经理2.Items.Insert(0, "");

        //}

        //protected void Drop所属项目部2SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Drop所属项目部2.Text != "")
        //    {
        //        getDrop所属项目经理2();
        //    }
        //    else
        //    {
        //        OledbHelper oledbHelper = new OledbHelper();
        //        string sql = string.Empty;
        //        DataTable dataSource = new DataTable();
        //        sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
        //        dataSource = oledbHelper.GetDataTable(sql);
        //        Drop项目经理2.DataTextField = "col2";
        //        Drop项目经理2.DataValueField = "col2";
        //        Drop项目经理2.DataSource = dataSource;
        //        Drop项目经理2.DataBind();
        //        Drop项目经理2.Items.Insert(0, "");
        //    }
        //}

        //protected void getDrop所属项目部3()
        //{
        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("xiangmu");
        //    DataRow dr;

        //    //sql = "select ID,guige  from tb_guige where 1=1     ";
        //    sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    string[] strxiangmu;
        //    if (dataSource.Rows.Count > 0)
        //    {
        //        strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
        //        for (int k = 0; k < strxiangmu.Length; k++)
        //        {
        //            if (strxiangmu[k].ToString().Trim() == "")
        //            {
        //                continue;
        //            }
        //            dr = dt.NewRow();
        //            dr["xiangmu"] = strxiangmu[k];
        //            dt.Rows.Add(dr);
        //        }

        //    }

        //    Drop所属项目部3.DataTextField = "xiangmu";
        //    Drop所属项目部3.DataValueField = "xiangmu";
        //    Drop所属项目部3.DataSource = dt;
        //    Drop所属项目部3.DataBind();
        //    Drop所属项目部3.Items.Insert(0, "");

        //}

        //protected void getDrop所属项目经理3()
        //{
        //    OledbHelper oledbHelper = new OledbHelper();
        //    string sql = string.Empty;
        //    DataTable dataSource = new DataTable();
        //    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部3.Text + "'    ";
        //    dataSource = oledbHelper.GetDataTable(sql);
        //    Drop项目经理3.DataTextField = "col2";
        //    Drop项目经理3.DataValueField = "col2";
        //    Drop项目经理3.DataSource = dataSource;
        //    Drop项目经理3.DataBind();
        //    Drop项目经理3.Items.Insert(0, "");

        //}

        //protected void Drop所属项目部3SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Drop所属项目部3.Text != "")
        //    {
        //        getDrop所属项目经理3();
        //    }
        //    else
        //    {
        //        OledbHelper oledbHelper = new OledbHelper();
        //        string sql = string.Empty;
        //        DataTable dataSource = new DataTable();
        //        sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
        //        dataSource = oledbHelper.GetDataTable(sql);
        //        Drop项目经理3.DataTextField = "col2";
        //        Drop项目经理3.DataValueField = "col2";
        //        Drop项目经理3.DataSource = dataSource;
        //        Drop项目经理3.DataBind();
        //        Drop项目经理3.Items.Insert(0, "");
        //    }
        //}


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt采购合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写采购合同名称");
                return;
            }
            if (this.TextBox采购合同编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写采购合同编号");
                return;
            }
            if (this.TextBox采购合同金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写采购合同金额");
                return;
            }
            if (this.TextBox供货单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写供货单位");
                return;
            }
            TextBoxbaocunnocol53.Text = TextBoxbaocunnocol53.Text == "" ? CreateNext2() : TextBoxbaocunnocol53.Text;
              

            hetong3List shichangList = new hetong3List();
            shichangList.col1 = txt采购合同名称.Text.Trim();
            shichangList.col2 = TextBox采购合同编号.Text.Trim();
            shichangList.col3 = TextBox供货单位.Text.Trim();
            shichangList.col4 = TextBox订货单位.Text.Trim();
            shichangList.col5 = TextBox采购合同金额.Text.Trim();
            shichangList.col6 = DropDown采购合同发票类型.Text.Trim();
            shichangList.col7 = TextBox采购合同税率.Text.Trim();
            shichangList.col8 = DropDown采购合同类别.Text.Trim();
            shichangList.col9 = TextBox采购日期.Text.Trim();
            shichangList.col10 = TextBox供货单位联系人.Text.Trim();
            shichangList.col11 = TextBox供货单位联系电话.Text.Trim();
            shichangList.col12 = "";
            shichangList.col13 = "";
            shichangList.col14 = "";
            shichangList.col15 = TextBox创建人.Text.Trim();
            shichangList.col16 = TextBox创建日期.Text.Trim();

            if (this.GridView1.Rows.Count == 0)
            {
                shichangList.col17 = "0";
            }
            else
            {
                shichangList.col17 = "1";
            }
            if (this.GridView2.Rows.Count == 0)
            {
                shichangList.col18 = "0";
            }
            else
            {
                shichangList.col18 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                shichangList.col19 = "0";
            }
            else
            {
                shichangList.col19 = "1";
            }
            //shichangList.col17 = TextBox电子版合同.Text.Trim();
            //shichangList.col18 = TextBox合同扫描件.Text.Trim();
            //shichangList.col19 = TextBox合同其他附件.Text.Trim();
            shichangList.col20 = TextBox备注.Text.Trim();

            shichangList.col21 = TextBoxbaocunnocol53.Text.Trim();

            //shichangList.col21 = Drop所属项目部2.Text.Trim();
            //shichangList.col22 = Drop项目经理2.Text.Trim();
            //shichangList.col23 = TextBox项目经理金额2.Text.Trim();
            //shichangList.col24 = Drop所属项目部3.Text.Trim();
            //shichangList.col25 = Drop项目经理3.Text.Trim();
            //shichangList.col26 = TextBox项目经理金额3.Text.Trim();

            int ssID = 0;
            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());
                shichangList.UpdateData(shichangList.ID);
                ssID = shichangList.ID;
            }
            else
            {
                ssID = shichangList.InsertData();
            }

            string ID2 = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_hetong3 where col21 = '" + TextBoxbaocunnocol53.Text.Trim() + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ID2 = ds.Tables[0].Rows[0]["ID"].ToString();
                hdNo2.Text = ID2;
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string ID = ((Label)GridView1.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string ID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string ID = ((Label)GridView3.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }


            base.Response.Redirect("hetong3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("hetong3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload电子版合同Button_Click(object sender, EventArgs e)
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

                电子版合同href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox电子版合同.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong31";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext22() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong31' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView2.DataSource = ds2.Tables[0];
                    GridView2.DataBind();
                    ViewState["GridDataSource2"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件1.Value = "";
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload合同扫描件Button_Click(object sender, EventArgs e)
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

                合同扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox合同扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong32";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext22() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong32' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件2.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView3.DataSource = ds2.Tables[0];
                    GridView3.DataBind();
                    ViewState["GridDataSource3"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件2.Value = "";
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

        protected void FileUpload合同其他附件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload3.PostedFile.FileName;
                FileUpload3.SaveAs(filePath + fileName);

                合同其他附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox合同其他附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong33";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext22() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong33' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件3.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView4.DataSource = ds2.Tables[0];
                    GridView4.DataBind();
                    ViewState["GridDataSource4"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件3.Value = "";
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (role == "审核")
                //{
                //    GridView1.Columns[0].Visible = false;
                //    GridView1.Columns[1].Visible = false;
                //}


            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource2"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView2.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource2"] = dtnew;
                this.GridView2.DataSource = dtnew;
                this.GridView2.DataBind();

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

        string CreateNext22()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col2) as col1 from t_fujian where 1=1  ";
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




        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col4) as col4 from t_hetong33 where 1=1 and col6 = '" + strdate + "' ";
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
            return  DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
        }

        string CreateNext2()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            sql = "select max(col21) as col21 from t_hetong3 where 1=1 and col16 = '" + strdate + "' ";
            dataSource = oledbHelper.GetDataTable(sql);
            if (dataSource.Rows.Count > 0)
            {
                string number = dataSource.Rows[0][0].ToString();
                if (number != "" && number.Length > 14)
                {
                    number = dataSource.Rows[0][0].ToString().Substring(14, 4);
                    count = Convert.ToDecimal(number);
                }

            }
            return "YNDKFP" + DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddData")
            {
                hdNo.Text = CreateNext();
                hdNo3.Text = hdNo3.Text == "" ? CreateNext2() : hdNo3.Text;
                string idno = base.Request.QueryString["id"] == null ? hdNo2.Text : base.Request.QueryString["id"].ToString();
                Response.Redirect("hetong33Add.aspx?id=" + idno + "&idno=" + hdNo.Text + "&idno3=" + hdNo3.Text, false);

            }
            else if (e.CommandName == "DisableData")
            {
                //GetDetail();

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblcol30")).Text);
                string rowIDs1 = Convert.ToString(((Label)row.FindControl("lblcol4")).Text);
                string rowIDs2 = Convert.ToString(((Label)row.FindControl("lblcol5")).Text);

                string sql = string.Empty;

                sql = "delete from t_hetong33 where col4 = '" + rowIDs1 + "' and col5 = '" + rowIDs2 + "'   ";
                Sql.SqlQuery(sql);

                string rows = rowIDs;

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView1.Rows[i].FindControl("lblcol30")).Text.ToString();
                    if (rows != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }

                ViewState["GridDataSource"] = dtnew;
                this.GridView1.DataSource = dtnew;
                this.GridView1.DataBind();

                if (GridView1.Rows.Count == 0)
                {
                    dt = new DataTable("column");
                    DataRow dr2;
                   
                    dt.Columns.Add("col1");
                    dt.Columns.Add("col2");
                    dt.Columns.Add("col3");
                    dt.Columns.Add("col4");
                    dt.Columns.Add("col5");

                    dr2 = dt.NewRow();
                    dt.Rows.Add(dr2);
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    ViewState["GridDataSource"] = dt;
                }

            }
        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox电子版合同.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox电子版合同.Text = "";
                电子版合同href.HRef = "";
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox合同扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox合同扫描件.Text = "";
                合同扫描件href.HRef = "";
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox合同其他附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox合同其他附件.Text = "";
                合同其他附件href.HRef = "";
            }
        }


    }
}