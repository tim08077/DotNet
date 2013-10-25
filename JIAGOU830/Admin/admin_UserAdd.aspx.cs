using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;


public partial class Admin_admin_UserAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostBack)
        {
            Common.CheckRoleAndPermission.CheckLogin();
            Common.CheckRoleAndPermission.Check(0,1);
            BindDepartmentID();
        }

    }
    private void BindDepartmentID()
    {
        BLL.Accounts.Accounts_Department bll = new BLL.Accounts.Accounts_Department();
        DataSet ds = bll.GetDropdownListOption();
        this.ddlDepartmentID.DataSource = ds;
        this.ddlDepartmentID.DataTextField = "ClassName";
        this.ddlDepartmentID.DataValueField = "ClassID";
        this.ddlDepartmentID.DataBind();

    }
    protected void valCtm_ServerValidate(object source, ServerValidateEventArgs args)
    {
        BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
        if (blluser.Exists(Common.PageValidate.InputText(this.txtUserName.Text, 30)))
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            Model.Accounts.Accounts_Users user = new Model.Accounts.Accounts_Users();
            user.UserName = Common.PageValidate.InputText(this.txtUserName.Text, 30);
            user.Password = Common.PageValidate.InputText(this.txtPassword.Text, 30);
            user.TrueName = Common.PageValidate.Encode(this.txtTrueName.Text);
            if (rblSex.Items[0].Selected)
            {
                user.Sex = "男";
            }
            else
            {
                user.Sex = "女";
            }
            user.Phone = Common.PageValidate.Encode(this.txtPhone.Text);
            user.Email = Common.PageValidate.Encode(this.txtEmail.Text);
            user.DepartmentID = this.ddlDepartmentID.SelectedValue.ToString();
            user.Activity = true;
            user.Duty = Common.PageValidate.Encode(this.txtDuty.Text);
            BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
            try
            {
                blluser.Add(user);
                Common.MsgBox.Alert("添加用户成功！", "admin_UserAdd.aspx");

            }
            catch
            {
                Common.MsgBox.Alert("添加用户失败！", "admin_UserAdd.aspx");
            }
        }
    }
}