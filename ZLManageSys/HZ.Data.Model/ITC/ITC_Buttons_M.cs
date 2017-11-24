using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 操作按扭定义
    /// </summary>
    [Serializable]
    public class ITC_Buttons_M
    {

        /// <summary>
        /// 操作ID
        /// </summary>		
        public string Buttons_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 操作名称
        /// </summary>		
        public string Buttons_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 操作说明
        /// </summary>		
        public string Buttons_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 操作图标
        /// </summary>		
        public string Buttons_Img
        {
            get;
            set;
        }
        /// <summary>
        /// 操作状态
        /// </summary>		
        public int Buttons_Status
        {
            get;
            set;
        }

    }
}

