<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="yuangongzs.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.yuangongzs" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            员工证件
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">员工证件</li>
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
                                <label><asp:Label ID="Label4" runat="server" Text="姓名"></asp:Label></label>
                                <asp:TextBox ID="txt姓名" runat="server" CssClass="form-control"></asp:TextBox>
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
                                <asp:Button ID="btnDelete" runat="server" Text="批量导出员工证件" CssClass="btn btn-primary" 
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
                            <asp:TemplateField HeaderText="ID"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label ID="lblThumbnail" runat="server" Text='<%# Bind("ImagePath1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                             <%--<asp:TemplateField HeaderText="州市">
                                <ItemTemplate>
                                    <asp:Label ID="lbl州市" runat="server" Text='<%# Bind("zhousi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="所属项目部">
                                <ItemTemplate>
                                    <asp:Label ID="lbl所属项目部" runat="server" Text='<%# Bind("xiangmu") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="职务">
                                <ItemTemplate>
                                    <asp:Label ID="lbl职务" runat="server" Text='<%# Bind("zhiwu") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:Label ID="lbl姓名" runat="server" Text='<%# Bind("name") %>' Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="身份证信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk身份证信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn身份证信息" runat="server" Class="btn btn-warning"  Text="详细"   Width="70px"
                                    CommandName="lbtn身份证信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl身份证信息" Visible="false" runat="server" Text='<%# Bind("shenfenweizhi") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="学历信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk学历信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn学历信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn学历信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl学历信息" Visible="false" runat="server" Text='<%# Bind("xueliweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="劳动合同信息">
                                <ItemTemplate>
                                     <asp:CheckBox ID="Chk劳动合同信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn劳动合同信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn劳动合同信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl劳动合同信息" Visible="false" runat="server" Text='<%# Bind("hetongweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类A/B/C证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk通信类ABC证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn通信类ABC证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn通信类ABC证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl通信类ABC证书信息" Visible="false" runat="server" Text='<%# Bind("ABCweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类职称证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk通信类职称证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn通信类职称证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn通信类职称证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl通信类职称证书信息" Visible="false" runat="server" Text='<%# Bind("zhichengweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类概预算证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk通信类概预算证书信息" runat="server" Width="70px" ></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn通信类概预算证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn通信类概预算证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl通信类概预算证书信息" Visible="false" runat="server" Text='<%# Bind("yusuanweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="建筑类A/B/C证书信息">
                                <ItemTemplate>
                                     <asp:CheckBox ID="Chk建筑类ABC证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn建筑类ABC证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn建筑类ABC证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl建筑类ABC证书信息" Visible="false" runat="server" Text='<%# Bind("jianzhuABCweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="一级建造师证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk一级建造师证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn一级建造师证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn一级建造师证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl一级建造师证书信息" Visible="false" runat="server" Text='<%# Bind("yijizsweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="二级建造师证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk二级建造师证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn二级建造师证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn二级建造师证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl二级建造师证书信息" Visible="false" runat="server" Text='<%# Bind("erjizsweizhi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="建筑类职称证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk建筑类职称证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn建筑类职称证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn建筑类职称证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl建筑类职称证书信息" Visible="false" runat="server" Text='<%# Bind("jzzccol9") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="建筑类技术工种证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk建筑类技术工种证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn建筑类技术工种证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn建筑类技术工种证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl建筑类技术工种证书信息" Visible="false" runat="server" Text='<%# Bind("jzjscol9") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类技术工种证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk通信类技术工种证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn通信类技术工种证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn通信类技术工种证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl通信类技术工种证书信息" Visible="false" runat="server" Text='<%# Bind("txjscol9") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="特种作业证书信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk特种作业证书信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn特种作业证书信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn特种作业证书信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl特种作业证书信息" Visible="false" runat="server" Text='<%# Bind("tzzycol9") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="其他证书1信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk其他证书1信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn其他证书1信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn其他证书1信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl其他证书1信息" Visible="false" runat="server" Text='<%# Bind("col1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书2信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk其他证书2信息" runat="server" Width="70px" ></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn其他证书2信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn其他证书2信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl其他证书2信息" Visible="false" runat="server" Text='<%# Bind("col2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书3信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk其他证书3信息" runat="server" Width="70px" ></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn其他证书3信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn其他证书3信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl其他证书3信息" Visible="false" runat="server" Text='<%# Bind("col3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="其他证书4信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk其他证书4信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn其他证书4信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn其他证书4信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl其他证书4信息" Visible="false" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书5信息">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk其他证书5信息" runat="server" Width="70px"></asp:CheckBox>
                                    <asp:LinkButton ID="lbtn其他证书5信息" runat="server" Class="btn btn-warning"  Text="详细" Width="70px"
                                    CommandName="lbtn其他证书5信息">
                                </asp:LinkButton>
                                    <asp:Label ID="lbl其他证书5信息" Visible="false" runat="server" Text='<%# Bind("col5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改" Width="50px" Height="25px"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" Visible="false" Width="50px" Height="25px" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
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

