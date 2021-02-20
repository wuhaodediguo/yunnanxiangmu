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
    public partial class xiangmu8_1 : System.Web.UI.Page
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
                btnExport1.Visible = true;
                btnExport2.Visible = true;
      
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
            adminPager.TableName = "t_xiangmu31";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            string sql = "select * from t_xiangmu31 where 1= 1 ";

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
            

            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (col3 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (col3 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) ";

            //}

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            //Decimal d1 = 0;
            //Decimal d2 = 0;
            //for (int i = 0; i < dtAll.Rows.Count; i++)
            //{
            //    d1 += dtAll.Rows[i]["col14"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col14"].ToString());
            //    d2 += dtAll.Rows[i]["col18"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col18"].ToString());
            //}
            //Label合计1.Text = "结算金额含税总计: " + (d1.ToString("F2") == "0.00" ? "0" : d1.ToString("F2"));
            //Label合计2.Text = "审定金额含税总计: " + (d2.ToString("F2") == "0.00" ? "0" : d2.ToString("F2"));

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
            Response.Redirect("xiangmu8_1Add.aspx?id=" + "" + "", false);
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu8.aspx?id=" + "" + "", false);
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol3")).Text;
                    string str项目经理 = ((Label)GridView1.Rows[k].FindControl("lblcol6")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能修改其他人创建的项目！");
                        return;
                    }
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                   
                    string temp7 = this.ListPager.CurrentPageIndex.ToString();

                    Response.Redirect("xiangmu8_1Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp7=" + temp7 + "", false);
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
            xiangmu31List xiangmu1List = new xiangmu31List();
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
                   
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql = "select *  from t_xiangmu32  where col1 = '" + lblcol1 + "' and col2 = '" + lblcol2 + "'   ";
                    DataTable dataSource = oledbHelper.GetDataTable(sql);

                    if (dataSource.Rows.Count > 0)
                    {
                        SetWarningMessage("不能删除已经上报的项目月报汇总内容！");
                        return;
                    }

                    string sql2 = "select *  from t_xiangmu3  where col1 = '" + lblcol1 + "' and col2 = '" + lblcol2 + "'   ";
                    DataTable dataSource2 = oledbHelper.GetDataTable(sql2);
                    if (dataSource2.Rows.Count > 0)
                    {
                        SetWarningMessage("不能删除已经上报的项目月报汇总内容！");
                        return;
                    }


                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol3")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能删除其他人创建的月份！");
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
            string str = "项目月报--月份" + dt.ToString("yyyyMMddhhmmss");
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
            
            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();

                string str1 = dtAll.Rows[i]["col1"].ToString();
                string str2 = dtAll.Rows[i]["col2"].ToString();

                decimal amount1 = 0;
                decimal amount2 = 0;
                decimal amount3 = 0;
                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu3 where col1 = '" + str1 + "' and col2 = '" + str2 + "'  ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        amount1 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col11"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col11"].ToString());
                        amount2 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col13"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col13"].ToString());
                        amount3 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col14"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col14"].ToString());
                    }
                }
                dr["A4"] = amount1.ToString("F2");
                dr["A5"] = amount2.ToString("F2");
                dr["A6"] = amount3.ToString("F2");
                dr["A7"] = dtAll.Rows[i]["col5"].ToString() == "" ? "未上报" : "已经上报";

                
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目月报--月份下载模板.xlsx", downloadTable, str);
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
                string temp1 = ((Label)e.Row.FindControl("lbl状态")).Text;
                //if (temp1 == "上报")
                //{
                //    ((LinkButton)e.Row.FindControl("lbtn3")).Enabled = false;

                //}

                string str1 = ((Label)e.Row.FindControl("lblcol1")).Text;
                string str2 = ((Label)e.Row.FindControl("lblcol2")).Text;

                DateTime date1 = Convert.ToDateTime(str1 + str2 + "10");
                DateTime date2 = DateTime.Now;
                if (DateTime.Compare(date1.AddMonths(1), date2) < 0)
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Text = "查看";
                    ((LinkButton)e.Row.FindControl("lbtn3")).Enabled = true;
                    ((LinkButton)e.Row.FindControl("lbtn4")).Visible = false;

                }

                decimal amount1 = 0;
                decimal amount2 = 0;
                decimal amount3 = 0;
                decimal amount11 = 0;
                decimal amount12 = 0;
                decimal amount13 = 0;
                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu32 where col1 = '" + str1 + "' and col2 = '" + str2 + "' ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string str11 = ds.Tables[0].Rows[i]["col1"].ToString();
                        string str12 = ds.Tables[0].Rows[i]["col2"].ToString();
                        string str13 = ds.Tables[0].Rows[i]["col3"].ToString();
                        string str14 = ds.Tables[0].Rows[i]["col4"].ToString();
 
                        
                        DataSet ds2 = Sql.SqlQueryDS("select * from t_xiangmu3 where col1 = '" + str11 + "' and col2 = '" + str12 + "' and col3 = '" + str13 + "' and col4 = '" + str14 + "' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                            {
                                var t1 = ds2.Tables[0].Rows[k]["col11"].ToString().Replace("..", ".").Replace("（不含税）", ".").Replace("（含税）", ".");
                                var t2 = ds2.Tables[0].Rows[k]["col13"].ToString().Replace("..", ".").Replace("（不含税）", ".").Replace("（含税）", ".");
                                var t3 = ds2.Tables[0].Rows[k]["col14"].ToString().Replace("..", ".").Replace("（不含税）", ".").Replace("（含税）", ".");
                                if (t1.EndsWith("."))
                                {
                                    t1 = t1.Substring(0, t1.Length  - 1);
                                }
                                if (t2.EndsWith("."))
                                {
                                    t2 = t2.Substring(0, t2.Length - 1);
                                }
                                if (t3.EndsWith("."))
                                {
                                    t3 = t3.Substring(0, t3.Length - 1);
                                }

                                amount11 += Convert.ToDecimal(t1 == "" ? "0" : t1);
                                amount12 += Convert.ToDecimal(t2 == "" ? "0" : t2);
                                amount13 += Convert.ToDecimal(t3 == "" ? "0" : t3);
                            }
                        }
                      
                    }
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    amount1 += Convert.ToDecimal(ds.Tables[0].Rows[i]["col11"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["col11"].ToString());
                    //    amount2 += Convert.ToDecimal(ds.Tables[0].Rows[i]["col13"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["col13"].ToString());
                    //    amount3 += Convert.ToDecimal(ds.Tables[0].Rows[i]["col14"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["col14"].ToString());
                    //}
                }
                ((Label)e.Row.FindControl("lblcol11")).Text = amount11.ToString("F2");
                ((Label)e.Row.FindControl("lblcol13")).Text = amount12.ToString("F2");
                ((Label)e.Row.FindControl("lblcol14")).Text = amount13.ToString("F2");
                 

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
            string lblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);
            string lblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);

            if (e.CommandName == "lbtn13" && ((LinkButton)e.CommandSource).Text == "查看")
            {
                Response.Redirect("xiangmu8_2.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "", false);
            }
            else if (e.CommandName == "lbtn13" && ((LinkButton)e.CommandSource).Text != "查看")
            {
                //xiangmu32List shichangList = new xiangmu32List();
                //shichangList.ID = int.Parse(rowIDs);

                ////shichangList.GetData(shichangList.ID);

                //shichangList.col7 = "上报";

                //shichangList.UpdateData2(shichangList.ID);
                //this.GridBind();
                Response.Redirect("xiangmu8_2.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&modelss=上报", false);
            }

            if (e.CommandName == "lbtn14" && ((LinkButton)e.CommandSource).Text == "查看")
            {
                Response.Redirect("xiangmu8_2.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&model=上报", false);
            }
            

        }

        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", message);
            return;
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {
            string @sql = "select t_xiangmu31.col1,t_xiangmu31.col2,t_xiangmu32.col3,t_xiangmu32.col4,t_xiangmu32.col5,t_xiangmu32.col6,t_xiangmu32.col7  from t_xiangmu31 left join t_xiangmu32  on t_xiangmu32.col1 = t_xiangmu31.col1 and  t_xiangmu32.col2 = t_xiangmu31.col2 where 1=1  ";
            if (this.txtcol1.Text.Trim() != "")
            {
                sql += " and t_xiangmu31.col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                sql += " and t_xiangmu31.col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }

            OledbHelper oledbHelper = new OledbHelper();

            DataTable dtAll = oledbHelper.GetDataTable(sql);

            DateTime dt = System.DateTime.Now;
            string str = "项目部月报列表" + dt.ToString("yyyyMMddhhmmss");
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

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();

                dr["A4"] = dtAll.Rows[i]["col3"].ToString();

                dr["A5"] = dtAll.Rows[i]["col4"].ToString();

                string str1 = dtAll.Rows[i]["col1"].ToString();
                string str2 = dtAll.Rows[i]["col2"].ToString();
                string str3 = dtAll.Rows[i]["col3"].ToString();
                string str4 = dtAll.Rows[i]["col4"].ToString();
                decimal amount1 = 0;
                decimal amount2 = 0;
                decimal amount3 = 0;
                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu3 where col1 = '" + str1 + "' and col2 = '" + str2 + "' and col3 = '" + str3 + "' and col4 = '" + str4 + "' ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        amount1 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col11"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col11"].ToString());
                        amount2 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col13"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col13"].ToString());
                        amount3 += Convert.ToDecimal(ds.Tables[0].Rows[k]["col14"].ToString() == "" ? "0" : ds.Tables[0].Rows[k]["col14"].ToString());
                    }
                }
                dr["A6"] = amount1.ToString("F2");
                dr["A7"] = amount2.ToString("F2");
                dr["A8"] = amount3.ToString("F2");
                dr["A9"] = dtAll.Rows[i]["col7"].ToString() == "" ? "未上报" : "已经上报";

                DateTime date1 = Convert.ToDateTime(str1 + str2 + "10");
                DateTime date2 = DateTime.Now;
                if (DateTime.Compare(date1.AddMonths(1), date2) < 0)
                {
                    dr["A9"] = "已经上报";

                }

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目部月报列表下载模板.xlsx", downloadTable, str);
        }

        protected void btnExport2_Click(object sender, EventArgs e)
        {
            string sql = "select t_xiangmu32.col1,t_xiangmu32.col2,t_xiangmu32.col3,t_xiangmu32.col4,t_xiangmu3.col5,t_xiangmu3.col6,t_xiangmu3.col7,t_xiangmu3.col8,t_xiangmu3.col9,t_xiangmu3.col10,t_xiangmu3.col11,t_xiangmu3.col12,t_xiangmu3.col13,t_xiangmu3.col14,t_xiangmu3.col15,t_xiangmu3.col16,t_xiangmu3.col17,t_xiangmu3.col18,t_xiangmu3.col19  from t_xiangmu32 left join t_xiangmu3 on t_xiangmu32.col1 = t_xiangmu3.col1 and  t_xiangmu32.col2 = t_xiangmu3.col2 and t_xiangmu32.col3 = t_xiangmu3.col3 and  t_xiangmu32.col4 = t_xiangmu3.col4 where 1=1  ";

            if (this.txtcol1.Text.Trim() != "")
            {
                sql += " and t_xiangmu32.col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                sql += " and t_xiangmu32.col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }

            OledbHelper oledbHelper = new OledbHelper();

            DataTable dtAll = oledbHelper.GetDataTable(sql);

            DateTime dt = System.DateTime.Now;
            string str = "项目部月报明细列表" + dt.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");

            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A20");

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
                dr["A15"] = dtAll.Rows[i]["col12"].ToString();
                dr["A13"] = dtAll.Rows[i]["col13"].ToString();
                dr["A14"] = dtAll.Rows[i]["col14"].ToString();

                dr["A16"] = dtAll.Rows[i]["col15"].ToString();
                dr["A17"] = dtAll.Rows[i]["col16"].ToString();
                dr["A18"] = dtAll.Rows[i]["col17"].ToString();
                dr["A19"] = dtAll.Rows[i]["col18"].ToString();
                dr["A20"] = dtAll.Rows[i]["col19"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目部月报明细列表下载模板.xlsx", downloadTable, str);
        }


    }
}