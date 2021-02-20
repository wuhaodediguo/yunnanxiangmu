using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MojoCube.Web.Logistics;
using Newtonsoft.Json;
using System.Web.Script.Services;
using Newtonsoft.Json.Converters;

namespace CopyMFRubikCubePowerContent
{
    /// <summary>
    /// Summary description for Logistics
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Logistics : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        
        [WebMethod]
        public string GetLogisticsInfo(string LogisticsNo)
        {
            IList<LogisticsList> result = new List<LogisticsList>();
            result = new LogisticsList().GetLogisticsList(LogisticsNo);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            string json_data = JsonConvert.SerializeObject(result, Formatting.Indented, timeFormat);//存放JSON的文字
            return json_data;
        }
    }
}
