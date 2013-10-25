using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;



public partial class Sales_SalesOrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Common.CheckRoleAndPermission.Check(0,10);
        if(!IsPostBack)
        {
            BLL.Sales.SalesOrderHeader bll = new BLL.Sales.SalesOrderHeader();
            Accounts.Bus.User currentUser = (Accounts.Bus.User)(Session["UserInfo"]);
            BLL.Accounts.Accounts_Department bllDept = new BLL.Accounts.Accounts_Department();
            this.lblRootDepartmentID.Text = bllDept.GetRootID(int.Parse(currentUser.DepartmentID)).ToString();
            this.lblStrWhere.Text = " RootDepartmentID=" + this.lblRootDepartmentID.Text;
            this.AspNetPager.RecordCount = bll.GetCount(this.lblStrWhere.Text);
            this.BindData();
            this.txtPageSize.Attributes.Add("onkeydown", "javascript:SetFocusPageSize();");
        }
        
    }

    /// <summary>
    /// 绑定GridView 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            //显示客户姓名
            Label lblCustomerName = (Label)(e.Row.FindControl("lblCustomerName"));
            BLL.Sales.Customer bllC = new BLL.Sales.Customer();
            Model.Sales.Customer mC = bllC.GetModel
                (int.Parse(this.myGridView.DataKeys
                [e.Row.RowIndex].Values["CustomerID"].ToString()));
            if(mC!=null)
            {
                lblCustomerName.Text = mC.CustomerName;
            }
            //显示设计师姓名
            Label lblDesigner = (Label)(e.Row.FindControl("lblDesigner"));
            BLL.Accounts.Accounts_Users bllUser = new BLL.Accounts.Accounts_Users();
            Model.Accounts.Accounts_Users mUser = bllUser.GetModel(this.myGridView.DataKeys[e.Row.RowIndex].Values["Designer"].ToString());
            lblDesigner.Text = mUser.TrueName;
            //显示提交状态
            Label lblStatusSubmit = (Label)(e.Row.FindControl("lblStatusSubmit"));
            string strStatusSubmit = this.myGridView.DataKeys[e.Row.RowIndex].Values["StatusSubmit"].ToString();
            switch (strStatusSubmit)
            {
                case "1":
                    lblStatusSubmit.Text = "初始添加";
                    lblStatusSubmit.ForeColor = System.Drawing.Color.Red;
                    break;
                case "2":
                    lblStatusSubmit.Text = "修改中";
                    lblStatusSubmit.ForeColor = System.Drawing.Color.Red;
                    break;
                case "3":
                    lblStatusSubmit.Text = "已提交";
                    lblStatusSubmit.ForeColor = System.Drawing.Color.Green;
                    break;
                default:
                    lblStatusSubmit.Text = "未知";
                    lblStatusSubmit.ForeColor = System.Drawing.Color.Red;
                    break;

            }
            //显示付款状态
            Label lblStatusPayment = (Label)(e.Row.FindControl("lblStatusPayment"));
            string strStatusPayment = this.myGridView.DataKeys[e.Row.RowIndex].Values["StatusPayment"].ToString();
            switch (strStatusPayment)
            {
                case "1":
                    lblStatusPayment.Text = "未付款";
                    lblStatusPayment.ForeColor = System.Drawing.Color.Red;
                    break;
                case "2":
                    lblStatusPayment.Text = "未付全款";
                    lblStatusPayment.ForeColor = System.Drawing.Color.Black;
                    break;
                case "3":
                    lblStatusPayment.Text = "已付全款 ";
                    lblStatusPayment.ForeColor = System.Drawing.Color.Green;
                    break;
                default :
                    lblStatusPayment.Text = "未知";
                    lblStatusPayment.ForeColor = System.Drawing.Color.Red;
                    break;

            }
            //显示订货状态
            Label lblStatusPurchaseMaterial = (Label)(e.Row.FindControl("lblStatusPurchaseMaterial"));
            string strStatusPurchaseMaterial = this.myGridView.DataKeys[e.Row.RowIndex].Values["StatusPurchaseMaterial"].ToString();
            switch (strStatusPurchaseMaterial)
            {
                case "1":
                    lblStatusPurchaseMaterial.Text = "未订货";
                    lblStatusPurchaseMaterial.ForeColor = System.Drawing.Color.Red;
                    break;
                case "2":
                    lblStatusPurchaseMaterial.Text = "部分订货";
                    lblStatusPurchaseMaterial.ForeColor = System.Drawing.Color.Red;
                    break;
                case "3":
                    lblStatusPurchaseMaterial.Text = "已经订货";
                    lblStatusPurchaseMaterial.ForeColor=System.Drawing.Color.Green;
                    break;
                default:
                    lblStatusPurchaseMaterial.Text="未知";
                    lblStatusPurchaseMaterial.ForeColor=System.Drawing.Color.Red;
                    break;



            }
            //显示流程状态
            Label lblStatusAll = (Label)(e.Row.FindControl("lblStatusAll"));
            string strStatusAll = this.myGridView.DataKeys[e.Row.RowIndex].Values["StatusAll"].ToString();
            switch (strStatusAll)
            {
                case "1":
                    lblStatusAll.Text = "未完成";
                    lblStatusAll.ForeColor = System.Drawing.Color.Red;
                    break;
                case "2":
                    lblStatusAll.Text = "已完成";
                    lblStatusAll.ForeColor = System.Drawing.Color.Green;
                    break;
                default:
                    lblStatusAll.Text = "未知";
                    lblStatusAll.ForeColor = System.Drawing.Color.Red;
                    break;


            }


        }
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.lblStrWhere.Text = "RootDepartmentID=" + this.lblRootDepartmentID.Text;

        StringBuilder strWhere = new StringBuilder();
        //客户名称不为空
        if(this.txtCustomerName.Text.Trim() !="")
        {
            strWhere.AppendFormat(" and CustomerName like '%{0}%'",Common.PageValidate.InputText(this.txtCustomerName.Text,50));

        }
        if(this.txtPhone.Text.Trim() != "")
        {
            strWhere.AppendFormat(" and Phone like '%{0}%'",Common.PageValidate.InputText(this.txtPhone.Text,20));
        }
        if(this.txtCellPhone.Text.Trim() !="")
        {
            strWhere.AppendFormat(" and CellPhone like '%{0}%'",Common.PageValidate.InputText(this.txtCellPhone.Text,20));
        }
        if(this.txtAddress.Text.Trim() !="")
        {
            strWhere.AppendFormat(" and Address like '%{0}%'",Common.PageValidate.InputText(this.txtAddress.Text,100));
        }

        StringBuilder strWhere2 = new StringBuilder();
        if(this.txtSalesOrderNumber.Text.Trim() !="")
        {
            strWhere2.AppendFormat(" and SalesOrderNumber like '%{0}%'",Common.PageValidate.InputText(this.txtSalesOrderNumber.Text,30));
        }

        StringBuilder strWhere3 = new StringBuilder();
        //strWhere2 > 0 ,SalesOrderNumber ,就并归到 StringBuilder3 
        if (strWhere2.Length > 0)
        {
            strWhere3.Append(strWhere2);
        }
        if (strWhere.Length > 0)
        {
            strWhere3.Append(" and CustomerID in (select CustomerID from Sales_Customer where ");
            strWhere3.Append(strWhere.ToString().Substring(5, strWhere.Length - 5));
            strWhere3.Append(")");
        }
        //并归到lblStrWhere 1
        if (strWhere3.Length > 0)
        {
            this.lblStrWhere.Text += strWhere3.ToString();
        }
        BLL.Sales.SalesOrderHeader bll = new BLL.Sales.SalesOrderHeader();
        this.AspNetPager.RecordCount = bll.GetCount(this.lblStrWhere.Text);
        this.BindData();


    }
    protected void btnSetPageSize_Click(object sender, EventArgs e)
    {
        if (this.txtPageSize.Text.Trim() != "")
        {
           if(this.txtPageSize.Text.Trim() !="")
           {
               this.AspNetPager.PageSize = int.Parse(this.txtPageSize.Text.Trim());
               this.BindData();
           }
           else
           {
               this.AspNetPager.PageSize = 10;
               this.BindData();
           }
        }
        else
        {
            this.AspNetPager.PageSize = 10;
            this.BindData();
        }

    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    public void BindData()
    {
        BLL.Sales.SalesOrderHeader bll = new BLL.Sales.SalesOrderHeader();
        DataSet ds = bll.GetList(this.AspNetPager.PageSize, this.AspNetPager.CurrentPageIndex, this.lblStrWhere.Text, "1");
        this.myGridView.DataSource = ds;
        this.myGridView.DataBind();
    }
}