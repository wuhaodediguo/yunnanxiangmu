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
    public partial class shangchuan4 : System.Web.UI.Page
    {
        public string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                id = base.Request.QueryString["id"].ToString();
            }

            if (id == "hezuo1")
            {
                title.Text = "合作单位管理导入页面";
            }
            else if (id == "hezuo2")
            {
                title.Text = "施工队伍管理导入页面";
            }
            else if (id == "hezuo3")
            {
                title.Text = "施工队结算管理导入页面";
            }
            else if (id == "hezuo4")
            {
                title.Text = "施工队结算明细导入页面";
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            if (id == "hezuo1")
            {
                Response.Redirect("hezuo1.aspx", false);
            }
            else if (id == "hezuo2")
            {
                Response.Redirect("hezuo2.aspx", false);
            }
            else if (id == "hezuo3")
            {
                Response.Redirect("hezuo3.aspx", false);
            }
            else if (id == "hezuo4")
            {
                Response.Redirect("hezuo4Add.aspx", false);
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


                    if (id == "hezuo1")
                    {
                        List<hezuo1List> hezuo1List = checkUploadData(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hezuo1List item in hezuo1List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hezuo1List item in hezuo1List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hezuo1 where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
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
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下合同：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
                               
                            }


                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    else if (id == "hezuo2")
                    {
                        List<hezuo2List> hezuo2List = checkUploadData2(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hezuo2List item in hezuo2List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hezuo2List item in hezuo2List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hezuo2 where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
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
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下合同：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");

                            }


                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    else if (id == "hezuo3")
                    {
                        List<hezuo3List> hezuo3List = checkUploadData3(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hezuo3List item in hezuo3List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hezuo3List item in hezuo3List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hezuo3 where col2='" + item.col2 + "' and col1='" + item.col1 + "' and col3='" + item.col3 + "' ");
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
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下合同：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                            else
                            {
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");

                            }


                        }
                        else
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", errorMsg.ToString());
                    }
                    else if (id == "hezuo4")
                    {
                        List<hezuo4List> hezuo4List = checkUploadData4(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hezuo4List item in hezuo4List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hezuo4List item in hezuo4List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hezuo4 where col2='" + item.col2 + "' and col1='" + item.col1 + "' and col3='" + item.col3 + "' ");
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
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下合同：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
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

        protected List<hezuo1List> checkUploadData(DataTable dt)
        {
            List<hezuo1List> hezuo1List = new List<hezuo1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hezuo1List list = new hezuo1List();
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
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString().Trim();
                list.col15 = dt.Rows[i][15].ToString();
                list.col16 = dt.Rows[i][16].ToString();
                list.col17 = dt.Rows[i][17].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][17].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col18 = dt.Rows[i][18].ToString();
                list.col19 = dt.Rows[i][19].ToString();
                list.col20 = dt.Rows[i][20].ToString();
                list.col21 = dt.Rows[i][21].ToString();
                

                hezuo1List.Add(list);
            }
            return hezuo1List;
        }

        protected List<hezuo2List> checkUploadData2(DataTable dt)
        {
            List<hezuo2List> hezuo2List = new List<hezuo2List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hezuo2List list = new hezuo2List();
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

                string[] 施工能力list;
                string str1 = string.Empty;
                string str2 = string.Empty;
                if (dt.Rows[i][11].ToString().Trim() != "")
                {
                    施工能力list = dt.Rows[i][11].ToString().Trim().Split(':');
                    if (施工能力list[0] != null)
                    {
                        str1 = 施工能力list[0];
                    }
                    if (施工能力list[1] != null)
                    {
                        str2 = 施工能力list[1];
                    }
                }
                list.col11 = str1;
                list.col12 = str2;
                list.col13 = dt.Rows[i][12].ToString();
                list.col14 = dt.Rows[i][13].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][13].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col15 = dt.Rows[i][14].ToString();
                list.col16 = dt.Rows[i][15].ToString();
                list.col17 = dt.Rows[i][16].ToString();
               

                hezuo2List.Add(list);
            }
            return hezuo2List;
        }

        protected List<hezuo3List> checkUploadData3(DataTable dt)
        {
            List<hezuo3List> hezuo3List = new List<hezuo3List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hezuo3List list = new hezuo3List();
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
                list.col12 = dt.Rows[i][12].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][12].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col13 = dt.Rows[i][13].ToString();
               


                hezuo3List.Add(list);
            }
            return hezuo3List;
        }

        protected List<hezuo4List> checkUploadData4(DataTable dt)
        {
            List<hezuo4List> hezuo4List = new List<hezuo4List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hezuo4List list = new hezuo4List();
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
                list.col12 = dt.Rows[i][12].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][12].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col13 = dt.Rows[i][13].ToString();



                hezuo4List.Add(list);
            }
            return hezuo4List;
        }




    }
}