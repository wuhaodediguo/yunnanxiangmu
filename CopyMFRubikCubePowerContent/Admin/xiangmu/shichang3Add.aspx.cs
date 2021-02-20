using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Web;
using System.IO;
using System.Data;
using MojoCube.Api.Excel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public partial class shichang3Add : System.Web.UI.Page
    {
        public string temp1
        {
            get { return Request.Params.Get("temp1"); }
        }
        public string temp2
        {
            get { return Request.Params.Get("temp2"); }
        }
        public string temp3
        {
            get { return Request.Params.Get("temp3"); }
        }
        
        public string temp7
        {
            get { return Request.Params.Get("temp7"); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                quanxian();
                TextBox创建人.Text = this.Session["FullName"].ToString();
                TextBox创建日期.Text = System.DateTime.Now.ToString("yyyy年-MM月-dd日");
                TextBox创建人.Attributes.Add("readOnly", "readOnly");
                TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    if (id == "")
                    {
                        return;
                    }
                    this.ViewState["ID"] = base.Request.QueryString["id"].ToString();

                    DataSet ds = Sql.SqlQueryDS("select * from t_keshang where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");

                        txt客户名称.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        DropDown客户属性.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        DropDown客户性质.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox三证合一证号.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox客户联系人.Text = ds.Tables[0].Rows[0]["col5"].ToString();
                        TextBox客户联系电话.Text = ds.Tables[0].Rows[0]["col6"].ToString();
                        TextBox联系人职务.Text = ds.Tables[0].Rows[0]["col7"].ToString();
                        TextBox纳税人识别号.Text = ds.Tables[0].Rows[0]["col8"].ToString();
                        TextBox地址.Text = ds.Tables[0].Rows[0]["col9"].ToString();
                        TextBox电话.Text = ds.Tables[0].Rows[0]["col10"].ToString();
                        TextBox开户银行.Text = ds.Tables[0].Rows[0]["col11"].ToString();
                        TextBox开户账号.Text = ds.Tables[0].Rows[0]["col12"].ToString();
                        TextBox创建人.Text = ds.Tables[0].Rows[0]["col13"].ToString();
                        TextBox创建日期.Text = ds.Tables[0].Rows[0]["col14"].ToString();
                        TextBox客户证照资料.Text = ds.Tables[0].Rows[0]["col15"].ToString();
                        
                        TextBox备注.Text = ds.Tables[0].Rows[0]["col16"].ToString();
                        //if (TextBox客户证照资料.Text != "")
                        //{
                        //    客户证照资料href.HRef = TextBox客户证照资料.Text;
                        //    客户证照资料href.Visible = true;
                        //}

                        DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'shichang31' and col1='" + id + "' ");
                        if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                            GridView1.DataSource = ds2.Tables[0];
                            GridView1.DataBind();
                            ViewState["GridDataSource"] = ds2.Tables[0];
                        }
                        else
                        {
                            HdCol2附件1.Value = "";
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }

                    }

                    string model = base.Request.QueryString["model"];
                    if (model == "view")
                    {
                        DropDown客户属性.Enabled = false;
                        DropDown客户性质.Enabled = false;
                        txt客户名称.Attributes.Add("readOnly", "readOnly");
                        TextBox三证合一证号.Attributes.Add("readOnly", "readOnly");
                        TextBox客户联系人.Attributes.Add("readOnly", "readOnly");
                        TextBox客户联系电话.Attributes.Add("readOnly", "readOnly");
                        TextBox联系人职务.Attributes.Add("readOnly", "readOnly");
                        TextBox纳税人识别号.Attributes.Add("readOnly", "readOnly");
                        TextBox地址.Attributes.Add("readOnly", "readOnly");
                        TextBox电话.Attributes.Add("readOnly", "readOnly");
                        TextBox开户银行.Attributes.Add("readOnly", "readOnly");
                        TextBox开户账号.Attributes.Add("readOnly", "readOnly");
                        TextBox创建人.Attributes.Add("readOnly", "readOnly");
                        TextBox创建日期.Attributes.Add("readOnly", "readOnly");
                        TextBox客户证照资料.Attributes.Add("readOnly", "readOnly");
                        TextBox备注.Attributes.Add("readOnly", "readOnly");
                        FileUpload1.Visible = false;
                        Button5.Enabled = false;
                        Button1.Visible = false;
                        btnAttach.Visible = false;
                       
                    }

                }

            }
            else
            {
                this.AlertDiv.InnerHtml = "";
            }
        }

        private void quanxian()
        {
            DataTable dataSource = new DataTable();
            OledbHelper oledbHelper = new OledbHelper();
            dataSource = oledbHelper.GetDataTable("select * from t_quanxian where col4 = '" + this.Session["UserName"] + "' order by col1 ");
            if (dataSource.Rows.Count > 0)
            {
                for (int i = 0; i < dataSource.Rows.Count; i++)
                {
                    if (dataSource.Rows[2]["col2"].ToString() == "1" && dataSource.Rows[2]["col1"].ToString() == "div0021")
                    {
                        dd0021.Visible = true;
                    }
                    else
                    {
                        dd0021.Visible = false;
                    }
                    if (dataSource.Rows[3]["col2"].ToString() == "1" && dataSource.Rows[3]["col1"].ToString() == "div0022")
                    {
                        dd0022.Visible = true;
                    }
                    else
                    {
                        dd0022.Visible = false;
                    }
                    if (dataSource.Rows[4]["col2"].ToString() == "1" && dataSource.Rows[4]["col1"].ToString() == "div0023")
                    {
                        dd0023.Visible = true;
                    }
                    else
                    {
                        dd0023.Visible = false;
                    }

                }

            }
            else
            {
                div0021.Visible = false;
                div0022.Visible = false;
                div0023.Visible = false;

            }
        }


        protected void btn保存_Click(object sender, EventArgs e)
        {
            if (this.txt客户名称.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写客户名称");
                return;
            }
            if (this.DropDown客户属性.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写客户属性");
                return;
            }
            if (this.DropDown客户性质.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写客户性质");
                return;
            }
            if (this.TextBox三证合一证号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写三证合一证号");
                return;
            }
            if (this.TextBox纳税人识别号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写纳税人识别号");
                return;
            }
            if (this.TextBox地址.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写地址");
                return;
            }
            if (this.TextBox电话.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写电话");
                return;
            }
            if (this.TextBox开户银行.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开户银行");
                return;
            }
            if (this.TextBox开户账号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写开户账号");
                return;
            }

            keshangList keshangList = new keshangList();
            keshangList.col1 = txt客户名称.Text.Trim();
            keshangList.col2 = DropDown客户属性.Text.Trim();
            keshangList.col3 = DropDown客户性质.Text.Trim();
            keshangList.col4 = TextBox三证合一证号.Text.Trim();
            keshangList.col5 = TextBox客户联系人.Text.Trim();
            keshangList.col6 = TextBox客户联系电话.Text.Trim();
            keshangList.col7 = TextBox联系人职务.Text.Trim();
            keshangList.col8 = TextBox纳税人识别号.Text.Trim();
            keshangList.col9 = TextBox地址.Text.Trim();
            keshangList.col10 = TextBox电话.Text.Trim();
            keshangList.col11 = TextBox开户银行.Text.Trim();
            keshangList.col12 = TextBox开户账号.Text.Trim();
            keshangList.col13 = TextBox创建人.Text.Trim();

            keshangList.col14 = TextBox创建日期.Text.Trim();
            if (this.GridView1.Rows.Count == 0)
            {
                keshangList.col15 = "0";
            }
            else
            {
                keshangList.col15 = "1";
            }
            //keshangList.col15 = TextBox客户证照资料.Text.Trim();
            keshangList.col16 = TextBox备注.Text.Trim();

            int ssID = 0;
            if (this.ViewState["ID"] != null)
            {
                keshangList.ID = int.Parse(this.ViewState["ID"].ToString());
                keshangList.UpdateData(keshangList.ID);
                ssID = keshangList.ID;
            }
            else
            {
                keshangList.GetAllData2(keshangList.col1, keshangList.col2, keshangList.col3);
                if (keshangList.ID > 0)
                {
                    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "已存在客户名称，客户属性，客户性质一样的数据，请修改再保存。");
                    return;
                }
                ssID = keshangList.InsertData();
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string ID = ((Label)GridView1.Rows[i].FindControl("lblID2")).Text.ToString();
                附件List 附件List = new 附件List();
                附件List.col1 = ssID.ToString();

                附件List.UpdateData(int.Parse(ID));
            }

            base.Response.Redirect("shichang3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp7=" + temp7 + "");
        }

        protected void btn返回_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("shichang3.aspx?temp1=" + temp1 + "&temp2=" + temp2 + "&temp3=" + temp3 + "&temp7=" + temp7 + "");
        }

        protected void FileUpload客户证照资料Button_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(filePath + fileName);

                客户证照资料href.HRef = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                //TextBox客户证照资料.Text = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;
                附件List 附件List = new 附件List();
                附件List.flag = "shichang31";
                附件List.col1 = this.ViewState["ID"] == null ? "" : this.ViewState["ID"].ToString();
                附件List.col2 = HdCol2附件1.Value == "" ? CreateNext() : HdCol2附件1.Value;
                附件List.col3 = "/Admin/xiangmu/公司证件UploadFile/" + aaa + fileName;

                附件List.InsertData();

                DataSet ds2 = Sql.SqlQueryDS("select * from t_fujian where flag = 'shichang31' and col2='" + 附件List.col2 + "' ");
                if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                {
                    HdCol2附件1.Value = ds2.Tables[0].Rows[0]["col2"].ToString();
                    GridView1.DataSource = ds2.Tables[0];
                    GridView1.DataBind();
                    ViewState["GridDataSource"] = ds2.Tables[0];
                }
                else
                {
                    HdCol2附件1.Value = "";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }


                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        string CreateNext()
        {
            OledbHelper oledbHelper = new OledbHelper();
            Decimal count = 0;
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            string strdate = DateTime.Now.ToString("yyyyMMdd");
            sql = "select max(col2) as col1 from t_fujian where 1=1 and col2 like '%" + strdate + "%'  ";
            
            dataSource = oledbHelper.GetDataTable(sql);
            if (dataSource.Rows.Count > 0)
            {
                string number = dataSource.Rows[0][0].ToString();
                if (number != "" && number.Length > 8)
                {
                    number = dataSource.Rows[0][0].ToString().Substring(8, 4);
                    count = Convert.ToDecimal(number);
                }

            }
            return DateTime.Now.ToString("yyyyMMdd") + (++count).ToString("0000");
        }


        protected void btnAttach_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("公司证件UploadFile/") + TextBox客户证照资料.Text.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                TextBox客户证照资料.Text = "";
                客户证照资料href.HRef = "";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var temp = ((HyperLink)e.Row.FindControl("HyperLink1")).Text;
                if (temp != "")
                {
                    var temps = temp.LastIndexOf("/");
                    if (temps > 0)
                    {
                        var temps2 = temp.Substring(temps);
                        ((HyperLink)e.Row.FindControl("HyperLink1")).Text = temps2;
                    }

                }
                string model = base.Request.QueryString["model"];
                if (model == "view")
                {
                    ((LinkButton)e.Row.FindControl("gvDelete")).Visible = false;
                }

            }




        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            附件List 附件List = new 附件List();
            if (e.CommandName == "_delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string rowIDs = Convert.ToString(((Label)row.FindControl("lblID")).Text);
                string strlblcol2 = Convert.ToString(((Label)row.FindControl("lblcol2")).Text);
                string strlblcol1 = Convert.ToString(((Label)row.FindControl("lblcol1")).Text);

                DataTable dt = (DataTable)ViewState["GridDataSource"];
                DataTable dtnew = dt.Clone();
                DataRow dr;
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string strNoID = ((Label)GridView1.Rows[i].FindControl("lblID")).Text.ToString();
                    if (rowIDs != strNoID)
                    {
                        dr = dt.Rows[i];
                        dtnew.Rows.Add(dr.ItemArray);

                    }
                }
                ViewState["GridDataSource"] = dtnew;
                this.GridView1.DataSource = dtnew;
                this.GridView1.DataBind();

                string IDs = Convert.ToString(((Label)row.FindControl("lblID2")).Text);
                if (IDs != "")
                {
                    附件List.DeleteData(int.Parse(IDs));

                    var fileName = Server.MapPath("公司证件UploadFile/") + strlblcol2.Replace("/Admin/xiangmu/公司证件UploadFile/", "");

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }

            }
        }


        
    }
}