using AFeiDemo.Model;
using System.Collections.Generic;

namespace AFeiDemo.IDAL
{
    public interface IUserDepartmentDAL
    {
        /// <summary>
        /// 设置用户部门（单个用户）
        /// </summary>
        /// <param name="dep_addList">要增加的</param>
        /// <param name="dep_deleteList">要删除的</param>
        bool SetDepartmentSingle(List<UserDepartmentModel> dep_addList, List<UserDepartmentModel> dep_deleteList);

        /// <summary>
        /// 设置用户部门（批量设置）
        /// </summary>
        /// <param name="dep_addList">要增加的</param>
        /// <param name="dep_deleteList">要删除的</param>
        bool SetDepartmentBatch(List<UserDepartmentModel> dep_addList, List<UserDepartmentModel> dep_deleteList);

    }
}
