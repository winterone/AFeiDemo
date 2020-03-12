﻿using AFeiDemo.Common;
using AFeiDemo.DAL;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System.Data;
using System.Text;

namespace AFeiDemo.BLL
{
    public class DepartmentBLL
    {
        IDepartmentDAL dal = DALFactory.GetDepartmentDAL();


        /// <summary>
        /// 根据用户id获取用户部门
        /// </summary>
        public DataTable GetDepartmentByUserId(int id)
        {
            return dal.GetDepartmentByUserId(id);
        }

        /// <summary>
        /// 根据条件获取部门
        /// </summary>
        public string GetAllDepartment(string where)
        {
            DataTable dt = dal.GetAllDepartment(where);
            StringBuilder str = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                str.Append(Recursion(dt, 0));
                str = str.Remove(str.Length - 2, 2);
            }
            return str.ToString();
        }

        //递归方法
        private string Recursion(DataTable dt, object parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            DataRow[] rows = dt.Select("ParentId = " + parentId);
            if (rows.Length > 0)
            {
                sbJson.Append("[");
                for (int i = 0; i < rows.Length; i++)
                {
                    string childString = Recursion(dt, rows[i]["id"]);
                    if (!string.IsNullOrEmpty(childString))
                    {
                        //comboTree必须设置【id】和【text】，一个是id一个是显示值
                        sbJson.Append("{\"id\":\"" + rows[i]["Id"].ToString() + "\",\"ParentId\":\"" + rows[i]["ParentId"].ToString() + "\",\"Sort\":\"" + rows[i]["Sort"].ToString() + "\",\"UpdateBy\":\"" + rows[i]["UpdateBy"].ToString() + "\",\"UpdateTime\":\"" + rows[i]["UpdateTime"].ToString() + "\",\"text\":\"" + rows[i]["DepartmentName"].ToString() + "\",\"children\":");
                        sbJson.Append(childString);
                    }
                    else
                        sbJson.Append("{\"id\":\"" + rows[i]["Id"].ToString() + "\",\"ParentId\":\"" + rows[i]["ParentId"].ToString() + "\",\"Sort\":\"" + rows[i]["Sort"].ToString() + "\",\"UpdateBy\":\"" + rows[i]["UpdateBy"].ToString() + "\",\"UpdateTime\":\"" + rows[i]["UpdateTime"].ToString() + "\",\"text\":\"" + rows[i]["DepartmentName"].ToString() + "\"},");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]},");
            }
            return sbJson.ToString();
        }

        /// <summary>
        /// 获取部门下的用户（分页）
        /// </summary>
        public string GetPagerDepartmentUser(string departmentIds, string order, int pageSize, int pageIndex)
        {
            if (SqlInjection.GetString(departmentIds))   //简单sql防注入
                departmentIds = "";
            if (SqlInjection.GetString(order))
                order = "CreateTime asc";
            int totalCount = dal.GetDepartmentUserCount(departmentIds);
            DataTable dt = dal.GetPagerDepartmentUser(departmentIds, order, pageSize, pageIndex);

            string strjson = JsonHelper.ToJson(dt);
            return "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strjson + "}";
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        public int AddDepartment(DepartmentModel department)
        {
            return dal.AddDepartment(department);
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        public bool EditDepartment(DepartmentModel department)
        {
            return dal.EditDepartment(department);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        public bool DeleteDepartment(string departmentIds)
        {
            return dal.DeleteDepartment(departmentIds);
        }
    }
}
