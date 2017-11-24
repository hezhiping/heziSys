using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZ.Data.Model;
using HZ.Data.BLL;

namespace HZ.Web
{
    /// <summary>
    /// 系统日志操作类
    /// </summary>
    public class EventContext
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="form">菜单ID</param>
        /// <param name="record">操作内容</param>
        public static void Add(string form, string record)
        {
            ITC_SysEvent_M model = new ITC_SysEvent_M();
            ITC_SysEvent bEvent = new ITC_SysEvent();
            model.E_Form = form;
            model.E_Appname = MenuContext.GetNameByCache(form);
            model.User_ID = UserContext.UserID;
            model.E_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            model.E_Record = record;
            model.E_Datetime = DateTime.Now;

            bEvent.Add(model);
        }
    }
}
