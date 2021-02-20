<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="companyguoqi.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.companyguoqi" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            公司证件到期提醒
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">公司证件到期提醒</li>
          </ol>
        </section>

        <section class="content">
         <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                 
                  <div class="box-body">
   
                  </div>
                </div>
                
                <div class="box-body table-responsive no-padding">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="ID"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="证件类别">
                                <ItemTemplate>
                                    <asp:Label ID="lbl证件类别" runat="server" Text='<%# Bind("style") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="证件名称">
                                <ItemTemplate>
                                    <asp:Label ID="lbl证件名称" runat="server" Text='<%# Bind("zsname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="gongshizEdit.aspx?id={0}"
                        DataTextField="zsno" HeaderText="证件编号" Target="_blank" 
                        ItemStyle-HorizontalAlign="Left" />
                             <%--<asp:TemplateField HeaderText="证件编号">
                                <ItemTemplate>
                                    <asp:Label ID="lbl证件编号" runat="server" Text='<%# Bind("zsno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="发证机关">
                                <ItemTemplate>
                                    <asp:Label ID="lbl发证机关" runat="server" Text='<%# Bind("jiguan") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="到期时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl合同到期日期" runat="server" Text='<%# Bind("daqidate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                         
                            <%--<asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
