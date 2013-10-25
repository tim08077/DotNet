using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Accounts
{
    public abstract class DbObject
    {
        protected SqlConnection Connection;
        public static string connectionString = PubConstant.ConnectionString;

        public DbObject(string newConnectionString)
        {
            connectionString = newConnectionString;
            this.Connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// 建立SQL存储过程命令
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns>command</returns>
        private SqlCommand BuildQueryCommand(string storedProcName,IDataParameter [] parameters)
        {
            SqlCommand comm = new SqlCommand(storedProcName,this.Connection);
            comm.CommandType = CommandType.StoredProcedure;
            foreach(SqlParameter parameter in parameters)
            {
                comm.Parameters.Add(parameter);
            }
            return comm;

        }
        /// <summary>
        /// 建立SQL文本命令
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private SqlCommand BuildQuerySqlCommand(string sqlString,IDataParameter [] parameters)
        {
            SqlCommand comm = new SqlCommand(sqlString,this.Connection);
            comm.CommandType = CommandType.Text;
            foreach(SqlParameter parameter in parameters)
            {
                comm.Parameters.Add(parameter);
            }
            return comm;
        }

        private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = this.BuildQueryCommand(storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 建立一个返回int类型参数的Sql文本命令
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private SqlCommand BuildIntSqlCommand(string SqlString, IDataParameter[] parameters)
        {
            SqlCommand command = this.BuildQuerySqlCommand(SqlString, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        /// <summary>
        /// 执行一个sql，返回一个DataReader
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected SqlDataReader ExecuteSql(string sqlString ,IDataParameter [] parameters)
        {
            this.Connection.Open();
            SqlCommand comm =this.BuildQuerySqlCommand(sqlString,parameters);
            SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        /// 执行存储过程 返回int类型 受影响的行数
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="rowsAffected"></param>
        /// <returns></returns>
        protected int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            this.Connection.Open();
            SqlCommand command = this.BuildIntSqlCommand(storedProcName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            int num = (int)command.Parameters["ReturnValue"].Value;
            this.Connection.Close();
            return num;
        }
        /// <summary>
        /// 执行存储过程 ，返回DataSet 
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildQueryCommand(storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
            return dataSet;
        }
        /// <summary>
        /// 执行存储过程， 空返回
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName)
        {
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildIntCommand(storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
        }

        /// <summary>
        /// 执行Sql文本命令 返回int类型 受影响的行数
        /// </summary>
        /// <param name="SqlString">Sql文本</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        /// 
        protected int ExecuteSqlInt(string SqlString, IDataParameter[] parameters)
        {
            this.Connection.Open();
            SqlCommand command = this.BuildQuerySqlCommand(SqlString, parameters);
            int rowsAffected = command.ExecuteNonQuery();
            this.Connection.Close();
            return rowsAffected;
        }

        /// <summary>
        /// 执行Sql文本命令
        /// </summary>
        /// <param name="SqlString">查询字符串</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">返回的DataSet的表名</param>
        /// <returns></returns>
        protected DataSet ExecuteSql(string SqlString, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildQuerySqlCommand(SqlString, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
            return dataSet;
        }



        protected string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

    }
}
