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
    public partial class xiangmu1 : System.Web.UI.Page
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
                Button1.Visible = true;
                btnAdd.Visible = true;
                Button3.Visible = true;
                Button5.Visible = true;
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
               for (int k = 0; k < tep.Length;k++ )
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
            adminPager.TableName = "(select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2)";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            string sql = "select * from (select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37  from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2) where 1= 1 ";
            
            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and t_xiangmu1.col4 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and t_xiangmu1.col5 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col1 like '%" + this.txtcol3.Text.Trim() + "%' ");
                //arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and t_xiangmu1.col1 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col8 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and t_xiangmu1.col8 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col7 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and t_xiangmu1.col7 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col9 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and t_xiangmu1.col9 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
                sql += " and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            }

           
            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            Decimal d1 = 0;
            Decimal d2 = 0;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                d1 += dtAll.Rows[i]["col14"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col14"].ToString());
                d2 += dtAll.Rows[i]["col18"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col18"].ToString());
            }
            Label合计1.Text = "结算金额含税总计: " + (d1.ToString("F2") == "0.00" ? "0" : d1.ToString("F2"));
            Label合计2.Text = "审定金额含税总计: " + (d2.ToString("F2") == "0.00" ? "0" : d2.ToString("F2"));

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable(memoryPage);
            this.GridView1.DataBind();
        }

        protected void btn查询_Click(object sender, EventArgs e)
        {
            quanxian();
            this.GridBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu1Add.aspx?id=" + "" + "", false);
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol13")).Text;
                    string str项目经理 = ((Label)GridView1.Rows[k].FindControl("lblcol6")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(str项目经理))
                    {
                        SetWarningMessage("不能修改其他人创建的项目！");
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

                    Response.Redirect("xiangmu1Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "", false);
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
            xiangmu1List xiangmu1List = new xiangmu1List();
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
                    string sql = "select *  from t_caiwu2  where col9 = '" + lblcol1 + "' and col10 = '" + lblcol2 + "' and col11 = '" + lblcol3 + "' and col55 like '%确定开票%'  ";
                    DataTable dataSource = oledbHelper.GetDataTable(sql);

                    if (dataSource.Rows.Count > 0)
                    {
                        SetWarningMessage("不能删除已经开过票的项目！");
                        return;
                    }

                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol13")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能删除其他人创建的项目！");
                        return;
                    }

                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    xiangmu1List.DeleteData(int.Parse(tickedFormNo));
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
            string str = "项目立项管理" + dt.ToString("yyyyMMddhhmmss");
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
                dr["A12"] = dtAll.Rows[i]["col31"].ToString();
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
               
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目立项管理下载模板.xlsx", downloadTable, str);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("shangchuan3.aspx?id=" + "xiangmu1" + "", false);

        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }

        protected List<xiangmu1List> checkUploadData(DataTable dt)
        {
            List<xiangmu1List> xiangmu1List = new List<xiangmu1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xiangmu1List list = new xiangmu1List();
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
               
                list.col5 = dt.Rows[i][5].ToString();
                list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString();
                list.col8 = dt.Rows[i][8].ToString();
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString();
                list.col15 = "1";
                list.col16 = "";
                list.col17 = "";
                list.col18 = "";
                list.col19 = "";
                list.col20 = "";
                list.col21 = "";
               
                xiangmu1List.Add(list);
            }
            return xiangmu1List;
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
                string lblcol13 = ((Label)e.Row.FindControl("lblcol13")).Text;
                if (this.Session["UserName"].ToString() != lblcol13 && this.Session["RoleValue"].ToString() != "1")
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = false;
                }

                string str项目经理 = ((Label)e.Row.FindControl("lblcol6")).Text;
                if (this.Session["RoleValue"].ToString() != "1" && hdtemp.Text.Contains(str项目经理))
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = true;
                }

                string temp1 = txtcol1.Text.Trim();
                string temp2 = txtcol2.Text.Trim();
                string temp3 = txtcol3.Text.Trim();
                string temp4 = txtcol4.Text.Trim();
                string temp5 = txtcol5.Text.Trim();
                string temp6 = txtcol6.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();

                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol8")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "xiangmu1Add.aspx?id=" + strid + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
             
                ((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol21")).Width = ((Label)e.Row.FindControl("lblcol21")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol21")).Width : ((Label)e.Row.FindControl("lblcol21")).Text.Trim().Length * 12;
                
                if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 200)
                {
                    ((Label)e.Row.FindControl("lblcol1")).Width = 200;
                }
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
                if (((Label)e.Row.FindControl("lblcol6")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol6")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol7")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol8")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol8")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol21")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol21")).Width = 150;
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
                        ((Label)e.Row.FindControl("lblcol35")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol35")).Text) *100).ToString("F0") + "%";
                    }
                }
                
                //((Label)e.Row.FindControl("lblcol341")).Text = ((Label)e.Row.FindControl("lblcol341")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol341")).Text).ToString("F2");
                ((Label)e.Row.FindControl("lblcol351")).Text = ((Label)e.Row.FindControl("lblcol351")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol351")).Text).ToString("F2");
                ((Label)e.Row.FindControl("lblcol342")).Text = ((Label)e.Row.FindControl("lblcol342")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol342")).Text).ToString("F2");
                if (((Label)e.Row.FindControl("lblcol343")).Text.Trim() != "")
                {
                    if (((Label)e.Row.FindControl("lblcol343")).Text.Trim().Contains("%"))
                    {
                        ((Label)e.Row.FindControl("lblcol343")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("lblcol343")).Text.Replace("%", "")) / 100).ToString("F2");
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblcol343")).Text = Convert.ToDecimal(((Label)e.Row.FindControl("lblcol343")).Text).ToString("F2");
                    }
                }
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
                ((Label)e.Row.FindControl("lblcol353")).Text = ((Label)e.Row.FindControl("lblcol353")).Text.Trim() == "" ? "" : Convert.ToDecimal(((Label)e.Row.FindControl("lblcol353")).Text).ToString("F2");
                


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
                    if (((CheckBox)r.FindControl("Chk电子版合同")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl电子版合同")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl电子版合同")).Text.Trim();

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

                    if (((CheckBox)r.FindControl("Chk合同扫描件")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl合同扫描件")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl合同扫描件")).Text.Trim();

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
                    if (((CheckBox)r.FindControl("Chk合同其他附件")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl合同其他附件")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl合同其他附件")).Text.Trim();

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