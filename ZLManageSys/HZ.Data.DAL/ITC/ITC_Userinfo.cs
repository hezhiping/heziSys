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
    /// 用户信息
    /// </summary>
    public class ITC_Userinfo:IITC_Userinfo
    {
        public ITC_Userinfo() { }
        #region IITC_Userinfo 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="User_ID"></param>
        /// <returns></returns>
        public bool Exists(string User_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Userinfo");
            strSql.Append(" where ");
            strSql.Append(" User_ID = @User_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = User_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string User_ID,string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Userinfo");
            strSql.Append(" where ");
            strSql.Append(" User_Account = @User_Account and User_Pwd=@User_Pwd ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_Account", SqlDbType.Char,8),
                    new SqlParameter("@User_Pwd",SqlDbType.VarChar,50)};
            parameters[0].Value = User_ID;
            parameters[1].Value = pwd;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_Userinfo_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Userinfo(");
            strSql.Append("User_ID,User_Mobile,User_Createdtime,User_Status,User_Oprt,User_Remark,Orga_ID,User_Account,User_Pwd,User_Name,User_Spelling,User_Sex,User_Email,User_Tel");
            strSql.Append(") values (");
            strSql.Append("@User_ID,@User_Mobile,@User_Createdtime,@User_Status,@User_Oprt,@User_Remark,@Orga_ID,@User_Account,@User_Pwd,@User_Name,@User_Spelling,@User_Sex,@User_Email,@User_Tel");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@User_ID", SqlDbType.Char,8) ,            
                        new SqlParameter("@User_Mobile", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@User_Createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@User_Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_Oprt", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Orga_ID", SqlDbType.Char,8) ,            
                        new SqlParameter("@User_Account", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Pwd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Spelling", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Sex", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Tel", SqlDbType.VarChar,15)             
              
            };

            parameters[0].Value = model.User_ID;
            parameters[1].Value = model.User_Mobile;
            parameters[2].Value = model.User_Createdtime;
            parameters[3].Value = model.User_Status;
            parameters[4].Value = model.User_Oprt;
            parameters[5].Value = model.User_Remark;
            parameters[6].Value = model.Orga_ID;
            parameters[7].Value = model.User_Account;
            parameters[8].Value = model.User_Pwd;
            parameters[9].Value = model.User_Name;
            parameters[10].Value = model.User_Spelling;
            parameters[11].Value = model.User_Sex;
            parameters[12].Value = model.User_Email;
            parameters[13].Value = model.User_Tel;
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
        public bool Update(ITC_Userinfo_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_Userinfo set "); 
            strSql.Append(" User_Mobile = @User_Mobile , ");
            strSql.Append(" User_Createdtime = @User_Createdtime , ");
            strSql.Append(" User_Status = @User_Status , ");
            strSql.Append(" User_Oprt = @User_Oprt , ");
            strSql.Append(" User_Remark = @User_Remark , ");
            strSql.Append(" Orga_ID = @Orga_ID , ");
            strSql.Append(" User_Account = @User_Account , ");
            //strSql.Append(" User_Pwd = @User_Pwd , ");
            strSql.Append(" User_Name = @User_Name , ");
            strSql.Append(" User_Spelling = @User_Spelling , ");
            strSql.Append(" User_Sex = @User_Sex , ");
            strSql.Append(" User_Email = @User_Email , ");
            strSql.Append(" User_Tel = @User_Tel  ");
            strSql.Append(" where User_ID=@User_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@User_ID", SqlDbType.Char,8) ,            
                        new SqlParameter("@User_Mobile", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@User_Createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@User_Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_Oprt", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Orga_ID", SqlDbType.Char,8) ,            
                        new SqlParameter("@User_Account", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Pwd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Spelling", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Sex", SqlDbType.Bit,1) ,            
                        new SqlParameter("@User_Email", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@User_Tel", SqlDbType.VarChar,15)             
              
            };

            parameters[0].Value = model.User_ID;
            parameters[1].Value = model.User_Mobile;
            parameters[2].Value = model.User_Createdtime;
            parameters[3].Value = model.User_Status;
            parameters[4].Value = model.User_Oprt;
            parameters[5].Value = model.User_Remark;
            parameters[6].Value = model.Orga_ID;
            parameters[7].Value = model.User_Account;
            parameters[8].Value = model.User_Pwd;
            parameters[9].Value = model.User_Name;
            parameters[10].Value = model.User_Spelling;
            parameters[11].Value = model.User_Sex;
            parameters[12].Value = model.User_Email;
            parameters[13].Value = model.User_Tel;
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
        public bool Delete(string User_ID)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from ITC_Userinfo ");
            //strSql.Append(" where User_ID=@User_ID ");
            List<string> sqllist = new List<string>();
            sqllist.Add("delete from ITC_Userinfo where User_ID=@User_ID");
            sqllist.Add("delete from ITC_UserPosition where User_ID=@User_ID");
            sqllist.Add("delete from ITC_UserPositionRange where User_ID=@User_ID");
            sqllist.Add("delete from ITC_UserRoles where User_ID=@User_ID");
            sqllist.Add("delete from ITC_UserRoleRange where User_ID=@User_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = User_ID;

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
        public List<ITC_Userinfo_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_Userinfo ");
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
        public List<ITC_Userinfo_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_Userinfo_M> list = new List<ITC_Userinfo_M>();
            string sql = DbHelperSQL.GetPagerSql("ITC_Userinfo", "*", strWhere, "Orga_ID", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        private List<ITC_Userinfo_M> DsToList(DataSet ds)
        {
            List<ITC_Userinfo_M> list = new List<ITC_Userinfo_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_Userinfo_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_Userinfo_M();
                    model.User_ID = ds.Tables[0].Rows[i]["User_ID"].ToString().Trim();
                    model.User_Mobile = ds.Tables[0].Rows[i]["User_Mobile"].ToString();
                    if (ds.Tables[0].Rows[i]["User_Createdtime"].ToString() != "")
                    {
                        model.User_Createdtime = DateTime.Parse(ds.Tables[0].Rows[i]["User_Createdtime"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["User_Status"].ToString() != "")
                    {
                        model.User_Status = int.Parse(ds.Tables[0].Rows[i]["User_Status"].ToString());
                    }
                    model.User_Oprt = ds.Tables[0].Rows[i]["User_Oprt"].ToString();
                    model.User_Remark = ds.Tables[0].Rows[i]["User_Remark"].ToString();
                    model.Orga_ID = ds.Tables[0].Rows[i]["Orga_ID"].ToString().Trim();
                    model.User_Account = ds.Tables[0].Rows[i]["User_Account"].ToString();
                    model.User_Pwd = ds.Tables[0].Rows[i]["User_Pwd"].ToString();
                    model.User_Name = ds.Tables[0].Rows[i]["User_Name"].ToString();
                    model.User_Spelling = ds.Tables[0].Rows[i]["User_Spelling"].ToString();
                    if (ds.Tables[0].Rows[i]["User_Sex"].ToString() != "")
                    {
                        if ((ds.Tables[0].Rows[i]["User_Sex"].ToString() == "1") || (ds.Tables[0].Rows[i]["User_Sex"].ToString().ToLower() == "true"))
                        {
                            model.User_Sex = true;
                        }
                        else
                        {
                            model.User_Sex = false;
                        }
                    }
                    model.User_Email = ds.Tables[0].Rows[i]["User_Email"].ToString();
                    model.User_Tel = ds.Tables[0].Rows[i]["User_Tel"].ToString();

                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 检查用户岗位范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public bool CheckPositionRange(string userid, string posid, string orgaid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserPositionRange");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Position_ID=@Position_ID and Orga_ID=@Orga_ID and Range_Status=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)	,
                    new SqlParameter("@Position_ID", SqlDbType.Char,10)	,
                    new SqlParameter("@Orga_ID", SqlDbType.Char,8)	,
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = posid;
            parameters[2].Value = orgaid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除用户岗位(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeletePosition(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_UserPosition ");
            strSql.Append(" where User_ID=@User_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = userid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除用户岗位范围(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeletePositionRange(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_UserPositionRange ");
            strSql.Append(" where User_ID=@User_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = userid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 添加用户岗位
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <returns></returns>
        public void AddPosition(string userid, string posid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserPosition");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Position_ID=@Position_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8),
                    new SqlParameter("@Position_ID",SqlDbType.Char,10)
                                       };
            parameters[0].Value = userid;
            parameters[1].Value = posid;
            if (DbHelperSQL.Exists(strSql.ToString(), parameters))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update ITC_UserPosition set ");
                strSql2.Append(" Postion_Status = 0  ");
                strSql2.Append(" where User_ID=@User_ID and Position_ID=@Position_ID ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into ITC_UserPosition(");
                strSql2.Append("User_ID,Position_ID,Postion_Status");
                strSql2.Append(") values (");
                strSql2.Append("@User_ID,@Position_ID,0");
                strSql2.Append(") ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
        }

        /// <summary>
        /// 添加用户岗位范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public void AddPositionRange(string userid, string posid, string orgaid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserPositionRange");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Position_ID=@Position_ID and Orga_ID=@Orga_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.VarChar,8),
                    new SqlParameter("@Position_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Orga_ID", SqlDbType.VarChar,8)                                        
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = posid;
            parameters[2].Value = orgaid;
            if (DbHelperSQL.Exists(strSql.ToString(), parameters))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update ITC_UserPositionRange set ");
                strSql2.Append(" Range_Status = 0 ");
                strSql2.Append(" where User_ID=@User_ID and Position_ID=@Position_ID and Orga_ID=@Orga_ID ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into ITC_UserPositionRange(");
                strSql2.Append("User_ID,Position_ID,Orga_ID,Range_Status");
                strSql2.Append(") values (");
                strSql2.Append("@User_ID,@Position_ID,@Orga_ID,0");
                strSql2.Append(") ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
        }

        /// <summary>
        /// 检查用户角色范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public bool CheckRoleRange(string userid, string roleid, string orgaid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserRoleRange");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Role_ID=@Role_ID and Orga_ID=@Orga_ID and Range_Status=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)	,
                    new SqlParameter("@Role_ID", SqlDbType.Char,10)	,
                    new SqlParameter("@Orga_ID", SqlDbType.Char,8)	,
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = roleid;
            parameters[2].Value = orgaid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除用户角色(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeleteRoles(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_UserRoles ");
            strSql.Append(" where User_ID=@User_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = userid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除用户角色范围(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeleteRoleRange(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_UserRoleRange ");
            strSql.Append(" where User_ID=@User_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = userid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public void AddRoles(string userid, string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserRoles");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Role_ID=@Role_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8),
                    new SqlParameter("@Role_ID",SqlDbType.Char,10)
                                       };
            parameters[0].Value = userid;
            parameters[1].Value = roleid;
            if (DbHelperSQL.Exists(strSql.ToString(), parameters))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update ITC_UserRoles set ");
                strSql2.Append(" Role_Status = 0  ");
                strSql2.Append(" where User_ID=@User_ID and Role_ID=@Role_ID ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into ITC_UserRoles(");
                strSql2.Append("User_ID,Role_ID,Role_Status");
                strSql2.Append(") values (");
                strSql2.Append("@User_ID,@Role_ID,0");
                strSql2.Append(") ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
        }

        /// <summary>
        /// 添加用户角色范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public void AddRoleRange(string userid, string roleid, string orgaid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserRoleRange");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Role_ID=@Role_ID and Orga_ID=@Orga_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Role_ID", SqlDbType.VarChar,10),
                    new SqlParameter("@Orga_ID", SqlDbType.VarChar,10)                                        
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = roleid;
            parameters[2].Value = orgaid;
            if (DbHelperSQL.Exists(strSql.ToString(), parameters))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update ITC_UserRoleRange set ");
                strSql2.Append(" Range_Status = 0 ");
                strSql2.Append(" where User_ID=@User_ID and Role_ID=@Role_ID and Orga_ID=@Orga_ID ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
            else
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into ITC_UserRoleRange(");
                strSql2.Append("User_ID,Role_ID,Orga_ID,Range_Status");
                strSql2.Append(") values (");
                strSql2.Append("@User_ID,@Role_ID,@Orga_ID,0");
                strSql2.Append(") ");
                DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters);
            }
        }

        /// <summary>
        /// 获取用户组织范围
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<string> GetOrgaIDs(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Orga_ID from ITC_UserPositionRange");
            strSql.Append(" where ");
            //strSql.Append(" User_ID = @User_ID  ");
            strSql.Append(" User_ID = @User_ID and Position_ID='HQ_10' ");
            strSql.Append(" group by Orga_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8)			};
            parameters[0].Value = userid;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            List<string> os = new List<string>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    os.Add(dr["Orga_ID"].ToString().Trim());
                }
            }

            return os;
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="orgid">组织ID</param>
        /// <param name="posid">岗位ID</param>
        /// <returns></returns>
        public string GetUserID(string orgid, string posid)
        {
            string sql = string.Format("select top 1 USER_ID from ITC_UserPositionRange where Orga_ID='{0}' and Position_ID='{1}' and Range_Status=0 order by USER_ID asc", orgid, posid);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString().Trim();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="orgid">组织ID</param>
        /// <param name="posid">岗位ID</param>
        /// <returns></returns>
        public List<string> GetUserIDs(string orgid, string posid)
        {
            string sql = string.Format("select USER_ID from ITC_UserPositionRange where Orga_ID='{0}' and Position_ID='{1}' and Range_Status=0 order by USER_ID asc", orgid, posid);
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> us = new List<string>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    us.Add(dr["USER_ID"].ToString().Trim());
                }
            }
            return us;
        }

        /// <summary>
        /// 是否拥有角色
        /// </summary>
        /// <returns></returns>
        public bool HaveRole(string userid, string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_UserRoles");
            strSql.Append(" where ");
            strSql.Append(" User_ID=@User_ID and Role_ID=@Role_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@User_ID", SqlDbType.Char,8),
                    new SqlParameter("@Role_ID", SqlDbType.Char,10),
                                        };
            parameters[0].Value = userid;
            parameters[1].Value = roleid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取某角色用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<string> GetUserIDbyRole(string roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_ID from ITC_UserRoles");
            strSql.Append(" where ");
            strSql.Append(" Role_ID=@Role_ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Role_ID", SqlDbType.Char,10),
                                        };
            parameters[0].Value = roleid;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            List<string> us = new List<string>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    us.Add(dr["User_ID"].ToString().Trim());
                }
            }
            return us;
        }
        /// <summary>
        /// 获取某岗位某部门用户
        /// </summary>
        /// <returns></returns>
        public List<string> GetUserIDbyPostionOrga(string posid, string orgaid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select User_ID from ITC_UserPositionRange");
            strSql.Append(" where ");
            strSql.Append(" Position_ID=@Position_ID and Orga_ID=@Orga_ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Position_ID", SqlDbType.Char,10),
                    new SqlParameter("@Orga_ID", SqlDbType.Char,8),
                                        };
            parameters[0].Value = posid;
            parameters[1].Value = orgaid;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<string> us = new List<string>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    us.Add(dr["User_ID"].ToString().Trim());
                }
            }
            return us;
        }
      
        #endregion
    }
}
