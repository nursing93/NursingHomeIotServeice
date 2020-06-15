using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.BaseClass
{
    [DataContract]
    class Position
    {
        [DataMember(Order = 0, IsRequired = true)]
        public double lng { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        public double lat { get; set; }
    }
}
