<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shenhecaozuo2.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shenhecaozuo2" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>审核</title>
    <meta name="keywords" content="审核" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" href="../Css/style.css" type="text/css" />
    <link rel="stylesheet" href="../Css/publice.css" type="text/css" />
    <link rel="shortcut icon" href="../Images/favicon.ico" type="image/x-icon" />
    <script type="text/javascript" src="../JS/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="../Skins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Css/font-awesome.min.css" />
    <link rel="stylesheet" href="../Css/ionicons.min.css" />
    <link rel="stylesheet" href="../Skins/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="../Css/main.css" />
    <script type="text/javascript" src="../JS/html5shiv.min.js"></script>
    <script type="text/javascript" src="../JS/respond.min.js"></script>
    <script type="text/javascript" src="../JS/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        function QueryByWindowOpen(purpose, identity, preload, limit) {

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            if (purpose == 'Allshenherenyuan2') {

                limit = document.getElementById('<%=TextBoxquanxian.ClientID %>').value;

            }

            window.open('/Admin/xiangmu/BASEQ04.aspx?QueryPurpose=' + purpose + '&&QueryIdentity=' + identity + '&&QueryPreload=' + preload + '&&QueryLimit=' + limit,
            "PopupWindow", 'left=' + PosX + ',top=' + PosY + ',height=350,width=800,scrollbars=yes');

        }

        function GetValueFromWindowOpen(object) {

            if (object.purpose == 'Allshenherenyuan2') {
                var hide1 = document.getElementById('<%=TextBox审核人员.ClientID %>');
                var hide2 = document.getElementById('<%=TextBox审核人员value.ClientID %>');

                hide1.value = object.col2;
                hide2.value = object.col1;

            }

        }

        function getValue(str) {

            var aaa = document.getElementById('<%=TextBox审核人员.ClientID %>').value;
            var objUserProductID = window.opener.document.getElementById('#queryForm');
            if (objUserProductID) {
                objUserProductID.value = aaa;
            };
            window.opener.document.getElementById("iConfirm").click();

            window.close();
        }

    </script>
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 400px;
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
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:TextBox ID="TextBox审核人员value" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="txtHideWHFrom" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxquanxian" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="container" style="margin-bottom: 20px; margin-top: 20px; overflow: auto;">
        <div class="main_con" style="font-size: 10px;">
            <div class="col-sm-12" style="width: 88%;">
                <!--进度条标签-->
                <div>
                    <div id="divMaskFrame" style="background-color: #F2F4F7; display: none; position: absolute;
                        left: 0px; top: 0px;">
                    </div>
                    <div id="divProgress" style="text-align: center; display: none; position: fixed;
                        top: 50%; left: 50%;">
                        <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Admin/Images/LoadingMask.gif" />
                    </div>
                </div>
                <div id="AlertDiv" runat="server">
                </div>
                <div class="row" style="margin-left: 100px;">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="200px"
                                    Text="审核人员：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox审核人员" TabIndex="13" Style="margin-left: 0px" Width="360px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                                    <span runat="server" id="span总包合同名称" >
                                        <button type="button" class="btn btn-default " onclick="QueryByWindowOpen('Allshenherenyuan2','TextBox合同名称', true,'合作合同');">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </button>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="200px"
                                    Height="66px" Text="审核意见：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox审核意见" TabIndex="11" Style="margin-left: 0px" Width="400px"
                                    runat="server" TextMode="MultiLine" Rows="3" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row" style="margin-left: 100px; margin-top: 100px">
                    <div class="col-sm-1 col-sm-offset-5">
                        <%--<input type="button" runat="server" id ="btnConfirm"  class="btn22" onclick="getValue('')" value="提交" />--%>
                        <asp:Button ID="Button1" runat="server" Text="提交" CssClass="btn22" Visible="false" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn提交2_Click" />
                        <asp:Button ID="Button2" runat="server" Text="提交" CssClass="btn22" Visible="false" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn审核通过_Click" />
                        <asp:Button ID="Button3" runat="server" Text="提交" CssClass="btn22" Visible="false" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn审核不通过_Click" />
                    </div>
                </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>
    </form>
</body>
</html>