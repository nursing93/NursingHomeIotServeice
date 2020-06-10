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
using LogingWindow.ToolClass;
using System.Threading;
using System.Net;
using LogingWindow.BaseClass;

namespace LogingWindow
{
    public partial class LogingWindown : Form
    {
        private string permissionStr="LOGING";
        public static LogingWindown logingWin = null;
        LogUser user = null;
        Boolean IFREQUESTLOG = false;
        private delegate void MethodCell_WE(WebException e);
        private delegate void MethodCell_SS(string strStatus);
        public LogingWindown()
        {
            InitializeComponent();
        }

        private void LogingWindown_Load(object sender, EventArgs e)
        {
            logingWin = this;
            IniNameBox();
        }
        private void LogingWindown_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Invoke_WebException(WebException e)
        {
            this.logingBtn.Enabled = true;
            IFREQUESTLOG = false;
            if (e.Status.ToString() == "Timeout")
            {
                statuLable.Text = "请求超时，请重试. . . . . .";
                statuLable.ForeColor = Color.Red;
            }
            else if (e.Status.ToString() == "ConnectFailure" || e.Status.ToString() == "NameResolutionFailure")
            {     
                //TODO 此时的情景需要查明缘由后决定处理方式
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

        private void InvokeLog_Admin()
        {
            this.logingBtn.Enabled = true;
            if(this.user!=null)
            {
                statuLable.Text = "正在以管理员身份登录";
                IFREQUESTLOG = false;
                MainForm mainForm = new MainForm();
                mainForm.UserPermission(true, user);
                mainForm.Show();
            }
            //TODO 待处理
        }

        private void InvokeLog_User()
        {
            this.logingBtn.Enabled = true;
            if(this.user!=null)
            {
                IFREQUESTLOG = false;
                statuLable.Text = "一般用户登录成功";
                MainForm mainForm = new MainForm();
                mainForm.UserPermission(false, user);
                mainForm.Show();
            }
            //TODO 待处理
        }

        private void InvokeLog_NoMission()
        {
            this.logingBtn.Enabled = true;
            IFREQUESTLOG = false;
            statuLable.Text = "用户名错误，请修改后重试";
            statuLable.ForeColor = Color.Red;
        }

        private void InvokeLog_WrongPassword()
        {
            this.logingBtn.Enabled = true;
            IFREQUESTLOG = false;  
            statuLable.Text = "密码错误";
            statuLable.ForeColor = Color.Red;
        }

        private void InvokeLog_NoResponse()
        {
            this.logingBtn.Enabled = true;
            IFREQUESTLOG = false;
            statuLable.Text = "响应失败，可能是程序出现了不可预估的错误";
            statuLable.ForeColor = Color.Red;
        }

        private void Invoke_InitialStatuLable()
        {
            this.logingBtn.Enabled = false;
            IFREQUESTLOG = true;
            if (userNameBox.Text == "" | userPassWordBox.Text == "")
            {
                statuLable.Text = "请输入用户名或密码后重试";
                statuLable.ForeColor = Color.Red;
                return;
            }
            statuLable.Text = "正在登陆. . . . . .";
            statuLable.ForeColor = Color.DodgerBlue;
            user = new LogUser(userNameBox.Text, userPassWordBox.Text);
        }

        private void IniNameBox()
        {
            this.userNameBox = DataBaseHandler.GetUserList(this.userNameBox);
            if(userNameBox.Items.Count==0)
            {
                return;
            }
            this.userNameBox.Text = userNameBox.Items[0].ToString();
        }

        private void LogingRequest()
        {
            Thread.CurrentThread.IsBackground = true;
            MethodInvoker mi_SB = new MethodInvoker(this.Invoke_InitialStatuLable);
            this.Invoke(mi_SB);
            if (this.user == null)
            {
                return;
            }
            HttpRequest logRequest = new HttpRequest(HttpURLs.LOGINGURL);
            logRequest.setContentType("application/x-www-form-urlencoded");
            string loginReqMsg = "username=" + user.userName + "&password=" + user.userPassword;
            try
            {   //TODO 优化异常处理逻辑
                HttpResponse response = logRequest.request(loginReqMsg);
                permissionStr = response.getResult();
            }
            catch (WebException e)
            {
                dealWithWebException(e);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception：\n" + e);
            }
            finally
            {
                invokeMainWindow();
            }
        }

        void dealWithWebException(WebException e)
        {
            Console.Write("Exception：\n" + e);
            permissionStr = LogingResult.WEBEXCEPTION;
            MethodCell_WE mcWebException = new MethodCell_WE(Invoke_WebException);
            this.Invoke(mcWebException, e);
        }

        private void invokeMainWindow()
        {
            MethodInvoker mi = null;
            if (permissionStr == LogingResult.ADMINISTRATOR)
            {
                getUserDetails();
                mi = new MethodInvoker(this.InvokeLog_Admin);
            }
            else if (permissionStr == LogingResult.USERPERMIT)
            {
                getUserDetails();
                mi = new MethodInvoker(this.InvokeLog_User);
            }
            else if (permissionStr == LogingResult.NOPERMISSION)
            {
                mi = new MethodInvoker(this.InvokeLog_NoMission);
            }
            else if (permissionStr == LogingResult.WRONGPASSWORD)
            {
                mi = new MethodInvoker(this.InvokeLog_WrongPassword);
            }
            else
            {
                mi = new MethodInvoker(this.InvokeLog_NoResponse);
                Console.WriteLine(permissionStr);
            }
            this.Invoke(mi);
        }

        private void getUserDetails() {
            HttpRequest request = new HttpRequest(HttpURLs.QUERYUSERDETAILURL + user.userName, HttpMethod.GET);
            try
            {
                HttpResponse response = request.request();  //TODO 异常处理
                user = response.getResultAsObj<LogUser>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Getting User Infomation Failed!" + e.Message.ToString());
            }
            DataBaseHandler.UserData(user, checkBox.Checked);
        }

        private void logingBtn_Click(object sender, EventArgs e) {
            if (!IFREQUESTLOG) {
                Thread thdLogRequest = new Thread(new ThreadStart(LogingRequest));
                thdLogRequest.Start();
            }
            else {
                MessageBox.Show("正在登陆，请稍后. . . . . .");
            }
        }

        private void cancleLogBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void userNameBox_SelectedIndexChanged(object sender, EventArgs e) {
            SetPasswordToBox();
        }
        private void SetPasswordToBox()
        {
            LogUser user = new LogUser();
            user.userName = userNameBox.Text;
            user = DataBaseHandler.GetUserObj(user);
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
    }
}
