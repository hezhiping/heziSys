using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// ������Ť����
    /// </summary>
    [Serializable]
    public class ITC_Buttons_M
    {

        /// <summary>
        /// ����ID
        /// </summary>		
        public string Buttons_ID
        {
            get;
            set;
        }
        /// <summary>
        /// ��������
        /// </summary>		
        public string Buttons_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// ����˵��
        /// </summary>		
        public string Buttons_Remark
        {
            get;
            set;
        }
        /// <summary>
        /// ����ͼ��
        /// </summary>		
        public string Buttons_Img
        {
            get;
            set;
        }
        /// <summary>
        /// ����״̬
        /// </summary>		
        public int Buttons_Status
        {
            get;
            set;
        }

    }
}

