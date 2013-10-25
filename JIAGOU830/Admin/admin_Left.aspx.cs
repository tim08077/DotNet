using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Accounts.Bus;

public partial class Admin_admin_Left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        BindMenu();
    }

    private void BindMenu()
    {
        
        AccountsPrincipal user = (AccountsPrincipal)(Session["UserRoleAndPermiison"]);
        ArrayList roleCodeList = user.RolesCode;
        for (int i = 0; i < roleCodeList.Count;i++ )
        {
            this.Menu.UserRoles.Add(roleCodeList[i].ToString());
        }
        this.Menu.DataSource = Server.MapPath("AdminMenu.xml");
        this.Menu.DataBind();
    }
}