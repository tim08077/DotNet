<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_Main.aspx.cs" Inherits="Admin_admin_Main" %>

<%@ Register Src="~/Admin/Controls/showCopyright.ascx" TagName="showCopyright" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="style/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="myform" runat="server">
       <table width="95%" border="0" cellpadding="0" cellspacing="0" align="center" class="tbbg">
         <tr>
           <td height="30" class="tbTopBg" align="center">系统说明
           </td>
          </tr>
          <tr>
                <td bgcolor="white" align="center">
                    <br />
                    <br />
                    <br />
                    &nbsp;<br />
                </td>
            </tr>
       </table>
       <uc1:showCopyright id="ShowCopyright1" runat="server">
       </uc1:showCopyright>
    </form>
</body>
</html>
