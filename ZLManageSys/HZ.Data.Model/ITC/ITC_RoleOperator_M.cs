using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// ��ɫ����Ȩ������
    /// </summary>
    [Serializable]
    public class ITC_RoleOperator_M
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
        /// �˵�ID
        /// </summary>		
        public string Menu_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ����ID
        /// </summary>		
        public string Buttons_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>		
        public DateTime RoleOperator_createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// ״̬
        /// </summary>		
        public int RoleOperator_Status
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string RoleOperator_oprt
        {
            get;
            set;
        }

    }
}

