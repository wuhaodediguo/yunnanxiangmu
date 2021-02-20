using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.CurrentExpenses;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using MojoCube.Api.Excel;
using MojoCube.Api.ExcelEx1;
using System.Text;
using System.IO;
using MojoCube.Api.File;

namespace CopyMFRubikCubePowerContent.Admin.BaseData
{
    public partial class pinzhongEdit : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                base.Title = "品名编辑";
            
                //this.hlBack.NavigateUrl = "CurrentExpenses.aspx?active=" + base.Request.QueryString["active"];
                if (base.Request.QueryString["id"] != null)
                {
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();
                    MojoCube.Web.CurrentExpenses.pinzhongList pinzhongList = new MojoCube.Web.CurrentExpenses.pinzhongList();
                    pinzhongList.GetData(int.Parse(this.ViewState["ID"].ToString()));
                    this.ddlIE.SelectedValue = pinzhongList.shiyongbiaoji;

                    txtpinming.Text = pinzhongList.pinzhong;
                    txtremark.Text = pinzhongList.remark;
        

                    //return;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpinming.Text))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "不能为空，请正确填写");
                return;
            }
            pinzhongList pinzhongList = new pinzhongList();
            pinzhongList.shiyongbiaoji = ddlIE.SelectedValue;
            pinzhongList.pinzhong = txtpinming.Text;
            pinzhongList.remark = txtremark.Text.Trim();
            
            if (this.ViewState["ID"] != null)
            {
                pinzhongList.ID = int.Parse(this.ViewState["ID"].ToString());
                pinzhongList.UpdateData();
                base.Response.Redirect("pinzhong.aspx?active=" + base.Request.QueryString["active"]);
            }
            else
            {
                pinzhongList.InsertData();
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");

                txtpinming.Text = "";
                txtremark.Text = "";
            }
            //base.Response.Redirect("pinzhong.aspx?active=" + base.Request.QueryString["active"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //if (this.ViewState["ID"] != null)
            //{
            base.Response.Redirect("pinzhong.aspx?active=" + base.Request.QueryString["active"]);
            //}
            this.AlertDiv.InnerHtml = "";
        }

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkFile(fuPortrait.PostedFile))
                {
                    if (!fuPortrait.FileName.Contains("收入") && !fuPortrait.FileName.Contains("支出"))
                        throw new Exception("请使用正确的收入/支出模板");
                    DataSet ds = null;
                    string IEType = string.Empty;
                    string CostItem = string.Empty;
                    if (fuPortrait.FileName.Contains("收入"))
                    {
                        IEType = "收入";
                        CostItem = "代收货款,包装费,面单费,公司借款,罚款,理赔款,税点,其他,提现";
                    }
                    else if (fuPortrait.FileName.Contains("支出"))
                    {
                        IEType = "支出";
                        CostItem = "系统充值,工资,代收货款,上楼费,物品购买,油卡充值,车辆维修,罚款,理赔款,手续费,其他,提现";
                    }
                    ds = ExcelHelperEx1.GetDataTableFromExcel(this.fuPortrait.PostedFile.InputStream, CostItem, true);
                    foreach (DataTable dtTemp in ds.Tables)
                    {
                        //InsertCurrentExp(dtTemp, IEType, dtTemp.TableName);
                    }
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择上传文件和正确文件格式");
                }
            }
            catch (Exception ex)
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", ex.ToString());
            }
        }
        
    }
}