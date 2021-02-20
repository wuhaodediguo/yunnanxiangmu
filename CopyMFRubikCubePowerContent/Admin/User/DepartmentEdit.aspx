<%@ Page Language="C#" masterpagefile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.User.Admin_User_DepartmentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            部门管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">部门管理</li>
          </ol>
        </section>

        <section class="content">

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
                    <label><asp:Label ID="Label1" runat="server" Text="名称"></asp:Label></label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="电话"></asp:Label></label>
                    <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="传真"></asp:Label></label>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                                    
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="邮箱"></asp:Label></label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                      
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="地址"></asp:Label></label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="排序"></asp:Label></label>
                    <asp:TextBox ID="txtSortID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label11" runat="server" Text="上下班时间"></asp:Label></label>
                    <small class="tips">如08:00-12:00|14:00-18:00</small>
                    <asp:TextBox ID="txtWorkTime" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
              </div>
            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
            </div>

          </div>

        </section>

      </div>

</asp:Content>


