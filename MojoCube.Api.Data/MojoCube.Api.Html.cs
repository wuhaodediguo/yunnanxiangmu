using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MojoCube.Api.Html
{
    public class AspxToHtml
    {
        public static bool ExecAspxToHtml(string Url, string Path, string FileName)
        {
            bool result;
            try
            {
                StringWriter stringWriter = new StringWriter();
                Page page = new Page();
                page.Server.Execute(Url, stringWriter);
                StreamWriter streamWriter = new StreamWriter(Path + FileName, true, Encoding.GetEncoding("utf-8"));
                streamWriter.Write(stringWriter.ToString());
                stringWriter.Close();
                streamWriter.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }

    public class Header
    {
        public Page _page;

        public Header(Page page)
        {
            this._page = page;
        }

        public void AddLiteral(string Literal)
        {
            Literal literal = new Literal();
            literal.Text = Literal + "\n";
            this._page.Header.Controls.Add(literal);
        }

        public void AddMeta(string name, string content)
        {
            HtmlMeta htmlMeta = new HtmlMeta();
            HtmlHead header = this._page.Header;
            htmlMeta.Name = name;
            htmlMeta.Content = content;
            header.Controls.Add(htmlMeta);
        }

        public void AddMeta(string type, string key, string content)
        {
            HtmlMeta htmlMeta = new HtmlMeta();
            HtmlHead header = this._page.Header;
            string text = type.ToLower();
            if (text != null)
            {
                if (!(text == "name"))
                {
                    if (text == "http-equiv")
                    {
                        htmlMeta.HttpEquiv = key;
                    }
                }
                else
                {
                    htmlMeta.Name = key;
                }
            }
            htmlMeta.Content = content;
            header.Controls.Add(htmlMeta);
        }

        public void AddCSS(string url)
        {
            HtmlLink htmlLink = new HtmlLink();
            htmlLink.Attributes.Add("type", "text/css");
            htmlLink.Attributes.Add("rel", "stylesheet");
            htmlLink.Attributes.Add("href", url);
            this._page.Header.Controls.Add(htmlLink);
        }

        public void AddJS(string url)
        {
            Literal literal = new Literal();
            literal.Text = "<script language=\"javascript\" src=\"" + url + "\" type=\"text/javascript\"></script>\n";
            this._page.Header.Controls.Add(literal);
        }

        public void AddJS(string type, string script)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("script");
            if (type != null)
            {
                if (type == "javascript")
                {
                    htmlGenericControl.Attributes.Add("type", "text/javascript");
                    goto IL_50;
                }
            }
            htmlGenericControl.Attributes.Add("type", "text/javascript");
        IL_50:
            htmlGenericControl.InnerHtml = script;
            this._page.Header.Controls.Add(htmlGenericControl);
        }
    }
}
