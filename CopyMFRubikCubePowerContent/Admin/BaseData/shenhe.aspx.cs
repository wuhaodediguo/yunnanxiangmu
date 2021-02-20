using MojoCube.Web;
using MojoCube.Web.User;
using MojoCube.Web.CurrentExpenses;
using System;
using System.Web.UI.WebControls;
using System.Data;

namespace CopyMFRubikCubePowerContent.Admin.BaseData
{
    public partial class shenhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                getDrop人员();
                getList一级审核人员();
                getList二级审核人员();
                getList三级审核人员();
                getList四级审核人员();
                getList五级审核人员();
                getList六级审核人员();
                getListBox1();
                getListBox2();
                getListBox3();
                getListBox4();
                getListBox5();
                getListBox6();

                getListBox7();
                getListBox8();
                getListBox9();
                getListBox10();
                getListBox11();
                getListBox12();
                
            }
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();
            
            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "1";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe where col2='" + li.Value + "' and col1 = '1' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }
            
            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "2";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe where col2='" + li.Value + "' and col1 = '2' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave3_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "3";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe where col2='" + li.Value + "' and col1 = '3' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                if (dataSource.Rows[31]["col2"].ToString() == "1" && dataSource.Rows[31]["col1"].ToString() == "div0071")
                {
                    dd0071.Visible = true;
                }
                else
                {
                    dd0071.Visible = false;
                }
                if (dataSource.Rows[32]["col2"].ToString() == "1" && dataSource.Rows[32]["col1"].ToString() == "div0072")
                {
                    dd0072.Visible = true;
                }
                else
                {
                    dd0072.Visible = false;
                }
                if (dataSource.Rows[33]["col2"].ToString() == "1" && dataSource.Rows[33]["col1"].ToString() == "div0073")
                {
                    dd0073.Visible = true;
                }
                else
                {
                    dd0073.Visible = false;
                }
                if (dataSource.Rows[34]["col2"].ToString() == "1" && dataSource.Rows[34]["col1"].ToString() == "div0074")
                {
                    dd0074.Visible = true;
                }
                else
                {
                    dd0074.Visible = false;
                }
                if (dataSource.Rows[35]["col2"].ToString() == "1" && dataSource.Rows[35]["col1"].ToString() == "div0075")
                {
                    dd0075.Visible = true;
                }
                else
                {
                    dd0075.Visible = false;
                }
                if (dataSource.Rows[36]["col2"].ToString() == "1" && dataSource.Rows[36]["col1"].ToString() == "div0076")
                {
                    dd0076.Visible = true;
                }
                else
                {
                    dd0076.Visible = false;
                }
                if (dataSource.Rows[37]["col2"].ToString() == "1" && dataSource.Rows[37]["col1"].ToString() == "div0077")
                {
                    dd0077.Visible = true;
                }
                else
                {
                    dd0077.Visible = false;
                }

            }
            else
            {
                div0071.Visible = false;
                div0072.Visible = false;
                div0073.Visible = false;
                div0074.Visible = false;
                div0075.Visible = false;
                div0076.Visible = false;
                div0077.Visible = false;
            }
        }

        protected void btnSave4_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "4";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe where col2='" + li.Value + "' and col1 = '4' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave5_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "5";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe where col2='" + li.Value + "' and col1 = '5' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave6_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "6";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe where col2='" + li.Value + "' and col1 = '6' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel1_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in List一级审核人员.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("1", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel2_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in List二级审核人员.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("2", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel3_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in List三级审核人员.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("3", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel4_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in List四级审核人员.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("4", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel5_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in List五级审核人员.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("5", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel6_Click(object sender, EventArgs e)
        {

            shenheList list = new shenheList();

            foreach (ListItem li in List六级审核人员.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("6", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave11_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "1";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe2 where col2='" + li.Value + "' and col1 = '1' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave12_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "2";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe2 where col2='" + li.Value + "' and col1 = '2' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave13_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "3";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe2 where col2='" + li.Value + "' and col1 = '3' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave14_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "4";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe2 where col2='" + li.Value + "' and col1 = '4' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave15_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "5";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe2 where col2='" + li.Value + "' and col1 = '5' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave16_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "6";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe2 where col2='" + li.Value + "' and col1 = '6' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel11_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("1", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel12_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in ListBox2.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("2", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel13_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in ListBox3.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("3", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel14_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in ListBox4.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("4", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel15_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in ListBox5.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("5", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel16_Click(object sender, EventArgs e)
        {

            shenhe2List list = new shenhe2List();

            foreach (ListItem li in ListBox6.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("6", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }


        protected void getDrop人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select UserName  from User_List where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop人员.DataTextField = "UserName";
            Drop人员.DataValueField = "UserName";
            Drop人员.DataSource = dataSource;
            Drop人员.DataBind();

        }

        protected void getList一级审核人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe where 1 = 1  and col1 = '1'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            List一级审核人员.DataTextField = "col2";
            List一级审核人员.DataValueField = "col2";
            List一级审核人员.DataSource = dataSource;
            List一级审核人员.DataBind();

        }

        protected void getList二级审核人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe where 1 = 1  and col1 = '2'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            List二级审核人员.DataTextField = "col2";
            List二级审核人员.DataValueField = "col2";
            List二级审核人员.DataSource = dataSource;
            List二级审核人员.DataBind();

        }

        protected void getList三级审核人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe where 1 = 1  and col1 = '3'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            List三级审核人员.DataTextField = "col2";
            List三级审核人员.DataValueField = "col2";
            List三级审核人员.DataSource = dataSource;
            List三级审核人员.DataBind();

        }

        protected void getList四级审核人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe where 1 = 1  and col1 = '4'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            List四级审核人员.DataTextField = "col2";
            List四级审核人员.DataValueField = "col2";
            List四级审核人员.DataSource = dataSource;
            List四级审核人员.DataBind();

        }

        protected void getList五级审核人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe where 1 = 1  and col1 = '5'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            List五级审核人员.DataTextField = "col2";
            List五级审核人员.DataValueField = "col2";
            List五级审核人员.DataSource = dataSource;
            List五级审核人员.DataBind();

        }

        protected void getList六级审核人员()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe where 1 = 1  and col1 = '6'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            List六级审核人员.DataTextField = "col2";
            List六级审核人员.DataValueField = "col2";
            List六级审核人员.DataSource = dataSource;
            List六级审核人员.DataBind();

        }


        protected void getListBox1()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe2 where 1 = 1  and col1 = '1'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox1.DataTextField = "col2";
            ListBox1.DataValueField = "col2";
            ListBox1.DataSource = dataSource;
            ListBox1.DataBind();

        }

        protected void getListBox2()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe2 where 1 = 1  and col1 = '2'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox2.DataTextField = "col2";
            ListBox2.DataValueField = "col2";
            ListBox2.DataSource = dataSource;
            ListBox2.DataBind();

        }

        protected void getListBox3()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe2 where 1 = 1  and col1 = '3'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox3.DataTextField = "col2";
            ListBox3.DataValueField = "col2";
            ListBox3.DataSource = dataSource;
            ListBox3.DataBind();

        }

        protected void getListBox4()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe2 where 1 = 1  and col1 = '4'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox4.DataTextField = "col2";
            ListBox4.DataValueField = "col2";
            ListBox4.DataSource = dataSource;
            ListBox4.DataBind();

        }

        protected void getListBox5()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe2 where 1 = 1  and col1 = '5'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox5.DataTextField = "col2";
            ListBox5.DataValueField = "col2";
            ListBox5.DataSource = dataSource;
            ListBox5.DataBind();

        }

        protected void getListBox6()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe2 where 1 = 1  and col1 = '6'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox6.DataTextField = "col2";
            ListBox6.DataValueField = "col2";
            ListBox6.DataSource = dataSource;
            ListBox6.DataBind();

        }


        protected void getListBox7()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe3 where 1 = 1  and col1 = '1'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox7.DataTextField = "col2";
            ListBox7.DataValueField = "col2";
            ListBox7.DataSource = dataSource;
            ListBox7.DataBind();

        }

        protected void getListBox8()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe3 where 1 = 1  and col1 = '2'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox8.DataTextField = "col2";
            ListBox8.DataValueField = "col2";
            ListBox8.DataSource = dataSource;
            ListBox8.DataBind();

        }

        protected void getListBox9()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe3 where 1 = 1  and col1 = '3'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox9.DataTextField = "col2";
            ListBox9.DataValueField = "col2";
            ListBox9.DataSource = dataSource;
            ListBox9.DataBind();

        }

        protected void getListBox10()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe3 where 1 = 1  and col1 = '4'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox10.DataTextField = "col2";
            ListBox10.DataValueField = "col2";
            ListBox10.DataSource = dataSource;
            ListBox10.DataBind();

        }

        protected void getListBox11()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe3 where 1 = 1  and col1 = '5'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox11.DataTextField = "col2";
            ListBox11.DataValueField = "col2";
            ListBox11.DataSource = dataSource;
            ListBox11.DataBind();

        }

        protected void getListBox12()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select * from t_shenhe3 where 1 = 1  and col1 = '6'   ";
            dataSource = oledbHelper.GetDataTable(sql);
            ListBox12.DataTextField = "col2";
            ListBox12.DataValueField = "col2";
            ListBox12.DataSource = dataSource;
            ListBox12.DataBind();

        }


        protected void btnSave21_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "1";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe3 where col2='" + li.Value + "' and col1 = '1' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave22_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "2";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe3 where col2='" + li.Value + "' and col1 = '2' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave23_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "3";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe3 where col2='" + li.Value + "' and col1 = '3' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave24_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "4";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe3 where col2='" + li.Value + "' and col1 = '4' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave25_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "5";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe3 where col2='" + li.Value + "' and col1 = '5' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnSave26_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in Drop人员.Items)
            {
                if (li.Selected == true)
                {
                    list.col2 = li.Value;
                    list.col1 = "6";
                    DataSet ds = Sql.SqlQueryDS("select * from t_shenhe3 where col2='" + li.Value + "' and col1 = '6' ");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.InsertData();
                    }
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel21_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in ListBox7.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("1", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel22_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in ListBox8.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("2", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel23_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in ListBox9.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("3", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel24_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in ListBox10.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("4", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel25_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in ListBox11.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("5", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btndel26_Click(object sender, EventArgs e)
        {

            shenhe3List list = new shenhe3List();

            foreach (ListItem li in ListBox12.Items)
            {
                if (li.Selected == true)
                {
                    list.DeleteData("6", li.Value);
                }
            }

            base.Response.Redirect("shenhe.aspx?active=" + base.Request.QueryString["active"]);
        }



    }
}