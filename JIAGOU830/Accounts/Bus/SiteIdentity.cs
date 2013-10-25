using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Principal;
using Accounts.Data;

namespace Accounts.Bus
{
    public class SiteIdentity:System.Security.Principal.IIdentity
    {
        private int userid;
        private string username;
        private string password;
        private string truename;
        private string sex;
        private string phone;
        private string email;
        private string departmentid;
        private string duty;
        private bool activity;
        /// <summary>
        /// 根据UserID获得用户信息
        /// </summary>
        /// <param name="currentUserID"></param>
        public SiteIdentity(int currentUserID)
        {
            DataRow row = new Accounts.Data.User(PubConstant.ConnectionString).Retrieve(currentUserID);
            this.userid = currentUserID;
            this.username = Convert.ToString(row["UserName"]);
            this.password = Convert.ToString(row["Password"]);
            this.truename = Convert.ToString(row["TrueName"]);
            this.sex = Convert.ToString(row["Sex"]);
            this.phone = Convert.ToString(row["Phone"]);
            this.email = Convert.ToString(row["Email"]);
            this.departmentid = Convert.ToString(row["departmentid"]);
            this.duty = Convert.ToString(row["duty"]);
            this.activity = Convert.ToBoolean(row["activity"]);
        }
        /// <summary>
        /// 根据UserName获得用户信息
        /// </summary>
        /// <param name="currentUserName"></param>
        public SiteIdentity(string currentUserName)
        {
            DataRow row = new Accounts.Data.User(PubConstant.ConnectionString).Retrieve(currentUserName);
            this.username = currentUserName;
            this.userid = Convert.ToInt32(row["UserID"]);
            this.password = Convert.ToString(row["Password"]);
            this.truename = Convert.ToString(row["TrueName"]);
            this.sex = Convert.ToString(row["Sex"]);
            this.phone = Convert.ToString(row["Phone"]);
            this.email = Convert.ToString(row["Email"]);
            this.departmentid = Convert.ToString(row["departmentid"]);
            this.duty = Convert.ToString(row["duty"]);
            this.activity = Convert.ToBoolean(row["activity"]);
        }

        #region IIdentity 成员
        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string AuthenticationType
        {
            get
            {
                return "Custom Authentication";
            }
            set
            {
            }
        }

        public string Name
        {
            get { return this.username; }
        }

        public string UserName
        {
            get { return this.username; }
        }

        public int UserID
        {
            get { return this.userid; }
        }

        public string Password
        {
            get { return this.password; }
            set { password = value; }
        }

        public string TrueName
        {
            get { return this.password; }
        }

        public string Sex
        {
            get { return this.sex; }
        }

        public  string  Phone
        {
            get { return this.phone; }
        }

        public string Email
        {
            get { return this.email; }
        }

        public string DepartmentID
        {
            get { return this.departmentid; }
        }

        public string Duty
        {
            get { return this.duty; }
        }

        public bool Activity
        {
            get { return this.activity; }
        }



        #endregion 

    }
}
