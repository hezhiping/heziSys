using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZ.Web
{
    public class Common
    {
        public Common()
        { }

        #region 状态转换
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static string GetStatus(int Status)
        {
            string str = "";
            switch (Status)
            {
                case 0:
                    str = "正常";
                    break;
                case 1:
                    str = "冻结";
                    break;
                default:
                    break;
            }
            return str;
        }
        public static int iStatus(string Status)
        {
            int i = 0;
            switch (Status)
            {
                case "正常":
                    i = 0;
                    break;
                case "冻结":
                    i = 1;
                    break;
                default:
                    break;
            }
            return i;
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string GetSex(bool sex)
        {
            string str = "";
            switch (sex)
            {
                case true:
                    str = "男";
                    break;
                case false:
                    str = "女";
                    break;
                default:
                    break;
            }
            return str;
        }
        public static bool bSex(string sex)
        {
            bool b = true;
            switch (sex)
            {
                case "女":
                    b = true;
                    break;
                case "男":
                    b = false;
                    break;
                default:
                    break;
            }
            return b;
        }

        /// <summary>
        /// 获取是否
        /// </summary>
        /// <param name="YesNo"></param>
        /// <returns></returns>
        public static string GetYesNo(int YesNo)
        {
            string str = "";
            switch (YesNo)
            {
                case 1:
                    str = "是";
                    break;
                case 0:
                    str = "否";
                    break;
                default:
                    break;
            }
            return str;
        }
        public static int iYesNo(string sex)
        {
            int i = 0;
            switch (sex)
            {
                case "是":
                    i = 1;
                    break;
                case "否":
                    i = 0;
                    break;
                default:
                    break;
            }
            return i;
        }
        #endregion

        #region 获取easyui页码\页大小\排序
        public static int GetPageIndex()
        {
            return System.Web.HttpContext.Current.Request["page"] == null ? 1 : int.Parse(System.Web.HttpContext.Current.Request["page"]);
        }
        public static int GetPageSize()
        {
            return System.Web.HttpContext.Current.Request["rows"] == null ? 15 : int.Parse(System.Web.HttpContext.Current.Request["rows"]);
        }
        public static string GetSortField()
        {
            return System.Web.HttpContext.Current.Request["sort"];
        }
        public static string GetSortOrder()
        {
            return System.Web.HttpContext.Current.Request["order"];
        }
        #endregion
    }
}
