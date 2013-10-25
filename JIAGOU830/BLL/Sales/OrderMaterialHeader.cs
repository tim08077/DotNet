using System;
using System.Data;
using System.Collections.Generic;
using Model.Sales;


namespace BLL.Sales
{
    public class OrderMaterialHeader
    {
        private readonly DAL.Sales.NeedMaterialHeader dal=new DAL.Sales.NeedMaterialHeader();
        public OrderMaterialHeader()
        {}
        #region 成员方法
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="NeedMaterialID"></param>
        /// <returns></returns>
        public bool Exists(int NeedMaterialID)
        {
           return  dal.Exists(NeedMaterialID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Sales.NeedMaterialHeader model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        public void Update(Model.Sales.NeedMaterialHeader model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="NeedMaterialID"></param>
        public void Delete(int NeedMaterialID)
        {
            dal.Delete(NeedMaterialID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="NeedMaterialID"></param>
        /// <returns></returns>
        public Model.Sales.NeedMaterialHeader GetModel(int NeedMaterialID)
        {
            return dal.GetModel(NeedMaterialID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据前几行
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top,strWhere,filedOrder);
        }

        public List<Model.Sales.NeedMaterialHeader> DataTableToList(DataTable dt)
        {
            List<Model.Sales.NeedMaterialHeader> modelList = new List<Model.Sales.NeedMaterialHeader>();
            int rowsCount = dt.Rows.Count;
            if(rowsCount >0)
            {
                Model.Sales.NeedMaterialHeader model;
                for (int n = 0; n < rowsCount;n++ )
                {
                    model = new Model.Sales.NeedMaterialHeader();
                    if (dt.Rows[n]["NeedMaterialID"].ToString() != "")
                    {
                        model.NeedMaterialID = int.Parse(dt.Rows[n]["NeedMaterialID"].ToString());
                    }
                    if (dt.Rows[n]["SalesOrderID"].ToString() != "")
                    {
                        model.SalesOrderID = int.Parse(dt.Rows[n]["SalesOrderID"].ToString());
                    }
                    if (dt.Rows[n]["DateOrder"].ToString() != "")
                    {
                        model.DateOrder = DateTime.Parse(dt.Rows[n]["DateOrder"].ToString());
                    }
                    model.Manager = dt.Rows[n]["Manager"].ToString();
                    model.StatusSubmit = dt.Rows[n]["StatusSubmit"].ToString();
                    model.StatusPurchaseMaterial = dt.Rows[n]["StatusPurchaseMaterial"].ToString();
                    if (dt.Rows[n]["ModifiedDate"].ToString() != "")
                    {
                        model.ModifiedDate = DateTime.Parse(dt.Rows[n]["ModifiedDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

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
        /// Updates the sales order header status.更新指定用料单的订货状态
        /// </summary>
        /// <param name="NeedMaterialID">The need material ID.</param>
        /// <param name="StatusPurchaseMaterial">The status purchase material.</param>
        public void UpdateNeedMaterialHeaderStatusPurchaseMaterial(int NeedMaterialID, string StatusPurchaseMaterial)
        {
            dal.UpdateNeedMaterialHeaderStatusPurchaseMaterial(NeedMaterialID, StatusPurchaseMaterial);
        }

        /// <summary>
        /// Updates the need material header status stock out.更新指定用料单的出库状态
        /// </summary>
        /// <param name="NeedMaterialID">The need material ID.</param>
        /// <param name="StatusStockOut">The status stock out.</param>
        public void UpdateNeedMaterialHeaderStatusStockOut(int NeedMaterialID, string StatusStockOut)
        {
            dal.UpdateNeedMaterialHeaderStatusStockOut(NeedMaterialID, StatusStockOut);
        }

        #endregion 
    }
}
