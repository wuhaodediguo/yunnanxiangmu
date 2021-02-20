using MojoCube.Web.User;
using System;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Commons
{
    public partial class Simple : System.Web.UI.MasterPage
    {
        public string skin = "";

        public string skinCss = "";
        protected void Page_Init(object sender, EventArgs e)
        {
            MojoCube.Web.User.Login.ChkLogin();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                List list = new List();
                list.GetData(int.Parse(base.Session["UserID"].ToString()));
                this.ViewState["Skin"] = list.Skin;
            }
            this.Page.Title = "MojoCube";
            this.skin = this.ViewState["Skin"].ToString();
            this.skinCss = string.Concat(new string[]
		{
			"<link rel=\"stylesheet\" href=\"../Skins/dist/css/skins/skin-",
			this.skin,
			".min.css\" /><link rel=\"stylesheet\" href=\"../Skins/plugins/iCheck/flat/",
			this.skin,
			".css\" />"
		});
        }
    }
}