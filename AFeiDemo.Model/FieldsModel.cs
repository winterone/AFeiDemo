using System;

namespace AFeiDemo.Model
{
    public class FieldsModel
    {
        public int Id { set; get; }
        
        public int TabId { set; get; }

        /// <summary>
        /// 字段名（数据库）
        /// </summary>
        public string FieldName { set; get; }

        /// <summary>
        /// 字段显示名
        /// </summary>
        public string FieldViewName { set; get; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public int FieldDataTypeId { set; get; }

        public bool IsActive { set; get; }
        
        public bool IsSearch { set; get; }

        public int Sort { set; get; }

        public DateTime CreateTime { set; get; }
        
        public string CreateBy { set; get; }
       
        public DateTime? UpdateTime { set; get; }
        
        public string UpdateBy { set; get; }
    }
}
