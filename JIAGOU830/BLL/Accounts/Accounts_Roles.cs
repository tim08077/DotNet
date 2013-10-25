using System;
using System.Data;
using Common;
using Model.Accounts;

namespace BLL.Accounts
{
    public class Accounts_Roles
    {
        private readonly DAL.Accounts.Accounts_Roles dal = new DAL.Accounts.Accounts_Roles();
        public Accounts_Roles()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            return dal.Exists(RoleID);
        }
        /// <summary>
        /// 是否存在该记录 根据RoleDescription
        /// </summary>
        public bool Exists(string RoleDescription)
        {
            return dal.Exists(RoleDescription);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Accounts.Accounts_Roles model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Model.Accounts.Accounts_Roles model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleID)
        {
            dal.Delete(RoleID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Accounts.Accounts_Roles GetModel(int RoleID)
        {
            return dal.GetModel(RoleID);
        }

        /// <summary>
        /// 得到一个对象实体 根据RoleDescription
        /// </summary>
        public Model.Accounts.Accounts_Roles GetModel(string RoleDescription)
        {
            return dal.GetModel(RoleDescription);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        //public Model.Accounts.Accounts_Roles GetModelByCache(int RoleID)
        //{
        //    string CacheKey = "Accounts_RolesModel-" + RoleID;
        //    object objModel = DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(RoleID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = UART.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (UART.Model.Accounts.Accounts_Roles)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        //2007.11.26添加 获取指定用户在当前角色分类下已经拥有的角色
        /// <summary>
        /// 获取指定用户在当前角色分类下已经拥有的角色
        /// </summary>
        /// <param name="RoleClassID">角色分类ID</param>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public DataSet GetRoleYes(int RoleClassID, int UserID)
        {
            return dal.GetRoleYes(RoleClassID, UserID);
        }

        //2007.11.26添加 获取指定用户在当前角色分类下还没拥有的角色
        /// <summary>
        /// 获取指定用户在当前角色分类下还没拥有的角色
        /// </summary>
        /// <param name="RoleClassID">角色分类ID</param>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public DataSet GetRoleNo(int RoleClassID, int UserID)
        {
            return dal.GetRoleNo(RoleClassID, UserID);
        }

        #endregion  成员方法
    }
}
