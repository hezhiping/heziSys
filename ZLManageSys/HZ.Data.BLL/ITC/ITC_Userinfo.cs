using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HZ.Data.Model;
using HZ.Data.Factory;
using HZ.Data.Interface;
using HZ.Utility;
namespace HZ.Data.BLL
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class ITC_Userinfo
    {
        private readonly IITC_Userinfo dal = DataAccess.CreateITC_Userinfo();
        public ITC_Userinfo() { }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(string userid)
        {
            return dal.Exists(userid);
        }
        public bool Exists(string userid, string pwd)
        {
            return dal.Exists(userid, pwd);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ITC_Userinfo_M GetModel(string userid)
        {
            List<ITC_Userinfo_M> list = GetList(string.Format("User_ID='{0}'", userid));
            return list.Count > 0 ? list[0] : null;
        }
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserName(string userid)
        {
            ITC_Userinfo_M model = GetModel(userid);
            return model != null ? model.User_Name : "";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_Userinfo_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_Userinfo_M model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool Delete(string userid)
        {
            return dal.Delete(userid);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ITC_Userinfo_M> GetList(string strWhere)
        {
            string where = "";
            if (strWhere != null)
            {
                where = strWhere;
            }
            return dal.GetList(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<ITC_Userinfo_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
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
            return dal.CheckPositionRange(userid, posid, orgaid);
        }
        /// <summary>
        /// 删除用户岗位(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeletePosition(string userid)
        {
            dal.DeletePosition(userid);
        }
        /// <summary>
        /// 删除用户岗位范围(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeletePositionRange(string userid)
        {
            dal.DeletePositionRange(userid);
        }
        /// <summary>
        /// 添加用户岗位
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <returns></returns>
        public void AddPosition(string userid, string posid)
        {
            dal.AddPosition(userid, posid);
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
            dal.AddPositionRange(userid, posid, orgaid);
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
            return dal.CheckRoleRange(userid, roleid, orgaid);
        }
        /// <summary>
        /// 删除用户角色(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeleteRoles(string userid)
        {
            dal.DeleteRoles(userid);
        }
        /// <summary>
        /// 删除用户角色范围(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void DeleteRoleRange(string userid)
        {
            dal.DeleteRoleRange(userid);
        }
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public void AddRoles(string userid, string roleid)
        {
            dal.AddRoles(userid, roleid);
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
            dal.AddRoleRange(userid, roleid, orgaid);
        }

        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ITC_Roles_M> GetUserRoles(string userid)
        {
            ITC_Roles rol = new ITC_Roles();
            string where = string.Format("Role_ID in (select Role_ID from ITC_UserRoles where User_ID='{0}' and Role_Status=0) and Role_Status=0", userid);
            return rol.GetList(where);
        }
        /// <summary>
        /// 获取用户菜单列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ITC_Sysmenus_M> GetUserMenus(string userid)
        {
            ITC_Sysmenus smenu = new ITC_Sysmenus();
            List<ITC_Sysmenus_M> list_mn = new List<ITC_Sysmenus_M>();
            List<ITC_Roles_M> list_rol = GetUserRoles(userid);
            if (list_rol.Count > 0)
            {
                string where_rol = "Role_ID in (";
                foreach (ITC_Roles_M r in list_rol)
                {
                    where_rol += "'" + r.Role_ID + "',";
                }
                where_rol = where_rol.TrimEnd(',');
                where_rol += ")";
                string where_mn = string.Format("Menu_ID in (select Menu_ID from ITC_RoleRights where {0} and Roleright_Status=0 group by Menu_ID) and Menu_Status=0", where_rol);
                list_mn = smenu.GetList(where_mn);
            }
            return list_mn;
        }
        /// <summary>
        /// 获取用户操作权限
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ITC_RoleOperator_M> GetUserRoleOperater(string userid)
        {
            ITC_Roles rol = new ITC_Roles();
            return rol.GetRoleOperater(GetUserRoles(userid));
        }
        /// <summary>
        /// 获取用户组织范围
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<string> GetOrgaIDs(string userid)
        {
            return dal.GetOrgaIDs(userid);
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="orgid">组织ID</param>
        /// <param name="posid">岗位ID</param>
        /// <returns></returns>
        public string GetUserID(string orgid, string posid)
        {
            return dal.GetUserID(orgid, posid);
        }
        public List<string> GetUserIDs(string orgid, string posid)
        {
            return dal.GetUserIDs(orgid, posid);
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string pwEcncrystr(string pwd)
        {

            string str = "";
            str = DESEncrypt.Encrypt(pwd);
            return str;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string pwDencrystr(string pwd)
        {
            string str = "";
            str = DESEncrypt.Decrypt(pwd);
            return str;
        }
        /// <summary>
        /// 是否拥有角色
        /// </summary>
        /// <returns></returns>
        public bool HaveRole(string userid, string roleid)
        {
            return dal.HaveRole(userid, roleid);
        }
        /// <summary>
        /// 获取某角色用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<string> GetUserIDbyRole(string roleid)
        {
            return dal.GetUserIDbyRole(roleid);
        }
        /// <summary>
        /// 获取某岗位某部门用户
        /// </summary>
        /// <returns></returns>
        public List<string> GetUserIDbyPostionOrga(string posid, string orgaid)
        {
            return dal.GetUserIDbyPostionOrga(posid, orgaid);
        }
    }

}
