using System.Collections.Generic;
using System.ServiceModel;

namespace AvenueEntrega.DataContracts.Messages
{
    [MessageContract(WrapperNamespace = "messages.avenueentrega.com")]
    public class ResponseBase
    {
        [MessageBodyMember(Name="success")]
        public bool Success { get; set; }

        [MessageBodyMember(Name = "message")]
        public string Message { get; set; }

        public IDictionary<string,string> Rules { get; set; }

        public ResponseBase()
        {
            Rules = new Dictionary<string, string>();
        }
    }
}