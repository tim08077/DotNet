<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NeedMaterialDetailEdit.aspx.cs" Inherits="Sales_NeedMaterialDetailEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="../Style/css.css" rel="stylesheet" type="text/css" />
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
                <td height="30" background="../Images/tab_05.gif">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                     <td width="12" height="30">
                       <img src="../Images/tab_03.gif" width="12" height="30" />
                     </td>
                     <td>
                       <table width="100%" height="0" cellspacing="0" cellpadding="0">
                         <tr>
                           <td width="46%" valign="middle">
                             <table width="100%" bordere="0" cellpadding="0" cellspacing="0">
                               <tr>
                                 <td>
                                   <div align="center">
                                     <img src="../Images/tb.gif" width="16" height="16" />
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
                     <td width="16" height="30">
                        <img src="../Images/tab_07.gif" width="16" height="30" />
                     </td>
                  </tr>
                </table>
                </td>
              </tr>
              <tr>
                <td>
                   <table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="8" background="../images/tab_12.gif">
                           &nbsp;
                       </td>
                       <td>
                         <table width="90%" border="0" cellpadding="0" cellspacing="0">
                            <asp:Panel ID="pnlAdd" width="100%" runat="server" Visible="true">
                               <tr>
                                  <td width="" height="" align="right">材料类型： 
                                  </td>
                                  <td>
                                     <asp:RadioButtonList ID ="rbtnlMaterialCategoryID" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>
                                     <asp:RequiredFieldValidator ID ="RequiredFieldValidator14" runat="server" ErrorMessage="请选择材料类型" Display="Dynamic" SetFocusOnError="True" ControlToValidate="rbtnlMaterialCategoryID" ValidationGroup="val"></asp:RequiredFieldValidator>
                                  </td>
                               </tr>
                               <tr>
                                   <td width="100" height="30" align="right">名称/货号： 
                                   </td>
                                   <td>
                                     <asp:TextBox ID ="txtName" runat="server" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                                       <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                        CompletionInterval="500" CompletionSetCount="20" MinimumPrefixLength="1" 
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" TargetControlID="txtName">
                                       </AjaxControlToolkit:AutoCompleteExtender>
                                   </td>
                               </tr>
                            </asp:Panel>
                         </table>
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
