<%@ Page Language="C#" MasterPageFile="../Commons/Main.master"  AutoEventWireup="true" CodeBehind="shangchuan5.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shangchuan5" %>

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
                财务管理&gt; <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
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
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd>
                        <a runat="server" id="div0061" href="caiwu1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="外经证管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd>
                        <a runat="server" id="div0062" href="caiwu2.aspx"><font color="blue">
                            <asp:Label ID="Label12" runat="server" Text="开票申请" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd>
                        <a runat="server" id="div0063" href="caiwu3.aspx"><font color="blue">
                            <asp:Label ID="Label13" runat="server" Text="开票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd>
                        <a runat="server" id="div0067" href="caiwu31.aspx"><font color="blue">
                            <asp:Label ID="Label16" runat="server" Text="税款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd>
                        <a runat="server" id="div0064" href="caiwu4.aspx"><font color="blue">
                            <asp:Label ID="Label4" runat="server" Text="发票管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd>
                        <a runat="server" id="div0065" href="caiwu5.aspx"><font color="blue">
                            <asp:Label ID="Label15" runat="server" Text="收款管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd>
                        <a runat="server" id="div0066" href="caiwu6.aspx"><font color="blue">
                            <asp:Label ID="Label26" runat="server" Text="结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <!--#endeditable-->
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



