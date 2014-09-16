using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog.Core
{
    public class NFlogMessage
    {
        public int MessageType { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string AppName { get; set; }
        public int ThreadID { get; set; }
        public string Data { get; set; }
    }
}