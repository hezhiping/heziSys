using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 角色
    /// </summary>
    [Serializable]
    public class ITC_Roles_M
    {

        /// <summary>
        /// 角色ID
        /// </summary>		
        public string Role_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 角色名称
        /// </summary>		
        public string Role_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Role_Remark
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
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime Role_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// 操作者
        /// </summary>		
        public string Role_oprt
        {
            get;
            set;
        }
    }
}

