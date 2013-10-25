using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;


namespace DAL.Sales
{
    public class NeedMaterialHeader
    {
        public NeedMaterialHeader()
        { }

        #region 成员方法

        public bool Exists(int NeedMaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select COUNT(*)  from dbo.Sales_NeedMaterialHeader ");
            strSql.Append(" where NeedMaterialID =@NeedMaterialID ");
            SqlParameter[] parameters = {
                    new SqlParameter ("@NeedMaterialID",SqlDbType.Int,4)};
            parameters[0].Value = NeedMaterialID;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
               
        }

        public int Add(Model.Sales.NeedMaterialHeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sales_NeedMaterialHeader(");
            strSql.Append("SalesOrderID,DateOrder,Manager,StatusSubmit,StatusPurchaseMaterial,StatusStockOut,ModifiedDate,RootDepartmentID)");
            strSql.Append(" values (");
            strSql.Append("@SalesOrderID,@DateOrder,@Manager,@StatusSubmit,@StatusPurchaseMaterial,@StatusStockOut,@ModifiedDate,@RootDepartmentID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesOrderID", SqlDbType.Int,4),
					new SqlParameter("@DateOrder", SqlDbType.DateTime),
					new SqlParameter("@Manager", SqlDbType.VarChar,50),
					new SqlParameter("@StatusSubmit", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusPurchaseMaterial", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusStockOut", SqlDbType.NVarChar,1),
					new SqlParameter("@ModifiedDate", SqlDbType.DateTime),
					new SqlParameter("@RootDepartmentID", SqlDbType.Int,4)};
            parameters[0].Value = model.SalesOrderID;
            parameters[1].Value = model.DateOrder;
            parameters[2].Value = model.Manager;
            parameters[3].Value = model.StatusSubmit;
            parameters[4].Value = model.StatusPurchaseMaterial;
            parameters[5].Value = model.StatusStockOut;
            parameters[6].Value = model.ModifiedDate;
            parameters[7].Value = model.RootDepartmentID;

            object obj = DbHelperSQL.GetSingles(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public void Update(Model.Sales.NeedMaterialHeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_NeedMaterialHeader set ");
            strSql.Append("SalesOrderID=@SalesOrderID,");
            strSql.Append("DateOrder=@DateOrder,");
            strSql.Append("Manager=@Manager,");
            strSql.Append("StatusSubmit=@StatusSubmit,");
            strSql.Append("StatusPurchaseMaterial=@StatusPurchaseMaterial,");
            strSql.Append("StatusStockOut=@StatusStockOut,");
            strSql.Append("ModifiedDate=@ModifiedDate,");
            strSql.Append("RootDepartmentID=@RootDepartmentID");
            strSql.Append(" where NeedMaterialID=@NeedMaterialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@NeedMaterialID", SqlDbType.Int,4),
					new SqlParameter("@SalesOrderID", SqlDbType.Int,4),
					new SqlParameter("@DateOrder", SqlDbType.DateTime),
					new SqlParameter("@Manager", SqlDbType.VarChar,50),
					new SqlParameter("@StatusSubmit", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusPurchaseMaterial", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusStockOut", SqlDbType.NVarChar,1),
					new SqlParameter("@ModifiedDate", SqlDbType.DateTime),
					new SqlParameter("@RootDepartmentID", SqlDbType.Int,4)};
            parameters[0].Value = model.NeedMaterialID;
            parameters[1].Value = model.SalesOrderID;
            parameters[2].Value = model.DateOrder;
            parameters[3].Value = model.Manager;
            parameters[4].Value = model.StatusSubmit;
            parameters[5].Value = model.StatusPurchaseMaterial;
            parameters[6].Value = model.StatusStockOut;
            parameters[7].Value = model.ModifiedDate;
            parameters[8].Value = model.RootDepartmentID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int NeedMaterialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sales_NeedMaterialHeader ");
            strSql.Append(" where NeedMaterialID=@NeedMaterialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@NeedMaterialID", SqlDbType.Int,4)};
            parameters[0].Value = NeedMaterialID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public Model.Sales.NeedMaterialHeader GetModel(int NeedMaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NeedMaterialID,SalesOrderID,DateOrder,Manager,StatusSubmit,StatusPurchaseMaterial,StatusStockOut,ModifiedDate,RootDepartmentID from Sales_NeedMaterialHeader ");
            strSql.Append(" where NeedMaterialID=@NeedMaterialID ");
            SqlParameter[] parameters = {
                  new SqlParameter("@NeedMaterialID",SqlDbType.Int,4)};
            parameters[0].Value = NeedMaterialID;

            Model.Sales.NeedMaterialHeader model = new Model.Sales.NeedMaterialHeader();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NeedMaterialID"].ToString() != "")
                {
                    model.NeedMaterialID = int.Parse(ds.Tables[0].Rows[0]["NeedMaterial"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SalesOrderID"].ToString() != "")
                {
                    model.SalesOrderID = int.Parse(ds.Tables[0].Rows[0]["SalesOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateOrder"].ToString() != "")
                {
                    model.DateOrder = DateTime.Parse(ds.Tables[0].Rows[0]["DateOrder"].ToString());
                }
                model.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                model.StatusSubmit = ds.Tables[0].Rows[0]["StatusSubmit"].ToString();
                model.StatusPurchaseMaterial = ds.Tables[0].Rows[0]["StatusPurchaseMaterial"].ToString();
                model.StatusStockOut = ds.Tables[0].Rows[0]["StatusStockOut"].ToString();
                if (ds.Tables[0].Rows[0]["ModifiedDate"].ToString() != "")
                {
                    model.ModifiedDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifiedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootDepartmentID"].ToString() != "")
                {
                    model.RootDepartmentID = int.Parse(ds.Tables[0].Rows[0]["RootDepartmentID"].ToString());
                }
                return model;

            }
            else
            {
                return null;

            }
            
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NeedMaterialID,SalesOrderID,DateOrder,Manager,StatusSubmit,StatusPurchaseMaterial,StatusStockOut,ModifiedDate,RootDepartmentID ");
            strSql.Append(" FROM Sales_NeedMaterialHeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" NeedMaterialID,SalesOrderID,DateOrder,Manager,StatusSubmit,StatusPurchaseMaterial,StatusStockOut,ModifiedDate,RootDepartmentID ");
            strSql.Append(" FROM Sales_NeedMaterialHeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <param name="PageIndex">当前页索引</param>
        /// <param name="strWhere">查询字符串</param>
        /// <param name="OrderType">设置排序类型, 非 0 值则降序</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string OrderType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Sales_NeedMaterialHeader";
            parameters[1].Value = "NeedMaterialID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = int.Parse(OrderType);
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetRecordFromPage", parameters, "ds");
        }

        /// <summary>
        /// 获得数据数量
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count (*) ");
            strSql.Append(" FROM Sales_NeedMaterialHeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingles(strSql.ToString()));
        }

        /// <summary>
        /// Updates the sales order header status.更新指定用料单的订货状态
        /// </summary>
        /// <param name="NeedMaterialID">The need material ID.</param>
        /// <param name="StatusPurchaseMaterial">The status purchase material.</param>
        public void UpdateNeedMaterialHeaderStatusPurchaseMaterial(int NeedMaterialID, string StatusPurchaseMaterial)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_NeedMaterialHeader set ");
            strSql.Append("StatusPurchaseMaterial=@StatusPurchaseMaterial ");
            strSql.Append(" where NeedMaterialID=");
            strSql.Append(NeedMaterialID.ToString());
            SqlParameter[] parameters = {
					new SqlParameter("@StatusPurchaseMaterial", SqlDbType.NVarChar,1)};
            parameters[0].Value = StatusPurchaseMaterial;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Updates the sales order header status.更新指定用料单的出库状态
        /// </summary>
        /// <param name="NeedMaterialID">The need material ID.</param>
        /// <param name="StatusStockOut">The status stock out.</param>
        public void UpdateNeedMaterialHeaderStatusStockOut(int NeedMaterialID, string StatusStockOut)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_NeedMaterialHeader set ");
            strSql.Append("StatusStockOut=@StatusStockOut ");
            strSql.Append(" where NeedMaterialID=");
            strSql.Append(NeedMaterialID.ToString());
            SqlParameter[] parameters = {
					new SqlParameter("@StatusStockOut", SqlDbType.NVarChar,1)};
            parameters[0].Value = StatusStockOut;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion
    }
}
