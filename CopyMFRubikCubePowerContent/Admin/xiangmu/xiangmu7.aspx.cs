using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using System.IO;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class xiangmu7 : System.Web.UI.Page
    {

        public string Request_temp1
        {
            get { return Request.Params.Get("temp1"); }
        }
        public string Request_temp2
        {
            get { return Request.Params.Get("temp2"); }
        }
        public string Request_temp3
        {
            get { return Request.Params.Get("temp3"); }
        }
        public string Request_temp4
        {
            get { return Request.Params.Get("temp4"); }
        }
        public string Request_temp5
        {
            get { return Request.Params.Get("temp5"); }
        }
        public string Request_temp6
        {
            get { return Request.Params.Get("temp6"); }
        }
        public string Request_temp7
        {
            get { return Request.Params.Get("temp7"); }
        }
        public int memoryPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;

                if (Request_temp1 != null && !string.Empty.Equals(Request_temp1))
                {
                    this.txtcol1.Text = Request_temp1;
                }
                if (Request_temp2 != null && !string.Empty.Equals(Request_temp2))
                {
                    this.txtcol2.Text = Request_temp2;
                }
                if (Request_temp3 != null && !string.Empty.Equals(Request_temp3))
                {
                    this.txtcol3.Text = Request_temp3;
                }
                if (Request_temp4 != null && !string.Empty.Equals(Request_temp4))
                {
                    this.txtcol4.Text = Request_temp4;
                }
                if (Request_temp5 != null && !string.Empty.Equals(Request_temp5))
                {
                    this.txtcol5.Text = Request_temp5;
                }
                if (Request_temp6 != null && !string.Empty.Equals(Request_temp6))
                {
                    this.txtcol6.Text = Request_temp6;
                }
                if (Request_temp7 != null && !string.Empty.Equals(Request_temp7))
                {

                    memoryPage = int.Parse(Request_temp7);
                }
                this.GridBind();

            }
            else
            {
                AlertDiv.InnerHtml = "";
            }
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");

            if (this.Session["RoleValue"].ToString() == "1")
            {
                //Button1.Visible = true;
                //Button5.Visible = true;
            }
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

            hdtemp.Text = "";
            DataTable dataSource2 = oledbHelper.GetDataTable("select xiangmu from User_List where UserName = '" + this.Session["UserName"] + "'  ");
            if (dataSource2.Rows.Count > 0)
            {
                string[] tep = dataSource2.Rows[0][0].ToString().Split(',');
                for (int k = 0; k < tep.Length; k++)
                {
                    if (tep[k].ToString() == "")
                    {
                        continue;
                    }
                    hdtemp.Text += "'" + tep[k].ToString() + "'" + ",";
                }
                if (hdtemp.Text != null && hdtemp.Text.EndsWith(","))
                    hdtemp.Text = hdtemp.Text.Substring(0, hdtemp.Text.Length - 1);

            }

        }



        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "(select t_caiwu22.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_caiwu22 inner join t_hetong on  t_caiwu22.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2)";
            
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 and t_caiwu22.col32='1' and t_caiwu22.col38='1' and t_caiwu22.col50='审核通过' ");
            string sql = "select * from (select t_caiwu22.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_caiwu22 inner join t_hetong on  t_caiwu22.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2) where 1= 1  and t_caiwu22.col32='1' and t_caiwu22.col38='1' and t_caiwu22.col50='审核通过'  ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and t_caiwu22.col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and t_caiwu22.col4 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and t_caiwu22.col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and t_caiwu22.col5 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and t_caiwu22.col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and t_caiwu22.col1 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and t_caiwu22.col8 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and t_caiwu22.col8 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and t_caiwu22.col7 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and t_caiwu22.col7 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and t_caiwu22.col9 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and t_caiwu22.col9 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and (t_caiwu22.col19 = '" + this.Session["FullName"].ToString() + "' or t_caiwu22.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
                sql += " and (t_caiwu22.col19 = '" + this.Session["FullName"].ToString() + "' or t_caiwu22.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            }
            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (col19 = '" + this.Session["FullName"].ToString() + "' or col6 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (col19 = '" + this.Session["FullName"].ToString() + "' or col6 in (" + hdtemp.Text + ") ) ";

            //}


            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable(memoryPage);
            this.GridView1.DataBind();
        }

        protected void btn查询_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        protected void btn查看_Click(object sender, EventArgs e)
        {

            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    Response.Redirect("xiangmu2Add.aspx?id=" + tickedFormNo + "", false);
                    break;
                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }


        }

        protected void btn资料打回_Click(object sender, EventArgs e)
        {
            caiwu22List xiangmu1List = new caiwu22List();
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    xiangmu1List.UpdateDataziliao2(int.Parse(tickedFormNo));

                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }
            this.GridBind();
        }

        protected void btn资料审核_Click(object sender, EventArgs e)
        {
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    Response.Redirect("xiangmu2Add.aspx?id=" + tickedFormNo + "&&model=shenhe ", false);
                    break;
                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu5.aspx", false);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "项目资料管理" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
            //GridBind("download");
            //DownloadHtmlExcelFile(GridView1, str, null);
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
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A22");
            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");
            downloadTable.Columns.Add("A25");
            downloadTable.Columns.Add("A26");
            downloadTable.Columns.Add("A27");

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                dr["A4"] = dtAll.Rows[i]["col3"].ToString();

                dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();
                dr["A12"] = dtAll.Rows[i]["col11"].ToString();
                dr["A13"] = dtAll.Rows[i]["col12"].ToString();
                dr["A14"] = dtAll.Rows[i]["col16"].ToString();
                dr["A15"] = dtAll.Rows[i]["col17"].ToString();
                dr["A16"] = dtAll.Rows[i]["col18"].ToString();
                dr["A17"] = dtAll.Rows[i]["col19"].ToString();
                dr["A18"] = dtAll.Rows[i]["col20"].ToString();
                dr["A19"] = dtAll.Rows[i]["col21"].ToString();
                dr["A20"] = dtAll.Rows[i]["col22"].ToString();
                dr["A21"] = dtAll.Rows[i]["col23"].ToString();
                dr["A22"] = dtAll.Rows[i]["col24"].ToString();
                dr["A23"] = dtAll.Rows[i]["col25"].ToString();
                dr["A24"] = dtAll.Rows[i]["col26"].ToString();
                dr["A25"] = dtAll.Rows[i]["col13"].ToString();
                dr["A26"] = dtAll.Rows[i]["col14"].ToString();
                dr["A27"] = dtAll.Rows[i]["col15"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目资料管理下载模板.xlsx", downloadTable, str);
        }


        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            if (this.ViewState["OrderByKey"].ToString() == sortExpression)
            {
                if ((bool)this.ViewState["OrderByType"])
                {
                    this.ViewState["OrderByType"] = false;
                }
                else
                {
                    this.ViewState["OrderByType"] = true;
                }
            }
            else
            {
                this.ViewState["OrderByKey"] = e.SortExpression;
            }
            this.GridBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strid = ((Label)e.Row.FindControl("lblID")).Text;

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol1")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "xiangmu2Add.aspx?id=" + strid + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;

                if (((Label)e.Row.FindControl("lbl发票扫描件")).Text.Trim() == "")
                {

                    ((CheckBox)e.Row.FindControl("Chk发票扫描件")).Visible = false;
                    ((HyperLink)e.Row.FindControl("HyperLinkcol26")).Visible = false;
                    ((Label)e.Row.FindControl("Label发票扫描件")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl采购订单扫描件")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk采购订单扫描件")).Visible = false;
                    ((HyperLink)e.Row.FindControl("HyperLinkcol27")).Visible = false;
                    ((Label)e.Row.FindControl("Label采购订单扫描件")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl完工结算证明扫描件")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk完工结算证明扫描件")).Visible = false;
                    ((HyperLink)e.Row.FindControl("HyperLinkcol28")).Visible = false;
                    ((Label)e.Row.FindControl("Label完工结算证明扫描件")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl审计定案扫描件")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk审计定案扫描件")).Visible = false;
                    ((HyperLink)e.Row.FindControl("HyperLinkcol29")).Visible = false;
                    ((Label)e.Row.FindControl("Label审计定案扫描件")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl竣工资料及图纸附件")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk竣工资料及图纸附件")).Visible = false;
                    ((HyperLink)e.Row.FindControl("HyperLinkcol30")).Visible = false;
                    ((Label)e.Row.FindControl("Label竣工资料及图纸附件")).Visible = true;
                }

                //((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;


                if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol2")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 150;
                }

                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol7")).Width = 100;
                }

                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol15")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol15")).Width = 150;
                }

                ((Label)e.Row.FindControl("lblcol34")).Text = ((Label)e.Row.FindControl("lblcol34")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol34")).Text).ToString("F2");
                if (((Label)e.Row.FindControl("lblcol341")).Text.Trim() != "")
                {
                    if (((Label)e.Row.FindControl("lblcol341")).Text.Trim().Contains("%"))
                    {
                        ((Label)e.Row.FindControl("lblcol341")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol341")).Text.Replace("%", "")) / 100).ToString("F2");
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblcol341")).Text = Convert.ToDecimal(((Label)e.Row.FindControl("lblcol341")).Text).ToString("F2");
                    }
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

                //((Label)e.Row.FindControl("lblcol341")).Text = ((Label)e.Row.FindControl("lblcol341")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol341")).Text).ToString("F2");
                ((Label)e.Row.FindControl("lblcol351")).Text = ((Label)e.Row.FindControl("lblcol351")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol351")).Text).ToString("F2");
                ((Label)e.Row.FindControl("lblcol342")).Text = ((Label)e.Row.FindControl("lblcol342")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol342")).Text).ToString("F2");
                //if (((Label)e.Row.FindControl("lblcol343")).Text.Trim() != "")
                //{
                //    if (((Label)e.Row.FindControl("lblcol343")).Text.Trim().Contains("%"))
                //    {
                //        ((Label)e.Row.FindControl("lblcol343")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol343")).Text.Replace("%", "")) / 100).ToString("F2");
                //    }
                //    else
                //    {
                //        ((Label)e.Row.FindControl("lblcol343")).Text = Convert.ToDecimal(((Label)e.Row.FindControl("lblcol343")).Text).ToString("F2");
                //    }
                //}
                if (((Label)e.Row.FindControl("lblcol352")).Text.Trim() != "")
                {
                    if (((Label)e.Row.FindControl("lblcol352")).Text.Trim().Contains("%"))
                    {
                        //((Label)e.Row.FindControl("lblcol352")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol352")).Text.Replace("%", "")) / 100).ToString("F2");
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblcol352")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol352")).Text) * 100).ToString("F0") + "%";
                    }
                }
                //((Label)e.Row.FindControl("lblcol343")).Text = ((Label)e.Row.FindControl("lblcol343")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol343")).Text).ToString("F2");
                //((Label)e.Row.FindControl("lblcol353")).Text = ((Label)e.Row.FindControl("lblcol353")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol353")).Text).ToString("F2");


            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
            if (e.CommandName == "lbtn11")
            {
                string tempfilename = "发票扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu21", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "采购订单扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu22", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn13")
            {
                string tempfilename = "完工结算证明扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu23", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn14")
            {
                string tempfilename = "审计定案扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu24", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn15")
            {
                string tempfilename = "竣工资料及图纸附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu25", rowIDs, tempfilename);
            }
        }

        //批量下载
        protected void btnDownLoad_Click(string str1, string str2, string str3)
        {
            string sourcePath = "";
            string savePath = "";
            Dictionary<string, Stream> streams = new Dictionary<string, Stream>();
            Stream streamWriter = null;
            int counts = 1000;

            DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + str1 + "' and col1='" + str2 + "' ");
            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
            {
                for (int kkk = 0; kkk < ds2.Tables[0].Rows.Count; kkk++)
                {
                    savePath = ds2.Tables[0].Rows[kkk]["col3"].ToString().Trim();
                    sourcePath = ds2.Tables[0].Rows[kkk]["col3"].ToString().Trim();
                    if (sourcePath != "")
                    {
                        string[] str11 = sourcePath.Split('/');
                        for (int k = 0; k < str11.Length; k++)
                        {
                            sourcePath = str11[str11.Length - 1].ToString();
                            savePath = "公司证件UploadFile/" + str11[str11.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }
                }

            }

            MemoryStream ms = new MemoryStream();
            ms = PackageManyZip(streams);
            byte[] bytes = new byte[(int)ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(str3, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();


        }

        static MemoryStream PackageManyZip(Dictionary<string, Stream> streams)
        {
            byte[] buffer = new byte[65000];
            MemoryStream returnStream = new MemoryStream();
            var zipMs = new MemoryStream();
            using (ZipOutputStream zipStream = new ZipOutputStream(zipMs))
            {
                zipStream.SetLevel(9);
                foreach (var kv in streams)
                {
                    string fileName = kv.Key.Substring(4, kv.Key.Length - 4);
                    using (var streamInput = kv.Value)
                    {
                        zipStream.PutNextEntry(new ZipEntry(fileName));
                        while (true)
                        {
                            var readCount = streamInput.Read(buffer, 0, buffer.Length);
                            if (readCount > 0)
                            {
                                zipStream.Write(buffer, 0, readCount);
                            }
                            else
                            {
                                break;
                            }
                        }
                        zipStream.Flush();
                    }
                }
                zipStream.Finish();
                zipMs.Position = 0;
                zipMs.CopyTo(returnStream, 56000);
            }
            returnStream.Position = 0;
            return returnStream;
        }


        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", message);
            return;
        }

    }
}