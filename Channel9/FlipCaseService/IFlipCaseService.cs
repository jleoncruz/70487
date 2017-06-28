using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlipCaseService
{
    [ServiceContract]
    public interface IFlipCaseService
    {
        [OperationContract]
        StringData FlipTheCase(StringData sd);
    }
}
