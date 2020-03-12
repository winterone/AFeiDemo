using System;

namespace AFeiDemo.Model
{
    public class RequestionTypeModel
    {
        public int id { set; get; }

        public int fsort { set; get; }
        
        public string ftypename { set; get; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新人 
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间 
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
