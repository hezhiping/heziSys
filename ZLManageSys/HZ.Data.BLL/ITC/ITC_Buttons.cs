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
    /// 操作按扭
    /// </summary>
    public class ITC_Buttons
    {
        private readonly IITC_Buttons dal = DataAccess.CreateITC_Buttons();

        public ITC_Buttons() { }
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
        public ITC_Buttons_M GetModel(string id)
        {
            List<ITC_Buttons_M> list = GetList(string.Format("Buttons_ID='{0}'", id));
            return list.Count > 0 ? list[0] : null;
        }
        /// <summary>
        /// 操作信息
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public string GetButtonName(string bid)
        {
            ITC_Buttons_M model = GetModel(bid);
            return model != null ? model.Buttons_NAME : "";
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_Buttons_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_Buttons_M model)
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
        public List<ITC_Buttons_M> GetList(string strWhere)
        {
            string where = "";
            if (strWhere != null)
            {
                //where = "User_ID like '%" + strWhere + "%'";
                where = strWhere;
            }
            return dal.GetList(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ITC_Buttons_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }


    }
}
