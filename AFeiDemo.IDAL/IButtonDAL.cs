using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface IButtonDAL
    {
        /// <summary>
        /// 根据菜单标识码和用户id获取此用户拥有该菜单下的哪些按钮权限
        /// </summary>
        DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId);

        /// <summary>
        /// 根据按钮名获取按钮
        /// </summary>
        ButtonModel GetButtonByButtonName(string ButtonName);

        /// <summary>
        /// 添加 按钮
        /// </summary>
        int AddButton(ButtonModel button);

        /// <summary>
        /// 修改 按钮
        /// </summary>
        bool EditButton(ButtonModel button);

        /// <summary>
        /// 删除 按钮
        /// </summary>
        bool DeleteButton(string id);

        /// <summary>
        /// 根据条件获取 按钮
        /// </summary>
        DataTable GetAllButton(string where);
    }
}
