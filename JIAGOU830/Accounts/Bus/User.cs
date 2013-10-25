using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Accounts;
using Accounts.Data;

namespace Accounts.Bus
{
    public sealed class User
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
        /// 确定用户信息
        /// </summary>
        /// <param name="existingPrincipal"></param>
        public User(AccountsPrincipal existingPrincipal)
        {
            this.userid = ((SiteIdentity)existingPrincipal.Identity).UserID;
            this.LoadFromID();
        }

        /// <summary>
        /// 确定用户信息
        /// </summary>
        /// <param name="existingUserID"></param>
        public User(int existingUserID)
        {
            this.userid = existingUserID;
            this.LoadFromID();
        }

        /// <summary>
        /// 确定用户信息
        /// </summary>
        /// <param name="userName">用户登陆名</param>
        public User(string userName)
        {
            DataRow row = new Accounts.Data.User(PubConstant.ConnectionString).Retrieve(userName);
            if (row != null)
            {
                this.username = userName;
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
        }

        /// <summary>
        /// 根据当前UserID取得用户信息
        /// </summary>
        private void LoadFromID()
        {
            DataRow row = new Accounts.Data.User(PubConstant.ConnectionString).Retrieve(this.userid);
            if (row != null)
            {

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
        }

        /// <summary>
        /// UserID
        /// </summary>
        public int UserID
        {
            set { this.userid = value; }
            get { return userid; }
        }
        /// <summary>
        /// 用户登陆名
        /// </summary>
        public string UserName
        {
            set { this.username = value; }
            get { return this.username; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string TrueName
        {
            set { this.truename = value; }
            get { return this.truename; }
        }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string Sex
        {
            set { this.sex = value; }
            get { return this.sex; }
        }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string Phone
        {
            set { this.phone = value; }
            get { return this.phone; }
        }
        /// <summary>
        /// 用户邮件
        /// </summary>
        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }
        /// <summary>
        /// 用户处编号
        /// </summary>
        public string DepartmentID
        {
            set { this.departmentid = value; }
            get { return this.departmentid; }
        }
        /// <summary>
        /// 用户科编号
        /// </summary>
        public string Duty
        {
            set { this.duty = value; }
            get { return this.duty; }
        }
        /// <summary>
        /// 用户是否激活，0为休眠，1为激活
        /// </summary>
        public bool Activity
        {
            set { this.activity = value; }
            get { return this.activity; }
        }

    }
}
