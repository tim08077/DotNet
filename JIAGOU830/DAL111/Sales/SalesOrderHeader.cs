using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;

namespace DAL.Sales
{
    public class SalesOrderHeader
    {
        public SalesOrderHeader()
        { }
        #region 成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SalesOrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sales_SalesOrderHeader");
            strSql.Append(" where SalesOrderID=@SalesOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesOrderID", SqlDbType.Int,4)};
            parameters[0].Value = SalesOrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Sales.SalesOrderHeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sales_SalesOrderHeader(");
            strSql.Append("CustomerID,DateOrder,DateDelivery,DateInspect,DateInstall,DateAllDone,SalesOrderNumber,Address,ContractAmount,SubTotal,TotalDue,Brokerage,RealIncome,PrepaidPayment,ResidualPayment,Designer,Producer,Installer,NotesOrder,NotesManufacture,NotesInstall,StatusSubmit,StatusPurchaseMaterial,StatusPayment,StatusAll,ModifiedDate,RootDepartmentID)");
            strSql.Append(" values (");
            strSql.Append("@CustomerID,@DateOrder,@DateDelivery,@DateInspect,@DateInstall,@DateAllDone,@SalesOrderNumber,@Address,@ContractAmount,@SubTotal,@TotalDue,@Brokerage,@RealIncome,@PrepaidPayment,@ResidualPayment,@Designer,@Producer,@Installer,@NotesOrder,@NotesManufacture,@NotesInstall,@StatusSubmit,@StatusPurchaseMaterial,@StatusPayment,@StatusAll,@ModifiedDate,@RootDepartmentID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@DateOrder", SqlDbType.DateTime),
					new SqlParameter("@DateDelivery", SqlDbType.DateTime),
					new SqlParameter("@DateInspect", SqlDbType.DateTime),
					new SqlParameter("@DateInstall", SqlDbType.DateTime),
					new SqlParameter("@DateAllDone", SqlDbType.DateTime),
					new SqlParameter("@SalesOrderNumber", SqlDbType.NVarChar,30),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@ContractAmount", SqlDbType.Decimal,9),
					new SqlParameter("@SubTotal", SqlDbType.Decimal,9),
					new SqlParameter("@TotalDue", SqlDbType.Decimal,9),
					new SqlParameter("@Brokerage", SqlDbType.Decimal,9),
					new SqlParameter("@RealIncome", SqlDbType.Decimal,9),
					new SqlParameter("@PrepaidPayment", SqlDbType.Decimal,9),
					new SqlParameter("@ResidualPayment", SqlDbType.Decimal,9),
					new SqlParameter("@Designer", SqlDbType.VarChar,50),
					new SqlParameter("@Producer", SqlDbType.NVarChar,50),
					new SqlParameter("@Installer", SqlDbType.NVarChar,50),
					new SqlParameter("@NotesOrder", SqlDbType.NVarChar,200),
					new SqlParameter("@NotesManufacture", SqlDbType.NVarChar,200),
					new SqlParameter("@NotesInstall", SqlDbType.NVarChar,200),
					new SqlParameter("@StatusSubmit", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusPurchaseMaterial", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusPayment", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusAll", SqlDbType.NVarChar,1),
					new SqlParameter("@ModifiedDate", SqlDbType.DateTime),
					new SqlParameter("@RootDepartmentID", SqlDbType.Int,4)};
            parameters[0].Value = model.CustomerID;
            parameters[1].Value = model.DateOrder;
            parameters[2].Value = model.DateDelivery;
            parameters[3].Value = model.DateInspect;
            parameters[4].Value = model.DateInstall;
            parameters[5].Value = model.DateAllDone;
            parameters[6].Value = model.SalesOrderNumber;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.ContractAmount;
            parameters[9].Value = model.SubTotal;
            parameters[10].Value = model.TotalDue;
            parameters[11].Value = model.Brokerage;
            parameters[12].Value = model.RealIncome;
            parameters[13].Value = model.PrepaidPayment;
            parameters[14].Value = model.ResidualPayment;
            parameters[15].Value = model.Designer;
            parameters[16].Value = model.Producer;
            parameters[17].Value = model.Installer;
            parameters[18].Value = model.NotesOrder;
            parameters[19].Value = model.NotesManufacture;
            parameters[20].Value = model.NotesInstall;
            parameters[21].Value = model.StatusSubmit;
            parameters[22].Value = model.StatusPurchaseMaterial;
            parameters[23].Value = model.StatusPayment;
            parameters[24].Value = model.StatusAll;
            parameters[25].Value = model.ModifiedDate;
            parameters[26].Value = model.RootDepartmentID;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Model.Sales.SalesOrderHeader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_SalesOrderHeader set ");
            strSql.Append("CustomerID=@CustomerID,");
            strSql.Append("DateOrder=@DateOrder,");
            strSql.Append("DateDelivery=@DateDelivery,");
            strSql.Append("DateInspect=@DateInspect,");
            strSql.Append("DateInstall=@DateInstall,");
            strSql.Append("DateAllDone=@DateAllDone,");
            strSql.Append("SalesOrderNumber=@SalesOrderNumber,");
            strSql.Append("Address=@Address,");
            strSql.Append("ContractAmount=@ContractAmount,");
            strSql.Append("SubTotal=@SubTotal,");
            strSql.Append("TotalDue=@TotalDue,");
            strSql.Append("Brokerage=@Brokerage,");
            strSql.Append("RealIncome=@RealIncome,");
            strSql.Append("PrepaidPayment=@PrepaidPayment,");
            strSql.Append("ResidualPayment=@ResidualPayment,");
            strSql.Append("Designer=@Designer,");
            strSql.Append("Producer=@Producer,");
            strSql.Append("Installer=@Installer,");
            strSql.Append("NotesOrder=@NotesOrder,");
            strSql.Append("NotesManufacture=@NotesManufacture,");
            strSql.Append("NotesInstall=@NotesInstall,");
            strSql.Append("StatusSubmit=@StatusSubmit,");
            strSql.Append("StatusPurchaseMaterial=@StatusPurchaseMaterial,");
            strSql.Append("StatusPayment=@StatusPayment,");
            strSql.Append("StatusAll=@StatusAll,");
            strSql.Append("ModifiedDate=@ModifiedDate,");
            strSql.Append("RootDepartmentID=@RootDepartmentID");
            strSql.Append(" where SalesOrderID=@SalesOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesOrderID", SqlDbType.Int,4),
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@DateOrder", SqlDbType.DateTime),
					new SqlParameter("@DateDelivery", SqlDbType.DateTime),
					new SqlParameter("@DateInspect", SqlDbType.DateTime),
					new SqlParameter("@DateInstall", SqlDbType.DateTime),
					new SqlParameter("@DateAllDone", SqlDbType.DateTime),
					new SqlParameter("@SalesOrderNumber", SqlDbType.NVarChar,30),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@ContractAmount", SqlDbType.Decimal,9),
					new SqlParameter("@SubTotal", SqlDbType.Decimal,9),
					new SqlParameter("@TotalDue", SqlDbType.Decimal,9),
					new SqlParameter("@Brokerage", SqlDbType.Decimal,9),
					new SqlParameter("@RealIncome", SqlDbType.Decimal,9),
					new SqlParameter("@PrepaidPayment", SqlDbType.Decimal,9),
					new SqlParameter("@ResidualPayment", SqlDbType.Decimal,9),
					new SqlParameter("@Designer", SqlDbType.VarChar,50),
					new SqlParameter("@Producer", SqlDbType.NVarChar,50),
					new SqlParameter("@Installer", SqlDbType.NVarChar,50),
					new SqlParameter("@NotesOrder", SqlDbType.NVarChar,200),
					new SqlParameter("@NotesManufacture", SqlDbType.NVarChar,200),
					new SqlParameter("@NotesInstall", SqlDbType.NVarChar,200),
					new SqlParameter("@StatusSubmit", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusPurchaseMaterial", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusPayment", SqlDbType.NVarChar,1),
					new SqlParameter("@StatusAll", SqlDbType.NVarChar,1),
					new SqlParameter("@ModifiedDate", SqlDbType.DateTime),
					new SqlParameter("@RootDepartmentID", SqlDbType.Int,4)};
            parameters[0].Value = model.SalesOrderID;
            parameters[1].Value = model.CustomerID;
            parameters[2].Value = model.DateOrder;
            parameters[3].Value = model.DateDelivery;
            parameters[4].Value = model.DateInspect;
            parameters[5].Value = model.DateInstall;
            parameters[6].Value = model.DateAllDone;
            parameters[7].Value = model.SalesOrderNumber;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.ContractAmount;
            parameters[10].Value = model.SubTotal;
            parameters[11].Value = model.TotalDue;
            parameters[12].Value = model.Brokerage;
            parameters[13].Value = model.RealIncome;
            parameters[14].Value = model.PrepaidPayment;
            parameters[15].Value = model.ResidualPayment;
            parameters[16].Value = model.Designer;
            parameters[17].Value = model.Producer;
            parameters[18].Value = model.Installer;
            parameters[19].Value = model.NotesOrder;
            parameters[20].Value = model.NotesManufacture;
            parameters[21].Value = model.NotesInstall;
            parameters[22].Value = model.StatusSubmit;
            parameters[23].Value = model.StatusPurchaseMaterial;
            parameters[24].Value = model.StatusPayment;
            parameters[25].Value = model.StatusAll;
            parameters[26].Value = model.ModifiedDate;
            parameters[27].Value = model.RootDepartmentID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SalesOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sales_SalesOrderHeader ");
            strSql.Append(" where SalesOrderID=@SalesOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesOrderID", SqlDbType.Int,4)};
            parameters[0].Value = SalesOrderID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Sales.SalesOrderHeader GetModel(int SalesOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SalesOrderID,CustomerID,DateOrder,DateDelivery,DateInspect,DateInstall,DateAllDone,SalesOrderNumber,Address,ContractAmount,SubTotal,TotalDue,Brokerage,RealIncome,PrepaidPayment,ResidualPayment,Designer,Producer,Installer,NotesOrder,NotesManufacture,NotesInstall,StatusSubmit,StatusPurchaseMaterial,StatusPayment,StatusAll,ModifiedDate,RootDepartmentID from Sales_SalesOrderHeader ");
            strSql.Append(" where SalesOrderID=@SalesOrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesOrderID", SqlDbType.Int,4)};
            parameters[0].Value = SalesOrderID;

            Model.Sales.SalesOrderHeader model = new Model.Sales.SalesOrderHeader();
            
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SalesOrderID"].ToString() != "")
                {
                    model.SalesOrderID = int.Parse(ds.Tables[0].Rows[0]["SalesOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                {
                    model.CustomerID = int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateOrder"].ToString() != "")
                {
                    model.DateOrder = DateTime.Parse(ds.Tables[0].Rows[0]["DateOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateDelivery"].ToString() != "")
                {
                    model.DateDelivery = DateTime.Parse(ds.Tables[0].Rows[0]["DateDelivery"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateInspect"].ToString() != "")
                {
                    model.DateInspect = DateTime.Parse(ds.Tables[0].Rows[0]["DateInspect"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateInstall"].ToString() != "")
                {
                    model.DateInstall = DateTime.Parse(ds.Tables[0].Rows[0]["DateInstall"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateAllDone"].ToString() != "")
                {
                    model.DateAllDone = DateTime.Parse(ds.Tables[0].Rows[0]["DateAllDone"].ToString());
                }
                model.SalesOrderNumber = ds.Tables[0].Rows[0]["SalesOrderNumber"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                if (ds.Tables[0].Rows[0]["ContractAmount"].ToString() != "")
                {
                    model.ContractAmount = decimal.Parse(ds.Tables[0].Rows[0]["ContractAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubTotal"].ToString() != "")
                {
                    model.SubTotal = decimal.Parse(ds.Tables[0].Rows[0]["SubTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalDue"].ToString() != "")
                {
                    model.TotalDue = decimal.Parse(ds.Tables[0].Rows[0]["TotalDue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Brokerage"].ToString() != "")
                {
                    model.Brokerage = decimal.Parse(ds.Tables[0].Rows[0]["Brokerage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealIncome"].ToString() != "")
                {
                    model.RealIncome = decimal.Parse(ds.Tables[0].Rows[0]["RealIncome"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PrepaidPayment"].ToString() != "")
                {
                    model.PrepaidPayment = decimal.Parse(ds.Tables[0].Rows[0]["PrepaidPayment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResidualPayment"].ToString() != "")
                {
                    model.ResidualPayment = decimal.Parse(ds.Tables[0].Rows[0]["ResidualPayment"].ToString());
                }
                model.Designer = ds.Tables[0].Rows[0]["Designer"].ToString();
                model.Producer = ds.Tables[0].Rows[0]["Producer"].ToString();
                model.Installer = ds.Tables[0].Rows[0]["Installer"].ToString();
                model.NotesOrder = ds.Tables[0].Rows[0]["NotesOrder"].ToString();
                model.NotesManufacture = ds.Tables[0].Rows[0]["NotesManufacture"].ToString();
                model.NotesInstall = ds.Tables[0].Rows[0]["NotesInstall"].ToString();
                model.StatusSubmit = ds.Tables[0].Rows[0]["StatusSubmit"].ToString();
                model.StatusPurchaseMaterial = ds.Tables[0].Rows[0]["StatusPurchaseMaterial"].ToString();
                model.StatusPayment = ds.Tables[0].Rows[0]["StatusPayment"].ToString();
                model.StatusAll = ds.Tables[0].Rows[0]["StatusAll"].ToString();
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
            strSql.Append("select SalesOrderID,CustomerID,DateOrder,DateDelivery,DateInspect,DateInstall,DateAllDone,SalesOrderNumber,Address,ContractAmount,SubTotal,TotalDue,Brokerage,RealIncome,PrepaidPayment,ResidualPayment,Designer,Producer,Installer,NotesOrder,NotesManufacture,NotesInstall,StatusSubmit,StatusPurchaseMaterial,StatusPayment,StatusAll,ModifiedDate,RootDepartmentID ");
            strSql.Append(" FROM Sales_SalesOrderHeader ");
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
            strSql.Append(" SalesOrderID,CustomerID,DateOrder,DateDelivery,DateInspect,DateInstall,DateAllDone,SalesOrderNumber,Address,ContractAmount,SubTotal,TotalDue,Brokerage,RealIncome,PrepaidPayment,ResidualPayment,Designer,Producer,Installer,NotesOrder,NotesManufacture,NotesInstall,StatusSubmit,StatusPurchaseMaterial,StatusPayment,StatusAll,ModifiedDate,RootDepartmentID ");
            strSql.Append(" FROM Sales_SalesOrderHeader ");
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
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">起始页</param>
        /// <param name="strWhere"></param>
        /// <param name="OrderType">0 为asc ,非0 为desc  </param>
        /// <returns></returns>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere,string OrderType)
        {
            SqlParameter[] parameters ={
                   new SqlParameter("@tblName",SqlDbType.VarChar,255),
                   new SqlParameter("@fldName",SqlDbType.VarChar,255),   
                   new SqlParameter("@PageSize",SqlDbType.Int), 
                   new SqlParameter("@PageIndex",SqlDbType.Int),
                   new SqlParameter("@IsReCount",SqlDbType.Bit), 
                   new SqlParameter("@OrderType",SqlDbType.Bit),
                   new SqlParameter("@strWhere",SqlDbType.VarChar,1000)
                   };
            parameters[0].Value = "Sales_SalesOrderHeader";
            parameters[1].Value = "SalesOrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = int.Parse(OrderType);
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetRecordFromPage",parameters,"ds");


        }
        //返回数据量
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count (*) ");
            strSql.Append(" from Sales_SalesOrderHeader ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " +strWhere);

            }
            return Convert.ToInt32(DbHelperSQL.GetSingles(strSql.ToString()));

        }
        //获得订单的用料总金额 
        public decimal GetSubTotal(int SalesOrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Subtotal) from ");
            strSql.Append(" FROM Sales_NeedMaterialDetail  ");
            strSql.Append(" where SalesOrderID="+SalesOrderID.ToString());
            return Convert.ToDecimal(DbHelperSQL.GetSingles(strSql.ToString()));
        }
        /// <summary>
        /// 跟新订单真实价格 和真实小计价格
        /// </summary>
        /// <param name="SalesOrderID"></param>
        /// <param name="Discount"></param>
        public void UpdateNeedMaterialDetailRealUnitPriceAndSubTotal(int SalesOrderID ,decimal Discount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update Sales_NeedMaterialDetail set ");
            strSql.Append(" RealUnitPrice =UnitPrice*@Discount");
            strSql.Append(" RealSubTotal= SubTotal*@Discount");
            strSql.Append(" where SalesOrderID=@SalesOrderID ");
            SqlParameter[] Parameter = {
                   new SqlParameter ("@Discount",SqlDbType.Decimal,9 ),                    
                   new SqlParameter ("@SalesOrderID",SqlDbType.Int,4)                   
                   };
            Parameter[0].Value = Discount;
            Parameter[1].Value = SalesOrderID;

            DbHelperSQL.ExecuteSql(strSql.ToString(),Parameter);
        
            
        }
        /// <summary>
        /// 更新制定订单的订货装货状态
        /// </summary>
        /// <param name="SalesOrderID"></param>
        /// <param name="StatusPurchaseMaterial"></param>
        public void UpdateSalesOrderHeaderStatusPurchaseMaterial(int SalesOrderID, string StatusPurchaseMaterial)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update Sales_SalesOrderHeader set ");
            strSql.Append(" StatusPurchaseMaterial=@StatusPurchaseMaterial ");
            strSql.Append(" where SalesOrderID=@SalesOrderID ");
            SqlParameter[] parameters = {
                            new SqlParameter ("@SalesOrderID",SqlDbType.Int,4),
                            new SqlParameter ("@StatusPurchaseMaterial",SqlDbType.NVarChar,1)
                            };
            parameters[0].Value = SalesOrderID;
            parameters[1].Value = StatusPurchaseMaterial;
            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

        }

        #endregion 
    }
}
