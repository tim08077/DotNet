using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//使用事务必须引用EnterpriseServices
using System.EnterpriseServices;


public partial class Sales_NeedMaterialHeaderEditFromSalesOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Common.CheckRoleAndPermission.Check(0,11);
        if( !this.IsPostBack)
        {
            if (Request.QueryString["SalesOrderID"] != null)
            {
                if (Common.PageValidate.IsNumber(Request.QueryString["SalesOrderID"].ToString()))
                {
                    this.lblSalesOrderID.Text = Request.QueryString["SalesOrderID"].ToString();
                }
                else
                {
                    Common.MsgBox.Alert_Close("参数错误！");
                }
            }
            else
            {
                Common.MsgBox.Alert_Close("参数错误！");
            }
            //设置经办人信息
            Accounts.Bus.User currentUser = (Accounts.Bus.User)(Session["UserInfo"]);
            this.lblManagerUserName.Text = currentUser.UserName;
            this.lblManagerTrueName.Text = currentUser.TrueName;
            //设置根部门ID 
            BLL.Accounts.Accounts_Department bllDept = new BLL.Accounts.Accounts_Department();
            this.lblRootDepartmentID.Text = bllDept.GetRootID(int.Parse(currentUser.DepartmentID)).ToString();
            //给日期框添加只读信息，不能在属性里直接设置，不然会取不到值 
            this.txtDateOrder.Attributes["readonly"] = "true";
            this.txtDateOrder.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.ShowSalesOrderHeaderInfo();



        }
    }


    private void ShowSalesOrderHeaderInfo()
    {
        BLL.Sales.SalesOrderHeader bllHeader = new BLL.Sales.SalesOrderHeader();
        Model.Sales.SalesOrderHeader mHeader = bllHeader.GetModel(int.Parse(this.lblSalesOrderID.Text));
        if(mHeader !=null)
        {
            //判断是否为本店订单
            if (int.Parse(lblRootDepartmentID.Text) == mHeader.RootDepartmentID)
            {
                if (mHeader.StatusAll == "2")
                {
                    this.pnlAdd.Visible = false;
                    this.pnlAdd.Enabled = false;
                }
                //显示订单编号，订单描述
                this.lblSalesOrderNumber.Text = mHeader.SalesOrderNumber;
                this.lblNotesOrder.Text = mHeader.NotesOrder;
                //显示用户名称
                BLL.Accounts.Accounts_Users bllUser = new BLL.Accounts.Accounts_Users();
                Model.Accounts.Accounts_Users mUser = bllUser.GetModel(mHeader.Designer);
                this.lblDesigner.Text = mUser.TrueName;
                this.BindNeedMaterialHeader();//绑定GridView 

            }
            else
            {
                Common.MsgBox.Alert_Close("只能操作本店的订单");
            }
            
        }
        else
        {
            Common.MsgBox.Alert("参数错误！", "SalesOrderListForPurchaseOrderHeader.aspx");
        }
    }
    /// <summary>
    /// 绑定GridView 
    /// </summary>
    private void BindNeedMaterialHeader()
    {
        BLL.NeedMaterialHeader bllHeader = new BLL.NeedMaterialHeader();
        DataSet ds = bllHeader.GetList("SalesOrderID=" +this.lblSalesOrderID.Text);
        this.myGridView.DataSource = ds;
        this.myGridView.DataBind();
    }
    /// <summary>
    /// 绑定GridView的表单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)//判断是否为数据行
        {
            //设置经办人姓名
            Label lblManagerName = (Label)(e.Row.FindControl("lblManagerName"));
            BLL.Accounts.Accounts_Users bllUser = new BLL.Accounts.Accounts_Users();
            Model.Accounts.Accounts_Users mUser = bllUser.GetModel(this.myGridView.DataKeys[e.Row.RowIndex].Values["Manager"].ToString());
            lblManagerName.Text = mUser.TrueName;
            
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
                    lblStatusSubmit.Text = "已经提交";
                    lblStatusSubmit.ForeColor = System.Drawing.Color.Green;
                    break;
                case "3":
                    lblStatusSubmit.Text = "未知";
                    lblStatusSubmit.ForeColor = System.Drawing.Color.Red;
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
                    lblStatusPurchaseMaterial.Text = "已经订货";
                    lblStatusPurchaseMaterial.ForeColor = System.Drawing.Color.Green;
                    break;
                case "3":
                    lblStatusPurchaseMaterial.Text = "未知";
                    lblStatusPurchaseMaterial.ForeColor = System.Drawing.Color.Red;
                    break;



            }


            
        }
    }
    /// <summary>
    /// 判断是否至少添加了至少一个订单项
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
         if(myGridView.Rows.Count >0)
         {
             args.IsValid = true;
         }
         else
         {
             args.IsValid = false;
         }
    }
    /// <summary>
    /// 添加用料单按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddOrder_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            this.lblMsg2.Text = string.Empty;

            BLL.NeedMaterialHeader bll = new BLL.NeedMaterialHeader();
            Model.Sales.NeedMaterialHeader m = new Model.Sales.NeedMaterialHeader();
            m.SalesOrderID = int.Parse(this.lblSalesOrderID.Text);//订单编号
            m.DateOrder = Convert.ToDateTime(this.txtDateOrder.Text);//订单时间
            m.Manager = this.lblManagerUserName.Text;//管理者
            m.ModifiedDate = System.DateTime.Now;//修订日期
            m.RootDepartmentID = int.Parse(this.lblRootDepartmentID.Text);//根部门id  

            m.StatusPurchaseMaterial = "1";
            m.StatusStockOut = "1";
            m.StatusSubmit = "1";
            try
            {
                bll.Add(m);//添加用料单

                //回写销售单： 提交状态，采购原材料状态
                BLL.Sales.SalesOrderHeader bllOrderheader = new BLL.Sales.SalesOrderHeader();
                Model.Sales.SalesOrderHeader mOrderheader = bllOrderheader.GetModel(int.Parse(this.lblSalesOrderID.Text));
                //获取当前销售订单的提交状态
                mOrderheader.StatusSubmit = bllOrderheader.GetStatusSubmit(mOrderheader.SalesOrderID);
                //获取材料订单的提交状态 
                mOrderheader.StatusPurchaseMaterial = bllOrderheader.GetStatusPurchaseMaterial(mOrderheader.SalesOrderID);
                bllOrderheader.Update(mOrderheader);
                this.lblMsg2.Text = "添加成功 !请确认用料单明细";
                this.BindNeedMaterialHeader();//绑定订单概况列表
                ContextUtil.SetComplete();//提交事务 


            }
            catch(Exception ex)
            {
                ContextUtil.SetAbort();//撤销事务
                this.lblMsg2.Text = "添加错误，错误消息:" +ex.Message;
            }

        }
    }
    protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.lblMsg2.Text = string.Empty;
        BLL.NeedMaterialHeader bll=new BLL.NeedMaterialHeader();
        try
        {
            //删除用料订单
            bll.Delete(int.Parse(this.myGridView.DataKeys[e.RowIndex].Values["NeedMaterialID"].ToString()));
            //回写销售订单状态
            BLL.Sales.SalesOrderHeader bllOrderHeader=new BLL.Sales.SalesOrderHeader();
            Model.Sales.SalesOrderHeader mOrderHeader=bllOrderHeader.GetModel(int.Parse(this.lblSalesOrderID.Text));
            mOrderHeader.StatusSubmit=bllOrderHeader.GetStatusSubmit(mOrderHeader.SalesOrderID);
            mOrderHeader.StatusPurchaseMaterial=bllOrderHeader.GetStatusPurchaseMaterial(mOrderHeader.SalesOrderID);
            bllOrderHeader.Update(mOrderHeader);
            this.BindNeedMaterialHeader();
            ContextUtil.SetComplete();
        }
        catch(Exception ex)
        {
            ContextUtil.SetAbort();
            this.lblMsg2.Text = "删除失败，错误信息：" +ex.Message;

        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if(this.IsValid)
        {
            Common.MsgBox.Alert("修改用料单成功，将返回订单列表", "SalesOrderList.aspx");
        }
    }
}