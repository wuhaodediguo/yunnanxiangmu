<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print2.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.print2" %>

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
    <div class="noprint" style="text-align: center; margin-bottom: 5px; width: 100%;">
        <button id="Button1" type="button" class="print" style="width: 100px;" onclick="LinkPrintPage()">
            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>打印
        </button>
    </div>
    <asp:TextBox ID="txtAmount" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxbaocunnocol45" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBox审核人" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBox49" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="tab-content" id="div01" style="margin: 0px auto; font-size: 12px;">
        <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
            height: 60px; font-size: 10px;">
        </div>
        <table>
            <tr>
                <td width="450px" rowspan="2">
                    <img id="imgc" src="../Images/biaoti.png" style="width: 120px; height: 50px; margin-bottom: 10px;
                        margin-left: 110px; margin-top: -100px;" />
                </td>
                <td width="500px">
                    <h4 class="panel-title">
                        <strong><font size="3px">
                            <asp:Label ID="Label4" Text="云南德凯通信工程有限公司" runat="server"></asp:Label></font></strong>
                    </h4>
                </td>
                
            </tr>
            <tr>
                <td>
                    <h4 class="panel-title">
                        <strong><font size="3px">
                            <asp:Label ID="Label5" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结算审批单"
                                runat="server"></asp:Label></font></strong>
                    </h4>
                    
                    </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" Text="结算单号：" Width="180px" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; margin-left: 0px;"
                        Font-Bold="true" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox结算单号" Text="" Width="360px" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" Text="" Width="140px" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" Text="打印时间：" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; width: 200px; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Label3" Text="页码：1/2" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox2" runat="server" class="form-control input-sm" Width="180px"
                        Text="项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox所属项目部" TabIndex="11" Style="margin-left: 0px" Width="360px"
                        onfocus="this.blur();" runat="server" autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox5" runat="server" class="form-control input-sm" Width="180px"
                        Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox项目经理" TabIndex="11" Style="margin-left: 0px" Width="348px"
                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox3" runat="server" class="form-control input-sm" Width="180px"
                        Text="总包合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox总包合同名称" TabIndex="13" Style="margin-left: 0px" Width="900px"
                            runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox14" runat="server" class="form-control input-sm" Width="180px"
                        Text="总包合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox总包合同编号" TabIndex="15" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox13" runat="server" class="form-control input-sm" Width="180px"
                        Text="总包合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox总包合同金额" TabIndex="16" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox12" runat="server" class="form-control input-sm" Width="180px"
                        Text="建设单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox建设单位名称" TabIndex="17" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox15" runat="server" class="form-control input-sm" Width="180px"
                        Text="施工单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox施工单位名称" TabIndex="17" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox35" runat="server" class="form-control input-sm" Width="180px"
                        Text="分包合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox分包合同名称" TabIndex="13" Style="margin-left: 0px" Width="900px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLabel1" runat="server" class="form-control input-sm" Width="180px"
                        Height="60px" Text="分包合同结算依据：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox分包合同结算依据" TabIndex="13" Style="margin-left: 0px" Width="900px"
                        Rows="4" TextMode="MultiLine" runat="server" class="form-control input-sm" autocomplete="off"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            
            <%--<tr>
                <td>
                    <asp:TextBox ID="TextBox28" runat="server" class="form-control input-sm" Width="180px"
                        Text="项目实施单位发票附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox项目实施单位发票附件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                    <a href="" runat="server" id="项目实施单位发票附件href" target="_blank">项目实施单位发票附件</a>
                </td>
                <td>
                    <asp:TextBox ID="TextBox36" runat="server" class="form-control input-sm" Width="180px"
                        Text="税票扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <a href="" runat="server" id="付款凭证href" target="_blank">付款凭证</a>
                    <asp:TextBox ID="TextBox付款凭证" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox34" runat="server" class="form-control input-sm" Width="180px"
                        Text="分包单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox分包单位" TabIndex="11" Style="margin-left: 0px" Width="240px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox36" runat="server" Width="120px" Text="分包合同金额：" Font-Bold="true"
                        ReadOnly="true" Style="text-align: right; border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox分包合同金额" TabIndex="11" Style="margin-left: 0px" Width="180px"
                        runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox37" runat="server" Width="180px" Text="分包合同签订日期：" Font-Bold="true"
                        ReadOnly="true" Style="text-align: right; border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox分包合同签订日期" TabIndex="13" Style="margin-left: 0px" Width="162px"
                        runat="server" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLabel2" runat="server" class="form-control input-sm" Width="180px"
                        Text="分包合同结算比例：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox分包合同结算比例" TabIndex="11" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLabel3" runat="server" class="form-control input-sm" Width="180px"
                        Text="分包合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox分包合同编号" TabIndex="13" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox24" runat="server" class="form-control input-sm" Width="180px"
                        Text="劳务合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox劳务合同名称" TabIndex="13" Style="margin-left: 0px" Width="900px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox7" runat="server" class="form-control input-sm" Width="180px"
                        Height="60px" Text="劳务合同结算依据：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox劳务合同结算依据" TabIndex="13" Style="margin-left: 0px" Width="900px"
                        Rows="4" TextMode="MultiLine" runat="server" class="form-control input-sm" autocomplete="off"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox39" runat="server" class="form-control input-sm" Width="180px"
                        Text="劳务单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox劳务单位" TabIndex="14" Style="margin-left: 0px" Width="240px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox30" runat="server" class="form-control input-sm" Width="120px"
                        Text="劳务合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox劳务合同金额" TabIndex="14" Style="margin-left: 0px" Width="180px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox4" runat="server" class="form-control input-sm" Width="180px"
                        Text="劳务合同签订日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox劳务合同签订日期" TabIndex="13" Style="margin-left: 0px" Width="162px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLabel4" runat="server" class="form-control input-sm" Width="180px"
                        Text="劳务合同结算比例：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox劳务合同结算比例" TabIndex="11" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLabel5" runat="server" class="form-control input-sm" Width="180px"
                        Text="劳务合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox劳务合同编号" TabIndex="13" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="180px"
                        Text="申请人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox申请人" TabIndex="29" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox23" runat="server" class="form-control input-sm" Width="180px"
                        Text="申请日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox申请日期" TabIndex="30" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="shdiv" runat="server">
            <tr>
                <td>
                    <asp:TextBox ID="TextBox25" runat="server" class="form-control input-sm" Width="180px"
                        Height="66px" Text="审批状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBox审批状态" TabIndex="39" Style="margin-left: 0px; word-wrap: break-word;
                        word-break: break-all;" Width="900px" TextMode="MultiLine" Rows="6" runat="server"
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
        <br />
        <br />
        <br />
         <br />
        <table>
            <tr>
                <td width="450px" rowspan="2">
                    <img id="img1" src="../Images/biaoti.png" style="width: 120px; height: 50px; margin-bottom: 10px;
                        margin-left: 110px; margin-top: -100px;" />
                </td>
                <td width="600px">
                    <h4 class="panel-title">
                        <strong><font size="3px">
                            <asp:Label ID="Label1" Text="云南德凯通信工程有限公司" runat="server"></asp:Label></font></strong>
                    </h4>
                </td>
                
            </tr>
            <tr>
                <td>
                    <h4 class="panel-title">
                        <strong><font size="3px">
                            <asp:Label ID="Label2" Text="&nbsp;&nbsp;&nbsp;&nbsp;结算审批支付明细单" runat="server"></asp:Label></font></strong>
                    </h4>
                   
                    </td>
            </tr>
        </table>
        <%--<div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
            height: 60px; font-size: 10px;">
            <h4 class="panel-title">
                <strong><font size="3px">
                    <asp:Label ID="Label1" Text="云南德凯通信工程有限公司" Height="5px" runat="server"></asp:Label></font></strong>
            </h4>
            <h4 class="panel-title">
                <strong><font size="3px">
                    <asp:Label ID="Label6" Text="结算审批支付明细单" runat="server"></asp:Label></font></strong>
            </h4>
            
        </div>--%>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox3" Text="结算单号：" Width="180px" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; margin-left: 0px;"
                        Font-Bold="true" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox结算单号2" Text="" Width="360px" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="margin-left: 0px; border: 0;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" Text="" Width="140px" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" Text="打印时间：" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; width: 200px; margin-left: 0px;"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" Text="页码：2/2" runat="server" class="form-control input-sm"
                        onfocus="this.blur();" Style="text-align: right; border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxLabel5Box22" runat="server" class="form-control input-sm"
                        Width="180px" Text="总包项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox总包项目名称" TabIndex="19" Style="margin-left: 0px" Width="900px"
                            runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox16" runat="server" class="form-control input-sm" Width="180px"
                        Text="总包项目编码：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox总包项目编码" TabIndex="23" Style="margin-left: 0px" Width="360px"
                            runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox18" runat="server" class="form-control input-sm" Width="180px"
                        Text="总包发票金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox总包发票金额" TabIndex="24" Style="margin-left: 0px" Width="348px"
                            runat="server" class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox6" runat="server" class="form-control input-sm" Width="180px"
                        Text="总包到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox总包到账金额" TabIndex="25" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox20" runat="server" class="form-control input-sm" Width="180px"
                        Text="分包发票金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox分包发票金额" TabIndex="26" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxlblBox21" runat="server" class="form-control input-sm" Width="180px"
                        Text="分包到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox分包到账金额" TabIndex="27" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxlblBox26" runat="server" class="form-control input-sm" Width="180px"
                        Text="劳务单位开票金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox劳务单位开票金额" TabIndex="28" Style="margin-left: 0px" Width="348px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox35" runat="server" class="form-control input-sm" Width="180px"
                        Height="60px" Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox备注" TabIndex="39" Style="margin-left: 0px" Width="900px"
                        TextMode="MultiLine" Rows="3" runat="server" class="form-control input-sm" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="table-responsive" style="text-align: center; margin-left: 86px">
            <asp:GridView ID="GridView1" runat="server" Font-Size="12px" Width="1000px" AutoGenerateColumns="False"
                BorderWidth="1px" CssClass="table table-bordered table-hover table-condensed"
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true">
                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
                <Columns>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col9") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="支付序号" ItemStyle-Height="5px">
                        <ItemTemplate>
                            <asp:Label ID="lbl支付序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'
                                Style="text-align: center;"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="支付对象" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                        ItemStyle-Height="5px">
                        <ItemTemplate>
                            <asp:Label ID="lblcol31" runat="server" Style="text-align: left; border: 0;" Text='<%# Bind("col1") %>'
                                autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="支付金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lblcol32" runat="server" Text='<%# Bind("col2") %>' Width="70px" Style="text-align: right;
                                border: 0;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="付款依据" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol33" runat="server" Text='<%# Bind("col3") %>' Style="text-align: left;
                                border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="收款人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol34" runat="server" Text='<%# Bind("col4") %>' Style="text-align: left;
                                border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="开户行" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblcol35" runat="server" Text='<%# Bind("col5") %>' Style="text-align: left;
                                    border: 0;" autocomplete="off"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="银行账号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol36" runat="server" Text='<%# Bind("col6") %>' Style="text-align: left;
                                border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol37" runat="server" Text='<%# Bind("col7") %>' Style="text-align: left;
                                border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="180px"
                        Text="申请人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox申请人2" TabIndex="29" Style="margin-left: 0px" Width="360px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="180px"
                        Text="申请日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; border: 0;
                        margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox申请日期2" TabIndex="30" Style="margin-left: 0px" Width="350px"
                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="Table1" runat="server">
            <tr>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="180px"
                        Height="66px" Text="审批状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                        border: 0; margin-left: 0px;"></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBox审批状态2" TabIndex="39" Style="margin-left: 0px; word-wrap: break-word;
                        word-break: break-all;" Width="900px" TextMode="MultiLine" Rows="6" runat="server"
                        class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
