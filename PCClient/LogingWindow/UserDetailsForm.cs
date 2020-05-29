using LogingWindow.BaseClass;
using LogingWindow.ToolClass;
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

        private void InvokeAmendDetails(string amendState, LogUser amendUser)
        {
            if (amendState == HttpRspState.AMENDUSER_SUCCESS)
            {
                user = amendUser; 
                MessageBox.Show("Amend Success!");
            }
            else if (amendState == HttpRspState.AMENDUSER_FAILD)
            {
                MessageBox.Show("Amend Failed!");
            }
            else
            {
                MessageBox.Show("Timeout...");
            }
        }

        private void InvokeAmendDetails(string state)
        {
            if (state == HttpRspState.AMENDPASSWORD_SUCCESS)
            {
                user.userPassword = this.pNewPasswordBox.Text;
                MessageBox.Show("Change Password Success!");
                this.pNewPasswordBox.Text = "";
                this.pConfirmPasswordBox.Text="";
                this.pOldPasswordBox.Text = "";
            }
            else if (state == HttpRspState.AMENDPASSWORD_FAILD)
            {
                //*********************************有待优化
                MessageBox.Show("Change Password Failed!");
            }
            else
            {
                MessageBox.Show("Timeout...");
            }
        }

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
            if (tableName == WinformName.UDFORMDETAILTAB)
            {
                this.userDetailsTab.SelectedTab = userDetails;   //将当先选项卡设置为人员档案修改选项卡
            }
            else if (tableName == WinformName.UDFORMPASSWORDTAB)
            {
                this.userDetailsTab.SelectedTab = amendPassword;   //将当先选项卡设置为人员档案删除选项卡           
            }
            else
            {
                //************************************************
                //this.userDetailsTab.SelectedTab = newRecord;   //将当先选项卡设置为人员档案删除选项卡  
            }
        }

        private void HttpAmendPassword(Object objSend)
        {
            string newPassw = (string)objSend;
            LogUser puser = user.copy();
            puser.userPassword = newPassw;
            string state = "";
            HttpRequest request = new HttpRequest(HttpURLs.AMENDPASSWORDURL, HttpMethod.POST);
            try
            {
                HttpResponse response = request.request(puser);
                state = response.getResult();
            }
            catch (WebException e)
            {
                Console.Write("Change Password Faild due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Change Password Faild due to a WebException! Try Again...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Change Password Faild due to an Other Exception!" + e);
                MessageBox.Show("Change Password Faild due to an Other Exception!");
            }
            finally
            {
                MethodCallerNY mcAmendPassword = new MethodCallerNY(InvokeAmendDetails);
                this.BeginInvoke(mcAmendPassword, state);
            }
        }

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

        private void HttpAmendDetails(Object objSend)
        {
            LogUser amendUser = (LogUser)objSend;
            string amendState = "";
            HttpRequest request = new HttpRequest(HttpURLs.AMENDUSERURL, HttpMethod.POST);
            try
            {
                HttpResponse response = request.request(amendUser);
                amendState = response.getResult();
            }
            catch (WebException e)
            {
                Console.Write("Amend User Infomation Failed due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Amend User Infomation Failed due to a WebException! Try Again..." + e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Amend User Infomation Failed due to an Other Exception!\n" + e);
                MessageBox.Show("Amend User Infomation Failed due to an Other Exception!");
            }
            finally
            {
                MethodCallerNYY mcAmendDetails = new MethodCallerNYY(InvokeAmendDetails);
                this.BeginInvoke(mcAmendDetails, amendState, amendUser);
            }
        }

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
            ParameterizedThreadStart PTSAmendDetails = new ParameterizedThreadStart(HttpAmendDetails);
            Thread thdAmendDetails = new Thread(PTSAmendDetails);
            thdAmendDetails.IsBackground = true;
            thdAmendDetails.Start(amendUser);
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
