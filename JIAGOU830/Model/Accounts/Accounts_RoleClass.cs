using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Accounts
{
    public class Accounts_RoleClass
    {
        public Accounts_RoleClass()
        { }
        #region Model
        private int _roleclassid;
        private string _roleclassname;
        /// <summary>
        /// 角色分类ID，表示各个系统
        /// </summary>
        public int RoleClassID
        {
            set { _roleclassid = value; }
            get { return _roleclassid; }
        }
        /// <summary>
        /// 角色分类名称，即各子系统名称
        /// </summary>
        public string RoleClassName
        {
            set { _roleclassname = value; }
            get { return _roleclassname; }
        }
        #endregion Model
    }
}
