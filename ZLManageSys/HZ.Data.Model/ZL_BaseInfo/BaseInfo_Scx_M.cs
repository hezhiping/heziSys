using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZ.Data.Model
{
    /// <summary>
    /// 基础数据_生产线数据字典Model
    /// </summary>
    [Serializable]
    public class BaseInfo_Scx_M
    {
        /// <summary>
        /// 生产线序号自增
        /// </summary>		
        public int ScxID
        {
            get;
            set;
        }
        /// <summary>
        /// 生产线编码
        /// </summary>		
        public string ScxCode
        {
            get;
            set;
        }
        /// <summary>
        /// 生产线名称
        /// </summary>		
        public string ScxName
        {
            get;
            set;
        }
        /// <summary>
        /// 工厂
        /// </summary>		
        public string Fct
        {
            get;
            set;
        }
        /// <summary>
        /// 单位人力值
        /// </summary>		
        public decimal WorkCast
        {
            get;
            set;
        }
        /// <summary>
        /// 币种
        /// </summary>	
        public string Currency
        {
            get;
            set;
        }
        /// <summary>
        /// 操作者
        /// </summary>		
        public string UpName
        {
            get;
            set;
        }
        /// <summary>
        /// 操作时间
        /// </summary>		
        public DateTime? UpTime
        {
            get;
            set;
        }
        /// <summary>
        /// 删除标识
        /// </summary>		
        public int Del
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public int State
        {
            get;
            set;
        }        

    }
}
