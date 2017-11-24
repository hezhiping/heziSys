using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZ.Data.Interface;
using HZ.Utility;
using System.Data.SqlClient;
using System.Data;
using HZ.Data.Model;

namespace HZ.Data.DAL
{
    /// <summary>
    /// 基础数据_生产线数据字典DAL
    /// </summary>
    public class BaseInfo_Scx_D : IBaseInfo_Scx
    {

        public BaseInfo_Scx_D() { }

        /// <summary>
        /// 记录是否存在
        /// </summary>
        public bool Exists(string ScxID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZL_BaseInfo_Scx");
            strSql.Append(" where ");
            strSql.Append(" ScxID = @ScxID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ScxID", SqlDbType.Int,10)		
                                        };
            parameters[0].Value = ScxID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region IBaseInfo_Scx 成员
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model">数据模型</param>
        public bool Add(BaseInfo_Scx_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Buttons(");
            strSql.Append(" ScxCode, ScxName, Fct, WorkCast, Currency, UpName, UpTime, Del");
            strSql.Append(") values (");
            strSql.Append("@ScxCode, @ScxName, @Fct, @WorkCast, @Currency, @UpName, @UpTime, @Del");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			             
                        new SqlParameter("@ScxCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ScxName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Fct", SqlDbType.VarChar,25) ,            
                        new SqlParameter("@WorkCast", SqlDbType.Decimal),                                   
                        new SqlParameter("@Currency", SqlDbType.VarChar,50),
                        new SqlParameter("@UpName", SqlDbType.VarChar,50),
                        new SqlParameter("@UpTime", SqlDbType.DateTime),
                        new SqlParameter("@Del", SqlDbType.Int,4)              
            };

            parameters[0].Value = model.ScxCode;
            parameters[1].Value = model.ScxName;
            parameters[2].Value = model.Fct;
            parameters[3].Value = model.WorkCast;
            parameters[4].Value = model.Currency;
            parameters[5].Value = model.WorkCast;
            parameters[6].Value = model.UpName;
            parameters[7].Value = model.Del;

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
        /// 更新一条记录
        /// </summary>
        /// <param name="model">数据模型</param>
        public bool Update(BaseInfo_Scx_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZL_BaseInfo_Scx  ");
            strSql.Append("ScxCode=@ScxCode, ");
            strSql.Append("ScxName=@ScxName, ");
            strSql.Append("Fct=@Fct, ");
            strSql.Append("WorkCast=@WorkCast,   ");
            strSql.Append("Currency=@Currency, ");
            strSql.Append("UpName=@UpName,  ");
            strSql.Append("UpTime=@UpTime, ");
            strSql.Append("Del=@Del  ");
            strSql.Append(" where ScxID=@ScxID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ScxID", SqlDbType.Int,4) ,
                        new SqlParameter("@ScxCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ScxName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Fct", SqlDbType.VarChar,25) ,            
                        new SqlParameter("@WorkCast", SqlDbType.Decimal),                                   
                        new SqlParameter("@Currency", SqlDbType.VarChar,50),
                        new SqlParameter("@UpName", SqlDbType.VarChar,50),
                        new SqlParameter("@UpTime", SqlDbType.DateTime),
                        new SqlParameter("@Del", SqlDbType.Int,4)              
            };

            parameters[0].Value = model.ScxID;
            parameters[1].Value = model.ScxCode;
            parameters[2].Value = model.ScxName;
            parameters[3].Value = model.Fct;
            parameters[4].Value = model.WorkCast;
            parameters[5].Value = model.Currency;
            parameters[6].Value = model.WorkCast;
            parameters[7].Value = model.UpName;
            parameters[8].Value = model.Del;

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
        /// <param name="ScxID">工厂序号主键</param>
        public bool Delete(int ScxID)
        {
            List<string> sqllist = new List<string>();
            sqllist.Add("delete from ZL_BaseInfo_Scx where ScxID=@ScxID");
            SqlParameter[] parameters = {
					new SqlParameter("@ScxID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = ScxID;

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
        /// 获取数据列表
        /// </summary>
        public List<BaseInfo_Scx_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ZL_BaseInfo_Scx ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ScxID asc "); //排序
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            //调用DsToList 
            return DsToList(ds);

            //调用解析数据表数据转成模型对象列表方法
            //DataTable dt = ds.Tables[0];
            //List<BaseInfo_Scx_M> list = new List<BaseInfo_Scx_M>();
            //list = EntityList.ToList<BaseInfo_Scx_M>(dt);

            //return list;
        }
        /// <summary>
        /// 获取数据分页
        /// </summary>      
        public List<BaseInfo_Scx_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<BaseInfo_Scx_M> list = new List<BaseInfo_Scx_M>();
            //排序:ScxID
            string sql = DbHelperSQL.GetPagerSql("ZL_BaseInfo_Scx", "*", strWhere, "ScxID", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        #endregion
        /// <summary>
        /// dataset转成list
        /// </summary>        
        private List<BaseInfo_Scx_M> DsToList(DataSet ds)
        {
            List<BaseInfo_Scx_M> list = new List<BaseInfo_Scx_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                BaseInfo_Scx_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new BaseInfo_Scx_M();
                    model.ScxID = int.Parse(ds.Tables[0].Rows[i]["ScxID"].ToString().Trim());
                    model.ScxCode = ds.Tables[0].Rows[i]["ScxCode"].ToString();
                    model.ScxName = ds.Tables[0].Rows[i]["ScxName"].ToString();
                    model.Fct = ds.Tables[0].Rows[i]["Fct"].ToString();
                    model.WorkCast = decimal.Parse(ds.Tables[0].Rows[i]["WorkCast"].ToString().Trim());
                    model.Currency = ds.Tables[0].Rows[i]["Currency"].ToString();
                    model.UpName = ds.Tables[0].Rows[i]["UpName"].ToString();
                    model.UpTime = DateTime.Parse(ds.Tables[0].Rows[i]["UpTime"].ToString().Trim());

                    if (ds.Tables[0].Rows[i]["Del"].ToString() != "")
                    {
                        model.Del = int.Parse(ds.Tables[0].Rows[i]["Del"].ToString());
                    }

                    if (ds.Tables[0].Rows[i]["State"].ToString() != "")
                    {
                        model.State = int.Parse(ds.Tables[0].Rows[i]["State"].ToString());
                    }

                    list.Add(model);
                }
            }
            return list;
        }



    }
}
