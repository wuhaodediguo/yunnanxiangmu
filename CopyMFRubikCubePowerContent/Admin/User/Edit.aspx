<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.User.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<style>
        .main_conL222
        {
            float: left;
            width: 220px;
            height: 640px;
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
            font-size: 9px;
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
               <div id="AlertDiv" runat="server"></div>
                <div class="box box-default">
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
              </h3>
            </div>

            <div class="box-body">
              <div class="row">

                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="电话"></asp:Label></label>
                    <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="真实姓名"></asp:Label></label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
             
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label12" runat="server" Text="角色"></asp:Label></label>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-4 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="全部项目部" ></asp:Label></label>
                    <asp:ListBox ID="ListBox项目部" runat="server" SelectionMode="Multiple" Width="300" Height="280">
                    
                    </asp:ListBox>
                  </div>
                  <div class="col-md-4 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="所属项目部" ></asp:Label></label>
                    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="300" Height="280" >
                    
                    </asp:ListBox>
                  </div>

                  <div class="col-md-2 form-group" style=" margin-left:-40px">
                                        <asp:Button ID="Button11" runat="server" Text="添加" CssClass="btn btn-primary" OnClick="btnSave11_Click">
                                        </asp:Button>
                                        <asp:Button ID="Button12" runat="server" Text="删除" CssClass="btn btn-primary" OnClick="btndel11_Click">
                                        </asp:Button>
                                    </div>
               <%--   <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label13" runat="server" Text="工资"></asp:Label></label>
                    <asp:TextBox ID="txtWages" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label14" runat="server" Text="入职时间"></asp:Label></label>
                    <asp:TextBox ID="txtEntryTime" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label20" runat="server" Text="生日"></asp:Label></label>
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label15" runat="server" Text="皮肤"></asp:Label></label>
                    <asp:DropDownList ID="ddlSkin" runat="server" CssClass="form-control select2">
                        <asp:ListItem Text="经典蓝" Value="blue" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="青草绿" Value="green"></asp:ListItem>
                        <asp:ListItem Text="中国红" Value="red"></asp:ListItem>
                        <asp:ListItem Text="商务黄" Value="yellow"></asp:ListItem>
                        <asp:ListItem Text="高贵紫" Value="purple"></asp:ListItem>
                    </asp:DropDownList>
                  </div>--%>
                  
              </div>
              
              <div id="EditDiv" runat="server" class="row" visible="false">
              
                  <hr />
              
                 <%--<div class="col-md-6 form-group">
                    <label><asp:Label ID="Label17" runat="server" Text="头像"></asp:Label></label>
                    <div class="user-edit-image"><asp:Image ID="imgPortrait" runat="server"></asp:Image></div>
                    <div class="form-group">
                        <div class="btn btn-default btn-file">
                            <i class="fa fa-upload"></i> 上传头像
                            <asp:FileUpload ID="fuPortrait" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgPortrait);"></asp:FileUpload>
                        </div>
                        <p class="help-block">尺寸在512*512以内，大小在500KB以内</p>
                    </div>
                  </div>--%>
                  
                  <div id="Div2" class="col-md-6 form-group" runat="server" visible="false">
                    <label><asp:Label ID="Label19" runat="server" Text="重置密码"></asp:Label></label>
                    <br />
                    <asp:CheckBox ID="cbResetPsw" runat="server"></asp:CheckBox>
                    
                  </div>
                  
              </div>

            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
                <%-- <asp:Button ID="Button1" runat="server" Text="批量导入" CssClass="btn btn-primary"></asp:Button>
                  <asp:Button ID="Button2" runat="server" Text="查询" CssClass="btn btn-primary"></asp:Button>
                 <asp:Button ID="Button3" runat="server" Text="导出表格" CssClass="btn btn-primary"></asp:Button>--%>
            </div>

          </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>


</asp:Content>




