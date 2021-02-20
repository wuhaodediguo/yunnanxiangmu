<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeBehind="hetong2Add.aspx.cs" Inherits="CopyMFRubikCubePowerContent.Admin.xiangmu.WEbForm1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <script type="text/javascript">
        function cleanForm() {


            return false;
        }
 </script>
    <div class="mainWrap clearfix">
        <div class="main_tit">
            <div>
                &nbsp;&nbsp;<img src="../Images/bri_icon1.png">
               项目综合编辑画面<em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</em>
            </div>
        </div>
        <div id="AlertDiv" runat="server">
        </div>
        <div class="main_con" style="font-size: 10px;">
            <div class="col-sm-12" style="width: 100%;">
                <div class="panel panel-default">
                    




                    <div class="tab-content" style="margin: 5px auto; font-size: 12px;">
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228);">
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同名称：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="txt采购合同名称" TabIndex="11" Style="margin-left: -1px" Width="987px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy'})"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同编号：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购合同编号" TabIndex="12" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control input-sm" Width="160px"
                                        Text="供货单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox供货单位" TabIndex="13" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control input-sm" Width="160px"
                                        Text="订货单位：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox订货单位" TabIndex="14" Style="margin-left: -1px" Width="200px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购合同金额" TabIndex="15" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同发票类型：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购合同发票类型" TabIndex="16" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同税率：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购合同税率" TabIndex="17" Style="margin-left: -1px" Width="200px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购合同类别：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购合同类别" TabIndex="18" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox9" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购日期" TabIndex="19" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy/MM/dd'})"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control input-sm" Width="160px"
                                        Text="供货单位联系人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox供货单位联系人" TabIndex="20" Style="margin-left: -1px" Width="200px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control input-sm" Width="160px"
                                        Text="供货单位联系电话：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox供货单位联系电话" TabIndex="21" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control input-sm" Width="160px"
                                        Text="采购项目部：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox采购项目部" TabIndex="22" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy/MM/dd'})"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control input-sm" Width="160px"
                                        Text="项目经理：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px; margin-left: -10px; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox项目经理" TabIndex="23" Style="margin-left: -1px" Width="200px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox14" runat="server" class="form-control input-sm" Width="160px"
                                        Text="项目经理金额：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox项目经理金额" TabIndex="24" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onblur='NumberCheck(this)'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox21" runat="server" class="form-control input-sm" Width="160px"
                                        Text="创建人：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox创建人" TabIndex="24" Style="margin-left: -2px" Width="229px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox25" runat="server" class="form-control input-sm" Width="160px"
                                        Text="创建日期：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox创建日期" TabIndex="25" Style="margin-left: -1px" Width="200px"
                                        runat="server" class="form-control input-sm" autocomplete="off" onclick="WdatePicker({lang:'zh-cn',dateFmt:'yyyy/MM/dd'})"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox22" runat="server" class="form-control input-sm" Width="160px"
                                        Text="备注：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:TextBox ID="TextBox备注" TabIndex="30" Style="margin-left: -1px" Width="987px"
                                        runat="server" class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                    <asp:TextBox ID="TextBox时间" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox38" runat="server" class="form-control input-sm" Width="160px"
                                        Text="电子版合同：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:FileUpload ID="FileUpload1" TabIndex="31" runat="server" />
                                    <asp:Button ID="Button4" runat="server" Text="上传" TabIndex="32" Style="font-size: 14"
                                        OnClick="FileUpload电子版合同Button_Click" CssClass="btn22" />
                                    <asp:TextBox ID="TextBox电子版合同" runat="server" class="form-control" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="电子版合同href" target="_blank">电子版合同</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox40" runat="server" class="form-control input-sm" Width="160px"
                                        Text="合同扫描件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:FileUpload ID="FileUpload2" TabIndex="33" runat="server" />
                                    <asp:Button ID="Button5" runat="server" Text="上传" TabIndex="34" Style="font-size: 14"
                                        OnClick="FileUpload合同扫描件Button_Click" CssClass="btn22" />
                                    <asp:TextBox ID="TextBox合同扫描件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                    <a href="" runat="server" id="合同扫描件href" target="_blank">合同扫描件</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-8" style="margin: 0 0 0 0">
                            <div class="row" style="margin: 0 0 0 0">
                                <div class="col-sm-5 col-xs-8" style="text-align: right; background-color: RGB(214,220,228)">
                                    <asp:TextBox ID="TextBox20" runat="server" class="form-control input-sm" Width="170px"
                                        Text="合同其他附件：" Font-Bold="true" ReadOnly="true" Style="text-align: right; background-color: RGB(214,220,228);
                                        border: 0; margin-left: -10px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 col-xs-8">
                                    <asp:FileUpload ID="FileUpload3" runat="server" TabIndex="35" Style="margin-left: 10px" />
                                    <asp:Button ID="Button6" runat="server" Text="上传" TabIndex="36" Style="font-size: 14;
                                        margin-left: 10px" OnClick="FileUpload合同其他附件Button_Click" CssClass="btn22" />
                                    <a href="" runat="server" id="合同其他附件href" target="_blank">合同其他附件</a>
                                    <asp:TextBox ID="TextBox合同其他附件" runat="server" class="form-control input-sm" Style="display: none"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>




                </div>
            </div>
            <!--#endeditable-->
        </div>
    </div>
</asp:Content>
