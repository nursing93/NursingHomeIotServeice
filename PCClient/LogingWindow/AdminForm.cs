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
    public partial class AdminForm : Form
    {
        LogUser user;              //本次登录用户
        /// <summary>
        /// 用于传输所需要操作用户的对象；
        /// </summary>
        LogUser usersDetail;  //
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数</param>
        private delegate void MethodCallerNY(string str);
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="userList">服务器传回来的用户列表</param>
        private delegate void MethodCallerNY_UL(List<LogUser> userList);
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数,状态字符</param>
        /// <param name="user">启动多线程所需要的参数，用户对象</param>
        private delegate void MethodCallerNYY(string str, LogUser user);
        /// <summary>
        /// 确保用户名输入框只能输入字母和数字的中间量，用于保存非汉字部分的已输入内容
        /// </summary>
        private string userNameStr = "";      //确保用户名输入框只能输入字母和数字的中间量，用于保存非汉字部分的已输入内容
        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.nSuperiorBox.Text = this.user.userName;
        }
        /**************************************************
         * 多线程通信处理块
         ****************************************************/
        /// <summary>
        /// 子线程通知主线程调用的方法，将服务器返回的用户列表显示在控件上
        /// </summary>
        /// <param name="userList"></param>
        private void InvokeGetUserList(List<LogUser> userList)
        {
            //将userList中所有用户的信息添加到dataGridView1中
            foreach (LogUser user in userList)
            {
                DataGridViewRow dr = new DataGridViewRow();        //新建dataGridView1行对象
                dr.CreateCells(dataGridView1);
                dr.Cells[0].Value = user.userName;
                dr.Cells[1].Value = user.isAdmin;
                dr.Cells[2].Value = user.number;
                dr.Cells[3].Value = user.realName;
                dr.Cells[4].Value = user.sex;
                dr.Cells[5].Value = user.idCard;
                dr.Cells[6].Value = user.birthday;
                dr.Cells[7].Value = user.superior;
                dataGridView1.Rows.Add(dr);                        //向dataGridView1添加新行
            }
        }
        /// <summary>
        /// 子线程通知主线程调用的方法,根据服务器返回的添加状况决策
        /// </summary>
        /// <param name="creatUserState">服务器返回的结果</param>
        private void InvokeAddUser(string creatUserState)
        {
            if (creatUserState == HttpRspState.CREATUSER_SUCCESS)
            {
                //******************************待优化
                MessageBox.Show("添加用户成功");
            }
            else if (creatUserState == HttpRspState.CREATUSER_FAILD)
            {
                //******************************待优化
                MessageBox.Show("添加用户失败");
            }
            else if (creatUserState == HttpRspState.CREATUSER_SAMENAME)
            {
                MessageBox.Show("用户名已存在\r请更换用户名后重试");
            }
            else
            {
                //******************************待优化
                MessageBox.Show("请求超时，请重试");
            }
        }
        /// <summary>
        /// 子线程通知主线程调用的方法,根据服务器返回的删除状况决策
        /// </summary>
        /// <param name="deleteUserState"></param>
        private void InvokeDeleteUser(string deleteUserState)
        {
            if (deleteUserState == HttpRspState.DELETEUSER_SUCCESS)
            {
                //******************************待优化
                MessageBox.Show("删除用户成功");
            }
            else if (deleteUserState == HttpRspState.DELETEUSER_FAILD)
            {
                //******************************待优化
                MessageBox.Show("删除用户失败");
            }
            else
            {
                //******************************待优化
                MessageBox.Show("请求超时，请重试");
            }
        }
        /****************************************************
         * 自定义方法
         * ************************************************/
        /// <summary>
        /// 启动窗口前先初始化该窗口，确定需要打开哪个选项卡,由主窗口调用
        /// </summary>
        /// <param name="tabSelect">将要显示的选项卡的名称</param>
        /// <param name="theUser">本次登录用户</param>
        public void InitialForm(string tabSelect,LogUser theUser)
        {
            user = theUser;   //设置用户
            if (tabSelect == WinformName.ADFORMUSERLISTTAB)
            {
                this.AdminTabControl.SelectedTab = userListPage;
            }
            else if (tabSelect == WinformName.ADFORMUSERMANAGETAB)
            {
                this.AdminTabControl.SelectedTab = userManagePage;
                this.nSuperiorBox.Text = user.userName;
            }
        }
        /// <summary>
        /// 向服务器请求用户列表，并显示在控件中，该方法只有在“显示用户”选项卡启用时才调用
        /// </summary>
        private void ShowUserNameList()
        {
            HttpProvider queryAllUserList = new HttpProvider(HttpURLs.QUERYALLUSERURL, HttpMethod.GET);  //get方式向服务器请求所有用户信息
            List<LogUser> userList = new List<LogUser>();
            //*****************************测试代码段，待删除
            //userList = LogingWindow.Test.HttpTest.UserListTest.getUserList();
            try
            {
                userList = (List<LogUser>)queryAllUserList.HttpGetResponseObj(JsonToObjectType.LISTLOGUSEROBJ);
                //*****************************测试代码段，待删除
                //userList = LogingWindow.Test.HttpTest.UserListTest.getUserList();
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("请求用户列表  出现异常：\r" + e);
                MessageBox.Show("由于网络原因\r添刷新用户列表失败  请重试. . . . . .");
            }
            catch (Exception e)
            {
                //其他异常导致请求失败
                Console.Write("请求用户列表  其他异常导致失败：\r" + e);
                MessageBox.Show("请求用户列表   其他异常导致失败");
                //*****************************测试代码段，待删除
                userList = LogingWindow.Test.HttpTest.UserListTest.getUserList();
            }
            finally
            {
                //向主线程发送服务器的返回结果，并由主线程来决定后续操作
                MethodCallerNY_UL mcGetUserList = new MethodCallerNY_UL(InvokeGetUserList);
                this.BeginInvoke(mcGetUserList,userList);
            }
        }
        /// <summary>
        /// 多线程启动的方法，向服务器发起请求，只有方法CreatUser可以调用
        /// </summary>
        /// <param name="objSend"></param>
        private void HttpAddUser(Object objSend)
        {
            LogUser creatUser = (LogUser)objSend;
            //请求体
            HttpProvider creatUserReq = new HttpProvider(HttpURLs.ADDUSERURL, HttpMethod.POST);  //向服务器发出请求，新增用户
            string creatUserState = "";        //获取请求状态的字符串
            //********************************************异常处理过于粗糙，有待改善
            try
            {
                creatUserState = creatUserReq.HttpRquestStr(creatUser);     //发送请求
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("添加新用户  出现异常：\r" + e);
                MessageBox.Show("由于网络原因\r添加新用户失败  请重试. . . . . .");
            }
            catch (Exception exception)
            {
                //其他异常导致添加失败
                Console.Write("添加新用户  其他异常导致新建失败：\r" + exception);
                MessageBox.Show("添加新用户   其他异常导致新建失败：\r");
            }
            finally
            {
                //通知主线程，将服务器返回的状态反馈给主线程，并由主线程决定后续操作
                MethodCallerNY mcAddUser = new MethodCallerNY(InvokeAddUser);
                this.BeginInvoke(mcAddUser, creatUserState);
            }
        }
        /// <summary>
        /// 请求添加新成员的方法
        /// </summary>
        private void CreatUser()
        {
            LogUser creatUser = new LogUser();
            creatUser.superior = this.nSuperiorBox.Text;
            creatUser.userName = this.nUserNameBox.Text;
            creatUser.userPassword = this.nPasswordBox.Text;
            creatUser.number = this.nUserIDBox.Text;
            creatUser.sex = this.nSexBox.Text;
            creatUser.isAdmin = IsAdminBoxToInt(this.nIsAdminBox.Text);
            creatUser.idCard = this.nIDCardBox.Text;
            creatUser.realName = this.nRealNameBox.Text;
            creatUser.birthday = OtherTools.DateTimeToString(this.nBirthdayBox.Value);
            //使用多线程的方式发送新建用户的请求
            ParameterizedThreadStart PTHAddUser = new ParameterizedThreadStart(HttpAddUser);
            Thread thdAddUser = new Thread(PTHAddUser);
            thdAddUser.IsBackground = true;
            thdAddUser.Start(creatUser);
        }
        /// <summary>
        /// 多线程启动的方法，向服务器发起请求，只有方法DeleteUser可以调用
        /// </summary>
        /// <param name="objSend"></param>
        private void HttpDeleteUser(Object objSend)
        {
            LogUser deleteUser = (LogUser)objSend;
            //请求体
            HttpProvider deleteUserReq = new HttpProvider(HttpURLs.DELETEUSERURL + deleteUser.userName, HttpMethod.GET);  //向服务器发出请求，新增用户
            string deleteUserState = "";        //获取请求状态的字符串
            try
            {
                deleteUserState = deleteUserReq.HttpRquestStr(deleteUser);     //发送请求
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("删除用户  出现异常：\r" + e);
                MessageBox.Show("由于网络原因\r删除用户失败  请重试. . . . . .");
            }
            catch (Exception exception)
            {
                //其他异常导致删除失败
                Console.Write("删除用户  其他异常导致删除失败：\r" + exception);
                MessageBox.Show("删除用户     其他异常导致删除失败：\r");
            }
            finally
            {
                //通知主线程，将服务器返回的状态反馈给主线程，并由主线程决定后续操作
                MethodCallerNY mcDeleteUser = new MethodCallerNY(InvokeDeleteUser);
                this.BeginInvoke(mcDeleteUser, deleteUserState);
            }
        }
        /// <summary>
        /// 向服务器请求删除指定用户的方法
        /// </summary>
        private void DeleteUser()
        {
            LogUser deleteUser = new LogUser();
            deleteUser.superior = this.dSuperiorBox.Text;
            deleteUser.userName = this.dUserNameBox.Text;
            //deleteUser.userPassword = this.dPasswordBox.Text;    //无password的编辑框
            deleteUser.number = this.dUserIDBox.Text;
            deleteUser.sex = this.dSexBox.Text;
            deleteUser.isAdmin = IsAdminBoxToInt(this.dIsAdminBox.Text);
            deleteUser.idCard = this.dIDCardBox.Text;
            deleteUser.realName = this.dRealNameBox.Text;
            deleteUser.birthday = this.dBirthdayBox.Text;
            //采取多线程的方式调用删除用户的请求
            ParameterizedThreadStart TSDeleteUser = new ParameterizedThreadStart(HttpDeleteUser);
            Thread thdDeleteUser = new Thread(TSDeleteUser);
            thdDeleteUser.IsBackground = true;
            thdDeleteUser.Start(deleteUser);
        }
        /// <summary>
        /// 当右键点击dataGridView1时的处理函数
        /// </summary>
        /// <param name="e"></param>
        private void DataGridRightClick(DataGridViewCellMouseEventArgs e)
        {
            this.Focus();
            if (e.Button == MouseButtons.Right )
            {
                usersDetail = new LogUser();
                usersDetail.userName = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                usersDetail.isAdmin = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                usersDetail.number = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                usersDetail.realName = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                usersDetail.sex = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                usersDetail.idCard = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                usersDetail.birthday = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                usersDetail.superior = this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                //显示右键菜单
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);     //
            }
        }
        /// <summary>
        /// 显示删除用户页面
        /// </summary>
        private void ShowDeleteUsersLayout()
        {
            this.dUserNameBox.Text = usersDetail.userName;
            this.dIsAdminBox.Text = usersDetail.isAdmin.ToString();
            this.dSexBox.Text = usersDetail.sex;
            this.dIDCardBox.Text = usersDetail.idCard;
            this.dBirthdayBox.Text = usersDetail.birthday;
            this.dSuperiorBox.Text = usersDetail.superior;
            this.dRealNameBox.Text = usersDetail.realName;
            this.dUserIDBox.Text = usersDetail.number;
            this.AdminTabControl.SelectedTab = userManagePage;
            this.userManageTabControl.SelectedTab = deleteUserTab;
        }
        /// <summary>
        /// 根据填写情况将新增用户的管理员权限转换成0,1两种数字，方便发送
        /// </summary>
        /// <param name="isAdminStr">新增用户是否管理员，汉字“是”或者“无”</param>
        /// <returns></returns>
        private int IsAdminBoxToInt(string isAdminStr)
        {
            int isUserAdmin = -1;    //判断新建用户是否管理员的辅助变量
            if (isAdminStr == "是")
            {
                isUserAdmin = 1;     //是管理员
            }
            else if (isAdminStr == "无")
            {
                isUserAdmin = 0;    //不是管理员
            }
            else
            {
                isUserAdmin = -1;
            }
            return isUserAdmin;
        }
        /*****************************************
         * 事件处理代码块
         * ************************************/
        private void userListPage_Enter(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count != 0)
            {
                //如果表中已经有数据，则不作改变，此代码段不可少
                return;
            }
            //****************************************建议采用多线程处理该功能
            //当打开用户列表选项卡时，向服务器请求用户列表及其详细信息
            ThreadStart TSGetUserList = new ThreadStart(ShowUserNameList);
            Thread thdGetUserList = new Thread(TSGetUserList);
            thdGetUserList.IsBackground = true;
            thdGetUserList.Start();
            //ShowUserNameList();    //当打开用户列表选项卡时，向服务器请求用户列表及其详细信息
        }

        private void nSaveUserBtn_Click(object sender, EventArgs e)
        {
            foreach(Control ct in this.creatUserTab.Controls)
            {
                if(ct is TextBox)
                {
                    if(ct.Text=="")
                    {
                        MessageBox.Show("信息不完整，请完善信息后重试");
                        return;     //直接跳出该方法体
                    }
                }
            }
            CreatUser();      //请求添加新成员
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ct in this.deleteUserTab.Controls)
            {
                if (ct is TextBox)
                {
                    if (ct.Text == "")
                    {
                        MessageBox.Show("未选择将要删除的用户，请完善信息后重试");
                        return;     //直接跳出该方法体
                    }
                }
            }
            if (dIsAdminBox.Text == "是" && user.userName != dSuperiorBox.Text)   //如果所操作的用户不是当前用户添加的，则不允许删除
            {
                MessageBox.Show("对不起，您无权删除该管理员！");
                return;
            }
            DeleteUser();   //调用请求删除指定用户的方法            
        }

        private void nCancleSaveBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dCancleDeleteBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            DataGridRightClick(e);    //
            this.TopMost = true;
            this.TopMost = false;
            //MessageBox.Show("显示着呢**************");
        }

        private void deleteUser_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDeleteUsersLayout();   //
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
        private void nUserNameBox_TextChanged(object sender, EventArgs e)    //保证用户名输入框只能输入字母和数字以及特殊字符
        {
            foreach (char chars in this.nUserNameBox.Text)
            {
                if (chars>=0x4e00&&chars<=0x9fa5||chars==' ')
                {
                    //MessageBox.Show("有汉字");
                    this.nUserNameBox.Text = "";
                    this.nUserNameBox.AppendText(userNameStr);
                    return;
                }
            }
            if (this.nUserNameBox.Text!="")
            {
                userNameStr = this.nUserNameBox.Text;
            }
        }

        
    }
}
