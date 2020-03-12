﻿using AFeiDemo.Common;
using AFeiDemo.IDAL;
using AFeiDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AFeiDemo.DAL
{
    public class RequestionTypeDAL:IRequestionTypeDAL
    {
        public bool Exists(string name)
        {
            string sql = "select count(1)num from tbRequestionType where ftypename = @ftypename";
            SqlParameter[] parameters = {
                        new SqlParameter("@ftypename", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = name;
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sql, parameters);
            if (int.Parse(dt.Rows[0]["num"].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RequestionTypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbRequestionType(");
            strSql.Append("ftypename,fsort,CreateBy,CreateTime,UpdateBy,UpdateTime");
            strSql.Append(") values (");
            strSql.Append("@ftypename,@fsort,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@ftypename", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CreateBy", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@UpdateBy", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                        new SqlParameter("@fsort", SqlDbType.Int)
            };

            parameters[0].Value = model.ftypename;
            parameters[1].Value = model.CreateBy;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.UpdateBy;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.fsort;
            object obj = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters));
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RequestionTypeModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, ftypename, fsort, CreateTime,CreateBy,UpdateTime,UpdateBy  ");
            strSql.Append("  from tbRequestionType ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;


            RequestionTypeModel model = new RequestionTypeModel();
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
                model.ftypename = dt.Rows[0]["ftypename"].ToString();
                if (dt.Rows[0]["fsort"].ToString() != "")
                {
                    model.fsort = int.Parse(dt.Rows[0]["fsort"].ToString());
                }
                model.CreateBy = dt.Rows[0]["CreateBy"].ToString();
                if (dt.Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(dt.Rows[0]["CreateTime"].ToString());
                }
                model.UpdateBy = dt.Rows[0]["UpdateBy"].ToString();
                if (dt.Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(dt.Rows[0]["UpdateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(RequestionTypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbRequestionType set ");
            strSql.Append(" ftypename = @ftypename , ");
            strSql.Append(" fsort = @fsort , ");
            strSql.Append(" CreateBy = @CreateBy , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" UpdateBy = @UpdateBy , ");
            strSql.Append(" UpdateTime = @UpdateTime  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4) ,
                        new SqlParameter("@ftypename", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CreateBy", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,
                        new SqlParameter("@UpdateBy", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                        new SqlParameter("@fsort", SqlDbType.Int)

            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.ftypename;
            parameters[2].Value = model.CreateBy;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.UpdateBy;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.fsort;

            object obj = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters);

            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            List<string> list = new List<string>();
            list.Add("delete from tbRequestionType where Id in (" + idlist + ")");
            list.Add("delete from tbRequestion where ftypeid in (" + idlist + ")");

            try
            {
                if (SqlHelper.ExecuteNonQuery(SqlHelper.connStr, list) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbRequestionType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }
    }
}
