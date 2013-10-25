using System;
using System.Data;
using Common;
using Model.Accounts;

namespace BLL.Accounts
{
   
    public class Accounts_Users
    {

        private readonly DAL.Accounts.Accounts_Users dal = new DAL.Accounts.Accounts_Users();

        public Accounts_Users()
        { }

        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

        public int Add(Model.Accounts.Accounts_Users model)
        {
            return dal.Add(model);
        }

        public void Update(Model.Accounts.Accounts_Users model)
        {
             dal.Update(model);
        }

        public void Delete(int UserID)
        {
            dal.Delete(UserID);
        }

        public Model.Accounts.Accounts_Users GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }

        public Model.Accounts.Accounts_Users GetModel(string UserName)
        {
            return dal.GetModel(UserName);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        //public Model.Accounts.Accounts_Users GetModelByCache(int UserID)
        //{
        //    string CacheKey = "Accounts_UsersModel-" + UserID;
        //    object objModel = DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(UserID);
        //            if (objModel != null)
        //            {
        //                int ModelCache =Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Model.Accounts.Accounts_Users)objModel;
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
        /// 验证用户登陆
        /// </summary>
        /// <param name="UserName">用户登陆名</param>
        /// <param name="Password">用户密码</param>
        /// <returns></returns>
        public Model.Accounts.Accounts_Users ValidateLogin(string UserName, string Password)
        {
            Model.Accounts.Accounts_Users user = dal.GetModel(UserName);
            if (user == null)
            {
                return null;
            }
            else
            {
                if (user.Password != Password)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
        }



        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <param name="PageIndex">当前页索引</param>
        /// <param name="strWhere">查询字符串</param>
        /// <param name="OrderType">设置排序类型, 非 0 值则降序</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string OrderType)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, OrderType);
        }

        /// <summary>
        /// 获得数据数量
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>数据数量</returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void Delete(string strWhere)
        {
            dal.Delete(strWhere);
        }



    }
}
