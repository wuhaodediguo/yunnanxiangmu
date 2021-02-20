using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MojoCube.Web;
using MojoCube.Web.CurrentExpenses;

namespace CopyMFRubikCubePowerContent
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                GridBind2();

            }
        }

        void GridBind2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = "1";
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}