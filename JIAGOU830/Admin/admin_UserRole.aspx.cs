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

public partial class Admin_admin_UserRole : System.Web.UI.Page
{
    private int UserID;
    /// <summary>
    /// 页面载入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Common.CheckRoleAndPermission.Check(0, 3);
        if (!this.IsPostBack)
        {
            if (Request.QueryString["UserID"] != null)
            {
                string strUserID = Request.QueryString["UserID"].ToString();
                if (!Common.PageValidate.IsNumber(strUserID))
                {
                    Common.MsgBox.Alert("参数错误！", "admin_UserList.aspx");
                    //Response.End();
                }
                else
                {
                    UserID = Convert.ToInt32(strUserID);
                    BindData();//绑定当前用户
                    BindRoleClass();//绑定角色分类
                    BindUserRoleNo();//绑定当前用户、当前角色分类下用户还没有的角色
                    BindUserRoleYes();//绑定当前用户、当前角色分类下已经拥有的角色
                }
            }
            else
            {
                Common.MsgBox.Alert("参数错误！", "admin_UserList.aspx");
                //Response.End();
            }
        }
    }
    //绑定当前用户
    private void BindData()
    {
        this.lblUserID.Text = UserID.ToString();
        BLL.Accounts.Accounts_Users bllUser = new BLL.Accounts.Accounts_Users();
        Model.Accounts.Accounts_Users user = bllUser.GetModel(UserID);
        this.lblUserName.Text = user.UserName;
        this.lblTrueName.Text = user.TrueName;

    }

    private void BindRoleClass()
    {
        BLL.Accounts.Accounts_RoleClass bllrc = new BLL.Accounts.Accounts_RoleClass();
        DataSet ds = bllrc.GetAllList();
        this.ddlRoleClass.DataSource = ds;
        this.ddlRoleClass.DataTextField = "RoleClassName";
        this.ddlRoleClass.DataValueField = "RoleClassID";
        this.ddlRoleClass.DataBind();

    }

    /// <summary>
    /// 绑定当前用户、当前角色分类下用户还没有的角色
    /// </summary>
    private void BindUserRoleNo()
    {
        //绑定前先移除所有的项
        this.lboxNo.Items.Clear();
        //如果有一个参数选择项为空则不绑定
        if (this.ddlRoleClass.SelectedIndex > -1)
        {
            BLL.Accounts.Accounts_Roles bllrole = new BLL.Accounts.Accounts_Roles();
            DataSet ds = bllrole.GetRoleNo(Convert.ToInt32(this.ddlRoleClass.SelectedValue), Convert.ToInt32(this.lblUserID.Text));
            this.lboxNo.DataSource = ds;
            this.lboxNo.DataTextField = "RoleDescription";
            this.lboxNo.DataValueField = "RoleCode";
            this.lboxNo.DataBind();
        }
    }
    /// <summary>
    /// 绑定当前用户、当前角色分类下已经拥有的角色
    /// </summary>
    private void BindUserRoleYes()
    {
        //绑定前先移除所有的项
        this.lboxYes.Items.Clear();
        //如果有一个参数选择项为空则不绑定
        if (this.ddlRoleClass.SelectedIndex > -1)
        {
            BLL.Accounts.Accounts_Roles bllrole = new BLL.Accounts.Accounts_Roles();
            DataSet ds = bllrole.GetRoleYes(Convert.ToInt32(this.ddlRoleClass.SelectedValue), Convert.ToInt32(this.lblUserID.Text));
            this.lboxYes.DataSource = ds;
            this.lboxYes.DataTextField = "RoleDescription";
            this.lboxYes.DataValueField = "RoleCode";
            this.lboxYes.DataBind();
        }
    }


    /// <summary>
    /// 添加角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            if (this.lboxNo.SelectedIndex > -1)
            {
                int roleCode = Convert.ToInt32(this.lboxNo.SelectedValue);
                int userID = Convert.ToInt32(this.lblUserID.Text);
                BLL.Accounts.Accounts_UserRoles bllur = new BLL.Accounts.Accounts_UserRoles();
                if (!bllur.Exists(userID, roleCode))
                {
                    Model.Accounts.Accounts_UserRoles ur = new Model.Accounts.Accounts_UserRoles();
                    ur.UserID = userID;
                    ur.RoleCode = roleCode;
                    bllur.Add(ur);
                    //重新绑定角色列表
                    BindUserRoleNo();
                    BindUserRoleYes();
                }
                else
                {
                    Common.MsgBox.Alert("请不要重复提交数据！", "admin_UserRole.aspx?UserID=" + this.lblUserID.Text);
                }
            }
        }
    }

    /// <summary>
    /// 移除角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            if (this.lboxYes.SelectedIndex > -1)
            {
                int roleCode = Convert.ToInt32(this.lboxYes.SelectedValue);
                int userID = Convert.ToInt32(this.lblUserID.Text);
                BLL.Accounts.Accounts_UserRoles bllur = new BLL.Accounts.Accounts_UserRoles();
                bllur.Delete(userID, roleCode);
                //重新绑定角色列表
                BindUserRoleNo();
                BindUserRoleYes();
            }
        }
    }
    protected void ddlRoleClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindUserRoleNo();
        BindUserRoleYes();
    }
}