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
    public partial class shangchuan2 : System.Web.UI.Page
    {
        public string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                id = base.Request.QueryString["id"].ToString();
            }
            
            if (id == "hetong1")
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
           
            if (id == "hetong1")
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


                    if (id == "hetong1")
                    {
                        List<hetong1List> hetong1List = checkUploadData(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hetong1List item in hetong1List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hetong1List item in hetong1List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hetong where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
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
                    else if (id == "hetong2")
                    {
                        List<hetong2List> hetong2List = checkUploadData2(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hetong2List item in hetong2List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hetong2List item in hetong2List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hetong2 where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
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
                    else if (id == "hetong3")
                    {
                        List<hetong3List> hetong3List = checkUploadData3(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (hetong3List item in hetong3List)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (hetong3List item in hetong3List)
                            {
                                DataSet ds = Sql.SqlQueryDS("select * from t_hetong3 where col2='" + item.col2 + "' and col1='" + item.col1 + "' ");
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

        protected List<hetong1List> checkUploadData(DataTable dt)
        {
            List<hetong1List> hetong1List = new List<hetong1List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hetong1List list = new hetong1List();
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
                    list.col3 = dt.Rows[i][3].ToString().Trim();
                list.col4 = dt.Rows[i][4].ToString().Trim();
                list.col5 = dt.Rows[i][5].ToString().Trim();
                list.col6 = dt.Rows[i][6].ToString().Trim();
                list.col7 = dt.Rows[i][7].ToString().Trim();
                list.col8 = dt.Rows[i][8].ToString().Trim();
                list.col9 = dt.Rows[i][9].ToString().Trim();
                list.col10 = dt.Rows[i][10].ToString().Trim();

                list.col23 = dt.Rows[i][11].ToString().Trim();
                list.col24 = dt.Rows[i][12].ToString().Trim();
                list.col25 = dt.Rows[i][13].ToString().Trim();
                list.col26 = dt.Rows[i][14].ToString().Trim();
                list.col27 = dt.Rows[i][15].ToString().Trim();
                list.col28 = dt.Rows[i][16].ToString().Trim();

                list.col31 = dt.Rows[i][17].ToString().Trim();
                list.col32 = dt.Rows[i][18].ToString().Trim();
                list.col33 = dt.Rows[i][19].ToString().Trim();
                list.col34 = dt.Rows[i][20].ToString().Trim();
                list.col35 = dt.Rows[i][21].ToString().Trim();
                list.col36 = dt.Rows[i][22].ToString().Trim();
                list.col37 = dt.Rows[i][23].ToString().Trim();
                list.col38 = dt.Rows[i][24].ToString().Trim();
                list.col39 = dt.Rows[i][25].ToString().Trim();



                list.col11 = dt.Rows[i][26].ToString().Trim();
                list.col12 = dt.Rows[i][27].ToString().Trim();
                list.col13 = dt.Rows[i][29].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][19].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col14 = dt.Rows[i][29].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][20].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col15 = dt.Rows[i][30].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][21].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col16 = dt.Rows[i][31].ToString();

                list.col17 = dt.Rows[i][32].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][23].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col18 = dt.Rows[i][33].ToString();
                list.col19 = dt.Rows[i][34].ToString();
                list.col20 = dt.Rows[i][35].ToString();
                list.col21 = dt.Rows[i][36].ToString();
                list.col22 = dt.Rows[i][37].ToString();
               
                hetong1List.Add(list);
            }
            return hetong1List;
        }

        protected List<hetong2List> checkUploadData2(DataTable dt)
        {
            List<hetong2List> hetong2List = new List<hetong2List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hetong2List list = new hetong2List();
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
                list.col4 = dt.Rows[i][4].ToString();
                list.col5 = dt.Rows[i][5].ToString();
                list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString();
                list.col8 = dt.Rows[i][8].ToString().Trim();
                list.col9 = dt.Rows[i][9].ToString();
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString().Trim();
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString();
                list.col15 = dt.Rows[i][15].ToString();
                list.col16 = dt.Rows[i][16].ToString().Trim();
                list.col17 = dt.Rows[i][17].ToString();
                list.col18 = dt.Rows[i][18].ToString();
                list.col19 = dt.Rows[i][19].ToString();
                list.col20 = dt.Rows[i][20].ToString();
                list.col21 = dt.Rows[i][21].ToString().Trim();
                list.col22 = dt.Rows[i][22].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][22].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col23 = dt.Rows[i][23].ToString();
                list.col24 = dt.Rows[i][24].ToString();
                list.col25 = dt.Rows[i][25].ToString();
                list.col26 = dt.Rows[i][26].ToString();
                list.col27 = dt.Rows[i][27].ToString();
                list.col28 = dt.Rows[i][28].ToString();
                list.col29 = dt.Rows[i][29].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][29].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col30 = dt.Rows[i][30].ToString();
                list.col31 = dt.Rows[i][31].ToString();
                list.col32 = dt.Rows[i][32].ToString();
                list.col33 = dt.Rows[i][33].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i][33].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col34 = dt.Rows[i][34].ToString();
                list.col35 = dt.Rows[i][35].ToString();
                list.col36 = dt.Rows[i][36].ToString();
                list.col37 = dt.Rows[i][37].ToString();
                list.col38 = dt.Rows[i][38].ToString();
                list.col39 = dt.Rows[i][39].ToString();

                hetong2List.Add(list);
            }
            return hetong2List;
        }

        protected List<hetong3List> checkUploadData3(DataTable dt)
        {
            List<hetong3List> hetong3List = new List<hetong3List>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()) && string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                {
                    continue;
                }
                hetong3List list = new hetong3List();
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
                list.col4 = dt.Rows[i][4].ToString();
                list.col5 = dt.Rows[i][5].ToString();
                list.col6 = dt.Rows[i][6].ToString();
                list.col7 = dt.Rows[i][7].ToString();
                list.col8 = dt.Rows[i][8].ToString();
                list.col9 = dt.Rows[i][9].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][9].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col10 = dt.Rows[i][10].ToString();
                list.col11 = dt.Rows[i][11].ToString();
                list.col12 = dt.Rows[i][12].ToString();
                list.col13 = dt.Rows[i][13].ToString();
                list.col14 = dt.Rows[i][14].ToString();
                list.col15 = dt.Rows[i][15].ToString();
                list.col16 = dt.Rows[i][16].ToString().Trim() == "" ? "" : Convert.ToDateTime(dt.Rows[i][16].ToString().Replace("年", "").Replace("月", "").Replace("日", "").Trim()).ToString("yyyy年-MM月-dd日");
                list.col17 = dt.Rows[i][17].ToString();
                list.col18 = dt.Rows[i][18].ToString();
                list.col19 = dt.Rows[i][19].ToString();
                list.col20 = dt.Rows[i][20].ToString();
                list.col21 = "";

                hetong3List.Add(list);
            }
            return hetong3List;
        }



    }
}