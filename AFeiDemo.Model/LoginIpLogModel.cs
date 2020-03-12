using System;

namespace AFeiDemo.Model
{
    public class LoginIpLogModel
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }
}
