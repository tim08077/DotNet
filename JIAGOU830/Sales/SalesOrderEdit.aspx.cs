using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Sales_SalesOrderEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.CheckRoleAndPermission.CheckLogin();
        Common.CheckRoleAndPermission.Check(0,10);
        if(!IsPostBack)
        {
            if (Request.QueryString["SalesOrderID"] != null)
            {
                if (Common.PageValidate.IsNumber(Request.QueryString["SalesOrderID"].ToString()))
                {
                    this.lblSalesOrderID.Text = Request.QueryString["SalesOrderID"].ToString();
                }
                else
                {
                    Common.MsgBox.Alert_Close("参数错误!");
                }
            }
            else
            {
                Common.MsgBox.Alert_Close("参数错误！");
            }

            this.DataBind();

        }
    }

    private void DataBind()
    {
        this.txtDateOrder.Attributes["readonly"] = "true";//订单日期
        this.txtDateDelivery.Attributes["readonly"] = "true";//交货日期
        this.txtDateInspect.Attributes["readonly"] = "true";//验货日期
        this.txtDateInstall.Attributes["readonly"] = "true";//安装日期

        BLL.Sales.SalesOrderHeader bll = new BLL.Sales.SalesOrderHeader();
        Model.Sales.SalesOrderHeader m = bll.GetModel(int.Parse(this.lblSalesOrderID.Text));
        if (m != null)
        {
            Accounts.Bus.User currentUser = (Accounts.Bus.User)(Session["UserInfo"]);
            //if (m.Designer == currentUser.UserName)
            //{
                this.lblCustomerID.Text = m.CustomerID.ToString();
                BLL.Sales.Customer bllC = new BLL.Sales.Customer();
                Model.Sales.Customer mC = bllC.GetModel(int.Parse(this.lblCustomerID.Text));
                this.txtCustomerName.Text = mC.CustomerName;
                this.txtCellPhone.Text = mC.CallPhone;
                this.txtPhone.Text = mC.Phone;

                this.txtAddress.Text = m.Address;
                this.txtDateOrder.Text = m.DateOrder.ToString("yyyy-MM-dd");
                this.txtDateInspect.Text = m.DateInspect.ToString("yyyy-MM-dd");
                this.txtDateInstall.Text = m.DateInstall.ToString("yyyy-MM-dd");
                this.txtDateDelivery.Text = m.DateDelivery.ToString("yyyy-MM-dd");

                this.txtSalesOrderNumber.Text = m.SalesOrderNumber;

                this.txtNotesOrder.Text = m.NotesOrder;//订单备注
                this.txtNotesManufacture.Text = m.NotesManufacture;//制造备注
                this.txtNotesInstall.Text = m.NotesInstall;//安装备注

                this.lblContractAmount.Text = m.ContractAmount.ToString("c");//客户合同金额 
                this.lblSubTotal.Text = m.SubTotal.ToString("c");//用料合计金额 
                this.lblTotalDue.Text = m.TotalDue.ToString("c");//实收金额 
                this.lblBrokerage.Text = m.Brokerage.ToString("c");//其他金额 

                this.lblDesignerTrueName.Text = currentUser.UserName;//设计师
                this.lblDesignerUserName.Text = currentUser.UserName;//设计师

                if (m.StatusSubmit == "3")
                {
                    btnOK.Visible = false;
                    btnOK.Enabled = false;

                }

            //}
            //else
            //{
            //    Common.MsgBox.Alert_Close("不能修改其他人的订单");
            //}


        }
        else
        {
            Common.MsgBox.Alert_Close("参数错误");
        }


    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //根据CustomerID 修改客户信息
        BLL.Sales.Customer bllC = new BLL.Sales.Customer();
        Model.Sales.Customer mC = bllC.GetModel(int.Parse(this.lblCustomerID.Text));
        mC.CallPhone = Common.PageValidate.InputText(this.txtCellPhone.Text,20);
        mC.Phone = Common.PageValidate.InputText(this.txtPhone.Text,20);
        mC.CustomerName = Common.PageValidate.InputText(this.txtCustomerName.Text,50);
        mC.ModifiedDate = System.DateTime.Now;

        //修改销售订单信息 BY SalesOrderID 
        BLL.Sales.SalesOrderHeader bll = new BLL.Sales.SalesOrderHeader();
        Model.Sales.SalesOrderHeader m = bll.GetModel(int.Parse(this.lblSalesOrderID.Text));
        if (m != null)
        {
            m.Address = Common.PageValidate.InputText(this.txtAddress.Text, 100);

            m.DateOrder = Convert.ToDateTime(this.txtDateOrder.Text);//订单日期
            m.DateInspect = Convert.ToDateTime(this.txtDateInspect.Text);//验货日期
            m.DateInstall = Convert.ToDateTime(this.txtDateInstall.Text);//安装日期
            m.DateDelivery = Convert.ToDateTime(this.txtDateDelivery.Text);//交货日期

            m.SalesOrderNumber = Common.PageValidate.InputText(this.txtSalesOrderNumber.Text, 20);
            m.NotesOrder = Common.PageValidate.InputText(this.txtNotesOrder.Text, 200);
            m.NotesManufacture = Common.PageValidate.InputText(this.txtNotesManufacture.Text, 200);
            m.NotesInstall = Common.PageValidate.InputText(this.txtNotesInstall.Text, 200);
            m.ModifiedDate = System.DateTime.Now;

            try
            {
                bllC.Update(mC);
                bll.Update(m);
                Common.MsgBox.Alert_Close("修改订单成功！");
            }
            catch (Exception ex)
            {
                Common.MsgBox.Alert_Close("修改订单失败 ！" + ex.Message);

            }



        }
        else
        {
            Common.MsgBox.Alert_Close("订单不存在或已经被删除");
        }

    }
}