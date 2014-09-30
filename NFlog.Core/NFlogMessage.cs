using System;

namespace NFlog.Core
{
    public class NFlogMessage
    {
        public const string MessageSeparator = "##NFLOG##";
        public int MessageType { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string AppName { get; set; }
        public int ThreadID { get; set; }
        public object Data { get; set; }
    }
}