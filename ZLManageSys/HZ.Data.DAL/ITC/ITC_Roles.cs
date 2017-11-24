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
    /// 角色
    /// </summary>
    public class ITC_Roles:IITC_Roles
    {
        public ITC_Roles() { }
        #region IITC_Roles 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Role_ID"></param>
        /// <returns></returns>
        public bool Exists(string Role_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Roles");
            strSql.Append(" where ");
            strSql.Append(" Role_ID = @Role_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Role_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_Roles_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Roles(");
            strSql.Append("Role_ID,Role_Name,Role_Remark,Role_Status,Role_createdtime,Role_oprt");
            strSql.Append(") values (");
            strSql.Append("@Role_ID,@Role_Name,@Role_Remark,@Role_Status,@Role_createdtime,@Role_oprt");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Role_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Role_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Role_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Role_Status", SqlDbType.Int,4),
                        new SqlParameter("@Role_createdtime", SqlDbType.DateTime) ,                   
                        new SqlParameter("@Role_oprt", SqlDbType.VarChar,10)
              
            };

            parameters[0].Value = model.Role_ID;
            parameters[1].Value = model.Role_Name;
            parameters[2].Value = model.Role_Remark;
            parameters[3].Value = model.Role_Status;
            parameters[4].Value = model.Role_createdtime;
            parameters[5].Value = model.Role_oprt;
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
        public bool Update(ITC_Roles_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_Roles set "); 
            strSql.Append(" Role_Name = @Role_Name , ");
            strSql.Append(" Role_Remark = @Role_Remark , ");
            strSql.Append(" Role_Status = @Role_Status , ");
            strSql.Append(" Role_createdtime = @Role_createdtime , ");
            strSql.Append(" Role_oprt = @Role_oprt  ");
            strSql.Append(" where Role_ID=@Role_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Role_ID", SqlDbType.Char,10) ,            
                        new SqlParameter("@Role_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Role_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Role_Status", SqlDbType.Int,4),
                        new SqlParameter("@Role_createdtime", SqlDbType.DateTime) ,                   
                        new SqlParameter("@Role_oprt", SqlDbType.VarChar,10)
              
            };

            parameters[0].Value = model.Role_ID;
            parameters[1].Value = model.Role_Name;
            parameters[2].Value = model.Role_Remark;
            parameters[3].Value = model.Role_Status;
            parameters[4].Value = model.Role_createdtime;
            parameters[5].Value = model.Role_oprt;
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
        public bool Delete(string Role_ID)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from ITC_Roles ");
            //strSql.Append(" where Role_ID=@Role_ID ");
            List<string> sqllist = new List<string>();
            sqllist.Add("delete from ITC_Roles where Role_ID=@Role_ID");
            sqllist.Add("delete from ITC_RoleRights where Role_ID=@Role_ID");
            sqllist.Add("delete from ITC_RoleOperator where Role_ID=@Role_ID");
            sqllist.Add("delete from ITC_UserRoles where Role_ID=@Role_ID");
            sqllist.Add("delete from ITC_UserRoleRange where Role_ID=@Role_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10)			};
            parameters[0].Value = Role_ID;

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
        public List<ITC_Roles_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds= DbHelperSQL.Query(strSql.ToString());
            return DsToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Roles_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_Roles_M> list = new List<ITC_Roles_M>();
            string sql = DbHelperSQL.GetPagerSql("ITC_Roles", "*", strWhere, "Role_Name", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        private List<ITC_Roles_M> DsToList(DataSet ds)
        {
            List<ITC_Roles_M> list = new List<ITC_Roles_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_Roles_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_Roles_M();
                    model.Role_ID = ds.Tables[0].Rows[i]["Role_ID"].ToString().Trim();
                    model.Role_Name = ds.Tables[0].Rows[i]["Role_Name"].ToString();
                    model.Role_Remark = ds.Tables[0].Rows[i]["Role_Remark"].ToString();
                    if (ds.Tables[0].Rows[i]["Role_Status"].ToString() != "")
                    {
                        model.Role_Status = int.Parse(ds.Tables[0].Rows[i]["Role_Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["Role_createdtime"].ToString() != "")
                    {
                        model.Role_createdtime = DateTime.Parse(ds.Tables[0].Rows[i]["Role_createdtime"].ToString());
                    }
                    model.Role_oprt = ds.Tables[0].Rows[i]["Role_oprt"].ToString();

                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 检查角色操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        public bool CheckRoleOperator(string roleid, string menuid, string buttonid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_RoleOperator");
            strSql.Append(" where ");
            strSql.Append(" Role_ID=@Role_ID and Menu_ID=@Menu_ID and Buttons_ID=@Buttons_ID and RoleOperator_Status=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10)	,
                    new SqlParameter("@Menu_ID", SqlDbType.Char,10)	,
                    new SqlParameter("@Buttons_ID", SqlDbType.Char,10)	,
                                        };
            parameters[0].Value = roleid;
            parameters[1].Value = menuid;
            parameters[2].Value = buttonid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除角色菜单权限(所有)
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public void DeleteRoleRights(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_RoleRights ");
            strSql.Append(" where Role_ID=@Role_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10)			};
            parameters[0].Value = roleid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除角色菜单操作权限(所有)
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public void DeleteRoleOperator(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_RoleOperator ");
            strSql.Append(" where Role_ID=@Role_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10)			};
            parameters[0].Value = roleid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 给角色添加菜单权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public void AddRoleRights(string roleid, string menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_RoleRights");
            strSql.Append(" where ");
            strSql.Append(" Role_ID=@Role_ID and Menu_ID=@Menu_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Char,10),
                    new SqlParameter("@Menu_ID",SqlDbType.Char,10)
                                       };
            parameters[0].Value = roleid;
            parameters[1].Value = menuid;
            if (DbHelperSQL.Exists(strSql.ToString(), parameters))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update ITC_RoleRights set ");
                strSql2.Append(" Roleright_Status = 0  ");
                strSql2.Append(" where Role_ID=@Role_ID and Menu_ID=@Menu_ID ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into ITC_RoleRights(");
                strSql2.Append("Role_ID,Menu_ID,Roleright_Status");
                strSql2.Append(") values (");
                strSql2.Append("@Role_ID,@Menu_ID,0");
                strSql2.Append(") ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
        }
        /// <summary>
        /// 给角色添加菜单操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        public void AddRoleOperator(string roleid, string menuid, string buttonid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_RoleOperator");
            strSql.Append(" where ");
            strSql.Append(" Role_ID=@Role_ID and Menu_ID=@Menu_ID and Buttons_ID=@Buttons_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Menu_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Buttons_ID", SqlDbType.VarChar,10)                                        
                                        };
            parameters[0].Value = roleid;
            parameters[1].Value = menuid;
            parameters[2].Value = buttonid;
            if (DbHelperSQL.Exists(strSql.ToString(), parameters))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update ITC_RoleOperator set ");
                strSql2.Append(" RoleOperator_Status = 0 ");
                strSql2.Append(" where Role_ID=@Role_ID and Menu_ID=@Menu_ID and Buttons_ID=@Buttons_ID ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into ITC_RoleOperator(");
                strSql2.Append("Role_ID,Menu_ID,Buttons_ID,RoleOperator_Status");
                strSql2.Append(") values (");
                strSql2.Append("@Role_ID,@Menu_ID,@Buttons_ID,0");
                strSql2.Append(") ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
        }

        /// <summary>
        /// 获取多角色的操作权限(汇总)
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<ITC_RoleOperator_M> GetRoleOperater(List<ITC_Roles_M> roles)
        {
            List<ITC_RoleOperator_M> list_power = new List<ITC_RoleOperator_M>();
            if (roles != null && roles.Count > 0)
            {
                string where_rol = "Role_ID in (";
                foreach (ITC_Roles_M r in roles)
                {
                    where_rol += "'" + r.Role_ID + "',";
                }
                where_rol = where_rol.TrimEnd(',');
                where_rol += ") and RoleOperator_Status=0";

                string sql = string.Format("select Menu_ID,Buttons_ID from ITC_RoleOperator where {0} and RoleOperator_Status=0 group by Menu_ID,Buttons_ID", where_rol);
                DataSet ds = DbHelperSQL.Query(sql);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ITC_RoleOperator_M model = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        model = new ITC_RoleOperator_M();
                        model.Menu_ID = ds.Tables[0].Rows[i]["Menu_ID"].ToString().Trim();
                        model.Buttons_ID = ds.Tables[0].Rows[i]["Buttons_ID"].ToString().Trim();
                        
                        list_power.Add(model);
                    }
                }
            }
            return list_power;
        }

        #endregion
    }
}
