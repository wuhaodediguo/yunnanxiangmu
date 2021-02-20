<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="pinzhong.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.BaseData.pinzhong" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style type="text/css">
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
            font-size: 12px;
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
    </style>
    <script type="text/javascript">

        function formatAsNum(mnt) {
            mnt -= 0;
            mnt = (Math.round(mnt * 100)) / 100;
            return mnt;
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

 </script>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                系统管理</a>&gt;州市管理
            </div>
        </div>
        <div class="main_con">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0071">
                        <a  runat="server" id="div0071" href="../Role/Name.aspx?active=11,12"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="系统管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0072">
                        <a runat="server" id="div0072" href="../User/List.aspx?active=11,82"><font color="blue">
                            <asp:Label ID="Label13" runat="server" Text="用户管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0073">
                        <a runat="server" id="div0073" href="../User/Profile.aspx"><font color="blue">
                            <asp:Label ID="Label14" runat="server" Text="用户面板" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0074">
                        <a runat="server" id="div0074" href="../BaseData/guige.aspx"><font color="blue">
                            <asp:Label ID="Label15" runat="server" Text="项目部管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd  runat="server" id="dd0075">
                        <a runat="server" id="div0075" href="../BaseData/xiangmujingli.aspx"><font color="blue">
                            <asp:Label ID="Label16" runat="server" Text="项目经理管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0076">
                        <a runat="server" id="div0076" href="../BaseData/pinzhong.aspx"><font color="blue">
                            <asp:Label ID="Label17" runat="server" Text="州市管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd  runat="server" id="dd0077">
                        <a runat="server" id="div0077" href="../BaseData/shenhe.aspx"><font color="blue">
                            <asp:Label ID="Label18" runat="server" Text="审核管理" Font-Size="14px"></asp:Label></font></a></dd>
                </dl>
            </div>
            <div class="col-sm-10" style="width: 88%;">
                <div id="AlertDiv" runat="server">
                </div>
                <div class="row" style="margin: 5px auto; font-size: 9px; width: 100%;">
                    <div class="col-sm-1  ">
                        <asp:Button ID="Button1" runat="server" Text="新增" CssClass="btn11" OnClick="btnAdd_Click">
                        </asp:Button>
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button3" runat="server" Text="保存" CssClass="btn11" OnClick="btnSave_Click">
                        </asp:Button>
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button4" runat="server" Text="全部勾选" CssClass="btn11" Width="70px"
                            Visible="false" OnClick="Button2_Click"></asp:Button>
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button5" runat="server" Text="批量删除" CssClass="btn11" Width="70px"
                            OnClick="btnDelete_Click"></asp:Button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 form-group" runat="server" visible="false" id="div01">
                        <label>
                            <asp:Label ID="Label1" runat="server" Text="州市"></asp:Label></label>
                        <asp:TextBox ID="txtpinming" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 10px;">
                            <div class="table-responsive" style="width: 450px">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                    CssClass="table table-bordered" AllowSorting="True"
                                    OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                                    OnRowCreated="GridView1_RowCreated">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                                    <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="序号" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="id" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="州市" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl项目经理" runat="server" Text='<%# Bind("pinming") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="gvEdit" runat="server" ToolTip="修改"><span class="label label-primary"><i class="fa fa-edit"></i> 修改</span></asp:HyperLink>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete"><span class="label label-danger"><i class="fa fa-remove"></i> 删除</span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="勾选" HeaderStyle-CssClass="text-center" ItemStyle-Height="5px">
                                            <ItemStyle VerticalAlign="Middle"></ItemStyle>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);"
                                                    Style="margin: 0 20%" data-toggle="tooltip" data-placement="center"></asp:CheckBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" runat="server" Width="30px" Style="text-align: center;" />
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
            </div>
        </div>
    </div>
</asp:Content>
