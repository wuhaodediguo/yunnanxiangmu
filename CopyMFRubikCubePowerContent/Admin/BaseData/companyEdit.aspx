<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="companyEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.BaseData.companyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            民族管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            
          </ol>
        </section>
        <section class="content">
         <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <div class="box-footer">
                
                <div class="col-md-2 form-group"  >
                    <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-primary" onclick="btnAdd_Click"></asp:Button>
                </div>
                 <div class="col-md-2 form-group"  >
                </div>
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消"  visible="false" CssClass="btn btn-default" onclick="btnCancel_Click" CausesValidation="false"></asp:Button>

            </div>
            <div class="row">
                <div class="col-md-2 form-group" runat="server" visible="false" id="div01" >
                    <label><asp:Label ID="lblColumn3" runat="server" Text="民族"></asp:Label></label>
                    <asp:TextBox ID="txtpinming" runat="server" CssClass="form-control"></asp:TextBox>
                   
                  </div>


                 
              </div>
                  
                  
                </div>

                <div class="box-body">

                  <div class="row">
                    <div class="col-sm-offset-9 col-sm-2 form-group">
                        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn btn-primary" onclick="btnSearch_Click" Visible="false"></asp:Button>
                    </div>

                     <div class="col-sm-offset-9 col-sm-3 form-group">
                        <%--<asp:Button ID="Button1" runat="server" Text="导出表格" CssClass="btn btn-primary" onclick="btnExport_Click"></asp:Button>--%>
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
                            <asp:TemplateField HeaderText="序号" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="民族" SortExpression="">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn1" runat="server" Text='<%# Bind("guige") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
       

                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField  HeaderText="勾选删除">
                            <ItemTemplate>
                                <asp:CheckBox ID="uxDeleteCheckBox" runat="server" /></ItemTemplate>
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
