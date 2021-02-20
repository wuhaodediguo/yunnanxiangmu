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
    public partial class hezuo4 : System.Web.UI.Page
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
            adminPager.TableName = "(SELECT col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24,max(ID) as ID FROM t_hezuo4 group by col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24)";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1  ");
            string sql = "SELECT * from (SELECT col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24,max(ID) as ID FROM t_hezuo4 group by col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24) where 1= 1  ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col2 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and col3 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and col3 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col7 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col7 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and col5 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col6 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and col6 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            //if (this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and col20 = '" + this.Session["FullName"].ToString() + "' ");
            //    sql += " and col20 = '" + this.Session["FullName"].ToString() + "' ";
            //}
            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and ( col1 in (" + hdtemp.Text + ") )  ");
                sql += " and ( col1 in (" + hdtemp.Text + ") ) ";

            }

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            Decimal d1 = 0;
            Decimal d2 = 0;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                d1 += dtAll.Rows[i]["col9"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col9"].ToString());
            }
            Label合计1.Text = "结算金额含税总计: " + (d1.ToString("F2") == "0.00" ? "0" : d1.ToString("F2"));

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("hezuo4Add.aspx?id=" + "" + "", false);
        }

        protected void btn编辑_Click(object sender, EventArgs e)
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol11")).Text;
                    string str项目经理 = ((Label)GridView1.Rows[k].FindControl("lblcol1")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(str项目经理))
                    {
                        SetWarningMessage("不能修改其他人创建的结算明细！");
                        return;
                    }
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    string strid2 = ((Label)GridView1.Rows[k].FindControl("lblID2")).Text;

                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();



                    Response.Redirect("hezuo4Add.aspx?idno=" + tickedFormNo + "&id=" + strid2 + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "", false);
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

        protected void btn删除_Click(object sender, EventArgs e)
        {
            hezuo4List hezuo4List = new hezuo4List();
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol11")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能删除其他人创建的结算明细！");
                        return;
                    }
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    hezuo4List.DeleteData(int.Parse(tickedFormNo));
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

        protected void btnExport_Click(object sender, EventArgs e)
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

            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");

            downloadTable.Columns.Add("A6");
            downloadTable.Columns.Add("A7");
            downloadTable.Columns.Add("A8");
            //downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
            
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");

            downloadTable.Columns.Add("A11");
            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                dr["A4"] = dtAll.Rows[i]["col3"].ToString();

                dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                dr["A23"] = dtAll.Rows[i]["col23"].ToString();
                dr["A24"] = dtAll.Rows[i]["col24"].ToString();

                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                //dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();
                dr["A20"] = dtAll.Rows[i]["col20"].ToString();
                dr["A21"] = dtAll.Rows[i]["col21"].ToString();
                dr["A17"] = dtAll.Rows[i]["col17"].ToString();
                dr["A18"] = dtAll.Rows[i]["col18"].ToString();
                dr["A19"] = dtAll.Rows[i]["col19"].ToString();
               
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/施工队结算明细下载模板.xlsx", downloadTable, str);
        }

        protected void btnExport2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * from t_hezuo4 where 1= 1  ";
            if (this.txtcol1.Text.Trim() != "")
            {
               
                sql += " and col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
              
                sql += " and col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
               
                sql += " and col3 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                
                sql += " and col7 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                
                sql += " and col5 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                
                sql += " and col6 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }
            sql += " order by col1,col2,col3,col4,col5,col6,col7,col8,col9,col17,col18,col19,col20,col21,col22,col11 ";

            OledbHelper oledbHelper = new OledbHelper();

            DataTable dtAll = oledbHelper.GetDataTable(sql);

           
            DateTime dt = System.DateTime.Now;
            string str = "施工队结算明细" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";

            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A5");

            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");

            downloadTable.Columns.Add("A6");
            downloadTable.Columns.Add("A7");
            downloadTable.Columns.Add("A8");
            //downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
           
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A111");
            


            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                dr["A4"] = dtAll.Rows[i]["col3"].ToString();

                dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                dr["A23"] = dtAll.Rows[i]["col23"].ToString();
                dr["A24"] = dtAll.Rows[i]["col24"].ToString();

                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                //dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A111"] = dtAll.Rows[i]["col10"].ToString();
                dr["A20"] = dtAll.Rows[i]["col20"].ToString();
                dr["A21"] = dtAll.Rows[i]["col21"].ToString();
                dr["A17"] = dtAll.Rows[i]["col17"].ToString();
                dr["A18"] = dtAll.Rows[i]["col18"].ToString();
                dr["A19"] = dtAll.Rows[i]["col19"].ToString();

                dr["A11"] = dtAll.Rows[i]["col11"].ToString();
                dr["A12"] = dtAll.Rows[i]["col12"].ToString();
                dr["A13"] = dtAll.Rows[i]["col13"].ToString();
                dr["A14"] = dtAll.Rows[i]["col14"].ToString();
                dr["A15"] = dtAll.Rows[i]["col15"].ToString();
                dr["A16"] = dtAll.Rows[i]["col16"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/施工队结算管理下载模板2.xlsx", downloadTable, str);
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuan4.aspx?id=" + "hezuo1" + "", false);

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
                //if (((Label)e.Row.FindControl("lbl施工队单项工程结算电子档附件")).Text.Trim() == "")
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol17")).Visible = false;
                //    ((Label)e.Row.FindControl("Label施工队单项工程结算电子档附件")).Visible = true;
                //}
                //if (((Label)e.Row.FindControl("lbl施工队单项工程结算签字扫描附件")).Text.Trim() == "")
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol18")).Visible = false;
                //    ((Label)e.Row.FindControl("Label施工队单项工程结算签字扫描附件")).Visible = true;
                //}
                //if (((Label)e.Row.FindControl("lbl施工队合同扫描件")).Text.Trim() == "")
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol19")).Visible = false;
                //    ((Label)e.Row.FindControl("Label施工队合同扫描件")).Visible = true;
                //}

                if (((Label)e.Row.FindControl("lbl施工队单项工程结算电子档附件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label施工队单项工程结算电子档附件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label施工队单项工程结算电子档附件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl施工队单项工程结算签字扫描附件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label施工队单项工程结算签字扫描附件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label施工队单项工程结算签字扫描附件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl施工队合同扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = true;
                    ((Label)e.Row.FindControl("Label施工队合同扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;
                    ((Label)e.Row.FindControl("Label施工队合同扫描件")).Visible = true;
                }

                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                string strid2 = ((Label)e.Row.FindControl("lblID2")).Text;

                string temp1 = txtcol1.Text.Trim();
                string temp2 = txtcol2.Text.Trim();
                string temp3 = txtcol3.Text.Trim();
                string temp4 = txtcol4.Text.Trim();
                string temp5 = txtcol5.Text.Trim();
                string temp6 = txtcol6.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol7")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "hezuo4Add.aspx?idno=" + strid + "&id=" + strid2 + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol23")).Width = ((((Label)e.Row.FindControl("lblcol23")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol23")).Width : (((Label)e.Row.FindControl("lblcol23")).Text.Trim().Length * 12));
                ((Label)e.Row.FindControl("lblcol24")).Width = ((((Label)e.Row.FindControl("lblcol24")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol24")).Width : (((Label)e.Row.FindControl("lblcol24")).Text.Trim().Length * 12));

                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 110)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 110)
                {
                    ((Label)e.Row.FindControl("lblcol7")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 110)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol23")).Width.Value < 110)
                {
                    ((Label)e.Row.FindControl("lblcol23")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol24")).Width.Value < 110)
                {
                    ((Label)e.Row.FindControl("lblcol24")).Width = 110;
                }

                ((Label)e.Row.FindControl("lblcol9")).Text = ((Label)e.Row.FindControl("lblcol9")).Text == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol9")).Text.ToString()).ToString("F2");

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
                string tempfilename = "施工队长身份证件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("hezuo21", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "施工队长照片" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("hezuo22", rowIDs, tempfilename);
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