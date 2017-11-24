using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZ.Web
{
    public class Assemble
    {
    }

    /// <summary>
    /// Session键
    /// </summary>
    public enum SessionKeys
    {
        UserID,    //用户ID
        UserName,  //用户名        
        OrgaID,    //用户所属组织ID
        Power,     //用户权限列表
        Orgas,     //用户组织列表
        //DeptCode,  //用户所属于利家部门
        //EmpID,     //员工ID
        //UserToken, //用户Token
    }

    /// <summary>
    /// Cache键
    /// </summary>
    public enum CacheKeys
    {
        Menus,     //菜单
        Orgas,     //组织
        Items,     //物料
        Suprs,     //供应商
        ItemJson,  //物料json
        Months,    //预算月份
        //ItemNTs,   //物料自然类型
        UOM,       //单位
        Acct,      //会计科目
    }

    /// <summary>
    /// 操作按扭
    /// </summary>
    public enum ButtonKeys
    {
        QUERY = 0,
        ADD = 1,
        MODIFY = 2,
        DELETE = 3,
        EXPORT = 4,
        PRINT = 5,
        ADMIT = 6,
    }  
}
