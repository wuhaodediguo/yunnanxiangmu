<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="caiwu8.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.caiwu8" %>

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
         .td2{   

            white-space: nowrap;/*控制单行显示*/   

            overflow: hidden;/*超出隐藏*/   

            text-overflow: ellipsis;/*隐藏的字符用省略号表示*/   

        }  
    </style>
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

            return false;
        }

        function PreviewConfirmMessage() {

            ShowProgressBar();
            PopUpEmployeeQuery2();

        }

        function LinkPrintPage() {

           
            var PosX = (screen.width - 800) / 2;
            var PosY = (screen.height - 400) / 2;

            var getid11 = document.getElementById("<%=TextBoxshenhe.ClientID%>");

            window.open('/Admin/xiangmu/shenhecaozuo.aspx?txtquanxian=' + txtquanxian + "&&fullname=" + fullname + "&&aaa=" + aaa + "&&tickedFormNo=" + tickedFormNo + "&&getid11=" + getid11,
                                'Window_Query', 'left=' + PosX + ',top=' + PosY + ',height=400,width=1000,scrollbars=yes');

        }

        function LinkPrintPage22() {

        var aaat = "只有当期审核人员" + aaa22 + "可以审核！";
        alert(aaat);
        }

        function btnAddPartDetail() {
            
            ShowProgressBar();
            document.getElementById("<%=Confirm.ClientID%>").click();
        }


 </script>

    <asp:TextBox ID="TextBoxshenhe" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:Button ID="Confirm" runat="server" Style="display: none" OnClick="btn提交2_Click" />
     <%--<button type="button" id="iConfirm" style="display: none" onclick="Action_Confirm()">
        </button>
        --%>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                <font size="2px">财务管理</font>&gt;<font size="2px">结算申请</font> <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        <div class="main_con">
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
                            <asp:Label ID="Label7" runat="server" Text="结算审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0093">
                        <a runat="server" id="div0093" href="caiwu7.aspx"><font color="blue">
                            <asp:Label ID="Label8" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0094">
                        <a runat="server" id="div0094" href="caiwu8.aspx?models=1"><font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="付款申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0095">
                        <a runat="server" id="div0095" href="caiwu8.aspx?models=2"><font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="付款审核" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0096">
                        <a runat="server" id="div0096" href="caiwu8.aspx?models=3"><font color="blue">
                            <asp:Label ID="Label11" runat="server" Text="付款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <!--#endeditable-->
                </dl>
            </div>
            <div class="col-sm-12" style="width: 88%; height: 600px;">
                <div class="panel panel-default" style="width: 100%; height: 600px; overflow: auto;
                    margin-top: -5px; background-color: transparent;">
                    <div id="AlertDiv" runat="server">
                    </div>
                    <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
                        height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                        <h4 class="panel-title">
                            <strong><font color="blue" size="2px" font-weight="bold">
                                <asp:Label ID="lblTitle" runat="server" Text="付款申请列表"></asp:Label></font></strong>
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
                                            <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="200px"
                                                Text="项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcol1" TabIndex="11" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="120px"
                                                Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtcol2" TabIndex="12" Style="margin-left: 0px" Width="390px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="200px"
                                                Text="总包合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcol3" TabIndex="11" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="120px"
                                                Text="收款人名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtcol4" TabIndex="12" Style="margin-left: 0px" Width="390px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                    <td>
                                        <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="200px"
                                            Text="到账金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol5" TabIndex="13" Style="margin-left: 0px" Width="400px" runat="server"
                                            class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" Width="120px"
                                            Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                            border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol6" TabIndex="13" Style="margin-left: 0px" Width="390px" runat="server"
                                            class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                    </td>
                                </tr>--%>
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
                    <div class="row" style="margin: 5px auto; font-size: 12px; width: 100%;">
                        <div id="Div1" class="col-sm-2" runat="server" visible="false">
                            <div class="btn btn-default btn-file" runat="server" id="divUpload">
                                <i class="fa fa-upload"></i>选择上传文件
                                <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                            </div>
                        </div>
                        <div class="col-sm-1 " runat="server" id="div新增">
                            <asp:Button ID="Button1" runat="server" Text="新增" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btnAdd_Click" />
                        </div>
                        <div class="col-sm-1 " runat="server" id="div编辑" visible="false">
                            <asp:Button ID="Button3" runat="server" Text="编辑" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn编辑_Click" />
                        </div>
                         <div class="col-sm-1 " runat="server" id="div提交" visible="false">
                            <asp:Button ID="Button8" runat="server" Text="提交" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn提交_Click"  />
                        </div>
                        <div class="col-sm-1 " runat="server" id="div审核">
                            <asp:Button ID="btnAdd" runat="server" Text="审核" CssClass="btn11" OnClick="btn审核_Click"
                                OnClientClick="RotateAnimation(this); return ShowProgressBar();"></asp:Button>
                        </div>
                        <div class="col-sm-1 " runat="server" id="div列表导出">
                            <asp:Button ID="Button4" runat="server" Text="列表导出" CssClass="btn11" Width="65px"
                                OnClick="btnExport_Click" />
                        </div>
                        <div class="col-sm-1 " runat="server" id="div明细导出">
                            <asp:Button ID="Button7" runat="server" Text="明细导出" CssClass="btn11" Width="65px"
                                OnClick="btnExport2_Click" />
                        </div>
                        <%-- <div class="col-sm-1 ">
                        <asp:Button ID="Button8" runat="server" Text="已审核结算" CssClass="btn11" Width="70px"  OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn已审核资料_Click" />
                    </div>--%>
                        <div class="col-sm-1" runat="server" id="div删除" >
                            <asp:Button ID="Button5" runat="server" Text="删除" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn删除_Click" />
                        </div>
                        
                    </div>
                    <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 10px;">
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
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID2" runat="server" Text='<%# Bind("col29") %>'></asp:Label>
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
                                                Style="text-align: center;"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="付款单号" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=''></asp:HyperLink>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col29") %>' Width="130px"
                                                Visible="false" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属项目部" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl所属项目部" runat="server" Text='<%# Bind("col1") %>' Width="130px"
                                                Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="项目经理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl项目经理" runat="server" Text='<%# Bind("col2") %>' Width="80px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="总包合同名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col3") %>' Width="220px" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="总包合同编号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>' Width="150px" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="劳务合同名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>' Width="120px" Style="text-align: Left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="劳务单位名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>' Width="120px" Style="text-align: Left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="劳务合同编号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col7") %>' Width="120px" Style="text-align: Left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="劳务合同结算依据" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>' CssClass="td2" ToolTip='<%# Bind("col8") %>' Width="100px" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="收款人名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col9") %>' Width="100px" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="收款人银行账号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol10" runat="server" Text='<%# Bind("col10") %>' Width="100px"
                                                Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="收款人开户行" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol11" runat="server" Text='<%# Bind("col11") %>' Width="110px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="已经支付金额（小写）" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol12" runat="server" Text='<%# Bind("col12") %>' Width="130px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="已经支付金额（大写）" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol13" runat="server" Text='<%# Bind("col13") %>' Width="130px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="本次申请支付发票金额（小写）" HeaderStyle-CssClass="text-center"
                                        ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol14" runat="server" Text='<%# Bind("col14") %>' Width="170px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="本次申请支付发票金额（大写）" HeaderStyle-CssClass="text-center" Visible="false"
                                        ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol15" runat="server" Text='<%# Bind("col15") %>' Width="170px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="本次申请支付实际金额（小写）" HeaderStyle-CssClass="text-center"
                                        ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol16" runat="server" Text='<%# Bind("col16") %>' Width="170px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="本次申请支付实际金额（大写）" HeaderStyle-CssClass="text-center" Visible="false"
                                        ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol17" runat="server" Text='<%# Bind("col17") %>' Width="170px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="本次申请支付发票号码" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol18" runat="server" Text='<%# Bind("col18") %>' Width="130px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="付款依据" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol19" runat="server" Text='<%# Bind("col19") %>' Width="110px" CssClass="td2" ToolTip='<%# Bind("col19") %>'
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申请人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl申请人" runat="server" Text='<%# Bind("col20") %>' Width="80px" Style="text-align: center;"
                                                autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申请日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl申请日期" runat="server" Text='<%# Bind("col21") %>' Width="110px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="审批状态" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLinkcol审批状态" runat="server"  NavigateUrl=''
                                                Target="_blank" Width="120px" Style="text-align: center;" >审批状态</asp:HyperLink>
                                          <%--  <asp:Label ID="lbl审批状态" runat="server" Text='<%# Bind("col25") %>' Width="200px"
                                                Style="text-align: Left;" autocomplete="off"></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="项目实施单位发票附件" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtn1" runat="server" Text="下载" Width="120px" CommandName="lbtn11">
                                            </asp:LinkButton>
                                            <asp:CheckBox ID="Chk项目实施单位发票附件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                            <asp:HyperLink ID="HyperLinkcol项目实施单位发票附件" runat="server" NavigateUrl='<%# Eval("col23") %>'
                                                Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                            <asp:Label ID="lbl项目实施单位发票附件" Visible="false" runat="server" Text='<%# Bind("col23") %>'></asp:Label>
                                            <asp:Label ID="Label项目实施单位发票附件" Visible="false" runat="server" Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="付款凭证" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtn2" runat="server" Text="下载" Width="120px" CommandName="lbtn12">
                                            </asp:LinkButton>
                                            <asp:CheckBox ID="Chk付款凭证" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                            <asp:HyperLink ID="HyperLinkcol付款凭证" runat="server" NavigateUrl='<%# Eval("col24") %>'
                                                 Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                            <asp:Label ID="lbl付款凭证" Visible="false" runat="server" Text='<%# Bind("col24") %>'></asp:Label>
                                            <asp:Label ID="Label付款凭证" Visible="false" runat="server" Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol22" runat="server" Text='<%# Bind("col22") %>' Width="150px" CssClass="td2" ToolTip='<%# Bind("col22") %>'
                                                Style="text-align: Left;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol25" runat="server" Text='<%# Bind("col25") %>' ></asp:Label>
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
    </div>
</asp:Content>
