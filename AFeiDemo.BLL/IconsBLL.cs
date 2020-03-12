using AFeiDemo.Common;
using AFeiDemo.DAL;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.BLL
{
    public class IconsBLL
    {
        IIconsDAL dal = DALFactory.GetIconsDAL();

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">要取的列名（逗号分开）</param>
        /// <param name="order">排序</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public string GetPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            return JsonHelper.ToJson(dt);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsIconName(string iconName)
        {
            return dal.ExistsIconName(iconName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IconsModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IconsModel GetModel(int Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(IconsModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 根据条件获取 
        /// </summary>
        public string GetAllIconsTree(string where)
        {
            DataTable dt = dal.GetList(where);

            string sb = "[";//[{\"id\":\"0\",\"text\":\"图标\",\"iconCls\":\"icon-application_view_icons\",\"children\": [
            foreach (DataRow dr in dt.Rows)
            {
                sb += "{\"id\":\"" + dr["IconCssInfo"] + "\",\"text\":\"" + dr["IconCssInfo"] + "\",\"iconCls\":\"" + dr["IconCssInfo"] + "\"},";//dr["IconName"]
            }
            sb = sb.Trim(",".ToCharArray());
            sb += "]"; //"]}]";
            return sb;
        }
    }
}
