using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface IIconsDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsIconName(string iconName);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(IconsModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        IconsModel GetModel(int Id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(IconsModel model);

        bool DeleteList(string Idlist);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
    }
}
