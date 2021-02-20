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

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class print : System.Web.UI.Page
    {
        public string strcase = string.Empty;
        public string strUserName = string.Empty;
        public string strRoleValue = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {

                strcase = Request.QueryString["hdstrcase"];
                strUserName = Request.QueryString["hdUserName"];
                strRoleValue = Request.QueryString["hdRoleValue"];
                this.GridBind();

            }
            
        }


        private void GridBind()
        {
            //AdminPager adminPager = new AdminPager(this.ListPager);
            //adminPager.PageSize = MojoCube.Web.String.PageSize();
            //adminPager.ConnStr = Connection.ConnString();
            string sql = string.Empty;
            string sql2 = string.Empty;
            string sql3 = string.Empty;
            string sql4 = string.Empty;
            string sql5 = string.Empty;
            string sql6 = string.Empty;

            //if (strcase == "" || strcase == "3")
            //{
            //    adminPager.TableName = "t_caiwu2";
            //}
            //else if (strcase == "2" || strcase == "4")
            //{
            //    adminPager.TableName = "t_caiwu22";
            //}
            //else if (strcase == "5" || strcase == "6")
            //{
            //    adminPager.TableName = "t_caiwu5";
            //}

            //adminPager.strGetFields = "*";
            //ArrayList arrayList = new ArrayList();
            //StringBuilder where = new StringBuilder();
            OledbHelper oledbHelper = new OledbHelper();

            //if (strcase == "")
            //{
            //    where.Append(" where 1=1 and col55 like '%未审批%' ");
            //    if (this.Session["RoleValue"].ToString() != "1")
            //    {
            //        //审核人员
            //        where.Append(" where 1=1 and col62 = '" + this.Session["FullName"].ToString() + "' ");
            //    }
            //}
            //else if (strcase == "2")
            //{
            //    where.Append(" where 1=1 and col30 = '0' ");

            //    if (this.Session["RoleValue"].ToString() != "1")
            //    {
            //        where.Append(" and col41 = '" + this.Session["FullName"].ToString() + "' ");
            //    }

            //}
            //else if (strcase == "3")
            //{
            //    where.Append(" where 1=1 and col55 not like '%未审批%' ");
            //    if (this.Session["RoleValue"].ToString() != "1")
            //    {
            //        where.Append(" where 1=1 and col63 like '%" + this.Session["FullName"].ToString() + "%' ");
            //    }
            //}
            //else if (strcase == "4")
            //{
            //    where.Append(" where 1=1 and col30 = '1'  ");

            //    if (this.Session["RoleValue"].ToString() != "1")
            //    {
            //        where.Append(" and col41 = '" + this.Session["FullName"].ToString() + "' ");
            //    }

            //}
            //else if (strcase == "5")
            //{
            //    where.Append(" where 1=1 and col43 like '%未审批%'  ");

            //    if (this.Session["RoleValue"].ToString() != "1")
            //    {
            //        where.Append(" and col49 = '" + this.Session["FullName"].ToString() + "' ");
            //    }

            //}
            //else if (strcase == "6")
            //{
            //    where.Append(" where 1=1 and col43 not like '%未审批%'  ");

            //    if (this.Session["RoleValue"].ToString() != "1")
            //    {
            //        where.Append(" and col50 like '%" + this.Session["FullName"].ToString() + "%' ");
            //    }

            //}


            sql = "select * from t_caiwu2 where 1=1 and col55 like '%未审批%' ";
            sql2 = "select * from t_caiwu22 where 1=1 and col30 = '0' ";
            sql3 = "select * from t_caiwu2 where 1=1 and col55 not like '%未审批%' ";
            sql4 = "select * from t_caiwu22 where 1=1 and col30 = '1' ";
            sql5 = "select * from t_caiwu5 where 1=1 and col43 like '%未审批%' ";
            sql6 = "select * from t_caiwu5 where 1=1 and col43 not like '%未审批%'  ";

            if (this.Session["RoleValue"].ToString() != "1")
            {
                sql += " and col62 = '" + strUserName + "' ";
                sql2 += " and col41 = '" + strUserName + "' ";
                sql3 += " and col63 like '%" + strUserName + "%' ";
                sql4 += " and col41 = '" + strUserName + "' ";
                sql5 += " and col49 = '" + strUserName + "' ";
                sql6 += " and col50 like '%" + strUserName + "%' ";
            }


            DataTable dt = oledbHelper.GetDataTable(sql);
            DataTable dt2 = oledbHelper.GetDataTable(sql2);
            DataTable dt3 = oledbHelper.GetDataTable(sql3);
            DataTable dt4 = oledbHelper.GetDataTable(sql4);
            DataTable dt5 = oledbHelper.GetDataTable(sql5);
            DataTable dt6 = oledbHelper.GetDataTable(sql6);

            //Label2.Text = dt.Rows.Count.ToString();
            //Label3.Text = dt2.Rows.Count.ToString();
            //Label5.Text = dt3.Rows.Count.ToString();
            //Label6.Text = dt4.Rows.Count.ToString();

            //Label8.Text = dt5.Rows.Count.ToString();
            //Label9.Text = dt6.Rows.Count.ToString();

            //Label1.Text = (dt.Rows.Count + dt2.Rows.Count + dt5.Rows.Count).ToString();
            //Label4.Text = (dt3.Rows.Count + dt4.Rows.Count + dt6.Rows.Count).ToString();


            //adminPager.where = where.ToString();
            //adminPager.parameter = arrayList;
            //adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            //adminPager.OrderType = (bool)this.ViewState["OrderByType"];

            if (strcase == "" || strcase == "3")
            {
                this.GridView1.Visible = true;
                this.GridView2.Visible = false;
                this.GridView3.Visible = false;
                if (strcase == "")
                {
                    Label7.Text = "待办   >开票审批";
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                }
                else
                {
                    Label7.Text = "已办   >开票审批";
                    this.GridView1.DataSource = dt3;
                    this.GridView1.DataBind();
                }
                
            }
            else if (strcase == "2" || strcase == "4")
            {
                this.GridView1.Visible = false;
                this.GridView2.Visible = true;
                this.GridView3.Visible = false;
                if (strcase == "")
                {
                    Label7.Text = "待办   >资料提交";
                    this.GridView2.DataSource = dt2;
                    this.GridView2.DataBind();
                }
                else
                {
                    Label7.Text = "已办   >资料提交";
                    this.GridView2.DataSource = dt4;
                    this.GridView2.DataBind();
                }
               
            }
            else if (strcase == "5" || strcase == "6")
            {
                this.GridView1.Visible = false;
                this.GridView2.Visible = false;
                this.GridView3.Visible = true;
                if (strcase == "")
                {
                    Label7.Text = "待办   >结算审批";
                    this.GridView3.DataSource = dt5;
                    this.GridView3.DataBind();
                }
                else
                {
                    Label7.Text = "已办   >结算审批";
                    this.GridView3.DataSource = dt6;
                    this.GridView3.DataBind();
                }
                
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string stridno = ((Label)e.Row.FindControl("lblcol53")).Text;
                //string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((Label)e.Row.FindControl("lblcol2")).Text = ((Label)e.Row.FindControl("lblcol2")).Text + "开票申请";
                //((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol2")).Text;
                //((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2.aspx?idno=" + strid + "&&id=" + stridno + "&role=审核";
                //if (strcase == "3")
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu2.aspx?idno=" + strid + "&&id=" + stridno + "&model=view";
                //}

            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string stridno = ((Label)e.Row.FindControl("lblcol53")).Text;
                //string strid = ((Label)e.Row.FindControl("lblID")).Text;
                ((Label)e.Row.FindControl("lblcol2")).Text = ((Label)e.Row.FindControl("lblcol2")).Text + "开票申请";
                //((HyperLink)e.Row.FindControl("HyperLink1")).Text = ((Label)e.Row.FindControl("lblcol2")).Text;
                //((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + strid + "&&id=" + stridno + "&role=审核";
                //if (strcase == "6")
                //{
                //    ((HyperLink)e.Row.FindControl("HyperLink1")).NavigateUrl = "caiwu6Add.aspx?idno=" + strid + "&&id=" + stridno + "&model=view";
                //}

            }
        }



    }
}