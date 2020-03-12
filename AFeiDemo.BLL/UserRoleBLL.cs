﻿using AFeiDemo.DAL;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace AFeiDemo.BLL
{
    public class UserRoleBLL
    {
        IUserRoleDAL dal = DALFactory.GetUserRoleDAL();

        /// <summary>
        /// 设置用户角色（单个用户）
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="roleIds">角色id，多个逗号隔开</param>
        public bool SetRoleSingle(int userId, string roleIds)
        {
            DataTable dt_user_role_old = new RoleBLL().GetRoleByUserId(userId);  //用户之前拥有的角色
            List<UserRoleModel> role_addList = new List<UserRoleModel>();     //需要插入角色的sql语句集合
            List<UserRoleModel> role_deleteList = new List<UserRoleModel>();     //需要删除角色的sql语句集合

            string[] str_role = roleIds.Trim(',').Split(',');    //传过来用户勾选的角色（有去勾的也有新勾选的）

            UserRoleModel userroledelete = null;
            UserRoleModel userroleadd = null;
            //用户去掉勾选的角色（要删除本用户的角色）
            for (int i = 0; i < dt_user_role_old.Rows.Count; i++)
            {
                //等于-1说明用户去掉勾选了某个角色 需要删除
                if (Array.IndexOf(str_role, dt_user_role_old.Rows[i]["roleid"].ToString()) == -1)
                {
                    userroledelete = new UserRoleModel();
                    userroledelete.RoleId = Convert.ToInt32(dt_user_role_old.Rows[i]["roleid"].ToString());
                    userroledelete.UserId = userId;
                    role_deleteList.Add(userroledelete);
                }
            }

            //用户新勾选的角色（要添加本用户的角色）
            if (!string.IsNullOrEmpty(roleIds))
            {
                for (int j = 0; j < str_role.Length; j++)
                {
                    //等于0那么原来的角色没有 是用户新勾选的
                    if (dt_user_role_old.Select("roleid = '" + str_role[j] + "'").Length == 0)
                    {
                        userroleadd = new UserRoleModel();
                        userroleadd.UserId = userId;
                        userroleadd.RoleId = Convert.ToInt32(str_role[j]);
                        role_addList.Add(userroleadd);
                    }
                }
            }
            if (role_addList.Count == 0 && role_deleteList.Count == 0)
                return true;
            else
                return dal.SetRoleSingle(role_addList, role_deleteList);
        }

        /// <summary>
        /// 设置用户角色（批量设置）
        /// </summary>
        /// <param name="userIds">用户主键，多个逗号隔开</param>
        /// <param name="roleIds">角色id，多个逗号隔开</param>
        public bool SetRoleBatch(string userIds, string roleIds)
        {
            List<UserRoleModel> role_addList = new List<UserRoleModel>();     //需要插入角色的sql语句集合
            List<UserRoleModel> role_deleteList = new List<UserRoleModel>();     //需要删除角色的sql语句集合
            string[] str_userid = userIds.Trim(',').Split(',');
            string[] str_role = roleIds.Trim(',').Split(',');

            UserRoleModel userroledelete = null;
            UserRoleModel userroleadd = null;
            for (int i = 0; i < str_userid.Length; i++)
            {
                //批量设置先删除当前用户的所有角色
                userroledelete = new UserRoleModel();
                userroledelete.UserId = Convert.ToInt32(str_userid[i]);
                role_deleteList.Add(userroledelete);

                if (!string.IsNullOrEmpty(roleIds))
                {
                    //再添加设置的角色
                    for (int j = 0; j < str_role.Length; j++)
                    {
                        userroleadd = new UserRoleModel();
                        userroleadd.UserId = Convert.ToInt32(str_userid[i]);
                        userroleadd.RoleId = Convert.ToInt32(str_role[j]);
                        role_addList.Add(userroleadd);
                    }
                }
            }
            return dal.SetRoleBatch(role_addList, role_deleteList);
        }
    }
}
