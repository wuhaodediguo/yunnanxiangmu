<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="hetong3Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.hetong3Add" %>

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

     <asp:HiddenField ID="HdCol2附件1" runat="server" />
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <asp:TextBox ID="hdNo" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdNo2" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="hdNo3" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxbaocunnocol53" runat="server" class="form-control" Style="display: none"></asp:TextBox>

    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                合同管理&gt;采购合同管理
            </div>
        </div>
        <div class="main_con" style="font-size: 10px;">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230); font-size: 14px;">
                <dl style="width:120px; height:100%;">
                        <dd runat="server" id="dd0031">
                            <a runat="server" id="div0031" href="hetong1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="施工合同管理" Font-Size="14px"></asp:Label></font></a></dd>
                        <dd runat="server" id="dd0032">
                            <a runat="server" id="div0032" href="hetong2.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="合作合同管理" Font-Size="14px"></asp:Label></font></a></dd>
                        <dd runat="server" id="dd0033">
                            <a runat="server" id="div0033" href="hetong3.aspx"><font color="blue">
                            <asp:Label ID="Label2" runat="server" Text="采购合同管理" Font-Size="14px"></asp:Label></font></a></dd>
                        <dd runat="server" id="dd0034">
                            <a runat="server" id="div0034" href="hetong4.aspx"><font color="blue">
                                <asp:Label ID="Label3" runat="server" Text="合同综合信息" Font-Size="14px"></asp:Label></font></a></dd>
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
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px; width:1120px;
                    height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                    <h4 class="panel-title">
                        <strong><font color="blue" size="2px" >采购合同新增管理</font></strong>
                    </h4>
                </div>
                
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox16" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>采购合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txt采购合同名称" TabIndex="11" Style="margin-left: 0px" Width="960px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                             
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>采购合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox采购合同编号" TabIndex="12" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                 <asp:Label ID="lblBox25" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>采购合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox采购合同金额" TabIndex="15" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox18" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>供货单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox供货单位" TabIndex="12" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                 <asp:Label ID="lblBox26" runat="server" class="form-control input-sm" Width="160px"
                                        Text="订货单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox订货单位" TabIndex="15" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <asp:Label ID="lblBox27" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>采购合同发票类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                             </td>
                             <td colspan="2">
                                <asp:DropDownList ID="DropDown采购合同发票类型" TabIndex="13" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem>增值税普通发票</asp:ListItem>
                                    <asp:ListItem>增值税专用发票</asp:ListItem>
                                    <asp:ListItem>不开具发票</asp:ListItem>
                                </asp:DropDownList>
                               <%-- <asp:TextBox ID="TextBox采购合同发票类型" TabIndex="13" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>--%>
                             </td>
                             <td>
                                <asp:TextBox ID="TextBox29" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                             </td>
                             <td colspan="2">
                                <asp:TextBox ID="TextBox采购合同税率" TabIndex="14" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                             </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblBox32" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>采购合同类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                             </td>
                             <td colspan="2">
                                <asp:DropDownList ID="DropDown采购合同类别" TabIndex="13" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem>材料（设备）采购合同</asp:ListItem>
                                    <asp:ListItem>仪器仪表采购合同</asp:ListItem>
                                    <asp:ListItem>安全生产用品采购合同</asp:ListItem>
                                    <asp:ListItem>技术服务采购合同</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="TextBox采购合同类别" TabIndex="14" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>--%>
                             </td>
                            <td>
                                <asp:TextBox ID="TextBox34" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox采购日期" TabIndex="11" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})" ></asp:TextBox>
                            </td>
                             
                        </tr>
                        <tr>
                             <td>
                                <asp:TextBox ID="TextBox35" runat="server" class="form-control input-sm" Width="160px"
                                        Text="供货单位联系人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                             </td>
                             <td colspan="2">
                                <asp:TextBox ID="TextBox供货单位联系人" TabIndex="13" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                             </td>
                              <td>
                                <asp:TextBox ID="TextBox36" runat="server" class="form-control input-sm" Width="160px"
                                        Text="供货单位联系电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox供货单位联系电话" TabIndex="11" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                             <td>
                                <asp:Label ID="lblBox41" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                             </td>
                             <td colspan="2">
                                <asp:TextBox ID="TextBox创建人" TabIndex="13" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                             </td>
                             <td>
                                <asp:Label ID="lblBox43" runat="server" class="form-control input-sm" Width="160px"
                                        Text="<font color='red'>*</font>创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:Label>
                             </td>
                             <td colspan="2">
                                <asp:TextBox ID="TextBox创建日期" TabIndex="14" Style="margin-left: 0px" Width="400px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                             </td>
                        </tr>
                         
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox45" runat="server" class="form-control input-sm" Width="160px"
                                        Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="11" Style="margin-left: 0px" Width="960px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                        <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    
                            </td>
                             
                        </tr>
                         <tr>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="160px"
                                    Height="52px" Text="电子版合同：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                               <asp:FileUpload ID="FileUpload1" TabIndex="31" runat="server" />
                                    <asp:Button ID="Button4" runat="server" Text="上传" TabIndex="32" Style="font-size: 12px"
                                        OnClick="FileUpload电子版合同Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                    <asp:TextBox ID="TextBox电子版合同" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="电子版合同href" target="_blank" style="font-size:12px;" Visible="false">电子版合同</a>
                                    <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="160px"
                                    Height="52px" Text="合同扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload2" TabIndex="33" Width="160px" runat="server" />
                                    <asp:Button ID="Button5" runat="server" Text="上传"  TabIndex="34" Style="font-size: 12px"
                                        OnClick="FileUpload合同扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                    <asp:TextBox ID="TextBox合同扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="合同扫描件href" target="_blank" style="font-size:12px;" Visible="false">合同扫描件</a>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach2_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server" class="form-control input-sm" Width="160px"
                                    Height="52px" Text="合同其他附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                    background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server" TabIndex="35" Style="margin-left: 0px" />
                                    <asp:Button ID="Button6" runat="server" Text="上传" TabIndex="36" Style="font-size: 12px;
                                        margin-left: 0px" OnClick="FileUpload合同其他附件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"/>
                                    <a href="" runat="server" id="合同其他附件href" target="_blank" style="font-size:12px;" Visible="false">合同其他附件</a>
                                    <asp:TextBox ID="TextBox合同其他附件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach3_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                        </tr>

                        <tr>
                            
                           <td colspan="2">
                                <div id="Div2" runat="server" width="158px"  style="width: 100%; height:200px; overflow: auto;  margin-top: 2px; background-color: RGB(217,237,247);" >
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="260" Target="_blank"></asp:HyperLink>
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
                                <div id="Div3" runat="server" width="158px"  style="width: 100%; height:200px; overflow: auto;  margin-top: 2px; background-color: RGB(217,237,247);" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2" NavigateUrl='<%# Bind("col3") %>' Width="260" Target="_blank" ></asp:HyperLink>
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
                                <div id="Div1" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto;  margin-top: 2px; background-color: RGB(217,237,247);" >
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="260" Target="_blank"></asp:HyperLink>
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
                             <td></td>
                        </tr>
                    </table>
                    
                </div>
                <div class="table-responsive" style="width: 1120px">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="9px" HeaderStyle-Height="5px"
                            Height="5px" RowStyle-Height="5px" AutoGenerateColumns="False" BorderWidth="0px"
                             CssClass="table table-bordered " AllowSorting="True"
                            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                            ShowHeader="true">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                   <asp:LinkButton ID="imbAdd" runat="server"  CommandName="AddData"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" > 
                                <span>+</span> </asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    
                                <ItemTemplate>
                                   <asp:LinkButton ID="imbDelete" runat="server"  CommandName="DisableData"
                                        OnClientClick="RotateAnimation(this); return ShowProgressBar();" > 
                                <span>-</span> </asp:LinkButton>
                                </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false" ItemStyle-Height="5px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false" ItemStyle-Height="5px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center"  ItemStyle-Height="5px" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol30" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="30px"
                                            Style="text-align: center;"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属项目部" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    ItemStyle-Height="5px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol31" runat="server"  onfocus="this.blur();"
                                                     Text='<%# Bind("col1") %>'  ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目经理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    ItemStyle-Height="5px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol32" runat="server" Text='<%# Bind("col2") %>' Style="text-align: left;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目经理金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    ItemStyle-Height="5px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol33" runat="server" Text='<%# Bind("col3") %>'  Style="text-align: left; border:0;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                        
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
                </div>
                <br />
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
