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
    public partial class hezuo5 : System.Web.UI.Page
    {
        public int memoryPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.quanxian();
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
            }
            else
            {
                this.AlertDiv.InnerHtml = "";
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

        protected void ListPager_PageChanged(object sender, System.EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "(SELECT aa.*,t_xiangmu1.col11,t_xiangmu1.col15 from (SELECT col1,col2,col5,col6 ,sum(col9) as col9,col10,col23,col24,max(ID)as ID  from(SELECT * from (SELECT col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24,max(ID) as ID FROM t_hezuo4  group by col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24) where 1= 1  )    group by col1,col2,col5,col6 ,col10,col23,col24) aa left join t_xiangmu1 on   t_xiangmu1.col1 = aa.col23 and  t_xiangmu1.col2 = aa.col24 and  t_xiangmu1.col8 = aa.col5 and  t_xiangmu1.col9 = aa.col6)";
            adminPager.strGetFields = "*";
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            System.Text.StringBuilder where = new System.Text.StringBuilder();
            where.Append(" where 1=1  ");
            string sql = "SELECT aa.*,t_xiangmu1.col11,t_xiangmu1.col15 from (SELECT col1,col2,col5,col6 ,sum(col9) as col9,col10,col23,col24,max(ID)as ID  from(SELECT * from (SELECT col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24,max(ID) as ID FROM t_hezuo4  group by col1,col2,col3,col4,col5,col6,col7,col8,col9,col10,col17,col18,col19,col20,col21,col22,col23,col24) where 1= 1  )     group by col1,col2,col5,col6 ,col10,col23,col24) aa left join t_xiangmu1 on   t_xiangmu1.col1 = aa.col23 and  t_xiangmu1.col2 = aa.col24 and  t_xiangmu1.col8 = aa.col5 and  t_xiangmu1.col9 = aa.col6 where 1=1  ";
            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql = sql + " and aa.col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col2 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql = sql + " and aa.col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and col23 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql = sql + " and aa.col23 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col24 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql = sql + " and aa.col24 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql = sql + " and aa.col5 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col6 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql = sql + " and aa.col6 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }
            if (this.hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append(" and ( col1 in (" + this.hdtemp.Text + ") )  ");
                sql = sql + " and ( aa.col1 in (" + this.hdtemp.Text + ") ) ";
            }
            OledbHelper oledbHelper = new OledbHelper();
            this.ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql, new object[0]);
            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable(memoryPage);
            this.GridView1.DataBind();
        }

        protected void btn查询_Click(object sender, System.EventArgs e)
        {
            this.GridBind();
        }

        protected void btn编辑_Click(object sender, System.EventArgs e)
        {
            System.Collections.Generic.List<string> formNoList = new System.Collections.Generic.List<string>();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox checkedControl = (CheckBox)this.GridView1.Rows[i].FindControl("chk");
                if (checkedControl != null)
                {
                    bool ifTick = checkedControl.Checked;
                    if (ifTick)
                    {
                        string ticked创建人 = ((Label)this.GridView1.Rows[i].FindControl("lblcol11")).Text;
                        if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                        {
                            this.SetWarningMessage("不能修改其他人创建的结算明细！");
                            return;
                        }
                        string tickedFormNo = ((Label)this.GridView1.Rows[i].FindControl("lblID")).Text;
                        formNoList.Add(tickedFormNo);
                        base.Response.Redirect("hezuo4Add.aspx?idno=" + tickedFormNo, false);
                        break;
                    }
                }
            }
            if (formNoList.Count == 0)
            {
                this.SetWarningMessage("请至少选择一项勾选！");
                return;
            }
        }

        protected void btn删除_Click(object sender, System.EventArgs e)
        {
            hezuo4List hezuo4List = new hezuo4List();
            System.Collections.Generic.List<string> formNoList = new System.Collections.Generic.List<string>();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox checkedControl = (CheckBox)this.GridView1.Rows[i].FindControl("chk");
                if (checkedControl != null)
                {
                    bool ifTick = checkedControl.Checked;
                    if (ifTick)
                    {
                        string ticked创建人 = ((Label)this.GridView1.Rows[i].FindControl("lblcol11")).Text;
                        if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                        {
                            this.SetWarningMessage("不能删除其他人创建的结算明细！");
                            return;
                        }
                        string tickedFormNo = ((Label)this.GridView1.Rows[i].FindControl("lblID")).Text;
                        formNoList.Add(tickedFormNo);
                        hezuo4List.DeleteData(int.Parse(tickedFormNo));
                    }
                }
            }
            if (formNoList.Count == 0)
            {
                this.SetWarningMessage("请至少选择一项勾选！");
                return;
            }
            this.GridBind();
        }

        protected void btnExport_Click(object sender, System.EventArgs e)
        {
            DataTable dtAll = (DataTable)this.ViewState["GridDataSource"];
            string str = "施工队项目明细" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
            str += ".xlsx";
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
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                DataRow dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                dr["A4"] = dtAll.Rows[i]["col23"].ToString();
                dr["A5"] = dtAll.Rows[i]["col24"].ToString();
                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                dr["A8"] = dtAll.Rows[i]["col11"].ToString();
                dr["A9"] = dtAll.Rows[i]["col15"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();
                downloadTable.Rows.Add(dr);
            }
            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/施工队项目明细下载模板.xlsx", downloadTable, str);
            
        }

        protected void btnUpload_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect("shangchuan4.aspx?id=hezuo1", false);
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
                ((Label)e.Row.FindControl("lblcol1")).Width = ((((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol1")).Width : (((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12));
                ((Label)e.Row.FindControl("lblcol2")).Width = ((((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol2")).Width : (((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12));
                ((Label)e.Row.FindControl("lblcol3")).Width = ((((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol3")).Width : (((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12));
                ((Label)e.Row.FindControl("lblcol4")).Width = ((((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol4")).Width : (((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12));
                ((Label)e.Row.FindControl("lblcol5")).Width = ((((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol5")).Width : (((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12));
                ((Label)e.Row.FindControl("lblcol6")).Width = ((((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0) ? ((Label)e.Row.FindControl("lblcol6")).Width : (((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12));
                if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 110.0)
                {
                    ((Label)e.Row.FindControl("lblcol1")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 80.0)
                {
                    ((Label)e.Row.FindControl("lblcol2")).Width = 80;
                }
                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 110.0)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 110.0)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 110.0)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 110;
                }
                if (((Label)e.Row.FindControl("lblcol6")).Width.Value < 110.0)
                {
                    ((Label)e.Row.FindControl("lblcol6")).Width = 110;
                }
                ((Label)e.Row.FindControl("lbl项目结算金额")).Text = ((((Label)e.Row.FindControl("lbl项目结算金额")).Text.Trim() == "") ? "" : System.Convert.ToDecimal(((Label)e.Row.FindControl("lbl项目结算金额")).Text.Trim()).ToString("F2"));
                ((Label)e.Row.FindControl("lbl项目审定金额")).Text = ((((Label)e.Row.FindControl("lbl项目审定金额")).Text.Trim() == "") ? "" : System.Convert.ToDecimal(((Label)e.Row.FindControl("lbl项目审定金额")).Text.Trim()).ToString("F2"));
                ((Label)e.Row.FindControl("lbl施工队结算金额")).Text = ((((Label)e.Row.FindControl("lbl施工队结算金额")).Text.Trim() == "") ? "" : System.Convert.ToDecimal(((Label)e.Row.FindControl("lbl施工队结算金额")).Text.Trim()).ToString("F2"));
            }
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
        }

        
        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", message);
        }

    }
}