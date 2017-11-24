using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HZ.Data.Model;
using HZ.Data.BLL;

namespace HZ.Web.HZ.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            //ViewBag.Pwd = HZ.Utility.DESEncrypt.Encrypt("123456");
            return View();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DL(ITC_Userinfo_M model)
        {
           
            if (!string.IsNullOrEmpty(model.User_ID) && !string.IsNullOrEmpty(model.User_Pwd))
            {
                ITC_Userinfo bll = new ITC_Userinfo();
                model.User_Pwd = bll.pwEcncrystr(model.User_Pwd);
                if (bll.Exists(model.User_ID, model.User_Pwd))
                {
                    UserContext.Init(model.User_ID);
                    //设置登录cookie，名称为：SdlCookie
                    HttpCookie SdlCookie = new HttpCookie("SdlCookie");
                    //EmpNo:登录工号
                    SdlCookie["EmpNo"] = UserContext.UserID;
                    //EmpName:姓名
                    SdlCookie["EmpName"] = System.Web.HttpContext.Current.Server.UrlEncode(UserContext.UserName);
                    //LastLoginTime:上次登录日期
                    //LastLoginIP:上次登录IP
                    if (false)
                    {
                        //SdlCookie["LastLoginTime"] = model_log_last.Entry.ToString();
                        //SdlCookie["LastLoginIP"] = model_log_last.IP;
                    }
                    else
                    {
                        SdlCookie["LastLoginTime"] = "";
                        SdlCookie["LastLoginIP"] = "";
                    }
                    System.Web.HttpContext.Current.Response.Cookies.Add(SdlCookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "帐号和密码不正确！请重新输入！";
                    ViewBag.SysName = "盒子系统";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.message = "请输入帐号和密码！";
                ViewBag.SysName = "盒子系统";
                return View("Index");
            }

        }

    }
}
