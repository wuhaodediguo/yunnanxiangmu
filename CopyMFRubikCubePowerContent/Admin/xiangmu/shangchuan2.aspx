﻿<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="shangchuan2.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shangchuan2" %>

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
     .main_conL222 dl dd {
    width: 220px;
    height: 20px;
    margin-top: 10px;
    margin-left: 20px;
}
    
</style>

    <script type="text/javascript">
        function cleanForm() {


            return false;
        }
 </script>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                合同管理&gt; <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                <em style="width:300%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
                <em><asp:Label ID="title" runat="server"></asp:Label></em>
            </div>
        </div>
       
        <div class="main_con" style="font-size: 10px;">
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230); font-size: 14px;">
                <dl style="width:120px; height:100%;">
                        <dd>
                            <a runat="server" id="div0031" href="hetong1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="施工合同管理" Font-Size="14px"></asp:Label></font></a></dd>
                        <dd>
                            <a runat="server" id="div0032" href="hetong2.aspx"><font color="blue">
                            <asp:Label ID="Label2" runat="server" Text="合作合同管理" Font-Size="14px"></asp:Label></font></a></dd>
                            <dd>
                            <a runat="server" id="div0033" href="hetong3.aspx"><font color="blue">
                            <asp:Label ID="Label3" runat="server" Text="采购合同管理" Font-Size="14px"></asp:Label></font></a></dd>
                      
                    </dl>
               
            </div>

            <div class="col-sm-12" style="width: 88%;">
                 <div id="AlertDiv" runat="server">
                 </div>
                 <div class="tab-content" style="margin: 5px auto; font-size: 12px;">
                        <div class="col-sm-2">
                        <div class="btn btn-default btn-file" runat="server" id="divUpload">
                            <i class="fa fa-upload"></i>选择导入文件
                            <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                        </div>
                    </div>
                       
                    </div>
                    <br />
                      <br />
                       <br />
                <div class="row">
                    <div class="col-sm-1 col-sm-offset-4">
                        <asp:Button ID="Button1" runat="server" TabIndex="23" Text="上传" CssClass="btn btn-primary" style="background-color:RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btnUpload_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1">
                        <asp:Button ID="Button7" runat="server" TabIndex="24" Text="返回" CssClass="btn btn-primary" style="background-color:RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btnBack_Click" />
                    </div>
                </div>

                <br />
                
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>


