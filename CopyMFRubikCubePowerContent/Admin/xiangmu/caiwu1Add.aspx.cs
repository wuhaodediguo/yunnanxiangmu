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
    public partial class caiwu1Add : System.Web.UI.Page
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
            hd用户.Text = this.Session["FullName"].ToString();
            hd合同类型.Text = "1";
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop所属项目部();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                Drop使用状态.Enabled = false;
                //TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                //TextBox合同有效期限.Attributes.Add("readOnly", "readOnly");

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu1 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        hdxiangmuid.Value = ds.Tables[0].Rows[0]["col30"].ToString();
                        Loadxiangmu_Click(sender, e);
                        //this.Drop所属项目部.Items.FindByText(ds.Tables[0].Rows[0]["col1"].ToString()).Selected = true;
                        //Drop所属项目部.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        getDrop所属项目经理();
                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox纳税人名称.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox纳税人识别号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox跨区域经营地址.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox经营方式.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox合同名称.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox合同有效期限.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox合同相对方名称.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox合同相对方纳税人识别号.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox跨区域涉税事项报验管理编号.Text = ds.Tables[0].Rows[0]["col12"].ToString();

                        Dropdown开具渠道.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox开具时间.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox到期时间.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox经办人1.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox延期时间.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox延长到期时间.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox经办人2.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox核销时间.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox核销税务局.Text = ds.Tables[0].Rows[0]["col21"].ToString();
                        TextBox经办人3.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        Drop使用状态.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox外经证扫描件.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox延期后外经证扫描件.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox核销反馈表扫描件.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        Drop纳税人属性.Text = ds.Tables[0].Rows[0]["col31"].ToString();

                        //if (TextBox外经证扫描件.Text != "")
                        //{
                        //    外经证扫描件href.HRef = TextBox外经证扫描件.Text;
                        //    外经证扫描件href.Visible = true;
                        //    var temp = TextBox外经证扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            外经证扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
                        //}
                        ////if (TextBox延期后外经证扫描件.Text != "")
                        ////{
                        ////    延期后外经证扫描件href.HRef = TextBox延期后外经证扫描件.Text;
                        ////    延期后外经证扫描件href.Visible = true;
                        ////}
                        //if (TextBox核销反馈表扫描件.Text != "")
                        //{
                        //    核销反馈表扫描件href.HRef = TextBox核销反馈表扫描件.Text;
                        //    核销反馈表扫描件href.Visible = true;
                        //    var temp = TextBox核销反馈表扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            核销反馈表扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton2.Visible = true;
                        //}



                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu11' and col1='" + id + "' ");
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

                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu12' and col1='" + id + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu13' and col1='" + id + "' ");
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

                    string model = base.Request.QueryString["model"];
                    if (model == "view")
                    {
                        Drop所属项目部.Enabled = false;
                        Drop项目经理.Enabled = false;
                        TextBox纳税人名称.Attributes.Add("readOnly", "readOnly");
                        TextBox纳税人识别号.Attributes.Add("readOnly", "readOnly");
                        TextBox跨区域经营地址.Attributes.Add("readOnly", "readOnly");
                        TextBox经营方式.Attributes.Add("readOnly", "readOnly");
                        TextBox合同名称.Attributes.Add("readOnly", "readOnly");
                        TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                        TextBox合同有效期限.Attributes.Add("readOnly", "readOnly");
                        TextBox合同相对方名称.Attributes.Add("readOnly", "readOnly");
                        TextBox合同相对方纳税人识别号.Attributes.Add("readOnly", "readOnly");
                        TextBox跨区域涉税事项报验管理编号.Attributes.Add("readOnly", "readOnly");

                        Dropdown开具渠道.Enabled = false;
                        TextBox开具时间.Attributes.Add("readOnly", "readOnly");
                        TextBox到期时间.Attributes.Add("readOnly", "readOnly");
                        TextBox经办人1.Attributes.Add("readOnly", "readOnly");
                        TextBox延期时间.Attributes.Add("readOnly", "readOnly");
                        TextBox延长到期时间.Attributes.Add("readOnly", "readOnly");
                        TextBox经办人2.Attributes.Add("readOnly", "readOnly");
                        TextBox核销时间.Attributes.Add("readOnly", "readOnly");
                        TextBox核销税务局.Attributes.Add("readOnly", "readOnly");
                        TextBox经办人3.Attributes.Add("readOnly", "readOnly");
                        Drop使用状态.Attributes.Add("readOnly", "readOnly");
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                        TextBox外经证扫描件.Attributes.Add("readOnly", "readOnly");
                        TextBox延期后外经证扫描件.Attributes.Add("readOnly", "readOnly");
                        TextBox核销反馈表扫描件.Attributes.Add("readOnly", "readOnly");
                        TextBox备注.Attributes.Add("readOnly", "readOnly");

                        FileUpload1.Visible = false;
                        FileUpload2.Visible = false;
                        FileUpload3.Visible = false;
                        Button4.Enabled = false;
                        Button5.Enabled = false;
                        Button6.Enabled = false;
                        span合同名称.Visible = false;
                        span纳税人名称.Visible = false;
                        TextBox纳税人名称.Width = 255;
                        TextBox合同名称.Width = 955;
                        btnAttach.Visible = false;
                        LinkButton1.Visible = false;
                        LinkButton2.Visible = false;
                        //GridView1.Enabled = false;

                    }

                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    外经证扫描件href.Visible = false;

                    核销反馈表扫描件href.Visible = false;
                    btnAttach.Visible = false;
                   
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
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部.SelectedValue + "'    ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop项目经理.DataTextField = "col2";
            Drop项目经理.DataValueField = "col2";
            Drop项目经理.DataSource = dataSource;
            Drop项目经理.DataBind();
            Drop项目经理.Items.Insert(0, "");
            //if (Drop所属项目部.Text != "")
            //{
            //    TextBox项目经理.Text = Drop所属项目部.SelectedValue;
            //    //getDrop所属项目经理();
            //}
            //else
            //{
            //    TextBox项目经理.Text = "";

            //}
        }

        protected void Loadxiangmu_Click(object sender, EventArgs e)
        {

            #region Step
            //Get
            var tickedid = hdxiangmuid.Value.Trim(); // 若該列有被選取，取出被選的單號
            if (tickedid == "")
            {
                return;
            }
            //DataSet ds = Sql.SqlQueryDS("select * from t_hetong where id=" + tickedid + "");
            //if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    //TextBox合同金额.Text = ds.Tables[0].Rows[0]["col3"].ToString();
            //    //TextBox合同有效期限.Text = ds.Tables[0].Rows[0]["col15"].ToString();

            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("xiangmu");
            //    dt.Columns.Add("xiangmu2");
            //    DataRow dr;
            //    if (ds.Tables[0].Rows[0]["col8"].ToString() != "")
            //    {
            //        dr = dt.NewRow();
            //        dr["xiangmu"] = ds.Tables[0].Rows[0]["col8"].ToString();
            //        dr["xiangmu2"] = ds.Tables[0].Rows[0]["col9"].ToString();
            //        dt.Rows.Add(dr);
            //    }
            //    if (ds.Tables[0].Rows[0]["col23"].ToString() != "")
            //    {
            //        dr = dt.NewRow();
            //        dr["xiangmu"] = ds.Tables[0].Rows[0]["col23"].ToString();
            //        dr["xiangmu2"] = ds.Tables[0].Rows[0]["col24"].ToString();
            //        dt.Rows.Add(dr);
            //    }
            //    if (ds.Tables[0].Rows[0]["col26"].ToString() != "")
            //    {
            //        dr = dt.NewRow();
            //        dr["xiangmu"] = ds.Tables[0].Rows[0]["col26"].ToString();
            //        dr["xiangmu2"] = ds.Tables[0].Rows[0]["col27"].ToString();
            //        dt.Rows.Add(dr);
            //    }
            //    Drop所属项目部.DataTextField = "xiangmu";
            //    Drop所属项目部.DataValueField = "xiangmu2";
            //    Drop所属项目部.DataSource = dt;
            //    Drop所属项目部.DataBind();
            //    Drop所属项目部.Items.Insert(0, "");

            //}


            #endregion
        }

        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写所属项目部");
                return;
            }
            if (this.Drop项目经理.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理");
                return;
            }
            if (this.Drop纳税人属性.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写纳税人属性");
                return;
            }
            if (this.TextBox纳税人名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写纳税人名称");
                return;
            }
            if (this.TextBox纳税人识别号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写纳税人识别号");
                return;
            }
            if (this.TextBox跨区域经营地址.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写跨区域经营地址");
                return;
            }
            if (this.TextBox经营方式.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写经营方式");
                return;
            }
            if (this.TextBox合同金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同金额");
                return;
            }
            if (this.TextBox合同有效期限.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同有效期限");
                return;
            }
            if (this.Dropdown开具渠道.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开具渠道");
                return;
            }
            if (this.TextBox开具时间.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开具时间");
                return;
            }
            if (this.TextBox到期时间.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写到期时间");
                return;
            }
            if (this.TextBox经办人1.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写经办人");
                return;
            }
            if (this.TextBox延期时间.Text.Trim() != "")
            {
                if (this.TextBox延长到期时间.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写延长到期时间");
                    return;
                }
                //if (this.TextBox延期后外经证扫描件.Text.Trim() == "")
                //{
                //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写延期后外经证扫描件");
                //    return;
                //}
                if (this.GridView1.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写延期后外经证扫描件");
                    return;
                }
            }

            if (this.TextBox外经证扫描件.Text.Trim() == "")
			{
				this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写外经证扫描件");
                return;
			}

			if (this.TextBox核销时间.Text.Trim() != "")
			{
				if (this.TextBox核销反馈表扫描件.Text.Trim() == "")
				{
					this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写核销反馈表扫描件");
					return;
				}
			}
            

            caiwu1List caiwu1List = new caiwu1List();
            caiwu1List.col1 = Drop所属项目部.Text.Trim();
            caiwu1List.col2 = Drop项目经理.Text.Trim();
            caiwu1List.col3 = TextBox纳税人名称.Text.Trim();
            caiwu1List.col4 = TextBox纳税人识别号.Text.Trim();
            caiwu1List.col5 = TextBox跨区域经营地址.Text.Trim();
            caiwu1List.col6 = TextBox经营方式.Text.Trim();
            caiwu1List.col7 = TextBox合同名称.Text.Trim();
            caiwu1List.col8 = TextBox合同金额.Text.Trim();
            caiwu1List.col9 = TextBox合同有效期限.Text.Trim();
            caiwu1List.col10 = TextBox合同相对方名称.Text.Trim();
            caiwu1List.col11 = TextBox合同相对方纳税人识别号.Text.Trim();
            caiwu1List.col12 = TextBox跨区域涉税事项报验管理编号.Text.Trim();
            caiwu1List.col13 = Dropdown开具渠道.Text.Trim();
            caiwu1List.col14 = TextBox开具时间.Text.Trim();
            caiwu1List.col15 = TextBox到期时间.Text.Trim();
            caiwu1List.col16 = TextBox经办人1.Text.Trim();
            caiwu1List.col17 = TextBox延期时间.Text.Trim();
            caiwu1List.col18 = TextBox延长到期时间.Text.Trim();
            caiwu1List.col19 = TextBox经办人2.Text.Trim();
            caiwu1List.col20 = TextBox核销时间.Text.Trim();
            caiwu1List.col21 = TextBox核销税务局.Text.Trim();
            caiwu1List.col22 = TextBox经办人3.Text.Trim();
            caiwu1List.col23 = Drop使用状态.Text.Trim();
            caiwu1List.col24 = TextBox创建人.Text.Trim();
            caiwu1List.col25 = TextBox创建日期.Text.Trim();
            //caiwu1List.col26 = TextBox外经证扫描件.Text.Trim();

            if (this.GridView1.Rows.Count == 0)
            {
                caiwu1List.col26 = "0";
            }
            else
            {
                caiwu1List.col26 = "1";
            }
            caiwu1List.col27 = "1";
            if (this.GridView1.Rows.Count == 0)
            {
                caiwu1List.col28 = "0";
            }
            else
            {
                caiwu1List.col28 = "1";
            }
            //caiwu1List.col27 = TextBox延期后外经证扫描件.Text.Trim();
            //caiwu1List.col28 = TextBox核销反馈表扫描件.Text.Trim();
            caiwu1List.col29 = TextBox备注.Text.Trim();
            caiwu1List.col30 = hdxiangmuid.Value.Trim();
            caiwu1List.col31 = Drop纳税人属性.Text.Trim();
            caiwu1List.col32 = "0";

            string strlblcol15 = caiwu1List.col15.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
            if (strlblcol15 == "")
            {
            }
            else
            {
                string strlblcol17 = caiwu1List.col17.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (strlblcol17 == "")
                {
                    if (DateTime.Compare(Convert.ToDateTime(strlblcol15), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) <= 0 && DateTime.Compare(Convert.ToDateTime(strlblcol15), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) >= 0)
                    {
                        caiwu1List.col32 = "1";
                        caiwu1List.col23 = "即将到期";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strlblcol15), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        caiwu1List.col32 = "1";
                        caiwu1List.col23 = "已经过期";
                    }
                    else
                    {
                        caiwu1List.col23 = "正常";
                    }
                }
                else
                {
                    caiwu1List.col23 = "已经延期";
                    string strlblcol18 = caiwu1List.col18.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                    if (strlblcol18 != "")
                    {
                        if (DateTime.Compare(Convert.ToDateTime(strlblcol18), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) <= 0)
                        {
                            caiwu1List.col32 = "1";
                            caiwu1List.col23 = "即将到期";
                        }
                    }

                }

            }

            string strlblcol20 = caiwu1List.col20.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
            if (strlblcol20 == "")
            {
            }
            else
            {
                caiwu1List.col23 = "已经核销";
            }


            int ssID = 0;
            if (this.ViewState["ID"] != null)
            {
                caiwu1List.ID = int.Parse(this.ViewState["ID"].ToString());
                caiwu1List.UpdateData(caiwu1List.ID);
                ssID = caiwu1List.ID;
            }
            else
            {
               ssID = caiwu1List.InsertData();
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

            base.Response.Redirect("caiwu1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("caiwu1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload外经证扫描件Button_Click(object sender, EventArgs e)
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

                外经证扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox外经证扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu11";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu11' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload延期后外经证扫描件Button_Click(object sender, EventArgs e)
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

                延期后外经证扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox延期后外经证扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu12";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu12' and col2='" + 附件List.col2 + "' ");
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
            return  DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
        }


        protected void FileUpload核销反馈表扫描件Button_Click(object sender, EventArgs e)
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

                核销反馈表扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox核销反馈表扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu13";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu13' and col2='" + 附件List.col2 + "' ");
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

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox外经证扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox外经证扫描件.Text = "";
                外经证扫描件href.HRef = "";
                外经证扫描件href.InnerText = "";
                btnAttach.Visible = false;
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox延期后外经证扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox延期后外经证扫描件.Text = "";
                延期后外经证扫描件href.HRef = "";
            }
        }

        protected void btnAttach3_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox核销反馈表扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox核销反馈表扫描件.Text = "";
                核销反馈表扫描件href.HRef = "";
                核销反馈表扫描件href.InnerText = "";
                LinkButton2.Visible = false;
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

                DataTable dt = (DataTable)ViewState["GridDataSource"];
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

                DataTable dt = (DataTable)ViewState["GridDataSource"];
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




    }
}