using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// �û���λ
    /// </summary>
    [Serializable]
    public class ITC_UserPosition_M
    {

        /// <summary>
        /// �û�ID
        /// </summary>		
        public string User_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ��λID
        /// </summary>		
        public string Position_ID
        {
            get;
            set;
        }
        /// <summary>
        /// �Ƿ�ȫְ���ְ
        /// </summary>		
        public int IsFullTime
        {
            get;
            set;
        }
        /// <summary>
        /// ״̬
        /// </summary>		
        public int Postion_Status
        {
            get;
            set;
        }

    }
}

