<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrderList.aspx.cs" Inherits="Sales_SalesOrderList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单列表 </title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="../Style/css.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/UART.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true">
        </AjaxControlToolkit:ToolkitScriptManager>
        <table width="100%" border="0" callpadding="0" cellspacing="0" >
           <tr>
             <td height="30" background="../Images/tab_05.gif" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                  <tr>
                     <td width="12" height="30" >
                       <img src="../Images/tab_03.gif" width="12" height="30" />
                     </td>
                     <td>
                       <table width="100%" border="0" cellpadding="0" cellspacing="0">
                         <tr>
                           <td width="46%" valign="middle">
                             <table width="100%" border="0" cellpadding="0" cellspacing="0">
                               <tr>
                                 <td>
                                   <div align="center">
                                   <img src="../images/tb.gif" width="16" height="16" /></div>
                                 </td>
                                 <td width="95%">
                                    <span class="titleBold12px">订单列表</span>
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
                     <td width="8" background="../images/tab_12.gif" >
                       &nbsp;
                     </td>
                     <td align="center">
                         
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                           <ContentTemplate>
                             <table width="100%" border ="0" cellpadding="0" cellspacing="0">
                               
                               <tr>
                                  <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="8" background="../images/tab_12.gif">
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                    <ProgressTemplate>
                                        <img src="../Images/ajax-loader.gif" alt="" />数据载入中，请稍候...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center">
                                                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left">
                                                                说明：不能修改已经提交审核的订单。
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblStrWhere" runat="server" Visible="False"></asp:Label>
                                                                <asp:Label ID="lblRootDepartmentID" runat="server" Visible="False"></asp:Label>
                                                                <br />
                                                                订单编号：<asp:TextBox ID="txtSalesOrderNumber" runat="server"></asp:TextBox>
                                                                客户名称：<asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                                                                <br />
                                                                电话：<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                                                手机：<asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                                                                地址：<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                                                <br />
                                                                <asp:Button ID="Button1" runat="server" OnClick="btnSearch_Click" Text="查询" />
                                                                分页页数：<asp:TextBox ID="txtPageSize" runat="server" Width="50px"></asp:TextBox>
                                                                <AjaxControlToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                                    runat="server" FilterType="Numbers" TargetControlID="txtPageSize">
                                                                </AjaxControlToolkit:FilteredTextBoxExtender>
                                                                <asp:Button ID="Button2" runat="server" Text="确定" OnClick="btnSetPageSize_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="80%">
                                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  ></webdiyer:AspNetPager>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="myGridView" runat="server" Width="98%" 
                                                        AutoGenerateColumns="false" 
                                                        DataKeyNames="SalesOrderID,CustomerID,Designer,StatusSubmit,StatusPurchaseMaterial,StatusPayment,StatusAll" 
                                                        onrowdatabound="myGridView_RowDataBound" >
                                                        <Columns>
                                                          <asp:BoundField DataField="SalesOrderID" HeaderText="ID" ReadOnly="true" >
                                                             <ItemStyle Width="50px" />
                                                          </asp:BoundField>
                                                          <asp:BoundField DataField="SalesOrderNumber" HeaderText="订单编号" >
                                                          </asp:BoundField>
                                                          <asp:TemplateField HeaderText="客户名称">
                                                             <ItemTemplate>
                                                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                                                             </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:BoundField DataField="DateOrder" HeaderText="订单日期" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                                                          <asp:TemplateField HeaderText="设计师" >
                                                             <ItemTemplate>
                                                               <asp:Label ID="lblDesigner" runat="server"></asp:Label>
                                                             </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="提交状态" >
                                                            <ItemTemplate>
                                                              <asp:Label ID ="lblStatusSubmit" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="付款状态" >
                                                            <ItemTemplate>
                                                              <asp:Label ID="lblStatusPayment" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="订货状态">
                                                            <ItemTemplate>
                                                              <asp:Label ID="lblStatusPurchaseMaterial" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="流程状态">
                                                            <ItemTemplate>
                                                              <asp:Label ID="lblStatusAll" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <%--显示订单编辑--%>
                                                          <asp:TemplateField HeaderText="订单编辑">
                                                             <ItemTemplate>
                                                               <a href="javascript:void(0)" onclick="OpenModalDialog('SalesOrderEdit.aspx?SalesOrderID=<%# Eval("SalesOrderID") %>');" >
                                                               编辑</a>
                                                             </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <%--显示用料明细 --%>
                                                          <asp:TemplateField HeaderText="用料单明细" Visible="false">
                                                             <ItemTemplate>
                                                                 <a href="javascript:void(0)" onclick="OpenModalDialog('NeedMaterialDetailEdit.aspx?SalesOrderID=<%# Eval("SalesOrderID") %>')">
                                                                 编辑</a>
                                                             </ItemTemplate>
                                                             <ItemStyle Width="70px" />
                                                          </asp:TemplateField>
                                                          <%--显示用料明细--%>
                                                          <asp:HyperLinkField DataNavigateUrlFields="SalesOrderID"  
                                                            DataNavigateUrlFormatString="NeedMaterialHeaderEditFromSalesOrder.aspx?SalesOrderID={0}" HeaderText="用料明细单" Text="编辑" >
                                                            <ItemStyle Width="70px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                        </asp:GridView>
                                                        
                                                </td>
                                            </tr>
                                            <tr>
                                              <td>
                                                 <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" CssClass="tbNormal"
                                                        CustomInfoHTML="共&lt;font color='red'&gt;&lt;b&gt;%RecordCount%&lt;/b&gt;&lt;/font&gt;条记录 第  &lt;font color='red'&gt;&lt;b&gt;%CurrentPageIndex%&lt;/b&gt;&lt;/font&gt; &nbsp;页&nbsp;共  %PageCount%&nbsp;&nbsp;页 &nbsp;顺序 %StartRecordIndex%-%EndRecordIndex%"
                                                        FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" meta:resourcekey="AspNetPager"
                                                        NextPageText="后页" OnPageChanged="AspNetPager_PageChanged" PageIndexBoxType="DropDownList"
                                                        PageSize="10" PrevPageText="前页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always"
                                                        Style="font-size: 12px" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到第"
                                                        Width="100%">
                                                    </webdiyer:AspNetPager>
                                              </td>
                                            </tr>
                                            
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="8" background="../images/tab_15.gif">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                               </tr>
                               <tr>
                                 <td height="35" background="../images/tab_19.gif" >
                                   <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                     <tr>
                                       <td width="12" height="35" >
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
                           </ContentTemplate>
                         </asp:UpdatePanel>
                         
                     </td>
                     <td>
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
