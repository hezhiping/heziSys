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
    /// 菜单
    /// </summary>
    public class ITC_Sysmenus
    {
        private readonly IITC_Sysmenus dal = DataAccess.CreateITC_Sysmenus();
        public ITC_Sysmenus() { }
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
        /// <param name="Menu_ID"></param>
        /// <returns></returns>
        public ITC_Sysmenus_M GetModel(string Menu_ID)
        {
            List<ITC_Sysmenus_M> list = GetList(string.Format("Menu_ID='{0}'", Menu_ID));
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_Sysmenus_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_Sysmenus_M model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Menu_ID"></param>
        /// <returns></returns>
        public bool Delete(string Menu_ID)
        {
            return dal.Delete(Menu_ID);
        }
        /// <summary>
        /// 获取菜单名称
        /// </summary>
        /// <param name="Menu_ID"></param>
        /// <returns></returns>
        public string GetMenuName(string Menu_ID)
        {
            ITC_Sysmenus_M model = GetModel(Menu_ID);
            return model != null ? model.Menu_Name : "";
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ITC_Sysmenus_M> GetList(string strWhere)
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
        public List<ITC_Sysmenus_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }


    }
}
