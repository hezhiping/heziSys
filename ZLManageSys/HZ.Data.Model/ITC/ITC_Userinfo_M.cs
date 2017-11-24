using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HZ.Data.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class ITC_Userinfo_M
    {

        /// <summary>
        ///  用户ID
        /// </summary>		
        public string User_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 组织ID
        /// </summary>		
        public string Orga_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户账号
        /// </summary>		
        public string User_Account
        {
            get;
            set;
        }
        /// <summary>
        /// 用户密码
        /// </summary>		
        public string User_Pwd
        {
            get;
            set;
        }
        /// <summary>
        /// 用户名称
        /// </summary>		
        public string User_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 用户名称拼写
        /// </summary>		
        public string User_Spelling
        {
            get;
            set;
        }
        /// <summary>
        /// 用户性别
        /// </summary>		
        public bool User_Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 用户邮箱
        /// </summary>		
        public string User_Email
        {
            get;
            set;
        }
        /// <summary>
        /// 用户电话
        /// </summary>		
        public string User_Tel
        {
            get;
            set;
        }
        /// <summary>
        /// 用户移动
        /// </summary>		
        public string User_Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime User_Createdtime
        {
            get;
            set;
        }
        /// <summary>
        /// 用户状态
        /// </summary>		
        public int User_Status
        {
            get;
            set;
        }
        /// <summary>
        /// 操作者
        /// </summary>		
        public string User_Oprt
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        public string User_Remark
        {
            get;
            set;
        }

    }
}

