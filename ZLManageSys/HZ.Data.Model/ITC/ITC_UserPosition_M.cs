using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 用户岗位
    /// </summary>
    [Serializable]
    public class ITC_UserPosition_M
    {

        /// <summary>
        /// 用户ID
        /// </summary>		
        public string User_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 岗位ID
        /// </summary>		
        public string Position_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 是否全职或兼职
        /// </summary>		
        public int IsFullTime
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public int Postion_Status
        {
            get;
            set;
        }

    }
}

