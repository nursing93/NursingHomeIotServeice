using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]
    class Kinestate
    {
        [DataMember(Order = 0, IsRequired = true)]
        private Acceleration acc { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        private Palstance pal { get; set; }
    }

    [DataContract]
    class Acceleration
    {
        [DataMember(Order = 0, IsRequired = true)]
        private double x { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        private double y { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        private double z { get; set; }
    }
    [DataContract]
    class Palstance
    {
        [DataMember(Order = 0, IsRequired = true)]
        private double x { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        private double y { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        private double z { get; set; }
    }
}
