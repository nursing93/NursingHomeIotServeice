using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCClintSoftware.ToolClass;
using PCClintSoftware.BaseClass;
using LogingWindow.ToolClass;
using System.Threading;
using System.Net;

namespace LogingWindow
{
    public partial class LogingWindown : Form
    {
        /// <summary>
        /// 标志位，存储用户登录权限，四种http响应值：
        /// ADMINISTRATOR---以管理员身份登录 
        /// USERPERMIT---以一般用户身份登录
        /// NOPERMISSION---登录失败，没有登录权限
        /// WRONGPASSWORD---登录失败，密码错误返回值
        /// 和一个默认值LOGING---正在登陆
        /// </summary>
        private string permissionStr="LOGING";
        public static LogingWindown logingWin = null;
        LogUser user = null;     //新建用户对象，用于提供发送请求的内容——主要用在登录请求成功之后
        /// <summary>
        /// 标志位，用于判断用户是否已经点击请求登录，放置过操作
        /// </summary>
        Boolean IFREQUESTLOG = false;
        /// <summary>
        /// 线程间通信代理——主要用于网络异常报告
        /// </summary>
        /// <param name="e">所发生的异常</param>
        private delegate void MethodCell_WE(WebException e);
        /// <summary>
        /// 线程间通信代理
        /// </summary>
        /// <param name="strStatus">所需要的字符串</param>
        private delegate void MethodCell_SS(string strStatus);
        public LogingWindown()
        {
            InitializeComponent();
        }

        private void LogingWindown_Load(object sender, EventArgs e)
        {
            logingWin = this;      //
            IniNameBox();      //调用初始化userNameBox内容的方法
        }
        private void LogingWindown_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        /**************************************************
         * 多线程通信处理块
         * ***********************************************/
        /// <summary>
        /// 子线程通知主线程调用的方法，主要用于网络异常时通信
        /// </summary>
        /// <param name="e"></param>
        private void Invoke_WebException(WebException e)
        {
            this.logingBtn.Enabled = true;    //服务器响应完成后，使登录按钮可用
            IFREQUESTLOG = false;        //将标志位设为已经请求
            if (e.Status.ToString() == "Timeout")
            {
                statuLable.Text = "请求超时，请重试. . . . . .";
                statuLable.ForeColor = Color.Red;
            }
            else if (e.Status.ToString() == "ConnectFailure" || e.Status.ToString() == "NameResolutionFailure")
            {      //此时的情景需要查明缘由后决定处理方式
                statuLable.Text = "网络连接异常，请检查网络并重试\r" + e.Message;
                statuLable.ForeColor = Color.Red;
            }
            else if (e.Status.ToString() == "ConnectionClosed")
            {
                statuLable.Text = "远程服务器尚未开启服务：\r" + e.Message + "\r" + e.Status;
                statuLable.ForeColor = Color.Red;
            }
            else if (e.Message.IndexOf("404", 0) != -1)
            {
                statuLable.Text = "请求失败：\r可能是请求地址错误，或者网络连接异常\r" + e.Message;
                statuLable.ForeColor = Color.Red;
            }
            else
            {
                //其他错误提示
                statuLable.Text = "登录过程中出现其他网络错误：\r" + e;
                statuLable.ForeColor = Color.Red;
            }
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，用户以管理员身份登录时处理方式
        /// </summary>
        private void InvokeLog_Admin()
        {
            this.logingBtn.Enabled = true;    //服务器响应完成后，使登录按钮可用
            if(this.user!=null)
            {
                statuLable.Text = "正在以管理员身份登录";
                IFREQUESTLOG = false;        //将标志位设为已经请求
                MainForm mainForm = new MainForm();
                mainForm.UserPermission(true, user);     //以管理员身份打开主窗口,并将该管理员的对象传给主窗口
                mainForm.Show();
            }
            //***********************待处理
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，用户以普通用户身份登录时处理方式
        /// </summary>
        private void InvokeLog_User()
        {
            this.logingBtn.Enabled = true;    //服务器响应完成后，使登录按钮可用
            if(this.user!=null)
            {
                IFREQUESTLOG = false;        //将标志位设为已经请求
                statuLable.Text = "一般用户登录成功";
                MainForm mainForm = new MainForm();
                mainForm.UserPermission(false, user);  //以一般用户身份登录
                mainForm.Show();
            }
            //***********************待处理
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，用户名错误处理方式
        /// </summary>
        private void InvokeLog_NoMission()
        {
            this.logingBtn.Enabled = true;    //服务器响应完成后，使登录按钮可用
            IFREQUESTLOG = false;        //将标志位设为已经请求
            statuLable.Text = "用户名错误，请修改后重试";
            statuLable.ForeColor = Color.Red;
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，密码错误处理方式
        /// </summary>
        private void InvokeLog_WrongPassword()
        {
            this.logingBtn.Enabled = true;    //服务器响应完成后，使登录按钮可用
            IFREQUESTLOG = false;        //将标志位设为已经请求
            statuLable.Text = "密码错误";
            statuLable.ForeColor = Color.Red;
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，服务器响应错误处理方式
        /// </summary>
        private void InvokeLog_NoResponse()
        {
            this.logingBtn.Enabled = true;    //服务器响应完成后，使登录按钮可用
            IFREQUESTLOG = false;        //将标志位设为已经请求
            statuLable.Text = "响应失败，可能是程序出现了不可预估的错误";
            statuLable.ForeColor = Color.Red;
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，刚启动多线程时，初始化用户采用的方法
        /// </summary>
        private void Invoke_InitialStatuLable()
        {
            this.logingBtn.Enabled = false;    //点击登录后，在服务器响应之前，不允许再次点击登录
            IFREQUESTLOG = true;        //将标志位设为已经请求
            if (userNameBox.Text == "" | userPassWordBox.Text == "")
            {
                //提示输入用户名和密码
                statuLable.Text = "请输入用户名或密码后重试";
                statuLable.ForeColor = Color.Red;
                return;
            }
            statuLable.Text = "正在登陆. . . . . .";   //将提示标签的内容置空
            statuLable.ForeColor = Color.DodgerBlue;  //
            user = new LogUser(userNameBox.Text, userPassWordBox.Text);   //新建用户对象，用于提供发送请求的内容
            //Thread.Sleep(1000);
        }

        /*******************************************
         * 自定义代码段
         * ******************************************/
        /// <summary>
        /// 初始化userNameBox内容的方法，在窗口加载时被调用，如果有老用户，则可以直接显示用户名
        /// </summary>
        private void IniNameBox()
        {
            //从临时数据库获取用户名列表
            this.userNameBox = HandDataBase.GetUserList(this.userNameBox);
            if(userNameBox.Items.Count==0)
            {
                return;
            }
            //将首条用户名显示在userNameBox内容中
            this.userNameBox.Text = userNameBox.Items[0].ToString();
        }
        /// <summary>
        /// 将已有用户的密码根据情况自动添加到密码框中,由userNameBox_SelectedIndexChanged事件调用
        /// </summary>
        private void SetPasswordToBox()
        {
            LogUser user = new LogUser();
            user.userName = userNameBox.Text;
            user = HandDataBase.GetUserObj(user);
            this.userPassWordBox.Text = user.userPassword;
            if (user.isSavePassword == 1)
            {
                this.checkBox.Checked = true;
            }
            else if (user.isSavePassword == 0)
            {
                this.checkBox.Checked = false;
            }
            else
            {
                MessageBox.Show("用户对象的属性设置不全");
            }
        }
        /// <summary>
        /// 该方法用于向http发送登录请求，并处理登录结果。。。。。。未开发完
        /// </summary>
        private void LogingRequest() {
            Thread.CurrentThread.IsBackground = true;   //设置为后台线程，放置程序停止时线程还在运行
            //if (userNameBox.Text == "" | userPassWordBox.Text == "")
            //{
            //    //提示输入用户名和密码
            //    statuLable.Text = "请输入用户名或密码后重试";
            //    statuLable.ForeColor = Color.Red;
            //    return;
            //}
            //statuLable.Text = "";   //将提示标签的内容置空
            //statuLable.ForeColor = Color.DodgerBlue;  //
            //user = new LogUser(userNameBox.Text, userPassWordBox.Text);   //新建用户对象，用于提供发送请求的内容
            //采用多线程通信，用主线程实现被屏蔽代码的方法——打开主窗口
            MethodInvoker mi_SB = new MethodInvoker(this.Invoke_InitialStatuLable);    //创建委托
            this.Invoke(mi_SB);
            //
            if(this.user==null)   //如果用户为空，则不进行一下操作
            {
                return;
            }
            HttpProvider logRequest = new HttpProvider(ConstantMember.LOGINGURL);  //新建RequestPostURL对象，用于向服务器发送“登录”请求
            HttpProvider userDetails = new HttpProvider(ConstantMember.QUERYUSERDETAILURL + user.userName,ConstantMember.GET);  //新建RequestPostURL对象，用于请求该用户的详细资料
            try   //********************************************，异常处理不完整，有待改善
            {
                logRequest.setcontentType("application/x-www-form-urlencoded");     //设置传输格式
                string loginStr ="username=" + user.userName + "&password=" + user.userPassword;    //登录请求的用户身份与密码
                permissionStr = logRequest.HttpRquestStr(loginStr);   //由服务器返回的字符串
                //*************************************************测试代码
                //permissionStr = "ADMINISTRATOR";  //ADMINISTRATOR,USERPERMIT,WRONGPASSWORD,NOPERMISSION
                //MessageBox.Show(permissionStr);
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("出现异常：\r" + e);
                permissionStr = ConstantMember.WEBEXCEPTION;    //将状态码设置为“网络异常”
                MethodCell_WE mcWebException = new MethodCell_WE(Invoke_WebException);
                this.Invoke(mcWebException,e);    //同步通信，必须采用该方式
            }
            catch (Exception e)
            {
                //不可缺少，以免由于其他原因导致的异常致使程序奔溃***************************************调试时可以去掉，方便发现问题
                //其他异常导致的错误，使登录不成功
                MessageBox.Show("出现非网络问题的异常：\r" + e);
                //permissionStr = "NORESPONSE";    //这里的字符以及finally方法体的最后一个处理块的内容需要根据之后的异常处理情况而改变
            }
            finally
            {
                if (permissionStr == ConstantMember.ADMINISTRATOR)
                {//********************************************有待改善
                    //以管理员身份运行
                    user = (LogUser)userDetails.HttpGetResponseObj(ConstantMember.LOGUSEROBJ);    //向服务器请求该用户的详细资料
                    HandDataBase.UserData(user, checkBox.Checked);     //保存用户名（密码可选是否保存）
                    //采用多线程通信，用主线程实现被屏蔽代码的方法——打开主窗口
                    MethodInvoker mi = new MethodInvoker(this.InvokeLog_Admin);    //创建委托
                    this.Invoke(mi);
                }
                else if (permissionStr == ConstantMember.USERPERMIT)
                {
                    //以普通用户身份运行
                    user = (LogUser)userDetails.HttpGetResponseObj(ConstantMember.LOGUSEROBJ);    //向服务器请求该用户的详细资料
                    HandDataBase.UserData(user, checkBox.Checked);        //保存用户名（密码可选是否保存）
                    //采用多线程通信，用主线程实现被屏蔽代码的方法——打开主窗口
                    MethodInvoker mi = new MethodInvoker(this.InvokeLog_User);    //创建委托
                    this.Invoke(mi);

                }
                else if (permissionStr == ConstantMember.NOPERMISSION)
                {
                    //禁止登陆，身份不合格
                    //采用多线程通信，用主线程实现被屏蔽代码的方法——没有用户
                    MethodInvoker mi = new MethodInvoker(this.InvokeLog_NoMission);    //创建委托
                    this.Invoke(mi);
                }
                else if (permissionStr == ConstantMember.WRONGPASSWORD)
                {
                    //提示密码错误
                    //采用多线程通信，用主线程实现被屏蔽代码的方法——密码错误
                    MethodInvoker mi = new MethodInvoker(this.InvokeLog_WrongPassword);    //创建委托
                    this.Invoke(mi);
                }
                else if(permissionStr ==ConstantMember.WEBEXCEPTION)
                {
                    //不作处理，此时的结果为网络异常处理之后的结果
                }
                else
                {
                    //采用多线程通信，用主线程实现被屏蔽代码的方法——登录超时
                    Console.WriteLine(permissionStr);
                    MethodInvoker mi = new MethodInvoker(this.InvokeLog_NoResponse);    //创建委托
                    this.Invoke(mi);
                }
            }
        }

        /************************************************
         * 事件处理代码块
         * *********************************************/

        private void logingBtn_Click(object sender, EventArgs e)
        {
            if (!IFREQUESTLOG)
            {
                //LogingRequest();     //调用请求登录方法
                //采用多线程的方式请求登录
                //this.logingBtn.Enabled = false;    //点击登录以后，在服务器做出响应之前不可以在此点击
                Thread thdLogRequest = new Thread(new ThreadStart(LogingRequest));
                thdLogRequest.Start();
            }
            else
            {
                MessageBox.Show("正在登陆，请稍后. . . . . .");
            }
            

        }

        private void cancleLogBtn_Click(object sender, EventArgs e)
        {
            this.Close();   //点击取消按钮，退出登陆
        }

        private void userNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPasswordToBox();     //调用密码自动设置方法，将对应用户的密码自动设置到密码框
        }


    }
}
