using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Sales
{
    public class Customer
    {
        public Customer() 
        {}
        #region Model
        private int _customerid;
        private string _customername;
        private string _phone;
        private string _callphone;
        private string _address;
        private Guid _rowguid;
        private DateTime _modifieddate;

        public int CustomerId
        {
            get { return _customerid; }
            set { _customerid = value; }
        }

        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }

        public string Phone
        {
            set {  _phone = value; }
            get { return _phone; }
        }

        public string CallPhone
        {
            set { _callphone = value; }
            get { return _callphone; }
        }

        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }

        public Guid rowguid
        {
            set { _rowguid = value; }
            get { return _rowguid; }
        }

        public DateTime ModifiedDate
        {
            set { _modifieddate = value; }
            get { return _modifieddate; }
        }




        #endregion  
    }
}
