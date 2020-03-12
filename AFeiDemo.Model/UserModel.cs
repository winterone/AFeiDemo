using System;

namespace AFeiDemo.Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class UserModel
    {
        // 主键 Id
        public int ID { get; set; }

        // 用户登录 UserId
        public string AccountName { get; set; }

        // 用户登录密码 UserPwd
        public string Password { get; set; }

        // 真实姓名
        public string RealName { get; set; }

        // 联系人手机号码 
        public string MobilePhone { get; set; }

        // 邮箱 
        public string Email { get; set; }

        // 用户是否被启用
        public bool IsAble { get; set; }

        // 用户是否修改密码（强制第一次登陆修改密码）
        public bool IfChangePwd { get; set; }

        // 用户简介
        public string Description { get; set; }

        // 创建人
        public string CreateBy { get; set; }
        
        // 创建时间 
        public DateTime CreateTime { get; set; }

        // 最后更新人 
        public string UpdateBy { get; set; }

        // 最后更新时间 
        public DateTime UpdateTime { get; set; }
    }
}
