<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.User.Admin_User_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style type="text/css">
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 600px;
            overflow: hidden;
            margin-top: 0px;
        }
        .main_conL222 dl dd
        {
            width: 220px;
            height: 20px;
            margin-top: 10px;
            margin-left: 20px;
        }
        .btn22
        {
            display: inline-block;
            padding: 1px 1px;
            margin-bottom: 0;
            font-size: 12px;
            font-weight: normal;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
            background-color: RGB(60,141,188);
            border: 1px solid transparent;
            color: #fff;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 12px;
        }
        .btn11
        {
            background-color: transparent;
            border: 0px;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 14px;
            color: #9933FF;
        }
        .button
        {
            display: inline-block;
            position: relative;
            margin: 10px;
            padding: 0 20px;
            text-align: center;
            text-decoration: none;
            font: bold 12px/25px Arial, sans-serif;
            text-shadow: 1px 1px 1px rgba(255,255,255, .22);
            -webkit-border-radius: 30px;
            -moz-border-radius: 30px;
            border-radius: 30px;
            -webkit-box-shadow: 1px 1px 1px rgba(0,0,0, .29), inset 1px 1px 1px rgba(255,255,255, .44);
            -moz-box-shadow: 1px 1px 1px rgba(0,0,0, .29), inset 1px 1px 1px rgba(255,255,255, .44);
            box-shadow: 1px 1px 1px rgba(0,0,0, .29), inset 1px 1px 1px rgba(255,255,255, .44);
            -webkit-transition: all 0.15s ease;
            -moz-transition: all 0.15s ease;
            -o-transition: all 0.15s ease;
            -ms-transition: all 0.15s ease;
            transition: all 0.15s ease;
        }
    </style>
    <script type="text/javascript">
        //全选功能
        function SelectAllCheckboxes(spanChk) {

            elm = document.forms[0];
            for (i = 0; i <= elm.length - 1; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                    if (elm.elements[i].checked != spanChk.checked)
                        elm.elements[i].click();
                }
            }
        }

 </script>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                系统管理</a>&gt;用户管理
            </div>
        </div>
        <div class="main_con">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0071">
                        <a  runat="server" id="div0071" href="../Role/Name.aspx?active=11,12"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="系统管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0072">
                        <a runat="server" id="div0072" href="../User/List.aspx?active=11,82"><font color="blue">
                            <asp:Label ID="Label13" runat="server" Text="用户管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0073">
                        <a runat="server" id="div0073" href="../User/Profile.aspx"><font color="blue">
                            <asp:Label ID="Label14" runat="server" Text="用户面板" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0074">
                        <a runat="server" id="div0074" href="../BaseData/guige.aspx"><font color="blue">
                            <asp:Label ID="Label15" runat="server" Text="项目部管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd  runat="server" id="dd0075">
                        <a runat="server" id="div0075" href="../BaseData/xiangmujingli.aspx"><font color="blue">
                            <asp:Label ID="Label16" runat="server" Text="项目经理管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0076">
                        <a runat="server" id="div0076" href="../BaseData/pinzhong.aspx"><font color="blue">
                            <asp:Label ID="Label17" runat="server" Text="州市管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd  runat="server" id="dd0077">
                        <a runat="server" id="div0077" href="../BaseData/shenhe.aspx"><font color="blue">
                            <asp:Label ID="Label18" runat="server" Text="审核管理" Font-Size="14px"></asp:Label></font></a></dd>
                </dl>
            </div>
            <div class="col-sm-10" style="width: 88%;">
                <div id="AlertDiv" runat="server">
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-header">
                                <h3 class="box-title">
                                    <asp:HyperLink ID="hlAdd" runat="server"><span class="label label-success"><i class="fa fa-plus"></i> 新增</span></asp:HyperLink>
                                </h3>
                                <div class="box-tools">
                                    <div class="input-group" style="width: 150px;">
                                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm pull-right"
                                            placeholder="查找..."></asp:TextBox>
                                        <div class="input-group-btn">
                                            <asp:LinkButton ID="lnbSearch" runat="server" CssClass="btn btn-sm btn-default" OnClick="lnbSearch_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    BorderWidth="0px"  CssClass="table table-bordered" AllowSorting="True" OnSorting="GridView1_Sorting"
                                    OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                                    <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" SortExpression="pk_User" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_User") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="id" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblThumbnail" runat="server" Text='<%# Bind("ImagePath1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="真实姓名" HeaderStyle-CssClass="text-center" SortExpression="FullName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户名" HeaderStyle-CssClass="text-center" SortExpression="UserName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="角色" HeaderStyle-CssClass="text-center" SortExpression="RoleName_CHS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("RoleName_CHS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="电话" HeaderStyle-CssClass="text-center" SortExpression="Phone1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhone1" runat="server" Text='<%# Bind("Phone1") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--  <asp:TemplateField HeaderText="工资" SortExpression="Wages">
                                <ItemTemplate>
                                    <asp:Label ID="lblWages" runat="server" Text='<%# Bind("Wages") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div id="pager">
                                    <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged">
                                    </webdiyer:AspNetPager>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
