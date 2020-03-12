using AFeiDemo.Common;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AFeiDemo.DAL
{
    public class LoginIpLogDAL : ILoginIpLogDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LoginIpLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbLoginIpLog(");
            strSql.Append("IpAddress,CreateTime,CreateBy,UpdateTime,UpdateBy");
            strSql.Append(") values (");
            strSql.Append("@IpAddress,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@IpAddress", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@CreateBy", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@UpdateBy", SqlDbType.NVarChar,50)

            };

            parameters[0].Value = model.IpAddress;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.CreateBy;
            parameters[3].Value = model.UpdateTime;
            parameters[4].Value = model.UpdateBy;
            //insert
            object obj = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters));
            return Convert.ToInt32(obj);
        }
    }
}
