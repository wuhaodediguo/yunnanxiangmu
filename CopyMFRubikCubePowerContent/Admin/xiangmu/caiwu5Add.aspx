<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="caiwu5Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu5Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 700px;
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
    <script type="text/javascript">

        function formatAsNum(mnt) {
            mnt -= 0;
            mnt = (Math.round(mnt * 100)) / 100;
            return mnt;
        }

        function NumberCheck(iField) {
            iField.value = iField.value.replace(',', '').replace(',', '').replace(',', '').replace(',', '').replace(',', '').replace(',', '').replace(',', '');

            document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = "";
            if (isNaN(iField.value)) {
                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 请输入数字</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

                return false;
            }

//            if (1 && iField.value < 0) {

//                iField.value = "";
//                iField.focus();
//                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 请输入大于0的数字</div>";
//                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

//                return false;
//            }

            if ((iField.value.length > 0) && (iField.value.indexOf(' ', 0) >= 0)) {

                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 请输入大于0的数字</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

                return false;
            }
            if (iField.value == "" || iField.value == "0") {
                return true;
            }
            iField.value = formatNumberHeader(iField.value);
            return true;

        }


        function NumberCheck5(iField) {
            document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = "";

            iField.value = iField.value.replace(',', '').replace(',', '').replace(',', '').replace(',', '').replace(',', '').replace(',', '').replace(',', '');

            if (isNaN(iField.value)) {
                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 您输入的非数字,请重新输入...</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

                return false;
            }

            if (1 && iField.value < 0) {

                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 不合法数字...</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;
                return false;
            }

            if ((iField.value.length > 0) && (iField.value.indexOf(' ', 0) >= 0)) {

                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 不合法数字...</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;
                return false;
            }
            if (iField.value == "" || iField.value == "0") {
                return true;
            }
            iField.value = formatNumberHeader(iField.value);
            return true;
        }

        function formatNumberHeader(num) {
            num = num.toString().replace(/\$|\,/g, '');
            var cent = 2;
            // 检查传入数值为数值类型
            if (isNaN(num))
                num = "0";

            // 获取符号(正/负数)
            sign = (num == (num = Math.abs(num)));

            num = Math.floor(num * Math.pow(10, cent) + 0.50000000001); // 把指定的小数位先转换成整数.多余的小数位四舍五入
            cents = num % Math.pow(10, cent);       // 求出小数位数值
            num = Math.floor(num / Math.pow(10, cent)).toString();  // 求出整数位数值
            cents = cents.toString();        // 把小数位转换成字符串,以便求小数位长度

            // 补足小数位到指定的位数
            while (cents.length < cent)
                cents = "0" + cents;

            // 对整数部分进行千分位格式化.
            //            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
            //                num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));

            if (cent > 0)
                return (((sign) ? '' : '-') + num + '.' + cents);
            else
                return (((sign) ? '' : '-') + num);
        }

        function formatNumberHeader2(num) {
            num = num.toString().replace(/\$|\,/g, '');
            var cent = 2;
            // 检查传入数值为数值类型
            if (isNaN(num))
                num = "2";

            // 获取符号(正/负数)
            sign = (num == (num = Math.abs(num)));

            num = Math.floor(num * Math.pow(10, cent) + 0.50000000001); // 把指定的小数位先转换成整数.多余的小数位四舍五入
            cents = num % Math.pow(10, cent);       // 求出小数位数值
            num = Math.floor(num / Math.pow(10, cent)).toString();  // 求出整数位数值
            cents = cents.toString();        // 把小数位转换成字符串,以便求小数位长度

            // 补足小数位到指定的位数
            while (cents.length < cent)
                cents = "0" + cents;

            // 对整数部分进行千分位格式化.
//            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
//                num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));

            if (cent > 0)
                return (((sign) ? '' : '-') + num + '.' + cents);
            else
                return (((sign) ? '' : '-') + num);
        }

        function tongji() {

            var TextBox第一次到账金额 = document.getElementById('<%= TextBox第一次到账金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox第二次到账金额 = document.getElementById('<%= TextBox第二次到账金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox第三次到账金额 = document.getElementById('<%= TextBox第三次到账金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox第四次到账金额 = document.getElementById('<%= TextBox第四次到账金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox第五次到账金额 = document.getElementById('<%= TextBox第五次到账金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox发票价税合计金额 = document.getElementById('<%= TextBox发票价税合计金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");

            var amount1 = 0;
            var amount2 = 0;
            var amount3 = 0;
            var amount4 = 0;
            var amount5 = 0;
            var TextBox总计到账金额 = document.getElementById('<%= TextBox总计到账金额.ClientID %>');

            if (TextBox第一次到账金额) {
                amount1 = formatAsNum(TextBox第一次到账金额);
            }
            if (TextBox第二次到账金额) {
                amount2 = formatAsNum(TextBox第二次到账金额);
            }
            if (TextBox第三次到账金额) {
                amount3 = formatAsNum(TextBox第三次到账金额);
            }
            if (TextBox第四次到账金额) {
                amount4 = formatAsNum(TextBox第四次到账金额);
            }
            if (TextBox第五次到账金额) {
                amount5 = formatAsNum(TextBox第五次到账金额);
            }

            TextBox总计到账金额.value = formatNumberHeader(amount1 + amount2 + amount3 + amount4 + amount5);

            var amount6 = 0;
            var amount7 = 0;
            if (TextBox发票价税合计金额) {
                amount6 = TextBox发票价税合计金额;
            }

            var TextBox到账情况 = document.getElementById('<%= TextBox到账情况.ClientID %>');

            if (amount6 != 0) {
                amount7 = (amount1 + amount2 + amount3 + amount4 + amount5) / amount6;
                if (amount7 != 0) {
                    if (amount7 == 1) {
                        TextBox到账情况.value = "全部到账";
                    }
                    else {
                        TextBox到账情况.value = "部分到账,到账" + formatNumberHeader2(amount7 * 100) + "%";
                    }

                }
                else if (amount7 == 0) {
                    TextBox到账情况.value = "未到账";
                }
            }
            
            return true;
        }

    </script>
    <script type="text/javascript">

        function PopUpEmployeeQuery1(controlClientID1, controlClientID2, controlClientID3) {
            var getid1 = document.getElementById('<%= txt发票单号.ClientID %>').value;
            var getid2 = controlClientID1;
            var getid3 = document.getElementById('<%= TextBox第一次到账金额.ClientID %>').id;
            var getid4 = document.getElementById('<%= TextBox第一次到账日期.ClientID %>').id;
  
            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            window.open('../xiangmu/caiwu51Add.aspx?_FormNo=' + getid1 + "&&_cishu=" + getid2 + "&&_txtjine=" + getid3+ "&&_txtdate=" + getid4,
                                'Window_PcodeQuery', 'left=' + PosX + ',top=' + PosY + ',height=450,width=1000,scrollbars=yes');

        }
        function PopUpEmployeeQuery2(controlClientID1, controlClientID2, controlClientID3) {
            var getid1 = document.getElementById('<%= txt发票单号.ClientID %>').value;
            var getid2 = controlClientID1;
            var getid3 = document.getElementById('<%= TextBox第二次到账金额.ClientID %>').id;
            var getid4 = document.getElementById('<%= TextBox第二次到账日期.ClientID %>').id;

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            window.open('../xiangmu/caiwu51Add.aspx?_FormNo=' + getid1 + "&&_cishu=" + getid2 + "&&_txtjine=" + getid3 + "&&_txtdate=" + getid4,
                                'Window_PcodeQuery', 'left=' + PosX + ',top=' + PosY + ',height=450,width=1000,scrollbars=yes');

        }
        function PopUpEmployeeQuery3(controlClientID1, controlClientID2, controlClientID3) {
            var getid1 = document.getElementById('<%= txt发票单号.ClientID %>').value;
            var getid2 = controlClientID1;
            var getid3 = document.getElementById('<%= TextBox第三次到账金额.ClientID %>').id;
            var getid4 = document.getElementById('<%= TextBox第三次到账日期.ClientID %>').id;

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            window.open('../xiangmu/caiwu51Add.aspx?_FormNo=' + getid1 + "&&_cishu=" + getid2 + "&&_txtjine=" + getid3 + "&&_txtdate=" + getid4,
                                'Window_PcodeQuery', 'left=' + PosX + ',top=' + PosY + ',height=450,width=1000,scrollbars=yes');

        }
        function PopUpEmployeeQuery4(controlClientID1, controlClientID2, controlClientID3) {
            var getid1 = document.getElementById('<%= txt发票单号.ClientID %>').value;
            var getid2 = controlClientID1;
            var getid3 = document.getElementById('<%= TextBox第四次到账金额.ClientID %>').id;
            var getid4 = document.getElementById('<%= TextBox第四次到账日期.ClientID %>').id;

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            window.open('../xiangmu/caiwu51Add.aspx?_FormNo=' + getid1 + "&&_cishu=" + getid2 + "&&_txtjine=" + getid3 + "&&_txtdate=" + getid4,
                                'Window_PcodeQuery', 'left=' + PosX + ',top=' + PosY + ',height=450,width=1000,scrollbars=yes');

        }
        function PopUpEmployeeQuery5(controlClientID1, controlClientID2, controlClientID3) {
            var getid1 = document.getElementById('<%= txt发票单号.ClientID %>').value;
            var getid2 = controlClientID1;
            var getid3 = document.getElementById('<%= TextBox第五次到账金额.ClientID %>').id;
            var getid4 = document.getElementById('<%= TextBox第五次到账日期.ClientID %>').id;

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            window.open('../xiangmu/caiwu51Add.aspx?_FormNo=' + getid1 + "&&_cishu=" + getid2 + "&&_txtjine=" + getid3 + "&&_txtdate=" + getid4,
                                'Window_PcodeQuery', 'left=' + PosX + ',top=' + PosY + ',height=450,width=1000,scrollbars=yes');

        }
    </script>
    <script type="text/javascript">
        function RotateAnimation(obj) {
            var $this = $(obj);
            $this.button('loading');
            setTimeout(function () {
                $this.button('reset');
            }, 2500);
        }

        // 顯示讀取遮罩
        function ShowProgressBar() {
            // Need to setTimeout to delay for IE Browser
            setTimeout(function () {
                displayProgress();
                displayMaskFrame();
            }, 300);
        }
        // 隱藏讀取遮罩
        function HideProgressBar() {
            var progress = $('#divProgress');
            var maskFrame = $("#divMaskFrame");
            progress.hide();
            maskFrame.hide();
        }
        // 顯示讀取畫面
        function displayProgress() {
            var w = $(document).width();
            var h = $(window).height(); // 若取 document 的位置會跑掉
            var progress = $('#divProgress');
            progress.css({ "z-index": 999, "top": (h / 2) - (progress.height() / 2), "left": (w / 2) - (progress.width() / 2) });
            progress.show();
        }
        // 顯示遮罩畫面
        function displayMaskFrame() {
            var w = $(window).width();
            var h = $(document).height();
            var maskFrame = $("#divMaskFrame");
            maskFrame.css({ "z-index": 998, "opacity": 0.8, "width": w, "height": h });
            maskFrame.show();
        }
    </script>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                财务管理&gt;收款管理
            </div>
        </div>
        <div class="main_con" style="font-size: 10px;">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0061">
                        <a runat="server" id="div0061" href="caiwu1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="外经证管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0062">
                        <a runat="server" id="div0062" href="caiwu2.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="开票申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0063">
                        <a runat="server" id="div0063" href="caiwu3.aspx"><font color="blue">
                            <asp:Label ID="Label2" runat="server" Text="开票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0067">
                        <a runat="server" id="div0067" href="caiwu31.aspx"><font color="blue">
                            <asp:Label ID="Label6" runat="server" Text="税款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0064">
                        <a runat="server" id="div0064" href="caiwu4.aspx"><font color="blue">
                            <asp:Label ID="Label3" runat="server" Text="发票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0065">
                        <a runat="server" id="div0065" href="caiwu5.aspx"><font color="blue">
                            <asp:Label ID="Label4" runat="server" Text="收款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0091">
                        <a runat="server" id="div0091" href="caiwu6.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label5" runat="server" Text="结算申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0092">
                        <a runat="server" id="div0092" href="caiwu6.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label7" runat="server" Text="结算审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0093">
                        <a runat="server" id="div0093" href="caiwu7.aspx"><font color="blue">
                            <asp:Label ID="Label8" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0094">
                        <a runat="server" id="div0094" href="caiwu8.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="付款申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0095">
                        <a runat="server" id="div0095" href="caiwu8.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="付款审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0096">
                        <a runat="server" id="div0096" href="caiwu8.aspx?models=3"><font color="blue">
                            <asp:Label ID="Label11" runat="server" Text="付款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <!--#endeditable-->
                </dl>
            </div>
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
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
                    width: 1140px; height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px">收款确认管理</font></strong>
                    </h4>
                </div>
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox21" runat="server" class="form-control input-sm" Width="190px"
                                    Text="发票单号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt发票单号" TabIndex="11" Style="margin-left: 0px" Width="380" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox25" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合同类型" TabIndex="12" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox32" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox合同名称" TabIndex="13" Style="margin-left: 0px" Width="950px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox18" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合同编号" TabIndex="14" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox26" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合同金额" TabIndex="15" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox27" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox付款单位名称" TabIndex="15" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox29" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票单位名称" TabIndex="16" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox34" runat="server" class="form-control input-sm" Width="190px"
                                    Text="发票类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox发票类型" TabIndex="18" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox35" runat="server" class="form-control input-sm" Width="190px"
                                    Text="发票类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox发票类别" TabIndex="19" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox36" runat="server" class="form-control input-sm" Width="190px"
                                    Text="项目属性：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox项目属性" TabIndex="20" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox37" runat="server" class="form-control input-sm" Width="190px"
                                    Text="所属项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox所属项目部" TabIndex="21" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox39" runat="server" class="form-control input-sm" Width="190px"
                                    Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox项目经理" TabIndex="22" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" class="form-control input-sm" Width="190px"
                                    Text="发票状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox发票状态" TabIndex="23" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" class="form-control input-sm" Width="190px"
                                    Text="申请人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox申请人" TabIndex="24" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="190px"
                                    Text="申请日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox申请日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票人" TabIndex="24" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" class="form-control input-sm" Width="190px"
                                    Height="66px" Text="发票备注栏信息：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox发票备注栏信息" TabIndex="13" Style="margin-left: 0px" Width="950px"
                                    runat="server" class="form-control input-sm" TextMode="MultiLine" Rows="3" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox13" runat="server" class="form-control input-sm" Width="190px"
                                    Text="发票价税合计金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox发票价税合计金额" TabIndex="13" Style="margin-left: 0px" Width="950px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第一次到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox第一次到账金额" TabIndex="24" Style="margin-left: 0px; text-align: right"
                                        Width="347px" runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"
                                        onblur='NumberCheck(this);tongji();'></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span管理编号">
                                        <asp:LinkButton ID="LinkButton2" runat="server" Class="btn btn-default btn-sm" OnClientClick="PopUpEmployeeQuery1('1','<%=TextBox第一次到账金额.ClientID %>','<%=TextBox第一次到账日期.ClientID %>');return false;"
                                            data-toggle="tooltip" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                                    </span>
                                    
                                </div>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第一次到账日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox第一次到账日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第二次到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox第二次到账金额" TabIndex="24" Style="margin-left: 0px; text-align: right"
                                        Width="347px" runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"
                                        onblur='NumberCheck(this);tongji();'></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span1">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm" OnClientClick="PopUpEmployeeQuery2('2','<%=TextBox第二次到账金额.ClientID %>','<%=TextBox第二次到账日期.ClientID %>');  return false;"
                                            data-toggle="tooltip" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第二次到账日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox第二次到账日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox15" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第三次到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox第三次到账金额" TabIndex="24" Style="margin-left: 0px; text-align: right"
                                        Width="347px" runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"
                                        onblur='NumberCheck(this);tongji();'></asp:TextBox>
                                     <span class="input-group-btn" runat="server" id="span2">
                                        <asp:LinkButton ID="LinkButton3" runat="server" Class="btn btn-default btn-sm" OnClientClick="PopUpEmployeeQuery3('3','<%=TextBox第三次到账金额.ClientID %>','<%=TextBox第三次到账日期.ClientID %>');  return false;"
                                            data-toggle="tooltip" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox17" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第三次到账日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox第三次到账日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第四次到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox第四次到账金额" TabIndex="24" Style="margin-left: 0px; text-align: right"
                                        Width="347px" runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"
                                        onblur='NumberCheck(this);tongji();'></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span3">
                                        <asp:LinkButton ID="LinkButton4" runat="server" Class="btn btn-default btn-sm" OnClientClick="PopUpEmployeeQuery4('4','<%=TextBox第四次到账金额.ClientID %>','<%=TextBox第四次到账日期.ClientID %>');return false;"
                                            data-toggle="tooltip" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox22" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第四次到账日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox第四次到账日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox19" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第五次到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox第五次到账金额" TabIndex="24" Style="margin-left: 0px; text-align: right"
                                        Width="347px" runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"
                                        onblur='NumberCheck(this);tongji();'></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span4">
                                        <asp:LinkButton ID="LinkButton5" runat="server" Class="btn btn-default btn-sm" OnClientClick="PopUpEmployeeQuery5('5','<%=TextBox第五次到账金额.ClientID %>','<%=TextBox第五次到账日期.ClientID %>'); return false;"
                                            data-toggle="tooltip" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox24" runat="server" class="form-control input-sm" Width="190px"
                                    Text="第五次到账日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox第五次到账日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="190px"
                                    Text="总计到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox总计到账金额" TabIndex="24" Style="margin-left: 0px; text-align: right"
                                    Width="380px" runat="server" class="form-control input-sm" autocomplete="off"
                                    onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox14" runat="server" class="form-control input-sm" Width="190px"
                                    Text="到账情况：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox到账情况" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox45" runat="server" class="form-control input-sm" Width="190px"
                                    Height="66px" Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="31" Style="margin-left: 0px" Width="950px"
                                    TextMode="MultiLine" Rows="3" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-1 col-sm-offset-4">
                        <asp:Button ID="Button3" runat="server" Text="保存" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn保存_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1">
                        <asp:Button ID="Button7" runat="server" Text="返回" TabIndex="38" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn返回_Click" />
                    </div>
                </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
