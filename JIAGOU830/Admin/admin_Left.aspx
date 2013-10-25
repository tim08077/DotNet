<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_Left.aspx.cs" Inherits="Admin_admin_Left" %>

<%@ Register Assembly="skmMenu" Namespace="skmMenu" TagPrefix="skmMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="style/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <skmMenu:Menu ID="Menu" runat="server" CssClass="tbNormal" Cursor="Pointer">
           <UnselectedMenuItemStyle BackColor="#ECF4FF" Height="25px" Width="80px" HorizontalAlign="Center" />
           <SelectedMenuItemStyle BackColor="#91AFDD" Height="25px" Width="80px" HorizontalAlign="Center" />
       </skmMenu:Menu>
    </div>
    </form>
</body>
</html>
