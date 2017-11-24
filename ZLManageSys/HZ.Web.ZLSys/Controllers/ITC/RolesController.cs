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
    /// 角色管理
    /// </summary>
    public class RolesController : ControllerBase
    {
        ITC_Roles uifo = new ITC_Roles();
        //
        // GET: /Roles/
        //写入日志
        public ActionResult Index()
        {
            EventContext.Add(MenuID, "进入");
            return View();
        }

        public ActionResult RoleRights()
        {
            return View();
        }
        //获取数据
        public ActionResult GetDataList(string sw)
        {
            #region pagesl
            var pageIndex = Common.GetPageIndex();
            var pageSize = Common.GetPageSize();
            var total = 0;
            List<ITC_Roles_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           f.Role_ID,
                           f.Role_Name,
                           f.Role_Remark,
                           f.Role_oprt,
                           Role_createdtime = f.Role_createdtime.ToString("g"),
                           Role_Status = Common.GetStatus(f.Role_Status)
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
            #endregion
        }
        //获取模型
        public ActionResult GetModel(string id)
        {
            ITC_Roles_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //添加保存
        public ActionResult SaveAdd(ITC_Roles_M model)
        {
            if (!uifo.Exists(model.Role_ID))
            {
                model.Role_createdtime = DateTime.Now;
                model.Role_oprt = UserContext.UserName;
                if (uifo.Add(model))
                {
                    EventContext.Add(MenuID, string.Format("添加:{0}", model.Role_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Role_ID + "]已存在!");
            }
        }
        //编辑保存
        public ActionResult SaveEdit(ITC_Roles_M model)
        {
            if (uifo.Exists(model.Role_ID))
            {
                model.Role_createdtime = DateTime.Now;
                model.Role_oprt = UserContext.UserName;
                if (uifo.Update(model))
                {
                    EventContext.Add(MenuID, string.Format("修改:{0}", model.Role_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.Role_ID + "]不存在!");
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
        


        [HttpPost]
        //设置权限
        public ActionResult SaveRight(FormCollection collection)
        {
            string roleid = Request["roleid"];
            if (!string.IsNullOrEmpty(roleid))
            {
                //删除菜单权限 操作权限
                uifo.DeleteRoleRights(roleid);
                uifo.DeleteRoleOperator(roleid);
                if (collection.Count > 0)
                {
                    string menuid = "";
                    string buttonid = "";
                    for (int i = 0; i < collection.Count; i++)
                    {
                        string key = collection.Keys[i];
                        string value = collection[i];
                        menuid = key.Split('|')[0];
                        buttonid = key.Split('|')[1];
                        //添加菜单权限 操作权限
                        if (value == "on")
                        {
                            uifo.AddRoleRights(roleid, menuid);
                            uifo.AddRoleOperator(roleid, menuid, buttonid);
                        }
                    }
                }
                ITC_Roles_M model = uifo.GetModel(roleid);
                model.Role_oprt = UserContext.UserName;
                model.Role_createdtime = DateTime.Now;
                uifo.Update(model);
                EventContext.Add(MenuID, string.Format("设置权限:{0}", roleid));
                return Content("保存成功!");
            }
            else
            {
                return Content("参数错误!");
            }
        }
    }
}
