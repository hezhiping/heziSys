using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// �û���ɫ
    /// </summary>
    [Serializable]
    public class ITC_UserRoles_M
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
        /// ��ɫID
        /// </summary>		
        public string Role_ID
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

    }
}

