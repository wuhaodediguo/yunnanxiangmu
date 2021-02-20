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
    public partial class hetong33Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop所属项目部();
                hdNo2.Text = CreateNext();

                if (base.Request.QueryString["id"] != null)
                {
                    //GetDetail();
                    hdNo.Text = base.Request.QueryString["id"].ToString().Trim();
                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col17) as col17 from t_caiwu22 where 1=1 and col19 = '" + strdate + "' ";
            dataSource = oledbHelper.GetDataTable(sql);
            if (dataSource.Rows.Count > 0)
            {
                string number = dataSource.Rows[0][0].ToString();
                if (number != "" && number.Length > 8)
                {
                    number = dataSource.Rows[0][0].ToString().Substring(8, 4);
                    count = Convert.ToDecimal(number);
                }

            }
            return DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");


            if (dataSource.Rows.Count > 0)
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[6]["col2"].ToString() == "1" && dataSource.Rows[6]["col1"].ToString() == "div0031")
                    {
                        dd0031.Visible = true;
                    }
                    else
                    {
                        dd0031.Visible = false;
                    }
                    if (dataSource.Rows[7]["col2"].ToString() == "1" && dataSource.Rows[7]["col1"].ToString() == "div0032")
                    {
                        dd0032.Visible = true;
                    }
                    else
                    {
                        dd0032.Visible = false;
                    }
                    if (dataSource.Rows[8]["col2"].ToString() == "1" && dataSource.Rows[8]["col1"].ToString() == "div0033")
                    {
                        dd0033.Visible = true;
                    }
                    else
                    {
                        dd0033.Visible = false;
                    }
                    if (dataSource.Rows[9]["col2"].ToString() == "1" && dataSource.Rows[9]["col1"].ToString() == "div0034")
                    {
                        dd0034.Visible = true;
                    }
                    else
                    {
                        dd0034.Visible = false;
                    }

                }

            }
            else
            {
                div0031.Visible = false;
                div0032.Visible = false;
                div0033.Visible = false;
                div0034.Visible = false;

            }
        }

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("xiangmu");
            DataRow dr;

            //sql = "select ID,guige  from tb_guige where 1=1     ";
            sql = "select xiangmu  from User_List  where UserName = '" + this.Session["UserName"] + "'     ";
            dataSource = oledbHelper.GetDataTable(sql);
            string[] strxiangmu;
            if (dataSource.Rows.Count > 0)
            {
                strxiangmu = dataSource.Rows[0]["xiangmu"].ToString().Split(',');
                for (int k = 0; k < strxiangmu.Length; k++)
                {
                    if (strxiangmu[k].ToString().Trim() == "")
                    {
                        continue;
                    }
                    dr = dt.NewRow();
                    dr["xiangmu"] = strxiangmu[k];
                    dt.Rows.Add(dr);
                }

            }

            Drop所属项目部.DataTextField = "xiangmu";
            Drop所属项目部.DataValueField = "xiangmu";
            Drop所属项目部.DataSource = dt;
            Drop所属项目部.DataBind();
            Drop所属项目部.Items.Insert(0, "");

        }

        protected void getDrop所属项目经理()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '" + Drop所属项目部.Text + "'    ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop项目经理.DataTextField = "col2";
            Drop项目经理.DataValueField = "col2";
            Drop项目经理.DataSource = dataSource;
            Drop项目经理.DataBind();
            Drop项目经理.Items.Insert(0, "");

        }

        protected void Drop所属项目部SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drop所属项目部.Text != "")
            {
                getDrop所属项目经理();
            }
            else
            {
                OledbHelper oledbHelper = new OledbHelper();
                string sql = string.Empty;
                DataTable dataSource = new DataTable();
                sql = "select col2,guige  from t_xiangmujingli where 1=1 and guige = '00000000'    ";
                dataSource = oledbHelper.GetDataTable(sql);
                Drop项目经理.DataTextField = "col2";
                Drop项目经理.DataValueField = "col2";
                Drop项目经理.DataSource = dataSource;
                Drop项目经理.DataBind();
                Drop项目经理.Items.Insert(0, "");
            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写所属项目部");
                return;
            }
            if (this.Drop项目经理.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理");
                return;
            }
            if (this.TextBox项目经理金额.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写项目经理金额");
                return;
            }

            hetong33List List = new hetong33List();
            List.col1 = Drop所属项目部.Text.Trim();
            List.col2 = Drop项目经理.Text.Trim();
            List.col3 = TextBox项目经理金额.Text.Trim();
            List.col4 = base.Request.QueryString["idno"];
            List.col5 = base.Request.QueryString["idno3"];
            List.col6 = DateTime.Now.ToString("yyyyMMdd");
            List.col7 = base.Request.QueryString["id"];
            List.col8 = int.Parse(base.Request.QueryString["id"].ToString());

            List.InsertData();

            Response.Redirect("hetong3Add.aspx?id=" + base.Request.QueryString["id"] + "&idno3=" + base.Request.QueryString["idno3"], false);
           
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            Response.Redirect("hetong3Add.aspx?id=" + base.Request.QueryString["id"] + "&idno3=" + base.Request.QueryString["idno3"], false);
           
        }

     
    }
}