using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HZ.Data.Model;
using HZ.Data.Factory;
using HZ.Data.Interface;
namespace HZ.Data.BLL
{
    /// <summary>
    /// 角色
    /// </summary>
    public class ITC_Roles
    {
        private readonly IITC_Roles dal = DataAccess.CreateITC_Roles();

        public ITC_Roles() { }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public ITC_Roles_M GetModel(string roleid)
        {
            List<ITC_Roles_M> list = GetList(string.Format("Role_ID='{0}'", roleid));
            return list.Count > 0 ? list[0] : null;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_Roles_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_Roles_M model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public bool Delete(string roleid)
        {
            return dal.Delete(roleid);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ITC_Roles_M> GetList(string strWhere)
        {
            string where = "";
            if (strWhere != null)
            {
                where = strWhere;
            }
            return dal.GetList(where);
        }
        public string GetRoleName(string roleid)
        {
            ITC_Roles_M model = GetModel(roleid);
            return model != null ? model.Role_Name : "";
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Roles_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }
        /// <summary>
        /// 检查角色菜单操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        public bool CheckRoleOperator(string roleid, string menuid, string buttonid)
        {
            return dal.CheckRoleOperator(roleid, menuid, buttonid);
        }
        /// <summary>
        /// 删除角色菜单权限(所有)
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public void DeleteRoleRights(string roleid)
        {
            dal.DeleteRoleRights(roleid);
        }
        /// <summary>
        /// 删除角色菜单操作权限(所有)
        /// </summary>
        /// <param name="roleid"></param>
        public void DeleteRoleOperator(string roleid)
        {
            dal.DeleteRoleOperator(roleid);
        }
        /// <summary>
        /// 给角色添加菜单权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        public void AddRoleRights(string roleid, string menuid)
        {
            dal.AddRoleRights(roleid, menuid);
        }
        /// <summary>
        /// 给角色添加菜单操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <param name="buttonid"></param>
        public void AddRoleOperator(string roleid, string menuid, string buttonid)
        {
            dal.AddRoleOperator(roleid, menuid, buttonid);
        }
        /// <summary>
        /// 获取多角色的操作权限(汇总)
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<ITC_RoleOperator_M> GetRoleOperater(List<ITC_Roles_M> roles)
        {
            return dal.GetRoleOperater(roles);
        }

    }
}
