using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// ��λ
    /// </summary>
    public class ITC_Position_M
    {

        /// <summary>
        /// ��λID
        /// </summary>		
        public string Position_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ��λ����
        /// </summary>		
        public string Position_name
        {
            get;
            set;
        }
        /// <summary>
        /// ��λ˵��
        /// </summary>		
        public string Position_remark
        {
            get;
            set;
        }
        /// <summary>
        /// ��λ״̬
        /// </summary>		
        public int Position_status
        {
            get;
            set;
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>		
        public DateTime Position_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string Position_Oprt
        {
            get;
            set;
        }

        /// <summary>
        /// ����
        /// </summary>		
        public int Position_Order
        {
            get;
            set;
        }
    }
}

