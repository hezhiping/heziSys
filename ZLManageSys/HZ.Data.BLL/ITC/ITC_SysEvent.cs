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
    /// 系统日志
    /// </summary>
    public class ITC_SysEvent
    {
        private readonly IITC_SysEvent dal = DataAccess.CreateITC_SysEvent();
        public ITC_SysEvent() { }

        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ITC_SysEvent_M GetModel(int id)
        {
            List<ITC_SysEvent_M> list = GetList(string.Format("E_ID={0}", id));
            return list.Count > 0 ? list[0] : null;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_SysEvent_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_SysEvent_M model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ITC_SysEvent_M> GetList(string strWhere)
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
        public List<ITC_SysEvent_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }

    }
}
