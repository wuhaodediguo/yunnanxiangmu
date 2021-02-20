<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="shouye.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shouye" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
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
            background-color: RGB(214,220,228);
            border: 1px solid transparent;
            color: #fff;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 12px;
        }
        .btn11{
               background-color:transparent;         
               border:0px;
               width:35px; text-align:center; height:25px; font-size:14px;
               color: #9933FF;
        }
        
    </style>
    <script type="text/javascript">
        function cleanForm() {


            return false;
        }
        function LinkPrintPage() {
            var hdstrcase = $("#<%= hdstrcase.ClientID %>").val();
            var hdUserName = $("#<%= hdUserName.ClientID %>").val();
            var hdRoleValue = $("#<%= hdRoleValue.ClientID %>").val();
           
            window.open("../xiangmu/print.aspx?hdstrcase=" + hdstrcase + "&hdUserName=" + hdUserName + "&hdRoleValue=" + hdRoleValue);
            
        }
 </script>
 <script type="text/javascript">

     function print_page() {

         pagesetup_null();

         var printData = document.getElementById("div01").innerHTML; //获得 div 里的所有 html 数据

         window.document.body.innerHTML = printData;   //把 html 里的数据 复制给 body 的 html 数据 ，相当于重置了 整个页面的 内容
         window.print();

     };

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

     <asp:TextBox ID="hdtemp" runat="server" class="form-control" Style="display: none"></asp:TextBox>
     <asp:TextBox ID="tempcase" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:HiddenField ID="hdstrcase" runat="server" />
    <asp:HiddenField ID="hdUserName" runat="server" />
    <asp:HiddenField ID="hdRoleValue" runat="server" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                首页信息
            </div>
        </div>
        <div class="main_con" style="font-size: 10px;">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd>
                        >待办（<asp:Label ID="Label1" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button4" runat="server" Text=">开票审批" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn待办1_Click" />（<asp:Label
                                ID="Label2" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button5" runat="server" Text=">结算审批" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn待办3_Click" />（<asp:Label
                                ID="Label8" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button3" runat="server" Text=">资料提交" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn待办2_Click" />（<asp:Label
                                ID="Label3" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button8" runat="server" Text=">收款管理" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn待办4_Click" />（<asp:Label
                                ID="Label10" runat="server"></asp:Label>）
                    </dd>

                    <dd>
                        >已办（<asp:Label ID="Label4" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text=">开票审批" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn已办1_Click" />（<asp:Label
                                ID="Label5" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button6" runat="server" Text=">结算审批" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn已办3_Click" />（<asp:Label
                                ID="Label9" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text=">资料提交" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn已办2_Click" />（<asp:Label
                                ID="Label6" runat="server"></asp:Label>）
                    </dd>
                    <dd>
                        &nbsp;&nbsp; &nbsp;<asp:Button ID="Button9" runat="server" Text=">收款管理" Style="border: 0;
                            background-color: RGB(155,194,230); color: Blue" OnClick="btn已办4_Click" />（<asp:Label
                                ID="Label11" runat="server"></asp:Label>）
                    </dd>
                </dl>
            </div>
            <div class="col-sm-12" style="width: 88%;">
                <div id="AlertDiv" runat="server">
                </div>
                <div class="panel-heading">
                    <h4 class="panel-title" style="text-align: left; margin-top: 5px; height: 10px; font-size: 10px">
                        <div class="col-sm-3  ">
                            <font size="2px" font-weight="bold">
                                <asp:Label ID="Label7" runat="server" Text=">待办   >开票审批" Font-Size="10"></asp:Label>
                            </font>
                            
                        </div>
                        
                        <div class="col-sm-1  col-sm-offset-8  ">
                            <asp:Button ID="Button10" runat="server" Text="导出" CssClass="btn11"
                                 OnClick="btnExport_Click" />
                            <%--<asp:Button ID="Button7" runat="server" Text="打印" CssClass="btn11"
                                 OnClientClick="LinkPrintPage();" />--%>
                        </div>
                    </h4>
                </div>
                <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 10px;">
                    <div class="table-responsive" style="width: 100%">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            Height="10px" AutoGenerateColumns="False" BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True" OnRowDataBound="GridView1_RowDataBound">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="id" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='' style=" text-align:left"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" Visible="false" HeaderStyle-CssClass="text-center"
                                    ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col3") %>' Width="200px" autocomplete="off"></asp:Label>
                                        <asp:Label ID="lblcol53" runat="server" Text='<%# Bind("col53") %>' Width="200px"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col1") %>' Width="150px" autocomplete="off" style=" text-align:center"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col2") %>' Width="150px" autocomplete="off" style=" text-align:center"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col55") %>' autocomplete="off" style=" text-align:center"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            Height="10px" AutoGenerateColumns="False" BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="id" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col8") %>' Width="100px" style=" text-align:left" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col13") %>' Width="150px" style=" text-align:center"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col14") %>' Width="150px" style=" text-align:center"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView3" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            Height="10px" AutoGenerateColumns="False" BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True" OnRowDataBound="GridView3_RowDataBound">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="id" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='' style=" text-align:left"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" Visible="false" HeaderStyle-CssClass="text-center"
                                    ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col1") %>' Width="200px" autocomplete="off"></asp:Label>
                                        <asp:Label ID="lblcol53" runat="server" Text='<%# Bind("col45") %>' Width="200px"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col29") %>' Width="150px" style=" text-align:center"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col30") %>' Width="150px" style=" text-align:center"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col43") %>' autocomplete="off" style=" text-align:center"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView4" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            Height="10px" AutoGenerateColumns="False" BorderWidth="0px" CssClass="table table-bordered table-hover table-condensed"
                            AllowSorting="True" OnRowDataBound="GridView4_RowDataBound">
                            <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                            <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="id" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="40px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票单号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='' ></asp:HyperLink>
                                        <asp:Label ID="lblcol53" runat="server" Text='<%# Bind("col53") %>' Width="130px" Visible="false" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同名称"  HeaderStyle-CssClass="text-center"
                                    ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col9") %>' style=" text-align:left" Width="200px" autocomplete="off"></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票金额"  HeaderStyle-CssClass="text-center"
                                    ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol666" runat="server" Text='<%# Bind("col666") %>' Width="200px" style=" text-align:center" autocomplete="off"></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol31" runat="server" Text='<%# Bind("col1") %>' Width="110px" style=" text-align:center"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol32" runat="server" Text='<%# Bind("col32") %>' Width="110px" style=" text-align:center"
                                            autocomplete="off"></asp:Label>
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
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
