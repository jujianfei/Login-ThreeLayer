using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login_ThreeLayer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string uid = txtUserName.Text.Trim();
            string pwd = txtPassword.Text.Trim();

            BLL.User user = new BLL.User();

            if (uid == "")
            {
                MessageBox.Show("请输入用户名", "温馨提示");
            }
            else if (pwd == "")
            {
                MessageBox.Show("请输入密码", "温馨提示");
            }
            else
            {
                bool result = user.JudgeUserName(uid);
                if (result == true) //用户名正确
                {
                    //判断是否过了15分钟
                    bool result3 = user.JudgeTime(uid);
                    if (result3 == true)
                    {
                        bool result2 = user.JudgeUserPwd(uid, pwd);
                        if (result2 == true)  //密码也正确
                        {
                            //重置错误次数
                            user.ReSetErrTimes(uid);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("密码不正确！", "温馨提示");
                            //更新错误次数
                            user.UpDateErrTimes(uid);
                            //并判断错误次数是否达到三次，如果达到三次就更新错误时间，重置错误次数；否则，什么都不做
                            bool result4 = user.JudgeTimes(uid);
                            if (result4 == true)
                            {
                                //达到三次，更新错误时间，重置错误次数
                                user.UpDateLastErrTime(uid);
                                user.ReSetErrTimes(uid);
                            }
                            else
                            {
                                txtPassword.Focus();
                                txtPassword.SelectAll();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("登录锁定时间未到，请稍后重试！", "温馨提示");
                    }
                }
                else
                {
                    MessageBox.Show("此用户不存在，请重新输入！", "温馨提示");
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                }
            }
        }
    }
}
