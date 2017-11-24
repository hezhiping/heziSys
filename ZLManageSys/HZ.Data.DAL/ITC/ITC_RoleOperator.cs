using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HZ.Data.Interface;
using HZ.Utility;
using HZ.Data.Model;

namespace HZ.Data.DAL
{
    /// <summary>
    /// 角色操作权限
    /// </summary>
    public class ITC_RoleOperator:IITC_RoleOperator
    {
        public ITC_RoleOperator() { }
        #region IITC_RoleOperator 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Role_ID"></param>
        /// <param name="mid"></param>
        /// <param name="bid"></param>
        /// <returns></returns>
        public bool Exists(string Role_ID,string mid,string bid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_RoleOperator");
            strSql.Append(" where ");
            strSql.Append(" Role_ID = @Role_ID  and Menu_ID=@Menu_ID and Buttons_ID=@Buttons_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Menu_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Buttons_ID", SqlDbType.VarChar,10)
                                        
                                        };
            parameters[0].Value = Role_ID;
            parameters[1].Value = mid;
            parameters[2].Value = bid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_RoleOperator_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_RoleOperator(");
            strSql.Append("Role_ID,Menu_ID,Buttons_ID,RoleOperator_createdtime,RoleOperator_Status,RoleOperator_oprt");
            strSql.Append(") values (");
            strSql.Append("@Role_ID,@Menu_ID,@Buttons_ID,@RoleOperator_createdtime,@RoleOperator_Status,@RoleOperator_oprt");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Role_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Menu_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Buttons_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@RoleOperator_createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@RoleOperator_Status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@RoleOperator_oprt", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.Role_ID;
            parameters[1].Value = model.Menu_ID;
            parameters[2].Value = model.Buttons_ID;
            parameters[3].Value = model.RoleOperator_createdtime;
            parameters[4].Value = model.RoleOperator_Status;
            parameters[5].Value = model.RoleOperator_oprt;
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
        public bool Update(ITC_RoleOperator_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_RoleOperator set "); 
            strSql.Append(" Menu_ID = @Menu_ID , ");
            strSql.Append(" Buttons_ID = @Buttons_ID , ");
            strSql.Append(" RoleOperator_createdtime = @RoleOperator_createdtime , ");
            strSql.Append(" RoleOperator_Status = @RoleOperator_Status , ");
            strSql.Append(" RoleOperator_oprt = @RoleOperator_oprt  ");
            strSql.Append(" where Role_ID=@Role_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Role_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Menu_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Buttons_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@RoleOperator_createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@RoleOperator_Status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@RoleOperator_oprt", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.Role_ID;
            parameters[1].Value = model.Menu_ID;
            parameters[2].Value = model.Buttons_ID;
            parameters[3].Value = model.RoleOperator_createdtime;
            parameters[4].Value = model.RoleOperator_Status;
            parameters[5].Value = model.RoleOperator_oprt;
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
        public bool Delete(string uid,string mid, string bid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_RoleOperator ");
            strSql.Append(" where ");
            strSql.Append(" Role_ID = @Role_ID  and Menu_ID=@Menu_ID and Buttons_ID=@Buttons_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Menu_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Buttons_ID", SqlDbType.VarChar,10)
                                        
                                        };
            parameters[0].Value = uid;
            parameters[1].Value = mid;
            parameters[2].Value = bid;

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
        /// 获得数据列表
        /// </summary>
        public List<ITC_RoleOperator_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_RoleOperator ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds= DbHelperSQL.Query(strSql.ToString());
            List<ITC_RoleOperator_M> list = new List<ITC_RoleOperator_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ITC_RoleOperator_M model = new ITC_RoleOperator_M();
                    model.Role_ID = ds.Tables[0].Rows[i]["Role_ID"].ToString();
                    model.Menu_ID = ds.Tables[0].Rows[i]["Menu_ID"].ToString();
                    model.Buttons_ID = ds.Tables[0].Rows[i]["Buttons_ID"].ToString();
                    if (ds.Tables[0].Rows[i]["RoleOperator_createdtime"].ToString() != "")
                    {
                        model.RoleOperator_createdtime = DateTime.Parse(ds.Tables[0].Rows[i]["RoleOperator_createdtime"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["RoleOperator_Status"].ToString() != "")
                    {
                        model.RoleOperator_Status = int.Parse(ds.Tables[0].Rows[i]["RoleOperator_Status"].ToString());
                    }
                    model.RoleOperator_oprt = ds.Tables[0].Rows[i]["RoleOperator_oprt"].ToString();

                    list.Add(model);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
