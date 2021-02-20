using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using MojoCube.Api.Excel;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Web;
using MojoCube.Api.File;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class hezuo4Add : System.Web.UI.Page
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
        public static string baocunnocol45 = string.Empty;
        public decimal amounts = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            hd用户.Text = this.Session["FullName"].ToString();
            hd合同类型.Text = "1";
            TextBox创建人.Text = this.Session["FullName"].ToString();
            TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            TextBox创建人.Attributes.Add("readOnly", "readOnly");
            TextBox创建日期.Attributes.Add("readOnly", "readOnly");
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop所属项目部();
                string idno = string.Empty;
                string id = string.Empty;
                

                if (base.Request.QueryString["idno"] != null)
                {
                    id = base.Request.QueryString["id"].ToString();
                    idno = base.Request.QueryString["idno"].ToString();
                    if (idno == "")
                    {
                        idno = "000000";
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();


                    DataSet ds = Sql.SqlQueryDS("select * from t_hezuo4 where col22 = " + idno + " ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        this.Drop所属项目部.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        getDrop所属项目经理();
                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox施工队长姓名.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox施工年份.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox项目名称.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox项目编码.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox单项工程名称.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col10"].ToString();

                        TextBox施工队单项工程结算电子档附件.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox施工队单项工程结算签字扫描附件.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox施工队合同扫描件.Text = ds.Tables[0].Rows[0]["col19"].ToString();

                        TextBox8.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox22.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        this.TextBox合同名称.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        this.TextBox合同编号.Text = ds.Tables[0].Rows[0]["col24"].ToString();

                        TextBox8.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        //if (TextBox施工队单项工程结算电子档附件.Text != "")
                        //{
                        //    施工队单项工程结算电子档附件href.HRef = TextBox施工队单项工程结算电子档附件.Text;
                        //    施工队单项工程结算电子档附件href.Visible = true;
                        //    var temp = TextBox施工队单项工程结算电子档附件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            施工队单项工程结算电子档附件href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
                        //}

                        //if (TextBox施工队单项工程结算签字扫描附件.Text != "")
                        //{
                        //    施工队单项工程结算签字扫描附件href.HRef = TextBox施工队单项工程结算签字扫描附件.Text;
                        //    施工队单项工程结算签字扫描附件href.Visible = true;
                        //    var temp = TextBox施工队单项工程结算签字扫描附件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            施工队单项工程结算签字扫描附件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}

                        //if (TextBox施工队合同扫描件.Text != "")
                        //{
                        //    施工队合同扫描件href.HRef = TextBox施工队合同扫描件.Text;
                        //    施工队合同扫描件href.Visible = true;
                        //    var temp = TextBox施工队合同扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            施工队合同扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton2.Visible = true;
                        //}
                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo41' and col1='" + id + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo42' and col1='" + id + "' ");
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

                        DataSet ds24 = Sql.SqlQueryDS("select * from t_fujian where ((flag = 'hezuo43'  and col1='" + id + "') or (flag = 'hezuo31' and col1='" + id + "')) ");
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
                        
                        ViewState["GridDataSource"] = ds.Tables[0];
                        this.GridView1.DataSource = ds.Tables[0];
                        this.GridView1.DataBind();
                    }
                    else
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;

                        dt.Columns.Add("col11");
                        dt.Columns.Add("col12");
                        dt.Columns.Add("col13");
                        dt.Columns.Add("col14");
                        dt.Columns.Add("col15");
                        dt.Columns.Add("col16");

                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }

                }
                else
                {
                    DataTable dt = new DataTable("column");
                    DataRow dr;
                    
                    dt.Columns.Add("col11");
                    dt.Columns.Add("col12");
                    dt.Columns.Add("col13");
                    dt.Columns.Add("col14");
                    dt.Columns.Add("col15");
                    dt.Columns.Add("col16");
                    
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    ViewState["GridDataSource"] = dt;
                }

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {

                    this.Drop所属项目部.Enabled = false;

                    Drop项目经理.Enabled = false;
                    TextBox施工队长姓名.Attributes.Add("readOnly", "readOnly");
                    TextBox施工年份.Attributes.Add("readOnly", "readOnly");
                    TextBox项目名称.Attributes.Add("readOnly", "readOnly");
                    TextBox项目编码.Attributes.Add("readOnly", "readOnly");
                    TextBox单项工程名称.Attributes.Add("readOnly", "readOnly");


                    FileUpload3.Visible = false;
                    FileUpload1.Visible = false;
                    FileUpload2.Visible = false;
                    Button1.Enabled = false;
                    Button8.Enabled = false;
                    Button9.Enabled = false;

                    Button4.Visible = false;
                    Button3.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    btnDownloadTemplate.Visible = false;
                    divUpload.Visible = false;
                    Button2.Visible = false;
                    span施工队长姓名.Visible = false;
                    TextBox施工队长姓名.Width = 380;
                    span项目名称.Visible = false;
                    TextBox项目名称.Width = 950;
                    span1.Visible = false;
                    TextBox合同名称.Width = 950;
                    GridView1.Enabled = false;

                }


            }
            else
            {
                this.AlertDiv.InnerHtml = "";
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    施工队单项工程结算电子档附件href.Visible = false;
                    施工队单项工程结算签字扫描附件href.Visible = false;
                    施工队合同扫描件href.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                }
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
                    if (dataSource.Rows[18]["col2"].ToString() == "1" && dataSource.Rows[18]["col1"].ToString() == "div0051")
                    {
                        dd0051.Visible = true;
                    }
                    else
                    {
                        dd0051.Visible = false;
                    }
                    if (dataSource.Rows[19]["col2"].ToString() == "1" && dataSource.Rows[19]["col1"].ToString() == "div0052")
                    {
                        dd0052.Visible = true;
                    }
                    else
                    {
                        dd0052.Visible = false;
                    }
                    if (dataSource.Rows[20]["col2"].ToString() == "1" && dataSource.Rows[20]["col1"].ToString() == "div0053")
                    {
                        dd0053.Visible = true;
                    }
                    else
                    {
                        dd0053.Visible = false;
                    }
                    if (dataSource.Rows[21]["col2"].ToString() == "1" && dataSource.Rows[21]["col1"].ToString() == "div0054")
                    {
                        dd0054.Visible = true;
                    }
                    else
                    {
                        dd0054.Visible = false;
                    }
                    if (dataSource.Rows[22]["col2"].ToString() == "1" && dataSource.Rows[22]["col1"].ToString() == "div0055")
                    {
                        this.dd0055.Visible = true;
                    }
                    else
                    {
                        this.dd0055.Visible = false;
                    }

                }

            }
            else
            {
                div0051.Visible = false;
                div0052.Visible = false;
                div0053.Visible = false;
                div0054.Visible = false;
                div0055.Visible = false;
            }
        }

        protected void getDrop所属项目部()
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

        protected void getDrop所属项目经理()
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

        protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
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



        private void GetDetail()
        {
            string Message = string.Empty;

            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("col11");
            dtnew.Columns.Add("col12");
            dtnew.Columns.Add("col13");
            dtnew.Columns.Add("col14");
            dtnew.Columns.Add("col15");
            dtnew.Columns.Add("col16");
            
            DataRow dr;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim() == "" )
                {
                    continue;
                }
                dr = dtnew.NewRow();
                dr["col11"] = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
                dr["col12"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString();
                dr["col13"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString();
                dr["col14"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString();
                dr["col15"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString();

                string str1 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim();
                string str2 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim();

                dr["col16"] = Convert.ToDecimal(str1) * Convert.ToDecimal(str2);
               
                dtnew.Rows.Add(dr);
            }

            ViewState["GridDataSource"] = dtnew;

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                ((Label)e.Row.FindControl("lblcol16")).Text =((Label)e.Row.FindControl("lblcol16")).Text == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol16")).Text.ToString()).ToString("F2");
                amounts += ((Label)e.Row.FindControl("lblcol16")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol16")).Text.Trim());
                txtAmount.Text = amounts.ToString();
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[7].Text = "<span align='center' style='font-weight:bold;'>合计（元）</span>";
                e.Row.Cells[8].Text = "<span align='center'  style='font-weight:bold;'>" + amounts.ToString("F2") + "</span>";

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddData")
            {
                GetDetail();

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                int i = dt.Rows.Count;
                DataRow dr;
                dr = dt.NewRow();
                dr["col11"] = i + 1;
                dr["col12"] = "";
                dr["col13"] = "";
                dr["col14"] = "";
                dr["col15"] = "";
                dr["col16"] = "";

                dt.Rows.Add(dr);

                ViewState["GridDataSource"] = dt;
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
            }
            else if (e.CommandName == "DisableData")
            {

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblcol11")).Text);
                
                string sql = string.Empty;

               
                string rows = rowIDs;

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
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
                    dt.Columns.Add("col11");
                    dt.Columns.Add("col12");
                    dt.Columns.Add("col13");
                    dt.Columns.Add("col14");
                    dt.Columns.Add("col15");
                    dt.Columns.Add("col16");
                    
                    dr2 = dt.NewRow();
                    dt.Rows.Add(dr2);
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    ViewState["GridDataSource"] = dt;
                }

            }
        }

        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
           
            sql = "select max(col22) as col22 from t_hezuo4 where 1=1  ";
            dataSource = oledbHelper.GetDataTable(sql);
            if (dataSource.Rows.Count > 0)
            {
                string number = dataSource.Rows[0][0].ToString().Trim() == "" ? "0" : dataSource.Rows[0][0].ToString().Trim();
                count = Convert.ToDecimal(number);

            }
            return (++count).ToString("00000000");
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

        protected void Loadxiangmu_Click(object sender, EventArgs e)
        {

            #region Step
            //Get
            var tickedid = TextBox8.Text.Trim(); // 若該列有被選取，取出被選的單號
            if (tickedid == "")
            {
                return;
            }
            DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where ((flag = 'hezuo31' and col1='" + TextBox8.Text.Trim() + "')) ");
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



            #endregion
        }

        protected void btn保存_Click(object sender, EventArgs e)
        {

            string ID = string.Empty;

            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目部");
                return;
            }
            if (this.Drop项目经理.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理");
                return;
            }
            if (this.TextBox施工年份.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写施工年份");
                return;
            }
            if (this.TextBox项目名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目名称");
                return;
            }
            if (this.TextBox单项工程名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写单项工程名称");
                return;
            }

            if (GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "指示要有一条明细");
                return;
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
 
                string str2 = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.Trim();
                string str3 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.Trim();
                string str4 = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.Trim();
                string str5 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.Trim();
                string str6 = ((Label)GridView1.Rows[i].FindControl("lblcol16")).Text.Trim();

                if (str2 == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "明细施工结算项目不能为空");
                    return;
                }
                if (str3 == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "明细数量不能为空");
                    return;
                }
                if (str4 == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "明细单位不能为空");
                    return;
                }
                if (str5 == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "明细单价不能为空");
                    return;
                }
                //if (str6 == "")
                //{
                //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "明细小计不能为空");
                //    return;
                //}
            }

            TextBox22.Text = TextBox22.Text == "" ? CreateNext() : TextBox22.Text;
            hezuo4List List = new hezuo4List();

            List.DeleteData(int.Parse(TextBox22.Text));
            if (GridView1.Rows.Count == 0)
            {
                List.col1 = Drop所属项目部.Text.Trim();
                List.col2 = Drop项目经理.Text.Trim();
                List.col3 = TextBox施工队长姓名.Text.Trim();
                List.col4 = TextBox施工年份.Text.Trim();
                List.col5 = TextBox项目名称.Text.Trim();
                List.col6 = TextBox项目编码.Text.Trim();
                List.col7 = TextBox单项工程名称.Text.Trim();
                List.col8 = TextBox8.Text.Trim();
                List.col9 = txtAmount.Text.ToString();
                List.col10 = "";

                List.col11 = "";
                List.col12 = "";
                List.col13 = "";
                List.col14 = "";
                List.col15 = "";
                List.col16 = "";
                List.col17 = TextBox施工队单项工程结算电子档附件.Text.Trim();
                List.col18 = TextBox施工队单项工程结算签字扫描附件.Text.Trim();
                List.col19 = TextBox施工队合同扫描件.Text.Trim();
                List.col20 = TextBox创建人.Text;
                List.col21 = TextBox创建日期.Text;
                List.col22 = int.Parse(TextBox22.Text);
                List.col23 = this.TextBox合同名称.Text;
                List.col24 = this.TextBox合同编号.Text;
                List.col25 = this.TextBox8.Text;

                ID = List.InsertData().ToString();
                //if (this.ViewState["IDNO"] != null)
                //{
                //    string id = this.ViewState["IDNO"].ToString();
                //    if (id == "")
                //    {
                //        List.InsertData();
                //    }
                //    else
                //    {
                //        List.ID = int.Parse(id);
                //        List.UpdateData(List.ID);
                //    }

                //}
                //else
                //{
                //    List.InsertData();
                //}
            }
            else
            {

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    List.col1 = Drop所属项目部.Text.Trim();
                    List.col2 = Drop项目经理.Text.Trim();
                    List.col3 = TextBox施工队长姓名.Text.Trim();
                    List.col4 = TextBox施工年份.Text.Trim();
                    List.col5 = TextBox项目名称.Text.Trim();
                    List.col6 = TextBox项目编码.Text.Trim();
                    List.col7 = TextBox单项工程名称.Text.Trim();
                    List.col8 = TextBox8.Text.Trim();
                    List.col9 = txtAmount.Text.ToString();
                    List.col10 = TextBox备注.Text.ToString();

                    List.col11 = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.Trim();
                    List.col12 = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.Trim();
                    List.col13 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.Trim();
                    List.col14 = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.Trim();
                    List.col15 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.Trim();

                    string str1 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim();
                    string str2 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim();

                    List.col16 = (Convert.ToDecimal(str1) * Convert.ToDecimal(str2)).ToString().Trim();

                    if (this.GridView2.Rows.Count == 0)
                    {
                        List.col17 = "0";
                    }
                    else
                    {
                        List.col17 = "1";
                    }
                    if (this.GridView3.Rows.Count == 0)
                    {
                        List.col18 = "0";
                    }
                    else
                    {
                        List.col18 = "1";
                    }
                    if (this.GridView4.Rows.Count == 0)
                    {
                        List.col19 = "0";
                    }
                    else
                    {
                        List.col19 = "1";
                    }
                    //List.col17 = TextBox施工队单项工程结算电子档附件.Text.Trim();
                    //List.col18 = TextBox施工队单项工程结算签字扫描附件.Text.Trim();
                    //List.col19 = TextBox施工队合同扫描件.Text.Trim();
                    List.col20 = TextBox创建人.Text;
                    List.col21 = TextBox创建日期.Text;
                    List.col22 = int.Parse(TextBox22.Text);
                    List.col23 = this.TextBox合同名称.Text;
                    List.col24 = this.TextBox合同编号.Text;
                    List.col25 = this.TextBox8.Text;

                    ID = List.InsertData().ToString();
                   
                    //if (this.ViewState["IDNO"] != null)
                    //{
                    //    string id = this.ViewState["IDNO"].ToString();
                    //    if (id == "")
                    //    {
                    //        List.InsertData();
                    //    }
                    //    else
                    //    {
                    //        List.col22 = int.Parse(id);
                    //        List.UpdateData(List.col22);
                    //    }

                    //}
                    //else
                    //{
                    //    List.InsertData();
                    //}
                }
            }
            
            hezuo3List List2 = new hezuo3List();
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            decimal aomunts = 0;
            sql = "select * from t_hezuo4 where col8 = '" + TextBox8.Text.Trim() + "' ";
            DataTable dataSource = oledbHelper.GetDataTable(sql);
            if (dataSource.Rows.Count > 0)
            { 
                for (int k = 0; k < dataSource.Rows.Count; k++)
                {
                    aomunts += dataSource.Rows[k]["col16"].ToString() == "" ? 0 : Convert.ToDecimal(dataSource.Rows[k]["col16"].ToString());
                }
            
            }
            List2.col7 = aomunts.ToString();
            List2.UpdateData2(int.Parse(TextBox8.Text.Trim()));


            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string ID11 = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
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
                string lblcol1 = ((Label)GridView4.Rows[i].FindControl("lblcol1")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ID.ToString();
                附件List.flag = "hezuo43";
                if (lblcol1 != "hezuo31")
                {
                    附件List.UpdateData(int.Parse(ID11));
                }
                
            }

            base.Response.Redirect("hezuo4.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");

        }

       
        protected void btn返回_Click(object sender, EventArgs e)
        {

            base.Response.Redirect("hezuo4.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload施工队单项工程结算电子档附件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(filePath + fileName);

                施工队单项工程结算电子档附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox施工队单项工程结算电子档附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        施工队单项工程结算电子档附件href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo41";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext3() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo41' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload施工队单项工程结算签字扫描附件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload2.PostedFile.FileName;
                FileUpload2.SaveAs(filePath + fileName);

                施工队单项工程结算签字扫描附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox施工队单项工程结算签字扫描附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        施工队单项工程结算签字扫描附件href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo42";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext3() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'hezuo42' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload施工队合同扫描件Button_Click(object sender, EventArgs e)
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

                施工队合同扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox施工队合同扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        施工队合同扫描件href.InnerText = temps2;
                //    }

                //}
                附件List 附件List = new 附件List();
                附件List.flag = "hezuo43";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件4.Value == "" ? CreateNext3() : HdCol2附件4.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where ((flag = 'hezuo43' and col2='" + 附件List.col2 + "') or (flag = 'hezuo31' and col1='" + TextBox8.Text.Trim() + "')) ");
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

        //protected void btn导入_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("shangchuan4.aspx?id=" + "hezuo4" + "", false);

        //}

        protected void btn导出_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "施工队结算明细" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";

            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A5");
            downloadTable.Columns.Add("A6");
            downloadTable.Columns.Add("A7");
            downloadTable.Columns.Add("A8");
            downloadTable.Columns.Add("A9");
            //downloadTable.Columns.Add("A10");
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");

            DataRow dr;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = Drop所属项目部.Text.Trim();
                dr["A2"] = Drop项目经理.Text.Trim();
                dr["A3"] = TextBox施工队长姓名.Text.Trim();
                dr["A4"] = TextBox施工年份.Text.Trim();
                dr["A5"] = TextBox项目名称.Text.Trim();
                dr["A6"] = TextBox项目编码.Text.Trim();
                dr["A7"] = TextBox单项工程名称.Text.Trim();
                dr["A8"] = TextBox8.Text.Trim();
                dr["A9"] = txtAmount.Text.ToString();

                dr["A11"] = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
                dr["A12"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString();
                dr["A13"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString();
                dr["A14"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString();
                dr["A15"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString();
                string str1 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim();
                string str2 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim();

                dr["A16"] = Convert.ToDecimal(str1) * Convert.ToDecimal(str2);
                dr["A17"] = TextBox施工队单项工程结算电子档附件.Text.Trim();
                dr["A18"] = TextBox施工队单项工程结算签字扫描附件.Text.Trim();
                dr["A19"] = TextBox施工队合同扫描件.Text.Trim();
                dr["A20"] = TextBox创建人.Text;
                dr["A21"] = TextBox创建日期.Text;
                
                
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/施工队结算明细下载模板.xlsx", downloadTable, str);
        }

        protected void btn导入_Click(object sender, EventArgs e)
        {

            try
            {

                if (checkFile(fuPortrait.PostedFile))
                {
                    ExcelHelper exh = new ExcelHelper();
                    DataTable dt = exh.ExcelToDataTable(this.fuPortrait.PostedFile.InputStream, "", true, fuPortrait.PostedFile.FileName);
                    //验证数据

                    if (dt == null)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "文件没有数据");
                        return;
                    }

                    List<hezuo4List> hezuo4List = checkUploadData4(dt);

                    StringBuilder errorMsg = new StringBuilder();
                    foreach (hezuo4List item in hezuo4List)
                    {
                        if (!string.IsNullOrEmpty(item.CheckUploadResult))
                            errorMsg.Append(item.CheckUploadResult);
                    }


                    if (string.IsNullOrEmpty(errorMsg.ToString()))
                    {
                        StringBuilder errorBillNo = new StringBuilder();
                        

                        GetDetail();

                        DataTable dt2 = (DataTable)ViewState["GridDataSource"];
                        int i = dt2.Rows.Count;
                        DataRow dr;
                        foreach (hezuo4List item in hezuo4List)
                        {

                            dr = dt2.NewRow();
                            dr["col11"] = i + 1;
                            dr["col12"] = item.col12;
                            dr["col13"] = item.col13;
                            dr["col14"] = item.col14;
                            dr["col15"] = item.col15;
                            dr["col16"] = item.col16;

                            dt2.Rows.Add(dr);

                        }


                        ViewState["GridDataSource"] = dt2;
                        this.GridView1.DataSource = dt2;
                        this.GridView1.DataBind();

                        if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下施工结算项目：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                        else
                        {
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");

                        }


                    }
                    else
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());

                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择导入文件和正确文件格式");
                }
            }
            catch (Exception ex)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", ex.ToString());
            }
        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }

        protected List<hezuo4List> checkUploadData4(DataTable dt)
        {
            List<hezuo4List> hezuo4List = new List<hezuo4List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hezuo4List list = new hezuo4List();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[1].ColumnName);
                else
                    list.col12 = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[2].ColumnName);
                else
                    list.col13 = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[3].ColumnName);
                else
                    list.col14 = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[4].ColumnName);
                else
                    list.col15 = dt.Rows[i][4].ToString();
               
                list.col16 = dt.Rows[i][5].ToString();
                


                hezuo4List.Add(list);
            }
            return hezuo4List;
        }

        protected void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string filename = "/Admin/DownLoadTemplates/施工队结算明细导入模板.xlsx";
            DownloadTemplateFile downloadTemplateFile = new DownloadTemplateFile();
            downloadTemplateFile.DoFileDownload(filename);
        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox施工队单项工程结算电子档附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox施工队单项工程结算电子档附件.Text = "";
                施工队单项工程结算电子档附件href.HRef = "";
                施工队单项工程结算电子档附件href.InnerText = "";
                btnAttach.Visible = false;
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox施工队单项工程结算签字扫描附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox施工队单项工程结算签字扫描附件.Text = "";
                施工队单项工程结算签字扫描附件href.HRef = "";
                施工队单项工程结算签字扫描附件href.InnerText = "";
                LinkButton1.Visible = false;
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox施工队合同扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox施工队合同扫描件.Text = "";
                施工队合同扫描件href.HRef = "";
                施工队合同扫描件href.InnerText = "";
                LinkButton2.Visible = false;
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
                        ((HyperLink)e.Row.FindControl("HyperLink1")).Attributes.Add("style", "word-break :break-all ; word-wrap:break-word");
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




    }
}