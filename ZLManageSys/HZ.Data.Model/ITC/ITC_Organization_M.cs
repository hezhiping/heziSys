using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HZ.Data.Model
{
    /// <summary>
    /// ��֯����
    /// </summary>
    [Serializable]
    public class ITC_Organization_M
    {
        /// <summary>
        /// ��֯ID
        /// </summary>		
        public string Orga_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ��֯����
        /// </summary>		
        public string Organization_Name
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string Organization_Ceo
        {
            get;
            set;
        }
        /// <summary>
        /// �ܻ�
        /// </summary>		
        [DataType(DataType.PhoneNumber)]
        public string Organization_Tel
        {
            get;
            set;
        }
        /// <summary>
        /// �����˵绰
        /// </summary>		
        [DataType(DataType.PhoneNumber)]
        public string Organization_Mobil
        {
            get;
            set;
        }
        /// <summary>
        /// ����
        /// </summary>		
        public string Organization_Fax
        {
            get;
            set;
        }
        /// <summary>
        /// �ʱ�����
        /// </summary>		
        public string Organization_Zip
        {
            get;
            set;
        }
        /// <summary>
        /// ��ַ
        /// </summary>		
        public string Organization_address
        {
            get;
            set;
        }
        /// <summary>
        /// �ϼ���֯ID
        /// </summary>		
        public string Organization_ParentID
        {
            get;
            set;
        }

        /// <summary>
        /// ��֯״̬
        /// </summary>		
        public int Organization_Status
        {
            get;
            set;
        }
        /// <summary>
        /// ����
        /// </summary>		
        public int Organization_Order
        {
            get;
            set;
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>		
        public DateTime Organization_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string Organization_Oprt
        {
            get;
            set;
        }
        /// <summary>
        /// ��ע
        /// </summary>		
        public string Organization_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// ���Ҳ��Ŵ���
        /// </summary>		
        public string Organization_DeptCode
        {
            get;
            set;
        }
        /// <summary>
        /// ����ȫ��
        /// </summary>		
        public string Organization_FullName
        {
            get;
            set;
        }

    }
}

