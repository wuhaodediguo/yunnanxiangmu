using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Controls
{
    public partial class Admin_Controls_CKEditor : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
                return this.CKEditor.Text;
            }
            set
            {
                this.CKEditor.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}