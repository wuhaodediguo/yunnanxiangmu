<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="caiwu8Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu8Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <link rel="stylesheet" href="../Skins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Css/font-awesome.min.css" />
    <link rel="stylesheet" href="../Css/ionicons.min.css" />
    <link rel="stylesheet" href="../Skins/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="../Css/main.css" />
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 1150px;
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
            iField.value = formatNumberHeader(iField.value);
            return true;
        }

        function weightCheck1(iField) {

            var TextBox已经支付金额小写 = document.getElementById('<%= TextBox已经支付金额小写.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox已经支付金额大写 = document.getElementById('<%= TextBox已经支付金额大写.ClientID %>');
            TextBox已经支付金额大写.value = digitUppercase(TextBox已经支付金额小写);

            return true;
        }

        function weightCheck2(iField) {

            var TextBox本次申请支付发票金额小写 = document.getElementById('<%= TextBox本次申请支付发票金额小写.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox本次申请支付发票金额大写 = document.getElementById('<%= TextBox本次申请支付发票金额大写.ClientID %>');
            TextBox本次申请支付发票金额大写.value = digitUppercase(TextBox本次申请支付发票金额小写);

            return true;
        }

        function weightCheck3(iField) {

            var TextBox本次申请支付实际金额小写 = document.getElementById('<%= TextBox本次申请支付实际金额小写.ClientID %>').value.replace(",", "").replace(",", "").replace(",", "").replace(",", "");
            var TextBox本次申请支付实际金额大写 = document.getElementById('<%= TextBox本次申请支付实际金额大写.ClientID %>');
            TextBox本次申请支付实际金额大写.value = digitUppercase(TextBox本次申请支付实际金额小写);

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

        function Replace(obj) {
            return obj.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
        }

        function GetAmount(iField) {
            document.getElementById("<%=AlertDiv.ClientID%>").innerHTML = "";

            var gvPartOpen = document.getElementById('<%=GridView1.ClientID%>');
            var amount = 0;
            for (var i = 1; i < gvPartOpen.rows.length; i++) {
                var Price = Replace(gvPartOpen.rows[i].cells[6].getElementsByTagName("input")[0].value);
                amount += Price;

            }
            document.getElementById("<%=txtAmount.ClientID %>").value = formatNumberHeader(amount);
            iField.value = formatNumberHeader(iField.value);

            return true;
        }

        function QueryProjectCodeInfo(obj) {

            var row = obj.parentNode.parentNode.parentNode.parentNode;
            var No = document.getElementById('<%= hdNo.ClientID %>');

            No.value = row.cells[1].innerText;

            var purpose = "Allxiangmu";
            var getlimitid = "";

            QueryByWindowOpen(purpose, "xiangmu", true, getlimitid);
            ShowProgressBar();
        }

        function QueryByWindowOpen(purpose, identity, preload, limit) {

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            if (purpose == 'Allhetong2') {

                limit = 'XMB:' + document.getElementById('<%=Drop所属项目部.ClientID %>').value + ',XMJL:' + document.getElementById('<%=Drop项目经理.ClientID %>').value;

            }

            window.open('/Admin/xiangmu/BASEQ04.aspx?QueryPurpose=' + purpose + '&&QueryIdentity=' + identity + '&&QueryPreload=' + preload + '&&QueryLimit=' + limit,
            "PopupWindow", 'left=' + PosX + ',top=' + PosY + ',height=350,width=800,scrollbars=yes');

        }

        function GetValueFromWindowOpen(object) {
            if (object.purpose == 'Allhetong2') {
                var hdxiangmuid = document.getElementById('<%= hdxiangmuid.ClientID %>');
                hdxiangmuid.value = object.id;


                document.getElementById("<%=Loadxiangmu.ClientID%>").click();
            }
            if (object.purpose == 'Allfukuanname') {
                var hide1 = document.getElementById('<%=TextBox收款人名称.ClientID %>');
                var hide2 = document.getElementById('<%=TextBox收款人银行账号.ClientID %>');
                var hide3 = document.getElementById('<%=TextBox收款人开户行.ClientID %>');

                hide1.value = object.col1;
                hide2.value = object.col6;
                hide3.value = object.col5;

            }

        }


        function LinkPrintPage() {


            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            var getid11 = document.getElementById("<%=TextBoxshenhe.ClientID%>");

            window.open('/Admin/xiangmu/shenhecaozuo.aspx?txtquanxian=' + txtquanxian + "&&fullname=" + fullname + "&&aaa=" + aaa + "&&tickedFormNo=" + tickedFormNo + "&&getid11=" + getid11,
                                'Window_Query', 'left=' + PosX + ',top=' + PosY + ',height=400,width=1000,scrollbars=yes');

        }

        function btnAddPartDetail() {

            ShowProgressBar();
            document.getElementById("<%=Confirm.ClientID%>").click();
        }

    </script>
    <script type="text/javascript">
        /** 数字金额大写转换(可以处理整数,小数,负数) */
        var digitUppercase = function (n) {
            var fraction = ['角', '分'];
            var digit = [
            '零', '壹', '贰', '叁', '肆',
            '伍', '陆', '柒', '捌', '玖'
        ];
            var unit = [
            ['元', '万', '亿'],
            ['', '拾', '佰', '仟']
        ];

            var head = n < 0 ? '欠' : '';
            n = Math.abs(n);


            var s = '';
            for (var i = 0; i < fraction.length; i++) {
                s += (digit[Math.floor(n * 10 * Math.pow(10, i)) % 10] + fraction[i]).replace(/零./, '');
            }
            s = s || '整';
            n = Math.floor(n);
            for (var i = 0; i < unit[0].length && n > 0; i++) {
                var p = '';
                for (var j = 0; j < unit[1].length && n > 0; j++) {
                    p = digit[n % 10] + unit[1][j] + p;
                    n = Math.floor(n / 10);
                }
                s = p.replace(/(零.)*零$/, '').replace(/^$/, '零') + unit[0][i] + s;
            }
            return head + s.replace(/(零.)*零元/, '元')
            .replace(/(零.)+/g, '零')
            .replace(/^整$/, '零元整');
        };

      
    </script>
    <script type="text/javascript">

        function LinkPrintPage2() {
            var hdidno = $("#<%= hdidno.ClientID %>").val();
            var hdid = $("#<%= hdid.ClientID %>").val();
            var hdRoleValue = $("#<%= hdRoleValue.ClientID %>").val();

            window.open("../xiangmu/print3.aspx?idno=" + hdidno + "&id=" + hdid + "&hdRoleValue=" + hdRoleValue);

        }

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
    <style type="text/css">
        /*--------------------------公共样式------------------*/
        .com-left
        {
            float: left;
        }
        /*公用分割线 宽度自行指定*/
        .com_divhr_solid
        {
            margin: 10px;
            height: 1px;
            border-top: 1px solid #D2CFCA;
            margin-top: 0px;
        }
        /*公用分割线虚线 宽度自行指定*/
        .com_div_dashedhr
        {
            margin: 10px;
            height: 1px;
            border-top: 1px dashed #D2CFCA;
            margin-top: 0px;
        }
        
        .align-center
        {
            margin: 0 auto; /* 居中 这个是必须的，，其它的属性非必须 */
            width: 1024px; /* 给个宽度 顶到浏览器的两边就看不出居中效果了 */
            margin-top: 70px;
            margin-bottom: 10px; /*text-align:center; 文字等内容居中 */
        }
        .nav11
        {
            width: 180px; /* 控制导航总宽度 */
        }
        /* 取消列表样式，内外补间为零 */
        .nav11 ul
        {
            list-style: none;
            margin: 0;
            padding: 0;
        }
        /* 竖排：控制导航高度*/
        .nav11 li
        {
            height: 35px;
            line-height: 35px; /* 文字垂直居中 指定行高为li高度 自动垂直居中 */
        }
        /* 鼠标放上效果 */
        
        .nav11 a:hover
        {
            /*background-color: #007ACC;
            color: #FFFFFF;*/
            cursor: hand;
        }
        
        
        /* 将a标签区块化就可以指定高度 */
        .nav11 a
        {
            display: block;
            height: 100%;
            text-decoration: none; /* 取消a标签下划线 */
            background-color: #fff;
            color: #000;
            text-align: left; /* 文字水平居中显示 */
        }
        .nav11 a span
        {
            text-align: left; /* 文字水平居中显示 */
            margin-left: 20px;
            font-size: 14px;
            font-family: '微软雅黑';
        }
        /*-点击后选中-*/
        li.current a
        {
            background-color: #007ACC;
            color: #FFFFFF;
            cursor: hand;
        }
    </style>
    <script type="text/javascript">
        $(".ulMenu li").hide();
        $("li.ulMenu").hover(function () {
            $(this).find("li").stop(true, true);
            $(this).find("li").slideDown();
        }, function () {
            $(this).find("li").stop(true, true);
            $(this).find("li").slideUp();
        });
        $(function () {
            $("#ulMenu> li").click(function () {
                $("#ulMenu> li.current").attr("class", "")
                $(this).attr("class", "current")
                /*-设置要显示的DIV链接-*/
                // $("div[name='" + div.attr('id') + "']").show();
            });
        });
    </script>
    <asp:TextBox ID="TextBoxshenhe" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:Button ID="Confirm" runat="server" Style="display: none" OnClick="btn提交2_Click" />
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <asp:TextBox ID="TextBoxxiangmuid" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:HiddenField ID="hdidno" runat="server" />
    <asp:HiddenField ID="hdid" runat="server" />
    <asp:HiddenField ID="hdRoleValue" runat="server" />
    <asp:HiddenField ID="hdxiangmuid" runat="server" />
    <asp:Button ID="Loadxiangmu" runat="server" Style="display: none" OnClick="Loadxiangmu_Click" />
    <asp:TextBox ID="txtAmount" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdNo" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdNo2" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hd合同类型" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxbaocunnocol45" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBox审核人" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBox49" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                财务管理&gt;付款管理
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
                            <asp:Label ID="Label6" runat="server" Text="开票申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0063">
                        <a runat="server" id="div0063" href="caiwu3.aspx"><font color="blue">
                            <asp:Label ID="Label7" runat="server" Text="开票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0067">
                        <a runat="server" id="div0067" href="caiwu31.aspx"><font color="blue">
                            <asp:Label ID="Label8" runat="server" Text="税款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0064">
                        <a runat="server" id="div0064" href="caiwu4.aspx"><font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="发票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0065">
                        <a runat="server" id="div0065" href="caiwu5.aspx"><font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="收款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0091">
                        <a runat="server" id="div0091" href="caiwu6.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label12" runat="server" Text="结算申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0092">
                        <a runat="server" id="div0092" href="caiwu6.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label13" runat="server" Text="结算审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0093">
                        <a runat="server" id="div0093" href="caiwu7.aspx"><font color="blue">
                            <asp:Label ID="Label20" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0094">
                        <a runat="server" id="div0094" href="caiwu8.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label21" runat="server" Text="付款申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0095">
                        <a runat="server" id="div0095" href="caiwu8.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label22" runat="server" Text="付款审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0096">
                        <a runat="server" id="div0096" href="caiwu8.aspx?models=3"><font color="blue">
                            <asp:Label ID="Label23" runat="server" Text="付款管理" Font-Size="14px"></asp:Label></font></a></dd>
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
                    width: 1200px; height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px">
                            <asp:Label ID="lbl结算Box2" Text="付款新增管理" runat="server"></asp:Label></font></strong>
                    </h4>
                </div>
                <div class="tab-content" id="div01" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox2" runat="server" class="form-control input-sm" Width="220px"
                                    Text="所属项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="Drop所属项目部" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" AutoPostBack="true"
                                    OnSelectedIndexChanged="Drop所属项目部SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBox5" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <%--<asp:TextBox ID="TextBox项目经理" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>--%>
                                <asp:DropDownList ID="Drop项目经理" TabIndex="14" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox3" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>总包合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox总包合同名称" TabIndex="13" Style="margin-left: 0px" Width="947px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span总包合同名称">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allhetong2','TextBox合同名称', true,'合作合同');">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </button>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox14" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>总包合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox总包合同编号" TabIndex="15" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox24" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>劳务合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox劳务合同名称" TabIndex="13" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off" onfocus="this.blur();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox39" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>劳务单位名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox劳务单位名称" TabIndex="14" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>劳务合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox劳务合同编号" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox7" runat="server" class="form-control input-sm" Width="220px"
                                    Height="52px" Text="<font color='red'>*</font>劳务合同结算依据：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox劳务合同结算依据" TabIndex="13" Style="margin-left: 0px" Width="980px"
                                    Height="52px" Rows="2" TextMode="MultiLine" runat="server" class="form-control input-sm"
                                    autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>收款人名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox收款人名称" TabIndex="23" Style="margin-left: 0px" Width="380px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>收款人银行账号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox收款人银行账号" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>收款人开户行：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox收款人开户行" TabIndex="13" Style="margin-left: 0px" Width="980px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>已经支付金额（小写）：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox已经支付金额小写" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    onblur='NumberCheck5(this);weightCheck1(this);' runat="server" class="form-control input-sm"
                                    autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>已经支付金额（大写）：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox已经支付金额大写" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>本次申请支付发票金额（小写）：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox本次申请支付发票金额小写" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    onblur='NumberCheck5(this);weightCheck2(this);' runat="server" class="form-control input-sm"
                                    autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>本次申请支付发票金额（大写）：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox本次申请支付发票金额大写" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>本次申请支付实际金额（小写）：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox本次申请支付实际金额小写" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    onblur='NumberCheck5(this);weightCheck3(this);' runat="server" class="form-control input-sm"
                                    autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label17" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>本次申请支付实际金额（大写）：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox本次申请支付实际金额大写" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" class="form-control input-sm" Width="220px"
                                    Text="<font color='red'>*</font>本次申请支付发票号码：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox本次申请支付发票号码" TabIndex="13" Style="margin-left: 0px" Width="980px" Height="52px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label19" runat="server" class="form-control input-sm" Width="220px"
                                    Height="52px" Text="<font color='red'>*</font>付款依据：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox付款依据" TabIndex="13" Style="margin-left: 0px" Width="980px"
                                    Height="52px" Rows="3" TextMode="MultiLine" runat="server" class="form-control input-sm"
                                    autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="220px"
                                    Text="申请人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox申请人" TabIndex="29" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox23" runat="server" class="form-control input-sm" Width="220px"
                                    Text="申请日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox申请日期" TabIndex="30" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox35" runat="server" class="form-control input-sm" Width="220px"
                                    Height="66px" Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="39" Style="margin-left: 0px" Width="980px"
                                    TextMode="MultiLine" Rows="3" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                   
                    <div runat="server" id="divGridView1" class="table-responsive" style="width: 1200px;
                        margin-top: 1px;">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                            BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                            ShowFooter="true">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="10px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="10px" />
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="imbAdd" runat="server" CommandName="AddData" OnClientClick="RotateAnimation(this); return ShowProgressBar();"> 
                                <span>+</span> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="imbDelete" runat="server" CommandName="DisableData" OnClientClick="RotateAnimation(this); return ShowProgressBar();"> 
                                <span>-</span> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol12" runat="server" Text='<%# Bind("col12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol14" runat="server" Text='<%# Bind("col14") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl支付序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'
                                            Width="30px" Style="text-align: center;"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算单号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl结算单号" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col12") %>'
                                            Width="130PX" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl项目名称" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col1") %>'
                                            Width="100PX" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目编码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl项目编码" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col2") %>'
                                            Width="100PX" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总包发票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl总包发票金额" runat="server" Style="text-align: center; border: 0;" Text='<%# Bind("col3") %>'
                                            Width="80PX" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总包到账金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl总包到账金额" runat="server" Text='<%# Bind("col4") %>' Width="80PX"
                                            Style="text-align: center; border: 0;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="分包发票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl分包发票金额" runat="server" Text='<%# Bind("col5") %>' Width="80PX"
                                            Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="分包到账金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl分包到账金额" runat="server" Text='<%# Bind("col6") %>' Width="80PX"
                                            Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="劳务单位开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lbl劳务单位开票金额" runat="server" Text='<%# Bind("col7") %>' Width="100PX"
                                                Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已经支付金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl已经支付金额" runat="server" Text='<%# Bind("col8") %>' Width="80PX"
                                            Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="本次申请支付金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl本次申请支付金额" runat="server" Text='<%# Bind("col9") %>' Width="100PX"
                                            Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol37" runat="server" Text='<%# Bind("col10") %>' Width="80px"
                                            Style="text-align: left; border: 0;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                     <table id="shdiv" runat="server" visible="false">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox25" runat="server" class="form-control input-sm" Width="220px"
                                    Height="66px" Text="审批状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px; margin-top: 1px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox审批状态" TabIndex="39" Style="margin-left: 0px; margin-top: 1px;
                                    word-wrap: break-word; height: 66px; word-break: break-all;" Width="980px" TextMode="MultiLine"
                                    Rows="3" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table id="div审批意见" runat="server" visible="false">
                        <tr>
                            <td>
                                <asp:Label ID="lblTextBox1" runat="server" class="form-control input-sm" Width="220px"
                                    Height="66px" Text="<font color='red'>*</font>审批意见：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;
                                    margin-top: 1px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox审批意见" TabIndex="39" Style="margin-left: 0px; margin-top: 1px;
                                    word-wrap: break-word; height: 66px; word-break: break-all;" Width="980px" TextMode="MultiLine"
                                    Rows="3" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblTextBox28" runat="server" class="form-control input-sm" Width="220px"
                                    Height="52px" Text="<font color='red'>*</font>项目实施单位发票附件：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:FileUpload ID="FileUpload1" TabIndex="31" runat="server" Width="380px" Style="margin-left: 1px;" />
                                <asp:Button ID="Button8" runat="server" Text="上传" TabIndex="32" Style="font-size: 12px;
                                    margin-left: 1px;" OnClick="FileUpload项目实施单位发票附件Button_Click" CssClass="btn22"
                                    OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <asp:TextBox ID="TextBox项目实施单位发票附件" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                <a href="" runat="server" id="项目实施单位发票附件href" target="_blank" style="font-size: 12px;"
                                    visible="false"></a>
                                <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" OnClick="btnAttach_Click"
                                    data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                    Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblTextBox36" runat="server" class="form-control input-sm" Width="220px"
                                    Height="52px" Text="<font color='red'>*</font>项目实施单位结算附件：" Font-Bold="true" ReadOnly="true"
                                    Style="text-align: right; background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:FileUpload ID="FileUpload2" runat="server" TabIndex="35" Width="380px" Style="margin-left: 1px;" />
                                <asp:Button ID="Button9" runat="server" Text="上传" TabIndex="36" Style="font-size: 12px;
                                    margin-left: 1px" OnClick="FileUpload付款凭证Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <a href="" runat="server" id="付款凭证href" target="_blank" style="font-size: 12px;"
                                    visible="false"></a>
                                <asp:TextBox ID="TextBox付款凭证" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm" OnClick="btnAttach2_Click"
                                    data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                    Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Div3" runat="server" width="158px" style="width: 100%; height: 180px; overflow: auto;
                                    margin-top: 2px; background-color: RGB(217,237,247);">
                                    <asp:GridView ID="GridView2" runat="server" Font-Size="12px" DefaultType="1" AutoGenerateColumns="False"
                                        BorderWidth="0px" CssClass="table table-bordered " OnRowDataBound="GridView2_RowDataBound"
                                        OnRowCommand="GridView2_RowCommand" ShowHeader="false">
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
                                            <asp:TemplateField HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2" Target="_blank"
                                                        NavigateUrl='<%# Bind("col3") %>' Width="300"></asp:HyperLink>
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
                                <div id="Div2" runat="server" width="178px" style="width: 100%; height: 180px; overflow: auto;
                                    margin-top: 2px; background-color: RGB(217,237,247);">
                                    <asp:GridView ID="GridView3" runat="server" Font-Size="12px" DefaultType="1" AutoGenerateColumns="False"
                                        BorderWidth="0px" CssClass="table table-bordered " OnRowDataBound="GridView3_RowDataBound"
                                        OnRowCommand="GridView3_RowCommand" ShowHeader="false">
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
                                            <asp:TemplateField HeaderStyle-CssClass="text-left">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2" Target="_blank"
                                                        NavigateUrl='<%# Bind("col3") %>' Width="300"></asp:HyperLink>
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
                                <asp:Label ID="Label24" runat="server" class="form-control input-sm" Width="220px"
                                    Visible="false" Text="审核人员：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="DropDownList审核人员" TabIndex="11" Style="margin-left: 0px" Width="380px"
                                    Visible="false" runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-sm-1 col-sm-offset-1" runat="server" id="zancundiv">
                        <asp:Button ID="Button3" runat="server" Text="暂存" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn暂存_Click" />
                    </div>
                    <div class="col-sm-1 " runat="server" id="tijiaodiv">
                        <asp:Button ID="Button7" runat="server" Text="保存" TabIndex="38" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn提交_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1" runat="server" id="shenhe1div" visible="false">
                        <asp:Button ID="Button1" runat="server" Text="审核通过" TabIndex="38" CssClass="btn22"
                            Width="55px" Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn审核通过_Click" />
                    </div>
                    <div class="col-sm-1 " runat="server" id="shenhe2div" visible="false">
                        <asp:Button ID="Button2" runat="server" Text="审核不通过" TabIndex="38" CssClass="btn22"
                            Width="65px" Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn审核不通过_Click" />
                    </div>
                    <div class="col-sm-1 " runat="server" id="backdiv">
                        <asp:Button ID="Button4" runat="server" Text="返回" TabIndex="38" CssClass="btn22"
                            Width="65px" Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn返回_Click" />
                    </div>
                    <div class="col-sm-1 " runat="server" id="printdiv">
                        <div class="noprint" style="text-align: center; margin-bottom: 10px; width: 100%;">
                            <button id="Button6" type="button" class="btn22" style="width: 65px;" onclick="LinkPrintPage2()">
                                打印
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
