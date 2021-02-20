<%@ Page Title="" Language="C#"  AutoEventWireup="true" 
CodeBehind="BASEQ04.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.BASEQ04" %>

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

     <script language="JavaScript" type="text/javascript">

         $(document).ready(function () {
             $('[data-toggle="tooltip"]').tooltip(
                {
                    'trigger': 'hover',
                    'html': 'true'
                }
            );

             $('.pagination-ys a').click(function () {
                 encodeTextBoxFromFreeTyping();
                 TriggerSearchEvent();
             });

         });

         var isF5 = false;
         var ifSearchTrigger = false;

         TriggerSearchEvent = function () {
             ifSearchTrigger = true;
         }

         document.onkeydown = function () {
             if (window.event.keyCode == 116) {
                 isF5 = true;
             }
         }

         window.onload = function () {
             decodeTextBoxFromFreeTyping();
         }

         window.onbeforeunload = function () {
             //離開頁面之前觸發事件
             //alert('onbeforeunload');
             //alert(isF5);
             //alert(ifSearchTrigger);

             decodeTextBoxFromFreeTyping();

             if (!isF5 && !ifSearchTrigger) {
                 if (window.opener) {

                     var functionObj = typeof (window.opener.HideProgressBar);

                     if (functionObj === 'function' || functionObj === 'object') {
                         //alert('HideProgressBar');
                         window.opener.HideProgressBar();
                     };
                 }
             }
         }

    </script>
    
    <script type="text/javascript">

        function encodeTextBoxFromFreeTyping() {
            var criteria = document.getElementById('<%= txtCriteria.ClientID %>');
            if (criteria) {
                criteria.value = htmlEncode(criteria.value);
            }
        }

        function decodeTextBoxFromFreeTyping() {
            var criteria = document.getElementById('<%= txtCriteria.ClientID %>');
            if (criteria) {
                criteria.value = htmlDecode(criteria.value);
            }
        }

        function htmlDecode(encoded) {
            var elem = document.createElement('textarea');
            elem.innerHTML = encoded;
            var decoded = elem.value;
            return decoded;
        }

        function htmlEncode(str) {
            var div = document.createElement('div');
            var text = document.createTextNode(str);
            div.appendChild(text);
            return div.innerHTML;
        }

    </script>

    <script type="text/javascript">

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

    <style>
    /* for Tooltip CSS*/
    .tooltip-inner {
        background-color: #666666;
        border: 1px solid #FFFFFF;
        padding: 13px;
        font-size: 12px;
    }
    /* Tooltip on bottom */
    .tooltip.bottom > .tooltip-arrow {
        border-bottom: 5px solid #666666;
    }
    /* Tooltip on bottom */
    .tooltip.top > .tooltip-arrow {
        border-top: 5px solid #666666;
    }
    /* Tooltip on bottom */
    .tooltip.right > .tooltip-arrow {
        border-right: 5px solid #666666;
    }
    /* Tooltip on bottom */
    .tooltip.left > .tooltip-arrow {
        border-left: 5px solid #666666;
    }
    .glyphicon-refresh-animate {
        animation-name: spin;
        animation-duration: 1000ms;
        animation-iteration-count: infinite;
        animation-timing-function: linear;
    }
    @keyframes spin {
        from { transform:rotate(0deg); }
        to { transform:rotate(360deg); }
    }
    
    /* for pagination CSS*/
    .pagination-ys {
    /*display: inline-block;*/
    padding-left: 0;
    margin: 20px 0;
    border-radius: 4px;
    }
 
    .pagination-ys table > tbody > tr > td {
        display: inline;
    }
 
    .pagination-ys table > tbody > tr > td > a,
    .pagination-ys table > tbody > tr > td > span {
        position: relative;
        float: left;
        padding: 8px 12px;
        line-height: 1.42857143;
        text-decoration: none;
        color: #dd4814;
        background-color: #ffffff;
        border: 1px solid #dddddd;
        margin-left: -1px;
    }
 
    .pagination-ys table > tbody > tr > td > span {
        position: relative;
        float: left;
        padding: 8px 12px;
        line-height: 1.42857143;
        text-decoration: none;    
        margin-left: -1px;
        z-index: 2;
        color: #aea79f;
        background-color: #f5f5f5;
        border-color: #dddddd;
        cursor: default;
    }
 
    .pagination-ys table > tbody > tr > td:first-child > a,
    .pagination-ys table > tbody > tr > td:first-child > span {
        margin-left: 0;
        border-bottom-left-radius: 4px;
        border-top-left-radius: 4px;
    }
 
    .pagination-ys table > tbody > tr > td:last-child > a,
    .pagination-ys table > tbody > tr > td:last-child > span {
        border-bottom-right-radius: 4px;
        border-top-right-radius: 4px;
    }
 
    .pagination-ys table > tbody > tr > td > a:hover,
    .pagination-ys table > tbody > tr > td > span:hover,
    .pagination-ys table > tbody > tr > td > a:focus,
    .pagination-ys table > tbody > tr > td > span:focus {
        color: #97310e;
        background-color: #eeeeee;
        border-color: #dddddd;
    }
    
    </style>
</head>

<body>
    <form runat="server">
        <div class="container" style="margin-bottom: 20px; margin-top: 20px;overflow: auto;">    

        <!--Loading Mask Region-->
        <div>
            <div id="divMaskFrame" style="background-color: #F2F4F7; display: none; position: absolute;
                left: 0px; top: 0px;">
            </div>
            <div id="divProgress" style="text-align: center; display: none; position: fixed;
                top: 50%; left: 50%;">
                <asp:Image ID="imgLoading" runat="server" ImageUrl="../Resources/Images/LoadingMask.gif" />
            </div>
        </div>
        <!---->

        <!--標題-->
        <div class="row">
            <div class="col-xs-12">
                <h3 class="page-header" style="margin-top: 0px">
                    <asp:Label ID="lblTitle" runat="server" ></asp:Label>
                    
                </h3>
            </div>
        </div>

        <div id="AlertDiv" runat="server">
                </div>
        <!--表單第一列 - 搜尋條件-->
        <div class="row">

            <div class="col-xs-12" style="margin-bottom: 5px;">
                <div class="form-group">
                    <div class="col-xs-12">
                        <b><asp:Label ID="lblCriteria" runat="server" ></asp:Label></b>
                    </div>
                    <div class="col-xs-12">
                        <asp:TextBox ID="txtCriteria" runat="server" class="form-control" autocomplete="off"
                            data-toggle="tooltip"  data-placement="bottom"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-xs-12" style="text-align: center;">

                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" 
                     OnClick="btnSearch_Click"
                     OnClientClick = "encodeTextBoxFromFreeTyping(); TriggerSearchEvent(); return ShowProgressBar();" 
                     Text="检索" 
                     Width="100"
                     />

                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" 
                    OnClientClick = "return encodeTextBoxFromFreeTyping();"
                    OnClick="btnBack_Click"
                    Text="返回" 
                    Width="100"
                    />
            </div>

        </div>

        <!-- 系統顯示訊息 -->
        <div class="row" style="margin-top: 10px; margin-bottom: 0px">
            <div class="col-xs-12">
                <asp:literal id="ltlSystemMessage" runat="server"></asp:literal>
            </div>
        </div>

        <!--Data List : 以 Gridview 呈現 -->
        <div class="table-responsive" style="margin-top: 0px; font-size: 12px;width:900px;overflow: auto; ">
            <asp:GridView ID="gvDataList" Font-Size="12px"
                runat="server" 
                AllowPaging="true"
                CssClass="table table-bordered table-hover table-condensed"
                Width="100%" 
                HorizontalAlign="Center"
                OnRowCommand="gvDataList_RowCommand" 
                OnRowDataBound="gvDataList_RowDataBound"
                OnPageIndexChanging="gvDataList_PageIndexChanging"
                AutoGenerateColumns="True"
                >

                <HeaderStyle HorizontalAlign="Center" CssClass="info"  />
                <RowStyle HorizontalAlign="Center" CssClass="text-center"  />

                <Columns>

                    <asp:TemplateField>

                        <ItemTemplate>

                            <asp:LinkButton ID="btnIcon" runat="server" CssClass="btn btn-primary btn-xs" CommandName="Select"
                                OnClientClick = "return encodeTextBoxFromFreeTyping();">
                                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                            </asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                </Columns>

                <PagerStyle CssClass="pagination-ys" />

            </asp:GridView>
        </div>

    </div>
    </form>
</body>


</html>

