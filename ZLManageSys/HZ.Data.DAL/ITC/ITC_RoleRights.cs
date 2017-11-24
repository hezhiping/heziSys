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
    /// 角色菜单
    /// </summary>
    public class ITC_RoleRights : IITC_RoleRights
    {
        public ITC_RoleRights() { }
        #region IITC_RoleRights 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Role_ID"></param>
        /// <param name="Menu_ID"></param>
        /// <returns></returns>
        public bool Exists(string Role_ID, string Menu_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_RoleRights");
            strSql.Append(" where ");
            strSql.Append(" Role_ID = @Role_ID and Menu_ID=@Menu_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10),
                    new SqlParameter("@Menu_ID",SqlDbType.Char,10)
                                       };
            parameters[0].Value = Role_ID;
            parameters[1].Value = Menu_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_RoleRights_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_RoleRights(");
            strSql.Append("Role_ID,Menu_ID,Roleright_Status");
            strSql.Append(") values (");
            strSql.Append("@Role_ID,@Menu_ID,@Roleright_Status");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Role_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Menu_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Roleright_Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Role_ID;
            parameters[1].Value = model.Menu_ID;
            parameters[2].Value = model.Roleright_Status;
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
        public bool Update(ITC_RoleRights_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_RoleRights set ");
            strSql.Append(" Roleright_Status = @Roleright_Status  ");
            strSql.Append(" where Role_ID=@Role_ID and Menu_ID=@Menu_ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Role_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Menu_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Roleright_Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Role_ID;
            parameters[1].Value = model.Menu_ID;
            parameters[2].Value = model.Roleright_Status;
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
        public bool Delete(string Role_ID, string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_RoleRights ");
            strSql.Append(" where Role_ID=@Role_ID  and Menu_ID=@Menu_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10),
                                       new SqlParameter("@Menu_ID",SqlDbType.Char,10)
                                       };
            parameters[0].Value = Role_ID;
            parameters[1].Value = mid;

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
        /// 得到一个对象实体
        /// </summary>
        public ITC_RoleRights_M GetModel(string Role_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Role_ID, Menu_ID, Roleright_Status  ");
            strSql.Append("  from ITC_RoleRights ");
            strSql.Append(" where Role_ID=@Role_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Role_ID;

            //List<ITC_RoleRights_M> list = new List<ITC_RoleRights_M>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                ITC_RoleRights_M model = new ITC_RoleRights_M();
                model.Role_ID = ds.Tables[0].Rows[0]["Role_ID"].ToString();
                model.Menu_ID = ds.Tables[0].Rows[0]["Menu_ID"].ToString();
                if (ds.Tables[0].Rows[0]["Roleright_Status"].ToString() != "")
                {
                    model.Roleright_Status = int.Parse(ds.Tables[0].Rows[0]["Roleright_Status"].ToString());
                }
                return model;
                //list.Add(model);
                //}
                //return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_RoleRights_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_RoleRights ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ITC_RoleRights_M> list = new List<ITC_RoleRights_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ITC_RoleRights_M model = new ITC_RoleRights_M();
                    model.Role_ID = ds.Tables[0].Rows[i]["Role_ID"].ToString();
                    model.Menu_ID = ds.Tables[0].Rows[i]["Menu_ID"].ToString();
                    if (ds.Tables[0].Rows[i]["Roleright_Status"].ToString() != "")
                    {
                        model.Roleright_Status = int.Parse(ds.Tables[0].Rows[i]["Roleright_Status"].ToString());
                    }
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
