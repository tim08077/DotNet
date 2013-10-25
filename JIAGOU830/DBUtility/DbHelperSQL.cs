using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;

namespace DBUtility
{
    public abstract class DbHelperSQL
    {
        public static string connectionString = PubConstant.ConnectionString;
        public DbHelperSQL()
        { }
        #region 公用方法
        public static bool ColumnExists(string tableName ,string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = DbHelperSQL.GetSingles(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;


        }
        public static int GetMaxID(string fieldName,string tableName)
        {
            string strSql = "select max(" + fieldName + ")+1 from " + tableName;
            object obj = DbHelperSQL.GetSingles(strSql);
            if(obj==null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }

        }

        public static bool Exists(string strSql)
        {
            object obj = DbHelperSQL.GetSingles(strSql);
            int cmdResult;
            if(Object.Equals(obj,null)||Object.Equals(obj,System.DBNull.Value))
            {
                cmdResult = 0;
            }
            else
            {
                cmdResult = int.Parse(obj.ToString());
            }
            if(cmdResult==0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = DbHelperSQL.GetSingles(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string strSql,params SqlParameter [] cmdParams)
        {
            object obj = DbHelperSQL.GetSingles(strSql, cmdParams);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion 
        #region 执行简单的SQL语句
        /// <summary>
        /// 返回受影响的行数 Rows
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql,conn);
            try
            {
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                return rows;
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                conn.Close();
                throw ex;
            }

        }
        /// <summary>
        /// 返回受影响的行数 rows  在指定的时间   
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ExecuteSql(string strSql, int time)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql, conn);
            try
            {
                conn.Open();
                comm.CommandTimeout = time;
                int rows = comm.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                conn.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 执行多条语句，执行数据库事务 Sqltransaction,返回受影响的行数
        /// </summary>
        /// <param name="strSqlList"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<String> strSqlList)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            SqlTransaction tx = conn.BeginTransaction();
            comm.Transaction = tx;
            try
            {
                int count = 0;
                for (int i = 0; i < strSqlList.Count ;i++ )
                {
                    string strSql = strSqlList[i];
                    if(strSql.Trim().Length>1)
                    {
                        comm.CommandText = strSql;
                        count += comm.ExecuteNonQuery();
                    }
                }
                tx.Commit();
                return count;
            }
            catch
            {
                tx.Rollback();
                return 0;
            }
        }
        /// <summary>
        /// 带参数的SQL语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="content">参数</param>
        /// <returns>影响记录数</returns>
        public static int ExecuteSql(string strSql, string content)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql, conn);
            SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
            myParameter.Value = content;
            comm.Parameters.Add(myParameter);
            try
            {
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            finally
            {
                comm.Dispose();
                conn.Close();

            }
        }
        /// <summary>
        /// 带参数的SQL语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="content">参数</param>
        /// <returns>object  1条</returns>
        //public static object ExecuteSql(string strSql, string content)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    SqlCommand comm = new SqlCommand(strSql, conn);
        //    SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
        //    myParameter.Value = content;
        //    comm.Parameters.Add(myParameter);
        //    try
        //    {
        //        conn.Open();
        //        object obj = comm.ExecuteScalar();
        //        if(Object.Equals(obj,null) ||Object.Equals(obj,System.DBNull.Value))
        //        {
        //            return null;

        //        }
        //        else
        //        {
        //            return obj;
        //        }
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        comm.Dispose();
        //        conn.Close();

        //    }
        //}
        /// <summary>
        /// 带2进志SQL
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="fs">图像字节</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteSqlInsertImg(string strSql,byte[] fs)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql, conn);
            SqlParameter myParameter = new SqlParameter("@fs",SqlDbType.Image);
            myParameter.Value = fs;
            comm.Parameters.Add(myParameter);
            try
            {
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                return rows;

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                comm.Dispose();
            }
        }
        /// <summary>
        /// 执行一条SQL 
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns> object 1条  </returns>
        public static object GetSingles(string strSql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql,conn);
            try
            {
                conn.Open();
                object obj = comm.ExecuteScalar();
                if(Object.Equals(obj,null)||Object.Equals(obj,System.DBNull.Value))
                {
                    return null;
                }
                else
                {
                    return obj;
                }

            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                comm.Dispose();
            }
        }
        /// <summary>
        /// 执行一条SQL  ,带时间 
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="time">时间参数</param>
        /// <returns>object 1条</returns>
        public static object GetSingles(string strSql,int time)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql, conn);
            try
            {
                conn.Open();
                comm.CommandTimeout = time;
                object obj = comm.ExecuteScalar();
                if (Object.Equals(obj, null) || Object.Equals(obj, System.DBNull.Value))
                {
                    return null;
                }
                else
                {
                    return obj;
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                comm.Dispose();
            }
        }
        /// <summary>
        /// 执行reader 操作
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>SqlDatareader </returns>
        public static SqlDataReader ExecuteReader(string strSql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(strSql,conn);
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);//reader完成之后自动关闭conn 
                return reader;

            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 执行一条SQL 语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>DataSet </returns>
        public static DataSet Query(string strSql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
                da.Fill(ds,"ds");
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            return ds;

        }
        /// <summary>
        /// 执行一条SQL 语句 带时间
        /// </summary>  
        /// </summary>
        /// <param name="strSql">SQL</param>
        /// <param name="time">时间</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string strSql,int time)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
                da.SelectCommand.CommandTimeout = time;
                da.Fill(ds, "ds");

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            return ds;

        }
             

        #endregion 
        #region 执行带参数的SQL语句
        private static void PrepareCommand(SqlCommand comm ,SqlConnection conn ,SqlTransaction trans,string cmdText,SqlParameter [] cmdParams)
        { 
            //链接 Conn
            if(conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            //命令 Command
            comm.Connection = conn;
            comm.CommandText = cmdText;
            comm.CommandType = CommandType.Text;
            //事务 trans
            if(trans!=null)
            {
                comm.Transaction = trans;
            }
            //命令参数 cmdParams
            if(cmdParams !=null)
            {
                foreach(SqlParameter parameter in cmdParams)
                {
                    if((parameter.Direction==ParameterDirection.Input||parameter.Direction==ParameterDirection.InputOutput)&&parameter.Value==null)
                    {
                        parameter.Value = DBNull.Value;//数据库中的null
                    }
                    comm.Parameters.Add(parameter);
                }
            }
        
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int count = 0;
                        //循环
                        foreach (CommandInfo myDE in cmdList)
                        {
                            string cmdText = myDE.CommandText;
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

                            if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
                            {
                                if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                                {
                                    trans.Rollback();
                                    return 0;
                                }

                                object obj = cmd.ExecuteScalar();
                                bool isHave = false;
                                if (obj == null && obj == DBNull.Value)
                                {
                                    isHave = false;
                                }
                                isHave = Convert.ToInt32(obj) > 0;

                                if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                continue;
                            }
                            int val = cmd.ExecuteNonQuery();
                            count += val;
                            if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
                            {
                                trans.Rollback();
                                return 0;
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return count;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (CommandInfo myDE in SQLStringList)
                        {
                            string cmdText = myDE.CommandText;
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingles(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        #endregion 
        #region 存储过程操作
        private static SqlCommand BuildQueryCommand(SqlConnection conn,string storedProcName,IDataParameter [] parameters)
        {
            SqlCommand comm = new SqlCommand(storedProcName, conn);
            comm.CommandType = CommandType.StoredProcedure;
            foreach(SqlParameter parameter in parameters)
            {
                if (parameter !=null)
                {
                    if ((parameter.Direction==ParameterDirection.InputOutput|| parameter.Direction==ParameterDirection.Input)&&(parameter.Value==null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    comm.Parameters.Add(parameter);
                }
            }
            return comm;

        }
        /// <summary>
        /// 执行存储过程 ，返回SqlDataReader
        /// </summary>
        /// <param name="storeProcName">storeProcedure</param>
        /// <param name="parameters">parameters</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storeProcName,IDataParameter [] parameters )
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            conn.Open();
            SqlCommand comm = BuildQueryCommand(conn, storeProcName, parameters);
            comm.CommandType = CommandType.StoredProcedure;
            returnReader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;

        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storeProcName">storeProcName</param>
        /// <param name="parameters">parameters</param>
        /// <param name="parameters">parameters</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storeProcName, IDataParameter[] parameters,string tableName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = BuildQueryCommand(conn, storeProcName, parameters);
            da.Fill(ds,tableName);
            conn.Close();
            return ds;
        }
        public static DataSet RunProcedure(string storeProcName, IDataParameter[] parameters, string tableName,int time)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = BuildQueryCommand(conn, storeProcName, parameters);
            da.SelectCommand.CommandTimeout = time;
            da.Fill(ds, tableName);
            conn.Close();
            return ds;
        }

        //////88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 执行存储过程查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>查询结果（object）</returns>
        public static object GetProcedureSingle(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = BuildQueryCommand(connection, storedProcName, parameters))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        #endregion 
    }
}
