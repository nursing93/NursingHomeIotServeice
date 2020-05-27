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
    public partial class ElderManageForm : Form
    {
        /// <summary>
        /// 为接收活动区域设置的临时存储字符串，用该字符串将数据传给服务器，并保存到本地数据库
        /// </summary>
        public string AREASTRING = "nra";       //为接收活动区域设置的临时存储字符串，用该字符串将数据存到数据库
        public static ElderManageForm elderManageForm = null;
        /// <summary>
        /// 启用多线程，所需要的代理
        /// </summary>
        /// <returns>返回值为字符串</returns>
        private delegate string MethodCallerNN();
        /// <summary>
        /// 带参启用多线程,或者多线程需要返回值时，所需要的代理
        /// </summary>
        /// <param name="str">启用多线程时所需要的参数</param>
        /// <returns>返回值为字符串</returns>
        private delegate string MethodCallerYY(string str);
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数</param>
        private delegate void MethodCallerNY(string str);
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数</param>
        private delegate void MethodCallerNY_B(Boolean boolean);
        /// <summary>
        /// 带参启用多线程,所需要的代理
        /// </summary>
        /// <param name="str">启动多线程所需要的参数,状态字符</param>
        /// <param name="elder">启动多线程所需要的参数，老人对象</param>
        private delegate void MethodCallerNYY(string str,ElderInfor elder);
        public ElderManageForm()
        {
            InitializeComponent();
        }

        private void ElderManageForm_Load(object sender, EventArgs e)
        {
            elderManageForm=this;
            ControlInfo(false);      //将新建人员列表的控件设为不可用
            this.csetAreaBtn.Enabled = false;  //修改人员窗口的设置区域按钮禁用
        }
        /**************************************************
         * 多线程通信处理块
         ****************************************************/
        /// <summary>
        /// 子线程通知主线程调用的方法，请求添加老人
        /// </summary>
        /// <param name="strElderID"></param>
        private void InvokeNewElderID(string strElderID)
        {
            this.elderIdBox.Text = strElderID;
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，申请新建（修改）老人信息
        /// </summary>
        /// <param name="StatuteStr">新建老人信息，服务器返回的结果</param>
        /// <param name="elder">老人信息</param>
        private void InvokeUpdateRecord(string StatuteStr,ElderInfor elder)
        {
            //根据服务器返回的情况，执行本地数据库的相关操作
            if (StatuteStr == HttpRspState.ADDELDER_SUCCESS)
            {
                HandDataBase.CreatElderRecord(elder);    //若服务器添加成功，则本地也添加
                MessageBox.Show("服务器存储成功，本地数据库更新成功");
            }
            else if (StatuteStr == HttpRspState.ADDELDER_FAILD)
            {
                //*******************************待完善该部分代码，应当具备向用户提示服务器报错的情况
                MessageBox.Show("服务器存储失败，请重试");
            }
            else if (StatuteStr == HttpRspState.AMENDELDER_SUCCESS)
            {
                HandDataBase.AmendElderRecord(elder);     //若服务器修改成功，则本地也修改
                MessageBox.Show("服务器修改成功，本地数据库更新成功");
            }
            else if (StatuteStr == HttpRspState.AMENDELDER_FAILD)
            {
                //*******************************待完善该部分代码，应当具备向用户提示服务器报错的情况
                MessageBox.Show("服务器修改失败，请重试");
            }
            else
            {
                //*******************************待完善该部分代码，应当具备向用户提示服务器报错的情况
                MessageBox.Show("服务器没有响应，请重试\r"+StatuteStr);
            }
        }
        /// <summary>
        /// 子线程通知主线程调用的方法，申请删除老人信息
        /// </summary>
        /// <param name="stateStr">请求删除状态</param>
        /// <param name="elder">对应老人对象</param>
        private void InvokeDeleteRecord(string stateStr,ElderInfor elder)
        {
            if (stateStr == HttpRspState.DELETEELDER_SUCCESS)
                {
                    HandDataBase.DeleteElderRecord(elder);      //根据服务器删除状况决定是否操作本地数据库
                    MessageBox.Show("服务器删除成功，本地数据库删除成功");
                }
            else if (stateStr == HttpRspState.DELETEELDER_FAILD)
                {
                    //********************************有待改善，若服务器删除失败，交互内容
                    MessageBox.Show("服务器删除失败，请重试");
                }
                else
                {
                    //*******************************待完善该部分代码，应当具备向用户提示服务器报错的情况
                    MessageBox.Show("服务器没有响应，请重试");
                    //后续操作。。。。。。若删除成功？删除失败？
                }
        }
        /*********************************************
         * 自定义代码
         * *******************************************/
        /// <summary>
        /// 打开区域设置窗口，同时只能打开一个窗口
        /// </summary>
        private void ShowAreaSetWindow()
        {
            Form form = Application.OpenForms["AreaSetWindow"];
            if(form==null)
            {
                AreaSetWindow areaForm = new AreaSetWindow();
                areaForm.Show();
            }
            else
            {
                AreaSetWindow areaForm =(AreaSetWindow)form;
                areaForm.Focus();
            }
        }
        /// <summary>
        /// 设置新建人员列表选项卡中TextBox的可见性，true可见，false不可见
        /// </summary>
        /// <param name="B">true可见，false不可见</param>
        private void ControlInfo(Boolean B)       //
        {
            foreach (Control ct in this.newRecord.Controls)       //遍历新建人员信息选项卡控件中的所有控件
            {
                if (ct is TextBox || ct is ComboBox)    //如果当前控件为TextBox
                {
                    if (B)  //如果为True当前控件可用，否则不可用
                    {
                        ct.Enabled = true;
                        this.saveRecordBtn.Enabled = true;
                        this.setAreaBtn.Enabled = true;
                    }
                    else
                    {
                        ct.Enabled = false;
                        this.saveRecordBtn.Enabled = false;
                        this.setAreaBtn.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 主窗口打开人员管理窗口时，调用此方法，用以判别显示哪张选项卡
        /// </summary>
        /// <param name="tableName"></param>
        public void showTablech(string tableName)  //被主场口调用，设置当前窗口为指定的选项卡，tableName为指定选项卡的名称
        {
            if (tableName == WinformName.EMFORMAMENDRTAB)
            {
                this.manTab.SelectedTab = amendRecord;   //将当先选项卡设置为人员档案修改选项卡
            }
            else if (tableName == WinformName.EMFORMDELETRTAB)
            {
                this.manTab.SelectedTab = deleteRecord;   //将当先选项卡设置为人员档案删除选项卡           
            }
            else
            {
                this.manTab.SelectedTab = newRecord;   //将当先选项卡设置为人员档案删除选项卡  
            }
        }
        /// <summary>
        /// 向服务器发起新建老人档案请求，并返回系统给定的ID
        /// </summary>
        private void AddRecordRequest() 
        {
            //****************************有待改善，若服务器响应超时，如何处理
            HttpProvider addRecordReq = new HttpProvider(HttpURLs.ADDRECORDURL, HttpMethod.GET);  //get方式向服务器请求添加一个老人档案
            string newElderId = "";
            try
            {
                newElderId = addRecordReq.HttpGetResponseStr();    //获取系统返回的新建老人ID
                //将控件设置为可用
                MethodCallerNY_B controlInFor = new MethodCallerNY_B(ControlInfo);
                this.Invoke(controlInFor, true);     //必须是同步处理方式
            }
            catch (WebException e)
            {
                //将控件设置为不可用
                MethodCallerNY_B controlInFor = new MethodCallerNY_B(ControlInfo);
                this.Invoke(controlInFor, false);
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("请求添加新人员  出现网络异常：\r" + e);
                MessageBox.Show("由于网络原因\r请求添加新人员失败   请重试. . . . . .");
            }
            catch (Exception e)
            {
                //将控件设置为不可用
                MethodCallerNY_B controlInFor = new MethodCallerNY_B(ControlInfo);
                this.Invoke(controlInFor, false);
                //其他异常导致添加失败
                Console.Write("请求添加新人员  由于其他异常导致失败：\r" + e);
                MessageBox.Show("请求添加新人员   其他异常导致失败");
            }
            finally 
            {
                if (newElderId == "")
                {
                    //未得到新建老人id，不作操作
                }
                else 
                {
                    MethodCallerNY mcNewElderID = new MethodCallerNY(InvokeNewElderID);
                    this.BeginInvoke(mcNewElderID, newElderId);
                }
            }
        }
        /// <summary>
        /// 新建老人对象，并向调用者返回一个已经完善了信息的老人对象
        /// 参数"boolean"用于判定完善老人信息的途径，true为从新建窗口完善，false为从修改窗口完善
        /// </summary>
        /// <param name="boolean">用于判别是新建或者修改档案，true为新建，false为修改</param>
        /// <returns>返回一个信息完整的老人对象</returns>
        private object NewElderRecord(Boolean boolean) 
        {
            //新建老人对象，并从新建档案窗口完善该老人的信息
            ElderInfor newElder = new ElderInfor();
            if (boolean==true)
            {       //从新建窗口完善老人信息
                newElder.elderID = elderIdBox.Text;    //必填
                newElder.elderName = elderNameBox.Text;   //必填
                newElder.elderSex = elderSexBox.Text;   //必填
                newElder.elderBirthday = OtherTools.DateTimeToString(elderBirthBox.Value);   //必填
                if (elderChildBox.Text == "") { newElder.elderChild = "未填写"; } else { newElder.elderChild = elderChildBox.Text; }  //选填
                if (elderChildNumBox.Text == "") { newElder.elderChildNumber = "未填写"; }
                else { newElder.elderChildNumber = elderChildNumBox.Text; } //选填
                newElder.elderArea = this.AREASTRING;   //必填
            }
            else
            {      //从修改窗口完善老人信息
                newElder.elderID = celderIdBox.Text;    //必填
                newElder.elderName = celderNameBox.Text;   //必填
                newElder.elderSex = celderSexBox.Text;   //必填
                newElder.elderBirthday = OtherTools.DateTimeToString(celderBirthBox.Value);   //必填
                if (celderChildBox.Text == "") { newElder.elderChild = null; } else { newElder.elderChild = celderChildBox.Text; }  //选填
                if (celderChildNumBox.Text == "") { newElder.elderChildNumber = null; }
                else { newElder.elderChildNumber = celderChildNumBox.Text; } //选填
                newElder.elderArea = this.AREASTRING;   //必填
            }

            //返回该老人对象给调用者
            return newElder;
        }
        /// <summary>
        /// 只被方法UpdataRecordState通过多线程的方式调用
        /// </summary>
        /// <param name="objSend">发起请求所需数据，包括布尔值和老人对象</param>
        private void HTTPUpdataRecord(Object objSend)
        {
            Object[] objArry = (Object[])objSend;    //将参数转化为对象组后便于利用
            Boolean boolean = (Boolean)objArry[0];
            ElderInfor elder = (ElderInfor)objArry[1];
            //判断接下来执行新建操作或者修改操作
            HttpProvider saveRecordReq = null;
            //**********************************测试代码段
            //LogingWindow.Test.HttpTest.SQLTest test;

            if (boolean == true)   //以新建档案的方式发出请求的对象
            {
                saveRecordReq = new HttpProvider(HttpURLs.SAVERECORDURL, HttpMethod.POST);
                //********************************测试
                //test=new Test.HttpTest.SQLTest("ADD_SUCCESS");
            }
            else
            {    //以修改档案的方式发出请求的对象
                saveRecordReq = new HttpProvider(HttpURLs.AMENDRECORDURL, HttpMethod.POST);
                //********************************测试
                //test=new Test.HttpTest.SQLTest("ADD_SUCCESS");

            }
            string StatuteStr = "";
            try
            {
                StatuteStr = saveRecordReq.HttpRquestStr(elder);  //用上述对象发送请求，并获取新建或修改的状态
                //***********************************测试代码
                //StatuteStr = test.STATE;
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("更新档案  出现异常：\r" + e);
                MessageBox.Show("由于网络原因\r请求更新档案失败   请重试. . . . . .");
            }
            catch (Exception e)
            {
                //由于其他异常，导致保存新建档案失败
                Console.Write("更新档案  由于其他异常失败：\r" + e);
                MessageBox.Show("更新档案   其他异常失败\r");
            }
            finally
            {
                //向主线程发送请求结果，并由主线程做出相应的响应
                MethodCallerNYY mcAddRecord = new MethodCallerNYY(InvokeUpdateRecord);
                this.BeginInvoke(mcAddRecord, StatuteStr,elder);     //将参数传给主线程，由主线程做响应后的其他操作
            }
        }

        /// <summary>
        /// 向服务器提交老人的信息--可能是修改信息，也可能是新建信息
        /// 参数boolean用于判别提交的是新建档案还是修改档案，true为新建，false为修改
        /// 参数为true时，返回新建档案的状态，为false时返回修改档案的状态
        /// </summary>
        /// <param name="boolean">用于判别提交的是新建档案还是修改档案，true为新建，false为修改</param>
        /// <returns>返回提交信息的状态--新建状态或者修改状态</returns>
        private void UpdataRecordState(Boolean boolean) 
        {
            ElderInfor elder = (ElderInfor)NewElderRecord(boolean);  //
            //确保该老人对象信息可靠后方可进行提交操作*********************************有待改善
            int elderYear =OtherTools.BirthdayToYear(elder);       //设置老人年龄的判别字符
            if (elder.elderSex == "" || elder.elderName == ""||elderYear>150||elderYear<0)    
            {
                //*********************************有待改善
                return;
                MessageBox.Show( "保存失败\n请确认输入信息\n人员姓名和性别不可为空,出生年月需合理");
            }
            //多线程的方式向服务器发起请求
            Object[] objArry = { boolean, elder };
            Object objSend = objArry;      //由于以下方法只能传输一个参数，不可以是数组，所以需要该步转化
            ParameterizedThreadStart thdPTH = new ParameterizedThreadStart(HTTPUpdataRecord);
            Thread thdUpdataRecord = new Thread(thdPTH);
            thdUpdataRecord.IsBackground = true;
            thdUpdataRecord.Start(objSend);
        }
        /// <summary>
        /// 向服务器请求删除对应ID老人的信息，并删除本地信息
        /// </summary>
        /// <returns></returns>
        private void DeleteRecordState(Object objSend)
        {
            //*****************************有待改善，尚未对接接口，建议用post方式
            string elderID = (string)objSend;
            if (elderID == "") { return; }         //如果字符为空，则不进行以下操作
            ElderInfor elder = new ElderInfor(elderID);
            HandDataBase.GetElderRecord(elder);//完善该老人信息
            HttpProvider deleteReq = new HttpProvider(HttpURLs.DELETRECORDURL, HttpMethod.POST);
            string stateStr = "";
            try
            {
                stateStr = deleteReq.HttpRquestStr(elder);     //请求删除并返回删除状态
                //*******************************测试
                //stateStr = "DEL_SUCCESS";
            }
            catch (WebException e)
            {
                //由于网络问题，或者url错误引起的异常，导致登录不成功
                Console.Write("删除档案  出现异常：\r" + e);
                MessageBox.Show("由于网络原因\r请求删除档案失败   请重试. . . . . .");
            }
            catch (Exception e)
            {
                //其他异常导致删除失败
                Console.Write("删除档案  由于其他异常失败：\r" + e);
                MessageBox.Show("删除档案    其他异常失败");
            }
            finally
            {
                //将删除状态告诉主线程，并由主线程决定之后的行为
                MethodCallerNYY mcDeleteRecord = new MethodCallerNYY(InvokeDeleteRecord);
                this.BeginInvoke(mcDeleteRecord, stateStr,elder);
            }    
        }
        /// <summary>
        /// 在修改（删除）选项卡中选取人员后，将对应老人的信息填充到对应的框中,true为修改，false为删除,
        /// 由本窗口的两个cobbox的items点击事件调用
        /// </summary>
        /// <param name="isAmendTab">判断调用者是修改按钮还是删除按钮</param>
        private void FillRecordBoxes(Boolean isAmendTab)
        {
            if (isAmendTab)
            {
                ElderInfor elder = new ElderInfor(this.scRecordIdBox.Text);    //传入一个老人的ID以新建老人对象
                HandDataBase.GetElderRecord(elder);      //完善该老人的所有信息
                {//将修改人员窗口的人员信息赋值
                    this.celderIdBox.Text = elder.elderID;
                    this.celderNameBox.Text = elder.elderName;
                    this.celderSexBox.Text = elder.elderSex;
                    this.celderBirthBox.Value = Convert.ToDateTime(elder.elderBirthday);    //将老人的出生年月赋值给出生年月框
                    this.celderChildBox.Text = elder.elderChild;
                    this.celderChildNumBox.Text = elder.elderChildNumber;
                    this.AREASTRING = elder.elderArea;
                }
            }
            else 
            {
                ElderInfor elder = new ElderInfor(this.sdRecordIdBox.Text);    //传入一个老人的ID以新建老人对象
                HandDataBase.GetElderRecord(elder);      //完善该老人的所有信息
                {//将删除人员窗口的人员信息赋值
                    this.delderIdBox.Text = elder.elderID;
                    this.delderNameBox.Text = elder.elderName;
                    this.delderSexBox.Text = elder.elderSex;
                    this.delderBirthdayBox.Text = elder.elderBirthday ;
                    this.delderChildBox.Text = elder.elderChild;
                    this.delderChildNumberBox.Text = elder.elderChildNumber;
                }
            }
        }

        /**********************************************
         * 事件处理代码段
         * **********************************************/
        private void addRcordBtn_Click(object sender, EventArgs e)
        {
            //异常已经在下一级代码中处理，尚不完善
            //elderIdBox.Text=AddRecordRequest();    //请求添加，并将id填入对应输入框
            //多线程的方式发送请求
            Thread thdAddRcordReq = new Thread(AddRecordRequest);
            thdAddRcordReq.IsBackground = true;       //将该属性设为true，防止关闭程序时还有残留线程
            thdAddRcordReq.Start();
        }

        private void saveRecordBtn_Click(object sender, EventArgs e)
        {
            if(elderIdBox.Text==""){ //id输入框为空时不可提交内容
                //***************************有待改善，当点击添加按钮时，其他控件才可用
                MessageBox.Show("请点击“添加”按钮\r以获取ID");
                return;
            }
            if(AREASTRING=="nra")     //未设置区域时，不可保存人员信息
            {
                MessageBox.Show("请设置安全活动区域后再进行保存");
                return;
            }
            //异常已经在下一级代码中处理，尚不完善
             UpdataRecordState(true);     //以新建档案的方式向服务器提交信息,字符串为新建档案的状态
            //MessageBox.Show(saveState);
            //后续操作。。。。。。若新建成功，则？若失败则？     是否退出窗口
        }

        private void csaveRecordBtn_Click(object sender, EventArgs e)
        {
            if(celderIdBox.Text==""){  //id输入框为空时不可提交修改的内容
                MessageBox.Show("请选择需要修改的档案后重试");
                return;            
            }
           UpdataRecordState(false);     //异常已经在下一级代码中处理，尚不完善
            //后续操作。。。。。。若修改成功，则？若失败则？     是否退出窗口
        }

        private void deleteRecordBtn_Click(object sender, EventArgs e)
        {
            if (sdRecordIdBox.Text == "")
            {
                MessageBox.Show("请选择需要修改的档案后重试");
                return;
            }
            if (MessageBox.Show("确定要删除“" + sdRecordNameBox.Text + "”\r编号“" 
                                + sdRecordIdBox .Text+ "”的所有资料？", "档案删除窗", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                //采用多线程请求删除对应人员
                ParameterizedThreadStart thdSt = new ParameterizedThreadStart(DeleteRecordState);
                Thread thdDeleteRecord = new Thread(thdSt);
                thdDeleteRecord.IsBackground = true;       //防止关闭程序后有残留线程
                thdDeleteRecord.Start(sdRecordIdBox.Text);
                //DeleteRecordState();     //请求删除选中的人员，异常已经在下一级代码中处理，尚不完善
                this.sdRecordNameBox.Text = "";      //清空姓名框
                this.sdRecordIdBox.Items.Clear();    //清空ID框
            }
            //后续操作。。。。。。若删除成功，则？若失败则？     是否退出窗口
        }

        private void scRecordNameBox_DropDown(object sender, EventArgs e)
        {
            //this.scRecordIdBox.Items.Clear();     //执行方法之前先将scRecordIdBox框清空，防止ID与姓名不匹配
            this.scRecordNameBox = HandDataBase.ComboBoxDropDown(this.scRecordNameBox, this.scRecordNameBox.Text, ComboBoxDropDownCaller.NameComboBox);
        }

        private void scRecordIdBox_DropDown(object sender, EventArgs e)
        {
            this.scRecordIdBox = HandDataBase.ComboBoxDropDown(this.scRecordIdBox, this.scRecordNameBox.Text, ComboBoxDropDownCaller.IDComboBox);
        }

        private void sdRecordNameBox_DropDown(object sender, EventArgs e)
        {
            //this.sdRecordIdBox.Items.Clear();        //执行方法之前先将sdRecordIdBox框清空，防止ID与姓名不匹配
            this.sdRecordNameBox = HandDataBase.ComboBoxDropDown(this.sdRecordNameBox, this.sdRecordNameBox.Text, ComboBoxDropDownCaller.NameComboBox);
        }

        private void sdRecordIdBox_DropDown(object sender, EventArgs e)
        {
            this.sdRecordIdBox = HandDataBase.ComboBoxDropDown(this.sdRecordIdBox, this.sdRecordNameBox.Text, ComboBoxDropDownCaller.IDComboBox);
        }

        private void scRecordNameBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.scRecordIdBox.Items.Clear();   //获取人员名单前先将ID下拉框的内容清空，防止出错
            this.celderIdBox.Text = "";    //修改窗口的人员编号输入框清空，防止人为的错误出现
            this.csetAreaBtn.Enabled = false;   //修改人员窗口的区域设置按钮不可用，防止人为操作出错
        }

        private void sdRecordNameBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.sdRecordIdBox.Items.Clear();     //获取人员名单前先将ID下拉框的内容清空，防止出错
            foreach (Control ct in this.splitContainer3.Panel2.Controls)
            {
                if(ct is TextBox)
                {
                    ct.Text = "";
                }
            }
        }

        private void sdRecordIdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillRecordBoxes(false);      //以的删除命令调用基本信息填充方法
        }

        private void scRecordIdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillRecordBoxes(true);     //以修改的命令调用基本信息填充方法
            this.csetAreaBtn.Enabled = true;      //设置区域按钮可用
        }

        private void setAreaBtn_Click(object sender, EventArgs e)
        {
            //*****************************************窗口打开方式有待考虑
            //新建并打开安全区域设置窗口
            //AreaSetWindow areaForm = new AreaSetWindow();    
            //areaForm.Show();
            ShowAreaSetWindow();       //打开区域设置窗口
        }

        private void csetAreaBtn_Click(object sender, EventArgs e)
        {
            //*****************************************窗口打开方式有待考虑
            //新建并打开安全区域设置窗口
            //AreaSetWindow areaForm = new AreaSetWindow();
            //areaForm.Show();
            ShowAreaSetWindow();                 //打开区域设置窗口
        }


    }
}
