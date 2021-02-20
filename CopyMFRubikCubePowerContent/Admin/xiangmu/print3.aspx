<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print3.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.print3" %>

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
            width: 120px;
            height: 600px;
            overflow: hidden;
            margin-top: 0px;
        }
        .main_conL222 dl dd
        {
            width: 120px;
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
            width: 120px;
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
            width: 120px;
        }
        .sel
        {
            background-color: #FFFF00;
        }
        .div1
        {
            width: 120px;
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
            top: 9px;
            font-size: large;
        }
        .mytable
        {
            position: absolute;
            margin-left: 120px;
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
        <button id="Button1" type="button" class="print" style="width: 120px;" onclick="LinkPrintPage()">
            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>打印
        </button>
    </div>
    <div class="tab-content" id="div01" style="margin: 0px auto; font-size: 9px;margin-right:10px;">
        <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;margin-right:10px;
            height: 60px; font-size: 9px;">
        </div>
         <table>
            <tr>
                <td width="340px">
                    <img id="imgc" src="../Images/biaoti.png" style="width: 120px; height: 50px; margin-bottom: 10px;
                        margin-left: 10px;" />
                </td>
                <td width="420px" style=" text-align:right;">
                    <h4 class="panel-title" style=" text-align:right; margin-bottom:-20px;">
                        <strong><font size="3px">
                            <asp:Label ID="Label124" Text="云南德凯通信工程有限公司" runat="server"></asp:Label></font></strong>
                    </h4>
                </td>
            </tr>
            
            
        </table>
        
        <hr style="border:2px dotted #ff0033; width:740px; text-align:left; margin-left:20px;margin-top:-10px;" size =2 />
        <table>
            <tr align="center" style=" text-align:center; width:760px;">
                <td style=" text-align:center;width:760px; ">
                    <h4 class="panel-title">
                        <strong><font size="3px">
                            <asp:Label ID="Label5" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;项目付款审批单"
                                runat="server"></asp:Label></font></strong>
                    </h4>
                </td>
            </tr>
        </table>

        
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1232" Text=" " Width="540px" runat="server" onfocus="this.blur();"
                        Style="text-align: left; float: right; border: 0; margin-left: 0px; border: 0;"
                        Font-Bold="true" ReadOnly="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label付款单号" Text="付款单号" Width="200px" runat="server" onfocus="this.blur();"
                        Style="text-align: left; float: right; border: 0; margin-left: 0px;font-size:9px;"
                        Font-Bold="true" ReadOnly="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table border="1" cellspacing="0"  style="border-collapse:collapse; width:760px; font-size:9px;">
            <tr>
                <td>
                    <asp:Label ID="Label121" runat="server" Width="120px" Text="申请人" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label申请人" TabIndex="29" Style="margin-left: 0px; border: 0;" Width="260px"
                        runat="server" autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label23" runat="server" Width="120px" Text="申请日期" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label申请日期" TabIndex="30" Style="margin-left: 0px; border: 0;" Width="260px"
                        runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBox2" runat="server" Width="120px" Text="所属项目部" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label所属项目部" TabIndex="11" Style="margin-left: 0px; border: 0;" Width="260px"
                        onfocus="this.blur();" runat="server" autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBox5" runat="server" Width="120px" Text="项目经理" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label项目经理" TabIndex="11" Style="margin-left: 0px; border: 0;" Width="260px"
                        onfocus="this.blur();" runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBox3" runat="server" Width="120px" Text="总包合同名称" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td colspan="3">
                    <div class="input-group">
                        <asp:Label ID="Label总包合同名称" TabIndex="13" Style="margin-left: 0px; border: 0;" Width="620px"
                            runat="server" autocomplete="off" onfocus="this.blur();"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBox14" runat="server" Width="120px" Text="总包合同编号" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label总包合同编号" TabIndex="15" Style="margin-left: 0px; border: 0;" Width="620px"
                        runat="server" autocomplete="off" onfocus="this.blur();"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBox24" runat="server" Width="120px" Text="劳务合同名称" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label劳务合同名称" TabIndex="13" Style="margin-left: 0px; border: 0;" Width="620px"
                        runat="server" autocomplete="off" onfocus="this.blur();"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBox39" runat="server" Width="120px" Text="劳务单位名称" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label劳务单位名称" TabIndex="14" Style="margin-left: 0px; border: 0;" Width="260px"
                        runat="server" autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Width="120px" Text="劳务合同编号" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label劳务合同编号" TabIndex="13" Style="margin-left: 0px; border: 0;" Width="260px"
                        runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBox7" runat="server" Width="120px" Height="52px" Text="劳务合同结算依据"
                        Font-Bold="true" ReadOnly="true" Style="text-align: left;line-height:52px; margin-left: 0px;
                        border: 0;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label劳务合同结算依据" TabIndex="13" Style="margin-left: 0px; border: 0;"
                        Width="620px" ReadOnly="true" Height="52px" Rows="2" TextMode="MultiLine" runat="server"
                        autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Width="120px" Text="收款人名称" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label收款人名称" TabIndex="23" Style="margin-left: 0px; border: 0;" Width="260px"
                        onfocus="this.blur();" runat="server" autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Width="120px" Text="收款人银行账号" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label收款人银行账号" TabIndex="11" Style="margin-left: 0px; border: 0;" Width="260px"
                        runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Width="120px" Text="收款人开户行" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label收款人开户行" TabIndex="13" Style="margin-left: 0px; border: 0;" Width="620px"
                        runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Width="120px" Text="已经支付金额" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label已经支付金额小写" TabIndex="11" Style="margin-left: 0px; border: 0;"
                        Width="260px" onblur='NumberCheck5(this);weightCheck1(this);' runat="server"
                        autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Width="120px" Text="大写金额" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label已经支付金额大写" TabIndex="11" Style="margin-left: 0px; border: 0;"
                        Width="260px" runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Width="120px" Text="本次申请支付发票金额" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label本次申请支付发票金额小写" TabIndex="11" Style="margin-left: 0px; border: 0;"
                        Width="260px" onblur='NumberCheck5(this);weightCheck2(this);' runat="server"
                        autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Width="120px" Text="大写金额" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label本次申请支付发票金额大写" TabIndex="11" Style="margin-left: 0px; border: 0;"
                        Width="260px" runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server" Width="120px" Text="本次申请支付实际金额" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label本次申请支付实际金额小写" TabIndex="11" Style="margin-left: 0px; border: 0;"
                        Width="260px" onblur='NumberCheck5(this);weightCheck3(this);' runat="server"
                        autocomplete="off"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label17" runat="server" Width="120px" Text="大写金额" Font-Bold="true" Height="22px" 
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0; line-height:22px;"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="Label本次申请支付实际金额大写" TabIndex="11" Style="margin-left: 0px; border: 0;"
                        Width="260px" runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" Width="120px" Text="本次申请支付发票号码" Font-Bold="true" Height="22px"
                        ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px; border: 0;line-height:22px;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label本次申请支付发票号码" TabIndex="13" Style="margin-left: 0px; border: 0;" Height="52px"
                        Width="620px" runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" runat="server" Width="120px" Height="52px" Text="付款依据" Font-Bold="true"
                        ReadOnly="true" Style="text-align: left; line-height:52px;margin-left: 0px; border: 0;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label付款依据" TabIndex="13" Style="margin-left: 0px; border: 0;" Width="620px"
                        ReadOnly="true" Height="52px" Rows="3" TextMode="MultiLine" runat="server" autocomplete="off"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="divGridView1" class="table-responsive" style="width: 760px;
            margin-top: 0px; margin-right:10px;">
            <asp:GridView ID="GridView1" runat="server" Font-Size="9px" AutoGenerateColumns="False"
                BorderWidth="1px" CssClass="table table-bordered table-hover table-condensed"
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                ShowFooter="true">
                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="9px" />
                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="9px" />
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <asp:Label ID="lbl支付序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'
                                Width="30px" Style="text-align: center;"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结算单号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl结算单号" runat="server" Style="text-align: center; border: 0;word-wrap:break-word;" Text='<%# Bind("col12") %>'
                                Width="70PX" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl项目名称" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col1") %>'
                                Width="113PX" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目编码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl项目编码" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col2") %>'
                                Width="58PX" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="总包发票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl总包发票金额" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col3") %>'
                                Width="55PX" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="总包到账金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl总包到账金额" runat="server" Text='<%# Bind("col4") %>' Width="55PX"
                                Style="text-align: center; border: 0;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="分包发票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl分包发票金额" runat="server" Text='<%# Bind("col5") %>' Width="55PX"
                                Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="分包到账金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl分包到账金额" runat="server" Text='<%# Bind("col6") %>' Width="55PX"
                                Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="劳务单位开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lbl劳务单位开票金额" runat="server" Text='<%# Bind("col7") %>' Width="55PX"
                                    Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="已经支付金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl已经支付金额" runat="server" Text='<%# Bind("col8") %>' Width="55PX"
                                Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="本次申请支付金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lbl本次申请支付金额" runat="server" Text='<%# Bind("col9") %>' Width="55PX"
                                Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcol37" runat="server" Text='<%# Bind("col10") %>' Width="80PX"
                                Style="text-align: left; border: 0;" autocomplete="off"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
       
        <table border="1" cellspacing="0"  style="border-collapse:collapse; width:76px;font-size:9px;margin-right:10px;">
            <tr>
                <td>
                    <asp:Label ID="Label3112" runat="server" Width="120px" Height="52px" Text="审批流程"
                        Font-Bold="true" ReadOnly="true" Style="text-align: left; border: 0; margin-left: 0px;
                        border: 0;"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBox审批流程" TabIndex="39" Style="margin-left: 0px; border:0; word-wrap: break-word; font-size:9px;
                        word-break: break-all;" Width="646px" TextMode="MultiLine" Rows="12" runat="server"
                        class="form-control input-sm" autocomplete="off" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table>
            <tr>
            <td>
                <asp:Label ID="Label155" Text="" Width="300px" runat="server" onfocus="this.blur();" Font-Size="9px"
                    Style="text-align: left; border: 0; margin-left: 0px; border: 0;"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label156" Text="" runat="server" onfocus="this.blur();" Style="text-align: left; float: right; font-size:9px;
                    border: 0; width: 240px; margin-left: 0px; border: 0;"></asp:Label>
            </td>

            <td>
                <asp:Label ID="Label157" Text="" runat="server" onfocus="this.blur();" Style="text-align: left;font-size:9px;
                    border: 0; width: 200px;margin-left: 0px; border: 0;"></asp:Label>
            </td>
            </tr>
            
        </table>
    </div>
    </form>
</body>
</html>
