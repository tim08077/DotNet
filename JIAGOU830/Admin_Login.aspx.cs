using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounts.Bus;

public partial class Admin_Login : System.Web.UI.Page
{
    private string referURL = "Admin_Index.html";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.lblCurrentYear.Text = System.DateTime.Now.Year.ToString();
        }
    }
    protected void imgLogin_Click(object sender, ImageClickEventArgs e)
    {
        string userName = this.txtUserName.Text.Trim();
        string password = this.txtPassword.Text.Trim();
        Accounts.Bus.AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(userName,password);
        if (newUser == null)
        {
            this.lblMsg.Text = "登陆失败，用户名或密码错误";
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