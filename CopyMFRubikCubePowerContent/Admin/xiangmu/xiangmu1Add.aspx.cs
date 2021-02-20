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
    public partial class xiangmu1Add : System.Web.UI.Page
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
                //getDrop所属项目部();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                TextBox税额1.Attributes.Add("readOnly", "readOnly");
                TextBox结算金额含税.Attributes.Add("readOnly", "readOnly");
                TextBox税额2.Attributes.Add("readOnly", "readOnly");
                TextBox审定金额含税.Attributes.Add("readOnly", "readOnly");

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    txt合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                    txt合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox合同编号.Attributes.Add("readOnly", "readOnly");
                    TextBox合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox建设单位.Attributes.Add("readOnly", "readOnly");
                    TextBox施工单位.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部.Enabled = false;
                    TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                    TextBox项目名称.Attributes.Add("readOnly", "readOnly");
                    TextBox项目编码.Attributes.Add("readOnly", "readOnly");
                    TextBox单项工程名称.Attributes.Add("readOnly", "readOnly");
                    TextBox结算金额不含税.Attributes.Add("readOnly", "readOnly");
                    TextBox结算金额含税.Attributes.Add("readOnly", "readOnly");
                    TextBox审定金额不含税.Attributes.Add("readOnly", "readOnly");
                    TextBox审定金额含税.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    Drop税率1.Enabled = false;
                    Drop税率2.Enabled = false;
                    Drop结算类型.Enabled = false;
                    span合同名称.Visible = false;
                    Button3.Visible = false;
                    txt合同名称.Width = 980;
                    
                }

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
                        txt合同名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox合同编号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox合同金额.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox建设单位.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox施工单位.Text = ds.Tables[0].Rows[0]["col5"].ToString();

                        hdxiangmuid.Value = ds.Tables[0].Rows[0]["col33"].ToString();
                        Loadxiangmu_Click(sender, e);

                        //if (Drop所属项目部.Items.Contains(new ListItem(ds.Tables[0].Rows[0]["col6"].ToString().Trim())))
                        //{
                        //    Drop所属项目部.ClearSelection();
                        //    this.Drop所属项目部.Items.FindByText(ds.Tables[0].Rows[0]["col6"].ToString().Trim()).Selected = true;
                        //}
                        //this.Drop所属项目部.Items.FindByText(ds.Tables[0].Rows[0]["col6"].ToString()).Selected = true;
                        //Drop所属项目部.SelectedValue = ds.Tables[0].Rows[0]["col6"].ToString();
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox项目经理.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox项目名称.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox项目编码.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox单项工程名称.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox结算金额不含税.Text = ds.Tables[0].Rows[0]["col11"].ToString();

                        if (ds.Tables[0].Rows[0]["col12"].ToString().Trim().Contains("%"))
                        {
                            Drop税率1.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        }
                        else
                        {
                            var temp1 = ds.Tables[0].Rows[0]["col12"].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[0]["col12"].ToString().Trim();
                            Drop税率1.Text = (Convert.ToDecimal(temp1) * 100).ToString("F0") + "%";
                        }
                        //Drop税率1.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox税额1.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox结算金额含税.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox审定金额不含税.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        if (ds.Tables[0].Rows[0]["col16"].ToString().Trim().Contains("%"))
                        {
                            Drop税率2.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        }
                        else
                        {
                            var temp1 = ds.Tables[0].Rows[0]["col16"].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[0]["col16"].ToString().Trim();
                            Drop税率2.Text = (Convert.ToDecimal(temp1) * 100).ToString("F0") + "%";
                        }
                        //Drop税率2.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox税额2.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox审定金额含税.Text = ds.Tables[0].Rows[0]["col18"].ToString();

                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col21"].ToString();

                        TextBox发票扫描件.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        TextBox采购订单扫描件.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox完工结算证明扫描件.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox审计定案扫描件.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox竣工资料及图纸附件.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox到账金额.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox到账日期.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox未到账金额.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox项目状态.Text = ds.Tables[0].Rows[0]["col30"].ToString();
                        Drop结算类型.Text = ds.Tables[0].Rows[0]["col31"].ToString();

                        

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

        protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drop所属项目部.Text != "")
            {
                TextBox项目经理.Text = Drop所属项目部.SelectedValue;
                //getDrop所属项目经理();
            }
            else
            {
                TextBox项目经理.Text = "";
                //OledbHelper oledbHelper = new OledbHelper();
                //string sql = string.Empty;
                //DataTable dataSource = new DataTable();
                //sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                //dataSource = oledbHelper.GetDataTable(sql);
                //Drop项目经理.DataTextField = "col2";
                //Drop项目经理.DataValueField = "col2";
                //Drop项目经理.DataSource = dataSource;
                //Drop项目经理.DataBind();
                //Drop项目经理.Items.Insert(0, "");
            }
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
                Drop所属项目部SelectedIndexChanged(sender, e);
                //Drop所属项目部.Items.Insert(0, "");
                //this.Drop所属项目部.Items.Insert(0, new ListItem("", ""));

            }

           
            #endregion
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox项目名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目名称");
                return;
            }
            if (this.TextBox项目编码.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目编码");
                return;
            }
            if (this.TextBox单项工程名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写单项工程名称");
                return;
            }
            if (this.TextBox结算金额不含税.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写结算金额不含税");
                return;
            }

            xiangmu1List shichangList = new xiangmu1List();
            shichangList.col1 = txt合同名称.Text.Trim();
            shichangList.col2 = TextBox合同编号.Text.Trim();
            shichangList.col3 = TextBox合同金额.Text.Trim();
            shichangList.col4 = TextBox建设单位.Text.Trim();
            shichangList.col5 = TextBox施工单位.Text.Trim();
            shichangList.col6 = Drop所属项目部.SelectedItem.Text.Trim();
            shichangList.col7 = TextBox项目经理.Text.Trim();
            shichangList.col8 = TextBox项目名称.Text.Trim();
            shichangList.col9 = TextBox项目编码.Text.Trim();
            shichangList.col10 = TextBox单项工程名称.Text.Trim();
            shichangList.col11 = TextBox结算金额不含税.Text.Trim();
            shichangList.col12 = Drop税率1.Text.Trim();
            shichangList.col13 = TextBox税额1.Text.Trim();
            shichangList.col14 = TextBox结算金额含税.Text.Trim();
            shichangList.col15 = TextBox审定金额不含税.Text.Trim();
            shichangList.col16 = Drop税率2.Text.Trim();
            shichangList.col17 = TextBox税额2.Text.Trim();
            shichangList.col18 = TextBox审定金额含税.Text.Trim();
            shichangList.col19 = TextBox创建人.Text.Trim();
            shichangList.col20 = TextBox创建日期.Text.Trim();
            shichangList.col21 = TextBox备注.Text.Trim();

            shichangList.col22 = TextBox发票扫描件.Text.Trim();
            shichangList.col23 = TextBox采购订单扫描件.Text.Trim();
            shichangList.col24 = TextBox完工结算证明扫描件.Text.Trim();
            shichangList.col25 = TextBox审计定案扫描件.Text.Trim();
            shichangList.col26 = TextBox竣工资料及图纸附件.Text.Trim();

            shichangList.col27 = TextBox到账金额.Text.Trim();
            shichangList.col28 = TextBox到账日期.Text.Trim();
            shichangList.col29 = TextBox未到账金额.Text.Trim();
            shichangList.col30 = "正常";
            shichangList.col31 = Drop结算类型.Text;
            shichangList.col32 = "0";//资料未上传

            shichangList.col33 = hdxiangmuid.Value.Trim();

            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());

                shichangList.GetData(shichangList.ID);

                shichangList.col1 = txt合同名称.Text.Trim();
                shichangList.col2 = TextBox合同编号.Text.Trim();
                shichangList.col3 = TextBox合同金额.Text.Trim();
                shichangList.col4 = TextBox建设单位.Text.Trim();
                shichangList.col5 = TextBox施工单位.Text.Trim();
                shichangList.col6 = Drop所属项目部.SelectedItem.Text.Trim();
                shichangList.col7 = TextBox项目经理.Text.Trim();
                shichangList.col8 = TextBox项目名称.Text.Trim();
                shichangList.col9 = TextBox项目编码.Text.Trim();
                shichangList.col10 = TextBox单项工程名称.Text.Trim();
                shichangList.col11 = TextBox结算金额不含税.Text.Trim();
                shichangList.col12 = Drop税率1.Text.Trim();
                shichangList.col13 = TextBox税额1.Text.Trim();
                shichangList.col14 = TextBox结算金额含税.Text.Trim();
                shichangList.col15 = TextBox审定金额不含税.Text.Trim();
                shichangList.col16 = Drop税率2.Text.Trim();
                shichangList.col17 = TextBox税额2.Text.Trim();
                shichangList.col18 = TextBox审定金额含税.Text.Trim();
                shichangList.col21 = TextBox备注.Text.Trim();

                shichangList.col22 = TextBox发票扫描件.Text.Trim();
                shichangList.col23 = TextBox采购订单扫描件.Text.Trim();
                shichangList.col24 = TextBox完工结算证明扫描件.Text.Trim();
                shichangList.col25 = TextBox审计定案扫描件.Text.Trim();
                shichangList.col26 = TextBox竣工资料及图纸附件.Text.Trim();
                shichangList.col31 = Drop结算类型.Text;

                shichangList.UpdateData(shichangList.ID);

                //update
                caiwu22List List = new caiwu22List();

                //List.col5 = shichangList.col5;
                //List.col8 = shichangList.col8;
                //List.col9 = shichangList.col9;

                List.col47 = shichangList.col31;

                List.col1 = shichangList.col1;
                List.col2 = shichangList.col2;
                List.col3 = shichangList.col3;
                List.col4 = shichangList.col4;
                List.col5 = shichangList.col5;
                List.col6 = shichangList.col6;
                List.col7 = shichangList.col7;
                List.col8 = shichangList.col8;
                List.col9 = shichangList.col9;
                List.col10 = shichangList.col10;
                List.col11 = shichangList.col11;
                List.col12 = shichangList.col12;
                List.col13 = shichangList.col13;
                List.col14 = shichangList.col14;
                List.col15 = shichangList.col15;
                List.col16 = shichangList.col16;

                List.col45 = shichangList.col17;
                List.col46 = shichangList.col18;
                //List.col47 = shichangList.col31;
               

                List.col43 = shichangList.ID.ToString();

                List.UpdateData开票端();
                


            }
            else
            {
                shichangList.GetAllData2(shichangList.col8, shichangList.col9, shichangList.col5, shichangList.col31);
                if (shichangList.ID > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已存在施工单位，项目名称，项目编号，结算类型一样的数据，请修改再保存。");
                    return;
                }

                shichangList.InsertData();
            }

            base.Response.Redirect("xiangmu1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("xiangmu1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }


    }
}