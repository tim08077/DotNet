using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model.Sales;


namespace BLL.Sales
{
     public class SalesOrderHeader
    {
         private readonly DAL.Sales.SalesOrderHeader dal = new DAL.Sales.SalesOrderHeader();

         public SalesOrderHeader()
         { 

         }
         /// <summary>
         /// 判断订单是否存在
         /// </summary>
         /// <param name="SalesOrderID"></param>
         /// <returns></returns>
         public bool Exists(int SalesOrderID)
         {
             return dal.Exists(SalesOrderID);
         }

         public int Add(Model.Sales.SalesOrderHeader model)
         {
             return dal.Add(model);
         }

         public void Update(Model.Sales.SalesOrderHeader model)
         {
             dal.Update(model);
         }

         public void Delete(int SalesOrderID)
         {
             dal.Delete(SalesOrderID);
         }

         public Model.Sales.SalesOrderHeader GetModel(int SalesOrderID)
         {
             return dal.GetModel(SalesOrderID);
         }

         public DataSet GetList(string strWhere)
         {
             return dal.GetList(strWhere);
         }

         public DataSet GetList(int PageSize, int PageIndex, string strWhere, string OrderType)
         {
             return dal.GetList(PageSize, PageIndex, strWhere, OrderType);
         }

         public int GetCount(string strWhere)
         {
             return dal.GetCount(strWhere);
         }

         public decimal GetSubTotal(int SalesOrderID)
         {
             return dal.GetSubTotal(SalesOrderID);
         }

         public void UpdateNeedMaterialDetailRealUnitPriceAndSubTotal(int SalesOrderID)
         {
             Model.Sales.SalesOrderHeader model = dal.GetModel(SalesOrderID);
             //此处为打折比率，根据公司的计算方式，如果包括设计师佣金，则应为model.TotalDue / model.SubTotal
             //需要判断一下合计金额是否为0的情况 如果合计金额为0 说明一项材料也没有 就不用计算了
             decimal Discount = 1;

             if (model.SubTotal > 0)
             {
                 Discount = model.TotalDue / model.SubTotal;
                 dal.UpdateNeedMaterialDetailRealUnitPriceAndSubTotal(SalesOrderID, Discount);
             }
         }

         public void UpdateSalesOrderHeaderStatusPurchaseMaterial(int SalesOrderID, string StatusPurchaseMaterial)
         {
             dal.UpdateSalesOrderHeaderStatusPurchaseMaterial(SalesOrderID, StatusPurchaseMaterial);
         }

         public bool IsAllSubmit(int SalesOrderID)
         {
             BLL.NeedMaterialHeader bll = new NeedMaterialHeader();
             if (bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString()) == bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString() + " and StatusSubmit='2'"))
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }

         public bool IsAllPurchase(int SalesOrderID)
         {
             BLL.NeedMaterialHeader bll = new NeedMaterialHeader();
             if (bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString()) == bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString() + " and StatusPurchaseMaterial='2'"))
             {
                 return true;
             }
             else
             {
                 return false;
             }

         }
         /// <summary>
         /// Get the Status Submit 取得订单的提交状态
         /// </summary>
         /// <param name="SalesOrderID"></param>
         /// <returns></returns>
         public string GetStatusSubmit(int SalesOrderID)
         {
             BLL.NeedMaterialHeader bll = new NeedMaterialHeader();
             int SubmitYes = bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString() +" and StatusSubmit='2'");
             int SubmitCount = bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString());
             if(SubmitYes==0 || SubmitCount==0)
             {
                 return "1";
             }
             else if(SubmitYes < SubmitCount)
             {
                 return "2";
             }
             else if (SubmitYes == SubmitCount)
             {
                 return "3";
             }
             else
             {
                 return "1";
             }

         }
         /// <summary>
         /// 取得订单的订货状态，判断用料单
         /// </summary>
         /// <param name="SalesOrderID"></param>
         /// <returns></returns>
         public string GetStatusPurchaseMaterial(int SalesOrderID)
         {
             BLL.NeedMaterialHeader bll = new NeedMaterialHeader();
             //订单 采购单已经提交 and 原材料已经购买 
             int PurchaseYes = bll.GetCount(" SalesOrderID=" + SalesOrderID.ToString() + " and StatusSubmit='2' and StatusPurchaseMaterial='2'");
             //订单 采购单 已经提交数量
             int PurchaseCount = bll.GetCount(" SalesOrderId=" + SalesOrderID.ToString() + " and StatusSubmit='2'");
             if (PurchaseCount == 0 || PurchaseYes == 0)
             {
                 return "1";
             }
             else if (PurchaseYes < PurchaseCount)
             {
                 return "2";
             }
             else if (PurchaseYes == PurchaseCount)
             {
                 return "3";
             }
             else
             {
                 return "1";
             }


         }
            


    }
}
