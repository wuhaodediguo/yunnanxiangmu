﻿using MojoCube.Api.Text;
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
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class caiwu1 : System.Web.UI.Page
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
                this.ViewState["OrderByKey"] = "col50,id";
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
                div01.Visible = true;
                div02.Visible = true;
                div03.Visible = true;
                div05.Visible = true;
            }
            if (this.Session["RoleValue"].ToString() == "6")
            {
                div03.Visible = false;
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

        //基本換頁寫法
        protected void gvDataList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GridBind();
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
            adminPager.TableName = "caiwu1view";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1  ");
            string sql = "select * from caiwu1view where 1= 1 ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col3 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and col3 = '" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col10 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and col10 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and col12 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and col12 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col1 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and col5 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col2 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and col2 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and (col24 = '" + this.Session["FullName"].ToString() + "' or col1 in (" + hdtemp.Text + ") )  ");
                sql += " and (col24 = '" + this.Session["FullName"].ToString() + "' or col1 in (" + hdtemp.Text + ") ) ";

            }

            sql += "order by col50,id";

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable2(memoryPage);
            //this.GridView1.DataSource = oledbHelper.GetDataTable(sql);
            this.GridView1.PageSize = 10;
            this.GridView1.DataBind();
        }

        protected void btn查询_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string str = string.Empty;
            Response.Redirect("caiwu1Add.aspx?id=" + str, false);
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol24")).Text;
                    string str项目经理 = ((Label)GridView1.Rows[k].FindControl("lblcol1")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(str项目经理))
                    {
                        SetWarningMessage("不能修改其他人创建的外经证管理！");
                        return;
                    }
                    
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);


                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();
                    
                    string temp7 = this.ListPager.CurrentPageIndex.ToString();



                    Response.Redirect("caiwu1Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "", false);
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol24")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能删除其他人创建的外经证管理！");
                        return;
                    }
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
            string str = "外经证管理" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
            //GridBind("download");
            //DownloadHtmlExcelFile(GridView1, str, null);
            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A5");
            downloadTable.Columns.Add("A31");
           
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
            downloadTable.Columns.Add("A29");
            downloadTable.Columns.Add("A30");
           
            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                dr["A4"] = dtAll.Rows[i]["col3"].ToString();

                dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                dr["A31"] = dtAll.Rows[i]["col31"].ToString();

                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();
                dr["A12"] = dtAll.Rows[i]["col11"].ToString();
                dr["A13"] = dtAll.Rows[i]["col12"].ToString();
                dr["A14"] = dtAll.Rows[i]["col13"].ToString();
                dr["A15"] = dtAll.Rows[i]["col14"].ToString();
                dr["A16"] = dtAll.Rows[i]["col15"].ToString();
                dr["A17"] = dtAll.Rows[i]["col16"].ToString();
                dr["A18"] = dtAll.Rows[i]["col17"].ToString();
                dr["A19"] = dtAll.Rows[i]["col18"].ToString();
                dr["A20"] = dtAll.Rows[i]["col19"].ToString();
                dr["A21"] = dtAll.Rows[i]["col20"].ToString();
                dr["A22"] = dtAll.Rows[i]["col21"].ToString();
                dr["A23"] = dtAll.Rows[i]["col22"].ToString();
                dr["A24"] = dtAll.Rows[i]["col23"].ToString();
                dr["A25"] = dtAll.Rows[i]["col24"].ToString();
                dr["A26"] = dtAll.Rows[i]["col25"].ToString();
                dr["A27"] = dtAll.Rows[i]["col26"].ToString();
                dr["A28"] = dtAll.Rows[i]["col27"].ToString();
                dr["A29"] = dtAll.Rows[i]["col28"].ToString();
                dr["A30"] = dtAll.Rows[i]["col29"].ToString();
                

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/外经证管理下载模板.xlsx", downloadTable, str);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuan5.aspx?id=" + "caiwu1" + "", false);

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
            //GridView1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            //GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strid = ((Label)e.Row.FindControl("lblID")).Text;

                string temp1 = txtcol1.Text.Trim();
                string temp2 = txtcol2.Text.Trim();
                string temp3 = txtcol3.Text.Trim();
                string temp4 = txtcol4.Text.Trim();
                string temp5 = txtcol5.Text.Trim();
                string temp6 = txtcol6.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol1")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu1Add.aspx?id=" + strid + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 130;

                string lblcol24 = ((Label)e.Row.FindControl("lblcol24")).Text;
                if (this.Session["UserName"].ToString() != lblcol24 && this.Session["RoleValue"].ToString() != "1")
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = false;
                }

                string str项目经理 = ((HyperLink)e.Row.FindControl("HyperLink1")).Text;
                if (this.Session["RoleValue"].ToString() != "1" && hdtemp.Text.Contains(str项目经理))
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = true;
                }
                
                //if (((Label)e.Row.FindControl("lbl外经证扫描件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk外经证扫描件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol26")).Visible = false;
                //    ((Label)e.Row.FindControl("Label外经证扫描件")).Visible = true;
                //}
                if (((Label)e.Row.FindControl("lbl外经证扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label外经证扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label外经证扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl延期后外经证扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label延期后外经证扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label延期后外经证扫描件")).Visible = true;
                }
                //if (((Label)e.Row.FindControl("lbl延期后外经证扫描件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk延期后外经证扫描件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol27")).Visible = false;
                //    ((Label)e.Row.FindControl("Label延期后外经证扫描件")).Visible = true;
                //}
                //if (((Label)e.Row.FindControl("lbl核销反馈表扫描件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk核销反馈表扫描件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol28")).Visible = false;
                //    ((Label)e.Row.FindControl("Label核销反馈表扫描件")).Visible = true;
                //}
                if (((Label)e.Row.FindControl("lbl核销反馈表扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = true;
                    ((Label)e.Row.FindControl("Label核销反馈表扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;
                    ((Label)e.Row.FindControl("Label核销反馈表扫描件")).Visible = true;
                }
                

                //if (((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length >= 25)
                //{
                //    ((Label)e.Row.FindControl("lblcol2")).Width = (Unit)300;
                //}
                //else if (((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length >= 25)
                //{
                //    ((Label)e.Row.FindControl("lblcol2")).Width = 300;
                //}
                //((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol11")).Width = ((Label)e.Row.FindControl("lblcol11")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol11")).Width : ((Label)e.Row.FindControl("lblcol11")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol12")).Width = ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol12")).Width : ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol13")).Width = ((Label)e.Row.FindControl("lblcol13")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol13")).Width : ((Label)e.Row.FindControl("lblcol13")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol29")).Width = ((Label)e.Row.FindControl("lblcol29")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol29")).Width : ((Label)e.Row.FindControl("lblcol29")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol21")).Width = ((Label)e.Row.FindControl("lblcol21")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol21")).Width : ((Label)e.Row.FindControl("lblcol21")).Text.Trim().Length * 12;
               
                //if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 220)
                //{
                //    ((Label)e.Row.FindControl("lblcol1")).Width = 220;
                //}
                if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol2")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 100;
                }
                //if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 220)
                //{
                //    ((Label)e.Row.FindControl("lblcol4")).Width = 220;
                //}
                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 220)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 220;
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
                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol11")).Width.Value < 160)
                {
                    ((Label)e.Row.FindControl("lblcol11")).Width = 160;
                }
                if (((Label)e.Row.FindControl("lblcol12")).Width.Value < 160)
                {
                    ((Label)e.Row.FindControl("lblcol12")).Width = 160;
                }
                if (((Label)e.Row.FindControl("lblcol13")).Width.Value < 160)
                {
                    ((Label)e.Row.FindControl("lblcol13")).Width = 160;
                }
                if (((Label)e.Row.FindControl("lblcol21")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol21")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol29")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol29")).Width = 100;
                }

                string strlblcol15 = ((Label)e.Row.FindControl("lblcol15")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (strlblcol15 == "")
                {
                }
                else
                {
                    string strlblcol17 = ((Label)e.Row.FindControl("lblcol17")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                    if (strlblcol17 == "")
                    {
                        if (DateTime.Compare(Convert.ToDateTime(strlblcol15), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) <= 0)
                        {
                            ((HyperLink)e.Row.FindControl("HyperLink1")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol1")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol2")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol3")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol4")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol5")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol6")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol7")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol8")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol9")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol10")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol11")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol12")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol13")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol14")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol15")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol16")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol17")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol18")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol19")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol20")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol21")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol22")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol23")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol24")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol25")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol29")).ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        string strlblcol18 = ((Label)e.Row.FindControl("lblcol18")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                        if (strlblcol18 != "")
                        {
                            if (DateTime.Compare(Convert.ToDateTime(strlblcol18), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) <= 0)
                            {
                                ((HyperLink)e.Row.FindControl("HyperLink1")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol1")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol2")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol3")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol4")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol5")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol6")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol7")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol8")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol9")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol10")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol11")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol12")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol13")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol14")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol15")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol16")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol17")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol18")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol19")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol20")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol21")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol22")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol23")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol24")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol25")).ForeColor = System.Drawing.Color.Red;
                                ((Label)e.Row.FindControl("lblcol29")).ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        
                    }

                    
                }

                string lblcol23 = ((Label)e.Row.FindControl("lblcol23")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (lblcol23 == "已经过期")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                    ((HyperLink)e.Row.FindControl("HyperLink1")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol1")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol2")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol3")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol4")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol5")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol6")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol7")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol8")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol9")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol10")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol11")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol12")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol13")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol14")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol15")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol16")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol17")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol18")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol19")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol20")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol21")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol22")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol23")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol24")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol25")).BackColor = System.Drawing.Color.LightGreen;
                    ((Label)e.Row.FindControl("lblcol29")).BackColor = System.Drawing.Color.LightGreen;
                }

                string lblcol20 = ((Label)e.Row.FindControl("lblcol20")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (lblcol23 == "已经核销" && lblcol20 != "")
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((HyperLink)e.Row.FindControl("HyperLink1")).BackColor = System.Drawing.Color.FromArgb(214,220,228);
                    ((Label)e.Row.FindControl("lblcol1")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol2")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol3")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol4")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol5")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol6")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol7")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol8")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol9")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol10")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol11")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol12")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol13")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol14")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol15")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol16")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol17")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol18")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol19")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol20")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol21")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol22")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol23")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol24")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol25")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);
                    ((Label)e.Row.FindControl("lblcol29")).BackColor = System.Drawing.Color.FromArgb(214, 220, 228);

                    ((HyperLink)e.Row.FindControl("HyperLink1")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol1")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol2")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol3")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol4")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol5")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol6")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol7")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol8")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol9")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol10")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol11")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol12")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol13")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol14")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol15")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol16")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol17")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol18")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol19")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol20")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol21")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol22")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol23")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol24")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol25")).ForeColor = System.Drawing.Color.Black;
                    ((Label)e.Row.FindControl("lblcol29")).ForeColor = System.Drawing.Color.Black;
                }

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
                string tempfilename = "外经证扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("caiwu11", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "延期后外经证扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("caiwu12", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn13")
            {
                string tempfilename = "核销反馈表扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("caiwu13", rowIDs, tempfilename);
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