using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

namespace DAL.Accounts
{
    public class Accounts_Users
    {
        public Accounts_Users()
        {}
        
        #region 成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where UserID= @UserID");
            SqlParameter[] parameters = { new SqlParameter("@UserID",SqlDbType.Int,4) };
            parameters[0].Value = UserID;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where UserName= @UserName");
            SqlParameter[] parameters = { new SqlParameter("@UserName",SqlDbType.VarChar,50) };
            parameters[0].Value = UserName;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }


        public int Add(Model.Accounts.Accounts_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Users(");
            strSql.Append("UserName,Password,TrueName,Sex,Phone,Email,DepartmentID,Duty,Activity)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@TrueName,@Sex,@Phone,@Email,@DepartmentID,@Duty,@Activity)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,2),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,5),
					new SqlParameter("@Duty", SqlDbType.VarChar,20),
					new SqlParameter("@Activity", SqlDbType.Bit,1)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.DepartmentID;
            parameters[7].Value = model.Duty;
            parameters[8].Value = model.Activity;

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

        public void Update(Model.Accounts.Accounts_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Users set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("DepartmentID=@DepartmentID,");
            strSql.Append("Duty=@Duty,");
            strSql.Append("Activity=@Activity");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,2),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,5),
					new SqlParameter("@Duty", SqlDbType.VarChar,20),
					new SqlParameter("@Activity", SqlDbType.Bit,1)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.TrueName;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.DepartmentID;
            parameters[8].Value = model.Duty;
            parameters[9].Value = model.Activity;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        public void Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_Users ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
				};
            parameters[0].Value = UserID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// GetModel
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public Model.Accounts.Accounts_Users GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,Password,TrueName,Sex,Phone,Email,DepartmentID,Duty,Activity from Accounts_Users ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value=UserID;

            Model.Accounts.Accounts_Users model = new Model.Accounts.Accounts_Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count >0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                model.Duty = ds.Tables[0].Rows[0]["Duty"].ToString();
                if (ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public Model.Accounts.Accounts_Users GetModel(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = UserName;
            Model.Accounts.Accounts_Users model = new Model.Accounts.Accounts_Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                model.Duty = ds.Tables[0].Rows[0]["Duty"].ToString();
                if (ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
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
            strSql.Append("select [UserID],[UserName],[Password],[TrueName],[Sex],[Phone],[Email],[DepartmentID],[Activity],[UserType],[Duty] ");
            strSql.Append(" FROM Accounts_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            parameters[0].Value = "Accounts_Users";
            //2007.11.22 这里修改为按UserName排序
            parameters[1].Value = "UserName";
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
            strSql.Append(" FROM Accounts_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingles(strSql.ToString()));
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Accounts_Users");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }



        #endregion 

    }
}
