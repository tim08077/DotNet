<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_Top.aspx.cs" Inherits="Admin_admin_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="style/style.css" type="text/css" rel="stylesheet" />
</head>
<body  text="#000000" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" method="post"  runat="server">
    <div>
      <table width="100%" height="102" runat="server" cellpadding="0" cellspacing="0">
        <tr>
          <td background='images/top-bj.gif'>
           <table width="778" height="102" border="0" cellpadding="0" cellspacing="0">
             <tr>
               <td colspan="3">
                 <img src='images/top-1.gif' width="778" height="71" alt="管理系统">
               </td>
             </tr>
             <tr>
               <td width="217" background='images/top-2.gif'>
                 <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
                   <tr>
                     <td height="3" colspan="2"></td>
                   </tr>
                   <tr>
                     <td width="30">
                         <div align="center">
                            <img src="images/bar_00.gif" width="16" height="16">
                         </div>
                     </td>
                     <td>
                        『当前用户：
                                            <asp:Label ID="lblSignIn" runat="server"></asp:Label>』
                     </td>
                   </tr>
                 </table>  
               </td>
               <td width="486" background='images/top-3.gif'>
                  <table height="31" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td height="9%">
                      </td>
                      <td>
                        <table height="31" border="0" cellpadding="0" cellspacing="0">
                           <tr>
                              <td rowspan="2">
                                <img src='images/top-4.gif' width="39" height="31"></td>
                              <td height="8">
                                  <font face="宋体"></font>
                              </td>
                           </tr>
                           <tr>
                             <td>
                                 <a href="admin_Main.aspx" target="mainFrame">首页</a>
                             </td>
                           </tr>

                        </table>
                      </td>
                      <td>
                        <table height="31"  border="0" cellpadding="0" cellspacing="0">
                          <tr>
                             <td rowspan="2">
                                <img src='images/top-4.gif' width="39" height="31" />
                             </td>
                             <td height="8"></td>
                          </tr>
                          <tr>
                            <td>
                              <a href="#" onclick="javascript:parent.mainFrame.focus();parent.mainFrame.print();">打印</a>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td>
                       <table height="31" border="0" cellpadding="0" cellspacing="0">
                         <tr>
                            <td rowspan="2">
                              <img src='images/top-4.gif' width="39" height='31' />
                            </td>
                            <td height="8">
                            </td>
                         </tr>
                         <tr> 
                           <td>
                             <a href="javascript.history.go(-1)">后退</a>
                           </td>
                         </tr>
                       </table>
                      </td>
                      <td> 
                        <table height="31" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                             <td rowspan="2">
                                <img src='images/top-4.gif' width="39" height="31" />
                             </td>
                             <td height="8">
                               
                             </td>
                          </tr>
                          <tr>
                            <td>
                              <a href="javascript:history.go(1)">前进</a>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td>
                        <table height="31" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td rowspan="2"> 
                              <img src='images/top-4.gif' width="39" height="31" />
                            </td>
                            <td height="8">
                            </td>
                          </tr>
                          <tr>
                             <td>
                               <a href="admin_ReLogin.aspx" target="_top" onclick="if(!window.confirm('您确认要注销当前用户么？')){return false;}">注销</a>
                             </td>
                          </tr>
                        </table>
                      </td>
                      <td>
                        <table height="31" border="0" cellpadding="0" cellspacing="0">
                           <tr>
                             <td rowspan="2">
                                <img src='images/top-4.gif' width="39" height="31" />
                             </td>
                             <td height="8"></td>
                           </tr>
                           <tr>
                             <td>
                                <a href="admin_Logout.aspx" target="_top">退出</a>
                             </td>
                           </tr>
                        </table>
                      </td>
                      <td>
                                            <table height="31" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="39" rowspan="2">
                                                        <img src='images/top-4.gif' width="39" height="31"></td>
                                                    <td height="8">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <img src="images/bar_07.gif" width="16" height="16" onclick="if(parent.topset.rows!='22,*'){parent.topset.rows='22,*';window.scroll(0,93)}else{parent.topset.rows='93,*'};"
                                                            style="cursor: hand" title="点击这里可以收缩顶部"></td>
                                                </tr>
                                            </table>
                                        </td>
                    </tr>
                  </table>
               </td>
               <td width="75">
                                <img src='images/top-5.gif' width="75" height="31">
                                </td>
              </tr>
                 </table>
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
