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
    public partial class shouye : System.Web.UI.Page
    {
        public int memoryPage = 0;
        public string strcase = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!base.IsPostBack)
            {
                OledbHelper oledbHelper = new OledbHelper();
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
                if (this.Session["CreateDate"] != null && DateTime.Compare(Convert.ToDateTime(this.Session["CreateDate"].ToString()).AddMonths(3), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script Language=Javascript>if( confirm('" + "密码3个月需要更换一次！" + "') ) {document.location.href='" + "../User/Profile.aspx" + "'; } else {   }</script>");
                    //Response.Write("javascript:alert('密码3个月需要更换一次！'");
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "密码3个月需要更换一次！");

                }
                if (this.Session["password"] != null && this.Session["password"].ToString() == "e10adc3949ba59abbe56e057f20f883e")
                {
                    System.Web.HttpContext.Current.Response.Write("<script Language=Javascript>if( confirm('" + "请及时更换初始密码！" + "') ) {document.location.href='" + "../User/Profile.aspx" + "'; } else {   }</script>");
                    //Response.Write("javascript:alert('密码3个月需要更换一次！'");
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请及时更换初始密码！");

                }
                if (strcase == "")
                {
                    Label7.Text = "待办   >开票审批";
                }
                else if (strcase == "2")
                {
                    Label7.Text = "待办   >资料提交";
                }
                else if (strcase == "3")
                {
                    Label7.Text = "已办   >开票审批";
                }
                else if (strcase == "4")
                {
                    Label7.Text = "已办   >资料提交";
                }
                else if (strcase == "5")
                {
                    Label7.Text = "待办   >结算审批";
                }
                else if (strcase == "6")
                {
                    Label7.Text = "已办   >结算审批";
                }
                else if (strcase == "7")
                {
                    Label7.Text = "待办   >收款管理";
                }
                else if (strcase == "8")
                {
                    Label7.Text = "已办   >收款管理";
                }
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();

                

            }
            else
            {
                AlertDiv.InnerHtml = "";
            }
        }


        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            strcase = tempcase.Text;
            this.GridBind();
        }

        private void GridBind()
        {
            tempcase.Text = strcase;
            if (strcase == "")
            {
                Label7.Text = "待办   >开票审批";
            }
            else if (strcase == "2")
            {
                Label7.Text = "待办   >资料提交";
            }
            else if (strcase == "3")
            {
                Label7.Text = "已办   >开票审批";
            }
            else if (strcase == "4")
            {
                Label7.Text = "已办   >资料提交";
            }
            else if (strcase == "5")
            {
                Label7.Text = "待办   >结算审批";
            }
            else if (strcase == "6")
            {
                Label7.Text = "已办   >结算审批";
            }
            else if (strcase == "7")
            {
                Label7.Text = "待办   >收款管理";
            }
            else if (strcase == "8")
            {
                Label7.Text = "已办   >收款管理";
            }
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            string sql = string.Empty;
            string sql2 = string.Empty;
            string sql3 = string.Empty;
            string sql4 = string.Empty;
            string sql5 = string.Empty;
            string sql6 = string.Empty;
            string sql7 = string.Empty;
            string sql8 = string.Empty;
            hdstrcase.Value = strcase;
            hdUserName.Value = this.Session["FullName"].ToString();
            hdRoleValue.Value = this.Session["RoleValue"].ToString();

            if (strcase == "" || strcase == "3")
            {
                adminPager.TableName = "t_caiwu2";
            }
            else if (strcase == "2" || strcase == "4")
            {
                adminPager.TableName = "t_caiwu22";
            }
            else if (strcase == "5" || strcase == "6")
            {
                adminPager.TableName = "t_caiwu5";
            }
            else if (strcase == "7" || strcase == "8")
            {
                adminPager.TableName = "t_caiwu2view";
            }
            
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            OledbHelper oledbHelper = new OledbHelper();
            
            if (strcase == "")
            {
                where.Append(" where 1=1 and col55 like '%未审批%' ");
                //审核人员
                where.Append("  and col62 = '" + this.Session["FullName"].ToString() + "' ");
                if (this.Session["RoleValue"].ToString() != "1")
                {
                    
                }
            }
            else if (strcase == "2")
            {
                where.Append(" where 1=1 and col30 = '0' ");

                where.Append(" and col41 = '" + this.Session["FullName"].ToString() + "' ");
                if (this.Session["RoleValue"].ToString() != "1")
                {
                    
                }

            }
            else if (strcase == "3")
            {
                where.Append(" where 1=1 and col55 like '%确定开票%' ");
                where.Append("  and col63 like '%" + this.Session["FullName"].ToString() + "%' ");
                if (this.Session["RoleValue"].ToString() != "1")
                {
                   
                }
            }
            else if (strcase == "4")
            {
                where.Append(" where 1=1 and col30 = '1'  ");

                where.Append(" and col41 = '" + this.Session["FullName"].ToString() + "' ");
                if (this.Session["RoleValue"].ToString() != "1")
                {
                    
                }

            }
            else if (strcase == "5")
            {
                where.Append(" where 1=1  and (col43 like '%未审批%' or col43 like '%未提交%' or col43 like '%申请结算%' or col43 like '%继续修改%')   ");

                where.Append(" and col49 = '" + this.Session["FullName"].ToString() + "' ");
                if (this.Session["RoleValue"].ToString() != "1")
                {
                    
                }

            }
            else if (strcase == "6")
            {
                where.Append(" where 1=1 and col43  not like '%未审批%' and col43  like '%审核通过%' ");

                where.Append(" and col50 like '%" + this.Session["FullName"].ToString() + "%' ");
                if (this.Session["RoleValue"].ToString() != "1")
                {
                    
                }

            }
            else if (strcase == "7")
            {
                where.Append(" where 1=1 and col55 like '%确定开票%' and col60  not like '%全部到账%'  ");

                //where.Append(" and col1 like '%" + this.Session["FullName"].ToString() + "%' ");
                if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
                {
                    where.Append(" and (col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") )  ");
                    sql += " and (col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) ";

                }

            }
            else if (strcase == "8")
            {
                where.Append(" where 1=1 and col55 like '%确定开票%' and col60  like '%全部到账%'  ");

                //where.Append(" and col1 like '%" + this.Session["FullName"].ToString() + "%' ");
                if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
                {
                    where.Append(" and (col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") )  ");
                    sql += " and (col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) ";

                }

            }


            sql = "select * from t_caiwu2 where 1=1 and col55 like '%未审批%' ";
            sql2 = "select * from t_caiwu22 where 1=1 and col30 = '0' ";
            sql3 = "select * from t_caiwu2 where 1=1 and col55 like '%确定开票%' ";
            sql4 = "select * from t_caiwu22 where 1=1 and col30 = '1' ";
            sql5 = "select * from t_caiwu5 where 1=1 and (col43 like '%未审批%' or col43 like '%未提交%' or col43 like '%申请结算%' or col43 like '%继续修改%')  ";
            sql6 = "select * from t_caiwu5 where 1=1 and col43  not like '%未审批%' and col43  like '%审核通过%' ";
            sql7 = "select * from t_caiwu2view where 1=1 and col55 like '%确定开票%' and col60  not like '%全部到账%'  ";
            sql8 = "select * from t_caiwu2view where 1=1 and col55 like '%确定开票%' and col60  like '%全部到账%'  ";
             
            sql += " and col62 = '" + this.Session["FullName"].ToString() + "' ";
            sql2 += " and col41 = '" + this.Session["FullName"].ToString() + "' ";
            sql3 += " and col63 like '%" + this.Session["FullName"].ToString() + "%' ";
            sql4 += " and col41 = '" + this.Session["FullName"].ToString() + "' ";
            sql5 += " and col49 = '" + this.Session["FullName"].ToString() + "' ";
            sql6 += " and col50 like '%" + this.Session["FullName"].ToString() + "%' ";
            if (this.Session["RoleValue"].ToString() != "1")
            {
                
            }
            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                sql7 += " and (col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) ";
                sql8 += " and (col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ") ) ";

            }
            

            DataTable dt = oledbHelper.GetDataTable(sql);
            DataTable dt2 = oledbHelper.GetDataTable(sql2);
            DataTable dt3 = oledbHelper.GetDataTable(sql3);
            DataTable dt4 = oledbHelper.GetDataTable(sql4);
            DataTable dt5 = oledbHelper.GetDataTable(sql5);
            DataTable dt6 = oledbHelper.GetDataTable(sql6);
            DataTable dt7 = oledbHelper.GetDataTable(sql7);
            DataTable dt8 = oledbHelper.GetDataTable(sql8);

            Label2.Text = dt.Rows.Count.ToString();
            Label3.Text = dt2.Rows.Count.ToString();
            Label5.Text = dt3.Rows.Count.ToString();
            Label6.Text = dt4.Rows.Count.ToString();

            Label8.Text = dt5.Rows.Count.ToString();
            Label9.Text = dt6.Rows.Count.ToString();
            Label10.Text = dt7.Rows.Count.ToString();
            Label11.Text = dt8.Rows.Count.ToString();

            Label1.Text = (dt.Rows.Count + dt2.Rows.Count + dt5.Rows.Count + dt7.Rows.Count).ToString();
            Label4.Text = (dt3.Rows.Count + dt4.Rows.Count + dt6.Rows.Count + dt8.Rows.Count).ToString();
            

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];

            if (strcase == "" || strcase == "3")
            {
                this.GridView1.Visible = true;
                this.GridView2.Visible = false;
                this.GridView3.Visible = false;
                this.GridView4.Visible = false;
                this.GridView1.DataSource = adminPager.GetTable(memoryPage);
                this.GridView1.DataBind();
                
            }
            else if (strcase == "2" || strcase == "4")
            {
                this.GridView1.Visible = false;
                this.GridView2.Visible = true;
                this.GridView3.Visible = false;
                this.GridView4.Visible = false;
                this.GridView2.DataSource = adminPager.GetTable(memoryPage);
                this.GridView2.DataBind();
            }
            else if (strcase == "5" || strcase == "6")
            {
                this.GridView1.Visible = false;
                this.GridView2.Visible = false;
                this.GridView3.Visible = true;
                this.GridView4.Visible = false;
                this.GridView3.DataSource = adminPager.GetTable(memoryPage);
                this.GridView3.DataBind();
            }
            else if (strcase == "7" || strcase == "8")
            {
                this.GridView1.Visible = false;
                this.GridView2.Visible = false;
                this.GridView3.Visible = false;
                this.GridView4.Visible = true;
                this.GridView4.DataSource = adminPager.GetTable(memoryPage);
                this.GridView4.DataBind();
            }

            if (strcase == "")
            {
                ViewState["GridDataSource"] = dt;
            }
            else if (strcase == "3")
            {
                ViewState["GridDataSource"] = dt3;
            }
            else if (strcase == "2")
            {
                ViewState["GridDataSource"] = dt2;
            }
            else if (strcase == "4")
            {
                ViewState["GridDataSource"] = dt4;
            }
            else if (strcase == "5")
            {
                ViewState["GridDataSource"] = dt5;
            }
            else if (strcase == "6")
            {
                ViewState["GridDataSource"] = dt6;
            }
            else if (strcase == "7")
            {
                ViewState["GridDataSource"] = dt7;
            }
            else if (strcase == "8")
            {
                ViewState["GridDataSource"] = dt8;
            }
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string stridno = ((Label)e.Row.FindControl("lblcol53")).Text;
                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((Label)e.Row.FindControl("lblcol2")).Text = ((Label)e.Row.FindControl("lblcol2")).Text + "开票申请";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol2")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2.aspx?idno=" + strid + "&&id=" + stridno + "&role=审核&model22=shouye";
                if (strcase == "3")
                {
                    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2.aspx?idno=" + strid + "&&id=" + stridno + "&model=view&model22=shouye";
                }
                
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string stridno = ((Label)e.Row.FindControl("lblcol53")).Text;
                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((Label)e.Row.FindControl("lblcol2")).Text = ((Label)e.Row.FindControl("lblcol2")).Text + "结算审批申请";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol2")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + strid + "&&id=" + stridno + "&role=审核&model22=shouye";
                if (strcase == "6")
                {
                    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + strid + "&&id=" + stridno + "&model=view&model22=shouye";
                }

            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var tickedFormNo = ((Label)e.Row.FindControl("lblID")).Text;

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol53")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu5Add.aspx?idno=" + tickedFormNo + "&model=view";
                if (this.Session["RoleValue"].ToString() == "1")
                {
                    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu5Add.aspx?idno=" + tickedFormNo + "&model=审核&model22=shouye";
                }
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 130;

                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = new DataTable();
            DateTime dt = System.DateTime.Now;
            DataTable downloadTable = new DataTable();
            DataRow dr;

            strcase = tempcase.Text;
            if (strcase == "")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "开票审批待办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
                downloadTable.Columns.Add("A5");
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col2"].ToString() + "开票申请";
                    dr["A3"] = dtAll.Rows[i]["col1"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col2"].ToString();

                    dr["A5"] = dtAll.Rows[i]["col55"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/开票审批导出.xlsx", downloadTable, str);
            }
            else if (strcase == "3")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "开票审批已办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
                downloadTable.Columns.Add("A5");
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col2"].ToString() + "开票申请";
                    dr["A3"] = dtAll.Rows[i]["col1"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col2"].ToString();

                    dr["A5"] = dtAll.Rows[i]["col55"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/开票审批导出.xlsx", downloadTable, str);
            }
            else if (strcase == "2")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "资料提交待办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
              
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col8"].ToString();
                    dr["A3"] = dtAll.Rows[i]["col3"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col4"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/资料提交导出.xlsx", downloadTable, str);
            }
            else if (strcase == "4")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "资料提交已办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");

                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col8"].ToString();
                    dr["A3"] = dtAll.Rows[i]["col3"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col4"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/资料提交导出.xlsx", downloadTable, str);
            }
            else if (strcase == "5")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "结算审批待办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
                downloadTable.Columns.Add("A5");
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col2"].ToString() + "结算审批申请";
                    dr["A3"] = dtAll.Rows[i]["col29"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col30"].ToString();

                    dr["A5"] = dtAll.Rows[i]["col43"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/开票审批导出.xlsx", downloadTable, str);
            }
            else if (strcase == "6")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "结算审批已办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
                downloadTable.Columns.Add("A5");
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col2"].ToString() + "结算审批申请";
                    dr["A3"] = dtAll.Rows[i]["col29"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col30"].ToString();

                    dr["A5"] = dtAll.Rows[i]["col43"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/开票审批导出.xlsx", downloadTable, str);
            }
            else if (strcase == "7")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "收款管理待办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
                downloadTable.Columns.Add("A5");
                downloadTable.Columns.Add("A6");
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col53"].ToString();
                    dr["A3"] = dtAll.Rows[i]["col9"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col666"].ToString();

                    dr["A5"] = dtAll.Rows[i]["col31"].ToString();
                    dr["A6"] = dtAll.Rows[i]["col32"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/收款管理导出.xlsx", downloadTable, str);
            }
            else if (strcase == "8")
            {
                dtAll = (DataTable)ViewState["GridDataSource"];
                string str = "收款管理已办" + dt.ToString("yyyyMMddhhmmss");
                str = str + ".xlsx";
                downloadTable.Columns.Add("A1");
                downloadTable.Columns.Add("A2");
                downloadTable.Columns.Add("A3");
                downloadTable.Columns.Add("A4");
                downloadTable.Columns.Add("A5");
                downloadTable.Columns.Add("A6");
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col53"].ToString();
                    dr["A3"] = dtAll.Rows[i]["col9"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col666"].ToString();

                    dr["A5"] = dtAll.Rows[i]["col31"].ToString();
                    dr["A6"] = dtAll.Rows[i]["col32"].ToString();

                    downloadTable.Rows.Add(dr);
                }

                MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/收款管理导出.xlsx.xlsx", downloadTable, str);
            }

            
            
            
        }



        protected void btn待办1_Click(object sender, EventArgs e)
        {
            strcase = "";
            this.GridBind();
        }

        protected void btn待办2_Click(object sender, EventArgs e)
        {
            strcase = "2";
            this.GridBind();
        }

        protected void btn已办1_Click(object sender, EventArgs e)
        {
            strcase = "3";
            this.GridBind();
        }

        protected void btn已办2_Click(object sender, EventArgs e)
        {
            strcase = "4";
            this.GridBind();
        }


        protected void btn待办3_Click(object sender, EventArgs e)
        {
            strcase = "5";
            this.GridBind();
        }

        protected void btn已办3_Click(object sender, EventArgs e)
        {
            strcase = "6";
            this.GridBind();
        }

        protected void btn待办4_Click(object sender, EventArgs e)
        {
            strcase = "7";
            this.GridBind();
        }

        protected void btn已办4_Click(object sender, EventArgs e)
        {
            strcase = "8";
            this.GridBind();
        }

       

    }
}