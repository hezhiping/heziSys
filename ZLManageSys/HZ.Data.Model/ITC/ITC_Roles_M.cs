using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// ��ɫ
    /// </summary>
    [Serializable]
    public class ITC_Roles_M
    {

        /// <summary>
        /// ��ɫID
        /// </summary>		
        public string Role_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ��ɫ����
        /// </summary>		
        public string Role_Name
        {
            get;
            set;
        }
        /// <summary>
        /// ����
        /// </summary>		
        public string Role_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// ״̬
        /// </summary>		
        public int Role_Status
        {
            get;
            set;
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>		
        public DateTime Role_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string Role_oprt
        {
            get;
            set;
        }
    }
}

