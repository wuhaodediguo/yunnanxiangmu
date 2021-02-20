<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="SurfaceSingleMaintain.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.SurfaceSingle.SurfaceSingleMaintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <script type="text/javascript">
        function EndNoChange() {
            var StartNo = document.getElementById('<%= txtStartNo.ClientID %>').value;
            var EndNo = document.getElementById('<%= txtEndNo.ClientID %>').value;
            var Amount = document.getElementById('<%= txtAmount.ClientID %>');
            if (isNaN(EndNo)) {
                return;
            }
            if (Number(EndNo) <= Number(StartNo)) {
                document.getElementById('<%= AlertDiv.ClientID %>').innerHtml = "<div class=\"alert alert-danger alert-dismissable\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>结束号不能小于开始号.</div>";
                EndNo = "";
                return;
            }
            if (StartNo) {
                Amount.value = Number(EndNo) - Number(StartNo)+1;
            }
        }

        function AmountChange() {
            var StartNo = document.getElementById('<%= txtStartNo.ClientID %>').value;
            var EndNo = document.getElementById('<%= txtEndNo.ClientID %>');
            var Amount = document.getElementById('<%= txtAmount.ClientID %>').value;
            if (isNaN(Amount)) {
                return;
            }
            if (Number(Amount) < 0) {
                document.getElementById('<%= AlertDiv.ClientID %>').innerHtml = "<div class=\"alert alert-danger alert-dismissable\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>张数不能小于0.</div>";
                EndNo = "";
                return;
            }
            if (StartNo) {
                EndNo.value = Number(StartNo) + Number(Amount)-1;
            }
        }
    </script>
      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            面单发放
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
           
          </ol>
        </section>

        <section class="content">

          <div id="AlertDiv" runat="server"></div>

          <div class="box box-default">
            

            <div class="box-body">
              <div class="row">
              
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="开始号"></asp:Label></label>
                    <asp:TextBox ID="txtStartNo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtStartNo" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ControlToValidate="txtStartNo" ErrorMessage="只能输入数字" ValidationExpression="^(-?\d+)(\.\d+)?$"/>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="结束号"></asp:Label></label>
                    <asp:TextBox ID="txtEndNo" runat="server" CssClass="form-control" onkeyup="EndNoChange()"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEndNo" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ControlToValidate="txtEndNo" ErrorMessage="只能输入数字" ValidationExpression="^(-?\d+)(\.\d+)?$"/>
                  </div>
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="张数" ></asp:Label></label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" onkeyup="AmountChange()"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtAmount" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="txtAmount" ErrorMessage="只能输入数字" ValidationExpression="^(-?\d+)(\.\d+)?$"/>
                  </div>
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="业务员"></asp:Label></label>
                    <asp:TextBox ID="txtCustomer" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtCustomer" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                  </div>
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="备注"></asp:Label></label>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
              </div>
            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click" CausesValidation="false"></asp:Button>
            </div>

          </div>

        </section>

      </div>

</asp:Content>
