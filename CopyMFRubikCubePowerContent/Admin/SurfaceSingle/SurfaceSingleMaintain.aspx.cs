using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using MojoCube.Api.UI;
using MojoCube.Api.Text;
using System.Data;

namespace CopyMFRubikCubePowerContent.Admin.SurfaceSingle
{
    public partial class SurfaceSingleMaintain : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["ID"] != null)
                {
                    this.ViewState["ID"] = Security.DecryptString(base.Request.QueryString["ID"]);
                    MojoCube.Web.SurfaceSingle.SurfaceSingle SurfaceSingle = new MojoCube.Web.SurfaceSingle.SurfaceSingle();
                    SurfaceSingle.GetData(int.Parse(this.ViewState["ID"].ToString()));
                    this.txtStartNo.Text = SurfaceSingle.StartNo;
                    txtStartNo.Enabled = false;
                    this.txtEndNo.Text = SurfaceSingle.EndNo;
                    txtEndNo.Enabled = false;
                    this.txtAmount.Text = SurfaceSingle.Amount;
                    txtAmount.Enabled = false;
                    this.txtCustomer.Text = SurfaceSingle.Customer;
                    this.txtRemark.Text = SurfaceSingle.Remark;
                    return;
                }
                base.Title = "面单管理编辑";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MojoCube.Web.SurfaceSingle.SurfaceSingle SurfaceSingle = new MojoCube.Web.SurfaceSingle.SurfaceSingle();
            if (this.ViewState["ID"] != null)
            {
                SurfaceSingle.GetData(int.Parse(this.ViewState["ID"].ToString()));

                SurfaceSingle.Customer = this.txtCustomer.Text.Trim();
                SurfaceSingle.Remark = this.txtRemark.Text.Trim();
                if (SurfaceSingle.updateData(SurfaceSingle.id) > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                    base.Response.Redirect("SurfaceSingleManager.aspx?active=" + base.Request.QueryString["active"]);
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                }
                //base.Response.Redirect("CurrentExpenses.aspx?active=" + base.Request.QueryString["active"]);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = SurfaceSingle.GetData(txtStartNo.Text.Trim(), txtEndNo.Text.Trim());
                if (dt.Rows.Count>0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已经存在该面单的开始号跟结束号已经存在");
                }
                else
                {
                    SurfaceSingle.StartNo = this.txtStartNo.Text.Trim();
                    SurfaceSingle.EndNo = this.txtEndNo.Text.Trim();
                    SurfaceSingle.Amount = this.txtAmount.Text.Trim();
                    SurfaceSingle.Customer = this.txtCustomer.Text.Trim();
                    SurfaceSingle.Remark = this.txtRemark.Text.Trim();
                    SurfaceSingle.CreateDate = System.DateTime.Now;
                    if (SurfaceSingle.InsertData() > 0)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                        ClearText();
                    }
                    else
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                    }
                }
                //this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");

            }
            //base.Response.Redirect("ReturnMoneyManager.aspx?active=" + base.Request.QueryString["active"]);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //if (this.ViewState["ID"] != null)
            //{
            //base.Response.Redirect("ReturnMoneyManager.aspx?active=" + base.Request.QueryString["active"]);
            //}
            this.AlertDiv.InnerHtml = "";
        }
        public void ClearText()
        {
            this.txtStartNo.Text = "";
            this.txtEndNo.Text = "";
            this.txtAmount.Text = "";
            this.txtCustomer.Text = "";
            this.txtRemark.Text = "";
        }
    }
}