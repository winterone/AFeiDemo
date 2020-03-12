using AFeiDemo.Model;

namespace AFeiDemo.IDAL
{
    /// <summary>
    /// 用户接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IUserDAL
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        UserModel UserLogin(string loginId, string loginPwd);

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        UserModel GetUserById(string id);

        /// <summary>
        /// 修改密码
        /// </summary>
        bool ChangePwd(UserModel user);

        /// <summary>
        /// 根据用户id获取用户
        /// </summary>
        UserModel GetUserByUserId(string userId);

        /// <summary>
        /// 添加用户
        /// </summary>
        int AddUser(UserModel user);

        /// <summary>
        /// 修改用户
        /// </summary>
        bool EditUser(UserModel user);

        /// <summary>
        /// 删除用户（可批量删除，删除用户同时删除对应的：角色/权限/部门）
        /// </summary>
        bool DeleteUser(string idList);
    }
}
