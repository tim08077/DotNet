using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Accounts
{
    public class Accounts_Users
    {
        public Accounts_Users()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _password;
        private string _truename;
        private string _sex;
        private string _phone;
        private string _email;
        private string _departmentid;
        private string _duty;
        private bool _activity;

        public int UserID
        {
            get { return _userid;}
            set { _userid = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string TrueName
        {
            get { return _truename; }
            set { _truename = value; }
        }
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string DepartmentID
        {
            get { return _departmentid; }
            set { _departmentid = value; }
        }
        public string Duty
        {
            get { return _duty; }
            set { _duty = value; }
            
        }
        public bool Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }

        #endregion 
    }
}
