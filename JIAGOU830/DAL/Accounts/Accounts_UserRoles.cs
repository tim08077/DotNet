using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using DBUtility;

namespace DAL.Accounts
{
    public class Accounts_UserRoles
    {
        public Accounts_UserRoles()
        { }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserRoles");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = { new SqlParameter("@ID",SqlDbType.Int,4) };
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);

        }

        public bool Exists(int ID,int RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserRoles ");
            strSql.Append("where ID=@ID ");
            strSql.Append("and RoleCode=@RoleCode");
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@RoleCode", SqlDbType.Int, 4) };
            parameters[0].Value = ID;
            parameters[1].Value = RoleCode;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int Add(Model.Accounts.Accounts_UserRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserRoles(");
            strSql.Append("UserID,RoleCode)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@RoleCode", SqlDbType.Int, 4) };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleCode;

            Object obj = DbHelperSQL.GetSingles(strSql.ToString(),parameters); 
            if(obj==null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        public void Update(Model.Accounts.Accounts_UserRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Accounts_UserRoles Set ");
            strSql.Append(" UserID=@UserID");
            strSql.Append("RoleCode=@RoleCode");
            strSql.Append("where ID=@ID");
            SqlParameter[] parameters = { 
                   new SqlParameter("@UserID",SqlDbType.Int,4),
                   new SqlParameter("@RoleCode",SqlDbType.Int,4),
                   new SqlParameter("@ID",SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleCode;
            parameters[2].Value = model.ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

        }

        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete Accounts_UserRoles ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = { new SqlParameter("@ID",SqlDbType.Int,4) };
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int UserID,int RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete Accounts_UserRoles ");
            strSql.Append(" where UserID=@UserID ");
            strSql.Append(" and RoleCode=@RoleCode ");
            SqlParameter[] parameters = { 
                 new SqlParameter("@UserID",SqlDbType.Int,4),
                 new SqlParameter("@RoleCode",SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleCode;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public Model.Accounts.Accounts_UserRoles GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_UserRoles ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = ID;
            Model.Accounts.Accounts_UserRoles model = new Model.Accounts.Accounts_UserRoles();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != null)
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }

                if (ds.Tables[0].Rows[0]["RoleCode"].ToString() != null)
                {
                    model.RoleCode = int.Parse(ds.Tables[0].Rows[0]["RoleCode"].ToString());
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
            strSql.Append("select [ID],[UserID],[RoleCode] ");
            strSql.Append(" FROM Accounts_UserRoles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public void Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_UserRoles");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

         
    }
}
