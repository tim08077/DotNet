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

public partial class Admin_admin_UserEdit : System.Web.UI.Page
{

    private int UserID;

    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Common.CheckRoleAndPermission.Check(0, 2);
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
                }
            }
            else
            {
                Common.MsgBox.Alert("参数错误！", "admin_UserList.aspx");
                //Response.End();
            }
            //绑定处室下拉列表框
            this.BindDepartmentID();
            //绑定其他页面数据
            BindData();
        }
    }

    /// <summary>
    ///绑定部门列表
    /// </summary>
    private void BindDepartmentID()
    {
        BLL.Accounts.Accounts_Department bll = new BLL.Accounts.Accounts_Department();
        DataSet ds = bll.GetDropdownListOption();
        this.ddlDepartmentID.DataSource = ds;
        this.ddlDepartmentID.DataTextField = "ClassName";
        this.ddlDepartmentID.DataValueField = "ClassID";
        this.ddlDepartmentID.DataBind();
    }

    /// <summary>
    /// 绑定页面数据
    /// </summary>
    private void BindData()
    {
        BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
        Model.Accounts.Accounts_Users user = blluser.GetModel(this.UserID);
        if (user == null)
        {
             Common.MsgBox.Alert("此用户不存在！", "admin_UserList.aspx");
            //Response.End();
        }
        else
        {
            this.lblUserName.Text = user.UserName;
            this.lblUserID.Text = user.UserID.ToString();
            this.txtTrueName.Text = user.TrueName;
            this.txtPhone.Text = Common.PageValidate.Decode(user.Phone);
            this.txtEmail.Text = Common.PageValidate.Decode(user.Email);
            if (user.Sex == "男")
            {
                this.rblSex.Items[0].Selected = true;
            }
            else
            {
                this.rblSex.Items[1].Selected = true;
            }
            //设置用户的处
            //for (int i = 0; i < this.ddlDepartment1.Items.Count; i++)
            //{
            //    if (this.ddlDepartmentID.Items[i].Value == user.DepartmentID)
            //    {
            //        this.ddlDepartmentID.SelectedIndex = i;
            //        break;
            //    }
            //}

            this.ddlDepartmentID.Items.FindByValue(user.DepartmentID.ToString()).Selected = true;
            this.txtDuty.Text = Common.PageValidate.Decode(user.Duty);


        }
    }

    /// <summary>
    /// 修改用户信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
            Model.Accounts.Accounts_Users user = blluser.GetModel(Convert.ToInt32(this.lblUserID.Text));
            user.UserName = Common.PageValidate.InputText(this.lblUserName.Text, 30);
            if (this.txtPassword.Text != "")
            {
                user.Password = this.txtPassword.Text;
            }
            else
            {
                //user.Password = blluser.GetModel(UserID).Password;
            }
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
            user.Duty = Common.PageValidate.Encode(this.txtDuty.Text);
            try
            {
                blluser.Update(user);
                Common.MsgBox.Alert("修改用户成功！", "admin_UserList.aspx");
            }
            catch
            {
                Common.MsgBox.Alert("修改用户失败！", "admin_UserList.aspx");
            }

        }
    }


}