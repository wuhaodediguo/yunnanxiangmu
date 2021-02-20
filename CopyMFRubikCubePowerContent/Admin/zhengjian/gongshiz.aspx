<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="gongshiz.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.gongshiz" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            公司证件
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">公司证件</li>
          </ol>
        </section>

        <section class="content">
         <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">
                      <asp:HyperLink ID="hlAdd" runat="server"><span class="label label-success"><i class="fa fa-plus"></i> 新增</span></asp:HyperLink>
                  </h3>
                  <div class="box-body">
                        <div class="row">
                              <div class="col-sm-1 col-sm-offset-1 form-group">
                                <label><asp:Label ID="Label3" runat="server" Text="证件类别"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="txt证件类别" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label2" runat="server" Text="证件名称"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="txt证件名称" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label1" runat="server" Text="证件编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="txt证件编号" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                        </div>

                         <div class="row">
                             <div class="col-sm-1 col-sm-offset-9 form-group">
                                <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-primary" onclick="lnbSearch_Click" CausesValidation="false"></asp:Button>
                             </div>
                             <asp:Button ID="Button2" runat="server" Text="导出表格" CssClass="btn btn-primary" onclick="btnExport_Click"></asp:Button>
                          <asp:Button ID="Button3" runat="server" Text="全部勾选" CssClass="btn btn-default" OnClick="Button2_Click"
                                ></asp:Button>
                         </div>
                         <div class="row">
                            <div class="col-sm-1 col-sm-offset-9 form-group">
                                <asp:Button ID="btnDelete" runat="server" Text="批量导出公司证件" CssClass="btn btn-primary" 
                              onclick="btnDelete_Click"></asp:Button>
                            </div>
                         </div>
                        
                  </div>
                </div>
                <div class="box-body">
                    <asp:Button ID="btnDownloadTemplate" runat="server" Text="下载模板" CssClass="btn btn-link" onclick="btnDownloadTemplate_Click" CausesValidation="false"></asp:Button>
                 
                 <div class="btn btn-default btn-file" runat="server" id="divUpload">
                   <i class="fa fa-upload"></i> 选择上传文件
                  <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                 </div>
                 <asp:Button ID="btnUpload" runat="server" Text="批量导入" CssClass="btn btn-primary" onclick="btnUpload_Click" CausesValidation="false"></asp:Button>

                </div>
                <div class="panel panel-default" style=" width:100%;overflow:auto;">
                    <div class="panel-body" style=" width:100%">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True"
                         OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID" SortExpression="pk_User" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="证件类别">
                                <ItemTemplate>
                                    <asp:Label ID="lbl证件类别" runat="server" Text='<%# Bind("style") %>' Width="120px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="证件名称">
                                <ItemTemplate>
                                    <asp:Label ID="lbl证件名称" runat="server" Text='<%# Bind("zsname") %>' Width="240px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="证件编号">
                                <ItemTemplate>
                                    <asp:Label ID="lbl证件编号" runat="server" Text='<%# Bind("zsno") %>' Width="150px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="发证机关">
                                <ItemTemplate>
                                    <asp:Label ID="lbl发证机关" runat="server" Text='<%# Bind("jiguan") %>' Width="190px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发证日期" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl发证日期" runat="server" Text='<%# Bind("fazdate") %>' Width="90px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="到期时间" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl到期时间" runat="server" Text='<%# Bind("daqidate") %>' Width="90px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="有效期限" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl有效期限" runat="server" Text='<%# Bind("youxiaodate") %>' Width="90px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公司证件" ItemStyle-Width="100" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk公司证件信息" runat="server" Width="90px" ></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn公司证件信息" runat="server" Class="btn btn-warning"  Text="详细"
                                    CommandName="lbtn公司证件信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl存储位置" Visible="false" runat="server" Text='<%# Bind("weizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="备注" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl备注" runat="server" Text='<%# Bind("remark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改" Width="50px" Height="25px"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" Visible="false" Width="50px" Height="25px" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="勾选导出">
                            <ItemTemplate>
                                <asp:CheckBox ID="uxDeleteCheckBox" runat="server" Width="60px" /></ItemTemplate>
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
          </div>

        </section>

      </div>

</asp:Content>

