using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HZ.Data.Model
{
    /// <summary>
    /// 组织机构
    /// </summary>
    [Serializable]
    public class ITC_Organization_M
    {
        /// <summary>
        /// 组织ID
        /// </summary>		
        public string Orga_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 组织名称
        /// </summary>		
        public string Organization_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人
        /// </summary>		
        public string Organization_Ceo
        {
            get;
            set;
        }
        /// <summary>
        /// 总机
        /// </summary>		
        [DataType(DataType.PhoneNumber)]
        public string Organization_Tel
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人电话
        /// </summary>		
        [DataType(DataType.PhoneNumber)]
        public string Organization_Mobil
        {
            get;
            set;
        }
        /// <summary>
        /// 传真
        /// </summary>		
        public string Organization_Fax
        {
            get;
            set;
        }
        /// <summary>
        /// 邮编区号
        /// </summary>		
        public string Organization_Zip
        {
            get;
            set;
        }
        /// <summary>
        /// 地址
        /// </summary>		
        public string Organization_address
        {
            get;
            set;
        }
        /// <summary>
        /// 上级组织ID
        /// </summary>		
        public string Organization_ParentID
        {
            get;
            set;
        }

        /// <summary>
        /// 组织状态
        /// </summary>		
        public int Organization_Status
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int Organization_Order
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime Organization_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// 创建者
        /// </summary>		
        public string Organization_Oprt
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Organization_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 利家部门代码
        /// </summary>		
        public string Organization_DeptCode
        {
            get;
            set;
        }
        /// <summary>
        /// 部门全称
        /// </summary>		
        public string Organization_FullName
        {
            get;
            set;
        }

    }
}

