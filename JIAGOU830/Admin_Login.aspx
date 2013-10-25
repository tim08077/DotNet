<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业订单管理系统登录</title>
    <link href="style/css.css" type="text/css" rel="stylesheet" />
</head>
<body id="userlogin_body">
    <form id="form1" runat="server">
    <div>
        <table width="500" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#EEEEE2"
            class="tbborder1" style="background-image: url(images/login_bg.gif)">
            <tr>
                <td style="height: 80px;">
                </td>
            </tr>
            <tr>
                <td style="height: 170px;">
                    <br />
                    <table width="400" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center">
                                <br />
                                <table width="400" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="30" align="right" style="width: 150px">
                                            &nbsp;用户名：
                                        </td>
                                        <td height="30" align="left">
                                            &nbsp;<asp:TextBox ID="txtUserName" runat="server" MaxLength="30"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valRfUserName" runat="server" ErrorMessage="用户名不得为空！"
                                                ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" style="width: 150px">
                                            &nbsp;密&nbsp; 码：
                                        </td>
                                        <td height="30" align="left">
                                            &nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valRfPassword" runat="server" ErrorMessage="密码不得为空！"
                                                ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                <br />
                                <asp:ImageButton ID="imgLogin" runat="server" ImageUrl="~/Admin/images/login.gif"
                                    OnClick="imgLogin_Click" />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" height="50">
                    &nbsp;Copyright © 2010-<asp:Label ID="lblCurrentYear" runat="server"></asp:Label>
&nbsp;企业订单管理系统
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
