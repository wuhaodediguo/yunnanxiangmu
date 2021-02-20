<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="pinzhongEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.BaseData.pinzhongEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">

        <section class="content-header">
          <h1>
            品名编辑
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
                <div class="col-md-6 form-group" runat="server" id="divColumn3" >
                    <label><asp:Label ID="lblColumn3" runat="server" Text="品名"></asp:Label></label>
                    <asp:TextBox ID="txtpinming" runat="server" CssClass="form-control"></asp:TextBox>
                   
                  </div>

                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="使用标记"></asp:Label></label>
                    <asp:DropDownList ID="ddlIE" runat="server" CssClass="form-control" >
                        <asp:ListItem Selected="True" Value="1">销售使用</asp:ListItem>
                        <asp:ListItem Value="2">收购使用</asp:ListItem>
                        <asp:ListItem Value="3">不使用</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group" runat="server" id="div1" >
                    <label><asp:Label ID="Label2" runat="server" Text="备注"></asp:Label></label>
                    <asp:TextBox ID="txtremark" runat="server" CssClass="form-control"></asp:TextBox>
                   
                  </div>

                  
                  
                  
              </div>
            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click" CausesValidation="false"></asp:Button>
                  
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
