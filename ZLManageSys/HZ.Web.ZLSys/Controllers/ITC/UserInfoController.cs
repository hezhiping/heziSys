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
    /// 用户管理
    /// </summary>
    public class UserInfoController : ControllerBase
    {
        ITC_Userinfo uifo = new ITC_Userinfo();  
        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            EventContext.Add(MenuID, "进入");
            return View();
        }
        public ActionResult UserPosition()
        {
            return View();
        }
        public ActionResult UserRoles()
        {
            return View();
        }
        //获取数据
        public ActionResult GetDataList(string sw)
        {
            ITC_Organization borg = new ITC_Organization();
            #region pagesl
            var pageIndex = Common.GetPageIndex();
            var pageSize = Common.GetPageSize();
            var total = 0;
            List<ITC_Userinfo_M> list_mo = uifo.GetList(sw, pageIndex, pageSize, out total);
            var list = from f in list_mo
                       select new
                       {
                           Orga_Name = borg.GetOrgaFullName(f.Orga_ID),
                           f.User_Account,
                           User_Createdtime = f.User_Createdtime.ToString("g"),
                           f.User_Email,
                           f.User_ID,
                           f.User_Mobile,
                           f.User_Name,
                           f.User_Oprt,
                           f.User_Pwd,
                           f.User_Remark,
                           User_Sex = Common.GetSex(f.User_Sex),
                           f.User_Spelling,
                           User_Status = Common.GetStatus(f.User_Status),
                           f.User_Tel
                       };
            var page = new PageViewModel { rows = list, total = total };
            return Json(page, JsonRequestBehavior.DenyGet);
            #endregion
        }
        //获取模型
        public ActionResult GetModel(string id)
        {
            ITC_Userinfo_M mo = uifo.GetModel(id);
            return Json(mo, JsonRequestBehavior.AllowGet);
        }
        //添加保存
        public ActionResult SaveAdd(ITC_Userinfo_M model)
        {
            model.User_Createdtime = DateTime.Now;
            model.User_Pwd = uifo.pwEcncrystr("123456");//加密
            model.User_Account = model.User_ID.Trim();
            model.User_Oprt = UserContext.UserName;
            if (!uifo.Exists(model.User_ID))
            {
                if (uifo.Add(model))
                {
                    EventContext.Add(MenuID, string.Format("添加:{0}", model.User_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.User_ID + "]已存在!");
            }
        }
        //编辑保存
        public ActionResult SaveEdit(ITC_Userinfo_M model)
        {
            model.User_Createdtime = DateTime.Now;
            model.User_Account = model.User_ID.Trim();
            model.User_Oprt = UserContext.UserName;
            if (uifo.Exists(model.User_ID))
            {
                if (uifo.Update(model))
                {
                    EventContext.Add(MenuID, string.Format("修改:{0}", model.User_ID));
                    return Content("保存成功!");
                }
                else
                {
                    return Content("保存失败!");
                }
            }
            else
            {
                return Content("保存失败! 编码[" + model.User_ID + "]不存在!");
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
                    //EventContext.Add(MenuID, string.Format("删除:{0}", id));
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
       //保存岗位
        public ActionResult SavePosition(FormCollection collection)
        {
            string userid = Request["userid"];
            if (!string.IsNullOrEmpty(userid))
            {
                //删除岗位 部门范围
                uifo.DeletePosition(userid);
                uifo.DeletePositionRange(userid);
                if (collection.Count > 0)
                {
                    string posid = "";
                    string orgaid = "";
                    for (int i = 0; i < collection.Count; i++)
                    {
                        string key = collection.Keys[i];
                        string value = collection[i];
                        posid = key.Split('|')[0];
                        orgaid = key.Split('|')[1];
                        //添加岗位 部门范围
                        if (value == "on")
                        {
                            uifo.AddPosition(userid, posid);
                            uifo.AddPositionRange(userid, posid, orgaid);
                        }
                    }
                }
                ITC_Userinfo_M model = uifo.GetModel(userid);
                model.User_Oprt = Session["username"].ToString();
                model.User_Createdtime = DateTime.Now;
                uifo.Update(model);
                EventContext.Add(MenuID, string.Format("分配岗位:{0}", userid));
                return Content("保存成功!");
            }
            else
            {
                return Content("参数错误!");
            }
        }

        [HttpPost]
        //保存用户角色
        public ActionResult SaveRoles(FormCollection collection)
        {
            string userid = Request["userid"];
            if (!string.IsNullOrEmpty(userid))
            {
                //删除角色 部门范围
                uifo.DeleteRoles(userid);
                uifo.DeleteRoleRange(userid);
                if (collection.Count > 0)
                {
                    string roleid = "";
                    string orgaid = "";
                    for (int i = 0; i < collection.Count; i++)
                    {
                        string key = collection.Keys[i];
                        string value = collection[i];
                        roleid = key.Split('|')[0];
                        orgaid = key.Split('|')[1];
                        //添加角色 部门范围
                        if (value == "on")
                        {
                            uifo.AddRoles(userid, roleid);
                            uifo.AddRoleRange(userid, roleid, orgaid);
                        }
                    }
                }
                ITC_Userinfo_M model = uifo.GetModel(userid);
                model.User_Oprt = Session["username"].ToString();
                model.User_Createdtime = DateTime.Now;
                uifo.Update(model);
                EventContext.Add(MenuID, string.Format("分配角色:{0}", userid));
                return Content("保存成功!");
            }
            else
            {
                return Content("参数错误!");
            }
        }

        #region 提供下拉数据源
        public ActionResult GetDataList2()
        {
            List<ITC_Userinfo_M> list_mo = uifo.GetList("User_Status=0");
            var list = from f in list_mo
                       orderby f.User_Name
                       select new
                       {
                           f.User_ID,
                           f.User_Name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        ////获取利家档案
        //public ActionResult GetUserModel(string userid)
        //{
        //    EmEmpData bEmp = new EmEmpData();
        //    EmEmpData_M mo = bEmp.GetModel(userid);
        //    return Json(mo, JsonRequestBehavior.AllowGet);
        //}

        //获取组织ID
        public string GetOragID(string deptcode)
        {
            ITC_Organization bOrga = new ITC_Organization();
            return bOrga.GetOrgaIDbyDeptCode(deptcode);
        }
    }
}
