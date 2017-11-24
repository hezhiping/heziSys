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
    /// 菜单
    /// </summary>
    public interface IITC_Sysmenus
    {
        #region 成员方法
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(string id); 
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(ITC_Sysmenus_M model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(ITC_Sysmenus_M model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        bool Delete(string Menu_ID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ITC_Sysmenus_M> GetList(string strWhere);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        List<ITC_Sysmenus_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount);

        #endregion
    }
}
