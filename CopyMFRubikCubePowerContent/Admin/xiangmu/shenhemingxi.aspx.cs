using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.IO;
using System.Data;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class shenhemingxi : System.Web.UI.Page
    {
        public static string RK_txtFormNo = "_txtFormNo";

        public static string querytxtFormNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                querytxtFormNo = base.Request.QueryString["txtFormNo"];

                DataSet ds1 = Sql.SqlQueryDS("select * from t_zhuangtai where col1= '" + querytxtFormNo + "' ");
                if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                {
                    ViewState["GridDataSource2"] = ds1.Tables[0];
                    this.GridView1.DataSource = ds1.Tables[0];
                    this.GridView1.DataBind();

                }


            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

    }
}