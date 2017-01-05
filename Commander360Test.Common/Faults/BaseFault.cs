using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Commander360Test.Common.Faults
{
    [DataContract]
    public class BaseFault
    {
        [DataMember]
        public string Description { get; set; }
    }
}
