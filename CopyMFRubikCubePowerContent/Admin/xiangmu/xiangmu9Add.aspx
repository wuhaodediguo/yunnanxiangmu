<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="xiangmu9Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.xiangmu9Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style type="text/css">
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 640px;
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
            font-size: 12px;
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
        .td2
        {
            white-space: nowrap; /*控制单行显示*/
            overflow: hidden; /*超出隐藏*/
            text-overflow: ellipsis; /*隐藏的字符用省略号表示*/
        }
    </style>
    <script type="text/javascript">

        function formatAsNum(mnt) {
            mnt -= 0;
            mnt = (Math.round(mnt * 100)) / 100;
            return mnt;
        }

        function NumberCheck(iField) {
            document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = "";
            if (isNaN(iField.value)) {
                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 请输入数字</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

                return false;
            }

            if (1 && iField.value < 0) {

                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 请输入大于0的数字</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

                return false;
            }

            if ((iField.value.length > 0) && (iField.value.indexOf(' ', 0) >= 0)) {

                iField.value = "";
                iField.focus();
                var tHTML = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong><big><span class='glyphicon glyphicon-warning-sign' aria-hidden='true'></span></big>Warning! &nbsp;</strong> 请输入大于0的数字</div>";
                document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = tHTML;

                return false;
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


        function LinkPrintPage() {


            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            alert(temp6);
            window.open('/Admin/xiangmu/shenhefujian.aspx?txtquanxian=' + txtquanxian + "&&fullname=" + fullname + "&&chakanmodel=" + chakanmodel + "&&temp1=" + temp1 +
            "&&temp2=" + temp2 + "&&temp3=" + temp3 + "&&temp4=" + temp4 + "&&temp5=" + temp5 + "&&temp6=" + temp6 + "&&temp7=" + temp7 + "&&temp8=" + temp8 +
             "&&temp9=" + temp9 + "&&caset=" + caset + "&&tickedFormNo=" + tickedFormNo,
                                'Window_Query', 'left=' + PosX + ',top=' + PosY + ',height=400,width=1000,scrollbars=yes');

        }

        function APlistPoP(formNo) {

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;
           
            var chakanmodel = document.getElementById('<%=Hdchakanmodel.ClientID %>').value;
            var temp1 = document.getElementById('<%=Hdtemp1.ClientID %>').value;
            var temp2 = document.getElementById('<%=Hdtemp2.ClientID %>').value;
            var temp3 = document.getElementById('<%=Hdtemp3.ClientID %>').value;
            var temp4 = document.getElementById('<%=Hdtemp4.ClientID %>').value;
            var temp5 = document.getElementById('<%=Hdtemp5.ClientID %>').value;
            var temp6 = document.getElementById('<%=Hdtemp6.ClientID %>').value;
            var temp7 = document.getElementById('<%=Hdtemp7.ClientID %>').value;
            var temp8 = document.getElementById('<%=Hdtemp8.ClientID %>').value;
            var temp9 = document.getElementById('<%=Hdtemp9.ClientID %>').value;
            var caset = document.getElementById('<%=Hdtcaset.ClientID %>').value;
            var HdID = document.getElementById('<%=HdID.ClientID %>').value;


            window.open('/Admin/xiangmu/shenhefujian.aspx?chakanmodel=' + chakanmodel + "&&temp1=" + temp1 + "&&temp2=" + temp2 + "&&temp3=" + temp3 + "&&HdID=" + HdID +
            "&&temp4=" + temp4 + "&&temp5=" + temp5 + "&&temp6=" + temp6 + "&&temp7=" + temp7 + "&&temp8=" + temp8 + "&&temp9=" + temp9 + "&&caset=" + caset +
             "&&tickedFormNo=" + formNo,
                                'Window_Query', 'left=' + PosX + ',top=' + PosY + ',height=400,width=1000,scrollbars=yes');

        }


        function LinkPrintPage2() {


            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            alert(temp6);
            window.open('/Admin/xiangmu/shenhefujian.aspx?txtquanxian=' + txtquanxian,
                                'Window_Query', 'left=' + PosX + ',top=' + PosY + ',height=400,width=1000,scrollbars=yes');

        }


        function btnAddPartDetail() {

            ShowProgressBar();
            document.getElementById("<%=HiddenField1.ClientID%>").value = "1";
        }




    </script>
    <asp:Button ID="Confirm" runat="server" Style="display: none" OnClick="btn返回_Click" />
    <asp:Button ID="Confirm22" runat="server" Style="display: none" OnClick="btn提交22_Click" />
    <asp:HiddenField ID="Hdchakanmodel" runat="server" />
     <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HdID" runat="server" />
    <asp:HiddenField ID="HdcasetName" runat="server" />
    <asp:HiddenField ID="HdCol2附件1" runat="server" />
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <asp:HiddenField ID="HdCol2附件4" runat="server" />
    <asp:HiddenField ID="HdCol2附件5" runat="server" />
    <asp:HiddenField ID="Hdtemp1" runat="server" />
    <asp:HiddenField ID="Hdtemp2" runat="server" />
    <asp:HiddenField ID="Hdtemp3" runat="server" />
    <asp:HiddenField ID="Hdtemp4" runat="server" />
    <asp:HiddenField ID="Hdtemp5" runat="server" />
    <asp:HiddenField ID="Hdtemp6" runat="server" />
    <asp:HiddenField ID="Hdtemp7" runat="server" />
    <asp:HiddenField ID="Hdtemp8" runat="server" />
    <asp:HiddenField ID="Hdtemp9" runat="server" />
    <asp:HiddenField ID="Hdtcaset" runat="server" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                项目管理&gt;项目资料管理
            </div>
        </div>
        <div class="main_con" style="font-size: 10px;">
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
            <div class="col-sm-12" style="width: 88%;">
                <div id="AlertDiv" runat="server">
                </div>
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
                    width: 1120px; height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px"><asp:Label ID="lbltitle" runat="server" Text="项目资料管理列表►查看"></asp:Label>
                        </font></strong>
                    </h4>
                </div>
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="140px"
                                    Text="合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txt合同名称" TabIndex="11" Style="margin-left: 0px" Width="980px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control input-sm" Width="140px"
                                    Text="合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox合同编号" TabIndex="12" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="140px"
                                    Text="合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox合同金额" TabIndex="15" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" Width="140px"
                                    Text="建设单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox建设单位" TabIndex="13" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" class="form-control input-sm" Width="140px"
                                    Text="施工单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox施工单位" TabIndex="14" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox14" runat="server" class="form-control input-sm" Width="140px"
                                    Text="项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox项目部" TabIndex="13" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox13" runat="server" class="form-control input-sm" Width="140px"
                                    Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox项目经理" TabIndex="14" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="140px"
                                    Text="项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox项目名称" TabIndex="11" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" class="form-control input-sm" Width="140px"
                                    Text="项目编码：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox项目编码" TabIndex="13" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" class="form-control input-sm" Width="140px"
                                    Text="单项工程名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox单项工程名称" TabIndex="11" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server" class="form-control input-sm" Width="140px"
                                    Text="结算类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox结算类型" TabIndex="11" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <asp:Label ID="lblBox38" runat="server" class="form-control input-sm" Width="160px"
                                        Text="发票扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox发票扫描件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="发票扫描件href" target="_blank">发票扫描件</a>
                            </td>
                            <td>
                                <asp:Label ID="lblBox40" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>采购订单扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox采购订单扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="采购订单扫描件href" target="_blank">采购订单扫描件</a>
                            </td>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>完工结算证明扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <a href="" runat="server" id="完工结算证明扫描件href" target="_blank">完工结算证明扫描件</a>
                                    <asp:TextBox ID="TextBox完工结算证明扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox23" runat="server" class="form-control input-sm" Width="160px"
                                        Text="审计定案扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                 <asp:TextBox ID="TextBox审计定案扫描件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="审计定案扫描件href" target="_blank">审计定案扫描件</a>
                            </td>
                            <td>
                                <asp:Label ID="lblBox26" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>竣工资料及图纸附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox竣工资料及图纸附件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="竣工资料及图纸附件href" target="_blank">竣工资料及图纸附件</a>
                            </td>
                            
                        </tr>--%>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox12" runat="server" class="form-control input-sm" Width="140px"
                                    Text="<font color='red'>*</font>结算金额(不含税)：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox结算金额不含税" TabIndex="13" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this);tongji();'></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" class="form-control input-sm" Width="140px"
                                    Text="<font color='red'>*</font>税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税率1" TabIndex="25" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" class="form-control input-sm" Width="140px"
                                    Text="<font color='red'>*</font>税额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税额1" TabIndex="13" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" class="form-control input-sm" Width="140px"
                                    Text="结算金额(含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox结算金额含税" TabIndex="14" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="140px"
                                    Text="审定金额(不含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox审定金额不含税" TabIndex="13" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this);tongji2();'></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" class="form-control input-sm" Width="140px"
                                    Text="税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税率2" TabIndex="25" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" class="form-control input-sm" Width="140px"
                                    Text="税额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税额2" TabIndex="13" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" class="form-control input-sm" Width="140px"
                                    Text="审定金额(含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox审定金额含税" TabIndex="14" Style="margin-left: 0px" Width="140px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="140px"
                                    Text="创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox创建人" TabIndex="13" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="140px"
                                    Text="创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox创建日期" TabIndex="14" Style="margin-left: 0px" Width="420px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="140px"
                                    Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="11" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                <asp:TextBox ID="TextBox到账金额" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                <asp:TextBox ID="TextBox到账日期" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="table-responsive" style="width: 1120px">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                            BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound"
                            OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" ShowHeader="true">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderText="开票次数">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Eval("A1") %>' Width="30px" Style="text-align: center;
                                            font-size: 12px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票申请单号" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl发票申请单号" runat="server" Text=' <%# Bind("A11") %>' Width="130px"
                                            Style="text-align: center; font-size: 12px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票不含税金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol541" runat="server" Text='<%# Bind("A12") %>' Width="70px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票含税金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol54" runat="server" Text='<%# Bind("A2") %>' Width="70px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="货物、服务名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("A3") %>' Width="70px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票类型" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol19" runat="server" Text='<%# Bind("A4") %>' Width="60px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票类别" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol20" runat="server" Text='<%# Bind("A5") %>' Width="60px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol14" runat="server" Text='<%# Bind("A6") %>' Width="40px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("A7") %>' Width="100px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="到账金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol43" runat="server" Text='<%# Bind("A8") %>' Width="70px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="到账日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol24" runat="server" Text='<%# Bind("A9") %>' Width="100px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol49" runat="server" Text='<%# Eval("A10") %>' Width="100px" Style="text-align: left;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="资料管理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <button type="button" style="border: 0; background-color:transparent" onclick="APlistPoP('<%# Eval("A11") %>');">
                                           
                                            <span class="glyphicon glyphicon-list-alt" style="font-size:14px; border-bottom-color:Red"><asp:Label runat="server" Text="操作" ForeColor="Red"></asp:Label></span>
                                        </button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-1 col-sm-offset-4">
                            <asp:Button ID="btn提交" runat="server" Text="提交" TabIndex="38" CssClass="btn22" Style="background-color: RGB(146,208,80)"
                                OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn提交_Click" />
                            <asp:Button ID="Button7" runat="server" Text="返回" TabIndex="38" CssClass="btn22"
                                Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn返回_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <!--#endeditable-->
        </div>
        <!-- Add PartSpecification Setting Area -->
        <!-- Modal -->
        <%--<div class="modal fade" id="myModalAdd" role="dialog" >
            <div class="modal-dialog" style=" width:800px; height:600px; ">
                <!-- Modal content-->
                <div class="modal-content" >
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        
                    </div>
                    <div class="modal-body" style="margin: 100px 0 0 0">
                        <!-- PartNo-->
                        <div class="row" style="margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Button ID="Button1" runat="server" Text="查询附件" CssClass="btn btn-primary" OnClick="btn提交22_Click" />
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                
                            </div>
                        </div>
                        <div class="row" style="margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label发票单号" runat="server" class="control-label" Text="发票单号"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:TextBox ID="txtInput发票单号" runat="server" class="form-control"  > 
                                </asp:TextBox>
                            </div>
                        </div>
                        <div id="div审核人" runat="server" visible="false" class="row" style="margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label13" runat="server" class="control-label" Text="审核人"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:TextBox ID="TextBox审核人" runat="server" class="form-control"  > 
                                </asp:TextBox>
                            </div>
                        </div>
                        <div id="div审核意见" runat="server" visible="false" class="row" style="margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label14" runat="server" class="control-label" Text="审核意见"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:TextBox ID="TextBox审核意见" runat="server" class="form-control"  > 
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row" id="div附件名称" runat="server" style="margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label附件名称" runat="server" class="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:FileUpload ID="FileUpload0" runat="server" TabIndex="35" Style="margin-left: 1px;" />
                                <asp:Button ID="Button9" runat="server" Text="上传" TabIndex="36" Style="font-size: 14;
                                    margin-left: 1px" OnClick="FileUpload税票扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <a href="" runat="server" id="税票扫描件href" target="_blank" visible="false"></a>
                                <asp:TextBox ID="TextBox税票扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div id="Div3" runat="server" width="158px" style="width: 100%; height: 180px; overflow: auto;
                            margin-top: 2px; background-color: RGB(217,237,247);">
                            <asp:GridView ID="GridView2" runat="server" Font-Size="12px" DefaultType="1" AutoGenerateColumns="False"
                                BorderWidth="0px" CssClass="table table-bordered " OnRowDataBound="GridView2_RowDataBound" 
                                OnRowCommand="GridView2_RowCommand" >
                                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" />
                                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID2" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="附件名称">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"
                                                NavigateUrl='<%# Bind("col3") %>' Width="300"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField  HeaderText="上传人">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField  HeaderText="上传时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="审核人">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="审核时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col7") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="审核意见">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="20"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer" >
                        <div class="row" >
                            <div class="col-xs-4 col-md-4" align="center" id="div附件名称footer" runat="server" visible="false">
                                <asp:Button ID="btn审核" runat="server" Text="审核通过" CssClass="btn btn-primary" OnClick="btn审核_Click"
                                    OnClientClick="return inputcheck();RotateAnimation(this);$('#myModalAdd').modal('hide');return ShowProgressBar();"
                                    data-toggle="tooltip" data-placement="right" ToolTip="Add a new Part Specification" />
                            </div>
                            <div class="col-xs-4 col-md-4" align="center" id="div附件名称footer2" runat="server" visible="false">
                                <asp:Button ID="Button2" runat="server" Text="审核不通过" CssClass="btn btn-primary" OnClick="btn审核不通过_Click"
                                    OnClientClick="return inputcheck();RotateAnimation(this);$('#myModalAdd').modal('hide');return ShowProgressBar();"
                                    data-toggle="tooltip" data-placement="right" ToolTip="Add a new Part Specification" />
                            </div>
                            <div class="col-xs-4 col-md-4" align="center">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    关闭
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
</asp:Content>
