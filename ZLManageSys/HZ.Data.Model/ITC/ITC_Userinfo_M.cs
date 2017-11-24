using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// �û���Ϣ
    /// </summary>
    [Serializable]
    public class ITC_Userinfo_M
    {

        /// <summary>
        ///  �û�ID
        /// </summary>		
        public string User_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ��֯ID
        /// </summary>		
        public string Orga_ID
        {
            get;
            set;
        }
        /// <summary>
        /// �û��˺�
        /// </summary>		
        public string User_Account
        {
            get;
            set;
        }
        /// <summary>
        /// �û�����
        /// </summary>		
        public string User_Pwd
        {
            get;
            set;
        }
        /// <summary>
        /// �û�����
        /// </summary>		
        public string User_Name
        {
            get;
            set;
        }
        /// <summary>
        /// �û�����ƴд
        /// </summary>		
        public string User_Spelling
        {
            get;
            set;
        }
        /// <summary>
        /// �û��Ա�
        /// </summary>		
        public bool User_Sex
        {
            get;
            set;
        }
        /// <summary>
        /// �û�����
        /// </summary>		
        public string User_Email
        {
            get;
            set;
        }
        /// <summary>
        /// �û��绰
        /// </summary>		
        public string User_Tel
        {
            get;
            set;
        }
        /// <summary>
        /// �û��ƶ�
        /// </summary>		
        public string User_Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// ��������
        /// </summary>		
        public DateTime User_Createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// �û�״̬
        /// </summary>		
        public int User_Status
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>		
        public string User_Oprt
        {
            get;
            set;
        }
        /// <summary>
        /// ��ע
        /// </summary>		
        public string User_Remark
        {
            get;
            set;
        }

    }
}

