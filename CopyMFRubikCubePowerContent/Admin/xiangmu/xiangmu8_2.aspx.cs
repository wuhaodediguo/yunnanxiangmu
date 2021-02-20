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
    public partial class xiangmu8_2 : System.Web.UI.Page
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
            if (this.Session["RoleValue"].ToString() != "1")
            {
              
                divbtnAdd.Visible = false;
                divButton5.Visible = false;

            }
            if (base.Request.QueryString["modelss"] == "上报")
            {
                divbtnAdd.Visible = true;
                divButton5.Visible = true;
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
            string lblcol1 = base.Request.QueryString["lblcol1"];
            string lblcol2 = base.Request.QueryString["lblcol2"];

            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "t_xiangmu32";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            string sql = "select * from t_xiangmu32 where 1= 1 ";

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

            if (lblcol1 != "" && lblcol1 != null)
            {
                where.Append(" and col1 = '" + lblcol1 + "' ");
                sql += " and col1 = '" + lblcol1 + "' ";
            }
            if (lblcol2 != "" && lblcol2 != null)
            {
                where.Append(" and col2 = '" + lblcol2 + "' ");
                sql += " and col2 = '" + lblcol2 + "' ";
            }
            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (col17 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (col17 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) ";

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
            string lblcol1 = base.Request.QueryString["lblcol1"];
            string lblcol2 = base.Request.QueryString["lblcol2"];

            Response.Redirect("xiangmu8_2Add.aspx?id=" + "" + "&lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "", false);
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu8_1.aspx?id=" + "" + "", false);
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
                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol5")).Text;
                    string str项目经理 = ((Label)GridView1.Rows[k].FindControl("lblcol3")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(str项目经理))
                    {
                        SetWarningMessage("不能修改其他人创建的项目！");
                        return;
                    }
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();

                    string str1 = ((Label)GridView1.Rows[k].FindControl("lblcol1")).Text;
                    string str2 = ((Label)GridView1.Rows[k].FindControl("lblcol2")).Text;
               
                    DateTime date1 = Convert.ToDateTime(str1 + str2 + "10");
                    DateTime date2 = DateTime.Now;
                    if (DateTime.Compare(date1.AddMonths(1), date2) < 0)
                    {
                        SetWarningMessage("10号之后不能编辑上个月的！");
                        return;
                        
                    }

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();
                    string lblcol1 = base.Request.QueryString["lblcol1"];
                    string lblcol2 = base.Request.QueryString["lblcol2"];

                    Response.Redirect("xiangmu8Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp7=" + temp7 + "&lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "", false);
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
            xiangmu32List xiangmu32List = new xiangmu32List();
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
                    var lblcol4 = ((Label)GridView1.Rows[k].FindControl("lblcol4")).Text;
                    OledbHelper oledbHelper = new OledbHelper();
                    string sql2 = "select *  from t_xiangmu3  where col1 = '" + lblcol1 + "' and col2 = '" + lblcol2 + "' and col3 = '" + lblcol3 + "' and col4 = '" + lblcol4 + "'   ";
                    DataTable dataSource2 = oledbHelper.GetDataTable(sql2);
                    if (dataSource2.Rows.Count > 0)
                    {
                        SetWarningMessage("不能删除已经上报的项目月报汇总内容！");
                        return;
                    }

                    string str1 = ((Label)GridView1.Rows[k].FindControl("lblcol1")).Text;
                    string str2 = ((Label)GridView1.Rows[k].FindControl("lblcol2")).Text;

                    DateTime date1 = Convert.ToDateTime(str1 + str2 + "10");
                    DateTime date2 = DateTime.Now;
                    if (DateTime.Compare(date1.AddMonths(1), date2) < 0)
                    {
                        SetWarningMessage("10号之后不能编辑上个月的！");
                        return;

                    }

                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol5")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能删除其他人创建的项目部！");
                        return;
                    }

                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    xiangmu32List.DeleteData(int.Parse(tickedFormNo));
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
            string str = "项目月报--项目部" + dt.ToString("yyyyMMddhhmmss");
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

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目月报--项目部下载模板.xlsx", downloadTable, str);
        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
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
                if (temp1 == "上报")
                {
                    //((LinkButton)e.Row.FindControl("lbtn3")).Enabled = false;
                   
                    ((Label)e.Row.FindControl("lbl状态")).Text = "已经上报";
                }
                else
                {
                    ((Label)e.Row.FindControl("lbl状态")).Text = "未上报";
                }

                string str1 = ((Label)e.Row.FindControl("lblcol1")).Text;
                string str2 = ((Label)e.Row.FindControl("lblcol2")).Text;
                string str3 = ((Label)e.Row.FindControl("lblcol3")).Text;
                string str4 = ((Label)e.Row.FindControl("lblcol4")).Text;

                DateTime date1 = Convert.ToDateTime(str1 + str2 + "10");
                DateTime date2 = DateTime.Now;
                if (DateTime.Compare(date1.AddMonths(1), date2) < 0)
                {
                    ((Label)e.Row.FindControl("lbl状态")).Text = "已经上报";
                    ((LinkButton)e.Row.FindControl("lbtn3")).Text = "查看";
                    ((LinkButton)e.Row.FindControl("lbtn3")).Enabled = true;
                    //((LinkButton)e.Row.FindControl("lbtn4")).Visible = false;

                }

                decimal amount1 = 0;
                decimal amount2 = 0;
                decimal amount3 = 0;
                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu3 where col1 = '" + str1 + "' and col2 = '" + str2 + "' and col3 = '" + str3 + "' and col4 = '" + str4 + "' ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                    {
                        amount1 += Convert.ToDecimal(ds.Tables[0].Rows[i]["col11"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["col11"].ToString());
                        amount2 += Convert.ToDecimal(ds.Tables[0].Rows[i]["col13"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["col13"].ToString());
                        amount3 += Convert.ToDecimal(ds.Tables[0].Rows[i]["col14"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["col14"].ToString());
                    }
                    ((Label)e.Row.FindControl("lbl状态")).Text = "已经上报";
                }
                ((Label)e.Row.FindControl("lblcol11")).Text = amount1.ToString("F2");
                ((Label)e.Row.FindControl("lblcol13")).Text = amount2.ToString("F2");
                ((Label)e.Row.FindControl("lblcol14")).Text = amount3.ToString("F2");

                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 100;
                }

                if (this.Session["RoleValue"].ToString() != "1" && base.Request.QueryString["modelss"] != "上报")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;

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
            string lblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);
            string lblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
            string lblcol3 = Convert.ToString(((Label)row.FindControl("lblcol3")).Text);
            string lblcol4 = Convert.ToString(((Label)row.FindControl("lblcol4")).Text);
            var ticked创建人 = Convert.ToString(((Label)row.FindControl("lblcol5")).Text);

            if (e.CommandName == "lbtn13" && ((LinkButton)e.CommandSource).Text == "查看")
            {
                if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(lblcol3))
                {
                    SetWarningMessage("不能查看或上报其他人创建的项目！");
                    return;
                }
                Response.Redirect("xiangmu8.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&lblcol3=" + lblcol3 + "&lblcol4=" + lblcol4 + "", false);
            }
            else if (e.CommandName == "lbtn13" && ((LinkButton)e.CommandSource).Text != "查看")
            {
                if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(lblcol3))
                {
                    SetWarningMessage("不能查看或上报其他人创建的项目！");
                    return;
                }
                Response.Redirect("xiangmu8.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&lblcol3=" + lblcol3 + "&lblcol4=" + lblcol4 + "", false);

            }
            if (e.CommandName == "lbtn14" && ((LinkButton)e.CommandSource).Text == "查看")
            {
                if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1" && !hdtemp.Text.Contains(lblcol3))
                {
                    SetWarningMessage("不能查看或上报其他人创建的项目！");
                    return;
                }
                Response.Redirect("xiangmu8.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&lblcol3=" + lblcol3 + "&lblcol4=" + lblcol4 + "", false);
            }


        }

        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", message);
            return;
        }

    }

}