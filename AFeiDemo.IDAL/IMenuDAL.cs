using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface IMenuDAL
    {
        /// <summary>
        /// 根据用户主键id查询用户可以访问的菜单
        /// </summary>
        DataTable GetUserMenu(int id);

        DataTable GetUserMenuData(int userId, int parentid);

        /// <summary>
        /// 根据条件获取菜单数据
        /// </summary>
        DataTable GetAllMenu(string strwhere);

        /// <summary>
        /// 添加 菜单
        /// </summary>
        int AddMenu(MenuModel menu);

        /// <summary>
        /// 根据菜单名获取菜单
        /// </summary>
        MenuModel GetMenuByName(string name);

        /// <summary>
        /// 修改 菜单
        /// </summary>
        bool EditMenu(MenuModel menu);

        /// <summary>
        /// 删除 菜单
        /// </summary>
        bool DeleteMenu(string id);

        /// <summary>
        /// 根据角色id获取此角色可以访问的菜单（编辑角色-菜单使用）
        /// </summary>
        DataTable GetAllMenu(int roleId);

        /// <summary>
        /// 根据角色id获取此角色可以访问的菜单和菜单下的按钮（编辑角色-菜单使用）
        /// </summary>
        DataTable GetAllMenuButton(int roleId);
    }
}
