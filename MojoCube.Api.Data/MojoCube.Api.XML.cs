using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Text;


namespace MojoCube.Api.XML
{
    public class Rss
    {
        public string RssVersion;

        public string RssTitle;

        public string RssLink;

        public string RssDescription;

        public string RssFileName;

        public string ItemTitle;

        public string ItemLink;

        public string ItemDescription;

        public string ItemDate;

        public string ItemID;

        public void CreateRss(DataSet ds)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            xmlDocument.AppendChild(newChild);
            XmlElement xmlElement = xmlDocument.CreateElement("rss");
            xmlElement.SetAttribute("version", this.RssVersion);
            xmlDocument.AppendChild(xmlElement);
            XmlElement xmlElement2 = xmlDocument.CreateElement("channel");
            xmlElement.AppendChild(xmlElement2);
            XmlElement xmlElement3 = xmlDocument.CreateElement("title");
            XmlNode newChild2 = xmlDocument.CreateTextNode(this.RssTitle);
            xmlElement3.AppendChild(newChild2);
            xmlElement2.AppendChild(xmlElement3);
            xmlElement3 = xmlDocument.CreateElement("link");
            newChild2 = xmlDocument.CreateTextNode(this.RssLink);
            xmlElement3.AppendChild(newChild2);
            xmlElement2.AppendChild(xmlElement3);
            xmlElement3 = xmlDocument.CreateElement("description");
            XmlNode newChild3 = xmlDocument.CreateTextNode(this.RssDescription);
            xmlElement3.AppendChild(newChild3);
            xmlElement2.AppendChild(xmlElement3);
            DataTable dataTable = ds.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                XmlElement xmlElement4 = xmlDocument.CreateElement("item");
                xmlElement2.AppendChild(xmlElement4);
                XmlElement xmlElement5 = xmlDocument.CreateElement("title");
                XmlNode newChild4 = xmlDocument.CreateTextNode(dataRow[this.ItemTitle].ToString());
                xmlElement5.AppendChild(newChild4);
                xmlElement4.AppendChild(xmlElement5);
                xmlElement5 = xmlDocument.CreateElement("link");
                newChild4 = xmlDocument.CreateTextNode(this.ItemLink.Replace("[ItemID]", dataRow[this.ItemID].ToString()));
                xmlElement5.AppendChild(newChild4);
                xmlElement4.AppendChild(xmlElement5);
                xmlElement5 = xmlDocument.CreateElement("description");
                newChild4 = xmlDocument.CreateTextNode(dataRow[this.ItemDescription].ToString());
                xmlElement5.AppendChild(newChild4);
                xmlElement4.AppendChild(xmlElement5);
                xmlElement5 = xmlDocument.CreateElement("pubDate");
                newChild4 = xmlDocument.CreateTextNode(DateTime.Parse(dataRow[this.ItemDate].ToString()).ToString("yyyy-MM-dd"));
                xmlElement5.AppendChild(newChild4);
                xmlElement4.AppendChild(xmlElement5);
            }
            xmlDocument.Save(HttpContext.Current.Server.MapPath("~/Feeds/" + this.RssFileName));
        }

        public DataTable ReadRss(string RssURL)
        {
            DataTable result;
            try
            {
                DataTable dataTable = new DataTable();
                DataColumn column = new DataColumn("ID", typeof(string));
                DataColumn column2 = new DataColumn("Title", typeof(string));
                DataColumn column3 = new DataColumn("Author", typeof(string));
                DataColumn column4 = new DataColumn("PubDate", typeof(string));
                DataColumn column5 = new DataColumn("Link", typeof(string));
                DataColumn column6 = new DataColumn("Description", typeof(string));
                dataTable.Columns.Add(column);
                dataTable.Columns.Add(column2);
                dataTable.Columns.Add(column3);
                dataTable.Columns.Add(column4);
                dataTable.Columns.Add(column5);
                dataTable.Columns.Add(column6);
                WebRequest webRequest = WebRequest.Create(RssURL);
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(responseStream);
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("rss/channel/item");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["ID"] = (i + 1).ToString();
                    XmlNode xmlNode = xmlNodeList.Item(i).SelectSingleNode("title");
                    if (xmlNode != null)
                    {
                        dataRow["Title"] = xmlNode.InnerText;
                    }
                    else
                    {
                        dataRow["Title"] = "";
                    }
                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("author");
                    if (xmlNode != null)
                    {
                        dataRow["Author"] = xmlNode.InnerText;
                    }
                    else
                    {
                        dataRow["Author"] = "";
                    }
                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("pubDate");
                    if (xmlNode != null)
                    {
                        dataRow["PubDate"] = Convert.ToDateTime(xmlNode.InnerText).ToString("yyyy年MM月dd日");
                    }
                    else
                    {
                        dataRow["PubDate"] = "";
                    }
                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("link");
                    if (xmlNode != null)
                    {
                        dataRow["Link"] = xmlNode.InnerText;
                    }
                    else
                    {
                        dataRow["Link"] = "";
                    }
                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("description");
                    if (xmlNode != null)
                    {
                        dataRow["Description"] = xmlNode.InnerText;
                    }
                    else
                    {
                        dataRow["Description"] = "";
                    }
                    dataTable.Rows.Add(dataRow);
                }
                result = dataTable;
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
    public class SiteMap
    {
        public string CreateSiteMap(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            stringBuilder.AppendLine("<urlset xmlns=\"http://www.google.com/schemas/sitemap/0.84\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stringBuilder.AppendLine("<url>");
                    stringBuilder.AppendLine("<loc>" + dt.Rows[i]["loc"].ToString() + "</loc>");
                    if (dt.Columns.Contains("lastmod"))
                    {
                        stringBuilder.AppendLine("<lastmod>" + DateTime.Parse(dt.Rows[i]["lastmod"].ToString()).ToString("yyyy-MM-dd") + "</lastmod>");
                    }
                    if (dt.Columns.Contains("changefreq"))
                    {
                        stringBuilder.AppendLine("<changefreq>" + dt.Rows[i]["changefreq"].ToString() + "</changefreq>");
                    }
                    if (dt.Columns.Contains("priority"))
                    {
                        stringBuilder.AppendLine("<priority>" + dt.Rows[i]["priority"].ToString() + "</priority>");
                    }
                    stringBuilder.AppendLine("</url>");
                }
            }
            stringBuilder.AppendLine("</urlset>");
            return stringBuilder.ToString();
        }

        public DataTable ReadSiteMap(string url)
        {
            DataTable result;
            try
            {
                DataTable dataTable = new DataTable();
                DataColumn column = new DataColumn("loc", typeof(string));
                DataColumn column2 = new DataColumn("lastmod", typeof(string));
                DataColumn column3 = new DataColumn("changefreq", typeof(string));
                DataColumn column4 = new DataColumn("priority", typeof(string));
                dataTable.Columns.Add(column);
                dataTable.Columns.Add(column2);
                dataTable.Columns.Add(column3);
                dataTable.Columns.Add(column4);
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse response = webRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(responseStream);
                XmlElement documentElement = xmlDocument.DocumentElement;
                XmlNodeList elementsByTagName = documentElement.GetElementsByTagName("url");
                foreach (XmlNode xmlNode in elementsByTagName)
                {
                    DataRow dataRow = dataTable.NewRow();
                    XmlNodeList elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("loc");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["loc"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["loc"] = "";
                    }
                    elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("lastmod");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["lastmod"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["lastmod"] = "";
                    }
                    elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("changefreq");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["changefreq"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["changefreq"] = "";
                    }
                    elementsByTagName2 = ((XmlElement)xmlNode).GetElementsByTagName("priority");
                    if (elementsByTagName2.Count == 1)
                    {
                        dataRow["priority"] = elementsByTagName2[0].InnerText;
                    }
                    else
                    {
                        dataRow["priority"] = "";
                    }
                    dataTable.Rows.Add(dataRow);
                }
                result = dataTable;
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}
