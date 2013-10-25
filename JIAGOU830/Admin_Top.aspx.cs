using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Admin_Top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Accounts.Bus.User currentUser = (Accounts.Bus.User)(Session["UserInfo"]);
        this.lblSignIn.Text = currentUser.TrueName;
        this.lblDepartment.Text = System.DateTime.Now.ToString("yyyy年M月d日") + System.DateTime.Now.ToString("dddd");
        //显示部门信息 
        BLL.Accounts.Accounts_Department bllDept = new BLL.Accounts.Accounts_Department();
        this.lblDepartment.Text = bllDept.GetDepartmentPath(currentUser.DepartmentID);

    }
}