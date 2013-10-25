using System;
using System.Data;
using Common;
using Model.Accounts;

namespace BLL.Accounts
{
    public class Accounts_RoleClass
    {
        private readonly DAL.Accounts.Accounts_RoleClass dal = new DAL.Accounts.Accounts_RoleClass();
        public Accounts_RoleClass()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleClassID)
        {
            return dal.Exists(RoleClassID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Accounts.Accounts_RoleClass model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Model.Accounts.Accounts_RoleClass model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleClassID)
        {
            dal.Delete(RoleClassID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Accounts.Accounts_RoleClass GetModel(int RoleClassID)
        {
            return dal.GetModel(RoleClassID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        //public Model.Accounts.Accounts_RoleClass GetModelByCache(int RoleClassID)
        //{
        //    string CacheKey = "Accounts_RoleClassModel-" + RoleClassID;
        //    object objModel = DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(RoleClassID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = UART.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (UART.Model.Accounts.Accounts_RoleClass)objModel;
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

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}
