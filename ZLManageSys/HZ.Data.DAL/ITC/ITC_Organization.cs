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
    /// 组织架构
    /// </summary>
    public class ITC_Organization:IITC_Organization
    {
        public ITC_Organization() { }

        #region IITC_Organization 成员
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Orga_ID"></param>
        /// <returns></returns>
        public bool Exists(string Orga_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ITC_Organization");
            strSql.Append(" where ");
            strSql.Append(" Orga_ID = @Orga_ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Orga_ID", SqlDbType.Char,8)			};
            parameters[0].Value = Orga_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_Organization_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_Organization(");
            strSql.Append("Orga_ID,Organization_Order,Organization_createdtime,Organization_Oprt,Organization_Remark,Organization_Name,Organization_Ceo,Organization_Tel,Organization_Mobil,Organization_Fax,Organization_Zip,Organization_address,Organization_ParentID,Organization_Status,Organization_DeptCode,Organization_FullName");
            strSql.Append(") values (");
            strSql.Append("@Orga_ID,@Organization_Order,@Organization_createdtime,@Organization_Oprt,@Organization_Remark,@Organization_Name,@Organization_Ceo,@Organization_Tel,@Organization_Mobil,@Organization_Fax,@Organization_Zip,@Organization_address,@Organization_ParentID,@Organization_Status,@Organization_DeptCode,@Organization_FullName");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Orga_ID", SqlDbType.Char,8) ,            
                        new SqlParameter("@Organization_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@Organization_createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Organization_Oprt", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Organization_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Organization_Name", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Organization_Ceo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Organization_Tel", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_Mobil", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_Fax", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_Zip", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_address", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Organization_ParentID", SqlDbType.Char,8),
                        new SqlParameter("@Organization_Status",SqlDbType.Int),
                        new SqlParameter("@Organization_DeptCode",SqlDbType.VarChar,50),
                        new SqlParameter("@Organization_FullName",SqlDbType.VarChar,500)
              
            };

            parameters[0].Value = model.Orga_ID;
            parameters[1].Value = model.Organization_Order;
            parameters[2].Value = model.Organization_createdtime;
            parameters[3].Value = model.Organization_Oprt;
            parameters[4].Value = model.Organization_Remark;
            parameters[5].Value = model.Organization_Name;
            parameters[6].Value = model.Organization_Ceo;
            parameters[7].Value = model.Organization_Tel;
            parameters[8].Value = model.Organization_Mobil;
            parameters[9].Value = model.Organization_Fax;
            parameters[10].Value = model.Organization_Zip;
            parameters[11].Value = model.Organization_address;
            parameters[12].Value = model.Organization_ParentID;
            parameters[13].Value = model.Organization_Status;
            parameters[14].Value = model.Organization_DeptCode;
            parameters[15].Value = model.Organization_FullName;
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
        public bool Update(ITC_Organization_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_Organization set "); 
            strSql.Append(" Organization_Order = @Organization_Order , ");
            strSql.Append(" Organization_createdtime = @Organization_createdtime , ");
            strSql.Append(" Organization_Oprt = @Organization_Oprt , ");
            strSql.Append(" Organization_Remark = @Organization_Remark , ");
            strSql.Append(" Organization_Name = @Organization_Name , ");
            strSql.Append(" Organization_Ceo = @Organization_Ceo , ");
            strSql.Append(" Organization_Tel = @Organization_Tel , ");
            strSql.Append(" Organization_Mobil = @Organization_Mobil , ");
            strSql.Append(" Organization_Fax = @Organization_Fax , ");
            strSql.Append(" Organization_Zip = @Organization_Zip , ");
            strSql.Append(" Organization_address = @Organization_address , ");
            strSql.Append(" Organization_ParentID = @Organization_ParentID,");
            strSql.Append(" Organization_Status = @Organization_Status,");
            strSql.Append(" Organization_DeptCode = @Organization_DeptCode,");
            strSql.Append(" Organization_FullName = @Organization_FullName");
            strSql.Append(" where Orga_ID=@Orga_ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Orga_ID", SqlDbType.Char,8) ,            
                        new SqlParameter("@Organization_Order", SqlDbType.Int,4) ,            
                        new SqlParameter("@Organization_createdtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Organization_Oprt", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Organization_Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Organization_Name", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Organization_Ceo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Organization_Tel", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_Mobil", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_Fax", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_Zip", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Organization_address", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Organization_ParentID", SqlDbType.Char,8),
                        new SqlParameter("@Organization_Status",SqlDbType.Int),
                        new SqlParameter("@Organization_DeptCode",SqlDbType.VarChar,50),
                        new SqlParameter("@Organization_FullName",SqlDbType.VarChar,500)
             
              
            };

            parameters[0].Value = model.Orga_ID;
            parameters[1].Value = model.Organization_Order;
            parameters[2].Value = model.Organization_createdtime;
            parameters[3].Value = model.Organization_Oprt;
            parameters[4].Value = model.Organization_Remark;
            parameters[5].Value = model.Organization_Name;
            parameters[6].Value = model.Organization_Ceo;
            parameters[7].Value = model.Organization_Tel;
            parameters[8].Value = model.Organization_Mobil;
            parameters[9].Value = model.Organization_Fax;
            parameters[10].Value = model.Organization_Zip;
            parameters[11].Value = model.Organization_address;
            parameters[12].Value = model.Organization_ParentID;
            parameters[13].Value = model.Organization_Status;
            parameters[14].Value = model.Organization_DeptCode;
            parameters[15].Value = model.Organization_FullName;
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
        public bool Delete(string Orga_ID)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from ITC_Organization ");
            //strSql.Append(" where Orga_ID=@Orga_ID ");
            List<string> sqllist = new List<string>();
            sqllist.Add("delete from ITC_Organization where Orga_ID=@Orga_ID");
            sqllist.Add("delete from ITC_Userinfo where Orga_ID=@Orga_ID");
            sqllist.Add("delete from ITC_UserPositionRange where Orga_ID=@Orga_ID");
            sqllist.Add("delete from ITC_UserRoleRange where Orga_ID=@Orga_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Orga_ID", SqlDbType.Char,8)			};
            parameters[0].Value = Orga_ID;

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
        public List<Model.ITC_Organization_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ITC_Organization ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<ITC_Organization_M> list = new List<ITC_Organization_M>();
            DataSet ds= DbHelperSQL.Query(strSql.ToString());
            return DsToList(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Organization_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_Organization_M> list = new List<ITC_Organization_M>();
            string sql = DbHelperSQL.GetPagerSql("ITC_Organization", "*", strWhere, "Orga_ID", "asc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        private List<ITC_Organization_M> DsToList(DataSet ds)
        {
            List<ITC_Organization_M> list = new List<ITC_Organization_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_Organization_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_Organization_M();
                    model.Orga_ID = ds.Tables[0].Rows[i]["Orga_ID"].ToString().Trim();
                    if (ds.Tables[0].Rows[i]["Organization_Order"].ToString() != "")
                    {
                        model.Organization_Order = int.Parse(ds.Tables[0].Rows[i]["Organization_Order"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Organization_createdtime"].ToString() != "")
                    {
                        model.Organization_createdtime = DateTime.Parse(ds.Tables[0].Rows[i]["Organization_createdtime"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Organization_Status"].ToString() != "")
                    {
                        model.Organization_Status = int.Parse(ds.Tables[0].Rows[i]["Organization_Status"].ToString());
                    }
                    model.Organization_Oprt = ds.Tables[0].Rows[i]["Organization_Oprt"].ToString();
                    model.Organization_Remark = ds.Tables[0].Rows[i]["Organization_Remark"].ToString();
                    model.Organization_Name = ds.Tables[0].Rows[i]["Organization_Name"].ToString();
                    model.Organization_Ceo = ds.Tables[0].Rows[i]["Organization_Ceo"].ToString();
                    model.Organization_Tel = ds.Tables[0].Rows[i]["Organization_Tel"].ToString();
                    model.Organization_Mobil = ds.Tables[0].Rows[i]["Organization_Mobil"].ToString();
                    model.Organization_Fax = ds.Tables[0].Rows[i]["Organization_Fax"].ToString();
                    model.Organization_Zip = ds.Tables[0].Rows[i]["Organization_Zip"].ToString();
                    model.Organization_address = ds.Tables[0].Rows[i]["Organization_address"].ToString();
                    model.Organization_ParentID = ds.Tables[0].Rows[i]["Organization_ParentID"].ToString().Trim();
                    model.Organization_DeptCode = ds.Tables[0].Rows[i]["Organization_DeptCode"].ToString().Trim();
                    model.Organization_FullName = ds.Tables[0].Rows[i]["Organization_FullName"].ToString();
                    if (model.Orga_ID == "")
                    {
                        model.Orga_ID = " ";
                    }

                    list.Add(model);
                }
            }
            return list;
        }


        #endregion
    }
}
