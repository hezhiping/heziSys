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
    /// 用户信息
    /// </summary>
    public interface IITC_Userinfo
    {
        #region 成员方法
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(string id);
        bool Exists(string id,string pwd);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(ITC_Userinfo_M model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(ITC_Userinfo_M model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        bool Delete(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ITC_Userinfo_M> GetList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        List<ITC_Userinfo_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount);

        /// <summary>
        /// 检查用户岗位范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        bool CheckPositionRange(string userid, string posid, string orgaid);
        /// <summary>
        /// 删除用户岗位(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        void DeletePosition(string userid);
        /// <summary>
        /// 删除用户岗位范围(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        void DeletePositionRange(string userid);
        /// <summary>
        /// 添加用户岗位
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <returns></returns>
        void AddPosition(string userid, string posid);
        /// <summary>
        /// 添加用户岗位范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="posid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        void AddPositionRange(string userid, string posid, string orgaid);

        /// <summary>
        /// 检查用户角色范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        bool CheckRoleRange(string userid, string roleid, string orgaid);
        /// <summary>
        /// 删除用户角色(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        void DeleteRoles(string userid);
        /// <summary>
        /// 删除用户角色范围(所有)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        void DeleteRoleRange(string userid);
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        void AddRoles(string userid, string roleid);
        /// <summary>
        /// 添加用户角色范围
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        void AddRoleRange(string userid, string roleid, string orgaid);
        /// <summary>
        /// 获取用户组织范围
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<string> GetOrgaIDs(string userid);
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="orgid">组织ID</param>
        /// <param name="posid">岗位ID</param>
        /// <returns></returns>
        string GetUserID(string orgid, string posid);
        List<string> GetUserIDs(string orgid, string posid);
        /// <summary>
        /// 是否拥有角色
        /// </summary>
        /// <returns></returns>
        bool HaveRole(string userid, string roleid);
        /// <summary>
        /// 获取某角色用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        List<string> GetUserIDbyRole(string roleid);
        /// <summary>
        /// 获取某岗位某部门用户
        /// </summary>
        /// <param name="posid"></param>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        List<string> GetUserIDbyPostionOrga(string posid, string orgaid);

        #endregion
    }
}
