using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class User
    {
        DAL.User user = new DAL.User();

        /// <summary>
        /// 判断用户名是否正确
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool JudgeUserName(string uid)
        {
            DataTable dt = user.SelectUser(uid);
            if (dt.Rows.Count != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断密码是否正确
        /// </summary>                                                                                                
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool JudgeUserPwd(string uid, string pwd)
        {
            DataTable dt = user.SelectUser(uid);
            if (dt.Rows[0][1].ToString().Trim() != pwd)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断最后的错误事件，如果过了15分钟，就放过去，否则给出提示
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool JudgeTime(string uid) 
        {
            DataTable dt = user.SelectUser(uid);
            if (Convert.ToInt32(dt.Rows[0][5])<15)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 重置错误次数
        /// </summary>
        /// <param name="uid"></param>
        public void ReSetErrTimes(string uid)
        {
            user.ReSetErrTimes(uid);
        }

         /// <summary>
        /// 更新错误次数
        /// </summary>
        /// <param name="uid"></param>
        public void UpDateErrTimes(string uid)
        {
            user.UpDateErrTimes(uid);
        }

        /// <summary>
        /// 判断错误次数是否达到三次
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool JudgeTimes(string uid)
        { 
            DataTable dt = user.SelectUser(uid);
            if (Convert.ToInt32(dt.Rows[0][3])==3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新错误登录时间
        /// </summary>
        /// <param name="uid"></param>
        public void UpDateLastErrTime(string uid)
        {
            user.UpDateLastErrTime(uid);
        }
    }
}
