using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    /// <summary>
    /// Summary description for upFile
    /// </summary>
    public class upFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string savePath = context.Request["path"];
            HttpPostedFile file = context.Request.Files[0];
            //文件扩展名
            string fileType = System.IO.Path.GetExtension(file.FileName);
            //存到文件服务器的文件名称 用当前时间命名
            string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
            string filePath = System.IO.Path.GetFullPath("公司证件UploadFile/") + aaa;

            //if (!Directory.Exists(filePath))
            //{
            //    Directory.CreateDirectory(filePath);
            //}
            string fileNewName = DateTime.Now.ToString("yyyyMMddHHmmss_fff") + fileType;
            try
            {
                file.SaveAs(savePath + fileNewName);
                context.Response.Write("上传成功！");
            }
            catch (Exception ex)
            {
                context.Response.Write("上传失败！错误信息：" + ex.Message.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}