<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="zhengshudaoqi.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.zhengshudaoqi" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

<style type="text/css">
        .users {
    font-size:15px; 
    width:100px;

}
    </style>

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            员工证书到期提醒
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">员工证书到期提醒</li>
          </ol>
        </section>

        <section class="content" style=" width:100%">
         <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                 
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
                                <asp:TextBox ID="txt车主姓名" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                               
                        </div>

                         <div class="row">
                             <div class="col-sm-1 col-sm-offset-9 form-group">
                                <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-primary" onclick="lnbSearch_Click" CausesValidation="false"></asp:Button>
                             </div>
                             <asp:Button ID="Button2" runat="server" Text="导出表格" CssClass="btn btn-primary" onclick="btnExport_Click"></asp:Button>
                         </div>
                        
                  </div>
                </div>
                <%--<div class="box-body">
                    <asp:Button ID="btnDownloadTemplate" runat="server" Text="下载模板" CssClass="btn btn-link" onclick="btnDownloadTemplate_Click" CausesValidation="false"></asp:Button>
                 
                 <div class="btn btn-default btn-file" runat="server" id="divUpload">
                   <i class="fa fa-upload"></i> 选择上传文件
                  <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                 </div>
                 <asp:Button ID="btnUpload" runat="server" Text="批量导入" CssClass="btn btn-primary" onclick="btnUpload_Click" CausesValidation="false"></asp:Button>

                </div>--%>
                
                
              </div>
            </div>

            <div class="panel panel-default" style=" width:100%;overflow:auto;">
                 <div class="panel-body" style=" width:100%">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderWidth="0px" 
                    CssClass="table table-bordered table-hover table-condensed" AllowSorting="True" OnSorting="GridView1_Sorting" 
                    OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" Width="80%" >
                        <Columns >
                            <asp:TemplateField HeaderText="ID"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="id" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="州市">
                                <ItemTemplate>
                                    <asp:Label ID="lbl州市" runat="server" Text='<%# Bind("zhousi") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="所属项目部">
                                <ItemTemplate>
                                    <asp:Label ID="lbl所属项目部" runat="server" Text='<%# Bind("xiangmu") %>' Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="职务">
                                <ItemTemplate>
                                    <asp:Label ID="lbl职务" runat="server" Text='<%# Bind("zhiwu") %>' Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:Label ID="lbl姓名" runat="server" Text='<%# Bind("name") %>' Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="yuangongzsEdit.aspx?id={0}&weizhi=lbtn身份证信息"
                        DataTextField="sno" HeaderText="身份证" Target="_blank"  ItemStyle-Width="100px" HeaderStyle-Width="100px" ControlStyle-CssClass="users" ItemStyle-CssClass="users"
                        ItemStyle-HorizontalAlign="Left" />
                          
                           <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl身份证信息date" runat="server" Text='<%# Bind("youxiaodate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl劳动合同信息date" runat="server" Text='<%# Bind("hetongcol3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类ABC证书信息date" runat="server" Text='<%# Bind("txcol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类职称证书信息date" runat="server" Text='<%# Bind("txzccol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类概预算证书信息date" runat="server" Text='<%# Bind("txyscol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl建筑类ABC证书信息date" runat="server" Text='<%# Bind("jzABCcol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl一级建造师证书信息date" runat="server" Text='<%# Bind("yijicol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl二级建造师证书信息date" runat="server" Text='<%# Bind("erjicol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl建筑类职称证书信息date" runat="server" Text='<%# Bind("jzzccol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl建筑类技术工种证书信息date" runat="server" Text='<%# Bind("jzjscol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类技术工种证书信息date" runat="server" Text='<%# Bind("txjscol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书信息date" runat="server" Text='<%# Bind("tzzycol5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书1信息date" runat="server" Text='<%# Bind("qita5col1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书2信息date" runat="server" Text='<%# Bind("qita5col2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书3信息date" runat="server" Text='<%# Bind("qita5col3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书4信息date" runat="server" Text='<%# Bind("qita5col4") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书5信息date" runat="server" Text='<%# Bind("qita5col5") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="身份证信息">
                                <ItemTemplate>
                                    <asp:Label ID="lbl身份证信息" runat="server" Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="劳动合同信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl劳动合同信息" runat="server" Width="90px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类A/B/C证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类ABC证书信息" runat="server" Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类职称证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类职称证书信息" runat="server" Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="通信类概预算证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类概预算证书信息" runat="server" Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="建筑类A/B/C证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl建筑类ABC证书信息" runat="server" Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="一级建造师证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl一级建造师证书信息" runat="server" Width="140px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="二级建造师证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl二级建造师证书信息" runat="server" Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="建筑类职称证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl建筑类职称证书信息" runat="server" Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="建筑类技术工种证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl建筑类技术工种证书信息" runat="server" Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通信类技术工种证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl通信类技术工种证书信息" runat="server" Width="160px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="特种作业证书信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl特种作业证书信息" runat="server" Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书1信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl其他证书1信息" runat="server" Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书2信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl其他证书2信息" runat="server" Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书3信息"  >
                                <ItemTemplate>
                                    <asp:Label ID="lbl其他证书3信息" runat="server" Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书4信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl其他证书4信息" runat="server" Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他证书5信息" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl其他证书5信息" runat="server" Width="130px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl备注" runat="server" Text='<%# Bind("remark") %>'></asp:Label>
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
                    
                    <div id="pager" >
                       <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged"></webdiyer:AspNetPager>
                    </div>
        
                 </div>
                    
                </div>
          </div>

        </section>

      </div>

</asp:Content>

