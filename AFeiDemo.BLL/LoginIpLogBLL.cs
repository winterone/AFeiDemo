using AFeiDemo.DAL;
using AFeiDemo.IDAL;
using AFeiDemo.Model;

namespace AFeiDemo.BLL
{
    public class LoginIpLogBLL
    {
        ILoginIpLogDAL dal = DALFactory.GetLoginIpLogDAL();

        // 增加一条数据
        public int Add(LoginIpLogModel model)
        {
            return dal.Add(model);

        }
    }
}
