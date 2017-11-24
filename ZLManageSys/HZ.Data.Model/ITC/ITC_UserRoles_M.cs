using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Serializable]
    public class ITC_UserRoles_M
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
        /// 角色ID
        /// </summary>		
        public string Role_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public int Role_Status
        {
            get;
            set;
        }

    }
}

