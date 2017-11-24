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
    /// 系统日志
    /// </summary>
    public interface IITC_SysEvent
    {
        #region 成员方法
      
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(ITC_SysEvent_M model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(ITC_SysEvent_M model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ITC_SysEvent_M> GetList(string strWhere);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        List<ITC_SysEvent_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount);

        #endregion
    }
}
