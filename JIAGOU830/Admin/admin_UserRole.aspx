<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_UserRole.aspx.cs" Inherits="Admin_admin_UserRole" %>

<%@ Register Src="Controls/showCopyright.ascx" TagName="showCopyright" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户角色分配</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="style/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server">
        <div>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="tbbg">
                <tr>
                    <td height="30" class="tbTopBg" align="center">
                        用户角色分配</td>
                </tr>
                <tr>
                    <td bgcolor="white" align="center">
                        <br />
                        <table width="95%" border="0" align="center" cellpadding="4" cellspacing="1" class="tbbg">
                            <tr>
                                <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                    当前用户：</td>
                                <td width="801" height="40" align="left" class="tbSbg">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lblUserName" runat="server"></asp:Label>&nbsp;
                                    <asp:Label ID="lblTrueName" runat="server"></asp:Label>
                                    <asp:Label ID="lblUserID" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                    角色分类：</td>
                                <td height="40" class="tbSbg" align="left">
                                    &nbsp;
                                    <asp:DropDownList ID="ddlRoleClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoleClass_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td height="40" align="center" class="tbTitleBg" colspan="2">
                                    <br />
                                    <br />
                                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="250px">
                                                可分配角色<br />
                                                <asp:ListBox ID="lboxNo" runat="server" Width="200px" Height="150px"></asp:ListBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lboxNo"
                                                    Display="Dynamic" ErrorMessage="请先选择一个角色！" ValidationGroup="add"></asp:RequiredFieldValidator></td>
                                            <td>
                                                <asp:Button ID="btnAdd" runat="server" Text="增加角色>>" OnClick="btnAdd_Click" ValidationGroup="add" /><br />
                                                <br />
                                                <asp:Button ID="btnDel" runat="server" Text="移除角色<<" OnClick="btnDel_Click" ValidationGroup="del" /></td>
                                            <td width="250px">
                                                已拥有角色<br />
                                                <asp:ListBox ID="lboxYes" runat="server" Width="200px" Height="150px"></asp:ListBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lboxYes"
                                                    Display="Dynamic" ErrorMessage="请先选择一个角色！" ValidationGroup="del"></asp:RequiredFieldValidator></td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <uc1:showCopyright ID="ShowCopyright1" runat="server" />
    </form>
</body>
</html>
