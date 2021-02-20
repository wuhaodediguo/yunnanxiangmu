<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="shichang3Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shichang3Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 650px;
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
            background-color: RGB(60,141,188);
            border: 1px solid transparent;
            color: #fff;
            width: 35px;
            text-align: center;
            height: 25px;
            font-size: 12px;
        }
        
         .td2{   

            white-space: nowrap;/*控制单行显示*/   

            overflow: hidden;/*超出隐藏*/   

            text-overflow: ellipsis;/*隐藏的字符用省略号表示*/   

        }   
    </style>
    <script type="text/javascript">
        function cleanForm() {


            return false;
        }
 </script>
 <script type="text/javascript">
     function RotateAnimation(obj) {
         var $this = $(obj);
         $this.button('loading');
         setTimeout(function () {
             $this.button('reset');
         }, 2500);
     }

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

    <asp:HiddenField ID="HdCol2附件1" runat="server" />
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                市场管理&gt;客商管理
            </div>
        </div>
        <div class="main_con" >
            <div class="main_conL222" style="width: 12%; background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0021">
                        <a runat="server" id="div0021" href="shichang1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="投标管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0022">
                        <a runat="server" id="div0022" href="shichang2.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="中标管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0023">
                        <a runat="server" id="div0023" href="shichang3.aspx"><font color="blue">
                            <asp:Label ID="Label2" runat="server" Text="客商管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <!--#endeditable-->
                </dl>
            </div>
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
                        <strong><font color="blue" size="2px" >客商新增管理</font></strong>
                    </h4>
                </div>
                
                <div class="tab-content" style="margin: 0px auto; font-size: 9px;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox21" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>客户名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt客户名称" TabIndex="11" Style="margin-left: 0px" Width="380px" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox25" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>客户属性：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                            <asp:DropDownList ID="DropDown客户属性" TabIndex="12" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>运营商</asp:ListItem>
                                    <asp:ListItem>党政机关</asp:ListItem>
                                    <asp:ListItem>中国人民解放军部队</asp:ListItem>
                                    <asp:ListItem>事业单位</asp:ListItem>
                                    <asp:ListItem>国有企业</asp:ListItem>
                                    <asp:ListItem>其他企业</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="TextBox客户属性" TabIndex="12" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 
                                <asp:Label ID="lblBox18" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>客户性质：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDown客户性质" TabIndex="14" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>一般纳税人</asp:ListItem>
                                    <asp:ListItem>小规模纳税人</asp:ListItem>
                                    <asp:ListItem>非纳税人</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="TextBox客户性质" TabIndex="14" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>--%>
                            </td>
                            <td>
                                <asp:Label ID="lblBox26" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>三证合一证号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox三证合一证号" TabIndex="15" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox27" runat="server" class="form-control input-sm" Width="190px"
                                    Text="客户联系人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                           <td>
                                <asp:TextBox ID="TextBox客户联系人" TabIndex="15" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox29" runat="server" class="form-control input-sm" Width="190px"
                                    Text="客户联系电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox客户联系电话" TabIndex="16" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox34" runat="server" class="form-control input-sm" Width="190px"
                                    Text="联系人职务：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                           <td>
                                <asp:TextBox ID="TextBox联系人职务" TabIndex="18" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox35" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>纳税人识别号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                           <td>
                                <asp:TextBox ID="TextBox纳税人识别号" TabIndex="19" Style="margin-left: 0px" Width="380"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox36" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>地址：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox地址" TabIndex="20" Style="margin-left: 0px" Width="380" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox37" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox电话" TabIndex="21" Style="margin-left: 0px" Width="380" runat="server"
                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox39" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>开户银行：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开户银行" TabIndex="22" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox14" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>开户账号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox开户账号" TabIndex="23" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBox15" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建人" TabIndex="24" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBox16" runat="server" class="form-control input-sm" Width="190px"
                                    Text="<font color='red'>*</font>创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox创建日期" TabIndex="25" Style="margin-left: 0px" Width="380px"
                                    runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox45" runat="server" class="form-control input-sm" Width="190px"
                                    Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox备注" TabIndex="31" Style="margin-left: 0px" Width="950px"
                                    runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" Width="190px" Height="52px"
                                    Text="客户证照资料：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                    border: 0; margin-left: 0px;"></asp:TextBox>
                            </td>
                            <td colspan="5">
                                <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="21" Width="378px"  Style=" margin-left:2px" />
                                <asp:Button ID="Button5" runat="server" TabIndex="22" Text="上传" Style="font-size:12px; margin-left:2px"
                                    OnClick="FileUpload客户证照资料Button_Click" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();" />
                                <asp:TextBox ID="TextBox客户证照资料" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                <a href="" runat="server" id="客户证照资料href" target="_blank" style="font-size:12px;" Visible="false">客户证照资料</a>
                                <asp:LinkButton ID="btnAttach" runat="server" Class="btn btn-default btn-sm" 
                                            OnClick="btnAttach_Click" data-toggle="tooltip" ToolTip="删除附件" data-loading-text="<i class='glyphicon glyphicon-refresh glyphicon-refresh-animate'></i>"
                                            Visible="false">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span>
                                        </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            
                            <td colspan="2">
                                <div id="Div2" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                    <asp:GridView ID="GridView1" runat="server" Font-Size="12px"  DefaultType="1" AutoGenerateColumns="False"  BorderWidth="0px" CssClass="table table-bordered "
                                 OnRowDataBound="GridView1_RowDataBound" 
                                OnRowCommand="GridView1_RowCommand" ShowHeader="false">
                                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle"  />
                                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle"  />
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
                                    <asp:TemplateField  HeaderStyle-CssClass="text-center"  >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("col3") %>' CssClass="td2"  NavigateUrl='<%# Bind("col3") %>' Width="280" Target="_blank" ></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="text-center" >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CommandName="_delete" Width="30"><span class="glyphicon glyphicon-trash" aria-hidden="true" align="left"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView>
                                </div>
                            </td>
                             <td colspan="2">
                                <div id="Div1" runat="server" width="178px"  style="width: 100%; height:200px; overflow: auto; margin-top: 2px; background-color: RGB(217,237,247);" >
                                  </div>
                             </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-sm-1 col-sm-offset-4">
                        <asp:Button ID="Button1" runat="server" TabIndex="23" Text="保存" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn保存_Click" />
                    </div>
                    <div class="col-sm-1 col-sm-offset-1">
                        <asp:Button ID="Button7" runat="server" TabIndex="24" Text="返回" CssClass="btn22"
                            Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn返回_Click" />
                    </div>
                </div>
                <br />
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
