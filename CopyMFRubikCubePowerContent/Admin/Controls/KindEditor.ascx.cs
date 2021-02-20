using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.Controls
{
    public partial class KindEditor : System.Web.UI.UserControl
    {
        public int _Height;
        public string Text
        {
            get
            {
                return this.content1.Value;
            }
            set
            {
                this.content1.Value = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.content1.Attributes.Add("style", "width:100%;height:" + this._Height.ToString() + "px;visibility:hidden;");
        }
    }
}