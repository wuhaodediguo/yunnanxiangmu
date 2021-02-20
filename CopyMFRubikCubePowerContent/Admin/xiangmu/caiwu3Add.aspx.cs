using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Data;
using System.Web.UI;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using MojoCube.Api.File;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class caiwu3Add : System.Web.UI.Page
    {
        public decimal amount1 = 0;
        public decimal amount5 = 0;
        public decimal amount6 = 0;
        public decimal amount7 = 0;
        public decimal amount8 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                
                TextBox开票申请单号.Attributes.Add("readOnly", "readOnly");

                if (base.Request.QueryString["idno"] != null)
                {
                    string id1 = base.Request.QueryString["idno"].ToString();

                   
                    if (id1 == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["idno"].ToString();
                    TextBox开票申请单号.Text = base.Request.QueryString["idno"].ToString();
                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu3 where col8='" + id1 + "' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        this.GridView1.DataSource = ds.Tables[0];
                        this.GridView1.DataBind();
                        ViewState["GridDataSource"] = ds.Tables[0];

                        //if (TextBox发票记账联扫描件.Text != "")
                        //{
                        //    发票记账联扫描件href.HRef = TextBox发票记账联扫描件.Text;
                        //    发票记账联扫描件href.Visible = true;
                        //    var temp = TextBox发票记账联扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            发票记账联扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    btnAttach.Visible = true;
                        //}
                        //if (TextBox发票发票联扫描件.Text != "")
                        //{
                        //    发票发票联扫描件href.HRef = TextBox发票发票联扫描件.Text;
                        //    发票发票联扫描件href.Visible = true;
                        //    var temp = TextBox发票发票联扫描件.Text;
                        //    if (temp != "")
                        //    {
                        //        var temps = temp.LastIndexOf("/");
                        //        if (temps > 0)
                        //        {
                        //            var temps2 = temp.Substring(temps);
                        //            发票发票联扫描件href.InnerText = temps2;
                        //        }

                        //    }
                        //    LinkButton1.Visible = true;
                        //}
                        DataSet ds22 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu32' and col1='" + id1 + "' ");
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

                        DataSet ds23 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu33' and col1='" + id1 + "' ");
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
                    else
                    {
                        DataTable dt = new DataTable("column");
                        DataRow dr;

                        dt.Columns.Add("col1");
                        dt.Columns.Add("col2");
                        dt.Columns.Add("col3");
                        dt.Columns.Add("col4");
                        dt.Columns.Add("col5");
                        dt.Columns.Add("col6");
                        dt.Columns.Add("col7");

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

                    dt.Columns.Add("col1");
                    dt.Columns.Add("col2");
                    dt.Columns.Add("col3");
                    dt.Columns.Add("col4");
                    dt.Columns.Add("col5");
                    dt.Columns.Add("col6");
                    dt.Columns.Add("col7");

                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    ViewState["GridDataSource"] = dt;
                }

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    this.GridView1.Enabled = false;
                    btnDownloadTemplate.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = false;
                    Button4.Visible = false;
                    divUpload.Visible = false;
                    btnAttach.Visible = false;
                    LinkButton1.Visible = false;
                }



            }
            else
            {
                this.AlertDiv.InnerHtml = "";
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


        private void GetDetail()
        {
            string Message = string.Empty;

            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("col1");
            dtnew.Columns.Add("col2");
            dtnew.Columns.Add("col3");
            dtnew.Columns.Add("col4");
            dtnew.Columns.Add("col5");
            dtnew.Columns.Add("col6");
            dtnew.Columns.Add("col7");

            DataRow dr;

            var a = GridView1.PageIndex;
            var aa = GridView1.PageCount;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim() == "" && ((TextBox)GridView1.Rows[i].FindControl("txtcol16")).Text.ToString().Trim() == "")
                {
                    continue;
                }
                dr = dtnew.NewRow();
                dr["col1"] = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
                dr["col2"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString();
                dr["col3"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString();
                dr["col4"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString();
                dr["col5"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString();

                dr["col6"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol16")).Text.ToString();
                dr["col7"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol17")).Text.ToString();
                
                dtnew.Rows.Add(dr);
            }

            ViewState["GridDataSource"] = dtnew;

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                amount1++;
                amount5 += ((TextBox)e.Row.FindControl("txtcol13")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol13")).Text.Trim());
                if (((TextBox)e.Row.FindControl("txtcol14")).Text.Trim().Contains("%"))
                {
                    ((TextBox)e.Row.FindControl("txtcol14")).Text = (Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text.Replace("%","")) / 100).ToString();
                }

                if (amount1 == 1)
                {
                    amount6 = ((TextBox)e.Row.FindControl("txtcol14")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text.Trim());
                }
                if (((TextBox)e.Row.FindControl("txtcol14")).Text != "")
                {
                    ((TextBox)e.Row.FindControl("txtcol14")).Text = Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol14")).Text) * 100 + "%";
                }
                
                amount7 += ((TextBox)e.Row.FindControl("txtcol15")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol15")).Text.Trim());
                amount8 += ((TextBox)e.Row.FindControl("txtcol16")).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)e.Row.FindControl("txtcol16")).Text.Trim());
               
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "<span align='center' style='font-weight:bold;'>合计</span>";
                e.Row.Cells[5].Text = "<span align='center'  style='font-weight:bold;'>" + amount5 + "</span>";
                e.Row.Cells[6].Text = "<span align='center'  style='font-weight:bold;'>" + (100 * amount6).ToString("F0") + "%" + "</span>";
                e.Row.Cells[7].Text = "<span align='center'  style='font-weight:bold;'>" + amount7 + "</span>";
                e.Row.Cells[8].Text = "<span align='center'  style='font-weight:bold;'>" + amount8 + "</span>";

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
                dr["col1"] = i + 1;
                dr["col2"] = "";
                dr["col3"] = "";
                dr["col4"] = "";
                dr["col5"] = "";
                dr["col6"] = "";
                dr["col7"] = "";

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

   

        protected void btn保存_Click(object sender, EventArgs e)
        {
            
            if (this.ViewState["ID"] != null)
            {
                caiwu3List List = new caiwu3List();
                List.DeleteData(TextBox开票申请单号.Text);

                if (this.GridView2.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传发票记账联扫描件");
                    return;
                }
                if (this.GridView3.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请上传发票发票联扫描件");
                    return;
                }

                if (GridView1.Rows.Count == 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "至少要有一条发票明细");
                    return;
                }
                else
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString().Trim() == ""
                            && ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString().Trim() == ""
                            && ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString().Trim() == ""
                            && ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString().Trim() == ""
                            && ((TextBox)GridView1.Rows[i].FindControl("txtcol16")).Text.ToString().Trim() == ""
                            && ((TextBox)GridView1.Rows[i].FindControl("txtcol17")).Text.ToString().Trim() == ""
                            )
                        {
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "至少要有一条发票明细有内容！");
                            return;
                        }
                        List.col1 = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
                        List.col2 = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString();
                        List.col3 = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString();
                        List.col4 = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString();
                        List.col5 = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString();

                        List.col6 = ((TextBox)GridView1.Rows[i].FindControl("txtcol16")).Text.ToString();
                        List.col7 = ((TextBox)GridView1.Rows[i].FindControl("txtcol17")).Text.ToString();
                        List.col8 = TextBox开票申请单号.Text;

                        List.InsertData();
                    }
                }

               

            }

            //
            zhuangtaiList list2 = new zhuangtaiList();
            string str1 = TextBox开票申请单号.Text;
            string str2 = this.Session["FullName"].ToString() + " " + System.DateTime.Now.ToString("yyyy年-MM月-dd日") + "确定开票";
            string sql2 = "select * from t_zhuangtai where col1='" + str1 + "' and col2='" + str2 + "' ";
            DataSet ds2 = Sql.SqlQueryDS(sql2);
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                list2.col1 = str1;
                list2.col2 = str2;
                list2.col3 = "";
                list2.InsertData();
            }

            string tid = string.Empty;
            string TextBox审核人 = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + str1 + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                TextBox审核人 = ds.Tables[0].Rows[0]["col63"].ToString();
                tid = ds.Tables[0].Rows[0]["id"].ToString();
            }

            caiwu2List Listnew = new caiwu2List();
            Listnew.col55 = str2;
            Listnew.col33 = "正常";
            Listnew.col34 = "";

            if (this.GridView2.Rows.Count == 0)
            {
                Listnew.col35 = "0";
            }
            else
            {
                Listnew.col35 = "1";
            }
           
            if (this.GridView3.Rows.Count == 0)
            {
                Listnew.col36 = "0";
            }
            else
            {
                Listnew.col36 = "1";
            }
            //Listnew.col35 = TextBox发票记账联扫描件.Text.Trim();
            //Listnew.col36 = TextBox发票发票联扫描件.Text.Trim();

            Listnew.col62 = this.Session["FullName"].ToString();
            Listnew.col63 = TextBox审核人 + "," + this.Session["FullName"].ToString();
            Listnew.UpdateDatashenhe2(int.Parse(tid));

            Listnew.col31 = this.Session["FullName"].ToString();
            Listnew.col32 = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
            Listnew.UpdateDatakaipiaoshijian(int.Parse(tid));

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string ID = ((Label)GridView2.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = tid.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string ID = ((Label)GridView3.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = tid.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

           
            Response.Redirect("caiwu3.aspx", false);

        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            string tid = string.Empty;
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + TextBox开票申请单号.Text + "' ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                tid = ds.Tables[0].Rows[0]["id"].ToString();
            }

            Response.Redirect("caiwu2.aspx?idno=" + tid + "&id=" + TextBox开票申请单号.Text + "&role=" + "审核", false);
          
        }

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
           

            DataRow dr;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = ((Label)GridView1.Rows[i].FindControl("lbl序号")).Text.ToString();
                dr["A2"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol12")).Text.ToString();
                dr["A3"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol13")).Text.ToString();
                dr["A4"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol14")).Text.ToString();
                dr["A5"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol15")).Text.ToString();
                dr["A6"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol16")).Text.ToString();
                dr["A7"] = ((TextBox)GridView1.Rows[i].FindControl("txtcol17")).Text.ToString();
                dr["A8"] = TextBox开票申请单号.Text.Trim();
                
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/发票号码明细下载模板.xlsx", downloadTable, str);
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

                    List<caiwu3List> caiwu3List = checkUploadData4(dt);

                    StringBuilder errorMsg = new StringBuilder();
                    foreach (caiwu3List item in caiwu3List)
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
                        foreach (caiwu3List item in caiwu3List)
                        {

                            dr = dt2.NewRow();
                            dr["col1"] = i + 1;
                            dr["col2"] = item.col2;
                            dr["col3"] = item.col3;
                            dr["col4"] = item.col4;
                            dr["col5"] = item.col5;
                            dr["col6"] = item.col6;
                            dr["col7"] = item.col7;

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

        protected List<caiwu3List> checkUploadData4(DataTable dt)
        {
            List<caiwu3List> caiwu3List = new List<caiwu3List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                caiwu3List list = new caiwu3List();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[1].ColumnName);
                else
                    list.col2 = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[2].ColumnName);
                else
                    list.col3 = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[3].ColumnName);
                else
                    list.col4 = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[4].ColumnName);
                else
                    list.col5 = dt.Rows[i][4].ToString();

                list.col6 = dt.Rows[i][5].ToString();
                list.col7 = dt.Rows[i][6].ToString();
               
                caiwu3List.Add(list);
            }
            return caiwu3List;
        }

        protected void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string filename = "/Admin/DownLoadTemplates/发票号码明细导入模板.xlsx";
            DownloadTemplateFile downloadTemplateFile = new DownloadTemplateFile();
            downloadTemplateFile.DoFileDownload(filename);
        }

        //基本換頁寫法
        protected void gvDataList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                this.GridView1.DataSource = ViewState["GridDataSource"];
                this.GridView1.DataBind();
               
            }
            catch (Exception ex)
            {
                
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


        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票记账联扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox发票记账联扫描件.Text = "";
                发票记账联扫描件href.HRef = "";
                发票记账联扫描件href.InnerText = "";
                btnAttach.Visible = false;
            }
        }

        protected void btnAttach2_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox发票发票联扫描件.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox发票发票联扫描件.Text = "";
                发票发票联扫描件href.HRef = "";
                发票发票联扫描件href.InnerText = "";
                LinkButton1.Visible = false;
            }
        }

        protected void FileUpload发票记账联扫描件Button_Click(object sender, EventArgs e)
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

                发票记账联扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox发票记账联扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu32";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件2.Value == "" ? CreateNext() : HdCol2附件2.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu32' and col2='" + 附件List.col2 + "' ");
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

        protected void FileUpload发票发票联扫描件Button_Click(object sender, EventArgs e)
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

                发票发票联扫描件href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                TextBox发票发票联扫描件.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "caiwu33";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件3.Value == "" ? CreateNext() : HdCol2附件3.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'caiwu33' and col2='" + 附件List.col2 + "' ");
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



    }
}