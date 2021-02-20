using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace MojoCube.Api.File
{
    public class Function
    {
        public static string GetContentType(string Path)
        {
            string text = string.Empty;
            if (Path.LastIndexOf('.') > 0)
            {
                text = Path.Substring(Path.LastIndexOf('.'));
            }
            string result = string.Empty;
            string text2 = text.ToLower();
            switch (text2)
            {
                case ".jpg":
                    result = "image/jpeg";
                    return result;
                case ".gif":
                    result = "image/gif";
                    return result;
                case ".png":
                    result = "image/png";
                    return result;
                case ".bmp":
                    result = "image/bmp";
                    return result;
                case ".wmv":
                    result = "application/octet-stream";
                    return result;
                case ".asf":
                    result = "application/octet-stream";
                    return result;
                case ".3gp":
                    result = "application/octet-stream";
                    return result;
                case ".mpg":
                    result = "application/octet-stream";
                    return result;
                case ".rar":
                    result = "application/x-msdownload";
                    return result;
                case ".pdf":
                    result = "application/pdf";
                    return result;
                case ".zip":
                    result = "application/zip";
                    return result;
            }
            result = "*/*";
            return result;
        }

        public static string GetRelativePath(string path)
        {
            path = HttpContext.Current.Request.ApplicationPath + "/" + path;
            path = path.Replace("///", "/").Replace("//", "/");
            return path;
        }

        public static string GetAbsolutePath(string path)
        {
            path = HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + "/" + HttpContext.Current.Request.ApplicationPath + path;
            path = path.Replace("///", "/").Replace("//", "/");
            path = "http://" + path;
            return path;
        }
    }

    public class IO
    {
        public static DataSet GetDirectoryDS(string[] files)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("FileName");
            dataTable.Columns.Add("FileFullPath");
            dataTable.Columns.Add("FileLength");
            dataTable.Columns.Add("Modified");
            dataTable.Columns.Add("FileSize");
            for (int i = 0; i < files.Length; i++)
            {
                string path = files[i];
                DataRow dataRow = dataTable.NewRow();
                dataRow["FileName"] = Path.GetFileName(path);
                dataRow["FileFullPath"] = Path.GetFullPath(path);
                dataRow["FileLength"] = Path.GetFullPath(path).Length.ToString();
                try
                {
                    FileInfo fileInfo = new FileInfo(Path.GetFullPath(path));
                    dataRow["Modified"] = fileInfo.LastWriteTime.ToString();
                    dataRow["FileSize"] = IO.FormatFileSize(fileInfo.Length.ToString());
                }
                catch
                {
                    dataRow["Modified"] = string.Empty;
                    dataRow["FileSize"] = string.Empty;
                }
                dataTable.Rows.Add(dataRow);
            }
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        public static string FormatFileSize(string a)
        {
            if (a != "")
            {
                double num = System.Convert.ToDouble(a) / 1024.0;
                if (num > 1000.0)
                {
                    a = IO.F2Size(num / 1024.0) + " MB";
                }
                else
                {
                    a = ((int)num).ToString() + " KB";
                }
            }
            return a;
        }

        public static string F2Size(double d)
        {
            d *= 100.0;
            d = (double)((int)d);
            d /= 100.0;
            return d.ToString();
        }

        public static string GetModifiedTime(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.LastWriteTime.ToString();
        }

        public static string SetModifiedTime(string path)
        {
            return new FileInfo(path)
            {
                LastWriteTime = DateTime.Now
            }.LastWriteTime.ToString();
        }

        public static bool DeleteFile(string path)
        {
            bool result;
            try
            {
                System.IO.File.Delete(path);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool DeleteDirectory(string path)
        {
            bool result;
            try
            {
                string[] array = Directory.GetFiles(path);
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string path2 = array2[i];
                    System.IO.File.Delete(path2);
                }
                array = Directory.GetDirectories(path);
                array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string path2 = array2[i];
                    IO.DeleteDirectory(path2);
                }
                Directory.Delete(path);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }

    public class Upload
    {
        private string _OldFilePath;

        private string _FilePath;

        private string _OldFileName;

        private string _FileName;

        private string _FileType;

        private int _FileSize;

        private string _Message;

        private bool _IsUpload;

        public string OldFilePath
        {
            get
            {
                return this._OldFilePath;
            }
            set
            {
                this._OldFilePath = value;
            }
        }

        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this._FilePath = value;
            }
        }

        public string OldFileName
        {
            get
            {
                return this._OldFileName;
            }
            set
            {
                this._OldFileName = value;
            }
        }

        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                this._FileName = value;
            }
        }

        public string FileType
        {
            get
            {
                return this._FileType;
            }
            set
            {
                this._FileType = value;
            }
        }

        public int FileSize
        {
            get
            {
                return this._FileSize;
            }
            set
            {
                this._FileSize = value;
            }
        }

        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this._Message = value;
            }
        }

        public bool IsUpload
        {
            get
            {
                return this._IsUpload;
            }
            set
            {
                this._IsUpload = value;
            }
        }

        public void DoFileUpload(FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.PostedFile.ContentLength != 0)
                {
                    if (this._FilePath == null)
                    {
                        this._FilePath = HttpContext.Current.Server.MapPath("~/") + "Files/";
                    }
                    else
                    {
                        this._OldFilePath = this._FilePath + "/";
                        this._FilePath = HttpContext.Current.Server.MapPath("~/") + "Files/" + this._FilePath + "/";
                    }
                    string text = fileUpload.PostedFile.FileName.Substring(fileUpload.PostedFile.FileName.LastIndexOf('\\') + 1);
                    this._OldFileName = text.Split(new char[]
					{
						'.'
					})[0];
                    this._FileType = text.Substring(text.LastIndexOf('.') + 1);
                    this._FileSize = fileUpload.PostedFile.ContentLength;
                    if (!Directory.Exists(this._FilePath))
                    {
                        Directory.CreateDirectory(this._FilePath);
                    }
                    if (this._FileName == null)
                    {
                        this._OldFilePath = (this._FileName = text);
                        this._FilePath += this._FileName;
                    }
                    else
                    {
                        this._OldFilePath = this._OldFilePath + this._FileName + "." + this._FileType;
                        this._FilePath = this._FilePath + this._FileName + "." + this._FileType;
                    }
                    fileUpload.PostedFile.SaveAs(this._FilePath);
                    this._IsUpload = true;
                    this._Message = "上传成功";
                }
                else
                {
                    this._IsUpload = false;
                }
            }
            catch
            {
                this._IsUpload = false;
                this._Message = "上传失败";
            }
        }

        public static bool DeleteFile(string sPath)
        {
            bool result;
            try
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/") + "Files/" + sPath);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool IsImage()
        {
            return this._FileType != null && (this._FileType.ToLower() == "gif" || this._FileType.ToLower() == "jpg" || this._FileType.ToLower() == "jpeg" || this._FileType.ToLower() == "png" || this._FileType.ToLower() == "bmp");
        }
    }

    public class DownloadTemplateFile
    {
        public void DoFileDownload(string fileUploadName)
        {
            try
            {
                string strFilePath = HttpContext.Current.Server.MapPath("~") + fileUploadName;// "/Admin/UploadTemplates/安能物流信息绑定.xls";//服务器文件路径
                FileInfo fileInfo = new FileInfo(strFilePath);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpContext.Current.Server.UrlEncode(fileInfo.Name));
                HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/x-bittorrent";
                HttpContext.Current.Response.WriteFile(fileInfo.FullName);
                HttpContext.Current.Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //不做处理
            }
            catch (Exception ex)
            {
                //做处理
            }
        }
    }
}
