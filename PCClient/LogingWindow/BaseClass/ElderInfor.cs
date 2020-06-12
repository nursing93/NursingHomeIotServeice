using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]      //声明该类为DataContract类型，并声明其各个属性用以解析json
    public class ElderInfo
    {
        private const string INVALIDID = "93000000";
        [DataMember(Order = 0, IsRequired = true)]
        public string id { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public string name { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public string sex { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public string birthday { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        public string idCard { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        public string phone { get; set; }

        [DataMember(Order = 6, IsRequired = true)]
        public string area { get; set; }

        [DataMember(Order = 7, IsRequired = true)]
        public string nursingDate;    //TODO 持久化、显示

        [DataMember(Order = 8, IsRequired = true)]
        public Relative[] relatives;    //TODO 持久化、显示

        public ElderInfo() { }

        public ElderInfo(string id)
        {
            this.id = id;
        }

        public ElderInfo(string id, string name, string birthday, string sex, string idCard, string phone, string area)
        {
            this.id = id;
            this.name = name;
            this.birthday = birthday;
            this.area = area;
            this.sex = sex;
            this.idCard = idCard;
            this.phone = phone;
        }

        public Boolean equals(ElderInfo elder1)
        {
            bool result = (this.id == elder1.id) &&
                   (this.name == elder1.name) &&
                   (this.sex == elder1.sex) &&
                   (Convert.ToDateTime(this.birthday) == Convert.ToDateTime(elder1.birthday)) &&
                   (this.idCard == elder1.idCard) &&
                   (this.phone == elder1.phone) &&
                   (this.area == elder1.area) &&
                   (this.nursingDate == elder1.nursingDate);
            return result;
        }

        public Boolean valid()
        {
            return this.id != INVALIDID;
        }

        public static ElderInfo invalidInst()
        {
            ElderInfo info = new ElderInfo();
            info.id = INVALIDID;
            return info;
        }
    }
}
