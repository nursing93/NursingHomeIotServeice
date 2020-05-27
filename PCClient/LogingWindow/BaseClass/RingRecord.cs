using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]
    public class RingRecord
    {
        [DataMember(Order = 0, IsRequired = true)]
        private int id { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        private int battery { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        private PhysicalData physical { get; set; }
        [DataMember(Order = 3, IsRequired = true)]
        private Position position { get; set; }
        [DataMember(Order = 4, IsRequired = true)]
        private Kinestate kinestat { get; set; }
        [DataMember(Order = 5, IsRequired = true)]
        private KeyEvent keyEvent { get; set; }
        //TODO time 
    }


    //TODO 删除，用RingRecord替换
    [DataContract]
    public class RingData
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string curID { get; set; }
        [DataMember(Order = 0, IsRequired = true)]
        public string datetime { get; set; }
        [DataMember(Order = 0, IsRequired = true)]
        public string lng { get; set; }
        [DataMember(Order = 0, IsRequired = true)]
        public string lat { get; set; }
        [DataMember(Order = 0, IsRequired = true)]
        public int heartRate { get; set; }

        public RingData() { }

        public RingData(string thecurID)
        {
            this.curID = thecurID;
        }

    }
}
