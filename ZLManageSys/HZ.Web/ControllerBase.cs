using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;

namespace HZ.Web
{
    public class ControllerBase : Controller
    {
        /// <summary>
        /// Action执行前判断
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!UserContext.IsLogin())
            {
                string url = "";
                string msg = "";
                if (ConfigurationManager.AppSettings["Debug"].ToString() == "true")
                {
                    //Debug
                    url = ConfigurationManager.AppSettings["DebugURL"].ToString();
                    filterContext.Result = Content(string.Concat("<script>", msg == "" ? "" : string.Format("alert('{0}');", msg), "top.location='", Url.Content(url), "'</script>"), "text/html");
                }
                else
                {
                    //Release
                    url = ConfigurationManager.AppSettings["WebURL"].ToString() + "/Default.htm?ReturnUrl=" + Server.UrlEncode(ConfigurationManager.AppSettings["SysURL"].ToString() + "/");
                    filterContext.Result = Content(string.Concat("<script>", msg == "" ? "" : string.Format("alert('{0}');", msg), "top.location='" + url + "'</script>"), "text/html");
                }
            }
            RenderViewData();
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="buttonid">操作ID</param>
        /// <returns></returns>
        public virtual bool CheckPower(string buttonid)
        {
            if (UserContext.CheckPower(this.MenuID, buttonid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public virtual string MenuID
        {
            get { return MenuContext.GetMenuIDByUrl(this.RouteData.Values["controller"].ToString()); }
        }

        private void RenderViewData()
        {
            //页面菜单ID，权限验证用
            ViewData.Add("MenuID", MenuID);
        }
    }
}
