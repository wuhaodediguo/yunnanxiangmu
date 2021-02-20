using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;

using System.Text;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.UI;
using MojoCube.Api.File;

using System;
using System.IO;
using System.Web.Security;
using System.Web.UI.HtmlControls;

using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.Data;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using MojoCube.Web.DispatchWaybill;
using Wuqi.Webdiyer;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace CopyMFRubikCubePowerContent.Admin.zhengjian
{
    public partial class yuangongzs : System.Web.UI.Page
    {
        private static string puserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                getDrop州市();
                getDrop所属项目部();
                puserID = base.Session["RoleValue"].ToString();
                this.hlAdd.NavigateUrl = "yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"];
                this.ViewState["OrderByKey"] = "ID";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                if (puserID != "1")
                {
                    hlAdd.Visible = false;
                }

            }
        }

        protected void getDrop州市()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,pinming  from tb_pinzhong where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop州市.DataTextField = "pinming";
            Drop州市.DataValueField = "pinming";
            Drop州市.DataSource = dataSource;
            Drop州市.DataBind();
            Drop州市.Items.Insert(0, "");

        }

        protected void getDrop所属项目部()
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select ID,guige  from tb_guige where 1=1     ";
            dataSource = oledbHelper.GetDataTable(sql);
            Drop所属项目部.DataTextField = "guige";
            Drop所属项目部.DataValueField = "guige";
            Drop所属项目部.DataSource = dataSource;
            Drop所属项目部.DataBind();
            Drop所属项目部.Items.Insert(0, "");

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
            adminPager.TableName = "yuangongzs ";
            adminPager.strGetFields = "*";
            string sql = "select * from yuangongzs where 1= 1 ";

            StringBuilder where = new StringBuilder();
            where.Append(" where 1=1 ");
            ArrayList arrayList = new ArrayList();
            if (this.Drop州市.Text.Trim() != "")
            {
                where.Append(" and zhousi like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.Drop州市.Text.Trim()));
                sql += " and zhousi = '" + this.Drop州市.Text + "' ";

            }
            if (this.Drop所属项目部.Text.Trim() != "")
            {
                where.Append(" and xiangmu like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.Drop所属项目部.Text.Trim()));
                sql += " and xiangmu = '" + this.Drop所属项目部.Text + "' ";
               
            }
            if (this.txt姓名.Text.Trim() != "")
            {
                where.Append(" and name like '%'+?+'%'");
                arrayList.Add(CheckSql.Filter(this.txt姓名.Text.Trim()));
                sql += " and name = '" + this.txt姓名.Text + "' ";
               
            }

            OledbHelper oledbHelper = new OledbHelper();

            ViewState["GridDataSource"] = oledbHelper.GetDataTable(sql);

            adminPager.where = where.ToString();
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
                if (((Label)e.Row.FindControl("lblThumbnail")).Text != "")
                {
                    string text = "../Files.aspx?image=" + Security.EncryptString(((Label)e.Row.FindControl("lblThumbnail")).Text);
                    ((Label)e.Row.FindControl("lblThumbnail")).Text = string.Concat(new string[]
				{
					"<a href=\"",
					text,
					"\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"",
					((Label)e.Row.FindControl("lbl姓名")).Text,
					"\"><img src=\"",
					text,
					"&cut=50,50\" class=\"img-circle\" style=\"width:25px; height:25px;\" /></a>"
				});
                }

                if (((Label)e.Row.FindControl("lbl身份证信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn身份证信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk身份证信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl学历信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn学历信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk学历信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl劳动合同信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn劳动合同信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk劳动合同信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl通信类ABC证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn通信类ABC证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk通信类ABC证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl通信类职称证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn通信类职称证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk通信类职称证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl通信类概预算证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn通信类概预算证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk通信类概预算证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl建筑类ABC证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn建筑类ABC证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk建筑类ABC证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl一级建造师证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn一级建造师证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk一级建造师证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl二级建造师证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn二级建造师证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk二级建造师证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl建筑类职称证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn建筑类职称证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk建筑类职称证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl建筑类技术工种证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn建筑类技术工种证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk建筑类技术工种证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl通信类技术工种证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn通信类技术工种证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk通信类技术工种证书信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl特种作业证书信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn特种作业证书信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk特种作业证书信息")).Visible = false;
                }

                if (((Label)e.Row.FindControl("lbl其他证书1信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn其他证书1信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk其他证书1信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl其他证书2信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn其他证书2信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk其他证书2信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl其他证书3信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn其他证书3信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk其他证书3信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl其他证书4信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn其他证书4信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk其他证书4信息")).Visible = false;
                }
                if (((Label)e.Row.FindControl("lbl其他证书5信息")).Text.Trim() == "")
                {
                    ((LinkButton)e.Row.FindControl("lbtn其他证书5信息")).Visible = false;
                    ((CheckBox)e.Row.FindControl("Chk其他证书5信息")).Visible = false;
                }

                if (puserID != "1")
                {
                    ((HyperLink)e.Row.FindControl("gvEdit")).Text = "浏览";
                    ((HyperLink)e.Row.FindControl("gvEdit")).ToolTip = "浏览";
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = true;
                    MojoCube.Web.String.ShowDel(e);
                }

                string str = ((Label)e.Row.FindControl("lblID")).Text.Trim();
                ((HyperLink)e.Row.FindControl("gvEdit")).NavigateUrl = "yuangongzsEdit.aspx?id=" + str + "&active=" + base.Request.QueryString["active"] + "&weizhi=" + "";

                
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            AdminGridView.SetSortingRowCreated(e, (string)this.ViewState["OrderByKey"], (bool)this.ViewState["OrderByType"], this.GridView1);
            string[] controlList = new string[]
		{
			"gvDelete"
		};
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            yuangongzsList list = new yuangongzsList();
            if (((Control)e.CommandSource).Parent.Parent is GridViewRow)
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string str = ((Label)row.FindControl("lblID")).Text;
                switch (e.CommandName)
                {
                    case "_delete":
                        int index = Convert.ToInt32(e.CommandArgument);
                        list.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
                        this.GridBind();
                        break;
                    case "lbtn身份证信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn身份证信息", false);
                        break;
                    case "lbtn学历信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn学历信息", false);
                        break;
                    case "lbtn劳动合同信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn劳动合同信息", false);
                        break;
                    case "lbtn通信类ABC证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn通信类ABC证书信息", false);
                        break;
                    case "lbtn通信类职称证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn通信类职称证书信息", false);
                        break;
                    case "lbtn通信类概预算证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn通信类概预算证书信息", false);
                        break;
                    case "lbtn建筑类ABC证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn建筑类ABC证书信息", false);
                        break;
                    case "lbtn一级建造师证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn一级建造师证书信息", false);
                        break;
                    case "lbtn二级建造师证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn二级建造师证书信息", false);
                        break;
                    case "lbtn建筑类职称证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn建筑类职称证书信息", false);
                        break;
                    case "lbtn建筑类技术工种证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn建筑类技术工种证书信息", false);
                        break;
                    case "lbtn通信类技术工种证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn通信类技术工种证书信息", false);
                        break;
                    case "lbtn特种作业证书信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn特种作业证书信息", false);
                        break;
                    case "lbtn其他证书1信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn其他证书1信息", false);
                        break;
                    case "lbtn其他证书2信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn其他证书2信息", false);
                        break;
                    case "lbtn其他证书3信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn其他证书3信息", false);
                        break;
                    case "lbtn其他证书4信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn其他证书4信息", false);
                        break;
                    case "lbtn其他证书5信息":
                        Response.Redirect("yuangongzsEdit.aspx?active=" + base.Request.QueryString["active"] + "&id=" + str + "&weizhi=" + "lbtn其他证书5信息", false);
                        break;

                }
 
            }
            

            
            

        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {

                if (checkFile(fuPortrait.PostedFile))
                {
                    ExcelHelper exh = new ExcelHelper();
                    DataTable dt = exh.ExcelToDataTable2(this.fuPortrait.PostedFile.InputStream, "", true, fuPortrait.PostedFile.FileName);
                    //验证数据

                    if (dt == null)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "文件没有数据");
                        return;
                    }
                    List<yuangongzsList> companyzsList = checkUploadData(dt);

                    List<yuangongzsList1> companyzsList2 = checkUploadData2(dt);


                    StringBuilder errorMsg = new StringBuilder();
                    foreach (yuangongzsList item in companyzsList)
                    {
                        if (!string.IsNullOrEmpty(item.CheckUploadResult))
                            errorMsg.Append(item.CheckUploadResult);
                    }


                    if (string.IsNullOrEmpty(errorMsg.ToString()))
                    {
                        StringBuilder errorBillNo = new StringBuilder();
                        foreach (yuangongzsList item in companyzsList)
                        {
                            DataSet ds = Sql.SqlQueryDS("select * from yuangongzs where sno='" + item.sno + "'");

                            

                            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            {
                                item.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());

                                foreach (yuangongzsList1 item2 in companyzsList2)
                                {
                                    if (item.sno == item2.sno)
                                    {
                                        item2.sID = item.ID;
                                        if (item2.UpdateData() <= 0)
                                        {
                                            errorBillNo.Append(item.ID + ",c");
                                        }
                                    }
                                }
                                if (item.UpdateData() <= 0)
                                {
                                    errorBillNo.Append(item.ID + ",d");
                                }
                            }
                            else
                            {
                                if (item.InsertData() <= 0)
                                {
                                    errorBillNo.Append(item.ID + ",");
                                }
                                DataSet ds2 = Sql.SqlQueryDS("select * from yuangongzs where sno='" + item.sno + "'");
                                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                                {
                                    item.ID = int.Parse(ds2.Tables[0].Rows[0]["ID"].ToString());
                                    foreach (yuangongzsList1 item2 in companyzsList2)
                                    {
                                        if (item.sno == item2.sno)
                                        {
                                            item2.sID = item.ID;
                                            if (item2.InsertData() <= 0)
                                            {
                                                errorBillNo.Append(item.ID + ",");
                                            }
                                        }
                                    }

                                }

                                
                                
                            }

                           
                        }
                        if (!string.IsNullOrEmpty(errorBillNo.ToString()))
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "以下证件号：" + errorBillNo.ToString().TrimEnd(',') + "保存失败");
                        else
                        {
                            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "所有数据保存成功");
                            this.GridBind();
                        }
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
        protected List<yuangongzsList> checkUploadData(DataTable dt)
        {
            List<yuangongzsList> yuangongzsList = new List<yuangongzsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yuangongzsList list = new yuangongzsList();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()))
                {
                    continue;
                }
                if (string.IsNullOrEmpty(dt.Rows[i][1].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.zhousi = dt.Rows[i][1].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.xiangmu = dt.Rows[i][2].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][3].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.zhiwu = dt.Rows[i][3].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.name = dt.Rows[i][4].ToString();
                list.sex = dt.Rows[i][5].ToString();
                list.minzu = dt.Rows[i][6].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][7].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.sno = dt.Rows[i][7].ToString();
                if (string.IsNullOrEmpty(dt.Rows[i][8].ToString()))
                    list.CheckUploadResult += string.Format("第 {0} 行 {1} 列不能为空，", (i + 1).ToString(), dt.Columns[0].ColumnName);
                else
                    list.sdate = chuli(dt.Rows[i][8].ToString()).Trim(); 
                list.nianli = dt.Rows[i][9].ToString();
                list.address = dt.Rows[i][10].ToString();
                list.youxiaodate = chuli(dt.Rows[i][11].ToString()).Trim();
                list.shenfenweizhi = dt.Rows[i][12].ToString();
                list.school = dt.Rows[i][13].ToString();
                list.zhuanye = dt.Rows[i][14].ToString();
                list.xueli = dt.Rows[i][15].ToString();
                list.biyedate = chuli(dt.Rows[i][16].ToString()).Trim();

               
                list.xueliflag = dt.Rows[i][17].ToString();
                list.yuanjianflag = dt.Rows[i][18].ToString();
                list.xueliweizhi = dt.Rows[i][19].ToString(); ;
                list.hetongcol1 = chuli(dt.Rows[i][20].ToString()).Trim(); 

                list.hetongcol2 = dt.Rows[i][21].ToString();
                list.hetongcol3 = chuli(dt.Rows[i][22].ToString()).Trim();
                list.hetongcol4 = chuli(dt.Rows[i][23].ToString()).Trim();

                list.hetongcol5 = dt.Rows[i][24].ToString();
                list.hetongcol6 = dt.Rows[i][25].ToString();
                list.hetongcol7 = dt.Rows[i][26].ToString();
                list.hetongweizhi = dt.Rows[i][27].ToString();
                list.txcol1 = dt.Rows[i][28].ToString();
                list.txcol2 = dt.Rows[i][29].ToString();
                list.txcol3 = chuli(dt.Rows[i][30].ToString()).Trim();// dt.Rows[i][30].ToString();

                list.txcol4 = dt.Rows[i][31].ToString();
                list.txcol5 = chuli(dt.Rows[i][32].ToString()).Trim() ; //dt.Rows[i][32].ToString();

                list.txcol6 = dt.Rows[i][33].ToString();
                list.txcol7 = dt.Rows[i][34].ToString();
                list.txcol8 = dt.Rows[i][35].ToString();
                list.ABCweizhi = dt.Rows[i][36].ToString();
                list.txzccol1 = dt.Rows[i][37].ToString();
                list.txzccol2 = dt.Rows[i][38].ToString();
                list.txzccol3 = chuli(dt.Rows[i][39].ToString()).Trim();

                list.txzccol4 = dt.Rows[i][40].ToString();
                list.txzccol5 = chuli(dt.Rows[i][41].ToString()).Trim();

                list.txzccol6 = dt.Rows[i][42].ToString();
                list.txzccol7 = dt.Rows[i][43].ToString();
                list.txzccol8 = dt.Rows[i][44].ToString();
                list.zhichengweizhi = dt.Rows[i][45].ToString();
                list.txyscol1 = dt.Rows[i][46].ToString();
                list.txyscol2 = dt.Rows[i][47].ToString();
                list.txyscol3 = chuli(dt.Rows[i][48].ToString()).Trim();

                list.txyscol4 = dt.Rows[i][49].ToString();
                list.txyscol5 = chuli(dt.Rows[i][50].ToString()).Trim(); 

                list.txyscol6 = dt.Rows[i][51].ToString();
                list.txyscol7 = dt.Rows[i][52].ToString();
                list.txyscol8 = dt.Rows[i][53].ToString();
                list.yusuanweizhi = dt.Rows[i][54].ToString();
                list.jzABCcol1 = dt.Rows[i][55].ToString();
                list.jzABCcol2 = dt.Rows[i][56].ToString();
                list.jzABCcol3 = chuli(dt.Rows[i][57].ToString()).Trim(); 
                list.jzABCcol4 = dt.Rows[i][58].ToString();
                list.jzABCcol5 = chuli(dt.Rows[i][59].ToString()).Trim(); 

                list.jzABCcol6 = dt.Rows[i][60].ToString();
                list.jzABCcol7 = dt.Rows[i][61].ToString();
                list.jzABCcol8 = dt.Rows[i][62].ToString();
                list.jianzhuABCweizhi = dt.Rows[i][63].ToString();
                list.yijicol1 = dt.Rows[i][64].ToString();
                list.yijicol2 = dt.Rows[i][65].ToString();
                list.yijicol3 = chuli(dt.Rows[i][66].ToString()).Trim(); 

                list.yijicol4 = dt.Rows[i][67].ToString();
                list.yijicol5 = chuli(dt.Rows[i][68].ToString()).Trim();

                list.yijicol6 = dt.Rows[i][69].ToString();
                list.yijicol7 = dt.Rows[i][70].ToString();
                list.yijicol8 = dt.Rows[i][71].ToString();
                list.yijizsweizhi = dt.Rows[i][72].ToString();

                list.erjicol1 = dt.Rows[i][73].ToString();
                list.erjicol2 = dt.Rows[i][74].ToString();
                list.erjicol3 = chuli(dt.Rows[i][75].ToString()).Trim();

                list.erjicol4 = dt.Rows[i][76].ToString();
                list.erjicol5 = chuli(dt.Rows[i][77].ToString()).Trim(); 

                list.erjicol6 = dt.Rows[i][78].ToString();
                list.erjicol7 = dt.Rows[i][79].ToString();
                list.erjicol8 = dt.Rows[i][80].ToString();
                list.erjizsweizhi = dt.Rows[i][81].ToString();
                list.jzzccol1 = dt.Rows[i][82].ToString();
                list.jzzccol2 = dt.Rows[i][83].ToString();
                list.jzzccol3 = chuli(dt.Rows[i][84].ToString()).Trim();

                list.jzzccol4 = dt.Rows[i][85].ToString();
                list.jzzccol5 = chuli(dt.Rows[i][86].ToString()).Trim(); 

                list.jzzccol6 = dt.Rows[i][87].ToString();
                list.jzzccol7 = dt.Rows[i][88].ToString();
                list.jzzccol8 = dt.Rows[i][89].ToString();
                list.jzzccol9 = dt.Rows[i][90].ToString();

                list.jzjscol1 = dt.Rows[i][91].ToString();
                list.jzjscol2 = dt.Rows[i][92].ToString();
                list.jzjscol3 = chuli(dt.Rows[i][93].ToString()).Trim(); 

                list.jzjscol4 = dt.Rows[i][94].ToString();
                list.jzjscol5 = chuli(dt.Rows[i][95].ToString()).Trim(); 

                list.jzjscol6 = dt.Rows[i][96].ToString();
                list.jzjscol7 = dt.Rows[i][97].ToString();
                list.jzjscol8 = dt.Rows[i][98].ToString();
                list.jzjscol9 = dt.Rows[i][99].ToString();

                list.txjscol1 = dt.Rows[i][100].ToString();
                list.txjscol2 = dt.Rows[i][101].ToString();
                list.txjscol3 = chuli(dt.Rows[i][102].ToString()).Trim();

                list.txjscol4 = dt.Rows[i][103].ToString();
                list.txjscol5 = chuli(dt.Rows[i][104].ToString()).Trim(); 

                list.txjscol6 = dt.Rows[i][105].ToString();
                list.txjscol7 = dt.Rows[i][106].ToString();
                list.txjscol8 = dt.Rows[i][107].ToString();
                list.txjscol9 = dt.Rows[i][108].ToString();

                list.tzzycol1 = dt.Rows[i][109].ToString();
                list.tzzycol2 = dt.Rows[i][110].ToString();
                list.tzzycol3 = chuli(dt.Rows[i][111].ToString()).Trim(); 

                list.tzzycol4 = dt.Rows[i][112].ToString();
                list.tzzycol5 = chuli(dt.Rows[i][113].ToString()).Trim();

                list.tzzycol6 = dt.Rows[i][114].ToString();
                list.tzzycol7 = dt.Rows[i][115].ToString();
                list.tzzycol8 = dt.Rows[i][116].ToString();
                list.tzzycol9 = dt.Rows[i][117].ToString();

                list.remark = dt.Rows[i][163].ToString();
                list.ImagePath1 = "";

                list.col1 = dt.Rows[i][126].ToString();
                list.col2 = dt.Rows[i][135].ToString();
                list.col3 = dt.Rows[i][144].ToString();
                list.col4 = dt.Rows[i][153].ToString();
                list.col5 = dt.Rows[i][162].ToString();
                list.hunyin = "";
                list.zhengzhi = "";

                //list.col1 = dt.Rows[i][119].ToString();
                //list.col2 = dt.Rows[i][120].ToString();
                //list.col3 = dt.Rows[i][121].ToString();
                //list.col4 = dt.Rows[i][122].ToString();
                //list.col5 = dt.Rows[i][123].ToString();
                //list.hunyin = dt.Rows[i][124].ToString();
                //list.zhengzhi = dt.Rows[i][125].ToString();
               

                yuangongzsList.Add(list);
            }
            return yuangongzsList;
        }

        protected List<yuangongzsList1> checkUploadData2(DataTable dt)
        {
            List<yuangongzsList1> yuangongzsList = new List<yuangongzsList1>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yuangongzsList1 list = new yuangongzsList1();
                list.CheckUploadResult = "";
                //
                if (string.IsNullOrEmpty(dt.Rows[i][0].ToString()))
                {
                    continue;
                }

                list.sno = dt.Rows[i][7].ToString();

                list.qita1col1 = dt.Rows[i][118].ToString();
                list.qita2col1 = dt.Rows[i][119].ToString();
                list.qita3col1 = chuli(dt.Rows[i][120].ToString()).Trim(); 
                list.qita4col1 = dt.Rows[i][121].ToString();
                list.qita5col1 = chuli(dt.Rows[i][122].ToString()).Trim();
                list.qita6col1 = dt.Rows[i][123].ToString();
                list.qita7col1 = dt.Rows[i][124].ToString();
                list.qita8col1 = dt.Rows[i][125].ToString();

                list.qita1col2 = dt.Rows[i][127].ToString();
                list.qita2col2 = dt.Rows[i][128].ToString();
                list.qita3col2 = chuli(dt.Rows[i][129].ToString()).Trim(); 
                list.qita4col2 = dt.Rows[i][130].ToString();
                list.qita5col2 = chuli(dt.Rows[i][131].ToString()).Trim();
                list.qita6col2 = dt.Rows[i][132].ToString();
                list.qita7col2 = dt.Rows[i][133].ToString();
                list.qita8col2 = dt.Rows[i][134].ToString();

                list.qita1col3 = dt.Rows[i][136].ToString();
                list.qita2col3 = dt.Rows[i][137].ToString();
                list.qita3col3 = chuli(dt.Rows[i][138].ToString()).Trim(); 
                list.qita4col3 = dt.Rows[i][139].ToString();
                list.qita5col3 = chuli(dt.Rows[i][140].ToString()).Trim(); 
                list.qita6col3 = dt.Rows[i][141].ToString();
                list.qita7col3 = dt.Rows[i][142].ToString();
                list.qita8col3 = dt.Rows[i][143].ToString();

                list.qita1col4 = dt.Rows[i][145].ToString();
                list.qita2col4 = dt.Rows[i][146].ToString();
                list.qita3col4 = chuli(dt.Rows[i][147].ToString()).Trim(); 
                list.qita4col4 = dt.Rows[i][148].ToString();
                list.qita5col4 = chuli(dt.Rows[i][149].ToString()).Trim(); 
                list.qita6col4 = dt.Rows[i][150].ToString();
                list.qita7col4 = dt.Rows[i][151].ToString();
                list.qita8col4 = dt.Rows[i][152].ToString();

                list.qita1col5 = dt.Rows[i][154].ToString();
                list.qita2col5 = dt.Rows[i][155].ToString();
                list.qita3col5 = chuli(dt.Rows[i][156].ToString()).Trim();
                list.qita4col5 = dt.Rows[i][157].ToString();
                list.qita5col5 = chuli(dt.Rows[i][158].ToString()).Trim(); 
                list.qita6col5 = dt.Rows[i][159].ToString();
                list.qita7col5 = dt.Rows[i][160].ToString();
                list.qita8col5 = dt.Rows[i][161].ToString();
               
                //list.col1 = dt.Rows[i][119].ToString();
                //list.col2 = dt.Rows[i][120].ToString();
                //list.col3 = dt.Rows[i][121].ToString();
                //list.col4 = dt.Rows[i][122].ToString();
                //list.col5 = dt.Rows[i][123].ToString();
                //list.hunyin = dt.Rows[i][124].ToString();
                //list.zhengzhi = dt.Rows[i][125].ToString();


                yuangongzsList.Add(list);
            }
            return yuangongzsList;
        }


        protected void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string filename = "/Admin/UploadTemplates/员工证件资料导入.xls";
            DownloadTemplateFile downloadTemplateFile = new DownloadTemplateFile();
            downloadTemplateFile.DoFileDownload(filename);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
           
            DateTime dt = System.DateTime.Now;
            string str = "员工证件" + dt.ToString("yyyyMMddhhmmss");

            DataTable dataSource1 = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            sql = "select * from yuangongzs  where 1=1  ";

            if (this.Drop州市.Text.Trim() != "")
            {
                sql += "and zhousi =  '" + this.Drop州市.Text.Trim() + "'";
                
            }
            if (this.Drop所属项目部.Text.Trim() != "")
            {
                sql += "and xiangmu =  '" + this.Drop所属项目部.Text.Trim() + "'";
                
            }
            if (this.txt姓名.Text.Trim() != "")
            {
                sql += "and name =  '" + this.txt姓名.Text.Trim() + "'";
                
            }
            dataSource1 = oledbHelper.GetDataTable(sql);

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
            downloadTable.Columns.Add("A25");
            downloadTable.Columns.Add("A26");
            downloadTable.Columns.Add("A27");
            downloadTable.Columns.Add("A28");
            downloadTable.Columns.Add("A29");
            downloadTable.Columns.Add("A30");
            downloadTable.Columns.Add("A31");
            downloadTable.Columns.Add("A32");
            downloadTable.Columns.Add("A33");
            downloadTable.Columns.Add("A34");
            downloadTable.Columns.Add("A35");
            downloadTable.Columns.Add("A36");
            downloadTable.Columns.Add("A37");
            downloadTable.Columns.Add("A38");
            downloadTable.Columns.Add("A39");
            downloadTable.Columns.Add("A40");
            downloadTable.Columns.Add("A41");
            downloadTable.Columns.Add("A42");
            downloadTable.Columns.Add("A43");
            downloadTable.Columns.Add("A44");
            downloadTable.Columns.Add("A45");
            downloadTable.Columns.Add("A46");
            downloadTable.Columns.Add("A47");
            downloadTable.Columns.Add("A48");
            downloadTable.Columns.Add("A49");
            downloadTable.Columns.Add("A50");
            downloadTable.Columns.Add("A51");
            downloadTable.Columns.Add("A52");
            downloadTable.Columns.Add("A53");
            downloadTable.Columns.Add("A54");
            downloadTable.Columns.Add("A55");
            downloadTable.Columns.Add("A56");
            downloadTable.Columns.Add("A57");
            downloadTable.Columns.Add("A58");
            downloadTable.Columns.Add("A59");
            downloadTable.Columns.Add("A60");

            downloadTable.Columns.Add("A61");
            downloadTable.Columns.Add("A62");
            downloadTable.Columns.Add("A63");
            downloadTable.Columns.Add("A64");
            downloadTable.Columns.Add("A65");
            downloadTable.Columns.Add("A66");
            downloadTable.Columns.Add("A67");
            downloadTable.Columns.Add("A68");
            downloadTable.Columns.Add("A69");
            downloadTable.Columns.Add("A70");
            downloadTable.Columns.Add("A71");
            downloadTable.Columns.Add("A72");
            downloadTable.Columns.Add("A73");
            downloadTable.Columns.Add("A74");
            downloadTable.Columns.Add("A75");
            downloadTable.Columns.Add("A76");
            downloadTable.Columns.Add("A77");
            downloadTable.Columns.Add("A78");
            downloadTable.Columns.Add("A79");
            downloadTable.Columns.Add("A80");
            downloadTable.Columns.Add("A81");
            downloadTable.Columns.Add("A82");
            downloadTable.Columns.Add("A83");
            downloadTable.Columns.Add("A84");
            downloadTable.Columns.Add("A85");
            downloadTable.Columns.Add("A86");
            downloadTable.Columns.Add("A87");
            downloadTable.Columns.Add("A88");
            downloadTable.Columns.Add("A89");
            downloadTable.Columns.Add("A90");
            downloadTable.Columns.Add("A91");
            downloadTable.Columns.Add("A92");
            downloadTable.Columns.Add("A93");
            downloadTable.Columns.Add("A94");
            downloadTable.Columns.Add("A95");
            downloadTable.Columns.Add("A96");
            downloadTable.Columns.Add("A97");
            downloadTable.Columns.Add("A98");
            downloadTable.Columns.Add("A99");
            downloadTable.Columns.Add("A100");
            downloadTable.Columns.Add("A101");
            downloadTable.Columns.Add("A102");
            downloadTable.Columns.Add("A103");
            downloadTable.Columns.Add("A104");
            downloadTable.Columns.Add("A105");
            downloadTable.Columns.Add("A106");
            downloadTable.Columns.Add("A107");
            downloadTable.Columns.Add("A108");
            downloadTable.Columns.Add("A109");
            downloadTable.Columns.Add("A110");
            downloadTable.Columns.Add("A111");
            downloadTable.Columns.Add("A112");
            downloadTable.Columns.Add("A113");
            downloadTable.Columns.Add("A114");
            downloadTable.Columns.Add("A115");
            downloadTable.Columns.Add("A116");
            downloadTable.Columns.Add("A117");
            downloadTable.Columns.Add("A118");

            downloadTable.Columns.Add("A119");
            downloadTable.Columns.Add("A120");
            downloadTable.Columns.Add("A121");
            downloadTable.Columns.Add("A122");
            downloadTable.Columns.Add("A123");
            downloadTable.Columns.Add("A124");
            downloadTable.Columns.Add("A125");
            downloadTable.Columns.Add("A126");
            downloadTable.Columns.Add("A127");

            downloadTable.Columns.Add("A128");
            downloadTable.Columns.Add("A129");
            downloadTable.Columns.Add("A130");
            downloadTable.Columns.Add("A131");
            downloadTable.Columns.Add("A132");
            downloadTable.Columns.Add("A133");
            downloadTable.Columns.Add("A134");
            downloadTable.Columns.Add("A135");
            downloadTable.Columns.Add("A136");

            downloadTable.Columns.Add("A137");
            downloadTable.Columns.Add("A138");
            downloadTable.Columns.Add("A139");
            downloadTable.Columns.Add("A140");
            downloadTable.Columns.Add("A141");
            downloadTable.Columns.Add("A142");
            downloadTable.Columns.Add("A143");
            downloadTable.Columns.Add("A144");
            downloadTable.Columns.Add("A145");

            downloadTable.Columns.Add("A146");
            downloadTable.Columns.Add("A147");
            downloadTable.Columns.Add("A148");
            downloadTable.Columns.Add("A149");
            downloadTable.Columns.Add("A150");
            downloadTable.Columns.Add("A151");
            downloadTable.Columns.Add("A152");
            downloadTable.Columns.Add("A153");
            downloadTable.Columns.Add("A154");

            downloadTable.Columns.Add("A155");
            downloadTable.Columns.Add("A156");
            downloadTable.Columns.Add("A157");
            downloadTable.Columns.Add("A158");
            downloadTable.Columns.Add("A159");
            downloadTable.Columns.Add("A160");
            downloadTable.Columns.Add("A161");
            downloadTable.Columns.Add("A162");
            downloadTable.Columns.Add("A163");

            downloadTable.Columns.Add("A164");


            DataRow dr;
            for (int i = 0; i < dataSource1.Rows.Count; i++)
            {
                dr = downloadTable.NewRow();
                dr["A1"] = i + 1;
                dr["A2"] = dataSource1.Rows[i]["zhousi"].ToString();
                dr["A3"] = dataSource1.Rows[i]["xiangmu"].ToString();
                dr["A4"] = dataSource1.Rows[i]["zhiwu"].ToString();
                dr["A5"] = dataSource1.Rows[i]["name"].ToString();
                dr["A6"] = dataSource1.Rows[i]["sex"].ToString();
                dr["A7"] = dataSource1.Rows[i]["minzu"].ToString();
                dr["A8"] = dataSource1.Rows[i]["sno"].ToString();
                dr["A9"] = dataSource1.Rows[i]["sdate"].ToString();
                dr["A10"] = dataSource1.Rows[i]["nianli"].ToString();
                dr["A11"] = dataSource1.Rows[i]["address"].ToString();
                dr["A12"] = dataSource1.Rows[i]["youxiaodate"].ToString().Substring(0,10);
                dr["A13"] = dataSource1.Rows[i]["shenfenweizhi"].ToString();
                dr["A14"] = dataSource1.Rows[i]["school"].ToString();
                dr["A15"] = dataSource1.Rows[i]["zhuanye"].ToString();
                dr["A16"] = dataSource1.Rows[i]["xueli"].ToString();
                dr["A17"] = dataSource1.Rows[i]["biyedate"].ToString();
                dr["A18"] = dataSource1.Rows[i]["xueliflag"].ToString();
                dr["A19"] = dataSource1.Rows[i]["yuanjianflag"].ToString();
                dr["A20"] = dataSource1.Rows[i]["xueliweizhi"].ToString();

                dr["A21"] = dataSource1.Rows[i]["hetongcol1"].ToString();
                dr["A22"] = dataSource1.Rows[i]["hetongcol2"].ToString();
                dr["A23"] = dataSource1.Rows[i]["hetongcol3"].ToString();
                dr["A24"] = dataSource1.Rows[i]["hetongcol4"].ToString();
                dr["A25"] = dataSource1.Rows[i]["hetongcol5"].ToString();
                dr["A26"] = dataSource1.Rows[i]["hetongcol6"].ToString();
                dr["A27"] = dataSource1.Rows[i]["hetongcol7"].ToString();
                dr["A28"] = dataSource1.Rows[i]["hetongweizhi"].ToString();
                dr["A29"] = dataSource1.Rows[i]["txcol1"].ToString();
                dr["A30"] = dataSource1.Rows[i]["txcol2"].ToString();
                dr["A31"] = dataSource1.Rows[i]["txcol3"].ToString();
                dr["A32"] = dataSource1.Rows[i]["txcol4"].ToString();
                dr["A33"] = dataSource1.Rows[i]["txcol5"].ToString();
                dr["A34"] = dataSource1.Rows[i]["txcol6"].ToString();
                dr["A35"] = dataSource1.Rows[i]["txcol7"].ToString();
                dr["A36"] = dataSource1.Rows[i]["txcol8"].ToString();
                dr["A37"] = dataSource1.Rows[i]["ABCweizhi"].ToString();
                dr["A38"] = dataSource1.Rows[i]["txzccol1"].ToString();
                dr["A39"] = dataSource1.Rows[i]["txzccol2"].ToString();
                dr["A40"] = dataSource1.Rows[i]["txzccol3"].ToString();

                dr["A41"] = dataSource1.Rows[i]["txzccol4"].ToString();
                dr["A42"] = dataSource1.Rows[i]["txzccol5"].ToString();
                dr["A43"] = dataSource1.Rows[i]["txzccol6"].ToString();
                dr["A44"] = dataSource1.Rows[i]["txzccol7"].ToString();
                dr["A45"] = dataSource1.Rows[i]["txzccol8"].ToString();
                dr["A46"] = dataSource1.Rows[i]["zhichengweizhi"].ToString();
                dr["A47"] = dataSource1.Rows[i]["txyscol1"].ToString();
                dr["A48"] = dataSource1.Rows[i]["txyscol2"].ToString();
                dr["A49"] = dataSource1.Rows[i]["txyscol3"].ToString();
                dr["A50"] = dataSource1.Rows[i]["txyscol4"].ToString();

                dr["A51"] = dataSource1.Rows[i]["txyscol5"].ToString();
                dr["A52"] = dataSource1.Rows[i]["txyscol6"].ToString();
                dr["A53"] = dataSource1.Rows[i]["txyscol7"].ToString();
                dr["A54"] = dataSource1.Rows[i]["txyscol8"].ToString();
                dr["A55"] = dataSource1.Rows[i]["yusuanweizhi"].ToString();
                dr["A56"] = dataSource1.Rows[i]["jzABCcol1"].ToString();
                dr["A57"] = dataSource1.Rows[i]["jzABCcol2"].ToString();
                dr["A58"] = dataSource1.Rows[i]["jzABCcol3"].ToString();
                dr["A59"] = dataSource1.Rows[i]["jzABCcol4"].ToString();
                dr["A60"] = dataSource1.Rows[i]["jzABCcol5"].ToString();
                dr["A61"] = dataSource1.Rows[i]["jzABCcol6"].ToString();
                dr["A62"] = dataSource1.Rows[i]["jzABCcol7"].ToString();
                dr["A63"] = dataSource1.Rows[i]["jzABCcol8"].ToString();
                dr["A64"] = dataSource1.Rows[i]["jianzhuABCweizhi"].ToString();
                dr["A65"] = dataSource1.Rows[i]["yijicol1"].ToString();
                dr["A66"] = dataSource1.Rows[i]["yijicol2"].ToString();
                dr["A67"] = dataSource1.Rows[i]["yijicol3"].ToString();
                dr["A68"] = dataSource1.Rows[i]["yijicol4"].ToString();
                dr["A69"] = dataSource1.Rows[i]["yijicol5"].ToString();
                dr["A70"] = dataSource1.Rows[i]["yijicol6"].ToString();
                dr["A71"] = dataSource1.Rows[i]["yijicol7"].ToString();
                dr["A72"] = dataSource1.Rows[i]["yijicol8"].ToString();
                dr["A73"] = dataSource1.Rows[i]["yijizsweizhi"].ToString();
                dr["A74"] = dataSource1.Rows[i]["erjicol1"].ToString();
                dr["A75"] = dataSource1.Rows[i]["erjicol2"].ToString();
                dr["A76"] = dataSource1.Rows[i]["erjicol3"].ToString();
                dr["A77"] = dataSource1.Rows[i]["erjicol4"].ToString();
                dr["A78"] = dataSource1.Rows[i]["erjicol5"].ToString();
                dr["A79"] = dataSource1.Rows[i]["erjicol6"].ToString();
                dr["A80"] = dataSource1.Rows[i]["erjicol7"].ToString();
                dr["A81"] = dataSource1.Rows[i]["erjicol8"].ToString();
                dr["A82"] = dataSource1.Rows[i]["erjizsweizhi"].ToString();
                dr["A83"] = dataSource1.Rows[i]["jzzccol1"].ToString();
                dr["A84"] = dataSource1.Rows[i]["jzzccol2"].ToString();
                dr["A85"] = dataSource1.Rows[i]["jzzccol3"].ToString();
                dr["A86"] = dataSource1.Rows[i]["jzzccol4"].ToString();
                dr["A87"] = dataSource1.Rows[i]["jzzccol5"].ToString();
                dr["A88"] = dataSource1.Rows[i]["jzzccol6"].ToString();
                dr["A89"] = dataSource1.Rows[i]["jzzccol7"].ToString();
                dr["A90"] = dataSource1.Rows[i]["jzzccol8"].ToString();

                dr["A91"] = dataSource1.Rows[i]["jzzccol9"].ToString();
                dr["A92"] = dataSource1.Rows[i]["jzjscol1"].ToString();
                dr["A93"] = dataSource1.Rows[i]["jzjscol2"].ToString();
                dr["A94"] = dataSource1.Rows[i]["jzjscol3"].ToString();
                dr["A95"] = dataSource1.Rows[i]["jzjscol4"].ToString();
                dr["A96"] = dataSource1.Rows[i]["jzjscol5"].ToString();
                dr["A97"] = dataSource1.Rows[i]["jzjscol6"].ToString();
                dr["A98"] = dataSource1.Rows[i]["jzjscol7"].ToString();
                dr["A99"] = dataSource1.Rows[i]["jzjscol8"].ToString();
                dr["A100"] = dataSource1.Rows[i]["jzjscol9"].ToString();

                dr["A101"] = dataSource1.Rows[i]["txjscol1"].ToString();
                dr["A102"] = dataSource1.Rows[i]["txjscol2"].ToString();
                dr["A103"] = dataSource1.Rows[i]["txjscol3"].ToString();
                dr["A104"] = dataSource1.Rows[i]["txjscol4"].ToString();
                dr["A105"] = dataSource1.Rows[i]["txjscol5"].ToString();
                dr["A106"] = dataSource1.Rows[i]["txjscol6"].ToString();
                dr["A107"] = dataSource1.Rows[i]["txjscol7"].ToString();
                dr["A108"] = dataSource1.Rows[i]["txjscol8"].ToString();
                dr["A109"] = dataSource1.Rows[i]["txjscol9"].ToString();
                dr["A110"] = dataSource1.Rows[i]["tzzycol1"].ToString();

                dr["A111"] = dataSource1.Rows[i]["tzzycol2"].ToString();
                dr["A112"] = dataSource1.Rows[i]["tzzycol3"].ToString();
                dr["A113"] = dataSource1.Rows[i]["tzzycol4"].ToString();
                dr["A114"] = dataSource1.Rows[i]["tzzycol5"].ToString();
                dr["A115"] = dataSource1.Rows[i]["tzzycol6"].ToString();
                dr["A116"] = dataSource1.Rows[i]["tzzycol7"].ToString();
                dr["A117"] = dataSource1.Rows[i]["tzzycol8"].ToString();
                dr["A118"] = dataSource1.Rows[i]["tzzycol9"].ToString();

                DataTable dataSource2= new DataTable();

                sql = "select * from yuangongzs_1  where 1=1 and sID = " + dataSource1.Rows[i]["ID"].ToString() + "  ";

                dataSource2 = oledbHelper.GetDataTable(sql);
                for (int j = 0; j < dataSource2.Rows.Count; j++)
                {
                    dr["A119"] = dataSource2.Rows[j]["qita1col1"].ToString();
                    dr["A120"] = dataSource2.Rows[j]["qita2col1"].ToString();
                    dr["A121"] = dataSource2.Rows[j]["qita3col1"].ToString();
                    dr["A122"] = dataSource2.Rows[j]["qita4col1"].ToString();
                    dr["A123"] = dataSource2.Rows[j]["qita5col1"].ToString();
                    dr["A124"] = dataSource2.Rows[j]["qita6col1"].ToString();
                    dr["A125"] = dataSource2.Rows[j]["qita7col1"].ToString();
                    dr["A126"] = dataSource2.Rows[j]["qita8col1"].ToString();
                    dr["A127"] = dataSource1.Rows[i]["col1"].ToString();

                    dr["A128"] = dataSource2.Rows[j]["qita1col2"].ToString();
                    dr["A129"] = dataSource2.Rows[j]["qita2col2"].ToString();
                    dr["A130"] = dataSource2.Rows[j]["qita3col2"].ToString();
                    dr["A131"] = dataSource2.Rows[j]["qita4col2"].ToString();
                    dr["A132"] = dataSource2.Rows[j]["qita5col2"].ToString();
                    dr["A133"] = dataSource2.Rows[j]["qita6col2"].ToString();
                    dr["A134"] = dataSource2.Rows[j]["qita7col2"].ToString();
                    dr["A135"] = dataSource2.Rows[j]["qita8col2"].ToString();
                    dr["A136"] = dataSource1.Rows[i]["col2"].ToString();

                    dr["A137"] = dataSource2.Rows[j]["qita1col3"].ToString();
                    dr["A138"] = dataSource2.Rows[j]["qita2col3"].ToString();
                    dr["A139"] = dataSource2.Rows[j]["qita3col3"].ToString();
                    dr["A140"] = dataSource2.Rows[j]["qita4col3"].ToString();
                    dr["A141"] = dataSource2.Rows[j]["qita5col3"].ToString();
                    dr["A142"] = dataSource2.Rows[j]["qita6col3"].ToString();
                    dr["A143"] = dataSource2.Rows[j]["qita7col3"].ToString();
                    dr["A144"] = dataSource2.Rows[j]["qita8col3"].ToString();
                    dr["A145"] = dataSource1.Rows[i]["col3"].ToString();

                    dr["A146"] = dataSource2.Rows[j]["qita1col4"].ToString();
                    dr["A147"] = dataSource2.Rows[j]["qita2col4"].ToString();
                    dr["A148"] = dataSource2.Rows[j]["qita3col4"].ToString();
                    dr["A149"] = dataSource2.Rows[j]["qita4col4"].ToString();
                    dr["A150"] = dataSource2.Rows[j]["qita5col4"].ToString();
                    dr["A151"] = dataSource2.Rows[j]["qita6col4"].ToString();
                    dr["A152"] = dataSource2.Rows[j]["qita7col4"].ToString();
                    dr["A153"] = dataSource2.Rows[j]["qita8col4"].ToString();
                    dr["A154"] = dataSource1.Rows[i]["col4"].ToString();

                    dr["A155"] = dataSource2.Rows[j]["qita1col5"].ToString();
                    dr["A156"] = dataSource2.Rows[j]["qita2col5"].ToString();
                    dr["A157"] = dataSource2.Rows[j]["qita3col5"].ToString();
                    dr["A158"] = dataSource2.Rows[j]["qita4col5"].ToString();
                    dr["A159"] = dataSource2.Rows[j]["qita5col5"].ToString();
                    dr["A160"] = dataSource2.Rows[j]["qita6col5"].ToString();
                    dr["A161"] = dataSource2.Rows[j]["qita7col5"].ToString();
                    dr["A162"] = dataSource2.Rows[j]["qita8col5"].ToString();
                    dr["A163"] = dataSource1.Rows[i]["col5"].ToString();


                }

                dr["A164"] = dataSource1.Rows[i]["remark"].ToString();



                downloadTable.Rows.Add(dr);
            }

            MojoCube.Api.NPOIHelp.NPOIHelp.ExportXlsx2("/Admin/DownLoadTemplates/员工证件下载模板.xlsx", downloadTable, str);
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            Dictionary<string, Stream> streams = new Dictionary<string, Stream>();
            Stream streamWriter = null;
            int counts = 1000;


            foreach (GridViewRow r in GridView1.Rows)
            {
                string name = ((Label)r.FindControl("lbl姓名")).Text.Trim();
                //savePath = "E:/导出证件信息/" + name;

                if (((CheckBox)r.FindControl("uxDeleteCheckBox")).Checked)
                {

                    savePath = ((Label)r.FindControl("lbl身份证信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl身份证信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    

                    savePath = ((Label)r.FindControl("lbl学历信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl学历信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl劳动合同信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl劳动合同信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl通信类ABC证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl通信类ABC证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl通信类职称证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl通信类职称证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl通信类概预算证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl通信类概预算证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl建筑类ABC证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl建筑类ABC证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl一级建造师证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl一级建造师证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl二级建造师证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl二级建造师证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl建筑类职称证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl建筑类职称证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl建筑类技术工种证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl建筑类技术工种证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl通信类技术工种证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl通信类技术工种证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl特种作业证书信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl特种作业证书信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl其他证书1信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl其他证书1信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl其他证书2信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl其他证书2信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl其他证书3信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl其他证书3信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl其他证书4信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl其他证书4信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }

                    savePath = ((Label)r.FindControl("lbl其他证书5信息")).Text.Trim();
                    sourcePath = ((Label)r.FindControl("lbl其他证书5信息")).Text.Trim();

                    if (sourcePath != "")
                    {
                        string[] str1 = sourcePath.Split('/');
                        for (int k = 0; k < str1.Length; k++)
                        {
                            sourcePath = str1[str1.Length - 1].ToString();
                            savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                        }

                        string filePath = Server.MapPath(savePath);//路径
                        streamWriter = new FileStream(filePath, FileMode.Open);
                        //streamWriter.Close();
                        counts++;
                        sourcePath = counts + sourcePath;
                        streams.Add(sourcePath, streamWriter);
                    }
                 
                    //sourcePath = ((Label)r.FindControl("lbl身份证信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl学历信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl劳动合同信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl通信类ABC证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl通信类职称证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl通信类概预算证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl建筑类ABC证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl一级建造师证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl二级建造师证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl建筑类职称证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl建筑类技术工种证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl通信类技术工种证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl特种作业证书信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);

                    //sourcePath = ((Label)r.FindControl("lbl其他证书1信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl其他证书2信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl其他证书3信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl其他证书4信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    //sourcePath = ((Label)r.FindControl("lbl其他证书5信息")).Text.Trim();
                    //CopyOldLabFilesToNewLab(sourcePath, savePath);

                }
                else
                {
                    if (((CheckBox)r.FindControl("Chk身份证信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl身份证信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl身份证信息")).Text.Trim();
                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }

                        //sourcePath = ((Label)r.FindControl("lbl身份证信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk学历信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl学历信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl学历信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }

                        //sourcePath = ((Label)r.FindControl("lbl学历信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk劳动合同信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl劳动合同信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl劳动合同信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl劳动合同信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk通信类ABC证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl通信类ABC证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl通信类ABC证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl通信类ABC证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk通信类职称证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl通信类职称证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl通信类职称证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl通信类职称证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk通信类概预算证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl通信类概预算证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl通信类概预算证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl通信类概预算证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk建筑类ABC证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl建筑类ABC证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl建筑类ABC证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl建筑类ABC证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk一级建造师证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl一级建造师证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl一级建造师证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl一级建造师证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk二级建造师证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl二级建造师证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl二级建造师证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl二级建造师证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk建筑类职称证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl建筑类职称证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl建筑类职称证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl建筑类职称证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk建筑类技术工种证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl建筑类技术工种证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl建筑类技术工种证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl建筑类技术工种证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk通信类技术工种证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl通信类技术工种证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl通信类技术工种证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl通信类技术工种证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk特种作业证书信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl特种作业证书信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl特种作业证书信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl特种作业证书信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }

                    if (((CheckBox)r.FindControl("Chk其他证书1信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl其他证书1信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl其他证书1信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl其他证书1信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk其他证书2信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl其他证书2信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl其他证书2信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl其他证书2信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk其他证书3信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl其他证书3信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl其他证书3信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl其他证书3信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk其他证书4信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl其他证书4信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl其他证书4信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl其他证书4信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }
                    if (((CheckBox)r.FindControl("Chk其他证书5信息")).Checked)
                    {
                        savePath = ((Label)r.FindControl("lbl其他证书5信息")).Text.Trim();
                        sourcePath = ((Label)r.FindControl("lbl其他证书5信息")).Text.Trim();

                        if (sourcePath != "")
                        {
                            string[] str1 = sourcePath.Split('/');
                            for (int k = 0; k < str1.Length; k++)
                            {
                                sourcePath = str1[str1.Length - 1].ToString();
                                savePath = "员工个人信息证件/" + str1[str1.Length - 2].ToString() + "/" + sourcePath;

                            }

                            string filePath = Server.MapPath(savePath);//路径
                            streamWriter = new FileStream(filePath, FileMode.Open);
                            //streamWriter.Close();
                            counts++;
                            sourcePath = counts + sourcePath;
                            streams.Add(sourcePath, streamWriter);
                        }
                        //sourcePath = ((Label)r.FindControl("lbl其他证书5信息")).Text.Trim();
                        //CopyOldLabFilesToNewLab(sourcePath, savePath);
                    }

                
                }
            }

            MemoryStream ms = new MemoryStream();
            ms = PackageManyZip(streams);
            byte[] bytes = new byte[(int)ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode("打包文档.zip", System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                CheckBox item = ((CheckBox)r.FindControl("uxDeleteCheckBox"));
                if (!item.Checked)
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// 拷贝oldlab的文件到newlab下面
        /// </summary>
        /// <param name="sourcePath">lab文件所在目录(@"~\labs\oldlab")</param>
        /// <param name="savePath">保存的目标目录(@"~\labs\newlab")</param>
        /// <returns>返回:true-拷贝成功;false:拷贝失败</returns>
        public bool CopyOldLabFilesToNewLab(string sourcePath, string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            #region //拷贝labs文件夹到savePath下
            try
            {
                string[] labDirs = Directory.GetDirectories(sourcePath);//目录
                string[] labFiles = Directory.GetFiles(sourcePath);//文件
                if (labFiles.Length > 0)
                {
                    for (int i = 0; i < labFiles.Length; i++)
                    {
                        if (Path.GetExtension(labFiles[i]) != ".lab")//排除.lab文件
                        {
                            File.Copy(sourcePath + "\\" + Path.GetFileName(labFiles[i]), savePath + "\\" + Path.GetFileName(labFiles[i]), true);
                        }
                    }
                }
                if (labDirs.Length > 0)
                {
                    for (int j = 0; j < labDirs.Length; j++)
                    {
                        Directory.GetDirectories(sourcePath + "\\" + Path.GetFileName(labDirs[j]));

                        //递归调用
                        CopyOldLabFilesToNewLab(sourcePath + "\\" + Path.GetFileName(labDirs[j]), savePath + "\\" + Path.GetFileName(labDirs[j]));
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            #endregion
            return true;
        }

        static MemoryStream PackageManyZip(Dictionary<string, Stream> streams)
        {
            byte[] buffer = new byte[65000];
            MemoryStream returnStream = new MemoryStream();
            var zipMs = new MemoryStream();
            using (ZipOutputStream zipStream = new ZipOutputStream(zipMs))
            {
                zipStream.SetLevel(9);
                foreach (var kv in streams)
                {
                    string fileName = kv.Key.Substring(4, kv.Key.Length -4);
                    using (var streamInput = kv.Value)
                    {
                        zipStream.PutNextEntry(new ZipEntry(fileName));
                        while (true)
                        {
                            var readCount = streamInput.Read(buffer, 0, buffer.Length);
                            if (readCount > 0)
                            {
                                zipStream.Write(buffer, 0, readCount);
                            }
                            else
                            {
                                break;
                            }
                        }
                        zipStream.Flush();
                    }
                }
                zipStream.Finish();
                zipMs.Position = 0;
                zipMs.CopyTo(returnStream, 56000);
            }
            returnStream.Position = 0;
            return returnStream;
        }

        string chuli(string str)
        { 
            var m =str.Length;
            var n = str.IndexOf(" ");
            if (n == -1)
            {
                return str;
            }
            var j = str.Substring(n,m-n);
            var s = str.Replace(j,"");
            return s;
        }

    }
}