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
    public partial class shangchuan3 : System.Web.UI.Page
    {
        public string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                id = base.Request.QueryString["id"].ToString();
            }

            if (id == "xiangmu1")
            {
                title.Text = "项目立项管理导入页面";
            }
            else if (id == "xiangmu8")
            {
                title.Text = "项目月报管理导入页面";
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            if (id == "xiangmu1")
            {
                Response.Redirect("xiangmu1.aspx", false);
            }
            else if (id == "xiangmu2")
            {
                Response.Redirect("xiangmu2.aspx", false);
            }
            else if (id == "xiangmu3")
            {
                Response.Redirect("xiangmu3.aspx", false);
            }
            else if (id == "xiangmu8")
            {
                string lblcol1 = base.Request.QueryString["lblcol1"];
                string lblcol2 = base.Request.QueryString["lblcol2"];
                string lblcol3 = base.Request.QueryString["lblcol3"];
                string lblcol4 = base.Request.QueryString["lblcol4"];
                Response.Redirect("xiangmu8.aspx?lblcol1=" + lblcol1 + "&lblcol2=" + lblcol2 + "&lblcol3=" + lblcol3 + "&lblcol4=" + lblcol4 + "", false);
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


                    if (id == "xiangmu1")
                    {
                        List<xiangmu1List> xiangmu1List = checkUploadData(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (xiangmu1List item in xiangmu1List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (xiangmu1List item in xiangmu1List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu1 where col8='" + item.col8 + "' and col9='" + item.col9 + "' and col5='" + item.col5 + "' and col31='" + item.col31 + "' ");
                                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                                {
                                    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                    item.UpdateData(item.ID);
                                }
                                else
                                {
                                    //xiangmu1List shichangList = new xiangmu1List();
                                    //shichangList.col8 = item.col8.Trim();
                                    //shichangList.col9 = item.col9.Trim();
                                    //shichangList.col31 = item.col31.Trim();

                                    //shichangList.GetAllData2(shichangList.col8, shichangList.col9, shichangList.col31);
                                    //if (shichangList.ID > 0)
                                    //{
                                    //    errorBillNo.Append(item.col8 + "," + item.col9 + "," + item.col31 + ",已存在");
                                    //    continue;
                                    //}
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
                    else if (id == "xiangmu8")
                    {
                        List<xiangmu3List> xiangmu3List = checkUploadData2(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (xiangmu3List item in xiangmu3List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (xiangmu3List item in xiangmu3List)
                            {
                                if (item.InsertData() <= 0)
                                {
                                    errorBillNo.Append(item.col2 + ",");
                                }
                                //DataSet ds = Sql.SqlQueryDS("select * from t_xiangmu3 where col1='" + item.col1 + "' and col2='" + item.col2 + "' and col3='" + item.col3 + "' and col4='" + item.col4 + "' ");
                                //if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                                //{
                                //    item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                //    item.UpdateData(item.ID);
                                //}
                                //else
                                //{
                                //    //xiangmu1List shichangList = new xiangmu1List();
                                //    //shichangList.col8 = item.col8.Trim();
                                //    //shichangList.col9 = item.col9.Trim();
                                //    //shichangList.col31 = item.col31.Trim();

                                //    //shichangList.GetAllData2(shichangList.col8, shichangList.col9, shichangList.col31);
                                //    //if (shichangList.ID > 0)
                                //    //{
                                //    //    errorBillNo.Append(item.col8 + "," + item.col9 + "," + item.col31 + ",已存在");
                                //    //    continue;
                                //    //}
                                //    if (item.InsertData() <= 0)
                                //    {
                                //        errorBillNo.Append(item.col2 + ",");
                                //    }
                                //}

                            }
                            if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下月度：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
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

        protected List<xiangmu1List> checkUploadData(DataTable dt)
        {
            List<xiangmu1List> xiangmu1List = new List<xiangmu1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                xiangmu1List list = new xiangmu1List();
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
                if (string.IsNullOrEmpty(dt.Rows[i][7].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[7].ColumnName);
                else
                    list.col7 = dt.Rows[i][7].ToString();

                string hdst = "";
                DataSet ds = Sql.SqlQueryDS("select * from t_hetong where col1='" + list.col1 + "' and col2='" + list.col2 + "' ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["col8"].ToString() == list.col6 || ds.Tables[0].Rows[0]["col23"].ToString() == list.col6 || ds.Tables[0].Rows[0]["col26"].ToString() == list.col6)
                    {
                        hdst = ds.Tables[0].Rows[0]["id"].ToString();
                    }
                    else
                    {
                        string tem = ds.Tables[0].Rows[0]["col8"].ToString() + "," + ds.Tables[0].Rows[0]["col23"].ToString() + "," + ds.Tables[0].Rows[0]["col26"].ToString();
                        list.CheckUploadResult += string.Format("第 {0} 行项目部列不属于该合同编号，该合同编号含有的项目部是：{1}", (i + 1).ToString(),tem);
                    }
                }
                else
                {
                    list.CheckUploadResult += string.Format("第 {0} 行合同名称编号列不存在，", (i + 1).ToString());
                }

                if (string.IsNullOrEmpty(dt.Rows[i][8].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[8].ColumnName);
                else
                    list.col8 = dt.Rows[i][8].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][9].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[9].ColumnName);
                else
                    list.col9 = dt.Rows[i][9].ToString();
                //list.col8 = dt.Rows[i][8].ToString();
                //list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][12].ToString().Trim();
                list.col12 = dt.Rows[i][13].ToString().Trim();
                //list.col13 = dt.Rows[i][14].ToString();
                string temp1 = list.col11 == "" ? "0" : list.col11;
                string temp2 = list.col12 == "" ? "0" : list.col12;
                if (temp2.Contains("%"))
                {
                    temp2 = (Convert.ToDecimal(temp2.Replace("%", "")) / 100).ToString("F2");
                }
                list.col13 = (Convert.ToDecimal(temp1) * Convert.ToDecimal(temp2)).ToString("F2");
                string temp3 = list.col13 == "" ? "0" : list.col13;
                list.col14 = (Convert.ToDecimal(temp1) + Convert.ToDecimal(temp3)).ToString("F2");
                list.col15 = dt.Rows[i][16].ToString();
                list.col16 = dt.Rows[i][17].ToString();
                string temp4 = list.col15 == "" ? "0" : list.col15;
                string temp5 = list.col16 == "" ? "0" : list.col16;
                if (temp5.Contains("%"))
                {
                    temp5 = (Convert.ToDecimal(temp5.Replace("%", "")) / 100).ToString("F2");
                }
                list.col17 = (Convert.ToDecimal(temp4) * Convert.ToDecimal(temp5)).ToString("F2");
                string temp7 = list.col17 == "" ? "0" : list.col17;
                list.col18 = (Convert.ToDecimal(temp4) + Convert.ToDecimal(temp7)).ToString("F2");
                //list.col17 = dt.Rows[i][18].ToString();
                //list.col18 = dt.Rows[i][19].ToString();
                list.col19 = dt.Rows[i][20].ToString();
                list.col20 = dt.Rows[i][21].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][21].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col21 = dt.Rows[i][22].ToString();
                list.col22 = "";
                list.col23 = "";
                list.col24 = "";
                list.col25 = "";
                list.col26 = "";
                list.col27 = "";
                list.col28 = "";
                list.col29 = "";
                list.col30 = "正常";
                list.col31 = dt.Rows[i][11].ToString();
                list.col32 = "";
                list.col33 = hdst;

                xiangmu1List.Add(list);
            }
            return xiangmu1List;
        }

        protected List<xiangmu3List> checkUploadData2(DataTable dt)
        {
            List<xiangmu3List> xiangmu3List = new List<xiangmu3List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                xiangmu3List list = new xiangmu3List();
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
                if (string.IsNullOrEmpty(dt.Rows[i][7].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[7].ColumnName);
                else
                    list.col7 = dt.Rows[i][7].ToString();

                string hdst = "";
                DataSet ds = Sql.SqlQueryDS("select * from t_hetong where col1='" + list.col5 + "' and col2='" + list.col6 + "' ");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    //if (ds.Tables[0].Rows[0]["col8"].ToString() == list.col6 || ds.Tables[0].Rows[0]["col23"].ToString() == list.col6 || ds.Tables[0].Rows[0]["col26"].ToString() == list.col6)
                    //{
                    //    hdst = ds.Tables[0].Rows[0]["id"].ToString();
                    //}
                    //else
                    //{
                    //    string tem = ds.Tables[0].Rows[0]["col8"].ToString() + "," + ds.Tables[0].Rows[0]["col23"].ToString() + "," + ds.Tables[0].Rows[0]["col26"].ToString();
                    //    list.CheckUploadResult += string.Format("第 {0} 行项目部列不属于该合同编号，该合同编号含有的项目部是：{1}", (i + 1).ToString(), tem);
                    //}
                }
                else
                {
                    list.CheckUploadResult += string.Format("第 {0} 行合同名称编号列不存在，", (i + 1).ToString());
                }

                if (string.IsNullOrEmpty(dt.Rows[i][8].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[8].ColumnName);
                else
                    list.col8 = dt.Rows[i][8].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][9].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[9].ColumnName);
                else
                    list.col9 = dt.Rows[i][9].ToString();

                list.col10 = dt.Rows[i][10].ToString().Trim();
                list.col11 = dt.Rows[i][11].ToString().Trim();
                list.col12 = dt.Rows[i][12].ToString().Trim();
                list.col13 = dt.Rows[i][13].ToString().Trim();
                list.col14 = dt.Rows[i][14].ToString().Trim();
                list.col15 = dt.Rows[i][15].ToString().Trim();
                list.col16 = dt.Rows[i][16].ToString().Trim();
                list.col17 = dt.Rows[i][17].ToString().Trim();
                list.col18 = dt.Rows[i][18].ToString().Trim();
                list.col19 = dt.Rows[i][19].ToString().Trim();
                list.col20 = "";
                
                xiangmu3List.Add(list);
            }
            return xiangmu3List;
        }

    

    }
}