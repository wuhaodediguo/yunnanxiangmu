<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"
        name="viewport" />
    <link rel="shortcut icon" href="Images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="Skins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Css/font-awesome.min.css" />
    <link rel="stylesheet" href="Css/ionicons.min.css" />
    <link rel="stylesheet" href="Skins/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="Skins/dist/css/skins/skin-blue.min.css" />
    <link rel="stylesheet" href="Skins/plugins/iCheck/flat/blue.css" />
    <!--[if lt IE 9]>
        <script src="JS/html5shiv.min.js"></script>
        <script src="JS/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function ChangeImage() {
            var now = new Date();
            var number = now.getSeconds();
            document.getElementById('CodeImage').src = "Identify/CheckCode.aspx?id=" + number;
        }

       
    </script>
    <style type="text/css">
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 440px;
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
            font-size: 9px;
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
            font-size: 9px;
        }
        .btn11
        {
            background-color: transparent;
            border: 0px;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 9px;
            color: RGB(85,164,249);
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
        .login-wrap{ position:absolute; top:50%; left:50%; margin:-150px auto auto -140px; width:280px; text-align:center; }
	.login-logo{ margin-right:10%; text-indent:-9999em; width:36px; height:42px; }
	.login-form .col{ position:relative; padding:10px 0; }
	.login-form .col .icon{ position:absolute; display:block; top:22px; left:10px; width:14px; height:14px; cursor:pointer; }
    .login-form .col .icon i{ color:#ccc; font-size:14px; line-height:1em; vertical-align:middle; }
	.login-form .col .login-input{ display:block; padding:5px 10px 5px 34px; background:#fff; border:0; border-radius:3px; font-size:14px; line-height:32px; *line-height:30px; height:32px; width:136px; color:#333; }
	.login-form .col .login-btn{ display:block; padding:5px 0; font-size:14px; color:#fff; width:50%; line-height:28px; height:42px; background:#0C4B77; border:0; border-radius:3px; letter-spacing:.5em; cursor:pointer; }
.login-tips{ display:block; margin:10px auto 0; height:14px; vertical-align:middle; }
	.login-tips i{ display:inline-block; margin-right:5px; width:14px; height:14px; color:#83b7ce; font-size:12px; line-height:14px; vertical-align:middle; zoom:1; *display:inline; }
	.login-tips p{ display:inline-block;height:14px; line-height:14px; font-size:12px; font-weight:normal; color:#83b7ce; vertical-align:middle; zoom:1; *display:inline; }
    </style>
</head>
<body class="hold-transition login-page" style="background: url(Images/登录logo.jpg) no-repeat #FFFFFF;
    background-size: 100%;">
    <div class="login-box" style="margin-top: 12%; margin-right: 8%;">
        <div class="login-logo">
            <asp:HyperLink ID="hlLogo" runat="server"></asp:HyperLink>
        </div>
        <%--<p class="login-box-pic" style="background:url(Images/登录02.jpg) no-repeat RGB(121,180,230);background-size:100%;  height: 80px; width: 360px;margin-left:80px;margin-top:20px;"></p>--%>
        <p class="login-box-pic" style="background-size: 100%; height: 90px; width: 80%;">
        </p>
        <form id="form1" runat="server">
        <asp:TextBox ID="hd用户" runat="server" class="form-control" Style="display: none"></asp:TextBox>
        <div id="AlertDiv" runat="server" style="margin-right: 55%">
        </div>
        <div class="container" style="width: 100%">
            <ul class="list-inline control-menu">
                <li style=" width:70px;">用户名:</li>
                <li class="control-item">
                    <asp:TextBox ID="txtUserName" runat="server" Width="150px" CssClass="form-control"
                        autocomplete="off"></asp:TextBox>
                </li>
            </ul>
            <ul class="list-inline control-menu">
                <li style=" width:70px;">密&nbsp;&nbsp;&nbsp;&nbsp;码:</li>
                <li class="control-item">
                    <asp:TextBox ID="txtPassword" runat="server" Width="150px" CssClass="form-control"
                        autocomplete="off" TextMode="Password"></asp:TextBox>
                </li>
            </ul>
            <ul class="list-inline control-menu">
                <li style=" width:70px;">
                    <asp:Button ID="btn验证码" runat="server" Text="验证码"  Height="30px" 
                        CssClass="btn btn-primary" OnClick="btnSendSMS_Click" /></li>
                <li class="control-item">
                    <asp:TextBox ID="TextBox验证码" runat="server" Width="150px" placeholder="请输入验证码" CssClass="form-control"
                        autocomplete="off"></asp:TextBox>
                </li>
            </ul>
            <ul class="list-inline control-menu">
                <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                <li>
                    <asp:Button ID="btnLogin" runat="server" Text="登录" Width="60px" Height="30px" CssClass="btn btn-primary"
                        OnClick="btnLogin_Click" /></li>
                <li class="control-item">
                    <asp:Button ID="btn重置" runat="server" Text="重置" Width="60px" Height="30px" CssClass="btn btn-primary"
                        OnClientClick="return cleanForm()" />
                </li>
            </ul>
        </div>
        <%-- <table cellspacing="0" style="border: 0; margin-right: 55%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="用户名：" Width="60px" Font-Bold="true" ForeColor="Blue"
                        Style="text-align: right"></asp:Label>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td style="height: 5px;">
                </td>
                <td style="height: 5px;">
                </td>
                <td style="height: 5px;">
                </td>
                <td style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="密&nbsp;&nbsp;&nbsp;&nbsp;码：" Font-Bold="true"
                        Width="60px" ForeColor="Blue" Style="text-align: right"></asp:Label>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td style="height: 5px;">
                </td>
                <td style="height: 5px;">
                </td>
                <td style="height: 5px;">
                </td>
                <td style="height: 5px;">
                </td>
                
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                   
                </td>
            </tr>
        </table>
        <table cellspacing="0" style="border: 0; margin-right: 45%;">
            <tr>
                <td style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;" Width="25px"></asp:Label>
                </td>
                <td>
                    
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;" Width="30px"></asp:Label>
                </td>
                <td>
                   
                </td>
            </tr>
        </table>--%>
        
        <div class="row">
            <div class="col-xs-4">
            </div>
        </div>
        </form>
    </div>
    <script src="Skins/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <script src="Skins/bootstrap/js/bootstrap.min.js"></script>
    <script src="Skins/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_flat-blue',
                radioClass: 'iradio_flat-blue',
                increaseArea: '20%'
            });
        });
    </script>
</body>
</html>
