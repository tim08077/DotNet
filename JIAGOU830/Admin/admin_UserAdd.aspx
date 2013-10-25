<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_UserAdd.aspx.cs" Inherits="Admin_admin_UserAdd" %>

<%@ Register Src="Controls/showCopyright.ascx" TagName="showCopyright" TagPrefix="uc1"%>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="style/style.css" type="text/css" rel="stylesheet" />
 </head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0" class="tbbg">
        <tr>
          <td height="30" class="tbTopBg" align="center">
             添加用户
          </td>
        </tr>
        <tr>
          <td bgcolor="white" align="center">
             <br />
            <table width="95%" border="0" align="center" cellpadding="4" cellspacing="1" class="tbbg">
               <tr>
                 <td width="100" height="40" align="right" class="tbTitleBg" style="width:100px">
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
                 <td width="857" style="height:40px" class="tbSbg" align="left">
                   &nbsp;
                   <asp:TextBox ID ="txtUserName"  runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="用户名不能为空! " ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="valCtm" runat="server" ControlToValidate="txtUserName" 
                         Display="Dynamic" ErrorMessage="此用户名已经存在，请输入其它用户名！" 
                         onservervalidate="valCtm_ServerValidate" ForeColor="Red" ></asp:CustomValidator>
                 </td>
               </tr>
               <tr>
                  <td width="100" height="40" align="right" class="tbTitleBg" style="width:100px">
                  密码：</td>
                  <td height="40" class="tbSbg" align="left">
                    &nbsp;
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="密码不能为空" ForeColor="red"></asp:RequiredFieldValidator> 
                  </td>

               </tr>
               <tr>
                 <td width="100" height="40" class="tbTitleBg" align="right" style="width:100px">确认密码： </td>
                 <td height="40" class="tbSbg" align="left">
                   &nbsp;<asp:TextBox ID ="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID ="RequiredFieldValidator3" runat="server" 
                         ControlToValidate="txtPassword2" Display="Dynamic" 
                     ErrorMessage="确认密码不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="valCmp" runat="server" ControlToCompare="txtPassword" 
                         ControlToValidate ="txtPassword2" Display="Dynamic" 
                      ErrorMessage="确认密码和密码不相符，请重新输入" ForeColor="Red"></asp:CompareValidator>
                 </td>
                 
               </tr>
               <tr>
                 <td width="100" height="40" class="tbTitleBg" align="right" style="width:100px" >真实姓名： 
                 </td>
                 <td height="40" class="tbSbg" align="left" >
                   <asp:TextBox ID="txtTrueName" runat="server" >
                   </asp:TextBox>
                   <asp:RequiredFieldValidator ID ="RequiredFieldValidator4"  runat="server" ControlToValidate="txtTrueName"  Display="Dynamic"
                        ErrorMessage="真实姓名不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
               </tr>
               <tr>
                 <td width="100" height="40" class="tbTitleBg" align="right" style="width:100">性别：</td>
                 <td height="40" class="tbSbg" align="left">
                   <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                     <asp:ListItem Value="2">女</asp:ListItem>
                   </asp:RadioButtonList>
                 </td>
               </tr>
               <tr>
                 <td width="100" height="40" class="tbTitleBg" align="right" style="width:100px" >电话：
                 </td>
                 <td height="40" class="tbSbg" align="left" >
                   <asp:TextBox ID ="txtPhone" runat="server"></asp:TextBox>
                 </td> 
               </tr>
              <tr> 
                 <td width="100" height="40" class="tbTitleBg " align="right" style ="width:100px">邮件： 
                 </td>
                 <td height="40" class="tbSbg" align="left"> 
                    <asp:TextBox id="txtEmail" runat="server" ></asp:TextBox>
                 </td>
              </tr>
              <tr>
                <td width="100" height="40" class="tbTitleBg" align="right" style="width:100px">职务：</td>
                <td height="40" class="tbSbg" align="left">
                <asp:TextBox ID="txtDuty" runat="server"></asp:TextBox></td>
               </tr>
               <td colspan="2" height="40" class="tbTitleBg" align="center">
                   <asp:Button ID="btnAdd" runat="server" Text="确定" OnClick="btnAdd_Click" />
               </td>

              
             
            </table>

          </td>
        </tr>

      </table>
    
    </div>
    </form>
</body>
</html>
