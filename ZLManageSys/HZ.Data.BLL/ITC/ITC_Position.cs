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
    /// 岗位信息
    /// </summary>
    public class ITC_Position
    {
        private readonly IITC_Position dal = DataAccess.CreateITC_Position();

        public ITC_Position() { }
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
        /// <param name="id"></param>
        /// <returns></returns>
        public ITC_Position_M GetModel(string id)
        {
            List<ITC_Position_M> list = GetList(string.Format("Position_ID='{0}'", id));
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_Position_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_Position_M model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ITC_Position_M> GetList(string strWhere)
        {
            string where = "";
            if (strWhere != null)
            {
                where = strWhere;
            }
            return dal.GetList(where);
        }
        //获取岗位信息
        public string GetPositionName(string pid)
        {
            ITC_Position_M model = GetModel(pid);
            return model != null ? model.Position_name : "";
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Position_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }
        public List<ITC_Position_M> GetListByOrder(params int[] Orders)
        {
            if (Orders.Length > 0)
            {
                string where = "Position_status=0 and Position_Order in (";
                foreach (int order in Orders)
                {
                    where += order + ",";
                }
                where = where.TrimEnd(',');
                where += ")";
                return GetList(where);
            }
            else
            {
                return new List<ITC_Position_M>();
            }
        }

    }
}
