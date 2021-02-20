using System;
using System.Web;

namespace MojoCube.Api.Http
{
    public class Cookies
    {
        public static void Create(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
            HttpContext.Current.Response.Cookies[key].Value = HttpContext.Current.Session[key].ToString();
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddYears(1);
        }

        public static string GetValue(string key)
        {
            string result;
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                result = HttpContext.Current.Request.Cookies[key].Value;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
