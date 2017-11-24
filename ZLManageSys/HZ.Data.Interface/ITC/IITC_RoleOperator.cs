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
    /// 角色操作权限
    /// </summary>
    public interface IITC_RoleOperator
    {
        #region 成员方法
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mid"></param>
        /// <param name="bid"></param>
        /// <returns></returns>
        bool Exists(string id,string mid,string bid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(ITC_RoleOperator_M model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(ITC_RoleOperator_M model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        bool Delete(string uid,string mid,string bid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ITC_RoleOperator_M> GetList(string strWhere);

        #endregion
    }
}
