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
using MojoCube.Web;
using MojoCube.Web.Logistics;
using MojoCube.Api.Excel;
using System.Text;
using System.Text.RegularExpressions;
using MojoCube.Api.SMS;
using MojoCube.Web.SMS;
using MojoCube.Api.File;

namespace CopyMFRubikCubePowerContent.Admin.SMS
{
    public partial class SMSEdit : MyPage, IRequiresSessionState
    {
        private int sdkappid = Convert.ToInt32(Connection.GetConfigValue("sdkappid"));
        private string appkey = Connection.GetConfigValue("appkey");
        private int tmplId = Convert.ToInt32(Connection.GetConfigValue("tmplId"));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string phoneNum=this.txtPhoneNum.Text.Trim();
            string logisticsNo=this.txtLogisticsNo.Text.Trim();
            if (string.IsNullOrEmpty(logisticsNo))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写运单号");
                return;
            }
            if (string.IsNullOrEmpty(phoneNum))
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写手机号");
                return;
            }
            SmsSingleSenderResult singleResult;
            SmsSingleSender singleSender = new SmsSingleSender(sdkappid, appkey);

            List<string> templParams = new List<string>();
            templParams.Add(this.txtLogisticsNo.Text.Trim());
            templParams.Add(this.txtLogisticsNo.Text.Trim());
            singleResult = singleSender.SendWithParam("86", phoneNum, tmplId, templParams, "", "", "");

            SMSList list = new SMSList();
            list.PhoneNum = phoneNum;
            list.LogisticsNo = logisticsNo;
            list.Status = singleResult.errmsg;
            list.CreateTime = DateTime.Now;

            if (list.InsertData() > 0 && singleResult.errmsg == "OK")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "短信发送成功");
                ClearTextBox();
            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "短信发送失败" + singleResult.errmsg);
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            this.txtPhoneNum.Text = "";
            this.txtLogisticsNo.Text = "";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {

                if (checkFile(fuPortrait.PostedFile))
                {
                    ExcelHelper exh = new ExcelHelper();
                    DataTable dt = exh.ExcelToDataTable(this.fuPortrait.PostedFile.InputStream, "", true, this.fuPortrait.PostedFile.FileName);
                    //验证数据
                    List<SMSList> SMSList = checkUploadData(dt);
                    StringBuilder errorMsg = new StringBuilder();
                    foreach (SMSList item in SMSList)
                    {
                        if (!string.IsNullOrEmpty(item.CheckUploadResult))
                            errorMsg.Append(item.CheckUploadResult);
                    }


                    if (string.IsNullOrEmpty(errorMsg.ToString()))
                    {
                        StringBuilder errorBillNo = new StringBuilder();
                        foreach (SMSList item in SMSList)
                        {
                            SmsSingleSenderResult singleResult;
                            SmsSingleSender singleSender = new SmsSingleSender(sdkappid, appkey);

                            List<string> templParams = new List<string>();
                            templParams.Add(item.LogisticsNo);
                            templParams.Add(item.LogisticsNo);
                            singleResult = singleSender.SendWithParam("86", item.PhoneNum, tmplId, templParams, "", "", "");
                            item.Status = singleResult.errmsg;
                            if (item.InsertData() <= 0 || singleResult.errmsg != "OK")
                            {
                                errorBillNo.Append(item.LogisticsNo + ":" + item.PhoneNum + ",");
                            }
                        }
                        if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下运单号：" + errorBillNo.ToString().TrimEnd(',') + "发送短信失败");
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有短信发送成功");
                    }
                    else
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
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

        protected bool checkFile(HttpPostedFile postFileName)
        {
            string postfix = System.IO.Path.GetExtension(postFileName.FileName).ToLower();
            string[] allowPostfixs = { ".xls", ".xlsx" };
            foreach (string allowPostfix in allowPostfixs)
                if (postfix.Equals(allowPostfix)) return true;
            return false;
        }


        protected List<SMSList> checkUploadData(DataTable dt)
        {
            List<SMSList> SMSList = new List<SMSList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SMSList list = new SMSList();
                list.CheckUploadResult = "";
                //运单号
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.LogisticsNo = dt.Rows[i][0].ToString();
                //手机号
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[1].ColumnName);
                else
                    list.PhoneNum = dt.Rows[i][1].ToString();

                
                list.CreateTime = DateTime.Now;

                SMSList.Add(list);
            }
            return SMSList;
        }
        protected void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string filename = "/Admin/UploadTemplates/短信通知批量导入.xls";
            DownloadTemplateFile downloadTemplateFile = new DownloadTemplateFile();
            downloadTemplateFile.DoFileDownload(filename);
        }
    }
}