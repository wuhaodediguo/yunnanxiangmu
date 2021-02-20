<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="SMS.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.SMS.SMS" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            短信通知管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            
          </ol>
        </section>
        <section class="content">

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
     
                <div class="box-body">
                <div class="row">
                  <div class="col-sm-1 col-sm-offset-2 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="手机号"></asp:Label></label>
                  </div>
                  <div class="col-sm-7 form-group">
                    <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>

                  <div class="row">
                  <div class="col-sm-1 col-sm-offset-2 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="运单号"></asp:Label></label>
                  </div>
                  <div class="col-sm-7 form-group">
                    <asp:TextBox ID="txtLogistics" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>


                  <div class="row">
                    <div class="col-sm-offset-9 col-sm-2 form-group">
                        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-primary" onclick="btnSearch_Click"></asp:Button>
                    </div>

                  <%--   <div class="col-sm-offset-9 col-sm-1 form-group">
                        <asp:Button ID="Button1" runat="server" Text="导出表格" CssClass="btn btn-primary" onclick="btnExport_Click"></asp:Button>
                          <asp:Button ID="btnDelete" runat="server" Text="批量删除" CssClass="btn btn-default" 
                          onclick="btnDelete_Click"></asp:Button>
                    </div>--%>
                  </div>

            </div>

                <div class="box-body table-responsive no-padding">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" ShowFooter="True">
                        <Columns>

                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="手机号" SortExpression="PhoneNum">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNum" runat="server" Text='<%# Bind("PhoneNum") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="运单号" SortExpression="LogisticsNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblLogisticsNo" runat="server" Text='<%# Bind("LogisticsNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送状态" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="发送时间" SortExpression="CreateTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateTime" runat="server" Text='<%# Bind("CreateTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                  <%--  <asp:TemplateField HeaderText="勾选删除">
                             <HeaderTemplate>
                                 <asp:CheckBox ID="cbAll" runat="server" Text="All" > </asp:CheckBox>
                               
                             </HeaderTemplate>
                            <ItemTemplate>
                            <asp:CheckBox ID="uxDeleteCheckBox" runat="server" /></ItemTemplate>
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
