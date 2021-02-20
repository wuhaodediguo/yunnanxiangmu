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

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class caiwu5 : System.Web.UI.Page
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
                this.ViewState["OrderByKey"] = "col601,ID";
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
                div收款确认.Visible = true;
               
            }
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


        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "t_caiwu2view2";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 and col55 like '%确定开票%' ");
            string sql = "select * from t_caiwu2view2 where 1= 1 and col55 like '%确定开票%' ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col14 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and col14 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col15 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and col15 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                if (this.txtcol3.Text.Trim().EndsWith("0"))
                {
                    var tee = txtcol3;
                    var tae = this.txtcol3.Text.Trim().Substring(0, this.txtcol3.Text.Trim().Length - 1);
                    where.Append(" and (col666 like '%" + tee + "%' or col666 like '%" + tae + "%')");
                    //arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                    sql += " and (col666 like '%" + tee + "%' or col666 like '%" + tae + "%' ) ";
                }
                else
                {
                    where.Append(" and col666 like '%'+?+'%'");
                    arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                    sql += " and (col666 like '%" + this.txtcol5.Text.Trim() + "%' ) ";
                }
                //where.Append(" and col666 like '%'+?+'%'");
                //arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                //sql += " and col666 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col60 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col60 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col59 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and col59 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }

            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and col4 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and ((col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) and col8 = '施工合同')  ");
                sql += " and ((col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) and col8 = '施工合同') ";

            }
            //if (this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and col1 = '" + this.Session["FullName"].ToString() + "' ");
            //    sql += " and col1 = '" + this.Session["FullName"].ToString() + "' ";
            //}
            sql += "order by col601,id";

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            Decimal d1 = 0;
            Decimal d2 = 0;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                d1 += dtAll.Rows[i]["col666"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col666"].ToString());
                d2 += dtAll.Rows[i]["col59"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col59"].ToString());
            }
            Label合计1.Text = "发票价税开票金额总计: " + (d1.ToString("F2") == "0.00" ? "0" : d1.ToString("F2"));
            Label合计2.Text = "总计到账金额总计: " + (d2.ToString("F2") == "0.00" ? "0" : d2.ToString("F2"));


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
            Response.Redirect("caiwu2.aspx?idno=" + "" + "", false);
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
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);


                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();

                    Response.Redirect("caiwu5Add.aspx?idno=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "", false);
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
            caiwu1List caiwu1List = new caiwu1List();
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
                    caiwu1List.DeleteData(int.Parse(tickedFormNo));
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
            string str = "收款管理" + dt.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("AA19");
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A22");
           
            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col53"].ToString();
                dr["A3"] = dtAll.Rows[i]["col8"].ToString();
                dr["A4"] = dtAll.Rows[i]["col9"].ToString();

                dr["A5"] = dtAll.Rows[i]["col10"].ToString();
                dr["A6"] = dtAll.Rows[i]["col11"].ToString();
                dr["A7"] = dtAll.Rows[i]["col14"].ToString();
                dr["A8"] = dtAll.Rows[i]["col15"].ToString();
                dr["A9"] = dtAll.Rows[i]["col5"].ToString();
                dr["A10"] = dtAll.Rows[i]["col7"].ToString();
                dr["A11"] = dtAll.Rows[i]["col8"].ToString();
                dr["A12"] = dtAll.Rows[i]["col3"].ToString();
                dr["A13"] = dtAll.Rows[i]["col4"].ToString();
                dr["A14"] = dtAll.Rows[i]["col33"].ToString();
                dr["A15"] = dtAll.Rows[i]["col1"].ToString();
                dr["A16"] = dtAll.Rows[i]["col2"].ToString();
                dr["A17"] = dtAll.Rows[i]["col31"].ToString();
                dr["A18"] = dtAll.Rows[i]["col32"].ToString();
                dr["A19"] = dtAll.Rows[i]["col54"].ToString();

                dr["AA19"] = dtAll.Rows[i]["col666"].ToString();
                //Decimal amount开票 = 0;
                //DataSet dsde = Sql.SqlQueryDS("select * from t_caiwu3 where col8='" + dtAll.Rows[i]["col53"].ToString() + "' ");
                //if (dsde != null && dsde.Tables[0] != null && dsde.Tables[0].Rows.Count > 0)
                //{
                //    for (int kk = 0; kk < dsde.Tables[0].Rows.Count; kk++)
                //    {
                //        amount开票 += dsde.Tables[0].Rows[kk]["col6"].ToString() == "" ? 0 : Convert.ToDecimal(dsde.Tables[0].Rows[kk]["col6"].ToString());
                //    }

                //}
                //dr["AA19"] = amount开票.ToString("F2");
            

                dr["A20"] = dtAll.Rows[i]["col59"].ToString();
                dr["A21"] = dtAll.Rows[i]["col60"].ToString();
                dr["A22"] = dtAll.Rows[i]["col49"].ToString();
                

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/收款管理下载模板.xlsx", downloadTable, str);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuan.aspx?id=" + "caiwu1" + "", false);

        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }

        protected List<caiwu1List> checkUploadData(DataTable dt)
        {
            List<caiwu1List> caiwu1List = new List<caiwu1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                caiwu1List list = new caiwu1List();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[1].ColumnName);
                else
                    list.col1 = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[2].ColumnName);
                else
                    list.col2 = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[3].ColumnName);
                else
                    list.col3 = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[4].ColumnName);
                else
                    list.col4 = dt.Rows[i][4].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[5].ColumnName);
                else
                    list.col5 = dt.Rows[i][5].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[6].ColumnName);
                else
                    list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][7].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col8 = dt.Rows[i][8].ToString().Trim();
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][14].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col15 = dt.Rows[i][15].ToString();
                list.col16 = dt.Rows[i][16].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][16].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col17 = dt.Rows[i][17].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][17].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col18 = dt.Rows[i][18].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][18].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col19 = dt.Rows[i][19].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][19].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col20 = dt.Rows[i][20].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][20].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col21 = dt.Rows[i][21].ToString();
                list.col22 = dt.Rows[i][22].ToString();
                list.col23 = dt.Rows[i][23].ToString();


                caiwu1List.Add(list);
            }
            return caiwu1List;
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
                var tickedFormNo = ((Label)e.Row.FindControl("lblID")).Text;
                string temp1 = txtcol1.Text.Trim();
                string temp2 = txtcol2.Text.Trim();
                string temp3 = txtcol3.Text.Trim();
                string temp4 = txtcol4.Text.Trim();
                string temp5 = txtcol5.Text.Trim();
                string temp6 = txtcol6.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol53")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu5Add.aspx?idno=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 130;

                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol14")).Width = ((Label)e.Row.FindControl("lblcol14")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol14")).Width : ((Label)e.Row.FindControl("lblcol14")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol42")).Width = ((Label)e.Row.FindControl("lblcol42")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol42")).Width : ((Label)e.Row.FindControl("lblcol42")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol49")).Width = ((Label)e.Row.FindControl("lblcol49")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol49")).Width : ((Label)e.Row.FindControl("lblcol49")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol55")).Width = ((Label)e.Row.FindControl("lblcol55")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol55")).Width : ((Label)e.Row.FindControl("lblcol55")).Text.Trim().Length * 12;

                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 220)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 220;
                }
                
                if (((Label)e.Row.FindControl("lblcol14")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol14")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol15")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol15")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol42")).Width.Value < 120)
                {
                    ((Label)e.Row.FindControl("lblcol42")).Width = 120;
                }
                if (((Label)e.Row.FindControl("lblcol49")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol49")).Width = 100;
                }

                ((Label)e.Row.FindControl("lblcol42")).Text = ((Label)e.Row.FindControl("lblcol42")).Text.Trim() == "" ? "未到账" : ((Label)e.Row.FindControl("lblcol42")).Text.Trim();
                //Decimal amount开票 = 0;
                //DataSet dsde = Sql.SqlQueryDS("select * from t_caiwu3 where col8='" + ((Label)e.Row.FindControl("lblcol53")).Text + "' ");
                //if (dsde != null && dsde.Tables[0] != null && dsde.Tables[0].Rows.Count > 0)
                //{
                //    for (int kk = 0; kk < dsde.Tables[0].Rows.Count; kk++)
                //    {
                //        amount开票 += dsde.Tables[0].Rows[kk]["col6"].ToString() == "" ? 0 : Convert.ToDecimal(dsde.Tables[0].Rows[kk]["col6"].ToString());
                //    }

                //}
                //((Label)e.Row.FindControl("lblcol544")).Text = amount开票.ToString("F2");
                ((Label)e.Row.FindControl("lblcol544")).Text = ((Label)e.Row.FindControl("lblcol544")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol544")).Text).ToString("F2");

                if (((Label)e.Row.FindControl("lblcol42")).Text.Trim() == "全部到账")
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(158, 234, 106);
                    //((HyperLink)e.Row.FindControl("HyperLink1")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol8")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol9")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol10")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol11")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol14")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol15")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol5")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol7")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol6")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol3")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol4")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol55")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol1")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol2")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol31")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol32")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol54")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol544")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol41")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol42")).BackColor = System.Drawing.Color.Green;
                    //((Label)e.Row.FindControl("lblcol49")).BackColor = System.Drawing.Color.Green;
                   
                }
                else if (((Label)e.Row.FindControl("lblcol42")).Text.Trim() != "全部到账" && ((Label)e.Row.FindControl("lblcol42")).Text.Trim() != "" && ((Label)e.Row.FindControl("lblcol42")).Text.Trim() != "未到账")
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((HyperLink)e.Row.FindControl("HyperLink1")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol8")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol9")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol10")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol11")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol14")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol15")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol5")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol7")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol6")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol3")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol4")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol55")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol1")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol2")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol31")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol32")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol54")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol544")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol41")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol42")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);
                    //((Label)e.Row.FindControl("lblcol49")).BackColor = System.Drawing.Color.FromArgb(254, 231, 153);

                }


            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        //批量下载
        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";
            Dictionary<string, Stream> streams = new Dictionary<string, Stream>();
            Stream streamWriter = null;
            int counts = 1000;


            foreach (GridViewRow r in GridView1.Rows)
            {
                string name = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
                //savePath = "E:/导出证件信息/" + name;

                if (((CheckBox)r.FindControl("chk")).Checked)
                {
                    savePath = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    //savePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
                    //sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();

                    //if (sourcePath != "")
                    //{
                    //    string[] str1 = sourcePath.Split('/');
                    //    for (int k = 0; k < str1.Length; k++)
                    //    {
                    //        sourcePath = str1[str1.Length - 1].ToString();
                    //        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                    //    }

                    //    string filePath = Server.MapPath(savePath);//路径
                    //    streamWriter = new FileStream(filePath, FileMode.Open);
                    //    //streamWriter.Close();
                    //    counts++;
                    //    sourcePath = counts + sourcePath;
                    //    streams.Add(sourcePath, streamWriter);
                    //}



                    //savePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
                    //sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();

                    //if (sourcePath != "")
                    //{
                    //    string[] str1 = sourcePath.Split('/');
                    //    for (int k = 0; k < str1.Length; k++)
                    //    {
                    //        sourcePath = str1[str1.Length - 1].ToString();
                    //        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                    //    }

                    //    string filePath = Server.MapPath(savePath);//路径
                    //    streamWriter = new FileStream(filePath, FileMode.Open);
                    //    //streamWriter.Close();
                    //    counts++;
                    //    sourcePath = counts + sourcePath;
                    //    streams.Add(sourcePath, streamWriter);
                    //}

                }
                else
                {
                    if (((CheckBox)r.FindControl("Chk招标文件")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl招标文件")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }

                    }

                    if (((CheckBox)r.FindControl("Chk缴纳保证金保函")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl缴纳保证金保函")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl缴纳保证金保函")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk投标文件")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl投标文件")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl投标文件")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
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
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode("投标管理打包文档.zip", System.Text.Encoding.UTF8));
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