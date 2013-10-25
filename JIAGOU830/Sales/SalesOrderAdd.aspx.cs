using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Text;


public partial class Sales_SalesOrderAdd : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.CheckRoleAndPermission.CheckLogin();
            Common.CheckRoleAndPermission.Check(0, 10);
            if (!IsPostBack)
            {
                //设置经办人
                Accounts.Bus.User currentUser = (Accounts.Bus.User)(Session["UserInfo"]);
                this.lblCurrentUser.Text = currentUser.UserName;
                this.lblDesignerUserName.Text = currentUser.UserName;
                this.lblDesignerTrueName.Text = currentUser.TrueName;
                //设置部门ID 
                BLL.Accounts.Accounts_Department bllDept = new BLL.Accounts.Accounts_Department();
                this.lblRootDepartmentID.Text = bllDept.GetRootID(int.Parse(currentUser.DepartmentID)).ToString();
                //给日期输入框添加只读属性，不能在属性里直接设置，不然会取不到值
                this.txtDateDelivery.Attributes["readonly"] = "true";
                this.txtDateInspect.Attributes["readonly"] = "true";
                this.txtDateInstall.Attributes["readonly"] = "true";
                this.txtDateOrder.Attributes["readonly"] = "true";
                this.txtDateDelivery.Text = System.DateTime.Now.AddDays(20).ToString("yyyy-MM-dd");
                this.txtDateInspect.Text = System.DateTime.Now.AddDays(21).ToString("yyyy-MM-dd");
                this.txtDateInstall.Text = System.DateTime.Now.AddDays(22).ToString("yyyy-MM-dd");
                this.txtDateOrder.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                this.textSearch.Attributes.Add("onkeydown", "javascript:SetFocusSearch();");

                


            }


        }
        /// <summary>
        /// 查询老客户 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        { 
            if(this.textSearch.Text.Trim() !="")
            {
                BLL.Sales.Customer bll = new BLL.Sales.Customer();
                StringBuilder strSql = new StringBuilder();
                string strSearch = Common.PageValidate.InputText(this.textSearch.Text,50);
                strSql.AppendFormat(" or  CustomerName like  '%{0}%'",strSearch);
                strSql.AppendFormat(" or  Phone like '%{0}%'",strSearch);
                strSql.AppendFormat(" or  CellPhone like '%{0}%'", strSearch);
                strSql.AppendFormat(" or  Address like '%{0}%'",strSearch);
                DataSet ds = bll.GetList(strSql.ToString().Substring(4,strSql.Length-4));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.pnlCustomerSelect.Visible = true;
                    this.rbtnlCustomer.DataSource = ds;
                    this.rbtnlCustomer.DataTextField = "CustomerName";
                    this.rbtnlCustomer.DataValueField = "CustomerID";
                    this.rbtnlCustomer.DataBind();
                    this.lblMsg.Visible = false;
                }
                else
                {
                    this.rbtnlCustomer.Items.Clear();
                    this.lblMsg.Visible = true;
                    this.lblMsg.Text = "搜索不到用户，请添加客户";
                }

                 

            }
        }

                      
        protected void rbtnlCustomer_SelectIndexChanged(object sender, EventArgs e)
        {
            if(this.rbtnlCustomer.SelectedItem !=null)
            {
                BLL.Sales.Customer bll = new BLL.Sales.Customer();
                Model.Sales.Customer m = bll.GetModel(int.Parse(this.rbtnlCustomer.SelectedValue));
                if(m !=null)
                {
                    this.pnlCustomerInfo.Visible = true;
                    this.lblCustomerName.Text = m.CustomerName;
                    this.lblCellPhone.Text = m.CallPhone;
                    this.lblPhone.Text = m.Phone;
                }

            }
        }
        /// <summary>
        /// 查询老客户  确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirmCustomer_Click(object sender, EventArgs e)
        {
            if(this.IsValid)
            {
                this.lblCustomerID.Text = this.rbtnlCustomer.SelectedValue;
                this.rbtnlCustomer.Enabled = false;
                this.pnlSalesOrderInfo.Visible = true;
                this.btnConfirmCustomer.Enabled = false;
            }
        }
        /// <summary>
        ///  添加新客户 ，添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                BLL.Sales.Customer bll = new BLL.Sales.Customer();
                Model.Sales.Customer m = new Model.Sales.Customer();
                m.CallPhone = Common.PageValidate.InputText(this.txtCallPhone.Text, 20);
                m.CustomerName = Common.PageValidate.InputText(this.txtCustomerName.Text, 50);
                m.ModifiedDate = System.DateTime.Now;        //修改日期
                //清理字符串中的特殊符号
                m.Phone = Common.PageValidate.InputText(this.txtPhone.Text, 20);
                try
                {
                    this.lblCustomerID.Text = bll.Add(m).ToString();
                    //显示不能用
                    this.txtPhone.Enabled = false;
                    this.txtCallPhone.Enabled = false;
                    this.txtCustomerName.Enabled = false;
                    this.btnAddCustomer.Enabled = false;
                    // 显示pannel 可见
                    this.pnlCustomerInfo.Visible = true;

                }
                catch (Exception ex)
                {
                    this.lblMsgAdd.Text = "添加错误信息失败！错误信息：" +ex.Message;
                }
            }
        }
        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if(this.IsValid)
            {
                //实例化销售订单业务逻辑类与实体类
                BLL.Sales.SalesOrderHeader bll = new BLL.Sales.SalesOrderHeader();
                Model.Sales.SalesOrderHeader m = new Model.Sales.SalesOrderHeader();
                //从用户界面中获取订单输入，作为实体类的属性
                m.Address = Common.PageValidate.InputText(this.txtAddress.Text, 100);
                m.CustomerID = int.Parse(this.lblCustomerID.Text);
                m.DateDelivery = Convert.ToDateTime(this.txtDateDelivery.Text);//交货日期
                m.DateInspect = Convert.ToDateTime(this.txtDateInspect.Text);//验货日期
                m.DateInstall = Convert.ToDateTime(this.txtDateInstall.Text);//安装日期
                m.DateOrder = Convert.ToDateTime(this.txtDateOrder.Text);//订单日期
                m.DateAllDone = Convert.ToDateTime("9999-1-1");
                m.Designer = this.lblDesignerUserName.Text;
                m.ModifiedDate = System.DateTime.Now;
                m.NotesInstall = Common.PageValidate.InputText
                    (this.txtNotesInstall.Text, 200);
                m.NotesManufacture = Common.PageValidate.InputText
                    (this.txtNotesManufacture.Text, 200);
                m.NotesOrder = Common.PageValidate.InputText
                    (this.txtNotesOrder.Text, 200);
                m.SalesOrderNumber = Common.PageValidate.InputText
                    (this.txtSalesOrderNumber.Text, 30);
                //初始化付款与汇总属性
                m.Brokerage = 0;//手续费
                m.SubTotal = 0;//小计
                m.TotalDue = 0;//全额还款金额 
                m.RealIncome = 0;//入账
                m.ContractAmount = 0;//合同金额 
                m.PrepaidPayment = 0;//预付款
                m.Producer = string.Empty;//生产者
                m.ResidualPayment = 0;//余款
                m.RootDepartmentID = int.Parse(this.lblRootDepartmentID.Text);
                //初始添加，状态位设置为 1
                m.StatusAll = "1";//流程状态 1：未完成 2：所有流程完成
                m.StatusPayment = "1";// 是否已经付款  1：未付款  2：付定金 3：付完全款
                m.StatusPurchaseMaterial = "1";// 订货状态  1：未订货 2：部分订货  3：已经订货
                m.StatusSubmit = "1";//订单状态  1:初始添加 2：修改中  3：已经提交
                try
                {
                    bll.Add(m);     //添加订单信息 
                    Common.MsgBox.Alert("添加订单成功！将返回订单列表，" +
                    "请继续编辑用料单明细", "SalesOrderList.aspx");
                }
                catch (Exception ex)  //如果出现异常，则抛出异常
                {
                    Common.MsgBox.Alert("添加订单失败！请重新添加！错误信息："
                        + ex.Message, "SalesOrderAdd.aspx");
                }
            }
        }
}
