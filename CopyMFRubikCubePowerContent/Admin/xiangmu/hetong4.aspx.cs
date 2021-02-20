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
    public partial class hetong4 : System.Web.UI.Page
    {
        public int memoryPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.quanxian();
                this.ViewState["OrderByKey"] = "col1";
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


        protected void ListPager_PageChanged(object sender, System.EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "(select col1,col2 ,col3,col4,col5,sum(col14) as col14 from (select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2) group by col1,col2 ,col3,col4,col5)";

            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1  ");
            string sql = @"select col1,col2 ,col3,col4,col5,sum(col14) as col14 from 
                        (select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 
                        from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2) 
                        where 1= 1  ";
            
            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql = sql + " and t_xiangmu1.col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col2 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql = sql + " and t_xiangmu1.col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql = sql + " and t_xiangmu1.col4 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql = sql + " and t_xiangmu1.col5 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                adminPager.TableName = @"(select col1,col2 ,col3,col4,col5,sum(col14) as col14 from (select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2) where 1= 1 
and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  group by col1,col2 ,col3,col4,col5)";

                //where.Append(" and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
                sql += " and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            }
           
            sql = sql + " group by col1,col2 ,col3,col4,col5 ";
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

        protected void btnExport_Click(object sender, System.EventArgs e)
        {
            DataTable dtAll = (DataTable)this.ViewState["GridDataSource"];
            string str = "合同综合信息列表" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
           

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
                dr["A7"] = dtAll.Rows[i]["col14"].ToString();

                string strlblcol1 = dtAll.Rows[i]["col1"].ToString();
                string strlblcol2 = dtAll.Rows[i]["col2"].ToString();
                string strlblcol3 = dtAll.Rows[i]["col3"].ToString();
                string strlblcol4 = dtAll.Rows[i]["col4"].ToString();
                string strlblcol5 = dtAll.Rows[i]["col5"].ToString();
                string sql = @"select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 
                            from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2 where 1=1 and
                            t_xiangmu1.col1 = '" + strlblcol1 + "' and t_xiangmu1.col2 = '" + strlblcol2 + "' and t_xiangmu1.col3 = '" + strlblcol3 + "' and t_xiangmu1.col4 = '" + strlblcol4 + "' and t_xiangmu1.col5 = '" + strlblcol5 + "' ";

                OledbHelper oledbHelper = new OledbHelper();
                DataTable dtT = oledbHelper.GetDataTable(sql, new object[0]);

                decimal dlbl审定金额不含税 = 0;
                decimal dlbl审定金额含税 = 0;
                decimal 总计到账金额 = 0;
                decimal 总计开票金额 = 0;
                decimal 总计开票不含税金额 = 0;
                string 开票金额 = "0";
                string 开票不含税金额 = "0";

                for (int t = 0; t < dtT.Rows.Count; t++)
                {
                    dlbl审定金额不含税 += dtT.Rows[t]["col15"].ToString() == "" ? 0 : Convert.ToDecimal(dtT.Rows[t]["col15"].ToString());
                    dlbl审定金额含税 += dtT.Rows[t]["col18"].ToString() == "" ? 0 : Convert.ToDecimal(dtT.Rows[t]["col18"].ToString());

                    string strid = dtT.Rows[t]["ID"].ToString();

                    string fapiaono = string.Empty;

                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + strid + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                        {

                            fapiaono = ds.Tables[0].Rows[ii]["col18"].ToString();
                            DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' and col55 like '%确定开票%' ");
                            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                            {
                                开票金额 = ds.Tables[0].Rows[ii]["col31"].ToString();
                                if (开票金额 == "" || 开票金额 == "&nbsp;")
                                {
                                    开票金额 = "0";
                                }
                                总计开票金额 += Convert.ToDecimal(开票金额);

                                开票不含税金额 = ds.Tables[0].Rows[ii]["col28"].ToString();
                                if (开票不含税金额 == "" || 开票不含税金额 == "&nbsp;")
                                {
                                    开票不含税金额 = "0";
                                }
                                总计开票不含税金额 += Convert.ToDecimal(开票不含税金额);

                                DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col9 ='1' and col3= '" + ds.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        string 到账金额 = ds1.Tables[0].Rows[kkk]["col6"].ToString();
                                        if (到账金额 == "" || 到账金额 == "&nbsp;")
                                        {
                                            到账金额 = "0";
                                        }
                                        总计到账金额 += Convert.ToDecimal(到账金额);
                                    }
                                }

                            }
                        }

                    }
                }

                dr["A8"] = dlbl审定金额不含税.ToString("F2");
                dr["A9"] = dlbl审定金额含税.ToString("F2");
                dr["A10"] = 总计开票不含税金额.ToString("F2");
                dr["A11"] = 总计开票金额.ToString("F2");
                dr["A12"] = 总计到账金额.ToString("F2");
                dr["A13"] = (dlbl审定金额不含税 - 总计开票不含税金额).ToString("F2");
                dr["A14"] = (总计开票金额 - 总计到账金额).ToString("F2");
              
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/合同综合信息列表下载模板.xlsx", downloadTable, str);

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
                ((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
               
                if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 200)
                {
                    ((Label)e.Row.FindControl("lblcol1")).Width = 200;
                }
                if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol2")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 150;
                }

                string strlblcol1 = ((Label)e.Row.FindControl("lblcol1")).Text;
                string strlblcol2 = ((Label)e.Row.FindControl("lblcol2")).Text;
                string strlblcol3 = ((Label)e.Row.FindControl("lblcol3")).Text;
                string strlblcol4 = ((Label)e.Row.FindControl("lblcol4")).Text;
                string strlblcol5 = ((Label)e.Row.FindControl("lblcol5")).Text;
                string sql = @"select * from (select t_xiangmu1.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 
                            from t_xiangmu1 inner join t_hetong on  t_xiangmu1.col1 =  t_hetong.col1 and t_xiangmu1.col2 = t_hetong.col2)    where 1=1  and
                            t_xiangmu1.col1 = '" + strlblcol1 + "' and t_xiangmu1.col2 = '" + strlblcol2 + "' and t_xiangmu1.col3 = '" + strlblcol3 + "' and t_xiangmu1.col4 = '" + strlblcol4 + "' and t_xiangmu1.col5 = '" + strlblcol5 + "' ";

                if (this.txtcol1.Text.Trim() != "")
                {
                    sql = sql + " and t_xiangmu1.col1 like '%" + this.txtcol1.Text.Trim() + "%' ";
                }
                if (this.txtcol2.Text.Trim() != "")
                {
                    sql = sql + " and t_xiangmu1.col2 like '%" + this.txtcol2.Text.Trim() + "%' ";
                }
                if (this.txtcol3.Text.Trim() != "")
                {
                    sql = sql + " and t_xiangmu1.col4 like '%" + this.txtcol3.Text.Trim() + "%' ";
                }
                if (this.txtcol4.Text.Trim() != "")
                {
                    sql = sql + " and t_xiangmu1.col5 like '%" + this.txtcol4.Text.Trim() + "%' ";
                }

                if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
                {
                    sql += " and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

                }
                OledbHelper oledbHelper = new OledbHelper();
                DataTable dtT = oledbHelper.GetDataTable(sql, new object[0]);

                decimal dlbl审定金额不含税 = 0;
                decimal dlbl审定金额含税 = 0;
                decimal 总计到账金额 = 0;
                decimal 总计开票金额 = 0;
                decimal 总计开票不含税金额 = 0;
                string 开票金额 = "0";
                string 开票不含税金额 = "0";
        
        
                for (int t = 0; t < dtT.Rows.Count; t++)
                {
                    dlbl审定金额不含税 += dtT.Rows[t]["col15"].ToString() == "" ? 0 : Convert.ToDecimal(dtT.Rows[t]["col15"].ToString());
                    dlbl审定金额含税 += dtT.Rows[t]["col18"].ToString() == "" ? 0 : Convert.ToDecimal(dtT.Rows[t]["col18"].ToString());

                    string strid = dtT.Rows[t]["ID"].ToString();

                    string fapiaono = string.Empty;
                   
                    DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + strid + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                        {

                            fapiaono = ds.Tables[0].Rows[ii]["col18"].ToString();
                            DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' and col55 like '%确定开票%' ");
                            if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                            {
                                开票金额 = ds.Tables[0].Rows[ii]["col31"].ToString();
                                if (开票金额 == "" || 开票金额 == "&nbsp;")
                                {
                                    开票金额 = "0";
                                }
                                总计开票金额 += Convert.ToDecimal(开票金额);

                                开票不含税金额 = ds.Tables[0].Rows[ii]["col28"].ToString();
                                if (开票不含税金额 == "" || 开票不含税金额 == "&nbsp;")
                                {
                                    开票不含税金额 = "0";
                                }
                                总计开票不含税金额 += Convert.ToDecimal(开票不含税金额);

                                DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col9 ='1' and col3= '" + ds.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                                {
                                    for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                    {
                                        string 到账金额 = ds1.Tables[0].Rows[kkk]["col6"].ToString();
                                        if (到账金额 == "" || 到账金额 == "&nbsp;")
                                        {
                                            到账金额 = "0";
                                        }
                                        总计到账金额 += Convert.ToDecimal(到账金额);
                                    }
                                }

                            }
                        }

                    }
                }
                ((Label)e.Row.FindControl("lbl开票金额不含税")).Text = dlbl审定金额不含税.ToString("F2");
                ((Label)e.Row.FindControl("lbl审定金额含税")).Text = dlbl审定金额含税.ToString("F2");

                ((Label)e.Row.FindControl("lbl开票金额不含税")).Text = 总计开票不含税金额.ToString("F2");
                ((Label)e.Row.FindControl("lbl开票金额含税")).Text = 总计开票金额.ToString("F2");
                ((Label)e.Row.FindControl("lbl到账金额含税")).Text = 总计到账金额.ToString("F2");

                ((Label)e.Row.FindControl("lbl未开票金额不含税")).Text = (dlbl审定金额不含税 - 总计开票不含税金额).ToString("F2");
                //((Label)e.Row.FindControl("lbl未开票金额含税")).Text = (dlbl审定金额含税 - 总计开票金额).ToString("F2");
                ((Label)e.Row.FindControl("lbl未到账金额含税")).Text = (总计开票金额 - 总计到账金额).ToString("F2");

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