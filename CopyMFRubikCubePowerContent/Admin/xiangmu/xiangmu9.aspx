<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="xiangmu9.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.xiangmu9" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style type="text/css">
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
        .btn111
        {
           background-color: RGB(72,185,229);
            border: 0px;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 14px;
            color: White;
        }
         .btn11
        {
            background-color: Window;
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
        .td2
        {
            white-space: nowrap; /*控制单行显示*/
            overflow: hidden; /*超出隐藏*/
            text-overflow: ellipsis; /*隐藏的字符用省略号表示*/
        }
    </style>
    <style type="text/css">
        .contentwrap
        {
             width: 100%;
            margin-left:0px;
            margin-bottom:-25px;
            margin-top:5px;
        }
        ul
        {
            list-style: none;
            margin: 0;
            padding-left: 0px;
            background-color: RGB(72,185,229);
        }
        ul.tab
        {
            border-bottom: 1px solid #ccc;
            padding-bottom: 1px;
            height: 25px;
            line-height: 20px;
            color: #696969;
        }
        ul.tab li
        {
            float: left;
            font-family: "微软雅黑";
            cursor: pointer;
            padding: 0px;width:170px;
        }
        ul.tab li.li
        {
            padding: 0px 0px 0px 36px;
            font-size: 14px;
            height: 25px;
            line-height: 23px;
            background: RGB(199,230,248);
            border-top: 1px solid #C5D0DC;
            border-left: 1px solid #C5D0DC;
            border-bottom: 1px solid #C5D0DC;
        }
        ul.tab li.current
        {
            border-bottom: 0px;
            border-top: 1px solid #7599DE;
            font-size: 13px;
            color: #343434;
            background: RGB(72,185,229);
        }
        ul.tab li.li:last-child
        {
            border-right: 1px solid #C5D0DC;
        }
        .divsshow
        {
            display: block;
        }
        .divsshowno
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function toli1() {
            document.getElementById("li1").className = "li current";
            document.getElementById("li2").className = "li";
            document.getElementById("li3").className = "li";
            document.getElementById("li4").className = "li";
            document.getElementById("li5").className = "li";

            document.getElementById("div11").className = "divsshow";
            document.getElementById("div12").className = "divsshowno";
            document.getElementById("div13").className = "divsshowno";
            document.getElementById("div14").className = "divsshowno";
            document.getElementById("div15").className = "divsshowno";

            document.getElementById('<%=lblbiaoti1.ClientID %>').value = "发票资料未上传明细列表";
        }

        function toli2() {
            document.getElementById("li1").className = "li";
            document.getElementById("li2").className = "li current";
            document.getElementById("li3").className = "li";
            document.getElementById("li4").className = "li";
            document.getElementById("li5").className = "li";

            document.getElementById("div11").className = "divsshowno";
            document.getElementById("div12").className = "divsshow";
            document.getElementById("div13").className = "divsshowno";
            document.getElementById("div14").className = "divsshowno";
            document.getElementById("div15").className = "divsshowno";
            document.getElementById('<%=lblbiaoti1.ClientID %>').value = "采购订单资料已上传明细列表";
        }
        function toli3() {
            document.getElementById("li1").className = "li";
            document.getElementById("li2").className = "li";
            document.getElementById("li3").className = "li current";
            document.getElementById("li4").className = "li";
            document.getElementById("li5").className = "li";

            document.getElementById("div11").className = "divsshowno";
            document.getElementById("div12").className = "divsshowno";
            document.getElementById("div13").className = "divsshow";
            document.getElementById("div14").className = "divsshowno";
            document.getElementById("div15").className = "divsshowno";
            document.getElementById('<%=lblbiaoti1.ClientID %>').value = "结算资料已上传明细列表";
        }
        function toli4() {
            document.getElementById("li1").className = "li";
            document.getElementById("li2").className = "li";
            document.getElementById("li3").className = "li";
            document.getElementById("li4").className = "li current";
            document.getElementById("li5").className = "li";

            document.getElementById("div11").className = "divsshowno";
            document.getElementById("div12").className = "divsshowno";
            document.getElementById("div13").className = "divsshowno";
            document.getElementById("div14").className = "divsshow";
            document.getElementById("div15").className = "divsshowno";
            document.getElementById('<%=lblbiaoti1.ClientID %>').value = "审计资料已上传明细列表";
        }
        function toli5() {
            document.getElementById("li1").className = "li";
            document.getElementById("li2").className = "li";
            document.getElementById("li3").className = "li";
            document.getElementById("li4").className = "li";
            document.getElementById("li5").className = "li current";

            document.getElementById("div11").className = "divsshowno";
            document.getElementById("div12").className = "divsshowno";
            document.getElementById("div13").className = "divsshowno";
            document.getElementById("div14").className = "divsshowno";
            document.getElementById("div15").className = "divsshow";
            document.getElementById('<%=lblbiaoti1.ClientID %>').value = "竣工资料已上传明细列表";
        }

    </script>
    <script type="text/javascript">
        //全选功能
        function SelectAllCheckboxes(spanChk) {

            elm = document.forms[0];
            for (i = 0; i <= elm.length - 1; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                    if (elm.elements[i].checked != spanChk.checked)
                        elm.elements[i].click();
                }
            }
        }
        function cleanForm() {

            document.getElementById("<%=txtcol1.ClientID%>").value = "";
            document.getElementById("<%=txtcol2.ClientID %>").value = "";
            document.getElementById("<%=txtcol3.ClientID %>").value = "";
            document.getElementById("<%=txtcol4.ClientID %>").value = "";
            document.getElementById("<%=txtcol5.ClientID %>").value = "";
            document.getElementById("<%=txtcol6.ClientID %>").value = "";
            return false;
        }

        function LinkPrintPage() {


            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            window.open('/Admin/xiangmu/shenhecaozuo.aspx?txtquanxian=' + txtquanxian + "&&fullname=" + fullname + "&&aaa=" + aaa + "&&tickedFormNo=" + tickedFormNo,
                                'Window_Query', 'left=' + PosX + ',top=' + PosY + ',height=400,width=1000,scrollbars=yes');

        }
    </script>
    <asp:TextBox ID="hdcase" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdtemp" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                项目管理&gt;项目资料管理 <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        <div class="main_con">
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
            <div class="col-sm-10" style="width: 88%; height: 700px;">
            <div id="AlertDiv" runat="server">
                    </div>
                <div class="panel panel-default" style="width: 100%; height: 65px;
                    margin-top: -7px;">
                    <div>
                        <div id="contentwrap" class="contentwrap">
                        <ul class="tab">
                            <li id="li1" class="li current" onclick="toli1()"><span >发票资料管理</span></li>
                            <li id="li2" class="li" onclick="toli2()" ><span >采购订单资料管理</span></li>
                            <li id="li3" class="li" onclick="toli3()"><span >结算资料管理</span></li>
                            <li id="li4" class="li" onclick="toli4()"><span >审计资料管理</span></li>
                            <li id="li5" class="li" onclick="toli5()"><span >竣工资料管理</span></li>
                        </ul>
                        <div class="row" style="background-color:RGB(199,230,248); height:26px; width:100%; margin-left:0px;" >
                            <div id="div11" >
                                <div class="panel-heading" style="text-align: left; margin-top: -10px; margin-bottom: 0px;
                                    height: 25px; font-size: 10px;">
                                    <asp:Button ID="Button7" runat="server" Text="发票资料未上传明细" CssClass="btn111" Width="171px" style=" border-right:1px solid #fff; margin-left:-15px;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn11_Click" />
                                    <asp:Button ID="Button8" runat="server" Text="发票资料已上传明细" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid #fff; "
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn12_Click" />
                                    <asp:Button ID="Button9" runat="server" Text="发票资料审核管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid #fff;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn13_Click" />
                                    <asp:Button ID="Button10" runat="server" Text="发票资料完成管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid #fff;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn14_Click" />
                                </div>
                            </div>
                            <div id="div12">
                                <div class="panel-heading" style="text-align: left; margin-top: -10px; margin-bottom: 0px;
                                    height: 25px; font-size: 10px;">
                                    <asp:Button ID="Button11" runat="server" Text="采购订单资料未上传明细" CssClass="btn111" Width="171px" style=" border-right:1px solid #fff; margin-left:-15px;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn21_Click" />
                                    <asp:Button ID="Button12" runat="server" Text="采购订单资料已上传明细" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn22_Click" />
                                    <asp:Button ID="Button13" runat="server" Text="采购订单资料审核管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn23_Click" />
                                    <asp:Button ID="Button14" runat="server" Text="采购订单资料完成管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn24_Click" />
                                </div>
                            </div>
                            <div id="div13" >
                                <div class="panel-heading" style="text-align: left; margin-top: -10px; margin-bottom: 0px;
                                    height: 25px; font-size: 10px;">
                                    <asp:Button ID="Button15" runat="server" Text="结算资料未上传明细" CssClass="btn111" Width="171px" style=" border-right:1px solid #fff; margin-left:-15px;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn31_Click" />
                                    <asp:Button ID="Button16" runat="server" Text="结算资料已上传明细" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn32_Click" />
                                    <asp:Button ID="Button17" runat="server" Text="结算资料审核管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn33_Click" />
                                    <asp:Button ID="Button18" runat="server" Text="结算资料完成管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn34_Click" />
                                </div>
                            </div>
                            <div id="div14">
                                <div class="panel-heading" style="text-align: left; margin-top: -10px; margin-bottom: 0px;
                                    height: 25px; font-size: 10px;">
                                    <asp:Button ID="Button19" runat="server" Text="审计资料未上传明细" CssClass="btn111" Width="171px" style=" border-right:1px solid #fff; margin-left:-15px;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn41_Click" />
                                    <asp:Button ID="Button20" runat="server" Text="审计资料已上传明细" CssClass="btn111" Width="170px" style=" margin-left:-3px; border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn42_Click" />
                                    <asp:Button ID="Button21" runat="server" Text="审计资料审核管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn43_Click" />
                                    <asp:Button ID="Button22" runat="server" Text="审计资料完成管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn44_Click" />
                                </div>
                            </div>
                            <div id="div15" >
                                <div class="panel-heading" style="text-align: left; margin-top: -10px; margin-bottom: 0px;
                                    height: 25px; font-size: 10px;">
                                    <asp:Button ID="Button23" runat="server" Text="竣工资料未上传明细" CssClass="btn111" Width="171px" style=" border-right:1px solid #fff; margin-left:-15px;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn51_Click" />
                                    <asp:Button ID="Button24" runat="server" Text="竣工资料已上传明细" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn52_Click" />
                                    <asp:Button ID="Button25" runat="server" Text="竣工资料审核管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid ;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn53_Click" />
                                    <asp:Button ID="Button26" runat="server" Text="竣工资料完成管理" CssClass="btn111" Width="170px" style=" margin-left:-3px;border-right:1px solid;"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn54_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                    
                </div>
                <div class="panel-heading" style="text-align: center; margin-top: -20px; margin-bottom: 0px;
                    height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px" font-weight="bold">
                            <asp:Label runat="server" ID="lblbiaoti1" Text="发票资料未上传明细列表"></asp:Label></font></strong>
                    </h4>
                </div>
                <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; width: 100%;">
                    <div class="panel-heading" style="text-align: right; margin-top: 0px; height: 25px;"
                        data-toggle="collapse" data-target="#SearchArea">
                        <h5 style="text-align: right; margin-top: -5px; font-size: 12px">
                            高级检索</h5>
                    </div>
                    <div id="SearchArea" class="collapse">
                        <div class="panel-body" style="margin: -10px auto; font-size: 12px;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="120px"
                                            Text="建设单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol1" TabIndex="11" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="120px"
                                            Text="施工单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtcol2" TabIndex="12" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="120px"
                                            Text="合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol3" TabIndex="11" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="120px"
                                            Text="项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtcol4" TabIndex="12" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="120px"
                                            Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol5" TabIndex="13" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" Width="120px"
                                            Text="项目编码：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol6" TabIndex="13" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="120px"
                                            Text="发票类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol7" TabIndex="13" Style="margin-left: 0px" Width="430px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" Width="120px"
                                            Text="项目状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="Dropcol8" TabIndex="13" Style="margin-left: 0px" Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>正常</asp:ListItem>
                                            <asp:ListItem>关闭</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <div class="row" style="margin: 5px auto; font-size: 9px; width: 100%; height: 50%;">
                                <div class="col-sm-1 col-sm-offset-5">
                                    <asp:Button ID="Button2" runat="server" Text="查询" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                        OnClick="btn查询_Click" />
                                </div>
                                <div class="col-sm-1 ">
                                    <asp:Button ID="Button6" runat="server" Text="清空" CssClass="btn22" Style="margin-left: 30px"
                                        OnClientClick="return cleanForm()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; height:40px;  width: 100%;">
                    <div class="col-sm-1" runat="server" id="div资料上传">
                        <asp:Button ID="Button1" runat="server" Text="资料上传" CssClass="btn11" Width="70px"
                             OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn资料上传_Click" />
                    </div>
                     <div class="col-sm-1" runat="server" id="div资料重提">
                        <asp:Button ID="Button27" runat="server" Text="资料重提" CssClass="btn11" Width="60px" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn资料重提_Click" />
                    </div>
                      <div class="col-sm-1" runat="server" id="div审核">
                        <asp:Button ID="Button28" runat="server" Text="审核" CssClass="btn11" Width="60px" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn审核_Click" />
                    </div>
                    <div class="col-sm-1" runat="server" id="div查看">
                        <asp:Button ID="Button3" runat="server" Text="查看" CssClass="btn11" Width="60px" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn查看_Click" />
                    </div>
                    <div class="col-sm-1" runat="server" id="div资料退回" Visible="false">
                        <asp:Button ID="btn资料退回" runat="server" Text="资料退回" CssClass="btn11" Width="60px" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn资料退回_Click" />
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button4" runat="server" Text="导出" CssClass="btn11" OnClick="btnExport_Click" />
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button5" runat="server" Text="删除" CssClass="btn11" Visible="false"
                            OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn查看_Click" />
                    </div>
                    <div class="col-sm-6 col-sm-offset-2">
                        <asp:Label ID="Label合计1" TabIndex="13" Width="260px" Style="margin-left: 0px; border: 0;
                            font-size: 12px; color: red" runat="server" class="form-control input-sm" autocomplete="off"></asp:Label>
                        <asp:Label ID="Label合计2" TabIndex="13" Width="260px" Style="margin-left: 0px; border: 0;
                            font-size: 12px; color: red" runat="server" class="form-control input-sm" autocomplete="off"></asp:Label>
                    </div>
                </div>
                <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 0px;">
                    <div class="table-responsive" style="width: 100%">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            Height="10px" AutoGenerateColumns="False" BorderWidth="0px" CssClass="table table-bordered "
                            AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound"
                            OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="勾选" HeaderStyle-CssClass="text-center">
                                    <ItemStyle VerticalAlign="Middle"></ItemStyle>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);"
                                            Style="margin: 0 20%" data-toggle="tooltip" data-placement="center"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" Width="30px" Style="text-align: center;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="30px"
                                            Height="20px" Style="text-align: center;"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>' Width="130px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同编号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>' Width="130px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col3") %>' Width="120px" Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="建设单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>' Width="180px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="施工单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>' Width="150px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目部" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>' Width="130px" Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目经理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col7") %>' Width="100px" Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=''></asp:HyperLink>
                                        <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>' Width="120px" Visible="false"
                                            Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目编码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col9") %>' Width="120px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单项工程名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol10" runat="server" Text='<%# Bind("col10") %>' CssClass="td2"
                                            Width="300px" ToolTip='<%# Bind("col10") %>' Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算类型" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol31" runat="server" Text='<%# Bind("col31") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol34" runat="server" Text='<%# Bind("col11") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol35" runat="server" Text='<%# Bind("col12") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol341" runat="server" Text='<%# Bind("col13") %>' Width="100px"
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
                                        <asp:Label ID="lblcol342" runat="server" Text='<%# Bind("col15") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol352" runat="server" Text='<%# Bind("col16") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol343" runat="server" Text='<%# Bind("col17") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审定金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol353" runat="server" Text='<%# Bind("col18") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票不含税金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl开票不含税金额" runat="server" Width="130px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票含税金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl开票含税金额" runat="server" Width="130px" Style="text-align: center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票扫描件" HeaderStyle-CssClass="text-center" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk发票扫描件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                        <asp:HyperLink ID="HyperLinkcol26" runat="server" NavigateUrl='<%# Eval("col22") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:LinkButton ID="lbtn1" runat="server" Text="下载" Width="120px" CommandName="lbtn11">
                                        </asp:LinkButton>
                                        <asp:Label ID="lbl发票扫描件" Visible="false" runat="server" Text='<%# Bind("col22") %>'></asp:Label>
                                        <asp:Label ID="Label发票扫描件" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="采购订单扫描件" HeaderStyle-CssClass="text-center" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk采购订单扫描件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                        <asp:LinkButton ID="lbtn2" runat="server" Text="下载" Width="120px" CommandName="lbtn12">
                                        </asp:LinkButton>
                                        <asp:HyperLink ID="HyperLinkcol27" runat="server" NavigateUrl='<%# Eval("col23") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:Label ID="lbl采购订单扫描件" Visible="false" runat="server" Text='<%# Bind("col23") %>'></asp:Label>
                                        <asp:Label ID="Label采购订单扫描件" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="完工结算证明扫描件" HeaderStyle-CssClass="text-center" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk完工结算证明扫描件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                        <asp:LinkButton ID="lbtn3" runat="server" Text="下载" Width="120px" CommandName="lbtn13">
                                        </asp:LinkButton>
                                        <asp:HyperLink ID="HyperLinkcol28" runat="server" NavigateUrl='<%# Eval("col24") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:Label ID="lbl完工结算证明扫描件" Visible="false" runat="server" Text='<%# Bind("col24") %>'></asp:Label>
                                        <asp:Label ID="Label完工结算证明扫描件" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审计定案扫描件" HeaderStyle-CssClass="text-center" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk审计定案扫描件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                        <asp:LinkButton ID="lbtn4" runat="server" Text="下载" Width="120px" CommandName="lbtn14">
                                        </asp:LinkButton>
                                        <asp:HyperLink ID="HyperLinkcol29" runat="server" NavigateUrl='<%# Eval("col25") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:Label ID="lbl审计定案扫描件" Visible="false" runat="server" Text='<%# Bind("col25") %>'></asp:Label>
                                        <asp:Label ID="Label审计定案扫描件" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="竣工资料及图纸附件" HeaderStyle-CssClass="text-center" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk竣工资料及图纸附件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                        <asp:LinkButton ID="lbtn5" runat="server" Text="下载" Width="120px" CommandName="lbtn15">
                                        </asp:LinkButton>
                                        <asp:HyperLink ID="HyperLinkcol30" runat="server" NavigateUrl='<%# Eval("col26") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:Label ID="lbl竣工资料及图纸附件" Visible="false" runat="server" Text='<%# Bind("col26") %>'></asp:Label>
                                        <asp:Label ID="Label竣工资料及图纸附件" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol15" runat="server" Text='<%# Bind("col21") %>' Width="150px"
                                            Style="text-align: left;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div id="pager">
                            <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>

                
            </div>
        </div>
        <!--#endeditable-->
    </div>
   
</asp:Content>
