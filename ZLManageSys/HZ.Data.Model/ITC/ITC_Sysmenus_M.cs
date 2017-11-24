using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Serializable]
    public class ITC_Sysmenus_M
    {

        /// <summary>
        /// 菜单ID
        /// </summary>		
        public string Menu_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单名称
        /// </summary>		
        public string Menu_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单说明
        /// </summary>		
        public string Menu_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 图标
        /// </summary>		
        public string Menu_Ico
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单类型
        /// </summary>		
        public string Menu_Type
        {
            get;
            set;
        }
        /// <summary>
        /// 菜单排序
        /// </summary>		
        public int Menu_Order
        {
            get;
            set;
        }
        /// <summary>
        /// URL链接
        /// </summary>		
        public string Menu_Url
        {
            get;
            set;
        }
        /// <summary>
        /// 节点菜单ID
        /// </summary>		
        public string Menu_ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime Menu_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// 操作者
        /// </summary>		
        public string Menu_Oprt
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public int Menu_Status
        {
            get;
            set;
        }

    }
}

