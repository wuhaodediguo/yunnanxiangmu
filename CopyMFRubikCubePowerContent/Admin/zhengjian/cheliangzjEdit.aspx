<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="cheliangzjEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.cheliangzjEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="content-wrapper">
    
        <section class="content-header">
          <h1>
            车辆证件管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">车辆证件管理</li>
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
                    <label><asp:Label ID="Label1" runat="server" Text="州市"></asp:Label></label>
                    <asp:Dropdownlist ID="Drop州市" runat="server" CssClass="form-control"></asp:Dropdownlist>
                  </div>
                  
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="所属项目部"></asp:Label></label>
                    <asp:Dropdownlist ID="Drop所属项目部" runat="server" CssClass="form-control"></asp:Dropdownlist>
                  </div>
                  
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="车主姓名"></asp:Label></label>
                    <asp:TextBox ID="txt车主姓名" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label7" runat="server" Text="车牌号码"></asp:Label></label>
                    <asp:TextBox ID="TextBox车牌号码" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label16" runat="server" Text="发动机号码"></asp:Label></label>
                    <asp:TextBox ID="TextBox发动机号码" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                   <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label17" runat="server" Text="车辆类型"></asp:Label></label>
                    <asp:TextBox ID="TextBox车辆类型" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                   <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label18" runat="server" Text="品牌型号"></asp:Label></label>
                    <asp:TextBox ID="TextBox品牌型号" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label19" runat="server" Text="制造商"></asp:Label></label>
                    <asp:TextBox ID="TextBox制造商" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label20" runat="server" Text="购置年份"></asp:Label></label>
                    <asp:TextBox ID="TextBox购置年份" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                  
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label9" runat="server" Text="检验有效期"></asp:Label></label>
                    <asp:TextBox ID="txt检验有效期" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" AutoPostBack="true" OnTextChanged="txt检验有效期_TextChanged"></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label10" runat="server" Text="是否到期"></asp:Label></label>
                    <asp:TextBox ID="txt是否到期" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label11" runat="server" Text="租车协议到期时间"></asp:Label></label>
                    <asp:TextBox ID="txt租车协议到期时间" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" AutoPostBack="true" OnTextChanged="txt租车协议到期时间_TextChanged"></asp:TextBox>
                  </div>
                   <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="是否到期"></asp:Label></label>
                    <asp:TextBox ID="txt租车协议到期时间是否到期" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                  <div class="col-md-4 form-group">
                    <label><asp:Label ID="Label12" runat="server" Text="备注"></asp:Label></label>
                    <asp:TextBox ID="txt备注" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                   
                  
                 
    
                 
                
           
   
              </div>
         <div class="row">
            <div class="col-md-4 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="行车证储存位置"></asp:Label></label>
                    <asp:TextBox ID="txt行车证储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="行车证"></asp:Label></label>
                     <div  runat="server" id="div1">
                  <div >
                 <asp:FileUpload ID="MyFileUpload" runat="server" /> 
        
                    <asp:Button ID="FileUploadButton" runat="server" Text="上传" 
                    onclick="FileUpload行车证Button_Click" />
                     <a href="" runat="server" id="行车证href" target="_blank"  >行车证附件</a>
                   
            </div>
                    
                 </div>
       
                    </div>
         </div>
         <div class="row">
            <div class="col-md-4 form-group">
                    <label><asp:Label ID="Label14" runat="server" Text="车辆照片储存位置"></asp:Label></label>
                    <asp:TextBox ID="TextBox车辆照片储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label8" runat="server" Text="车辆照片"></asp:Label></label>
                     <div  runat="server" id="div2">
                  <div >
                 <asp:FileUpload ID="FileUpload1" runat="server" /> 
        
                    <asp:Button ID="Button1" runat="server" Text="上传" 
                    onclick="FileUpload车辆照片Button_Click" />
                    <a href="" runat="server" id="车辆照片href" target="_blank"  >车辆照片附件</a>
                    
            </div>
                    
                 </div>
       
                    </div>
         </div>
         <div class="row">
             <div class="col-md-4 form-group">
                    <label><asp:Label ID="Label15" runat="server" Text="租车协议储存位置"></asp:Label></label>
                    <asp:TextBox ID="TextBox租车协议储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                     <div class="col-md-2 form-group">
                    <label><asp:Label ID="Label13" runat="server" Text="租车协议"></asp:Label></label>
                     <div  runat="server" id="div3">
                  <div >
                 <asp:FileUpload ID="FileUpload2" runat="server" /> 
        
                    <asp:Button ID="Button2" runat="server" Text="上传" 
                    onclick="FileUpload租车协议Button_Click" />
                    <a href="" runat="server" id="租车协议href" target="_blank"  >租车协议附件</a>
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
