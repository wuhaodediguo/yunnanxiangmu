<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="Name.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.Role.Admin_Role_Name" %>

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
    </script>
    <asp:TextBox ID="TextBox审核人" runat="server" class="form-control" Style="display: none"></asp:TextBox>

    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                系统管理&gt;系统管理
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
                <div class="row">
                    <div class="col-xs-12">
                        <div class="panel-body" style="margin: -10px auto; font-size: 12px;">
                            <div class="col-sm-2 col-sm-offset-1">
                                <asp:DropDownList ID="DropUser" TabIndex="13" Style="margin-left: 0px" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="DropUserSelectedIndexChanged"
                                    runat="server" class="form-control input-sm" autocomplete="off">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-1 col-sm-offset-1">
                                <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                    OnClick="lnbSearch_Click" />
                            </div>
                            <div class="col-sm-1 col-sm-offset-2">
                                <asp:Button ID="Button3" runat="server" Text="保存" TabIndex="37" CssClass="btn22"
                                    Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                    OnClick="btnSave_Click" />
                            </div>
                            <div class="col-sm-1 col-sm-offset-1" runat="server" visible="false">
                                <asp:Button ID="Button4" runat="server" Text="导出" CssClass="btn22" OnClick="btnExport_Click" />
                            </div>
                            <div class="col-sm-2">
                                <div class="btn btn-default btn-file" runat="server" id="divUpload" visible="false">
                                    <i class="fa fa-upload"></i>选择导入文件
                                    <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                                </div>
                            </div>
                            <div class="col-sm-1 col-sm-offset-4" runat="server" visible="false">
                                <asp:Button ID="Button2" runat="server" TabIndex="23" Text="上传" CssClass="btn btn-primary"
                                    Style="background-color: RGB(146,208,80)" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                    OnClick="btnUpload_Click" />
                            </div>
                        </div>
                        <br />
                        <div class="box-body table-responsive no-padding">
                            <div class="col-xs-4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="240px"
                                GridLines="None" CssClass="table table-bordered " BorderWidth="0px" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="id" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="ParentID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="col2" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="名称">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName_CHS" runat="server" Text='<%# Bind("col3") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="col4" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="开启权限">
                                        <HeaderTemplate>
                                            <span aria-hidden="true" style="text-align: center;">开启权限</span><br></br>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" Checked="true"
                                                Style="margin: 0 42%" data-toggle="tooltip" data-placement="center"></asp:CheckBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbUse" runat="server" Width="80px" Style="text-align: center;"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                            <div class="col-xs-4">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="240px"
                                GridLines="None" CssClass="table table-bordered " BorderWidth="0px" OnRowDataBound="GridView2_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="id" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="ParentID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="col2" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="名称">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName_CHS" runat="server" Text='<%# Bind("col3") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="col4" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="开启权限">
                                        <HeaderTemplate>
                                            <span aria-hidden="true" style="text-align: center;">开启权限</span><br></br>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" Checked="true"
                                                Style="margin: 0 42%" data-toggle="tooltip" data-placement="center"></asp:CheckBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbUse" runat="server" Width="80px" Style="text-align: center;"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                            <div class="col-xs-4">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="240px"
                                GridLines="None" CssClass="table table-bordered " BorderWidth="0px" OnRowDataBound="GridView3_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="id" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="ParentID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="col2" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="名称">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName_CHS" runat="server" Text='<%# Bind("col3") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="col4" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="开启权限">
                                        <HeaderTemplate>
                                            <span aria-hidden="true" style="text-align: center;">开启权限</span><br></br>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" Checked="true"
                                                Style="margin: 0 42%" data-toggle="tooltip" data-placement="center"></asp:CheckBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbUse" runat="server" Width="80px" Style="text-align: center;"/>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                            
                        </div>
                        <div class="row">
                        </div>
                    </div>
                </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
