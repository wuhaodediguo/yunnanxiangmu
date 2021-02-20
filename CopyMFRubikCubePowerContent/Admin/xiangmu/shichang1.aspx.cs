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
    public partial class shichang1 : System.Web.UI.Page
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
            if (dataSource.Rows.Count > 0)
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[2]["col2"].ToString() == "1" && dataSource.Rows[2]["col1"].ToString() == "div0021")
                    {
                        dd0021.Visible = true;
                    }
                    else
                    {
                        dd0021.Visible = false;
                    }
                    if (dataSource.Rows[3]["col2"].ToString() == "1" && dataSource.Rows[3]["col1"].ToString() == "div0022")
                    {
                        dd0022.Visible = true;
                    }
                    else
                    {
                        dd0022.Visible = false;
                    }
                    if (dataSource.Rows[4]["col2"].ToString() == "1" && dataSource.Rows[4]["col1"].ToString() == "div0023")
                    {
                        dd0023.Visible = true;
                    }
                    else
                    {
                        dd0023.Visible = false;
                    }

                }

            }
            else
            {
                div0021.Visible = false;
                div0022.Visible = false;
                div0023.Visible = false;
                
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
            adminPager.TableName = "t_shichangview";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 and col39 = '0' ");
            string sql = "select * from t_shichangview where 1= 1 and col39 = '0' ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col2 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and col2 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col3 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and col3 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and col4 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col9 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col9 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col17 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and col17 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            //if (this.TextBox招标编号.Text.Trim() != "")
            //{
            //    where.Append(" and col5 like '%'+?+'%'");
            //    arrayList.Add(CheckSql.Filter(this.TextBox招标编号.Text.Trim()));
            //    sql += " and col5 = '" + this.TextBox招标编号.Text.Trim() + "' ";
            //}
            //if (this.TextBox开标日期.Text.Trim() != "")
            //{
            //    where.Append(" and col8 like '%'+?+'%'");
            //    arrayList.Add(CheckSql.Filter(this.TextBox开标日期.Text.Trim()));
            //    sql += " and col8 = '" + this.TextBox开标日期.Text.Trim() + "' ";
            //}
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and col1 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and col40 = '" + this.Session["FullName"].ToString() + "' ");
                sql += " and col40 = '" + this.Session["FullName"].ToString() + "' ";
            }
           
            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];

            //GridView1.Attributes.Add("style", "table-layout:fixed");
            this.GridView1.DataSource = adminPager.GetTable33(memoryPage);
            this.GridView1.DataBind();
        }

        protected void btn查询_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("shichang1Add.aspx?id=" + "" + "", false);
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

                    Response.Redirect("shichang1Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "", false);
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
            shichangList shichangList = new shichangList();
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
                     shichangList.DeleteData(int.Parse(tickedFormNo));
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
            string str = "投标管理" + dt.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("A44");
            downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");

            downloadTable.Columns.Add("A42");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A22");
            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");

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
                dr["A44"] = dtAll.Rows[i]["col44"].ToString();

                dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();
                dr["A12"] = dtAll.Rows[i]["col11"].ToString();
                dr["A13"] = dtAll.Rows[i]["col12"].ToString();
                dr["A14"] = dtAll.Rows[i]["col13"].ToString();
                dr["A15"] = dtAll.Rows[i]["col14"].ToString();
                dr["A16"] = dtAll.Rows[i]["col15"].ToString();

                dr["A42"] = dtAll.Rows[i]["col42"].ToString();
                dr["A17"] = dtAll.Rows[i]["col16"].ToString();
                dr["A18"] = dtAll.Rows[i]["col17"].ToString();
                dr["A19"] = dtAll.Rows[i]["col18"].ToString();
                dr["A20"] = dtAll.Rows[i]["col19"].ToString();
                dr["A21"] = dtAll.Rows[i]["col20"].ToString();
                dr["A22"] = dtAll.Rows[i]["col21"].ToString();
                dr["A23"] = dtAll.Rows[i]["col22"].ToString();
                dr["A24"] = dtAll.Rows[i]["col23"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/投标管理下载模板.xlsx", downloadTable, str);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuan.aspx?id=" + "shichang1" + "", false);

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
            //        List<shichangList> shichangList = checkUploadData(dt);

            //        StringBuilder errorMsg = new StringBuilder();
            //        foreach (shichangList item in shichangList)
            //        {
            //            if (!string.IsNullOrEmpty(item.CheckUploadResult))
            //                errorMsg.Append(item.CheckUploadResult);
            //        }


            //        if (string.IsNullOrEmpty(errorMsg.ToString()))
            //        {
            //            StringBuilder errorBillNo = new StringBuilder();
            //            foreach (shichangList item in shichangList)
            //            {
            //                DataSet ds = Sql.SqlQueryDS("select * from t_shichang where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
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
            //                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下招标人：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
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
        
        protected List<shichangList> checkUploadData(DataTable dt)
        {
            List<shichangList> shichangList = new List<shichangList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                shichangList list = new shichangList();
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
                list.col8 = dt.Rows[i][8].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][8].ToString().Trim()).ToString("yyyy/MM/dd");
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString();
                list.col15 = dt.Rows[i][15].ToString();
                list.col16 = dt.Rows[i][16].ToString();
                list.col17 = dt.Rows[i][17].ToString();
                list.col18 = dt.Rows[i][18].ToString();
                list.col19 = dt.Rows[i][19].ToString();
                list.col20 = dt.Rows[i][20].ToString();
                list.col21 = dt.Rows[i][21].ToString();
                list.col22 = dt.Rows[i][22].ToString();
                list.col23 = dt.Rows[i][23].ToString();


                shichangList.Add(list);
            }
            return shichangList;
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
                string temp5 = txtcol5.Text.Trim();
                string temp6 = txtcol6.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();

                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol4")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "shichang1Add.aspx?id=" + strid + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=view";

                if (((Label)e.Row.FindControl("lbl招标文件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label招标文件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label招标文件")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl缴纳保证金保函")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label缴纳保证金保函")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label缴纳保证金保函")).Visible = true;
                }
                if (((Label)e.Row.FindControl("lbl投标文件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = true;
                    ((Label)e.Row.FindControl("Label投标文件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;
                    ((Label)e.Row.FindControl("Label投标文件")).Visible = true;
                }
                //if (((Label)e.Row.FindControl("lbl招标文件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk招标文件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol20")).Visible = false;
                //    ((Label)e.Row.FindControl("Label招标文件")).Visible = true;
                //}
                //if (((Label)e.Row.FindControl("lbl缴纳保证金保函")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk缴纳保证金保函")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol21")).Visible = false;
                //    ((Label)e.Row.FindControl("Label缴纳保证金保函")).Visible = true;
                //}
                //if (((Label)e.Row.FindControl("lbl投标文件")).Text.Trim() == "")
                //{
                //    ((CheckBox)e.Row.FindControl("Chk投标文件")).Visible = false;
                //    ((HyperLink)e.Row.FindControl("HyperLinkcol22")).Visible = false;
                //    ((Label)e.Row.FindControl("Label投标文件")).Visible = true;
                //}

                string strlblcol18 = ((Label)e.Row.FindControl("lblcol18")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                string strlblcol19 = ((Label)e.Row.FindControl("lblcol19")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                
                string strlblcol42 = ((Label)e.Row.FindControl("lblcol42")).Text.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (strlblcol42 == "")
                {
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strlblcol42), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) <= 0)
                    {
                        if (strlblcol18 == "" && strlblcol19 == "")
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
                            ((Label)e.Row.FindControl("lblcol23")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol42")).ForeColor = System.Drawing.Color.Red;
                            ((Label)e.Row.FindControl("lblcol44")).ForeColor = System.Drawing.Color.Red;
                            ((HyperLink)e.Row.FindControl("HyperLink1")).ForeColor = System.Drawing.Color.Red;
                        }
                        else if (strlblcol18 != "")
                        {
                            string strlblcol13 = ((Label)e.Row.FindControl("lblcol13")).Text.Trim();
                            if (strlblcol13 != "&nbsp;" && strlblcol13 != "" && strlblcol18 != "&nbsp;")
                            {
                                if (Convert.ToDecimal(strlblcol13) != Convert.ToDecimal(strlblcol18))
                                 {
                                     ((HyperLink)e.Row.FindControl("HyperLink1")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol1")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol2")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol3")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol4")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol5")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol6")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol7")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol8")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol9")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol10")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol11")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol12")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol13")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol14")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol15")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol16")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol17")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol18")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol19")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol23")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol42")).ForeColor = System.Drawing.Color.Blue;
                                     ((Label)e.Row.FindControl("lblcol44")).ForeColor = System.Drawing.Color.Blue;
                                     ((HyperLink)e.Row.FindControl("HyperLink1")).ForeColor = System.Drawing.Color.Blue;
                                 }
                            }
                
                        }
                        
                    }
                }
                //if (((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length >= 25)
                //{
                //    ((Label)e.Row.FindControl("lblcol2")).Width = (Unit)300;
                //}
                //else if (((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length >= 25)
                //{
                //    ((Label)e.Row.FindControl("lblcol2")).Width = 300;
                //}
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                
                //((Label)e.Row.FindControl("lblcol11")).Width = ((Label)e.Row.FindControl("lblcol11")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol11")).Width : ((Label)e.Row.FindControl("lblcol11")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol12")).Width = ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol12")).Width : ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol13")).Width = ((Label)e.Row.FindControl("lblcol13")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol13")).Width : ((Label)e.Row.FindControl("lblcol13")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol14")).Width = ((Label)e.Row.FindControl("lblcol14")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol14")).Width : ((Label)e.Row.FindControl("lblcol14")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol16")).Width = ((Label)e.Row.FindControl("lblcol16")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol16")).Width : ((Label)e.Row.FindControl("lblcol16")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol17")).Width = ((Label)e.Row.FindControl("lblcol17")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol17")).Width : ((Label)e.Row.FindControl("lblcol17")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol18")).Width = ((Label)e.Row.FindControl("lblcol18")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol18")).Width : ((Label)e.Row.FindControl("lblcol18")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol19")).Width = ((Label)e.Row.FindControl("lblcol19")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol19")).Width : ((Label)e.Row.FindControl("lblcol19")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol23")).Width = ((Label)e.Row.FindControl("lblcol23")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol23")).Width : ((Label)e.Row.FindControl("lblcol23")).Text.Trim().Length * 12;
                //e.Row.Attributes.Add("style", "height:20px;text-align:left;");

                if (((HyperLink)e.Row.FindControl("HyperLink1")).Width.Value < 100)
                {
                    ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 100;
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
                //if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol7")).Width = 100;
                //}
                //if (((Label)e.Row.FindControl("lblcol8")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol8")).Width = 100;
                //}
                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 100;
                }
               
                if (((Label)e.Row.FindControl("lblcol14")).Width.Value < 110)
                {
                    ((Label)e.Row.FindControl("lblcol14")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol16")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol16")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol17")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol17")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol23")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol23")).Width = 100;
                }
                
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
        //    string[] controlList = new string[]
        //{
        //    "gvDelete"
        //};
        //    AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
            if (e.CommandName == "lbtn11")
            {
                string tempfilename = "投标文件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("shichang11", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "缴纳保证金保函" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("shichang12", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn13")
            {
                string tempfilename = "招标文件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("shichang13", rowIDs, tempfilename);
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
                for (int kkk = 0; kkk < ds2.Tables[0].Rows.Count; kkk ++ )
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