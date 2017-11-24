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
    /// 菜单管理
    /// </summary>
    public class SysmenusController : ControllerBase
    {
        ITC_Sysmenus uifo = new ITC_Sysmenus();
        //
        // GET: /Sysmenus/

        public ActionResult Index()
        {
            EventContext.Add(MenuID, "进入");
            return View();
        }

        //获取数据
        public ActionResult GetDataList(string sw)
        {
            var pageIndex = Common.GetPageIndex();
            var pageSize = Common.GetPageSize();
            var total = 0;
            List<ITC_Sysmenus_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           Menu_createdtime = f.Menu_createdtime.ToString("g"),
                           f.Menu_Ico,
                           f.Menu_ID,
                           f.Menu_Name,
                           f.Menu_Oprt,
                           f.Menu_Order,
                           Menu_ParentName=uifo.GetMenuName(f.Menu_ParentID),
                           f.Menu_Remark,
                           Menu_Status = Common.GetStatus(f.Menu_Status),
                           f.Menu_Type,
                           f.Menu_Url
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
        }
        //获取模型
        public ActionResult GetModel(string id)
        {
            ITC_Sysmenus_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //添加保存
        public ActionResult SaveAdd(ITC_Sysmenus_M model)
        {
            model.Menu_createdtime = DateTime.Now;
            model.Menu_Oprt = UserContext.UserName;
            if (!uifo.Exists(model.Menu_ID))
            {
                if (uifo.Add(model))
                {
                    MenuContext.InitCache();
                    EventContext.Add(MenuID, string.Format("添加:{0}", model.Menu_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Menu_ID + "]已存在!");
            }
        }
        //编辑保存
        public ActionResult SaveEdit(ITC_Sysmenus_M model)
        {
            model.Menu_createdtime = DateTime.Now;
            model.Menu_Oprt = UserContext.UserName;
            if (uifo.Exists(model.Menu_ID))
            {
                if (uifo.Update(model))
                {
                    MenuContext.InitCache();
                    EventContext.Add(MenuID, string.Format("修改:{0}", model.Menu_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Menu_ID + "]不存在!");
            }
        }
        //删除
        public ActionResult Delete(string ids)
        {
            int count = 0;
            foreach (string id in ids.Split(','))
            {
                if (uifo.Delete(id))
                {
                    EventContext.Add(MenuID, string.Format("删除:{0}", id));
                    count++;
                }
            }
            if (count > 0)
            {
                MenuContext.InitCache();
                return Content("删除成功!");
            }
            else
            {
                return Content("删除失败!");
            }
        }

        #region 提供下拉数据源
        public ActionResult GetParentList()
        {
            var list = from f in uifo.GetList("")
                       orderby f.Menu_Order
                       select new
                       {
                           f.Menu_ID,
                           f.Menu_Name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion








    }
}
