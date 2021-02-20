<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print1.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.print1" %>

<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8;width=device-width, initial-scale=1.0, user-scalable=no">
</head>
<body>
    <script type="text/javascript">
        function LinkPrintPage() {

            window.print();
        }

    </script>
    <style>
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
            font-size: 12px;
            color: #9933FF;
        }
    </style>
    <style media="print">
        @page
        {
            size: auto;
            margin: 0mm;
        }
    </style>
    <style type="text/css">
        .sel
        {
            background-color: #33CCCC;
        }
        
        
        .div1
        {
            width: 100px;
            display: none;
        }
        @media print
        {
            .noprint
            {
                display: none;
            }
        }
        @page
        {
            size: auto; /* auto is the initial value */
            margin: 0mm; /* this affects the margin in the printer settings */
        }
    </style>
    <style type="text/css">
        .td3
        {
            font-size: 16px;
            border-right: #f6f6f6 1px solid;
            text-align: right;
        }
        .style6
        {
            width: 100px;
        }
        .sel
        {
            background-color: #FFFF00;
        }
        .div1
        {
            width: 100px;
            display: none;
        }
        @media print
        {
            .noprint
            {
                display: none;
            }
        }
        @page
        {
            size: auto; /* auto is the initial value */
            margin: 0mm; /* this affects the margin in the printer settings */
        }
    </style>
    <script type="text/javascript">

        function print_page() {

            pagesetup_null();

            var printData = document.getElementById("div01").innerHTML; //获得 div 里的所有 html 数据

            window.document.body.innerHTML = printData;   //把 html 里的数据 复制给 body 的 html 数据 ，相当于重置了 整个页面的 内容
            window.print();

        };

        function remove_ie_header_and_footer() {
            var hkey_root, hkey_path, hkey_key;
            hkey_path = "HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
            try {
                var RegWsh = new ActiveXObject("WScript.Shell");
                RegWsh.RegWrite(hkey_path + "header", "");
                RegWsh.RegWrite(hkey_path + "footer", "");
            } catch (e) { }
        }

        function pagesetup_null() {
            try {
                var RegWsh = new ActiveXObject("WScript.Shell")
                hkey_key = "header"
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
                hkey_key = "footer"
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
            } catch (e) { }
        }



        function getExplorer() {
            var explorer = window.navigator.userAgent;
            //ie 
            if (explorer.indexOf("MSIE") >= 0) {
                return "IE";
            }
            //firefox 
            else if (explorer.indexOf("Firefox") >= 0) {
                return "Firefox";
            }
            //Chrome
            else if (explorer.indexOf("Chrome") >= 0) {
                return "Chrome";
            }
            //Opera
            else if (explorer.indexOf("Opera") >= 0) {
                return "Opera";
            }
            //Safari
            else if (explorer.indexOf("Safari") >= 0) {
                return "Safari";
            }
        }

    </script>
    <style>
        .father
        {
            position: relative;
            width: 500px;
            height: 500px;
        }
        .mydiv
        {
            position: absolute;
            left: -200px;
            width: 350px;
            margin-top: 205px;
            height: 40px;
            padding-left: 150px;
            border-bottom: 1px dashed black;
            border-top: 1px solid black;
            transform: rotate(90deg);
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=1);
            top: 14px;
            font-size: large;
        }
        .mytable
        {
            position: absolute;
            margin-left: 100px;
            width: 300px;
            height: 200px;
        }
        @media print
        {
            .noprint
            {
                display: none;
            }
        }
        .text-right
        {
            height: 11px;
            width: 1062px;
        }
        .table-condensed
        {
        }
    </style>
    <form id="form1" runat="server">
    <asp:TextBox ID="TextBoxbaocunnocol53" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="noprint" style="text-align: center; margin-bottom: 5px; width: 100%;">
        <button id="Button1" type="button" class="print" style="width: 100px;" onclick="LinkPrintPage()">
            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>打印
        </button>
    </div>
    <asp:TextBox ID="txtAmount" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="tab-content" id="div01" style="margin: 0px auto; font-size: 12px;">
        <%--<div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
            height: 80px; font-size: 10px;">
            
        </div>--%>
        <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
            height: 60px; font-size: 10px;">
        </div>
        <table>
            <tr>
                <td width="450px" rowspan="2">
                    <img id="img1" src="../Images/biaoti.png" style="width: 120px; height: 50px; margin-bottom: 10px;
                        margin-left: 110px; margin-top: -100px;" />
                </td>
                <td width="600px">
                 <h4 class="panel-title">
                <strong><font size="3px">
                    <asp:Label ID="Label6" Text="云南德凯通信工程有限公司" runat="server"></asp:Label></font></strong>
            </h4>
                </td>
                
                
            </tr>
            <tr>
               
                <td>
                <h4 class="panel-title">
            
                <strong><font size="3px">
                    <asp:Label ID="Label7" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开票审批单" runat="server"></asp:Label></font></strong>
            </h4>
               
                </td>
                
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" Text="开票申请单号：" Width="195px" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; 
                        margin-left: 0px;" Font-Bold="true" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票申请单号" Text=""  Width="380px" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" Text="" Width="140px"  runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; 
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" Text="打印时间：" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; width:200px; 
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Label3" Text="页码：1/2" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; 
                        margin-left: 0px;"></asp:TextBox>
                </td>
                
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox2" runat="server" class="form-control input-sm" Width="195px"
                        Text="申请人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt申请人" TabIndex="11" Style="margin-left: 0px" Width="380px" runat="server"
                        class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox5" runat="server" class="form-control input-sm" Width="195px"
                        Text="申请日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox申请日期" TabIndex="12" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox3" runat="server" class="form-control input-sm" Width="195px"
                        Text="所属项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox所属项目部" TabIndex="13" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox4" runat="server" class="form-control input-sm" Width="195px"
                        Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox项目经理" TabIndex="14" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox14" runat="server" class="form-control input-sm" Width="195px"
                        Text="申请发票类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox申请发票类型" TabIndex="15" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true">
                                    
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox13" runat="server" class="form-control input-sm" Width="195px"
                        Text="项目属性：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox项目属性" TabIndex="16" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true">
                                    
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox12" runat="server" class="form-control input-sm" Width="195px"
                        Text="申请发票类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox申请发票类别" TabIndex="17" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true">
                                    
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox15" runat="server" class="form-control input-sm" Width="195px"
                        Text="合同类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox合同类型" TabIndex="18" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true">
                                    
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="lblBox8" runat="server" class="form-control input-sm" Width="195px"
                        Text="合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="3">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox合同名称" TabIndex="19" Style="margin-left: 0px" Width="963px"
                            onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox10" runat="server" class="form-control input-sm" Width="195px"
                        Text="合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox合同编号" TabIndex="20" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox9" runat="server" class="form-control input-sm" Width="195px"
                        Text="合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox合同金额" TabIndex="20" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox7" runat="server" class="form-control input-sm" Width="195px"
                        Text="跨区域经营地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="TextBox跨区域经营地址" TabIndex="22" Style="margin-left: 0px" Width="380px"
                            onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox1" runat="server" class="form-control input-sm" Width="195px"
                        Text="跨区域涉税事项报验管理编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="TextBox跨区域涉税事项报验管理编号" TabIndex="22" Style="margin-left: 0px" Width="380px"
                            onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox16" runat="server" class="form-control input-sm" Width="195px"
                        Text="付款单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="TextBox付款单位名称" TabIndex="23" Style="margin-left: 0px" Width="380px"
                            onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox18" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox ID="TextBox开票单位名称" TabIndex="24" Style="margin-left: 0px" Width="380px"
                            onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" class="form-control input-sm" Width="195px"
                        Text="付款单位纳税人识别号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox付款单位纳税人识别号" TabIndex="25" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox20" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票单位纳税人识别号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票单位纳税人识别号" TabIndex="26" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox21" runat="server" class="form-control input-sm" Width="195px"
                        Text="付款单位地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox付款单位地址" TabIndex="27" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox26" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票单位地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票单位地址" TabIndex="28" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="195px"
                        Text="付款单位电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox付款单位电话" TabIndex="29" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox23" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票单位电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票单位电话" TabIndex="30" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox25" runat="server" class="form-control input-sm" Width="195px"
                        Text="付款单位开户行：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox付款单位开户行" TabIndex="29" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox28" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票单位开户行：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票单位开户行" TabIndex="30" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox27" runat="server" class="form-control input-sm" Width="195px"
                        Text="付款单位账号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox付款单位账号" TabIndex="29" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"
                        ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox30" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票单位账号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票单位账号" TabIndex="30" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox29" runat="server" class="form-control input-sm" Width="195px"
                        Text="增值税预缴税款方式：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox增值税预缴税款方式" TabIndex="29" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox32" runat="server" class="form-control input-sm" Width="195px"
                        Text="增值税预缴税款地点：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox增值税预缴税款地点" TabIndex="30" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox31" runat="server" class="form-control input-sm" Width="195px"
                        Text="增值税预缴金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox国税预缴金额" TabIndex="29" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox34" runat="server" class="form-control input-sm" Width="195px"
                        Text="附加税预缴金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox地税预缴金额" TabIndex="30" Style="margin-left: 0px" Width="380px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLabel1" runat="server" class="form-control input-sm" Width="195px"
                        Text="本次开票金额合计(不含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox本次开票金额合计不含税" TabIndex="39" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLabel2" runat="server" class="form-control input-sm" Width="195px"
                        Text="税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox税率" TabIndex="39" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLabel3" runat="server" class="form-control input-sm" Width="195px"
                        Text="税额合计：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox税额合计" TabIndex="39" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLabel4" runat="server" class="form-control input-sm" Width="195px"
                        Text="本次发票价税合计金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox本次发票价税合计金额" TabIndex="39" Style="margin-left: 0px" Width="380px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox35" runat="server" class="form-control input-sm" Width="195px"
                         Text="发票备注栏信息：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBox发票备注栏信息" TabIndex="39" Style="margin-left: 0px" Width="963px"
                        TextMode="MultiLine" Rows="5" runat="server" class="form-control input-sm" autocomplete="off"
                        onfocus="this.blur();" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox22" runat="server" class="form-control input-sm" Width="195px"
                        Text="开票申请表附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票申请表附件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                    <a href="" runat="server" id="开票申请表附件href" target="_blank">开票申请表附件</a>
                </td>
                <td>
                    <asp:TextBox ID="TextBox36" runat="server" class="form-control input-sm" Width="195px"
                        Text="税票扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <a href="" runat="server" id="税票扫描件href" target="_blank">税票扫描件</a>
                    <asp:TextBox ID="TextBox税票扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
        <table id="shdiv" runat="server">
            <tr>
                <td>
                    <asp:TextBox ID="TextBox17" runat="server" class="form-control input-sm" Width="195px"
                        Height="66px" Text="审批状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBox审批状态" TabIndex="39" Style="margin-left: 0px; word-wrap: break-word;
                        word-break: break-all;" Width="963px" TextMode="MultiLine" Rows="6" runat="server"
                        class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        
        <table>
            <tr>
                <td width="450px" rowspan="2">
                    <img id="img2" src="../Images/biaoti.png" style="width: 120px; height: 50px; margin-bottom: 10px;
                        margin-left: 110px; margin-top: -100px;" />
                </td>
                <td width="600px">
                 <h4 class="panel-title">
                <strong><font size="3px">
                    <asp:Label ID="Label2" Text="云南德凯通信工程有限公司" runat="server"></asp:Label></font></strong>
            </h4>
                </td>
               
            </tr>
            <tr>
               
                <td>
                <h4 class="panel-title">
            
                <strong><font size="3px">
                    <asp:Label ID="Label5" Text="&nbsp;&nbsp;&nbsp;&nbsp;开票审批项目明细单" runat="server"></asp:Label></font></strong>
            </h4>
                
                </td>
                
            </tr>
        </table>
        <%--<div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
            height: 60px; font-size: 10px;">
            <h4 class="panel-title">
                <strong><font size="3px">
                    <asp:Label ID="Label4" Text="云南德凯通信工程有限公司" Height="5px" runat="server"></asp:Label></font></strong>
            </h4>
            <h4 class="panel-title">
                <strong><font size="3px">
                    <asp:Label ID="Label1" Text="开票审批项目明细单" runat="server"></asp:Label></font></strong>
            </h4>
        </div>--%>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox3" Text="开票申请单号：" Width="195px" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; 
                        margin-left: 0px;" Font-Bold="true" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox开票申请单号2" Text=""  Width="360px" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="margin-left: 0px; border: 0; "></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" Text="" Width="140px"  runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; 
                        margin-left: 0px;"></asp:TextBox>
                </td>
                 <td>
                    <asp:TextBox ID="TextBox12" Text="打印时间：" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; width:200px; 
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" Text="页码：2/2" runat="server" class="form-control input-sm" onfocus="this.blur();"
                    Style="text-align: right; border: 0; 
                        margin-left: 0px;"></asp:TextBox>
                </td>
                
            </tr>
        </table>
        <div class="table-responsive" style="width: 1165px">
            <asp:GridView ID="GridView1" runat="server" Font-Size="9px" HeaderStyle-Height="7px"
                Height="5px" RowStyle-Height="5px" AutoGenerateColumns="False" BorderWidth="1px"
                CssClass="table table-bordered " AllowSorting="True" OnRowDataBound="GridView1_RowDataBound"
                ShowFooter="true">
                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="7px" />
                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="7px" />
                <Columns>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblcol47" runat="server" Text='<%# Bind("col17") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblcol48" runat="server" Text='<%# Bind("col18") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol30" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'
                                Width="30px" Style="text-align: center;"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                         
                            <asp:Label ID="lblcol31" runat="server" Text='<%# Bind("col8") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目编码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol32" runat="server" Text='<%# Bind("col9") %>' Style="text-align: left;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="单项工程名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol33" runat="server" Text='<%# Bind("col10") %>' Style="text-align: left;
                                border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结算金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol34" runat="server" Text='<%# Bind("col11") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol35" runat="server" Text='<%# Bind("col12") %>' Style="text-align: center;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol341" runat="server" Text='<%# Bind("col13") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结算金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol351" runat="server" Text='<%# Bind("col14") %>' Style="text-align: center;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审定金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol342" runat="server" Text='<%# Bind("col15") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol352" runat="server" Text='<%# Bind("col16") %>' Style="text-align: center;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol343" runat="server" Text='<%# Bind("col45") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审定金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol353" runat="server" Text='<%# Bind("col46") %>' Style="text-align: center;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="已经开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol36" runat="server" Text='<%# Bind("col21") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="本次开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol37" runat="server" Text='<%# Bind("col22") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="货物或应税劳务、服务名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol38" runat="server" Text='<%# Bind("col23") %>' Style="text-align: left;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="规格型号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol39" runat="server" Text='<%# Bind("col24") %>' Style="text-align: left;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol40" runat="server" Text='<%# Bind("col25") %>' Style="text-align: left;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="数量" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol41" runat="server" Text='<%# Bind("col26") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="单价" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol42" runat="server" Text='<%# Bind("col27") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="col28" HeaderText="金额" ItemStyle-HorizontalAlign="center" />--%>
                    <asp:TemplateField HeaderText="金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol43" runat="server" Text='<%# Bind("col28") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol44" runat="server" Text='<%# Bind("col29") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol45" runat="server" Text='<%# Bind("col30") %>' Style="text-align: center;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="合计" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblcol46" runat="server" Text='<%# Bind("col31") %>' Style="text-align: center;"
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
