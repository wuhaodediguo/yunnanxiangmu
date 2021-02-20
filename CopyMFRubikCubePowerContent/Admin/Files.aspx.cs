using MojoCube.Api.File;
using MojoCube.Api.Text;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace CopyMFRubikCubePowerContent.Admin
{
    public partial class Admin_Files : System.Web.UI.Page
    {
        private int cutWidth;

        private int cutHeight;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.GetFile();
            }
        }

        private void GetFile()
        {
            try
            {
                if (base.Request.QueryString["image"] != null)
                {
                    string text = Security.DecryptString(base.Request.QueryString["image"]);
                    string text2;
                    if (text.Length > 0)
                    {
                        if (text == "no_image.jpg")
                        {
                            text2 = base.Server.MapPath("~/Images/no_image.jpg");
                        }
                        else
                        {
                            text2 = base.Server.MapPath("~/Files/" + text);
                        }
                    }
                    else
                    {
                        text2 = base.Server.MapPath("~/Images/blank.png");
                    }
                    DateTime lastWriteTime = File.GetLastWriteTime(text2);
                    DateTime dateTime = new DateTime(lastWriteTime.Year, lastWriteTime.Month, lastWriteTime.Day, lastWriteTime.Hour, lastWriteTime.Minute, lastWriteTime.Second);
                    string text3 = base.Request.Headers["If-Modified-Since"];
                    DateTime t;
                    if (text3 != null && DateTime.TryParse(text3, out t) && t >= dateTime)
                    {
                        base.Response.StatusCode = 304;
                    }
                    else if (dateTime.ToUniversalTime() < DateTime.UtcNow)
                    {
                        HttpCachePolicy cache = base.Response.Cache;
                        cache.SetCacheability(HttpCacheability.Public);
                        cache.SetLastModified(dateTime);
                    }
                    Image image = Image.FromFile(text2);
                    int num = image.Width;
                    int num2 = image.Height;
                    if (base.Request.QueryString["w"] != null && base.Request.QueryString["h"] != null && text.Length > 0)
                    {
                        if (num > num2 && num > int.Parse(base.Request.QueryString["w"]))
                        {
                            num = int.Parse(base.Request.QueryString["w"]);
                            num2 = image.Height * num / image.Width;
                        }
                        else if (num2 > num && num2 > int.Parse(base.Request.QueryString["h"]))
                        {
                            num2 = int.Parse(base.Request.QueryString["h"]);
                            num = image.Width * num2 / image.Height;
                        }
                        else if (num == num2)
                        {
                            num2 = int.Parse(base.Request.QueryString["h"]);
                            num = image.Width * num2 / image.Height;
                        }
                    }
                    Image image2;
                    if (base.Request.QueryString["cut"] != null)
                    {
                        FileInfo file = new FileInfo(text2);
                        byte[] buffer = this.CutPhoto(file, base.Request.QueryString["cut"]);
                        MemoryStream memoryStream = new MemoryStream(buffer);
                        image2 = (Bitmap)Image.FromStream(memoryStream);
                        memoryStream.Close();
                    }
                    else
                    {
                        image2 = new Bitmap(num, num2);
                        Graphics graphics = Graphics.FromImage(image2);
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(image, new Rectangle(0, 0, num, num2));
                    }
                    MemoryStream memoryStream2 = new MemoryStream();
                    string contentType = MojoCube.Api.File.Function.GetContentType(text);
                    if (contentType == "image/png")
                    {
                        image2.Save(memoryStream2, ImageFormat.Png);
                    }
                    else
                    {
                        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                        EncoderParameters encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                        image2.Save(memoryStream2, imageEncoders[1], encoderParameters);
                    }
                    byte[] buffer2 = memoryStream2.ToArray();
                    base.Response.Clear();
                    base.Response.ContentType = contentType;
                    string str = base.Server.HtmlEncode(text.Substring(text.LastIndexOf('/') + 1));
                    base.Response.AddHeader("Content-Disposition", "inline;filename=\"" + str + "\"");
                    base.Response.Charset = "";
                    base.Response.ContentEncoding = Encoding.Unicode;
                    base.Response.AddHeader("Connection", "close");
                    base.Response.BinaryWrite(buffer2);
                    image2.Dispose();
                    memoryStream2.Dispose();
                    image.Dispose();
                }
                else if (base.Request.QueryString["file"] != null)
                {
                    string text4 = Security.DecryptString(base.Request.QueryString["file"]);
                    FileInfo fileInfo = new FileInfo(base.Server.MapPath("~/Files/" + text4));
                    FileStream fileStream = fileInfo.OpenRead();
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    byte[] buffer3 = binaryReader.ReadBytes((int)fileStream.Length);
                    fileStream.Dispose();
                    binaryReader.Close();
                    base.Response.Clear();
                    base.Response.ContentType = MojoCube.Api.File.Function.GetContentType(text4);
                    string str2 = base.Server.HtmlEncode(text4.Substring(text4.LastIndexOf('/') + 1));
                    base.Response.AddHeader("Content-Disposition", "inline;filename=\"" + str2 + "\"");
                    base.Response.Charset = "";
                    base.Response.ContentEncoding = Encoding.Unicode;
                    base.Response.AddHeader("Connection", "close");
                    base.Response.BinaryWrite(buffer3);
                }
            }
            catch
            {
                base.Response.Write("Error!");
            }
        }

        private void FormatCutSize(string text)
        {
            string[] array = text.Split(new char[]
		{
			','
		});
            if (array.Length > 1)
            {
                this.cutWidth = int.Parse(array[0].ToString());
                this.cutHeight = int.Parse(array[1].ToString());
                return;
            }
            this.cutWidth = (this.cutHeight = int.Parse(array[0].ToString()));
        }

        public byte[] CutPhoto(FileInfo file, string text)
        {
            string[] array = text.Split(new char[]
		{
			','
		});
            int num;
            if (array.Length > 1)
            {
                num = int.Parse(array[0].ToString());
                int.Parse(array[1].ToString());
            }
            else
            {
                num = int.Parse(array[0].ToString());
            }
            int num2 = num;
            Image image = Image.FromFile(file.FullName);
            byte[] array2;
            if (image.Width <= num2 && image.Height <= num2)
            {
                FileStream fileStream = file.OpenRead();
                array2 = new byte[fileStream.Length];
                fileStream.Read(array2, 0, Convert.ToInt32(fileStream.Length));
                return array2;
            }
            int num3 = image.Width;
            int num4 = image.Height;
            if (num3 != num4)
            {
                Image image2;
                Graphics graphics;
                if (num3 > num4)
                {
                    image2 = new Bitmap(num4, num4);
                    graphics = Graphics.FromImage(image2);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    Rectangle srcRect = new Rectangle((num3 - num4) / 2, 0, num4, num4);
                    Rectangle destRect = new Rectangle(0, 0, num4, num4);
                    graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                    num3 = num4;
                }
                else
                {
                    image2 = new Bitmap(num3, num3);
                    graphics = Graphics.FromImage(image2);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    Rectangle srcRect2 = new Rectangle(0, (num4 - num3) / 2, num3, num3);
                    Rectangle destRect2 = new Rectangle(0, 0, num3, num3);
                    graphics.DrawImage(image, destRect2, srcRect2, GraphicsUnit.Pixel);
                    num4 = num3;
                }
                image.Dispose();
                image = (Image)image2.Clone();
                graphics.Dispose();
                image2.Dispose();
            }
            Image image3 = new Bitmap(num2, num2);
            Graphics graphics2 = Graphics.FromImage(image3);
            graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics2.SmoothingMode = SmoothingMode.HighQuality;
            graphics2.Clear(Color.White);
            graphics2.DrawImage(image, new Rectangle(0, 0, num2, num2), new Rectangle(0, 0, num3, num4), GraphicsUnit.Pixel);
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            ImageCodecInfo[] array3 = imageEncoders;
            for (int i = 0; i < array3.Length; i++)
            {
                ImageCodecInfo imageCodecInfo = array3[i];
                if (imageCodecInfo.MimeType == "image/jpeg" || imageCodecInfo.MimeType == "image/bmp" || imageCodecInfo.MimeType == "image/png" || imageCodecInfo.MimeType == "image/gif")
                {
                    encoder = imageCodecInfo;
                }
            }
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Position = 0L;
            image3.Save(memoryStream, encoder, encoderParameters);
            array2 = memoryStream.ToArray();
            memoryStream.Dispose();
            graphics2.Dispose();
            image3.Dispose();
            image.Dispose();
            return array2;
        }
    }
}