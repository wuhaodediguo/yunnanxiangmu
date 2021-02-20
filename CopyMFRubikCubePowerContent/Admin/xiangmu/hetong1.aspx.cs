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
    public partial class hetong1 : System.Web.UI.Page
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
        string templ;
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
                div01.Visible = true;
                div02.Visible = true;
                div03.Visible = true;
                div05.Visible = true;
            }
            if (dataSource.Rows.Count > 0)
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[6]["col2"].ToString() == "1" && dataSource.Rows[6]["col1"].ToString() == "div0031")
                    {
                        dd0031.Visible = true;
                    }
                    else
                    {
                        dd0031.Visible = false;
                    }
                    if (dataSource.Rows[7]["col2"].ToString() == "1" && dataSource.Rows[7]["col1"].ToString() == "div0032")
                    {
                        dd0032.Visible = true;
                    }
                    else
                    {
                        dd0032.Visible = false;
                    }
                    if (dataSource.Rows[8]["col2"].ToString() == "1" && dataSource.Rows[8]["col1"].ToString() == "div0033")
                    {
                        dd0033.Visible = true;
                    }
                    else
                    {
                        dd0033.Visible = false;
                    }
                    if (dataSource.Rows[9]["col2"].ToString() == "1" && dataSource.Rows[9]["col1"].ToString() == "div0034")
                    {
                        dd0034.Visible = true;
                    }
                    else
                    {
                        dd0034.Visible = false;
                    }

                }

            }
            else
            {
                div0031.Visible = false;
                div0032.Visible = false;
                div0033.Visible = false;
                div0034.Visible = false;

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
            adminPager.TableName = "t_hetong";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            string sql = "select * from t_hetong where 1= 1 ";

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
                where.Append(" and col6 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and col6 like '%" + this.txtcol3.Text.Trim() + "%' ";
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
                where.Append(" and  format(col22,'yyyyMMdd') >= format('" + this.txtcol6.Text.Trim() + "','yyyyMMdd') ");
                sql += "and  format(col22,'yyyyMMdd') >= format('" + this.txtcol6.Text.Trim() + "','yyyyMMdd') ";
            }
            if (this.txtcol7.Text.Trim() != "")
            {
                where.Append(" and  format(col22,'yyyyMMdd') <= format('" + this.txtcol7.Text.Trim() + "','yyyyMMdd') ");
                sql += "and  format(col22,'yyyyMMdd') <= format('" + this.txtcol7.Text.Trim() + "','yyyyMMdd') ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and (col16 = '" + this.Session["FullName"].ToString() + "' or col8 in (" + hdtemp.Text + ") or col23 in (" + hdtemp.Text + ") or col26 in (" + hdtemp.Text + ") or col31 in (" + hdtemp.Text + ") or col34 in (" + hdtemp.Text + ") or col37 in (" + hdtemp.Text + ") ) ");
                sql += " and (col16 = '" + this.Session["FullName"].ToString() + "' or col8 in (" + hdtemp.Text + ") or col23 in (" + hdtemp.Text + ") or col26 in (" + hdtemp.Text + ") or col31 in (" + hdtemp.Text + ") or col34 in (" + hdtemp.Text + ") or col37 in (" + hdtemp.Text + ") ) ";
            }
            

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
            Response.Redirect("hetong1Add.aspx?id=" + "" + "", false);
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

                    Response.Redirect("hetong1Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "", false);
                    break;
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

        protected void btn删除_Click(object sender, EventArgs e)
        {
            hetong1List hetong1List = new hetong1List();
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
                    var lblcol1 = ((Label)GridView1.Rows[k].FindControl("lblcol1")).Text;
                    var lblcol2 = ((Label)GridView1.Rows[k].FindControl("lblcol2")).Text;
                    var lblcol3 = ((Label)GridView1.Rows[k].FindControl("lblcol3")).Text;
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = "select *  from t_caiwu2  where col9 = '" + lblcol1 + "' and col10 = '" + lblcol2 + "' and col11 = '" + lblcol3 + "' and col8 = '施工合同' and col55 like '%确定开票%'  ";
                    DataTable dataSource = oledbHelper.GetDataTable(sql);

                    if (dataSource.Rows.Count > 0)
                    {
                        SetWarningMessage("不能删除已经开过票的项目！");
                        return;
                    }

                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    hetong1List.DeleteData(int.Parse(tickedFormNo));
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
            string str = "施工合同管理" + dt.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A32");
            downloadTable.Columns.Add("A33");
            downloadTable.Columns.Add("A34");
            downloadTable.Columns.Add("A35");
            downloadTable.Columns.Add("A36");
            downloadTable.Columns.Add("A37");
            downloadTable.Columns.Add("A38");
            downloadTable.Columns.Add("A39");

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
                dr["A12"] = dtAll.Rows[i]["col23"].ToString();
                dr["A13"] = dtAll.Rows[i]["col24"].ToString();
                dr["A14"] = dtAll.Rows[i]["col25"].ToString();
                dr["A15"] = dtAll.Rows[i]["col26"].ToString();
                dr["A16"] = dtAll.Rows[i]["col27"].ToString();
                dr["A17"] = dtAll.Rows[i]["col28"].ToString();
                dr["A31"] = dtAll.Rows[i]["col31"].ToString();
                dr["A32"] = dtAll.Rows[i]["col32"].ToString();
                dr["A33"] = dtAll.Rows[i]["col33"].ToString();
                dr["A34"] = dtAll.Rows[i]["col34"].ToString();
                dr["A35"] = dtAll.Rows[i]["col35"].ToString();
                dr["A36"] = dtAll.Rows[i]["col36"].ToString();
                dr["A37"] = dtAll.Rows[i]["col37"].ToString();
                dr["A38"] = dtAll.Rows[i]["col38"].ToString();
                dr["A39"] = dtAll.Rows[i]["col39"].ToString();

                dr["A18"] = dtAll.Rows[i]["col11"].ToString();
                dr["A19"] = dtAll.Rows[i]["col12"].ToString();
                dr["A20"] = dtAll.Rows[i]["col13"].ToString();
                dr["A21"] = dtAll.Rows[i]["col14"].ToString();
                dr["A22"] = dtAll.Rows[i]["col15"].ToString();
                dr["A23"] = dtAll.Rows[i]["col16"].ToString();
                dr["A24"] = dtAll.Rows[i]["col17"].ToString();
                dr["A25"] = dtAll.Rows[i]["col18"].ToString();
                dr["A26"] = dtAll.Rows[i]["col19"].ToString();
                dr["A27"] = dtAll.Rows[i]["col20"].ToString();
                dr["A28"] = dtAll.Rows[i]["col21"].ToString();
                dr["A29"] = dtAll.Rows[i]["col22"].ToString();

                

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/施工合同管理下载模板.xlsx", downloadTable, str);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuan2.aspx?id=" + "hetong1" + "", false);

            //try
            //{

            //    if (checkFile(fuPortrait.PostedFile))
            //    {
            //        ExcelHelper exh = new ExcelHelper();
            //        DataTable dt = exh.ExcelToDataTable(this.fuPortrait.PostedFile.InputStream, "", true, fuPortrait.PostedFile.FileName);
            //        //验证数据

            //        if (dt == null)
            //        {
            //            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "文件没有数据");
            //            return;
            //        }
            //        List<hetong1List> hetong1List = checkUploadData(dt);

            //        StringBuilder errorMsg = new StringBuilder();
            //        foreach (hetong1List item in hetong1List)
            //        {
            //            if (!string.IsNullOrEmpty(item.CheckUploadResult))
            //                errorMsg.Append(item.CheckUploadResult);
            //        }


            //        if (string.IsNullOrEmpty(errorMsg.ToString()))
            //        {
            //            StringBuilder errorBillNo = new StringBuilder();
            //            foreach (hetong1List item in hetong1List)
            //            {
            //                DataSet ds = Sql.SqlQueryDS("select * from t_hetong where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
            //                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //                {
            //                    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            //                    item.UpdateData(item.ID);
            //                }
            //                else
            //                {
            //                    if (item.InsertData() <= 0)
            //                    {
            //                        errorBillNo.Append(item.col1 + ",");
            //                    }
            //                }

            //            }
            //            if (!string.IsNullOrEmpty(errorBillNo.ToString()))
            //                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下合同：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
            //            else
            //            {
            //                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
            //                this.GridBind();
            //            }


            //        }
            //        else
            //            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
            //    }
            //    else
            //    {
            //        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择上传文件和正确文件格式");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", ex.ToString());
            //}
        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }

        protected List<hetong1List> checkUploadData(DataTable dt)
        {
            List<hetong1List> hetong1List = new List<hetong1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hetong1List list = new hetong1List();
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
                list.col4 = dt.Rows[i][4].ToString();
                list.col5 = dt.Rows[i][5].ToString();
                list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString();
                list.col8 = dt.Rows[i][8].ToString();
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = dt.Rows[i][13].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][13].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col14 = dt.Rows[i][14].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][14].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col15 = dt.Rows[i][15].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][15].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col16 = dt.Rows[i][16].ToString();
                list.col17 = dt.Rows[i][17].ToString();
                list.col18 = dt.Rows[i][18].ToString();
                list.col19 = dt.Rows[i][19].ToString();
                list.col20 = dt.Rows[i][20].ToString();
                list.col21 = System.DateTime.Now.ToString("yyyy/MM/dd");

                hetong1List.Add(list);
            }
            return hetong1List;
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
                string temp1 = txtcol1.Text.Trim();
                string temp2 = txtcol2.Text.Trim();
                string temp3 = txtcol3.Text.Trim();
                string temp4 = txtcol4.Text.Trim();
                string temp5 = txtcol6.Text.Trim();
                string temp6 = txtcol7.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();

                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol1")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "hetong1Add.aspx?id=" + strid + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=view";

                string lblcol16 = ((Label)e.Row.FindControl("lblcol16")).Text;
                if (this.Session["UserName"].ToString() != lblcol16 && this.Session["RoleValue"].ToString() != "1")
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = false;
                }
                string str项目经理 = ((Label)e.Row.FindControl("lblcol6")).Text;
                if (this.Session["RoleValue"].ToString() != "1" && hdtemp.Text.Contains(str项目经理))
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl电子版合同")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label电子版合同")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label电子版合同")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl合同扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label合同扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label合同扫描件")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl合同其他附件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = true;
                    ((Label)e.Row.FindControl("Label合同其他附件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;
                    ((Label)e.Row.FindControl("Label合同其他附件")).Visible = true;
                }
                //if (((Label)e.Row.FindControl("lbl电子版合同")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk电子版合同")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol17")).Visible = false;
                //    ((Label)e.Row.FindControl("Label电子版合同")).Visible = true;
                //}
                
                //if (((Label)e.Row.FindControl("lbl合同扫描件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk合同扫描件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol18")).Visible = false;
                //    ((Label)e.Row.FindControl("Label合同扫描件")).Visible = true;
                //}

                //if (((Label)e.Row.FindControl("lbl合同其他附件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk合同其他附件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol19")).Visible = false;
                //    ((Label)e.Row.FindControl("Label合同其他附件")).Visible = true;
                //}

                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol11")).Width = ((Label)e.Row.FindControl("lblcol11")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol11")).Width : ((Label)e.Row.FindControl("lblcol11")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol12")).Width = ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol12")).Width : ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol16")).Width = ((Label)e.Row.FindControl("lblcol16")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol16")).Width : ((Label)e.Row.FindControl("lblcol16")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol20")).Width = ((Label)e.Row.FindControl("lblcol20")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol20")).Width : ((Label)e.Row.FindControl("lblcol20")).Text.Trim().Length * 12;

                if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol1")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol2")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 100;
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
                if (((Label)e.Row.FindControl("lblcol11")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol11")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol12")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol12")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol16")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol16")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol20")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol20")).Width = 100;
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
                string tempfilename = "电子版合同" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("hetong11", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "合同扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("hetong12", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn13")
            {
                string tempfilename = "合同其他附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("hetong13", rowIDs, tempfilename);
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