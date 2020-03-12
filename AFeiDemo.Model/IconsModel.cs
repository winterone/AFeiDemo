using System;

namespace AFeiDemo.Model
{
    public class IconsModel
    {
        public int Id { get; set; }
        public string IconName { get; set; }

        public string IconCssInfo { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreateBy { get; set; }

        public DateTime UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }
}
