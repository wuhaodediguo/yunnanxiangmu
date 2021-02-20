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

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class shangchuan5 : System.Web.UI.Page
    {
        public string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                id = base.Request.QueryString["id"].ToString();
            }

            if (id == "caiwu1")
            {
                title.Text = "外经证管理导入页面";
            }
           

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            if (id == "caiwu1")
            {
                Response.Redirect("caiwu1.aspx", false);
            }
           
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            try
            {

                if (checkFile(fuPortrait.PostedFile))
                {
                    ExcelHelper exh = new ExcelHelper();
                    DataTable dt = exh.ExcelToDataTable(this.fuPortrait.PostedFile.InputStream, "", true, fuPortrait.PostedFile.FileName);
                    //验证数据

                    if (dt == null)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "文件没有数据");
                        return;
                    }


                    if (id == "caiwu1")
                    {
                        List<caiwu1List> caiwu1List = checkUploadData(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (caiwu1List item in caiwu1List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (caiwu1List item in caiwu1List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_caiwu1 where col12='" + item.col12 + "' ");
                                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                    item.UpdateData(item.ID);
                                }
                                else
                                {
                                    if (item.InsertData() <= 0)
                                    {
                                        errorBillNo.Append(item.col12 + ",");
                                    }
                                }

                            }
                            if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下管理编号：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");

                            }


                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    

                }
                else
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择导入文件和正确文件格式");
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

        protected List<caiwu1List> checkUploadData(DataTable dt)
        {
            List<caiwu1List> caiwu1List = new List<caiwu1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                caiwu1List list = new caiwu1List();
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

                list.col31 = dt.Rows[i][5].ToString().Trim();

                list.col5 = dt.Rows[i][6].ToString().Trim();
                list.col6 = dt.Rows[i][7].ToString().Trim();
                list.col7 = dt.Rows[i][8].ToString().Trim();
                list.col8 = dt.Rows[i][9].ToString().Trim();
                list.col9 = dt.Rows[i][10].ToString();
                list.col10 = dt.Rows[i][11].ToString();
                list.col11 = dt.Rows[i][12].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][13].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[13].ColumnName);
                else
                    list.col12 = dt.Rows[i][13].ToString();
                
               
                list.col13 = dt.Rows[i][14].ToString();
                list.col14 = dt.Rows[i][15].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][15].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col15 = dt.Rows[i][16].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][16].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col16 = dt.Rows[i][17].ToString().Trim();
                list.col17 = dt.Rows[i][18].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][18].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col18 = dt.Rows[i][19].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][19].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col19 = dt.Rows[i][20].ToString().Trim();
                list.col20 = dt.Rows[i][21].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][21].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col21 = dt.Rows[i][22].ToString();
                list.col22 = dt.Rows[i][23].ToString();
                list.col23 = dt.Rows[i][24].ToString();
                list.col24 = dt.Rows[i][25].ToString();
                list.col25 = dt.Rows[i][26].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][26].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col26 = dt.Rows[i][27].ToString();
                list.col27 = dt.Rows[i][28].ToString();
                list.col28 = dt.Rows[i][29].ToString();
                list.col29 = dt.Rows[i][30].ToString();
                list.col30 = "";

                list.col32 = "0";
                string strlblcol15 = list.col15.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (strlblcol15 == "")
                {
                }
                else
                {
                    string strlblcol17 = list.col17.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                    if (strlblcol17 == "")
                    {
                        if (DateTime.Compare(Convert.ToDateTime(strlblcol15), Convert.ToDateTime(DateTime.Now.AddDays(15).ToString("yyyy-MM-dd"))) <= 0)
                        {
                            list.col32 = "1";
                        }
                    }
                    else
                    {
                        string strlblcol18 = list.col18.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                        if (strlblcol18 != "")
                        {
                            if (DateTime.Compare(Convert.ToDateTime(strlblcol18), Convert.ToDateTime(DateTime.Now.AddDays(15).ToString("yyyy-MM-dd"))) <= 0)
                            {
                                list.col32 = "1";
                            }
                        }

                    }

                }
                
                caiwu1List.Add(list);
            }
            return caiwu1List;
        }


    }
}