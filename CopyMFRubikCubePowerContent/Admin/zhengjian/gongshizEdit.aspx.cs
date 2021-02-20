using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.Security;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using System.IO;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;


namespace CopyMFRubikCubePowerContent.Admin.zhengjian
{
    public partial class gongshizEdit :  MyPage, IRequiresSessionState
    {
        private static string puserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                puserID = base.Session["RoleValue"].ToString();
                this.hlBack.NavigateUrl = "gongshiz.aspx?active=" + base.Request.QueryString["active"];
                //txt存储位置.Attributes.Add("readOnly", "readOnly");
                if (base.Request.QueryString["id"] != null)
                {

                    string id = base.Request.QueryString["id"].ToString();
                    DataSet ds = Sql.SqlQueryDS("select * from companyzs where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txt证件类别.Text = ds.Tables[0].Rows[0]["style"].ToString();
                        txt证件名称.Text = ds.Tables[0].Rows[0]["zsname"].ToString();
                        txt证件编号.Text = ds.Tables[0].Rows[0]["zsno"].ToString();
                        txt发证机关.Text = ds.Tables[0].Rows[0]["jiguan"].ToString();
                        txt发证日期.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fazdate"].ToString()).ToString("yyyy-MM-dd");
                        txt到期时间.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["daqidate"].ToString()).ToString("yyyy-MM-dd");
                        txt有效期限.Text = ds.Tables[0].Rows[0]["youxiaodate"].ToString();
                        txt存储位置.Text = ds.Tables[0].Rows[0]["weizhi"].ToString();
                        txt备注.Text = ds.Tables[0].Rows[0]["remark"].ToString();
                        if (txt存储位置.Text != "")
                        {
                            公司证件href.HRef = txt存储位置.Text;
                            公司证件href.Visible = true;
                        }
                        
                       
                    }

                }

                if (puserID != "1")
                {
                    txt证件类别.ReadOnly = true;
                    txt证件名称.ReadOnly = true;
                    txt证件编号.ReadOnly = true;
                    txt发证机关.ReadOnly = true;
                    txt发证日期.Enabled = false;
                    txt到期时间.Enabled = false;
                    txt有效期限.ReadOnly = true;
                    txt存储位置.ReadOnly = true;
                    txt备注.ReadOnly = true;
                    txt存储位置.ReadOnly = true;
                    MyFileUpload.Visible = false;
                    FileUploadButton.Visible = false;
                    btnSave.Visible = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txt证件类别.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写证件类别");
                return;
            }
            if (this.txt证件名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写证件名称");
                return;
            }
            if (this.txt证件编号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写证件编号");
                return;
            }

            if (this.txt发证机关.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发证机关");
                return;
            }
            if (this.txt发证日期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发证日期");
                return;
            }
            if (this.txt到期时间.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写到期时间");
                return;
            }
            if (this.txt有效期限.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写有效期限");
                return;
            }

            companyzsList list = new companyzsList();
            if (this.ViewState["id"] != null)
            {
            }
            else
            {
                list.style = this.txt证件类别.Text.Trim();
                list.zsname = this.txt证件名称.Text.Trim();
                list.zsno = this.txt证件编号.Text.Trim();
                list.jiguan = this.txt发证机关.Text.Trim();
                list.fazdate = Convert.ToDateTime(this.txt发证日期.Text.Trim());
                list.daqidate = Convert.ToDateTime(this.txt到期时间.Text.Trim());
                list.youxiaodate = this.txt有效期限.Text.Trim();
                list.weizhi = this.txt存储位置.Text.Trim();
                list.remark = this.txt备注.Text.Trim();

                if (base.Request.QueryString["id"] != null)
                {

                    list.ID =int.Parse(base.Request.QueryString["id"]);
                    if (list.UpdateData() > 0)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                        //清空文本框

                        base.Response.Redirect("gongshiz.aspx?active=" + base.Request.QueryString["active"]);
                    }
                    else
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                    }
                }
                else
                {
                    if (list.InsertData() > 0)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                        //清空文本框
                        ClearTextBox();
                    }
                    else
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
        }
        private void ClearTextBox()
        {
            txt证件类别.Text = "";
            txt证件名称.Text = "";
            txt证件编号.Text = "";
            txt发证机关.Text = "";
            txt发证日期.Text = "";
            txt到期时间.Text = "";
            txt有效期限.Text = "";
            txt存储位置.Text = "";
            txt备注.Text = "";
            
        }


        protected void FileUploadButton_Click(object sender, EventArgs e)
        {
            if (MyFileUpload.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
               
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = MyFileUpload.PostedFile.FileName;
                MyFileUpload.SaveAs(filePath + fileName);

                公司证件href.HRef = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;
                txt存储位置.Text = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;
               

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");
                
            }
        }

        //
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "公司证件附件";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = txt存储位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);
                

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

        public void FlushtheFile(string fileFullName, Stream unzipFileStream)
        {
            HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.Charset = "UFT8";
            //var postFileName = HttpUtility.UrlEncode(fileFullName);
            var postFileName = HttpUtility.UrlPathEncode(fileFullName);
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = ReturnContentType(Path.GetExtension(postFileName));
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + postFileName);
            this.ReadWriteStream(unzipFileStream, HttpContext.Current.Response.OutputStream);

            if (HttpContext.Current.Response.IsClientConnected)
            {
              
                HttpContext.Current.Response.Flush();
                // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;
                // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                
            }

        }

        public string ReturnContentType(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            // readStream is the stream you need to read
            // writeStream is the stream you want to write to

            readStream.Seek(0, SeekOrigin.Begin);

            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }




    }
}