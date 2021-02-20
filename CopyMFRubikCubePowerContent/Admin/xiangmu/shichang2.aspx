<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="shichang2.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.shichang2" %>

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
            document.getElementById("<%=txtcol6.ClientID %>").value = "";
            return false;
        }
 </script>
    <div class="mainWrap clearfix">
        <div class="main_tit" style="height:35px; margin-top:-10px;">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
                市场管理&gt;中标管理 <em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        <div class="main_con">
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
            <div class="col-sm-10" style="width: 88%;height:600px;">
            <div class="panel panel-default" style="width: 100%; height:600px; overflow: auto; margin-top: -5px;background-color:transparent;">
                <div id="AlertDiv" runat="server">
                </div>
                <div class="panel-heading" style="text-align: center; margin-top: 0px; margin-bottom:0px; height: 35px; font-size: 10px;background-color: RGB(217,237,247); ">
                    <h4 class="panel-title" >
                       <strong><font color="blue" size="2px" font-weight="bold">中标管理列表</font></strong> </h4>
                       
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
                                            Width="120px" Text="招标人名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol1" TabIndex="11" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="招标代理机构：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
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
                                            Width="120px" Text="招标项目名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol3" TabIndex="11" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="招标编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
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
                                            Width="120px" Text="中标人名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcol5" TabIndex="13" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" 
                                            Width="120px" Text="中标年份：" Font-Bold="true" ReadOnly="true" Style="text-align: right;
                                            background-color: RGB(214,220,228); border: 0; margin-left: 0px;"></asp:TextBox>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtcol6" TabIndex="13" Style="margin-left: 0px"  Width="430px"
                                            runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy年'})"></asp:TextBox>
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
                    <div class="col-sm-1  ">
                        <asp:Button ID="Button1" runat="server" Text="导入" CssClass="btn11" OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btnUpload_Click" />
                    </div>
                    <div class="col-sm-1 " >
                        <asp:Button ID="btnAdd" runat="server"  Text="新建"  CssClass="btn11" OnClick="btnAdd_Click"
                            OnClientClick="RotateAnimation(this); return ShowProgressBar();"></asp:Button>
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button3" runat="server" Text="编辑" CssClass="btn11"  OnClientClick="RotateAnimation(this); return ShowProgressBar();"
                            OnClick="btn编辑_Click" />
                    </div>
                    <div class="col-sm-1 ">
                        <asp:Button ID="Button4" runat="server" Text="导出" CssClass="btn11"  OnClick="btnExport_Click" />
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
                                <asp:TemplateField HeaderText="序号"  HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl序号" runat="server" Text=' <%# Container.DataItemIndex + 1 %>' Width="30px"
                                            Style="text-align: center;"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="年份"  HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol1" runat="server" Text='<%# Bind("col1") %>' Width="50px" Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="招标人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    >
                                    <ItemTemplate>
                                        
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Bind("col2") %>' Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="招标代理机构" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Bind("col3") %>' Width="220px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="招标项目名称" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                    >
                                    <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='' ></asp:HyperLink>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Bind("col4") %>' Visible="false"  Width="220px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="招标编号" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Bind("col5") %>' Width="150px" Style="text-align: left;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="招标方式" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol6" runat="server" Text='<%# Bind("col6") %>' Width="150px" Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中标人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol7" runat="server" Text='<%# Bind("col24") %>' Width="120px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中标公示日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol8" runat="server" Text='<%# Bind("col25") %>' Width="120px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中标通知书领取日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol9" runat="server" Text='<%# Bind("col26") %>' Width="110px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中标标段" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol10" runat="server" Text='<%# Bind("col27") %>' Width="150px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="缴纳中标服务费金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol11" runat="server" Text='<%# Bind("col28") %>' Width="150px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="缴纳中标服务费日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol12" runat="server" Text='<%# Bind("col29") %>' Width="110px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中标服务费发票领取时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol13" runat="server" Text='<%# Bind("col30") %>' Width="150px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="缴纳履约保证金金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol14" runat="server" Text='<%# Bind("col31") %>' Width="150px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="缴纳履约保证金形式" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol15" runat="server" Text='<%# Bind("col32") %>' Width="120px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="缴纳履约保证金时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol16" runat="server" Text='<%# Bind("col33") %>' Width="130px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="缴纳履约保证金到期时间" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol43" runat="server" Text='<%# Bind("col43") %>' Width="150px"
                                            Style="text-align: center;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="履约保函开具银行" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol17" runat="server" Text='<%# Bind("col34") %>' Width="120px"
                                            Style="text-align: left;" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="履约保证金退还金额" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol18" runat="server" Text='<%# Bind("col35") %>' Width="120px"
                                            CssClass="text-center" autocomplete="off"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="履约保证金/保函退还日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol19" runat="server" Text='<%# Bind("col36") %>' Width="140px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建人" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol40" runat="server" Text='<%# Bind("col40") %>' Width="90px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="创建日期" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="center"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol41" runat="server" Text='<%# Bind("col41") %>' Width="110px"
                                            Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中标通知书" HeaderStyle-CssClass="text-center" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk中标通知书" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                        <asp:LinkButton ID="lbtn1" runat="server"   Text="下载" Width="120px"
                                                         CommandName="lbtn11">
                                                         </asp:LinkButton>
                                        <asp:HyperLink ID="HyperLinkcol20" runat="server" NavigateUrl='<%# Eval("col37") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:Label ID="lbl中标通知书" Visible="false" runat="server" Text='<%# Bind("col37") %>'></asp:Label>
                                        <asp:Label ID="Label中标通知书" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="履约保证金/保函" HeaderStyle-CssClass="text-center" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk履约保证金保函" runat="server" Visible="false" Width="120px"></asp:CheckBox>
                                         <asp:LinkButton ID="lbtn2" runat="server" Text="下载" Width="120px"
                                                         CommandName="lbtn12">
                                            </asp:LinkButton>
                                        <asp:HyperLink ID="HyperLinkcol21" runat="server" NavigateUrl='<%# Eval("col38") %>'
                                            Target="_blank" Width="120px" Style="text-align: center;" Visible="false">下载</asp:HyperLink>
                                        <asp:Label ID="lbl履约保证金保函" Visible="false" runat="server" Text='<%# Bind("col38") %>'></asp:Label>
                                        <asp:Label ID="Label履约保证金保函" Visible="false" runat="server" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="left"
                                    >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcol23" runat="server" Text='<%# Bind("col23") %>' Width="150px"
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
