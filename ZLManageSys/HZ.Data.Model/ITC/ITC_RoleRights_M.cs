using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 角色菜单权限设置
    /// </summary>
    [Serializable]
    public class ITC_RoleRights_M
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
        /// 状态
        /// </summary>		
        public int Roleright_Status
        {
            get;
            set;
        }

    }
}

