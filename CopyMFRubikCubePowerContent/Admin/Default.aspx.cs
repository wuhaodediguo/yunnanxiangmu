using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin
{
    public partial class Admin_Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Response.Redirect("Dashboard/Default.aspx");
        }
    }
}