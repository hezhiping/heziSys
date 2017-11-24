using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZ.Data.Interface;
using HZ.Data.Factory;
using System.Data;
using HZ.Data.Model;

namespace HZ.Data.BLL
{  
    /// <summary>
    /// 基础数据_生产线数据字典BLL
    /// </summary>
    public class BaseInfo_Scx_B
    {
          private readonly IBaseInfo_Scx dal = DataAccess.CreateBaseInfo_Scx();

          public BaseInfo_Scx_B() { }
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
        public BaseInfo_Scx_M GetModel(string id)
        {
            List<BaseInfo_Scx_M> list = GetList(string.Format("ScxID='{0}'", id));
            return list.Count > 0 ? list[0] : null;
        }
        /// <summary>
        /// 操作信息
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public string GetButtonName(string bid)
        {
            BaseInfo_Scx_M model = GetModel(bid);
            return model != null ? model.ScxName : "";
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(BaseInfo_Scx_M model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(BaseInfo_Scx_M model)
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
            return dal.Delete(int.Parse(id));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<BaseInfo_Scx_M> GetList(string strWhere)
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
        public List<BaseInfo_Scx_M> GetList(string strWhere, int pageIndex, int pageSize, out int recordCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out recordCount);
        }

    }
}
