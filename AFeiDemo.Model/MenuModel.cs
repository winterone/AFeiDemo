using System;

namespace AFeiDemo.Model
{
    /// <summary>
    /// 导航菜单类
    /// </summary>
    public class MenuModel
    {
        // 主键
        public int Id { get; set; }

        // 导航菜单名称
        public string Name { get; set; }

        // 父级节点id
        public int ParentId { get; set; }

        // 菜单标识码
        public string Code { get; set; }

        // 链接地址
        public string LinkAddress { get; set; }

        // 导航菜单图标
        public string Icon { get; set; }

        // 导航菜单排序
        public int Sort { get; set; }

        // 添加时间
        public DateTime CreateTime { get; set; }

        // 修改时间
        public DateTime UpdateTime { get; set; }

        // 添加人
        public string CreateBy { get; set; }

        // 修改人
        public string UpdateBy { get; set; }
    }
}
