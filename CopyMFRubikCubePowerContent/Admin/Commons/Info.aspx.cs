using MojoCube.Api.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Commons
{
    public partial class Info : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a;
            if (base.Request.QueryString["type"] != null && (a = base.Request.QueryString["type"]) != null)
            {
                if (!(a == "1"))
                {
                    return;
                }
                this.lblInfo.Text = "对不起，您没有权限操作，请重新登录<br/><a href=\"../Login.aspx\">点击登录</a>";
            }
        }
    }
}