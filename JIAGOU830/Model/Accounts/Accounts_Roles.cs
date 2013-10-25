using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Accounts
{
    public class Accounts_Roles
    {
        public Accounts_Roles()
        { }
        #region Model
        private int _roleid;
        private int _rolecode;
        private int _roleclassid;
        private string _roledescription;
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 角色代码
        /// </summary>
        public int RoleCode
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }
        /// <summary>
        /// 角色分类ID
        /// </summary>
        public int RoleClassID
        {
            set { _roleclassid = value; }
            get { return _roleclassid; }
        }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleDescription
        {
            set { _roledescription = value; }
            get { return _roledescription; }
        }
        #endregion Model

    }
}
