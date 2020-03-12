using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface INewsDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(NewsModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        NewsModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(NewsModel model);

        bool DeleteList(string idlist);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataTable GetList(int Top, string strWhere, string filedOrder);
    }
}
