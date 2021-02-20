<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="caiwu4Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu4Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 1780px;
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

        function QtyCheck(iField) {
            document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = "";
            if (isNaN(iField.value)) {
                if (iField.value.indexOf("%") > 0) {

                }
                else {
                    iField.value = "";
                    iField.focus();

                    return false;
                }

            }



            if ((iField.value.length > 0) && (iField.value.indexOf(' ', 0) >= 0)) {

                iField.value = "";
                iField.focus();

                return false;
            }
            if (iField.value == "" || iField.value == "0") {
                return true;
            }

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

        function tongji() {

            var amount = 0;

            var amount2 = 0;
            var amount3 = 0;
            var amount4 = 0;
            var amount5 = 0;
            var amount6 = 0;

            var gvPartOpen = document.getElementById('<%=GridView1.ClientID%>');

            for (var i = 1; i < gvPartOpen.rows.length; i++) {

                if (i == gvPartOpen.rows.length - 1) {
                    gvPartOpen.rows[i].cells[2].innerText = amount3;
                    gvPartOpen.rows[i].cells[3].innerText = amount4;
                    gvPartOpen.rows[i].cells[4].innerText = formatNumberHeader(amount5);
                    gvPartOpen.rows[i].cells[5].innerText = formatNumberHeader(amount6);

                }
                var tempPrice2 = 0;
                var tPrice2 = "";
                var Price2 = gvPartOpen.rows[i].cells[3].getElementsByTagName("input")[0].value.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
                if (Price2.indexOf("%") > -1) {
                    Price2 = Price2.replace("%", "");
                }
                var Price1 = gvPartOpen.rows[i].cells[2].getElementsByTagName("input")[0].value.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
                if (Price1 && Price2) {

                    amount = formatAsNum(Price1) * formatAsNum(Price2) / 100;
                    if (i == 1) {
                        amount4 = Price2 + "%";
                    }
                    gvPartOpen.rows[i].cells[3].getElementsByTagName("input")[0].value = Price2 + "%";
                    gvPartOpen.rows[i].cells[4].getElementsByTagName("input")[0].value = formatNumberHeader(amount);

                    amount2 = formatAsNum(Price1) + formatAsNum(amount);
                    gvPartOpen.rows[i].cells[5].getElementsByTagName("input")[0].value = formatNumberHeader(amount2);
                    amount3 += formatAsNum(Price1);
                    amount5 += formatAsNum(amount);
                    amount6 += formatAsNum(amount2);
                }
                else if (Price1) {
                    amount3 += formatAsNum(Price1);
                }

            }

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

    <asp:HiddenField ID="HdCol2附件6" runat="server" />
    <asp:HiddenField ID="HdCol2附件5" runat="server" />
    <asp:HiddenField ID="HdCol2附件4" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <asp:TextBox ID="TextBox审核人" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="mainWrap clearfix">
       <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                财务管理&gt;发票查看管理
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
                            <asp:Label ID="Label112" runat="server" Text="开票管理" Font-Size="14px"></asp:Label></font></a></dd>
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
                            <asp:Label ID="Label1" runat="server" Text="结算申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0092">
                        <a runat="server" id="div0092" href="caiwu6.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label2" runat="server" Text="结算审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0093">
                        <a runat="server" id="div0093" href="caiwu7.aspx"><font color="blue">
                            <asp:Label ID="Label5" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0094">
                        <a runat="server" id="div0094" href="caiwu8.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label14" runat="server" Text="付款申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0095">
                        <a runat="server" id="div0095" href="caiwu8.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label15" runat="server" Text="付款审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0096">
                        <a runat="server" id="div0096" href="caiwu8.aspx?models=3"><font color="blue">
                            <asp:Label ID="Label16" runat="server" Text="付款管理" Font-Size="14px"></asp:Label></font></a></dd>
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
                        <strong><font color="blue" size="2px" >发票查看管理</font></strong>
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
                            <td >
                                <asp:TextBox ID="txt发票单号" TabIndex="11" Style="margin-left: 0px" Width="190px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                          <td>
                                <asp:Label ID="lblBox2" runat="server" class="form-control input-sm" Width="190px"
                                    Text="申请人：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox申请人" TabIndex="11" Style="margin-left: 0px" Width="190px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox5" runat="server" class="form-control input-sm" Width="190px"
                                    Text="申请日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox申请日期" TabIndex="12" Style="margin-left: 0px" Width="190px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblBox3" runat="server" class="form-control input-sm" Width="190px"
                                    Text="所属项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox所属项目部" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" >
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox4" runat="server" class="form-control input-sm" Width="190px"
                                    Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox项目经理" TabIndex="14" Style="margin-left: 0px" Width="380px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                <%--<asp:TextBox ID="TextBox项目经理" TabIndex="14" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" class="form-control input-sm" Width="190px"
                                    Text="申请发票类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox申请发票类型" TabIndex="15" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox13" runat="server" class="form-control input-sm" Width="190px"
                                    Text="项目属性：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox项目属性" TabIndex="16" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox12" runat="server" class="form-control input-sm" Width="190px"
                                    Text="申请发票类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox申请发票类别" TabIndex="17" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox15" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合同类型" TabIndex="18" Style="margin-left: 0px" Width="380px" runat="server"
                                    class="form-control input-sm" autocomplete="off">

                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox8" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox合同名称" TabIndex="19" Style="margin-left: 0px" Width="950px"
                                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合同编号" TabIndex="20" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox9" runat="server" class="form-control input-sm" Width="190px"
                                    Text="合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox合同金额" TabIndex="20" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox7" runat="server" class="form-control input-sm" Width="190px"
                                    Text="跨区域经营地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox跨区域经营地址" TabIndex="22" Style="margin-left: 0px" Width="380px"
                                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="lblBox1" runat="server" class="form-control input-sm" Width="190px"
                                    Text="跨区域涉税事项报验管理编号：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
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
                                <asp:Label ID="lblBox16" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox付款单位名称" TabIndex="23" Style="margin-left: 0px" Width="380px"
                                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="lblBox18" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
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
                                <asp:TextBox ID="TextBox6" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位纳税人识别号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox付款单位纳税人识别号" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox20" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位纳税人识别号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票单位纳税人识别号" TabIndex="26" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox付款单位地址" TabIndex="27" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox26" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票单位地址" TabIndex="28" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox付款单位电话" TabIndex="29" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox23" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票单位电话" TabIndex="30" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位开户行：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox付款单位开户行" TabIndex="29" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox28" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位开户行：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票单位开户行" TabIndex="30" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox27" runat="server" class="form-control input-sm" Width="190px"
                                    Text="付款单位账号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox付款单位账号" TabIndex="29" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox30" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票单位账号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票单位账号" TabIndex="30" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox29" runat="server" class="form-control input-sm" Width="190px"
                                    Text="增值税预缴税款方式：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox增值税预缴税款方式" TabIndex="29" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox32" runat="server" class="form-control input-sm" Width="190px"
                                    Text="增值税预缴税款地点：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox增值税预缴税款地点" TabIndex="30" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox31" runat="server" class="form-control input-sm" Width="190px"
                                    Text="增值税预缴金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox国税预缴金额" TabIndex="29" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox34" runat="server" class="form-control input-sm" Width="190px"
                                    Text="附加税预缴金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox地税预缴金额" TabIndex="30" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" class="form-control input-sm" Width="190px"
                                    Text="本次开票金额合计(不含税)：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox本次开票金额合计不含税" TabIndex="39" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" class="form-control input-sm" Width="190px"
                                    Text="税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税率" TabIndex="39" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" class="form-control input-sm" Width="190px"
                                    Text="税额合计：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox税额合计" TabIndex="39" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" class="form-control input-sm" Width="190px"
                                    Text="本次发票价税合计金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox本次发票价税合计金额" TabIndex="39" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox35" runat="server" class="form-control input-sm" Width="190px"
                                     Text="发票备注栏信息：" Font-Bold="true" ReadOnly="true" Height="66px"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox发票备注栏信息" TabIndex="39" Style="margin-left: 0px" Width="950px"
                                     runat="server" class="form-control input-sm" TextMode="MultiLine" Rows="3" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="190px" 
                                    Text="开票人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票人" TabIndex="24" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="190px"
                                    Text="开票日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开票日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox10" runat="server" class="form-control input-sm" Width="190px" 
                                    Text="发票状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox发票状态" TabIndex="24" Style="margin-left: 0px" Width="380px" 
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox14" runat="server" class="form-control input-sm" Width="190px" 
                                    Text="<font color='red'>*</font>发票作废/冲红说明：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox发票作废冲红说明" TabIndex="25" Style="margin-left: 0px" Width="380px" 
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label缴税备注栏信息" runat="server"  class="form-control input-sm" Width="190px"
                                    Height="66px" Text="<font color='red'>*</font>备注栏信息：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox缴税备注栏信息"  TabIndex="39" Style="margin-left: 0px" Width="950px"
                                    TextMode="MultiLine" Rows="3" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        
                        
                    </table>
                    <div class="table-responsive" runat="server" id="divGridView2" style="width: 1140px;overflow: auto; height:180px;">
                        <asp:GridView ID="GridView2" runat="server" Font-Size="12px"  AutoGenerateColumns="False" BorderWidth="0px"
                            CssClass="table table-bordered " AllowSorting="True" OnRowDataBound="GridView2_RowDataBound"
                            ShowFooter="true">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="10px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="10px" />
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
                                       
                                        <asp:Label ID="lblcol31" runat="server"  Text='<%# Bind("col8") %>'
                                            Width="90px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目编码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol32" runat="server" Text='<%# Bind("col9") %>' Width="90px"
                                            Style="text-align: left;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算类型" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol147" runat="server" Text='<%# Bind("col47") %>' Width="120px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单项工程名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol33" runat="server" Text='<%# Bind("col10") %>' Width="200PX"
                                            Style="text-align: left; border: 0;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol34" runat="server" Text='<%# Bind("col11") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol35" runat="server" Text='<%# Bind("col12") %>' Width="40px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol341" runat="server" Text='<%# Bind("col13") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol351" runat="server" Text='<%# Bind("col14") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审定金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol342" runat="server" Text='<%# Bind("col15") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol352" runat="server" Text='<%# Bind("col16") %>' Width="40px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol343" runat="server" Text='<%# Bind("col45") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审定金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol353" runat="server" Text='<%# Bind("col46") %>' Width="90px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已经开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol36" runat="server" Text='<%# Bind("col21") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="本次开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol37" runat="server" Text='<%# Bind("col22") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="货物或应税劳务、服务名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol38" runat="server" Text='<%# Bind("col23") %>' Width="160px"
                                            Style="text-align: left;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="规格型号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol39" runat="server" Text='<%# Bind("col24") %>' Width="90px"
                                            Style="text-align: left;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol40" runat="server" Text='<%# Bind("col25") %>' Width="50px"
                                            Style="text-align: left;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="数量" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol41" runat="server" Text='<%# Bind("col26") %>' Width="50px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单价" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol42" runat="server" Text='<%# Bind("col27") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="col28" HeaderText="金额" ItemStyle-HorizontalAlign="center" />--%>
                                <asp:TemplateField HeaderText="金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol43" runat="server" Text='<%# Bind("col28") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol44" runat="server" Text='<%# Bind("col29") %>' Width="40px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="col30" HeaderText="税额" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField DataField="col31" HeaderText="合计" ItemStyle-HorizontalAlign="center" />--%>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol45" runat="server" Text='<%# Bind("col30") %>' Width="90px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合计" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol46" runat="server" Text='<%# Bind("col31") %>' Width="90px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="table-responsive" style="width: 1140px;overflow: auto; height:180px;">

                    <asp:GridView ID="GridView1" runat="server" Font-Size="12px"  AutoGenerateColumns="False" BorderWidth="0px"
                        CssClass="table table-bordered table-hover table-condensed" AllowSorting="True"  
                        OnRowDataBound="GridView1_RowDataBound" 
                         ShowFooter="true">
                        <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="10px" />
                        <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="10px" />
                        <Columns>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="imbAdd" runat="server" CommandName="AddData" OnClientClick="RotateAnimation(this); return ShowProgressBar();"> 
                                <span>+</span> </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="imbDelete" runat="server" CommandName="DisableData" OnClientClick="RotateAnimation(this); return ShowProgressBar();"> 
                                <span>-</span> </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"
                                        Style="text-align: center;"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="lblcol11" runat="server" Text='<%# Bind("col1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发票号码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcol12" runat="server"  Style="text-align: left;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col2") %>' autocomplete="off"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发票不含税金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcol13" runat="server"  Style="text-align: left;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col3") %>'
                                        autocomplete="off" onblur='QtyCheck(this);tongji()'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcol14" runat="server"  Style="text-align: left;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col4") %>' 
                                        autocomplete="off" onblur='QtyCheck(this);tongji()'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcol15" runat="server" Style="text-align: left; 
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col5") %>' 
                                        autocomplete="off"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发票价税合计金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <div>
                                        <asp:TextBox ID="txtcol16" runat="server"  Text='<%# Bind("col6") %>' 
                                            Style="text-align: left; border: 0;" autocomplete="off"></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <div>
                                        <asp:TextBox ID="txtcol17" runat="server" Text='<%# Bind("col7") %>' 
                                            Style="text-align: left; border: 0;" autocomplete="off"></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                     
                </div>
                <table>
                    <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" class="form-control input-sm" Width="190px" Height="66px"
                                    Text="<font color='red'>*</font>审批状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox审批状态" TabIndex="24" Style="margin-left: 0px" Width="950px" TextMode="MultiLine" Rows="3"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>
                                <asp:TextBox ID="TextBox38" runat="server" class="form-control input-sm" Width="190px" Height="50px"
                                        Text="发票记账联扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;margin-top: 1px;"></asp:TextBox>
                            </td>
                           <td style=" width:400px" >
                                <asp:FileUpload ID="FileUpload1" TabIndex="31" runat="server" Style="margin-left: 1px;" />
                                    <asp:Button ID="Button4" runat="server" Text="上传" TabIndex="32" Style="font-size: 12px;
                                        margin-left: 1px;" OnClick="FileUpload发票记账联扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                    <asp:TextBox ID="TextBox发票记账联扫描件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="发票记账联扫描件href" target="_blank" style="font-size:12px;"></a>
                                    <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox40" runat="server" class="form-control input-sm" Width="190px" Height="50px"
                                        Text="发票发票联扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;margin-top: 1px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload2" TabIndex="33" runat="server" Style="margin-left: 1px;" />
                                    <asp:Button ID="Button5" runat="server" Text="上传" TabIndex="34" Style="font-size: 12px;
                                        margin-left: 1px;" OnClick="FileUpload发票发票联扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                    <asp:TextBox ID="TextBox发票发票联扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="发票发票联扫描件href" target="_blank" style="font-size:12px;"></a>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach2_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            
                        </tr>
                        <tr>
                            
                            
                            <td colspan="2">
                                <div id="Div3" runat="server" width="158px"  style="width: 100%; height:180px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView3" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView3_RowDataBound" 
                                OnRowCommand="GridView3_RowCommand" ShowHeader="false">
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="300" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="20"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                             <td colspan="2">
                                <div id="Div1" runat="server" width="178px"  style="width: 100%; height:180px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView4" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView4_RowDataBound" 
                                OnRowCommand="GridView4_RowCommand" ShowHeader="false">
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="300" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="20"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                             </td>
                             
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" class="form-control input-sm" Width="190px" Height="50px"
                                        Text="税票扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;margin-top: 1px;"></asp:TextBox>
                            </td>
                            <td style=" width:400px" >
                                <asp:FileUpload ID="FileUpload3" runat="server" TabIndex="35" Style="margin-left: 1px;" />
                                    <asp:Button ID="Button6" runat="server" Text="上传" TabIndex="36" Style="font-size: 12px;
                                        margin-left: 1px" OnClick="FileUpload税票扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                    <a href="" runat="server" id="税票扫描件href" target="_blank" style="font-size:12px;"></a>
                                    <asp:TextBox ID="TextBox税票扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach3_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox15" runat="server" class="form-control input-sm" Width="190px" Height="50px"
                                        Text="发票作废/冲红附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                        background-color: RGB(214,220,228); border: 0; margin-left: 0px;margin-top: 1px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload4" runat="server" TabIndex="35" Style="margin-left: 1px;" />
                                    <asp:Button ID="Button1" runat="server" Text="上传" TabIndex="36" Style="font-size: 12px;
                                        margin-left: 1px" OnClick="FileUpload发票作废冲红附件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                    <a href="" runat="server" id="发票作废冲红附件href" target="_blank" style="font-size:12px;"></a>
                                    <asp:TextBox ID="TextBox发票作废冲红附件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach4_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            
                        </tr>
                        <tr>
                            
                            <td colspan="2">
                                <div id="Div2" runat="server" width="158px"  style="width: 100%; height:180px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView5" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView5_RowDataBound" 
                                OnRowCommand="GridView5_RowCommand" ShowHeader="false">
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="300" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="20"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                             <td colspan="2">
                                <div id="Div4" runat="server" width="178px"  style="width: 100%; height:180px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView6" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView6_RowDataBound" 
                                OnRowCommand="GridView6_RowCommand" ShowHeader="false">
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="300"  Target="_blank"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="20"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                             </td>
                             
                        </tr>
                </table>
                <br />

                <div class="row">
                    <div class="col-sm-1 col-sm-offset-1" runat="server" id="保存div" >
                        <asp:Button ID="Button3" runat="server" Text="保存" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn保存_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1" runat="server" id="发票作废div" >
                        <asp:Button ID="btn发票作废" runat="server" Text="发票作废" CssClass="btn22" Width="55px" OnClick="btn发票作废_Click"
                            OnClientClick="RotateAnimation(this); return ShowProgressBar();"></asp:Button>
                    </div>
                     <div class="col-sm-1 col-sm-offset-1" runat="server" id="发票冲红div" >
                        <asp:Button ID="btn发票冲红" runat="server" Text="发票冲红" CssClass="btn22" Width="55px" OnClick="btn发票冲红_Click"
                            Style="background-color: Red" OnClientClick="RotateAnimation(this); return ShowProgressBar();"></asp:Button>
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

