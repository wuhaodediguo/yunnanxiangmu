<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="shangchuan3.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shangchuan3" %>

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
                项目管理&gt; <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
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
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230); 
                font-size: 14px">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0041">
                        <a runat="server" id="div0041" href="xiangmu1.aspx">
                        <font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="项目立项管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0045">
                        <a runat="server" id="div0045" href="xiangmu11.aspx">
                        <font color="blue">
                            <asp:Label ID="Label12" runat="server" Text="项目审计管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0042">
                        <a runat="server" id="div0042" href="xiangmu2.aspx">
                        <font color="blue">
                            <asp:Label ID="Label9" runat="server" Text="项目资料管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0043">
                        <a runat="server" id="div0043" href="xiangmu3.aspx">
                        <font color="blue">
                            <asp:Label ID="Label10" runat="server" Text="项目综合管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0044">
                        <a runat="server" id="div0044" href="xiangmu4.aspx">
                        <font color="blue">
                            <asp:Label ID="Label11" runat="server" Text="项目关闭管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0046">
                        <a runat="server" id="div0046" href="xiangmu8.aspx">
                        <font color="blue">
                            <asp:Label ID="Label2" runat="server" Text="项目月报管理" Font-Size="14px"></asp:Label></font></a></dd>
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


