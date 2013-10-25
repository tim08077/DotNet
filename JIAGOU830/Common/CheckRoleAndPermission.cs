using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounts.Bus;

namespace Common
{
    public class CheckRoleAndPermission
    {

        private int _rolecode = 0;
        private int _permissioncode = 0;
        private int _returntype = 0;

        public int RoleCode
        {
            get
            {
                return _rolecode;
            }
            set
            {
                _rolecode = value;
            }
        }

        public int PermissionCode
        {
            get
            {
                return _permissioncode;
            }
            set
            {
                _permissioncode = value;

            }
        }
        /// <summary>
        /// 如果通不过验证返回的类型  1为重定向到登陆页，2为返回前一页，3为停止输出
        /// </summary>
        public int ReturnType
        {
            get
            {
                return _returntype;
            }
            set
            {
                _returntype = value;
            }


        }
        /// <summary>
        /// 检查用户是否已经登陆 
        /// </summary>
        public static void CheckLogin()
        {
            if (System.Web.HttpContext.Current.Session["UserInfo"]==null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>top.location.href='../admin_Login.aspx'</script>");
                System.Web.HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// 检查用户是否已经登陆 ，返回 bool
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            if (System.Web.HttpContext.Current.Session["UserInfo"]==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 检查用户角色及权限 
        /// </summary>
        /// <param name="_rolecode"></param>
        /// <param name="_permissioncode"></param>
        public static void Check(int _rolecode ,int _permissioncode)
        {
            bool result = true;
            if (System.Web.HttpContext.Current.Session["UserRoleAndPermiison"] == null)
            {
                result = false;
            }
            else
            {
                AccountsPrincipal user = (AccountsPrincipal)(System.Web.HttpContext.Current.Session["UserRoleAndPermiison"]);
                if(_rolecode !=0)
                {
                    if(!user.IsInRole(_rolecode.ToString()))
                    {
                        result = false;
                    }
                }
                if(_permissioncode !=0)
                {
                    if (!user.HasPermissionCode(_permissioncode))
                    {
                        result = false;
                    }
                }

            }
            if(result==false)
            {
                Common.MsgBox.Alert_History("您不具有所需角色或权限", -1);
                System.Web.HttpContext.Current.Response.End();

            }

        }
        /// <summary>
        /// 检查用户角色及权限 返回bool值
        /// </summary>
        /// <param name="_rolecode">角色代码</param>
        /// <param name="_permissioncode">权限代码</param>
        /// <returns></returns>
        public static bool HasRight(int _rolecode, int _permissioncode)
        {
            bool result = true;
            if (System.Web.HttpContext.Current.Session["UserRoleAndPermiison"] == null)
            {
                result = false;
                //return result;
            }
            else
            {
                AccountsPrincipal user = (AccountsPrincipal)(System.Web.HttpContext.Current.Session["UserRoleAndPermiison"]);
                //验证用户是否具有指定的角色或权限
                if (_rolecode != 0)
                {
                    if (!user.IsInRole(_rolecode.ToString()))
                    {
                        result = false;
                        //return result;
                    }
                }
                //验证用户是否具有指定的权限
                if (_permissioncode != 0)
                {
                    if (!user.HasPermissionCode(_permissioncode))
                    {
                        result = false;
                        //return result;
                    }
                }
                //return result;
            }
            return result;
        }

    }
}
