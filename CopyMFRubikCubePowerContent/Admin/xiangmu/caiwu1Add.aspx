<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="caiwu1Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu1Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style type="text/css">
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
        .btn11
        {
            background-color: transparent;
            border: 0px;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 14px;
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

        function QueryByWindowOpen(purpose, identity, preload, limit) {

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;
            if (purpose == 'Allhetongshi') {
                limit = 'lx:' + document.getElementById(limit).value + ',yh:' + document.getElementById('<%=hd用户.ClientID %>').value;

            }

            window.open('/Admin/xiangmu/BASEQ04.aspx?QueryPurpose=' + purpose + '&&QueryIdentity=' + identity + '&&QueryPreload=' + preload + '&&QueryLimit=' + limit,
            "PopupWindow", 'left=' + PosX + ',top=' + PosY + ',height=350,width=800,scrollbars=yes');

        }

        function GetValueFromWindowOpen(object) {

            if (object.purpose == 'Allhezuodanwei') {
                var hide1 = document.getElementById('<%=TextBox纳税人名称.ClientID %>');
                hide1.value = object.col1;
                var hide2 = document.getElementById('<%=TextBox纳税人识别号.ClientID %>');
                hide2.value = object.col2;
            }
            if (object.purpose == 'Allhetongshi') {
                var hide1 = document.getElementById('<%=TextBox合同名称.ClientID %>');
               
                var hdxiangmuid = document.getElementById('<%= hdxiangmuid.ClientID %>');
                hdxiangmuid.value = object.id;

                hide1.value = object.col1;
              
                document.getElementById("<%=Loadxiangmu.ClientID%>").click();
            }

            if (object.purpose == 'Allhetongxiangduifang') {
                var hide1 = document.getElementById('<%=TextBox合同相对方名称.ClientID %>');
                hide1.value = object.col1;
                var hide2 = document.getElementById('<%=TextBox合同相对方纳税人识别号.ClientID %>');
                hide2.value = object.col8;
            }

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

    <asp:TextBox ID="hd用户" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hd合同类型" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:HiddenField ID="hdxiangmuid" runat="server" />
    <asp:Button ID="Loadxiangmu" runat="server" Style="display: none" OnClick="Loadxiangmu_Click" />
    <asp:HiddenField ID="HdCol2附件1" runat="server" />
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                财务管理&gt;外经证管理
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
                            <asp:Label ID="Label8" runat="server" Text="结算审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0093">
                        <a runat="server" id="div0093" href="caiwu7.aspx"><font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0094">
                        <a runat="server" id="div0094" href="caiwu8.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="付款申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0095">
                        <a runat="server" id="div0095" href="caiwu8.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label11" runat="server" Text="付款审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0096">
                        <a runat="server" id="div0096" href="caiwu8.aspx?models=3"><font color="blue">
                            <asp:Label ID="Label12" runat="server" Text="付款管理" Font-Size="14px"></asp:Label></font></a></dd>
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
                    width: 1150px; height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px">外经证新增管理</font></strong>
                    </h4>
                </div>
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="Drop所属项目部" TabIndex="11" Style="margin-left: 0px" Width="390px"
                                    runat="server" class="form-control input-sm" autocomplete="off" AutoPostBack="true"
                                    OnSelectedIndexChanged="Drop所属项目部SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBox25" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <%--<asp:TextBox ID="TextBox项目经理" TabIndex="11" Style="margin-left: 0px" Width="370px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>--%>
                                <asp:DropDownList ID="Drop项目经理" TabIndex="12" Style="margin-left: 0px" Width="370px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox18" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>纳税人名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox纳税人名称" TabIndex="13" Style="margin-left: 0px" Width="222px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span纳税人名称">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allhezuodanwei','TextBox纳税人名称', true,'');">
                                                        <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                                    </button>
                                       
                                    </span>
                                </div>
                                
                            </td>
                            <td>
                                <asp:Label ID="lblBox26" runat="server" class="form-control input-sm" Width="135px"
                                    Text="<font color='red'>*</font>纳税人识别号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox纳税人识别号" TabIndex="14" Style="margin-left: 0px" Width="195px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                             <td>
                                <asp:Label ID="Label7" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>纳税人属性：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="Drop纳税人属性" TabIndex="11" Style="margin-left: 0px" Width="175px"
                                    runat="server" class="form-control input-sm" autocomplete="off" >
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>施工单位</asp:ListItem>
                                    <asp:ListItem>分包单位</asp:ListItem>
                                    <asp:ListItem>劳务单位</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox27" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>跨区域经营地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox跨区域经营地址" TabIndex="15" Style="margin-left: 0px" Width="390px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox29" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>经营方式：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox经营方式" TabIndex="16" Style="margin-left: 0px" Width="370px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox32" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox合同名称" TabIndex="11" Style="margin-left: 0px" Width="922px" runat="server"
                                    class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span合同名称">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allhetongshi','txt合同名称', true,'<%=hd合同类型.ClientID %>');">
                                                        <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                                    </button>
                                       
                                    </span>
                                </div>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox34" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox合同金额" TabIndex="18" Style="margin-left: 0px; text-align: right;"
                                    Width="390px" runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'
                                    ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox35" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>合同有效期限：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox合同有效期限" TabIndex="19" Style="margin-left: 0px" Width="370"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox36" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>合同相对方名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                 <div class="input-group">
                                    <asp:TextBox ID="TextBox合同相对方名称" TabIndex="13" Style="margin-left: 0px" Width="357px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span合同相对方名称">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allhetongxiangduifang','TextBox合同相对方名称', true,'');">
                                                        <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                                    </button>
                                       
                                    </span>
                                </div>
                                
                            </td>
                            <td>
                                <asp:Label ID="lblBox37" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>合同相对方纳税人识别号：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox合同相对方纳税人识别号" TabIndex="21" Style="margin-left: 0px" Width="370" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox39" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>跨区域涉税事项报验管理编号：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox跨区域涉税事项报验管理编号" TabIndex="22" Style="margin-left: 0px" Width="390px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblTextBox6" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>开具渠道：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:Dropdownlist ID="Dropdown开具渠道" TabIndex="23" Style="margin-left: 0px" Width="370px" runat="server"
                                    class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>税务大厅办理</asp:ListItem>
                                    <asp:ListItem>网上系统办理</asp:ListItem>
                                </asp:Dropdownlist>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTextBox7" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>开具时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开具时间" TabIndex="24" Style="margin-left: 0px" Width="255px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblTextBox9" runat="server" class="form-control input-sm" Width="135px"
                                    Text="<font color='red'>*</font>到期时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox到期时间" TabIndex="25" Style="margin-left: 0px" Width="195px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblTextBox11" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>经办人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox经办人1" TabIndex="25" Style="margin-left: 0px" Width="175px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="195px"
                                    Text="延期时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox延期时间" TabIndex="24" Style="margin-left: 0px" Width="255px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" Width="135px"
                                    Text="延长到期时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox延长到期时间" TabIndex="25" Style="margin-left: 0px" Width="195px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox14" runat="server" class="form-control input-sm" Width="195px"
                                    Text="经办人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox经办人2" TabIndex="25" Style="margin-left: 0px" Width="175px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="195px"
                                    Text="核销时间：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox核销时间" TabIndex="24" Style="margin-left: 0px" Width="255px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox15" runat="server" class="form-control input-sm" Width="135px"
                                    Text="核销税务局：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox核销税务局" TabIndex="25" Style="margin-left: 0px" Width="195px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox17" runat="server" class="form-control input-sm" Width="195px"
                                    Text="经办人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox经办人3" TabIndex="25" Style="margin-left: 0px" Width="175px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox13" runat="server" class="form-control input-sm" Width="195px"
                                    Text="使用状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="Drop使用状态" TabIndex="25" Style="margin-left: 0px" Width="255px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem>正常</asp:ListItem>
                                    <asp:ListItem>即将到期</asp:ListItem>
                                    <asp:ListItem>已经到期</asp:ListItem>
                                    <asp:ListItem>已经过期</asp:ListItem>
                                    <asp:ListItem>已经延期</asp:ListItem>
                                    <asp:ListItem>已经核销</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBox41" runat="server" class="form-control input-sm" Width="135px"
                                    Text="<font color='red'>*</font>创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建人" TabIndex="24" Style="margin-left: 0px" Width="195px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox43" runat="server" class="form-control input-sm" Width="195px"
                                    Text="<font color='red'>*</font>创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建日期" TabIndex="25" Style="margin-left: 0px" Width="175px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox45" runat="server" class="form-control input-sm" Width="195px"
                                    Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="31" Style="margin-left: 0px" Width="955px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTextBox1" runat="server" class="form-control input-sm" Width="195px"
                                    Height="52px" Text="<font color='red'>*</font>外经证扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" TabIndex="31" runat="server" Width="253px" Style="margin-left: 2px;" />
                                <asp:Button ID="Button4" runat="server" Text="上传" TabIndex="32" Style="font-size: 12px;
                                    margin-left: 2px;" OnClick="FileUpload外经证扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <asp:TextBox ID="TextBox外经证扫描件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                <a href="" runat="server" id="外经证扫描件href" target="_blank" style="font-size:12px;"></a>
                                <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" Width="135px"
                                    Height="52px" Text="延期后外经证扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td >
                                <asp:FileUpload ID="FileUpload2" TabIndex="33" runat="server" Width="193px" Style="margin-left: 2px; margin-top:0px" />
                                <asp:Button ID="Button5" runat="server" Text="上传" TabIndex="34" Style="font-size: 12px;
                                    margin-left: 2px;" OnClick="FileUpload延期后外经证扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <asp:TextBox ID="TextBox延期后外经证扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                
                                
                           
                                <a href="" runat="server" id="延期后外经证扫描件href" target="_blank" style="font-size:12px;" Visible="false"></a>
                                <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm"  Visible="false"
                                            OnClick="btnAttach2_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            >
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server" class="form-control input-sm" Width="195px"
                                    Height="52px" Text="核销反馈表扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server" TabIndex="35" Width="193px" Style="margin-left: 2px;" />
                                <asp:Button ID="Button6" runat="server" Text="上传" TabIndex="36" Style="font-size: 12px;
                                    margin-left: 2px" OnClick="FileUpload核销反馈表扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <a href="" runat="server" id="核销反馈表扫描件href" target="_blank" style="font-size:12px; width:120px "></a>
                                <asp:TextBox ID="TextBox核销反馈表扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                            <asp:LinkButton ID="LinkButton2" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach3_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            
                            <td colspan="2">
                                <div id="Div2" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto;  margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView1" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView1_RowDataBound" 
                                OnRowCommand="GridView1_RowCommand" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="400" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="30"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                            
                            <td colspan="2">
                                <div id="Div3" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto;  margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView2" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView2_RowDataBound" 
                                OnRowCommand="GridView2_RowCommand" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2" NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="30"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                           
                              <td colspan="2">
                                <div id="Div1" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto;  margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView3" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView3_RowDataBound" 
                                OnRowCommand="GridView3_RowCommand" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2" NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="30"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                             </td>
                             <td></td>
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
