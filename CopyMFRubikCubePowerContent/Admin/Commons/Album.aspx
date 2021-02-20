<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.Commons.Album" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSimple" Runat="Server">

      <div class="content-wrapper-simple">

        <section class="content">

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header with-border">
                  <h3 class="box-title">
                       <asp:DropDownList ID="ddlCategory1" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged" Height="30px"></asp:DropDownList>
                  </h3>
                  <div class="box-tools">
                    <div class="input-group" style="width: 150px;">
                      <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm pull-right" placeholder="查找..."></asp:TextBox>
                      <div class="input-group-btn">
                        <asp:LinkButton ID="lnbSearch" runat="server" CssClass="btn btn-sm btn-default" onclick="lnbSearch_Click"><i class="fa fa-search"></i></asp:LinkButton>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                  <li class="active"><a href="#image" data-toggle="tab">图片</a></li>
                  <li><a href="#upload" data-toggle="tab">上传</a></li>
                  <li><a href="#category" data-toggle="tab">分类</a></li>
                </ul>
                <div class="tab-content">
                  
                  <div class="active tab-pane" id="image">
                  
                  <div class="box-body">
                        <div class="row">
                        
                            <script type="text/javascript">
                                function InsertImage(imgUrl) {
                                    var editor = window.parent.CKEDITOR.instances.ctl00_cphMain_txtDescription_CKEditor;
                                    editor.insertHtml('<img src="' + imgUrl + '" style="border:0" />');
                                    window.parent.$.fancybox.close();
                                }

                                function delImage(id) {
                                    if (window.confirm('确定删除该图片吗？')) {
                                        window.location.href = "Album.aspx?del=" + id;
                                        return true;
                                    }
                                    else {
                                        return false;
                                    }
                                }
                            </script>

                            <div id="ImageDiv" runat="server"></div>

                        </div>
                    </div>
                    
                    <div class="box-footer no-padding" style="margin-top:-10px; border:0px;">
                      <div class="mailbox-controls">
                  
                        <div id="pager" style="background:#fff; border:0px; margin-top:0px; padding:2px;">
                           <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged"></webdiyer:AspNetPager>
                        </div>
        
                      </div>
                    </div>

                  </div>

                  <div class="tab-pane" id="upload">

                    <div class="box-body">
                    
                      <div class="row">
                            
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label3" runat="server" Text="分类"></asp:Label></label>
                            <asp:DropDownList ID="ddlCategory2" runat="server" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                  
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label4" runat="server" Text="标题"></asp:Label></label>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                      </div>
                        
                      <div class="row">
              
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label17" runat="server" Text="图片"></asp:Label></label>
                            <div class="form-group">
                                <div class="btn btn-default btn-file">
                                    <i class="fa fa-upload"></i> 上传图片
                                    <asp:FileUpload ID="fuImage" runat="server"></asp:FileUpload>
                                </div>
                            </div>
                          </div>
                  
                      </div>

                    </div>
            
                    <div class="box-footer">
                        <asp:Button ID="btnSave" runat="server" Text="上传" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                    </div>

                  </div>
                  
                  <div class="tab-pane" id="category">

                    <div class="box-body">
                    
                      <div class="row">
                            
                        <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label2" runat="server" Text="名称"></asp:Label></label>
                            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                      </div>
                        
                    </div>
            
                    <div class="box-footer">
                        <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-primary" onclick="btnAdd_Click"></asp:Button>
                    </div>
                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Category") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="标题">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCategoryNameGV" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序">
                                <ItemTemplate>
                                    <asp:Label ID="lblSortID" runat="server" Text='<%# Bind("SortID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="显示">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbVisible" runat="server" Checked='<%# Bind("Visible") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="gvUp" runat="server" ToolTip="上移" CommandName="_up"><span class="label label-back"><i class="fa fa-arrow-up"></i> 上移</span></asp:LinkButton>
                                    <asp:LinkButton ID="gvDown" runat="server" ToolTip="下移" CommandName="_down"><span class="label label-back"><i class="fa fa-arrow-down"></i> 下移</span></asp:LinkButton>
                                    <asp:LinkButton ID="gvSave" runat="server" ToolTip="保存" CommandName="_save"><span class="label label-primary"><i class="fa fa-save"></i> 保存</span></asp:LinkButton>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                  </div>

                </div>
              </div>

              </div>
            </div>
          </div>

        </section>

      </div>

</asp:Content>


