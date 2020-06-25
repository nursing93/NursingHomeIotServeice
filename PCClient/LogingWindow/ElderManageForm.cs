using LogingWindow.BaseClass;
using LogingWindow.Data;
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
        private delegate void MethodCallerNYY(string str,ElderInfo elder);
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

        private void InvokeNewElderID(string strElderID)
        {
            this.elderIdBox.Text = strElderID;
        }

        private void InvokeUpdateRecord(string StatuteStr, ElderInfo elder)
        {
            ElderDao dao = new ElderDao();
            if (StatuteStr == HttpRspState.ADDELDER_SUCCESS)
            {
                dao.create(elder);
                MessageBox.Show("Insert Success!, Local Datas Has been Updated!");
            }
            else if (StatuteStr == HttpRspState.ADDELDER_FAILD)
            {
                MessageBox.Show("Insert Failed! Try Again...");
            }
            else if (StatuteStr == HttpRspState.AMENDELDER_SUCCESS)
            {
                dao.update(elder);
                MessageBox.Show("Modify Success!  Local Datas Has been Updated!");
            }
            else if (StatuteStr == HttpRspState.AMENDELDER_FAILD)
            {
                MessageBox.Show("Modify Failed! Try Again...");
            }
            else
            {
                MessageBox.Show("No Response! Try Again..." + StatuteStr);
            }
        }

        private void InvokeDeleteRecord(string stateStr,ElderInfo elder)
        {
            ElderDao dao = new ElderDao();
            if (stateStr == HttpRspState.DELETEELDER_SUCCESS)
                {
                    dao.delete(elder);
                    MessageBox.Show("Delete Elder Infomation Success!");
                }
            else if (stateStr == HttpRspState.DELETEELDER_FAILD)
                {
                    //TODO 有待改善，若服务器删除失败，交互内容
                    MessageBox.Show("Delete Elder Infomation Failed! Try Again...");
                }
                else
                {
                    //TODO 待完善该部分代码，应当具备向用户提示服务器报错的情况
                    MessageBox.Show("Service out of Responsing...");
                    //后续操作。。。。。。若删除成功？删除失败？
                }
        }

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

        private void AddRecordRequest() 
        {
            //TODO 若服务器响应超时，如何处理
            HttpRequest request = new HttpRequest(HttpURLs.ADDRECORDURL, HttpMethod.GET);
            string newElderId = "";
            try
            {
                HttpResponse response = request.request();
                newElderId = response.getResult();
                MethodCallerNY_B controlInFor = new MethodCallerNY_B(ControlInfo);
                this.Invoke(controlInFor, true);
            }
            catch (WebException e)
            {
                MethodCallerNY_B controlInFor = new MethodCallerNY_B(ControlInfo);
                this.Invoke(controlInFor, false);
                Console.Write("Get new ElderId Failed due to a WebException!\n" + e);
                MessageBox.Show("Get new ElderId Failed due to a WebException!Try Again...");
            }
            catch (Exception e)
            {
                MethodCallerNY_B controlInFor = new MethodCallerNY_B(ControlInfo);
                this.Invoke(controlInFor, false);
                Console.Write("Get new ElderId Failed due to an Other Exception!\n" + e);
                MessageBox.Show("Get new ElderId Failed due to an Other Exception!");
            }
            finally 
            {
                if (newElderId == "")    //TODO 判断新ID的合法性
                {
                    //TODO 未得到新建老人id，不作操作
                }
                else 
                {
                    MethodCallerNY mcNewElderID = new MethodCallerNY(InvokeNewElderID);
                    this.BeginInvoke(mcNewElderID, newElderId);
                }
            }
        }

        private object NewElderRecord(Boolean boolean) 
        {
            //新建老人对象，并从新建档案窗口完善该老人的信息
            ElderInfo newElder = new ElderInfo();
            if (boolean==true)
            {       //从新建窗口完善老人信息
                newElder.id = elderIdBox.Text;    //必填
                newElder.name = elderNameBox.Text;   //必填
                newElder.sex = elderSexBox.Text;   //必填
                newElder.birthday = OtherTools.DateTimeToString(elderBirthBox.Value);   //必填
                newElder.joinTime = OtherTools.DateTimeToString(joinTimeBox.Value);   //必填
                if (idCardBox.Text == "") { newElder.idCard = "未填写"; } else { newElder.idCard = idCardBox.Text; }  //选填
                if (phoneBox.Text == "") { newElder.phone = "null"; }
                else { newElder.phone = phoneBox.Text; } //选填
                newElder.area = this.AREASTRING;   //必填
            }
            else
            {      //从修改窗口完善老人信息
                newElder.id = celderIdBox.Text;    //必填
                newElder.name = celderNameBox.Text;   //必填
                newElder.sex = celderSexBox.Text;   //必填
                newElder.birthday = OtherTools.DateTimeToString(celderBirthBox.Value);   //必填
                newElder.joinTime = OtherTools.DateTimeToString(cjoinTimeBox.Value);   //必填
                if (cidCardBox.Text == "") { newElder.idCard = null; } else { newElder.idCard = cidCardBox.Text; }  //选填
                if (celderPhone.Text == "") { newElder.phone = null; }
                else { newElder.phone = celderPhone.Text; } //选填
                newElder.area = this.AREASTRING;   //必填
            }

            //返回该老人对象给调用者
            return newElder;
        }

        private void HTTPUpdataRecord(Object objSend)
        {
            Object[] objArry = (Object[])objSend;    //将参数转化为对象组后便于利用
            Boolean boolean = (Boolean)objArry[0];
            ElderInfo elder = (ElderInfo)objArry[1];
            HttpRequest request = null;
            if (boolean == true)
            {
                request = new HttpRequest(HttpURLs.SAVERECORDURL, HttpMethod.POST);
            }
            else
            {
                request = new HttpRequest(HttpURLs.AMENDRECORDURL, HttpMethod.POST);
            }
            string StatuteStr = "";
            try
            {
                HttpResponse response = request.request(elder);
                StatuteStr = response.getResult();
            }
            catch (WebException e)
            {
                Console.Write("Updating Elder Info Faild due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Updating Elder Info Faild due to a WebException! Try Again...\n");
            }
            catch (Exception e)
            {
                Console.Write("Updating Elder Info Faild due to an Other Exception!\n" + e);
                MessageBox.Show("Updating Elder Info Faild due to an Other Exception!");
            }
            finally
            {
                MethodCallerNYY mcAddRecord = new MethodCallerNYY(InvokeUpdateRecord);
                this.BeginInvoke(mcAddRecord, StatuteStr, elder);
            }
        }

        private void UpdataRecordState(Boolean boolean) 
        {
            ElderInfo elder = (ElderInfo)NewElderRecord(boolean);  //
            //确保该老人对象信息可靠后方可进行提交操作*********************************有待改善
            int elderYear =OtherTools.BirthdayToYear(elder);       //设置老人年龄的判别字符
            if (elder.sex == "" || elder.name == "" || elderYear > 150 || elderYear < 0)    
            {
                //TODO 有待改善
                MessageBox.Show( "保存失败\n请确认输入信息\n人员姓名和性别不可为空,出生年月需合理");
                return;
            }
            //多线程的方式向服务器发起请求
            Object[] objArry = { boolean, elder };
            Object objSend = objArry;      //由于以下方法只能传输一个参数，不可以是数组，所以需要该步转化
            ParameterizedThreadStart thdPTH = new ParameterizedThreadStart(HTTPUpdataRecord);
            Thread thdUpdataRecord = new Thread(thdPTH);
            thdUpdataRecord.IsBackground = true;
            thdUpdataRecord.Start(objSend);
        }

        private void DeleteRecordState(Object objSend)
        {
            string elderID = (string)objSend;
            if (elderID == "") { return; }
            ElderDao dao = new ElderDao();
            ElderInfo elder = dao.get(elderID);
            HttpRequest request = new HttpRequest(HttpURLs.DELETRECORDURL, HttpMethod.POST);
            string stateStr = "";
            try
            {
                HttpResponse response = request.request(elder);
                stateStr = response.getResult();
            }
            catch (WebException e)
            {
                Console.Write("Delete Failed due to a WebException! Try Again...\n" + e);
                MessageBox.Show("Delete Failed due to a WebException! Try Again...");
            }
            catch (Exception e)
            {
                Console.Write("Delete Failed due to an Other Exception! \n" + e);
                MessageBox.Show("Delete Failed due to an Other Exception!");
            }
            finally
            {
                MethodCallerNYY mcDeleteRecord = new MethodCallerNYY(InvokeDeleteRecord);
                this.BeginInvoke(mcDeleteRecord, stateStr,elder);
            }    
        }

        private void FillRecordBoxes(Boolean isAmendTab)
        {
            if (isAmendTab)
            {
                ElderDao dao = new ElderDao();
                ElderInfo elder = dao.get(this.scRecordIdBox.Text);
                {//将修改人员窗口的人员信息赋值
                    this.celderIdBox.Text = elder.id;
                    this.celderNameBox.Text = elder.name;
                    this.celderSexBox.Text = elder.sex;
                    this.celderBirthBox.Value = Convert.ToDateTime(elder.birthday);    //将老人的出生年月赋值给出生年月框
                    //this.cjoinTimeBox.Value = Convert.ToDateTime(elder.joinTime);
                    this.cidCardBox.Text = elder.idCard;
                    this.celderPhone.Text = elder.phone;
                    this.AREASTRING = elder.area;
                }
            }
            else 
            {
                ElderDao dao = new ElderDao();
                ElderInfo elder = dao.get(this.sdRecordIdBox.Text);
                {
                    this.delderIdBox.Text = elder.id;
                    this.delderNameBox.Text = elder.name;
                    this.delderSexBox.Text = elder.sex;
                    this.delderBirthdayBox.Text = elder.birthday;
                    this.didCardBox.Text = elder.idCard;
                    this.delderPhone.Text = elder.phone;
                }
            }
        }

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
                //TODO 有待改善，当点击添加按钮时，其他控件才可用
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
            ElderDao dao = new ElderDao();
            dao.fillDropDownBoxWithElderName(this.scRecordNameBox, this.scRecordNameBox.Text);
        }

        private void scRecordIdBox_DropDown(object sender, EventArgs e)
        {
            ElderDao dao = new ElderDao();
            dao.fillDropDownBoxWithElderId(this.scRecordIdBox, this.scRecordNameBox.Text);
        }

        private void sdRecordNameBox_DropDown(object sender, EventArgs e)
        {
            ElderDao dao = new ElderDao();
            dao.fillDropDownBoxWithElderName(this.sdRecordNameBox, this.sdRecordNameBox.Text);
        }

        private void sdRecordIdBox_DropDown(object sender, EventArgs e)
        {
            ElderDao dao = new ElderDao();
            dao.fillDropDownBoxWithElderId(this.sdRecordIdBox, this.sdRecordNameBox.Text);
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
