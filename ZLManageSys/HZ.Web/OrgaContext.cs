using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZ.Data.Model;
using HZ.Data.BLL;
using HZ.Cache.IO;

namespace HZ.Web
{
    /// <summary>
    /// 组织操作类
    /// </summary>
    public class OrgaContext
    {
        #region 属性
        /// <summary>
        /// 数据列表(缓存)
        /// </summary>
        public static List<ITC_Organization_M> CacheList
        {
            get
            {
                object obj = CacheHelper.Get(CacheKeys.Orgas.ToString());
                if (obj == null)
                {
                    return InitCache();
                }
                else
                {
                    return (List<ITC_Organization_M>)obj;
                }
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化组织缓存数据
        /// </summary>
        public static List<ITC_Organization_M> InitCache()
        {
            ITC_Organization bll = new ITC_Organization();
            List<ITC_Organization_M> list = bll.GetList("Organization_Status=0");
            CacheHelper.Set(CacheKeys.Orgas.ToString(), list);
            return list;
        }
        /// <summary>
        /// 获取名称(缓存)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ITC_Organization_M model = CacheList.Find(m => m.Orga_ID == id);
                if (model != null)
                {
                    return model.Organization_Name;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取名称(数据库)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetNameByDB(string id)
        {
            ITC_Organization bll = new ITC_Organization();
            return bll.GetOrgaName(id);
        }
        /// <summary>
        /// 获取全称(缓存)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetFullNameByCache(string id)
        {
            //if (!string.IsNullOrEmpty(id))
            //{
            ITC_Organization_M model = CacheList.Find(m => m.Orga_ID == id);
            if (model != null)
            {
                return model.Organization_FullName;
            }
            else
            {
                return "";
            }
            //}
            //else
            //{
            //    return "利银辉";
            //}
        }
        /// <summary>
        /// 获取全称(数据库)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetFullNameByDB(string id)
        {
            ITC_Organization bll = new ITC_Organization();
            return bll.GetOrgaFullName(id);
        }
        /// <summary>
        /// 编码是否存在(缓存)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool ExistsByCache(string id)
        {
            return CacheList.Exists(m => m.Orga_ID == id);
        }
        /// <summary>
        /// 编码是否存在(数据库)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool ExistsByDB(string id)
        {
            ITC_Organization bll = new ITC_Organization();
            return bll.Exists(id);
        }

        /// <summary>
        /// 获取利家部门编码(缓存)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetDeptCodeByCache(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ITC_Organization_M model = CacheList.Find(m => m.Orga_ID == id);
                if (model != null)
                {
                    return model.Organization_DeptCode;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取利家部门编码(数据库)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetDeptCodeByDB(string id)
        {
            ITC_Organization bll = new ITC_Organization();
            return bll.GetDeptCode(id);
        }
        #endregion
    }
}
