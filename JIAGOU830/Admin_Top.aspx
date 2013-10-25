<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Top.aspx.cs" Inherits="Admin_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理TOP部分</title>
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table  width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="556"><img src="Images/top_01.gif" alt="企业订单管理系统" width="556"  height="71"/></td>
          <td background="Images/top_bg.gif" style="width:600px"><img src="Images/top_02.gif" alt="企业订单管理系统" width="148" height="71" /></td>
          <td width="289" align="right"><table width="289" border="0" cellpadding="0" cellspacing="0">
            <tr>
             <td height="46" ><img src="Images/top_03.gif" width="289" height="46" /></td>
            </tr>
            <tr>
              <td height="25" background="Images/top_04.gif" align="center">
               <asp:Label ID="lblDate" runat="server" ForeColor="#003366"></asp:Label>
              </td>
            </tr>
          </table>
          
          </td>
        </tr>
      </table>
      <table id="topbar" width="100%" border="0" cellspacing="0" cellpadding="0" background="Images/top_bg2.gif">
            <tr>
             <td width="170" height="29">
               &nbsp;
             </td>
             <td width="490" height="29">
               <table width="100%" cellpadding="0" cellspacing="0" border="0">
                 <tr>
                            <td>
                                <img src="Images/16_home.png" alt="首页" width="16" height="16" /><a href="Middel.html"
                                    target="mainFrame">首页</a>
                            </td>
                            <td>
                                <img src="Images/16_back.png" alt="后退" width="16" height="16" /><a href="javascript:history.go(-1)">后退</a>
                            </td>
                            <td>
                                <img src="Images/16_forward.png" alt="前进" width="16" height="16" /><a href="javascript:history.go(1)">前进</a>
                            </td>
                            <td>
                                <img src="Images/16_refresh.png" alt="刷新" width="16" height="16" /><a href="javascript:window.parent.frames('mainFrame').frames('I2').location.reload();">刷新</a>
                            </td>
                            <td>
                                <img src="Images/16_print.png" alt="打印" width="16" height="16" /><a href="#" onclick="javascript:parent.mainFrame.I2.focus();parent.mainFrame.I2.print();">打印</a>
                            </td>
                            <td>
                                <img src="Images/16_relogin.png" alt="注销" width="16" height="16" /><a href="Admin_ReLogin.aspx"
                                    target="_top" onclick="if (!window.confirm('您确认要注消当前登录用户吗？')){return false;}">注销</a>
                            </td>
                            <td>
                                <img src="Images/16_exit.png" alt="退出" width="16" height="16" target="_top" /><a
                                    href="Admin_Logout.aspx" onclick="if (!window.confirm('您确认要退出吗？')){return false;}">退出</a>
                            </td>
                 </tr>
               </table>
             </td>
             <td height="29">
              &nbsp;
             </td>
            </tr>
          </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0" background="Images/main_31.gif">
        <tr>
          <td width="8" height="30">
            <img src="Images/main_28.gif" width="8" height="30" />
          </td>
          <td width="147" height="30" background="Images/main_29.gif">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
               <tr>
                 <td width="24%">
                    &nbsp;
                 </td>
                 <td with="43%" height="20" valign="bottom">
                   菜单管理 
                 </td>
                 <td width="33%">
                   &nbsp;
                 </td>
               </tr>
            </table>
          </td>
          <td width="39" height="30">
                    <img src="Images/main_30.gif" width="39" height="30" />
                </td>
                <td height="30">
                    当前登录用户：<asp:Label ID="lblSignIn" runat="server"></asp:Label>
                    部门：<asp:Label ID="lblDepartment" runat="server"></asp:Label>
                </td>
                <td width="17" height="30">
                    <img src="Images/main_32.gif" width="17" height="30" />
                </td>

        </tr>
      </table>
    </div>
    </form>
</body>
</html>
