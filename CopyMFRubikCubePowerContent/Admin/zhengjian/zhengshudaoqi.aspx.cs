using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System.Text;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using MojoCube.Api.File;
using System;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MojoCube.Web.DispatchWaybill;
using Wuqi.Webdiyer;

namespace CopyMFRubikCubePowerContent.Admin.zhengjian
{
    public partial class zhengshudaoqi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                getDrop州市();
                getDrop所属项目部();
                
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();

            }
        }

        protected void getDrop州市()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,pinming  from tb_pinzhong where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop州市.DataTextField = "pinming";
            Drop州市.DataValueField = "pinming";
            Drop州市.DataSource = dataSource;
            Drop州市.DataBind();
            Drop州市.Items.Insert(0, "");

        }

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from tb_guige where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop所属项目部.DataTextField = "guige";
            Drop所属项目部.DataValueField = "guige";
            Drop所属项目部.DataSource = dataSource;
            Drop所属项目部.DataBind();
            Drop所属项目部.Items.Insert(0, "");

        }


        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            this.GridBind();
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
            adminPager.TableName = "(SELECT yuangongzs.*,yuangongzs_1.qita5col1 as qita5col1,yuangongzs_1.qita5col2 as qita5col2,yuangongzs_1.qita5col3 as qita5col3,yuangongzs_1.qita5col4 as qita5col4,yuangongzs_1.qita5col5 as qita5col5 FROM yuangongzs left join yuangongzs_1 on yuangongzs.ID = yuangongzs_1.SID)";
            adminPager.strGetFields = "*";

            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            ArrayList arrayList = new ArrayList();
            if (this.Drop州市.Text.Trim() != "")
            {
                where.Append(" and style like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.Drop州市.Text.Trim()));

            }
            if (this.Drop所属项目部.Text.Trim() != "")
            {
                where.Append(" and zsname like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.Drop所属项目部.Text.Trim()));

            }
            if (this.txt车主姓名.Text.Trim() != "")
            {
                where.Append(" and name like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txt车主姓名.Text.Trim()));

            }

            adminPager.where = where.ToString();
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.GridView1.DataSource = adminPager.GetTable();
            this.GridView1.DataBind();
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
                string strdate1 = ((Label)e.Row.FindControl("lbl身份证信息date")).Text.Trim();
                if (strdate1 == "")
                {
                    ((Label)e.Row.FindControl("lbl身份证信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl身份证信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl身份证信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl身份证信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl身份证信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl身份证信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl身份证信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl身份证信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string strdate2 = ((Label)e.Row.FindControl("lbl劳动合同信息date")).Text.Trim();
                if (strdate2 == "")
                {
                    ((Label)e.Row.FindControl("lbl劳动合同信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl劳动合同信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl通信类ABC证书信息date = ((Label)e.Row.FindControl("lbl通信类ABC证书信息date")).Text.Trim();
                if (lbl通信类ABC证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl通信类ABC证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl通信类职称证书信息date = ((Label)e.Row.FindControl("lbl通信类职称证书信息date")).Text.Trim();
                if (lbl通信类职称证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl通信类职称证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl通信类职称证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl通信类概预算证书信息date = ((Label)e.Row.FindControl("lbl通信类概预算证书信息date")).Text.Trim();
                if (lbl通信类概预算证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl通信类概预算证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl建筑类ABC证书信息date = ((Label)e.Row.FindControl("lbl建筑类ABC证书信息date")).Text.Trim();
                if (lbl建筑类ABC证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl一级建造师证书信息date = ((Label)e.Row.FindControl("lbl一级建造师证书信息date")).Text.Trim();
                if (lbl一级建造师证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl一级建造师证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl一级建造师证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl二级建造师证书信息date = ((Label)e.Row.FindControl("lbl二级建造师证书信息date")).Text.Trim();
                if (lbl二级建造师证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl二级建造师证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl二级建造师证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl建筑类职称证书信息date = ((Label)e.Row.FindControl("lbl建筑类职称证书信息date")).Text.Trim();
                if (lbl建筑类职称证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl建筑类职称证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl建筑类技术工种证书信息date = ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息date")).Text.Trim();
                if (lbl建筑类技术工种证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl通信类技术工种证书信息date = ((Label)e.Row.FindControl("lbl通信类技术工种证书信息date")).Text.Trim();
                if (lbl通信类技术工种证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl特种作业证书信息date = ((Label)e.Row.FindControl("lbl特种作业证书信息date")).Text.Trim();
                if (lbl特种作业证书信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl特种作业证书信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl特种作业证书信息")).BackColor = System.Drawing.Color.Red;
                    }
                }

                string lbl其他证书1信息date = ((Label)e.Row.FindControl("lbl特种作业证书1信息date")).Text.Trim();
                if (lbl其他证书1信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl其他证书1信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl其他证书1信息")).BackColor = System.Drawing.Color.Red;
                    }

                }

                string lbl其他证书2信息date = ((Label)e.Row.FindControl("lbl特种作业证书2信息date")).Text.Trim();
                if (lbl其他证书2信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl其他证书2信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl其他证书2信息")).BackColor = System.Drawing.Color.Red;
                    }

                }

                string lbl其他证书3信息date = ((Label)e.Row.FindControl("lbl特种作业证书3信息date")).Text.Trim();
                if (lbl其他证书3信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl其他证书3信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl其他证书3信息")).BackColor = System.Drawing.Color.Red;
                    }

                }

                string lbl其他证书4信息date = ((Label)e.Row.FindControl("lbl特种作业证书4信息date")).Text.Trim();
                if (lbl其他证书4信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl其他证书4信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl其他证书4信息")).BackColor = System.Drawing.Color.Red;
                    }

                }

                string lbl其他证书5信息date = ((Label)e.Row.FindControl("lbl特种作业证书5信息date")).Text.Trim();
                if (lbl其他证书5信息date == "")
                {
                    ((Label)e.Row.FindControl("lbl其他证书5信息")).Text = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).Text = "已经到期";
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).BackColor = System.Drawing.Color.Blue;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).Text = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).Text = "即将到期";
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).BackColor = System.Drawing.Color.Green;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).Text = "已经过期";
                        ((Label)e.Row.FindControl("lbl其他证书5信息")).BackColor = System.Drawing.Color.Red;
                    }

                }




            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
        //    AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
        //    string[] controlList = new string[]
        //{
        //    "gvDelete"
        //};
        //    AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //yuangongzsList list = new yuangongzsList();
            //if (e.CommandName == "_delete")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    list.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            //}
            //this.GridBind();
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {

            DateTime dt = System.DateTime.Now;
            string str = "证件到期提醒" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
            //GridBind("download");

            DataTable dataSource1 = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            sql = "select * from (SELECT yuangongzs.*,yuangongzs_1.qita5col1 as qita5col1,yuangongzs_1.qita5col2 as qita5col2,yuangongzs_1.qita5col3 as qita5col3,yuangongzs_1.qita5col4 as qita5col4,yuangongzs_1.qita5col5 as qita5col5 FROM yuangongzs left join yuangongzs_1 on yuangongzs.ID = yuangongzs_1.SID)  where 1=1  ";

            if (this.Drop州市.Text.Trim() != "")
            {
                sql += "and zhousi =  '" + this.Drop州市.Text.Trim() + "'";

            }
            if (this.Drop所属项目部.Text.Trim() != "")
            {
                sql += "and xiangmu =  '" + this.Drop所属项目部.Text.Trim() + "'";

            }
            if (this.txt车主姓名.Text.Trim() != "")
            {
                sql += "and name =  '" + this.txt车主姓名.Text.Trim() + "'";

            }

          
            dataSource1 = oledbHelper.GetDataTable(sql);

            //DownloadHtmlExcelFile(GridView1, str, null);
            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A41");
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
            downloadTable.Columns.Add("A21");
            
            DataRow dr;
            for (int i = 0; i < dataSource1.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dataSource1.Rows[i]["zhousi"].ToString();
                dr["A3"] = dataSource1.Rows[i]["xiangmu"].ToString();
                dr["A31"] = dataSource1.Rows[i]["zhiwu"].ToString(); 
                dr["A4"] = dataSource1.Rows[i]["name"].ToString();
                dr["A41"] = dataSource1.Rows[i]["sno"].ToString();

                string strdate1 = dataSource1.Rows[i]["youxiaodate"].ToString().Trim();
                if (strdate1 == "")
                {
                    dr["A5"] =  "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A5"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A5"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A5"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate1), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A5"] = "已经过期";
                      
                    }
                }

                string strdate2 = dataSource1.Rows[i]["hetongcol3"].ToString().Trim();
               
                if (strdate2 == "")
                {
                    dr["A6"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A6"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A6"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A6"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(strdate2), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A6"] = "已经过期";
                        
                    }
                }

           
                string lbl通信类ABC证书信息date = dataSource1.Rows[i]["txcol5"].ToString().Trim();
                if (lbl通信类ABC证书信息date == "")
                {
                    dr["A7"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A7"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A7"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A7"] = "即将到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A7"] = "已经过期";
                        
                    }
                }

                string lbl通信类职称证书信息date = dataSource1.Rows[i]["txzccol5"].ToString().Trim();
                if (lbl通信类职称证书信息date == "")
                {
                    dr["A8"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A8"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A8"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A8"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A8"] = "已经过期";
                        
                    }
                }

                string lbl通信类概预算证书信息date = dataSource1.Rows[i]["txyscol5"].ToString().Trim();
                if (lbl通信类概预算证书信息date == "")
                {
                    dr["A9"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A9"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A9"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A9"] = "即将到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类概预算证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A9"] = "已经过期";
                        
                    }
                }

                string lbl建筑类ABC证书信息date = dataSource1.Rows[i]["jzABCcol5"].ToString().Trim();
                if (lbl建筑类ABC证书信息date == "")
                {
                    dr["A10"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A10"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A10"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A10"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类ABC证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A10"] = "已经过期";
                       
                    }
                }

                string lbl一级建造师证书信息date = dataSource1.Rows[i]["yijicol5"].ToString().Trim();
                if (lbl一级建造师证书信息date == "")
                {
                    dr["A11"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A11"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A11"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A11"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl一级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A11"] = "已经过期";
                        
                    }
                }

                string lbl二级建造师证书信息date = dataSource1.Rows[i]["erjicol5"].ToString().Trim();
                if (lbl二级建造师证书信息date == "")
                {
                    dr["A12"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A12"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A12"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A12"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl二级建造师证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A12"] = "已经过期";
                       
                    }
                }

                string lbl建筑类职称证书信息date = dataSource1.Rows[i]["jzzccol5"].ToString().Trim();
                if (lbl建筑类职称证书信息date == "")
                {
                    dr["A13"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A13"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A13"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A13"] = "即将到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类职称证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A13"] = "已经过期";
                       
                    }
                }

                string lbl建筑类技术工种证书信息date = dataSource1.Rows[i]["jzjscol5"].ToString().Trim();
                if (lbl建筑类技术工种证书信息date == "")
                {
                    dr["A14"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A14"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A14"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A14"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl建筑类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A14"] = "已经过期";
                       
                    }
                }

                string lbl通信类技术工种证书信息date = dataSource1.Rows[i]["txjscol5"].ToString().Trim();
                if (lbl通信类技术工种证书信息date == "")
                {
                    dr["A15"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A15"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A15"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A15"] = "即将到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl通信类技术工种证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A15"] = "已经过期";
                        
                    }
                }

                string lbl特种作业证书信息date = dataSource1.Rows[i]["tzzycol5"].ToString().Trim();
                if (lbl特种作业证书信息date == "")
                {
                    dr["A16"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A16"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A16"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A16"] = "即将到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl特种作业证书信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A16"] = "已经过期";
                        
                    }
                }

                string lbl其他证书1信息date = dataSource1.Rows[i]["qita5col1"].ToString().Trim();
                if (lbl其他证书1信息date == "")
                {
                    dr["A17"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A17"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A17"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A17"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A17"] = "已经过期";
                        
                    }

                }

                string lbl其他证书2信息date = dataSource1.Rows[i]["qita5col2"].ToString().Trim();
                if (lbl其他证书2信息date == "")
                {
                    dr["A18"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A18"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A18"]  = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书2信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A18"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书1信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A18"] = "已经过期";
                       
                    }

                }

                string lbl其他证书3信息date = dataSource1.Rows[i]["qita5col3"].ToString().Trim();
                if (lbl其他证书3信息date == "")
                {
                    dr["A19"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A19"] = "已经到期";
                        
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A19"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A19"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书3信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A19"] = "已经过期";
                        
                    }

                }

                string lbl其他证书4信息date = dataSource1.Rows[i]["qita5col4"].ToString().Trim();
                if (lbl其他证书4信息date == "")
                {
                    dr["A20"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A20"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A20"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A20"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书4信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                        dr["A20"] = "已经过期";
                        
                    }

                }

                string lbl其他证书5信息date = dataSource1.Rows[i]["qita5col5"].ToString().Trim();
                if (lbl其他证书5信息date == "")
                {
                    dr["A21"] = "";
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                    {
                        dr["A21"] = "已经到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A21"] = "";
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                    {
                        dr["A21"] = "即将到期";
                       
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(lbl其他证书5信息date), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                    {
                       dr["A21"] = "已经过期";
                        
                    }

                }

               
               
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx2("/Admin/DownLoadTemplates/证书到期下载模板.xlsx", downloadTable, str);
        }


    }
}