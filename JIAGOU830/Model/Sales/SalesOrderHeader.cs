using System;

namespace Model.Sales
{
    public class SalesOrderHeader
    {
        public SalesOrderHeader()
        { }
        #region Model
        private int _salesorderid;
        private int _customerid;
        private DateTime _dateorder;
        private DateTime _datedelivery;
        private DateTime _dateinspect;
        private DateTime _dateinstall;
        private DateTime _datealldone;
        private string _salesordernumber;
        private string _address;
        private decimal _contractamount;
        private decimal _subtotal;
        private decimal _totaldue;
        private decimal _brokerage;
        private decimal _realincome;
        private decimal _prepaidpayment;
        private decimal _residualpayment;
        private string _designer;
        private string _producer;
        private string _installer;
        private string _notesorder;
        private string _notesmanufacture;
        private string _notesinstall;
        private string _statussubmit;
        private string _statuspurchasematerial;
        private string _statuspayment;
        private string _statusall;
        private DateTime _modifieddate;
        private int _rootdepartmentid;
        /// <summary>
        /// 订单ID
        /// </summary>
        public int SalesOrderID
        {
            set { _salesorderid = value; }
            get { return _salesorderid; }
        }
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime DateOrder
        {
            set { _dateorder = value; }
            get { return _dateorder; }
        }
        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime DateDelivery
        {
            set { _datedelivery = value; }
            get { return _datedelivery; }
        }
        /// <summary>
        /// 验货日期
        /// </summary>
        public DateTime DateInspect
        {
            set { _dateinspect = value; }
            get { return _dateinspect; }
        }
        /// <summary>
        /// 安装日期
        /// </summary>
        public DateTime DateInstall
        {
            set { _dateinstall = value; }
            get { return _dateinstall; }
        }
        /// <summary>
        /// 流程完工日期
        /// </summary>
        public DateTime DateAllDone
        {
            set { _datealldone = value; }
            get { return _datealldone; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string SalesOrderNumber
        {
            set { _salesordernumber = value; }
            get { return _salesordernumber; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 客户合同金额
        /// </summary>
        public decimal ContractAmount
        {
            set { _contractamount = value; }
            get { return _contractamount; }
        }
        /// <summary>
        /// 用料合计金额
        /// </summary>
        public decimal SubTotal
        {
            set { _subtotal = value; }
            get { return _subtotal; }
        }
        /// <summary>
        /// 实收金额 即顾客实付款
        /// </summary>
        public decimal TotalDue
        {
            set { _totaldue = value; }
            get { return _totaldue; }
        }
        /// <summary>
        /// 其他金额，即设计师佣金
        /// </summary>
        public decimal Brokerage
        {
            set { _brokerage = value; }
            get { return _brokerage; }
        }
        /// <summary>
        /// 实际收入 即TotalDue-Brokerage 实收金额减去设计师佣金
        /// </summary>
        public decimal RealIncome
        {
            set { _realincome = value; }
            get { return _realincome; }
        }
        /// <summary>
        /// 预付金额
        /// </summary>
        public decimal PrepaidPayment
        {
            set { _prepaidpayment = value; }
            get { return _prepaidpayment; }
        }
        /// <summary>
        /// 余款
        /// </summary>
        public decimal ResidualPayment
        {
            set { _residualpayment = value; }
            get { return _residualpayment; }
        }
        /// <summary>
        /// 设计师UserName
        /// </summary>
        public string Designer
        {
            set { _designer = value; }
            get { return _designer; }
        }
        /// <summary>
        /// 制作人
        /// </summary>
        public string Producer
        {
            set { _producer = value; }
            get { return _producer; }
        }
        /// <summary>
        /// 安装责任人
        /// </summary>
        public string Installer
        {
            set { _installer = value; }
            get { return _installer; }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string NotesOrder
        {
            set { _notesorder = value; }
            get { return _notesorder; }
        }
        /// <summary>
        /// 制作备注
        /// </summary>
        public string NotesManufacture
        {
            set { _notesmanufacture = value; }
            get { return _notesmanufacture; }
        }
        /// <summary>
        /// 安装备注
        /// </summary>
        public string NotesInstall
        {
            set { _notesinstall = value; }
            get { return _notesinstall; }
        }
        /// <summary>
        /// 订单状态 1-初始添加 2-修改中 3-已提交
        /// </summary>
        public string StatusSubmit
        {
            set { _statussubmit = value; }
            get { return _statussubmit; }
        }
        /// <summary>
        /// 订货状态：1-未订货 2-部分订货 3-已定货
        /// </summary>
        public string StatusPurchaseMaterial
        {
            set { _statuspurchasematerial = value; }
            get { return _statuspurchasematerial; }
        }
        /// <summary>
        /// 是否已付款 1-未付款 2-付定金 3-付完全款
        /// </summary>
        public string StatusPayment
        {
            set { _statuspayment = value; }
            get { return _statuspayment; }
        }
        /// <summary>
        /// 流程状态 1-未完成 2-所有流程已完成 统计时以此状态为准
        /// </summary>
        public string StatusAll
        {
            set { _statusall = value; }
            get { return _statusall; }
        }
        /// <summary>
        /// 行的上次更新日期和时间
        /// </summary>
        public DateTime ModifiedDate
        {
            set { _modifieddate = value; }
            get { return _modifieddate; }
        }
        /// <summary>
        /// 根部门ID 
        /// </summary>
        public int RootDepartmentID
        {
            set { _rootdepartmentid = value; }
            get { return _rootdepartmentid; }
        }
        #endregion Model
    }
}
