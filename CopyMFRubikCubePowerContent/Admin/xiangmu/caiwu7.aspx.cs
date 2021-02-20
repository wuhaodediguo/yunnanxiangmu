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
    public partial class caiwu7 : System.Web.UI.Page
    {
        public int memoryPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
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
            adminPager.TableName = "t_caiwu5";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            //where.Append(" where 1=1 and col43 like '%审核通过%' and col43 not like '%未审批%' and col43 not like '%未提交%' and col43 not like '%申请结算%'  ");
            //string sql = "select * from t_caiwu5 where 1= 1 and col43 like '%审核通过%' and col43 not like '%未审批%' and col43 not like '%未提交%' and col43 not like '%申请结算%' ";
            where.Append(" where 1=1  and col54 = '已完成'  ");
            string sql = "select * from t_caiwu5 where 1= 1 and col54 = '已完成' ";

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
                where.Append(" and col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col4 like '%" + this.txtcol4.Text.Trim() + "%' ";
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

            if (this.txtcol7.Text.Trim() != "")
            {
                where.Append(" and col10 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol7.Text.Trim()));
                sql += " and col10 like '%" + this.txtcol7.Text.Trim() + "%' ";
            }

            if (this.txtcol8.Text.Trim() != "")
            {
                where.Append(" and col17 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol8.Text.Trim()));
                sql += " and col17 like '%" + this.txtcol8.Text.Trim() + "%' ";
            }

            if (this.txtcol9.Text.Trim() != "")
            {
                where.Append(" and col22 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol9.Text.Trim()));
                sql += " and col22 like '%" + this.txtcol9.Text.Trim() + "%' ";
            }

            if (this.txtcol10.Text.Trim() != "")
            {
                where.Append(" and col23 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol10.Text.Trim()));
                sql += " and col23 like '%" + this.txtcol10.Text.Trim() + "%' ";
            }

            if (this.txtcol11.Text.Trim() != "")
            {
                where.Append(" and col45 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol11.Text.Trim()));
                sql += " and col45 like '%" + this.txtcol11.Text.Trim() + "%' ";
            }


            if (this.txtcol12.Text.Trim() != "")
            {
                where.Append(" and col28 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol12.Text.Trim()));
                sql += " and col28 like '%" + this.txtcol12.Text.Trim() + "%' ";
            }

            //if (this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and col29 = '" + this.Session["FullName"].ToString() + "' ");
            //    sql += " and col29 = '" + this.Session["FullName"].ToString() + "' ";
            //}
            where.Append("  and (col49 = '" + this.Session["FullName"].ToString() + "' or col50 like '%" + this.Session["FullName"].ToString() + "%' or col29 = '" + this.Session["FullName"].ToString() + "') ");
            sql += " and  (col49 = '" + this.Session["FullName"].ToString() + "' or col50 like '%" + this.Session["FullName"].ToString() + "%' or col29 = '" + this.Session["FullName"].ToString() + "') ";


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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            Response.Redirect("caiwu6Add.aspx?id=" + str, false);
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
                    var tickedFormNo2 = ((Label)GridView1.Rows[k].FindControl("lblID2")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    Response.Redirect("caiwu6Add.aspx?idno=" + tickedFormNo + "&id=" + tickedFormNo2, false);
                    
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

        protected void btn审核_Click(object sender, EventArgs e)
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
                    var tickedFormNo2 = ((Label)GridView1.Rows[k].FindControl("lblID2")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    string model = "审核";
                    Response.Redirect("caiwu6Add.aspx?idno=" + tickedFormNo + "&id=" + tickedFormNo2 + "&role=" + model, false);

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
            caiwu5List caiwu5List = new caiwu5List();
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
                    caiwu5List.DeleteData(int.Parse(tickedFormNo));
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
            string str = "结算管理" + dt.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("A28");
            downloadTable.Columns.Add("A333");

            downloadTable.Columns.Add("A29");
            downloadTable.Columns.Add("A30");
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A32");
            downloadTable.Columns.Add("A33");
            downloadTable.Columns.Add("A34");
            downloadTable.Columns.Add("A35");
            downloadTable.Columns.Add("A36");

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col45"].ToString();
                dr["A3"] = dtAll.Rows[i]["col1"].ToString();
                dr["A4"] = dtAll.Rows[i]["col2"].ToString();

                dr["A5"] = dtAll.Rows[i]["col3"].ToString();
                dr["A6"] = dtAll.Rows[i]["col4"].ToString();
                dr["A7"] = dtAll.Rows[i]["col5"].ToString();
                dr["A8"] = dtAll.Rows[i]["col6"].ToString();
                dr["A9"] = dtAll.Rows[i]["col7"].ToString();
                dr["A10"] = dtAll.Rows[i]["col8"].ToString();
                dr["A11"] = dtAll.Rows[i]["col9"].ToString();
                dr["A12"] = dtAll.Rows[i]["col10"].ToString();
                dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                dr["A20"] = dtAll.Rows[i]["col18"].ToString();
                dr["A21"] = dtAll.Rows[i]["col19"].ToString();
                dr["A22"] = dtAll.Rows[i]["col20"].ToString();
                dr["A23"] = dtAll.Rows[i]["col21"].ToString();
                dr["A24"] = dtAll.Rows[i]["col22"].ToString();
                dr["A25"] = dtAll.Rows[i]["col23"].ToString();
                dr["A26"] = dtAll.Rows[i]["col24"].ToString();
                dr["A27"] = dtAll.Rows[i]["col25"].ToString();
                dr["A28"] = dtAll.Rows[i]["col26"].ToString();
                dr["A29"] = dtAll.Rows[i]["col27"].ToString();
                dr["A30"] = dtAll.Rows[i]["col28"].ToString();

                string id = dtAll.Rows[i]["col1"].ToString();
                string id2 = dtAll.Rows[i]["ID"].ToString();
                decimal amount1 = 0;
                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu55 where col9 = '" + id + "'");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        amount1 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col2"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col2"].ToString());
                    }

                }
                else
                {
                    ds = Sql.SqlQueryDS("select * from t_caiwu55 where col9 = '" + id2 + "'");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                        {
                            amount1 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col2"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col2"].ToString());
                        }

                    }
                }
                dr["A333"] = amount1.ToString("F2");
                
                dr["A31"] = dtAll.Rows[i]["col29"].ToString();
                dr["A32"] = dtAll.Rows[i]["col30"].ToString();
                dr["A33"] = dtAll.Rows[i]["col43"].ToString();
                dr["A34"] = dtAll.Rows[i]["col41"].ToString();
                dr["A35"] = dtAll.Rows[i]["col42"].ToString();
                dr["A36"] = dtAll.Rows[i]["col46"].ToString();
               
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/结算管理下载模板.xlsx", downloadTable, str);
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
                var tickedFormNo = ((Label)e.Row.FindControl("lblID")).Text;
                var tickedFormNo2 = ((Label)e.Row.FindControl("lblID2")).Text; // 若該列有被選取，取出被選的單號

                ((HyperLink)e.Row.FindControl("HyperLinkcol审批状态")).NavigateUrl = "shenhemingxi.aspx?txtFormNo=" + ((Label)e.Row.FindControl("lblcol1")).Text + "";

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol1")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + tickedFormNo + "&id=" + tickedFormNo2 + "&model=view&model2=view2&model3=caiwu7";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 130;
                //((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol17")).Width = ((Label)e.Row.FindControl("lblcol17")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol17")).Width : ((Label)e.Row.FindControl("lblcol17")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol22")).Width = ((Label)e.Row.FindControl("lblcol22")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol22")).Width : ((Label)e.Row.FindControl("lblcol22")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol44")).Width = ((Label)e.Row.FindControl("lblcol44")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol44")).Width : ((Label)e.Row.FindControl("lblcol44")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lbl审批状态")).Width = ((Label)e.Row.FindControl("lbl审批状态")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lbl审批状态")).Width : ((Label)e.Row.FindControl("lbl审批状态")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lbl项目经理")).Width = ((Label)e.Row.FindControl("lbl项目经理")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lbl项目经理")).Width : ((Label)e.Row.FindControl("lbl项目经理")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol21")).Width = ((Label)e.Row.FindControl("lblcol21")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol21")).Width : ((Label)e.Row.FindControl("lblcol21")).Text.Trim().Length * 12;

                //if (((Label)e.Row.FindControl("lbl项目实施单位发票附件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk项目实施单位发票附件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol项目实施单位发票附件")).Visible = false;
                //    ((Label)e.Row.FindControl("Label项目实施单位发票附件")).Visible = true;
                //}

                //if (((Label)e.Row.FindControl("lbl付款凭证")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk付款凭证")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol付款凭证")).Visible = false;
                //    ((Label)e.Row.FindControl("Label付款凭证")).Visible = true;
                //}

                if (((Label)e.Row.FindControl("lbl项目实施单位发票附件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label项目实施单位发票附件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label项目实施单位发票附件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl付款凭证")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label付款凭证")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label付款凭证")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 200)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 200;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 200)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 200;
                }
                
                if (((Label)e.Row.FindControl("lblcol6")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol6")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol7")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol8")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol8")).Width = 100;
                }
               
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol15")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol15")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol17")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol17")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol22")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol22")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol21")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol21")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol44")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol44")).Width = 100;
                }

                string id = ((Label)e.Row.FindControl("lblcol1")).Text;
                string id2 = ((Label)e.Row.FindControl("lblID")).Text;
                decimal amount1 = 0;
                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu55 where col9 = '" + id + "'");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        amount1 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col2"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col2"].ToString());
                    }

                }
                else
                {
                    ds = Sql.SqlQueryDS("select * from t_caiwu55 where col9 = '" + id2 + "'");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                        {
                            amount1 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col2"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col2"].ToString());
                        }

                    }
                }
                ((Label)e.Row.FindControl("lbl总支付金额")).Text = amount1.ToString("F2");

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
                string tempfilename = "项目实施单位发票附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("caiwu62", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "付款凭证" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("caiwu63", rowIDs, tempfilename);
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

        protected void btnExport2_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "结算管理明细" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";

            DataTable downloadTable = new DataTable();
            DataRow dr;

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
            downloadTable.Columns.Add("A28");
            downloadTable.Columns.Add("A333");

            downloadTable.Columns.Add("A29");
            downloadTable.Columns.Add("A30");
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A32");
            downloadTable.Columns.Add("A33");
            downloadTable.Columns.Add("A34");
            downloadTable.Columns.Add("A35");
            downloadTable.Columns.Add("A36");

            //downloadTable.Columns.Add("col9");
            downloadTable.Columns.Add("col118");
            downloadTable.Columns.Add("col111");
            downloadTable.Columns.Add("col112");
            downloadTable.Columns.Add("col113");
            downloadTable.Columns.Add("col114");
            downloadTable.Columns.Add("col115");
            downloadTable.Columns.Add("col116");
            downloadTable.Columns.Add("col117");
            int couint = 0;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {

                decimal amount1 = 0;
                couint = 0;
                var tickedID = dtAll.Rows[i]["ID"].ToString();
                var tickedcol45 = dtAll.Rows[i]["col45"].ToString();
                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu55 where col11 = '" + tickedID + "'");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                    {
                        dr = downloadTable.NewRow();
                        amount1 += Convert.ToDecimal(ds.Tables[0].Rows[ii]["col2"].ToString() == "" ? "0" : ds.Tables[0].Rows[ii]["col2"].ToString());
                        couint++;
                        
                        //dr["col9"] = tickedcol45;
                        dr["col118"] = couint;
                        dr["col111"] = ds.Tables[0].Rows[ii]["col1"];
                        dr["col112"] = ds.Tables[0].Rows[ii]["col2"];
                        dr["col113"] = ds.Tables[0].Rows[ii]["col3"];
                        dr["col114"] = ds.Tables[0].Rows[ii]["col4"];
                        dr["col115"] = ds.Tables[0].Rows[ii]["col5"];
                        dr["col116"] = ds.Tables[0].Rows[ii]["col6"];
                        dr["col117"] = ds.Tables[0].Rows[ii]["col7"];

                        if (ii == ds.Tables[0].Rows.Count - 1)
                        {
                            
                            dr["A1"] = i + 1;
                            dr["A2"] = dtAll.Rows[i]["col45"].ToString();
                            dr["A3"] = dtAll.Rows[i]["col1"].ToString();
                            dr["A4"] = dtAll.Rows[i]["col2"].ToString();

                            dr["A5"] = dtAll.Rows[i]["col3"].ToString();
                            dr["A6"] = dtAll.Rows[i]["col4"].ToString();
                            dr["A7"] = dtAll.Rows[i]["col5"].ToString();
                            dr["A8"] = dtAll.Rows[i]["col6"].ToString();
                            dr["A9"] = dtAll.Rows[i]["col7"].ToString();
                            dr["A10"] = dtAll.Rows[i]["col8"].ToString();
                            dr["A11"] = dtAll.Rows[i]["col9"].ToString();
                            dr["A12"] = dtAll.Rows[i]["col10"].ToString();
                            dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                            dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                            dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                            dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                            dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                            dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                            dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                            dr["A20"] = dtAll.Rows[i]["col18"].ToString();
                            dr["A21"] = dtAll.Rows[i]["col19"].ToString();
                            dr["A22"] = dtAll.Rows[i]["col20"].ToString();
                            dr["A23"] = dtAll.Rows[i]["col21"].ToString();
                            dr["A24"] = dtAll.Rows[i]["col22"].ToString();
                            dr["A25"] = dtAll.Rows[i]["col23"].ToString();
                            dr["A26"] = dtAll.Rows[i]["col24"].ToString();
                            dr["A27"] = dtAll.Rows[i]["col25"].ToString();
                            dr["A28"] = dtAll.Rows[i]["col26"].ToString();
                            dr["A29"] = dtAll.Rows[i]["col27"].ToString();
                            dr["A30"] = dtAll.Rows[i]["col28"].ToString();

                            dr["A333"] = amount1.ToString("F2");

                            dr["A31"] = dtAll.Rows[i]["col29"].ToString();
                            dr["A32"] = dtAll.Rows[i]["col30"].ToString();
                            dr["A33"] = dtAll.Rows[i]["col43"].ToString();
                            dr["A34"] = dtAll.Rows[i]["col41"].ToString();
                            dr["A35"] = dtAll.Rows[i]["col42"].ToString();
                            dr["A36"] = dtAll.Rows[i]["col46"].ToString();

                        }
                        downloadTable.Rows.Add(dr);
                    }

                }

            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/结算管理明细下载模板.xlsx", downloadTable, str);
        }


    }
    
}