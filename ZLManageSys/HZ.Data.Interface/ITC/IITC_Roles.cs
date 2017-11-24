using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HZ.Data.Model;

namespace HZ.Data.Interface
{
    /// <summary>
    /// 角色
    /// </summary>
    public interface IITC_Roles
    {
        #region 成员方法
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(ITC_Roles_M model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(ITC_Roles_M model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        bool Delete(string roleid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ITC_Roles_M> GetList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        List<ITC_Roles_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount);

        /// <summary>
        /// 检查角色操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        bool CheckRoleOperator(string roleid, string menuid, string buttonid);
        /// <summary>
        /// 删除角色菜单权限(所有)
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        void DeleteRoleRights(string roleid);
        /// <summary>
        /// 删除角色菜单操作权限(所有)
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        void DeleteRoleOperator(string roleid);
        /// <summary>
        /// 给角色添加菜单权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <returns></returns>
        void AddRoleRights(string roleid, string menuid);
        /// <summary>
        /// 给角色添加菜单操作权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuid"></param>
        /// <param name="buttonid"></param>
        /// <returns></returns>
        void AddRoleOperator(string roleid, string menuid, string buttonid);
        /// <summary>
        /// 获取多角色的操作权限(汇总)
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        List<ITC_RoleOperator_M> GetRoleOperater(List<ITC_Roles_M> roles);

        #endregion
    }
}
