using AFeiDemo.Model;
using System.Collections.Generic;

namespace AFeiDemo.IDAL
{
    public interface IUserRoleDAL
    {
        /// <summary>
        /// 设置用户角色（单个用户）
        /// </summary>
        /// <param name="role_addList">要增加的</param>
        /// <param name="role_deleteList">要删除的</param>
        bool SetRoleSingle(List<UserRoleModel> role_addList, List<UserRoleModel> role_deleteList);

        /// <summary>
        /// 设置用户角色（批量设置）
        /// </summary>
        /// <param name="role_addList">要增加的</param>
        /// <param name="role_deleteList">要删除的</param>
        bool SetRoleBatch(List<UserRoleModel> role_addList, List<UserRoleModel> role_deleteList);
    }
}
