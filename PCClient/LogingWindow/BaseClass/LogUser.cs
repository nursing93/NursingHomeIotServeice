using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]
    public class LogUser
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string userName { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        public string userPassword { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public int isAdmin = -1;             // 本地数据库没有该列
        [DataMember(Order = 3, IsRequired = true)]
        public string number { get; set; }    // 本地数据库没有该列
        [DataMember(Order = 4, IsRequired = true)]
        public string realName { get; set; }  // 本地数据库没有该列
        [DataMember(Order = 5, IsRequired = true)]
        public string sex { get; set; }       //本地数据库没有该列
        [DataMember(Order = 6, IsRequired = true)]
        public string idCard { get; set; }    // 本地数据库没有该列
        [DataMember(Order = 7, IsRequired = true)]
        public string birthday { get; set; }  // 本地数据库没有该列
        [DataMember(Order = 8, IsRequired = true)]
        public string superior { get; set; }  // 本地数据库没有该列
        //不JSON序列化的属性
        public int isSavePassword = -1;

        public LogUser() { }

        public LogUser(string userName, string password)
        {
            this.userName = userName;
            this.userPassword = password;
        }

        public LogUser copy()
        {
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
}
