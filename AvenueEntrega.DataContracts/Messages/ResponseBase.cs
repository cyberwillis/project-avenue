using System.Collections.Generic;

namespace AvenueEntrega.DataContracts.Messages
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IDictionary<string,string> Rules { get; set; }
        public ResponseBase()
        {
            Rules = new Dictionary<string, string>();
        }
    }
}