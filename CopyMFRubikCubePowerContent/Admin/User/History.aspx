<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.User.Admin_User_History" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            历史记录
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">历史记录</li>
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

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="标题" SortExpression="Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                    <asp:Label ID="lblUrl" runat="server" Text='<%# Bind("Url") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="时间" SortExpression="CreateDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateDate" runat="server" Text='<%# Bind("CreateDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvView" runat="server" ToolTip="查看"><span class="label label-primary"><i class="fa fa-search"></i> 查看</span></asp:HyperLink>
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


