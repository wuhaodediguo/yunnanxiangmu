<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.User.Admin_User_Profile" %>

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
                <div class="box box-default">
                    <div class="box-body">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBox10" runat="server" class="form-control input-sm" Width="195px"
                                        Text="<font color='red'>*</font>用户名：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" TabIndex="20" Style="margin-left: 0px" Width="380px" onfocus="this.blur();"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" class="form-control input-sm" Width="195px"
                                        Text="<font color='red'>*</font>电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhone1" TabIndex="20" Style="margin-left: 0px" Width="380px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" class="form-control input-sm" Width="195px"
                                        Text="<font color='red'>*</font>真实姓名：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFullName" TabIndex="20" Style="margin-left: 0px" Width="380px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" class="form-control input-sm" Width="195px"
                                        Text="<font color='red'>*</font>新的密码：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword1" TabIndex="20" Style="margin-left: 0px" Width="380px"
                                        TextMode="Password" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" class="form-control input-sm" Width="195px"
                                        Text="<font color='red'>*</font>确认密码：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword2" TabIndex="20" Style="margin-left: 0px" Width="380px"
                                        TextMode="Password" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="box-footer">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn22" OnClick="btnSave_Click">
                        </asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
