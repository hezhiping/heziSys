using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 系统日志
    /// </summary>
    [Serializable]
    public class ITC_SysEvent_M
    {
        /// <summary>
        /// ID
        /// </summary>		
        public int E_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public string User_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户IP
        /// </summary>		
        public string E_IP
        {
            get;
            set;
        }
        /// <summary>
        /// 操作页面
        /// </summary>		
        public string E_Form
        {
            get;
            set;
        }
        /// <summary>
        /// 操作页面名称
        /// </summary>		
        public string E_Appname
        {
            get;
            set;
        }
        /// <summary>
        /// 操作内容
        /// </summary>		
        public string E_Record
        {
            get;
            set;
        }
        /// <summary>
        /// 记录时间
        /// </summary>		
        public DateTime E_Datetime
        {
            get;
            set;
        }

        /// <summary>
        /// 用户ID
        /// </summary>		
        public string User_Name
        {
            get;
            set;
        }
    }
}

