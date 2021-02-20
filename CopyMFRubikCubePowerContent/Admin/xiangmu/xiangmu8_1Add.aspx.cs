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
    public partial class xiangmu8_1Add : System.Web.UI.Page
    {

        public string temp1
        {
            get { return Request.Params.Get("temp1"); }
        }
        public string temp2
        {
            get { return Request.Params.Get("temp2"); }
        }
        public string temp3
        {
            get { return Request.Params.Get("temp3"); }
        }
        public string temp4
        {
            get { return Request.Params.Get("temp4"); }
        }
        public string temp5
        {
            get { return Request.Params.Get("temp5"); }
        }
        public string temp6
        {
            get { return Request.Params.Get("temp6"); }
        }
        public string temp7
        {
            get { return Request.Params.Get("temp7"); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hd用户.Text = this.Session["FullName"].ToString();
            hd合同类型.Text = "1";
            if (!base.IsPostBack)
            {
                quanxian();
                //getDrop所属项目部();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox年度.Text = System.DateTime.Now.ToString("yyyy年");
                TextBox月份.Text = System.DateTime.Now.ToString("MM月");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                   

                }

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu3 where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {

                        TextBox年度.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox月份.Text = ds.Tables[0].Rows[0]["col2"].ToString();

                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col17"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col18"].ToString();
                        

                    }

                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
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
                    if (dataSource.Rows[11]["col2"].ToString() == "1" && dataSource.Rows[11]["col1"].ToString() == "div0041")
                    {
                        dd0041.Visible = true;
                    }
                    else
                    {
                        dd0041.Visible = false;
                    }
                    if (dataSource.Rows[12]["col2"].ToString() == "1" && dataSource.Rows[12]["col1"].ToString() == "div0042")
                    {
                        dd0042.Visible = true;
                    }
                    else
                    {
                        dd0042.Visible = false;
                    }
                    if (dataSource.Rows[13]["col2"].ToString() == "1" && dataSource.Rows[13]["col1"].ToString() == "div0043")
                    {
                        dd0043.Visible = true;
                    }
                    else
                    {
                        dd0043.Visible = false;
                    }
                    if (dataSource.Rows[14]["col2"].ToString() == "1" && dataSource.Rows[14]["col1"].ToString() == "div0044")
                    {
                        dd0044.Visible = true;
                    }
                    else
                    {
                        dd0044.Visible = false;
                    }
                    if (dataSource.Rows[15]["col2"].ToString() == "1" && dataSource.Rows[15]["col1"].ToString() == "div0045")
                    {
                        dd0045.Visible = true;
                    }
                    else
                    {
                        dd0045.Visible = false;
                    }
                    if (dataSource.Rows[16]["col2"].ToString() == "1" && dataSource.Rows[16]["col1"].ToString() == "div0046")
                    {
                        dd0046.Visible = true;
                    }
                    else
                    {
                        dd0046.Visible = false;
                    }

                }

            }
            else
            {
                div0041.Visible = false;
                div0045.Visible = false;
                div0042.Visible = false;
                div0043.Visible = false;
                div0044.Visible = false;
                div0046.Visible = false;

            }


        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
           
            if (this.TextBox年度.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写年度");
                return;
            }
            if (this.TextBox月份.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写月份");
                return;
            }


            xiangmu31List shichangList = new xiangmu31List();
            shichangList.col1 = TextBox年度.Text.Trim();
            shichangList.col2 = TextBox月份.Text.Trim();
            
            shichangList.col3 = TextBox创建人.Text.Trim();
            shichangList.col4 = TextBox创建日期.Text.Trim();
  
            if (this.ViewState["ID"] != null)
            {
                shichangList.ID = int.Parse(this.ViewState["ID"].ToString());

                shichangList.GetData(shichangList.ID);

                shichangList.col1 = TextBox年度.Text.Trim();
                shichangList.col2 = TextBox月份.Text.Trim();

                shichangList.col3 = TextBox创建人.Text.Trim();
                shichangList.col4 = TextBox创建日期.Text.Trim();

                shichangList.UpdateData(shichangList.ID);


            }
            else
            {
                shichangList.GetAllData2(shichangList.col1, shichangList.col2);
                if (shichangList.ID > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已存在年度，月份一样的数据，请修改再保存。");
                    return;
                }

                shichangList.InsertData();
            }

            base.Response.Redirect("xiangmu8_1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("xiangmu8_1.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "");
        }


    }

}