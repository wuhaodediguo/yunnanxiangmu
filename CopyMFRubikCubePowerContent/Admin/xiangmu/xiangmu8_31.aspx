﻿<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="xiangmu8_31.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.xiangmu8_31" %>

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
    <asp:TextBox ID="hdtemp" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                项目管理&gt;项目月报管理 <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        <div class="main_con">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0041">
                        <a runat="server" id="div0041" href="xiangmu1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="项目立项管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0045">
                        <a runat="server" id="div0045" href="xiangmu11.aspx"><font color="blue">
                            <asp:Label ID="Label12" runat="server" Text="项目审计管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0042">
                        <a runat="server" id="div0042" href="xiangmu2.aspx"><font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="项目资料管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0043">
                        <a runat="server" id="div0043" href="xiangmu3.aspx"><font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="项目综合管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0044">
                        <a runat="server" id="div0044" href="xiangmu4.aspx"><font color="blue">
                            <asp:Label ID="Label11" runat="server" Text="项目关闭管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0046">
                        <a runat="server" id="div0046" href="xiangmu8_1.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="项目月报管理" Font-Size="14px"></asp:Label></font></a></dd>
                </dl>
            </div>
            <div class="col-sm-10" style="width: 88%; height: 600px;">
                <div class="panel panel-default" style="width: 100%; height: 600px; overflow: auto;
                    margin-top: -5px; background-color: transparent;">
                    <div id="AlertDiv" runat="server">
                    </div>
                    <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
                        height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                        <h4 class="panel-title">
                            <strong><font color="blue" size="2px" font-weight="bold">项目月报明细列表</font></strong>
                        </h4>
                    </div>
                    <div class="tab-content" style="margin: 0px auto; font-size: 10px;">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBox1" runat="server" class="form-control input-sm" Width="140px"
                                        Text="年度：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox年度" TabIndex="11" Style="margin-left: 0px" Width="420px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="140px"
                                        Text="月份：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox月份" TabIndex="11" Style="margin-left: 0px" Width="420px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                           
                        </table>
                    </div>
                    <div class="row" style="margin: 5px auto; font-size: 12px; width: 100%;">
                        <div class="col-sm-1 " runat="server" id="div新建" visible="false">
                            <asp:Button ID="btnAdd" runat="server" Text="新建" CssClass="btn11" OnClick="btnAdd_Click"
                                OnClientClick="RotateAnimation(this); return ShowProgressBar();"></asp:Button>
                        </div>
                        <div class="col-sm-1 ">
                            <asp:Button ID="Button4" runat="server" Text="导出" CssClass="btn11" OnClick="btnExport_Click" />
                        </div>
                        <div class="col-sm-1 " runat="server" id="div删除" visible="false">
                            <asp:Button ID="Button5" runat="server" Text="删除" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn删除_Click" />
                        </div>
                        <div class="col-sm-1 ">
                            <asp:Button ID="Button2" runat="server" Text="返回" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn返回_Click" />
                        </div>
                        <div class="col-sm-6 col-sm-offset-1">
                            <asp:Label ID="Label合计1" TabIndex="13" Width="260px" Style="margin-left: 0px; border: 0;
                                font-size: 12px; color: red" runat="server" class="form-control input-sm" autocomplete="off"></asp:Label>
                            <asp:Label ID="Label合计2" TabIndex="13" Width="260px" Style="margin-left: 0px; border: 0;
                                font-size: 12px; color: red;" runat="server" class="form-control input-sm" autocomplete="off"></asp:Label>
                        </div>
                    </div>
                    <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 10px;">
                        <div class="table-responsive" style="width: 100%">
                            <asp:GridView ID="GridView1" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                                Height="10px" RowStyle-Height="5px" AutoGenerateColumns="False" BorderWidth="0px"
                                CssClass="table table-bordered" AllowSorting="True" OnSorting="GridView1_Sorting"
                                OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="30px"
                                                Height="20px" Style="text-align: center;"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年度" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>' Width="70px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="月份" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>' Width="70px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="项目部" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col3") %>' Width="110px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="项目经理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>' Width="180px" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="完成产值金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol11" runat="server"  Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="本月已经开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol13" runat="server" Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="下月计划开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol14" runat="server"  Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtn3" runat="server" Text="上报" Width="120px" CommandName="lbtn13">
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lbtn4" runat="server" Text="查看" Width="120px" CommandName="lbtn14">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl状态" Text='<%# Bind("col7") %>' runat="server" Width="100px" Style="text-align: center;"
                                                autocomplete="off"></asp:Label>
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
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>

