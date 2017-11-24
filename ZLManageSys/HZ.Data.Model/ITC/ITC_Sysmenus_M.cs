using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// �˵�
    /// </summary>
    [Serializable]
    public class ITC_Sysmenus_M
    {

        /// <summary>
        /// �˵�ID
        /// </summary>		
        public string Menu_ID
        {
            get;
            set;
        }
        /// <summary>
        /// �˵�����
        /// </summary>		
        public string Menu_Name
        {
            get;
            set;
        }
        /// <summary>
        /// �˵�˵��
        /// </summary>		
        public string Menu_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// ͼ��
        /// </summary>		
        public string Menu_Ico
        {
            get;
            set;
        }
        /// <summary>
        /// �˵�����
        /// </summary>		
        public string Menu_Type
        {
            get;
            set;
        }
        /// <summary>
        /// �˵�����
        /// </summary>		
        public int Menu_Order
        {
            get;
            set;
        }
        /// <summary>
        /// URL����
        /// </summary>		
        public string Menu_Url
        {
            get;
            set;
        }
        /// <summary>
        /// �ڵ�˵�ID
        /// </summary>		
        public string Menu_ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>		
        public DateTime Menu_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string Menu_Oprt
        {
            get;
            set;
        }
        /// <summary>
        /// ״̬
        /// </summary>		
        public int Menu_Status
        {
            get;
            set;
        }

    }
}

