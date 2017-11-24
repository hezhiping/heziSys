using System;
using System.Configuration;
using HZ.Utility;

namespace HZ.Utility
{
    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }

        /// <summary>
        /// 获取连接字符串(Lijia)
        /// </summary>
        public static string LJConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["LijiaConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
        /// <summary>
        /// 获取连接字符串(SDLSYS)
        /// </summary>
        public static string ESConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ESConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
        /// <summary>
        /// 获取连接字符串(AS400)
        /// </summary>
        public static string DB2ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["DB2ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
    }
}
