using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZ.Data.Model
{
    [Serializable]
    public class ModelBase
    {
        public ModelBase()
        {
            //初始化默认操作者与时间
            if (System.Web.HttpContext.Current.Session["UserID"] != null)
            {
                CurrUserID = System.Web.HttpContext.Current.Session["UserID"].ToString();
            }
            else
            {
                CurrUserID = "";
            }
            if (System.Web.HttpContext.Current.Session["UserName"] != null)
            {
                CurrUserName = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            else
            {
                CurrUserName = "";
            }
            NowDateTime = DateTime.Now;
        }
        public virtual string CurrUserID { get; set; }
        public virtual string CurrUserName { get; set; }
        public virtual DateTime NowDateTime { get; set; }
    }
}
