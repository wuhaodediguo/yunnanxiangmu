using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using System.IO;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class xiangmu9 : System.Web.UI.Page
    {
        public string Request_temp1
        {
            get { return Request.Params.Get("temp1"); }
        }
        public string Request_temp2
        {
            get { return Request.Params.Get("temp2"); }
        }
        public string Request_temp3
        {
            get { return Request.Params.Get("temp3"); }
        }
        public string Request_temp4
        {
            get { return Request.Params.Get("temp4"); }
        }
        public string Request_temp5
        {
            get { return Request.Params.Get("temp5"); }
        }
        public string Request_temp6
        {
            get { return Request.Params.Get("temp6"); }
        }
        public string Request_temp7
        {
            get { return Request.Params.Get("temp7"); }
        }

        public string Request_temp8
        {
            get { return Request.Params.Get("temp8"); }
        }
        public string Request_temp9
        {
            get { return Request.Params.Get("temp9"); }
        }

        public int memoryPage = 0;
        Boolean chaxunflag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdcase.Text = base.Request.QueryString["caset"];
            if (base.Request.QueryString["caset"] == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli1();", true);
                lblbiaoti1.Text = "发票资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button7.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "2")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli2();", true);
                lblbiaoti1.Text = "采购订单资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button11.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "3")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli3();", true);
                lblbiaoti1.Text = "结算资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button15.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "4")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli4();", true);
                lblbiaoti1.Text = "审计资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button19.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "5")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli5();", true);
                lblbiaoti1.Text = "竣工资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button23.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "11")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli1();", true);
                lblbiaoti1.Text = "发票资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button7.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
                //Button8.BackColor = System.Drawing.Color.Transparent;
                //Button9.BackColor = System.Drawing.Color.Transparent;
                //Button10.BackColor = System.Drawing.Color.Transparent;
            }
            else if (base.Request.QueryString["caset"] == "12")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli1();", true);
                lblbiaoti1.Text = "发票资料已上传明细列表";
                div资料上传.Visible = false;
                div审核.Visible = false;
                //Button7.BackColor = System.Drawing.Color.Transparent;
                Button8.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
                //Button9.BackColor = System.Drawing.Color.Transparent;
                //Button10.BackColor = System.Drawing.Color.Transparent;
            }
            else if (base.Request.QueryString["caset"] == "13")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli1();", true);
                lblbiaoti1.Text = "发票资料审核管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                Button9.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "14")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli1();", true);
                lblbiaoti1.Text = "发票资料完成管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                div审核.Visible = false;
                div资料退回.Visible = true;

                Button10.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "21")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli2();", true);
                lblbiaoti1.Text = "采购订单资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button11.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);

            }
            else if (base.Request.QueryString["caset"] == "22")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli2();", true);
                lblbiaoti1.Text = "采购订单资料已上传明细列表";
                div资料上传.Visible = false;
                div审核.Visible = false;
                Button12.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "23")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli2();", true);
                lblbiaoti1.Text = "采购订单资料审核管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                Button13.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "24")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli2();", true);
                lblbiaoti1.Text = "采购订单资料完成管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                div审核.Visible = false;
                div资料退回.Visible = true;

                Button14.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "31")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli3();", true);
                lblbiaoti1.Text = "结算资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button15.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);

            }
            else if (base.Request.QueryString["caset"] == "32")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli3();", true);
                lblbiaoti1.Text = "结算资料已上传明细列表";
                div资料上传.Visible = false;
                div审核.Visible = false;
                Button16.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "33")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli3();", true);
                lblbiaoti1.Text = "结算资料审核管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                Button17.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "34")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli3();", true);
                lblbiaoti1.Text = "结算资料完成管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                div审核.Visible = false;
                div资料退回.Visible = true;

                Button18.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "41")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli4();", true);
                lblbiaoti1.Text = "审计资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button19.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);

            }
            else if (base.Request.QueryString["caset"] == "42")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli4();", true);
                lblbiaoti1.Text = "审计资料已上传明细列表";
                div资料上传.Visible = false;
                div审核.Visible = false;
                Button20.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "43")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli4();", true);
                lblbiaoti1.Text = "审计资料审核管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                Button21.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "44")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli4();", true);
                lblbiaoti1.Text = "审计资料完成管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                div审核.Visible = false;
                div资料退回.Visible = true;

                Button22.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "51")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli5();", true);
                lblbiaoti1.Text = "竣工资料未上传明细列表";
                div资料重提.Visible = false;
                div审核.Visible = false;
                Button23.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);

            }
            else if (base.Request.QueryString["caset"] == "52")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli5();", true);
                lblbiaoti1.Text = "竣工资料已上传明细列表";
                div资料上传.Visible = false;
                div审核.Visible = false;
                Button24.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "53")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli5();", true);
                lblbiaoti1.Text = "竣工资料审核管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                Button25.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            else if (base.Request.QueryString["caset"] == "54")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clickPage", "toli5();", true);
                lblbiaoti1.Text = "竣工资料完成管理列表";
                div资料重提.Visible = false;
                div资料上传.Visible = false;
                div审核.Visible = false;
                div资料退回.Visible = true;

                Button26.BackColor = System.Drawing.Color.FromArgb(255, 254, 90, 81);
            }
            if (!base.IsPostBack)
            {
                quanxian();
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;

                if (Request_temp1 != null && !string.Empty.Equals(Request_temp1))
                {
                    this.txtcol1.Text = Request_temp1;
                }
                if (Request_temp2 != null && !string.Empty.Equals(Request_temp2))
                {
                    this.txtcol2.Text = Request_temp2;
                }
                if (Request_temp3 != null && !string.Empty.Equals(Request_temp3))
                {
                    this.txtcol3.Text = Request_temp3;
                }
                if (Request_temp4 != null && !string.Empty.Equals(Request_temp4))
                {
                    this.txtcol4.Text = Request_temp4;
                }
                if (Request_temp5 != null && !string.Empty.Equals(Request_temp5))
                {
                    this.txtcol5.Text = Request_temp5;
                }
                if (Request_temp6 != null && !string.Empty.Equals(Request_temp6))
                {
                    this.txtcol6.Text = Request_temp6;
                }
                if (Request_temp7 != null && !string.Empty.Equals(Request_temp7))
                {

                    memoryPage = int.Parse(Request_temp7);
                }

                if (Request_temp8 != null && !string.Empty.Equals(Request_temp8))
                {
                    this.txtcol7.Text = Request_temp8;
                }
                if (Request_temp9 != null && !string.Empty.Equals(Request_temp9))
                {
                    this.Dropcol8.Text = Request_temp9;
                }

               

                this.GridBind();

            }
            else
            {
                AlertDiv.InnerHtml = "";
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

            hdtemp.Text = "";
            DataTable dataSource2 = oledbHelper.GetDataTable("select xiangmu from User_List where UserName = '" + this.Session["UserName"] + "'  ");
            if (dataSource2.Rows.Count > 0)
            {
                string[] tep = dataSource2.Rows[0][0].ToString().Split(',');
                for (int k = 0; k < tep.Length; k++)
                {
                    if (tep[k].ToString() == "")
                    {
                        continue;
                    }
                    hdtemp.Text += "'" + tep[k].ToString() + "'" + ",";
                }
                if (hdtemp.Text != null && hdtemp.Text.EndsWith(","))
                    hdtemp.Text = hdtemp.Text.Substring(0, hdtemp.Text.Length - 1);

            }


        }

        protected void btn11_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "11";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn12_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "12";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn13_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "13";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn14_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "14";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn21_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "21";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn22_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "22";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn23_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "23";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn24_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "24";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn31_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "31";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn32_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "32";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn33_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "33";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn34_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "34";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn41_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "41";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn42_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "42";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn43_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "43";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn44_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "44";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn51_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "51";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn52_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "52";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn53_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "53";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void btn54_Click(object sender, EventArgs e)
        {
            string temp1 = txtcol1.Text.Trim();
            string temp2 = txtcol2.Text.Trim();
            string temp3 = txtcol3.Text.Trim();
            string temp4 = txtcol4.Text.Trim();
            string temp5 = txtcol5.Text.Trim();
            string temp6 = txtcol6.Text.Trim();

            string temp7 = this.ListPager.CurrentPageIndex.ToString();
            string temp8 = txtcol7.Text.Trim();
            string temp9 = Dropcol8.Text.Trim();
            string caset = "54";

            Response.Redirect("xiangmu9.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "", false);
            
        }

        protected void ListPager_PageChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void GridBind()
        {
            AdminPager adminPager = new AdminPager(this.ListPager);
            adminPager.PageSize = MojoCube.Web.String.PageSize();
            adminPager.ConnStr = Connection.ConnString();
            //adminPager.TableName = "(select t_caiwu22.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_caiwu22 inner join t_hetong on  t_caiwu22.col1 =  t_hetong.col1 )";
            //adminPager.strGetFields = "*";
            //ArrayList arrayList = new ArrayList();
            //StringBuilder where = new StringBuilder();
            //where.Append(" where 1=1 and col32='1' and (col38 <>'1' or col38 = '' or col38 is null) and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
            //string sql = "select * from (select t_caiwu22.*,t_hetong.col8 as newcol8,t_hetong.col23 as newcol23,t_hetong.col26 as newcol26,t_hetong.col31 as newcol31,t_hetong.col34 as newcol34,t_hetong.col37 as newcol37 from t_caiwu22 inner join t_hetong on  t_caiwu22.col1 =  t_hetong.col1 ) where 1= 1  and col32='1' and (col38 <>'1' or col38 = '' or col38 is null) and (col49 <> '合作合同' or col49 = '' or col49 is null) ";

            adminPager.TableName = "(SELECT distinct viewxiangmu9.* FROM viewxiangmu9 ,t_caiwu22,t_caiwu2 where viewxiangmu9.col5 = t_caiwu22.col5 and viewxiangmu9.col8 = t_caiwu22.col8 and viewxiangmu9.col9 = t_caiwu22.col9 and viewxiangmu9.col31 = t_caiwu22.col47 and CStr(t_caiwu2.ID) =  t_caiwu22.col20  and t_caiwu2.col55 like '%确定开票%')";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1  ");
            string sql = @"SELECT distinct viewxiangmu9.* FROM viewxiangmu9 ,t_caiwu22,t_caiwu2 
                            where viewxiangmu9.col5 = t_caiwu22.col5
                            and viewxiangmu9.col8 = t_caiwu22.col8
                            and viewxiangmu9.col9 = t_caiwu22.col9
                            and viewxiangmu9.col31 = t_caiwu22.col47
                            and CStr(t_caiwu2.ID) =  t_caiwu22.col20    
                            and t_caiwu2.col55 like '%确定开票%'    ";


            if (this.txtcol1.Text.Trim() != "")
            {
                where.Append(" and viewxiangmu9.col4 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol1.Text.Trim()));
                sql += " and viewxiangmu9.col4 like '%" + this.txtcol1.Text.Trim() + "%' ";
            }
            if (this.txtcol2.Text.Trim() != "")
            {
                where.Append(" and viewxiangmu9.col5 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol2.Text.Trim()));
                sql += " and viewxiangmu9.col5 like '%" + this.txtcol2.Text.Trim() + "%' ";
            }
            if (this.txtcol3.Text.Trim() != "")
            {
                where.Append(" and viewxiangmu9.col1 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol3.Text.Trim()));
                sql += " and viewxiangmu9.col1 like '%" + this.txtcol3.Text.Trim() + "%' ";
            }
            if (this.txtcol4.Text.Trim() != "")
            {
                where.Append(" and viewxiangmu9.col8 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol4.Text.Trim()));
                sql += " and viewxiangmu9.col8 = '%" + this.txtcol4.Text.Trim() + "%' ";
            }
            if (this.txtcol5.Text.Trim() != "")
            {
                where.Append(" and viewxiangmu9.col7 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol5.Text.Trim()));
                sql += " and viewxiangmu9.col7 = '%" + this.txtcol5.Text.Trim() + "%' ";
            }
            if (this.txtcol6.Text.Trim() != "")
            {
                where.Append(" and viewxiangmu9.col9 like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txtcol6.Text.Trim()));
                sql += " and viewxiangmu9.col9 = '%" + this.txtcol6.Text.Trim() + "%' ";
            }

            if (base.Request.QueryString["caset"] == "1")
            {
                where.Append(" and (((viewxiangmu9.col22 is null or viewxiangmu9.col22 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ");
                sql += " and (((viewxiangmu9.col22 is null or viewxiangmu9.col22 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ";
            }
            else if (base.Request.QueryString["caset"] == "2")
            {
                where.Append(" and (((viewxiangmu9.col23 is null or viewxiangmu9.col23 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ");
                sql += " and (((viewxiangmu9.col23 is null or viewxiangmu9.col23 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ";
            }
            else if (base.Request.QueryString["caset"] == "3")
            {
                where.Append(" and (((viewxiangmu9.col24 is null or viewxiangmu9.col24 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ");
                sql += " and (((viewxiangmu9.col24 is null or viewxiangmu9.col24 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ";
            }
            else if (base.Request.QueryString["caset"] == "4")
            {
                where.Append(" and (((viewxiangmu9.col25 is null or viewxiangmu9.col25 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ");
                sql += " and (((viewxiangmu9.col25 is null or viewxiangmu9.col25 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ";
            }
            else if (base.Request.QueryString["caset"] == "5")
            {
                where.Append(" and (((viewxiangmu9.col26 is null or viewxiangmu9.col26 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ");
                sql += " and (((viewxiangmu9.col26 is null or viewxiangmu9.col26 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or viewxiangmu9.col28 = '1') ";
            }
            else if (base.Request.QueryString["caset"] == "11")
            {
                where.Append(" and (((viewxiangmu9.col22 is null or viewxiangmu9.col22 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ");
                sql += " and (((viewxiangmu9.col22 is null or viewxiangmu9.col22 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ";
            }
            else if (base.Request.QueryString["caset"] == "12")
            {
                where.Append(" and (viewxiangmu9.col22 is not null and viewxiangmu9.col22 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col22 is not null and viewxiangmu9.col22 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "13")
            {
                where.Append(" and (viewxiangmu9.col22 is not null and viewxiangmu9.col22 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col22 is not null and viewxiangmu9.col22 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "14")
            {
                where.Append(" and (viewxiangmu9.col22 is not null and viewxiangmu9.col22 <> '') and (viewxiangmu9.col27 = '1') ");
                sql += " and (viewxiangmu9.col22 is not null and viewxiangmu9.col22 <> '') and (viewxiangmu9.col27 = '1')  ";
            }
            else if (base.Request.QueryString["caset"] == "21")
            {
                where.Append(" and (((viewxiangmu9.col23 is null or viewxiangmu9.col23 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ");
                sql += " and (((viewxiangmu9.col23 is null or viewxiangmu9.col23 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ";
            }
            else if (base.Request.QueryString["caset"] == "22")
            {
                where.Append(" and (viewxiangmu9.col23 is not null and viewxiangmu9.col23 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')  ");
                sql += " and (viewxiangmu9.col23 is not null and viewxiangmu9.col23 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')  ";
            }
            else if (base.Request.QueryString["caset"] == "23")
            {
                where.Append(" and (viewxiangmu9.col23 is not null and viewxiangmu9.col23 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col23 is not null and viewxiangmu9.col23 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "24")
            {
                where.Append(" and (viewxiangmu9.col23 is not null and viewxiangmu9.col23 <> '') and (viewxiangmu9.col27 = '1') and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col23 is not null and viewxiangmu9.col23 <> '') and (viewxiangmu9.col27 = '1') and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "31")
            {
                where.Append(" and (((viewxiangmu9.col24 is null or viewxiangmu9.col24 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ");
                sql += " and (((viewxiangmu9.col24 is null or viewxiangmu9.col24 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ";
            }
            else if (base.Request.QueryString["caset"] == "32")
            {
                where.Append(" and (viewxiangmu9.col24 is not null and viewxiangmu9.col24 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1'  ");
                sql += " and (viewxiangmu9.col24 is not null and viewxiangmu9.col24 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "33")
            {
                where.Append(" and (viewxiangmu9.col24 is not null and viewxiangmu9.col24 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col24 is not null and viewxiangmu9.col24 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "34")
            {
                where.Append(" and (viewxiangmu9.col24 is not null and viewxiangmu9.col24 <> '') and (viewxiangmu9.col27 = '1') ");
                sql += " and (viewxiangmu9.col24 is not null and viewxiangmu9.col24 <> '') and (viewxiangmu9.col27 = '1')  ";
            }
            else if (base.Request.QueryString["caset"] == "41")
            {
                where.Append(" and (((viewxiangmu9.col25 is null or viewxiangmu9.col25 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ");
                sql += " and (((viewxiangmu9.col25 is null or viewxiangmu9.col25 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ";
            }
            else if (base.Request.QueryString["caset"] == "42")
            {
                where.Append(" and (viewxiangmu9.col25 is not null and viewxiangmu9.col25 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col25 is not null and viewxiangmu9.col25 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "43")
            {
                where.Append(" and (viewxiangmu9.col25 is not null and viewxiangmu9.col25 <> '') and viewxiangmu9.col27 <> '1'and  viewxiangmu9.col28 <> '1'  ");
                sql += " and (viewxiangmu9.col25 is not null and viewxiangmu9.col25 <> '')  and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1' ";
            }
            else if (base.Request.QueryString["caset"] == "44")
            {
                where.Append(" and (viewxiangmu9.col25 is not null and viewxiangmu9.col25 <> '') and (viewxiangmu9.col27 = '1') ");
                sql += " and (viewxiangmu9.col25 is not null and viewxiangmu9.col25 <> '') and (viewxiangmu9.col27 = '1')  ";
            }
            else if (base.Request.QueryString["caset"] == "51")
            {
                where.Append(" and (((viewxiangmu9.col26 is null or viewxiangmu9.col26 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ");
                sql += " and (((viewxiangmu9.col26 is null or viewxiangmu9.col26 = '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '')) or (viewxiangmu9.col28 = '1' and viewxiangmu9.col27 <> '1')) ";
            }
            else if (base.Request.QueryString["caset"] == "52")
            {
                where.Append(" and (viewxiangmu9.col26 is not null and viewxiangmu9.col26 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1'  ");
                sql += " and (viewxiangmu9.col26 is not null and viewxiangmu9.col26 <> '') and (viewxiangmu9.col27 is null or viewxiangmu9.col27 = '') and  viewxiangmu9.col28 <> '1'  ";
            }
            else if (base.Request.QueryString["caset"] == "53")
            {
                where.Append(" and (viewxiangmu9.col26 is not null and viewxiangmu9.col26 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1' ");
                sql += " and (viewxiangmu9.col26 is not null and viewxiangmu9.col26 <> '') and viewxiangmu9.col27 <> '1' and  viewxiangmu9.col28 <> '1' ";
            }
            else if (base.Request.QueryString["caset"] == "54")
            {
                where.Append(" and (viewxiangmu9.col26 is not null and viewxiangmu9.col26 <> '') and (viewxiangmu9.col27 = '1') ");
                sql += " and (viewxiangmu9.col26 is not null and viewxiangmu9.col26 <> '') and (viewxiangmu9.col27 = '1')  ";
            }
            //if (this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and col41 = '" + this.Session["FullName"].ToString() + "' ");
            //    sql += " and col41 = '" + this.Session["FullName"].ToString() + "' ";
            //}
            //if (hdtemp.Text != null && (this.Session["RoleValue"].ToString() != "1" || this.Session["RoleValue"].ToString() != "7"))
            //{
            //    where.Append(" and (viewxiangmu9.col19 = '" + this.Session["FullName"].ToString() + "' or viewxiangmu9.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (viewxiangmu9.col19 = '" + this.Session["FullName"].ToString() + "' or viewxiangmu9.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            //}
            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (viewxiangmu9.col19 = '" + this.Session["FullName"].ToString() + "' or viewxiangmu9.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (viewxiangmu9.col19 = '" + this.Session["FullName"].ToString() + "' or viewxiangmu9.col6 in (" + hdtemp.Text + ") or newcol8 in (" + hdtemp.Text + ") or newcol23 in (" + hdtemp.Text + ") or newcol26 in (" + hdtemp.Text + ") or newcol31 in (" + hdtemp.Text + ") or newcol34 in (" + hdtemp.Text + ") or newcol37 in (" + hdtemp.Text + ") ) ";

            //}

            //if (hdtemp.Text != null && this.Session["RoleValue"].ToString() != "1")
            //{
            //    where.Append(" and (col41 = '" + this.Session["FullName"].ToString() + "' or col6 in (" + hdtemp.Text + ") )  ");
            //    sql += " and (col41 = '" + this.Session["FullName"].ToString() + "' or col6 in (" + hdtemp.Text + ") ) ";

            //}

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            //Decimal d1 = 0;
            //Decimal d2 = 0;
            //for (int i = 0; i < dtAll.Rows.Count; i++)
            //{
            //    d1 += dtAll.Rows[i]["col14"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col14"].ToString());
            //    d2 += dtAll.Rows[i]["col46"].ToString() == "" ? 0 : Convert.ToDecimal(dtAll.Rows[i]["col46"].ToString());
            //}
            //Label合计1.Text = "结算金额含税总计: " + (d1.ToString("F2") == "0.00" ? "0" : d1.ToString("F2"));
            //Label合计2.Text = "审定金额含税总计: " + (d2.ToString("F2") == "0.00" ? "0" : d2.ToString("F2"));

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable(memoryPage);
            this.GridView1.DataBind();
        }

        protected void btn查询_Click(object sender, EventArgs e)
        {
            chaxunflag = true;
            this.GridBind();
        }

        protected void btn资料上传_Click(object sender, EventArgs e)
        {
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();
                    string temp8 = txtcol7.Text.Trim();
                    string temp9 = Dropcol8.Text.Trim();
                    string caset = base.Request.QueryString["caset"];

                    Response.Redirect("xiangmu9Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "&chakanmodel=chakan2", false);
                    break;
                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }

        }

        protected void btn资料重提_Click(object sender, EventArgs e)
        {
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();
                    string temp8 = txtcol7.Text.Trim();
                    string temp9 = Dropcol8.Text.Trim();
                    string caset = base.Request.QueryString["caset"];

                    Response.Redirect("xiangmu9Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "&chakanmodel=chakan2", false);
                    break;
                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }

        }

        protected void btn审核_Click(object sender, EventArgs e)
        {
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();
                    string temp8 = txtcol7.Text.Trim();
                    string temp9 = Dropcol8.Text.Trim();
                    string caset = base.Request.QueryString["caset"];

                    Response.Redirect("xiangmu9Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "&chakanmodel=shenhe", false);
                    break;
                }
                //if (ifTick)
                //{
                //    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                //    formNoList.Add(tickedFormNo);

                //    string temp1 = txtcol1.Text.Trim();
                //    string temp2 = txtcol2.Text.Trim();
                //    string temp3 = txtcol3.Text.Trim();
                //    string temp4 = txtcol4.Text.Trim();
                //    string temp5 = txtcol5.Text.Trim();
                //    string temp6 = txtcol6.Text.Trim();

                //    string temp7 = this.ListPager.CurrentPageIndex.ToString();
                //    string temp8 = txtcol7.Text.Trim();
                //    string temp9 = Dropcol8.Text.Trim();
                //    string caset = base.Request.QueryString["caset"];

                //    caiwu8List List = new caiwu8List();
                //    List.GetData(int.Parse(tickedFormNo));
                //    //txtquanxian = List.col33 == "" ? "0" : List.col33;
                //    //string fullname = this.Session["FullName"].ToString();

                //    //var Pdata = "<script> var  aaa ='"
                //    //     + 1 + "';fullname ='"
                //    //     + fullname + "';tickedFormNo ="
                //    //     + tickedFormNo + ";txtquanxian ="
                //    //     + txtquanxian + ";LinkPrintPage();</script>";

                //    //ClientScript.RegisterStartupScript(this.GetType(), "a", Pdata);//將結果傳到Cient Site.


                //}
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }

        }


        protected void btn查看_Click(object sender, EventArgs e)
        {
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);

                    string temp1 = txtcol1.Text.Trim();
                    string temp2 = txtcol2.Text.Trim();
                    string temp3 = txtcol3.Text.Trim();
                    string temp4 = txtcol4.Text.Trim();
                    string temp5 = txtcol5.Text.Trim();
                    string temp6 = txtcol6.Text.Trim();

                    string temp7 = this.ListPager.CurrentPageIndex.ToString();
                    string temp8 = txtcol7.Text.Trim();
                    string temp9 = Dropcol8.Text.Trim();
                    string caset = base.Request.QueryString["caset"];

                    Response.Redirect("xiangmu9Add.aspx?id=" + tickedFormNo + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "&chakanmodel=chakan", false);
                    break;
                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "项目综合管理" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
            //GridBind("download");
            //DownloadHtmlExcelFile(GridView1, str, null);
            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A5");
            downloadTable.Columns.Add("A6");
            downloadTable.Columns.Add("A7");
            downloadTable.Columns.Add("A8");
            downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A20");

            downloadTable.Columns.Add("A211");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A22");
            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");
            downloadTable.Columns.Add("A25");
            downloadTable.Columns.Add("A26");

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                string fapiaono = string.Empty;
                decimal 总计到账金额 = 0;
                decimal 总计不含税开票金额 = 0;
                decimal 总计开票金额 = 0;
                string 开票金额 = "0";
                string 不含税开票金额 = "0";
                string 开票日期 = "";
                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + dtAll.Rows[i]["id"].ToString() + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                    {
                        fapiaono = ds.Tables[0].Rows[ii]["col18"].ToString();
                        DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' and col55 like '%确定开票%' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            不含税开票金额 = ds.Tables[0].Rows[ii]["col28"].ToString();
                            开票金额 = ds.Tables[0].Rows[ii]["col31"].ToString();
                            if (开票金额 == "" || 开票金额 == "&nbsp;")
                            {
                                开票金额 = "0";
                            }
                            总计开票金额 += Convert.ToDecimal(开票金额);

                            if (不含税开票金额 == "" || 不含税开票金额 == "&nbsp;")
                            {
                                不含税开票金额 = "0";
                            }
                            总计不含税开票金额 += Convert.ToDecimal(不含税开票金额);

                            DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col9 ='1' and col3= '" + ds.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                            {
                                for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                                {
                                    string 到账金额 = ds1.Tables[0].Rows[kkk]["col6"].ToString();
                                    if (到账金额 == "" || 到账金额 == "&nbsp;")
                                    {
                                        到账金额 = "0";
                                    }
                                    总计到账金额 += Convert.ToDecimal(到账金额);
                                }
                            }
                            开票日期 = ds2.Tables[0].Rows[0]["col32"].ToString();

                        }
                    }

                }

                //if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                //    {
                //        开票金额 = ds.Tables[0].Rows[ii]["col22"].ToString();
                //        if (开票金额 == "" || 开票金额 == "&nbsp;")
                //        {
                //            开票金额 = "0";
                //        }
                //        总计开票金额 += Convert.ToDecimal(开票金额);

                //        DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col9 ='1' and col3= '" + ds.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                //        if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                //        {
                //            for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                //            {
                //                string 到账金额 = ds1.Tables[0].Rows[kkk]["col6"].ToString();
                //                if (到账金额 == "" || 到账金额 == "&nbsp;")
                //                {
                //                    到账金额 = "0";
                //                }
                //                总计到账金额 += Convert.ToDecimal(到账金额);
                //            }
                //        }
                //        开票日期 = ds.Tables[0].Rows[0]["col32"].ToString();
                //    }

                //}

                dr["A211"] = 总计不含税开票金额.ToString();
                dr["A21"] = 总计开票金额;
                dr["A22"] = 开票日期;
                dr["A23"] = 总计到账金额;
                dr["A24"] = (Convert.ToDecimal(总计开票金额) - 总计到账金额).ToString();
                dr["A25"] = dtAll.Rows[i]["col30"].ToString();
                dr["A26"] = dtAll.Rows[i]["col21"].ToString();

                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目综合管理下载模板.xlsx", downloadTable, str);
        }

        protected void btnExport2_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "项目综合管理明细" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
            //GridBind("download");
            //DownloadHtmlExcelFile(GridView1, str, null);
            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A5");
            downloadTable.Columns.Add("A6");
            downloadTable.Columns.Add("A7");
            downloadTable.Columns.Add("A8");
            downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A20");
            //downloadTable.Columns.Add("A21");
            //downloadTable.Columns.Add("A22");
            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");

            downloadTable.Columns.Add("A101");
            downloadTable.Columns.Add("A102");
            downloadTable.Columns.Add("A1103");

            downloadTable.Columns.Add("A103");
            downloadTable.Columns.Add("A104");
            downloadTable.Columns.Add("A105");
            downloadTable.Columns.Add("A106");
            downloadTable.Columns.Add("A107");
            downloadTable.Columns.Add("A108");
            downloadTable.Columns.Add("A109");
            downloadTable.Columns.Add("A110");
            //downloadTable.Columns.Add("A111");

            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                string fapiaono = string.Empty;
                int iiii = 0;
                Boolean youshuju = false;
                DataSet ds02 = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + dtAll.Rows[i]["id"] + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
                if (ds02 != null && ds02.Tables[0] != null && ds02.Tables[0].Rows.Count > 0)
                {
                    for (int ii = 0; ii < ds02.Tables[0].Rows.Count; ii++)
                    {
                        fapiaono = ds02.Tables[0].Rows[ii]["col18"].ToString();
                        DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '1' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                            {
                                for (int kk = 0; kk < ds1.Tables[0].Rows.Count; kk++)
                                {
                                    dr = downloadTable.NewRow();
                                    dr["A1"] = i + 1;
                                    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                                    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                                    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                                    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                                    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                                    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                                    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                                    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                                    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                                    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                                    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                                    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                                    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                                    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                                    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                                    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                                    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                                    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                                    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                                    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                                    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                                    dr["A101"] = iiii + 1;
                                    dr["A102"] = ds02.Tables[0].Rows[ii]["col18"];
                                    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                                    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                                    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                                    dr["A104"] = ds02.Tables[0].Rows[ii]["col23"];
                                    dr["A105"] = ds02.Tables[0].Rows[ii]["col39"];
                                    dr["A106"] = ds02.Tables[0].Rows[ii]["col40"];
                                    dr["A107"] = ds02.Tables[0].Rows[ii]["col29"];

                                    dr["A108"] = ds2.Tables[0].Rows[0]["col32"];
                                    dr["A109"] = ds1.Tables[0].Rows[kk]["col6"];
                                    dr["A110"] = ds1.Tables[0].Rows[kk]["col7"];
                                    //dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];
                                    downloadTable.Rows.Add(dr);
                                }

                            }
                            else
                            {
                                dr = downloadTable.NewRow();
                                dr["A1"] = i + 1;
                                dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                                dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                                dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                                dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                                dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                                dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                                dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                                dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                                dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                                dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                                dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                                dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                                dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                                dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                                dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                                dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                                dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                                dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                                dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                                dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                                dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                                dr["A101"] = iiii + 1;
                                dr["A102"] = ds02.Tables[0].Rows[ii]["col18"];
                                dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                                dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                                //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                                dr["A104"] = ds02.Tables[0].Rows[ii]["col23"];
                                dr["A105"] = ds02.Tables[0].Rows[ii]["col39"];
                                dr["A106"] = ds02.Tables[0].Rows[ii]["col40"];
                                dr["A107"] = ds02.Tables[0].Rows[ii]["col29"];

                                dr["A108"] = ds2.Tables[0].Rows[0]["col32"];
                                downloadTable.Rows.Add(dr);

                            }

                            ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '2' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                            {
                                for (int kk = 0; kk < ds1.Tables[0].Rows.Count; kk++)
                                {
                                    dr = downloadTable.NewRow();
                                    dr["A1"] = i + 1;
                                    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                                    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                                    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                                    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                                    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                                    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                                    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                                    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                                    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                                    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                                    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                                    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                                    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                                    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                                    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                                    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                                    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                                    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                                    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                                    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                                    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                                    dr["A101"] = iiii + 1;
                                    dr["A102"] = ds02.Tables[0].Rows[ii]["col18"];
                                    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                                    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                                    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                                    dr["A104"] = ds02.Tables[0].Rows[ii]["col23"];
                                    dr["A105"] = ds02.Tables[0].Rows[ii]["col39"];
                                    dr["A106"] = ds02.Tables[0].Rows[ii]["col40"];
                                    dr["A107"] = ds02.Tables[0].Rows[ii]["col29"];

                                    dr["A108"] = ds2.Tables[0].Rows[0]["col32"];
                                    dr["A109"] = ds1.Tables[0].Rows[kk]["col6"];
                                    dr["A110"] = ds1.Tables[0].Rows[kk]["col7"];
                                    //dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];
                                    downloadTable.Rows.Add(dr);
                                }

                            }
                            ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '3' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                            {
                                for (int kk = 0; kk < ds1.Tables[0].Rows.Count; kk++)
                                {
                                    dr = downloadTable.NewRow();
                                    dr["A1"] = i + 1;
                                    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                                    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                                    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                                    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                                    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                                    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                                    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                                    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                                    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                                    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                                    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                                    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                                    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                                    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                                    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                                    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                                    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                                    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                                    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                                    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                                    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                                    dr["A101"] = iiii + 1;
                                    dr["A102"] = ds02.Tables[0].Rows[ii]["col18"];
                                    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                                    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                                    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                                    dr["A104"] = ds02.Tables[0].Rows[ii]["col23"];
                                    dr["A105"] = ds02.Tables[0].Rows[ii]["col39"];
                                    dr["A106"] = ds02.Tables[0].Rows[ii]["col40"];
                                    dr["A107"] = ds02.Tables[0].Rows[ii]["col29"];

                                    dr["A108"] = ds2.Tables[0].Rows[0]["col32"];
                                    dr["A109"] = ds1.Tables[0].Rows[kk]["col6"];
                                    dr["A110"] = ds1.Tables[0].Rows[kk]["col7"];
                                    //dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];
                                    downloadTable.Rows.Add(dr);
                                }

                            }
                            ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '4' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                            {
                                for (int kk = 0; kk < ds1.Tables[0].Rows.Count; kk++)
                                {
                                    dr = downloadTable.NewRow();
                                    dr["A1"] = i + 1;
                                    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                                    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                                    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                                    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                                    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                                    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                                    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                                    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                                    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                                    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                                    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                                    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                                    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                                    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                                    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                                    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                                    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                                    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                                    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                                    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                                    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                                    dr["A101"] = iiii + 1;
                                    dr["A102"] = ds02.Tables[0].Rows[ii]["col18"];
                                    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                                    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                                    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                                    dr["A104"] = ds02.Tables[0].Rows[ii]["col23"];
                                    dr["A105"] = ds02.Tables[0].Rows[ii]["col39"];
                                    dr["A106"] = ds02.Tables[0].Rows[ii]["col40"];
                                    dr["A107"] = ds02.Tables[0].Rows[ii]["col29"];

                                    dr["A108"] = ds2.Tables[0].Rows[0]["col32"];
                                    dr["A109"] = ds1.Tables[0].Rows[kk]["col6"];
                                    dr["A110"] = ds1.Tables[0].Rows[kk]["col7"];
                                    //dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];
                                    downloadTable.Rows.Add(dr);
                                }

                            }
                            ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col2 = '5' and col9 ='1' and col3= '" + ds02.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds02.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                            {
                                for (int kk = 0; kk < ds1.Tables[0].Rows.Count; kk++)
                                {
                                    dr = downloadTable.NewRow();
                                    dr["A1"] = i + 1;
                                    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                                    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                                    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                                    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                                    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                                    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                                    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                                    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                                    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                                    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                                    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                                    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                                    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                                    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                                    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                                    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                                    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                                    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                                    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                                    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                                    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                                    dr["A101"] = iiii + 1;
                                    dr["A102"] = ds02.Tables[0].Rows[ii]["col18"];
                                    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                                    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                                    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                                    dr["A104"] = ds02.Tables[0].Rows[ii]["col23"];
                                    dr["A105"] = ds02.Tables[0].Rows[ii]["col39"];
                                    dr["A106"] = ds02.Tables[0].Rows[ii]["col40"];
                                    dr["A107"] = ds02.Tables[0].Rows[ii]["col29"];

                                    dr["A108"] = ds2.Tables[0].Rows[0]["col32"];
                                    dr["A109"] = ds1.Tables[0].Rows[kk]["col6"];
                                    dr["A110"] = ds1.Tables[0].Rows[kk]["col7"];
                                    //dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];
                                    downloadTable.Rows.Add(dr);
                                }

                            }

                            youshuju = false;
                            //for (int kk = 0; kk < ds2.Tables[0].Rows.Count; kk++)
                            //{
                            //if (youshuju == true)
                            //{
                            //    iiii++;
                            //}

                            //youshuju = true;
                            ////dr = dt.NewRow();
                            ////dr["A1"] = iiii + 1;
                            ////dr["A2"] = ds02.Tables[0].Rows[kk]["col22"];
                            ////dr["A3"] = ds02.Tables[0].Rows[kk]["col23"];
                            ////dr["A4"] = ds02.Tables[0].Rows[kk]["col39"];
                            ////dr["A5"] = ds02.Tables[0].Rows[kk]["col40"];
                            ////dr["A6"] = ds02.Tables[0].Rows[kk]["col29"];

                            //if (ds2.Tables[0].Rows[kk]["col39"].ToString() != "")
                            //{
                            //    dr = downloadTable.NewRow();
                            //    dr["A1"] = i + 1;
                            //    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                            //    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                            //    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                            //    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                            //    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                            //    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                            //    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                            //    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                            //    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                            //    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                            //    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                            //    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                            //    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                            //    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                            //    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                            //    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                            //    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                            //    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                            //    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                            //    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                            //    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                            //    dr["A101"] = iiii + 1;
                            //    dr["A102"] = ds02.Tables[0].Rows[kk]["col18"];
                            //    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                            //    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                            //    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                            //    dr["A104"] = ds02.Tables[0].Rows[kk]["col23"];
                            //    dr["A105"] = ds02.Tables[0].Rows[kk]["col39"];
                            //    dr["A106"] = ds02.Tables[0].Rows[kk]["col40"];
                            //    dr["A107"] = ds02.Tables[0].Rows[kk]["col29"];

                            //    dr["A108"] = ds2.Tables[0].Rows[kk]["col2"];
                            //    dr["A109"] = ds2.Tables[0].Rows[kk]["col39"];
                            //    dr["A110"] = ds2.Tables[0].Rows[kk]["col40"];
                            //    dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];
                            //    downloadTable.Rows.Add(dr);
                            //}
                            ////dt.Rows.Add(dr);

                            //youshuju = true;

                            //if (ds2.Tables[0].Rows[kk]["col41"].ToString() != "")
                            //{
                            //    dr = downloadTable.NewRow();
                            //    dr["A1"] = i + 1;
                            //    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                            //    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                            //    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                            //    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                            //    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                            //    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                            //    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                            //    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                            //    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                            //    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                            //    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                            //    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                            //    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                            //    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                            //    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                            //    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                            //    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                            //    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                            //    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                            //    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                            //    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                            //    dr["A101"] = iiii + 1;
                            //    dr["A102"] = ds02.Tables[0].Rows[kk]["col18"];
                            //    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                            //    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                            //    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                            //    dr["A104"] = ds02.Tables[0].Rows[kk]["col23"];
                            //    dr["A105"] = ds02.Tables[0].Rows[kk]["col39"];
                            //    dr["A106"] = ds02.Tables[0].Rows[kk]["col40"];
                            //    dr["A107"] = ds02.Tables[0].Rows[kk]["col29"];

                            //    dr["A108"] = ds2.Tables[0].Rows[kk]["col2"];
                            //    dr["A109"] = ds2.Tables[0].Rows[kk]["col41"];
                            //    dr["A110"] = ds2.Tables[0].Rows[kk]["col42"];
                            //    dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];

                            //    downloadTable.Rows.Add(dr);
                            //}


                            //youshuju = true;

                            //if (ds2.Tables[0].Rows[kk]["col43"].ToString() != "")
                            //{
                            //    dr = downloadTable.NewRow();
                            //    dr["A1"] = i + 1;
                            //    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                            //    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                            //    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                            //    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                            //    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                            //    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                            //    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                            //    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                            //    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                            //    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                            //    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                            //    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                            //    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                            //    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                            //    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                            //    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                            //    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                            //    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                            //    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                            //    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                            //    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                            //    dr["A101"] = iiii + 1;
                            //    dr["A102"] = ds02.Tables[0].Rows[kk]["col18"];
                            //    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                            //    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                            //    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                            //    dr["A104"] = ds02.Tables[0].Rows[kk]["col23"];
                            //    dr["A105"] = ds02.Tables[0].Rows[kk]["col39"];
                            //    dr["A106"] = ds02.Tables[0].Rows[kk]["col40"];
                            //    dr["A107"] = ds02.Tables[0].Rows[kk]["col29"];

                            //    dr["A108"] = ds2.Tables[0].Rows[kk]["col2"];
                            //    dr["A109"] = ds2.Tables[0].Rows[kk]["col43"];
                            //    dr["A110"] = ds2.Tables[0].Rows[kk]["col44"];
                            //    dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];

                            //    downloadTable.Rows.Add(dr);

                            //}


                            //youshuju = true;

                            //if (ds2.Tables[0].Rows[kk]["col45"].ToString() != "")
                            //{
                            //    dr = downloadTable.NewRow();
                            //    dr["A1"] = i + 1;
                            //    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                            //    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                            //    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                            //    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                            //    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                            //    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                            //    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                            //    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                            //    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                            //    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                            //    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                            //    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                            //    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                            //    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                            //    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                            //    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                            //    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                            //    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                            //    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                            //    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                            //    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                            //    dr["A101"] = iiii + 1;
                            //    dr["A102"] = ds02.Tables[0].Rows[kk]["col18"];
                            //    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                            //    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                            //    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                            //    dr["A104"] = ds02.Tables[0].Rows[kk]["col23"];
                            //    dr["A105"] = ds02.Tables[0].Rows[kk]["col39"];
                            //    dr["A106"] = ds02.Tables[0].Rows[kk]["col40"];
                            //    dr["A107"] = ds02.Tables[0].Rows[kk]["col29"];

                            //    dr["A108"] = ds2.Tables[0].Rows[kk]["col2"];
                            //    dr["A109"] = ds2.Tables[0].Rows[kk]["col45"];
                            //    dr["A110"] = ds2.Tables[0].Rows[kk]["col46"];
                            //    dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];

                            //    downloadTable.Rows.Add(dr);

                            //}


                            //youshuju = true;

                            //if (ds2.Tables[0].Rows[kk]["col47"].ToString() != "")
                            //{
                            //    dr = downloadTable.NewRow();
                            //    dr["A1"] = i + 1;
                            //    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                            //    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                            //    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                            //    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                            //    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                            //    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                            //    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                            //    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                            //    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                            //    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                            //    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                            //    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                            //    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                            //    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                            //    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                            //    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                            //    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                            //    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                            //    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                            //    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                            //    dr["A24"] = dtAll.Rows[i]["col21"].ToString();

                            //    dr["A101"] = iiii + 1;
                            //    dr["A102"] = ds02.Tables[0].Rows[kk]["col18"];
                            //    dr["A1103"] = ds02.Tables[0].Rows[ii]["col28"];
                            //    dr["A103"] = ds02.Tables[0].Rows[ii]["col31"];
                            //    //dr["A103"] = ds02.Tables[0].Rows[kk]["col22"];
                            //    dr["A104"] = ds02.Tables[0].Rows[kk]["col23"];
                            //    dr["A105"] = ds02.Tables[0].Rows[kk]["col39"];
                            //    dr["A106"] = ds02.Tables[0].Rows[kk]["col40"];
                            //    dr["A107"] = ds02.Tables[0].Rows[kk]["col29"];

                            //    dr["A108"] = ds2.Tables[0].Rows[kk]["col2"];
                            //    dr["A109"] = ds2.Tables[0].Rows[kk]["col47"];
                            //    dr["A110"] = ds2.Tables[0].Rows[kk]["col48"];
                            //    dr["A111"] = ds2.Tables[0].Rows[kk]["col49"];

                            //    downloadTable.Rows.Add(dr);

                            //}


                            //}
                        }
                    }

                }
                else
                {
                    dr = downloadTable.NewRow();
                    dr["A1"] = i + 1;
                    dr["A2"] = dtAll.Rows[i]["col1"].ToString();
                    dr["A3"] = dtAll.Rows[i]["col2"].ToString();
                    dr["A4"] = dtAll.Rows[i]["col3"].ToString();
                    dr["A5"] = dtAll.Rows[i]["col4"].ToString();
                    dr["A6"] = dtAll.Rows[i]["col5"].ToString();
                    dr["A7"] = dtAll.Rows[i]["col6"].ToString();
                    dr["A8"] = dtAll.Rows[i]["col7"].ToString();
                    dr["A9"] = dtAll.Rows[i]["col8"].ToString();
                    dr["A10"] = dtAll.Rows[i]["col9"].ToString();
                    dr["A11"] = dtAll.Rows[i]["col10"].ToString();

                    dr["A12"] = dtAll.Rows[i]["col31"].ToString();
                    dr["A13"] = dtAll.Rows[i]["col11"].ToString();
                    dr["A14"] = dtAll.Rows[i]["col12"].ToString();
                    dr["A15"] = dtAll.Rows[i]["col13"].ToString();
                    dr["A16"] = dtAll.Rows[i]["col14"].ToString();
                    dr["A17"] = dtAll.Rows[i]["col15"].ToString();
                    dr["A18"] = dtAll.Rows[i]["col16"].ToString();
                    dr["A19"] = dtAll.Rows[i]["col17"].ToString();
                    dr["A20"] = dtAll.Rows[i]["col18"].ToString();

                    dr["A23"] = dtAll.Rows[i]["col30"].ToString();
                    dr["A24"] = dtAll.Rows[i]["col21"].ToString();
                    downloadTable.Rows.Add(dr);
                }



            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/项目综合管理明细下载模板.xlsx", downloadTable, str);
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void btn资料退回_Click(object sender, EventArgs e)
        {
            var formNoList = new List<string>();
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                var checkedControl = (CheckBox)GridView1.Rows[k].FindControl("chk");
                if (checkedControl == null)
                {
                    continue;
                }
                var ifTick = checkedControl.Checked;
                if (ifTick)
                {
                    var tickedFormNo = ((Label)GridView1.Rows[k].FindControl("lblID")).Text; // 若該列有被選取，取出被選的單號
                    formNoList.Add(tickedFormNo);
                    string str1 = "";
                    string str2 = tickedFormNo;
                    if (base.Request.QueryString["caset"] == "1")
                    {
                        GridView1.Columns[24].Visible = true;
                        str1 = "xiangmu91";
                    }
                    else if (base.Request.QueryString["caset"] == "2")
                    {
                        GridView1.Columns[24].Visible = true;
                        str1 = "xiangmu92";
                    }
                    else if (base.Request.QueryString["caset"] == "3")
                    {
                        GridView1.Columns[26].Visible = true;
                        str1 = "xiangmu93";
                    }
                    else if (base.Request.QueryString["caset"] == "4")
                    {
                        GridView1.Columns[27].Visible = true;
                        str1 = "xiangmu94";
                    }
                    else if (base.Request.QueryString["caset"] == "5")
                    {
                        GridView1.Columns[28].Visible = true;
                        str1 = "xiangmu95";
                    }
                    else if (base.Request.QueryString["caset"] == "11")
                    {
                        GridView1.Columns[24].Visible = true;
                        str1 = "xiangmu91";
                    }
                    else if (base.Request.QueryString["caset"] == "12")
                    {
                        GridView1.Columns[24].Visible = true;
                        str1 = "xiangmu91";
                    }
                    else if (base.Request.QueryString["caset"] == "13")
                    {
                        GridView1.Columns[24].Visible = true;
                        str1 = "xiangmu91";
                    }
                    else if (base.Request.QueryString["caset"] == "14")
                    {
                        GridView1.Columns[24].Visible = true;
                        str1 = "xiangmu91";
                    }
                    else if (base.Request.QueryString["caset"] == "21")
                    {
                        GridView1.Columns[25].Visible = true;
                        str1 = "xiangmu92";
                    }
                    else if (base.Request.QueryString["caset"] == "22")
                    {
                        GridView1.Columns[25].Visible = true;
                        str1 = "xiangmu92";
                    }
                    else if (base.Request.QueryString["caset"] == "23")
                    {
                        GridView1.Columns[25].Visible = true;
                        str1 = "xiangmu92";
                    }
                    else if (base.Request.QueryString["caset"] == "24")
                    {
                        GridView1.Columns[25].Visible = true;
                        str1 = "xiangmu92";
                    }
                    else if (base.Request.QueryString["caset"] == "31")
                    {
                        GridView1.Columns[26].Visible = true;
                        str1 = "xiangmu93";
                    }
                    else if (base.Request.QueryString["caset"] == "32")
                    {
                        GridView1.Columns[26].Visible = true;
                        str1 = "xiangmu93";
                    }
                    else if (base.Request.QueryString["caset"] == "33")
                    {
                        GridView1.Columns[26].Visible = true;
                        str1 = "xiangmu93";
                    }
                    else if (base.Request.QueryString["caset"] == "34")
                    {
                        GridView1.Columns[26].Visible = true;
                        str1 = "xiangmu93";
                    }
                    else if (base.Request.QueryString["caset"] == "41")
                    {
                        GridView1.Columns[27].Visible = true;
                        str1 = "xiangmu94";
                    }
                    else if (base.Request.QueryString["caset"] == "42")
                    {
                        GridView1.Columns[27].Visible = true;
                        str1 = "xiangmu94";
                    }
                    else if (base.Request.QueryString["caset"] == "43")
                    {
                        GridView1.Columns[27].Visible = true;
                        str1 = "xiangmu94";
                    }
                    else if (base.Request.QueryString["caset"] == "44")
                    {
                        GridView1.Columns[27].Visible = true;
                        str1 = "xiangmu94";
                    }
                    else if (base.Request.QueryString["caset"] == "51")
                    {
                        GridView1.Columns[28].Visible = true;
                        str1 = "xiangmu95";
                    }
                    else if (base.Request.QueryString["caset"] == "52")
                    {
                        GridView1.Columns[28].Visible = true;
                        str1 = "xiangmu95";
                    }
                    else if (base.Request.QueryString["caset"] == "53")
                    {
                        GridView1.Columns[28].Visible = true;
                        str1 = "xiangmu95";
                    }
                    else if (base.Request.QueryString["caset"] == "54")
                    {
                        GridView1.Columns[28].Visible = true;
                        str1 = "xiangmu95";
                    }

                    xiangmu1List xiangmu1List = new xiangmu1List();

                    xiangmu1List.GetData(int.Parse(tickedFormNo));

                    xiangmu1List.col22 = "";
                    xiangmu1List.col23 = "";
                    xiangmu1List.col24 = "";
                    xiangmu1List.col25 = "";
                    xiangmu1List.col26 = "";
                    xiangmu1List.col27 = "";
                  
                    xiangmu1List.UpdateData(int.Parse(tickedFormNo));

                    //
                    附件List 附件List = new 附件List();
                    DataSet ds02 = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + tickedFormNo + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
                    for (int i = 0; i < ds02.Tables[0].Rows.Count;i++ )
                    {
                        var fapiaohaoma = ds02.Tables[0].Rows[i]["col18"].ToString();
                        附件List.col9 = "";

                        附件List.flag = str1;
                        附件List.col1 = fapiaohaoma;

                        附件List.DeleteData3();
                    }

                }
            }

            // 至少要勾一項
            if (formNoList.Count == 0)
            {
                SetWarningMessage("请至少选择一项勾选！");
                return;
            }

            this.GridBind();
        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }

        protected List<xiangmu1List> checkUploadData(DataTable dt)
        {
            List<xiangmu1List> xiangmu1List = new List<xiangmu1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xiangmu1List list = new xiangmu1List();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[1].ColumnName);
                else
                    list.col1 = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[2].ColumnName);
                else
                    list.col2 = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[3].ColumnName);
                else
                    list.col3 = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[4].ColumnName);
                else
                    list.col4 = dt.Rows[i][4].ToString();

                list.col5 = dt.Rows[i][5].ToString();
                list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString();
                list.col8 = dt.Rows[i][8].ToString();
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = "1";
                list.col14 = System.DateTime.Now.ToString("yyyy/MM/dd");
                list.col15 = "";
                list.col16 = "";
                list.col17 = "";
                list.col18 = "";
                list.col19 = "";
                list.col20 = "";
                list.col21 = "";

                xiangmu1List.Add(list);
            }
            return xiangmu1List;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            if (this.ViewState["OrderByKey"].ToString() == sortExpression)
            {
                if ((bool)this.ViewState["OrderByType"])
                {
                    this.ViewState["OrderByType"] = false;
                }
                else
                {
                    this.ViewState["OrderByType"] = true;
                }
            }
            else
            {
                this.ViewState["OrderByKey"] = e.SortExpression;
            }
            this.GridBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string temp1 = txtcol1.Text.Trim();
                string temp2 = txtcol2.Text.Trim();
                string temp3 = txtcol3.Text.Trim();
                string temp4 = txtcol4.Text.Trim();
                string temp5 = txtcol5.Text.Trim();
                string temp6 = txtcol6.Text.Trim();

                string temp7 = this.ListPager.CurrentPageIndex.ToString();
                string temp8 = txtcol7.Text.Trim();
                string temp9 = Dropcol8.Text.Trim();

                ((Label)e.Row.FindControl("lblcol1")).Width = ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol1")).Width : ((Label)e.Row.FindControl("lblcol1")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol2")).Width = ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol2")).Width : ((Label)e.Row.FindControl("lblcol2")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol4")).Width = ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol4")).Width : ((Label)e.Row.FindControl("lblcol4")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol5")).Width = ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol5")).Width : ((Label)e.Row.FindControl("lblcol5")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol6")).Width = ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol6")).Width : ((Label)e.Row.FindControl("lblcol6")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol8")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol9")).Width = ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol9")).Width : ((Label)e.Row.FindControl("lblcol9")).Text.Trim().Length * 12;
                //((Label)e.Row.FindControl("lblcol10")).Width = ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol10")).Width : ((Label)e.Row.FindControl("lblcol10")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol7")).Width = ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol7")).Width : ((Label)e.Row.FindControl("lblcol7")).Text.Trim().Length * 12;
                ((Label)e.Row.FindControl("lblcol15")).Width = ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol15")).Width : ((Label)e.Row.FindControl("lblcol15")).Text.Trim().Length * 12;

                if (((Label)e.Row.FindControl("lblcol1")).Width.Value < 200)
                {
                    ((Label)e.Row.FindControl("lblcol1")).Width = 200;
                }
                if (((Label)e.Row.FindControl("lblcol2")).Width.Value < 100)
                {
                    ((Label)e.Row.FindControl("lblcol2")).Width = 100;
                }
                if (((Label)e.Row.FindControl("lblcol4")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol4")).Width = 150;
                }

                if (((Label)e.Row.FindControl("lblcol5")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol5")).Width = 150;
                }

                if (((Label)e.Row.FindControl("lblcol9")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol9")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol10")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol10")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol7")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol7")).Width = 150;
                }
                if (((Label)e.Row.FindControl("lblcol15")).Width.Value < 150)
                {
                    ((Label)e.Row.FindControl("lblcol15")).Width = 150;
                }

                string strid = ((Label)e.Row.FindControl("lblID")).Text;
                string caset = base.Request.QueryString["caset"];

                ((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol8")).Text;
                ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "xiangmu9Add.aspx?id=" + strid + "&temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp4=" + temp4 + "&temp5=" + temp5 + "&temp6=" + temp6 + "&temp7=" + temp7 + "&temp8=" + temp8 + "&temp9=" + temp9 + "&caset=" + caset + "&model=view";
                ((HyperLink)e.Row.FindControl("HyperLink1")).Width = ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12 == 0 ? ((Label)e.Row.FindControl("lblcol8")).Width : ((Label)e.Row.FindControl("lblcol8")).Text.Trim().Length * 12;

                if (((Label)e.Row.FindControl("lbl发票扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = true;
                    ((Label)e.Row.FindControl("Label发票扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn1")).Visible = false;
                    ((Label)e.Row.FindControl("Label发票扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl采购订单扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = true;
                    ((Label)e.Row.FindControl("Label采购订单扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn2")).Visible = false;
                    ((Label)e.Row.FindControl("Label采购订单扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl完工结算证明扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = true;
                    ((Label)e.Row.FindControl("Label完工结算证明扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn3")).Visible = false;
                    ((Label)e.Row.FindControl("Label完工结算证明扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl审计定案扫描件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn4")).Visible = true;
                    ((Label)e.Row.FindControl("Label审计定案扫描件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn4")).Visible = false;
                    ((Label)e.Row.FindControl("Label审计定案扫描件")).Visible = true;
                }

                if (((Label)e.Row.FindControl("lbl竣工资料及图纸附件")).Text.Trim() == "1")
                {
                    ((LinkButton)e.Row.FindControl("lbtn5")).Visible = true;
                    ((Label)e.Row.FindControl("Label竣工资料及图纸附件")).Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("lbtn5")).Visible = false;
                    ((Label)e.Row.FindControl("Label竣工资料及图纸附件")).Visible = true;
                }

                if (base.Request.QueryString["caset"] == "1")
                {
                    GridView1.Columns[24].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "2")
                {
                    GridView1.Columns[24].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "3")
                {
                    GridView1.Columns[26].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "4")
                {
                    GridView1.Columns[27].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "5")
                {
                    GridView1.Columns[28].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "11")
                {
                    GridView1.Columns[24].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "12")
                {
                    GridView1.Columns[24].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "13")
                {
                    GridView1.Columns[24].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "14")
                {
                    GridView1.Columns[24].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "21")
                {
                    GridView1.Columns[25].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "22")
                {
                    GridView1.Columns[25].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "23")
                {
                    GridView1.Columns[25].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "24")
                {
                    GridView1.Columns[25].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "31")
                {
                    GridView1.Columns[26].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "32")
                {
                    GridView1.Columns[26].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "33")
                {
                    GridView1.Columns[26].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "34")
                {
                    GridView1.Columns[26].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "41")
                {
                    GridView1.Columns[27].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "42")
                {
                    GridView1.Columns[27].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "43")
                {
                    GridView1.Columns[27].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "44")
                {
                    GridView1.Columns[27].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "51")
                {
                    GridView1.Columns[28].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "52")
                {
                    GridView1.Columns[28].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "53")
                {
                    GridView1.Columns[28].Visible = true;
                }
                else if (base.Request.QueryString["caset"] == "54")
                {
                    GridView1.Columns[28].Visible = true;
                }

            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
            if (e.CommandName == "lbtn11")
            {
                string tempfilename = "发票扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu91", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn12")
            {
                string tempfilename = "采购订单扫描件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu92", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn13")
            {
                string tempfilename = "结算资料附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu93", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn14")
            {
                string tempfilename = "审计资料附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu94", rowIDs, tempfilename);
            }
            if (e.CommandName == "lbtn15")
            {
                string tempfilename = "竣工资料附件" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                btnDownLoad_Click("xiangmu95", rowIDs, tempfilename);
            }
        }

        //批量下载
        protected void btnDownLoad_Click(string str1, string str2, string str3)
        {
            string sourcePath = "";
            string savePath = "";
            Dictionary<string, Stream> streams = new Dictionary<string, Stream>();
            Stream streamWriter = null;
            int counts = 1000;

            DataSet ds02 = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + str2 + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
            for (int ii = 0; ii < ds02.Tables[0].Rows.Count; ii++)
            {
                var fapiaono = ds02.Tables[0].Rows[ii]["col18"].ToString();
                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = '" + str1 + "' and col1='" + fapiaono + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    for (int kkk = 0; kkk < ds2.Tables[0].Rows.Count; kkk++)
                    {
                        savePath = ds2.Tables[0].Rows[kkk]["col3"].ToString().Trim();
                        sourcePath = ds2.Tables[0].Rows[kkk]["col3"].ToString().Trim();
                        if (sourcePath != "")
                        {
                            string[] str11 = sourcePath.Split('/');
                            for (int k = 0; k < str11.Length; k++)
                            {
                                sourcePath = str11[str11.Length - 1].ToString();
                                savePath = "公司证件UploadFile/" + str11[str11.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                    }

                }
            }

            

            MemoryStream ms = new MemoryStream();
            ms = PackageManyZip(streams);
            byte[] bytes = new byte[(int)ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(str3, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();


        }


        //批量下载
        //protected void btnDownLoad_Click(object sender, EventArgs e)
        //{
        //    string sourcePath = "";
        //    string savePath = "";
        //    Dictionary<string, Stream> streams = new Dictionary<string, Stream>();
        //    Stream streamWriter = null;
        //    int counts = 1000;


        //    foreach (GridViewRow r in GridView1.Rows)
        //    {
        //        string name = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
        //        //savePath = "E:/导出证件信息/" + name;

        //        if (((CheckBox)r.FindControl("chk")).Checked)
        //        {
        //            savePath = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
        //            sourcePath = ((Label)r.FindControl("lbl招标文件")).Text.Trim();
        //            if (sourcePath != "")
        //            {
        //                string[] str1 = sourcePath.Split('/');
        //                for (int k = 0; k < str1.Length; k++)
        //                {
        //                    sourcePath = str1[str1.Length - 1].ToString();
        //                    savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

        //                }

        //                string filePath = Server.MapPath(savePath);//路径
        //                streamWriter = new FileStream(filePath, FileMode.Open);
        //                //streamWriter.Close();
        //                counts++;
        //                sourcePath = counts + sourcePath;
        //                streams.Add(sourcePath, streamWriter);
        //            }

        //            //savePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();
        //            //sourcePath = ((Label)r.FindControl("lbl车辆照片储存位置")).Text.Trim();

        //            //if (sourcePath != "")
        //            //{
        //            //    string[] str1 = sourcePath.Split('/');
        //            //    for (int k = 0; k < str1.Length; k++)
        //            //    {
        //            //        sourcePath = str1[str1.Length - 1].ToString();
        //            //        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

        //            //    }

        //            //    string filePath = Server.MapPath(savePath);//路径
        //            //    streamWriter = new FileStream(filePath, FileMode.Open);
        //            //    //streamWriter.Close();
        //            //    counts++;
        //            //    sourcePath = counts + sourcePath;
        //            //    streams.Add(sourcePath, streamWriter);
        //            //}



        //            //savePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();
        //            //sourcePath = ((Label)r.FindControl("lbl租车协议储存位置")).Text.Trim();

        //            //if (sourcePath != "")
        //            //{
        //            //    string[] str1 = sourcePath.Split('/');
        //            //    for (int k = 0; k < str1.Length; k++)
        //            //    {
        //            //        sourcePath = str1[str1.Length - 1].ToString();
        //            //        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

        //            //    }

        //            //    string filePath = Server.MapPath(savePath);//路径
        //            //    streamWriter = new FileStream(filePath, FileMode.Open);
        //            //    //streamWriter.Close();
        //            //    counts++;
        //            //    sourcePath = counts + sourcePath;
        //            //    streams.Add(sourcePath, streamWriter);
        //            //}

        //        }
        //        else
        //        {
        //            if (((CheckBox)r.FindControl("Chk电子版合同")).Checked)
        //            {
        //                savePath = ((Label)r.FindControl("lbl电子版合同")).Text.Trim();
        //                sourcePath = ((Label)r.FindControl("lbl电子版合同")).Text.Trim();

        //                if (sourcePath != "")
        //                {
        //                    string[] str1 = sourcePath.Split('/');
        //                    for (int k = 0; k < str1.Length; k++)
        //                    {
        //                        sourcePath = str1[str1.Length - 1].ToString();
        //                        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

        //                    }

        //                    string filePath = Server.MapPath(savePath);//路径
        //                    streamWriter = new FileStream(filePath, FileMode.Open);
        //                    //streamWriter.Close();
        //                    counts++;
        //                    sourcePath = counts + sourcePath;
        //                    streams.Add(sourcePath, streamWriter);
        //                }

        //            }

        //            if (((CheckBox)r.FindControl("Chk合同扫描件")).Checked)
        //            {
        //                savePath = ((Label)r.FindControl("lbl合同扫描件")).Text.Trim();
        //                sourcePath = ((Label)r.FindControl("lbl合同扫描件")).Text.Trim();

        //                if (sourcePath != "")
        //                {
        //                    string[] str1 = sourcePath.Split('/');
        //                    for (int k = 0; k < str1.Length; k++)
        //                    {
        //                        sourcePath = str1[str1.Length - 1].ToString();
        //                        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

        //                    }

        //                    string filePath = Server.MapPath(savePath);//路径
        //                    streamWriter = new FileStream(filePath, FileMode.Open);
        //                    //streamWriter.Close();
        //                    counts++;
        //                    sourcePath = counts + sourcePath;
        //                    streams.Add(sourcePath, streamWriter);
        //                }

        //            }
        //            if (((CheckBox)r.FindControl("Chk合同其他附件")).Checked)
        //            {
        //                savePath = ((Label)r.FindControl("lbl合同其他附件")).Text.Trim();
        //                sourcePath = ((Label)r.FindControl("lbl合同其他附件")).Text.Trim();

        //                if (sourcePath != "")
        //                {
        //                    string[] str1 = sourcePath.Split('/');
        //                    for (int k = 0; k < str1.Length; k++)
        //                    {
        //                        sourcePath = str1[str1.Length - 1].ToString();
        //                        savePath = "公司证件UploadFile/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

        //                    }

        //                    string filePath = Server.MapPath(savePath);//路径
        //                    streamWriter = new FileStream(filePath, FileMode.Open);
        //                    //streamWriter.Close();
        //                    counts++;
        //                    sourcePath = counts + sourcePath;
        //                    streams.Add(sourcePath, streamWriter);
        //                }

        //            }

        //        }
        //    }


        //    MemoryStream ms = new MemoryStream();
        //    ms = PackageManyZip(streams);
        //    byte[] bytes = new byte[(int)ms.Length];
        //    ms.Read(bytes, 0, bytes.Length);
        //    ms.Close();
        //    Response.ContentType = "application/octet-stream";
        //    //通知浏览器下载文件而不是打开
        //    Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode("投标管理打包文档.zip", System.Text.Encoding.UTF8));
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();


        //}

        static MemoryStream PackageManyZip(Dictionary<string, Stream> streams)
        {
            byte[] buffer = new byte[65000];
            MemoryStream returnStream = new MemoryStream();
            var zipMs = new MemoryStream();
            using (ZipOutputStream zipStream = new ZipOutputStream(zipMs))
            {
                zipStream.SetLevel(9);
                foreach (var kv in streams)
                {
                    string fileName = kv.Key.Substring(4, kv.Key.Length - 4);
                    using (var streamInput = kv.Value)
                    {
                        zipStream.PutNextEntry(new ZipEntry(fileName));
                        while (true)
                        {
                            var readCount = streamInput.Read(buffer, 0, buffer.Length);
                            if (readCount > 0)
                            {
                                zipStream.Write(buffer, 0, readCount);
                            }
                            else
                            {
                                break;
                            }
                        }
                        zipStream.Flush();
                    }
                }
                zipStream.Finish();
                zipMs.Position = 0;
                zipMs.CopyTo(returnStream, 56000);
            }
            returnStream.Position = 0;
            return returnStream;
        }


        public void SetWarningMessage(string message)
        {
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", message);
            return;
        }


        

    }
}