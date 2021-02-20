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
    public partial class caiwu2 : System.Web.UI.Page
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
        public string role = "";
        public decimal aomunt1 = 0;
        public decimal aomunt2 = 0;
        public decimal aomunt3 = 0;
        public decimal aomunt4 = 0;

        public decimal aomunt18 = 0;
        public decimal dscount = 0;
        public int nums = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            OledbHelper oledbHelper = new OledbHelper();
            DataTable dtshenhe = oledbHelper.GetDataTable("select * from t_shenhe where col2 = '" + this.Session["FullName"].ToString() + "' and col1 = '3' ");
            hdRoleValue.Value = "审核";
            hd用户.Text = this.Session["FullName"].ToString();
            if (!base.IsPostBack)
            {
                hdNo.Text = "";

                quanxian();
                getDrop所属项目部();
               
                hd合同类型.Text = this.Drop合同类型.Text;
                //hdNo.Text = CreateNext();
                txt申请人.Text = this.Session["FullName"].ToString();
                TextBox申请日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                txt申请人.Attributes.Add("readOnly", "readOnly");
                TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                TextBox本次开票金额合计不含税.Attributes.Add("readOnly", "readOnly");
                TextBox税额合计.Attributes.Add("readOnly", "readOnly");
                TextBox本次发票价税合计金额.Attributes.Add("readOnly", "readOnly");
                TextBox税率.Attributes.Add("readOnly", "readOnly");

                hdidno.Value = base.Request.QueryString["idno"];
                hdid.Value = base.Request.QueryString["id"];

                
                string zihuamianid = string.Empty;
                string idno = string.Empty;
                
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

                  
                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where ID = " + idno + " ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        
                        hdxiangmuid.Value = ds.Tables[0].Rows[0]["col61"].ToString();
                        Loadxiangmu_Click(sender, e);

                        txt申请人.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox申请日期.Text = ds.Tables[0].Rows[0]["col2"].ToString();

                        //if (Drop所属项目部.Items.Contains(new ListItem(ds.Tables[0].Rows[0]["col3"].ToString())))
                        //{
                        //    Drop所属项目部.ClearSelection();
                        //    this.Drop所属项目部.Items.FindByText(ds.Tables[0].Rows[0]["col3"].ToString()).Selected = true;
                        //}
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        //this.Drop所属项目部.Items.FindByText(ds.Tables[0].Rows[0]["col3"].ToString()).Selected = true;
                        //Drop所属项目部.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        getDrop所属项目经理();
                        Drop项目经理.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        Dropdown申请发票类型.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        Dropdown项目属性.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        Dropdown申请发票类别.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        Drop合同类型.Text = ds.Tables[0].Rows[0]["col8"].ToString();
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
                        Drop增值税预缴税款方式.Text = ds.Tables[0].Rows[0]["col26"].ToString();
                        TextBox增值税预缴税款地点.Text = ds.Tables[0].Rows[0]["col27"].ToString();
                        TextBox国税预缴金额.Text = ds.Tables[0].Rows[0]["col28"].ToString();
                        TextBox地税预缴金额.Text = ds.Tables[0].Rows[0]["col29"].ToString();

                        TextBox发票备注栏信息.Text = ds.Tables[0].Rows[0]["col49"].ToString();
                        TextBoxbaocunnocol53.Text = ds.Tables[0].Rows[0]["col53"].ToString();

                        TextBox开票申请表附件.Text = ds.Tables[0].Rows[0]["col50"].ToString();
                        TextBox税票扫描件.Text = ds.Tables[0].Rows[0]["col37"].ToString();

                        TextBox审核人.Text = ds.Tables[0].Rows[0]["col63"].ToString();
                        TextBox缴税备注栏信息.Text = ds.Tables[0].Rows[0]["col65"].ToString();
                        TextBox审批说明情况.Text = ds.Tables[0].Rows[0]["col66"].ToString();

                        zhuangtaiList list2 = new zhuangtaiList();
                        string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol53.Text + "' ";
                        DataSet ds22 = Sql.SqlQueryDS(sql2);
                        if (ds22 != null && ds22.Tables[0] != null && ds22.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds22.Tables[0].Rows.Count; k++)
                            {
                                TextBox审批状态.Text += ds22.Tables[0].Rows[k]["col2"].ToString() + @"
";
                            }

                        }
                        else
                        {
                            TextBox审批状态.Text = ds.Tables[0].Rows[0]["col33"].ToString();
                        }
                        //string[] str审批状态 = ds.Tables[0].Rows[0]["col55"].ToString().Split(';');
                       
                        //for (int k = 0; k < str审批状态.Length;k++ )
                        //{
                        //    if (str审批状态[k].ToString().Trim() == "")
                        //    {
                        //        continue;
                        //    }
                        //    TextBox审批状态.Text += str审批状态[k] + ";";
                        //}
                        

                        //if (TextBox开票申请表附件.Text != "")
                        //{
                        //    开票申请表附件href.HRef = TextBox开票申请表附件.Text;
                        //    开票申请表附件href.Visible = true;
                        //    var temp = TextBox开票申请表附件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            开票申请表附件href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
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
                        //    LinkButton4.Visible = true;
                        //}

                        DataSet ds222 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu22' and col1='" + idno + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu23' and col1='" + idno + "' ");
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

                Boolean detailflag = false;
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

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where col20 = '" + idno + "'");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["GridDataSource"] = ds.Tables[0];
                        this.GridView1.DataSource = ds.Tables[0];
                        this.GridView1.DataBind();
                        detailflag = true;

                        TextBox本次开票金额合计不含税.Text = aomunt1.ToString();
                        TextBox税额合计.Text = aomunt2.ToString();
                        TextBox本次发票价税合计金额.Text = aomunt3.ToString();
                        TextBox税率.Text = (aomunt4 * 100).ToString("F0") + "%";
                       
                    }
                    else
                    { 
                        DataTable dt = new DataTable("column");
                        DataRow dr;
                        dt.Columns.Add("id");
                        dt.Columns.Add("col17");
                        dt.Columns.Add("col18");
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col47");
                        dt.Columns.Add("col10");
                        dt.Columns.Add("col11");
                        dt.Columns.Add("col12");
                        dt.Columns.Add("col13");
                        dt.Columns.Add("col14");
                        dt.Columns.Add("col15");
                        dt.Columns.Add("col16");
                        dt.Columns.Add("col45");
                        dt.Columns.Add("col46");

                        dt.Columns.Add("col21");
                        dt.Columns.Add("col22");
                        dt.Columns.Add("col23");
                        dt.Columns.Add("col24");
                        dt.Columns.Add("col25");
                        dt.Columns.Add("col26");
                        dt.Columns.Add("col27");
                        dt.Columns.Add("col28");
                        dt.Columns.Add("col29");
                        dt.Columns.Add("col30");
                        dt.Columns.Add("col31");
 
                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        this.GridView1.DataSource = dt;
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = dt;
                    }
                }

                if (idno == "")
                {
                    idno = "00000";
                }

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    shdiv.Visible = true;
                    lbl开票Box2.Text = "开票审核管理";
                    txt申请人.Attributes.Add("readOnly", "readOnly");
                    TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    Dropdown申请发票类型.Enabled = false;
                    Dropdown申请发票类别.Enabled = false;
                    Dropdown项目属性.Enabled = false;
                    Drop合同类型.Enabled = false;
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
                    Drop增值税预缴税款方式.Enabled = false;
                    TextBox增值税预缴税款地点.Attributes.Add("readOnly", "readOnly");
                    TextBox国税预缴金额.Attributes.Add("readOnly", "readOnly");
                    TextBox地税预缴金额.Attributes.Add("readOnly", "readOnly");
                    TextBox发票备注栏信息.Attributes.Add("readOnly", "readOnly");
                    TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                    TextBox缴税备注栏信息.Attributes.Add("readOnly", "readOnly");
                    zancundiv.Visible = false;
                    tijiaodiv.Visible = false;
                    FileUpload1.Enabled = false;
                    Button8.Enabled = false;
                    FileUpload0.Enabled = false;
                    Button9.Enabled = false;
                    TextBox审批说明情况.Enabled = false;

                    span合同名称.Visible = false;
                    span经营地址.Visible = false;
                    span管理编号.Visible = false;
                    span付款单位名称.Visible = false;
                    span开票单位名称.Visible = false;
                    TextBox合同名称.Width = 955;
                    TextBox跨区域经营地址.Width = 380;
                    TextBox跨区域涉税事项报验管理编号.Width = 380;
                    TextBox付款单位名称.Width = 380;
                    TextBox开票单位名称.Width = 380;
                    btn导出.Visible = false;
                    this.GridView1.Enabled = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton4.Visible = false;

                }

                string model2 = base.Request.QueryString["model2"];
                if (model2 == "税额")
                {
                    Label缴税备注栏信息.Visible = true;
                    TextBox缴税备注栏信息.Visible = true;

                    lbl开票Box2.Text = "税款管理";
                    txt申请人.Attributes.Add("readOnly", "readOnly");
                    TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                    Drop所属项目部.Enabled = false;
                    Drop项目经理.Enabled = false;
                    Dropdown申请发票类型.Enabled = false;
                    Dropdown申请发票类别.Enabled = false;
                    Dropdown项目属性.Enabled = false;
                    Drop合同类型.Enabled = false;
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
                    Drop增值税预缴税款方式.Enabled = false;

                    TextBox发票备注栏信息.Attributes.Add("readOnly", "readOnly");
                    TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                    zancundiv.Visible = false;
                    tijiaodiv.Visible = true;
                    Div导出.Visible = false;
                    shenhe1div.Visible = false;
                    FileUpload1.Enabled = false;
                    Button8.Enabled = false;
                    //FileUpload0.Enabled = false;
                    //Button9.Enabled = false;
                    TextBox审批说明情况.Enabled = false;

                    span合同名称.Visible = false;
                    span经营地址.Visible = false;
                    span管理编号.Visible = false;
                    span付款单位名称.Visible = false;
                    span开票单位名称.Visible = false;
                    TextBox合同名称.Width = 955;
                    TextBox跨区域经营地址.Width = 380;
                    TextBox跨区域涉税事项报验管理编号.Width = 380;
                    TextBox付款单位名称.Width = 380;
                    TextBox开票单位名称.Width = 380;
                    btn导出.Visible = false;
                    this.GridView1.Enabled = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton4.Visible = false;

                }

                if (base.Request.QueryString["role"] != null)
                {
                    role = base.Request.QueryString["role"].ToString();
                    if (role == "审核")
                    {
                        printdiv.Visible = true;
                        shdiv.Visible = true;
                        shenhe1div.Visible = true;
                        shenhe2div.Visible = true;

                        backdiv.Visible = true;
                        btn导出.Visible = false;
                        if (dtshenhe.Rows.Count > 0)
                        {
                            kaipiaodiv.Visible = true;
                        }
                    }
                    if (role == "审核")
                    {
                        lbl开票Box2.Text = "开票审核管理";
                        txt申请人.Attributes.Add("readOnly", "readOnly");
                        TextBox申请日期.Attributes.Add("readOnly", "readOnly");
                        Drop所属项目部.Enabled = false;
                        Drop项目经理.Enabled = false;
                        Dropdown申请发票类型.Enabled = false;
                        Dropdown申请发票类别.Enabled = false;
                        Dropdown项目属性.Enabled = false;
                        Drop合同类型.Enabled = false;
                        Drop增值税预缴税款方式.Enabled = false;
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
                        Drop增值税预缴税款方式.Attributes.Add("readOnly", "readOnly");
                        TextBox增值税预缴税款地点.Attributes.Add("readOnly", "readOnly");
                        TextBox国税预缴金额.Attributes.Add("readOnly", "readOnly");
                        TextBox地税预缴金额.Attributes.Add("readOnly", "readOnly");
                        TextBox发票备注栏信息.Attributes.Add("readOnly", "readOnly");
                        TextBox审批状态.Attributes.Add("readOnly", "readOnly");
                        zancundiv.Visible = false;
                        tijiaodiv.Visible = false;
                        Div导出.Visible = false;
                        FileUpload1.Enabled = false;
                        Button8.Enabled = false;
                        FileUpload0.Enabled = false;
                        Button9.Enabled = false;

                        span合同名称.Visible = false;
                        span经营地址.Visible = false;
                        span管理编号.Visible = false;
                        span付款单位名称.Visible = false;
                        span开票单位名称.Visible = false;
                        TextBox合同名称.Width = 955;
                        TextBox跨区域经营地址.Width = 380;
                        TextBox跨区域涉税事项报验管理编号.Width = 380;
                        TextBox付款单位名称.Width = 380;
                        TextBox开票单位名称.Width = 380;

                        btn导出.Visible = false;
                        //this.GridView1.Enabled = false;
                        //TextBox审批说明情况.Enabled = false;

                        btnAttach.Visible = false;
                        LinkButton1.Visible = false;
                        LinkButton4.Visible = false;
                    }

                }

                if (this.GridView1.Rows.Count > 0 && this.ViewState["ID"].ToString().Trim() != "" && detailflag == true)
                {
                    return;
                }
                DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu22 where col20 = '" + idno + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
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
                        dt.Columns.Add("id");
                        dt.Columns.Add("col17");
                        dt.Columns.Add("col18");
                        dt.Columns.Add("col8");
                        dt.Columns.Add("col9");
                        dt.Columns.Add("col47");
                        dt.Columns.Add("col10");
                        dt.Columns.Add("col11");
                        dt.Columns.Add("col12");
                        dt.Columns.Add("col13");
                        dt.Columns.Add("col14");
                        dt.Columns.Add("col15");
                        dt.Columns.Add("col16");
                        dt.Columns.Add("col45");
                        dt.Columns.Add("col46");

                        dt.Columns.Add("col21");
                        dt.Columns.Add("col22");
                        dt.Columns.Add("col23");
                        dt.Columns.Add("col24");
                        dt.Columns.Add("col25");
                        dt.Columns.Add("col26");
                        dt.Columns.Add("col27");
                        dt.Columns.Add("col28");
                        dt.Columns.Add("col29");
                        dt.Columns.Add("col30");
                        dt.Columns.Add("col31");

                        dr = dt.NewRow();
                        dt.Rows.Add(dr);
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
                            dt.Columns.Add("id");
                            dt.Columns.Add("col17");
                            dt.Columns.Add("col18");
                            dt.Columns.Add("col8");
                            dt.Columns.Add("col9");
                            dt.Columns.Add("col47");
                            dt.Columns.Add("col10");
                            dt.Columns.Add("col11");
                            dt.Columns.Add("col12");
                            dt.Columns.Add("col13");
                            dt.Columns.Add("col14");
                            dt.Columns.Add("col15");
                            dt.Columns.Add("col16");
                            dt.Columns.Add("col45");
                            dt.Columns.Add("col46");

                            dt.Columns.Add("col21");
                            dt.Columns.Add("col22");
                            dt.Columns.Add("col23");
                            dt.Columns.Add("col24");
                            dt.Columns.Add("col25");
                            dt.Columns.Add("col26");
                            dt.Columns.Add("col27");
                            dt.Columns.Add("col28");
                            dt.Columns.Add("col29");
                            dt.Columns.Add("col30");
                            dt.Columns.Add("col31");

                            dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            this.GridView1.DataSource = dt;
                            this.GridView1.DataBind();
                            ViewState["GridDataSource"] = dt;
                        }
                    }

                }


            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        string CreateNext3()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col2) as col1 from t_fujian where 1=1 and col2 like '%"+ strdate +"%'  ";
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
            sql = "select max(col18) as col18 from t_caiwu22 where 1=1 and col19 = '" + strdate + "' ";
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

        string CreateNext2()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyy年-MM月-dd日");
            sql = "select max(col53) as col53 from t_caiwu2 where 1=1 and col2 = '" + strdate + "' ";
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


        //protected void ListPager_PageChanged(object sender, EventArgs e)
        //{
        //    this.GridBind();
        //}

        //private void GridBind()
        //{
        //    AdminPager adminPager = new AdminPager(this.ListPager);
        //    adminPager.PageSize = MojoCube.Web.String.PageSize();
        //    adminPager.ConnStr = Connection.ConnString();
        //    adminPager.TableName = "t_caiwu2";
        //    adminPager.strGetFields = "*";
        //    ArrayList arrayList = new ArrayList();
        //    StringBuilder where = new StringBuilder();
        //    where.Append(" where 1=1 and ID = '1' ");

        //    adminPager.where = where.ToString();
        //    adminPager.parameter = arrayList;
        //    adminPager.fldName = this.ViewState["OrderByKey"].ToString();
        //    adminPager.OrderType = (bool)this.ViewState["OrderByType"];
        //    this.GridView1.DataSource = adminPager.GetTable();
        //    this.GridView1.DataBind();
        //}

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
            dtnew.Columns.Add("col38");
            dtnew.Columns.Add("col39");
            dtnew.Columns.Add("col40");
            dtnew.Columns.Add("col41");
            dtnew.Columns.Add("col42");
            dtnew.Columns.Add("col43");
            dtnew.Columns.Add("col44");
            dtnew.Columns.Add("col45");
            dtnew.Columns.Add("col46");
            DataRow dr;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                dr = dtnew.NewRow();
                dr["col30"] = i + 1;
                dr["col31"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol31")).Text.ToString();
                dr["col32"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol32")).Text.ToString();
                dr["col33"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol33")).Text.ToString();
                dr["col34"] = ((Label)GridView1.Rows[i].FindControl("lblcol34")).Text.ToString();
                dr["col35"] = ((Label)GridView1.Rows[i].FindControl("lblcol35")).Text.ToString();
                dr["col36"] = ((Label)GridView1.Rows[i].FindControl("lblcol36")).Text.ToString();
                dr["col37"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol37")).Text.ToString();
                dr["col38"] = ((Label)GridView1.Rows[i].FindControl("lblcol38")).Text.ToString();
                dr["col39"] = ((Label)GridView1.Rows[i].FindControl("lblcol39")).Text.ToString();
                dr["col40"] = ((Label)GridView1.Rows[i].FindControl("lblcol40")).Text.ToString();
                dr["col41"] = ((Label)GridView1.Rows[i].FindControl("lblcol41")).Text.ToString();
                dr["col42"] = ((Label)GridView1.Rows[i].FindControl("lblcol42")).Text.ToString();
                dr["col42"] = ((Label)GridView1.Rows[i].FindControl("lblcol43")).Text.ToString();
                dr["col44"] = ((Label)GridView1.Rows[i].FindControl("lblcol44")).Text.ToString();
                dr["col45"] = ((Label)GridView1.Rows[i].FindControl("lblcol45")).Text.ToString();
                dr["col46"] = ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.ToString();
                
                dtnew.Rows.Add(dr);
            }

            ViewState["GridDataSource"] = dtnew;

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                nums++;
                if (base.Request.QueryString["role"] == "审核")
                {
                    GridView1.Columns[0].Visible = false;
                    GridView1.Columns[1].Visible = false;
                }
                string strid1 = ((Label)e.Row.FindControl("lblID")).Text;
                //hdNo.Text = hdNo.Text == "" ? CreateNext() : hdNo.Text;
                string idno = base.Request.QueryString["idno"] == null ? hdNo2.Text : base.Request.QueryString["idno"].ToString();
                
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol31")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2Add.aspx?id1=" + strid1 + "&id=" + hdNo.Text + "&idno=" + idno + "";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 200;
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol31")).Width : ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 6;
               
                //((Label)e.Row.FindControl("lblcol31")).Width = ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol31")).Width : ((Label)e.Row.FindControl("lblcol31")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol32")).Width = ((Label)e.Row.FindControl("lblcol32")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol32")).Width : ((Label)e.Row.FindControl("lblcol32")).Text.Trim().Length * 10;
                ((Label)e.Row.FindControl("lblcol33")).Width = ((Label)e.Row.FindControl("lblcol33")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol33")).Width : ((Label)e.Row.FindControl("lblcol33")).Text.Trim().Length * 6;
                
                ((Label)e.Row.FindControl("lblcol34")).Width = ((Label)e.Row.FindControl("lblcol34")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol34")).Width : ((Label)e.Row.FindControl("lblcol34")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol35")).Width = ((Label)e.Row.FindControl("lblcol35")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol35")).Width : ((Label)e.Row.FindControl("lblcol35")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol36")).Width = ((Label)e.Row.FindControl("lblcol36")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol36")).Width : ((Label)e.Row.FindControl("lblcol36")).Text.Trim().Length * 6;
                ((Label)e.Row.FindControl("lblcol37")).Width = ((Label)e.Row.FindControl("lblcol37")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol37")).Width : ((Label)e.Row.FindControl("lblcol37")).Text.Trim().Length * 6;

                ((Label)e.Row.FindControl("lblcol38")).Width = ((Label)e.Row.FindControl("lblcol38")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol38")).Width : ((Label)e.Row.FindControl("lblcol38")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol39")).Width = ((Label)e.Row.FindControl("lblcol39")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol39")).Width : ((Label)e.Row.FindControl("lblcol39")).Text.Trim().Length * 12;
                
                if (((HyperLink)e.Row.FindControl("HyperLink1")).Width.Value < 100)
                {
                    ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol32")).Width.Value < 90)
                {
                    ((Label)e.Row.FindControl("lblcol32")).Width = 90;
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

                if (((Label)e.Row.FindControl("lblcol35")).Text.Trim() != "")
                {
                    if (((Label)e.Row.FindControl("lblcol35")).Text.Trim().Contains("%"))
                    {
                        //((Label)e.Row.FindControl("lblcol35")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol35")).Text.Replace("%", "")) / 100).ToString("F2");
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblcol35")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol35")).Text) * 100).ToString("F0") + "%";
                    }
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

                if (str18 == "" || str18 == "&nbsp;")
                {
                    str18 = "0";
                }
                aomunt1 += Convert.ToDecimal(str01);
                aomunt2 += Convert.ToDecimal(str02);
                aomunt3 += Convert.ToDecimal(str03);
                aomunt18 += Convert.ToDecimal(str18);
                
                dscount++;
                if(nums == 1)
                {
                    if (str04 == "3%")
                    {
                        aomunt4 = Convert.ToDecimal(0.03);
                    }
                    else if (str04 == "6%")
                    {
                        aomunt4 = Convert.ToDecimal(0.06);
                    }
                    else if (str04 == "9%")
                    {
                        aomunt4 = Convert.ToDecimal(0.09);
                    }
                    else if (str04 == "10%")
                    {
                        aomunt4 = Convert.ToDecimal(0.1);
                    }
                    else if (str04 == "11%")
                    {
                        aomunt4 = Convert.ToDecimal(0.11);
                    }
                    else if (str04 == "13%")
                    {
                        aomunt4 = Convert.ToDecimal(0.13);
                    }
                    else if (str04 == "16%")
                    {
                        aomunt4 = Convert.ToDecimal(0.16);
                    }
                    else if (str04 == "17%")
                    {
                        aomunt4 = Convert.ToDecimal(0.17);
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int kk = int.Parse((dscount * 40).ToString());
                if (kk > 200)
                {
                    this.GridView1.Height = (Unit)200;
                }
                else
                {
                    this.GridView1.Height = (Unit)int.Parse((dscount * 40).ToString());
                }

                e.Row.Cells[19].Text = "<span align='center' style='font-weight:bold;color:red'> " + aomunt18 + " </span>";

                e.Row.Cells[25].Text = "<span align='center' style='font-weight:bold;color:red'> " + aomunt1 + " </span>";
                e.Row.Cells[26].Text = "<span align='center' style='font-weight:bold;color:red'> " + (aomunt4 * 100).ToString("F0") + "%" + " </span>";
                e.Row.Cells[27].Text = "<span align='center' style='font-weight:bold;color:red'>" + aomunt2 + "</span>";
                e.Row.Cells[28].Text = "<span align='center' style='font-weight:bold;color:red'>" + aomunt3 + "</span>";
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddData")
            {
                if (this.TextBox合同名称.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                    return;
                }
                if (hdNo.Text == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请先点暂存按钮保存信息！");
                    return;
                }
                hdNo.Text = hdNo.Text == "" ? CreateNext() : hdNo.Text;
                string t1 = TextBox合同名称.Text.Trim();
                string t2 = TextBox合同编号.Text.Trim();
                string t3 = Drop合同类型.Text.Trim();

                string idno = base.Request.QueryString["idno"] == null ? hdNo2.Text : base.Request.QueryString["idno"].ToString();
                Response.Redirect("caiwu2Add.aspx?id=" + hdNo.Text + "&idno=" + idno + "&t1=" + t1 + "&t2=" + t2 + "&t3=" + t3, false);

            }
            else if (e.CommandName == "DisableData")
            {
                //GetDetail();

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblcol30")).Text);
                string rowIDs1 = Convert.ToString(((Label)row.FindControl("lblcol47")).Text);
                string rowIDs2 = Convert.ToString(((Label)row.FindControl("lblcol48")).Text);

                string sql = string.Empty;

                sql = "delete from t_caiwu22 where col17 = '" + rowIDs1 + "' and col18 = '" + rowIDs2 + "'   ";
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
                    dt.Columns.Add("col17");
                    dt.Columns.Add("col18");
                    dt.Columns.Add("col8");
                    dt.Columns.Add("col9");
                    dt.Columns.Add("col47");
                    dt.Columns.Add("col10");
                    dt.Columns.Add("col11");
                    dt.Columns.Add("col12");
                    dt.Columns.Add("col21");
                    dt.Columns.Add("col22");
                    dt.Columns.Add("col23");
                    dt.Columns.Add("col24");
                    dt.Columns.Add("col25");
                    dt.Columns.Add("col26");
                    dt.Columns.Add("col27");
                    dt.Columns.Add("col28");
                    dt.Columns.Add("col29");
                    dt.Columns.Add("col30");
                    dt.Columns.Add("col31");

                    dr2 = dt.NewRow();
                    dt.Rows.Add(dr2);
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    ViewState["GridDataSource"] = dt;
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


        protected void FileUpload开票申请表附件Button_Click(object sender, EventArgs e)
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

                开票申请表附件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox开票申请表附件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List 附件List = new 附件List();
                附件List.flag = "caiwu22";
                附件List.col1 = this.ViewState["IDNO"] == null ? "" : this.ViewState["IDNO"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext3() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu22' and col2='" + 附件List.col2 + "' ");
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
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        开票申请表附件href.InnerText = temps2;
                //    }
                //    btnAttach.Visible = true;

                //}

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload税票扫描件Button_Click(object sender, EventArgs e)
        {
            if (FileUpload0.HasFile)
            {

                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload0.PostedFile.FileName;
                FileUpload0.SaveAs(filePath + fileName);

                税票扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox税票扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List 附件List = new 附件List();
                附件List.flag = "caiwu23";
                附件List.col1 = this.ViewState["IDNO"] == null ? "" : this.ViewState["IDNO"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext3() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu23' and col2='" + 附件List.col2 + "' ");
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
                //var temp = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                //if (temp != "")
                //{
                //    var temps = temp.LastIndexOf("/");
                //    if (temps > 0)
                //    {
                //        var temps2 = temp.Substring(temps);
                //        税票扫描件href.InnerText = temps2;
                //    }
                //    LinkButton4.Visible = true;

                //}

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }


        //protected void FileUpload发票记账联扫描件Button_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload2.HasFile)
        //    {
        //        //string filePath = Server.MapPath("公司证件UploadFile/");
        //        string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
        //        string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = FileUpload2.PostedFile.FileName;
        //        FileUpload2.SaveAs(filePath + fileName);

        //        发票记账联扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        TextBox发票记账联扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

        //    }
        //    else
        //    {
        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

        //    }
        //}

        //protected void FileUpload发票发票联扫描件Button_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload3.HasFile)
        //    {

        //        string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
        //        string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = FileUpload3.PostedFile.FileName;
        //        FileUpload3.SaveAs(filePath + fileName);

        //        发票记账联扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        TextBox发票记账联扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

        //    }
        //    else
        //    {
        //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

        //    }
        //}


        protected void Drop合同类型SelectedIndexChanged(Object sender, EventArgs e)
        {
            hd合同类型.Text = this.Drop合同类型.Text;
        }


        protected void btn暂存_Click(object sender, EventArgs e)
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

            if (this.Dropdown申请发票类型.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写申请发票类型");
                return;
            }
            if (this.Dropdown项目属性.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目属性");
                return;
            }
            if (this.Dropdown申请发票类别.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写申请发票类别");
                return;
            }
            if (this.Drop合同类型.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同类型");
                return;
            }

            if (this.TextBox合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox跨区域涉税事项报验管理编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写跨区域涉税事项报验管理编号");
                return;
            }
            if (this.TextBox付款单位名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写付款单位名称");
                return;
            }
            if (this.TextBox开票单位名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开票单位名称");
                return;
            }
            if (this.Drop增值税预缴税款方式.Text.Trim() == "开票前预缴")
            {
                if (this.TextBox增值税预缴税款地点.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写增值税预缴税款地点");
                    return;
                }
                if (this.TextBox国税预缴金额.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写增值税预缴金额");
                    return;
                }
                if (this.TextBox地税预缴金额.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写附加税预缴金额");
                    return;
                }
                if (this.GridView3.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写税票扫描件");
                    return;
                }

            }
            if (this.TextBox发票备注栏信息.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发票备注栏信息");
                return;
            }
            if (this.GridView2.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开票申请表附件");
                return;
            }
            
            TextBoxbaocunnocol53.Text = TextBoxbaocunnocol53.Text == "" ? CreateNext2() : TextBoxbaocunnocol53.Text;
              
            caiwu2List List = new caiwu2List();
            List.col1 = txt申请人.Text.Trim();
            List.col2 = TextBox申请日期.Text.Trim();
            List.col3 = Drop所属项目部.Text.Trim();
            List.col4 = Drop项目经理.Text.Trim();
            List.col5 = Dropdown申请发票类型.Text.Trim();
            List.col6 = Dropdown项目属性.Text.Trim();
            List.col7 = Dropdown申请发票类别.Text.Trim();
            List.col8 = Drop合同类型.Text.Trim();
            List.col9 = TextBox合同名称.Text.Trim();
            List.col10 = TextBox合同编号.Text.Trim();
            List.col11 = TextBox合同金额.Text.Trim();
            List.col12 = TextBox跨区域经营地址.Text.Trim();
            List.col13 = TextBox跨区域涉税事项报验管理编号.Text.Trim();
            List.col14 = TextBox付款单位名称.Text.Trim();
            List.col15 = TextBox开票单位名称.Text.Trim();
            List.col16 = TextBox付款单位纳税人识别号.Text.Trim();
            List.col17 = TextBox开票单位纳税人识别号.Text.Trim();
            List.col18 = TextBox付款单位地址.Text.Trim();
            List.col19 = TextBox开票单位地址.Text.Trim();
            List.col20 = TextBox付款单位电话.Text.Trim();
            List.col21 = TextBox开票单位电话.Text.Trim();
            List.col22 = TextBox付款单位开户行.Text.Trim();
            List.col23 = TextBox开票单位开户行.Text.Trim();
            List.col24 = TextBox付款单位账号.Text.Trim();
            List.col25 = TextBox开票单位账号.Text.Trim();
            List.col26 = Drop增值税预缴税款方式.Text.Trim();
            List.col27 = TextBox增值税预缴税款地点.Text.Trim();
            List.col28 = TextBox国税预缴金额.Text.Trim();
            List.col29 = TextBox地税预缴金额.Text.Trim();

            List.col30 = "";
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
            List.col41 = "";
            List.col42 = "";
            List.col43 = "";
            List.col44 = "";
            List.col45 = "";
            List.col46 = "";
            List.col47 = "";
            List.col48 = "";
            List.col59 = "";
            List.col60 = "";

            decimal amount1 = 0;
            caiwu22List caiwu1List = new caiwu22List();

            string ttcol17 = "";
            string ttcol18 = "";
            for (int i = 0; i < GridView1.Rows.Count; i ++ )
            {
                //List.col30 = ((Label)GridView1.Rows[i].FindControl("lblcol30")).Text.Trim();
                //List.col31 = ((Label)GridView1.Rows[i].FindControl("lblcol31")).Text.Trim();
                //List.col32 = ((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim();
                //List.col33 = ((Label)GridView1.Rows[i].FindControl("lblcol33")).Text.Trim();
                //List.col34 = ((Label)GridView1.Rows[i].FindControl("lblcol34")).Text.Trim();
                //List.col35 = ((Label)GridView1.Rows[i].FindControl("lblcol35")).Text.Trim();
                //List.col36 = ((Label)GridView1.Rows[i].FindControl("lblcol36")).Text.Trim();
                //List.col37 = ((Label)GridView1.Rows[i].FindControl("lblcol37")).Text.Trim();
                //List.col38 = ((Label)GridView1.Rows[i].FindControl("lblcol38")).Text.Trim();
                //List.col39 = ((Label)GridView1.Rows[i].FindControl("lblcol39")).Text.Trim();
                //List.col40 = ((Label)GridView1.Rows[i].FindControl("lblcol40")).Text.Trim();
                //List.col41 = ((Label)GridView1.Rows[i].FindControl("lblcol41")).Text.Trim();
                //List.col42 = ((Label)GridView1.Rows[i].FindControl("lblcol42")).Text.Trim();
                //List.col43 = ((Label)GridView1.Rows[i].FindControl("lblcol43")).Text.Trim();
                //List.col44 = ((Label)GridView1.Rows[i].FindControl("lblcol44")).Text.Trim();
                //List.col45 = ((Label)GridView1.Rows[i].FindControl("lblcol45")).Text.Trim();
                //List.col46 = ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim();
                //List.col47 = ((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim();
                //List.col48 = ((Label)GridView1.Rows[i].FindControl("lblcol48")).Text.Trim();
                ttcol17 += "'" + ((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim() + "'" + ",";
                ttcol18 = ((Label)GridView1.Rows[i].FindControl("lblcol48")).Text.Trim();

                amount1 += Convert.ToDecimal(((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim() == "" ? "0" : ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim());

                
            }
            if (ttcol17.Length > 1)
            {
                ttcol17 = ttcol17.Substring(0, ttcol17.Length - 1);
            }
            

            Sql.SqlQueryDS("delete from t_caiwu22 where col17 not in (" + ttcol17 + ") and col18 = '" + ttcol18 + "' ");


            List.col49 = TextBox发票备注栏信息.Text.Trim();
            if (this.GridView2.Rows.Count == 0)
            {
                List.col50 = "0";
            }
            else
            {
                List.col50 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                List.col37 = "0";
            }
            else
            {
                List.col37 = "1";
            }
            //List.col50 = TextBox开票申请表附件.Text.Trim();
            //List.col37 = TextBox税票扫描件.Text.Trim();
            List.col51 = "";
            List.col52 = "";
            List.col53 = TextBoxbaocunnocol53.Text;
            //发票价税合计金额
            List.col54 = amount1.ToString();
            //审批状态
            OledbHelper oledbHelper = new OledbHelper();
            string str审核人员 = string.Empty;
            string sql审核人员 = "select * from t_shenhe where 1=1 and col1 = '1' ";
            DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            if (dt审核人员.Rows.Count > 0)
            {
                str审核人员 = dt审核人员.Rows[0]["col2"].ToString();
            }

            //List.col55 = txt申请人.Text + " " + TextBox申请日期.Text + "申请开票," + str审核人员 + "未提交";
            List.col55 = txt申请人.Text + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "申请开票," + txt申请人.Text + "未提交";

            List.col61 = hdxiangmuid.Value.Trim();
            List.col62 = str审核人员;
            List.col63 = "";

            List.col65 = TextBox缴税备注栏信息.Text.Trim();
            List.col66 = TextBox审批说明情况.Text.Trim();


            if (this.ViewState["IDNO"] != null || hdNo2.Text != "")
            {
                string id = this.ViewState["IDNO"] == null ? hdNo2.Text : this.ViewState["IDNO"].ToString();
                if (id == "")
                {
                    List.ID = List.InsertData();
                }
                else
                {
                    List.ID = int.Parse(id);
                    List.UpdateData(List.ID);
                }
                
            }
            else
            {
                List.GetData(TextBoxbaocunnocol53.Text);
                if (List.ID > 0)
                {
                    TextBoxbaocunnocol53.Text = CreateNext2();
                }

                List.InsertData();
            }
            hdNo.Text = List.col53.ToString();

            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol53.Text + "' and col2='" + List.col55 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {
           
            }
            else
            {
                list2.col1 = TextBoxbaocunnocol53.Text;
                list2.col2 = List.col55;
                list2.col3 = "";
                list2.InsertData();
            }

            

            string ID = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + List.col53 + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ID = ds.Tables[0].Rows[0]["ID"].ToString();
                hdNo2.Text = ID;
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

            //财务管理》发票管理 
            //caiwu3List List发票 = new caiwu3List();

            string fapiaono = string.Empty;
            decimal 总计到账金额 = 0;
            decimal 总计开票金额 = 0;
            string 开票金额 = "0";

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    caiwu1List.col18 = TextBoxbaocunnocol53.Text;
            //    caiwu1List.col19 = DateTime.Now.ToString("yyyyMMdd");
            //    caiwu1List.col20 = hdNo2.Text;
            //    caiwu1List.col32 = "1";
            //    caiwu1List.col39 = Dropdown申请发票类型.Text.Trim();
            //    caiwu1List.col40 = Dropdown申请发票类别.Text.Trim();
            //    caiwu1List.col41 = txt申请人.Text;
            //    caiwu1List.col42 = TextBox申请日期.Text;
            //    caiwu1List.col49 = Drop合同类型.Text;

            //    caiwu1List.UpdateData2(((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim());

            //    //开票金额 = ((Label)GridView1.Rows[i].FindControl("lblcol37")).Text.Trim();
            //    //if (开票金额 == "" || 开票金额 == "&nbsp;")
            //    //{
            //    //    开票金额 = "0";
            //    //}
            //    //总计开票金额 += Convert.ToDecimal(开票金额);

            //    //fapiaono = TextBoxbaocunnocol53.Text;
            //    //DataSet ds222 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' ");
            //    //if (ds222 != null && ds222.Tables[0] != null && ds222.Tables[0].Rows.Count > 0)
            //    //{
            //    //    for (int iii = 0; iii < ds222.Tables[0].Rows.Count; iii++)
            //    //    {
            //    //        string 到账金额 = ds222.Tables[0].Rows[iii]["col59"].ToString();
            //    //        if (到账金额 == "" || 到账金额 == "&nbsp;")
            //    //        {
            //    //            到账金额 = "0";
            //    //        }
            //    //        总计到账金额 += Convert.ToDecimal(到账金额);
            //    //    }

            //    //}

            //}


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                caiwu1List.col18 = hdNo.Text;
                caiwu1List.col19 = DateTime.Now.ToString("yyyyMMdd");
                caiwu1List.col20 = hdNo2.Text;
                caiwu1List.col32 = "1";
                caiwu1List.col39 = Dropdown申请发票类型.Text.Trim();
                caiwu1List.col40 = Dropdown申请发票类别.Text.Trim();
                caiwu1List.col41 = txt申请人.Text;
                caiwu1List.col42 = TextBox申请日期.Text;
                caiwu1List.col49 = Drop合同类型.Text;


                caiwu1List.UpdateData2(((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim());

            }

            //if (GridView1.Rows.Count == 0)
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "开票明细至少要有一条数据才能提交！");
            //    return;
            //}

            //if (model2 == "税额")
            //{
            //    base.Response.Redirect("caiwu31.aspx");
            //}
            //else
            //{
            //    base.Response.Redirect("caiwu3.aspx");
            //}
            //Response.Redirect("caiwu2.aspx?id=" + hdNo.Text + "&idno = " + hdNo2.Text + "", false);
            
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

            string sql = string.Empty;
            //if (this.Drop合同类型.Text == "施工合同")
            //{
            //    sql = "select * from t_hetong where id=" + tickedid + "";
            //    DataSet ds = Sql.SqlQueryDS(sql);
            //    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //    {
            //        DataTable dt = new DataTable();
            //        dt.Columns.Add("xiangmu");
            //        dt.Columns.Add("xiangmu2");
            //        DataRow dr;
            //        if (ds.Tables[0].Rows[0]["col8"].ToString() != "")
            //        {
            //            dr = dt.NewRow();
            //            dr["xiangmu"] = ds.Tables[0].Rows[0]["col8"].ToString();
            //            dr["xiangmu2"] = ds.Tables[0].Rows[0]["col9"].ToString();
            //            dt.Rows.Add(dr);
            //        }
            //        if (ds.Tables[0].Rows[0]["col23"].ToString() != "")
            //        {
            //            dr = dt.NewRow();
            //            dr["xiangmu"] = ds.Tables[0].Rows[0]["col23"].ToString();
            //            dr["xiangmu2"] = ds.Tables[0].Rows[0]["col24"].ToString();
            //            dt.Rows.Add(dr);
            //        }
            //        if (ds.Tables[0].Rows[0]["col26"].ToString() != "")
            //        {
            //            dr = dt.NewRow();
            //            dr["xiangmu"] = ds.Tables[0].Rows[0]["col26"].ToString();
            //            dr["xiangmu2"] = ds.Tables[0].Rows[0]["col27"].ToString();
            //            dt.Rows.Add(dr);
            //        }
            //        Drop所属项目部.DataTextField = "xiangmu";
            //        Drop所属项目部.DataValueField = "xiangmu2";
            //        Drop所属项目部.DataSource = dt;
            //        Drop所属项目部.DataBind();
            //        Drop所属项目部.Items.Insert(0, "");

            //    }
            //}
            //else
            //{
            //    sql = "select * from t_hetong2 where id=" + tickedid + "";
            //    DataSet ds = Sql.SqlQueryDS(sql);
            //    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //    {
            //        DataTable dt = new DataTable();
            //        dt.Columns.Add("xiangmu");
            //        dt.Columns.Add("xiangmu2");
            //        DataRow dr;
            //        if (ds.Tables[0].Rows[0]["col9"].ToString() != "")
            //        {
            //            dr = dt.NewRow();
            //            dr["xiangmu"] = ds.Tables[0].Rows[0]["col9"].ToString();
            //            dr["xiangmu2"] = ds.Tables[0].Rows[0]["col10"].ToString();
            //            dt.Rows.Add(dr);
            //        }
            //        if (ds.Tables[0].Rows[0]["col12"].ToString() != "")
            //        {
            //            dr = dt.NewRow();
            //            dr["xiangmu"] = ds.Tables[0].Rows[0]["col12"].ToString();
            //            dr["xiangmu2"] = ds.Tables[0].Rows[0]["col13"].ToString();
            //            dt.Rows.Add(dr);
            //        }
            //        if (ds.Tables[0].Rows[0]["col15"].ToString() != "")
            //        {
            //            dr = dt.NewRow();
            //            dr["xiangmu"] = ds.Tables[0].Rows[0]["col15"].ToString();
            //            dr["xiangmu2"] = ds.Tables[0].Rows[0]["col16"].ToString();
            //            dt.Rows.Add(dr);
            //        }
            //        Drop所属项目部.DataTextField = "xiangmu";
            //        Drop所属项目部.DataValueField = "xiangmu2";
            //        Drop所属项目部.DataSource = dt;
            //        Drop所属项目部.DataBind();
            //        Drop所属项目部.Items.Insert(0, "");

            //    }
            //}
           
            #endregion
        }


        protected void btn提交_Click(object sender, EventArgs e)
        {
            string model2 = base.Request.QueryString["model2"];
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

            if (this.Dropdown申请发票类型.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写申请发票类型");
                return;
            }
            if (this.Dropdown项目属性.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目属性");
                return;
            }
            if (this.Dropdown申请发票类别.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写申请发票类别");
                return;
            }
            if (this.Drop合同类型.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同类型");
                return;
            }

            if (this.TextBox合同名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写合同名称");
                return;
            }
            if (this.TextBox跨区域涉税事项报验管理编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写跨区域涉税事项报验管理编号");
                return;
            }
            if (this.TextBox付款单位名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写付款单位名称");
                return;
            }
            if (this.TextBox开票单位名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开票单位名称");
                return;
            }
            if (this.Drop增值税预缴税款方式.Text.Trim() == "开票前预缴")
            {
                if (this.TextBox增值税预缴税款地点.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写增值税预缴税款地点");
                    return;
                }
                if (this.TextBox国税预缴金额.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写增值税预缴金额");
                    return;
                }
                if (this.TextBox地税预缴金额.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写附加税预缴金额");
                    return;
                }
                if (this.TextBox税票扫描件.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写税票扫描件");
                    return;
                }

            }
            if (this.TextBox发票备注栏信息.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发票备注栏信息");
                return;
            }
            if (this.GridView2.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开票申请表附件");
                return;
            }
            

            if (model2 == "税额")
            {
                if (this.TextBox增值税预缴税款地点.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写增值税预缴税款地点");
                    return;
                }
                if (this.TextBox国税预缴金额.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写增值税预缴金额");
                    return;
                }
                if (this.TextBox地税预缴金额.Text.Trim() == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写附加税预缴金额");
                    return;
                }
                if (this.GridView3.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写税票扫描件");
                    return;
                }
            }

            if (this.GridView1.Rows.Count > 0)
            {
                var t1 = ((Label)GridView1.Rows[0].FindControl("lblcol31")).Text.Trim();
                var t2 = ((Label)GridView1.Rows[0].FindControl("lblcol32")).Text.Trim();
                if (t1 == "" && t2 == "")
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "至少要有一条明细！");
                    return;
                }
                
            }
           

            TextBoxbaocunnocol53.Text = TextBoxbaocunnocol53.Text == "" ? CreateNext2() : TextBoxbaocunnocol53.Text;

            caiwu2List List = new caiwu2List();
            List.col1 = txt申请人.Text.Trim();
            List.col2 = TextBox申请日期.Text.Trim();
            List.col3 = Drop所属项目部.Text.Trim();
            List.col4 = Drop项目经理.Text.Trim();
            List.col5 = Dropdown申请发票类型.Text.Trim();
            List.col6 = Dropdown项目属性.Text.Trim();
            List.col7 = Dropdown申请发票类别.Text.Trim();
            List.col8 = Drop合同类型.Text.Trim();
            List.col9 = TextBox合同名称.Text.Trim();
            List.col10 = TextBox合同编号.Text.Trim();
            List.col11 = TextBox合同金额.Text.Trim();
            List.col12 = TextBox跨区域经营地址.Text.Trim();
            List.col13 = TextBox跨区域涉税事项报验管理编号.Text.Trim();
            List.col14 = TextBox付款单位名称.Text.Trim();
            List.col15 = TextBox开票单位名称.Text.Trim();
            List.col16 = TextBox付款单位纳税人识别号.Text.Trim();
            List.col17 = TextBox开票单位纳税人识别号.Text.Trim();
            List.col18 = TextBox付款单位地址.Text.Trim();
            List.col19 = TextBox开票单位地址.Text.Trim();
            List.col20 = TextBox付款单位电话.Text.Trim();
            List.col21 = TextBox开票单位电话.Text.Trim();
            List.col22 = TextBox付款单位开户行.Text.Trim();
            List.col23 = TextBox开票单位开户行.Text.Trim();
            List.col24 = TextBox付款单位账号.Text.Trim();
            List.col25 = TextBox开票单位账号.Text.Trim();
            List.col26 = Drop增值税预缴税款方式.Text.Trim();
            List.col27 = TextBox增值税预缴税款地点.Text.Trim();
            List.col28 = TextBox国税预缴金额.Text.Trim();
            List.col29 = TextBox地税预缴金额.Text.Trim();

            List.col30 = "";
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
            List.col41 = "";
            List.col42 = "";
            List.col43 = "";
            List.col44 = "";
            List.col45 = "";
            List.col46 = "";
            List.col47 = "";
            List.col48 = "";
            List.col59 = "";
            List.col60 = "";

            List.col65 = TextBox缴税备注栏信息.Text.Trim();
            List.col66 = TextBox审批说明情况.Text.Trim();

            decimal amount1 = 0;
            caiwu22List caiwu1List = new caiwu22List();
            string ttcol17 = "";
            string ttcol18 = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //List.col30 = ((Label)GridView1.Rows[i].FindControl("lblcol30")).Text.Trim();
                //List.col31 = ((Label)GridView1.Rows[i].FindControl("lblcol31")).Text.Trim();
                //List.col32 = ((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim();
                //List.col33 = ((Label)GridView1.Rows[i].FindControl("lblcol33")).Text.Trim();
                //List.col34 = ((Label)GridView1.Rows[i].FindControl("lblcol34")).Text.Trim();
                //List.col35 = ((Label)GridView1.Rows[i].FindControl("lblcol35")).Text.Trim();
                //List.col36 = ((Label)GridView1.Rows[i].FindControl("lblcol36")).Text.Trim();
                //List.col37 = ((Label)GridView1.Rows[i].FindControl("lblcol37")).Text.Trim();
                //List.col38 = ((Label)GridView1.Rows[i].FindControl("lblcol38")).Text.Trim();
                //List.col39 = ((Label)GridView1.Rows[i].FindControl("lblcol39")).Text.Trim();
                //List.col40 = ((Label)GridView1.Rows[i].FindControl("lblcol40")).Text.Trim();
                //List.col41 = ((Label)GridView1.Rows[i].FindControl("lblcol41")).Text.Trim();
                //List.col42 = ((Label)GridView1.Rows[i].FindControl("lblcol42")).Text.Trim();
                //List.col43 = ((Label)GridView1.Rows[i].FindControl("lblcol43")).Text.Trim();
                //List.col44 = ((Label)GridView1.Rows[i].FindControl("lblcol44")).Text.Trim();
                //List.col45 = ((Label)GridView1.Rows[i].FindControl("lblcol45")).Text.Trim();
                //List.col46 = ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim();
                //List.col47 = ((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim();
                //List.col48 = ((Label)GridView1.Rows[i].FindControl("lblcol48")).Text.Trim();
                ttcol17 += "'" + ((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim() + "'" + ",";
                ttcol18 = ((Label)GridView1.Rows[i].FindControl("lblcol48")).Text.Trim();

                amount1 += Convert.ToDecimal(((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim() == "" ? "0" : ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim());


            }
            if (ttcol17.Length > 1)
            {
                ttcol17 = ttcol17.Substring(0, ttcol17.Length - 1);
            }


            Sql.SqlQueryDS("delete from t_caiwu22 where col17 not in (" + ttcol17 + ") and col18 = '" + ttcol18 + "' ");



            List.col49 = TextBox发票备注栏信息.Text.Trim();
            if (this.GridView2.Rows.Count == 0)
            {
                List.col50 = "0";
            }
            else
            {
                List.col50 = "1";
            }
            if (this.GridView3.Rows.Count == 0)
            {
                List.col37 = "0";
            }
            else
            {
                List.col37 = "1";
            }
            //List.col50 = TextBox开票申请表附件.Text.Trim();
            //List.col37 = TextBox税票扫描件.Text.Trim();
            List.col51 = "";
            List.col52 = "";
            List.col53 = TextBoxbaocunnocol53.Text;
            //发票价税合计金额
            List.col54 = amount1.ToString();
            //审批状态
            OledbHelper oledbHelper = new OledbHelper();
            string str审核人员 = string.Empty;
            string sql审核人员 = "select * from t_shenhe where 1=1 and col1 = '1' ";
            DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            if (dt审核人员.Rows.Count > 0)
            {
                str审核人员 = dt审核人员.Rows[0]["col2"].ToString();
            }

            List.col55 = txt申请人.Text + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "申请开票," + str审核人员 + "未审批";

            List.col61 = hdxiangmuid.Value.Trim();
            List.col62 = str审核人员;
            List.col63 = "";

            if (this.ViewState["IDNO"] != null || hdNo2.Text != "")
            {
                string id = this.ViewState["IDNO"] == null ? hdNo2.Text : this.ViewState["IDNO"].ToString();
                if (id == "")
                {
                    List.ID = List.InsertData();
                }
                else
                {
                    List.ID = int.Parse(id);
                    List.UpdateData(List.ID);
                }

            }
            else
            {
                List.GetData(TextBoxbaocunnocol53.Text);
                if (List.ID > 0)
                {
                    TextBoxbaocunnocol53.Text = CreateNext2();
                }
                List.InsertData();
            }

            hdNo.Text = List.col53.ToString();
            zhuangtaiList list2 = new zhuangtaiList();
            string sql2 = "select * from t_zhuangtai where col1='" + TextBoxbaocunnocol53.Text + "' and col2='" + List.col55 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = TextBoxbaocunnocol53.Text;
                list2.col2 = List.col55;
                list2.col3 = "";
                list2.InsertData();
            }



            string ID = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + List.col53 + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ID = ds.Tables[0].Rows[0]["ID"].ToString();
                hdNo2.Text = ID;
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

            //财务管理》发票管理 
            //caiwu3List List发票 = new caiwu3List();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //List.col30 = ((Label)GridView1.Rows[i].FindControl("lblcol30")).Text.Trim();
                //List.col31 = ((Label)GridView1.Rows[i].FindControl("lblcol31")).Text.Trim();
                //List.col32 = ((Label)GridView1.Rows[i].FindControl("lblcol32")).Text.Trim();
                //List.col33 = ((Label)GridView1.Rows[i].FindControl("lblcol33")).Text.Trim();
                //List.col34 = ((Label)GridView1.Rows[i].FindControl("lblcol34")).Text.Trim();
                //List.col35 = ((Label)GridView1.Rows[i].FindControl("lblcol35")).Text.Trim();
                //List.col36 = ((Label)GridView1.Rows[i].FindControl("lblcol36")).Text.Trim();
                //List.col37 = ((Label)GridView1.Rows[i].FindControl("lblcol37")).Text.Trim();
                //List.col38 = ((Label)GridView1.Rows[i].FindControl("lblcol38")).Text.Trim();
                //List.col39 = ((Label)GridView1.Rows[i].FindControl("lblcol39")).Text.Trim();
                //List.col40 = ((Label)GridView1.Rows[i].FindControl("lblcol40")).Text.Trim();
                //List.col41 = ((Label)GridView1.Rows[i].FindControl("lblcol41")).Text.Trim();
                //List.col42 = ((Label)GridView1.Rows[i].FindControl("lblcol42")).Text.Trim();
                //List.col43 = ((Label)GridView1.Rows[i].FindControl("lblcol43")).Text.Trim();
                //List.col44 = ((Label)GridView1.Rows[i].FindControl("lblcol44")).Text.Trim();
                //List.col45 = ((Label)GridView1.Rows[i].FindControl("lblcol45")).Text.Trim();
                //List.col46 = ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim();
                //List.col47 = ((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim();
                //List.col48 = ((Label)GridView1.Rows[i].FindControl("lblcol48")).Text.Trim();
                ttcol17 += "'" + ((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim() + "'" + ",";
                ttcol18 = ((Label)GridView1.Rows[i].FindControl("lblcol48")).Text.Trim();

                amount1 += Convert.ToDecimal(((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim() == "" ? "0" : ((Label)GridView1.Rows[i].FindControl("lblcol46")).Text.Trim());


            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                caiwu1List.col18 = hdNo.Text;
                caiwu1List.col19 = DateTime.Now.ToString("yyyyMMdd");
                caiwu1List.col20 = hdNo2.Text;
                caiwu1List.col32 = "1";
                caiwu1List.col39 = Dropdown申请发票类型.Text.Trim();
                caiwu1List.col40 = Dropdown申请发票类别.Text.Trim();
                caiwu1List.col41 = txt申请人.Text;
                caiwu1List.col42 = TextBox申请日期.Text;
                caiwu1List.col49 = Drop合同类型.Text;


                caiwu1List.UpdateData2(((Label)GridView1.Rows[i].FindControl("lblcol47")).Text.Trim());

            }

            if (GridView1.Rows.Count == 0)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "开票明细至少要有一条数据才能提交！");
                return;
            }

            if (model2 == "税额")
            {
                base.Response.Redirect("caiwu31.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            else
            {
                base.Response.Redirect("caiwu3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            string model2 = base.Request.QueryString["model2"];
            
            if (model2 == "税额")
            {
                base.Response.Redirect("caiwu31.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            else if (model2 == "caiwu32")
            {
                base.Response.Redirect("caiwu32.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
            }
            else
            {
                string model22 = base.Request.QueryString["model22"];

                if (model22 == "shouye")
                {
                    base.Response.Redirect("shouye.aspx");
                }
                else
                {
                    base.Response.Redirect("caiwu3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
                }
                
            }
        }

        protected void btn导出_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "开票管理明细" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
          
            DataTable downloadTable = new DataTable();

            
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A01");

            downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");

            //downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A22");
            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");
            downloadTable.Columns.Add("A25");
            downloadTable.Columns.Add("A26");
            downloadTable.Columns.Add("A27");
            downloadTable.Columns.Add("A28");
            downloadTable.Columns.Add("A29");
            downloadTable.Columns.Add("A30");
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A32");

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
               
                dr["A1"] = hdNo.Text;
                dr["A01"] = i + 1;

                dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();
                dr["A12"] = dtAll.Rows[i]["col11"].ToString();
                dr["A13"] = dtAll.Rows[i]["col12"].ToString();
                dr["A14"] = dtAll.Rows[i]["col13"].ToString();
                dr["A15"] = dtAll.Rows[i]["col14"].ToString();
                dr["A16"] = dtAll.Rows[i]["col15"].ToString();
                dr["A17"] = dtAll.Rows[i]["col16"].ToString();
                dr["A18"] = dtAll.Rows[i]["col45"].ToString();
                dr["A19"] = dtAll.Rows[i]["col46"].ToString();
               
                dr["A22"] = dtAll.Rows[i]["col21"].ToString();
                dr["A23"] = dtAll.Rows[i]["col22"].ToString();
                dr["A24"] = dtAll.Rows[i]["col23"].ToString();
                dr["A25"] = dtAll.Rows[i]["col24"].ToString();
                dr["A26"] = dtAll.Rows[i]["col25"].ToString();
                dr["A27"] = dtAll.Rows[i]["col26"].ToString();
                dr["A28"] = dtAll.Rows[i]["col27"].ToString();
                dr["A29"] = dtAll.Rows[i]["col28"].ToString();
                dr["A30"] = dtAll.Rows[i]["col29"].ToString();
                dr["A31"] = dtAll.Rows[i]["col30"].ToString();
                dr["A32"] = dtAll.Rows[i]["col31"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/开票管理明细下载模板.xlsx", downloadTable, str);
        }

        protected void btn新增一行_Click(object sender, EventArgs e)
        {
            

            hdNo.Text = hdNo.Text == "" ? CreateNext() : hdNo.Text;
            string idno = base.Request.QueryString["idno"] == null ? hdNo2.Text : base.Request.QueryString["idno"].ToString();
            Response.Redirect("caiwu2Add.aspx?id=" + hdNo.Text + "&idno=" + idno, false);
        }

        protected void btn审核通过_Click(object sender, EventArgs e)
        {
            if (this.TextBox审批说明情况.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审批说明情况");
                return;
            }
            zhuangtaiList list2 = new zhuangtaiList();
            string str1 = TextBoxbaocunnocol53.Text;

            //审批状态
            OledbHelper oledbHelper = new OledbHelper();
            string str审核人员 = string.Empty;
            string str新审核人员 = string.Empty;
            string sql审核人员 = "select * from t_shenhe where 1=1 and col2 = '" + this.Session["FullName"].ToString() + "' ";
            DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            if (dt审核人员.Rows.Count > 0)
            {
                str审核人员 = dt审核人员.Rows[0]["col1"].ToString();
                int new审核 = int.Parse(str审核人员) + 1;
                sql审核人员 = "select * from t_shenhe where 1=1 and col1 = '" + new审核 + "' ";
                DataTable dt审核人员2 = oledbHelper.GetDataTable(sql审核人员);
                if (dt审核人员2.Rows.Count > 0)
                {
                    str新审核人员 = dt审核人员2.Rows[0]["col2"].ToString();
                }
            }
            string str新审核人员1 = string.Empty;
            if (str新审核人员 != "")
            {
                str新审核人员1 = ";" + str新审核人员 + "未审批";
            }

            string str2 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "审核通过" + str新审核人员1;
            string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = str1;
                list2.col2 = str2;
                list2.col3 = this.TextBox审批说明情况.Text.Trim();
                list2.InsertData();
            }

            caiwu2List List = new caiwu2List();
            List.col55 = str2;
            List.col33 = "正常";
            List.col66 = this.TextBox审批说明情况.Text.Trim();
            List.col62 = str新审核人员;
            List.col63 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            List.UpdateDatashenhe(int.Parse(this.ViewState["IDNO"].ToString()));
            base.Response.Redirect("caiwu3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn审核不通过_Click(object sender, EventArgs e)
        {
            if (this.TextBox审批说明情况.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写审批说明情况");
                return;
            }
            zhuangtaiList list2 = new zhuangtaiList();
            string str1 = TextBoxbaocunnocol53.Text;

            ////审批状态
            //OledbHelper oledbHelper = new OledbHelper();

            //string str审核人员 = string.Empty;
            //string str新审核人员 = string.Empty;
            //string sql审核人员 = "select * from t_shenhe where 1=1 and col2 = '" + this.Session["FullName"].ToString() + "' ";
            //DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            //if (dt审核人员.Rows.Count > 0)
            //{
            //    str审核人员 = dt审核人员.Rows[0]["col1"].ToString();
            //    int new审核 = int.Parse(str审核人员) - 1;
            //    sql审核人员 = "select * from t_shenhe where 1=1 and col1 = '" + new审核 + "' ";
            //    DataTable dt审核人员2 = oledbHelper.GetDataTable(sql审核人员);
            //    if (dt审核人员2.Rows.Count > 0)
            //    {
            //        str新审核人员 = dt审核人员2.Rows[0]["col2"].ToString();
            //    }
            //}
            //if (str新审核人员 != "")
            //{
            //    str新审核人员 = ";" + str新审核人员 + "未审批";
            //}

            string str2 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日 HH:mm分") + "审核不通过" + ";" + txt申请人.Text + "继续修改!";
            string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = str1;
                list2.col2 = str2;
                list2.col3 = this.TextBox审批说明情况.Text.Trim();
                list2.InsertData();
            }

            caiwu2List List = new caiwu2List();
            List.col55 = str2;
            List.col33 = "正常";
            List.col66 = this.TextBox审批说明情况.Text.Trim();
            List.col62 = this.Session["FullName"].ToString();
            List.col63 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            List.UpdateDatashenhe(int.Parse(this.ViewState["IDNO"].ToString()));
            base.Response.Redirect("caiwu3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn确定开票_Click(object sender, EventArgs e)
        {
            //zhuangtaiList list2 = new zhuangtaiList();
            string str1 = TextBoxbaocunnocol53.Text;
            //string str2 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日") +"确定开票";
            //string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            //DataSet ds2 = Sql.SqlQueryDS(sql2);
            //if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            //{

            //}
            //else
            //{
            //    list2.col1 = str1;
            //    list2.col2 = str2;
            //    list2.InsertData();
            //}

            //caiwu2List List = new caiwu2List();
            //List.col55 = str2;
            //List.col33 = "正常";
            //List.col62 = this.Session["FullName"].ToString();
            //List.col63 = TextBox审核人.Text + "," + this.Session["FullName"].ToString();
            //List.UpdateDatashenhe(int.Parse(this.ViewState["IDNO"].ToString()));
       
            Response.Redirect("caiwu3Add.aspx?idno=" + str1, false);
        }

        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox开票申请表附件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox开票申请表附件.Text = "";
                开票申请表附件href.HRef = "";
                开票申请表附件href.InnerText = "";
                btnAttach.Visible = false;
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox税票扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox税票扫描件.Text = "";
                税票扫描件href.HRef = "";
                税票扫描件href.InnerText = "";
                LinkButton4.Visible = false;
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




       
    }
}