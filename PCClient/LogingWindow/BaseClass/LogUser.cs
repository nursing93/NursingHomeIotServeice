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
        public string id { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public string password { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public int role = -1;             // TODO 改为枚举类型Role、持久化

        [DataMember(Order = 3, IsRequired = true)]
        public string nursHomeId { get; set; }    // 本地数据库没有该列

        [DataMember(Order = 4, IsRequired = true)]
        public string realName { get; set; }  // 本地数据库没有该列

        [DataMember(Order = 5, IsRequired = true)]
        public string sex { get; set; }       //本地数据库没有该列

        [DataMember(Order = 6, IsRequired = true)]
        public string birthday { get; set; }  // 本地数据库没有该列

        [DataMember(Order = 7, IsRequired = true)]
        public string phone { get; set; }    // 本地数据库没有该列

        //不JSON序列化的属性
        public int isSavePassword = -1;

        public LogUser() { }

        public LogUser(string id, string password)
        {
            this.id = id;
            this.password = password;
        }

        public LogUser copy()
        {
            LogUser newUser = new LogUser(this.id, this.password);
            newUser.birthday = this.birthday;
            newUser.phone = this.phone;
            newUser.role = this.role;
            newUser.isSavePassword = this.isSavePassword;
            newUser.nursHomeId = this.nursHomeId;
            newUser.realName = this.realName;
            newUser.sex = this.sex;
            return newUser;
        }
    }
}
