<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrderAdd.aspx.cs" Inherits="Sales_SalesOrderAdd" %>

<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加订单</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"
          EnableScriptGlobalization="true">
        </AjaxControlToolkit:ToolkitScriptManager>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td height="30" background="../Images/tab_05.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="12" height="30" >
                    <img src="../Images/tab_03.gif" width="12" height="30" />
                  </td>
                  <td>
                    <table  width="100%"  border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td>
                           <div align="center">
                              <img src="../images/tb.gif" width="16" height="16" />
                           </div>
                        </td>
                        <td width="95%" >
                            <span class="titleBold12px" >添加订单</span>
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
              <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                          AssociatedUpdatePanelID="UpdatePanel1" >
                          <ProgressTemplate>
                            <img src="../Images/ajax-loader.gif" alt="" />数据载入中，请稍候 ...
                          </ProgressTemplate>
                     </asp:UpdateProgress>
              <br />
              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                       <ContentTemplate>
                         <table width= "100%" border ="0" cellspacing="0" cellpadding="0">
                             <tr>
                               <td width="8" background="../images/tab_12.gif">
                                 &nbsp;
                               </td>
                               <td>
                                   <AjaxControlToolkit:TabContainer ID="TabContainer1" runat="server" 
                                       ActiveTabIndex="1" Width="100%">
                                       <AjaxControlToolkit:TabPanel runat="server" HeaderText="查询老客户" ID="TabPanel1">
                                         <ContentTemplate>
                                           <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" >
                                             <tr>
                                               <td width="100" height="30" align="center">
                                                 客户查询</td>
                                                <td align="center">
                                                    可输入电话、手机、客户姓名、地址等关键字查询，支持模糊搜索<br />
                                                    <asp:TextBox ID="textSearch" runat="server" Font-Size="Small" Font-Bold="True" ></asp:TextBox>
                                                    <asp:Button ID="btnSearch" runat="server" Width="80px" Height="30px" Text="搜索" OnClick="btnSearch_Click" Font-Size="16px"/>
                                                    <br />
                                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                                                </td>
                                             </tr>
                                           </table>
                                           <asp:Panel Width="100%" ID="pnlCustomerSelect" visable="false"   runat="server" >
                                             <table width="90%" border="0" cellpadding="0" cellspacing="0" align="center" >
                                               <tr>
                                                 <td width="100" height="30" align="right">
                                                    客户选择： 
                                                 </td>
                                                 <td>
                                                   <asp:RadioButtonList ID="rbtnlCustomer" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtnlCustomer_SelectIndexChanged"
                                                   RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                   </asp:RadioButtonList>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rbtnlCustomer" 
                                                     Display="Dynamic" ErrorMessage="请先选择客户" SetFocusOnError="True" 
                                                         ValidationGroup="valCustomer" ForeColor="Red"></asp:RequiredFieldValidator>
                                                  </td>
                                               </tr>
                                             </table>
                                           </asp:Panel>
                                           <asp:Panel Width ="100%" ID="pnlCustomerInfo" runat="server" Visible="False">
                                              <table  width="90%" border="0" align="center" cellpadding="0" cellspacing="0" >
                                                 <tr>
                                                   <td>
                                                     
                                                         <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                             <tr>
                                                                 <td align="right" height="30" width="100">
                                                                     姓名： 
                                                                 </td>
                                                                 <td>
                                                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                                                 </td>
                                                             </tr>
                                                             <tr>
                                                               <td align="right" height="30" width="100">电话： 
                                                               </td>
                                                               <td>
                                                                  <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                               </td>
                                                             </tr>
                                                         </table>
                                                     
                                                   </td>
                                                   <td>
                                                      <table width ="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                                          <tr>
                                                            <td align="right" width="100" height="30">手机：
                                                            </td>
                                                            <td>
                                                              <asp:Label ID="lblCellPhone" runat="server"></asp:Label>
                                                            </td>
                                                          </tr>
                                                          <tr>
                                                            <td width="100" height="30" align="right">
                                                            </td>
                                                            <td>
                                                               &nbsp;
                                                            </td>
                                                          </tr>
                                                      </table>
                                                   </td>
                                                   
                                                 </tr>
                                                 <tr>
                                                   <td colspan="2" height="" align="center">
                                                   <br />
                                                   <asp:Button ID ="btnConfirmCustomer" runat="server" Width="200" Height="30" Text="确定" ValidationGroup="valCustomer" 
                                                     OnClick="btnConfirmCustomer_Click" Font-Size="16" />
                                                   <br />
                                                   <hr />
                                                   <br />
                                                   </td>
                                                 </tr>
                                                
                                              </table>
                                           </asp:Panel>


                                         </ContentTemplate>
                                       </AjaxControlToolkit:TabPanel>
                                       <AjaxControlToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="添加新客户">
                                          <ContentTemplate>
                                             <table width="90%" border="0" align="center" cellspacing="0" cellpadding="0">
                                                <tr>
                                                  <td>
                                                    <table align="center" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                      <tr>
                                                        <td width="100" height="30" align="right" >
                                                           姓名： 
                                                        </td>
                                                        <td>
                                                          <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                ControlToValidate="txtCustomerName" Display="Dynamic"
                                                            ErrorMessage="请输入姓名" SetFocusOnError="True" ValidationGroup="addCustomer"></asp:RequiredFieldValidator>
                                                        </td>
                                                      </tr>
                                                      <tr>
                                                        <td width="100" height="30" align="right">
                                                          电话： 
                                                        </td>
                                                        <td>
                                                          <asp:TextBox ID ="txtPhone" runat="server"></asp:TextBox>
                                                        </td>
                                                      </tr>
                                                    </table>
                                                  </td>
                                                  <td>
                                                   <table align="center" border="0" cellspacing="0" cellpadding="0" width="100%">
                                                     <tr>
                                                       <td width="100" height="30" align="right">
                                                        电话：
                                                       </td>
                                                       <td>
                                                          <asp:TextBox ID="txtCallPhone" runat="server" ></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"  ControlToValidate ="txtCallPhone" 
                                                          ErrorMessage="请输入手机" SetFocusOnError="True" ValidationGroup="addCustomer" 
                                                               Display="Dynamic"></asp:RequiredFieldValidator>
                                                       </td>
                                                     </tr>
                                                     <tr>
                                                       <td width="100" height="30" align="right">
                                                       </td>
                                                       <td>
                                                       </td>
                                                     </tr>
                                                   </table>
                                                  </td>
                                                </tr>
                                                <tr>
                                                  <td colspan="2" height="30" align="center">
                                                  <asp:Label ID="lblMsgAdd" runat="server"  ForeColor="Red" Visible="false"></asp:Label>
                                                  <br />
                                                  <asp:Button ID="btnAddCustomer" runat="server" Width="200" Height="30" Text="添加" Font-Size="16" 
                                                      ValidationGroup="addCustomer" OnClick="btnAddCustomer_Click" />
                                                   <br />
                                                   <br />
                                                   <br />
                                                  </td>
                                                </tr>
                                             </table>
                                          </ContentTemplate>
                                       </AjaxControlToolkit:TabPanel>
                                   </AjaxControlToolkit:TabContainer>
                                   <asp:Label ID="lblCustomerID" runat="server" Visible="false" ></asp:Label>
                                   <asp:Label ID="lblCurrentUser" runat="server"  Visible="false"></asp:Label>
                                   <asp:Label ID="lblRootDepartmentID" runat="server" Visible="false"></asp:Label>
                                   <asp:Panel ID= "pnlSalesOrderInfo" Width="100%" Visible="false" runat="server">
                                     <table align="center" border="0" cellspacing="0" cellpadding="0" width="90%">
                                       <tr>
                                         <td width="100" height="30" align="right">地址：
                                         </td>
                                         <td>
                                           <asp:TextBox ID ="txtAddress" runat="server" Width="400" ></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtAddress" 
                                                Display="Dynamic" ErrorMessage="地址不能为空" SetFocusOnError="true" ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                         
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right">订单日期： 
                                         </td>
                                         <td>
                                           <asp:TextBox ID="txtDateOrder" runat="server"></asp:TextBox>
                                             <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOrder" Format="yyyy-mm-dd">
                                             </AjaxControlToolkit:CalendarExtender>          
                                         </td>
                                       </tr>
                                       <tr>
                                          <td width="100" height="30" align="right" >交货日期： 
                                          </td>
                                          <td>
                                             <asp:TextBox  ID ="txtDateDelivery" runat="server" ></asp:TextBox>
                                              <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateDelivery" Format="yyyy-mm-dd" >
                                              </AjaxControlToolkit:CalendarExtender>
                                          </td>
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right" >验货日期： 
                                         </td>
                                         <td>
                                          <asp:textbox ID ="txtDateInspect" runat="server" ></asp:textbox>
                                             <AjaxControlToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateInspect" Format="yyyy-mm-dd" >
                                             </AjaxControlToolkit:CalendarExtender>
                                         </td>
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right">安装日期： 
                                         </td>
                                         <td>
                                              <asp:TextBox ID ="txtDateInstall" runat="server" ></asp:TextBox>
                                             <AjaxControlToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateInstall" Format="yyyy-mm-dd" >
                                             </AjaxControlToolkit:CalendarExtender>
                                         </td>
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right"> 合同号：
                                         </td>
                                         <td>
                                           <asp:TextBox ID ="txtSalesOrderNumber" runat="server" ></asp:TextBox>
                                           <asp:RequiredFieldValidator ID ="RequiredFieldValidator15" runat="server" ControlToValidate="txtSalesOrderNumber" 
                                             ErrorMessage="请输入合同号" Display="Dynamic" ValidationGroup="add"></asp:RequiredFieldValidator>
                                         </td>                                    
                                       </tr>
                                       <tr>
                                         <td  width="100" height="30" align="right">设计师： 
                                         </td>
                                         <td>
                                           <asp:label ID="lblDesignerTrueName" runat="server" ></asp:label>
                                           <asp:Label ID="lblDesignerUserName" runat="server" Visible="false"></asp:Label>
                                         </td>
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right">订单备注： 
                                         </td>
                                         <td>
                                         <asp:TextBox ID ="txtNotesOrder" runat="server" Width="400" ></asp:TextBox>
                                         </td>
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right">制作备注：
                                         </td>
                                         <td>
                                           <asp:TextBox ID ="txtNotesManufacture" runat="server" Width="400" ></asp:TextBox>
                                         </td>
                                       </tr>
                                       <tr>
                                         <td width="100" height="30" align="right" >安装备注： 
                                         </td>
                                         <td>
                                           <asp:TextBox ID ="txtNotesInstall" runat="server" Width="400"></asp:TextBox>
                                         </td>
                                       </tr>
                                       <tr>
                                         <td colspan="2" align="center">
                                           <br />
                                           <asp:Button ID="btnOK" runat="server" Font-Size="16" Width="200" height="30" OnClick="btnOK_Click" Text="生成订单" />
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
                               <td width="8" background="../images/tab_15.gif">
                                 &nbsp;
                               </td>
                             </tr>
                         </table>

                       </ContentTemplate>
                       <Triggers>
                         <asp:PostBackTrigger ControlID="btnOK"  />
                       </Triggers>
               </asp:UpdatePanel>
            </td>
           </tr>
          </table>
           
              
            
    
    </div>
    </form>
</body>
</html>
<script language ="javasctipt" type="text/javascript">
function SetFocusSearch()
{
    if(event.KeyCode==13)
    {
        event.KeyCode = 9;
        document.getElementById('TabContainer1_TabPanel1_btnSearch').click();
    }
}
</script>
