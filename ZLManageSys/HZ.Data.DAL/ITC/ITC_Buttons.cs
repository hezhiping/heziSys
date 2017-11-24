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
    /// 操作按扭
    /// </summary>
    public class ITC_Buttons:IITC_Buttons
    {
        public ITC_Buttons() { }

        #region IITC_Buttons 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Buttons_ID"></param>
        /// <returns></returns>
        public bool Exists(string Buttons_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Buttons");
            strSql.Append(" where ");
            strSql.Append(" Buttons_ID=@Buttons_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Buttons_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Buttons_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_Buttons_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Buttons(");
            strSql.Append("Buttons_ID,Buttons_NAME,Buttons_Remark,Buttons_Img,Buttons_Status");
            strSql.Append(") values (");
            strSql.Append("@Buttons_ID,@Buttons_NAME,@Buttons_Remark,@Buttons_Img,@Buttons_Status");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Buttons_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Buttons_NAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Buttons_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Buttons_Img", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Buttons_Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Buttons_ID;
            parameters[1].Value = model.Buttons_NAME;
            parameters[2].Value = model.Buttons_Remark;
            parameters[3].Value = model.Buttons_Img;
            parameters[4].Value = model.Buttons_Status;
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
        public bool Update(ITC_Buttons_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_Buttons set "); 
            strSql.Append(" Buttons_NAME = @Buttons_NAME , ");
            strSql.Append(" Buttons_Remark = @Buttons_Remark , ");
            strSql.Append(" Buttons_Img = @Buttons_Img , ");
            strSql.Append(" Buttons_Status = @Buttons_Status  ");
            strSql.Append(" where Buttons_ID=@Buttons_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Buttons_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Buttons_NAME", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Buttons_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Buttons_Img", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Buttons_Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Buttons_ID;
            parameters[1].Value = model.Buttons_NAME;
            parameters[2].Value = model.Buttons_Remark;
            parameters[3].Value = model.Buttons_Img;
            parameters[4].Value = model.Buttons_Status;
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
        public bool Delete(string Buttons_ID)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from ITC_Buttons ");
            //strSql.Append(" where Buttons_ID=@Buttons_ID ");
            List<string> sqllist = new List<string>();
            sqllist.Add("delete from ITC_Buttons where Buttons_ID=@Buttons_ID");
            sqllist.Add("delete from ITC_RoleOperator where Buttons_ID=@Buttons_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Buttons_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Buttons_ID;

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
        public List<ITC_Buttons_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_Buttons ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Buttons_Img asc "); //排序
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return DsToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Buttons_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_Buttons_M> list = new List<ITC_Buttons_M>();
            //排序:Buttons_Img
            string sql = DbHelperSQL.GetPagerSql("ITC_Buttons", "*", strWhere, "Buttons_Img", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {                
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }
        private List<ITC_Buttons_M> DsToList(DataSet ds)
        {
            List<ITC_Buttons_M> list = new List<ITC_Buttons_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_Buttons_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_Buttons_M();
                    model.Buttons_ID = ds.Tables[0].Rows[i]["Buttons_ID"].ToString().Trim();
                    model.Buttons_NAME = ds.Tables[0].Rows[i]["Buttons_NAME"].ToString();
                    model.Buttons_Remark = ds.Tables[0].Rows[i]["Buttons_Remark"].ToString();
                    model.Buttons_Img = ds.Tables[0].Rows[i]["Buttons_Img"].ToString();
                    if (ds.Tables[0].Rows[i]["Buttons_Status"].ToString() != "")
                    {
                        model.Buttons_Status = int.Parse(ds.Tables[0].Rows[i]["Buttons_Status"].ToString());
                    }

                    list.Add(model);
                }                
            }
            return list;
        }

        #endregion
    }
}
