<%@ Page Language="C#" Transaction="Required" AutoEventWireup="true" CodeFile="NeedMaterialDetailEdit.aspx.cs" Inherits="BLL_Sales_NeedMaterialDetailEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用料单明细管理</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="../../Style/css.css"  rel="stylesheet"  type="text/css" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
        </AjaxControlToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
             <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" background="../../Images/tab_05.gif">
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                         <tr>
                           <td width="12" height="30">
                              <img  src="../../Images/tab_03.gif" width="12" height="30" />
                           </td>
                           <td>
                               <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="46%" valign="middle">
                                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                         <tr>
                                           <td width="5%">
                                              <div align="center"> 
                                                <img src="../../Images/tb.gif" width="16" height="16" />
                                              </div>
                                           </td>
                                           <td width="95%">
                                              <span class="titleBold12px">管理用料单明细</span>
                                           </td>
                                         </tr>
                                      </table>
                                    </td>
                                     <td width="54%" align="right">
                                     </td>
                                  </tr>
                               </table>
                           </td>
                         </tr>
                      </table>
                    </td>
                </tr>
                <tr>
                  <td>
                   <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                          <td width="8" background="../../Images/tab_12.gif">
                              &nbsp;
                          </td>
                          <td>
                             <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                <asp:Panel ID="pnlAdd" Width="100%" runat="server" Visible="true">
                                    <tr>
                                      <td width="100" height="30" align="right">
                                         材料类型：
                                      </td>
                                      <td>
                                        <asp:RadioButtonList ID="rbtnlMaterialCategoryID" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="rbtnlMaterialCategoryID" Display="Dynamic" SetFocusOnError="True" ValidationGroup="val"></asp:RequiredFieldValidator>
                                      </td>
                                    </tr>
                                </asp:Panel>
                             </table>
                          </td>
                          <td width="8"  background="../../Images/tab_15.gif">
                             &nbsp;
                          </td>
                      </tr>
                   </table>
                  </td>
                </tr>
             </table>
           </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
