using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CopyMFRubikCubePowerContent.Admin.Identify
{
    public partial class CheckCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CreateCheckCodeImage(this.GenerateCheckCode());
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        private string GenerateCheckCode()
        {
            string text = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int num = random.Next();
                char c;
                if (num % 2 == 0)
                {
                    c = (char)(48 + (ushort)(num % 10));
                }
                else
                {
                    c = (char)(65 + (ushort)(num % 26));
                }
                text += c.ToString();
            }
            this.Session["CheckCode"] = text;
            return text;
        }

        private void CreateCheckCodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == string.Empty)
            {
                return;
            }
            Bitmap bitmap = new Bitmap(100, 30);
            Graphics graphics = Graphics.FromImage(bitmap);
            try
            {
                Random random = new Random();
                graphics.Clear(Color.White);
                for (int i = 0; i < 25; i++)
                {
                    int x = random.Next(bitmap.Width);
                    int x2 = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    int y2 = random.Next(bitmap.Height);
                    graphics.DrawLine(new Pen(Color.Silver), x, y, x2, y2);
                }
                Font font = new Font("Arial", 18f, FontStyle.Bold | FontStyle.Italic);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue, Color.Blue, 1.2f, true);
                graphics.DrawString(checkCode, font, brush, 2f, 2f);
                for (int j = 0; j < 5; j++)
                {
                    int x3 = random.Next(bitmap.Width);
                    int y3 = random.Next(bitmap.Height);
                    bitmap.SetPixel(x3, y3, Color.FromArgb(random.Next()));
                }
                graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                MemoryStream memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, ImageFormat.Gif);
                base.Response.ClearContent();
                base.Response.ContentType = "image/Gif";
                base.Response.BinaryWrite(memoryStream.ToArray());
            }
            finally
            {
                graphics.Dispose();
                bitmap.Dispose();
            }
        }
    }
}