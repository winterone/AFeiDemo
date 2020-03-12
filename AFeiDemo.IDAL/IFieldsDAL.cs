using AFeiDemo.Model;

namespace AFeiDemo.IDAL
{
    public interface IFieldsDAL
    {
        bool ExistsFieldName(string tabName, int tabId);

        bool ExistsFieldViewName(string fieldViewName, int tabId);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(FieldsModel model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        FieldsModel GetModel(int id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(FieldsModel model);

        bool DeleteList(string Idlist);
    }
}
