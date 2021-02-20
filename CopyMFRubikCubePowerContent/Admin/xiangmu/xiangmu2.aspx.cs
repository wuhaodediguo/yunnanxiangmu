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
    public partial class xiangmu2 : System.Web.UI.Page
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
            if (this.Session["UserName"].ToString() == "蔡光明" || this.Session["UserName"].ToString() == "admin" || this.Session["RoleValue"].ToString() == "1")
            {
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
            //adminPager.TableName = "(select t_caiwu22.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_caiwu22 inner join t_hetong on  t_caiwu22.col1 =  t_hetong.col1 )";
            //adminPager.strGetFields = "*";
            //ArrayList arrayList = new ArrayList();
            //StringBuilder where = new StringBuilder();
            //where.Append(" where 1=1 and col32='1' and (col38 <>'1' or col38 = '' or col38 is null) and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
            //string sql = "select * from (select t_caiwu22.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_caiwu22 inner join t_hetong on  t_caiwu22.col1 =  t_hetong.col1 ) where 1= 1  and col32='1' and (col38 <>'1' or col38 = '' or col38 is null) and (col49 <> '合作合同' or col49 = '' or col49 is null) ";

            adminPager.TableName = "(SELECT distinct viewxiangmu9.* FROM viewxiangmu9 ,t_caiwu22,t_caiwu2 where viewxiangmu9.col5 = t_caiwu22.col5 and viewxiangmu9.col8 = t_caiwu22.col8 and viewxiangmu9.col9 = t_caiwu22.col9 and viewxiangmu9.col31 = t_caiwu22.col47 and CStr(t_caiwu2.ID) =  t_caiwu22.col20  and t_caiwu2.col55 like '%确定开票%')";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1  ");
            string sql = @"SELECT distinct viewxiangmu9.* FROM viewxiangmu9 ,t_caiwu22,t_caiwu2 
                            where viewxiangmu9.col5 = t_caiwu22.col5
                            and viewxiangmu9.col8 = t_caiwu22.col8
                            and viewxiangmu9.col9 = t_caiwu22.col9
                            and viewxiangmu9.col31 = t_caiwu22.col47
                            and CStr(t_caiwu2.ID) =  t_caiwu22.col20    
                            and t_caiwu2.col55 like '%确定开票%' ";
            

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
                where.Append(" and t_xiangmu1.col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and t_xiangmu1.col1 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col8 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and t_xiangmu1.col8 = '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col7 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and t_xiangmu1.col7 = '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and t_xiangmu1.col9 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and t_xiangmu1.col9 = '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            //if (this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and col41 = '" + this.Session["FullName"].ToString() + "' ");
            //    sql += " and col41 = '" + this.Session["FullName"].ToString() + "' ";
            //}


            //if (hdtemp.Text != null && (this.Session["RoleValue"].ToString() != "1" || this.Session["RoleValue"].ToString() != "7"))
            //{
            //    where.Append(" and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            //}


            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (t_xiangmu1.col19 = '" + this.Session["FullName"].ToString() + "' or t_xiangmu1.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            //}

            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (col41 = '" + this.Session["FullName"].ToString() + "' or col6 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (col41 = '" + this.Session["FullName"].ToString() + "' or col6 in (" + hdtemp.Text + ") ) ";

            //}

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            //Decimal d1 = 0;
            //Decimal d2 = 0;
            //for (int i = 0; i < dtAll.Rows.Count; i++)
            //{
            //    d1 += dtAll.Rows[i]["col14"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col14"].ToString());
            //    d2 += dtAll.Rows[i]["col46"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col46"].ToString());
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

        private void GridBind2()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "t_caiwu22";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 and col32='1' ");
            string sql = "select * from t_caiwu22 where 1= 1  and col32='1' and col38='1' ";

            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and col4 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and col5 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and col1 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and col8 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and col8 like '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and col7 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and col7 like '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and col9 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and col9 like '%" + this.txtcol6.Text.Trim() + "%' ";
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

        protected void btn删除_Click(object sender, EventArgs e)
        {
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
                    caiwu22List.DeleteData2(int.Parse(tickedFormNo));

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


        protected void btn查询_Click(object sender, EventArgs e)
        {
            this.GridBind();
        }

        protected void btn查看_Click(object sender, EventArgs e)
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
                    string tiaozhuang = "xiangmu2";


                    Response.Redirect("xiangmu31Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&tiaozhuang=" + tiaozhuang + "", false);
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

        protected void btn已上传资料_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu5.aspx", false);
            //this.GridBind2();

        }

        protected void btn11_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu9.aspx?caset=1", false);

        }

        protected void btn12_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu9.aspx?caset=2", false);

        }

        protected void btn13_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu9.aspx?caset=3", false);

        }

        protected void btn14_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu9.aspx?caset=4", false);

        }

        protected void btn15_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu9.aspx?caset=5", false);

        }

       
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "项目资料管理" + dt.ToString("yyyyMMddhhmmss");
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
            downloadTable.Columns.Add("A24");
            downloadTable.Columns.Add("A25");
            downloadTable.Columns.Add("A26");
            downloadTable.Columns.Add("A27");
            downloadTable.Columns.Add("A28");
            downloadTable.Columns.Add("A29");
            downloadTable.Columns.Add("A30");
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A32");
            downloadTable.Columns.Add("A33");
            downloadTable.Columns.Add("A34");

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
                dr["A12"] = dtAll.Rows[i]["col47"].ToString();
                dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                dr["A19"] = dtAll.Rows[i]["col45"].ToString();
                dr["A20"] = dtAll.Rows[i]["col46"].ToString();
                dr["A21"] = dtAll.Rows[i]["col22"].ToString();
                dr["A22"] = dtAll.Rows[i]["col23"].ToString();
                dr["A23"] = dtAll.Rows[i]["col39"].ToString();
                dr["A24"] = dtAll.Rows[i]["col40"].ToString();
                dr["A25"] = dtAll.Rows[i]["col29"].ToString();
                dr["A26"] = dtAll.Rows[i]["col42"].ToString();
                dr["A27"] = dtAll.Rows[i]["col33"].ToString();
                dr["A28"] = dtAll.Rows[i]["col34"].ToString();
                dr["A29"] = dtAll.Rows[i]["col35"].ToString();
                dr["A30"] = dtAll.Rows[i]["col36"].ToString();
                dr["A31"] = dtAll.Rows[i]["col37"].ToString();
                dr["A32"] = dtAll.Rows[i]["col41"].ToString();
                dr["A33"] = dtAll.Rows[i]["col42"].ToString();
                dr["A34"] = dtAll.Rows[i]["col48"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目资料管理下载模板.xlsx", downloadTable, str);
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
                string temp8 = txtcol7.Text.Trim();
                string temp9 = Dropcol8.Text.Trim();

                ((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;

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

                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol7")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol15")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol15")).Width = 150;
                }

                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                string tiaozhuang = "xiangmu2";

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol8")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "xiangmu3Add.aspx?id=" + strid + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&tiaozhuang=" + tiaozhuang + "&temp9=" + temp9 + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                
                if (((Label)e.Row.FindControl("lbl发票扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label发票扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label发票扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl采购订单扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label采购订单扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label采购订单扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl完工结算证明扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = true;
                    ((Label)e.Row.FindControl("Label完工结算证明扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;
                    ((Label)e.Row.FindControl("Label完工结算证明扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl审计定案扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn4")).Visible = true;
                    ((Label)e.Row.FindControl("Label审计定案扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn4")).Visible = false;
                    ((Label)e.Row.FindControl("Label审计定案扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl竣工资料及图纸附件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn5")).Visible = true;
                    ((Label)e.Row.FindControl("Label竣工资料及图纸附件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn5")).Visible = false;
                    ((Label)e.Row.FindControl("Label竣工资料及图纸附件")).Visible = true;
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
                string tempfilename = "发票扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu91", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "采购订单扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu92", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn13")
            {
                string tempfilename = "完工结算证明扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu93", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn14")
            {
                string tempfilename = "审计定案扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu94", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn15")
            {
                string tempfilename = "竣工资料及图纸附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu95", rowIDs, tempfilename);
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

            DataSet ds02 = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + str2 + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
            for (int ii = 0; ii < ds02.Tables[0].Rows.Count; ii++)
            {
                var fapiaono = ds02.Tables[0].Rows[ii]["col18"].ToString();
                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + str1 + "' and col1='" + fapiaono + "' ");
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