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


namespace CopyMFRubikCubePowerContent.Admin.zhengjian
{
    public partial class cheliangzjEdit : System.Web.UI.Page
    {
        private static string puserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                getDrop州市();
                getDrop所属项目部();
                puserID = base.Session["RoleValue"].ToString();
                this.hlBack.NavigateUrl = "cheliangzj.aspx?active=" + base.Request.QueryString["active"];
                //txt行车证储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox车辆照片储存位置.Attributes.Add("readOnly", "readOnly");
                //TextBox租车协议储存位置.Attributes.Add("readOnly", "readOnly");
                //txt是否到期.Attributes.Add("readOnly", "readOnly");
                //txt租车协议到期时间是否到期.Attributes.Add("readOnly", "readOnly");

                if (base.Request.QueryString["id"] != null)
                {
                    string id = base.Request.QueryString["id"].ToString();
                    DataSet ds = Sql.SqlQueryDS("select * from cheliangzs where id=" + id + "");
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Drop州市.Text = ds.Tables[0].Rows[0]["zhousi"].ToString();
                        Drop所属项目部.Text = ds.Tables[0].Rows[0]["xiangmu"].ToString();
                        txt车主姓名.Text = ds.Tables[0].Rows[0]["chezhuname"].ToString();
                        TextBox车牌号码.Text = ds.Tables[0].Rows[0]["cheno"].ToString();
                        txt检验有效期.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["jianchayouxiaodate"].ToString()).ToString("yyyy-MM-dd");
                        txt是否到期.Text = ds.Tables[0].Rows[0]["jianchadaqi"].ToString();
                        txt租车协议到期时间.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["zuchedate"].ToString()).ToString("yyyy-MM-dd");
                        txt租车协议到期时间是否到期.Text = ds.Tables[0].Rows[0]["zuchedaiqi"].ToString();
                        txt行车证储存位置.Text = ds.Tables[0].Rows[0]["xingchezhengweizhi"].ToString();
                        TextBox车辆照片储存位置.Text = ds.Tables[0].Rows[0]["cheliangzpweizhi"].ToString();
                        TextBox租车协议储存位置.Text = ds.Tables[0].Rows[0]["zucheweizhi"].ToString();
                        txt备注.Text = ds.Tables[0].Rows[0]["remark"].ToString();

                        TextBox发动机号码.Text = ds.Tables[0].Rows[0]["col1"].ToString();
                        TextBox车辆类型.Text = ds.Tables[0].Rows[0]["col2"].ToString();
                        TextBox品牌型号.Text = ds.Tables[0].Rows[0]["col3"].ToString();
                        TextBox制造商.Text = ds.Tables[0].Rows[0]["col4"].ToString();
                        TextBox购置年份.Text = ds.Tables[0].Rows[0]["col5"].ToString();

                        if (txt行车证储存位置.Text != "")
                        {
                            行车证href.HRef = txt行车证储存位置.Text;
                            行车证href.Visible = true;
                        }
                        if (TextBox车辆照片储存位置.Text != "")
                        {
                            车辆照片href.HRef = TextBox车辆照片储存位置.Text;
                            车辆照片href.Visible = true;
                        }
                        if (TextBox租车协议储存位置.Text != "")
                        {
                            租车协议href.HRef = TextBox租车协议储存位置.Text;
                            行车证href.Visible = true;
                        }

                    }

                    
                }

                if (puserID != "1")
                {
                  
                    Drop州市.Enabled = false;
                    Drop所属项目部.Enabled = false;
                    txt车主姓名.ReadOnly = true;
                    TextBox车牌号码.ReadOnly = true;
                    txt检验有效期.Enabled = false;
                    txt是否到期.ReadOnly = true;
                    txt是否到期.ReadOnly = true;
                    txt租车协议到期时间.Enabled = false;
                    txt租车协议到期时间是否到期.ReadOnly = true;
                    txt行车证储存位置.ReadOnly = true;
                    TextBox车辆照片储存位置.ReadOnly = true;
                    TextBox租车协议储存位置.ReadOnly = true;
                    txt备注.ReadOnly = true;

                    TextBox发动机号码.ReadOnly = true;
                    TextBox车辆类型.ReadOnly = true;
                    TextBox品牌型号.ReadOnly = true;
                    TextBox制造商.ReadOnly = true;
                    TextBox购置年份.ReadOnly = true;


                    MyFileUpload.Visible = false;
                    FileUploadButton.Visible = false;
                    FileUpload2.Visible = false;
                    Button2.Visible = false;
                    FileUpload1.Visible = false;
                    Button1.Visible = false;
                    btnSave.Visible = false;
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Drop州市.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写州市");
                return;
            }
            if (this.Drop所属项目部.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写所属项目部");
                return;
            }
            if (this.txt车主姓名.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写车主姓名");
                return;
            }

            if (this.TextBox车牌号码.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写车牌号码");
                return;
            }

            if (this.TextBox发动机号码.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写发动机号码");
                return;
            }
            if (this.TextBox车辆类型.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写车辆类型");
                return;
            }
            if (this.TextBox品牌型号.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写品牌型号");
                return;
            }
            if (this.TextBox制造商.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写制造商");
                return;
            }
            if (this.TextBox购置年份.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写购置年份");
                return;
            }

            if (this.txt检验有效期.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写检验有效期");
                return;
            }
            if (this.txt租车协议到期时间.Text.Trim() == "")
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写租车协议到期时间");
                return;
            }


            cheliangzsList list = new cheliangzsList();
            if (this.ViewState["pk_DispatchWaybill"] != null)
            {
            }
            else
            {
                list.zhousi = this.Drop州市.Text.Trim();
                list.xiangmu = this.Drop所属项目部.Text.Trim();
                list.chezhuname = this.txt车主姓名.Text.Trim();
                list.cheno = this.TextBox车牌号码.Text.Trim();
                list.jianchayouxiaodate = this.txt检验有效期.Text.Trim();
                list.jianchadaqi = this.txt是否到期.Text.Trim();
                list.zuchedate = this.txt租车协议到期时间.Text.Trim();
                list.zuchedaiqi = this.txt租车协议到期时间是否到期.Text.Trim();
                list.xingchezhengweizhi = this.txt行车证储存位置.Text.Trim();
                list.cheliangzpweizhi = this.TextBox车辆照片储存位置.Text.Trim();
                list.zucheweizhi = this.TextBox租车协议储存位置.Text.Trim();
                list.remark = this.txt备注.Text.Trim();

                list.col1 = this.TextBox发动机号码.Text.Trim();
                list.col2 = this.TextBox车辆类型.Text.Trim();
                list.col3 = this.TextBox品牌型号.Text.Trim();
                list.col4 = this.TextBox制造商.Text.Trim();
                list.col5 = this.TextBox购置年份.Text.Trim();

                if (base.Request.QueryString["id"] != null)
                {

                    list.ID = int.Parse(base.Request.QueryString["id"]);
                    if (list.UpdateData() > 0)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                        //清空文本框

                        base.Response.Redirect("cheliangzj.aspx?active=" + base.Request.QueryString["active"]);
                    }
                    //else
                    //{
                    //    this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                    //}
                }
                else
                {
                    if (list.InsertData() > 0)
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
                        //清空文本框
                        ClearTextBox();
                    }
                    else
                    {
                        this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "数据保存失败");
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.AlertDiv.InnerHtml = "";
        }
        private void ClearTextBox()
        {
            Drop州市.Text = "";
            Drop所属项目部.Text = "";
            txt车主姓名.Text = "";
            TextBox车牌号码.Text = "";
            txt检验有效期.Text = "";
            txt是否到期.Text = "";
            txt租车协议到期时间.Text = "";
            txt租车协议到期时间是否到期.Text = "";
            txt行车证储存位置.Text = "";
            TextBox车辆照片储存位置.Text = "";
            TextBox租车协议储存位置.Text = "";
            txt备注.Text = "";
            txt备注.Text = "";

        }

        protected void txt检验有效期_TextChanged(object sender, EventArgs e)
        {
            if (txt检验有效期.Text == "")
            {
                txt是否到期.Text = "已经过期";
            }
            else
            {
                if (DateTime.Compare(Convert.ToDateTime(txt检验有效期.Text), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                {
                    txt是否到期.Text = "已经到期";
                }
                else if (DateTime.Compare(Convert.ToDateTime(txt检验有效期.Text), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) > 0)
                {
                    txt是否到期.Text = "";
                }
                else if (DateTime.Compare(Convert.ToDateTime(txt检验有效期.Text), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(txt检验有效期.Text), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                {
                    txt是否到期.Text = "即将到期";
                }
                else if (DateTime.Compare(Convert.ToDateTime(txt检验有效期.Text), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                {
                    txt是否到期.Text = "已经过期";
                }
            }
            

        }

        protected void txt租车协议到期时间_TextChanged(object sender, EventArgs e)
        {
            if (txt租车协议到期时间.Text == "")
            {
                txt租车协议到期时间是否到期.Text = "已经过期";
            }
            else
            {
                if (DateTime.Compare(Convert.ToDateTime(txt租车协议到期时间.Text), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) == 0)
                {
                    txt租车协议到期时间是否到期.Text = "已经到期";
                }
                else if (DateTime.Compare(Convert.ToDateTime(txt租车协议到期时间.Text), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) > 0)
                {
                    txt租车协议到期时间是否到期.Text = "";
                }
                else if (DateTime.Compare(Convert.ToDateTime(txt租车协议到期时间.Text), Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"))) < 0 && DateTime.Compare(Convert.ToDateTime(txt租车协议到期时间.Text), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) > 0)
                {
                    txt租车协议到期时间是否到期.Text = "即将到期";
                }
                else if (DateTime.Compare(Convert.ToDateTime(txt租车协议到期时间.Text), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0)
                {
                    txt租车协议到期时间是否到期.Text = "已经过期";
                }
            }
            
        }

        protected void FileUpload行车证Button_Click(object sender, EventArgs e)
        {
            if (MyFileUpload.HasFile)
            {
                //string filePath = Server.MapPath("公司证件UploadFile/");
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = MyFileUpload.PostedFile.FileName;
                MyFileUpload.SaveAs(filePath + fileName);

                行车证href.HRef = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;
               
                txt行车证储存位置.Text = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload车辆照片Button_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                } 
                string fileName = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(filePath + fileName);

                车辆照片href.HRef = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;
                TextBox车辆照片储存位置.Text = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }

        protected void FileUpload租车协议Button_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string aaa = DateTime.Now.ToString("yyyyMMddhhmmss") + "/";
                string filePath = Server.MapPath("公司证件UploadFile/") + aaa;
               
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName = FileUpload2.PostedFile.FileName;
                FileUpload2.SaveAs(filePath + fileName);

                租车协议href.HRef = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;
                TextBox租车协议储存位置.Text = "/Admin/zhengjian/公司证件UploadFile/" + aaa + fileName;

                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "上传成功");

            }
            else
            {
                this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请选择要上传的文件!");

            }
        }


        //
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "行车证储存位置";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = txt行车证储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


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


        //
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "车辆照片储存位置";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox车辆照片储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string sourcePath = "";
            string savePath = "";

            string name = "租车协议储存位置";
            savePath = "E:/导出证件信息/" + name;
            sourcePath = TextBox租车协议储存位置.Text.Trim();
            CopyOldLabFilesToNewLab(sourcePath, savePath);
            this.AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "文件已经下载到" + savePath);


        }

    }
}