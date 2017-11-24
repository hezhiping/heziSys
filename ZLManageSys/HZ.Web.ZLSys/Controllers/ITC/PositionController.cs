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
    /// 岗位管理
    /// </summary>
    public class PositionController : ControllerBase
    {
        ITC_Position uifo = new ITC_Position();
        //
        // GET: /Position/

        public ActionResult Index()
        {
            EventContext.Add(MenuID, "进入");
            return View();
        }
        //获取数据列表
        public ActionResult GetDataList(string sw)
        {
            var pageIndex = Common.GetPageIndex();
            var pageSize = Common.GetPageSize();
            var total = 0;
            List<ITC_Position_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           f.Position_ID,
                           f.Position_name,
                           f.Position_Oprt,
                           f.Position_remark,
                           Position_createdtime = f.Position_createdtime.ToString("g"),
                           Position_status = Common.GetStatus(f.Position_status),
                           f.Position_Order
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
        }
        //获取模型
        public ActionResult GetModel(string id)
        {
            ITC_Position_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //保存添加
        public ActionResult SaveAdd(ITC_Position_M model)
        {
            if (!uifo.Exists(model.Position_ID))
            {
                model.Position_createdtime = DateTime.Now;
                model.Position_Oprt = UserContext.UserName;
                if (uifo.Add(model))
                {
                    EventContext.Add(MenuID, string.Format("添加:{0}", model.Position_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Position_ID + "]已存在!");
            }
        }
        //编辑保存
        public ActionResult SaveEdit(ITC_Position_M model)
        {
            if (uifo.Exists(model.Position_ID))
            {
                model.Position_createdtime = DateTime.Now;
                model.Position_Oprt = UserContext.UserName;
                if (uifo.Update(model))
                {
                    EventContext.Add(MenuID, string.Format("修改:{0}", model.Position_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Position_ID + "]不存在!");
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
                return Content("删除成功!");
            }
            else
            {
                return Content("删除失败!");
            }
        }
    }
}
