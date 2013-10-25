using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using Accounts.Data;
using System.Collections;

namespace Accounts.Bus
{
    //IPrincipal接口 定义用户对象的基本功能  
    //属性：Identity 获取当前用户的标识 
    // 方法：IsInRole 确定当前用户是否属于指定的角色
    public class AccountsPrincipal:System.Security.Principal.IPrincipal//定义用户对象的基本功能
    {
        //获取当前用户的标识
        private System.Security.Principal.IIdentity identity;

        private ArrayList roleCodeList;

        private ArrayList permissionList;

        private ArrayList permissionCodeList;

        /// <summary>
        /// 根据用户ID 获取用户角色，权限列表
        /// </summary>
        /// <param name="userID"></param>
        public AccountsPrincipal(int userID)
        {
            Accounts.Data.User user = new Accounts.Data.User(PubConstant.ConnectionString);
            this.identity = new SiteIdentity(userID);
            this.permissionList = user.GetEffectivePermissionList(userID);
            this.permissionCodeList = user.GetEffectivePermissionCodeList(userID);
            this.roleCodeList = user.GetUserRoles(userID);

        }
        /// <summary>
        /// 根据 用户名 ，获取用户角色 ，权限列表 
        /// </summary>
        /// <param name="userName"></param>
        public AccountsPrincipal(string userName)
        {
            Accounts.Data.User user = new Accounts.Data.User(PubConstant.ConnectionString);
            this.identity = new SiteIdentity(userName);
            this.permissionList = user.GetEffectivePermissionList(((SiteIdentity)this.identity).UserID);
            this.permissionCodeList = user.GetEffectivePermissionCodeList(((SiteIdentity)this.identity).UserID);
            this.roleCodeList = user.GetUserRoles(((SiteIdentity)this.identity).UserID);
        }
        /// <summary>
        /// 验证用户名 and 密码 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static AccountsPrincipal ValidateLogin(string userName, string password)
        {
            Accounts.Data.User user = new Accounts.Data.User(PubConstant.ConnectionString);
            int userID = user.ValidateLogin(userName, password);
            if (userID > 0)
            {
                return new AccountsPrincipal(userID);
            }
            return null;

        }


        public ArrayList RolesCode
        {
            get {return  this.roleCodeList; }
        }

        public ArrayList Permissions
        {
            get { return this.permissionList; }
        }

        public ArrayList PermissionsCode
        {
            get { return this.permissionCodeList; }
        }

        #region Iprincipal 成员 
        public System.Security.Principal.IIdentity Identity
        {
            get
            {
                return this.identity;
            }
            set
            {
                this.identity = value;
            }

        }
        /// <summary>
        /// 用户是否有角色 
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        public bool IsInRole(string roleCode)
        {
            return roleCodeList.Contains(roleCode);
        }

        public bool HasPermission(string permission)
        {
            return permissionList.Contains(permission);
        }

        public bool HasPermissionCode(int permissionCode)
        {
            return permissionCodeList.Contains(permissionCode);
        }
        #endregion 
    }
}
