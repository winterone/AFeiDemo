using AFeiDemo.Model;

namespace AFeiDemo.IDAL
{
    public interface ILoginIpLogDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(LoginIpLogModel model);
    }
}
