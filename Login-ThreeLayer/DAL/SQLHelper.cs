using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SQLHelper
    {
        //wf项目中，请添加对System.Configuration的引用
        //1.对配置文件connectionStrings节进行读取
        static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 查询数据库返回一张表
        /// </summary>
        /// <param name="sql">查询字符串</param>
        /// <param name="parameters">查询所需要的参数</param>
        /// <returns>返回查询的结果的第一个结果集的表</returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            //创建一个临时的数据集，在内存里
            DataSet ds = new DataSet();
            //创建一个适配器对象
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connstr);
            //给适配器对象的查询命令对象添加参数
            adapter.SelectCommand.Parameters.AddRange(parameters);
            try
            {
                //填充数据集
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception) //如果捕捉错误就返回null
            {
                return null;
            }
        }

        /// <summary>
        /// 数据库的增删改语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 查询返回单个的值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>首行首列的值</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
