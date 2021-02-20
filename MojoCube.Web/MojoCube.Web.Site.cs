using System;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Web;
using MojoCube.Api.UI;
using System.Text.RegularExpressions;

namespace MojoCube.Web.Site
{
    public class Banner
    {
        private int _pk_Banner;

        private string _Title;

        private string _Description;

        private string _Url;

        private string _Target;

        private int _TypeID;

        private string _FileName;

        private string _FilePath;

        private string _FileType;

        private int _FileSize;

        private int _Width;

        private int _Height;

        private int _SortID;

        private bool _Visible;

        private string _CreateDate;

        private int _CreateUserID;

        private string _ModifyDate;

        private int _ModifyUserID;

        private string _Language;

        public int pk_Banner
        {
            get
            {
                return this._pk_Banner;
            }
            set
            {
                this._pk_Banner = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public string Target
        {
            get
            {
                return this._Target;
            }
            set
            {
                this._Target = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
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

        public int Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
            }
        }

        public int Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this._Height = value;
            }
        }

        public int SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                this._SortID = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }

        public string CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this._CreateDate = value;
            }
        }

        public int CreateUserID
        {
            get
            {
                return this._CreateUserID;
            }
            set
            {
                this._CreateUserID = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public int ModifyUserID
        {
            get
            {
                return this._ModifyUserID;
            }
            set
            {
                this._ModifyUserID = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Site_Banner where pk_Banner=@pk_Banner";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Banner", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Banner"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Banner = Convert.ToInt32(oleDbDataReader["pk_Banner"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._Description = oleDbDataReader["Description"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._Target = oleDbDataReader["Target"].ToString();
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._FileName = oleDbDataReader["FileName"].ToString();
                    this._FilePath = oleDbDataReader["FilePath"].ToString();
                    this._FileType = oleDbDataReader["FileType"].ToString();
                    this._FileSize = Convert.ToInt32(oleDbDataReader["FileSize"].ToString());
                    this._Width = Convert.ToInt32(oleDbDataReader["Width"].ToString());
                    this._Height = Convert.ToInt32(oleDbDataReader["Height"].ToString());
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._Visible = Convert.ToBoolean(oleDbDataReader["Visible"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._CreateUserID = Convert.ToInt32(oleDbDataReader["CreateUserID"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    if (oleDbDataReader["ModifyUserID"] != DBNull.Value)
                    {
                        this._ModifyUserID = Convert.ToInt32(oleDbDataReader["ModifyUserID"].ToString());
                    }
                    else
                    {
                        this._ModifyUserID = 0;
                    }
                    this._Language = oleDbDataReader["Language"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Banner(Title,Description,Url,Target,TypeID,FileName,FilePath,FileType,FileSize,Width,Height,SortID,Visible,CreateDate,CreateUserID,ModifyDate,ModifyUserID,[Language]) values (@Title,@Description,@Url,@Target,@TypeID,@FileName,@FilePath,@FileType,@FileSize,@Width,@Height,@SortID,@Visible,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@FileName"].Value = this._FileName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FilePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@FilePath"].Value = this._FilePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileType", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@FileType"].Value = this._FileType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileSize", OleDbType.Integer));
                oleDbCommand.Parameters["@FileSize"].Value = this._FileSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Width", OleDbType.Integer));
                oleDbCommand.Parameters["@Width"].Value = this._Width;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Height", OleDbType.Integer));
                oleDbCommand.Parameters["@Height"].Value = this._Height;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Site_Banner set Title=@Title,Description=@Description,Url=@Url,Target=@Target,TypeID=@TypeID,FileName=@FileName,FilePath=@FilePath,FileType=@FileType,FileSize=@FileSize,Width=@Width,Height=@Height,SortID=@SortID,Visible=@Visible,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,[Language]=@Language where pk_Banner=@pk_Banner";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@FileName"].Value = this._FileName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FilePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@FilePath"].Value = this._FilePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileType", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@FileType"].Value = this._FileType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@FileSize", OleDbType.Integer));
                oleDbCommand.Parameters["@FileSize"].Value = this._FileSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Width", OleDbType.Integer));
                oleDbCommand.Parameters["@Width"].Value = this._Width;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Height", OleDbType.Integer));
                oleDbCommand.Parameters["@Height"].Value = this._Height;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Banner", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Banner"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Banner where pk_Banner=" + id);
        }
    }

    public class Cache
    {
        public static void RemoveCache(string key)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
        }

        public void RemoveAllCache()
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = cache.GetEnumerator();
            ArrayList arrayList = new ArrayList();
            while (enumerator.MoveNext())
            {
                arrayList.Add(enumerator.Key);
            }
            foreach (string key in arrayList)
            {
                cache.Remove(key);
            }
        }

        public DataSet GetCacheDS()
        {
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CacheKey");
            while (enumerator.MoveNext())
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["CacheKey"] = enumerator.Key;
                dataTable.Rows.Add(dataRow);
            }
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        public static DataTable GetLanguageDT()
        {
            if (HttpRuntime.Cache["MojoCube_LanguageDT"] == null)
            {
                Language language = new Language();
                HttpRuntime.Cache["MojoCube_LanguageDT"] = language.LanguageDT(HttpContext.Current.Server.MapPath("~/App_LocalResources/config.xml"));
            }
            return (DataTable)HttpRuntime.Cache["MojoCube_LanguageDT"];
        }

        public static string GetIsBoundIP(string language)
        {
            if (HttpRuntime.Cache["MojoCube_IsBoundIP_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_IsBoundIP_" + language] = config.IsBoundIP.ToString();
            }
            return HttpRuntime.Cache["MojoCube_IsBoundIP_" + language].ToString();
        }

        public static string GetBoundIP(string language)
        {
            if (HttpRuntime.Cache["MojoCube_BoundIP_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_BoundIP_" + language] = config.BoundIP;
            }
            return HttpRuntime.Cache["MojoCube_BoundIP_" + language].ToString();
        }

        public static string GetUrlExtension(string language)
        {
            if (HttpRuntime.Cache["MojoCube_UrlExtension_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_UrlExtension_" + language] = config.UrlExtension;
            }
            return HttpRuntime.Cache["MojoCube_UrlExtension_" + language].ToString();
        }

        public static string GetUrlExtension(string url, string language)
        {
            string result;
            if (url == "#")
            {
                result = url;
            }
            else
            {
                string pattern = "http://([\\w-]+\\.)+[\\w-]+(/[\\w-\\./?%=]*)?";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(url);
                if (match.Success)
                {
                    url = url.Trim();
                }
                else
                {
                    url = url.Split(new char[]
					{
						'.'
					})[0].ToLower();
                    if (HttpRuntime.Cache["MojoCube_UrlExtension_" + language] == null)
                    {
                        Config config = new Config();
                        config.GetData(1, language);
                        HttpRuntime.Cache["MojoCube_UrlExtension_" + language] = config.UrlExtension;
                    }
                    string text = HttpRuntime.Cache["MojoCube_UrlExtension_" + language].ToString();
                    if (text != null)
                    {
                        if (text == "")
                        {
                            url = url.Trim() + "/";
                            goto IL_131;
                        }
                    }
                    url = url.Trim() + "." + HttpRuntime.Cache["MojoCube_UrlExtension_" + language].ToString();
                IL_131: ;
                }
                result = url;
            }
            return result;
        }

        public static string GetSiteTheme(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteTheme_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteTheme_" + language] = config.SiteTheme;
            }
            return HttpRuntime.Cache["MojoCube_SiteTheme_" + language].ToString();
        }

        public static string GetSiteName(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteName_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteName_" + language] = config.SiteName;
            }
            return HttpRuntime.Cache["MojoCube_SiteName_" + language].ToString();
        }

        public static string GetSiteTitle(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteTitle_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteTitle_" + language] = config.SiteTitle;
            }
            return HttpRuntime.Cache["MojoCube_SiteTitle_" + language].ToString();
        }

        public static string GetSiteContentType(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteContentType_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteContentType_" + language] = config.SiteContentType;
            }
            return HttpRuntime.Cache["MojoCube_SiteContentType_" + language].ToString();
        }

        public static string GetSiteKeyword(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteKeyword_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteKeyword_" + language] = config.SiteKeyword;
            }
            return HttpRuntime.Cache["MojoCube_SiteKeyword_" + language].ToString();
        }

        public static string GetSiteDescription(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteDescription_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteDescription_" + language] = config.SiteDescription;
            }
            return HttpRuntime.Cache["MojoCube_SiteDescription_" + language].ToString();
        }

        public static string GetStatistics(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Statistics_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Statistics_" + language] = config.StatisticsCode;
            }
            return HttpRuntime.Cache["MojoCube_Statistics_" + language].ToString();
        }

        public static string GetShare(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Share_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Share_" + language] = config.ShareCode;
            }
            return HttpRuntime.Cache["MojoCube_Share_" + language].ToString();
        }

        public static string GetSiteLogo(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteLogo_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteLogo_" + language] = config.SiteLogo;
            }
            return HttpRuntime.Cache["MojoCube_SiteLogo_" + language].ToString();
        }

        public static string GetSiteContact(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteContact_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteContact_" + language] = config.SiteContact;
            }
            return HttpRuntime.Cache["MojoCube_SiteContact_" + language].ToString();
        }

        public static string GetContactUs(string language)
        {
            if (HttpRuntime.Cache["MojoCube_ContactUs_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_ContactUs_" + language] = config.ContactUs;
            }
            return HttpRuntime.Cache["MojoCube_ContactUs_" + language].ToString();
        }

        public static string GetSiteCopyRight(string language)
        {
            if (HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                if (config.IsSiteOpen)
                {
                    HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language] = "1";
                }
                else
                {
                    HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language] = "0";
                }
            }
            if (HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language].ToString() == "0")
            {
                HttpContext.Current.Response.Redirect("~/Info.aspx?type=0");
                HttpContext.Current.Response.End();
            }
            if (HttpRuntime.Cache["MojoCube_SiteCounter_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                if (config.SiteCounter)
                {
                    HttpRuntime.Cache["MojoCube_SiteCounter_" + language] = "1";
                }
                else
                {
                    HttpRuntime.Cache["MojoCube_SiteCounter_" + language] = "0";
                }
            }
            if (HttpRuntime.Cache["MojoCube_SiteCounter_" + language].ToString() == "1")
            {
                Log.InsertData(language);
            }
            if (HttpRuntime.Cache["MojoCube_SiteCopyRight_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteCopyRight_" + language] = config.SiteCopyRight;
            }
            return HttpRuntime.Cache["MojoCube_SiteCopyRight_" + language].ToString();
        }

        public static string GetMap(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Map_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Map_" + language] = config.MapCode;
            }
            return HttpRuntime.Cache["MojoCube_Map_" + language].ToString();
        }

        public static string GetSiteNotify(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteNotify_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteNotify_" + language] = config.SiteNotify;
            }
            return HttpRuntime.Cache["MojoCube_SiteNotify_" + language].ToString();
        }

        public static string GetSearchType(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SearchType_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SearchType_" + language] = config.SearchType.ToString();
            }
            return HttpRuntime.Cache["MojoCube_SearchType_" + language].ToString();
        }

        public static string GetSiteService(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteService_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteService_" + language] = config.ShowService;
            }
            return HttpRuntime.Cache["MojoCube_SiteService_" + language].ToString();
        }

        public static string GetArticleTitleLength(string language)
        {
            if (HttpRuntime.Cache["MojoCube_ArticleTitleLength_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_ArticleTitleLength_" + language] = config.ArticleTitleLength;
            }
            return HttpRuntime.Cache["MojoCube_ArticleTitleLength_" + language].ToString();
        }
    }

    public class Config
    {
        private int _pk_Config;

        private int _IndexID;

        private string _SiteName;

        private string _SiteTitle;

        private string _SiteKeyword;

        private string _SiteDescription;

        private string _SiteContentType;

        private string _SiteUrl;

        private string _SiteLogo;

        private string _SiteCopyRight;

        private string _SiteContact;

        private string _SiteNotify;

        private string _MapCode;

        private string _StatisticsCode;

        private string _ShareCode;

        private string _OtherMeta;

        private string _ContactUs;

        private bool _IsSiteOpen;

        private string _ClosedInfo;

        private int _ShowPageSize;

        private bool _AllowComment;

        private string _SiteLogoPath;

        private string _ArticleImagePath;

        private string _ProductImagePath;

        private string _ADImagePath;

        private int _ImgSize_S_W;

        private int _ImgSize_S_H;

        private int _ImgSize_M_W;

        private int _ImgSize_M_H;

        private string _SiteTheme;

        private string _WM_Text;

        private string _WM_Font;

        private int _WM_FontSize;

        private int _WM_Bottom;

        private int _WM_Right;

        private int _WM_Rotate;

        private int _WM_Size;

        private int _WM_Alpha;

        private int _WM_Red;

        private int _WM_Green;

        private int _WM_Blue;

        private bool _WM_IsShow;

        private int _WM_Show_W;

        private int _WM_Show_H;

        private bool _WM_Mode;

        private string _WM_ImagePath;

        private bool _SiteCounter;

        private int _SiteFlow;

        private string _UrlExtension;

        private bool _IsBoundIP;

        private string _BoundIP;

        private string _Target;

        private int _SearchType;

        private bool _ShowService;

        private int _ArticleTitleLength;

        private string _Language;

        public int pk_Config
        {
            get
            {
                return this._pk_Config;
            }
            set
            {
                this._pk_Config = value;
            }
        }

        public int IndexID
        {
            get
            {
                return this._IndexID;
            }
            set
            {
                this._IndexID = value;
            }
        }

        public string SiteName
        {
            get
            {
                return this._SiteName;
            }
            set
            {
                this._SiteName = value;
            }
        }

        public string SiteTitle
        {
            get
            {
                return this._SiteTitle;
            }
            set
            {
                this._SiteTitle = value;
            }
        }

        public string SiteKeyword
        {
            get
            {
                return this._SiteKeyword;
            }
            set
            {
                this._SiteKeyword = value;
            }
        }

        public string SiteDescription
        {
            get
            {
                return this._SiteDescription;
            }
            set
            {
                this._SiteDescription = value;
            }
        }

        public string SiteContentType
        {
            get
            {
                return this._SiteContentType;
            }
            set
            {
                this._SiteContentType = value;
            }
        }

        public string SiteUrl
        {
            get
            {
                return this._SiteUrl;
            }
            set
            {
                this._SiteUrl = value;
            }
        }

        public string SiteLogo
        {
            get
            {
                return this._SiteLogo;
            }
            set
            {
                this._SiteLogo = value;
            }
        }

        public string SiteCopyRight
        {
            get
            {
                return this._SiteCopyRight;
            }
            set
            {
                this._SiteCopyRight = value;
            }
        }

        public string SiteContact
        {
            get
            {
                return this._SiteContact;
            }
            set
            {
                this._SiteContact = value;
            }
        }

        public string SiteNotify
        {
            get
            {
                return this._SiteNotify;
            }
            set
            {
                this._SiteNotify = value;
            }
        }

        public string MapCode
        {
            get
            {
                return this._MapCode;
            }
            set
            {
                this._MapCode = value;
            }
        }

        public string StatisticsCode
        {
            get
            {
                return this._StatisticsCode;
            }
            set
            {
                this._StatisticsCode = value;
            }
        }

        public string ShareCode
        {
            get
            {
                return this._ShareCode;
            }
            set
            {
                this._ShareCode = value;
            }
        }

        public string OtherMeta
        {
            get
            {
                return this._OtherMeta;
            }
            set
            {
                this._OtherMeta = value;
            }
        }

        public string ContactUs
        {
            get
            {
                return this._ContactUs;
            }
            set
            {
                this._ContactUs = value;
            }
        }

        public bool IsSiteOpen
        {
            get
            {
                return this._IsSiteOpen;
            }
            set
            {
                this._IsSiteOpen = value;
            }
        }

        public string ClosedInfo
        {
            get
            {
                return this._ClosedInfo;
            }
            set
            {
                this._ClosedInfo = value;
            }
        }

        public int ShowPageSize
        {
            get
            {
                return this._ShowPageSize;
            }
            set
            {
                this._ShowPageSize = value;
            }
        }

        public bool AllowComment
        {
            get
            {
                return this._AllowComment;
            }
            set
            {
                this._AllowComment = value;
            }
        }

        public string SiteLogoPath
        {
            get
            {
                return this._SiteLogoPath;
            }
            set
            {
                this._SiteLogoPath = value;
            }
        }

        public string ArticleImagePath
        {
            get
            {
                return this._ArticleImagePath;
            }
            set
            {
                this._ArticleImagePath = value;
            }
        }

        public string ProductImagePath
        {
            get
            {
                return this._ProductImagePath;
            }
            set
            {
                this._ProductImagePath = value;
            }
        }

        public string ADImagePath
        {
            get
            {
                return this._ADImagePath;
            }
            set
            {
                this._ADImagePath = value;
            }
        }

        public int ImgSize_S_W
        {
            get
            {
                return this._ImgSize_S_W;
            }
            set
            {
                this._ImgSize_S_W = value;
            }
        }

        public int ImgSize_S_H
        {
            get
            {
                return this._ImgSize_S_H;
            }
            set
            {
                this._ImgSize_S_H = value;
            }
        }

        public int ImgSize_M_W
        {
            get
            {
                return this._ImgSize_M_W;
            }
            set
            {
                this._ImgSize_M_W = value;
            }
        }

        public int ImgSize_M_H
        {
            get
            {
                return this._ImgSize_M_H;
            }
            set
            {
                this._ImgSize_M_H = value;
            }
        }

        public string SiteTheme
        {
            get
            {
                return this._SiteTheme;
            }
            set
            {
                this._SiteTheme = value;
            }
        }

        public string WM_Text
        {
            get
            {
                return this._WM_Text;
            }
            set
            {
                this._WM_Text = value;
            }
        }

        public string WM_Font
        {
            get
            {
                return this._WM_Font;
            }
            set
            {
                this._WM_Font = value;
            }
        }

        public int WM_FontSize
        {
            get
            {
                return this._WM_FontSize;
            }
            set
            {
                this._WM_FontSize = value;
            }
        }

        public int WM_Bottom
        {
            get
            {
                return this._WM_Bottom;
            }
            set
            {
                this._WM_Bottom = value;
            }
        }

        public int WM_Right
        {
            get
            {
                return this._WM_Right;
            }
            set
            {
                this._WM_Right = value;
            }
        }

        public int WM_Rotate
        {
            get
            {
                return this._WM_Rotate;
            }
            set
            {
                this._WM_Rotate = value;
            }
        }

        public int WM_Size
        {
            get
            {
                return this._WM_Size;
            }
            set
            {
                this._WM_Size = value;
            }
        }

        public int WM_Alpha
        {
            get
            {
                return this._WM_Alpha;
            }
            set
            {
                this._WM_Alpha = value;
            }
        }

        public int WM_Red
        {
            get
            {
                return this._WM_Red;
            }
            set
            {
                this._WM_Red = value;
            }
        }

        public int WM_Green
        {
            get
            {
                return this._WM_Green;
            }
            set
            {
                this._WM_Green = value;
            }
        }

        public int WM_Blue
        {
            get
            {
                return this._WM_Blue;
            }
            set
            {
                this._WM_Blue = value;
            }
        }

        public bool WM_IsShow
        {
            get
            {
                return this._WM_IsShow;
            }
            set
            {
                this._WM_IsShow = value;
            }
        }

        public int WM_Show_W
        {
            get
            {
                return this._WM_Show_W;
            }
            set
            {
                this._WM_Show_W = value;
            }
        }

        public int WM_Show_H
        {
            get
            {
                return this._WM_Show_H;
            }
            set
            {
                this._WM_Show_H = value;
            }
        }

        public bool WM_Mode
        {
            get
            {
                return this._WM_Mode;
            }
            set
            {
                this._WM_Mode = value;
            }
        }

        public string WM_ImagePath
        {
            get
            {
                return this._WM_ImagePath;
            }
            set
            {
                this._WM_ImagePath = value;
            }
        }

        public bool SiteCounter
        {
            get
            {
                return this._SiteCounter;
            }
            set
            {
                this._SiteCounter = value;
            }
        }

        public int SiteFlow
        {
            get
            {
                return this._SiteFlow;
            }
            set
            {
                this._SiteFlow = value;
            }
        }

        public string UrlExtension
        {
            get
            {
                return this._UrlExtension;
            }
            set
            {
                this._UrlExtension = value;
            }
        }

        public bool IsBoundIP
        {
            get
            {
                return this._IsBoundIP;
            }
            set
            {
                this._IsBoundIP = value;
            }
        }

        public string BoundIP
        {
            get
            {
                return this._BoundIP;
            }
            set
            {
                this._BoundIP = value;
            }
        }

        public string Target
        {
            get
            {
                return this._Target;
            }
            set
            {
                this._Target = value;
            }
        }

        public int SearchType
        {
            get
            {
                return this._SearchType;
            }
            set
            {
                this._SearchType = value;
            }
        }

        public bool ShowService
        {
            get
            {
                return this._ShowService;
            }
            set
            {
                this._ShowService = value;
            }
        }

        public int ArticleTitleLength
        {
            get
            {
                return this._ArticleTitleLength;
            }
            set
            {
                this._ArticleTitleLength = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public void GetData(int indexId, string language)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Site_Config where IndexID=@IndexID and [Language]=@Language";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IndexID", OleDbType.Integer));
                oleDbCommand.Parameters["@IndexID"].Value = indexId;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = language;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Config = Convert.ToInt32(oleDbDataReader["pk_Config"].ToString());
                    this._IndexID = Convert.ToInt32(oleDbDataReader["IndexID"].ToString());
                    this._SiteName = oleDbDataReader["SiteName"].ToString();
                    this._SiteTitle = oleDbDataReader["SiteTitle"].ToString();
                    this._SiteKeyword = oleDbDataReader["SiteKeyword"].ToString();
                    this._SiteDescription = oleDbDataReader["SiteDescription"].ToString();
                    this._SiteContentType = oleDbDataReader["SiteContentType"].ToString();
                    this._SiteUrl = oleDbDataReader["SiteUrl"].ToString();
                    this._SiteLogo = oleDbDataReader["SiteLogo"].ToString();
                    this._SiteCopyRight = oleDbDataReader["SiteCopyRight"].ToString();
                    this._SiteContact = oleDbDataReader["SiteContact"].ToString();
                    this._SiteNotify = oleDbDataReader["SiteNotify"].ToString();
                    this._MapCode = oleDbDataReader["MapCode"].ToString();
                    this._StatisticsCode = oleDbDataReader["StatisticsCode"].ToString();
                    this._ShareCode = oleDbDataReader["ShareCode"].ToString();
                    this._OtherMeta = oleDbDataReader["OtherMeta"].ToString();
                    this._ContactUs = oleDbDataReader["ContactUs"].ToString();
                    this._IsSiteOpen = Convert.ToBoolean(oleDbDataReader["IsSiteOpen"].ToString());
                    this._ClosedInfo = oleDbDataReader["ClosedInfo"].ToString();
                    this._ShowPageSize = Convert.ToInt32(oleDbDataReader["ShowPageSize"].ToString());
                    this._AllowComment = Convert.ToBoolean(oleDbDataReader["AllowComment"].ToString());
                    this._SiteLogoPath = oleDbDataReader["SiteLogoPath"].ToString();
                    this._ArticleImagePath = oleDbDataReader["ArticleImagePath"].ToString();
                    this._ProductImagePath = oleDbDataReader["ProductImagePath"].ToString();
                    this._ADImagePath = oleDbDataReader["ADImagePath"].ToString();
                    this._ImgSize_S_W = Convert.ToInt32(oleDbDataReader["ImgSize_S_W"].ToString());
                    this._ImgSize_S_H = Convert.ToInt32(oleDbDataReader["ImgSize_S_H"].ToString());
                    this._ImgSize_M_W = Convert.ToInt32(oleDbDataReader["ImgSize_M_W"].ToString());
                    this._ImgSize_M_H = Convert.ToInt32(oleDbDataReader["ImgSize_M_H"].ToString());
                    this._SiteTheme = oleDbDataReader["SiteTheme"].ToString();
                    this._WM_Text = oleDbDataReader["WM_Text"].ToString();
                    this._WM_Font = oleDbDataReader["WM_Font"].ToString();
                    this._WM_FontSize = Convert.ToInt32(oleDbDataReader["WM_FontSize"].ToString());
                    this._WM_Bottom = Convert.ToInt32(oleDbDataReader["WM_Bottom"].ToString());
                    this._WM_Right = Convert.ToInt32(oleDbDataReader["WM_Right"].ToString());
                    this._WM_Rotate = Convert.ToInt32(oleDbDataReader["WM_Rotate"].ToString());
                    this._WM_Size = Convert.ToInt32(oleDbDataReader["WM_Size"].ToString());
                    this._WM_Alpha = Convert.ToInt32(oleDbDataReader["WM_Alpha"].ToString());
                    this._WM_Red = Convert.ToInt32(oleDbDataReader["WM_Red"].ToString());
                    this._WM_Green = Convert.ToInt32(oleDbDataReader["WM_Green"].ToString());
                    this._WM_Blue = Convert.ToInt32(oleDbDataReader["WM_Blue"].ToString());
                    this._WM_IsShow = Convert.ToBoolean(oleDbDataReader["WM_IsShow"].ToString());
                    this._WM_Show_W = Convert.ToInt32(oleDbDataReader["WM_Show_W"].ToString());
                    this._WM_Show_H = Convert.ToInt32(oleDbDataReader["WM_Show_H"].ToString());
                    this._WM_Mode = Convert.ToBoolean(oleDbDataReader["WM_Mode"].ToString());
                    this._WM_ImagePath = oleDbDataReader["WM_ImagePath"].ToString();
                    this._SiteCounter = Convert.ToBoolean(oleDbDataReader["SiteCounter"].ToString());
                    this._SiteFlow = Convert.ToInt32(oleDbDataReader["SiteFlow"].ToString());
                    this._UrlExtension = oleDbDataReader["UrlExtension"].ToString();
                    this._IsBoundIP = Convert.ToBoolean(oleDbDataReader["IsBoundIP"].ToString());
                    this._BoundIP = oleDbDataReader["BoundIP"].ToString();
                    this._Target = oleDbDataReader["Target"].ToString();
                    this._SearchType = Convert.ToInt32(oleDbDataReader["SearchType"].ToString());
                    this._ShowService = Convert.ToBoolean(oleDbDataReader["ShowService"].ToString());
                    this._ArticleTitleLength = Convert.ToInt32(oleDbDataReader["ArticleTitleLength"].ToString());
                    this._Language = oleDbDataReader["Language"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Config(IndexID,SiteName,SiteTitle,SiteKeyword,SiteDescription,SiteContentType,SiteUrl,SiteLogo,SiteCopyRight,SiteContact,SiteNotify,MapCode,StatisticsCode,ShareCode,OtherMeta,ContactUs,IsSiteOpen,ClosedInfo,ShowPageSize,AllowComment,SiteLogoPath,ArticleImagePath,ProductImagePath,ADImagePath,ImgSize_S_W,ImgSize_S_H,ImgSize_M_W,ImgSize_M_H,SiteTheme,WM_Text,WM_Font,WM_FontSize,WM_Bottom,WM_Right,WM_Rotate,WM_Size,WM_Alpha,WM_Red,WM_Green,WM_Blue,WM_IsShow,WM_Show_W,WM_Show_H,WM_Mode,WM_ImagePath,SiteCounter,SiteFlow,UrlExtension,IsBoundIP,BoundIP,Target,SearchType,ShowService,ArticleTitleLength,[Language]) values (@IndexID,@SiteName,@SiteTitle,@SiteKeyword,@SiteDescription,@SiteContentType,@SiteUrl,@SiteLogo,@SiteCopyRight,@SiteContact,@SiteNotify,@MapCode,@StatisticsCode,@ShareCode,@OtherMeta,@ContactUs,@IsSiteOpen,@ClosedInfo,@ShowPageSize,@AllowComment,@SiteLogoPath,@ArticleImagePath,@ProductImagePath,@ADImagePath,@ImgSize_S_W,@ImgSize_S_H,@ImgSize_M_W,@ImgSize_M_H,@SiteTheme,@WM_Text,@WM_Font,@WM_FontSize,@WM_Bottom,@WM_Right,@WM_Rotate,@WM_Size,@WM_Alpha,@WM_Red,@WM_Green,@WM_Blue,@WM_IsShow,@WM_Show_W,@WM_Show_H,@WM_Mode,@WM_ImagePath,@SiteCounter,@SiteFlow,@UrlExtension,@IsBoundIP,@BoundIP,@Target,@SearchType,@ShowService,@ArticleTitleLength,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IndexID", OleDbType.Integer));
                oleDbCommand.Parameters["@IndexID"].Value = this._IndexID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteName"].Value = this._SiteName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteTitle", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SiteTitle"].Value = this._SiteTitle;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteKeyword", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SiteKeyword"].Value = this._SiteKeyword;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteDescription", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SiteDescription"].Value = this._SiteDescription;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteContentType", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SiteContentType"].Value = this._SiteContentType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteUrl", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteUrl"].Value = this._SiteUrl;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteLogo", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteLogo"].Value = this._SiteLogo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteCopyRight", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@SiteCopyRight"].Value = this._SiteCopyRight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteContact", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteContact"].Value = this._SiteContact;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteNotify", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@SiteNotify"].Value = this._SiteNotify;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MapCode", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@MapCode"].Value = this._MapCode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatisticsCode", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@StatisticsCode"].Value = this._StatisticsCode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ShareCode", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@ShareCode"].Value = this._ShareCode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@OtherMeta", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@OtherMeta"].Value = this._OtherMeta;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ContactUs", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@ContactUs"].Value = this._ContactUs;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsSiteOpen", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsSiteOpen"].Value = this._IsSiteOpen;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ClosedInfo", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@ClosedInfo"].Value = this._ClosedInfo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ShowPageSize", OleDbType.Integer));
                oleDbCommand.Parameters["@ShowPageSize"].Value = this._ShowPageSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AllowComment", OleDbType.Boolean));
                oleDbCommand.Parameters["@AllowComment"].Value = this._AllowComment;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteLogoPath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteLogoPath"].Value = this._SiteLogoPath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ArticleImagePath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@ArticleImagePath"].Value = this._ArticleImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ProductImagePath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@ProductImagePath"].Value = this._ProductImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ADImagePath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@ADImagePath"].Value = this._ADImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_S_W", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_S_W"].Value = this._ImgSize_S_W;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_S_H", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_S_H"].Value = this._ImgSize_S_H;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_M_W", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_M_W"].Value = this._ImgSize_M_W;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_M_H", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_M_H"].Value = this._ImgSize_M_H;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteTheme", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteTheme"].Value = this._SiteTheme;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Text", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@WM_Text"].Value = this._WM_Text;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Font", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@WM_Font"].Value = this._WM_Font;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_FontSize", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_FontSize"].Value = this._WM_FontSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Bottom", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Bottom"].Value = this._WM_Bottom;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Right", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Right"].Value = this._WM_Right;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Rotate", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Rotate"].Value = this._WM_Rotate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Size", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Size"].Value = this._WM_Size;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Alpha", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Alpha"].Value = this._WM_Alpha;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Red", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Red"].Value = this._WM_Red;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Green", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Green"].Value = this._WM_Green;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Blue", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Blue"].Value = this._WM_Blue;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_IsShow", OleDbType.Boolean));
                oleDbCommand.Parameters["@WM_IsShow"].Value = this._WM_IsShow;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Show_W", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Show_W"].Value = this._WM_Show_W;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Show_H", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Show_H"].Value = this._WM_Show_H;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Mode", OleDbType.Boolean));
                oleDbCommand.Parameters["@WM_Mode"].Value = this._WM_Mode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_ImagePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@WM_ImagePath"].Value = this._WM_ImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteCounter", OleDbType.Boolean));
                oleDbCommand.Parameters["@SiteCounter"].Value = this._SiteCounter;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteFlow", OleDbType.Integer));
                oleDbCommand.Parameters["@SiteFlow"].Value = this._SiteFlow;
                oleDbCommand.Parameters.Add(new OleDbParameter("@UrlExtension", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@UrlExtension"].Value = this._UrlExtension;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsBoundIP", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsBoundIP"].Value = this._IsBoundIP;
                oleDbCommand.Parameters.Add(new OleDbParameter("@BoundIP", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@BoundIP"].Value = this._BoundIP;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SearchType", OleDbType.Integer));
                oleDbCommand.Parameters["@SearchType"].Value = this._SearchType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ShowService", OleDbType.Boolean));
                oleDbCommand.Parameters["@ShowService"].Value = this._ShowService;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ArticleTitleLength", OleDbType.Integer));
                oleDbCommand.Parameters["@ArticleTitleLength"].Value = this._ArticleTitleLength;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Site_Config set IndexID=@IndexID,SiteName=@SiteName,SiteTitle=@SiteTitle,SiteKeyword=@SiteKeyword,SiteDescription=@SiteDescription,SiteContentType=@SiteContentType,SiteUrl=@SiteUrl,SiteLogo=@SiteLogo,SiteCopyRight=@SiteCopyRight,SiteContact=@SiteContact,SiteNotify=@SiteNotify,MapCode=@MapCode,StatisticsCode=@StatisticsCode,ShareCode=@ShareCode,OtherMeta=@OtherMeta,ContactUs=@ContactUs,IsSiteOpen=@IsSiteOpen,ClosedInfo=@ClosedInfo,ShowPageSize=@ShowPageSize,AllowComment=@AllowComment,SiteLogoPath=@SiteLogoPath,ArticleImagePath=@ArticleImagePath,ProductImagePath=@ProductImagePath,ADImagePath=@ADImagePath,ImgSize_S_W=@ImgSize_S_W,ImgSize_S_H=@ImgSize_S_H,ImgSize_M_W=@ImgSize_M_W,ImgSize_M_H=@ImgSize_M_H,SiteTheme=@SiteTheme,WM_Text=@WM_Text,WM_Font=@WM_Font,WM_FontSize=@WM_FontSize,WM_Bottom=@WM_Bottom,WM_Right=@WM_Right,WM_Rotate=@WM_Rotate,WM_Size=@WM_Size,WM_Alpha=@WM_Alpha,WM_Red=@WM_Red,WM_Green=@WM_Green,WM_Blue=@WM_Blue,WM_IsShow=@WM_IsShow,WM_Show_W=@WM_Show_W,WM_Show_H=@WM_Show_H,WM_Mode=@WM_Mode,WM_ImagePath=@WM_ImagePath,SiteCounter=@SiteCounter,SiteFlow=@SiteFlow,UrlExtension=@UrlExtension,IsBoundIP=@IsBoundIP,BoundIP=@BoundIP,Target=@Target,SearchType=@SearchType,ShowService=@ShowService,ArticleTitleLength=@ArticleTitleLength,[Language]=@Language where pk_Config=@pk_Config";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IndexID", OleDbType.Integer));
                oleDbCommand.Parameters["@IndexID"].Value = this._IndexID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteName", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteName"].Value = this._SiteName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteTitle", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SiteTitle"].Value = this._SiteTitle;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteKeyword", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SiteKeyword"].Value = this._SiteKeyword;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteDescription", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SiteDescription"].Value = this._SiteDescription;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteContentType", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@SiteContentType"].Value = this._SiteContentType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteUrl", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteUrl"].Value = this._SiteUrl;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteLogo", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteLogo"].Value = this._SiteLogo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteCopyRight", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@SiteCopyRight"].Value = this._SiteCopyRight;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteContact", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteContact"].Value = this._SiteContact;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteNotify", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@SiteNotify"].Value = this._SiteNotify;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MapCode", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@MapCode"].Value = this._MapCode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StatisticsCode", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@StatisticsCode"].Value = this._StatisticsCode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ShareCode", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@ShareCode"].Value = this._ShareCode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@OtherMeta", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@OtherMeta"].Value = this._OtherMeta;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ContactUs", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@ContactUs"].Value = this._ContactUs;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsSiteOpen", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsSiteOpen"].Value = this._IsSiteOpen;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ClosedInfo", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@ClosedInfo"].Value = this._ClosedInfo;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ShowPageSize", OleDbType.Integer));
                oleDbCommand.Parameters["@ShowPageSize"].Value = this._ShowPageSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@AllowComment", OleDbType.Boolean));
                oleDbCommand.Parameters["@AllowComment"].Value = this._AllowComment;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteLogoPath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteLogoPath"].Value = this._SiteLogoPath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ArticleImagePath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@ArticleImagePath"].Value = this._ArticleImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ProductImagePath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@ProductImagePath"].Value = this._ProductImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ADImagePath", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@ADImagePath"].Value = this._ADImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_S_W", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_S_W"].Value = this._ImgSize_S_W;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_S_H", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_S_H"].Value = this._ImgSize_S_H;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_M_W", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_M_W"].Value = this._ImgSize_M_W;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImgSize_M_H", OleDbType.Integer));
                oleDbCommand.Parameters["@ImgSize_M_H"].Value = this._ImgSize_M_H;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteTheme", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@SiteTheme"].Value = this._SiteTheme;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Text", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@WM_Text"].Value = this._WM_Text;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Font", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@WM_Font"].Value = this._WM_Font;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_FontSize", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_FontSize"].Value = this._WM_FontSize;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Bottom", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Bottom"].Value = this._WM_Bottom;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Right", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Right"].Value = this._WM_Right;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Rotate", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Rotate"].Value = this._WM_Rotate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Size", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Size"].Value = this._WM_Size;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Alpha", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Alpha"].Value = this._WM_Alpha;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Red", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Red"].Value = this._WM_Red;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Green", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Green"].Value = this._WM_Green;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Blue", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Blue"].Value = this._WM_Blue;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_IsShow", OleDbType.Boolean));
                oleDbCommand.Parameters["@WM_IsShow"].Value = this._WM_IsShow;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Show_W", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Show_W"].Value = this._WM_Show_W;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Show_H", OleDbType.Integer));
                oleDbCommand.Parameters["@WM_Show_H"].Value = this._WM_Show_H;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_Mode", OleDbType.Boolean));
                oleDbCommand.Parameters["@WM_Mode"].Value = this._WM_Mode;
                oleDbCommand.Parameters.Add(new OleDbParameter("@WM_ImagePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@WM_ImagePath"].Value = this._WM_ImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteCounter", OleDbType.Boolean));
                oleDbCommand.Parameters["@SiteCounter"].Value = this._SiteCounter;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SiteFlow", OleDbType.Integer));
                oleDbCommand.Parameters["@SiteFlow"].Value = this._SiteFlow;
                oleDbCommand.Parameters.Add(new OleDbParameter("@UrlExtension", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@UrlExtension"].Value = this._UrlExtension;
                oleDbCommand.Parameters.Add(new OleDbParameter("@IsBoundIP", OleDbType.Boolean));
                oleDbCommand.Parameters["@IsBoundIP"].Value = this._IsBoundIP;
                oleDbCommand.Parameters.Add(new OleDbParameter("@BoundIP", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@BoundIP"].Value = this._BoundIP;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SearchType", OleDbType.Integer));
                oleDbCommand.Parameters["@SearchType"].Value = this._SearchType;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ShowService", OleDbType.Boolean));
                oleDbCommand.Parameters["@ShowService"].Value = this._ShowService;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ArticleTitleLength", OleDbType.Integer));
                oleDbCommand.Parameters["@ArticleTitleLength"].Value = this._ArticleTitleLength;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Config", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Config"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Config where pk_Config=" + id);
        }
    }

    public class Link
    {
        private int _pk_Link;

        private string _Title;

        private string _Description;

        private string _Url;

        private string _Target;

        private int _TypeID;

        private string _ImagePath;

        private int _SortID;

        private bool _Visible;

        private string _CreateDate;

        private int _CreateUserID;

        private string _ModifyDate;

        private int _ModifyUserID;

        private string _Language;

        public int pk_Link
        {
            get
            {
                return this._pk_Link;
            }
            set
            {
                this._pk_Link = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public string Target
        {
            get
            {
                return this._Target;
            }
            set
            {
                this._Target = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return this._ImagePath;
            }
            set
            {
                this._ImagePath = value;
            }
        }

        public int SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                this._SortID = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }

        public string CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this._CreateDate = value;
            }
        }

        public int CreateUserID
        {
            get
            {
                return this._CreateUserID;
            }
            set
            {
                this._CreateUserID = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public int ModifyUserID
        {
            get
            {
                return this._ModifyUserID;
            }
            set
            {
                this._ModifyUserID = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Site_Link where pk_Link=@pk_Link";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Link", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Link"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Link = Convert.ToInt32(oleDbDataReader["pk_Link"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._Description = oleDbDataReader["Description"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._Target = oleDbDataReader["Target"].ToString();
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._ImagePath = oleDbDataReader["ImagePath"].ToString();
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._Visible = Convert.ToBoolean(oleDbDataReader["Visible"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._CreateUserID = Convert.ToInt32(oleDbDataReader["CreateUserID"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    if (oleDbDataReader["ModifyUserID"] != DBNull.Value)
                    {
                        this._ModifyUserID = Convert.ToInt32(oleDbDataReader["ModifyUserID"].ToString());
                    }
                    else
                    {
                        this._ModifyUserID = 0;
                    }
                    this._Language = oleDbDataReader["Language"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Link(Title,Description,Url,Target,TypeID,ImagePath,SortID,Visible,CreateDate,CreateUserID,ModifyDate,ModifyUserID,[Language]) values (@Title,@Description,@Url,@Target,@TypeID,@ImagePath,@SortID,@Visible,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ImagePath"].Value = this._ImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Site_Link set Title=@Title,Description=@Description,Url=@Url,Target=@Target,TypeID=@TypeID,ImagePath=@ImagePath,SortID=@SortID,Visible=@Visible,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,[Language]=@Language where pk_Link=@pk_Link";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ImagePath", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@ImagePath"].Value = this._ImagePath;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Link", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Link"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Link where pk_Link=" + id);
        }
    }

    public class Log
    {
        private int _pk_Log;

        private string _IPAddress;

        private string _Url;

        private int _MemberID;

        private string _Browser;

        private int _TypeID;

        private string _LogTime;

        private string _Language;

        public int pk_Log
        {
            get
            {
                return this._pk_Log;
            }
            set
            {
                this._pk_Log = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return this._IPAddress;
            }
            set
            {
                this._IPAddress = value;
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public int MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                this._MemberID = value;
            }
        }

        public string Browser
        {
            get
            {
                return this._Browser;
            }
            set
            {
                this._Browser = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public string LogTime
        {
            get
            {
                return this._LogTime;
            }
            set
            {
                this._LogTime = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Site_Log where pk_Log=@pk_Log";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Log", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Log"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Log = Convert.ToInt32(oleDbDataReader["pk_Log"].ToString());
                    this._IPAddress = oleDbDataReader["IPAddress"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._MemberID = Convert.ToInt32(oleDbDataReader["MemberID"].ToString());
                    this._Browser = oleDbDataReader["Browser"].ToString();
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._LogTime = oleDbDataReader["LogTime"].ToString();
                    this._Language = oleDbDataReader["Language"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Log(IPAddress,Url,MemberID,Browser,TypeID,LogTime,[Language]) values (@IPAddress,@Url,@MemberID,@Browser,@TypeID,@LogTime,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@IPAddress"].Value = this._IPAddress;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MemberID", OleDbType.Integer));
                oleDbCommand.Parameters["@MemberID"].Value = this._MemberID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = this._Browser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogTime", OleDbType.Date));
                oleDbCommand.Parameters["@LogTime"].Value = this._LogTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public static void InsertData(string language)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Log(IPAddress,Url,MemberID,Browser,TypeID,LogTime,[Language]) values (@IPAddress,@Url,@MemberID,@Browser,@TypeID,@LogTime,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@IPAddress"].Value = IP.Get();
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Url"].Value = HttpContext.Current.Request.Path.ToString();
                oleDbCommand.Parameters.Add(new OleDbParameter("@MemberID", OleDbType.Integer));
                oleDbCommand.Parameters["@MemberID"].Value = 0;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = String.GetBrowserInfo();
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = 0;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogTime", OleDbType.Date));
                oleDbCommand.Parameters["@LogTime"].Value = DateTime.Now;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = language;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Site_Log set IPAddress=@IPAddress,Url=@Url,MemberID=@MemberID,Browser=@Browser,TypeID=@TypeID,LogTime=@LogTime,[Language]=@Language where pk_Log=@pk_Log";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@IPAddress", OleDbType.VarChar, 20));
                oleDbCommand.Parameters["@IPAddress"].Value = this._IPAddress;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 100));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MemberID", OleDbType.Integer));
                oleDbCommand.Parameters["@MemberID"].Value = this._MemberID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Browser", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Browser"].Value = this._Browser;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@LogTime", OleDbType.Date));
                oleDbCommand.Parameters["@LogTime"].Value = this._LogTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Log", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Log"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Log where pk_Log=" + id);
        }
    }

    public class Menu
    {
        private int _pk_Menu;

        private int _ParentID;

        private string _MenuName;

        private string _Url;

        private string _Icon;

        private int _SortID;

        private int _TypeID;

        private string _Target;

        private bool _Visible;

        private string _SEO_Title;

        private string _SEO_Keyword;

        private string _SEO_Description;

        private string _Language;

        public int pk_Menu
        {
            get
            {
                return this._pk_Menu;
            }
            set
            {
                this._pk_Menu = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this._ParentID = value;
            }
        }

        public string MenuName
        {
            get
            {
                return this._MenuName;
            }
            set
            {
                this._MenuName = value;
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public string Icon
        {
            get
            {
                return this._Icon;
            }
            set
            {
                this._Icon = value;
            }
        }

        public int SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                this._SortID = value;
            }
        }

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }

        public string Target
        {
            get
            {
                return this._Target;
            }
            set
            {
                this._Target = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }

        public string SEO_Title
        {
            get
            {
                return this._SEO_Title;
            }
            set
            {
                this._SEO_Title = value;
            }
        }

        public string SEO_Keyword
        {
            get
            {
                return this._SEO_Keyword;
            }
            set
            {
                this._SEO_Keyword = value;
            }
        }

        public string SEO_Description
        {
            get
            {
                return this._SEO_Description;
            }
            set
            {
                this._SEO_Description = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Site_Menu where pk_Menu=@pk_Menu";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Menu"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Menu = Convert.ToInt32(oleDbDataReader["pk_Menu"].ToString());
                    this._ParentID = Convert.ToInt32(oleDbDataReader["ParentID"].ToString());
                    this._MenuName = oleDbDataReader["MenuName"].ToString();
                    this._Url = oleDbDataReader["Url"].ToString();
                    this._Icon = oleDbDataReader["Icon"].ToString();
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._TypeID = Convert.ToInt32(oleDbDataReader["TypeID"].ToString());
                    this._Target = oleDbDataReader["Target"].ToString();
                    this._Visible = Convert.ToBoolean(oleDbDataReader["Visible"].ToString());
                    this._SEO_Title = oleDbDataReader["SEO_Title"].ToString();
                    this._SEO_Keyword = oleDbDataReader["SEO_Keyword"].ToString();
                    this._SEO_Description = oleDbDataReader["SEO_Description"].ToString();
                    this._Language = oleDbDataReader["Language"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Menu(ParentID,MenuName,Url,Icon,SortID,TypeID,Target,Visible,SEO_Title,SEO_Keyword,SEO_Description,[Language]) values (@ParentID,@MenuName,@Url,@Icon,@SortID,@TypeID,@Target,@Visible,@SEO_Title,@SEO_Keyword,@SEO_Description,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MenuName", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@MenuName"].Value = this._MenuName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Icon", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Icon"].Value = this._Icon;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SEO_Title", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SEO_Title"].Value = this._SEO_Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SEO_Keyword", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SEO_Keyword"].Value = this._SEO_Keyword;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SEO_Description", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@SEO_Description"].Value = this._SEO_Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Site_Menu set ParentID=@ParentID,MenuName=@MenuName,Url=@Url,Icon=@Icon,SortID=@SortID,TypeID=@TypeID,Target=@Target,Visible=@Visible,SEO_Title=@SEO_Title,SEO_Keyword=@SEO_Keyword,SEO_Description=@SEO_Description,[Language]=@Language where pk_Menu=@pk_Menu";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@ParentID", OleDbType.Integer));
                oleDbCommand.Parameters["@ParentID"].Value = this._ParentID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@MenuName", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@MenuName"].Value = this._MenuName;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.VarChar, 200));
                oleDbCommand.Parameters["@Url"].Value = this._Url;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Icon", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Icon"].Value = this._Icon;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@TypeID", OleDbType.Integer));
                oleDbCommand.Parameters["@TypeID"].Value = this._TypeID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Target", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Target"].Value = this._Target;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SEO_Title", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SEO_Title"].Value = this._SEO_Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SEO_Keyword", OleDbType.VarChar, 250));
                oleDbCommand.Parameters["@SEO_Keyword"].Value = this._SEO_Keyword;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SEO_Description", OleDbType.VarChar, 1000));
                oleDbCommand.Parameters["@SEO_Description"].Value = this._SEO_Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Menu", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Menu"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Menu where pk_Menu=" + id);
        }
    }

    public class Service
    {
        private int _pk_Service;

        private string _Title;

        private string _Description;

        private bool _Visible;

        private string _StartTime;

        private string _EndTime;

        private int _SortID;

        private string _CreateDate;

        private int _CreateUserID;

        private string _ModifyDate;

        private int _ModifyUserID;

        private string _Language;

        public int pk_Service
        {
            get
            {
                return this._pk_Service;
            }
            set
            {
                this._pk_Service = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
            }
        }

        public string StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                this._StartTime = value;
            }
        }

        public string EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                this._EndTime = value;
            }
        }

        public int SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                this._SortID = value;
            }
        }

        public string CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this._CreateDate = value;
            }
        }

        public int CreateUserID
        {
            get
            {
                return this._CreateUserID;
            }
            set
            {
                this._CreateUserID = value;
            }
        }

        public string ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this._ModifyDate = value;
            }
        }

        public int ModifyUserID
        {
            get
            {
                return this._ModifyUserID;
            }
            set
            {
                this._ModifyUserID = value;
            }
        }

        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this._Language = value;
            }
        }

        public void GetData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "select * from Site_Service where pk_Service=@pk_Service";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Service", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Service"].Value = id;
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    this._pk_Service = Convert.ToInt32(oleDbDataReader["pk_Service"].ToString());
                    this._Title = oleDbDataReader["Title"].ToString();
                    this._Description = oleDbDataReader["Description"].ToString();
                    this._Visible = Convert.ToBoolean(oleDbDataReader["Visible"].ToString());
                    this._StartTime = oleDbDataReader["StartTime"].ToString();
                    this._EndTime = oleDbDataReader["EndTime"].ToString();
                    this._SortID = Convert.ToInt32(oleDbDataReader["SortID"].ToString());
                    this._CreateDate = oleDbDataReader["CreateDate"].ToString();
                    this._CreateUserID = Convert.ToInt32(oleDbDataReader["CreateUserID"].ToString());
                    this._ModifyDate = oleDbDataReader["ModifyDate"].ToString();
                    if (oleDbDataReader["ModifyUserID"] != DBNull.Value)
                    {
                        this._ModifyUserID = Convert.ToInt32(oleDbDataReader["ModifyUserID"].ToString());
                    }
                    else
                    {
                        this._ModifyUserID = 0;
                    }
                    this._Language = oleDbDataReader["Language"].ToString();
                }
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public int InsertData()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            int result;
            try
            {
                oleDbConnection.Open();
                string cmdText = "insert into Site_Service(Title,Description,Visible,StartTime,EndTime,SortID,CreateDate,CreateUserID,ModifyDate,ModifyUserID,[Language]) values (@Title,@Description,@Visible,@StartTime,@EndTime,@SortID,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StartTime", OleDbType.Date));
                oleDbCommand.Parameters["@StartTime"].Value = this._StartTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@EndTime", OleDbType.Date));
                oleDbCommand.Parameters["@EndTime"].Value = this._EndTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select @@identity";
                result = Convert.ToInt32(oleDbCommand.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            finally
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public void UpdateData(int id)
        {
            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = "update Site_Service set Title=@Title,Description=@Description,Visible=@Visible,StartTime=@StartTime,EndTime=@EndTime,SortID=@SortID,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,[Language]=@Language where pk_Service=@pk_Service";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.VarChar, 50));
                oleDbCommand.Parameters["@Title"].Value = this._Title;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, -1));
                oleDbCommand.Parameters["@Description"].Value = this._Description;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Visible", OleDbType.Boolean));
                oleDbCommand.Parameters["@Visible"].Value = this._Visible;
                oleDbCommand.Parameters.Add(new OleDbParameter("@StartTime", OleDbType.Date));
                oleDbCommand.Parameters["@StartTime"].Value = this._StartTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@EndTime", OleDbType.Date));
                oleDbCommand.Parameters["@EndTime"].Value = this._EndTime;
                oleDbCommand.Parameters.Add(new OleDbParameter("@SortID", OleDbType.Integer));
                oleDbCommand.Parameters["@SortID"].Value = this._SortID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateDate", OleDbType.Date));
                oleDbCommand.Parameters["@CreateDate"].Value = this._CreateDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@CreateUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@CreateUserID"].Value = this._CreateUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyDate", OleDbType.Date));
                oleDbCommand.Parameters["@ModifyDate"].Value = this._ModifyDate;
                oleDbCommand.Parameters.Add(new OleDbParameter("@ModifyUserID", OleDbType.Integer));
                oleDbCommand.Parameters["@ModifyUserID"].Value = this._ModifyUserID;
                oleDbCommand.Parameters.Add(new OleDbParameter("@Language", OleDbType.VarChar, 10));
                oleDbCommand.Parameters["@Language"].Value = this._Language;
                oleDbCommand.Parameters.Add(new OleDbParameter("@pk_Service", OleDbType.Integer));
                oleDbCommand.Parameters["@pk_Service"].Value = id;
                oleDbCommand.ExecuteNonQuery();
            }
            finally
            {
                oleDbConnection.Close();
            }
        }

        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Site_Service where pk_Service=" + id);
        }
    }
}
