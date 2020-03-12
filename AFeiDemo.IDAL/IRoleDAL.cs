using AFeiDemo.Model;
using System.Collections.Generic;
using System.Data;

namespace AFeiDemo.IDAL
{
    /// <summary>
    /// 角色接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IRoleDAL
    {
        /// <summary>
        /// 根据用户id获取用户角色
        /// </summary>
        DataTable GetRoleByUserId(int id);

        /// <summary>
        /// 根据条件获取角色
        /// </summary>
        DataTable GetAllRole(string where);

        /// <summary>
        /// 根据角色名获取角色
        /// </summary>
        RoleModel GetRoleByRoleName(string roleName);

        /// <summary>
        /// 添加角色
        /// </summary>
        int AddRole(RoleModel role);

        /// <summary>
        /// 修改角色
        /// </summary>
        bool EditRole(RoleModel role);

        /// <summary>
        /// 删除角色（删除角色同时删除对应的：用户角色/角色菜单按钮【即权限】）
        /// </summary>
        bool DeleteRole(int id);

        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="roleId">要授权的角色Id</param>
        /// <param name="menuIds">菜单按钮Id 格式：1,2,3 </param>
        bool SetRoleMenu(int roleId, string menuIds);

        /// <summary>
        /// 获取权限下的用户个数
        /// </summary>
        int GetRoleUserCount(int roleId);

        /// <summary>
        /// 获取权限下的用户（分页）
        /// </summary>
        DataTable GetPagerRoleUser(int roleId, string order, int pageSize, int pageIndex);

        /// <summary>
        /// 角色授权
        /// </summary>
        bool Authorize(List<RoleMenuButtonModel> addlist);
    }
}
