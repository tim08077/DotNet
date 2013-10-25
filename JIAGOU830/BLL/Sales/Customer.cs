using System;
using System.Data;
using System.Collections.Generic;
using Model.Sales;

namespace BLL.Sales
{
    public  class Customer
    {
        private readonly DAL.Sales.Customer dal = new DAL.Sales.Customer();
        public Customer()
        { }

        public bool Exists(int customerID)
        {
            return dal.Exists(customerID);
        }

        public int Add(Model.Sales.Customer model)
        {
           return dal.Add(model);
        }

        public void Update(Model.Sales.Customer model)
        {
            dal.Update(model);
        }

        public void Delete(int customerID)
        {
            dal.Delete(customerID);
        }
        public Model.Sales.Customer GetModel(int customerID)
        {
            return dal.GetModel(customerID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetList(int top, string strWhere, string order) 
        {
            return dal.GetList(top,strWhere,order);
        }

        public List<Model.Sales.Customer> DataTableToList(DataTable dt)
        {
            List<Model.Sales.Customer> modelList = new List<Model.Sales.Customer>();
            if(dt.Rows.Count >0)
            {
                Model.Sales.Customer model;
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    model = new Model.Sales.Customer();
                    if (dt.Rows[i]["CustomerID"].ToString() !=null)
                    {
                        model.CustomerId = int.Parse(dt.Rows[i]["CustomerID"].ToString());

                    }
                    model.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                    model.Phone = dt.Rows[i]["Phone"].ToString();
                    model.CallPhone = dt.Rows[i]["CellPhone"].ToString();
                    model.Address = dt.Rows[i]["Address"].ToString();
                    if (dt.Rows[i]["rowguid"].ToString() != null)
                    {
                        model.rowguid = new Guid(dt.Rows[i]["rowguid"].ToString());
                    }
                    if (dt.Rows[i]["ModifiedDate"].ToString() != null)
                    {
                        model.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                    }
                    modelList.Add(model);

                }
            }
            return modelList;
        }

        public List<Model.Sales.Customer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        public DataSet GetAllList()
        {
            return GetList("");
        }


    }
}
