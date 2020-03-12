using System;

namespace AFeiDemo.Model
{
    public class TableModel
    {
        public int Id { set; get; }
        
        public string TabName { set; get; }
        
        public string TabViewName { set; get; }
        
        public bool IsActive { set; get; }
        
        public DateTime CreateTime { set; get; }
        
        public string CreateBy { set; get; }
        
        public DateTime? UpdateTime { set; get; }
        
        public string UpdateBy { set; get; }
    }
}
