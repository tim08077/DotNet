<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_UserList.aspx.cs" Inherits="Admin_admin_UserList" %>

<%@ Register Src="~/Admin/Controls/showCopyright.ascx" TagName="showCopyright" TagPrefix="uc1"  %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户列表</title>
    <!--服务器把名称/值 添加到发送给浏览器的内容头部 -->
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href="style/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server">
    <div>
      <table width="95%" border="0" align="center" cellspacing="0" cellpadding="0" class="tbbg">
        <tr>
           <td height="30" class="tbTopBg" align="center" >
             用户列表
           </td>
        </tr>
        <tr>
          <td bgcolor="white" align="center">
            <br />
            <table width="95%" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td height="30" align="right">
                  搜索用户名：<asp:TextBox ID ="txtUserName" runat="server"></asp:TextBox>
                  <asp:Button ID ="btnSearch"  runat="server" OnClick="btnSearch_Click" Text="搜索" />
                  <asp:Label ID="lblStrWhere" runat="server" Visible="false"></asp:Label>
                  <asp:DropDownList ID="ddlDepartmentID" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlDepartmentID_SelectedIndexChanged" ></asp:DropDownList>
                  <asp:Button ID ="btnShowAllUser" runat="server" OnClick="btnShowAllUser_Click" Text="查看所有用户" />
                </td>
              </tr>
            </table>
            <br />
                <asp:GridView ID ="myGridView" runat="server" Width="95%" AutoGenerateColumns="false" DataKeyNames="UserID">
                  <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="false" />
                    <asp:BoundField DataField="UserName" HeaderText="用户名" >
                       <ItemStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TrueName" HeaderText="真实姓名">
                       <ItemStyle HorizontalAlign="Center" Width="70px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="部门"> 
                       <ItemStyle HorizontalAlign="Center" />
                       <ItemTemplate>
                          <%# GetDepartment(Eval("DepartmentID").ToString()) %>
                       </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Sex" HeaderText="性别">
                       <ItemStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Duty" HeaderText="职务">
                        <ItemStyle Width="70px" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="UserID"  DataNavigateUrlFormatString="admin_UserRole.aspx?UserID={0}"
                         HeaderText="角色"  Text="角色" >
                         <ItemStyle Width="70px" HorizontalAlign="Center"/>
                    </asp:HyperLinkField>
                    <asp:HyperLinkField DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="admin_UserEdit.aspx?UserID={0}"
                         HeaderText="修改" Text="修改">
                         <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    <asp:TemplateField>
                      <HeaderTemplate>
                        <input type="checkbox" onclick="checkFormAll(this.checked)">
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:CheckBox ID ="chkSelect" runat="server"></asp:CheckBox>
                      </ItemTemplate>
                      <ItemStyle Width="20px" />
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
                &nbsp;<br />
                <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" CssClass="tbNormal"
                  CustomInfoHTML="共<font color='red'><b>%RecordCount%</b></font>条记录 Page  <font color='red'><b>%CurrentPageIndex%</b></font> of  %PageCount%&nbsp;&nbsp;Order %StartRecordIndex%-%EndRecordIndex%"
                  FirstPageText="首页" HorizontalAlign="Center" InputBoxStyle="width:19px" LastPageText="尾页"
                  meta:resourcekey="AspNetPager" NextPageText="后页" OnPageChanged="AspNetPager_PageChanged"
                  PageSize="10" PrevPageText="前页" ShowCustomInfoSection="Left" ShowInputBox="Always"
                  Style="font-size: 12px" Width="90%">
               </webdiyer:AspNetPager>
               &nbsp;&nbsp;<br />
               <table width="95%" border="0" cellpadding="0" cellspacing="0" align="center">
                 <tr>
                   <td height="30">
                      <asp:Button ID="btnDel" runat="server" Text="删除用户" OnClick="btnDel_Click" />
                   </td>
                 </tr>
               </table>
          </td>
        </tr>
      </table>
    </div>
    <uc1:showCopyright ID="ShowCopyright1" runat="server" />
    </form>
</body>
</html>

<script type="text/jscript">
    function checkFormAll(chk) {
        form = document.getElementById("<%=myForm.ClientID%>");
        for (var i = 0; i < form.elements.length; i++) {
            if (form.elements[i].type == "checkbox") {
                form.elements[i].checked = chk;
            }
        }
    }
</script>
