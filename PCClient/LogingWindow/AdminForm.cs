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

        private void InvokeAddUser(string creatUserState)
        {
            if (creatUserState == HttpRspState.CREATUSER_SUCCESS)
            {
                MessageBox.Show("Add User Success!");
            }
            else if (creatUserState == HttpRspState.CREATUSER_FAILD)
            {
                MessageBox.Show("Add User Failed!");
            }
            else if (creatUserState == HttpRspState.CREATUSER_SAMENAME)
            {
                MessageBox.Show("Username already Existed, Try Again with another Username");
            }
            else
            {
                MessageBox.Show("Timeout...");
            }
        }

        private void InvokeDeleteUser(string deleteUserState)
        {
            if (deleteUserState == HttpRspState.DELETEUSER_SUCCESS)
            {
                MessageBox.Show("Delete Success!");
            }
            else if (deleteUserState == HttpRspState.DELETEUSER_FAILD)
            {
                MessageBox.Show("Delete Faild!");
            }
            else
            {
                MessageBox.Show("Timout...");
            }
        }

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

        private void ShowUserNameList()
        {
            HttpRequest request = new HttpRequest(HttpURLs.QUERYALLUSERURL, HttpMethod.GET);
            List<LogUser> userList = new List<LogUser>();
            try
            {
                HttpResponse response = request.request();
                userList = response.getResultAsObjList<LogUser>();
            }
            catch (WebException e)
            {
                Console.Write("Getting All Users Faild due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Getting All Users Faild due to a WebException! Try Again...");
            }
            catch (Exception e)
            {
                Console.Write("Getting All Users Faild due to an Other Exception!\n" + e);
                MessageBox.Show("Getting All Users Faild due to an Other Exception!");
            }
            finally
            {
                MethodCallerNY_UL mcGetUserList = new MethodCallerNY_UL(InvokeGetUserList);
                this.BeginInvoke(mcGetUserList,userList);
            }
        }

        private void HttpAddUser(Object objSend)
        {
            LogUser creatUser = (LogUser)objSend;
            HttpRequest request = new HttpRequest(HttpURLs.ADDUSERURL, HttpMethod.POST);
            string creatUserState = "";
            try
            {
                HttpResponse response = request.request(creatUser);
                creatUserState = response.getResult();
            }
            catch (WebException e)
            {
                Console.Write("Add User Failed due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Add User Failed due to a WebException! Try Again...");
            }
            catch (Exception exception)
            {
                Console.Write("Add User Failed due to an Other Exception!\n" + exception);
                MessageBox.Show("Add User Failed due to an Other Exception!");
            }
            finally
            {
                MethodCallerNY mcAddUser = new MethodCallerNY(InvokeAddUser);
                this.BeginInvoke(mcAddUser, creatUserState);
            }
        }

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
            ParameterizedThreadStart PTHAddUser = new ParameterizedThreadStart(HttpAddUser);
            Thread thdAddUser = new Thread(PTHAddUser);
            thdAddUser.IsBackground = true;
            thdAddUser.Start(creatUser);
        }

        private void HttpDeleteUser(Object objSend)
        {
            LogUser deleteUser = (LogUser)objSend;
            HttpRequest request = new HttpRequest(HttpURLs.DELETEUSERURL + deleteUser.userName, HttpMethod.GET);
            string deleteUserState = "";
            try
            {
                HttpResponse response = request.request(deleteUser);
                deleteUserState = response.getResult();
            }
            catch (WebException e)
            {
                Console.Write("Delete User Faild due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Delete User Faild due to a WebException! Try Again...");
            }
            catch (Exception exception)
            {
                Console.Write("Delete User Faild due to an Other Exception!" + exception);
                MessageBox.Show("Delete User Faild due to an Other Exception!");
            }
            finally
            {
                MethodCallerNY mcDeleteUser = new MethodCallerNY(InvokeDeleteUser);
                this.BeginInvoke(mcDeleteUser, deleteUserState);
            }
        }

        private void DeleteUser()
        {
            LogUser deleteUser = new LogUser();
            deleteUser.superior = this.dSuperiorBox.Text;
            deleteUser.userName = this.dUserNameBox.Text;
            deleteUser.number = this.dUserIDBox.Text;
            deleteUser.sex = this.dSexBox.Text;
            deleteUser.isAdmin = IsAdminBoxToInt(this.dIsAdminBox.Text);
            deleteUser.idCard = this.dIDCardBox.Text;
            deleteUser.realName = this.dRealNameBox.Text;
            deleteUser.birthday = this.dBirthdayBox.Text;
            ParameterizedThreadStart TSDeleteUser = new ParameterizedThreadStart(HttpDeleteUser);
            Thread thdDeleteUser = new Thread(TSDeleteUser);
            thdDeleteUser.IsBackground = true;
            thdDeleteUser.Start(deleteUser);
        }

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
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

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
