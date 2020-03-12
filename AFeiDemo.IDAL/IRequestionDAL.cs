using AFeiDemo.Model;

namespace AFeiDemo.IDAL
{
    public interface IRequestionDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(RequestionModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        RequestionModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(RequestionModel model);

        bool DeleteList(string idlist);
    }
}
