using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace HZ.Utility
{
    /// <summary>
    /// AS400数据访问抽象基础类
    /// </summary>
    public abstract class DbHelperDB2
    {
        //数据库连接字符串(web.config来配置)，多数据库可使用DbHelperSQLP来实现.
        public static string connectionString = PubConstant.DB2ConnectionString;
        public DbHelperDB2()
        {
        }
        /// <summary>
        /// 获取某表的记录，返回DataSet
        /// </summary>
        /// <param name="libName">库名</param>
        /// <param name="tblName">表名</param>
        /// <param name="strGetFields">读取字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static DataSet Query(string libName, string tblName, string strGetFields, string strWhere)
        {
            if (libName != null && libName != "" && tblName != null && tblName != "")
            {
                string getfield = "*";
                if (strGetFields != null && strGetFields != "")
                {
                    getfield = strGetFields;
                }
                string sql = string.Format("select {0} from {1}.{2}", getfield, libName, tblName);
                if (strWhere != null && strWhere != "")
                {
                    sql = sql + " where " + strWhere;
                }
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        OleDbDataAdapter command = new OleDbDataAdapter(sql, connection);
                        command.Fill(ds, tblName);
                        return ds;
                    }
                    catch
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询，返回DataSet
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public static DataSet Query(string strSql)
        {
            if (strSql != null && strSql != "")
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        OleDbDataAdapter command = new OleDbDataAdapter(strSql, connection);
                        command.Fill(ds, "ds1");
                        return ds;
                    }
                    catch
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数(不允许删除)
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch
                    {
                        connection.Close();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数(不允许删除)
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数数组</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, CommandType.Text, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch
                    {
                        connection.Close();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">OleDbCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">OleDbCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
