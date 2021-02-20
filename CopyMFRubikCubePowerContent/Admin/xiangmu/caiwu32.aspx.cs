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
    public partial class caiwu32 : System.Web.UI.Page
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


        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "t_caiwu2";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            OledbHelper oledbHelper = new OledbHelper();

            where.Append(" where 1=1 and (col27 <> '' and col27 is not null) and (col28 <> '' and col28 is not null) and (col29 <> '' and col29 is not null) ");
            string sql = "select * from t_caiwu2 where 1= 1  and (col27 <> '' and col27 is not null) and (col28 <> '' and col28 is not null) and (col29 <> '' and col29 is not null) ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col14 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and col14 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col15 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and col15 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and col13 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and col13 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col5 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col54 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and col54 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }

            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and col4 like '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            {
                where.Append("  and (col62 = '" + this.Session["FullName"].ToString() + "' or col63 like '%" + this.Session["FullName"].ToString() + "%' or col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ")) ");
                sql += " and  (col62 = '" + this.Session["FullName"].ToString() + "' or col63 like '%" + this.Session["FullName"].ToString() + "%' or col1 = '" + this.Session["FullName"].ToString() + "' or col3 in (" + hdtemp.Text + ")) ";

            }
            
            //if (this.Session["RoleValue"].ToString() != "1")
            //{
            //    //审核人员
            //    Boolean shenheflag = false;
            //    string sql审核人员 = "select * from t_shenhe where 1=1 and col2 = '"+this.Session["FullName"].ToString() +"' ";
            //    DataTable dt审核人员 = oledbHelper.GetDataTable(sql审核人员);
            //    if (dt审核人员.Rows.Count > 0)
            //    {
            //        shenheflag = true;
            //        for (int k = 0; k < dt审核人员.Rows.Count; k++)
            //        {
            //            if (dt审核人员.Rows[k]["col1"].ToString() == "1")
            //            {
            //                where.Append(" and col55 like '%申请开票,未审批%' ");
            //                sql += " and col55 like '%申请开票,未审批%' ";
            //            }
            //            else if (dt审核人员.Rows[k]["col1"].ToString() == "2")
            //            {
            //                where.Append(" and (col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ");
            //                sql += " and (col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ";
            //            }
            //            else if (dt审核人员.Rows[k]["col1"].ToString() == "3")
            //            {
            //                where.Append(" and (col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ");
            //                sql += " and (col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ";
            //            }
            //            else if (dt审核人员.Rows[k]["col1"].ToString() == "4")
            //            {
            //                where.Append(" and (col55 like '%三级审批%' or col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ");
            //                sql += " and (col55 like '%三级审批%' or col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ";
            //            }
            //            else if (dt审核人员.Rows[k]["col1"].ToString() == "5")
            //            {
            //                where.Append(" and (col55 like '%四级审批%' or col55 like '%三级审批%' or col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ");
            //                sql += " and (col55 like '%四级审批%' or col55 like '%三级审批%' or col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ";
            //            }
            //            else if (dt审核人员.Rows[k]["col1"].ToString() == "6")
            //            {
            //                where.Append(" and (col55 like '%五级审批%' or col55 like '%四级审批%' or col55 like '%三级审批%' or col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ");
            //                sql += " and (col55 like '%五级审批%' or col55 like '%四级审批%' or col55 like '%三级审批%' or col55 like '%二级审批%' or col55 like '%一级审批%' or col55 like '%申请开票,未审批%') ";
            //            }
            //        }
            //    }
            //    if (shenheflag == false)
            //    {
            //        where.Append(" and col1 = '" + this.Session["FullName"].ToString() + "' ");
            //        sql += " and col1 = '" + this.Session["FullName"].ToString() + "' ";
            //    }

            //}

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

        //审核
        protected void btn审核_Click(object sender, EventArgs e)
        {
            caiwu2List caiwu2List = new caiwu2List();
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

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();

                    Response.Redirect("caiwu2.aspx?idno=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&id=" + tickedFormNo2 + "&role=" + "审核", false);
                    break;
                    //caiwu2List.col55 = "已审核";
                    //caiwu2List.UpdateDatashenhe(int.Parse(tickedFormNo));
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

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();

                    Response.Redirect("caiwu2.aspx?idno=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&id=" + tickedFormNo2, false);
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
            caiwu2List caiwu2List = new caiwu2List();
            caiwu22List caiwu22List = new caiwu22List();
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
                    caiwu2List.DeleteData(int.Parse(tickedFormNo));

                    //
                    var lblcol53 = ((Label)GridView1.Rows[k].FindControl("lblcol53")).Text;
                    caiwu22List.DeleteData(lblcol53);

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
            string str = "开票管理" + dt.ToString("yyyyMMddhhmmss");
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
                dr["A2"] = dtAll.Rows[i]["col53"].ToString();
                dr["A3"] = dtAll.Rows[i]["col8"].ToString();
                dr["A4"] = dtAll.Rows[i]["col9"].ToString();

                dr["A5"] = dtAll.Rows[i]["col10"].ToString();
                dr["A6"] = dtAll.Rows[i]["col11"].ToString();
                dr["A7"] = dtAll.Rows[i]["col12"].ToString();
                dr["A8"] = dtAll.Rows[i]["col13"].ToString();
                dr["A9"] = dtAll.Rows[i]["col14"].ToString();
                dr["A10"] = dtAll.Rows[i]["col15"].ToString();
                dr["A11"] = dtAll.Rows[i]["col5"].ToString();
                dr["A12"] = dtAll.Rows[i]["col7"].ToString();
                dr["A13"] = dtAll.Rows[i]["col6"].ToString();
                dr["A14"] = dtAll.Rows[i]["col3"].ToString();
                dr["A15"] = dtAll.Rows[i]["col4"].ToString();
                dr["A16"] = dtAll.Rows[i]["col54"].ToString();
                dr["A17"] = dtAll.Rows[i]["col26"].ToString();
                dr["A18"] = dtAll.Rows[i]["col28"].ToString();
                dr["A19"] = dtAll.Rows[i]["col29"].ToString();
                dr["A20"] = dtAll.Rows[i]["col1"].ToString();
                dr["A21"] = dtAll.Rows[i]["col2"].ToString();
                dr["A22"] = dtAll.Rows[i]["col55"].ToString();
                dr["A23"] = dtAll.Rows[i]["col49"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/开票管理下载模板.xlsx", downloadTable, str);
        }

        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", message);
            return;
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
                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                var tickedFormNo = ((Label)e.Row.FindControl("lblID")).Text;
                var tickedFormNo2 = ((Label)e.Row.FindControl("lblID2")).Text; // 若該列有被選取，取出被選的單號

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol53")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2.aspx?idno=" + tickedFormNo + "&id=" + tickedFormNo2 + "&model=view&model2=caiwu32";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = 135;

                string lblcol1 = ((Label)e.Row.FindControl("lblcol1")).Text;
                if (this.Session["UserName"].ToString() != lblcol1 && this.Session["RoleValue"].ToString() != "1")
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = false;
                }

                string str项目经理 = ((Label)e.Row.FindControl("lblcol3")).Text;
                if (this.Session["RoleValue"].ToString() != "1" && hdtemp.Text.Contains(str项目经理))
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = true;
                }

                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol12")).Width = ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol12")).Width : ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol13")).Width = ((Label)e.Row.FindControl("lblcol13")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol13")).Width : ((Label)e.Row.FindControl("lblcol13")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol14")).Width = ((Label)e.Row.FindControl("lblcol14")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol14")).Width : ((Label)e.Row.FindControl("lblcol14")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol49")).Width = ((Label)e.Row.FindControl("lblcol49")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol49")).Width : ((Label)e.Row.FindControl("lblcol49")).Text.Trim().Length * 12;

                //string[] str审批状态 = ((Label)e.Row.FindControl("lblcol55")).Text.Split(';');

                //for (int k = 0; k < str审批状态.Length; k++)
                //{
                //    if (k == str审批状态.Length - 1)
                //    {
                //        ((Label)e.Row.FindControl("lblcol55")).Text = str审批状态[k].Trim();
                //    }

                //}
                ((Label)e.Row.FindControl("lblcol55")).Width = ((Label)e.Row.FindControl("lblcol55")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol55")).Width : ((Label)e.Row.FindControl("lblcol55")).Text.Trim().Length * 12;

                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 220)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 220;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol12")).Width.Value < 220)
                {
                    ((Label)e.Row.FindControl("lblcol12")).Width = 220;
                }
                if (((Label)e.Row.FindControl("lblcol13")).Width.Value < 220)
                {
                    ((Label)e.Row.FindControl("lblcol13")).Width = 220;
                }
                if (((Label)e.Row.FindControl("lblcol14")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol14")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol15")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol15")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol3")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol3")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 100;
                }

                if (((Label)e.Row.FindControl("lblcol49")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol49")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol49")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol49")).Width = 100;
                }



            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("caiwu31.aspx", false);
        }

    }
}