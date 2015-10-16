using System.Collections.Generic;

namespace AvenueEntrega.RepositoryFile.Messages
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}