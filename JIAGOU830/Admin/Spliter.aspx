<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Spliter.aspx.cs" Inherits="Admin_Spliter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script>
        function switchSysBar() {
            if (switchPoint.innerText == 3) {
                switchPoint.innerText = 4;
                parent.middleset.cols = "0,*";
         }
            else {
                switchPoint.innerText = 3;
                parent.middleset.cols = "200,*";
         }
        }
    </script>
</head>
<body bgcolor='#edecec' topmargin="0" leftmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
      <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#99ccff" onclick="switchSysBar()">
        <tr>
           <td style="width:100%;" valign="middle">
              <span id="switchPoint" title="关闭/打开左栏" style="color:Blue;font-family:Webdings; cursor:hand;" >3</span>
           </td>
        </tr>
      </table>
     </form>
</body>
</html>
