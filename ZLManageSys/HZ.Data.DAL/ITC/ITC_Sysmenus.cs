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
    /// 菜单
    /// </summary>
    public class ITC_Sysmenus:IITC_Sysmenus
    {
        public ITC_Sysmenus() { }
        #region IITC_Sysmenus 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Menu_ID"></param>
        /// <returns></returns>
        public bool Exists(string Menu_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Sysmenus");
            strSql.Append(" where ");
            strSql.Append(" Menu_ID = @Menu_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Menu_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Menu_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_Sysmenus_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Sysmenus(");
            strSql.Append("Menu_ID,Menu_Oprt,Menu_Status,Menu_Name,Menu_Remark,Menu_Ico,Menu_Type,Menu_Order,Menu_Url,Menu_ParentID,Menu_createdtime");
            strSql.Append(") values (");
            strSql.Append("@Menu_ID,@Menu_Oprt,@Menu_Status,@Menu_Name,@Menu_Remark,@Menu_Ico,@Menu_Type,@Menu_Order,@Menu_Url,@Menu_ParentID,@Menu_createdtime");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Menu_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Menu_Oprt", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Menu_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Menu_Ico", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Type", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@Menu_Url", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Menu_ParentID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Menu_createdtime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Menu_ID;
            parameters[1].Value = model.Menu_Oprt;
            parameters[2].Value = model.Menu_Status;
            parameters[3].Value = model.Menu_Name;
            parameters[4].Value = model.Menu_Remark;
            parameters[5].Value = model.Menu_Ico;
            parameters[6].Value = model.Menu_Type;
            parameters[7].Value = model.Menu_Order;
            parameters[8].Value = model.Menu_Url;
            parameters[9].Value = model.Menu_ParentID;
            parameters[10].Value = model.Menu_createdtime;
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
        public bool Update(ITC_Sysmenus_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_Sysmenus set "); 
            strSql.Append(" Menu_Oprt = @Menu_Oprt , ");
            strSql.Append(" Menu_Status = @Menu_Status , ");
            strSql.Append(" Menu_Name = @Menu_Name , ");
            strSql.Append(" Menu_Remark = @Menu_Remark , ");
            strSql.Append(" Menu_Ico = @Menu_Ico , ");
            strSql.Append(" Menu_Type = @Menu_Type , ");
            strSql.Append(" Menu_Order = @Menu_Order , ");
            strSql.Append(" Menu_Url = @Menu_Url , ");
            strSql.Append(" Menu_ParentID = @Menu_ParentID , ");
            strSql.Append(" Menu_createdtime = @Menu_createdtime  ");
            strSql.Append(" where Menu_ID=@Menu_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Menu_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Menu_Oprt", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Menu_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Menu_Ico", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Type", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Menu_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@Menu_Url", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Menu_ParentID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Menu_createdtime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Menu_ID;
            parameters[1].Value = model.Menu_Oprt;
            parameters[2].Value = model.Menu_Status;
            parameters[3].Value = model.Menu_Name;
            parameters[4].Value = model.Menu_Remark;
            parameters[5].Value = model.Menu_Ico;
            parameters[6].Value = model.Menu_Type;
            parameters[7].Value = model.Menu_Order;
            parameters[8].Value = model.Menu_Url;
            parameters[9].Value = model.Menu_ParentID;
            parameters[10].Value = model.Menu_createdtime;
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
        public bool Delete(string Menu_ID)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from ITC_Sysmenus ");
            //strSql.Append(" where Menu_ID=@Menu_ID ");
            List<string> sqlList = new List<string>();
            sqlList.Add("DELETE ITC_Sysmenus WHERE Menu_ID=@Menu_ID");
            sqlList.Add("DELETE ITC_RoleRights WHERE Menu_ID=@Menu_ID");
            sqlList.Add("DELETE ITC_RoleOperator WHERE Menu_ID=@Menu_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Menu_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Menu_ID;

            int rows = DbHelperSQL.ExecuteSqlTran(sqlList, parameters);
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
        public List<ITC_Sysmenus_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_Sysmenus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  Menu_Order asc");
            DataSet ds= DbHelperSQL.Query(strSql.ToString());
            return DsToList(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Sysmenus_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_Sysmenus_M> list = new List<ITC_Sysmenus_M>();
            string sql = DbHelperSQL.GetPagerSql("ITC_Sysmenus", "*", strWhere, "Menu_Order", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        //将ds中的数据转换成list返回
        private List<ITC_Sysmenus_M> DsToList(DataSet ds)
        {
            List<ITC_Sysmenus_M> list = new List<ITC_Sysmenus_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_Sysmenus_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_Sysmenus_M();
                    model.Menu_ID = ds.Tables[0].Rows[i]["Menu_ID"].ToString().Trim();
                    model.Menu_Oprt = ds.Tables[0].Rows[i]["Menu_Oprt"].ToString();
                    if (ds.Tables[0].Rows[i]["Menu_Status"].ToString() != "")
                    {
                        model.Menu_Status = int.Parse(ds.Tables[0].Rows[i]["Menu_Status"].ToString());
                    }
                    model.Menu_Name = ds.Tables[0].Rows[i]["Menu_Name"].ToString();
                    model.Menu_Remark = ds.Tables[0].Rows[i]["Menu_Remark"].ToString();
                    model.Menu_Ico = ds.Tables[0].Rows[i]["Menu_Ico"].ToString();
                    model.Menu_Type = ds.Tables[0].Rows[i]["Menu_Type"].ToString();
                    if (ds.Tables[0].Rows[i]["Menu_Order"].ToString() != "")
                    {
                        model.Menu_Order = int.Parse(ds.Tables[0].Rows[i]["Menu_Order"].ToString());
                    }
                    model.Menu_Url = ds.Tables[0].Rows[i]["Menu_Url"].ToString();
                    model.Menu_ParentID = ds.Tables[0].Rows[i]["Menu_ParentID"].ToString().Trim();
                    if (ds.Tables[0].Rows[i]["Menu_createdtime"].ToString() != "")
                    {
                        model.Menu_createdtime = DateTime.Parse(ds.Tables[0].Rows[i]["Menu_createdtime"].ToString());
                    }

                    list.Add(model);
                }
            }
            return list;
        }

        
        #endregion
    }
}
