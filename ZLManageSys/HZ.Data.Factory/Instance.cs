using System;
using HZ.Data.Interface;
using HZ.Data.DAL;

namespace HZ.Data.Factory
{
    public class DataAccess
    {
        #region 系统管理

        /// <summary>
        /// 操作按扭定义
        /// </summary>
        public static IITC_Buttons CreateITC_Buttons()
        {
            return new ITC_Buttons();

        }
        /// <summary>
        /// 组织机构
        /// </summary>
        public static IITC_Organization CreateITC_Organization()
        {
            return new ITC_Organization();
        }
        /// <summary>
        /// 岗位
        /// </summary>
        public static IITC_Position CreateITC_Position()
        {
            return new ITC_Position();

        }
        /// <summary>
        /// 角色操作权限设置
        /// </summary>
        public static IITC_RoleOperator CreateITC_RoleOperator()
        {
            return new ITC_RoleOperator();
        }
        /// <summary>
        /// 角色菜单权限设置
        /// </summary>
        public static IITC_RoleRights CreateITC_RoleRights()
        {
            return new ITC_RoleRights();
        }
        /// <summary>
        /// 角色
        /// </summary>
        public static IITC_Roles CreateITC_Roles()
        {
            return new ITC_Roles();
        }      
        /// <summary>
        /// 系统日志
        /// </summary>
        public static IITC_SysEvent CreateITC_SysEvent()
        {
            return new ITC_SysEvent();
        }
        /// <summary>
        /// 菜单
        /// </summary>
        public static IITC_Sysmenus CreateITC_Sysmenus()
        {
            return new ITC_Sysmenus();
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        public static IITC_Userinfo CreateITC_Userinfo()
        {
            return new ITC_Userinfo();
        }
        #endregion


        #region 基础数据字典

        /// <summary>
        /// 生产线数据字典
        /// </summary>
        public static IBaseInfo_Scx CreateBaseInfo_Scx()
        {
            return new BaseInfo_Scx_D();
        }

        #endregion
    }
}
