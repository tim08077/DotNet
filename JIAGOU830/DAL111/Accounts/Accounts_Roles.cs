using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

namespace DAL.Accounts
{
    public class Accounts_Roles
    {
        public Accounts_Roles()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Roles");
            strSql.Append(" where RoleID= @RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
				};
            parameters[0].Value = RoleID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        //2007.11.22 添加按RoleDescription判断是否存在
        /// <summary>
        /// 是否存在该记录 根据RoleDescription
        /// </summary>
        public bool Exists(string RoleDescription)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Roles");
            strSql.Append(" where RoleDescription= @RoleDescription");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleDescription", SqlDbType.VarChar)
				};
            parameters[0].Value = RoleDescription;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Accounts.Accounts_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Roles(");
            strSql.Append("RoleCode,RoleClassID,RoleDescription)");
            strSql.Append(" values (");
            strSql.Append("@RoleCode,@RoleClassID,@RoleDescription)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleCode", SqlDbType.Int,4),
					new SqlParameter("@RoleClassID", SqlDbType.Int,4),
					new SqlParameter("@RoleDescription", SqlDbType.NVarChar)};
            parameters[0].Value = model.RoleCode;
            parameters[1].Value = model.RoleClassID;
            parameters[2].Value = model.RoleDescription;

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
        public void Update(Model.Accounts.Accounts_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Roles set ");
            strSql.Append("RoleCode=@RoleCode,");
            strSql.Append("RoleClassID=@RoleClassID,");
            strSql.Append("RoleDescription=@RoleDescription");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleCode", SqlDbType.Int,4),
					new SqlParameter("@RoleClassID", SqlDbType.Int,4),
					new SqlParameter("@RoleDescription", SqlDbType.NVarChar)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleCode;
            parameters[2].Value = model.RoleClassID;
            parameters[3].Value = model.RoleDescription;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_Roles ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
				};
            parameters[0].Value = RoleID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Accounts.Accounts_Roles GetModel(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Roles ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;
            Model.Accounts.Accounts_Roles model = new Model.Accounts.Accounts_Roles();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.RoleID = RoleID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleCode"].ToString() != "")
                {
                    model.RoleCode = int.Parse(ds.Tables[0].Rows[0]["RoleCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleClassID"].ToString() != "")
                {
                    model.RoleClassID = int.Parse(ds.Tables[0].Rows[0]["RoleClassID"].ToString());
                }
                model.RoleDescription = ds.Tables[0].Rows[0]["RoleDescription"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        //2007.11.22 增加按RoleDescription取得对象实体
        /// <summary>
        /// 得到一个对象实体 根据RoleDescription
        /// </summary>
        public Model.Accounts.Accounts_Roles GetModel(string RoleDescription)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Roles ");
            strSql.Append(" where RoleDescription=@RoleDescription");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleDescription", SqlDbType.VarChar)};
            parameters[0].Value = RoleDescription;
            Model.Accounts.Accounts_Roles model = new Model.Accounts.Accounts_Roles();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.RoleDescription = RoleDescription;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleCode"].ToString() != "")
                {
                    model.RoleCode = int.Parse(ds.Tables[0].Rows[0]["RoleCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleClassID"].ToString() != "")
                {
                    model.RoleClassID = int.Parse(ds.Tables[0].Rows[0]["RoleClassID"].ToString());
                }
                model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
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
            strSql.Append("select [RoleID],[RoleCode],[RoleClassID],[RoleDescription] ");
            strSql.Append(" FROM Accounts_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
            parameters[0].Value = "Accounts_Roles";
            parameters[1].Value = "RoleID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        //2007.11.26添加 获取指定用户在当前角色分类下已经拥有的角色
        /// <summary>
        /// 获取指定用户在当前角色分类下已经拥有的角色
        /// </summary>
        /// <param name="RoleClassID">角色分类ID</param>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public DataSet GetRoleYes(int RoleClassID, int UserID)
        {
            if (RoleClassID != 0 && UserID != 0)
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@RoleClassID", SqlDbType.Int, 4),
                    new SqlParameter("@UserID", SqlDbType.Int, 4)
                    };
                parameters[0].Value = RoleClassID;
                parameters[1].Value = UserID;
                return DbHelperSQL.RunProcedure("GetRoleYes", parameters, "ds");
            }
            else
            {
                return null;
            }
        }
        //2007.11.26添加 获取指定用户在当前角色分类下还没拥有的角色
        /// <summary>
        /// 获取指定用户在当前角色分类下还没拥有的权限
        /// </summary>
        /// <param name="RoleClassID">角色分类ID</param>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public DataSet GetRoleNo(int RoleClassID, int UserID)
        {
            if (RoleClassID != 0 && UserID != 0)
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@RoleClassID", SqlDbType.Int, 4),
                    new SqlParameter("@UserID", SqlDbType.Int, 4)
                    };
                parameters[0].Value = RoleClassID;
                parameters[1].Value = UserID;
                return DbHelperSQL.RunProcedure("GetRoleNo", parameters, "ds");
            }
            else
            {
                return null;
            }
        }

        #endregion  成员方法
    }
}
