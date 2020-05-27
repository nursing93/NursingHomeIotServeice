using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]      //声明该类为DataContract类型，并声明其各个属性用以解析json
    public class ElderInfor
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string elderID { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        public string elderName { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public string elderBirthday { get; set; }
        [DataMember(Order = 3, IsRequired = true)]
        public string elderSex { get; set; }
        [DataMember(Order = 4, IsRequired = true)]
        public string elderChild { get; set; }
        [DataMember(Order = 5, IsRequired = true)]
        public string elderChildNumber { get; set; }
        [DataMember(Order = 6, IsRequired = true)]
        public string elderArea { get; set; }

        public ElderInfor() { }

        public ElderInfor(string elderID)
        {
            this.elderID = elderID;
        }

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

        public Boolean equals(ElderInfor elder1)
        {
            bool result = (this.elderID == elder1.elderID) &&
                   (this.elderName == elder1.elderName) &&
                   (this.elderSex == elder1.elderSex) &&
                   (Convert.ToDateTime(this.elderBirthday) == Convert.ToDateTime(elder1.elderBirthday)) &&
                   (this.elderChild == elder1.elderChild) &&
                   (this.elderChildNumber == elder1.elderChildNumber) &&
                   (this.elderArea == elder1.elderArea);
            return result;
        }
    }
}
