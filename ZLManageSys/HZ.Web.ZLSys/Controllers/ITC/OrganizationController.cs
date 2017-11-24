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
    /// 组织管理
    /// </summary>
    public class OrganizationController : ControllerBase
    {
        ITC_Organization uifo = new ITC_Organization();
        //
        // GET: /Organization/

        public ActionResult Index()
        {
            EventContext.Add(MenuID, "进入");
            return View();
        }
        //获取数据
        public ActionResult GetDataList(string sw)
        {
            ITC_Userinfo busr = new ITC_Userinfo();
            var pageIndex = Common.GetPageIndex();
            var pageSize = Common.GetPageSize();
            var total = 0;
            List<ITC_Organization_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           f.Orga_ID,
                           f.Organization_address,
                           Organization_Ceo = busr.GetUserName(f.Organization_Ceo),
                           Organization_createdtime = f.Organization_createdtime.ToString("g"),
                           f.Organization_DeptCode,
                           f.Organization_Fax,
                           f.Organization_FullName,
                           f.Organization_Mobil,
                           f.Organization_Name,
                           f.Organization_Oprt,
                           f.Organization_Order,
                           Organization_PanelName = uifo.GetOrgaName(f.Organization_ParentID),
                           f.Organization_Remark,
                           Organization_Status = Common.GetStatus(f.Organization_Status),
                           f.Organization_Tel,
                           f.Organization_Zip,
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
        }
        //获取模型
        public ActionResult GetModel(string id)
        {
            ITC_Organization_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //添加保存
        public ActionResult SaveAdd(ITC_Organization_M model)
        {
            model.Organization_createdtime = DateTime.Now;
            model.Organization_Oprt = UserContext.UserName;
            if (!uifo.Exists(model.Orga_ID))
            {
                if (uifo.Add(model))
                {
                    OrgaContext.InitCache();
                    EventContext.Add(MenuID, string.Format("添加:{0}", model.Orga_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Orga_ID + "]已存在!");
            }
        }
        //编辑保存
        public ActionResult SaveEdit(ITC_Organization_M model)
        {
            model.Organization_createdtime = DateTime.Now;
            model.Organization_Oprt = UserContext.UserName;
            if (uifo.Exists(model.Orga_ID))
            {
                if (uifo.Update(model))
                {
                    OrgaContext.InitCache();
                    EventContext.Add(MenuID, string.Format("修改:{0}", model.Orga_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Orga_ID + "]不存在!");
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
                OrgaContext.InitCache();
                return Content("删除成功!");
            }
            else
            {
                return Content("删除失败!");
            }
        }

        #region 提供下拉数据源
        /// <summary>
        /// 获取所有组织(不含利银辉)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDataList2()
        {
            List<ITC_Organization_M> list_mo = OrgaContext.CacheList;//从缓存读取
            var list = from f in list_mo
                       where f.Orga_ID != " "
                       orderby f.Orga_ID
                       select new
                       {
                           f.Orga_ID,
                           f.Organization_FullName
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取所有组织(含利银辉)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDataList3()
        {
            List<ITC_Organization_M> list_mo = OrgaContext.CacheList;//从缓存读取
            List<ITC_Organization_M> list_mo1 = new List<ITC_Organization_M>();
            foreach (ITC_Organization_M item in list_mo)
            {
                list_mo1.Add(item);
            }
            ITC_Organization_M blank = new ITC_Organization_M();
            blank.Orga_ID = "";
            blank.Organization_FullName = " 所有";
            list_mo1.Add(blank);

            var list = from f in list_mo1
                       orderby f.Orga_ID
                       select new
                       {
                           f.Orga_ID,
                           f.Organization_FullName
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取当前用户组织
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDataList4()
        {
            List<ITC_Organization_M> list_mo = OrgaContext.CacheList;//从缓存读取
            var list = from f in list_mo
                       where UserContext.OrgaIDs.Contains(f.Orga_ID)
                       orderby f.Orga_ID
                       select new
                       {
                           f.Orga_ID,
                           f.Organization_FullName
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //获取父级列表
        public ActionResult GetParentList()
        {
            var list = from f in uifo.GetList("")
                       orderby f.Orga_ID
                       select new
                       {
                           f.Orga_ID,
                           f.Organization_Name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
