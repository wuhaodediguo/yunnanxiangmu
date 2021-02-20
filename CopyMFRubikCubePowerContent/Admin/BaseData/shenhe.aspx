<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="shenhe.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.BaseData.shenhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 700px;
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
    </style>
    <div class="mainWrap clearfix">
        <div class="main_tit">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                系统管理</a>&gt;用户管理
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
                <div >
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <asp:DropDownList ID="Drop人员" TabIndex="18" Style="margin-left: 0px" Width="100px"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; width: 100%;">
                            <div class="panel-heading" style="text-align: center; margin-top: 0px; height: 25px;">
                                <h5 style="text-align: left; margin-top: -5px; font-size: 12px">
                                    开票审核</h5>
                            </div>
                            <br />
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 30px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <label>
                                            <asp:Label ID="Label19" runat="server" Text="一级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label20" runat="server" Text="二级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label21" runat="server" Text="三级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label22" runat="server" Text="四级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label23" runat="server" Text="五级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label24" runat="server" Text="六级审核人员"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 30px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <asp:ListBox ID="List一级审核人员" runat="server" SelectionMode="Multiple" Width="100">
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="List二级审核人员" runat="server" SelectionMode="Multiple" Width="100">
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="List三级审核人员" runat="server" SelectionMode="Multiple" Width="100">
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="List四级审核人员" runat="server" SelectionMode="Multiple" Width="100">
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="List五级审核人员" runat="server" SelectionMode="Multiple" Width="100">
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="List六级审核人员" runat="server" SelectionMode="Multiple" Width="100">
                                        </asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 100px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <asp:Button ID="btnSave1" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave1_Click">
                                        </asp:Button>
                                        <asp:Button ID="btndel1" runat="server" Text="删除" CssClass="btn22" OnClick="btndel1_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button1" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave2_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button2" runat="server" Text="删除" CssClass="btn22" OnClick="btndel2_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button5" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave3_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button6" runat="server" Text="删除" CssClass="btn22" OnClick="btndel3_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button7" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave4_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button8" runat="server" Text="删除" CssClass="btn22" OnClick="btndel4_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button9" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave5_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button10" runat="server" Text="删除" CssClass="btn22" OnClick="btndel5_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button3" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave6_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button4" runat="server" Text="删除" CssClass="btn22" OnClick="btndel6_Click">
                                        </asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; width: 100%;">
                            <div class="panel-heading" style="text-align: center; margin-top: 0px; height: 25px;">
                                <h5 style="text-align: left; margin-top: -5px; font-size: 12px">
                                    结算审核</h5>
                            </div>
                            <br />
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 30px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <label>
                                            <asp:Label ID="Label1" runat="server" Text="一级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label2" runat="server" Text="二级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label3" runat="server" Text="三级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label4" runat="server" Text="四级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label5" runat="server" Text="五级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label12" runat="server" Text="六级审核人员"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 30px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox3" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox4" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox5" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox6" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 100px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <asp:Button ID="Button11" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave11_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button12" runat="server" Text="删除" CssClass="btn22" OnClick="btndel11_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button13" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave12_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button14" runat="server" Text="删除" CssClass="btn22" OnClick="btndel12_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button15" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave13_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button16" runat="server" Text="删除" CssClass="btn22" OnClick="btndel13_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button17" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave14_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button18" runat="server" Text="删除" CssClass="btn22" OnClick="btndel14_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button19" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave15_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button20" runat="server" Text="删除" CssClass="btn22" OnClick="btndel15_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button21" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave16_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button22" runat="server" Text="删除" CssClass="btn22" OnClick="btndel16_Click">
                                        </asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; width: 100%;">
                            <div class="panel-heading" style="text-align: center; margin-top: 0px; height: 25px;">
                                <h5 style="text-align: left; margin-top: -5px; font-size: 12px">
                                    付款审核</h5>
                            </div>
                            <br />
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 30px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <label>
                                            <asp:Label ID="Label6" runat="server" Text="一级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label7" runat="server" Text="二级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label8" runat="server" Text="三级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label9" runat="server" Text="四级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label10" runat="server" Text="五级审核人员"></asp:Label></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <label>
                                            <asp:Label ID="Label11" runat="server" Text="六级审核人员"></asp:Label></label>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 30px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <asp:ListBox ID="ListBox7" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox8" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox9" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox10" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox11" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:ListBox ID="ListBox12" runat="server" SelectionMode="Multiple" Width="100"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-bodying" style="text-align: center; margin-top: 0px; height: 100px;">
                                <div class="row">
                                    <div class="col-md-2 form-group" style="margin-left: 0px">
                                        <asp:Button ID="Button23" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave21_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button24" runat="server" Text="删除" CssClass="btn22" OnClick="btndel21_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button25" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave22_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button26" runat="server" Text="删除" CssClass="btn22" OnClick="btndel22_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button27" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave23_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button28" runat="server" Text="删除" CssClass="btn22" OnClick="btndel23_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button29" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave24_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button30" runat="server" Text="删除" CssClass="btn22" OnClick="btndel24_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button31" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave25_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button32" runat="server" Text="删除" CssClass="btn22" OnClick="btndel25_Click">
                                        </asp:Button>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:Button ID="Button33" runat="server" Text="添加" CssClass="btn22" OnClick="btnSave26_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button34" runat="server" Text="删除" CssClass="btn22" OnClick="btndel26_Click">
                                        </asp:Button>
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
</asp:Content>
