using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlipCaseService
{
    [DataContract]
    public class StringData
    {
        [DataMember]
        public string OriginalString;

        [DataMember]
        public string FlippedCaseString;
    }
}
