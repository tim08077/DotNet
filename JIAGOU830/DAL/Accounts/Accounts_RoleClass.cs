using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;


namespace DAL.Accounts
{
    public class Accounts_RoleClass
    {
        public Accounts_RoleClass()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_RoleClass");
            strSql.Append(" where RoleClassID= @RoleClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleClassID", SqlDbType.Int,4)
				};
            parameters[0].Value = RoleClassID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Accounts.Accounts_RoleClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_RoleClass(");
            strSql.Append("RoleClassName)");
            strSql.Append(" values (");
            strSql.Append("@RoleClassName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleClassName", SqlDbType.NVarChar)};
            parameters[0].Value = model.RoleClassName;

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
        public void Update(Model.Accounts.Accounts_RoleClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_RoleClass set ");
            strSql.Append("RoleClassName=@RoleClassName");
            strSql.Append(" where RoleClassID=@RoleClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleClassID", SqlDbType.Int,4),
					new SqlParameter("@RoleClassName", SqlDbType.NVarChar)};
            parameters[0].Value = model.RoleClassID;
            parameters[1].Value = model.RoleClassName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RoleClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_RoleClass ");
            strSql.Append(" where RoleClassID=@RoleClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleClassID", SqlDbType.Int,4)
				};
            parameters[0].Value = RoleClassID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Accounts.Accounts_RoleClass GetModel(int RoleClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_RoleClass ");
            strSql.Append(" where RoleClassID=@RoleClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleClassID", SqlDbType.Int,4)};
            parameters[0].Value = RoleClassID;
            Model.Accounts.Accounts_RoleClass model = new Model.Accounts.Accounts_RoleClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.RoleClassID = RoleClassID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.RoleClassName = ds.Tables[0].Rows[0]["RoleClassName"].ToString();
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
            strSql.Append("select [RoleClassID],[RoleClassName] ");
            strSql.Append(" FROM Accounts_RoleClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}