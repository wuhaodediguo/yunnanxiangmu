<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="caiwu51Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu51Add" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>检索画面</title>
    <meta name="keywords" content="检索画面" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="stylesheet" href="../Css/style.css" type="text/css" />
    <link rel="stylesheet" href="../Css/publice.css" type="text/css" />
    <link rel="shortcut icon" href="../Images/favicon.ico" type="image/x-icon" />

    <script type="text/javascript" src="../JS/jquery-3.3.1.min.js"></script>

    <link rel="stylesheet" href="../Skins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Css/font-awesome.min.css" />
    <link rel="stylesheet" href="../Css/ionicons.min.css" />
    <link rel="stylesheet" href="../Skins/dist/css/AdminLTE.min.css" />
   
    <link rel="stylesheet" href="../Css/main.css" />
    <script type="text/javascript" src="../JS/html5shiv.min.js"></script>
    <script type="text/javascript" src="../JS/respond.min.js"></script>
    <script type="text/javascript" src="../JS/My97DatePicker/WdatePicker.js"></script>
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

           
            var gvPartOpen = document.getElementById('<%=GridView1.ClientID%>');

            for (var i = 1; i < gvPartOpen.rows.length; i++) {

                if (i == gvPartOpen.rows.length - 1) {
                   
                    gvPartOpen.rows[i].cells[4].innerText = formatNumberHeader(amount);
                    
                }
               
                var Price1 = gvPartOpen.rows[i].cells[4].getElementsByTagName("input")[0].value.replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "").replace(",", "");
                if (Price1) {

                    amount += formatAsNum(Price1) ;

                    gvPartOpen.rows[i].cells[4].getElementsByTagName("input")[0].value = formatNumberHeader(Price1);
                    
                }
                else if (Price1) {
                    amount += formatAsNum(Price1);
                }

            }

            return true;
        }

    </script>
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
    </head>

<body>
    <form id="Form1" runat="server">
        <div class="container" style="margin-bottom: 20px; margin-top: 20px;overflow: auto;">    

        <div class="main_con" style="font-size: 10px;">
            
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
                        <strong><font color="blue" size="2px" >新增收款明细</font></strong>
                    </h4>
                </div>
                <div class="tab-content" style="margin: 0px auto; font-size: 12px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="170px"
                                    Text="开票申请单号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox开票申请单号" TabIndex="12" Style="margin-left: 0px" Width="170px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" class="form-control input-sm" Width="170px"
                                    Text="收款次数：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox收款次数" TabIndex="12" Style="margin-left: 0px" Width="170px"
                                    onfocus="this.blur();" runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            
                        </tr>
                        </table>
                </div>
                <div class="table-responsive" style="width: 1140px;overflow: auto; ">

                    <asp:GridView ID="GridView1" runat="server" Font-Size="12px"  AutoGenerateColumns="False" BorderWidth="0px"
                        CssClass="table table-bordered table-hover table-condensed" AllowSorting="True"  
                        OnRowDataBound="GridView1_RowDataBound" 
                         ShowFooter="true">
                        <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="10px" />
                        <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="10px" />
                        <Columns>
   
                            <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"
                                        Style="text-align: center;"> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <asp:Label ID="lblcol3" runat="server"  Style="text-align: left;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col3") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="项目编码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <asp:Label ID="lblcol4" runat="server"  Style="text-align: left;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col4") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="本次开票金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="right">
                                <ItemTemplate>
                                    <asp:Label ID="lblcol5" runat="server"  Style="text-align: right; width:120px;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col5") %>'
                                       ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="本次到账金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="right"
                                >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcol6" runat="server"  Style="text-align: right;width:120px;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col6") %>' 
                                        autocomplete="off" onblur='QtyCheck(this);tongji()'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="本次到账时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcol7" runat="server" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年-MM月-dd日'})" Style="text-align: left; width:120px;
                                        border: 0; height: 15px; font-size: 12px;" Text='<%# Bind("col7") %>' 
                                        autocomplete="off"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                >
                                <ItemTemplate>
                                    <div>
                                        <asp:TextBox ID="txtcol8" runat="server" Text='<%# Bind("col8") %>' 
                                            Style="text-align: left; border: 0;" autocomplete="off"></asp:TextBox>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                
                <div class="row">
                    <div class="col-sm-1 col-sm-offset-4">
                        <asp:Button ID="Button3" runat="server" Text="保存" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn保存_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1">
                        <asp:Button ID="Button1" runat="server" Text="返回" TabIndex="37" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" 
                            OnClick="btn返回_Click" />
                    </div>
                    
            </div>
            <!--#endeditable-->
        </div>
    </div>

    </div>
    </form>
</body>


</html>


