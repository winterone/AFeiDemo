using System;

namespace AFeiDemo.Model
{
    public class RequestionModel
    {
        public int id { set; get; }

        /// <summary>
        /// 类型
        /// </summary>
        public int? ftypeid { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        public string ftitle { set; get; }

        /// <summary>
        /// 内容
        /// </summary>
        public string fcontent { set; get; }

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
