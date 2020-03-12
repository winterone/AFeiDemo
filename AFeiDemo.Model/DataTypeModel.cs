using System;

namespace AFeiDemo.Model
{
    public class DataTypeModel
    {

        public int id { set; get; }

        public int Sort { set; get; }

        /// <summary>
        /// 数据类型 例如 int  decimal
        /// </summary>
        public string DataType { set; get; }

        /// <summary>
        /// 数据类型显示名称  例如整数 浮点等
        /// </summary>
        public string DataTypeName { set; get; }

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
