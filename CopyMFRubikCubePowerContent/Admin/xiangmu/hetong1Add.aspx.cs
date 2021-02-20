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
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class hetong1Add : System.Web.UI.Page
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
                getDrop地州市();
                getDrop所属项目部();
                getDrop所属项目部2();
                getDrop所属项目部3();
                getDrop所属项目部4();
                getDrop所属项目部5();
                getDrop所属项目部6();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_hetong where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        txt合同名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox专业.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        Dropdown地州市.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox建设单位.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox施工单位.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox项目经理电话.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox建设单位联系人.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox建设单位联系电话.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox合同签订日期.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox合同开工日期.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox合同完工日期.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                       
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox总工期.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox电子版合同.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox合同扫描件.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox合同其他附件.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col22"].ToString();

                        Drop所属项目部2.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        Drop所属项目部3.Text = ds.Tables[0].Rows[0]["col26"].ToString();

                        Drop所属项目部4.Text = ds.Tables[0].Rows[0]["col31"].ToString();
                        Drop所属项目部5.Text = ds.Tables[0].Rows[0]["col34"].ToString();
                        Drop所属项目部6.Text = ds.Tables[0].Rows[0]["col37"].ToString();

                        getDrop所属项目经理();
                        getDrop所属项目经理2();
                        getDrop所属项目经理3();
                        getDrop所属项目经理4();
                        getDrop所属项目经理5();
                        getDrop所属项目经理6();

                        Drop项目经理2.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox项目经理电话2.Text = ds.Tables[0].Rows[0]["col25"].ToString();

                        Drop项目经理3.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox项目经理电话3.Text = ds.Tables[0].Rows[0]["col28"].ToString();

                        Drop项目经理4.Text = ds.Tables[0].Rows[0]["col32"].ToString();
                        TextBox项目经理电话4.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        Drop项目经理5.Text = ds.Tables[0].Rows[0]["col35"].ToString();
                        TextBox项目经理电话5.Text = ds.Tables[0].Rows[0]["col36"].ToString();
                        Drop项目经理6.Text = ds.Tables[0].Rows[0]["col38"].ToString();
                        TextBox项目经理电话6.Text = ds.Tables[0].Rows[0]["col39"].ToString();

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

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong11' and col1='" + id + "' ");
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

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong12' and col1='" + id + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong13' and col1='" + id + "' ");
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

                    }

                }

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {

                    txt合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                    TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox专业.Attributes.Add("readOnly", "readOnly");
                    Dropdown地州市.Enabled = false;
                    TextBox建设单位.Attributes.Add("readOnly", "readOnly");
                    TextBox施工单位.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    TextBox项目经理电话.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部2.Enabled = false;
                    Drop项目经理2.Enabled = false;
                    TextBox项目经理电话2.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部3.Enabled = false;
                    Drop项目经理3.Enabled = false;
                    TextBox项目经理电话3.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部4.Enabled = false;
                    Drop项目经理4.Enabled = false;
                    TextBox项目经理电话4.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部5.Enabled = false;
                    Drop项目经理5.Enabled = false;
                    TextBox项目经理电话5.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部6.Enabled = false;
                    Drop项目经理6.Enabled = false;
                    TextBox项目经理电话6.Attributes.Add("readOnly", "readOnly");

                    TextBox建设单位联系人.Attributes.Add("readOnly", "readOnly");
                    TextBox建设单位联系电话.Attributes.Add("readOnly", "readOnly");
                    TextBox合同签订日期.Attributes.Add("readOnly", "readOnly");
                    TextBox合同开工日期.Attributes.Add("readOnly", "readOnly");
                    TextBox合同完工日期.Attributes.Add("readOnly", "readOnly");
                    TextBox总工期.Attributes.Add("readOnly", "readOnly");
                    TextBox创建人.Attributes.Add("readOnly", "readOnly");
                    TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                    TextBox电子版合同.Attributes.Add("readOnly", "readOnly");
                    TextBox合同扫描件.Attributes.Add("readOnly", "readOnly");
                    TextBox合同其他附件.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");

                    Button5.Visible = false;
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;
                    FileUpload3.Visible = false;
                    Button6.Visible = false;
                    Button4.Visible = false;
                    Button3.Visible = false;
                    span建设单位.Visible = false;
                    span施工单位.Visible = false;
                    TextBox建设单位.Width = 400;
                    TextBox施工单位.Width = 400;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
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

        protected void getDrop地州市()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("pinming");
                DataRow dr;

                sql = "select pinming  from tb_pinzhong where 1=1     ";
                //sql = "select pinming  from tb_pinzhong  where UserName = '" + this.Session["UserName"] + "'     ";
                dataSource = oledbHelper.GetDataTable(sql);
                //string[] strxiangmu;
                //if (dataSource.Rows.Count > 0)
                //{
                //    strxiangmu = dataSource.Rows[0]["pinming"].ToString().Split(',');
                //    for (int k = 0; k < strxiangmu.Length; k++)
                //    {
                //        if (strxiangmu[k].ToString().Trim() == "")
                //        {
                //            continue;
                //        }
                //        dr = dt.NewRow();
                //        dr["pinming"] = strxiangmu[k];
                //        dt.Rows.Add(dr);
                //    }

                //}

                Dropdown地州市.DataTextField = "pinming";
                Dropdown地州市.DataValueField = "pinming";
                Dropdown地州市.DataSource = dataSource;
                Dropdown地州市.DataBind();
                Dropdown地州市.Items.Insert(0, "");
            }
            catch
            {

            }
            

        }


        protected void getDrop所属项目部()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("xiangmu");
                DataRow dr;

                //sql = "select ID,guige  from tb_guige where 1=1     ";
                sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
                dataSource = oledbHelper.GetDataTable(sql);
                string[] strxiangmu;
                if (dataSource.Rows.Count > 0)
                {
                    strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                    for (int k = 0; k < strxiangmu.Length; k++)
                    {
                        if (strxiangmu[k].ToString().Trim() == "")
                        {
                            continue;
                        }
                        dr = dt.NewRow();
                        dr["xiangmu"] = strxiangmu[k];
                        dt.Rows.Add(dr);
                    }

                }

                Drop所属项目部.DataTextField = "xiangmu";
                Drop所属项目部.DataValueField = "xiangmu";
                Drop所属项目部.DataSource = dt;
                Drop所属项目部.DataBind();
                Drop所属项目部.Items.Insert(0, "");
            }
            catch
            {

            }
            

        }

        protected void getDrop所属项目经理()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部.Text + "'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理.DataTextField = "col2";
                Drop项目经理.DataValueField = "col2";
                Drop项目经理.DataSource = dataSource;
                Drop项目经理.DataBind();
                Drop项目经理.Items.Insert(0, "");
            }
            catch
            { 
            
            }
            

        }

        protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drop所属项目部.Text != "")
                {
                    getDrop所属项目经理();
                }
                else
                {
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = string.Empty;
                    DataTable dataSource = new DataTable();
                    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                    dataSource = oledbHelper.GetDataTable(sql);
                    Drop项目经理.DataTextField = "col2";
                    Drop项目经理.DataValueField = "col2";
                    Drop项目经理.DataSource = dataSource;
                    Drop项目经理.DataBind();
                    Drop项目经理.Items.Insert(0, "");
                }
            }
            catch
            {

            }

            
        }

        protected void getDrop所属项目部2()
        {
            try
            {

            }
            catch
            { 
            
            }
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("xiangmu");
            DataRow dr;

            //sql = "select ID,guige  from tb_guige where 1=1     ";
            sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
            dataSource = oledbHelper.GetDataTable(sql);
            string[] strxiangmu;
            if (dataSource.Rows.Count > 0)
            {
                strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                for (int k = 0; k < strxiangmu.Length; k++)
                {
                    if (strxiangmu[k].ToString().Trim() == "")
                    {
                        continue;
                    }
                    dr = dt.NewRow();
                    dr["xiangmu"] = strxiangmu[k];
                    dt.Rows.Add(dr);
                }

            }

            Drop所属项目部2.DataTextField = "xiangmu";
            Drop所属项目部2.DataValueField = "xiangmu";
            Drop所属项目部2.DataSource = dt;
            Drop所属项目部2.DataBind();
            Drop所属项目部2.Items.Insert(0, "");

        }

        protected void getDrop所属项目经理2()
        {
            try
            {

            }
            catch
            {

            }
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部2.Text + "'    ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop项目经理2.DataTextField = "col2";
            Drop项目经理2.DataValueField = "col2";
            Drop项目经理2.DataSource = dataSource;
            Drop项目经理2.DataBind();
            Drop项目经理2.Items.Insert(0, "");

        }

        protected void Drop所属项目部2SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
            if (Drop所属项目部2.Text != "")
            {
                getDrop所属项目经理2();
            }
            else
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理2.DataTextField = "col2";
                Drop项目经理2.DataValueField = "col2";
                Drop项目经理2.DataSource = dataSource;
                Drop项目经理2.DataBind();
                Drop项目经理2.Items.Insert(0, "");
            }
        }

        protected void getDrop所属项目部3()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("xiangmu");
                DataRow dr;

                //sql = "select ID,guige  from tb_guige where 1=1     ";
                sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
                dataSource = oledbHelper.GetDataTable(sql);
                string[] strxiangmu;
                if (dataSource.Rows.Count > 0)
                {
                    strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                    for (int k = 0; k < strxiangmu.Length; k++)
                    {
                        if (strxiangmu[k].ToString().Trim() == "")
                        {
                            continue;
                        }
                        dr = dt.NewRow();
                        dr["xiangmu"] = strxiangmu[k];
                        dt.Rows.Add(dr);
                    }

                }

                Drop所属项目部3.DataTextField = "xiangmu";
                Drop所属项目部3.DataValueField = "xiangmu";
                Drop所属项目部3.DataSource = dt;
                Drop所属项目部3.DataBind();
                Drop所属项目部3.Items.Insert(0, "");
            }
            catch
            {

            }
            

        }

        protected void getDrop所属项目经理3()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部3.Text + "'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理3.DataTextField = "col2";
                Drop项目经理3.DataValueField = "col2";
                Drop项目经理3.DataSource = dataSource;
                Drop项目经理3.DataBind();
                Drop项目经理3.Items.Insert(0, "");
            }
            catch
            {

            }
            

        }

        protected void Drop所属项目部3SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drop所属项目部3.Text != "")
                {
                    getDrop所属项目经理3();
                }
                else
                {
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = string.Empty;
                    DataTable dataSource = new DataTable();
                    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                    dataSource = oledbHelper.GetDataTable(sql);
                    Drop项目经理3.DataTextField = "col2";
                    Drop项目经理3.DataValueField = "col2";
                    Drop项目经理3.DataSource = dataSource;
                    Drop项目经理3.DataBind();
                    Drop项目经理3.Items.Insert(0, "");
                }
            }
            catch
            {

            }
            
        }

        protected void getDrop所属项目部4()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("xiangmu");
                DataRow dr;

                //sql = "select ID,guige  from tb_guige where 1=1     ";
                sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
                dataSource = oledbHelper.GetDataTable(sql);
                string[] strxiangmu;
                if (dataSource.Rows.Count > 0)
                {
                    strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                    for (int k = 0; k < strxiangmu.Length; k++)
                    {
                        if (strxiangmu[k].ToString().Trim() == "")
                        {
                            continue;
                        }
                        dr = dt.NewRow();
                        dr["xiangmu"] = strxiangmu[k];
                        dt.Rows.Add(dr);
                    }

                }

                Drop所属项目部4.DataTextField = "xiangmu";
                Drop所属项目部4.DataValueField = "xiangmu";
                Drop所属项目部4.DataSource = dt;
                Drop所属项目部4.DataBind();
                Drop所属项目部4.Items.Insert(0, "");
            }
            catch
            {

            }


        }

        protected void getDrop所属项目经理4()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部4.Text + "'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理4.DataTextField = "col2";
                Drop项目经理4.DataValueField = "col2";
                Drop项目经理4.DataSource = dataSource;
                Drop项目经理4.DataBind();
                Drop项目经理4.Items.Insert(0, "");
            }
            catch
            {

            }


        }

        protected void Drop所属项目部4SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drop所属项目部4.Text != "")
                {
                    getDrop所属项目经理4();
                }
                else
                {
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = string.Empty;
                    DataTable dataSource = new DataTable();
                    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                    dataSource = oledbHelper.GetDataTable(sql);
                    Drop项目经理4.DataTextField = "col2";
                    Drop项目经理4.DataValueField = "col2";
                    Drop项目经理4.DataSource = dataSource;
                    Drop项目经理4.DataBind();
                    Drop项目经理4.Items.Insert(0, "");
                }
            }
            catch
            {

            }

        }

        protected void getDrop所属项目部5()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("xiangmu");
                DataRow dr;

                //sql = "select ID,guige  from tb_guige where 1=1     ";
                sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
                dataSource = oledbHelper.GetDataTable(sql);
                string[] strxiangmu;
                if (dataSource.Rows.Count > 0)
                {
                    strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                    for (int k = 0; k < strxiangmu.Length; k++)
                    {
                        if (strxiangmu[k].ToString().Trim() == "")
                        {
                            continue;
                        }
                        dr = dt.NewRow();
                        dr["xiangmu"] = strxiangmu[k];
                        dt.Rows.Add(dr);
                    }

                }

                Drop所属项目部5.DataTextField = "xiangmu";
                Drop所属项目部5.DataValueField = "xiangmu";
                Drop所属项目部5.DataSource = dt;
                Drop所属项目部5.DataBind();
                Drop所属项目部5.Items.Insert(0, "");
            }
            catch
            {

            }


        }

        protected void getDrop所属项目经理5()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部5.Text + "'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理5.DataTextField = "col2";
                Drop项目经理5.DataValueField = "col2";
                Drop项目经理5.DataSource = dataSource;
                Drop项目经理5.DataBind();
                Drop项目经理5.Items.Insert(0, "");
            }
            catch
            {

            }


        }

        protected void Drop所属项目部5SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drop所属项目部5.Text != "")
                {
                    getDrop所属项目经理5();
                }
                else
                {
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = string.Empty;
                    DataTable dataSource = new DataTable();
                    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                    dataSource = oledbHelper.GetDataTable(sql);
                    Drop项目经理5.DataTextField = "col2";
                    Drop项目经理5.DataValueField = "col2";
                    Drop项目经理5.DataSource = dataSource;
                    Drop项目经理5.DataBind();
                    Drop项目经理5.Items.Insert(0, "");
                }
            }
            catch
            {

            }

        }

        protected void getDrop所属项目部6()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("xiangmu");
                DataRow dr;

                //sql = "select ID,guige  from tb_guige where 1=1     ";
                sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
                dataSource = oledbHelper.GetDataTable(sql);
                string[] strxiangmu;
                if (dataSource.Rows.Count > 0)
                {
                    strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                    for (int k = 0; k < strxiangmu.Length; k++)
                    {
                        if (strxiangmu[k].ToString().Trim() == "")
                        {
                            continue;
                        }
                        dr = dt.NewRow();
                        dr["xiangmu"] = strxiangmu[k];
                        dt.Rows.Add(dr);
                    }

                }

                Drop所属项目部6.DataTextField = "xiangmu";
                Drop所属项目部6.DataValueField = "xiangmu";
                Drop所属项目部6.DataSource = dt;
                Drop所属项目部6.DataBind();
                Drop所属项目部6.Items.Insert(0, "");
            }
            catch
            {

            }


        }

        protected void getDrop所属项目经理6()
        {
            try
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部6.Text + "'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理6.DataTextField = "col2";
                Drop项目经理6.DataValueField = "col2";
                Drop项目经理6.DataSource = dataSource;
                Drop项目经理6.DataBind();
                Drop项目经理6.Items.Insert(0, "");
            }
            catch
            {

            }


        }

        protected void Drop所属项目部6SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drop所属项目部6.Text != "")
                {
                    getDrop所属项目经理6();
                }
                else
                {
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = string.Empty;
                    DataTable dataSource = new DataTable();
                    sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                    dataSource = oledbHelper.GetDataTable(sql);
                    Drop项目经理6.DataTextField = "col2";
                    Drop项目经理6.DataValueField = "col2";
                    Drop项目经理6.DataSource = dataSource;
                    Drop项目经理6.DataBind();
                    Drop项目经理6.Items.Insert(0, "");
                }
            }
            catch
            {

            }

        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox合同编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同编号");
                return;
            }
            if (this.TextBox合同金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同金额");
                return;
            }
            if (this.TextBox专业.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写专业");
                return;
            }
            if (this.Dropdown地州市.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写地州市");
                return;
            }
            if (this.TextBox建设单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写建设单位");
                return;
            }
            if (this.TextBox施工单位.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工单位");
                return;
            }
            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写实施项目部");
                return;
            }
            if (this.Drop项目经理.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理");
                return;
            }
            if (this.TextBox项目经理电话.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理电话");
                return;
            }
            if (this.TextBox合同签订日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同签订日期");
                return;
            }
            if (this.TextBox合同开工日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同开工日期");
                return;
            }
            if (this.TextBox合同完工日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同完工日期");
                return;
            }

            //if (this.TextBox合同扫描件.Text.Trim() == "")
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同扫描件");
            //    return;
            //}
            //if (this.GridView1.Rows.Count == 0)
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写投标文件");
            //    return;
            //}
            if (this.GridView2.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传合同扫描件");
                return;
            }
            //if (this.GridView3.Rows.Count == 0)
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写招标文件");
            //    return;
            //}

            hetong1List hetong1List = new hetong1List();
            hetong1List.col1 = txt合同名称.Text.Trim();
            hetong1List.col2 = TextBox合同编号.Text.Trim();
            hetong1List.col3 = TextBox合同金额.Text.Trim();
            hetong1List.col4 = TextBox专业.Text.Trim();
            hetong1List.col5 = Dropdown地州市.Text.Trim();
            hetong1List.col6 = TextBox建设单位.Text.Trim();
            hetong1List.col7 = TextBox施工单位.Text.Trim();
            hetong1List.col8 = Drop所属项目部.SelectedItem.Text.Trim();
            hetong1List.col9 = Drop项目经理.Text.Trim();
            hetong1List.col10 = TextBox项目经理电话.Text.Trim();
            hetong1List.col11 = TextBox建设单位联系人.Text.Trim();
            hetong1List.col12 = TextBox建设单位联系电话.Text.Trim();
            hetong1List.col13 = TextBox合同签订日期.Text.Trim();
            hetong1List.col14 = TextBox合同开工日期.Text.Trim();
            hetong1List.col15 = TextBox合同完工日期.Text.Trim();
            hetong1List.col16 = TextBox创建人.Text.Trim();
            hetong1List.col17 = TextBox创建日期.Text.Trim();
            hetong1List.col18 = TextBox总工期.Text.Trim();
            if (this.GridView1.Rows.Count == 0)
            {
                hetong1List.col19 = "0";
            }
            else
            {
                hetong1List.col19 = "1";
            }
            //hetong1List.col19 = TextBox电子版合同.Text.Trim();
            //hetong1List.col20 = TextBox合同扫描件.Text.Trim();
            //hetong1List.col20 = "1";
            if (this.GridView2.Rows.Count == 0)
            {
                hetong1List.col20 = "0";
            }
            else
            {
                hetong1List.col20 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                hetong1List.col21 = "0";
            }
            else
            {
                hetong1List.col21 = "1";
            }
            //hetong1List.col21 = TextBox合同其他附件.Text.Trim();
            hetong1List.col22 = TextBox备注.Text.Trim();

            hetong1List.col23 = Drop所属项目部2.Text.Trim();
            hetong1List.col24 = Drop项目经理2.Text.Trim();
            hetong1List.col25 = TextBox项目经理电话2.Text.Trim();
            hetong1List.col26 = Drop所属项目部3.Text.Trim();
            hetong1List.col27 = Drop项目经理3.Text.Trim();
            hetong1List.col28 = TextBox项目经理电话3.Text.Trim();

            hetong1List.col31 = Drop所属项目部4.Text.Trim();
            hetong1List.col32 = Drop项目经理4.Text.Trim();
            hetong1List.col33 = TextBox项目经理电话4.Text.Trim();
            hetong1List.col34 = Drop所属项目部5.Text.Trim();
            hetong1List.col35 = Drop项目经理5.Text.Trim();
            hetong1List.col36 = TextBox项目经理电话5.Text.Trim();
            hetong1List.col37 = Drop所属项目部6.Text.Trim();
            hetong1List.col38 = Drop项目经理6.Text.Trim();
            hetong1List.col39 = TextBox项目经理电话6.Text.Trim();

            int ssID = 0;
            if (this.ViewState["ID"] != null)
            {
                hetong1List.ID = int.Parse(this.ViewState["ID"].ToString());
                hetong1List.UpdateData(hetong1List.ID);
                ssID = hetong1List.ID;
            }
            else
            {
                hetong1List.GetAllData2(hetong1List.col1, hetong1List.col2, hetong1List.col3);
                if (hetong1List.ID > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已存在合同名称，合同编号一样的数据，请修改再保存。");
                    return;
                }

                ssID = hetong1List.InsertData();
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

            base.Response.Redirect("hetong1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("hetong1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
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


        protected void FileUpload电子版合同Button_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = "E:/项目管理系统/Admin/xiangmu/公司证件UploadFile/" + aaa;

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(filePath + fileName);

                电子版合同href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox电子版合同.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong11";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong11' and col2='" + 附件List.col2 + "' ");
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
                附件List.flag = "hetong12";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong12' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload合同其他附件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {
               
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                //string filePath = "E:/项目管理系统/Admin/xiangmu/公司证件UploadFile/" + aaa;
                string filePath = HttpContext.Current.Request.MapPath("~/") + aaa;

                var FileStream = FileUpload3.PostedFile.InputStream;
                //string filePath2 = System.AppDomain.CurrentDomain.BaseDirectory("公司证件UploadFile/");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

 
                string fileName = FileUpload3.PostedFile.FileName;
                string fileName2 = FileUpload3.FileName;

                SaveFile(filePath + fileName, FileStream);
                //FileUpload3.SaveAs(filePath + fileName);

                合同其他附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox合同其他附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "hetong13";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hetong13' and col2='" + 附件List.col2 + "' ");
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


        private bool SaveFile(string fileFullPath, Stream fs)
        {
            var fileSaveSuccess = false;

            // create a write stream
            FileStream writeStream = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write);

            // write to the stream
            try
            {
                ReadWriteStream(fs, writeStream);

                fileSaveSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileSaveSuccess;
        }

        public void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            // readStream is the stream you need to read
            // writeStream is the stream you want to write to

            readStream.Seek(0, SeekOrigin.Begin);

            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
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