using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;


namespace CopyMFRubikCubePowerContent.Admin.User
{
    public partial class Admin_User_History : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ViewState["OrderByKey"] = "CreateDate";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                base.Title = "历史记录";
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
            adminPager.TableName = "View_MyHistory";
            adminPager.strGetFields = "*";
            string text = " where fk_User=" + this.Session["UserID"].ToString() + " and TypeID=0";
            ArrayList arrayList = new ArrayList();
            if (this.txtKeyword.Text.Trim() != "")
            {
                string value = CheckSql.Filter(this.txtKeyword.Text.Trim());
                text += " and (Title like '%'+?+'%')";
                arrayList.Add(value);
            }
            adminPager.where = text;
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
                ((HyperLink)e.Row.FindControl("gvView")).NavigateUrl = "../../" + ((Label)e.Row.FindControl("lblUrl")).Text;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
        }
    }
}