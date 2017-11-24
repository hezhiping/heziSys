using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class ITC_Position_M
    {

        /// <summary>
        /// 岗位ID
        /// </summary>		
        public string Position_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 岗位名称
        /// </summary>		
        public string Position_name
        {
            get;
            set;
        }
        /// <summary>
        /// 岗位说明
        /// </summary>		
        public string Position_remark
        {
            get;
            set;
        }
        /// <summary>
        /// 岗位状态
        /// </summary>		
        public int Position_status
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime Position_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// 操作者
        /// </summary>		
        public string Position_Oprt
        {
            get;
            set;
        }

        /// <summary>
        /// 排序
        /// </summary>		
        public int Position_Order
        {
            get;
            set;
        }
    }
}

