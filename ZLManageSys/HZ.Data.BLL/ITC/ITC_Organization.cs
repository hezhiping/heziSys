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
    /// 组织架构
    /// </summary>
    public class ITC_Organization
    {
        private readonly IITC_Organization dal = DataAccess.CreateITC_Organization();

        public ITC_Organization() { }
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
        public ITC_Organization_M GetModel(string id)
        {
            List<ITC_Organization_M> list = GetList(string.Format("Orga_ID='{0}'", id));
            return list.Count > 0 ? list[0] : null;
        }
        /// <summary>
        /// 获取组织名称
        /// </summary>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public string GetOrgaName(string orgaid)
        {
            ITC_Organization_M model = GetModel(orgaid);
            return model != null ? model.Organization_Name : "";
        }
        /// <summary>
        /// 获取组织全称
        /// </summary>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public string GetOrgaFullName(string orgaid)
        {
            ITC_Organization_M model = GetModel(orgaid);
            return model != null ? model.Organization_FullName : "";
        }
        /// <summary>
        /// 获取利家部门编码
        /// </summary>
        /// <param name="orgaid"></param>
        /// <returns></returns>
        public string GetDeptCode(string orgaid)
        {
            ITC_Organization_M model = GetModel(orgaid);
            return model != null ? model.Organization_DeptCode : "";
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ITC_Organization_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ITC_Organization_M model)
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
        public List<ITC_Organization_M> GetList(string strWhere)
        {
            string where = "";
            if (strWhere != null)
            {
                where = strWhere;
            }
            else
            {
                where = "";
            }
            return dal.GetList(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<ITC_Organization_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }

        /// <summary>
        /// 获取组织ID
        /// </summary>
        /// <param name="deptcode">利家部门code</param>
        /// <returns></returns>
        public string GetOrgaIDbyDeptCode(string deptcode)
        {
            List<ITC_Organization_M> list = GetList(string.Format("Organization_DeptCode='{0}'", deptcode));
            return list.Count > 0 ? list[0].Orga_ID : null;
        }
    }
}
