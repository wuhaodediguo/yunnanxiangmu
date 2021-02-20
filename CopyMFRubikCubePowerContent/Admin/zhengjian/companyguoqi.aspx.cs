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
    public partial class companyguoqi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {

                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();

            }
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
            adminPager.TableName = "companyzs";
            adminPager.strGetFields = "*";
            ArrayList arrayList = new ArrayList();
            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");

            string strdate = DateTime.Now.AddMonths(2).ToString("yyyyMMdd");
            where.Append(" and format(daqidate,'yyyyMMdd') <= ''+?+'' ");
            arrayList.Add(strdate);
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
                //if (((Label)e.Row.FindControl("lbl合同到期日期")).Text.Length > 10)
                //{
                //    ((Label)e.Row.FindControl("lbl合同到期日期")).Text = ((Label)e.Row.FindControl("lbl合同到期日期")).Text.Substring(0,10);
                   
                //}
                ((Label)e.Row.FindControl("lbl合同到期日期")).Text = ((Label)e.Row.FindControl("lbl合同到期日期")).Text== "" ? "" : Convert.ToDateTime(((Label)e.Row.FindControl("lbl合同到期日期")).Text).ToString("yyyy-MM-dd");


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


    }
}