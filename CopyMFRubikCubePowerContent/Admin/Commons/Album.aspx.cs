using MojoCube.Api.File;
using MojoCube.Api.Text;
using MojoCube.Api.UI;
using MojoCube.Web;
using MojoCube.Web.Image;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace CopyMFRubikCubePowerContent.Admin.Commons
{
    public partial class Album : MyPage, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["del"] != null)
                {
                    List list = new List();
                    list.DeleteData(int.Parse(base.Request.QueryString["del"]));
                }
                this.ViewState["OrderByKey"] = "pk_Image";
                this.ViewState["OrderByType"] = true;
                this.GridBind();
                this.CategoryBind();
                base.Title = "系统相册";
            }
        }

        protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ViewState["CategoryID"] = this.ddlCategory1.SelectedValue;
            this.GridBind();
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
            adminPager.PageSize = 12;
            adminPager.ConnStr = Connection.ConnString();
            adminPager.TableName = "Image_List";
            adminPager.strGetFields = "*";
            string text = " where FileSize>0";
            ArrayList arrayList = new ArrayList();
            if (this.ViewState["CategoryID"] != null && this.ViewState["CategoryID"].ToString() != "0")
            {
                text = text + " and fk_Category=" + this.ViewState["CategoryID"].ToString();
            }
            if (this.txtKeyword.Text.Trim() != "")
            {
                string value = CheckSql.Filter(this.txtKeyword.Text.Trim());
                text += " and (Title like '%'+?+'%')";
                arrayList.Add(value);
            }
            adminPager.where = text;
            adminPager.parameter = arrayList;
            adminPager.fldName = this.ViewState["OrderByKey"].ToString();
            adminPager.OrderType = (bool)this.ViewState["OrderByType"];
            this.ImageDiv.InnerHtml = this.CreateImage(adminPager.GetTable());
        }

        private string CreateImage(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                string text = string.Empty;
                string text2 = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    text = "../Files.aspx?image=" + Security.EncryptString(dt.Rows[i]["FilePath"].ToString());
                    text2 = base.Request.ApplicationPath + "/Files.aspx?image=" + Security.EncryptString(dt.Rows[i]["FilePath"].ToString());
                    text2 = text2.Replace("//", "/");
                    stringBuilder.Append("<div class=\"image-item\">");
                    stringBuilder.Append("<div class=\"image-item-img\">");
                    stringBuilder.Append(string.Concat(new string[]
				{
					"<a href=\"",
					text,
					"\" class=\"fancybox fancybox.image\" data-fancybox-group=\"gallery\" title=\"",
					dt.Rows[i]["Title"].ToString(),
					"\"><img src=\"",
					text,
					"&w=200&h=200\" style=\"width:100px;\" /></a>"
				}));
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("<div class=\"image-item-btn\">");
                    stringBuilder.Append("<a href=\"javascript:InsertImage('" + text2 + "');\"><i class=\"fa fa-plus\"></i> 插入</a>");
                    stringBuilder.Append("<a href=\"#\" class=\"del\" onclick=\"delImage(" + dt.Rows[i]["pk_Image"].ToString() + ");\"><i class=\"fa fa-remove\"></i> 删除</a>");
                    stringBuilder.Append("</div>");
                    stringBuilder.Append("</div>");
                }
            }
            return stringBuilder.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload();
            upload.FilePath = "Image";
            upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
            upload.DoFileUpload(this.fuImage);
            if (upload.IsUpload)
            {
                List list = new List();
                list.fk_Category = int.Parse(this.ddlCategory2.SelectedValue);
                list.FileName = upload.OldFileName;
                list.FilePath = upload.OldFilePath;
                list.FileType = upload.FileType;
                list.FileSize = upload.FileSize;
                list.Width = 0;
                list.Height = 0;
                if (upload.IsImage())
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(this.fuImage.PostedFile.InputStream);
                    list.Width = image.Width;
                    list.Height = image.Height;
                }
                list.Title = this.txtTitle.Text.Trim();
                list.CreateDate = DateTime.Now.ToString();
                list.CreateUserID = int.Parse(this.Session["UserID"].ToString());
                list.ModifyDate = DateTime.Now.ToString();
                list.ModifyUserID = 0;
                list.Language = MojoCube.Api.UI.Language.GetLanguage();
                list.InsertData();
                this.GridBind();
            }
        }

        private void CategoryBind()
        {
            DataTable dataSource = Sql.SqlQueryDS("select * from Image_Category order by SortID asc").Tables[0];
            this.GridView1.DataSource = dataSource;
            this.GridView1.DataBind();
            Sql.DropDownListBind(this.ddlCategory1, "Image_Category", "CategoryName", "pk_Category", "Visible=True", "SortID", "asc", new ListItem("全部图片", "0"));
            Sql.DropDownListBind(this.ddlCategory2, "Image_Category", "CategoryName", "pk_Category", "Visible=True", "SortID", "asc", new ListItem("默认分类", "0"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtCategoryName.Text.Trim() != "")
            {
                new Category
                {
                    CategoryName = this.txtCategoryName.Text.Trim(),
                    ParentID = 0,
                    SortID = 0,
                    Visible = true,
                    CreateDate = DateTime.Now.ToString(),
                    CreateUserID = int.Parse(this.Session["UserID"].ToString()),
                    ModifyDate = DateTime.Now.ToString(),
                    ModifyUserID = 0,
                    Language = MojoCube.Api.UI.Language.GetLanguage()
                }.InsertData();
                this.CategoryBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                MojoCube.Web.String.ShowDel(e);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string[] controlList = new string[]
		{
			"gvUp",
			"gvDown",
			"gvSave",
			"gvDelete"
		};
            AdminGridView.SetDataRow(e, controlList);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Category category = new Category();
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "_save")
            {
                category.GetData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
                category.CategoryName = ((TextBox)this.GridView1.Rows[index].FindControl("txtCategoryNameGV")).Text;
                category.Visible = ((CheckBox)this.GridView1.Rows[index].FindControl("cbVisible")).Checked;
                category.UpdateData(category.pk_Category);
            }
            if (e.CommandName == "_delete")
            {
                category.DeleteData(int.Parse(((Label)this.GridView1.Rows[index].FindControl("lblID")).Text));
            }
            if (e.CommandName == "_up")
            {
                Sql.SetSortID("Image_Category", "pk_Category", ((Label)this.GridView1.Rows[index].FindControl("lblID")).Text, -1);
            }
            if (e.CommandName == "_down")
            {
                Sql.SetSortID("Image_Category", "pk_Category", ((Label)this.GridView1.Rows[index].FindControl("lblID")).Text, 1);
            }
            this.CategoryBind();
        }
    }
}