using LogingWindow.BaseClass;
using LogingWindow.Data;
using LogingWindow.ToolClass;
using PCClintSoftware.ToolClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 打开该窗口的用户，方便用户自行修改密码等方法的实现
        /// </summary>
        private LogUser user = null;
        /// <summary>
        /// 标志位，判断该用户是否是官员身份
        /// </summary>
        private Boolean ISADMIN = false;
        /// <summary>
        /// 标志位，判断人员列表是否处于收缩（最小）状态，用以实现窗口布局变化而设置
        /// </summary>
        private Boolean ISMIN = false;
        private ArrayList forms = null;
        public static MainForm mainForm;
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数,状态字符</param>
        /// <param name="elder">启动多线程所需要的参数，老人对象</param>
        private delegate void MethodCallerNYY(ElderInfo theElder);
        /// <summary>
        /// 线程间通信代理——主要用于网络异常报告
        /// </summary>
        /// <param name="e">所发生的异常</param>
        private delegate void MethodCell_WE(WebException e);
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LogingWindown.logingWin.Hide();
            mainForm = this;
            this.ISMIN = true;
            LayoutControl();
            InitTheForm();
            MapHandler.ShowBaseMap(this.mainWebBrowser);
            forms=new ArrayList();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HttpRequest request = new HttpRequest(HttpURLs.LOGOUTURL, HttpMethod.GET);
            try
            {
                request.request();
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception.Status);
            }
            finally 
            {
                foreach (Form form in forms) {
                    form.Close();
                }

                LogingWindown.logingWin.Show();
            }
        }
        /***********************************************************************
         * 线程通信代码块
         * **********************************************************/
        /// <summary>
        /// 子线程通知主线程调用的方法，主要用于网络异常时通信
        /// </summary>
        /// <param name="e"></param>
        private void Invoke_WebException(WebException e)
        {
            //由于网络问题，或者url错误引起的异常，导致登录不成功
            Console.Write("主窗口  出现异常：\r" + e);
            if (e.Status.ToString() == "Timeout")
            {
                this.statusLabel_Main.Text = "主窗口  请求超时，请重试. . . . . .";
                this.statusLabel_Main.ForeColor = Color.Red;
            }
            else if (e.Status.ToString() == "ConnectFailure" || e.Status.ToString() == "NameResolutionFailure")
            {      //此时的情景需要查明缘由后决定处理方式
                this.statusLabel_Main.Text = "主窗口  网络连接异常，请检查网络并重试\r" + e.Message;
                this.statusLabel_Main.ForeColor = Color.Red;
            }
            else if (e.Status.ToString() == "ConnectionClosed")
            {
                this.statusLabel_Main.Text = "主窗口  远程服务器尚未开启服务：\r" + e.Message + "\r" + e.Status;
                this.statusLabel_Main.ForeColor = Color.Red;
            }
            else if (e.Message.IndexOf("404", 0) != -1)
            {
                this.statusLabel_Main.Text = "主窗口  请求失败：\r可能是请求地址错误，或者网络连接异常\r" + e.Message;
                this.statusLabel_Main.ForeColor = Color.Red;
            }
            else
            {
                //其他错误提示
                this.statusLabel_Main.Text = "主窗口  登录过程中出现其他网络错误：\r" + e;
                this.statusLabel_Main.ForeColor = Color.Red;
            }
        }

        private void InvokeGetLastRingDT(ElderInfo elder)
        {
            RingRecordDao dao = new RingRecordDao();
            RingRecord record =  dao.getLast(Int32.Parse(elder.id));
            MapHandler.ShowElderPoint(this.mainWebBrowser, elder, record);    //调用人员地图显示函数，参数为通过查询获得的手环信息
        }

        public void UserPermission(Boolean boolean,LogUser theUser)
        {
            this.ISADMIN = boolean;
            this.user = theUser;    //将登录用户对象保存在本地，方便使用
        }
        /// <summary>
        /// 由个人信息修改完成后向主窗口返回该用户的新信息
        /// </summary>
        /// <param name="theUser">修改后的用户</param>
        public void UserDetails(LogUser theUser)
        {
            this.user = theUser;    //将登录用户对象保存在本地，方便使用
        }
        /// <summary>
        /// 该窗口的初始化方法，根据登录权限不同，显示不同的功能
        /// </summary>
        private void InitTheForm()
        {
            if (ISADMIN)
            {
                //*******************************有待完善
                //MessageBox.Show("我是管理员:"+user.userName+"    "+user.userPassword);
                this.Text = "集散化养老智能管理系统——管理员登陆";
            }
            else
            {
                //*******************************有待完善
                //MessageBox.Show("我是平民:"+user.userName);
                //设置对应功能不可用
                this.amendRecord_ToolStripMenuItem.Visible = false;
                this.deleteRecord_ToolStripMenuItem.Visible = false;
                this.newRecord_ToolStripMenuItem.Visible = false;
                this.manager_ToolStripMenuItem.Visible = false;
            }
            ElderDao elderDao = new ElderDao();
            this.dataGridView1.DataSource = elderDao.listNameAsDataTable("");
            for (int i = 0; i < dataGridView1.Columns.Count; i++)     //设定dataGridView1的列宽设定方式
            {
                this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void HttpGetRingDT(Object objSend)
        {
            Object[] objArry = (Object[])objSend;
            RingRecord record = (RingRecord)objArry[0];
            ElderInfo elder = (ElderInfo)objArry[1];
            Boolean hasRecord = false;
            try
            {
                HttpRequest request = new HttpRequest(HttpURLs.GRRINGDATAURL + record.id.ToString(), HttpMethod.GET);
                HttpResponse response = request.request();
                record = response.getResultAsObj<RingRecord>();
                updateRingRecords(record);
                hasRecord = true;
            }
            catch (WebException e)
            {
                MethodCell_WE mcWebException = new MethodCell_WE(Invoke_WebException);
                this.Invoke(mcWebException, e);
                hasRecord = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("MainForm Other Error:\n" + e);
                hasRecord = false;
            }
            finally
            {
                if (hasRecord)
                {
                    MethodCallerNYY ceGetLastRDT = new MethodCallerNYY(InvokeGetLastRingDT);
                    this.BeginInvoke(ceGetLastRDT, elder);
                }
            }
        }

        private void updateRingRecords(RingRecord record1)
        {
            RingRecordDao rDao = new RingRecordDao();
            RingRecord record = rDao.getWithTime(record1.id, record1.time);
            if (!record.validRecord())
            {
                rDao.create(record1);
            }
            else
            {
                Console.WriteLine(record.id + "  的数据是最新的");
            }
        }

        /// <summary>
        /// 显示对应的人员的坐标位置和身体参数，由本窗口的
        /// dataGridView1_RowHeaderMouseDoubleClick事件调用
        /// </summary>
        private void ShowElderPoint()
        {
            //获取所选中行第一列的值，即为所选中列的老人编号
            string selectedElderID = (string)this.dataGridView1.SelectedRows[0].Cells[0].Value;
            RingRecord record = new RingRecord(Int32.Parse(selectedElderID));
            ElderDao dao = new ElderDao();
            ElderInfo elder = dao.get(selectedElderID);
            //尝试向服务器请求最新数据，否则度本地缓存的最新数据
            //*********************************设置合适的请求时间，防止等待时间过长
            this.statusLabel_Main.ForeColor = Color.Blue;
            this.statusLabel_Main.Text = "欢迎使用本系统";
            Object[] objArry = { record, elder };
            Object objSend = objArry;
            ParameterizedThreadStart PTGetRingDT = new ParameterizedThreadStart(HttpGetRingDT);
            Thread thdGetRingDT = new Thread(PTGetRingDT);
            thdGetRingDT.IsBackground = true;
            thdGetRingDT.Start(objSend);
        }
        /// <summary>
        /// 打开人员管理窗口，并显示为指定的页面可选参数有  空  amendRecord   deleteRecord
        /// </summary>
        /// <param name="window"></param>
        private void ShowManageElderWindow(string window)
        {
            Form form = Application.OpenForms["ElderManageForm"];     //获取所有ElderManageForm窗体的对象
            if (form == null)                                          //如果从未打开该对象，则新建并打开窗口
            {
                ElderManageForm managerForm = new ElderManageForm();
                managerForm.showTablech(window);               //指定选项卡的默认加载页面
                managerForm.Show();                            //显示窗口
                forms.Add(managerForm);
            }
            else                                                    //如果已经存在ElderManageForm窗体的对象，则使该窗口获取焦点
            {
                ElderManageForm managerForm = (ElderManageForm)form;
                managerForm.showTablech(window);
                managerForm.Focus();
            }
        }
        /// <summary>
        /// 打开用户个人信息修改窗口，可选页面有修改密码和个人信息两个页面
        /// </summary>
        /// <param name="tabSelect">指定选项卡名称</param>
        private void ShowUserDetailForm(string tabSelect)
        {
            Form form = Application.OpenForms["UserDetailsForm"];           //获取所有ElderManageForm窗体的对象
            if(form==null)
            {
                UserDetailsForm userForm = new UserDetailsForm();
                userForm.InitialForm(this.user, tabSelect);    //将本次登录的用户对象传给用户个人管理窗口,打开对应的选项卡
                userForm.Show();
                forms.Add(userForm);                            //向列表添加元素
            }
            else
            {
                UserDetailsForm userForm = (UserDetailsForm)form;
                userForm.InitialForm(this.user, tabSelect);
                userForm.Focus();                            //使窗口获取焦点
            }
            //*****************************************待改善,无自动切换窗口的功能
            
        }
        /// <summary>
        /// 打开管理员窗口，可选人员列表页面和人员管理两个页面
        /// </summary>
        /// <param name="tabSelect">指定选项卡名称</param>
        private void ShowAdminForm(string tabSelect)
        {
            Form form = Application.OpenForms["AdminForm"];
            if(form==null)
            {
                AdminForm adminForm = new AdminForm();
                adminForm.InitialForm(tabSelect,user);   //初始化该窗口
                adminForm.Show();
                forms.Add(adminForm);                    //向列表添加元素
            }
            else
            {
                AdminForm adminForm = (AdminForm)form;
                adminForm.InitialForm(tabSelect,user);   //初始化该窗口
                adminForm.Focus();
            }
        }
        /// <summary>
        /// 打开更新本地数据库的窗口
        /// </summary>
        /// <param name="isShowRingDataLayout">标志位，判断是否显示更新手环数据的布局，true为显示，false为不显示</param>
        private void ShowHandLocalDataForm(Boolean isShowRingDataLayout)
        {
            Form form = Application.OpenForms["HandLocalDataForm"];
            if (form == null)
            {
                HandLocalDataForm handLDBForm = new HandLocalDataForm();
                handLDBForm.InitialForm(isShowRingDataLayout);   //初始化该窗口
                handLDBForm.Show();
                forms.Add(handLDBForm);                          //向列表添加元素
            }
            else
            {
                HandLocalDataForm handLDBForm = (HandLocalDataForm)form;
                handLDBForm.Focus();
                handLDBForm.InitialForm(isShowRingDataLayout);   //初始化该窗口
                
            }
        }
        /// <summary>
        /// 控制主窗口面的布局，即人员列表的伸拉状态
        /// </summary>
        private void LayoutControl()
        {
            if (ISMIN)
            {
                this.panel1.Width = 220;
                this.panel2.Width = this.Width - this.panel1.Width;
                this.layoutControlBtn.Text = "<<";
                this.ISMIN = false;
            }
            else
            {
                this.panel1.Width = 0;
                this.panel2.Width = this.Width - this.panel1.Width;
                this.layoutControlBtn.Text = ">>";
                this.ISMIN = true;
            }
        }
        /// <summary>
        /// 当鼠标滑过某人时，显示其基本信息
        /// </summary>
        /// <param name="e">C#提供的事件</param>
        private void MouseEnterNameList(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string elderIDs = (string)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;   //获取鼠标划过列的老人ID值
                ElderDao dao = new ElderDao();
                ElderInfo elder = dao.get(elderIDs);
                RingRecordDao rDao = new RingRecordDao();
                RingRecord ring = rDao.getLast(Int32.Parse(elderIDs));
                this.IDLabel.Text = elder.id;
                this.nameLabel.Text = elder.name;
                this.yearLabel.Text = Convert.ToString(OtherTools.BirthdayToYear(elder));
                this.hardRateLabel.Text = ring.physical.heartRate.ToString();
                this.sexLabel.Text = elder.sex;
            }
        }

        private void searchByNameBut_Click(object sender, EventArgs e)
        {
            ElderDao elderDao = new ElderDao();
            this.dataGridView1.DataSource = elderDao.listNameAsDataTable(searchBox.Text);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowElderPoint();//调用显示对应人员坐标和身体参数的方法
        }

        private void newRecord_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManageElderWindow(WinformName.EMFORMCREATRTAB);    //以修改的命令调用打开人员管理窗口的方法，并打开修改窗口
        }

        private void amendRecord_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManageElderWindow(WinformName.EMFORMAMENDRTAB);    //以修改的命令调用打开人员管理窗口的方法，并打开修改窗口
        }

        private void deleteRecord_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManageElderWindow(WinformName.EMFORMDELETRTAB);    //以删除的命令调用打开人员管理窗口的方法，并打开删除窗口
        }

        private void manageDetails_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetailForm(WinformName.UDFORMDETAILTAB);    //以修改密码的命令打开个人信息窗口
        }

        private void changePassword_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetailForm(WinformName.UDFORMPASSWORDTAB);    //以修改密码的命令打开个人信息窗口
        }

        private void layoutControlBtn_Click(object sender, EventArgs e)
        {
            LayoutControl();   //改变窗口显示页
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.panel2.Width = this.Width - this.panel1.Width;    //窗口大小改变时，使控件宽度自适应
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            MouseEnterNameList(e);
        }

        private void checkUser_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAdminForm(WinformName.ADFORMUSERLISTTAB);    //以用户列表的命令打开管理员窗口
        }

        private void manageUser_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAdminForm(WinformName.ADFORMUSERMANAGETAB);  //以管理用户的命令打开管理员窗口
        }

        private void updateElderList_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHandLocalDataForm(false);     //以不显示更新手环数据布局的命令打开HandLocalDataForm窗口
        }

        private void updateRingData_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHandLocalDataForm(true);     //以显示更新手环数据布局的命令打开HandLocalDataForm窗口
        }

        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
