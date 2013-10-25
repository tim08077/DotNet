using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

namespace DAL.Sales
{
    public class Customer
    {
        public Customer()
        { 

        }

        public bool Exists(int  customerID )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) from dbo.Sales_Customer ");
            strSql.Append(" where CustomerID =@CustomerID ");
            SqlParameter[] parameters = { new SqlParameter("@CustomerID", SqlDbType.Int, 4) };
            parameters[0].Value=customerID;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);

        }


        public int Add(Model.Sales.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sales_Customer(");
            strSql.Append("CustomerName,Phone,CellPhone,Address,ModifiedDate)");
            strSql.Append(" values (");
            strSql.Append("@CustomerName,@Phone,@CellPhone,@Address,@ModifiedDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter ("@CustomerName",SqlDbType.NVarChar,50),
                    new SqlParameter ("@Phone",SqlDbType.NVarChar,20),
                    new SqlParameter ("@CellPhone",SqlDbType.NVarChar,20),
                    new SqlParameter ("@Address",SqlDbType.NVarChar,100),
                    new SqlParameter ("@ModifiedDate",SqlDbType.NVarChar,100 )};
            parameters[0].Value = model.CustomerName;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.CallPhone;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.ModifiedDate;

            object obj = DbHelperSQL.GetSingles(strSql.ToString(),parameters);
            if(obj==null)
            {
                return 1;

            }
            else
            {
                return Convert.ToInt32(obj);

            }



        }

        public void Update(Model.Sales.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  dbo.Sales_Customer set ");
            strSql.Append("CustomerName=@CustomerName, ");
            strSql.Append("Phone =@Phone, ");
            strSql.Append("CellPhone=@CellPhone, ");
            strSql.Append("Address =@Address, ");
            strSql.Append("ModifiedDate =@ModifiedDate ");
            strSql.Append("where CustomerID=@CustomerID ");
            SqlParameter[] parameters = { 
                  new SqlParameter ("@CustomerName",SqlDbType.NVarChar,50),
                  new SqlParameter ("@Phone",SqlDbType.NVarChar,20),
                  new SqlParameter ("@CellPhone",SqlDbType.NVarChar,20),
                  new SqlParameter ("@Address",SqlDbType.NVarChar,100),
                  new SqlParameter ("@ModifiedDate",SqlDbType.DateTime),
                  new SqlParameter ("@CustomerID",SqlDbType.Int,4)};
            parameters[0].Value = model.CustomerName;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.CallPhone;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.ModifiedDate;
            parameters[5].Value = model.CustomerId;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        public void Delete(int customerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Delete from Sales_Customer ");
            strSql.Append(" where CustomerID=@CustomerID ");
            SqlParameter[] parameters = { 
                    new SqlParameter ("@CustomerID",SqlDbType.Int,4)};
            parameters[0].Value = customerID;
            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        public Model.Sales.Customer GetModel(int customerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP (1) CustomerID, CustomerName, Phone, CellPhone, Address, rowguid, ModifiedDate ");
            strSql.Append(" FROM Sales_Customer where CustomerID =@CustomerID");
            SqlParameter[] parameters = { 
                      new SqlParameter ("@CustomerID",SqlDbType.Int,4)};
            parameters[0].Value = customerID;

            Model.Sales.Customer model = new Model.Sales.Customer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CustomerID"] != null)
                {
                    model.CustomerId = int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString());
                }
                model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.CallPhone = ds.Tables[0].Rows[0]["CellPhone"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                if (ds.Tables[0].Rows[0]["rowguid"].ToString() != null)
                {
                    model.rowguid = new Guid(ds.Tables[0].Rows[0]["rowguid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifiedDate"].ToString() != null)
                {
                    model.ModifiedDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifiedDate"].ToString());
                }
                return model;

            }
            else
            {
                return null;
            }



        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  CustomerID, CustomerName, Phone, CellPhone, Address, rowguid, ModifiedDate ");
            strSql.Append(" FROM Sales_Customer");
            if (strWhere!=null)
            {
                strSql.Append(" where" + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(int top, string strWhere,string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            if(top >0)
            {
                strSql.Append(" top " +top.ToString());

            }
            strSql.Append("SELECT  CustomerID, CustomerName, Phone, CellPhone, Address, rowguid, ModifiedDate ");
            strSql.Append(" FROM Sales_Customer");
            if(strWhere.Trim () !=null)
            {
                strSql.Append("  Where " + strWhere.ToString());
            }
            strSql.Append(" order " + order.ToString());
            return DbHelperSQL.Query(strSql.ToString());

        }

     
    }
}
