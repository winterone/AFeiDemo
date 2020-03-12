using AFeiDemo.Common;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AFeiDemo.DAL
{
    /// <summary>
    /// 用户（SQL Server数据库实现）
    /// </summary>
    public class UserDAL : IUserDAL
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        public UserModel UserLogin(string loginId, string loginPwd)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select top 1 ID,AccountName,[Password],RealName,MobilePhone,Email,IsAble,IfChangePwd,[Description],CreateTime,CreateBy,UpdateTime,UpdateBy from tbUser ");
            sbSql.Append("where AccountName=@UserId and Password=@UserPwd");
            SqlParameter[] paras = {
                                       new SqlParameter("@UserId",loginId),
                                       new SqlParameter("@UserPwd",loginPwd)
                                       };
            UserModel user = null;
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sbSql.ToString(), paras);
            if (dt.Rows.Count > 0)
            {
                user = new UserModel();

                if (!DBNull.Value.Equals(dt.Rows[0]["ID"]))
                    user.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                if (!DBNull.Value.Equals(dt.Rows[0]["AccountName"]))
                    user.AccountName = dt.Rows[0]["AccountName"].ToString();
                if (!DBNull.Value.Equals(dt.Rows[0]["RealName"]))
                    user.RealName = dt.Rows[0]["RealName"].ToString();
                if (!DBNull.Value.Equals(dt.Rows[0]["Password"]))
                    user.Password = dt.Rows[0]["Password"].ToString();
                if (!DBNull.Value.Equals(dt.Rows[0]["IsAble"]))
                    user.IsAble = bool.Parse(dt.Rows[0]["IsAble"].ToString());
                if (!DBNull.Value.Equals(dt.Rows[0]["IfChangePwd"]))
                    user.IfChangePwd = bool.Parse(dt.Rows[0]["IfChangePwd"].ToString());
                return user;
            }
            return user;
        }

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        public UserModel GetUserById(string id)
        {
            string sql = "select ID,AccountName,[Password],RealName,MobilePhone,Email,IsAble,IfChangePwd,[Description],CreateTime,CreateBy,UpdateTime,UpdateBy from tbUser where ID = @ID";
            UserModel user = null;
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sql, new SqlParameter("@ID", id));
            if (dt.Rows.Count > 0)
            {
                user = new UserModel();
                DataRowToModel(user, dt.Rows[0]);
                return user;
            }
            else
                return null;
        }

        /// <summary>
        /// 把DataRow行转成实体类对象
        /// </summary>
        private void DataRowToModel(UserModel model, DataRow dr)
        {
            if (!DBNull.Value.Equals(dr["ID"]))
                model.ID = int.Parse(dr["ID"].ToString());

            if (!DBNull.Value.Equals(dr["AccountName"]))
                model.AccountName = dr["AccountName"].ToString();

            if (!DBNull.Value.Equals(dr["Password"]))
                model.Password = dr["Password"].ToString();

            if (!DBNull.Value.Equals(dr["RealName"]))
                model.RealName = dr["RealName"].ToString();

            if (!DBNull.Value.Equals(dr["MobilePhone"]))
                model.MobilePhone = dr["MobilePhone"].ToString();

            if (!DBNull.Value.Equals(dr["Email"]))
                model.Email = dr["Email"].ToString();

            if (!DBNull.Value.Equals(dr["IsAble"]))
                model.IsAble = bool.Parse(dr["IsAble"].ToString());

            if (!DBNull.Value.Equals(dr["IfChangePwd"]))
                model.IfChangePwd = bool.Parse(dr["IfChangePwd"].ToString());

            if (!DBNull.Value.Equals(dr["Description"]))
                model.Description = dr["Description"].ToString();

            if (!DBNull.Value.Equals(dr["CreateTime"]))
                model.CreateTime = Convert.ToDateTime(dr["CreateTime"]);

            if (!DBNull.Value.Equals(dr["CreateBy"]))
                model.CreateBy = dr["CreateBy"].ToString();

            if (!DBNull.Value.Equals(dr["UpdateTime"]))
                model.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);

            if (!DBNull.Value.Equals(dr["UpdateBy"]))
                model.UpdateBy = dr["UpdateBy"].ToString();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public bool ChangePwd(UserModel user)
        {
            string sql = "update tbUser set Password = @UserPwd,IfChangePwd=1 where ID = @Id";
            SqlParameter[] paras = {
                                   new SqlParameter("@UserPwd",user.Password),
                                   new SqlParameter("@Id",user.ID)
                                   };
            object obj = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, sql, paras);
            if (Convert.ToInt32(obj) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据用户id获取用户
        /// </summary>
        public UserModel GetUserByUserId(string userId)
        {
            string sql = "select top 1 ID,AccountName,[Password],RealName,MobilePhone,Email,IsAble,IfChangePwd,[Description],CreateTime,CreateBy,UpdateTime,UpdateBy from tbUser where AccountName = @UserId";
            UserModel user = null;
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sql, new SqlParameter("@UserId", userId));
            if (dt.Rows.Count > 0)
            {
                user = new UserModel();
                DataRowToModel(user, dt.Rows[0]);
                return user;
            }
            else
                return null;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public int AddUser(UserModel user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbUser(AccountName,[Password],RealName,MobilePhone,Email,IsAble,IfChangePwd,[Description],CreateTime,CreateBy,UpdateTime,UpdateBy)");
            strSql.Append(" values ");
            strSql.Append("(@AccountName,@Password,@RealName,@MobilePhone,@Email,@IsAble,@IfChangePwd,@Description,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy)");
            strSql.Append(";SELECT @@IDENTITY");   //返回插入用户的主键
            SqlParameter[] paras = {
                                   new SqlParameter("@AccountName",user.AccountName),
                                   new SqlParameter("@Password",user.Password),
                                   new SqlParameter("@RealName",user.RealName),
                                   new SqlParameter("@MobilePhone",user.MobilePhone),
                                   new SqlParameter("@Email",user.Email),
                                   new SqlParameter("@IsAble",user.IsAble),
                                   new SqlParameter("@IfChangePwd",user.IfChangePwd),
                                   new SqlParameter("@Description",user.Description),
                                   new SqlParameter("@CreateTime",user.CreateTime),
                                   new SqlParameter("@CreateBy",user.CreateBy),
                                   new SqlParameter("@UpdateTime",user.UpdateTime),
                                   new SqlParameter("@UpdateBy",user.UpdateBy)
                                   };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras));
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public bool EditUser(UserModel user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUser set ");
            strSql.Append("AccountName=@AccountName,RealName=@RealName,MobilePhone=@MobilePhone,Email=@Email,IsAble=@IsAble,IfChangePwd=@IfChangePwd,Description=@Description,UpdateTime=@UpdateTime,UpdateBy=@UpdateBy");
            strSql.Append(" where ID=@Id");

            SqlParameter[] paras = {
                                   new SqlParameter("@AccountName",user.AccountName),
                                   new SqlParameter("@RealName",user.RealName),
                                   new SqlParameter("@MobilePhone",user.MobilePhone),
                                   new SqlParameter("@Email",user.Email),
                                   new SqlParameter("@IsAble",user.IsAble),
                                   new SqlParameter("@IfChangePwd",user.IfChangePwd),
                                   new SqlParameter("@UpdateTime",user.UpdateTime),
                                   new SqlParameter("@Description",user.Description),
                                   new SqlParameter("@Id",user.ID),
                                   new SqlParameter("@UpdateBy",user.UpdateBy)
                                   };
            object obj = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
            if (Convert.ToInt32(obj) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除用户（可批量删除，删除用户同时删除对应的权限和所处的部门）
        /// </summary>
        public bool DeleteUser(string idList)
        {
            List<string> list = new List<string>();
            list.Add("delete from tbUser where ID in (" + idList + ")");
            list.Add("delete from tbUserRole where UserId in (" + idList + ")");

            try
            {
                int count = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, list);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
