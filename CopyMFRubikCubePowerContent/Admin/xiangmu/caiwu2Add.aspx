<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="caiwu2Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu2Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
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

        function uploadFile() {
            var ofile = $("#file").get(0).files[0];
            var formData = new FormData();
            if (!ofile) {
                $.messager.alert('提示', '请上传文件!', 'info');
                return;
            }
            var size = ofile.size / 1024 / 1024;
            if (size > 5) {
                $.messager.alert('提示', '文件不能大于5M', 'info');
                return;
            }

            formData.append("file", ofile); //这个是文件，这里只是演示上传了一个文件，如果要上传多个的话将[0]去掉
            formData.append("F_ID", $("#F_ID").val()); //这个是上传的其他参数
            formData.append("F_NAME", fNameHL);


            $.ajax({
                url: api_address + 'api/Test/Test',
                type: "POST",
                data: formData,
                cache: false, //不需要缓存
                processData: false,
                contentType: false,
                success: function (data) {
                    var ss = $.parseJSON(data);
                    if (ss.MSG == 'OK') {
                        $.messager.alert('提示', '保存成功!', 'info');

                    }
                }
            });
        }

        function QueryProjectCodeInfo(obj) {

            var purpose = "Allxiangmu";
            var getlimitid = document.getElementById('<%=TextBoxlimit.ClientID %>').value;

            QueryByWindowOpen(purpose, "xiangmu", true, getlimitid);
            ShowProgressBar();
        }

        function QueryByWindowOpen(purpose, identity, preload, limit) {

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;
            

            window.open('/Admin/xiangmu/BASEQ04.aspx?QueryPurpose=' + purpose + '&&QueryIdentity=' + identity + '&&QueryPreload=' + preload + '&&QueryLimit=' + limit,
            "PopupWindow", 'left=' + PosX + ',top=' + PosY + ',height=350,width=800,scrollbars=yes');

        }

        function GetValueFromWindowOpen(object) {

            if (object.purpose == 'Allxiangmu') {

                var txt项目名称 = document.getElementById('<%=txt项目名称.ClientID %>');
                txt项目名称.value = object.col1;
                var TextBox项目编码 = document.getElementById('<%=TextBox项目编码.ClientID %>');
                TextBox项目编码.value = object.col2;
                var Text单项工程名称 = document.getElementById('<%=Text单项工程名称.ClientID %>');
                Text单项工程名称.value = object.col3;
            
                var TextBoxID = document.getElementById('<%=TextBoxID.ClientID %>');
                TextBoxID.value = object.col7;
                document.getElementById("<%=Loadxiangmu.ClientID%>").click();

            }

        }

        function tongji() {

            var Drop税率 = document.getElementById('<%= Drop税率.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
           
            var amount1 = 0;
            var amount2 = 0;
            var amount3 = 0;

            var TextBox金额 = document.getElementById('<%= TextBox金额.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox税额 = document.getElementById('<%= TextBox税额.ClientID %>');
            var TextBox合计 = document.getElementById('<%= TextBox合计.ClientID %>');

            if (TextBox金额) {
                amount1 = formatAsNum(TextBox金额);
            }

            if (Drop税率 == "3%") {
                amount3 = 0.03;
            }
            else if (Drop税率 == "0%") {
                amount3 = 0;
            }
            else if (Drop税率 == "6%") {
                amount3 = 0.06;
            }
            else if (Drop税率 == "10%") {
                amount3 = 0.1;
            }
            else if (Drop税率 == "16%") {
                amount3 = 0.16;
            }
            else if (Drop税率 == "11%") {
                amount3 = 0.11;
            }
            else if (Drop税率 == "17%") {
                amount3 = 0.17;
            }
            else if (Drop税率 == "9%") {
                amount3 = 0.09;
            }
            else if (Drop税率 == "13%") {
                amount3 = 0.13;
            }

            TextBox金额.value = formatNumberHeader(amount1);
            TextBox税额.value = formatNumberHeader(amount1  * amount3);
            TextBox合计.value = formatNumberHeader(amount1 * (1 + amount3));
            
            return true;
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
    <asp:TextBox ID="txthetonglx" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxID" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdNo" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdNo2" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxlimit" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:Button ID="Loadxiangmu" runat="server" Style="display: none" OnClick="Loadxiangmu_Click" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                财务管理&gt;开票申请
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
                            <asp:Label ID="Label111" runat="server" Text="开票申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0063">
                        <a runat="server" id="div0063" href="caiwu3.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="开票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0067">
                        <a runat="server" id="div0067" href="caiwu31.aspx"><font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="税款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0064">
                        <a runat="server" id="div0064" href="caiwu4.aspx"><font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="发票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0065">
                        <a runat="server" id="div0065" href="caiwu5.aspx"><font color="blue">
                            <asp:Label ID="Label11" runat="server" Text="收款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0091">
                        <a runat="server" id="div0091" href="caiwu6.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label12" runat="server" Text="结算申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0092">
                        <a runat="server" id="div0092" href="caiwu6.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label13" runat="server" Text="结算审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0093">
                        <a runat="server" id="div0093" href="caiwu7.aspx"><font color="blue">
                            <asp:Label ID="Label14" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0094">
                        <a runat="server" id="div0094" href="caiwu8.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label15" runat="server" Text="付款申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0095">
                        <a runat="server" id="div0095" href="caiwu8.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label16" runat="server" Text="付款审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0096">
                        <a runat="server" id="div0096" href="caiwu8.aspx?models=3"><font color="blue">
                            <asp:Label ID="Label17" runat="server" Text="付款管理" Font-Size="14px"></asp:Label></font></a></dd>
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
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px; width:1140px;
                    height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px" >新增开票明细申请</font></strong>
                    </h4>
                </div>
                
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                                
                            </td>
                            <td colspan="5">
                                <div class="input-group">
                                    <asp:TextBox ID="txt项目名称" TabIndex="11" Style="margin-left: 0px" Width="917px" runat="server" onfocus="this.blur();"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span项目名称">
                                                    <asp:LinkButton ID="lkbtntxtcol31" runat="server" Class="btn btn-default btn-sm "
                                                        OnClientClick="QueryProjectCodeInfo(this); return false;" data-toggle="tooltip"
                                                        data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>">
                                                                <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                                    </asp:LinkButton>
                                                </span>
                                </div>
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox25" runat="server" class="form-control input-sm" Width="190px"
                                    Text="项目编码：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox项目编码" TabIndex="12" Style="margin-left: 0px" Width="950px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox32" runat="server" class="form-control input-sm" Width="190px"
                                    Text="单项工程名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="Text单项工程名称" TabIndex="17" Style="margin-left: 0px" Width="950px" runat="server" onfocus="this.blur();"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                
                            </td>
                        </tr>
                        
                        
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox12" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>结算金额(不含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox结算金额不含税" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税率1" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>税额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税额1" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" class="form-control input-sm" Width="190px"
                                    Text="结算金额(含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox结算金额含税" TabIndex="14" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="190px"
                                    Text="审定金额(不含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox审定金额不含税" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" class="form-control input-sm" Width="190px"
                                    Text="税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税率2" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                            </td>
                            
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" class="form-control input-sm" Width="190px"
                                    Text="税额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税额2" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" class="form-control input-sm" Width="190px"
                                    Text="审定金额(含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox审定金额含税" TabIndex="14" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                            </td>
                         </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="190px"
                                    Text="结算类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox结算类型" TabIndex="14" Style="margin-left: 0px; text-align:left;" Width="190px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox27" runat="server" class="form-control input-sm" Width="190px"
                                    Text="已经开票金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox已经开票金额" TabIndex="15" Style="margin-left: 0px; text-align:right;" Width="190px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbltBox29" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>本次开票金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox本次开票金额" TabIndex="16" Style="margin-left: 0px; text-align:right;" Width="190px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this);'></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblBox34" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>货物或应税劳务、服务名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="Drop货物或应税劳务服务名称" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>*建筑服务*工程款</asp:ListItem>
                                    <asp:ListItem>*建筑服务*施工费</asp:ListItem>
                                    <asp:ListItem>*建筑服务*工程服务*</asp:ListItem>
                                    <asp:ListItem>*建筑服务*安全生产费</asp:ListItem>
                                    <asp:ListItem>*建筑服务*工程服务费</asp:ListItem>
                                    <asp:ListItem>*劳务*维修费</asp:ListItem>
                                    <asp:ListItem>*电信服务*基础电信服务</asp:ListItem>
                                    <asp:ListItem>*材料费</asp:ListItem>
                                    <asp:ListItem>*电信服务*代维服务费</asp:ListItem>
						            <asp:ListItem>*信息技术服务*代维服务费</asp:ListItem>
                                     <asp:ListItem>*信息技术服务*技术服务费</asp:ListItem>
                                    <asp:ListItem>*研发和技术服务*选址服务费</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox35" runat="server" class="form-control input-sm" Width="190px"
                                    Text="规格型号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox规格型号" TabIndex="19" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox36" runat="server" class="form-control input-sm" Width="190px"
                                    Text="单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox单位" TabIndex="20" Style="margin-left: 0px; text-align:right;" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox37" runat="server" class="form-control input-sm" Width="190px"
                                    Text="数量：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox数量" TabIndex="21" Style="margin-left: 0px; text-align:right;" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox39" runat="server" class="form-control input-sm" Width="190px"
                                    Text="单价：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox单价" TabIndex="22" Style="margin-left: 0px;text-align: right;" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this);'></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lbltBox6" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2"> 
                                <asp:TextBox ID="TextBox金额" TabIndex="23" Style="margin-left: 0px;text-align: right;" Width="380px" 
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this);tongji();'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                                <asp:Label ID="lblBox7" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Drop税率" TabIndex="25" Style="margin-left: 0px" Width="190px"  onchange='tongji();'
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>0%</asp:ListItem>
                                    <asp:ListItem>3%</asp:ListItem>
                                    <asp:ListItem>6%</asp:ListItem>
                                    <asp:ListItem>9%</asp:ListItem>
                                    <asp:ListItem>10%</asp:ListItem>
                                    <asp:ListItem>11%</asp:ListItem>
                                    <asp:ListItem>13%</asp:ListItem>
                                    <asp:ListItem>16%</asp:ListItem>
                                    <asp:ListItem>17%</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="190px"
                                    Text="税额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税额" TabIndex="25" Style="margin-left: 0px; text-align:right;" Width="190px" 
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合计：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合计" TabIndex="25" Style="margin-left: 0px; text-align:right;" Width="190px" 
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                      
                    </table>
                </div>
                <br />
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
               
                <br />
            </div>
            <!--#endeditable-->
        </div>
    </div>
    </div>
</asp:Content>

