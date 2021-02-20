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
    public partial class xiangmu8_3 : System.Web.UI.Page
    {

        public string temp1
        {
            get { return Request.Params.Get("temp1"); }
        }
        public string temp2
        {
            get { return Request.Params.Get("temp2"); }
        }
        public string temp3
        {
            get { return Request.Params.Get("temp3"); }
        }
        public string temp4
        {
            get { return Request.Params.Get("temp4"); }
        }
        public string temp5
        {
            get { return Request.Params.Get("temp5"); }
        }
        public string temp6
        {
            get { return Request.Params.Get("temp6"); }
        }
        public string temp7
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
                if (base.Request.QueryString["model"] == "上报")
                {
                    div新建.Visible = true;
                    div删除.Visible = true;
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string lblcol1 = base.Request.QueryString["lblcol1"];
            string lblcol2 = base.Request.QueryString["lblcol2"];
            string lblcol3 = base.Request.QueryString["lblcol3"];
            string lblcol4 = base.Request.QueryString["lblcol4"];
            Response.Redirect("xiangmu8Add.aspx?id=" + "" + "&lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&lblcol3=" + lblcol3 + "&lblcol4=" + lblcol4 + "", false);
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiangmu8_31.aspx?id=" + "" + "", false);
        }


        protected void btn删除_Click(object sender, EventArgs e)
        {
            xiangmu3List xiangmu3List = new xiangmu3List();
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

                    var ticked创建人 = ((Label)GridView1.Rows[k].FindControl("lblcol13")).Text;
                    if (ticked创建人 != this.Session["FullName"].ToString() && this.Session["RoleValue"].ToString() != "1")
                    {
                        SetWarningMessage("不能删除其他人创建的月报管理！");
                        return;
                    }

                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    xiangmu3List.DeleteData(int.Parse(tickedFormNo));
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
            string str = "项目月报明细管理" + dt.ToString("yyyyMMddhhmmss");
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
                dr["A13"] = dtAll.Rows[i]["col12"].ToString();
                dr["A14"] = dtAll.Rows[i]["col13"].ToString();
                dr["A15"] = dtAll.Rows[i]["col14"].ToString();
                dr["A16"] = dtAll.Rows[i]["col15"].ToString();
                dr["A17"] = dtAll.Rows[i]["col16"].ToString();
                dr["A18"] = dtAll.Rows[i]["col17"].ToString();
                dr["A19"] = dtAll.Rows[i]["col18"].ToString();
                dr["A20"] = dtAll.Rows[i]["col19"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目月报明细管理下载模板.xlsx", downloadTable, str);
        }


        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            string lblcol1 = base.Request.QueryString["lblcol1"];
            string lblcol2 = base.Request.QueryString["lblcol2"];
            string lblcol3 = base.Request.QueryString["lblcol3"];
            string lblcol4 = base.Request.QueryString["lblcol4"];

            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "t_xiangmu3";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 and col1='" + lblcol1 + "' and col2='" + lblcol2 + "' and col3='" + lblcol3 + "' and col4='" + lblcol4 + "' ");
            string sql = "select * from t_xiangmu3 where 1= 1 and col1='" + lblcol1 + "' and col2='" + lblcol2 + "' and col3='" + lblcol3 + "' and col4='" + lblcol4 + "' ";
           
            OledbHelper oledbHelper = new OledbHelper();
            TextBox年度.Attributes.Add("readOnly", "readOnly");
            TextBox月份.Attributes.Add("readOnly", "readOnly");
            TextBox项目部.Attributes.Add("readOnly", "readOnly");
            TextBox项目经理.Attributes.Add("readOnly", "readOnly");

            TextBox年度.Text = lblcol1;
            TextBox月份.Text = lblcol2;
            TextBox项目部.Text = lblcol3;
            TextBox项目经理.Text = lblcol4;
            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];
            //if (dtAll.Rows.Count > 0)
            //{
            //    TextBox年度.Text = dtAll.Rows[0]["col1"].ToString();
            //    TextBox月份.Text = dtAll.Rows[0]["col2"].ToString();
            //    TextBox项目部.Text = dtAll.Rows[0]["col3"].ToString();
            //    TextBox项目经理.Text = dtAll.Rows[0]["col4"].ToString();
                
            //}

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable(memoryPage);
            this.GridView1.DataBind();
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
                string lblcol17 = ((Label)e.Row.FindControl("lblcol17")).Text;
                if (this.Session["UserName"].ToString() != lblcol17 && this.Session["RoleValue"].ToString() != "1")
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = false;
                }

                string str项目经理 = ((Label)e.Row.FindControl("lblcol4")).Text;
                if (this.Session["RoleValue"].ToString() != "1" && hdtemp.Text.Contains(str项目经理))
                {
                    ((CheckBox)e.Row.FindControl("Chk")).Visible = true;
                }

       
                //((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol3")).Width = ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol3")).Width : ((Label)e.Row.FindControl("lblcol3")).Text.Trim().Length * 12;

                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol12")).Width = ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol12")).Width : ((Label)e.Row.FindControl("lblcol12")).Text.Trim().Length * 12;

                //if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 200)
                //{
                //    ((Label)e.Row.FindControl("lblcol1")).Width = 200;
                //}
                //if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 100)
                //{
                //    ((Label)e.Row.FindControl("lblcol2")).Width = 100;
                //}
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
                if (((Label)e.Row.FindControl("lblcol12")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol12")).Width = 150;
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