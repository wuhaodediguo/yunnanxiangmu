<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="shichang2Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shichang2Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 800px;
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
         .td2{   

            white-space: nowrap;/*控制单行显示*/   

            overflow: hidden;/*超出隐藏*/   

            text-overflow: ellipsis;/*隐藏的字符用省略号表示*/   

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
    <script type="text/javascript">
        function cleanForm() {


            return false;
        }
 </script>

    <asp:HiddenField ID="HdCol2附件1" runat="server" />
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                市场管理&gt;中标管理
            </div>
        </div>
        <div class="main_con" >
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0021">
                        <a runat="server" id="div0021" href="shichang1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="投标管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0022">
                        <a runat="server" id="div0022" href="shichang2.aspx"><font color="blue">
                            <asp:Label ID="Label3" runat="server" Text="中标管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0023">
                        <a runat="server" id="div0023" href="shichang3.aspx"><font color="blue">
                            <asp:Label ID="Label4" runat="server" Text="客商管理" Font-Size="14px"></asp:Label></font></a></dd>
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
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px; width:1080px;
                    height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px" >中标新增管理</font></strong>
                    </h4>
                </div>
                
                <div class="tab-content" style="margin: 0px auto; font-size: 10px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>年份：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt年份" TabIndex="11" Style="margin-left: 0px" Width="180px" runat="server"
                                    class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox25" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建人" TabIndex="12" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox18" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建日期" TabIndex="14" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox26" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>招标人：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox招标人" TabIndex="15" Style="margin-left: 0px" Width="900px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox5" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>招标代理机构：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox招标代理机构" TabIndex="15" Style="margin-left: 0px" Width="900px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox29" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>招标项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox招标项目名称" TabIndex="16" Style="margin-left: 0px" Width="900px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox24" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>中标人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox中标人" TabIndex="16" Style="margin-left: 0px" Width="900px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox35" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>招标编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox招标编号" TabIndex="19" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox28" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>中标公示日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox中标公示日期" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>招标方式：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox招标方式" TabIndex="19" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  ></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox31" runat="server" class="form-control input-sm" Width="180px"
                                    Text="<font color='red'>*</font>中标标段：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox中标标段" TabIndex="21" Style="margin-left: 0px" Width="900px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox222" runat="server" class="form-control input-sm" Width="180px"
                                    Text="中标通知书领取日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox中标通知书领取日期" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox33" runat="server" class="form-control input-sm" Width="180px"
                                    Text="缴纳中标服务费金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox缴纳中标服务费金额" TabIndex="21" Style="margin-left: 0px;text-align: right;" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox35" runat="server" class="form-control input-sm" Width="180px"
                                    Text="缴纳中标服务费日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox缴纳中标服务费日期" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox37" runat="server" class="form-control input-sm" Width="180px"
                                    Text="中标服务费发票领取时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox中标服务费发票领取时间" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off"  onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox39" runat="server" class="form-control input-sm" Width="180px"
                                    Text="缴纳履约保证金金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox缴纳履约保证金金额" TabIndex="21" Style="margin-left: 0px;text-align: right;" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox41" runat="server" class="form-control input-sm" Width="180px"
                                    Text="缴纳履约保证金形式：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox缴纳履约保证金形式" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox43" runat="server" class="form-control input-sm" Width="180px"
                                    Text="缴纳履约保证金时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox缴纳履约保证金时间" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="180px"
                                    Text="缴纳履约保证金到期时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox缴纳履约保证金到期时间" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox45" runat="server" class="form-control input-sm" Width="180px"
                                    Text="履约保函开具银行：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox履约保函开具银行" TabIndex="21" Style="margin-left: 0px" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            
                            <td>
                                <asp:TextBox ID="TextBox47" runat="server" class="form-control input-sm" Width="180px"
                                    Text="履约保证金退还金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox履约保证金退还金额" TabIndex="21" Style="margin-left: 0px;text-align: right;" Width="180px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox49" runat="server" class="form-control input-sm" Width="180px"
                                    Text="履约保证金保函退还日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox履约保证金保函退还日期" TabIndex="21" Style="margin-left: 0px" Width="540px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox51" runat="server" class="form-control input-sm" Width="180px"
                                    Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="30" Style="margin-left: 0px" Width="900px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox报名起止日期" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox开标日期" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标人" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标报名标段" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox缴纳报名费金额" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox报名费发票领取时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox缴纳投标保证金金额" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox缴纳投标保证金形式" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox缴纳投标保证金时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标保函开具银行" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标授权代表" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标保证金退还金额" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标保证金保函退还日期" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox招标文件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox缴纳保证金保函" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="TextBox投标文件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTextBox7" runat="server" class="form-control input-sm" Width="180px"
                                    Height="52px" Text="<font color='red'>*</font>中标通知书：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:FileUpload ID="FileUpload2" runat="server" TabIndex="21" Width="178px" Style="margin-left: 2px" />
                                <asp:Button ID="Button2" runat="server" TabIndex="22" Text="上传" Style="font-size:12px;
                                    margin-left: 2px" OnClick="FileUpload中标通知书Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <asp:TextBox ID="TextBox中标通知书" runat="server" class="form-control input-sm" Style="display: none" Visible="false"></asp:TextBox>
                                <a href="" runat="server" id="中标通知书href" target="_blank" style="font-size:12px;"  Visible="false">中标通知书</a>
                                <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblTextBox6" runat="server" class="form-control input-sm" Width="180px"
                                    Height="52px" Text="<font color='red'>*</font>履约保证金/保函：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="21" Width="178px" Style="margin-left: 2px" />
                                <asp:Button ID="Button4" runat="server" TabIndex="22" Text="上传" Style="font-size:12px;
                                    margin-left: 2px" OnClick="FileUpload履约保证金保函Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <asp:TextBox ID="TextBox履约保证金保函" runat="server" class="form-control input-sm" Style="display: none" Visible="false"></asp:TextBox>
                                <a href="" runat="server" id="履约保证金保函href" target="_blank" style="font-size:12px;"  Visible="false">履约保证金/保函</a>
                                <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach2_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                           
                        </tr>
                        <tr>
                          
                            <td colspan="3">
                                <div id="Div2" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView1" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView1_RowDataBound" 
                                OnRowCommand="GridView1_RowCommand" ShowHeader="false">
                                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle"  />
                                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle"  />
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center" >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="30"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                           
                            <td colspan="3">
                                <div id="Div3" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView2" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView2_RowDataBound" 
                                OnRowCommand="GridView2_RowCommand" ShowHeader="false">
                                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle"  />
                                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle"  />
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-left"  ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-left"  ItemStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="30"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                            
                        </tr>
                    </table>

                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-sm-1 col-sm-offset-4">
                        <asp:Button ID="Button6" runat="server" Text="保存" TabIndex="35" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn保存_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1">
                        <asp:Button ID="Button7" runat="server" Text="返回" TabIndex="36" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn返回_Click" />
                    </div>
                </div>
                <br />
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
