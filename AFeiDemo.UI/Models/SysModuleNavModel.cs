using System.Collections.Generic;

namespace AFeiDemo.UI.Models
{
    public class SysModuleNavModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string attributes { get; set; }
        public string state { get; set; }
        public List<SysModuleNavModel> Children { get; set; }
    }
}