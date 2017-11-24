using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// ϵͳ��־
    /// </summary>
    [Serializable]
    public class ITC_SysEvent_M
    {
        /// <summary>
        /// ID
        /// </summary>		
        public int E_ID
        {
            get;
            set;
        }
        /// <summary>
        /// �û�ID
        /// </summary>		
        public string User_ID
        {
            get;
            set;
        }
        /// <summary>
        /// �û�IP
        /// </summary>		
        public string E_IP
        {
            get;
            set;
        }
        /// <summary>
        /// ����ҳ��
        /// </summary>		
        public string E_Form
        {
            get;
            set;
        }
        /// <summary>
        /// ����ҳ������
        /// </summary>		
        public string E_Appname
        {
            get;
            set;
        }
        /// <summary>
        /// ��������
        /// </summary>		
        public string E_Record
        {
            get;
            set;
        }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>		
        public DateTime E_Datetime
        {
            get;
            set;
        }

        /// <summary>
        /// �û�ID
        /// </summary>		
        public string User_Name
        {
            get;
            set;
        }
    }
}

