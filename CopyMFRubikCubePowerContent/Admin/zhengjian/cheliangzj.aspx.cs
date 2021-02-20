using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System.Text;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using MojoCube.Api.File;
using System;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using System.Web.UI;
using System.IO;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MojoCube.Web.DispatchWaybill;
using Wuqi.Webdiyer;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace CopyMFRubikCubePowerContent.Admin.zhengjian
{
    
    public partial class cheliangzj : System.Web.UI.Page
    {
        private static string puserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                getDrop州市();
                getDrop所属项目部();
                puserID = base.Session["RoleValue"].ToString();
                this.hlAdd.NavigateUrl = "cheliangzjEdit.aspx?active=" + base.Request.QueryString["active"];
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                if (puserID != "1")
                {
                    hlAdd.Visible = false;
                }

            }
        }

        protected void getDrop州市()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,pinming  from tb_pinzhong where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop州市.DataTextField = "pinming";
            Drop州市.DataValueField = "pinming";
            Drop州市.DataSource = dataSource;
            Drop州市.DataBind();
            Drop州市.Items.Insert(0, "");

        }

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from tb_guige where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop所属项目部.DataTextField = "guige";
            Drop所属项目部.DataValueField = "guige";
            Drop所属项目部.DataSource = dataSource;
            Drop所属项目部.DataBind();
            Drop所属项目部.Items.Insert(0, "");

        }


        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            this.GridBind();
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
            adminPager.TableName = "cheliangzs";
            adminPager.strGetFields = "*";

            string sql = "select * from cheliangzs where 1= 1 ";


            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            ArrayList arrayList = new ArrayList();
            if (this.Drop州市.Text.Trim() != "")
            {
                where.Append(" and zhousi like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.Drop州市.Text.Trim()));
                sql += " and zhousi = '" + this.Drop州市.Text + "' ";
            }
            if (this.Drop所属项目部.Text.Trim() != "")
            {
                where.Append(" and xiangmu like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.Drop所属项目部.Text.Trim()));
                sql += " and xiangmu = '" + this.Drop所属项目部.Text + "' ";

            }
            if (this.txt车主姓名.Text.Trim() != "")
            {
                where.Append(" and chezhuname like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txt车主姓名.Text.Trim()));

                sql += " and chezhuname = '" + this.txt车主姓名.Text + "' ";

            }

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);


            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable();
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
                string strdate1 = ((Label)e.Row.FindControl("lbl检验有效期")).Text.Trim();
                if (strdate1 == "")
                {
                    ((Label)e.Row.FindControl("lbl是否到期")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl是否到期")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl是否到期")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl是否到期")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl是否到期")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl是否到期")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl是否到期")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl是否到期")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string strdate2 = ((Label)e.Row.FindControl("lbl租车协议到期时间")).Text.Trim();
                if (strdate2 == "")
                {
                    ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl租车协议到期时间是否到期")).BackColor = System.Drawing.Color.Red;
                    }
                }

                if (((Label)e.Row.FindControl("lbl行车证储存位置")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk行车证储存位置")).Visible = false;
                    ((LinkButton)e.Row.FindControl("lbtn行车证储存位置")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl车辆照片储存位置")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk车辆照片储存位置")).Visible = false;
                    ((LinkButton)e.Row.FindControl("lbtn车辆照片储存位置")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl租车协议储存位置")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk租车协议储存位置")).Visible = false;
                    ((LinkButton)e.Row.FindControl("lbtn租车协议储存位置")).Visible = false;
                }

                if (puserID != "1")
                {
                    ((HyperLink)e.Row.FindControl("gvEdit")).Text = "浏览";
                    ((HyperLink)e.Row.FindControl("gvEdit")).ToolTip = "浏览";
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = true;
                    MojoCube.Web.String.ShowDel(e);
                }

                string str = ((Label)e.Row.FindControl("lblID")).Text.Trim();
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "cheliangzjEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];

                ((Label)e.Row.FindControl("lbl检验有效期")).Text = Convert.ToDateTime(((Label)e.Row.FindControl("lbl检验有效期")).Text).ToString("yyyy-MM-dd");
                ((Label)e.Row.FindControl("lbl租车协议到期时间")).Text = Convert.ToDateTime(((Label)e.Row.FindControl("lbl租车协议到期时间")).Text).ToString("yyyy-MM-dd");

                //((Label)e.Row.FindControl("lbl购置年份")).Text = Convert.ToDateTime(((Label)e.Row.FindControl("lbl购置年份")).Text).ToString("yyyy-MM-dd");

            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
            string[] controlList = new string[]
		{
			"gvDelete"
		};
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            cheliangzsList list = new cheliangzsList();
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string str = ((Label)row.FindControl("lblID")).Text;
            switch (e.CommandName)
            {
                case "_delete":
                    int index = Convert.ToInt32(e.CommandArgument);
                    list.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
                    this.GridBind();
                    break;
                case "lbtn行车证储存位置":
                    Response.Redirect("cheliangzjEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str, false);
                    break;
                case "lbtn车辆照片储存位置":
                    Response.Redirect("cheliangzjEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str, false);
                    break;
                case "lbtn租车协议储存位置":
                    Response.Redirect("cheliangzjEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str, false);
                    break;
                
            }

        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {

                if (checkFile(fuPortrait.PostedFile))
                {
                    ExcelHelper exh = new ExcelHelper();
                    DataTable dt = exh.ExcelToDataTable3(this.fuPortrait.PostedFile.InputStream, "", true, fuPortrait.PostedFile.FileName);
                    //验证数据

                    if (dt == null)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "文件没有数据");
                        return;
                    }
                    List<cheliangzsList> cheliangzsList = checkUploadData(dt);

                    StringBuilder errorMsg = new StringBuilder();
                    foreach (cheliangzsList item in cheliangzsList)
                    {
                        if (!string.IsNullOrEmpty(item.CheckUploadResult))
                            errorMsg.Append(item.CheckUploadResult);
                    }


                    if (string.IsNullOrEmpty(errorMsg.ToString()))
                    {
                        StringBuilder errorBillNo = new StringBuilder();
                        foreach (cheliangzsList item in cheliangzsList)
                        {
                            DataSet ds = Sql.SqlQueryDS("select * from cheliangzs where cheno='" + item.cheno + "'");
                            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            {
                                item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                if (item.UpdateData() <= 0)
                                {
                                    errorBillNo.Append(item.ID + ",");
                                }
                            }
                            else
                            {
                                if (item.InsertData() <= 0)
                                {
                                    errorBillNo.Append(item.ID + ",");
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下证件号：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                        else
                        {
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
                            this.GridBind();
                        }
                    }
                    else
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择上传文件和正确文件格式");
                }
            }
            catch (Exception ex)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", ex.ToString());
            }
        }
        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }
        protected List<cheliangzsList> checkUploadData(DataTable dt)
        {
            List<cheliangzsList> cheliangzsList = new List<cheliangzsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cheliangzsList list = new cheliangzsList();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[1].ColumnName);
                else
                    list.zhousi = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[2].ColumnName);
                else
                    list.xiangmu = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[3].ColumnName);
                else
                    list.chezhuname = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[4].ColumnName);
                else
                    list.cheno = dt.Rows[i][4].ToString();

                if (string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[5].ColumnName);
                else
                    list.col1 = dt.Rows[i][5].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[6].ColumnName);
                else
                    list.col2 = dt.Rows[i][6].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][7].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[7].ColumnName);
                else
                    list.col3 = dt.Rows[i][7].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][8].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[8].ColumnName);
                else
                    list.col4 = dt.Rows[i][8].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][9].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[9].ColumnName);
                else
                    list.col5 = dt.Rows[i][9].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][10].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[10].ColumnName);
                else
                    list.jianchayouxiaodate = chuli(dt.Rows[i][10].ToString()).Trim();

                list.jianchadaqi = dt.Rows[i][11].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][12].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[12].ColumnName);
                else
                    list.zuchedate = chuli(dt.Rows[i][12].ToString()).Trim(); 

               
                list.zuchedaiqi = dt.Rows[i][13].ToString();
                list.xingchezhengweizhi = dt.Rows[i][14].ToString();
                list.cheliangzpweizhi = dt.Rows[i][15].ToString();
                list.zucheweizhi = dt.Rows[i][16].ToString();
                list.remark = dt.Rows[i][17].ToString();


                cheliangzsList.Add(list);
            }
            return cheliangzsList;
        }
        protected void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string filename = "/Admin/UploadTemplates/车辆证件资料导入.xls";
            DownloadTemplateFile downloadTemplateFile = new DownloadTemplateFile();
            downloadTemplateFile.DoFileDownload(filename);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "车辆证件" + dt.ToString("yyyyMMddhhmmss");
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

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["zhousi"].ToString();
                dr["A3"] = dtAll.Rows[i]["xiangmu"].ToString(); 
                dr["A4"] = dtAll.Rows[i]["chezhuname"].ToString();
                dr["A5"] = dtAll.Rows[i]["cheno"].ToString(); 

                dr["A6"] = dtAll.Rows[i]["col1"].ToString(); 
                dr["A7"] = dtAll.Rows[i]["col2"].ToString();
                dr["A8"] = dtAll.Rows[i]["col3"].ToString();

                dr["A9"] = dtAll.Rows[i]["col4"].ToString();
                dr["A10"] = dtAll.Rows[i]["col5"].ToString();

                dr["A11"] = dtAll.Rows[i]["jianchayouxiaodate"].ToString();
                dr["A12"] = dtAll.Rows[i]["jianchadaqi"].ToString();
                dr["A13"] = dtAll.Rows[i]["zuchedate"].ToString();

                dr["A14"] = dtAll.Rows[i]["zuchedaiqi"].ToString();
                dr["A15"] = dtAll.Rows[i]["xingchezhengweizhi"].ToString();
                dr["A16"] = dtAll.Rows[i]["cheliangzpweizhi"].ToString(); 
                dr["A17"] = dtAll.Rows[i]["zucheweizhi"].ToString(); 
                dr["A18"] = dtAll.Rows[i]["remark"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/车辆证件下载模板.xlsx", downloadTable, str);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";
            Dictionary<string, Stream> streams = new Dictionary<string, Stream>();
            Stream streamWriter = null;
            int counts = 1000;


            foreach (GridViewRow r in GridView1.Rows)
            {
                string name = ((Label)r.FindControl("lbl车主姓名")).Text.Trim();
                //savePath = "E:/导出证件信息/" + name;

                if (((CheckBox)r.FindControl("uxDeleteCheckBox")).Checked)
                {
                    savePath = ((Label)r.FindControl("lbl行车证储存位置")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl行车证储存位置")).Text.Trim();
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
               

                    

                    savePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();

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

                    

                    savePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();

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

                    //sourcePath = ((Label)r.FindControl("lbl行车证储存位置")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);

                    //sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);

                    //sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);

                }
                else
                {
                    if (((CheckBox)r.FindControl("Chk行车证储存位置")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl行车证储存位置")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl行车证储存位置")).Text.Trim();

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

                       
                        //sourcePath = ((Label)r.FindControl("lbl行车证储存位置")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk车辆照片储存位置")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();

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
                        //sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk租车协议储存位置")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();

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
                        //sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
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
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode("打包文档.zip", System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                CheckBox item = ((CheckBox)r.FindControl("uxDeleteCheckBox"));
                if (!item.Checked)
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// 拷贝oldlab的文件到newlab下面
        /// </summary>
        /// <param name="sourcePath">lab文件所在目录(@"~\labs\oldlab")</param>
        /// <param name="savePath">保存的目标目录(@"~\labs\newlab")</param>
        /// <returns>返回:true-拷贝成功;false:拷贝失败</returns>
        public bool CopyOldLabFilesToNewLab(string sourcePath, string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            #region //拷贝labs文件夹到savePath下
            try
            {
                string[] labDirs = Directory.GetDirectories(sourcePath);//目录
                string[] labFiles = Directory.GetFiles(sourcePath);//文件
                if (labFiles.Length > 0)
                {
                    for (int i = 0; i < labFiles.Length; i++)
                    {
                        if (Path.GetExtension(labFiles[i]) != ".lab")//排除.lab文件
                        {
                            File.Copy(sourcePath + "\\" + Path.GetFileName(labFiles[i]), savePath + "\\" + Path.GetFileName(labFiles[i]), true);
                        }
                    }
                }
                if (labDirs.Length > 0)
                {
                    for (int j = 0; j < labDirs.Length; j++)
                    {
                        Directory.GetDirectories(sourcePath + "\\" + Path.GetFileName(labDirs[j]));

                        //递归调用
                        CopyOldLabFilesToNewLab(sourcePath + "\\" + Path.GetFileName(labDirs[j]), savePath + "\\" + Path.GetFileName(labDirs[j]));
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            #endregion
            return true;
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

        string chuli(string str)
        {
            var m = str.Length;
            var n = str.IndexOf(" ");
            if (n == -1)
            {
                return str;
            }
            var j = str.Substring(n, m - n);
            var s = str.Replace(j, "");
            return s;
        }


    }
}