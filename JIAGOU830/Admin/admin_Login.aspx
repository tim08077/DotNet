<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_Login.aspx.cs" Inherits="Admin_admin_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css"  type="text/css" rel="stylesheet" />
</head>
<body id="userlogin_body">
    <form id="myForm" runat="server">
    <div>
       <table width="500" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#EEEEE2" class="tbborder1"
        style="background-image:url(images/login_bg.gif)">
          <tr>
            <td style="height:80px">
            </td>
          </tr>
          <tr>
            <td style="height:170px;"><br />
              <table width="400" border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                  <td align="center">
                      <act:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                      </act:ToolkitScriptManager>
                      <br />
                      <table width="400" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td height="30" align="right" style="width:150px">&nbsp;用户名：</td>
                          <td height="30">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="30">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID ="valRFUserName" runat="server" 
                                  ErrorMessage="用户名不能为空" ControlToValidate="txtUserName" Display="None" 
                                  ForeColor="Red"></asp:RequiredFieldValidator>
                              <act:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="valRFUserName">
                              </act:ValidatorCalloutExtender>
                          </td>
                        </tr>
                        <tr>
                          <td height="30" align="right" style="width:150px">&nbsp;密码：
                          </td>
                          <td> 
                            <asp:TextBox ID="txtPassword"  runat="server" TextMode="Password" MaxLength="30" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valRFPassword" runat="server" 
                                  ErrorMessage="密码不能为空" ControlToValidate="txtPassword" Display="None" 
                                  ForeColor="Red"></asp:RequiredFieldValidator>
                              <act:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="valRFPassword">
                              </act:ValidatorCalloutExtender>
                          </td>
                        </tr>
                      </table>
                  </td>
                </tr>
                <tr>
                  <td align="center">
                    <br />
                       <asp:ImageButton ID="imgLogin" runat="server" ImageUrl="~/Admin/images/login.gif" OnClick="imgLogin_Click" />
                    <br />
                  </td>
                </tr>
                <tr>
                  <td align="center" height="50">
                    &nbsp;Copyright © 2010 Poseidon
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
