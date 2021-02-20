<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="cheliangzj.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.cheliangzj" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            车辆证件
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">车辆证件</li>
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
                               <div class="col-md-2 col-sm-offset-2 form-group">
                                    <label><asp:Label ID="Label3" runat="server" Text="州市"></asp:Label></label>
                                    <asp:Dropdownlist ID="Drop州市" runat="server" CssClass="form-control"></asp:Dropdownlist>
                              </div>
                              <div class="col-md-2 form-group">
                                <label><asp:Label ID="Label2" runat="server" Text="所属项目部"></asp:Label></label>
                                <asp:Dropdownlist ID="Drop所属项目部" runat="server" CssClass="form-control"></asp:Dropdownlist>
                              </div>
                                <div class="col-md-2 form-group">
                                <label><asp:Label ID="Label4" runat="server" Text="车主姓名"></asp:Label></label>
                                <asp:TextBox ID="txt车主姓名" runat="server" CssClass="form-control"></asp:TextBox>
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
                                <asp:Button ID="btnDelete" runat="server" Text="批量导出车辆证件" CssClass="btn btn-primary" 
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
                <div class="box-body table-responsive no-padding">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" CssClass="table table-hover" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                        <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
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
                             <asp:TemplateField HeaderText="州市">
                                <ItemTemplate>
                                    <asp:Label ID="lbl州市" runat="server" Text='<%# Bind("zhousi") %>' Width="40px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="所属项目部">
                                <ItemTemplate>
                                    <asp:Label ID="lbl所属项目部" runat="server" Text='<%# Bind("xiangmu") %>' Width="120px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="车主姓名">
                                <ItemTemplate>
                                    <asp:Label ID="lbl车主姓名" runat="server" Text='<%# Bind("chezhuname") %>' Width="70px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="车牌号码">
                                <ItemTemplate>
                                    <asp:Label ID="lbl车牌号码" runat="server" Text='<%# Bind("cheno") %>' Width="80px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                           
                            <asp:TemplateField HeaderText="发动机号码">
                                <ItemTemplate>
                                    <asp:Label ID="lbl发动机号码" runat="server" Text='<%# Bind("col1") %>' Width="80px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="车辆类型">
                                <ItemTemplate>
                                    <asp:Label ID="lbl车辆类型" runat="server" Text='<%# Bind("col2") %>' Width="80px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品牌型号">
                                <ItemTemplate>
                                    <asp:Label ID="lbl品牌型号" runat="server" Text='<%# Bind("col3") %>' Width="80px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="制造商">
                                <ItemTemplate>
                                    <asp:Label ID="lbl制造商" runat="server" Text='<%# Bind("col4") %>' Width="100px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="购置年份">
                                <ItemTemplate>
                                    <asp:Label ID="lbl购置年份" runat="server" Text='<%# Bind("col5") %>' Width="80px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="检验有效期" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl检验有效期" runat="server" Text='<%# Bind("jianchayouxiaodate") %>' Width="80px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否到期" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl是否到期" runat="server" Text='<%# Bind("jianchadaqi") %>' Width="70px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="租车协议到期时间" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl租车协议到期时间" runat="server" Text='<%# Bind("zuchedate") %>' Width="120px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="是否到期" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl租车协议到期时间是否到期" runat="server" Text='<%# Bind("zuchedaiqi") %>' Width="70px" CssClass="text-left"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="行车证储存位置">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk行车证储存位置" runat="server" Width="120px" ></asp:CheckBox>
                                     <asp:LinkButton ID="lbtn行车证储存位置" runat="server" Class="btn btn-warning"  Text="详细"
                                    CommandName="lbtn行车证储存位置">
                                     </asp:LinkButton>
                                    <asp:Label ID="lbl行车证储存位置" Visible="false" runat="server" Text='<%# Bind("xingchezhengweizhi") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="车辆照片储存位置">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk车辆照片储存位置" runat="server" Width="120px"   ></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn车辆照片储存位置" runat="server" Class="btn btn-warning"  Text="详细"
                                    CommandName="lbtn车辆照片储存位置">
                                     </asp:LinkButton>
                                    <asp:Label ID="lbl车辆照片储存位置" Visible="false" runat="server" Text='<%# Bind("cheliangzpweizhi") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="租车协议储存位置">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk租车协议储存位置" runat="server" Width="120px"  ></asp:CheckBox>
                                     <asp:LinkButton ID="lbtn租车协议储存位置" runat="server" Class="btn btn-warning"  Text="详细"
                                    CommandName="lbtn租车协议储存位置">
                                     </asp:LinkButton>
                                    <asp:Label ID="lbl租车协议储存位置" Visible="false" runat="server" Text='<%# Bind("zucheweizhi") %>' ></asp:Label>
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

        </section>

      </div>

</asp:Content>


