using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.IDAL
{
    public  interface IDataTypeDAL
    {
        bool Exists(string name);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(DataTypeModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DataTypeModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(DataTypeModel model);

        bool DeleteList(string idlist);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
    }
}
