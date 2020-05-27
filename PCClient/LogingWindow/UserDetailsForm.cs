using PCClintSoftware.BaseClass;
using PCClintSoftware.ToolClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow
{
    public partial class UserDetailsForm : Form
    {
        LogUser user ;     //= new LogUser();    //本次登录的对象
        LogUser user_1;    //辅助功能，帮助判断user的内容是否改变
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数</param>
        private delegate void MethodCallerNY(string str);
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数,状态字符</param>
        /// <param name="elder">启动多线程所需要的参数，老人对象</param>
        private delegate void MethodCallerNYY(string str,LogUser elder);

        public UserDetailsForm()
        {
            InitializeComponent();
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            ControlInfo(false);   //初始化时设置控件不可用
            FillUserDetailsToForm();   //填充用户信息
        }
        private void UserDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(user!=user_1)
            {
                MainForm.mainForm.UserDetails(user);  //如果user内容有所改变，关闭窗口时将本窗口的用户传给主窗口，方便调用
            }
        }
        /**************************************************
        * 多线程通信处理块
        ****************************************************/
        /// <summary>
        /// 子线程通知主线程调用的方法，请求修改用户个人信息
        /// </summary>
        /// <param name="amendState">由服务器返回的修改状态</param>
        /// <param name="amendUser">所需要修改的用户对象</param>
        private void InvokeAmendDetails(string amendState, LogUser amendUser)
        {
            if (amendState == ConstantMember.AMENDUSER_SUCCESS)
            {//*****************************有待完善
                user = amendUser;   //如果修改成功则令该用户信息成为最新信息
                MessageBox.Show("个人信息修改成功");
            }
            else if (amendState == ConstantMember.AMENDUSER_FAILD)
            {
                //*****************************有待完善
                MessageBox.Show("个人信息修改失败");
            }
            else
            {
                //*****************************有待完善
                //MessageBox.Show("请求超时，请重试");
            }
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，请求修改用户个人信息
        /// </summary>
        /// <param name="state">由服务器返回的修改状态</param>
        private void InvokeAmendDetails(string state)
        {
            if (state == ConstantMember.AMENDPASSWORD_SUCCESS)
            {
                //*********************************有待优化
                user.userPassword = this.pNewPasswordBox.Text;        //将密码置为新密码
                MessageBox.Show("密码修改成功");
                this.pNewPasswordBox.Text = "";     //设置成功后，清空密码框
                this.pConfirmPasswordBox.Text="";
                this.pOldPasswordBox.Text = "";
            }
            else if (state == ConstantMember.AMENDPASSWORD_FAILD)
            {
                //*********************************有待优化
                MessageBox.Show("密码修改失败，请重试");
            }
            else
            {
                //*********************************有待优化
                //MessageBox.Show("请求超时，请重试");
            }
        }
        /***********************************************
         * 自定义代码块
         * *********************************************/
        /// <summary>
        /// 设置userDetails中控件的可用性
        /// </summary>
        /// <param name="isEnable"></param>
        private void ControlInfo(Boolean isEnable)
        {
            foreach (Control ct in this.userDetails.Controls)
            {
                if (ct is TextBox || ct == this.saveDetailsBtn)
                    ct.Enabled = isEnable;   //使控件不可用
            }
        }
        /// <summary>
        /// 将用户信息填充到该窗口的对应编辑框中
        /// </summary>
        private void FillUserDetailsToForm()
        {
            this.userNameBox.Text = user.userName;
            this.userRealNameBox.Text = user.realName;
            this.userIDBox.Text = user.number;
            this.userBirthdayBox.Text = user.birthday;
            this.userSexBox.Text = user.sex;
            this.userIDcardBox.Text = user.idCard;
        }

        /// <summary>
        /// 初始化本窗口，在打开窗口前被调用,包括获取登录用户到本窗口，
        /// 选择窗口显示的页面
        /// </summary>
        /// <param name="theUser">获取登录用户</param>
        /// <param name="tableName">选择打开的页面</param>
        public void InitialForm(LogUser theUser, string tableName)
        {
            this.user = theUser;     //获取用户信息到本窗口
            this.user_1 = user;      //辅助功能，判断user内容是否改变
            //根据调用者的参数显示丢应的页面
            if (tableName == ConstantMember.UDFORMDETAILTAB)
            {
                this.userDetailsTab.SelectedTab = userDetails;   //将当先选项卡设置为人员档案修改选项卡
            }
            else if (tableName == ConstantMember.UDFORMPASSWORDTAB)
            {
                this.userDetailsTab.SelectedTab = amendPassword;   //将当先选项卡设置为人员档案删除选项卡           
            }
            else
            {
                //************************************************
                //this.userDetailsTab.SelectedTab = newRecord;   //将当先选项卡设置为人员档案删除选项卡  
            }
        }
        /// <summary>
        /// 多线程启动的方法，向服务器请求修改密码，只有方法AmendPassword可以调用
        /// </summary>
        private void HttpAmendPassword(Object objSend)
        {
            string newPassw = (string)objSend;
            LogUser puser = user.copy();
            puser.userPassword = newPassw;
            string state = "";
            HttpProvider amendPassword = new HttpProvider(ConstantMember.AMENDPASSWORDURL, ConstantMember.POST);   //新建请求连接
            //****************************************异常处理过于粗糙，有待改善
            try
            {
                state = amendPassword.HttpRquestStr(puser);
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("修改密码  出现网络异常：\r" + e);
                MessageBox.Show("由于网络异常\r修改密码失败    请重试");
            }
            catch (Exception e)
            {
                //其他异常导致修改失败
                Console.WriteLine("修改密码：\r" + e);
                MessageBox.Show("修改密码   其他异常");
            }
            finally
            {
                //子线程将服务器返回结果通知给主线程，由主线程决定后屋操作
                MethodCallerNY mcAmendPassword = new MethodCallerNY(InvokeAmendDetails);
                this.BeginInvoke(mcAmendPassword, state);
            }
        }
        /// <summary>
        /// 向服务器请求修改本用户的密码，由本窗口的修改密码窗口的保存按钮的单击事件调用
        /// </summary>
        private void AmendPassword()
        {
            if(this.pOldPasswordBox.Text=="")
            {
                //***********************************有待优化
                MessageBox.Show("请输入原密码后重试");
                return;
            }
            else if(this.pOldPasswordBox.Text!=user.userPassword)
            {
                //***********************************有待优化
                MessageBox.Show("原密码有误，请重新输入后重试");
                return;
            }
            else if(this.pNewPasswordBox.Text=="")
            {
                //*********************************有待优化
                MessageBox.Show("请输入新密码后保存");
                return;
            }
            else if (this.pNewPasswordBox.Text != this.pConfirmPasswordBox.Text)
            {
                //*********************************有待优化
                MessageBox.Show("两次输入的新密码不同，请重试");
                return;
            }
            else 
            {//**************************************请求修改密码*********************方法体的主要内容
                //采用多线程的方式向服务器发起修改密码的请求
                ParameterizedThreadStart THAmendPAssword = new ParameterizedThreadStart(HttpAmendPassword);
                Thread thdAmendPassword = new Thread(THAmendPAssword);
                thdAmendPassword.IsBackground = true;             //防止程序结束时线程还在继续运行
                thdAmendPassword.Start(pConfirmPasswordBox.Text);
            }
        }
        /// <summary>
        /// 多线程调用的方法，向服务器发出请求，只有方法AmendUserDetails可以调用
        /// </summary>
        /// <param name="objSend">用户对象，请求时所需要</param>
        private void HttpAmendDetails(Object objSend)
        {
            LogUser amendUser = (LogUser)objSend;
            //请求体
            string amendState = "";
            HttpProvider amendUserReq = new HttpProvider(ConstantMember.AMENDUSERURL, ConstantMember.POST);
            try
            {
                amendState = amendUserReq.HttpRquestStr(amendUser);   //发出请求并返回请求状态
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("修改个人资料  出现网络异常：\r" + e);
                MessageBox.Show("由于网络异常\r修改个人资料失败    请重试"+e);
            }
            catch (Exception e)
            {
                //由于其他异常，导致修改失败
                Console.WriteLine("修改个人资料   其他异常：\r" + e);
                MessageBox.Show("修改个人资料   其他异常");
            }
            finally
            {
                //将服务器返回的修改状态通知给主线程，并由主线程决定后续操作
                MethodCallerNYY mcAmendDetails = new MethodCallerNYY(InvokeAmendDetails);
                this.BeginInvoke(mcAmendDetails, amendState, amendUser);
            }
        }
        /// <summary>
        /// 向服务器发起修改本用户基本信息的请求，并由返回结果进行提示
        /// </summary>
        private void AmendUserDetails()
        {
            if (this.userNameBox.Text == "" || this.userRealNameBox.Text == "" || this.userIDBox.Text==""||this.userIDcardBox.Text=="")
            {
                //***************************************************有待改善，不完整
                MessageBox.Show("信息不完整，请补充完整后重试");
                return;
            }
            LogUser amendUser = new LogUser();
            amendUser.userName = this.userNameBox.Text;
            amendUser.realName = this.userRealNameBox.Text;
            amendUser.number = this.userIDBox.Text;
            amendUser.birthday = this.userBirthdayBox.Text;
            amendUser.sex = this.userSexBox.Text;
            amendUser.idCard = this.userIDcardBox.Text;
            amendUser.superior = this.user.superior;
            amendUser.userPassword = this.user.userPassword;
            amendUser.isAdmin = this.user.isAdmin;
            //采用多线程发送修改个人信息的请求
            ParameterizedThreadStart PTSAmendDetails = new ParameterizedThreadStart(HttpAmendDetails);
            Thread thdAmendDetails = new Thread(PTSAmendDetails);
            thdAmendDetails.IsBackground = true;             //防止程序结束时线程还在继续运行
            thdAmendDetails.Start(amendUser);    //将手环对象传给多线程的方法
        }


        /*****************************************************
         * 事件处理代码块
         * **************************************************/
        private void okAmendBtn_Click(object sender, EventArgs e)
        {
            AmendPassword();    //向服务器请求修改密码
        }

        private void amendPassword_Enter(object sender, EventArgs e)
        {
            this.pUserNameBox.Text = this.user.userName;   //将用户名输入框的值设为用户名
        }

        private void amendDetailsBtn_Click(object sender, EventArgs e)
        {
            ControlInfo(true);      //设置相关控件
        }

        private void saveDetailsBtn_Click(object sender, EventArgs e)
        {
            AmendUserDetails();   //请求修改本用户的个人信息
        }

        private void pCancleAmendBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }






    }
}
