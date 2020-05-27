using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCClintSoftware.BaseClass       // 该引用空间包含一些成员类，该class文件里主要包含请求http的类
{
    /// <summary>
    /// 老人的基本信息类，包含老人的基本信息和一些修改方法
    /// </summary>
    [DataContract]      //声明该类为DataContract类型，并声明其各个属性用以解析json
    public class ElderInfor
    {
        /**************************************
         * 老人类的基本属性
        *****************************************/
        [DataMember(Order = 0, IsRequired = true)]
        public string elderID { get; set; }                    //编号
        [DataMember(Order = 1, IsRequired = true)]
        public string elderName { get; set; }                  //姓名
        [DataMember(Order = 2, IsRequired = true)]
        public string elderBirthday { get; set; }              //年龄
        [DataMember(Order = 3, IsRequired = true)]
        public string elderSex { get; set; }                   //性别
        [DataMember(Order = 4, IsRequired = true)]
        public string elderChild { get; set; }                 //监护人
        [DataMember(Order = 5, IsRequired = true)]
        public string elderChildNumber { get; set; }           //监护人联系方式
        [DataMember(Order = 6, IsRequired = true)]
        public string elderArea { get; set; }                  //安全活动范围
        /***************************************
         * 构造方法
         * *****************************************/
        public ElderInfor() { }
        /// <summary>
        /// 构造方法，3种重载形式，以ID新建一个老人对象
        /// </summary>
        /// <param name="elderID">老人的ID号</param>
        public ElderInfor(string elderID)
        {
            this.elderID = elderID;
        }
        /// <summary>
        /// 构造方法，3种重载形式，新建一个老人对象
        /// </summary>
        /// <param name="elderID">编号</param>
        /// <param name="elderName">姓名</param>
        /// <param name="elderAge">年龄</param>
        /// <param name="elderSex">性别</param>
        /// <param name="elderChild">监护人</param>
        /// <param name="elderChildNum">监护人联系方式</param>
        /// <param name="elderArea">安全活动区域</param>
        public ElderInfor(string elderID, string elderName, string elderAge, string elderSex, string elderChild, string elderChildNum, string elderArea)
        {
            this.elderID = elderID;
            this.elderName = elderName;
            this.elderBirthday = elderAge;
            this.elderArea = elderArea;
            this.elderSex = elderSex;
            this.elderChild = elderChild;
            this.elderChildNumber = elderChildNum;
        }
        /// <summary>
        /// 自定义方法，判断当前引用对象与参数中的对象的内容是否一致
        /// </summary>
        /// <param name="elder1"></param>
        public Boolean equals(ElderInfor elder1)
        {
            if (this.elderID!= elder1.elderID)
            { return false; }
            if (this.elderName != elder1.elderName)
            { return false; }
            if (this.elderSex != elder1.elderSex)
            { return false; }
            if (Convert.ToDateTime(this.elderBirthday) != Convert.ToDateTime(elder1.elderBirthday))
            { return false; }
            if (this.elderChild != elder1.elderChild)
            { return false; }
            if (this.elderChildNumber != elder1.elderChildNumber)
            { return false; }
            if (this.elderArea != elder1.elderArea)
            { return false; }
            return true;
        }
    }
    /// <summary>
    /// 工作人员系统用户类，包含用户名、密码和权限，同时用作用户登录请求类
    /// </summary>
    [DataContract]
    public class LogUser
    {
        /******************************************
         * 用户的基本属性
         * *****************************************/
        //JSON序列化的属性
        [DataMember(Order = 0, IsRequired = true)]
        public string userName { get; set; }        //用户名          本地数据库有该列——有
        [DataMember(Order = 1, IsRequired = true)]
        public string userPassword { get; set; }    //用户密码        本地数据库有该列——有
        [DataMember(Order = 2, IsRequired = true)] 
        public int isAdmin = -1;             //用户权限               本地数据库没有有该列——无
        [DataMember(Order = 3, IsRequired = true)] 
        public string number { get; set; }    //用户工号              本地数据库没有有该列——无
        [DataMember(Order = 4, IsRequired = true)]
        public string realName { get; set; }  //用户姓名              本地数据库没有有该列——无
        [DataMember(Order = 5, IsRequired = true)]
        public string sex { get; set; }       //用户性别              本地数据库没有有该列——无
        [DataMember(Order = 6, IsRequired = true)]
        public string idCard { get; set; }    //用户身份证号          本地数据库没有有该列——无
        [DataMember(Order = 7, IsRequired = true)]
        public string birthday { get; set; }  //用户生日              本地数据库没有有该列——无
        [DataMember(Order = 8, IsRequired = true)]
        public string superior { get; set; }  //添加该用户的管理员    本地数据库没有有该列——无
        //不JSON序列化的属性
        public int isSavePassword = -1;   //0为不保存密码，1为保存密码，-1为未知        本地数据库有该列——有
       
        /********************************************
         * 构造方法
         * *******************************************/
        public LogUser() { }
        /// <summary>
        /// 构造方法。2种重载形式
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">登录密码</param>
        public LogUser(string userName,string password) {
            this.userName = userName;
            this.userPassword = password;
        }
        /************************************
         * 复制一个LogUser对象并返回
         * 
         * *********************************/
        public LogUser copy() {
            LogUser newUser = new LogUser(this.userName, this.userPassword);
            newUser.birthday = this.birthday;
            newUser.idCard = this.idCard;
            newUser.isAdmin = this.isAdmin;
            newUser.isSavePassword = this.isSavePassword;
            newUser.number = this.number;
            newUser.realName = this.realName;
            newUser.sex = this.sex;
            newUser.superior = this.superior;
            return newUser;
        }
    }
    /// <summary>
    /// 手环数据类，包含对应老人的最近一次手环数据
    /// </summary>
    [DataContract]
    public class RingData 
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string curID { get; set; }                //表名，即为对应老人的ID
        [DataMember(Order = 0, IsRequired = true)]
        public string datetime { get; set; }             //时间
        [DataMember(Order = 0, IsRequired = true)]
        public string lng { get; set; }                  //经度
        [DataMember(Order = 0, IsRequired = true)]
        public string lat { get; set; }                  //纬度
        [DataMember(Order = 0, IsRequired = true)]
        public int heartRate { get; set; }               //心率
        //[DataMember(Order = 0, IsRequired = true)]
        //public string xueTang { get; set; }
        //[DataMember(Order = 0, IsRequired = true)]
        //public string xueZhi { get; set; }

        /***************************************
        * 构造方法
        ******************************************/
        public RingData(){}
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="thecurID">手环的ID，与对应老人ID相同</param>
        public RingData(string thecurID)
        {
            this.curID = thecurID;
        }

    }









}
