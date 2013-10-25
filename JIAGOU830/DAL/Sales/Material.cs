using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;


namespace DAL.Sales
{
    public class Material
    {
        public Material()
        { }
        #region 成员方法
        public bool Exists(int MaterialID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from Sales_Material");
            sb.Append(" where MaterialID=@MaterialID");
            SqlParameter[] parameters = { new SqlParameter("@MaterialID", SqlDbType.Int, 4) };
            parameters[0].Value = MaterialID;
            return DbHelperSQL.Exists(sb.ToString(), parameters);

        }

        public int Add(Model.Sales.Material model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" insert into Sales_Material(");
            sb.Append("MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID)");
            sb.Append(" valus (");
            sb.Append("@MaterialCategoryID,@ManufacturerID,@Name,@ManufacturerCode,@RootDepartmentID)");
            sb.Append(";select @@IDENTITY");
            SqlParameter[] parameters ={
                                           new SqlParameter ("@MaterialCategoryID",SqlDbType.Int,4),
                                           new SqlParameter("@ManufacturerID",SqlDbType.Int,4),
                                           new SqlParameter("@Name",SqlDbType.NVarChar,50),
                                           new SqlParameter("@ManufacturerCode",SqlDbType.NVarChar,20),
                                           new SqlParameter("@RootDepartmentID",SqlDbType.Int,4)};
            parameters[0].Value = model.MaterialCategoryID;
            parameters[1].Value = model.ManufacturerID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.ManufacturerCode;
            parameters[4].Value = model.RootDepartmentID;

            object obj = DbHelperSQL.GetSingles(sb.ToString(), parameters);
            if (obj == null)
            {
                return 1;

            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }
        public void Update(Model.Sales.Material model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update Sales_Material set ");
            sb.Append(" MaterialCategoryID=@MaterialCategoryID,");
            sb.Append(" ManufacturerID=@ManufacturerID,");
            sb.Append(" Name=@Name,");
            sb.Append(" ManufacturerCode=@ManufacturerCode,");
            sb.Append(" RootDepartmentID=@RootDepartmentID");
            sb.Append(" where MaterialID=@MaterialID");
            SqlParameter[] parameters = { new SqlParameter ("@MaterialCategoryID",SqlDbType.Int,4),
                                          new SqlParameter ("@ManufacturerID",SqlDbType.Int,4),
                                          new SqlParameter ("@Name",SqlDbType.NVarChar,50),
                                          new SqlParameter ("@ManufacturerCode",SqlDbType.NVarChar,20),
                                          new SqlParameter ("@RootDepartmentID",SqlDbType.Int,4),
                                          new SqlParameter ("@MaterialID",SqlDbType.Int,4)};
            parameters[0].Value = model.MaterialCategoryID;
            parameters[1].Value = model.ManufacturerID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.ManufacturerCode;
            parameters[4].Value = model.RootDepartmentID;
            parameters[5].Value = model.MaterialID;

            DbHelperSQL.ExecuteSql(sb.ToString(), parameters);

        }

        public void Delete(int MaterialID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Sales_Material ");
            sb.Append(" where MaterialID=@MaterialID ");
            SqlParameter[] parameters = { new SqlParameter("MaterialID", SqlDbType.Int, 4) };
            parameters[0].Value = MaterialID;
            DbHelperSQL.ExecuteSql(sb.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="MaterialID"></param>
        /// <returns></returns>
        public Model.Sales.Material GetModel(int MaterialID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  top 1 MaterialID,MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID from Sales_Material ");
            sb.Append(" where Material=@Material");
            SqlParameter[] parameters = { new SqlParameter("MaterialID", SqlDbType.Int, 4) };
            parameters[0].Value = MaterialID;

            Model.Sales.Material model = new Model.Sales.Material();
            DataSet ds = DbHelperSQL.Query(sb.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MaterialID"].ToString() != "")
                {
                    model.MaterialID = int.Parse(ds.Tables[0].Rows[0]["MaterialID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString() != "")
                {
                    model.MaterialCategoryID = int.Parse(ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ManufacturerID"].ToString() != "")
                {
                    model.ManufacturerID = int.Parse(ds.Tables[0].Rows[0]["ManufacturerID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ManufacturerCode"].ToString() != "")
                {
                    model.ManufacturerCode = ds.Tables[0].Rows[0]["ManufacturerCode"].ToString();
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
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select MaterialID,MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID ");
            sb.Append("  FROM Sales_Material  ");
            if (strWhere.Trim() != "")
            {
                sb.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(sb.ToString());
        }
        /// <summary>列表
        /// 获取前几行数据
        /// </summary>
        /// <param name="top">前几行</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序</param>
        /// <returns>DataSet</returns>
        public DataSet GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            if (top > 0)
            {
                sb.Append(" top " + top.ToString());
            }
            sb.Append(" MaterialID,MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID ");
            sb.Append(" FROM Sales_Material  ");
            if (strWhere.Trim() != "")
            {
                sb.Append(" Where " + strWhere.ToString());
            }
            sb.Append(" order " + filedOrder.ToString());
            return DbHelperSQL.Query(sb.ToString());

        }
        /// <summary>
        /// 统计有多少行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select Count(*)");
            sb.Append(" from Sales_Material ");
            if (strWhere.Trim() != "")
            {
                sb.Append(" where " + strWhere.ToString());
            }
            return Convert.ToInt32(DbHelperSQL.GetSingles(sb.ToString()));
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <param name="PageIndex">当前页索引</param>
        /// <param name="strWhere">查询字符串</param>
        /// <param name="OrderType">设置排序类型, 非 0 值则降序</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string OrderType)///此存储过程需要再练习 
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
            parameters[0].Value = "Sales_Material";
            parameters[1].Value = "MaterialID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = int.Parse(OrderType);
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetRecordFromPage", parameters, "ds");
        }
        /// <summary>
        /// 更具材料名称得到一个model
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Model.Sales.Material GetModel(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  top 1 MaterialID,MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID from Sales_Material ");
            sb.Append(" where Name=@Name ");
            SqlParameter[] parameters = { new SqlParameter("@Name", SqlDbType.NVarChar, 50) };
            parameters[0].Value = name;

            Model.Sales.Material model = new Model.Sales.Material();
            DataSet ds = DbHelperSQL.Query(sb.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MaterialID"].ToString() != "")
                {
                    model.MaterialID = int.Parse(ds.Tables[0].Rows[0]["MaterialID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString() != "")
                {
                    model.MaterialCategoryID = int.Parse(ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ManufacturerID"].ToString() != "")
                {
                    model.ManufacturerID = int.Parse(ds.Tables[0].Rows[0]["ManufacturerID"].ToString());

                }
                if (ds.Tables[0].Rows[0]["Name"].ToString() != null)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ManufacturerCode"].ToString() != null)
                {
                    model.ManufacturerCode = ds.Tables[0].Rows[0]["ManufacturerCode"].ToString();
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
        /// 根据材料类型，材料名称，制造id  得到Model  
        /// </summary>
        /// <param name="MaterialCategoryID"></param>
        /// <param name="ManufacturerID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Model.Sales.Material GetModel(int MaterialCategoryID, int ManufacturerID, string Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  top 1 MaterialID,MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID from Sales_Material   ");
            sb.Append("  where MaterialCategoryID=@MaterialCategoryID and ManufacturerID=@ManufacturerID and Name=@Name ");
            SqlParameter[] parameters ={new SqlParameter ("@MaterialCategoryID",SqlDbType.Int,4),
                                       new SqlParameter ("@ManufacturerID",SqlDbType.Int,4),
                                       new SqlParameter ("@Name",SqlDbType.NVarChar,50)
                                      };
            parameters[0].Value = MaterialCategoryID;
            parameters[1].Value = ManufacturerID;
            parameters[2].Value = Name;

            Model.Sales.Material model = new Model.Sales.Material();
            DataSet ds = DbHelperSQL.Query(sb.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MaterialID"].ToString() != "")
                {
                    model.MaterialID = int.Parse(ds.Tables[0].Rows[0]["MaterialID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString() != "")
                {
                    model.MaterialCategoryID = int.Parse(ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ManufacturerID"].ToString() != "")
                {
                    model.ManufacturerID = int.Parse(ds.Tables[0].Rows[0]["ManufacturerID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ManufacturerCode"].ToString() != "")
                {
                    model.ManufacturerCode = ds.Tables[0].Rows[0]["ManufacturerCode"].ToString();
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
        /// 根据材料类型，材料名称 得到一个对象实体  
        /// </summary>
        /// <param name="MaterialCategoryID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Model.Sales.Material GetModel(int MaterialCategoryID, string Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select  top 1 MaterialID,MaterialCategoryID,ManufacturerID,Name,ManufacturerCode,RootDepartmentID from Sales_Material ");
            sb.Append("  where MaterialCategoryID=@MaterialCategoryID and Name=@Name ");
            SqlParameter[] parameters = { new SqlParameter ("@MaterialCategoryID",SqlDbType.Int,4),
                                          new SqlParameter ("@Name",SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value=MaterialCategoryID;
            parameters[1].Value=Name;

            Model.Sales.Material model = new Model.Sales.Material();
            DataSet ds = DbHelperSQL.Query(sb.ToString(),parameters);
            if(ds.Tables[0].Rows.Count>0)
            {
                if (ds.Tables[0].Rows[0]["MaterialID"].ToString() != "")
                {
                    model.MaterialID = int.Parse(ds.Tables[0].Rows[0]["MaterialID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString() != "")
                {
                    model.MaterialCategoryID = int.Parse(ds.Tables[0].Rows[0]["MaterialCategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ManufacturerID"].ToString() != "")
                {
                    model.ManufacturerID = int.Parse(ds.Tables[0].Rows[0]["ManufacturerID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ManufacturerCode"].ToString() != "")
                {
                    model.ManufacturerCode=ds.Tables[0].Rows[0]["ManufacturerCode"].ToString();
                }
                if(ds.Tables[0].Rows[0]["RootDepartmentID"].ToString() !="")
                {
                    model.RootDepartmentID=int.Parse(ds.Tables[0].Rows[0]["RootDepartmentID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }


        }
        /// <summary>
        /// 判断材料类型，材料名称，制造id 是否存在
        /// </summary>
        /// <param name="MaterialCategoryID"></param>
        /// <param name="ManufacturerID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Exists(int MaterialCategoryID, int ManufacturerID, string Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from Sales_Material");
            sb.Append("  where MaterialCategoryID=@MaterialCategoryID and ManufacturerID=@ManufacturerID and Name=@Name ");
            SqlParameter[] parameters = { 
                                           new SqlParameter ("@MaterialCategoryID",SqlDbType.Int,4),
                                           new SqlParameter("@ManufacturerID",SqlDbType.Int,4),
                                           new SqlParameter("@Name",SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value=MaterialCategoryID;
            parameters[1].Value=ManufacturerID;
            parameters[2].Value = Name;
            return DbHelperSQL.Exists(sb.ToString(), parameters);
        }
        /// <summary>
        /// 判断材料类型，材料名称  是否存在
        /// </summary>
        /// <param name="MaterialCategoryID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Exists(int MaterialCategoryID, string Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select count(1) from Sales_Material ");
            sb.Append(" where MaterialCategoryID=@MaterialCategoryID and Name=@Name  ");
            SqlParameter[] parameters = { 
                                            new SqlParameter ("@MaterialCategoryID",SqlDbType.Int,4),
                                            new SqlParameter ("@Name",SqlDbType.NVarChar ,50)
                                        };
            parameters[0].Value=MaterialCategoryID;
            parameters[1].Value=Name;

            return DbHelperSQL.Exists(sb.ToString(),parameters);

        }


        #endregion

    }
}
