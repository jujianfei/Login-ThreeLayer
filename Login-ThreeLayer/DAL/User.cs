using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class User
    {
        /// <summary>
        /// 根据参数返回查询的一行用户信息
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataTable SelectUser(string uid)
        {
            return SQLHelper.ExecuteDataTable("select *,DATEDIFF(MINUTE,LastErrTime,GetDATE()) from Users where UserName = @name", new SqlParameter("@name", uid));
        }

        /// <summary>
        /// 重置错误次数
        /// </summary>
        /// <param name="uid"></param>
        public void ReSetErrTimes(string uid)
        {
            SQLHelper.ExecuteNonQuery("update Users set ErrTimes = 0 where UserName = @name", new SqlParameter("@name", uid));
        }

        /// <summary>
        /// 更新错误次数
        /// </summary>
        /// <param name="uid"></param>
        public void UpDateErrTimes(string uid)
        {
            SQLHelper.ExecuteNonQuery("update Users set ErrTimes = ErrTimes + 1 where UserName = @name", new SqlParameter("@name", uid));
        }

        /// <summary>
        /// 更新错误登录时间
        /// </summary>
        /// <param name="ui"></param>
        public void UpDateLastErrTime(string uid)
        {
            SQLHelper.ExecuteNonQuery("update Users set LastErrTime = getdate() where UserName = @name", new SqlParameter("@name", uid));
        }
    }
}
