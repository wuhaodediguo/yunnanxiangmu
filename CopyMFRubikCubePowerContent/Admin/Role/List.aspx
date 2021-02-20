<%@ Page Language="C#"   masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.Role.Admin_Role_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            <asp:Label ID="Label1" runat="server"></asp:Label>
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active"><asp:Label ID="Label2" runat="server"></asp:Label></li>
          </ol>
        </section>

        <section class="content">
        
          <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">
                      <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
                  </h3>
                </div>
                <div class="box-body table-responsive no-padding">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
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
                            <asp:TemplateField HeaderText="开启权限">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbUse" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="管理模式">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbAdmin" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
            </div>

              </div>
            </div>
          </div>

        </section>

      </div>

</asp:Content>




