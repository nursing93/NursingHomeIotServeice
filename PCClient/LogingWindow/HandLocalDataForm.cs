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
                this.dataGridView1.DataSource = DataBaseHandler.GetNameList_AllColums("");     //返回本地数据库的人员列表
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
                this.dataGridView1.DataSource = DataBaseHandler.GetNameList("");     //返回本地数据库的人员列表
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void UpdateLocalElderList()
        {
            HttpRequest request = new HttpRequest(HttpURLs.QUERYALLELDERURL, HttpMethod.GET);
            List<ElderInfor> elderList = null;
            try  //TODO 优化异常处理逻辑
            {
                HttpResponse response = request.request();
                elderList = response.getResultAsObj<List<ElderInfor>>();
            }
            catch (WebException e)
            {
                elderList = new List<ElderInfor>();
                Console.Write("Update Failed：\n" + e);
                MessageBox.Show("Update Failed due to a WebException! Please Try Again...");
            }
            catch (Exception e)
            {
                elderList = new List<ElderInfor>();
                MessageBox.Show("Update Failed due to an Unkown Cause!" + e);
                MessageBox.Show("Update Failed due to an Unkown Cause!");
            }
            finally
            {
                updateElderCache(elderList);
            }
        }

        private void updateElderCache(List<ElderInfor> elderList)
        {
            MethodCell_INT mcUpdateProgressBar = new MethodCell_INT(UpdateprogressBar);
            MethodCell_S mcUpdateStatus = new MethodCell_S(UpdateStatus);
            int i = 0;
            this.BeginInvoke(mcUpdateStatus, "Updating. . . . . .");
            foreach (ElderInfor elder in elderList)
            {
                i++;
                //更新进度条
                if (elderList.Count > 0)
                {
                    int j = i * 100 / (elderList.Count);
                    this.BeginInvoke(mcUpdateProgressBar, j);    //TODO 需要同步通信，不可异步通信
                    Console.WriteLine(j);
                }
                ElderInfor elder_Select = new ElderInfor(elder.elderID);
                if (DataBaseHandler.GetElderRecord(elder_Select).elderID == "")
                {
                    Console.WriteLine("Has no Elder's Info with id = " + elder.elderID + ", name = " + elder.elderName + ".");
                    DataBaseHandler.CreatElderRecord(elder);
                }
                else if (elder.equals(DataBaseHandler.GetElderRecord(elder_Select)))
                {
                    Console.WriteLine("Elder：id = " + elder.elderID + ", name = " + elder.elderName
                                      + " Info is latest" + ", chileds: " + elder_Select.elderChild);
                }
                else
                {
                    Console.WriteLine("Updating Elder：id = " + elder.elderID + ", name = " + elder.elderName
                                     + "Info..." + ", childs: " + elder_Select.elderChild);
                    DataBaseHandler.AmendElderRecord(elder);
                }
            }

            MethodInvoker miUpdateLocalEL = new MethodInvoker(InvokeUpdateLocalEL);
            this.BeginInvoke(miUpdateLocalEL);

            this.Invoke(mcUpdateStatus, "在院人员列表更新成功！");
            Console.WriteLine("Update Elders' Infomation Seccess!");
            Thread.Sleep(2000);
            this.BeginInvoke(mcUpdateStatus, "");
            this.BeginInvoke(mcUpdateProgressBar, 0);
        }

        private void UpdateLocalRingData(Object objSend)
        {
            Object[] objArry=(Object[])objSend;
            string elderID=(string)objArry[0];
            string startTime=(string)objArry[1];
            string endTime = (string)objArry[2];
            //TODO URL不全，缺少参数
            HttpRequest request = new HttpRequest(HttpURLs.QEALLRINGDATAURL + elderID + "/" + startTime + "/" + endTime, HttpMethod.GET);
            List<RingData> ringDataList = new List<RingData>();    
            //TODO 改善异常处理逻辑
            try
            {
                HttpResponse response = request.request();
                ringDataList = response.getResultAsObjList<RingData>();
            }
            catch (WebException e)
            {
                Console.Write("Update Faild due to a WebException!\n" + e);
                MessageBox.Show("Update Faild due to a WebException! Try Again...");
            }
            catch (Exception e)
            {
                MessageBox.Show("Update Faild due to an Other Exception" + e);
                return;
            }
            updateRingRecordsCache(ringDataList, elderID);
        }

        private void updateRingRecordsCache(List<RingData> ringDataList, string elderID)
        {

            MethodCell_INT mcUpdateProgressBar = new MethodCell_INT(UpdateprogressBar);
            MethodCell_S mcUpdateStatus = new MethodCell_S(UpdateStatus);
            int i = 0;
            this.BeginInvoke(mcUpdateStatus, "Updating RingRecords for " + elderID + " ...");
            foreach (RingData elderRing in ringDataList)
            {
                i++;
                //更新进度条
                if (ringDataList.Count > 0)
                {
                    int j = i * 100 / (ringDataList.Count);
                    this.BeginInvoke(mcUpdateProgressBar, j);    //TODO 需要同步通信，不可异步通信
                    Console.WriteLine(j);
                }
                //实际操作
                RingData ringData = new RingData(elderRing.curID);
                ringData.datetime = elderRing.datetime;
                if (DataBaseHandler.GetRingDataByTime(ringData).lat == "")
                {
                    Console.WriteLine(elderRing.curID + "  " + elderRing.datetime + "  " + elderRing.lat
                                      + "  " + elderRing.lng + "  " + elderRing.heartRate);
                    DataBaseHandler.SaveRingData(elderRing);
                }
                else
                {
                    Console.WriteLine("RingRecords ElderName = " + this.elderNameBox.Text + " at time = " + elderRing.datetime.ToString() + " Already Existed");
                }
            }
            this.Invoke(mcUpdateStatus, "ElderId = " + elderID + " has Updated " + ringDataList.Count.ToString() + " Records");
            Console.WriteLine("ElderId = " + elderID + " has Updated " + ringDataList.Count.ToString() + " Records");
            Thread.Sleep(2000);
            this.BeginInvoke(mcUpdateStatus, "");
            this.BeginInvoke(mcUpdateProgressBar, 0);
        }

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
