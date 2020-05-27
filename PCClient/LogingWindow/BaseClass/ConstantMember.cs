using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCClintSoftware.BaseClass
{
    /// <summary>
    /// 静态类，存储系统中所有经常用到的字符串
    /// </summary>
    public static class ConstantMember
    {
        /************************************
         * URL字符串
         *********************************/
        private const string host = "http://localhost:8080/ElderLinkWebServer";
        /// <summary>
        /// 登录请求--URL，post
        /// </summary>
        public const string LOGINGURL = host + "/login";
        /// <summary>
        /// 注销用户session请求
        /// </summary>
        public const string LOGOUTURL = host + "/logout";
        //*******************************************老人
        /// <summary>
        /// 查询所有老人信息请求--URL，get
        /// </summary>
        public const string QUERYALLELDERURL = host + "/elder/listAll";
        /// <summary>
        /// 添加新入院老人基本资料请求--URL，get
        /// </summary>
        public const string ADDRECORDURL = host + "/elder/newID";
        /// <summary>
        /// 保存新入院老人基本资料请求--URL，post
        /// </summary>
        public const string SAVERECORDURL = host + "/elder/create";
        /// <summary>
        /// 查询某个老人基本资料请求--URL,get，最后带参ElderID
        /// </summary>
        public const string QUERYTRECORDURL = host + "/elder/find/";
        /// <summary>
        /// 提交修改在院老人基本资料请求--URL，post
        /// </summary>
        public const string AMENDRECORDURL = host + "/elder/update";
        /// <summary>
        /// 删除在院老人基本资料请求--URL，post
        /// </summary>
        public const string DELETRECORDURL = host + "/elder/delete";
        //************************************老人手环数据
        /// <summary>
        /// 获取指定老人的最新位置信息请求--URL,get,最后带参ElderID
        /// </summary>
        public const string GRRINGDATAURL = host + "/ring/lastRecord/";
        /// <summary>
        /// 获取指定老人的所有位置信息请求--URL,get，最后带参数，elderID+startTime+endTime
        /// </summary>
        public const string QEALLRINGDATAURL = host + "/ring/listByTime/";
        //************************************用户
        /// <summary>
        /// 查询所有用户信息请求--URL，get
        /// </summary>
        public const string QUERYALLUSERURL = host + "/user/listAll";
        /// <summary>
        /// 查询指定用户的个人信息请求--URL，get，最后带参数userName
        /// </summary>
        public const string QUERYUSERDETAILURL = host + "/user/find/";
        /// <summary>
        /// 新建用户个人资料请求--URL，post
        /// </summary>
        public const string ADDUSERURL = host + "/user/create";
        /// <summary>
        /// 修改指定用户个人资料请求--URL，post
        /// </summary>
        public const string AMENDUSERURL = host + "/user/update";
        /// <summary>
        /// 删除指定用户的个人资料请求--URL，get，最后带参数ElderID
        /// </summary>
        public const string DELETEUSERURL = host + "/user/delete/";
        /// <summary>
        /// 用户修改个人密码的请求--URL,post
        /// </summary>
        public const string AMENDPASSWORDURL = host + "/user/password";

        /*****************************************************************************
         * URL的请求方式，本系统采用有两种方式，get方式,post方式
        **************************************************************************/
        /// <summary>
        /// url请求方式为get方式
        /// </summary>
        public const string GET = "get";
        /// <summary>
        /// url请求方式为post方式
        /// </summary>
        public const string POST = "post";
        /************************************************************************
         * 登录结果返回值的匹配字符串
         * ********************************************************************/
        /// <summary>
        /// 管理员身份
        /// </summary>
        public const string ADMINISTRATOR = "ADMINISTRATOR";
        /// <summary>
        /// 普通用户身份
        /// </summary>
        public const string USERPERMIT = "USERPERMIT";
        /// <summary>
        /// 用户不存在
        /// </summary>
        public const string NOPERMISSION = "NOPERMISSION";
        /// <summary>
        /// 密码错误 
        /// </summary>
        public const string WRONGPASSWORD = "WRONGPASSWORD";
        /// <summary>
        /// 网络错误时的标志状态
        /// </summary>
        public const string WEBEXCEPTION = "WEBEXCEPTION";
        /// <summary>
        /// 正在登陆
        /// </summary>
        public const string LOGING = "LOGING";

        /********************************************************************************
         * 请求保存新建老人基本资料后，服务器响应情况，由服务器返回值，两种情况
        *******************************************************************************/
        /// <summary>
        /// 请求保存新建老人基本资料后，服务器响应情况————成功
        /// </summary>
        public const string ADDELDER_SUCCESS = "ADD_SUCCESS";
        /// <summary>
        /// 请求保存新建老人基本资料后，服务器响应情况————失败
        /// </summary>
        public const string ADDELDER_FAILD = "ADD_FAILD";
        /// <summary>
        /// 请求保存修改老人基本资料后，服务器响应情况————成功
        /// </summary>
        public const string AMENDELDER_SUCCESS = "UPDATE_SUCCESS";
        /// <summary>
        /// 请求保存修改老人基本资料后，服务器响应情况————失败
        /// </summary>
        public const string AMENDELDER_FAILD = "UPDATE_FAILD";
        /// <summary>
        /// 请求保存删除老人基本资料后，服务器响应情况————成功
        /// </summary>
        public const string DELETEELDER_SUCCESS = "DEL_SUCCESS";
        /// <summary>
        /// 请求保存删除老人基本资料后，服务器响应情况————失败
        /// </summary>
        public const string DELETEELDER_FAILD = "DEL_FAILD";
        /**************************************************************
         * 请求添加、修改、删除用户，服务器响应结果字符串
         * ***************************************************************/
        /// <summary>
        /// 请求新建用户后，服务器响应情况————成功
        /// </summary>
        public const string CREATUSER_SUCCESS = "ADD_SUCCESS";
        /// <summary>
        /// 请求新建用户后，服务器响应情况————失败
        /// </summary>
        public const string CREATUSER_FAILD = "ADD_FAILD";

        public const string CREATUSER_SAMENAME = "REPEATNAME";
        /// <summary>
        /// 请求修改用户信息后，服务器响应————成功
        /// </summary>
        public const string AMENDUSER_SUCCESS = "UPDATE_SUCCESS";
        /// <summary>
        /// 请求修改用户信息后，服务器响应————失败
        /// </summary>
        public const string AMENDUSER_FAILD = "UPDATE_FAILD";
        /// <summary>
        /// 请求删除用户信息后，服务器响应————成功
        /// </summary>
        public const string DELETEUSER_SUCCESS = "DEL_SUCCESS";
        /// <summary>
        /// 请求删除用户信息后，服务器响应————失败
        /// </summary>
        public const string DELETEUSER_FAILD = "DEL_FAILD";
        /// <summary>
        /// 请求修改用户密码，服务器响应————成功
        /// </summary>
        public const string AMENDPASSWORD_SUCCESS = "UPDATE_SUCCESS";
        /// <summary>
        /// 请求修改用户密码，服务器响应————失败
        /// </summary>
        public const string AMENDPASSWORD_FAILD = "UPDATE_FAILD";
        /*********************************************************
         * 对象类型，用于告知将要返回的对象的类型，共五种
        *************************************************************/
        /// <summary>
        /// 告诉调用方法，需要返回一个“LogUser”的对象
        /// </summary>
        public const string LOGUSEROBJ = "LOGUSER";
        /// <summary>
        /// 需要返回一个“ElderInfor”的对象
        /// </summary>
        public const string ELDERINFOROBJ = "ELDERINFOR";
        /// <summary>
        /// 告诉调用方法，需要返回一个“RingData”的对象
        /// </summary>
        public const string RINGDATAOBJ = "RINGDATA";
        /// <summary>
        ///告诉调用方法， 需要返回一个"ELDER"的对象集合
        /// </summary>
        public const string LISTELDEROBJ = "LISTELDER";
        /// <summary>
        /// 告诉调用方法，需要返回一个"RINGDATA"的对象集合
        /// </summary>
        public const string LISTRINGDATAOBJ = "LISTRINGDATA";
        /// <summary>
        /// 告诉调用方法，需要返回一个"LOGUSER"的对象集合
        /// </summary>
        public const string LISTLOGUSEROBJ = "LISTLOGUSER";
        /*************************************************************
         * 标志位，用于判断ComboBoxDropDown()方法是被谁调用，下拉框时间参数
         * ******************************************************/
        /// <summary>
        /// ComboBoxDropDown()方法将被修改（删除）窗口的——姓名下拉框——调用
        /// </summary>
        public const string NameComboBox = "CNameComboBoxDropDown";
        /// <summary>
        /// ComboBoxDropDown()方法将被修改（删除）窗口的——编号下拉框——调用
        /// </summary>
        public const string IDComboBox = "CIDComboBoxDropDown";


        /**********************************************************
         * 窗口调用中使用到的字符串常量
         * **********************************************************/
        /// <summary>
        /// 打开用户个人信息管理窗口时，选择显示页面的字符串————显示用户个人信息页面
        /// </summary>
        public const string UDFORMDETAILTAB = "userDetails";
        /// <summary>
        /// 打开用户个人信息管理窗口时，选择显示页面的字符串————显示修改密码页面
        /// </summary>
        public const string UDFORMPASSWORDTAB = "amendPassword";
        /// <summary>
        /// 打开老人管理窗口时，选择页面的字符串，该字符串未赋值，由于除另外两种情况外均为该情况————打开新建人员页面
        /// </summary>
        public const string EMFORMCREATRTAB = "";
        /// <summary>
        /// 打开老人管理窗口时，选择页面的字符串————打开修改人员页面
        /// </summary>
        public const string EMFORMAMENDRTAB = "amendRecord";
        /// <summary>
        /// 打开老人管理窗口时，选择页面的字符串————打开删除人员页面
        /// </summary>
        public const string EMFORMDELETRTAB = "deleteRecord";
        /// <summary>
        /// 打开管理员窗口时，选择页面字符串————打开用户列表页面
        /// </summary>
        public const string ADFORMUSERLISTTAB = "userListTab";
        /// <summary>
        /// 打开管理员窗口时，选择页面字符串————打开用户管理页面
        /// </summary>
        public const string ADFORMUSERMANAGETAB = "userManageTab";


    }
}
