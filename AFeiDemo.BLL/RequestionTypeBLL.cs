using AFeiDemo.Common;
using AFeiDemo.DAL;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System.Data;

namespace AFeiDemo.BLL
{
    public class RequestionTypeBLL
    {
        IRequestionTypeDAL dal = DALFactory.GetRequestionTypeDAL();

        public bool Exists(string name)
        {
            return dal.Exists(name);
        }
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
        /// 增加一条数据
        /// </summary>
        public int Add(RequestionTypeModel model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RequestionTypeModel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(RequestionTypeModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        public string GetAllRequestionTypeInfo(string where)
        {
            return JsonHelper.ToJson(dal.GetList(where));
        }
    }
}
