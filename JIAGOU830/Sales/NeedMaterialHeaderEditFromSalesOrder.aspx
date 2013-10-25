<%@ Page Language="C#" Transaction="Required" AutoEventWireup="true" CodeFile="NeedMaterialHeaderEditFromSalesOrder.aspx.cs" Inherits="Sales_NeedMaterialHeaderEditFromSalesOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用料单管理</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/UART.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" 
            runat="server" EnableScriptGlobalization="True">
        </AjaxControlToolkit:ToolkitScriptManager>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="" background="../Images/tab_05.gif" >
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                 <tr>
                      <td width="12" height="30" >
                        <img src="../Images/tab_03.gif" width="12" height="30" />
                      </td>
                      <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="46%" valign="middle">
                              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                      <div align="center" >
                                        <img src="../images/tb.gif" width="16" height="16" />
                                      </div>
                                    </td>
                                    <td width="95%">
                                      <span class="titleBold12px" >管理用料单</span>
                                    </td>
                                </tr>
                              </table>
                            </td>
                            <td width="54%" align="right">
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td width="16" height="30" >
                        <img src="../Images/tab_07.gif" width="16" height="30" />
                      </td>
                 </tr>
                   
              </table>

            </td>
          </tr>
          <tr>
            <td>
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td  width="8" background="../images/tab_12.gif"> 
                    &nbsp;
                  </td>
                  <td>
                    <table width="90%" border="0" align="center" cellpadding="0"  cellspacing="0">
                      <tr>
                        <td height="30" align="center" >
                          <strong>订单概况</strong>
                        </td>
                      </tr>
                      <tr>
                        <td height="30" align="center">
                           <table width="100%" border="0" cellspacing="0" cellpadding="0">
                             <tr>
                                <td width="100"  height="30" align="center">
                                   合同号：
                                </td>
                                <td align="left">
                                    <asp:Label ID ="lblSalesOrderNumber" runat="server" ></asp:Label>
                                    <asp:Label ID ="lblSalesOrderID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblRootDepartmentID" runat="server" Visible="false"></asp:Label>
                                </td>
                             </tr>
                             <tr>
                               <td width="100" height="30" align="center">
                                 设计师： 
                               </td>
                               <td align="left">
                                   <asp:Label ID="lblDesigner" runat="server" ></asp:Label>
                               </td>
                             </tr>
                             <tr>
                               <td width="100" height="30" align="center">
                                  备注： 
                               </td>
                               <td align="left">
                                   <asp:Label ID ="lblNotesOrder" runat="server"></asp:Label>
                               </td>
                             </tr>
                             <tr>
                               <td colspan="2"></td>
                             </tr>
                           </table>
                        </td>
                      </tr>
                      <tr>
                        <td height="30" align="center">
                        </td>
                      </tr>
                    </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                          <img src="../Images/ajax-loader.gif" alt="" />数据载入中，请稍后 ...
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                           <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                             <asp:Panel ID="pnlAdd" runat="server" Width="100%">
                               <tr>
                                 <td width="100" height="30" align="right">
                                    用料单日期：
                                 </td>
                                 <td>
                                    <asp:TextBox ID ="txtDateOrder" runat="server"></asp:TextBox>
                                    <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateOrder">
                                    </AjaxControlToolkit:CalendarExtender>
                                 </td>
                               </tr>
                               <tr>
                                 <td width="100" height="30" align="right">
                                 经办人：</td>
                                 <td>
                                    <asp:Label ID ="lblManagerUserName" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblManagerTrueName" runat="server" ></asp:Label>
                                 </td>
                               </tr>
                               <tr>
                                 <td colspan="2" align="center">
                                   <br />
                                   <asp:Button ID="btnAddOrder" runat="server" Text ="添加" OnClick="btnAddOrder_Click" 
                                      ValidationGroup="val" Font-Size="16px" Width="200" Height="30" />
                                 </td>
                               </tr>
                             </asp:Panel>
                               <tr>
                                 <td align="center" colspan="2">
                                   <asp:label ID ="lblMsg2" runat="server" ForeColor="Red"></asp:label>
                                   <br />
                                   <hr />
                                   <asp:CustomValidator ID ="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="请至少添加一项用料单"
                                        OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="ok" 
                                         ForeColor="Red" ></asp:CustomValidator>
                                   <br />
                                   <asp:GridView ID="myGridView" runat="server" Width="100%"  AutoGenerateColumns="False" 
                                    DataKeyNames="NeedMaterialID,Manager,StatusSubmit,StatusPurchaseMaterial" 
                                         onrowdeleting="myGridView_RowDeleting" OnRowDataBound="myGridView_RowDataBound"  >
                                         <Columns>
                                           <asp:BoundField DataField ="NeedMaterialID" HeaderText="ID" />
                                           <asp:BoundField DataField ="DateOrder" HeaderText="用料单日期" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"/>
                                           <asp:TemplateField  HeaderText="经办人">
                                              <ItemTemplate>
                                                 <asp:Label ID="lblManagerName" runat="server"></asp:Label>
                                              </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="提交状态">
                                               <ItemTemplate>
                                                 <asp:Label ID="lblStatusSubmit" runat="server"></asp:Label>
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="订货状态">
                                               <ItemTemplate>
                                                 <asp:label ID="lblStatusPurchaseMaterial" runat="server"></asp:label>
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="用料明细">
                                             <ItemTemplate> 
                                               <a href="javascript:void(0)" onclick="OpenModalDialog('NeedMaterialDetailEdit.aspx?NeedMaterialID=<%# Eval("NeedMaterialID") %>');">
                                               编辑</a>
                                             </ItemTemplate>
                                             <ItemStyle Width="60px"  />

                                           </asp:TemplateField>
                                           <asp:TemplateField  HeaderText="删除" ShowHeader="false" >
                                              <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDel" runat="server" CausesValidation ="false" CommandName="delete" 
                                                   OnClientClick="return confirm(&quot;将删除此项目，且无法恢复，您确认删除此记录吗?&quot;)" Text="删除"></asp:LinkButton>
                                              </ItemTemplate>
                                              <ItemStyle Width="30px" />
                                           </asp:TemplateField>
                                         </Columns>
                                   </asp:GridView>
                                 </td>
                               </tr>
                               <tr>
                                  <td align="center" colspan="2">
                                  <br />
                                    <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click"
                                     Font-Size="16px"  Width="200px" Height="30px" ValidationGroup="ok" />
                                  <br />
                                  </td>
                              </tr>
                           </table>
                         </ContentTemplate>
                         <Triggers>
                           <asp:PostBackTrigger ControlID="btnOK" />
                         </Triggers>
                      </asp:UpdatePanel>
                  </td>
                  <td width="8" background="../images/tab_15.gif" >
                    &nbsp;
                  </td>
                </tr>
                
              </table>
            </td>
            
          </tr>
          <tr>
            <td height="35" background="../images/tab_19.gif">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="12" height="35">
                     <img src="../images/tab_18.gif" width="12" height="35" />
                  </td>
                  <td align="center">
                    &nbsp;
                  </td>
                  <td width="16">
                    <img src="../images/tab_20.gif" width="16" height="35" /> 
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
    </div>
    </form>
</body>
</html>
