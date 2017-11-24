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
    /// 按扭设置
    /// </summary>
    public class ButtonsController : ControllerBase
    {
        ITC_Buttons uifo = new ITC_Buttons(); 
        //
        // GET: /Buttons/

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
            List<ITC_Buttons_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           f.Buttons_ID,
                           f.Buttons_Img,
                           f.Buttons_NAME,
                           f.Buttons_Remark,
                           Buttons_Status = Common.GetStatus(f.Buttons_Status)
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
        }
        //获取模型
        public ActionResult GetModel(string id)
        {
            ITC_Buttons_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //保存添加
        public ActionResult SaveAdd(ITC_Buttons_M model)
        {
            if (!uifo.Exists(model.Buttons_ID))
            {
                if (uifo.Add(model))
                {
                    EventContext.Add(MenuID, string.Format("添加:{0}", model.Buttons_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Buttons_ID + "]已存在!");
            }
        }
        //编辑保存
        public ActionResult SaveEdit(ITC_Buttons_M model)
        {
            if (uifo.Exists(model.Buttons_ID))
            {
                if (uifo.Update(model))
                {
                    EventContext.Add(MenuID, string.Format("修改:{0}", model.Buttons_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Buttons_ID + "]不存在!");
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
