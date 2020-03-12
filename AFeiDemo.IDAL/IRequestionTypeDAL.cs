using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public interface IRequestionTypeDAL
    {
        bool Exists(string name);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(RequestionTypeModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        RequestionTypeModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(RequestionTypeModel model);

        bool DeleteList(string idlist);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
    }
}
