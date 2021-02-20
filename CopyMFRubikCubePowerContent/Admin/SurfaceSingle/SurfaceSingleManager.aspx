<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="SurfaceSingleManager.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.SurfaceSingle.SurfaceSingleManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            面单管理
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
                    <label><asp:Label ID="Label2" runat="server" Text="单号"></asp:Label></label>
                  </div>
                  <div class="col-sm-7 form-group">
                    <asp:TextBox ID="txtNo" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>
                  <div class="row">
                  <div class="col-sm-1 col-sm-offset-2 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="业务员"></asp:Label></label>
                  </div>
                  <div class="col-sm-7 form-group">
                    <asp:TextBox ID="txtCustomer" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>

                  <div class="row">
                  <div class="col-sm-1 col-sm-offset-2 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="创建日期"></asp:Label></label>
                  </div>
                  <div class="col-sm-3 form-group">
                    <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd 00:00:00'})"></asp:TextBox>
                  </div>
                  <div class="col-sm-1 form-group" style="margin-left: 30px; margin-right: auto; width:68px;">
                      <label><asp:Label ID="Label12" runat="server" Text="~"></asp:Label></label>
                  </div>
                  <div class="col-sm-3">
                    <asp:TextBox ID="txtDateEnd" runat="server" CssClass="form-control" onclick="WdatePicker({dateFmt:'yyyy-MM-dd 23:59:59'})"></asp:TextBox>
                  </div>
                  </div>

                  <div class="row">
                    <div class="col-sm-offset-9 col-sm-2 form-group">
                        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-primary" onclick="btnSearch_Click"></asp:Button>
                    </div>

                     <div class="col-sm-offset-9 col-sm-3 form-group">
                        <asp:Button ID="Button1" runat="server" Text="导出表格" CssClass="btn btn-primary" onclick="btnExport_Click"></asp:Button>
                         <asp:Button ID="Button2" runat="server" Text="全部勾选" CssClass="btn btn-default" OnClick="Button2_Click"
                          ></asp:Button>
                          <asp:Button ID="btnDelete" runat="server" Text="批量删除" CssClass="btn btn-default" 
                          onclick="btnDelete_Click"></asp:Button>
                    </div>
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
                            <asp:TemplateField HeaderText="发放时间" SortExpression="CreateDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateDate" runat="server" Text='<%# Bind("CreateDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="开始号" SortExpression="StartNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartNo" runat="server" Text='<%# Bind("StartNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="结束号" SortExpression="EndNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndNo" runat="server" Text='<%# Bind("EndNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="张数" SortExpression="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="业务员" SortExpression="Customer">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Customer") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注" SortExpression="Remark">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="勾选删除">
                            <%--<HeaderTemplate>
                                 <asp:CheckBox ID="cbAll" runat="server" Text="All" > </asp:CheckBox>
                               
                             </HeaderTemplate>--%>
                            <ItemTemplate>
                            <asp:CheckBox ID="uxDeleteCheckBox" runat="server" /></ItemTemplate>
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
    <script type="text/javascript">
        function SelectAll(aControl) {
            var tempControl = aControl;
            var isChecked = tempControl.checked;

            elem = tempControl.form.elements;
            for (i = 0; i < elem.length; i++)
                if (elem[i].type == "checkbox" && elem[i].id != tempControl.id) {
                    if (elem[i].checked != isChecked)
                        elem[i].click();
                }
        }
    </script>
</asp:Content>

