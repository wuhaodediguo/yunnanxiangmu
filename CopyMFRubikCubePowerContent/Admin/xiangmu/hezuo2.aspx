<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="hezuo2.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.hezuo2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
     .main_conL222 dl dd {
    width: 220px;
    height: 20px;
    margin-top: 10px;
    margin-left: 20px;
}
.btn22 {
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
  background-color:RGB(60,141,188); 
  border: 1px solid transparent; color: #fff;
  width:35px; text-align:center; height:25px; font-size:12px;
}
.btn11{
   background-color:transparent;         
   border:0px;
   width:35px; text-align:center; height:25px; font-size:14px;
   color: #9933FF;
}
.button {
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
        function cleanForm() {

            document.getElementById("<%=txtcol1.ClientID%>").value = "";
            document.getElementById("<%=txtcol2.ClientID %>").value = "";
            document.getElementById("<%=txtcol3.ClientID %>").value = "";
            document.getElementById("<%=txtcol4.ClientID %>").value = "";
            document.getElementById("<%=txtcol5.ClientID %>").value = "";
            document.getElementById("<%=Dropcol6.ClientID %>").value = "";
            return false;
        }
 </script>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height: 35px; margin-top: -10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                合作管理&gt;施工队伍管理 <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        <div class="main_con">
            <div class="main_conL222" style="width: 12%;background-color: RGB(155,194,230);
                font-size: 14px;">
                <dl style="width: 120px; height: 100%;">
                    <dd runat="server" id="dd0051">
                        <a runat="server" id="div0051" href="hezuo1.aspx"><font color="blue">
                            <asp:Label ID="lblcol5" runat="server" Text="合作单位管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0052">
                        <a runat="server" id="div0052" href="hezuo2.aspx"><font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="施工队伍管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0053">
                        <a runat="server" id="div0053" href="hezuo3.aspx"><font color="blue">
                            <asp:Label ID="Label3" runat="server" Text="施工队结算管理" Font-Size="14px"></asp:Label></font></a></dd>
                    <dd runat="server" id="dd0054">
                        <a runat="server" id="div0054" href="hezuo4.aspx"><font color="blue">
                            <asp:Label ID="Label4" runat="server" Text="施工队结算明细" Font-Size="14px"></asp:Label></font></a></dd>
                      <dd runat="server" id="dd0055">
                        <a runat="server" id="div0055" href="hezuo5.aspx"><font color="blue">
                            <asp:Label ID="Label42" runat="server" Text="施工队项目明细" Font-Size="14px"></asp:Label></font></a></dd>
                </dl>
            </div>
            <div class="col-sm-12" style="width: 88%; height: 600px;">
                <div class="panel panel-default" style="width: 100%; height: 600px; overflow: auto;
                    margin-top: -5px; background-color: transparent;">
                    <div id="AlertDiv" runat="server">
                    </div>
                    <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom: 0px;
                        height: 35px; font-size: 10px; background-color: RGB(217,237,247);">
                        <h4 class="panel-title">
                            <strong><font color="blue" size="2px" font-weight="bold">施工队伍管理列表</font></strong>
                        </h4>
                    </div>
                    <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; width: 100%;">
                        <div class="panel-heading" style="text-align: right; margin-top: 0px; height: 25px;"
                            data-toggle="collapse" data-target="#SearchArea">
                            <h5 style="text-align: right; margin-top: -5px; font-size: 12px">
                                高级检索</h5>
                        </div>
                        <div id="SearchArea" class="collapse">
                            <div class="panel-body" style="margin: -10px auto; font-size: 12px;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="120px"
                                                Text="施工队长姓名：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcol1" TabIndex="11" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="120px"
                                                Text="施工队长电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtcol2" TabIndex="12" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="120px"
                                                Text="项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcol3" TabIndex="11" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="120px"
                                                Text="施工区域：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtcol4" TabIndex="12" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="120px"
                                                Text="施工队成员：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcol5" TabIndex="13" Style="margin-left: 0px" Width="400px" runat="server"
                                                class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" Width="120px"
                                                Text="施工能力：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                                border: 0; margin-left: 0px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="Dropcol6" TabIndex="13" Style="margin-left: 0px"  Width="400px"
                                            runat="server" class="form-control input-sm" autocomplete="off">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>优秀</asp:ListItem>
                                                <asp:ListItem>中等</asp:ListItem>
                                                <asp:ListItem>一般</asp:ListItem>
                                                <asp:ListItem>较差</asp:ListItem>
                                                <asp:ListItem>列入黑名单</asp:ListItem>
                                            </asp:DropDownList>
                                           
                                        </td>
                                    </tr>
                                </table>
                                <div class="row" style="margin: 5px auto; font-size: 9px; width: 100%; height: 50%;">
                                <div class="col-sm-1 col-sm-offset-5">
                                    <asp:Button ID="Button2" runat="server" Text="查询" CssClass="btn22" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                        OnClick="btn查询_Click" />
                                </div>
                                <div class="col-sm-1 ">
                                    <asp:Button ID="Button6" runat="server" Text="清空" CssClass="btn22" style="margin-left:30px" OnClientClick="return cleanForm()" />
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin: 5px auto; font-size: 12px; width: 100%;">
                        <div id="Div1" class="col-sm-2" runat="server" visible="false">
                            <div class="btn btn-default btn-file" runat="server" id="divUpload">
                                <i class="fa fa-upload"></i>选择上传文件
                                <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                            </div>
                        </div>
                        <div class="col-sm-1  " runat="server" id="div01" >
                            <asp:Button ID="Button1" runat="server" Text="导入" CssClass="btn11"  OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btnUpload_Click" />
                        </div>
                        <div class="col-sm-1 " runat="server" id="div02" >
                            <asp:Button ID="btnAdd" runat="server" Text="新建" CssClass="btn11"  OnClick="btnAdd_Click"
                                OnClientClick="RotateAnimation(this); return ShowProgressBar();"></asp:Button>
                        </div>
                        <div class="col-sm-1 ">
                            <asp:Button ID="Button3" runat="server" Text="编辑" CssClass="btn11"  OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn编辑_Click" />
                        </div>
                        <div class="col-sm-1 ">
                            <asp:Button ID="Button4" runat="server" Text="导出" CssClass="btn11" OnClick="btnExport_Click" />
                        </div>
                        <div class="col-sm-1 ">
                            <asp:Button ID="Button5" runat="server" Text="删除" CssClass="btn11"  OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                                OnClick="btn删除_Click" />
                        </div>
                       
                    </div>
                    <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 10px;">
                        <div class="table-responsive" style="width: 100%">
                            <asp:GridView ID="GridView1" runat="server" Font-Size="12px" HeaderStyle-Height="10px"
                            Height="10px" AutoGenerateColumns="False" BorderWidth="0px"
                                 CssClass="table table-bordered " AllowSorting="True"
                                OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                                OnRowCreated="GridView1_RowCreated">
                                <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px" />
                                <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="勾选" HeaderStyle-CssClass="text-center" >
                                     <ItemStyle VerticalAlign="Middle"></ItemStyle>
                                     <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);"
                                        Style="margin: 0 20%" data-toggle="tooltip" data-placement="center" >
                                    </asp:CheckBox>
                                     </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" Width="30px"  style=" text-align:center;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="序号" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="30px"
                                                Style="text-align: center;"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长姓名" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='' ></asp:HyperLink>
                                            <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>' Width="90px" Visible="false" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长电话" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>' Width="90px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长身份证号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col3") %>' Width="130px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长出生日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>' Width="110px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长身份地址" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>' Width="150px" Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工区域" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>' Width="150px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工专业" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col7") %>' Width="100px" Style="text-align: Left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="项目部" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>' Width="120px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="项目经理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col9") %>' Width="120px" Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队成员" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol10" runat="server" Text='<%# Bind("col10") %>' Width="100px"
                                                Style="text-align: left;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工能力" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Width="70px" Text='<%# Bind("col11") %>' Style="text-align: center;"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("col12") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblcol11" runat="server" Width="150px" Visible="false" Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="创建人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol13" runat="server" Text='<%# Bind("col13") %>' Width="120px"
                                                Style="text-align: center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="创建日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol14" runat="server" Text='<%# Bind("col14") %>' Width="110px"
                                                Style="text-align: center;" autocomplete="off"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长身份证件" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lbtn1" runat="server"   Text="下载" Width="120px"
                                                         CommandName="lbtn11">
                                                         </asp:LinkButton>
                                            <asp:CheckBox ID="Chk施工队长身份证件" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                            <asp:HyperLink ID="HyperLinkcol15" runat="server" NavigateUrl='<%# Eval("col15") %>'
                                                Target="_blank" Width="120px" Style="text-align: center;"  Visible="false">下载</asp:HyperLink>
                                            <asp:Label ID="lbl施工队长身份证件" Visible="false" runat="server" Text='<%# Bind("col15") %>'></asp:Label>
                                            <asp:Label ID="Label施工队长身份证件" Visible="false" runat="server" Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="施工队长照片" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lbtn2" runat="server"   Text="下载" Width="120px"
                                                         CommandName="lbtn12">
                                                         </asp:LinkButton>
                                            <asp:CheckBox ID="Chk施工队长照片" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                            <asp:HyperLink ID="HyperLinkcol16" runat="server" NavigateUrl='<%# Eval("col16") %>'
                                                Target="_blank" Width="120px" Style="text-align: center;"  Visible="false">下载</asp:HyperLink>
                                            <asp:Label ID="lbl施工队长照片" Visible="false" runat="server" Text='<%# Bind("col16") %>'></asp:Label>
                                            <asp:Label ID="Label施工队长照片" Visible="false" runat="server" Width="120px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcol17" runat="server" Text='<%# Bind("col17") %>' Width="150px"
                                                Style="text-align: left;" autocomplete="off"></asp:Label>
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
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
