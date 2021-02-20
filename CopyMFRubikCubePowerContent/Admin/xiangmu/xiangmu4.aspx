<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="xiangmu4.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.xiangmu4" %>

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
 .td2{   

            white-space: nowrap;/*控制单行显示*/   

            overflow: hidden;/*超出隐藏*/   

            text-overflow: ellipsis;/*隐藏的字符用省略号表示*/   

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
            document.getElementById("<%=txtcol6.ClientID %>").value = "";
            return false;
        }
 </script>
    <asp:TextBox ID="hdtemp" runat="server" class="form-control" Style="display: none"></asp:TextBox>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                项目管理&gt;项目关闭管理
                <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        
        <div class="main_con">
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
                        <a runat="server" id="div0046" href="xiangmu8_1.aspx">
                        <font color="blue">
                            <asp:Label ID="Label1" runat="server" Text="项目月报管理" Font-Size="14px"></asp:Label></font></a></dd>
                </dl>
            </div>
            <div class="col-sm-10" style="width: 88%;height:600px;">
            
            <div class="panel panel-default" style="width: 100%; height:600px; overflow: auto; margin-top: -5px;background-color:transparent;">
                <div id="AlertDiv" runat="server">
                </div>
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom:0px; height: 35px; font-size: 10px;background-color: RGB(217,237,247); ">
                    <h4 class="panel-title" >
                       <strong><font color="blue" size="2px" font-weight="bold">项目资料管理列表</font></strong> </h4>
                       
                    </div>
                <div class="panel panel-default" style="margin: 0px auto; font-size: 12px; width: 100%;">
                    <div class="panel-heading" style="text-align:right; margin-top:0px; height:25px; " data-toggle="collapse" data-target="#SearchArea">
                        <h5  style="text-align:right; margin-top:-5px;  font-size:12px">
                            高级检索</h5>
                    </div>
                    <div id="SearchArea" class="collapse">
                         <div class="panel-body" style="margin: -10px auto; font-size: 12px;" >
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm"
                                            Width="120px" Text="建设单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol1" TabIndex="11" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="施工单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                   <td colspan="3">
                                        <asp:TextBox ID="txtcol2" TabIndex="12" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    
                                    
                                     
                                </tr>
                                <tr>
                                    
                                    <td >
                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol3" TabIndex="11" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtcol4" TabIndex="12" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol5" TabIndex="13" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="项目编码：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtcol6" TabIndex="13" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="发票类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol7" TabIndex="13" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="项目状态：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="Dropcol8" TabIndex="13" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>正常</asp:ListItem>
                                            <asp:ListItem>关闭</asp:ListItem>
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
                    
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button3" runat="server" Text="项目关闭" CssClass="btn11" Width="55px"  OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn项目关闭_Click" />
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button4" runat="server" Text="项目开启" CssClass="btn11" Width="55px" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                        OnClick="btn项目开启_Click" />
                    </div>
                    
                </div>
                <div class="panel panel-default" style="width: 100%; overflow: auto; margin-top: 10px;">
                    <div class="table-responsive" style="width: 100%">
                        <asp:GridView ID="GridView1" runat="server" Font-Size="12px" HeaderStyle-Height="10px" Height="10px" RowStyle-Height="10px"  AutoGenerateColumns="False"  BorderWidth="0px"  CssClass="table table-bordered " AllowSorting="True"
                         OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                        <HeaderStyle HorizontalAlign="Center" CssClass="info" VerticalAlign="Middle" Height="5px"  />
                        <RowStyle HorizontalAlign="Center" CssClass="" VerticalAlign="Middle" Height="5px"  />
                            <Columns>
                                <asp:TemplateField HeaderText="ID"  Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="勾选" HeaderStyle-CssClass="text-center">
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
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="30px" Height="20px" style=" text-align:center;"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同名称" HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        
                                        <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>' Width="130px"  style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同编号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>' Width="130px"  style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="合同金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col3") %>' Width="120px"  style=" text-align:center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="建设单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>' Width="180px"  style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="施工单位" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>' Width="150px"  style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目部" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>' Width="130px"  style=" text-align:center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目经理" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col7") %>' Width="100px"  style=" text-align:center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col8") %>' Width="120px"  style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目编码"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col9") %>' Width="120px"  style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单项工程名称"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol10" runat="server" Text='<%# Bind("col10") %>' CssClass="td2" Width="300px" ToolTip='<%# Bind("col10") %>' style=" text-align:left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算类型" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol31" runat="server" Text='<%# Bind("col31") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol34" runat="server" Text='<%# Bind("col11") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol35" runat="server" Text='<%# Bind("col12") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol341" runat="server" Text='<%# Bind("col13") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结算金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol351" runat="server" Text='<%# Bind("col14") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审定金额不含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol342" runat="server" Text='<%# Bind("col15") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol352" runat="server" Text='<%# Bind("col16") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol343" runat="server" Text='<%# Bind("col17") %>' Width="100px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审定金额含税" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol353" runat="server" Text='<%# Bind("col18") %>' Width="100px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票金额"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol16" runat="server" Text='<%# Bind("col16") %>' Width="100px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="货物、服务名称"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol17" runat="server" Text='<%# Bind("col17") %>' Width="100px"  style=" text-align:left;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票类型"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol18" runat="server" Text='<%# Bind("col18") %>' Width="100px"  style=" text-align:left;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发票类别"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol19" runat="server" Text='<%# Bind("col19") %>' Width="100px"  style=" text-align:left;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="税率"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol20" runat="server" Text='<%# Bind("col20") %>' Width="100px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开票日期"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol21" runat="server" Text='<%# Bind("col21") %>' Width="110px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="到账金额"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol27" runat="server" Text='<%# Bind("col27") %>' Width="100px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <%--<asp:TemplateField HeaderText="到账日期"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol28" runat="server" Text='<%# Bind("col28") %>' Width="110px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="未到账金额"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol29" runat="server" Text='<%# Bind("col29") %>' Width="100px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="项目状态"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol30" runat="server" Text='<%# Bind("col30") %>' Width="100px"  style=" text-align:center;"
                                            autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol15" runat="server" Text='<%# Bind("col21") %>' Width="150px"  style=" text-align:left;"
                                            autocomplete="off"></asp:Label>
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

