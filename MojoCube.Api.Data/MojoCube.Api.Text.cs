using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;
using System.Web.UI.Adapters;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace MojoCube.Api.Text
{
    public class CheckSql
    {
        public static string NoHTML(string Htmlstring)
        {
            string result;
            if (Htmlstring == null)
            {
                result = "0";
            }
            else
            {
                Htmlstring = Htmlstring.Replace("\r\n", "");
                Htmlstring = Regex.Replace(Htmlstring, "<script.*?</script>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "<style.*?</style>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "<.*?>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "([\\r\\n])[\\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "¡", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "¢", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "£", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "©", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&#(\\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("'", "");
                Htmlstring = Htmlstring.Replace("--", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");
                Htmlstring = Regex.Replace(Htmlstring, "select", "s", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "insert", "i", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete from", "d", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "count''", "c", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop table", "d", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "truncate", "t", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "asc", "a", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "mid", "m", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "char", "c", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "x", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec master", "e", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "n", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "and", "a", RegexOptions.IgnoreCase);
                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
                if (Htmlstring == string.Empty)
                {
                    Htmlstring = "0";
                }
                result = Htmlstring;
            }
            return result;
        }

        public static string Format(string text)
        {
            text = text.Replace("'", "''");
            return text;
        }

        public static string Format(string text, string exception)
        {
            if (text != exception)
            {
                text = text.Replace("'", "''");
            }
            else
            {
                text = string.Empty;
            }
            return text;
        }

        public static string Filter(string text)
        {
            string result;
            if (text == null || text == "")
            {
                result = null;
            }
            else
            {
                string input = text.ToLower();
                string str = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
                string text2;
                if (Regex.Match(input, Regex.Escape(str), RegexOptions.IgnoreCase).Success)
                {
                    text2 = text.Replace(text, "''");
                }
                else
                {
                    text2 = text.Replace("'", "''");
                }
                result = text2;
            }
            return result;
        }
    }

    public class Content
    {
        public static string GetContentSummary(string content, int length, bool StripHTML)
        {
            string result;
            if (string.IsNullOrEmpty(content) || length == 0)
            {
                result = "";
            }
            else if (StripHTML)
            {
                Regex regex = new Regex("<[^>]*>");
                content = regex.Replace(content, "");
                content = content.Replace("\u3000", "").Replace(" ", "").Replace("&nbsp;", "");
                if (content.Length <= length)
                {
                    result = content;
                }
                else
                {
                    result = content.Substring(0, length) + "...";
                }
            }
            else if (content.Length <= length)
            {
                result = content;
            }
            else
            {
                int i = 0;
                int num = 0;
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                StringBuilder stringBuilder = new StringBuilder();
                while (i < content.Length)
                {
                    string text = content.Substring(i, 1);
                    if (text == "<")
                    {
                        string text2 = content.Substring(i + 1, 3).ToLower();
                        int num2;
                        if (text2.IndexOf("p") == 0 && text2.IndexOf("pre") != 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                        }
                        else if (text2.IndexOf("/p") == 0 && text2.IndexOf("/pr") != 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            if (num < length)
                            {
                                stringBuilder.Append("<br />");
                            }
                        }
                        else if (text2.IndexOf("br") == 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            if (num < length)
                            {
                                stringBuilder.Append("<br />");
                            }
                        }
                        else if (text2.IndexOf("img") == 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            if (num < length)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                                num += num2 - i + 1;
                            }
                        }
                        else if (text2.IndexOf("li") == 0 || text2.IndexOf("/li") == 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            if (num < length)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                            }
                            else if (!flag3 && text2.IndexOf("/li") == 0)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                                flag3 = true;
                            }
                        }
                        else if (text2.IndexOf("tr") == 0 || text2.IndexOf("/tr") == 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            if (num < length)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                            }
                            else if (!flag2 && text2.IndexOf("/tr") == 0)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                                flag2 = true;
                            }
                        }
                        else if (text2.IndexOf("td") == 0 || text2.IndexOf("/td") == 0)
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            if (num < length)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                            }
                            else if (!flag2)
                            {
                                stringBuilder.Append(content.Substring(i, num2 - i));
                            }
                        }
                        else
                        {
                            num2 = content.IndexOf(">", i) + 1;
                            stringBuilder.Append(content.Substring(i, num2 - i));
                        }
                        if (num2 <= i)
                        {
                            num2 = i + 1;
                        }
                        i = num2;
                    }
                    else
                    {
                        if (num < length)
                        {
                            stringBuilder.Append(text);
                            num++;
                        }
                        else if (!flag)
                        {
                            stringBuilder.Append("...");
                            flag = true;
                        }
                        i++;
                    }
                }
                result = stringBuilder.ToString();
            }
            return result;
        }

        public static string GetPageContent(string content, int count)
        {
            int num = 1;
            string text = HttpContext.Current.Request.QueryString["page"];
            if (text != null)
            {
                try
                {
                    num = Convert.ToInt32(text);
                }
                catch
                {
                    num = 1;
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div class='pageContent'>");
            int num2 = 0;
            string[] array = new string[count];
            while (content.Length > count && num2 < count - 1)
            {
                if (content.IndexOf("<hr class=\"page-break\" />", count) < 0)
                {
                    break;
                }
                array[num2] = content.Substring(0, content.IndexOf("<hr class=\"page-break\" />", count));
                content = content.Remove(0, array[num2].Length);
                num2++;
            }
            array[num2] = content;
            string[] array2 = array;
            if (array2[num - 1] != null)
            {
                stringBuilder.Append("<div>" + array2[num - 1].ToString() + "</div>");
            }
            else
            {
                stringBuilder.Append("<div>None</div>");
            }
            string text2 = string.Empty;
            string path = HttpContext.Current.Request.Path;
            int num3 = 0;
            string text3 = string.Empty;
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i] != null)
                {
                    num3 = i + 1;
                    if (num3 == num)
                    {
                        text3 = "class='focus'";
                    }
                    else
                    {
                        text3 = "";
                    }
                    object obj = text2;
                    text2 = string.Concat(new object[]
					{
						obj,
						"<a href=",
						path,
						"?page=",
						num3,
						" onfocus=\"this.blur();\" ",
						text3,
						"><span>",
						num3,
						"</span></a>"
					});
                }
            }
            if (num3 > 1)
            {
                stringBuilder.Append("<div class='pager'>" + text2.ToString() + "</div>");
            }
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();
        }
    }

    public class Function
    {
        public static string SubString(string text, int textLong)
        {
            if (text.Length > textLong)
            {
                text = text.Substring(0, textLong) + "...";
            }
            return text;
        }

        public static string SubString(string text, int textLong, string format)
        {
            if (text.Length > textLong)
            {
                text = text.Substring(0, textLong) + format;
            }
            return text;
        }

        public static string DateTimeString(bool IsDate)
        {
            string result;
            if (IsDate)
            {
                Random random = new Random();
                result = DateTime.Now.ToString("yyyyMMddHHmmssffff") + random.Next(1000, 9999).ToString();
            }
            else
            {
                result = Guid.NewGuid().ToString();
            }
            return result;
        }

        public static string GetAnonymous(string name)
        {
            if (name.Length > 1)
            {
                name = name.Replace(name.Substring(1, 1), "*");
            }
            return name;
        }

        public static string UpperUrlEncode(string s)
        {
            char[] array = HttpUtility.UrlEncode(s).ToCharArray();
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i] == '%')
                {
                    array[i + 1] = char.ToUpper(array[i + 1]);
                    array[i + 2] = char.ToUpper(array[i + 2]);
                }
            }
            return new string(array);
        }

        public static string ToHtmlString(string content)
        {
            content = content.Replace("\n", "<br />");
            return content;
        }
    }

    public class HtmlHeadAdapter : ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine("<head>");
            this.RenderChildren(writer);
            writer.Write("</head>");
        }

        protected override void OnPreRender(EventArgs e)
        {
            bool flag = false;
            foreach (Control control in base.Control.Controls)
            {
                if (control is HtmlTitle)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                HtmlTitle htmlTitle = new HtmlTitle();
                htmlTitle.Text = base.Page.Title;
                base.Control.Controls.Add(htmlTitle);
            }
            base.OnPreRender(e);
        }
    }

    public class HtmlLinkAdapter : ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            AttributeCollection attributes = ((HtmlLink)base.Control).Attributes;
            if (attributes != null && attributes.Count > 0)
            {
                writer.Write("<link");
                foreach (string text in attributes.Keys)
                {
                    writer.Write(" ");
                    writer.Write(text);
                    writer.Write("=\"");
                    if (0 == string.Compare("href", text, true, CultureInfo.InvariantCulture))
                    {
                        writer.Write(base.Control.ResolveUrl(attributes[text]));
                    }
                    else
                    {
                        writer.Write(attributes[text]);
                    }
                    writer.Write("\"");
                }
                writer.WriteLine(" />");
            }
        }
    }

    public class HtmlMetaAdapter : ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlMeta htmlMeta = (HtmlMeta)base.Control;
            writer.Write("<meta");
            if (!string.IsNullOrEmpty(htmlMeta.HttpEquiv))
            {
                writer.Write(" http-equiv=\"");
                writer.Write(htmlMeta.HttpEquiv);
            }
            if (!string.IsNullOrEmpty(htmlMeta.Name))
            {
                writer.Write(" name=\"");
                writer.Write(htmlMeta.Name);
            }
            writer.Write("\" content=\"");
            writer.Write(htmlMeta.Content);
            writer.WriteLine("\" />");
        }
    }

    public class HtmlTitleAdapter : ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlTitle htmlTitle = (HtmlTitle)base.Control;
            writer.Write("<title>");
            writer.Write(htmlTitle.Text);
            writer.WriteLine("</title>");
        }
    }

    public class RegexClass
    {
        public static string GetUrlFileName()
        {
            string input = string.Empty;
            if (HttpContext.Current != null)
            {
                input = HttpContext.Current.Request.Path.ToString();
            }
            Regex regex = new Regex("\\w*\\.\\w*");
            return regex.Match(input).Value.ToString();
        }

        public static string GetUrlShortFileName()
        {
            string input = string.Empty;
            if (HttpContext.Current != null)
            {
                input = HttpContext.Current.Request.Path.ToString();
            }
            Regex regex = new Regex("([\\w-]+\\.)+[\\w-]+(/[\\w-\\./?%=]*)?");
            return regex.Match(input).Value.ToString().Split(new char[]
			{
				'.'
			})[0];
        }

        public static string GetUrlShortFileName(string url)
        {
            Regex regex = new Regex("([\\w-]+\\.)+[\\w-]+(/[\\w-\\./?%=]*)?");
            url = regex.Match(url).Value.ToString().Split(new char[]
			{
				'.'
			})[0];
            return url;
        }

        public static string ChkInt(string value)
        {
            string result;
            if (value != null)
            {
                string pattern = "^\\d+$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (match.Success)
                {
                    result = value;
                }
                else
                {
                    result = "0";
                }
            }
            else
            {
                result = "0";
            }
            return result;
        }
    }

    public class Security
    {
        public static string sKey = "^$@%#!*&";

        public static string EncryptString(string JiaMiString)
        {
            string result = "";
            try
            {
                JiaMiString = Security.sKey + JiaMiString;
                byte[] bytes = Encoding.GetEncoding(0).GetBytes(JiaMiString);
                result = Convert.ToBase64String(bytes);
            }
            catch
            {
                result = JiaMiString;
            }
            return result;
        }

        public static string DecryptString(string JieMiString)
        {
            string text = "";
            try
            {
                byte[] bytes = Convert.FromBase64String(JieMiString);
                text = Encoding.GetEncoding(0).GetString(bytes);
                text = text.Replace(Security.sKey, "");
            }
            catch
            {
                text = "0";
            }
            return text;
        }
    }
}
