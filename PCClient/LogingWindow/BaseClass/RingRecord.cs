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
        private const int INVALIDELDERID = 93000000;

        [DataMember(Order = 0, IsRequired = true)]
        public int id { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        public int battery { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public PhysicalData physical { get; set; }
        [DataMember(Order = 3, IsRequired = true)]
        public Position position { get; set; }
        [DataMember(Order = 4, IsRequired = true)]
        public Kinestate kinestat { get; set; }
        [DataMember(Order = 5, IsRequired = true)]
        public KeyEvent keyEvent { get; set; }

        public string time { get; set; }

        public RingRecord()
        {
            physical = new PhysicalData();
            position = new Position();
            kinestat = new Kinestate();
            keyEvent = KeyEvent.NON;
        }

        public RingRecord(int id)
        {
            this.id = id;
            physical = new PhysicalData();
            position = new Position();
            kinestat = new Kinestate();
            keyEvent = KeyEvent.NON;
        }

        public Boolean validRecord()
        {
            return id != INVALIDELDERID;
        }

        public static RingRecord defaultRecord()
        {
            RingRecord record = new RingRecord();
            record.id = INVALIDELDERID;
            return record;
        }
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
