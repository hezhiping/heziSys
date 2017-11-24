using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HZ.Data.Interface;
using HZ.Utility;
using HZ.Data.Model;

namespace HZ.Data.DAL
{
    /// <summary>
    /// 岗位信息
    /// </summary>
    public class ITC_Position:IITC_Position
    {
        public ITC_Position() { }
        #region IITC_Position 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Position_ID"></param>
        /// <returns></returns>
        public bool Exists(string Position_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Position");
            strSql.Append(" where ");
            strSql.Append(" Position_ID = @Position_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Position_ID", SqlDbType.VarChar,10)			};
            parameters[0].Value = Position_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_Position_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Position(");
            strSql.Append("Position_ID,Position_name,Position_remark,Position_status,Position_createdtime,Position_Oprt,Position_Order");
            strSql.Append(") values (");
            strSql.Append("@Position_ID,@Position_name,@Position_remark,@Position_status,@Position_createdtime,@Position_Oprt,@Position_Order");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Position_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Position_name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Position_remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Position_status", SqlDbType.Int,4) ,
                        new SqlParameter("@Position_Order", SqlDbType.Int,4) ,
                        new SqlParameter("@Position_createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Position_Oprt", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.Position_ID;
            parameters[1].Value = model.Position_name;
            parameters[2].Value = model.Position_remark;
            parameters[3].Value = model.Position_status;
            parameters[4].Value = model.Position_Order;
            parameters[5].Value = model.Position_createdtime;
            parameters[6].Value = model.Position_Oprt;
            int result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ITC_Position_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_Position set "); 
            strSql.Append(" Position_name = @Position_name , ");
            strSql.Append(" Position_remark = @Position_remark , ");
            strSql.Append(" Position_status = @Position_status , ");
            strSql.Append(" Position_Order = @Position_Order , ");
            strSql.Append(" Position_createdtime = @Position_createdtime , ");
            strSql.Append(" Position_Oprt = @Position_Oprt  ");
            strSql.Append(" where Position_ID=@Position_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Position_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Position_name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Position_remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Position_status", SqlDbType.Int,4) ,
                        new SqlParameter("@Position_Order", SqlDbType.Int,4) ,
                        new SqlParameter("@Position_createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Position_Oprt", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.Position_ID;
            parameters[1].Value = model.Position_name;
            parameters[2].Value = model.Position_remark;
            parameters[3].Value = model.Position_status;
            parameters[4].Value = model.Position_Order;
            parameters[5].Value = model.Position_createdtime;
            parameters[6].Value = model.Position_Oprt;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Position_ID)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from ITC_Position ");
            //strSql.Append(" where Position_ID=@Position_ID ");
            List<string> sqllist = new List<string>();
            sqllist.Add("delete from ITC_Position where Position_ID=@Position_ID");
            sqllist.Add("delete from ITC_UserPosition where Position_ID=@Position_ID");
            sqllist.Add("delete from ITC_UserPositionRange where Position_ID=@Position_ID");
            //待添加岗位部门范围
            SqlParameter[] parameters = {
					new SqlParameter("@Position_ID", SqlDbType.VarChar,10)			};
            parameters[0].Value = Position_ID;

            int rows = DbHelperSQL.ExecuteSqlTran(sqllist, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Position_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_Position ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<ITC_Position_M> list = new List<ITC_Position_M>();
            DataSet ds=  DbHelperSQL.Query(strSql.ToString());
            return DsToList(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Position_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_Position_M> list = new List<ITC_Position_M>();
            string sql = DbHelperSQL.GetPagerSql("ITC_Position", "*", strWhere, "Position_Order", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        private List<ITC_Position_M> DsToList(DataSet ds)
        {
            List<ITC_Position_M> list = new List<ITC_Position_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_Position_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_Position_M();
                    model.Position_ID = ds.Tables[0].Rows[i]["Position_ID"].ToString().Trim();
                    model.Position_name = ds.Tables[0].Rows[i]["Position_name"].ToString();
                    model.Position_remark = ds.Tables[0].Rows[i]["Position_remark"].ToString();
                    if (ds.Tables[0].Rows[i]["Position_status"].ToString() != "")
                    {
                        model.Position_status = int.Parse(ds.Tables[0].Rows[i]["Position_status"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Position_createdtime"].ToString() != "")
                    {
                        model.Position_createdtime = DateTime.Parse(ds.Tables[0].Rows[i]["Position_createdtime"].ToString());
                    }
                    model.Position_Oprt = ds.Tables[0].Rows[i]["Position_Oprt"].ToString();
                    if (ds.Tables[0].Rows[i]["Position_Order"].ToString() != "")
                    {
                        model.Position_Order = int.Parse(ds.Tables[0].Rows[i]["Position_Order"].ToString());
                    }

                    list.Add(model);
                }
            }
            return list;
        }

        #endregion
    }
}
