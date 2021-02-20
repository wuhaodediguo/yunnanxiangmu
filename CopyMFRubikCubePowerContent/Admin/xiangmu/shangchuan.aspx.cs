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
    public partial class shangchuan : System.Web.UI.Page
    {
        public string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                id = base.Request.QueryString["id"].ToString();
            }
            if (id == "shichang1")
            {
                title.Text = "投标管理导入页面";
                Label1.Text = "投标管理导入页面";
            }
            else if (id == "shichang2")
            {
                title.Text = "中标管理导入页面";
                Label1.Text = "中标管理导入页面";
            }
            else if (id == "shichang3")
            {
                title.Text = "客商管理导入页面";
                Label1.Text = "客商管理导入页面";
            }
            else if (id == "hetong1")
            {
                title.Text = "施工合同管理导入页面";
            }
            else if (id == "hetong2")
            {
                title.Text = "合作合同管理导入页面";
            }
            else if (id == "hetong3")
            {
                title.Text = "采购合同管理导入页面";
            }
           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (id == "shichang1")
            {
                Response.Redirect("shichang1.aspx", false);
            }
            else if (id == "shichang2")
            {
                Response.Redirect("shichang2.aspx", false);
            }
            else if (id == "shichang3")
            {
                Response.Redirect("shichang3.aspx", false);
            }
            else if (id == "hetong1")
            {
                Response.Redirect("hetong1.aspx", false);
            }
            else if (id == "hetong2")
            {
                Response.Redirect("hetong2.aspx", false);
            }
            else if (id == "hetong3")
            {
                Response.Redirect("hetong3.aspx", false);
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


                    if (id == "shichang1")
                    {
                        List<shichangList> shichangList = checkUploadData(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (shichangList item in shichangList)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }

                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (shichangList item in shichangList)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_shichang where col4='" + item.col4 + "' and col5='" + item.col5 + "' and col9='" + item.col9 + "' and col10='" + item.col10 + "' ");
                                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                    item.UpdateData(item.ID);
                                }
                                else
                                {
                                    if (item.InsertData() <= 0)
                                    {
                                        errorBillNo.Append(item.col2 + ",");
                                    }
                                }

                            }
                            if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下招标人：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
                                //this.GridBind();
                            }
                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    else if (id == "shichang2")
                    {
                        List<shichangList> shichangList = checkUploadData2(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (shichangList item in shichangList)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (shichangList item in shichangList)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_shichang where col4='" + item.col4 + "' and col5='" + item.col5 + "' and col24='" + item.col24 + "' and col27='" + item.col27 + "' ");
                                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                    item.UpdateData(item.ID);
                                }
                                else
                                {
                                    if (item.InsertData() <= 0)
                                    {
                                        errorBillNo.Append(item.col1 + ",");
                                    }
                                }

                            }
                            if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下中标人：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
                            }

                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    else if (id == "shichang3")
                    {
                        List<keshangList> keshangList = checkUploadData3(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (keshangList item in keshangList)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (keshangList item in keshangList)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_keshang where col2='" + item.col2 + "' and col1='" + item.col1 + "' and col3='" + item.col3 + "' and col4='" + item.col4 + "' ");
                                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                    item.UpdateData(item.ID);
                                }
                                else
                                {
                                    if (item.InsertData() <= 0)
                                    {
                                        errorBillNo.Append(item.col1 + ",");
                                    }
                                }

                            }
                            if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下客户：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
                               
                            }


                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    else if (id == "hetong1")
                    {
                        Response.Redirect("hetong1.aspx", false);
                    }
                    else if (id == "hetong2")
                    {
                        Response.Redirect("hetong2.aspx", false);
                    }
                    else if (id == "hetong3")
                    {
                        Response.Redirect("hetong3.aspx", false);
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

        protected List<shichangList> checkUploadData(DataTable dt)
        {
            List<shichangList> shichangList = new List<shichangList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                shichangList list = new shichangList();
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
                if (string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[5].ColumnName);
                else
                    list.col5 = dt.Rows[i][5].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[6].ColumnName);
                else
                    list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][7].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col8 = dt.Rows[i][9].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][9].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");

                if (string.IsNullOrEmpty(dt.Rows[i][10].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[9].ColumnName);
                else
                    list.col9 = dt.Rows[i][10].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][11].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[10].ColumnName);
                else
                    list.col10 = dt.Rows[i][11].ToString();

                //list.col9 = dt.Rows[i][9].ToString().Trim();
                //list.col10 = dt.Rows[i][10].ToString().Trim();
                list.col11 = dt.Rows[i][12].ToString().Trim();
                list.col12 = dt.Rows[i][13].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][13].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col13 = dt.Rows[i][14].ToString().Trim();
                list.col14 = dt.Rows[i][15].ToString().Trim();
                list.col15 = dt.Rows[i][16].ToString();
                
                //list.col17 = dt.Rows[i][17].ToString();
                //list.col18 = dt.Rows[i][18].ToString();
                //list.col19 = dt.Rows[i][19].ToString();
                //list.col20 = dt.Rows[i][20].ToString();
                //list.col21 = dt.Rows[i][21].ToString();
                //list.col22 = dt.Rows[i][22].ToString();
                //list.col23 = dt.Rows[i][23].ToString();

                list.col42 = dt.Rows[i][17].ToString();
                list.col16 = dt.Rows[i][18].ToString();
                list.col17 = dt.Rows[i][19].ToString();
                list.col18 = dt.Rows[i][20].ToString();
                list.col19 = dt.Rows[i][21].ToString();
                list.col20 = dt.Rows[i][22].ToString();
                list.col21 = dt.Rows[i][23].ToString();
                list.col22 = dt.Rows[i][24].ToString();
                list.col23 = dt.Rows[i][25].ToString();

                list.col24 = "";
                list.col25 = "";
                list.col26 = "";
                list.col27 = "";
                list.col28 = "";
                list.col29 = "";
                list.col30 = "";
                list.col31 = "";
                list.col32 = "";
                list.col33 = "";
                list.col34 = "";
                list.col35 = "";
                list.col36 = "";
                list.col37 = "";
                list.col38 = "";
                list.col39 = "0";
                list.col40 = this.Session["FullName"].ToString();
                list.col41 = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                list.col43 = "";
                list.col44 = dt.Rows[i][8].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][8].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");

                list.col45 = "0";
                string strlblcol42 = list.col42.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (strlblcol42 == "")
                {
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strlblcol42), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) <= 0)
                    {
                        list.col45 = "1";
                    }
                }

                shichangList.Add(list);
            }
            return shichangList;
        }

        protected List<shichangList> checkUploadData2(DataTable dt)
        {
            List<shichangList> shichangList = new List<shichangList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                shichangList list = new shichangList();
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
                if (string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[5].ColumnName);
                else
                    list.col5 = dt.Rows[i][5].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[6].ColumnName);
                else
                    list.col6 = dt.Rows[i][6].ToString();
                list.col24 = dt.Rows[i][7].ToString();
                list.col25 = dt.Rows[i][8].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][8].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col26 = dt.Rows[i][9].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][9].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col27 = dt.Rows[i][10].ToString();
                list.col28 = dt.Rows[i][11].ToString();
                list.col29 = dt.Rows[i][12].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][12].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col30 = dt.Rows[i][13].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][13].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col31 = dt.Rows[i][14].ToString();
                list.col32 = dt.Rows[i][15].ToString();
                list.col33 = dt.Rows[i][16].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][16].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");

                list.col43 = dt.Rows[i][17].ToString();
                list.col34 = dt.Rows[i][18].ToString();
                list.col35 = dt.Rows[i][19].ToString();
                list.col36 = dt.Rows[i][20].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][20].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col40 = dt.Rows[i][21].ToString().Trim();
                list.col41 = dt.Rows[i][22].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][22].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col37 = dt.Rows[i][23].ToString();
                list.col38 = dt.Rows[i][24].ToString();
                list.col23 = dt.Rows[i][25].ToString();

                //list.col34 = dt.Rows[i][17].ToString();
                //list.col35 = dt.Rows[i][18].ToString();
                //list.col36 = dt.Rows[i][19].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][19].ToString().Trim()).ToString("yyyy/MM/dd");
                //list.col40 = dt.Rows[i][20].ToString().Trim();
                //list.col41 = dt.Rows[i][21].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][21].ToString().Trim()).ToString("yyyy/MM/dd");
                //list.col37 = dt.Rows[i][22].ToString();
                //list.col38 = dt.Rows[i][23].ToString();
                //list.col23 = dt.Rows[i][24].ToString();
                list.col7 = "";
                list.col8 = "";
                list.col9 = "";
                list.col10 = "";
                list.col11 = "";
                list.col12 = "";
                list.col13 = "";
                list.col14 = "";
                list.col15 = "";
                list.col16 = "";
                list.col17 = "";
                list.col18 = "";
                list.col19 = "";
                list.col20 = "";
                list.col21 = "";
                list.col22 = "";
                list.col39 = "1";
                list.col42 = "";
                list.col44 = "";

                list.col45 = "0";
                string strlblcol42 = list.col43.Replace("年", "").Replace("月", "").Replace("日", "").Trim();
                if (strlblcol42 == "")
                {
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(strlblcol42), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) <= 0)
                    {
                        list.col45 = "1";
                    }
                }

                shichangList.Add(list);
            }
            return shichangList;
        }


        protected List<keshangList> checkUploadData3(DataTable dt)
        {
            List<keshangList> keshangList = new List<keshangList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                keshangList list = new keshangList();
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
                if (string.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[5].ColumnName);
                else
                    list.col5 = dt.Rows[i][5].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[6].ColumnName);
                else
                    list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString();
                list.col8 = dt.Rows[i][8].ToString();
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString();
                list.col15 = dt.Rows[i][15].ToString();
                list.col16 = dt.Rows[i][16].ToString();


                keshangList.Add(list);
            }
            return keshangList;
        }





    }
}