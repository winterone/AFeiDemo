using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface INewsTypeDAL
    {
        bool Exists(string name);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(NewsTypeModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        NewsTypeModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(NewsTypeModel model);

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        bool DeleteList(string idlist);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
    }
}
