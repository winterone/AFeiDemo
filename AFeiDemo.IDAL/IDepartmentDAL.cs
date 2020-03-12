using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface IDepartmentDAL
    {
        /// <summary>
        /// 根据用户id获取用户部门
        /// </summary>
        DataTable GetDepartmentByUserId(int id);

        /// <summary>
        /// 根据条件获取部门
        /// </summary>
        DataTable GetAllDepartment(string where);

        /// <summary>
        /// 获取部门下的用户个数
        /// </summary>
        int GetDepartmentUserCount(string departmentIds);

        /// <summary>
        /// 获取部门下的用户（分页）
        /// </summary>
        DataTable GetPagerDepartmentUser(string departmentIds, string order, int pageSize, int pageIndex);

        /// <summary>
        /// 添加部门
        /// </summary>
        int AddDepartment(DepartmentModel department);

        /// <summary>
        /// 修改部门
        /// </summary>
        bool EditDepartment(DepartmentModel department);

        /// <summary>
        /// 删除部门
        /// </summary>
        bool DeleteDepartment(string departmentIds);
    }
}
