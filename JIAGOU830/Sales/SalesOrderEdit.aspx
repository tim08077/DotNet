<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrderEdit.aspx.cs" Inherits="Sales_SalesOrderEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改订单</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </AjaxControlToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
         <tr>
           <td height="" background="../Images/tab_05.gif">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="12" height="30" >
              <img src="../Images/tab_03.gif" width="12" height="30" />
            </td>
            <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="46%" valign="middle">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <div align="center">
                                                                    <img src="../images/tb.gif" width="16" height="16" /></div>
                                                            </td>
                                                            <td width="95%">
                                                                <span class="titleBold12px">修改订单概况</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="54%" align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
            <td width="16" height="30">
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
                  <td width="8" background="../images/tab_12.gif">
                      &nbsp;
                  </td>
                  <td>

                    <asp:Label ID="lblCustomerID" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblCurrentUser" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblSalesOrderID" runat="server" Visible="false"></asp:Label>
                    <asp:Panel ID="pnlSalesOrderInfo" runat="server" Visible="true"  Width="100%" >
                       <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                         <tr>
                           <td width="100"  height="30" align="right">
                              客户姓名： 
                           </td>
                           <td>
                              <asp:TextBox ID ="txtCustomerName" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                   ControlToValidate="txtCustomerName" Display="Dynamic" 
                                    ErrorMessage="请输入姓名" SetFocusOnError="true" ValidationGroup="val" 
                                   ForeColor="Red"></asp:RequiredFieldValidator>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">电话：</td>
                           <td>
                              <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right" >手机：</td>
                           <td>
                              <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID ="RequiredFieldValidator14" runat="server" 
                                   ControlToValidate="txtCellPhone" ErrorMessage="请输入手机" Display="Dynamic"
                                SetFocusOnError="true" ValidationGroup="val" ForeColor="Red"></asp:RequiredFieldValidator>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">地址：</td>
                           <td>
                              <asp:TextBox ID="txtAddress" runat="server" Width="400"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAddress" 
                              Display="Dynamic" ErrorMessage="请输入地址" SetFocusOnError="true" ValidationGroup="val" ForeColor="Red" ></asp:RequiredFieldValidator>

                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">订单日期：</td>
                           <td>
                           <asp:TextBox ID="txtDateOrder" runat="server"></asp:TextBox>
                           <AjaxControlToolkit:CalendarExtender ID ="CalendarExtender1" runat="server" TargetControlID="txtDateOrder" Format="yyyy-MM-dd"></AjaxControlToolkit:CalendarExtender>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">交货日期：</td>
                           <td>
                           <asp:TextBox ID="txtDateDelivery" runat="server"></asp:TextBox>
                           <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateDelivery" Format="yyyy-MM-dd"></AjaxControlToolkit:CalendarExtender>
                           </td>
                         </tr>
                         <tr>
                            <td width="100" height="30" align="right">验货日期：</td>
                            <td>
                            <asp:TextBox ID="txtDateInspect" runat="server"></asp:TextBox>
                            <AjaxControlToolkit:CalendarExtender  ID="CalendarExtender3" runat="server" TargetControlID="txtDateInspect" Format="yyyy-MM-dd"></AjaxControlToolkit:CalendarExtender>

                            </td>
                         </tr>
                         <tr>
                            <td width="100" height="30" align="right">安装日期：</td>
                            <td>
                              <asp:TextBox ID="txtDateInstall" runat="server"></asp:TextBox>
                              <AjaxControlToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateInstall" Format="yyyy-MM-dd"></AjaxControlToolkit:CalendarExtender>
                            </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">合同号：</td>
                           <td>
                             <asp:TextBox ID="txtSalesOrderNumber" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                   ControlToValidate="txtSalesOrderNumber" ErrorMessage="请输入合同号"
                               Display="Dynamic" SetFocusOnError="true" ValidationGroup="val" ForeColor="Red"></asp:RequiredFieldValidator> 
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">客户合同金额</td>
                           <td>
                             <asp:Label ID="lblContractAmount" runat="server">
                             </asp:Label>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">用料实际金额 
                           </td>
                           <td>
                             <asp:Label ID="lblSubTotal" runat="server" ></asp:Label>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">实收金额：</td>
                           <td>
                             <asp:Label ID ="lblTotalDue" runat="server"></asp:Label>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">其他金额</td>
                           <td>
                             <asp:Label ID ="lblBrokerage" runat="server"></asp:Label>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">设计师：
                           </td>
                           <td>
                             <asp:Label ID ="lblDesignerTrueName" runat="server" ></asp:Label>
                             <asp:Label ID ="lblDesignerUserName" runat="server" Visible="false"></asp:Label>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">订单备注
                           </td>
                           <td>
                             <asp:TextBox ID="txtNotesOrder" runat="server" Width="400"></asp:TextBox>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">制作备注
                           </td>
                           <td>
                             <asp:TextBox ID="txtNotesManufacture" runat="server" Width="400"></asp:TextBox>
                           </td>
                         </tr>
                         <tr>
                           <td width="100" height="30" align="right">安装备注
                           </td>
                           <td>
                             <asp:TextBox ID ="txtNotesInstall" runat="server" Width="400"></asp:TextBox>
                           </td>
                         </tr>
                         <tr>
                           <td colspan="2" align="center">
                             <br />
                             <asp:Button ID ="btnOK" runat="server" Height="30" Font-Size="16px" OnClick="btnOK_Click" Text="修改订单" Width="100" ValidationGroup="val" />
                             &nbsp;
                             <asp:Button ID="btnClose" runat="server" Font-Size="16px" Height="30px" Text="关闭" Width="100" OnClientClick="window.close();" />
                           </td>
                         </tr>
                         <tr>
                           <td colspan="2" align="center">
                             <br />
                           </td>
                         </tr>

                       </table>
                    </asp:Panel>
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
                 <img src="../images/tab_20.gif"  width="16" height="35" />
               </td>
             </tr>
           </table>
           </td>

         </tr>
         
        </table>
      </ContentTemplate>
      <Triggers>
        <asp:PostBackTrigger ControlID="btnOK" />
      </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
