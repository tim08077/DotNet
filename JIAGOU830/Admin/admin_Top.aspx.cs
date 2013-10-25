using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Accounts.Bus;



public partial class Admin_admin_Top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Accounts.Bus.User currentUser = (Accounts.Bus.User)(Session["UserInfo"]);
        this.lblSignIn.Text = currentUser.UserName;

    }
}