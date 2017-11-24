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
    /// 角色菜单
    /// </summary>
    public class ITC_RoleRights
    {
        private readonly IITC_RoleRights dal = DataAccess.CreateITC_RoleRights();
        public ITC_RoleRights() { }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(string id, string mid)
        {
            return dal.Exists(id, mid);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_RoleRights_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_RoleRights_M model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool Delete(string id, string mid)
        {
            return dal.Delete(id, mid);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ITC_RoleRights_M> GetList(string strWhere)
        {
            string where = "";
            if (strWhere != null)
            {
                where = strWhere;
            }
            return dal.GetList(where);
        }

    }
}
