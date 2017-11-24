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
    /// 菜单操作类
    /// </summary>
    public class MenuContext
    {
        public MenuContext()
        {
        }

        #region 属性
        /// <summary>
        /// 数据列表(缓存)
        /// </summary>
        public static List<ITC_Sysmenus_M> CacheList
        {
            get
            {
                object obj = CacheHelper.Get(CacheKeys.Menus.ToString());
                if (obj == null)
                {
                    return InitCache();
                }
                else
                {
                    return (List<ITC_Sysmenus_M>)obj;
                }
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初如化缓存数据
        /// </summary>
        public static List<ITC_Sysmenus_M> InitCache()
        {
            ITC_Sysmenus bll = new ITC_Sysmenus();
            List<ITC_Sysmenus_M> list = bll.GetList("Menu_Status=0");
            CacheHelper.Set(CacheKeys.Menus.ToString(), list);
            return list;
        }
        /// <summary>
        /// 获取MenuID(缓存)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetMenuIDByUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                ITC_Sysmenus_M model = CacheList.Find(m => m.Menu_Url.ToLower().Contains(url.ToLower()));
                if (model != null)
                {
                    return model.Menu_ID;
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
        /// 获取名称(缓存)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetNameByCache(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ITC_Sysmenus_M model = CacheList.Find(m => m.Menu_ID == id);
                if (model != null)
                {
                    return model.Menu_Name;
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
        #endregion
    }
}