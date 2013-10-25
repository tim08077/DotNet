using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;
using Accounts.Bus;

public partial class Admin_admin_Login : System.Web.UI.Page
{
    private string referURL = "admin_index.html";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgLogin_Click(object sender, ImageClickEventArgs e)
    {
        string username = txtUserName.Text.Trim();
        string password = txtPassword.Text.Trim();
        Accounts.Bus.AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(username,password);
        if (newUser == null)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

        }
        else
        {
            Accounts.Bus.User currentUser = new Accounts.Bus.User(newUser);
            Context.User = newUser;
            Session["UserInfo"] = currentUser;
            Session["UserRoleAndPermiison"] = newUser;
            System.Web.Security.FormsAuthentication.SetAuthCookie(Context.User.Identity.Name, false);
            Response.Redirect(referURL, false);

        }
    }
}