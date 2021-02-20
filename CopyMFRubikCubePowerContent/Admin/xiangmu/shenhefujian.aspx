<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="shenhefujian.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shenhefujian" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>审核</title>
    <meta name="keywords" content="审核" />
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

       
    </script>
    <style type="text/css">
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 640px;
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
            font-size: 12px;
            color: #9933FF;
        }
        
        .headtile
        {
            background-color: transparent;
            border: 0px;
            text-align: center;   
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
</head>
<body>
    <form id="Form1" runat="server">
     <asp:HiddenField ID="Hdchakanmodel" runat="server" />
    <asp:HiddenField ID="HdcasetName" runat="server" />
    <asp:HiddenField ID="HdCol2附件1" runat="server" />
    <asp:HiddenField ID="HdCol2附件2" runat="server" />
    <asp:HiddenField ID="HdCol2附件3" runat="server" />
    <asp:HiddenField ID="HdCol2附件4" runat="server" />
    <asp:HiddenField ID="HdCol2附件5" runat="server" />
    <asp:TextBox ID="TextBox审核人员value" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="txtHideWHFrom" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <asp:TextBox ID="TextBoxquanxian" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="container" style="margin-bottom: 20px; margin-top: 20px; overflow: auto;">
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
                <div class="row" style="margin-left: 10px;">
                    <div class="modal-dialog" style=" width:800px; height:500px; ">
                <!-- Modal content-->
                <div class="modal-content" >
                   
                    <div class="modal-body" >
                       
                        <div class="row" style="margin: 5px 0 0 0">
                            <div class="col-sm-4" style=" text-align:right">
                                <asp:Label ID="Label发票单号" runat="server" class="control-label" Text="发票单号" Font-Size="12"  ></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:TextBox ID="txtInput发票单号" runat="server" class="form-control"  > 
                                </asp:TextBox>
                            </div>
                        </div>
                        <div id="div审核人" runat="server" visible="false" class="row" style="text-align:right;margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label13" runat="server" class="control-label" Text="审核人" Font-Size="12"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:TextBox ID="TextBox审核人" runat="server" class="form-control"  > 
                                </asp:TextBox>
                            </div>
                        </div>
                        <div id="div审核意见" runat="server" visible="false" class="row" style="text-align:right;margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label14" runat="server" class="control-label" Text="审核意见" Font-Size="12"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:TextBox ID="TextBox审核意见" runat="server" class="form-control"  > 
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row" id="div附件名称" runat="server" style="margin: 5px 0 0 0">
                            <div class="col-sm-4">
                                <asp:Label ID="Label附件名称" runat="server" class="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-7 col-xs-8">
                                <asp:FileUpload ID="FileUpload0" runat="server" TabIndex="35" Style="margin-left: 1px;" />
                                <asp:Button ID="Button9" runat="server" Text="上传" TabIndex="36" Style="font-size: 14;
                                    margin-left: 1px" OnClick="FileUpload税票扫描件Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <a href="" runat="server" id="税票扫描件href" target="_blank" visible="false"></a>
                                <asp:TextBox ID="TextBox税票扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div id="Div1" runat="server" width="158px" style="width: 100%; height: 180px; overflow: auto;
                            margin-top: 2px; background-color: RGB(217,237,247);">
                            <asp:GridView ID="GridView2" runat="server" Font-Size="12px" DefaultType="1" AutoGenerateColumns="False"
                                BorderWidth="0px" CssClass="table table-bordered " OnRowDataBound="GridView2_RowDataBound" 
                                OnRowCommand="GridView2_RowCommand" >
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
                                    <asp:TemplateField HeaderStyle-CssClass="headtile" HeaderText="附件名称" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2" Target="_blank"
                                                NavigateUrl='<%# Bind("col3") %>' Width="300"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField  HeaderStyle-CssClass="headtile" HeaderText="上传人">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField  HeaderStyle-CssClass="headtile" HeaderText="上传时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-CssClass="headtile" HeaderText="审核人">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-CssClass="headtile" HeaderText="审核时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col7") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-CssClass="headtile" HeaderText="审核意见">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="headtile" HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="20"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer" >
                        <div class="row" >
                            <div class="col-xs-4 col-md-4" align="center" id="div附件名称footer" runat="server" visible="false">
                                <asp:Button ID="btn审核" runat="server" Text="审核通过" CssClass="btn22" Width="60" OnClick="btn审核_Click"
                                    OnClientClick="return inputcheck();RotateAnimation(this);$('#myModalAdd').modal('hide');return ShowProgressBar();"
                                    data-toggle="tooltip" data-placement="right" ToolTip="Add a new Part Specification" />
                            </div>
                            <div class="col-xs-4 col-md-4" align="center" id="div附件名称footer2" runat="server" visible="false">
                                <asp:Button ID="Button5" runat="server" Text="审核不通过" CssClass="btn22" Width="66" OnClick="btn审核不通过_Click"
                                    OnClientClick="return inputcheck();RotateAnimation(this);$('#myModalAdd').modal('hide');return ShowProgressBar();"
                                    data-toggle="tooltip" data-placement="right" ToolTip="Add a new Part Specification" />
                            </div>
                            <div class="col-xs-6 col-md-6" align="center" id="div提交" runat="server" visible="false">
                                <asp:Button ID="btn提交" runat="server" Text="确定" TabIndex="38" CssClass="btn22" Style="background-color: RGB(146,208,80)"
                                OnClientClick="RotateAnimation(this); return ShowProgressBar();" OnClick="btn提交_Click" />
                            </div>
                            <div class="col-xs-6 col-md-6" align="center" id="div2" runat="server" >
                                <asp:Button ID="Button1" runat="server" Text="关闭" TabIndex="38" CssClass="btn22" 
                                 OnClick="btn关闭_Click" />
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
                </div>
                
                
            </div>
            <!--#endeditable-->
        </div>
    </div>
    </form>
</body>
</html>
