<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="SMSEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.SMS.SMSEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
           短信通知录入
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">短信通知录入</li>
          </ol>
        </section>

        <section class="content">

          <div id="AlertDiv" runat="server"></div>

          <div class="box box-default">

            <div class="box-body">
              <div class="row">
                <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="手机号"></asp:Label></label>
                    <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtPhoneNum" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                  </div>
                 <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label12" runat="server" Text="运单号"></asp:Label></label>
                    <asp:TextBox ID="txtLogisticsNo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ControlToValidate="txtLogisticsNo" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                  </div>
                 
              </div>
 
            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="发送" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click" CausesValidation="false"></asp:Button>
                 <asp:Button ID="btnDownloadTemplate" runat="server" Text="下载模板" CssClass="btn btn-link" onclick="btnDownloadTemplate_Click" CausesValidation="false"></asp:Button>
                <div class="btn btn-default btn-file" runat="server" id="divUpload">
                   <i class="fa fa-upload"></i> 选择上传文件
                  <asp:FileUpload ID="fuPortrait" runat="server"></asp:FileUpload>
                 </div>
                 <asp:Button ID="btnUpload" runat="server" Text="批量导入" CssClass="btn btn-primary" onclick="btnUpload_Click" CausesValidation="false"></asp:Button>
              
            </div>

          </div>

        </section>

      </div>

</asp:Content>
