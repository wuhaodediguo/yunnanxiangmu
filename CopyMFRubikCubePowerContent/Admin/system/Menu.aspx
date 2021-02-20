<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.system.Admin_System_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            菜单管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">菜单管理</li>
          </ol>
        </section>

        <section class="content">

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">
                      <asp:HyperLink ID="hlAdd" runat="server"><span class="label label-success"><i class="fa fa-plus"></i> 新增</span></asp:HyperLink>
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
                <div class="box-body table-responsive no-padding">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Menu") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ParentID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblParentID" runat="server" Text='<%# Bind("ParentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblName_CHS" runat="server" Text='<%# Bind("Name_CHS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="图标">
                                <ItemTemplate>
                                    <asp:Label ID="lblIcon" runat="server" Text='<%# Bind("Icon") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="160px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="路径">
                                <ItemTemplate>
                                    <asp:Label ID="lblUrl" runat="server" Text='<%# Bind("Url") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("TypeID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序">
                                <ItemTemplate>
                                    <asp:Label ID="lblSort" runat="server" Text='<%# Bind("SortID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" ForeColor="#999999" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="显示">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbVisible" runat="server" Checked='<%# Bind("Visible") %>' Enabled="False" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="gvUp" runat="server" ToolTip="上移" CommandName="_up"><span class="label label-back"><i class="fa fa-arrow-up"></i> 上移</span></asp:LinkButton>
                                    <asp:LinkButton ID="gvDown" runat="server" ToolTip="下移" CommandName="_down"><span class="label label-back"><i class="fa fa-arrow-down"></i> 下移</span></asp:LinkButton>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                    <asp:HyperLink ID="gvAdd" runat="server" Visible="False" ToolTip="新增"><span class="label label-success"><i class="fa fa-plus"></i> 新增</span></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
              </div>
            </div>
          </div>

        </section>

      </div>

</asp:Content>


