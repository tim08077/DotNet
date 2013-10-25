using System;
using System.Data;
using System.Collections.Generic;//泛型 
using Model.Sales;

namespace BLL.Sales
{
    public class Material
    {
        private readonly DAL.Sales.Material dal=new DAL.Sales.Material();
        
        public Material()
        {}
         
       #region 成员方法
        public bool Exists(int MaterialID)
        {
            return dal.Exists(MaterialID);
        }

        public int Add(Model.Sales.Material model)
        {
            return dal.Add(model);
        }

        public void Update(Model.Sales.Material model) 
        {
            dal.Update(model);
        }

        public void Delete(int MaterialID)
        {
            dal.Delete(MaterialID);
        }

        public Model.Sales.Material GetModel(int MaterialID)
        {
            return dal.GetModel(MaterialID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetList(int top,string strWhere ,string filedOrder)
        {
            return dal.GetList(top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据DataTable, 返回modelList  
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Model.Sales.Material> DataTableToList(DataTable dt)
        {
            List<Model.Sales.Material> modelList = new List<Model.Sales.Material>();
            int rowsCount = dt.Rows.Count;
            if(rowsCount>0)
            {
                Model.Sales.Material model;
                for (int n = 0; n < rowsCount;n++ )
                {
                    model = new Model.Sales.Material();
                    if(dt.Rows[n]["MaterialID"].ToString() !="")
                    {
                        model.MaterialID = int.Parse(dt.Rows[n]["MaterialID"].ToString());
                    }
                    if (dt.Rows[n]["MaterialCategoryID"].ToString() != "")
                    {
                        model.MaterialCategoryID = int.Parse(dt.Rows[n]["MaterialCategoryID"].ToString());

                    }
                    if (dt.Rows[n]["ManufacturerID"].ToString() != "")
                    {
                        model.ManufacturerID = int.Parse(dt.Rows[n]["ManufacturerID"].ToString());

                    }
                    if(dt.Rows[n]["ManufacturerCode"].ToString() !="")
                    {
                        model.ManufacturerCode = dt.Rows[n]["ManufacturerCode"].ToString();
                      
                    }
                    if(dt.Rows[n]["Name"].ToString() !="")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if(dt.Rows[n]["RootDepartmentID"].ToString() !="")
                    {
                        model.RootDepartmentID = int.Parse(dt.Rows[n]["RootDepartmentID"].ToString());
                    }
                    modelList.Add(model);

                }
                

            }
            return modelList;
        }

        /// <summary>
        /// 根据strwhere 返回DataSet 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.Sales.Material> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public DataSet GetAllList()
        {
            return GetList("");
        }

        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);

        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string OrderType)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, OrderType);
        }

        public Model.Sales.Material GetModel(string name)
        {
            return dal.GetModel(name);
        }
        public Model.Sales.Material GetModel(int MaterialCategoryID, int ManufacturerID, string Name)
        {
            return dal.GetModel(MaterialCategoryID, ManufacturerID, Name);
        }
        public Model.Sales.Material GetModel(int MaterialCategoryID, string Name)
        {
            return dal.GetModel(MaterialCategoryID, Name);
        }
        public bool Exists(int MaterialCategoryID, int ManufacturerID, string Name)
        {
            return dal.Exists(MaterialCategoryID, ManufacturerID, Name);
        }
        public bool Exists(int MaterialCategoryID, string Name)
        {
            return dal.Exists(MaterialCategoryID, Name);
        }
       #endregion 
        



    }
}
