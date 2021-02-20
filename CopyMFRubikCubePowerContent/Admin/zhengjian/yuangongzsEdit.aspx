<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true"
    CodeBehind="yuangongzsEdit.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.zhengjian.yuangongzsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
          <h1>
            员工证件管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Dashboard/Default.aspx"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">员工证件管理</li>
          </ol>
        </section>
        <section class="content">

          <div id="AlertDiv" runat="server"></div>

          <div class="box box-default">
          
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
                    <asp:Button ID="Button11" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
              </h3>
            </div>
            <div class="box-body"  >

            <table border="0" align="center" id="Table1" width="100%">
                <tr>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label1" runat="server" Text="个人基本资料"></asp:Label></label>
                              </div>

                        </div>

                       <div class="col-md-6 form-group">
                    <asp:Label ID="lblThumbnail" runat="server" Width="100px" Height="100px" Visible="false">
                     </asp:Label>
                    <div class="user-edit-image"><asp:Image ID="imgPortrait" runat="server" ></asp:Image></div>
                   
                    <div class="form-group">
                        <div class="btn btn-default btn-file">
                            <i class="fa fa-upload"></i> 上传头像
                            <asp:FileUpload ID="fuPortrait" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgPortrait);"></asp:FileUpload>
                        </div>
                        <p class="help-block">尺寸在512*512以内，大小在500KB以内</p>
                    </div>
                  </div>

                </td>
                <td >
                        <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label7" runat="server" Text="姓名"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TexttBox姓名" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label8" runat="server" Text="性别"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                               <asp:Dropdownlist ID="Drop性别" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                               </asp:Dropdownlist>
                                
                              
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label13" runat="server" Text="年龄"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TexttBox年龄" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label14" runat="server" Text="民族"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Drop民族" runat="server" CssClass="form-control"></asp:Dropdownlist>
                                
                              </div>
                              

                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label157" runat="server" Text="有效日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效日期" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label15" runat="server" Text="出生日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox出生日期" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label16" runat="server" Text="职务"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                              <asp:Dropdownlist ID="Drop职务" runat="server" CssClass="form-control"></asp:Dropdownlist>
                                
                              </div>
                               
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label19" runat="server" Text="州市"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Drop州市" runat="server" CssClass="form-control"></asp:Dropdownlist>
                              </div>
                        </div>
                        <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label17" runat="server" Text="身份证号"></asp:Label></label>
                              </div>
                              <div class="col-sm-3 form-group">
                                <asp:TextBox ID="TextBox身份证号" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label18" runat="server" Text="户籍所在地"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox户籍所在地" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                               
                        </div>
                         
                         <div class="row">
                              
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label20" runat="server" Text="所属项目部"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                              <asp:Dropdownlist ID="Drop所属项目部" runat="server" CssClass="form-control"></asp:Dropdownlist>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label156" runat="server" Text="备注"></asp:Label></label>
                              </div>
                              <div class="col-sm-8 form-group">
                                <asp:TextBox ID="TextBoxremark" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                            
                        </div>
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label21" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox个人基本资料储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label22" runat="server" Text="个人基本资料证件"></asp:Label></label>
                                     <div  runat="server" id="div2">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="MyFileUpload" runat="server" /> 
        
                                            <asp:Button ID="Button1" runat="server" Text="上传" 
                                            onclick="FileUploadButton_Click" />
                                             <a href="" runat="server" id="个人基本资料href" target="_blank"  >个人基本资料附件</a>
                    
                                           
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>

                </tr>

                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label2" runat="server" Text="学历信息"></asp:Label></label>
                              </div>
                             
                              
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label3" runat="server" Text="毕业院校"></asp:Label></label>
                              </div>
                              <div class="col-sm-3 form-group">
                                <asp:TextBox ID="TextBox毕业院校" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                               <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label9" runat="server" Text="毕业时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox毕业时间" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              
                              
                        </div>
                        <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label6" runat="server" Text="学历"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                              <asp:Dropdownlist ID="Drop学历" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>博士</asp:ListItem>
                                <asp:ListItem>硕士</asp:ListItem>
                                <asp:ListItem>本科</asp:ListItem>
                                <asp:ListItem>大专</asp:ListItem>
                                <asp:ListItem>高中</asp:ListItem>
                                <asp:ListItem>中专</asp:ListItem>
                                <asp:ListItem>初中</asp:ListItem>
                              </asp:Dropdownlist>
                            
                              </div>
                             <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label4" runat="server" Text="专业"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                               <asp:Dropdownlist ID="Drop专业" runat="server" CssClass="form-control"></asp:Dropdownlist>
                           
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label10" runat="server" Text="学历真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist学历真假" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                              </asp:Dropdownlist>
                               
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label11" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                                
                              </div>
                              
                        </div>
     
                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label25" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox学历信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label26" runat="server" Text="学历信息证件"></asp:Label></label>
                                     <div  runat="server" id="div1">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload学历信息" runat="server" /> 
        
                                            <asp:Button ID="Button2" runat="server" Text="上传" 
                                            onclick="FileUpload学历信息Button_Click" />
                                            <a href="" runat="server" id="学历信息href" target="_blank"  >学历信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label5" runat="server" Text="劳动合同信息"></asp:Label></label>
                              </div>
                             
                              
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label12" runat="server" Text="合同签订日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox合同签订日期ht" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label23" runat="server" Text="合同年限"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox合同年限ht" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label32" runat="server" Text="合同到期日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox合同到期日期ht" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                        </div>
                        <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label24" runat="server" Text="续签日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox续签日期ht" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label27" runat="server" Text="续签年限"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox续签年限ht" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label28" runat="server" Text="合同真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist学历真假ht" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                              </asp:Dropdownlist>
                                
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label29" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist有无原件ht" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                               
                              </div>
                        </div>

                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label30" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox劳动合同信息储存位置ht" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label31" runat="server" Text="劳动合同信息证件"></asp:Label></label>
                                     <div  runat="server" id="div3">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload劳动合同信息" runat="server" /> 
        
                                            <asp:Button ID="Button劳动合同信息证件" runat="server" Text="上传" 
                                            onclick="FileUpload劳动合同信息Button_Click" />
                                            <a href="" runat="server" id="劳动合同信息href" target="_blank"  >劳动合同信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label33" runat="server" Text="通信类A/B/C证书信息"></asp:Label></label>
                              </div>
                             
                              
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label34" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型ABC" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label35" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号ABC" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label36" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期ABC" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label37" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期ABC" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label38" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间ABC" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label39" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关ABC" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label43" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假ABC" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label40" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件ABC" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>

                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label41" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox通信类ABC证书信息储存位置ABC" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label42" runat="server" Text="通信类A/B/C证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div4">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload员工通信类ABC证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button通信类ABC证书信息证件" runat="server" Text="上传" 
                                            onclick="FileUpload员工通信类ABC证书信息Button_Click" />
                                             <a href="" runat="server" id="员工通信类ABC证书信息附件href" target="_blank"  >员工通信类ABC证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label44" runat="server" Text="通信类职称证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label45" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型zc" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label46" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号zc" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label47" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期zc" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label48" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期zc" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label49" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间zc" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label50" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关zc" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label154" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假zc" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label52" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件zc" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
   
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label53" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox通信类职称证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label54" runat="server" Text="通信类职称证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div5">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload通信类职称证书信息证件" runat="server" /> 
        
                                            <asp:Button ID="Button通信类职称证书信息" runat="server" Text="上传" 
                                            onclick="FileUpload员工通信类职称证书信息Button_Click" />
                                             <a href="" runat="server" id="通信类职称证书信息href" target="_blank"  >通信类职称证书信息附件</a>
                    
                                          
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label55" runat="server" Text="通信类概预算证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label56" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型ys" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label57" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号ys" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label58" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期ys" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label59" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期ys" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label60" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间ys" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label61" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关ys" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label51" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假ys" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label63" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件ys" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                              
                        </div>
   
                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label64" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox通信类概预算证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label65" runat="server" Text="通信类概预算证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div6">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload通信类概预算证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button通信类概预算证书信息" runat="server" Text="上传" 
                                            onclick="FileUpload员工通信类概预算证书信息Button_Click" />
                                            <a href="" runat="server" id="通信类概预算证书信息href" target="_blank"  >通信类概预算证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label66" runat="server" Text="建筑类A/B/C证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label67" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型jz" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label68" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号jz" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label69" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期jz" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label70" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期jz" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label71" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间jz" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label72" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关jz" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                             <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label62" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假jz" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label74" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件jz" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>

                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label75" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox建筑类ABC证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label76" runat="server" Text="建筑类A/B/C证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div7">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload建筑类ABC证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button3" runat="server" Text="上传" 
                                            onclick="FileUpload员工建筑类ABC证书信息Button_Click" />
                                             <a href="" runat="server" id="建筑类ABC证书信息href" target="_blank"  >建筑类ABC证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label77" runat="server" Text="一级建造师证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label78" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型yj" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label79" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号yj" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label80" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期yj" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label81" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期yj" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label82" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间yj" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label83" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关yj" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label73" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假yj" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>

                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label85" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件yj" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>

                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label86" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox一级建造师证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label87" runat="server" Text="一级建造师证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div8">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload一级建造师证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button4" runat="server" Text="上传" 
                                            onclick="FileUpload一级建造师证书信息Button_Click" />
                                             <a href="" runat="server" id="一级建造师证书信息href" target="_blank"  >一级建造师证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label88" runat="server" Text="二级建造师证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label89" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型ej" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label90" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号ej" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label91" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期ej" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label92" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期ej" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label93" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间ej" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label94" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关ej" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label84" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假ej" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>

                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label96" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件ej" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>

                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label97" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox二级建造师证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label98" runat="server" Text="二级建造师证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div9">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload二级建造师证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button5" runat="server" Text="上传" 
                                            onclick="FileUpload二级建造师证书信息Button_Click" />
                                            <a href="" runat="server" id="二级建造师证书信息href" target="_blank"  >二级建造师证书信息附件</a>
                    
                                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label99" runat="server" Text="建筑类职称证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label100" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型jzzc" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label101" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号jzzc" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label102" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期jzzc" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label103" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期jzzc" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label104" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间jzzc" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label105" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关jzzc" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                             <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label95" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假jzzc" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>

                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label107" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件jzzc" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>

                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label108" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox建筑类职称证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label109" runat="server" Text="建筑类职称证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div10">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload建筑类职称证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button6" runat="server" Text="上传" 
                                            onclick="FileUpload建筑类职称证书信息Button_Click" />
                                            <a href="" runat="server" id="建筑类职称证书信息href" target="_blank"  >建筑类职称证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label110" runat="server" Text="建筑类技术工种证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label111" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型jzjs" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label112" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号jzjs" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label113" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期jzjs" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label114" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期jzjs" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label115" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间jzjs" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label116" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关jzjs" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label106" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假jzjs" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                               <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label118" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件jzjs" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                        </div>
                
                              
                        </div>
                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label119" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox建筑类技术工种证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label120" runat="server" Text="建筑类技术工种证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div11">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload建筑类技术工种证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button7" runat="server" Text="上传" 
                                            onclick="FileUpload建筑类技术工种证书信息Button_Click" />
                                             <a href="" runat="server" id="建筑类技术工种证书信息href" target="_blank"  >建筑类技术工种证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label121" runat="server" Text="通信类技术工种证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label122" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型txjs" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label123" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号txjs" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label124" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期txjs" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label125" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期txjs" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label126" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间txjs" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label127" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关txjs" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label117" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假txjs" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                  <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label129" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件txjs" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                              
                        </div>
                
                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label130" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox通信类技术工种证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label131" runat="server" Text="通信类技术工种证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div12">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload通信类技术工种证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button8" runat="server" Text="上传" 
                                            onclick="FileUpload通信类技术工种证书信息Button_Click" />
                                             <a href="" runat="server" id="通信类技术工种证书信息href" target="_blank"  >通信类技术工种证书信息附件</a>
                    
                             
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label132" runat="server" Text="特种作业证书信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label133" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型tz" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label134" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号tz" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label135" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期tz" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label136" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期tz" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label137" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间tz" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label138" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关tz" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label128" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假tz" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label139" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件tz" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
                
                         
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label141" runat="server" Text="储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox特种作业证书信息储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label142" runat="server" Text="特种作业证书信息证件"></asp:Label></label>
                                     <div  runat="server" id="div13">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload特种作业证书信息" runat="server" /> 
        
                                            <asp:Button ID="Button9" runat="server" Text="上传" 
                                            onclick="FileUpload特种作业证书信息Button_Click" />
                                            <a href="" runat="server" id="特种作业证书信息href" target="_blank"  >特种作业证书信息附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>

                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label140" runat="server" Text="其他证书1信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label155" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型qita01" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label158" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号qita01" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label159" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期qita01" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label160" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期qita01" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label161" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间qita01" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label162" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关qita01" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label163" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假qita01" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label164" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件qita01" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label152" runat="server" Text="其他证书1储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox其他证书1储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label153" runat="server" Text="其他证书1信息证件"></asp:Label></label>
                                     <div  runat="server" id="div14">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload其他证书1信息证件" runat="server" /> 
        
                                            <asp:Button ID="Button10" runat="server" Text="上传" 
                                            onclick="FileUpload其他证书1信息证件Button_Click" />
                                            <a href="" runat="server" id="其他证书1信息证件href" target="_blank"  >其他证书1信息证件附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label165" runat="server" Text="其他证书2信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label166" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型qita02" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label167" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号qita02" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label168" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期qita02" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label169" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期qita02" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label170" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间qita02" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label171" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关qita02" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label172" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假qita02" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label173" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件qita02" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label144" runat="server" Text="其他证书2储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox其他证书2储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label145" runat="server" Text="其他证书2信息证件"></asp:Label></label>
                                     <div  runat="server" id="div15">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload其他证书2信息证件" runat="server" /> 
        
                                            <asp:Button ID="Button1其他证书2信息证件" runat="server" Text="上传" 
                                            onclick="FileUpload其他证书2信息证件Button_Click" />
                                           <a href="" runat="server" id="其他证书2信息证件href" target="_blank"  >其他证书2信息证件附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label174" runat="server" Text="其他证书3信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label175" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型qita03" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label176" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号qita03" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label177" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期qita03" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label178" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期qita03" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label179" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间qita03" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label180" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关qita03" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label181" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假qita03" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label182" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件qita03" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label146" runat="server" Text="其他证书3储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox其他证书3储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label147" runat="server" Text="其他证书3信息证件"></asp:Label></label>
                                     <div  runat="server" id="div16">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload其他证书3信息证件" runat="server" /> 
        
                                            <asp:Button ID="Button1其他证书3信息证件" runat="server" Text="上传" 
                                            onclick="FileUpload其他证书3信息证件Button_Click" />
                                             <a href="" runat="server" id="其他证书3信息证件href" target="_blank"  >其他证书3信息证件附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label183" runat="server" Text="其他证书4信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label184" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型qita04" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label185" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号qita04" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label186" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期qita04" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label187" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期qita04" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label188" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间qita04" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label189" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关qita04" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label190" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假qita04" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label191" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件qita04" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label148" runat="server" Text="其他证书4储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox其他证书4储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label149" runat="server" Text="其他证书4信息证件"></asp:Label></label>
                                     <div  runat="server" id="div17">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload其他证书4信息证件" runat="server" /> 
        
                                            <asp:Button ID="Button其他证书4信息证件" runat="server" Text="上传" 
                                            onclick="FileUpload其他证书4信息证件Button_Click" />
                                            <a href="" runat="server" id="其他证书4信息证件href" target="_blank"  >其他证书4信息证件附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                </td>


                </tr>
                <tr>
                <td  >
                    <div class="row">
                              <div class="col-sm-2 form-group">
                                <label><asp:Label ID="Label192" runat="server" Text="其他证书5信息"></asp:Label></label>
                              </div>
                        </div>

                </td>
                <td >
                    <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label193" runat="server" Text="证书类型"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书类型qita05" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label194" runat="server" Text="证书编号"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox证书编号qita05" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              
                        </div>
                        <div class="row">
                                <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label195" runat="server" Text="发证日期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox发证日期qita05" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label196" runat="server" Text="有效期"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox有效期qita05" runat="server" CssClass="form-control" ></asp:TextBox>
                              </div>
                              <div class="col-sm-1  form-group">
                                <label><asp:Label ID="Label197" runat="server" Text="到期时间"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:TextBox ID="TextBox到期时间qita05" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                              </div>
                               
                        </div>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label198" runat="server" Text="发证机关"></asp:Label></label>
                              </div>
                              <div class="col-sm-4 form-group">
                                <asp:TextBox ID="TextBox发证机关qita05" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label199" runat="server" Text="证书真假"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                 <asp:Dropdownlist ID="Dropdownlist证书真假qita05" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>真</asp:ListItem>
                                <asp:ListItem>假</asp:ListItem>
                                </asp:Dropdownlist>
                              </div>
                                <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label200" runat="server" Text="有无原件"></asp:Label></label>
                              </div>
                              <div class="col-sm-2 form-group">
                                <asp:Dropdownlist ID="Dropdownlist有无原件qita05" runat="server" CssClass="form-control">
                                <asp:ListItem></asp:ListItem>
                                 <asp:ListItem>有</asp:ListItem>
                                <asp:ListItem>无</asp:ListItem>
                              </asp:Dropdownlist>
                              
                              </div>
                        </div>
                         <div class="row">
                              <div class="col-sm-1 form-group">
                                <label><asp:Label ID="Label150" runat="server" Text="其他证书5储存位置"></asp:Label></label>
                              </div>
                              <div class="col-sm-7 form-group">
                                <asp:TextBox ID="TextBox其他证书5储存位置" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col-md-2 form-group">
                                    <label><asp:Label ID="Label151" runat="server" Text="其他证书5信息证件"></asp:Label></label>
                                     <div  runat="server" id="div18">
                 
                  
                                        <div >
                                         <asp:FileUpload ID="FileUpload其他证书5信息证件" runat="server" /> 
        
                                            <asp:Button ID="Button1其他证书5信息证件" runat="server" Text="上传" 
                                            onclick="FileUpload其他证书5信息证件Button_Click" />
                                             <a href="" runat="server" id="其他证书5信息证件href" target="_blank"  >其他证书5信息证件附件</a>
                    
                                         </div>
                    
                                        </div>
       
                                </div>
                        </div>
                
                    </td>
                </tr>


            </table>
                        
                        
                         
                         
                        









                  </div>
            


            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                 <asp:HyperLink ID="hlBack2" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
               
            </div>

          </div>

        </section>
    </div>
</asp:Content>
