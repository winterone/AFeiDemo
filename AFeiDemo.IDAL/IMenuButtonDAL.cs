﻿using System.Data;

namespace AFeiDemo.IDAL
{
    public interface IMenuButtonDAL
    {
        /// <summary>
        /// 分配 菜单按钮
        /// </summary>
        bool SaveMenuButton(string menuid, string buttonids);

        /// <summary>
        /// 根据菜单id查询所有分配的按钮
        /// </summary>
        DataTable GetButtonByMenuId(int menuId);

        bool DelRoleMenuButtonByRoleId(int RoleId);
    }
}
