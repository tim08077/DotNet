using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Accounts.Data
{
    public class User:Accounts.DbObject
    {
        public User(string newConnectionString):base(newConnectionString)
        {
        }
        /// <summary>
        /// 根据userID取得用户信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataRow Retrieve(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users");
            strSql.Append(" where UserID= @UserID");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID",SqlDbType.Int,4) };
            parameters[0].Value = userID;
            DataSet set = base.ExecuteSql(strSql.ToString(), parameters, "Users");
            if(set.Tables[0].Rows.Count >0)
            {
                return set.Tables[0].Rows[0];
            }
            return null;

        }
        public DataRow Retrieve(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users");
            strSql.Append(" where UserName= @UserName");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = userName;
            DataSet set = base.ExecuteSql(strSql.ToString(), parameters, "Users");
            if(set.Tables[0].Rows.Count==0)
            {
                throw new Exception("无此用户：" + userName);
            }
            return set.Tables[0].Rows[0];

        }
        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int ValidateLogin(string userName,string passWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users");
            strSql.Append(" where UserName= @userName");
            strSql.Append(" and Password=@passWord");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@userName", SqlDbType.VarChar, 50), new SqlParameter("@passWord",SqlDbType.VarChar,50) };
            parameters[0].Value = userName;
            parameters[1].Value = passWord;
            SqlDataReader sdr = base.ExecuteSql(strSql.ToString(),parameters);
            if (sdr.Read())
            {
                int userID = (int)sdr["UserID"];
                sdr.Close();
                return userID;

            }
            else
            {
                sdr.Close();
                return -1;
            }

        }
        /// <summary>
        /// 获得用户角色代码列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ArrayList GetUserRoles(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct(ur.RoleCode), r.RoleDescription FROM Accounts_UserRoles ur");
            strSql.Append(" INNER JOIN Accounts_Roles r ON ur.RoleCode = r.RoleCode");
            strSql.Append(" where ur.UserID = @UserID");
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID",SqlDbType.Int,4) };
            parameters[0].Value = userID;
            SqlDataReader reader = base.ExecuteSql(strSql.ToString(),parameters);
            while(reader.Read())
            {
                list.Add(reader.GetInt32(0).ToString());
            }
            base.Connection.Close();
            return list;
        }
        /// <summary>
        /// 取得用户权限描述列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ArrayList GetEffectivePermissionList(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT p.PermissionDescription FROM Accounts_RolePermissions rp");
            strSql.Append(" inner join Accounts_Permissions p on rp.PermissionCode=p.PermissionCode");
            strSql.Append(" WHERE RoleCode IN (SELECT RoleCode FROM Accounts_UserRoles WHERE UserID = @UserID)");
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID",SqlDbType.Int,50) };
            parameters[0].Value = userID;
            SqlDataReader reader = base.ExecuteSql(strSql.ToString(),parameters);
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            base.Connection.Close();
            return list;


        }
        /// <summary>
        /// 取得用户权限代码列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public ArrayList GetEffectivePermissionCodeList(int userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT p.PermissionCode FROM Accounts_RolePermissions rp");
            strSql.Append(" inner join Accounts_Permissions p on rp.PermissionCode=p.PermissionCode");
            strSql.Append(" WHERE RoleCode IN (SELECT RoleCode FROM Accounts_UserRoles WHERE UserID = @UserID)");
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;
            SqlDataReader reader = base.ExecuteSql(strSql.ToString(), parameters);
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0));
            }
            base.Connection.Close();
            return list;
        }
        
    }
}
