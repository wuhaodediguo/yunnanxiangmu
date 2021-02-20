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
using System.Web.UI;
using System.IO;
using System.IO.Compression;
using System.Data;
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
    public partial class gongshiz : System.Web.UI.Page
    {
        private static string puserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                //string pk_menu = base.Request.QueryString["active"].Split(',')[1];
                //MojoCube.Web.Role.List roleList = new MojoCube.Web.Role.List();
                //roleList.GetData(Convert.ToInt32(base.Session["RoleValue"].ToString()), Convert.ToInt32(pk_menu));
                //if (!roleList.IsAdmin)
                //{
                //    this.GridView1.Columns[6].Visible = false;
                //}
                puserID = base.Session["RoleValue"].ToString();
                this.hlAdd.NavigateUrl = "gongshizEdit.aspx?active=" + base.Request.QueryString["active"];
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                if (puserID != "1")
                {
                    hlAdd.Visible = false;
                }
                
            }
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
            adminPager.TableName = "companyzs";
            adminPager.strGetFields = "*";

            string sql = "select * from companyzs where 1= 1 ";

            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            ArrayList arrayList = new ArrayList();
            if (this.txt证件类别.Text.Trim() != "")
            {
                where.Append(" and style like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txt证件类别.Text.Trim()));
                sql += " and style = '" + this.txt证件类别.Text + "' ";

            }
            if (this.txt证件名称.Text.Trim() != "")
            {
                where.Append(" and zsname like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txt证件名称.Text.Trim()));
                sql += " and zsname = '" + this.txt证件名称.Text + "' ";
            }
            if (this.txt证件编号.Text.Trim() != "")
            {
                where.Append(" and zsno like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txt证件编号.Text.Trim()));
                sql += " and zsno = '" + this.txt证件编号.Text + "' ";
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
                ((Label)e.Row.FindControl("lbl发证日期")).Text = ((Label)e.Row.FindControl("lbl发证日期")).Text == "" ? "" : Convert.ToDateTime(((Label)e.Row.FindControl("lbl发证日期")).Text).ToString("yyyy-MM-dd");
                ((Label)e.Row.FindControl("lbl到期时间")).Text = ((Label)e.Row.FindControl("lbl到期时间")).Text == "" ? "" : Convert.ToDateTime(((Label)e.Row.FindControl("lbl到期时间")).Text).ToString("yyyy-MM-dd");
                if (((Label)e.Row.FindControl("lbl存储位置")).Text.Trim() == "")
                {
                    ((CheckBox)e.Row.FindControl("Chk公司证件信息")).Visible = false;
                    ((LinkButton)e.Row.FindControl("lbtn公司证件信息")).Visible = false;
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
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "gongshizEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"];

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
            companyzsList list = new companyzsList();
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string str = ((Label)row.FindControl("lblID")).Text;
            switch (e.CommandName)
            {
                case "_delete":
                    int index = Convert.ToInt32(e.CommandArgument);
                    list.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
                    this.GridBind();
                    break;
                case "lbtn公司证件信息":
                    Response.Redirect("gongshizEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str, false);
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
                    DataTable dt = exh.ExcelToDataTable(this.fuPortrait.PostedFile.InputStream, "", true, fuPortrait.PostedFile.FileName);
                    //验证数据

                    if (dt == null)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "文件没有数据");
                        return;
                    }
                    List<companyzsList> companyzsList = checkUploadData(dt);

                    StringBuilder errorMsg = new StringBuilder();
                    foreach (companyzsList item in companyzsList)
                    {
                        if (!string.IsNullOrEmpty(item.CheckUploadResult))
                            errorMsg.Append(item.CheckUploadResult);
                    }


                    if (string.IsNullOrEmpty(errorMsg.ToString()))
                    {
                        StringBuilder errorBillNo = new StringBuilder();
                        foreach (companyzsList item in companyzsList)
                        {
                            DataSet ds = Sql.SqlQueryDS("select * from companyzs where zsno='" + item.zsno + "' and zsname='" + item.zsname + "' ");
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
        protected List<companyzsList> checkUploadData(DataTable dt)
        {
            List<companyzsList> companyzsList = new List<companyzsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                companyzsList list = new companyzsList();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.style = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.zsname = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.zsno = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.jiguan = dt.Rows[i][4].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.fazdate = Convert.ToDateTime(dt.Rows[i][5].ToString());
                if (string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.daqidate = Convert.ToDateTime(dt.Rows[i][6].ToString());
                list.youxiaodate = dt.Rows[i][7].ToString();
                list.weizhi = dt.Rows[i][8].ToString();
                list.remark = dt.Rows[i][9].ToString();



                companyzsList.Add(list);
            }
            return companyzsList;
        }

        protected void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string filename = "/Admin/UploadTemplates/公司证件资料导入.xls";
            DownloadTemplateFile downloadTemplateFile = new DownloadTemplateFile();
            downloadTemplateFile.DoFileDownload(filename);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "公司证件" + dt.ToString("yyyyMMddhhmmss");
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

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["style"].ToString();
                dr["A3"] = dtAll.Rows[i]["zsname"].ToString(); 
                dr["A4"] = dtAll.Rows[i]["zsno"].ToString();

                dr["A5"] = dtAll.Rows[i]["jiguan"].ToString();
                dr["A6"] = dtAll.Rows[i]["fazdate"].ToString() == "" ? "" : dtAll.Rows[i]["fazdate"].ToString().Substring(0, 10).Replace("星", "").Replace("/", "-").Trim();
                dr["A7"] = dtAll.Rows[i]["daqidate"].ToString() == "" ? "" : dtAll.Rows[i]["daqidate"].ToString().Substring(0, 10).Replace("星", "").Replace("/", "-").Trim();
                dr["A8"] = dtAll.Rows[i]["youxiaodate"].ToString(); 
                dr["A9"] = dtAll.Rows[i]["weizhi"].ToString(); 
                dr["A10"] = dtAll.Rows[i]["remark"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/公司证件下载模板.xlsx", downloadTable, str);
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
                string name = ((Label)r.FindControl("lbl证件编号")).Text.Trim();
                //savePath = "E:/导出证件信息/" + name;

                if (((CheckBox)r.FindControl("uxDeleteCheckBox")).Checked)
                {
                    savePath = ((Label)r.FindControl("lbl存储位置")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl存储位置")).Text.Trim();
                    if (sourcePath == "")
                    {
                        continue;
                    }
               
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

              
                    //Button4_Click(sourcePath, savePath);
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);

                }
                else
                {
                    if (((CheckBox)r.FindControl("Chk公司证件信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl存储位置")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl存储位置")).Text.Trim();

                        if (sourcePath == "")
                        {
                            continue;
                        }
               
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

                 
                        //Button4_Click(sourcePath, savePath);
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
            //
            //savePath = "E:/代码元/公司证件管理/公司证件管理系统/CopyMFRubikCubePowerContent" + @"/wulala.gz";
           

            //if (!Directory.Exists(savePath))
            //{
            //    Directory.CreateDirectory(savePath);
            //}
            //CompressMulti(fileNames, "E:/ZIP文件");
            //Button4_Click(sourcePath, "E:/ZIP文件");
            //ZipFiles(fileNames, savePath, "公司证书", 9, "", "");

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


        //WriteFile分块下载
        //protected void Button3_Click(object sender, EventArgs e)
        //{

        //    string fileName = "123.pdf";//客户端保存的文件名
        //    string filePath = Server.MapPath("公司证件UploadFile/123.pdf");//路径

        //    System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

        //    if (fileInfo.Exists == true)
        //    {
        //        const long ChunkSize = 102400;//100K 每次读取文件，只读取100Ｋ，这样可以缓解服务器的压力
        //        byte[] buffer = new byte[ChunkSize];

        //        Response.Clear();
        //        System.IO.FileStream iStream = System.IO.File.OpenRead(filePath);
        //        long dataLengthToRead = iStream.Length;//获取下载的文件总大小
        //        Response.ContentType = "application/octet-stream";
        //        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
        //        while (dataLengthToRead > 0 && Response.IsClientConnected)
        //        {
        //            int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
        //            Response.OutputStream.Write(buffer, 0, lengthRead);
        //            Response.Flush();
        //            dataLengthToRead = dataLengthToRead - lengthRead;
        //        }
        //        Response.Close();
        //    }
        //}

        //流方式下载
        protected void Button4_Click(string fileName, string filePath)
        {
            //string fileName = "123.pdf";//客户端保存的文件名
            //string filePath = Server.MapPath("公司证件UploadFile/123.pdf");//路径
            filePath = Server.MapPath(filePath);//路径
            //以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        } 


        /// <summary>
        /// 制作压缩包（多个文件压缩到一个压缩包，支持加密、注释）
        /// </summary>
        /// <param name="fileNames">要压缩的文件</param>
        /// <param name="topDirectoryName">压缩文件目录</param>
        /// <param name="zipedFileName">压缩包文件名</param>
        /// <param name="compresssionLevel">压缩级别 1-9</param>
        /// <param name="password">密码</param>
        /// <param name="comment">注释</param>
        public static void ZipFiles(string[] fileNames, string topDirectoryName, string zipedFileName, int? compresssionLevel, string password="", string comment="")
        {
            
           

            using (ZipOutputStream zos = new ZipOutputStream(File.Open(zipedFileName, FileMode.OpenOrCreate)))
            {
                if (compresssionLevel.HasValue)
                {
                    zos.SetLevel(compresssionLevel.Value);//设置压缩级别
                }

                if (!string.IsNullOrEmpty(password))
                {
                    zos.Password = password;//设置zip包加密密码
                }

                if (!string.IsNullOrEmpty(comment))
                {
                    zos.SetComment(comment);//设置zip包的注释
                }

                foreach (string file in fileNames)
                {
                    string fileName = string.Format("{0}/{1}", topDirectoryName, file);
                    if (File.Exists(fileName))
                    {
                        FileInfo item = new FileInfo(fileName);
                        FileStream fs = File.OpenRead(item.FullName);
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);

                        ZipEntry entry = new ZipEntry(item.Name);
                        zos.PutNextEntry(entry);
                        zos.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }


        
        /// <summary>
        /// 自定义多文件压缩（生成的压缩包和第三方的压缩文件解压不兼容）
        /// </summary>
        /// <param name="sourceFileList">文件列表</param>
        /// <param name="saveFullPath">压缩包全路径</param>
        public void CompressMulti(string[] sourceFileList, string saveFullPath)
        {
            MemoryStream ms = new MemoryStream();
            foreach (string filePath in sourceFileList)
            {
                Console.WriteLine(filePath);
                if (File.Exists(filePath))
                {
                    string fileName = Path.GetFileName(filePath);
                    byte[] fileNameBytes = System.Text.Encoding.UTF8.GetBytes(fileName);
                    byte[] sizeBytes = BitConverter.GetBytes(fileNameBytes.Length);
                    ms.Write(sizeBytes, 0, sizeBytes.Length);
                    ms.Write(fileNameBytes, 0, fileNameBytes.Length);
                    byte[] fileContentBytes = System.IO.File.ReadAllBytes(filePath);
                    ms.Write(BitConverter.GetBytes(fileContentBytes.Length), 0, 4);
                    ms.Write(fileContentBytes, 0, fileContentBytes.Length);
                }
            }
            ms.Flush();
            ms.Position = 0;

            //StreamReader streamReader = new StreamReader(saveFullPath);
            //while (streamReader.ReadLine() != null)
            //{
            //    using (GZipStream zipStream = new GZipStream(streamReader, CompressionMode.Compress))
            //    {
            //        ms.Position = 0;
            //        ms.CopyTo(zipStream);
            //    }
            //}

            using (FileStream zipFileStream = File.Create(saveFullPath))
            {
                using (GZipStream zipStream = new GZipStream(zipFileStream, CompressionMode.Compress))
                {
                    ms.Position = 0;
                    ms.CopyTo(zipStream);
                }
            }
            ms.Close();
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



    }
}