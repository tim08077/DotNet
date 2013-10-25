using System;

namespace Model.Sales
{
    public class NeedMaterialHeader
    {
        public NeedMaterialHeader()
        { }

        #region Model
        private int _needmaterialid;
        private int _salesorderid;
        private DateTime _dateorder;
        private string _manager;
        private string _statussubmit;
        private string _statuspurchasematerial;
        private string _statusstockout;
        private DateTime _modifieddate;
        private int _rootdepartmentid;
        /// <summary>
        /// 用料单ID
        /// </summary>
        public int NeedMaterialID
        {
            set { _needmaterialid = value; }
            get { return _needmaterialid; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int SalesOrderID
        {
            set { _salesorderid = value; }
            get { return _salesorderid; }
        }
        /// <summary>
        /// 用料单日期
        /// </summary>
        public DateTime DateOrder
        {
            set { _dateorder = value; }
            get { return _dateorder; }
        }
        /// <summary>
        /// 经办人UserName
        /// </summary>
        public string Manager
        {
            set { _manager = value; }
            get { return _manager; }
        }
        /// <summary>
        /// 提交状态 1-初始添加 2-已提交
        /// </summary>
        public string StatusSubmit
        {
            set { _statussubmit = value; }
            get { return _statussubmit; }
        }
        /// <summary>
        /// 订货状态：1-未订货 2-已定货
        /// </summary>
        public string StatusPurchaseMaterial
        {
            set { _statuspurchasematerial = value; }
            get { return _statuspurchasematerial; }
        }
        /// <summary>
        /// 出库状态 1-未出库 2-已出库
        /// </summary>
        public string StatusStockOut
        {
            set { _statusstockout = value; }
            get { return _statusstockout; }
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
