<%@ Page Language="C#"  masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="Online.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.User.Admin_User_Online" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            在线用户
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">在线用户</li>
          </ol>
        </section>

        <section class="content">

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">
                      <asp:HyperLink ID="hlPrint" runat="server" NavigateUrl="javascript:McPrint();"><span class="label label-primary"><i class="fa fa-print"></i> 打印</span></asp:HyperLink>
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

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" SortExpression="pk_Online">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Online") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="类型" SortExpression="TypeID">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("TypeID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="账号" SortExpression="UserName">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="名称" SortExpression="FullName">
                                <ItemTemplate>
                                    <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="部门" SortExpression="DepartmentName">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IP" SortExpression="IPAddress">
                                <ItemTemplate>
                                    <asp:Label ID="lblIPAddress" runat="server" Text='<%# Bind("IPAddress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="登录时间" SortExpression="LoginTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblLoginTime" runat="server" Text='<%# Bind("LoginTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    <div id="pager">
                       <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged"></webdiyer:AspNetPager>
                    </div>
        
                </div>
                
              </div>
            </div>
          </div>

        </section>

      </div>

</asp:Content>



