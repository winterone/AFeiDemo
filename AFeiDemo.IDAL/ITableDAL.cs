using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface ITableDAL
    {
        bool ExistsTabName(string tabName);

        bool ExistsTabViewName(string tabViewName);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(TableModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TableModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(TableModel model);

        bool DeleteList(string idlist);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
    }
}
