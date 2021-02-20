using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Role;
using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Text;
using MojoCube.Api.Excel;
using System.Collections.Generic;

namespace CopyMFRubikCubePowerContent.Admin.Role
{
    public partial class Admin_Role_Name : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                getDropUser();
               
                //this.GridBind();
               
            }
        }


        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                if (dataSource.Rows[31]["col2"].ToString() == "1" && dataSource.Rows[31]["col1"].ToString() == "div0071")
                {
                    dd0071.Visible = true;
                }
                else
                {
                    dd0071.Visible = false;
                }
                if (dataSource.Rows[32]["col2"].ToString() == "1" && dataSource.Rows[32]["col1"].ToString() == "div0072")
                {
                    dd0072.Visible = true;
                }
                else
                {
                    dd0072.Visible = false;
                }
                if (dataSource.Rows[33]["col2"].ToString() == "1" && dataSource.Rows[33]["col1"].ToString() == "div0073")
                {
                    dd0073.Visible = true;
                }
                else
                {
                    dd0073.Visible = false;
                }
                if (dataSource.Rows[34]["col2"].ToString() == "1" && dataSource.Rows[34]["col1"].ToString() == "div0074")
                {
                    dd0074.Visible = true;
                }
                else
                {
                    dd0074.Visible = false;
                }
                if (dataSource.Rows[35]["col2"].ToString() == "1" && dataSource.Rows[35]["col1"].ToString() == "div0075")
                {
                    dd0075.Visible = true;
                }
                else
                {
                    dd0075.Visible = false;
                }
                if (dataSource.Rows[36]["col2"].ToString() == "1" && dataSource.Rows[36]["col1"].ToString() == "div0076")
                {
                    dd0076.Visible = true;
                }
                else
                {
                    dd0076.Visible = false;
                }
                if (dataSource.Rows[37]["col2"].ToString() == "1" && dataSource.Rows[37]["col1"].ToString() == "div0077")
                {
                    dd0077.Visible = true;
                }
                else
                {
                    dd0077.Visible = false;
                }

            }
            else
            {
                div0071.Visible = false;
                div0072.Visible = false;
                div0073.Visible = false;
                div0074.Visible = false;
                div0075.Visible = false;
                div0076.Visible = false;
                div0077.Visible = false;
            }
        }

       
        protected void getDropUser()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select UserName  from User_List where 1=1 and UserName <> 'admin' order by pk_User    ";
            dataSource = oledbHelper.GetDataTable(sql);
            DropUser.DataTextField = "UserName";
            DropUser.DataValueField = "UserName";
            DropUser.DataSource = dataSource;
            DropUser.DataBind();
            DropUser.Items.Insert(0, "");

        }

        protected void DropUserSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropUser.Text != "")
            {
                this.GridBind();
            }
            else
            {
                
            }
        }


        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            if (DropUser.Text == "") 
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择一个用户！");
                return;
            }
            this.GridBind();
        }

        private void GridBind()
        {
            DataTable dataSource = new DataTable();
            DataTable dataSource2 = new DataTable();
            DataTable dataSource3 = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select  * from t_quanxian where col4 = '" + this.DropUser.Text.Trim() + "' and col1 in ('div001','div002','div002','div0021','div0022','div0023','div003','div0031','div0032','div0033','div0034','div004','div0041','div0042','div0043','div0044','div0045','div0046') order by col1 ");
            dataSource2 = oledbHelper.GetDataTable("select  * from t_quanxian where col4 = '" + this.DropUser.Text.Trim() + "' and col1 in ('div005','div005','div0051','div0052','div0053','div0054','div0055','div006','div0061','div0061','div0062','div0063','div0064','div0065','div0066','div0067','div0068','div009','div0091','div0092','div0093','div0094','div0095','div0096') order by col1 ");
            dataSource3 = oledbHelper.GetDataTable("select  * from t_quanxian where col4 = '" + this.DropUser.Text.Trim() + "' and col1 in ('div007','div0071','div0072','div0073','div0074','div0075','div0076','div0077') order by col1 ");

            if (dataSource.Rows.Count == 0)
            {
                dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = 'admin' and col1 in ('div001','div002','div002','div0021','div0022','div0023','div003','div0031','div0032','div0033','div0034','div004','div0041','div0042','div0043','div0044','div0045','div0046') order by col1 ");
                dataSource2 = oledbHelper.GetDataTable("select  * from t_quanxian where col4 = 'admin' and col1 in ('div005','div005','div0051','div0052','div0053','div0054','div0055','div006','div0061','div0061','div0062','div0063','div0064','div0065','div0066','div0067','div0068','div009','div0091','div0092','div0093','div0094','div0095','div0096') order by col1 ");
                dataSource3 = oledbHelper.GetDataTable("select  * from t_quanxian where col4 = 'admin' and col1 in ('div007','div0071','div0072','div0073','div0074','div0075','div0076','div0077') order by col1 ");

                TextBox审核人.Text = this.DropUser.Text.Trim();
                this.GridView1.DataSource = dataSource;
                this.GridView1.DataBind();

                this.GridView2.DataSource = dataSource2;
                this.GridView2.DataBind();
                this.GridView3.DataSource = dataSource3;
                this.GridView3.DataBind();
                //this.GridView4.DataSource = dataSource;
                //this.GridView4.DataBind();
            }
            else
            {
                TextBox审核人.Text = this.DropUser.Text.Trim();
                this.GridView1.DataSource = dataSource;
                this.GridView1.DataBind();

                this.GridView2.DataSource = dataSource2;
                this.GridView2.DataBind();
                this.GridView3.DataSource = dataSource3;
                this.GridView3.DataBind();
                //this.GridView4.DataSource = dataSource;
                //this.GridView4.DataBind();
            }
            ViewState["GridDataSource"] = dataSource;
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblcol2")).Text == "1")
                {
                    ((CheckBox)e.Row.FindControl("cbUse")).Checked = true;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "首页")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "市场管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "合同管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "项目管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "财务管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblcol2")).Text == "1")
                {
                    ((CheckBox)e.Row.FindControl("cbUse")).Checked = true;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "项目管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "合作管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
               

               
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblcol2")).Text == "1")
                {
                    ((CheckBox)e.Row.FindControl("cbUse")).Checked = true;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "财务管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                if (((Label)e.Row.FindControl("lblName_CHS")).Text == "系统管理")
                {
                    ((Label)e.Row.FindControl("lblName_CHS")).BackColor = System.Drawing.Color.LightGray;
                }
                
            }
        }


        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            quanxianList list = new quanxianList();
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + DropUser.Text.Trim() + "' order by ID ");
            if (dataSource.Rows.Count == 0)
            {
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    list.col1 = ((Label)this.GridView1.Rows[i].FindControl("lblcol1")).Text;
                    list.col2 = ((CheckBox)this.GridView1.Rows[i].FindControl("cbUse")).Checked == true ? "1" : "0";
                    list.col3 = ((Label)this.GridView1.Rows[i].FindControl("lblName_CHS")).Text;
                    list.col4 = this.DropUser.Text.Trim();
                    list.InsertData();
                }
                for (int i = 0; i < this.GridView2.Rows.Count; i++)
                {
                    list.col1 = ((Label)this.GridView2.Rows[i].FindControl("lblcol1")).Text;
                    list.col2 = ((CheckBox)this.GridView2.Rows[i].FindControl("cbUse")).Checked == true ? "1" : "0";
                    list.col3 = ((Label)this.GridView2.Rows[i].FindControl("lblName_CHS")).Text;
                    list.col4 = this.DropUser.Text.Trim();
                    list.InsertData();
                }
                for (int i = 0; i < this.GridView3.Rows.Count; i++)
                {
                    list.col1 = ((Label)this.GridView3.Rows[i].FindControl("lblcol1")).Text;
                    list.col2 = ((CheckBox)this.GridView3.Rows[i].FindControl("cbUse")).Checked == true ? "1" : "0";
                    list.col3 = ((Label)this.GridView3.Rows[i].FindControl("lblName_CHS")).Text;
                    list.col4 = this.DropUser.Text.Trim();
                    list.InsertData();
                }
            }
            else
            {
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    list.ID = int.Parse(((Label)this.GridView1.Rows[i].FindControl("lblID")).Text);
                    list.col1 = ((Label)this.GridView1.Rows[i].FindControl("lblcol1")).Text;
                    list.col2 = ((CheckBox)this.GridView1.Rows[i].FindControl("cbUse")).Checked == true ? "1" : "0";
                    list.col3 = ((Label)this.GridView1.Rows[i].FindControl("lblName_CHS")).Text;
                    list.col4 = this.DropUser.Text.Trim();
                    list.UpdateData(list.ID);
                }
                for (int i = 0; i < this.GridView2.Rows.Count; i++)
                {
                    list.ID = int.Parse(((Label)this.GridView2.Rows[i].FindControl("lblID")).Text);
                    list.col1 = ((Label)this.GridView2.Rows[i].FindControl("lblcol1")).Text;
                    list.col2 = ((CheckBox)this.GridView2.Rows[i].FindControl("cbUse")).Checked == true ? "1" : "0";
                    list.col3 = ((Label)this.GridView2.Rows[i].FindControl("lblName_CHS")).Text;
                    list.col4 = this.DropUser.Text.Trim();
                    list.UpdateData(list.ID);
                }
                for (int i = 0; i < this.GridView3.Rows.Count; i++)
                {
                    list.ID = int.Parse(((Label)this.GridView3.Rows[i].FindControl("lblID")).Text);
                    list.col1 = ((Label)this.GridView3.Rows[i].FindControl("lblcol1")).Text;
                    list.col2 = ((CheckBox)this.GridView3.Rows[i].FindControl("cbUse")).Checked == true ? "1" : "0";
                    list.col3 = ((Label)this.GridView3.Rows[i].FindControl("lblName_CHS")).Text;
                    list.col4 = this.DropUser.Text.Trim();
                    list.UpdateData(list.ID);
                }
            }
            
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "用户权限保存成功");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtAll = (DataTable)ViewState["GridDataSource"];

            DateTime dt = System.DateTime.Now;
            string str = "结算管理" + dt.ToString("yyyyMMddhhmmss");
            str = str + ".xlsx";
            //GridBind("download");
            //DownloadHtmlExcelFile(GridView1, str, null);
            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("A1");
            downloadTable.Columns.Add("A2");
            downloadTable.Columns.Add("A3");
            downloadTable.Columns.Add("A4");
            downloadTable.Columns.Add("A5");
            downloadTable.Columns.Add("A6");
            downloadTable.Columns.Add("A7");
            downloadTable.Columns.Add("A8");
            downloadTable.Columns.Add("A9");
            downloadTable.Columns.Add("A10");
            downloadTable.Columns.Add("A11");
            downloadTable.Columns.Add("A12");
            downloadTable.Columns.Add("A13");
            downloadTable.Columns.Add("A14");
            downloadTable.Columns.Add("A15");
            downloadTable.Columns.Add("A16");
            downloadTable.Columns.Add("A17");
            downloadTable.Columns.Add("A18");
            downloadTable.Columns.Add("A19");
            downloadTable.Columns.Add("A20");
            downloadTable.Columns.Add("A21");
            downloadTable.Columns.Add("A22");
            downloadTable.Columns.Add("A23");
            downloadTable.Columns.Add("A24");
            //downloadTable.Columns.Add("A25");
            //downloadTable.Columns.Add("A26");


            DataRow dr;
            for (int i = 0; i < dtAll.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = i + 1; ;
                dr["A3"] = dtAll.Rows[i]["col1"].ToString();
                dr["A4"] = dtAll.Rows[i]["col2"].ToString();

                dr["A5"] = dtAll.Rows[i]["col3"].ToString();
                dr["A6"] = dtAll.Rows[i]["col4"].ToString();
                
                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx("/Admin/DownLoadTemplates/结算管理下载模板.xlsx", downloadTable, str);
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


                    if (1 == 1)
                    {
                        List<quanxianList> quanxianList = checkUploadData(dt);

                        StringBuilder errorMsg = new StringBuilder();
                        foreach (quanxianList item in quanxianList)
                        {
                            if (!string.IsNullOrEmpty(item.CheckUploadResult))
                                errorMsg.Append(item.CheckUploadResult);
                        }


                        if (string.IsNullOrEmpty(errorMsg.ToString()))
                        {
                            StringBuilder errorBillNo = new StringBuilder();
                            foreach (quanxianList item in quanxianList)
                            {
                                item.InsertData();

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

        protected List<quanxianList> checkUploadData(DataTable dt)
        {
            List<quanxianList> quanxianList = new List<quanxianList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                quanxianList list = new quanxianList();
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
                


                quanxianList.Add(list);
            }
            return quanxianList;
        }



    }
}