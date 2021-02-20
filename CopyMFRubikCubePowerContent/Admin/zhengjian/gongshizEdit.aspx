<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="gongshizEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.gongshizEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="content-wrapper">
    
        <section class="content-header">
          <h1>
            公司证件管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">公司证件管理</li>
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

                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="证件类别"></asp:Label></label>
                    <asp:TextBox ID="txt证件类别" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-3 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="证件名称"></asp:Label></label>
                    <asp:TextBox ID="txt证件名称" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="证件编号"></asp:Label></label>
                    <asp:TextBox ID="txt证件编号" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-3 form-group">
                    <label><asp:Label ID="Label9" runat="server" Text="发证机关"></asp:Label></label>
                    <asp:TextBox ID="txt发证机关" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                
                 
                
           
   
              </div>
                <div class="row">
                         <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label10" runat="server" Text="发证日期"></asp:Label></label>
                    <asp:TextBox ID="txt发证日期" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label11" runat="server" Text="到期时间"></asp:Label></label>
                    <asp:TextBox ID="txt到期时间" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                  </div>
                   <div class="col-md-1 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="有效期限"></asp:Label></label>
                    <asp:TextBox ID="txt有效期限" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                   <div class="col-md-5 form-group">
                    <label><asp:Label ID="Label12" runat="server" Text="备注"></asp:Label></label>
                    <asp:TextBox ID="txt备注" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>  
                   <div class="row">
                   <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="存储位置"></asp:Label></label>
                    <asp:TextBox ID="txt存储位置" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  

                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="公司证件"></asp:Label></label>
                     <div  runat="server" id="div1">
                 
                  
                  <div >
                 <asp:FileUpload ID="MyFileUpload" runat="server" /> 
        
                    <asp:Button ID="FileUploadButton" runat="server" Text="上传" 
                    onclick="FileUploadButton_Click" />
                    <a href="" runat="server" id="公司证件href" target="_blank"  >公司证件附件</a>
                    
            </div>
                    
                 </div>
       
                    </div>
                </div>
    

            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                
            </div>

          </div>

        </section>

    </div>
</asp:Content>
