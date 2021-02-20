<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="hezuo4Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.hezuo4Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style type="text/css">
    .main_conL222
     {
        float: left;
        width: 220px;
        height:1120px;
        overflow: hidden;
        margin-top: 0px;
     }
     .main_conL222 dl dd {
    width: 220px;
    height: 20px;
    margin-top: 10px;
    margin-left: 20px;
}
.btn22 {
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
  background-color:RGB(60,141,188); 
  border: 1px solid transparent; color: #fff;
  width:35px; text-align:center; height:25px; font-size:12px;
}
.btn11{
   background-color:transparent;         
   border:0px;
   width:35px; text-align:center; height:25px; font-size:12px;
   color: #9933FF;
}
.button {
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

	 function formatAsNum2(mnt) {
            mnt -= 0;
            mnt = (Math.round(mnt * 100000)) / 100000;
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

 function NumberCheck52(iField) {
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


        function QueryByWindowOpen(purpose, identity, preload, limit) {

            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;
            if (purpose == 'Allshigong') {
                limit = "xmb:" + document.getElementById('<%=Drop所属项目部.ClientID %>').value + ',xmjl:' + document.getElementById('<%=Drop项目经理.ClientID %>').value;
            }
            if (purpose == 'Allxiangmu2') {
                limit = "xmb:" + document.getElementById('<%=Drop所属项目部.ClientID %>').value + ',xmjl:' + document.getElementById('<%=Drop项目经理.ClientID %>').value;
            }
            if (purpose == 'Allhetongshi') {
                limit = 'lx:' + document.getElementById(limit).value + ',yh:' + document.getElementById('<%=hd用户.ClientID %>').value
                + ',xmb:' + document.getElementById('<%=Drop所属项目部.ClientID %>').value + ',xmjl:' + document.getElementById('<%=Drop项目经理.ClientID %>').value;

            }

            window.open('/Admin/xiangmu/BASEQ04.aspx?QueryPurpose=' + purpose + '&&QueryIdentity=' + identity + '&&QueryPreload=' + preload + '&&QueryLimit=' + limit,
            "PopupWindow", 'left=' + PosX + ',top=' + PosY + ',height=350,width=800,scrollbars=yes');

        }

        function GetValueFromWindowOpen(object) {
            if (object.purpose == 'Allshigong') {
                
                var TextBox施工队长姓名 = document.getElementById('<%= TextBox施工队长姓名.ClientID %>');
                TextBox施工队长姓名.value = object.col3;
                var TextBox8 = document.getElementById('<%= TextBox8.ClientID %>');
                TextBox8.value = object.id;
                document.getElementById("<%=Loadxiangmu.ClientID%>").click();

            }
            if (object.purpose == 'Allxiangmu2') {
                var TextBox项目名称 = document.getElementById('<%= TextBox项目名称.ClientID %>');
                TextBox项目名称.value = object.col1;
                var TextBox项目编码 = document.getElementById('<%= TextBox项目编码.ClientID %>');
                TextBox项目编码.value = object.col2;

            }
            if (object.purpose == 'Allhetongshi') {
                var TextBox合同名称 = document.getElementById('<%= TextBox合同名称.ClientID %>');
                TextBox合同名称.value = object.col1;
                var TextBox合同编号 = document.getElementById('<%= TextBox合同编号.ClientID %>');
                TextBox合同编号.value = object.col2;
            }
            

        }

        function Replace(obj) {
            return obj.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
        }

        function QtyCheck(object) {
            var gvPartOpen = document.getElementById('<%=GridView1.ClientID%>');
            var amount = 0;
            for (var i = 1; i < gvPartOpen.rows.length - 1; i++) {
                
                var num = Replace(gvPartOpen.rows[i].cells[4].getElementsByTagName("input")[0].value);
                var price = Replace(gvPartOpen.rows[i].cells[6].getElementsByTagName("input")[0].value);
                
                gvPartOpen.rows[i].cells[7].innerText = formatNumberHeader(formatAsNum2(num) * formatAsNum(price));
                amount += formatAsNum2(num) * formatAsNum(price);
            }
            gvPartOpen.rows[gvPartOpen.rows.length - 1].cells[7].innerText = formatNumberHeader(amount);
            document.getElementById("<%=txtAmount.ClientID %>").value = amount;
            
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
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <asp:HiddenField ID="HdCol2附件4" runat="server" />

    <asp:TextBox ID="txtAmount" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBox22" runat="server" class="form-control" Style="display: none"></asp:TextBox>
     <asp:HiddenField ID="hdxiangmuid" runat="server" />
    <asp:Button ID="Loadxiangmu" runat="server" Style="display: none" OnClick="Loadxiangmu_Click" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                合作管理&gt;施工队单项工程结算明细
                <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        
        <div class="main_con">
            <div class="main_conL222" style="width: 12%;background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0051">
                        <a runat="server" id="div0051" href="hezuo1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="合作单位管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0052">
                        <a runat="server" id="div0052" href="hezuo2.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="施工队伍管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0053">
                        <a runat="server" id="div0053" href="hezuo3.aspx"><font color="blue">
                            <asp:Label ID="Label3" runat="server" Text="施工队结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0054">
                        <a runat="server" id="div0054" href="hezuo4.aspx"><font color="blue">
                            <asp:Label ID="Label4" runat="server" Text="施工队结算明细" Font-Size="14px"></asp:Label></font></a></dd>
                     <dd runat="server" id="dd0055">
                        <a runat="server" id="div0055" href="hezuo5.aspx"><font color="blue">
                            <asp:Label ID="Label42" runat="server" Text="施工队项目明细" Font-Size="14px"></asp:Label></font></a></dd>
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
                        <strong><font color="blue" size="2px" >施工队单项工程结算明细</font></strong>
                    </h4>
                </div>
               
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:Dropdownlist ID="Drop所属项目部" TabIndex="13" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" AutoPostBack="true" OnSelectedIndexChanged="Drop所属项目部SelectedIndexChanged"></asp:Dropdownlist>
                                <%--<asp:TextBox ID="TextBox项目部" TabIndex="13" Style="margin-left: 0px" Width="380px" onfocus="this.blur();"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>--%>
                            </td>
                            <td>
                                 <asp:Label ID="lblBox25" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:Dropdownlist ID="Drop项目经理" TabIndex="14" Style="margin-left: 0px" Width="380px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:Dropdownlist>
                                <%--<asp:TextBox ID="TextBox项目经理" TabIndex="12" Style="margin-left: 0px" Width="380px" onfocus="this.blur();"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox18" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>施工队长姓名：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox施工队长姓名" TabIndex="19" Style="margin-left: 0px" Width="347px"
                                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span施工队长姓名">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allshigong','TextBox施工队长姓名', true,'');">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </button>
                                    </span>
                                </div>
                                
                            </td>
                            <td>
                                 <asp:Label ID="lblBox26" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>施工年份：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox施工年份" TabIndex="14" Style="margin-left: 0px" Width="380px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年'})" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabTextBox3" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <div class="input-group" >
                                    <asp:TextBox ID="TextBox合同名称" TabIndex="19" Style="margin-left: 0px" Width="917px"
                                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span1">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allhetongshi','TextBox合同名称', true,'<%=hd合同类型.ClientID %>');">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </button>
                                    </span>
                                </div>
                               
                            </td>
                             
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabTextBox5" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox合同编号" TabIndex="11" Style="margin-left: 0px" Width="950px" onfocus="this.blur();" 
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                       
                            </td>
                             
                        </tr>
                        
                        <tr>
                             <td>
                                <asp:Label ID="lblBox27" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                             </td>
                             <td colspan="3">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox项目名称" TabIndex="19" Style="margin-left: 0px" Width="917px"
                                        onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <span class="input-group-btn" runat="server" id="span项目名称">
                                        <button type="button" class="btn btn-default btn-sm" onclick="QueryByWindowOpen('Allxiangmu2','TextBox项目名称', true,'');">
                                            <span class="glyphicon glyphicon-search" aria-hidden="true" align="left"></span>
                                        </button>
                                    </span>
                                </div>
                             </td>
                        </tr>
                        <tr>
                             <td>
                                <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="190px"
                                        Text="<font color='red'>*</font>项目编码：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                             </td>
                             <td colspan="3">
                                <asp:TextBox ID="TextBox项目编码" TabIndex="16" Style="margin-left: 0px" Width="950px" onfocus="this.blur();" 
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox45" runat="server" class="form-control input-sm" Width="190px"
                                        Text="单项工程名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox单项工程名称" TabIndex="11" Style="margin-left: 0px" Width="950px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                       
                            </td>
                             
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control input-sm" Width="190px"
                                        Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox备注" TabIndex="11" Style="margin-left: 0px" Width="950px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                       
                            </td>
                             
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox2" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建人" TabIndex="11" Style="margin-left: 0px" Width="380px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox5" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建日期" TabIndex="12" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        
                    </table>
                    <div class="table-responsive" style="width: 1140px">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" HeaderStyle-Height="15px"
                            Height="15px" RowStyle-Height="15px" AutoGenerateColumns="False" BorderWidth="0px"
                            CssClass="table table-bordered table-hover table-condensed" AllowSorting="True"
                            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" ShowFooter="true">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="15px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="15px" />
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
                               
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Font-Size="12px"
                                            Width="30px" Style="text-align: center;"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID2" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol11" runat="server" Text='<%# Bind("col11") %>' Font-Size="15px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="施工结算项目" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    >
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtcol12" runat="server" class="form-control " Style="text-align: left; border: 0; height:15px;  font-size:12px; margin-top:-2px" Text='<%# Bind("col12") %>'
                                             autocomplete="off"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="数量"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:TextBox ID="txtcol13" runat="server" class="form-control" Style="text-align: center; border: 0;height:15px; font-size:12px; margin-top:-2px " Text='<%# Bind("col13") %>' onblur='NumberCheck52(this);QtyCheck(this);'  autocomplete="off" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtcol14" runat="server" class="form-control " Style="text-align: center; border: 0; height:15px;font-size:12px; margin-top:-2px" Text='<%# Bind("col14") %>' 
                                             autocomplete="off"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单价（元）"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:TextBox ID="txtcol15" runat="server" class="form-control " Style="text-align:center;  border: 0;height:15px; font-size:12px; margin-top:-2px"  Text='<%# Bind("col15") %>' onblur='NumberCheck5(this);QtyCheck(this);'  autocomplete="off" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="小计（元）" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lblcol16" runat="server" Text='<%# Bind("col16") %>' Width="200px" Font-Size="12px"
                                                Style="text-align: center; border: 0;" autocomplete="off"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox28" runat="server" class="form-control input-sm" Width="190px"
                                    Height="52px" Text="单项工程结算电子档附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td style=" width:380px" >
                                <asp:FileUpload ID="FileUpload1" TabIndex="31" runat="server" Width="280px" Style="margin-left: 1px;" />
                                <asp:Button ID="Button8" runat="server" Text="上传" TabIndex="32"  Style="font-size: 12px;
                                    margin-left: 1px;" OnClick="FileUpload施工队单项工程结算电子档附件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                <asp:TextBox ID="TextBox施工队单项工程结算电子档附件" runat="server" class="form-control" Width="280px"  Style="display: none"></asp:TextBox>
                                <a href="" runat="server" id="施工队单项工程结算电子档附件href" target="_blank" style="font-size:12px;" Visible="false"></a>
                                <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox36" runat="server" class="form-control input-sm" Width="190px"
                                    Height="52px" Text="单项工程结算签字扫描附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td  style=" width:380px" >
                                <asp:FileUpload ID="FileUpload2" runat="server" TabIndex="35" Width="280px" Style="margin-left: 1px;" />
                                <asp:Button ID="Button9" runat="server" Text="上传" TabIndex="36"  Style="font-size: 12px;
                                    margin-left: 1px" OnClick="FileUpload施工队单项工程结算签字扫描附件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                <a href="" runat="server" id="施工队单项工程结算签字扫描附件href" target="_blank" style="font-size:12px;" Visible="false"></a>
                                <asp:TextBox ID="TextBox施工队单项工程结算签字扫描附件" runat="server" class="form-control input-sm" Width="280px"  Style="display: none"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach2_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                           
                            <td colspan="2">
                                <div id="Div2" runat="server" width="570px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px;background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView2" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView2_RowDataBound"  
                                OnRowCommand="GridView3_RowCommand" ShowHeader="false" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
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
                                <div id="Div3" runat="server" width="570px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px;margin-left:0px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView3" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>'  NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
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
                            
                        </tr>

                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="190px"
                                    Height="52px" Text="施工队合同扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;margin-top: 2px;"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:FileUpload ID="FileUpload3" TabIndex="31" runat="server" Width="280px" Style="margin-left: 1px;" />
                                <asp:Button ID="Button1" runat="server" Text="上传" TabIndex="32" Style="font-size: 12px;
                                    margin-left: 1px;" OnClick="FileUpload施工队合同扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                <asp:TextBox ID="TextBox施工队合同扫描件" runat="server" class="form-control" Width="280px"  Style="display: none"></asp:TextBox>
                                <a href="" runat="server" id="施工队合同扫描件href" target="_blank" style="font-size:12px;" Visible="false"></a>
                                <asp:LinkButton ID="LinkButton2" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach3_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            
                        </tr> 
                        <tr>
                           
                            <td colspan="2">
                                <div id="Div4" runat="server" width="570px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px;background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView4" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="1px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView4_RowDataBound" 
                                OnRowCommand="GridView4_RowCommand" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank"  ></asp:HyperLink>
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
                            <td colspan="2">
                                <div id="Div1" runat="server" width="570px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px;background-color: RGB(217,237,247);" >
                                </div>
                            </td>
                            </tr>
                    </table>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-sm-1 ">
                        <asp:Button ID="btnDownloadTemplate" runat="server" Text="下载模板" CssClass="btn btn-link" onclick="btnDownloadTemplate_Click" CausesValidation="false"></asp:Button>
                    </div>
                    <div class="col-sm-1 ">
                        <div class="btn btn-default btn-file" runat="server" id="divUpload">
                            <i class="fa fa-upload"></i>选择导入文件
                            <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                        </div>
                    </div>
                    <div class="col-sm-1 col-sm-offset-1 ">
                        <asp:Button ID="Button2" runat="server" Text="导入" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn导入_Click" />
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button4" runat="server" Text="导出" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn导出_Click" />
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button3" runat="server" Text="保存" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn保存_Click" />
                    </div>
                    <div class="col-sm-1 ">
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

