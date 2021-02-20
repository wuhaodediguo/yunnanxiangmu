using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.IO;
using System.Data;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class hetong2Add : System.Web.UI.Page
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
            hd用户.Text = this.Session["FullName"].ToString();
            hd合同类型.Text = "1";
            if (!base.IsPostBack)
            {
                quanxian();
                //getDrop所属项目部();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                TextBox专业.Attributes.Add("readOnly", "readOnly");
                TextBox地州市.Attributes.Add("readOnly", "readOnly");
                TextBox建设单位.Attributes.Add("readOnly", "readOnly");
                TextBox施工单位.Attributes.Add("readOnly", "readOnly");
                TextBox合同签订日期.Attributes.Add("readOnly", "readOnly");
                //Drop所属项目部.Enabled = false;
                TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                TextBox项目经理电话.Attributes.Add("readOnly", "readOnly");
                //Drop所属项目部2.Enabled = false;
                TextBox项目经理2.Attributes.Add("readOnly", "readOnly");
                TextBox项目经理电话2.Attributes.Add("readOnly", "readOnly");
                //Drop所属项目部3.Enabled = false;
                TextBox项目经理3.Attributes.Add("readOnly", "readOnly");
                TextBox项目经理电话3.Attributes.Add("readOnly", "readOnly");

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_hetong2 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        txt合同名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox专业.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox地州市.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox建设单位.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox施工单位.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox合同签订日期.Text = ds.Tables[0].Rows[0]["col8"].ToString();

                        hdxiangmuid.Value = ds.Tables[0].Rows[0]["col40"].ToString();
                        Loadxiangmu_Click(sender, e);

                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox项目经理电话.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        Drop所属项目部2.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox项目经理2.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox项目经理电话2.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        Drop所属项目部3.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox项目经理3.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox项目经理电话3.Text = ds.Tables[0].Rows[0]["col17"].ToString();

                        TextBox分包合同名称.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox分包合同结算依据.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox分包单位.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox分包合同金额.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        TextBox分包合同签订日期.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        TextBox分包合同结算比例.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox分包合同编号.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox劳务合同名称.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox劳务合同结算依据.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox劳务单位.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox劳务合同金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox劳务合同签订日期.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox劳务合同结算比例.Text = ds.Tables[0].Rows[0]["col30"].ToString();
                        TextBox劳务合同编号.Text = ds.Tables[0].Rows[0]["col31"].ToString();
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col32"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        TextBox分包电子版合同.Text = ds.Tables[0].Rows[0]["col34"].ToString();
                        TextBox劳务电子版合同.Text = ds.Tables[0].Rows[0]["col35"].ToString();
                        TextBox分包合同扫描件.Text = ds.Tables[0].Rows[0]["col36"].ToString();
                        TextBox劳务合同扫描件.Text = ds.Tables[0].Rows[0]["col37"].ToString();
                        TextBox合同其他附件.Text = ds.Tables[0].Rows[0]["col38"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col39"].ToString();
                       
                        //if (TextBox分包电子版合同.Text != "")
                        //{
                        //    分包电子版合同href.HRef = TextBox分包电子版合同.Text;
                        //    分包电子版合同href.Visible = true;
                        //}
                        //if (TextBox劳务电子版合同.Text != "")
                        //{
                        //    劳务电子版合同href.HRef = TextBox劳务电子版合同.Text;
                        //    劳务电子版合同href.Visible = true;
                        //}
                        //if (TextBox分包合同扫描件.Text != "")
                        //{
                        //    分包合同扫描件href.HRef = TextBox分包合同扫描件.Text;
                        //    分包合同扫描件href.Visible = true;
                        //}
                        //if (TextBox劳务合同扫描件.Text != "")
                        //{
                        //    劳务合同扫描件href.HRef = TextBox劳务合同扫描件.Text;
                        //    劳务合同扫描件href.Visible = true;
                        //}
                        //if (TextBox合同其他附件.Text != "")
                        //{
                        //    合同其他附件href.HRef = TextBox合同其他附件.Text;
                        //    合同其他附件href.Visible = true;
                        //}

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong21' and col1='" + id + "' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                            GridView1.DataSource = ds2.Tables[0];
                            GridView1.DataBind();
                            ViewState["GridDataSource"] = ds2.Tables[0];
                        }
                        else
                        {
                            HdCol2附件1.Value = "";
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong22' and col1='" + id + "' ");
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件2.Value = ds22.Tables[0].Rows[0]["col2"].ToString();
                            GridView2.DataSource = ds22.Tables[0];
                            GridView2.DataBind();
                            ViewState["GridDataSource2"] = ds22.Tables[0];
                        }
                        else
                        {
                            HdCol2附件2.Value = "";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        }

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong23' and col1='" + id + "' ");
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

                        DataSet ds24 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong24' and col1='" + id + "' ");
                        if (ds24 != null && ds24.Tables[0] != null && ds24.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件4.Value = ds24.Tables[0].Rows[0]["col2"].ToString();
                            GridView4.DataSource = ds24.Tables[0];
                            GridView4.DataBind();
                            ViewState["GridDataSource4"] = ds24.Tables[0];
                        }
                        else
                        {
                            HdCol2附件4.Value = "";
                            GridView4.DataSource = null;
                            GridView4.DataBind();
                        }

                        DataSet ds25 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong25' and col1='" + id + "' ");
                        if (ds25 != null && ds25.Tables[0] != null && ds25.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件5.Value = ds25.Tables[0].Rows[0]["col2"].ToString();
                            GridView5.DataSource = ds25.Tables[0];
                            GridView5.DataBind();
                            ViewState["GridDataSource5"] = ds25.Tables[0];
                        }
                        else
                        {
                            HdCol2附件5.Value = "";
                            GridView5.DataSource = null;
                            GridView5.DataBind();
                        }


                    }

                    string model = base.Request.QueryString["model"];
                    if (model == "view")
                    {

                        txt合同名称.Attributes.Add("readOnly", "readOnly");
                        TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                        TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                        TextBox专业.Attributes.Add("readOnly", "readOnly");
                        TextBox地州市.Attributes.Add("readOnly", "readOnly");
                        TextBox建设单位.Attributes.Add("readOnly", "readOnly");
                        TextBox施工单位.Attributes.Add("readOnly", "readOnly");
                        TextBox合同签订日期.Attributes.Add("readOnly", "readOnly");


                        Drop所属项目部.Enabled = false;
                        TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                        TextBox项目经理电话.Attributes.Add("readOnly", "readOnly");
                        Drop所属项目部2.Enabled = false;
                        TextBox项目经理2.Attributes.Add("readOnly", "readOnly");
                        TextBox项目经理电话2.Attributes.Add("readOnly", "readOnly");
                        Drop所属项目部3.Enabled = false;
                        TextBox项目经理3.Attributes.Add("readOnly", "readOnly");
                        TextBox项目经理电话3.Attributes.Add("readOnly", "readOnly");

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
                        TextBox劳务单位.Width = 400;
                        TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                        TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                        TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                        TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                        TextBox分包电子版合同.Attributes.Add("readOnly", "readOnly");
                        TextBox劳务电子版合同.Attributes.Add("readOnly", "readOnly");
                        TextBox分包合同扫描件.Attributes.Add("readOnly", "readOnly");
                        TextBox劳务合同扫描件.Attributes.Add("readOnly", "readOnly");
                        TextBox合同其他附件.Attributes.Add("readOnly", "readOnly");
                        TextBox备注.Attributes.Add("readOnly", "readOnly");
                       
                        FileUpload1.Visible = false;
                        FileUpload2.Visible = false;
                        FileUpload3.Visible = false;
                        FileUpload4.Visible = false;
                        FileUpload5.Visible = false;
                        Button5.Enabled = false;
                        Button6.Enabled = false;
                        Button4.Enabled = false;
                        Button2.Enabled = false;
                        Button1.Enabled = false;
                        Button3.Visible = false;
                        span合同名称.Visible = false;
                        txt合同名称.Width = 960;
                        span劳务单位.Visible = false;
                        span分包单位.Visible = false;
                        TextBox分包单位.Width = 400;
                        TextBox分包单位.Width = 400;
                        btnAttach.Visible = false;
                        LinkButton1.Visible = false;
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = false;
                        LinkButton4.Visible = false;

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
        protected void Loadxiangmu_Click(object sender, EventArgs e)
        {

            #region Step
            //Get
            var tickedid = hdxiangmuid.Value.Trim(); // 若該列有被選取，取出被選的單號
            if (tickedid == "")
            {
                return;
            }
            DataSet ds = Sql.SqlQueryDS("select * from t_hetong where id=" + tickedid + "");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("xiangmu");
                dt.Columns.Add("xiangmu2");
                DataRow dr;
                if (ds.Tables[0].Rows[0]["col8"].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["xiangmu"] = ds.Tables[0].Rows[0]["col8"].ToString();
                    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col9"].ToString();
                    dt.Rows.Add(dr);
                }
                if (ds.Tables[0].Rows[0]["col23"].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["xiangmu"] = ds.Tables[0].Rows[0]["col23"].ToString();
                    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col24"].ToString();
                    dt.Rows.Add(dr);
                }
                if (ds.Tables[0].Rows[0]["col26"].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["xiangmu"] = ds.Tables[0].Rows[0]["col26"].ToString();
                    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col27"].ToString();
                    dt.Rows.Add(dr);
                }
                if (ds.Tables[0].Rows[0]["col31"].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["xiangmu"] = ds.Tables[0].Rows[0]["col31"].ToString();
                    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col32"].ToString();
                    dt.Rows.Add(dr);
                }
                if (ds.Tables[0].Rows[0]["col34"].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["xiangmu"] = ds.Tables[0].Rows[0]["col34"].ToString();
                    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col35"].ToString();
                    dt.Rows.Add(dr);
                }
                if (ds.Tables[0].Rows[0]["col37"].ToString() != "")
                {
                    dr = dt.NewRow();
                    dr["xiangmu"] = ds.Tables[0].Rows[0]["col37"].ToString();
                    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col38"].ToString();
                    dt.Rows.Add(dr);
                }

                Drop所属项目部.DataTextField = "xiangmu";
                Drop所属项目部.DataValueField = "xiangmu2";
                Drop所属项目部.DataSource = dt;
                Drop所属项目部.DataBind();

                this.Drop所属项目部.Items.Insert(0, new ListItem("", ""));

                Drop所属项目部2.DataTextField = "xiangmu";
                Drop所属项目部2.DataValueField = "xiangmu2";
                Drop所属项目部2.DataSource = dt;
                Drop所属项目部2.DataBind();

                this.Drop所属项目部2.Items.Insert(0, new ListItem("", ""));

                Drop所属项目部3.DataTextField = "xiangmu";
                Drop所属项目部3.DataValueField = "xiangmu2";
                Drop所属项目部3.DataSource = dt;
                Drop所属项目部3.DataBind();
   
                this.Drop所属项目部3.Items.Insert(0, new ListItem("", ""));

                Drop所属项目部SelectedIndexChanged(sender, e);
                Drop所属项目部2SelectedIndexChanged(sender, e);
                Drop所属项目部3SelectedIndexChanged(sender, e);
                

            }


            #endregion
        }

        protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drop所属项目部.Text != "")
            {
                TextBox项目经理.Text = Drop所属项目部.SelectedValue;
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select *  from t_hetong where 1=1 and id=" + hdxiangmuid.Value.Trim() + "   ";
                dataSource = oledbHelper.GetDataTable(sql);
                if (dataSource.Rows.Count > 0)
                {
                    if (dataSource.Rows[0]["col8"].ToString() == Drop所属项目部.SelectedItem.Text.Trim() && dataSource.Rows[0]["col9"].ToString() == Drop所属项目部.SelectedValue)
                    {
                        TextBox项目经理电话.Text = dataSource.Rows[0]["col10"].ToString();
                    }
                    if (dataSource.Rows[0]["col23"].ToString() == Drop所属项目部.SelectedItem.Text.Trim() && dataSource.Rows[0]["col24"].ToString() == Drop所属项目部.SelectedValue)
                    {
                        TextBox项目经理电话.Text = dataSource.Rows[0]["col25"].ToString();
                    }
                    if (dataSource.Rows[0]["col26"].ToString() == Drop所属项目部.SelectedItem.Text.Trim() && dataSource.Rows[0]["col27"].ToString() == Drop所属项目部.SelectedValue)
                    {
                        TextBox项目经理电话.Text = dataSource.Rows[0]["col28"].ToString();
                    }
                    if (dataSource.Rows[0]["col31"].ToString() == Drop所属项目部.SelectedItem.Text.Trim() && dataSource.Rows[0]["col32"].ToString() == Drop所属项目部.SelectedValue)
                    {
                        TextBox项目经理电话.Text = dataSource.Rows[0]["col33"].ToString();
                    }
                    if (dataSource.Rows[0]["col34"].ToString() == Drop所属项目部.SelectedItem.Text.Trim() && dataSource.Rows[0]["col35"].ToString() == Drop所属项目部.SelectedValue)
                    {
                        TextBox项目经理电话.Text = dataSource.Rows[0]["col36"].ToString();
                    }
                    if (dataSource.Rows[0]["col37"].ToString() == Drop所属项目部.SelectedItem.Text.Trim() && dataSource.Rows[0]["col38"].ToString() == Drop所属项目部.SelectedValue)
                    {
                        TextBox项目经理电话.Text = dataSource.Rows[0]["col39"].ToString();
                    }
                }
            }
            else
            {
                TextBox项目经理.Text = "";
                TextBox项目经理电话.Text = "";
            }
        }

        protected void Drop所属项目部2SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drop所属项目部2.Text != "")
            {
                TextBox项目经理2.Text = Drop所属项目部2.SelectedValue;
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select *  from t_hetong where 1=1 and id=" + hdxiangmuid.Value.Trim() + "   ";
                dataSource = oledbHelper.GetDataTable(sql);
                if (dataSource.Rows.Count > 0)
                {
                    if (dataSource.Rows[0]["col8"].ToString() == Drop所属项目部2.SelectedItem.Text.Trim() && dataSource.Rows[0]["col9"].ToString() == Drop所属项目部2.SelectedValue)
                    {
                        TextBox项目经理电话2.Text = dataSource.Rows[0]["col10"].ToString();
                    }
                    if (dataSource.Rows[0]["col23"].ToString() == Drop所属项目部2.SelectedItem.Text.Trim() && dataSource.Rows[0]["col24"].ToString() == Drop所属项目部2.SelectedValue)
                    {
                        TextBox项目经理电话2.Text = dataSource.Rows[0]["col25"].ToString();
                    }
                    if (dataSource.Rows[0]["col26"].ToString() == Drop所属项目部2.SelectedItem.Text.Trim() && dataSource.Rows[0]["col27"].ToString() == Drop所属项目部2.SelectedValue)
                    {
                        TextBox项目经理电话2.Text = dataSource.Rows[0]["col28"].ToString();
                    }
                    if (dataSource.Rows[0]["col31"].ToString() == Drop所属项目部2.SelectedItem.Text.Trim() && dataSource.Rows[0]["col32"].ToString() == Drop所属项目部2.SelectedValue)
                    {
                        TextBox项目经理电话2.Text = dataSource.Rows[0]["col33"].ToString();
                    }
                    if (dataSource.Rows[0]["col34"].ToString() == Drop所属项目部2.SelectedItem.Text.Trim() && dataSource.Rows[0]["col35"].ToString() == Drop所属项目部2.SelectedValue)
                    {
                        TextBox项目经理电话2.Text = dataSource.Rows[0]["col36"].ToString();
                    }
                    if (dataSource.Rows[0]["col37"].ToString() == Drop所属项目部2.SelectedItem.Text.Trim() && dataSource.Rows[0]["col38"].ToString() == Drop所属项目部2.SelectedValue)
                    {
                        TextBox项目经理电话2.Text = dataSource.Rows[0]["col39"].ToString();
                    }
                }
            }
            else
            {
                TextBox项目经理2.Text = "";
                TextBox项目经理电话2.Text = "";
            }
        }

        protected void Drop所属项目部3SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drop所属项目部3.Text != "")
            {
                TextBox项目经理3.Text = Drop所属项目部3.SelectedValue;
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select *  from t_hetong where 1=1 and id=" + hdxiangmuid.Value.Trim() + "   ";
                dataSource = oledbHelper.GetDataTable(sql);
                if (dataSource.Rows.Count > 0)
                {
                    if (dataSource.Rows[0]["col8"].ToString() == Drop所属项目部3.SelectedItem.Text.Trim() && dataSource.Rows[0]["col9"].ToString() == Drop所属项目部3.SelectedValue)
                    {
                        TextBox项目经理电话3.Text = dataSource.Rows[0]["col10"].ToString();
                    }
                    if (dataSource.Rows[0]["col23"].ToString() == Drop所属项目部3.SelectedItem.Text.Trim() && dataSource.Rows[0]["col24"].ToString() == Drop所属项目部3.SelectedValue)
                    {
                        TextBox项目经理电话3.Text = dataSource.Rows[0]["col25"].ToString();
                    }
                    if (dataSource.Rows[0]["col26"].ToString() == Drop所属项目部3.SelectedItem.Text.Trim() && dataSource.Rows[0]["col27"].ToString() == Drop所属项目部3.SelectedValue)
                    {
                        TextBox项目经理电话3.Text = dataSource.Rows[0]["col28"].ToString();
                    }
                    if (dataSource.Rows[0]["col31"].ToString() == Drop所属项目部3.SelectedItem.Text.Trim() && dataSource.Rows[0]["col32"].ToString() == Drop所属项目部3.SelectedValue)
                    {
                        TextBox项目经理电话3.Text = dataSource.Rows[0]["col33"].ToString();
                    }
                    if (dataSource.Rows[0]["col34"].ToString() == Drop所属项目部3.SelectedItem.Text.Trim() && dataSource.Rows[0]["col35"].ToString() == Drop所属项目部3.SelectedValue)
                    {
                        TextBox项目经理电话3.Text = dataSource.Rows[0]["col36"].ToString();
                    }
                    if (dataSource.Rows[0]["col37"].ToString() == Drop所属项目部3.SelectedItem.Text.Trim() && dataSource.Rows[0]["col38"].ToString() == Drop所属项目部3.SelectedValue)
                    {
                        TextBox项目经理电话3.Text = dataSource.Rows[0]["col39"].ToString();
                    }
                }
            }
            else
            {
                TextBox项目经理3.Text = "";
                TextBox项目经理电话3.Text = "";
            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox分包合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包合同名称");
                return;
            }
            if (this.TextBox分包合同结算依据.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包合同结算依据");
                return;
            }
            if (this.TextBox分包单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包单位");
                return;
            }
            if (this.TextBox分包合同金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包合同金额");
                return;
            }
            if (this.TextBox分包合同签订日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包合同签订日期");
                return;
            }
            if (this.TextBox分包合同结算比例.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包合同结算比例");
                return;
            }
            if (this.TextBox分包合同编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包合同编号");
                return;
            }
            if (this.TextBox劳务合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务合同名称");
                return;
            }
            if (this.TextBox劳务合同结算依据.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务合同结算依据");
                return;
            }
            if (this.TextBox劳务单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务单位");
                return;
            }
            if (this.TextBox劳务合同金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务合同金额");
                return;
            }
            if (this.TextBox劳务合同签订日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务合同签订日期");
                return;
            }
            if (this.TextBox劳务合同结算比例.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务合同结算比例");
                return;
            }
            if (this.TextBox劳务合同编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务合同编号");
                return;
            }

            hetong2List shichangList = new hetong2List();
            shichangList.col1 = txt合同名称.Text.Trim();
            shichangList.col2 = TextBox合同编号.Text.Trim();
            shichangList.col3 = TextBox合同金额.Text.Trim();
            shichangList.col4 = TextBox专业.Text.Trim();
            shichangList.col5 = TextBox地州市.Text.Trim();
            shichangList.col6 = TextBox建设单位.Text.Trim();
            shichangList.col7 = TextBox施工单位.Text.Trim();
            shichangList.col8 = TextBox合同签订日期.Text.Trim();

            shichangList.col9 = Drop所属项目部.SelectedItem.Text.Trim();
            shichangList.col10 = TextBox项目经理.Text.Trim();
            shichangList.col11 = TextBox项目经理电话.Text.Trim();
            shichangList.col12 = Drop所属项目部2.Text.Trim();
            shichangList.col13 = TextBox项目经理2.Text.Trim();
            shichangList.col14 = TextBox项目经理电话2.Text.Trim();
            shichangList.col15 = Drop所属项目部3.Text.Trim();
            shichangList.col16 = TextBox项目经理2.Text.Trim();
            shichangList.col17 = TextBox项目经理电话3.Text.Trim();

            shichangList.col18 = TextBox分包合同名称.Text.Trim();
            shichangList.col19 = TextBox分包合同结算依据.Text.Trim();
            shichangList.col20 = TextBox分包单位.Text.Trim();
            shichangList.col21 = TextBox分包合同金额.Text.Trim();
            shichangList.col22 = TextBox分包合同签订日期.Text.Trim();
            shichangList.col23 = TextBox分包合同结算比例.Text.Trim();
            shichangList.col24 = TextBox分包合同编号.Text.Trim();
            shichangList.col25 = TextBox劳务合同名称.Text.Trim();
            shichangList.col26 = TextBox劳务合同结算依据.Text.Trim();
            shichangList.col27 = TextBox劳务单位.Text.Trim();
            shichangList.col28 = TextBox劳务合同金额.Text.Trim();
            shichangList.col29 = TextBox劳务合同签订日期.Text.Trim();
            shichangList.col30 = TextBox劳务合同结算比例.Text.Trim();
            shichangList.col31 = TextBox劳务合同编号.Text.Trim();
            shichangList.col32 = TextBox创建人.Text.Trim();
            shichangList.col33 = TextBox创建日期.Text.Trim();
            if (this.GridView1.Rows.Count == 0)
            {
                shichangList.col34 = "0";
            }
            else
            {
                shichangList.col34 = "1";
            }
            if (this.GridView2.Rows.Count == 0)
            {
                shichangList.col35 = "0";
            }
            else
            {
                shichangList.col35 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                shichangList.col36 = "0";
            }
            else
            {
                shichangList.col36 = "1";
            }
            if (this.GridView4.Rows.Count == 0)
            {
                shichangList.col37 = "0";
            }
            else
            {
                shichangList.col37 = "1";
            }
            if (this.GridView5.Rows.Count == 0)
            {
                shichangList.col38 = "0";
            }
            else
            {
                shichangList.col38 = "1";
            }
            //shichangList.col34 = TextBox分包电子版合同.Text.Trim();
            //shichangList.col35 = TextBox劳务电子版合同.Text.Trim();
            //shichangList.col36 = TextBox分包合同扫描件.Text.Trim();
            //shichangList.col37 = TextBox劳务合同扫描件.Text.Trim();
            //shichangList.col38 = TextBox合同其他附件.Text.Trim();
            shichangList.col39 = TextBox备注.Text.Trim();
            shichangList.col40 = hdxiangmuid.Value.Trim();

            int ssID = 0;
            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());
                shichangList.UpdateData(shichangList.ID);
                ssID = shichangList.ID;
            }
            else
            {
                //2019.7.30临时取消
                //shichangList.GetAllData2(shichangList.col1, shichangList.col2);
                //if (shichangList.ID > 0)
                //{
                //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已存在合同名称，合同编号一样的数据，请修改再保存。");
                //    return;
                //}
                ssID = shichangList.InsertData();
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

            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                string ID = ((Label)GridView4.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                string ID = ((Label)GridView5.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            base.Response.Redirect("hetong2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("hetong2.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "");
        }

        protected void FileUpload分包电子版合同Button_Click(object sender, EventArgs e)
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

                分包电子版合同href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox分包电子版合同.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong21";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong21' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView1.DataSource = ds2.Tables[0];
                    GridView1.DataBind();
                    ViewState["GridDataSource"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件1.Value = "";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }


                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload劳务电子版合同Button_Click(object sender, EventArgs e)
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

                劳务电子版合同href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox劳务电子版合同.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong22";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong22' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件2.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView2.DataSource = ds2.Tables[0];
                    GridView2.DataBind();
                    ViewState["GridDataSource2"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件2.Value = "";
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

        protected void FileUpload分包合同扫描件Button_Click(object sender, EventArgs e)
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

                分包合同扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox分包合同扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong23";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong23' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload劳务合同扫描件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload4.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload4.PostedFile.FileName;
                FileUpload4.SaveAs(filePath + fileName);

                劳务合同扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox劳务合同扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong24";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件4.Value == "" ? CreateNext() : HdCol2附件4.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong24' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload合同其他附件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload5.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload5.PostedFile.FileName;
                FileUpload5.SaveAs(filePath + fileName);

                合同其他附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox合同其他附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong25";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件5.Value == "" ? CreateNext() : HdCol2附件5.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong25' and col2='" + 附件List.col2 + "' ");
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

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox分包电子版合同.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox分包电子版合同.Text = "";
                分包电子版合同href.HRef = "";
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox劳务电子版合同.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox劳务电子版合同.Text = "";
                劳务电子版合同href.HRef = "";
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox分包合同扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox分包合同扫描件.Text = "";
                分包合同扫描件href.HRef = "";
            }
        }

        protected void btnAttach4_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox劳务合同扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox劳务合同扫描件.Text = "";
                劳务合同扫描件href.HRef = "";
            }
        }

        protected void btnAttach5_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox合同其他附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox合同其他附件.Text = "";
                合同其他附件href.HRef = "";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView1.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource"] = dtnew;
                this.GridView1.DataSource = dtnew;
                this.GridView1.DataBind();

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




    }
}