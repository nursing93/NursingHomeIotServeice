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
    public partial class HandLocalDataForm : Form
    {
        /// <summary>
        /// 标志位，用于判断用户列表窗口是否处于最小状态
        /// </summary>
        private Boolean ISMIN = false;
        /// <summary>
        /// 线程间通信代理
        /// </summary>
        /// <param name="str">数据更新条目状态字符</param>
        private delegate void MethodCell_S(string str);
        /// <summary>
        /// 线程间通信代理
        /// </summary>
        /// <param name="i">数据更新的数量</param>
        private delegate void MethodCell_INT(int i);
        public HandLocalDataForm()
        {
            InitializeComponent();
        }

        private void HandLocalDataForm_Load(object sender, EventArgs e)
        {
            //ChangeLayout(false);             //以不更改窗口布局的命令调用显示数据方法
        }

        /**************************************************
        * 多线程通信处理块
        ****************************************************/
        /// <summary>
        /// 以文字的方式提示更新进度
        /// </summary>
        /// <param name="str"></param>
        private void UpdateStatus(string str)
        {
            this.statusLabel_RingDT.Text = str;
        }
        /// <summary>
        /// 以进度条的形式提示进度
        /// </summary>
        /// <param name="i"></param>
        private void UpdateprogressBar(int i)
        {
            this.progressBar_RingDT.Value = i;
        }
        /// <summary>
        /// 老人列表刷新完毕后，由主线程更新列表
        /// </summary>
        private void InvokeUpdateLocalEL()
        {
            //this.dataGridView1.DataSource = HandDataBase.GetNameList("");     //更新本地数据库成功后，刷新列表，返回本地数据库的人员列表
            ChangeLayout(false);
        }
        /************************************************
         * 自定义代码块
         * *********************************************/
        /// <summary>
        /// 初始化窗口，判断打开窗口时是否显示更新手环数据的布局，true为显示，false为不显示，由主窗口调用
        /// </summary>
        /// <param name="isShowRingLayout">标志位，判断是否显示更新手环数据的布局</param>
        public void InitialForm(Boolean isShowRingLayout)
        {
            if (isShowRingLayout)
            {
                this.ISMIN = true;      //由于之后会触发窗口的加载事件，事件中调用了不改变布局的ChangeLayout()方法
            }
            else
            {
                this.ISMIN = false;
            }
            //if(!this.IsDisposed)
            //{
                ChangeLayout(false);             //以不更改窗口布局的命令调用显示数据方法
            //}
            
        }
        
        /// <summary>
        /// 显示本窗口数据的方法体，提供更改本窗口布局的功能
        /// </summary>
        /// <param name="ifChange">判断调用该方法时是否要求更改布局，true需要更改，false不需要更改</param>
        private void ChangeLayout(Boolean ifChange)
        {
            if(!ifChange)
            {
                this.ISMIN = !this.ISMIN;      //将标志位取反，再调用更改布局的方法，由于本按钮事件的作用是只显示列表，而不更改
            }
            if (ISMIN)
            {
                //将窗口的人员列表布局设为较大布局置为——置为大
                this.ISMIN = false;   //标志位置为false
                this.changeLayoutBtn.Text = "<<";          //将按钮的样式换成缩小指示
                this.panel1.Width = this.Width;
                this.panel2.Width = this.Width - this.panel1.Width;
                this.dataGridView1.DataSource = HandDataBase.GetNameList_AllColums("");     //返回本地数据库的人员列表
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    if (i == this.dataGridView1.Columns.Count - 1)
                    {
                        this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            else
            {
                //将窗口的人员列表布局设为较小布局置为——置为小
                this.ISMIN = true;           //标志位置为false
                this.changeLayoutBtn.Text = ">>";          //将按钮的样式换成放大指示
                this.panel1.Width = 170;
                this.panel2.Width = this.Width - this.panel1.Width;
                this.dataGridView1.DataSource = HandDataBase.GetNameList("");     //返回本地数据库的人员列表
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
        /// <summary>
        /// 向服务器发出请求，并更新本地数据库的老人列表，建议采用多线程调用该方法
        /// </summary>
        private void UpdateLocalElderList()
        {
            HttpProvider queryAllElder = new HttpProvider(HttpURLs.QUERYALLELDERURL, HttpMethod.GET);  //get方式向服务器请求所有用户信息
            List<ElderInfor> elderList = new List<ElderInfor>();
            //*******************************异常处理太粗糙，待优化
            try
            {
                elderList = (List<ElderInfor>)queryAllElder.HttpGetResponseObj(JsonToObjectType.LISTELDEROBJ);
                //*********************************测试代码，待删除
                //elderList = LogingWindow.Test.HttpTest.UserListTest.getElderList();
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("更新列表  出现异常：\r" + e);
                MessageBox.Show("列表更新失败   请重试");
            }
            catch (Exception e)
            {
                //*************************请求失败时的处理方法，待优化
                MessageBox.Show("更新列表    其他异常导致更新失败" + e);
            }
            finally
            {
                MethodCell_INT mcUpdateProgressBar = new MethodCell_INT(UpdateprogressBar);   //新建代理
                MethodCell_S mcUpdateStatus = new MethodCell_S(UpdateStatus);
                int i = 0;    //计算进度条的进度
                this.BeginInvoke(mcUpdateStatus, "正在更新在院人员列表. . . . . .");
                foreach (ElderInfor elder in elderList)
                {
                    //更新进度条
                    i++;           //每次循环都加1
                    //更新进度条
                    if (elderList.Count > 0)
                    {
                        int j = i * 100 / (elderList.Count);
                        this.BeginInvoke(mcUpdateProgressBar, j);    //需要同步通信，不可异步通信*********************************************
                        Console.WriteLine(j);
                    }
                    //实际操作
                    ElderInfor elder_Select = new ElderInfor(elder.elderID);          //读取当前老人的id
                    //在数据库中查询该老人，切记，
                    //HandDataBase.GetElderRecord(elder_Select)方法会直接改变参数elder_Select的所有属性，使之与数据库已有数据相等
                    if (HandDataBase.GetElderRecord(elder_Select).elderID == "")
                    {
                        //****************************测试代码，待删除
                        Console.WriteLine("没有用户 " + elder.elderID + "    " + elder.elderName + "  的资料");
                        HandDataBase.CreatElderRecord(elder);    //如果没有对应老人的数据，就新建一条老人信息，并新建手环数据表
                    }
                    else if (elder.equals(HandDataBase.GetElderRecord(elder_Select)))
                    {
                        //****************************测试代码，待删除
                        Console.WriteLine("有这个人：" + elder.elderID + "  " + elder.elderName
                                          + "而且资料是最新的" + "  " + elder_Select.elderChild);
                        //空操作  如果有对应老人的信息，且信息相同，则不作处理
                    }
                    else
                    {
                        Console.WriteLine("有这个人：" + elder.elderID + "  " + elder.elderName
                                         + "但是资料需要更新" + "  " + elder_Select.elderChild);
                        HandDataBase.AmendElderRecord(elder);        //如果有对应老人的数据，且信息不相等，就刷新其内容
                    }
                }
                //子线程通知主线程，列表更新完毕，主线程刷新列表
                MethodInvoker miUpdateLocalEL = new MethodInvoker(InvokeUpdateLocalEL);
                this.BeginInvoke(miUpdateLocalEL);
                //更新状态栏字符
                this.Invoke(mcUpdateStatus, "在院人员列表更新成功");
                Console.WriteLine("在院人员列表更新成功");
                Thread.Sleep(2000);
                //MessageBox.Show("在院人员列表更新成功！！！");    //更换另一种提醒方式
                this.BeginInvoke(mcUpdateStatus, "");    //显示两秒后清除
                this.BeginInvoke(mcUpdateProgressBar, 0);   //清除进度
                
            }
        }
        /// <summary>
        /// 向服务器请求指定老人的指定时间段的所有手环数据
        /// </summary>
        /// <param name="elderID">所需查询手环数据的老人ID</param>
        /// <param name="startTime">查询的起始时间</param>
        /// <param name="endTime">查询的终止时间</param>
        private void UpdateLocalRingData(Object objSend)
        {
            //将所需要的参数解析出来
            Object[] objArry=(Object[])objSend;
            string elderID=(string)objArry[0];
            string startTime=(string)objArry[1];
            string endTime = (string)objArry[2];
            //**************************************URL不全，缺少参数
            //以get方式，请求对应老人的指定时间段内的手环数据
            HttpProvider queryElderAllRingData = new HttpProvider(HttpURLs.QEALLRINGDATAURL + elderID + "/" + startTime + "/" + endTime, HttpMethod.GET);
            //Console.WriteLine(queryElderAllRingData.ToString());
            List<RingData> ringDataList = new List<RingData>();    
            //********************************异常处理太粗糙，有待改善
            try
            {
                ringDataList = (List<RingData>)queryElderAllRingData.HttpGetResponseObj(JsonToObjectType.LISTRINGDATAOBJ);        //
                //************************************测试代码段，待删除
                //ringDataList = LogingWindow.Test.HttpTest.UserListTest.getRingDataList(elderID);
                //Console.WriteLine(ringDataList.Count);
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("更新列表  出现异常：\r" + e);
                MessageBox.Show("更新手环数据更新失败   请重试");
            }
            catch (Exception e)
            {
                //其他异常导致更新失败
                MessageBox.Show("更新手环数据    其他异常导致更新失败：" + e);
                return;
            }
            MethodCell_INT mcUpdateProgressBar = new MethodCell_INT(UpdateprogressBar);   //新建代理
            MethodCell_S mcUpdateStatus = new MethodCell_S(UpdateStatus);
            int i = 0;    //计算进度条的进度
            this.BeginInvoke(mcUpdateStatus, "正在更新“" + elderID + "”的手环数据表. . . . . .");
            foreach (RingData elderRing in ringDataList)
            {
                i++;           //每次循环都加1
                //更新进度条
                if (ringDataList.Count>0)
                {
                    int j = i * 100 / (ringDataList.Count);
                    this.BeginInvoke(mcUpdateProgressBar, j);    //需要同步通信，不可异步通信*********************************************
                    Console.WriteLine(j);
                }
                //实际操作
                RingData ringData = new RingData(elderRing.curID);
                ringData.datetime = elderRing.datetime;      //令两者的时间一样
                if (HandDataBase.GetRingDataByTime(ringData).lat == "")
                {
                    //如果该时间点的数据，插入数据
                    Console.WriteLine(elderRing.curID + "  " + elderRing.datetime + "  " + elderRing.lat
                                      + "  " + elderRing.lng + "  " + elderRing.heartRate);
                    HandDataBase.SaveRingData(elderRing);     //如果没有改时间点的数据，就插入该数据
                }
                else
                {
                    //如果有该时间点数据，不作其他处理
                    Console.WriteLine("老人“" + this.elderNameBox.Text + "”已经有时间点“" + elderRing.datetime.ToString() + "”的数据");
                }
            }
            //更新状态栏字符
            this.Invoke(mcUpdateStatus, "人员“" + elderID + "”有 " + ringDataList.Count.ToString() + " 条手环数据更新成功");
            Console.WriteLine("人员“" + elderID + "”有 " + ringDataList.Count.ToString() + " 条手环数据更新成功");
            //MessageBox.Show("人员“"+elderID+"”有 "+ringDataList.Count.ToString()+" 条手环数据更新成功");    //更换为其他方式
            Thread.Sleep(2000);
            this.BeginInvoke(mcUpdateStatus,"");    //显示两秒后清除
            this.BeginInvoke(mcUpdateProgressBar, 0);   //清除进度
        }
        /**************************************
         * 事件处理代码块
         * **************************************/
        private void showLocalListBtn_Click(object sender, EventArgs e)
        {
            ChangeLayout(false);    //以不更改窗口布局的命令调用显示数据方法            
        }
        
        private void updateLocalListBtn_Click(object sender, EventArgs e)
        {
            //*****************************************此处应当加入更新前询问，并采用多线程处理
            if (MessageBox.Show("确定要从服务器更新在院人员名单到本地？", "数据管理",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                //****************************************建议采用多线程处理该功能
                //采用多线程的方式请求更新数据本地数据   //调用更新老人表方法
                ThreadStart THUpdateLocalEL=new ThreadStart(UpdateLocalElderList);
                Thread thdUpdateLocalEL = new Thread(THUpdateLocalEL);
                thdUpdateLocalEL.IsBackground = true;
                thdUpdateLocalEL.Start();
            }
        }

        private void changeLayoutBtn_Click(object sender, EventArgs e)
        {
            ChangeLayout(true);            //以更改窗口布局的命令调用显示数据方法
        }

        private void updateRingDataBtn_Click(object sender, EventArgs e)
        {
            //*************************************为测试该段代码
            if(this.elderIDBox.Text==""||this.sDateTimePicker.Text==""|| this.eDateTimePicker.Text=="")
            {
                MessageBox.Show("请选择查询内容！！！！");
                return;
            }
            //采用多线程请求更新手环数据
            Object[] objArry = { this.elderIDBox.Text, OtherTools.DateTimeToString(this.sDateTimePicker.Value)+" 00:00:01",
                                                       OtherTools.DateTimeToString(this.eDateTimePicker.Value)+" 23:59:59" };
            Object objSend = objArry;
            ParameterizedThreadStart PTUpdateRD = new ParameterizedThreadStart(UpdateLocalRingData);
            Thread thdUpdateRD = new Thread(PTUpdateRD);
            thdUpdateRD.IsBackground = true;
            thdUpdateRD.Start(objSend);            
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.elderIDBox.Text = (string)this.dataGridView1.SelectedRows[0].Cells[0].Value;       //给ID输入框赋值
            this.elderNameBox.Text = (string)this.dataGridView1.SelectedRows[0].Cells[1].Value;     //给姓名输入框赋值
            if (!this.ISMIN)
            {
                ChangeLayout(true);          //如果人员列表不是小型布局，则更改为小型布局
            }
        }



        
    }
}
