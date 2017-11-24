using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 角色操作权限设置
    /// </summary>
    [Serializable]
    public class ITC_RoleOperator_M
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
        /// 菜单ID
        /// </summary>		
        public string Menu_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 操作ID
        /// </summary>		
        public string Buttons_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime RoleOperator_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public int RoleOperator_Status
        {
            get;
            set;
        }
        /// <summary>
        /// 操作者
        /// </summary>		
        public string RoleOperator_oprt
        {
            get;
            set;
        }

    }
}

