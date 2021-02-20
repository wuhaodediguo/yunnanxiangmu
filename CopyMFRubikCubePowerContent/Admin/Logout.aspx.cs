using MojoCube.Web.User;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CopyMFRubikCubePowerContent.Admin
{
    public partial class Admin_Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MojoCube.Web.User.Login.SetLogout();
            this.Session.RemoveAll();
            base.Response.Redirect("Login.aspx");
        }
    }
}