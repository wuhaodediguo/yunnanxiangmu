using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Data;
using System.Text;
using System.Collections;
using System.IO;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class caiwu6Add : System.Web.UI.Page
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
        public string models
        {
            get { return Request.Params.Get("models"); }
        }
        public string model
        {
            get { return Request.Params.Get("model"); }
        }
        public static string baocunnocol45 = string.Empty;
        public decimal amount1 = 0;
        public string tempzhuangtai = "";
        public static string txtquanxian = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            hdRoleValue.Value = "审核";
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop所属项目部();
                lblBox2.Text = "<font color='red'>*</font>" + lblBox2.Text;
                //hdNo.Text = CreateNext();
                TextBox申请人.Text = this.Session["FullName"].ToString();
                TextBox申请日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox申请人.Attributes.Add("readOnly", "readOnly");
                TextBox申请日期.Attributes.Add("readOnly", "readOnly");

                TextBox总包合同编号.Attributes.Add("readOnly", "readOnly");
                TextBox总包合同金额.Attributes.Add("readOnly", "readOnly");
                TextBox建设单位名称.Attributes.Add("readOnly", "readOnly");
                TextBox施工单位名称.Attributes.Add("readOnly", "readOnly");

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
                TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");
                string zihuamianid = string.Empty;
                string idno = string.Empty;

              
                hdidno.Value = base.Request.QueryString["idno"];
                hdid.Value = base.Request.QueryString["id"];
                string role = "";
                if (base.Request.QueryString["role"] != null)
                {
                    role = base.Request.QueryString["role"].ToString();
                    
                }
                var modals = base.Request.QueryString["modals"];
                var modal = base.Request.QueryString["modal"];
                if (role == "审核")
                {
                    //shdiv.Visible = true;
                    shenhe1div.Visible = true;
                    shenhe2div.Visible = true;
                    shdiv.Visible = true;
                    backdiv.Visible = true;
                    lbl结算Box2.Text = "结算审核管理";
                }

                if (base.Request.QueryString["model2"] == "view2")
                {
                    shdiv.Visible = true;
                }
                if (base.Request.QueryString["idno"] != null || hdNo2.Text != "")
                {

                    if (base.Request.QueryString["idno"] == null)
                    {
                        idno = hdNo2.Text;
                    }
                    else
                    {
                        idno = base.Request.QueryString["idno"].ToString();
                    }

                    if (idno == "")
                    {
                        idno = "000000";
                    }
                    this.ViewState["IDNO"] = base.Request.QueryString["idno"].ToString();


                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu5 where ID = " + idno + " ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {



                        TextBoxxiangmuid.Text = ds.Tables[0].Rows[0]["col51"].ToString();
                        hdxiangmuid.Value = ds.Tables[0].Rows[0]["col47"].ToString();
                        Loadxiangmu_Click(sender, e);
                        this.Drop所属项目部.Items.FindByText(ds.Tables[0].Rows[0]["col1"].ToString()).Selected = true;
                        getDrop所属项目经理();

                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox总包合同名称.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox总包合同编号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox总包合同金额.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox建设单位名称.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox施工单位名称.Text = ds.Tables[0].Rows[0]["col7"].ToString();

                        TextBox分包合同名称.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox分包合同结算依据.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox分包单位.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox分包合同金额.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox分包合同签订日期.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox分包合同结算比例.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox分包合同编号.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox劳务合同名称.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        TextBox劳务合同结算依据.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        TextBox劳务单位.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox劳务合同金额.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        TextBox劳务合同签订日期.Text = ds.Tables[0].Rows[0]["col19"].ToString();
                        TextBox劳务合同结算比例.Text = ds.Tables[0].Rows[0]["col20"].ToString();
                        TextBox劳务合同编号.Text = ds.Tables[0].Rows[0]["col21"].ToString();

                        TextBox总包项目名称.Text = ds.Tables[0].Rows[0]["col22"].ToString();
                        TextBox总包项目编码.Text = ds.Tables[0].Rows[0]["col23"].ToString();
                        TextBox总包发票金额.Text = ds.Tables[0].Rows[0]["col24"].ToString();
                        TextBox总包到账金额.Text = ds.Tables[0].Rows[0]["col25"].ToString();
                        TextBox分包发票金额.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox分包到账金额.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox劳务单位开票金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox申请人.Text = ds.Tables[0].Rows[0]["col29"].ToString();
                        TextBox申请日期.Text = ds.Tables[0].Rows[0]["col30"].ToString();


                        TextBox项目实施单位发票附件.Text = ds.Tables[0].Rows[0]["col41"].ToString();
                        TextBox付款凭证.Text = ds.Tables[0].Rows[0]["col42"].ToString();
                        //TextBox审批状态.Text = ds.Tables[0].Rows[0]["col43"].ToString();
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col44"].ToString();

                        TextBoxbaocunnocol45.Text = ds.Tables[0].Rows[0]["col45"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["col46"].ToString();

                        TextBox审核人.Text = ds.Tables[0].Rows[0]["col50"].ToString();
                        TextBox49.Text = ds.Tables[0].Rows[0]["col49"].ToString();
                        TextBox审批意见.Text = ds.Tables[0].Rows[0]["col52"].ToString();
                        TextBox结算依据.Text = ds.Tables[0].Rows[0]["col53"].ToString();
                        txtquanxian = ds.Tables[0].Rows[0]["col48"].ToString();
                        txtquanxian = txtquanxian == "" ? "0" : txtquanxian;


                        zhuangtaiList list2 = new zhuangtaiList();
                        string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol45.Text + "' ";
                        DataSet ds22 = Sql.SqlQueryDS(sql2);
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds22.Tables[0].Rows.Count; k++)
                            {
                                TextBox审批状态.Text += ds22.Tables[0].Rows[k]["col2"].ToString() + @"
";
                                if(k == ds22.Tables[0].Rows.Count -1)
                                {
                                    tempzhuangtai = ds22.Tables[0].Rows[k]["col2"].ToString();
                                }
                            }

                        }
                        else
                        {
                            TextBox审批状态.Text = ds.Tables[0].Rows[0]["col43"].ToString();
                        }


                        //if (TextBox项目实施单位发票附件.Text != "")
                        //{
                        //    项目实施单位发票附件href.HRef = TextBox项目实施单位发票附件.Text;
                        //    项目实施单位发票附件href.Visible = true;
                        //    var temp = TextBox项目实施单位发票附件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            项目实施单位发票附件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}
                        //if (TextBox付款凭证.Text != "")
                        //{
                        //    付款凭证href.HRef = TextBox付款凭证.Text;
                        //    付款凭证href.Visible = true;
                        //    var temp = TextBox付款凭证.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            付款凭证href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}

                        DataSet ds222 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu62' and col1='" + idno + "' ");
                        if (ds222 != null && ds222.Tables[0] != null && ds222.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件2.Value = ds222.Tables[0].Rows[0]["col2"].ToString();
                            GridView2.DataSource = ds222.Tables[0];
                            GridView2.DataBind();
                            ViewState["GridDataSource2"] = ds222.Tables[0];
                        }
                        else
                        {
                            HdCol2附件2.Value = "";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                        }

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu63' and col1='" + idno + "' ");
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

                //2019.8.22
                if (tempzhuangtai.Trim().Contains("审核通过"))
                {
                    //lbl结算Box2.Text = "结算审核管理";
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    //TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同编号.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox建设单位名称.Attributes.Add("readOnly", "readOnly");
                    TextBox施工单位名称.Attributes.Add("readOnly", "readOnly");

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
                    TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");

                    TextBox总包项目名称.Attributes.Add("readOnly", "readOnly");
                    TextBox总包项目编码.Attributes.Add("readOnly", "readOnly");
                    TextBox总包到账金额.Attributes.Add("readOnly", "readOnly");
                    TextBox总包发票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox分包发票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox分包到账金额.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务单位开票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox申请人.Attributes.Add("readOnly", "readOnly");
                    TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                    TextBox项目实施单位发票附件.Attributes.Add("readOnly", "readOnly");
                    TextBox付款凭证.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    TextBox结算依据.Attributes.Add("readOnly", "readOnly");
                    TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                    //TextBox审批意见.Attributes.Add("readOnly", "readOnly");
                    Button3.Visible = false;
                    Button7.Visible = false;
                    FileUpload1.Enabled = false;
                    Button8.Enabled = false;
                    FileUpload2.Enabled = false;
                    Button9.Enabled = false;
                    span合同名称.Visible = false;
                    TextBox总包合同名称.Width = 950;
                    span总包项目名称.Visible = false;
                    TextBox总包项目名称.Width = 950;
                    span总包发票金额.Visible = false;
                    TextBox总包发票金额.Width = 380;

                    this.GridView1.Enabled = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                }

                if (base.Request.QueryString["id"] != null)
                {
                    //GetDetail();
                    hdNo.Text = base.Request.QueryString["id"].ToString();
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        id = "000000";
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu55 where col9 = '" + id + "'");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        amount1 = 0;
                        ViewState["GridDataSource"] = ds.Tables[0];
                        this.GridView1.DataSource = ds.Tables[0];
                        this.GridView1.DataBind();

                    }
                    else
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col1");
                        dt.Columns.Add("col2");
                        dt.Columns.Add("col3");
                        dt.Columns.Add("col4");
                        dt.Columns.Add("col5");
                        dt.Columns.Add("col6");
                        dt.Columns.Add("col7");

                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        amount1 = 0;
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }
                }

                if (idno == "")
                {
                    idno = "00000";
                }

                DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu55 where col11 = '" + idno + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    amount1 = 0;
                    ViewState["GridDataSource"] = ds2.Tables[0];
                    this.GridView1.DataSource = ds2.Tables[0];
                    this.GridView1.DataBind();

                }
                else
                {
                    DataTable dttep = (DataTable)ViewState["GridDataSource"];
                    if (dttep == null)
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col1");
                        dt.Columns.Add("col2");
                        dt.Columns.Add("col3");
                        dt.Columns.Add("col4");
                        dt.Columns.Add("col5");
                        dt.Columns.Add("col6");
                        dt.Columns.Add("col7");
                       
                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        amount1 = 0;
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }
                    else
                    {
                        if (dttep.Rows.Count == 0)
                        {
                            DataTable dt = new DataTable("column");
                            DataRow dr;
                            dt.Columns.Add("col8");
                            dt.Columns.Add("col9");
                            dt.Columns.Add("col1");
                            dt.Columns.Add("col2");
                            dt.Columns.Add("col3");
                            dt.Columns.Add("col4");
                            dt.Columns.Add("col5");
                            dt.Columns.Add("col6");
                            dt.Columns.Add("col7");

                            dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            amount1 = 0;
                            this.GridView1.DataSource = dt;
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = dt;
                        }
                    }

                }

                if (role == "审核")
                {
                    lbl结算Box2.Text = "结算审核管理";
                    printdiv.Visible = true;
                    //div审批意见.Visible = true;
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    //TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同编号.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox建设单位名称.Attributes.Add("readOnly", "readOnly");
                    TextBox施工单位名称.Attributes.Add("readOnly", "readOnly");

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
                    TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");

                    TextBox总包项目名称.Attributes.Add("readOnly", "readOnly");
                    TextBox总包项目编码.Attributes.Add("readOnly", "readOnly");
                    TextBox总包到账金额.Attributes.Add("readOnly", "readOnly");
                    TextBox总包发票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox分包发票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox分包到账金额.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务单位开票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox申请人.Attributes.Add("readOnly", "readOnly");
                    TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                    TextBox项目实施单位发票附件.Attributes.Add("readOnly", "readOnly");
                    TextBox付款凭证.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    TextBox结算依据.Attributes.Add("readOnly", "readOnly");
                    TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                    
                    Button3.Visible = false;
                    Button7.Visible = false;
                    FileUpload1.Enabled = false;
                    Button8.Enabled = false;
                    FileUpload2.Enabled = false;
                    Button9.Enabled = false;
                    span合同名称.Visible = false;
                    TextBox总包合同名称.Width = 950;
                    span总包项目名称.Visible = false;
                    TextBox总包项目名称.Width = 950;
                    span总包发票金额.Visible = false;
                    TextBox总包发票金额.Width = 380;

                    this.GridView1.Enabled = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                }

                if (role == "view")
                {
                    lbl结算Box2.Text = "结算审核管理";
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    //TextBox项目经理.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同名称.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同编号.Attributes.Add("readOnly", "readOnly");
                    TextBox总包合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox建设单位名称.Attributes.Add("readOnly", "readOnly");
                    TextBox施工单位名称.Attributes.Add("readOnly", "readOnly");

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
                    TextBox劳务合同金额.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同签订日期.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同结算比例.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务合同编号.Attributes.Add("readOnly", "readOnly");

                    TextBox总包项目名称.Attributes.Add("readOnly", "readOnly");
                    TextBox总包项目编码.Attributes.Add("readOnly", "readOnly");
                    TextBox总包到账金额.Attributes.Add("readOnly", "readOnly");
                    TextBox总包发票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox分包发票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox分包到账金额.Attributes.Add("readOnly", "readOnly");
                    TextBox劳务单位开票金额.Attributes.Add("readOnly", "readOnly");
                    TextBox申请人.Attributes.Add("readOnly", "readOnly");
                    TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                    TextBox项目实施单位发票附件.Attributes.Add("readOnly", "readOnly");
                    TextBox付款凭证.Attributes.Add("readOnly", "readOnly");
                    TextBox备注.Attributes.Add("readOnly", "readOnly");
                    TextBox结算依据.Attributes.Add("readOnly", "readOnly");
                    TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                    TextBox审批意见.Attributes.Add("readOnly", "readOnly");
                    //div审批意见.Visible = true;
                    Button3.Visible = false;
                    Button7.Visible = false;
                    FileUpload1.Enabled = false;
                    Button8.Enabled = false;
                    FileUpload2.Enabled = false;
                    Button9.Enabled = false;
                    span合同名称.Visible = false;
                    TextBox总包合同名称.Width = 950;
                    span总包项目名称.Visible = false;
                    TextBox总包项目名称.Width = 950;
                    span总包发票金额.Visible = false;
                    TextBox总包发票金额.Width = 380;

                    this.GridView1.Enabled = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
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


        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col9) as col9 from t_caiwu55 where 1=1 and col10 = '" + strdate + "' ";
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

        string CreateNext2()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyy年-MM月-dd日");
            sql = "select max(col45) as col45 from t_caiwu5 where 1=1 and col30 = '" + strdate + "' ";
           
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
            return "YNDKJS" + DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
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
            DataSet ds = Sql.SqlQueryDS("select * from t_hetong2 where id=" + tickedid + "");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                //DataTable dt = new DataTable();
                //dt.Columns.Add("xiangmu");
                //dt.Columns.Add("xiangmu2");
                //DataRow dr;
                //if (ds.Tables[0].Rows[0]["col9"].ToString() != "")
                //{
                //    dr = dt.NewRow();
                //    dr["xiangmu"] = ds.Tables[0].Rows[0]["col9"].ToString();
                //    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col10"].ToString();
                //    dt.Rows.Add(dr);
                //}
                //if (ds.Tables[0].Rows[0]["col12"].ToString() != "")
                //{
                //    dr = dt.NewRow();
                //    dr["xiangmu"] = ds.Tables[0].Rows[0]["col12"].ToString();
                //    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col13"].ToString();
                //    dt.Rows.Add(dr);
                //}
                //if (ds.Tables[0].Rows[0]["col15"].ToString() != "")
                //{
                //    dr = dt.NewRow();
                //    dr["xiangmu"] = ds.Tables[0].Rows[0]["col15"].ToString();
                //    dr["xiangmu2"] = ds.Tables[0].Rows[0]["col16"].ToString();
                //    dt.Rows.Add(dr);
                //}
                //Drop所属项目部.DataTextField = "xiangmu";
                //Drop所属项目部.DataValueField = "xiangmu2";
                //Drop所属项目部.DataSource = dt;
                //Drop所属项目部.DataBind();
                //Drop所属项目部.Items.Insert(0, "");

                TextBox总包合同名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                TextBox总包合同编号.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                TextBox总包合同金额.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                TextBox建设单位名称.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                TextBox施工单位名称.Text = ds.Tables[0].Rows[0]["col7"].ToString();

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


            }


            #endregion
        }


        private void GetDetail()
        {
            string Message = string.Empty;

            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("col30");
            dtnew.Columns.Add("col31");
            dtnew.Columns.Add("col32");
            dtnew.Columns.Add("col33");
            dtnew.Columns.Add("col34");
            dtnew.Columns.Add("col35");
            dtnew.Columns.Add("col36");
            dtnew.Columns.Add("col37");
           
            DataRow dr;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                dr = dtnew.NewRow();
                dr["col30"] = ((Label)GridView1.Rows[i].FindControl("lblcol1")).Text.ToString();
                dr["col31"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol31")).Text.ToString();
                dr["col32"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol32")).Text.ToString();
                dr["col33"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol33")).Text.ToString();
                dr["col34"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol34")).Text.ToString();
                dr["col35"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol35")).Text.ToString();
                dr["col36"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol36")).Text.ToString();
                dr["col37"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol37")).Text.ToString();
                
                dtnew.Rows.Add(dr);
            }

            ViewState["GridDataSource"] = dtnew;

        }

        private void AddDetail()
        {
            GetDetail();
            DataTable dt = (DataTable)ViewState["GridDataSource"];
           
            DataRow dr;

            dr = dt.NewRow();
            dr["col30"] = CreateNext();
            dr["col31"] = "";
            dr["col32"] = "";
            dr["col33"] = "";
            dr["col34"] = "";
            dr["col35"] = "";
            dr["col36"] = "";
            dr["col37"] = "";

            dt.Rows.Add(dr);

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (base.Request.QueryString["role"] == "审核")
                {
                    GridView1.Columns[0].Visible = false;
                    GridView1.Columns[1].Visible = false;
                }
                amount1 += ((Label)e.Row.FindControl("lblcol32")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol32")).Text.Trim());

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "<span align='center' style='font-weight:bold;'>合计:</span>";
                e.Row.Cells[6].Text = "<span align='center' style='font-weight:bold;'>" + amount1 + "</span>";
               
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddData")
            {
                if (hdNo.Text == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请先点暂存按钮保存信息！");
                    return;
                }
                hdNo.Text = hdNo.Text == "" ? CreateNext() : hdNo.Text;
                string idno = base.Request.QueryString["idno"] == null ? hdNo2.Text : base.Request.QueryString["idno"].ToString();
                Response.Redirect("caiwu6Add2.aspx?id=" + hdNo.Text + "&idno=" + idno, false);
            }
            else if (e.CommandName == "DisableData")
            {
                
                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lbl支付序号")).Text);
                string rowIDs1 = Convert.ToString(((Label)row.FindControl("lblcol8")).Text);
                string rowIDs2 = Convert.ToString(((Label)row.FindControl("lblcol9")).Text);

                string sql = string.Empty;

                sql = "delete from t_caiwu55 where col8 = '" + rowIDs1 + "' and col9 = '" + rowIDs2 + "'   ";
                Sql.SqlQuery(sql);

                string rows = rowIDs;

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView1.Rows[i].FindControl("lbl支付序号")).Text.ToString();
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
                    dt.Columns.Add("col8");
                    dt.Columns.Add("col9");
                    dt.Columns.Add("col1");
                    dt.Columns.Add("col2");
                    dt.Columns.Add("col3");
                    dt.Columns.Add("col4");
                    dt.Columns.Add("col5");
                    dt.Columns.Add("col6");
                    dt.Columns.Add("col7");

                    dr2 = dt.NewRow();
                    dt.Rows.Add(dr2);
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    ViewState["GridDataSource"] = dt;
                }

            }
        }

        protected void FileUpload项目实施单位发票附件Button_Click(object sender, EventArgs e)
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

                项目实施单位发票附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox项目实施单位发票附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu62";
                附件List.col1 = this.ViewState["IDNO"] == null ? "" : this.ViewState["IDNO"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext3() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu62' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload付款凭证Button_Click(object sender, EventArgs e)
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

                付款凭证href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox付款凭证.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu63";
                附件List.col1 = this.ViewState["IDNO"] == null ? "" : this.ViewState["IDNO"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext3() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu63' and col2='" + 附件List.col2 + "' ");
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



        protected void btn暂存_Click(object sender, EventArgs e)
        {
            if (this.TextBox总包合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写总包合同名称");
                return;
            }
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
            if (this.TextBox总包项目名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写总包项目名称");
                return;
            }
            if (this.TextBox分包发票金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包发票金额");
                return;
            }
            if (this.TextBox分包到账金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写分包到账金额");
                return;
            }
            if (this.TextBox劳务单位开票金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写劳务单位开票金额");
                return;
            }

            caiwu5List List = new caiwu5List();
            TextBoxbaocunnocol45.Text = TextBoxbaocunnocol45.Text == "" ? CreateNext2() : TextBoxbaocunnocol45.Text;
            decimal amount1 = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                amount1 += Convert.ToDecimal(((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim() == "" ? "0" : ((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim());
            }

            List.col1 = Drop所属项目部.Text.Trim();
            List.col2 = Drop项目经理.Text.Trim();
            List.col3 = TextBox总包合同名称.Text.Trim();
            List.col4 = TextBox总包合同编号.Text.Trim();
            List.col5 = TextBox总包合同金额.Text.Trim();
            List.col6 = TextBox建设单位名称.Text.Trim();
            List.col7 = TextBox施工单位名称.Text.Trim();
            List.col8 = TextBox分包合同名称.Text.Trim();
            List.col9 = TextBox分包合同结算依据.Text.Trim();
            List.col10 = TextBox分包单位.Text.Trim();
            List.col11 = TextBox分包合同金额.Text.Trim();
            List.col12 = TextBox分包合同签订日期.Text.Trim();
            List.col13 = TextBox分包合同结算比例.Text.Trim();
            List.col14 = TextBox分包合同编号.Text.Trim();
            List.col15 = TextBox劳务合同名称.Text.Trim();
            List.col16 = TextBox劳务合同结算依据.Text.Trim();
            List.col17 = TextBox劳务单位.Text.Trim();
            List.col18 = TextBox劳务合同金额.Text.Trim();
            List.col19 = TextBox劳务合同签订日期.Text.Trim();
            List.col20 = TextBox劳务合同结算比例.Text.Trim();
            List.col21 = TextBox劳务合同编号.Text.Trim();

            List.col22 = TextBox总包项目名称.Text.Trim();
            List.col23 = TextBox总包项目编码.Text.Trim();
            List.col24 = TextBox总包发票金额.Text.Trim();
            List.col25 = TextBox总包到账金额.Text.Trim();
            List.col26 = TextBox分包发票金额.Text.Trim();
            List.col27 = TextBox分包到账金额.Text.Trim();
            List.col28 = TextBox劳务单位开票金额.Text.Trim();
            List.col29 = TextBox申请人.Text.Trim();
            List.col30 = TextBox申请日期.Text.Trim();

            if (this.GridView2.Rows.Count == 0)
            {
                List.col41 = "0";
            }
            else
            {
                List.col41 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                List.col42 = "0";
            }
            else
            {
                List.col42 = "1";
            }
            //List.col41 = TextBox项目实施单位发票附件.Text.Trim();
            //List.col42 = TextBox付款凭证.Text.Trim();

            //审批状态
            OledbHelper oledbHelper = new OledbHelper();
            string str审核人员 = string.Empty;
            string sql审核人员 = "select * from t_shenhe2 where 1=1 and col1 = '1' ";
            DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            if (dt审核人员.Rows.Count > 0)
            {
                str审核人员 = dt审核人员.Rows[0]["col2"].ToString();
            }
            //List.col43 = TextBox申请人.Text + " " + TextBox申请日期.Text + "申请结算," + str审核人员 + "未提交";
            List.col43 = TextBox申请人.Text + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "申请结算," + TextBox申请人.Text + "未提交";
            List.col44 = TextBox备注.Text.Trim();
            List.col49 = str审核人员;
            
            List.col31 = "";
            List.col32 = "";
            List.col33 = "";
            List.col34 = "";
            List.col35 = "";
            List.col36 = "";
            List.col37 = "";
            List.col38 = "";
            List.col39 = "";
            List.col40 = "";

            List.col45 = "";
            List.col46 = "";
            List.col48 = "";
            List.col50 = "";
            // 2019.09 .27
            List.col53 = TextBox结算依据.Text.Trim();

            List.col47 = hdxiangmuid.Value.Trim();
            List.col51 = TextBoxxiangmuid.Text.Trim();

            //List.col31 = ((TextBox)GridView1.Rows[i].FindControl("txtcol31")).Text.Trim();
            //List.col32 = ((TextBox)GridView1.Rows[i].FindControl("txtcol32")).Text.Trim();
            //List.col33 = ((TextBox)GridView1.Rows[i].FindControl("txtcol33")).Text.Trim();
            //List.col34 = ((TextBox)GridView1.Rows[i].FindControl("txtcol34")).Text.Trim();
            //List.col35 = ((TextBox)GridView1.Rows[i].FindControl("txtcol35")).Text.Trim();
            //List.col36 = ((TextBox)GridView1.Rows[i].FindControl("txtcol36")).Text.Trim();
            //List.col37 = ((TextBox)GridView1.Rows[i].FindControl("txtcol37")).Text.Trim();

            List.col45 = TextBoxbaocunnocol45.Text;
            //合计
            List.col46 = amount1.ToString();

            if (this.ViewState["IDNO"] != null || hdNo2.Text != "")
            {
                string id = this.ViewState["IDNO"] == null ? hdNo2.Text : this.ViewState["IDNO"].ToString();
                if (id == "")
                {
                    List.InsertData();
                }
                else
                {
                    List.ID = int.Parse(id);
                    List.UpdateData(List.ID);
                }

            }
            else
            {
                List.InsertData();
            }

            //
            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol45.Text + "' and col2='" + List.col43 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = TextBoxbaocunnocol45.Text;
                list2.col2 = List.col43;
                list2.col3 = "";
                list2.InsertData();
            }


            string ID = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu5 where col45 = '" + List.col45 + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ID = ds.Tables[0].Rows[0]["ID"].ToString();
                hdNo2.Text = ID;
                hdNo.Text = ID;
            }

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
            //caiwu55List caiwu55List = new caiwu55List();
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    caiwu55List.col9 = TextBoxbaocunnocol45.Text;
            //    caiwu55List.col10 = DateTime.Now.ToString("yyyyMMdd");
            //    caiwu55List.col11 = hdNo2.Text;
            //    caiwu55List.UpdateData2(((Label)GridView1.Rows[i].FindControl("lblcol8")).Text.Trim());
            //}

            
        }

        protected void btn提交_Click(object sender, EventArgs e)
        {
            if (this.TextBox总包合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写总包合同名称");
                return;
            }
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
            if (this.TextBox总包项目名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写总包项目名称");
                return;
            }
            caiwu5List List = new caiwu5List();
            TextBoxbaocunnocol45.Text = TextBoxbaocunnocol45.Text == "" ? CreateNext2() : TextBoxbaocunnocol45.Text;
            decimal amount1 = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                amount1 += Convert.ToDecimal(((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim() == "" ? "0" : ((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim());
            }

            List.col1 = Drop所属项目部.Text.Trim();
            List.col2 = Drop项目经理.Text.Trim();
            List.col3 = TextBox总包合同名称.Text.Trim();
            List.col4 = TextBox总包合同编号.Text.Trim();
            List.col5 = TextBox总包合同金额.Text.Trim();
            List.col6 = TextBox建设单位名称.Text.Trim();
            List.col7 = TextBox施工单位名称.Text.Trim();
            List.col8 = TextBox分包合同名称.Text.Trim();
            List.col9 = TextBox分包合同结算依据.Text.Trim();
            List.col10 = TextBox分包单位.Text.Trim();
            List.col11 = TextBox分包合同金额.Text.Trim();
            List.col12 = TextBox分包合同签订日期.Text.Trim();
            List.col13 = TextBox分包合同结算比例.Text.Trim();
            List.col14 = TextBox分包合同编号.Text.Trim();
            List.col15 = TextBox劳务合同名称.Text.Trim();
            List.col16 = TextBox劳务合同结算依据.Text.Trim();
            List.col17 = TextBox劳务单位.Text.Trim();
            List.col18 = TextBox劳务合同金额.Text.Trim();
            List.col19 = TextBox劳务合同签订日期.Text.Trim();
            List.col20 = TextBox劳务合同结算比例.Text.Trim();
            List.col21 = TextBox劳务合同编号.Text.Trim();

            List.col22 = TextBox总包项目名称.Text.Trim();
            List.col23 = TextBox总包项目编码.Text.Trim();
            List.col24 = TextBox总包发票金额.Text.Trim();
            List.col25 = TextBox总包到账金额.Text.Trim();
            List.col26 = TextBox分包发票金额.Text.Trim();
            List.col27 = TextBox分包到账金额.Text.Trim();
            List.col28 = TextBox劳务单位开票金额.Text.Trim();
            List.col29 = TextBox申请人.Text.Trim();
            List.col30 = TextBox申请日期.Text.Trim();

            if (this.GridView2.Rows.Count == 0)
            {
                List.col41 = "0";
            }
            else
            {
                List.col41 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                List.col42 = "0";
            }
            else
            {
                List.col42 = "1";
            }
            //List.col41 = TextBox项目实施单位发票附件.Text.Trim();
            //List.col42 = TextBox付款凭证.Text.Trim();

            //审批状态
            OledbHelper oledbHelper = new OledbHelper();
            //string str审核人员 = string.Empty;
            //string sql审核人员 = "select * from t_shenhe2 where 1=1 and col1 = '1' ";
            //DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            //if (dt审核人员.Rows.Count > 0)
            //{
            //    str审核人员 = dt审核人员.Rows[0]["col2"].ToString();
            //}
            List.col43 = TextBox申请人.Text + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "申请结算," + TextBox申请人.Text + "未提交";
            List.col44 = TextBox备注.Text.Trim();
            List.col49 = "";

            // 2019.09 .27
            List.col53 = TextBox结算依据.Text.Trim();

            List.col31 = "";
            List.col32 = "";
            List.col33 = "";
            List.col34 = "";
            List.col35 = "";
            List.col36 = "";
            List.col37 = "";
            List.col38 = "";
            List.col39 = "";
            List.col40 = "";

            List.col45 = "";
            List.col46 = "";
            List.col48 = "";
            List.col50 = "";

            List.col47 = hdxiangmuid.Value.Trim();
            List.col51 = TextBoxxiangmuid.Text.Trim();

            //List.col31 = ((TextBox)GridView1.Rows[i].FindControl("txtcol31")).Text.Trim();
            //List.col32 = ((TextBox)GridView1.Rows[i].FindControl("txtcol32")).Text.Trim();
            //List.col33 = ((TextBox)GridView1.Rows[i].FindControl("txtcol33")).Text.Trim();
            //List.col34 = ((TextBox)GridView1.Rows[i].FindControl("txtcol34")).Text.Trim();
            //List.col35 = ((TextBox)GridView1.Rows[i].FindControl("txtcol35")).Text.Trim();
            //List.col36 = ((TextBox)GridView1.Rows[i].FindControl("txtcol36")).Text.Trim();
            //List.col37 = ((TextBox)GridView1.Rows[i].FindControl("txtcol37")).Text.Trim();

            List.col45 = TextBoxbaocunnocol45.Text;
            //合计
            List.col46 = amount1.ToString();

            if (this.ViewState["IDNO"] != null || hdNo2.Text != "")
            {
                string id = this.ViewState["IDNO"] == null ? hdNo2.Text : this.ViewState["IDNO"].ToString();
                if (id == "")
                {
                    List.InsertData();
                }
                else
                {
                    List.ID = int.Parse(id);
                    List.UpdateData(List.ID);
                }

            }
            else
            {
                List.InsertData();
            }

            //
            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol45.Text + "' and col2='" + List.col43 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = TextBoxbaocunnocol45.Text;
                list2.col2 = List.col43;
                list2.col3 = "";
                list2.InsertData();
            }


            string ID = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu5 where col45 = '" + List.col45 + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ID = ds.Tables[0].Rows[0]["ID"].ToString();
                hdNo2.Text = ID;
                hdNo.Text = ID;
            }

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


            base.Response.Redirect("caiwu6.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=" + model + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            string model22 = base.Request.QueryString["model22"];
            string model3 = base.Request.QueryString["model3"];
            string models = base.Request.QueryString["models"];

            if (model22 == "shouye")
            {
                base.Response.Redirect("shouye.aspx");
            }
            if (model3 == "caiwu7")
            {
                base.Response.Redirect("caiwu7.aspx");
            }
            else
            {
                base.Response.Redirect("caiwu6.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=" + model + "&models=" + models + "");
            }
            
        }

        protected void btn审核通过_Click(object sender, EventArgs e)
        {
            string fullname = this.Session["FullName"].ToString();
            var tickedFormNo = base.Request.QueryString["idno"];
            txtquanxian = txtquanxian == "" ? "0" : txtquanxian;

            var Pdata = "<script> var  aaa ='"
                           + 2 + "';fullname ='"
                         + fullname + "';tickedFormNo ="
                         + tickedFormNo + ";txtquanxian ="
                         + txtquanxian + ";LinkPrintPage();</script>";

            ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata);//將結果傳到Cient Site.


            //zhuangtaiList list2 = new zhuangtaiList();
            //string str1 = TextBoxbaocunnocol45.Text;
            ////审批状态
            //OledbHelper oledbHelper = new OledbHelper();
            //string str审核人员 = string.Empty;
            //string str新审核人员 = string.Empty;
            //string sql审核人员 = "select * from t_shenhe2 where 1=1 and col2 = '" + this.Session["FullName"].ToString() + "' ";
            //DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            //if (dt审核人员.Rows.Count > 0)
            //{
            //    str审核人员 = dt审核人员.Rows[0]["col1"].ToString();
            //    int new审核 = int.Parse(str审核人员) + 1;
            //    sql审核人员 = "select * from t_shenhe2 where 1=1 and col1 = '" + new审核 + "' ";
            //    DataTable dt审核人员2 = oledbHelper.GetDataTable(sql审核人员);
            //    if (dt审核人员2.Rows.Count > 0)
            //    {
            //        str新审核人员 = dt审核人员2.Rows[0]["col2"].ToString();
            //    }
            //}
            //string str新审核人员1 = string.Empty;
            //if (str新审核人员 != "")
            //{
            //    str新审核人员1 = ";" + str新审核人员 + "未审批";
            //}

            //string str2 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "审核通过" + str新审核人员1;
            //string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            //DataSet ds2 = Sql.SqlQueryDS(sql2);
            //if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            //{

            //}
            //else
            //{
            //    list2.col1 = str1;
            //    list2.col2 = str2;
            //    list2.col3 = TextBox审批意见.Text.Trim();
            //    list2.InsertData();
            //}

            //caiwu5List List = new caiwu5List();
            //List.col43 = str2;
            //List.col49 = str新审核人员;
            //List.col50 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            //List.col52 = TextBox审批意见.Text.Trim();
            //List.UpdateDatashenhe(int.Parse(this.ViewState["IDNO"].ToString()));
            //base.Response.Redirect("caiwu6.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn审核不通过_Click(object sender, EventArgs e)
        {
            string fullname = TextBox申请人.Text;
            var tickedFormNo = base.Request.QueryString["idno"];
            txtquanxian = txtquanxian == "" ? "0" : txtquanxian;


            var Pdata = "<script> var aaa ='"
                           + 3 + "'; fullname ='"
                         + fullname + "';tickedFormNo ="
                         + tickedFormNo + ";txtquanxian ="
                         + txtquanxian + ";LinkPrintPage();</script>";

            ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata);//將結果傳到Cient Site.


            //zhuangtaiList list2 = new zhuangtaiList();
            //string str1 = TextBoxbaocunnocol45.Text;
            //string str2 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "审核不通过" + ";" + TextBox申请人.Text + "继续修改!";
            //string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            //DataSet ds2 = Sql.SqlQueryDS(sql2);
            //if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            //{

            //}
            //else
            //{
            //    list2.col1 = str1;
            //    list2.col2 = str2;
            //    list2.col3 = TextBox审批意见.Text.Trim();
            //    list2.InsertData();
            //}

            //caiwu5List List = new caiwu5List();
            //List.col43 = str2;
            //List.col49 = this.Session["FullName"].ToString();
            //List.col50 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            //List.col52 = TextBox审批意见.Text.Trim();
            //List.UpdateDatashenhe(int.Parse(this.ViewState["IDNO"].ToString()));
            //base.Response.Redirect("caiwu6.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            
        }

        protected void btn提交2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("caiwu6.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&models=" + models + " ");

        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox项目实施单位发票附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox项目实施单位发票附件.Text = "";
                项目实施单位发票附件href.HRef = "";
                项目实施单位发票附件href.InnerText = "";
                btnAttach.Visible = false;
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox付款凭证.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox付款凭证.Text = "";
                付款凭证href.HRef = "";
                付款凭证href.InnerText = "";
                LinkButton1.Visible = false;
            }
        }



    }
}