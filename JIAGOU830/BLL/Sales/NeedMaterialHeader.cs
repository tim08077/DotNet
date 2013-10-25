using System;
using System.Data;
using System.Collections.Generic;
using Model.Sales;


namespace BLL
{
    
    public class NeedMaterialHeader
    {
        private readonly DAL.Sales.NeedMaterialHeader dal = new DAL.Sales.NeedMaterialHeader();

        public NeedMaterialHeader()
        { 

        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="NeedMaterialID"></param>
        /// <returns></returns>
        public bool Exists(int NeedMaterialID)
        {
            return dal.Exists(NeedMaterialID);
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Sales.NeedMaterialHeader model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        public void Update(Model.Sales.NeedMaterialHeader model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="NeedMaterialID"></param>
        public void Delete(int NeedMaterialID)
        {
            dal.Delete(NeedMaterialID);
        }
        /// <summary>
        /// 返回一个实体
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
        /// 获得前几行数据列表
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// DataTable  -- ModelList
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Model.Sales.NeedMaterialHeader> DataTableToList(DataTable dt)
        {
            List<Model.Sales.NeedMaterialHeader> modelList = new List<Model.Sales.NeedMaterialHeader>();
            int rowsCount = dt.Rows.Count;
            if(rowsCount>0)
            {
                Model.Sales.NeedMaterialHeader model;
                for (int i = 0; i < rowsCount;i++ )
                {
                    model = new Model.Sales.NeedMaterialHeader();
                    if(dt.Rows[i]["NeedMaterialID"].ToString()!="")
                    {
                        model.NeedMaterialID =int.Parse( dt.Rows[i]["NeedMaterialID"].ToString());
                    }
                    if (dt.Rows[i]["SalesOrderID"].ToString() != "")
                    {
                        model.SalesOrderID = int.Parse(dt.Rows[i]["SalesOrderID"].ToString());
                    }
                    if (dt.Rows[i]["DateOrder"].ToString() != "")
                    {
                        model.DateOrder = DateTime.Parse(dt.Rows[i]["DateOrder"].ToString());
                    }
                    model.Manager = dt.Rows[i]["Manager"].ToString();
                    model.StatusSubmit = dt.Rows[i]["StatusSubmit"].ToString();
                    model.StatusPurchaseMaterial = dt.Rows[i]["StatusPurchaseMaterial"].ToString();
                    if (dt.Rows[i]["ModifiedDate"].ToString() != "")
                    {
                        model.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// DataSet    -- DataTable
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.Sales.NeedMaterialHeader> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }


        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string OrderType)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, OrderType);
        }

        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }


        public void UpdateNeedMaterialHeaderStatusPurchaseMaterial(int NeedMaterialID, string StatusPurchaseMaterial)
        {
            dal.UpdateNeedMaterialHeaderStatusPurchaseMaterial(NeedMaterialID, StatusPurchaseMaterial);
        }

        public void UpdateNeedMaterialHeaderStatusStockOut(int NeedMaterialID, string StatusStockOut)
        {
            dal.UpdateNeedMaterialHeaderStatusStockOut(NeedMaterialID, StatusStockOut);
        }


    }
}
