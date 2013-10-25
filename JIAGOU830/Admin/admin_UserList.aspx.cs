using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


public partial class Admin_admin_UserList : System.Web.UI.Page
{

    private string strWhere = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Common.CheckRoleAndPermission.CheckLogin();
            Common.CheckRoleAndPermission.Check(0,2);
            BindDepartmentID();
            BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
            this.AspNetPager.RecordCount = blluser.GetCount(strWhere);
            BindGridView();
            this.btnDel.Attributes.Add("onclick", "return confirm('确认删除吗？');");
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
    private void BindGridView()
    {
        strWhere = this.lblStrWhere.Text;
        BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
        DataSet ds = blluser.GetList(this.AspNetPager.PageSize, this.AspNetPager.CurrentPageIndex, strWhere, "0");
        this.myGridView.DataSource = ds;
        this.myGridView.DataBind();
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindGridView();
    }


    public string GetDepartment(string DepartmentID)
    {
        StringBuilder strDepartment = new StringBuilder();

        BLL.Accounts.Accounts_Department bll = new BLL.Accounts.Accounts_Department();
        Model.Accounts.Accounts_Department m = bll.GetModel(int.Parse(DepartmentID));
        string parentPath = m.ParentPath;
        string selfDeptName = m.ClassName;
        //取得父级路径部门名称
        string[] arrParentDept = parentPath.Split(',');
        if (arrParentDept.Length > 1)
        {
            for (int i = 1; i < arrParentDept.Length; i++)
            {
                m = bll.GetModel(int.Parse(arrParentDept[i]));
                strDepartment.Append(m.ClassName);
                strDepartment.Append("/");
            }
        }
        strDepartment.Append(selfDeptName);

        return strDepartment.ToString();
    }




    /// <summary>
    /// 显示所有用户
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowAllUser_Click(object sender, EventArgs e)
    {
        this.lblStrWhere.Text = "";
        //确定数据数量
        BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
        this.AspNetPager.RecordCount = blluser.GetCount("");
        BindGridView();
    }

    /// <summary>
    /// 搜索用户
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("UserName like '%");
        strSql.Append(Common.PageValidate.InputText(this.txtUserName.Text, 30));
        strSql.Append("%'");
        strWhere = strSql.ToString();
        //用一个隐藏Label保存查询条件
        this.lblStrWhere.Text = strWhere;
        //确定数据数量
        BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
        this.AspNetPager.RecordCount = blluser.GetCount(strWhere);
        BindGridView();
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDel_Click(object sender, EventArgs e)
    {
        //遍历所有的 chkSelect 找出那些项需要删除
        string strDel = "";
        foreach (GridViewRow gr in this.myGridView.Rows)
        {
            CheckBox chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked)
            {
                strDel = strDel + this.myGridView.DataKeys[gr.RowIndex].Value + ",";
            }
        }
        if (strDel != "")
        {
            BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
            //去掉最后的逗号
            strDel = strDel.Substring(0, strDel.Length - 1);
            //删除用户
            blluser.Delete(" UserID in (" + strDel + ")");
            //删除用户角色表中的数据
            BLL.Accounts.Accounts_UserRoles bllur = new BLL.Accounts.Accounts_UserRoles();
            bllur.Delete(" UserID in (" + strDel + ")");
            //重新绑定数据
            this.AspNetPager.RecordCount = blluser.GetCount(this.lblStrWhere.Text);
            this.BindGridView();
        }
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDepartmentID control.部门列表变动时重新绑定用户列表数据
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void ddlDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BLL.Accounts.Accounts_Department bll = new BLL.Accounts.Accounts_Department();
        Model.Accounts.Accounts_Department m = bll.GetModel(int.Parse(this.ddlDepartmentID.SelectedValue));

        StringBuilder strSql = new StringBuilder();
        strSql.Append("DepartmentID in (");
        strSql.Append(m.arrChildID.ToString());
        strSql.Append(")");
        strWhere = strSql.ToString();
        //用一个隐藏Label保存查询条件
        this.lblStrWhere.Text = strWhere;
        //确定数据数量
        BLL.Accounts.Accounts_Users blluser = new BLL.Accounts.Accounts_Users();
        this.AspNetPager.RecordCount = blluser.GetCount(strWhere);
        BindGridView();
    }
}