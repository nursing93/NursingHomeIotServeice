using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]
    class PhysicalData
    {
        [DataMember(Order = 0, IsRequired = true)]
        public int heartRate { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        public int bloodPressure { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public double temperature { get; set; }
    }
}
