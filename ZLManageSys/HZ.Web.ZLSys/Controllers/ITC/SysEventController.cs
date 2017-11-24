using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HZ.Data.Model;
using HZ.Data.BLL;

namespace HZ.Web.HZ.Controllers.ITC
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SysEventController : ControllerBase
    {
        ITC_SysEvent uifo = new ITC_SysEvent();
        //
        // GET: /SysEvent/

        public ActionResult Index()
        {
           // EventContext.Add(MenuID, "进入");
            return View();
        }
        //获取数据
        public ActionResult GetDataList(string sw)
        {
            var pageIndex = Common.GetPageIndex();
            var pageSize = Common.GetPageSize();
            var total = 0;
            List<ITC_SysEvent_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           f.E_Appname,
                           E_Datetime = f.E_Datetime.ToString("g"),
                           f.E_Form,
                           f.E_ID,
                           f.E_IP,
                           f.E_Record,
                           f.User_ID,
                           f.User_Name,
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
        }
        //获取模型
        public ActionResult GetModel(int id)
        {
            ITC_SysEvent_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //删除
        public ActionResult Delete(string deleteID)
        {
            int count = 0;

            foreach (string uid in deleteID.Split(','))
            {
                if (uifo.Delete(int.Parse(uid)))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                return Content("删除成功");
            }
            else
            {
                return Content("删除失败！");
            }
        }
    }
}
