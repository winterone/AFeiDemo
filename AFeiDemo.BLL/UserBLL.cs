using AFeiDemo.Common;
using AFeiDemo.DAL;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System;
using System.Data;

namespace AFeiDemo.BLL
{
    public class UserBLL
    {
        IUserDAL dal = DALFactory.GetUserDAL();

        /// <summary>
        /// 用户登录
        /// </summary>
        public UserModel UserLogin(string loginId, string loginPwd)
        {
            return dal.UserLogin(loginId, loginPwd);
        }

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        public UserModel GetUserById(string id)
        {
            return dal.GetUserById(id);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public bool ChangePwd(UserModel user)
        {
            return dal.ChangePwd(user);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">要取的列名（逗号分开）</param>
        /// <param name="order">排序</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public string GetPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            dt.Columns.Add(new DataColumn("UserRoleId"));
            dt.Columns.Add(new DataColumn("UserRole"));
            dt.Columns.Add(new DataColumn("UserDepartmentId"));
            dt.Columns.Add(new DataColumn("UserDepartment"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dtrole = new RoleBLL().GetRoleByUserId(Convert.ToInt32(dt.Rows[i]["ID"]));
                DataTable dtdepartment = new DepartmentBLL().GetDepartmentByUserId(Convert.ToInt32(dt.Rows[i]["ID"]));
                dt.Rows[i]["UserRoleId"] = JsonHelper.ColumnToJson(dtrole, 0);
                dt.Rows[i]["UserRole"] = JsonHelper.ColumnToJson(dtrole, 1);
                dt.Rows[i]["UserDepartmentId"] = JsonHelper.ColumnToJson(dtdepartment, 0);
                dt.Rows[i]["UserDepartment"] = JsonHelper.ColumnToJson(dtdepartment, 1);
            }
            return JsonHelper.ToJson(dt);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public int AddUser(UserModel user)
        {
            UserModel userCompare = dal.GetUserByUserId(user.AccountName);
            if (userCompare != null)
            {
                throw new Exception("已经存在此用户！");
            }
            return dal.AddUser(user);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public bool EditUser(UserModel user, string originalName)
        {
            if (user.AccountName != originalName && dal.GetUserByUserId(user.AccountName) != null)
            {
                throw new Exception("已经存在此用户！");
            }
            return dal.EditUser(user);
        }

        /// <summary>
        /// 删除用户（可批量删除，删除用户同时删除对应的权限和所处的部门）
        /// </summary>
        public bool DeleteUser(string idList)
        {
            return dal.DeleteUser(idList);
        }
    }
}
