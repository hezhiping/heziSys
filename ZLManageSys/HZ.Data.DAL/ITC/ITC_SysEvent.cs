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
    /// 系统日志
    /// </summary>
    public class ITC_SysEvent:IITC_SysEvent
    {
        public ITC_SysEvent() { }

        #region IITC_SysEvent 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ITC_SysEvent_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ITC_SysEvent(");
            strSql.Append("User_ID,E_IP,E_Form,E_Appname,E_Record,E_Datetime");
            strSql.Append(") values (");
            strSql.Append("@User_ID,@E_IP,@E_Form,@E_Appname,@E_Record,@E_Datetime");
            strSql.Append(") ");

            SqlParameter[] parameters = {           
                        new SqlParameter("@User_ID", SqlDbType.VarChar,8) ,            
                        new SqlParameter("@E_IP", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@E_Form", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@E_Appname", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@E_Record", SqlDbType.Text) ,            
                        new SqlParameter("@E_Datetime", SqlDbType.DateTime)             
              
            };
            parameters[0].Value = model.User_ID;
            parameters[1].Value = model.E_IP;
            parameters[2].Value = model.E_Form;
            parameters[3].Value = model.E_Appname;
            parameters[4].Value = model.E_Record;
            parameters[5].Value = model.E_Datetime;
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
        public bool Update(ITC_SysEvent_M model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ITC_SysEvent set "); 
            strSql.Append(" User_ID = @User_ID , ");
            strSql.Append(" E_IP = @E_IP , ");
            strSql.Append(" E_Form = @E_Form , ");
            strSql.Append(" E_Appname = @E_Appname , ");
            strSql.Append(" E_Record = @E_Record , ");
            strSql.Append(" E_Datetime = @E_Datetime  ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@E_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@User_ID", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@E_IP", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@E_Form", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@E_Appname", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@E_Record", SqlDbType.Text) ,            
                        new SqlParameter("@E_Datetime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.E_ID;
            parameters[1].Value = model.User_ID;
            parameters[2].Value = model.E_IP;
            parameters[3].Value = model.E_Form;
            parameters[4].Value = model.E_Appname;
            parameters[5].Value = model.E_Record;
            parameters[6].Value = model.E_Datetime;
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ITC_SysEvent ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

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
        public List<ITC_SysEvent_M> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM View_ITC_SysEvent1 ");
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
        public List<ITC_SysEvent_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            List<ITC_SysEvent_M> list = new List<ITC_SysEvent_M>();
            string sql = DbHelperSQL.GetPagerSql("View_ITC_SysEvent1", "*", strWhere, "E_ID", "desc", pageIndex, pageSize, out recordCount);
            if (recordCount > 0)
            {
                DataSet ds = DbHelperSQL.Query(sql);
                list = DsToList(ds);
            }
            return list;
        }

        private List<ITC_SysEvent_M> DsToList(DataSet ds)
        {
            List<ITC_SysEvent_M> list = new List<ITC_SysEvent_M>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ITC_SysEvent_M model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new ITC_SysEvent_M();
                    if (ds.Tables[0].Rows[i]["E_ID"].ToString() != "")
                    {
                        model.E_ID = int.Parse(ds.Tables[0].Rows[i]["E_ID"].ToString());
                    }
                    model.User_ID = ds.Tables[0].Rows[i]["User_ID"].ToString();
                    model.E_IP = ds.Tables[0].Rows[i]["E_IP"].ToString();
                    model.E_Form = ds.Tables[0].Rows[i]["E_Form"].ToString();
                    model.E_Appname = ds.Tables[0].Rows[i]["E_Appname"].ToString();
                    model.E_Record = ds.Tables[0].Rows[i]["E_Record"].ToString();
                    if (ds.Tables[0].Rows[i]["E_Datetime"].ToString() != "")
                    {
                        model.E_Datetime = DateTime.Parse(ds.Tables[0].Rows[i]["E_Datetime"].ToString());
                    }
                    //view
                    model.User_Name = ds.Tables[0].Rows[i]["User_Name"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion
    }
}
