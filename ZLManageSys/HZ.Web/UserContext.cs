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
    /// 当前用户
    /// </summary>
    public class UserContext
    {
        #region 操作方法
        /// <summary>
        /// 初始化用户信息、菜单操作权限
        /// </summary>
        /// <param name="id"></param>
        public static void Init(string userid)
        {
            if (userid != null && userid != "")
            {
                ITC_Userinfo usr = new ITC_Userinfo();
                ITC_Userinfo_M model_usr = usr.GetModel(userid);
                if (model_usr != null)
                {
                    System.Web.HttpContext.Current.Session[SessionKeys.UserID.ToString()] = model_usr.User_ID;
                    System.Web.HttpContext.Current.Session[SessionKeys.UserName.ToString()] = model_usr.User_Name;
                    System.Web.HttpContext.Current.Session[SessionKeys.OrgaID.ToString()] = model_usr.Orga_ID;
                    System.Web.HttpContext.Current.Session[SessionKeys.Power.ToString()] = usr.GetUserRoleOperater(model_usr.User_ID);
                    System.Web.HttpContext.Current.Session[SessionKeys.Orgas.ToString()] = usr.GetOrgaIDs(model_usr.User_ID);
                }
            }
        }
        /// <summary>
        /// 用户是否已登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["SdlCookie"] != null)
            {
                string userid = System.Web.HttpContext.Current.Request.Cookies["SdlCookie"]["EmpNo"];
                if (System.Web.HttpContext.Current.Session[SessionKeys.UserID.ToString()] != null)
                {
                    if (System.Web.HttpContext.Current.Session[SessionKeys.UserID.ToString()].ToString() != userid)
                    {
                        System.Web.HttpContext.Current.Session.RemoveAll();
                        Init(userid);
                    }
                }
                else
                {
                    Init(userid);
                }
                return System.Web.HttpContext.Current.Session[SessionKeys.UserID.ToString()] != null;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证当前用户权限
        /// </summary>
        /// <param name="menuid">菜单ID</param>
        /// <param name="buttonid">操作ID</param>
        /// <returns></returns>
        public static bool CheckPower(string menuid, string buttonid)
        {
            if (Power != null)
            {
                ITC_RoleOperator_M usropt = Power.Find(
                    delegate(ITC_RoleOperator_M opt)
                    {
                        return opt.Menu_ID == menuid && opt.Buttons_ID == buttonid;
                    });
                if (usropt != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 用户属性
        /// <summary>
        /// 当前用户ID
        /// </summary>
        public static string UserID
        {
            get
            {
                object obj = System.Web.HttpContext.Current.Session[SessionKeys.UserID.ToString()];
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 当前用户名
        /// </summary>
        public static string UserName
        {
            get
            {
                object obj = System.Web.HttpContext.Current.Session[SessionKeys.UserName.ToString()];
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 当前用户所在组织ID
        /// </summary>
        public static string OrgaID
        {
            get
            {
                object obj = System.Web.HttpContext.Current.Session[SessionKeys.OrgaID.ToString()];
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 当前用户菜单操作权限
        /// </summary>
        public static List<ITC_RoleOperator_M> Power
        {
            get
            {
                object obj = System.Web.HttpContext.Current.Session[SessionKeys.Power.ToString()];
                if (obj != null)
                {
                    return (List<ITC_RoleOperator_M>)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 当前用户组织范围(IDs)
        /// </summary>
        public static List<string> OrgaIDs
        {
            get
            {
                object obj = System.Web.HttpContext.Current.Session[SessionKeys.Orgas.ToString()];
                if (obj != null)
                {
                    return (List<string>)obj;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion
    }
}
