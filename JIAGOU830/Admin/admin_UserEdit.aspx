<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_UserEdit.aspx.cs" Inherits="Admin_admin_UserEdit" %>

<%@ Register Src="Controls/showCopyright.ascx" TagName="showCopyright" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改用户信息</title>
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
                    修改用户信息
                </td>
            </tr>
            <tr>
                <td bgcolor="white" align="center">
                    <br />
                    <table width="95%" border="0" align="center" cellpadding="4" cellspacing="1" class="tbbg">
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                部门：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;<asp:DropDownList ID="ddlDepartmentID" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg">
                                用户名：
                            </td>
                            <td width="857" style="height: 40px" class="tbSbg" align="left">
                                &nbsp;&nbsp;
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                                <asp:Label ID="lblUserID" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                密码：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                确认密码：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;<asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                                <asp:CompareValidator ID="valCmp" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2"
                                    Display="Dynamic" ErrorMessage="确认密码与密码不符，请重新输入！"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                真实姓名：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;<asp:TextBox ID="txtTrueName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTrueName"
                                    Display="Dynamic" ErrorMessage="真实姓名不得为空！"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                性别：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                电话：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                邮件：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="40" align="right" class="tbTitleBg" style="width: 100px">
                                职务：
                            </td>
                            <td height="40" class="tbSbg" align="left">
                                &nbsp;<asp:TextBox ID="txtDuty" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" colspan="2" align="center" class="tbTitleBg">
                                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="修改" />
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
