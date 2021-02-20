<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.print" %>


<html lang="en">
  <head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8;width=device-width, initial-scale=1.0, user-scalable=no">  
  </head>
  <body>
  
    <Script type="text/javascript">
        function LinkPrintPage() {
            
            window.print();
        }

    </Script>
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
            font-size: 9px;
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
            font-size: 9px;
        }
        .btn11{
               background-color:transparent;         
               border:0px;
               width:35px; text-align:center; height:25px; font-size:12px;
               color: #9933FF;
        }
        
    </style>
    <style media="print">
    @page {
        size: auto;
        margin: 0mm;
    }
    </style>
    <style type="text/css">
        .sel
        {
            background-color: #33CCCC;
        }
        
        
        .div1
        {
            width: 100px;
            display: none;
        }
        @media print
        {
            .noprint
            {
                display: none;
            }
        }
        @page {
      size: auto;  /* auto is the initial value */
      margin: 0mm; /* this affects the margin in the printer settings */
    }
    </style>
    <style type="text/css">
        .td3
        {
            font-size: 16px;
            border-right: #f6f6f6 1px solid;
            text-align: right;
        }
        .style6
        {
            width: 100px;
        }
        .sel
        {
            background-color: #FFFF00;
        }
        .div1
        {
            width: 100px;
            display: none;
        }
        @media print
        {
            .noprint
            {
                display: none;
            }
        }
        @page {
      size: auto;  /* auto is the initial value */
      margin: 0mm; /* this affects the margin in the printer settings */
    }
    </style>
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
    <style>
 .father{
            position: relative;
            width: 500px;
            height: 500px;
        }
        .mydiv {
            position: absolute;
            left:-200px;
            width: 350px;
            margin-top: 205px;
            height: 40px;
            padding-left: 150px;
            border-bottom: 1px dashed black;
            border-top: 1px solid black;
            transform: rotate(90deg);
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=1);
            top: 14px;
            font-size:large;
        }
        .mytable{
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
        {}
    </style>
    
    <form id="form1" runat="server">
    <div class="noprint" 
        style="text-align: center; margin-bottom: 5px; width: 100%;">
        <button id="Button1" type="button" class="print" style="width:100px;height:20px;" 
                    onclick="LinkPrintPage()">
                <span class="glyphicon glyphicon-print" aria-hidden="true"></span> Print
            </button>
            </div>
    
       
    <div id ="div01" style=" text-align:center;width: 100%">
        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
        <br />
        <div class="table-responsive"  style="width: 100%">
                        <asp:GridView ID="GridView1" Width="100%" runat="server" Font-Size="12px" HeaderStyle-Height="10px" GridLines="Both" 
                            Height="10px" AutoGenerateColumns="False" BorderWidth="1px" CssClass="table table-bordered table-hover table-condensed"
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
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' > </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="标题"  HeaderStyle-CssClass="text-center"
                                    ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col3") %>'  ></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col1") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col2") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col55") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" Width="100%" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            GridLines="Both" 
                            Height="10px" AutoGenerateColumns="False" BorderWidth="1px" CssClass="table table-bordered table-hover table-condensed"
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
                                <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col8") %>'  autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col13") %>' 
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col14") %>' 
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView3" Width="100%" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            GridLines="Both" 
                            Height="10px" AutoGenerateColumns="False" BorderWidth="1px" CssClass="table table-bordered table-hover table-condensed"
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
                                <%--<asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=''></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="text-center"
                                    ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col1") %>' ></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col29") %>' 
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发起时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col30") %>' 
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col43") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        
                    </div>
    </div>
       
    
    </form>

</body>
</html>
