using System;
using System.Reflection;
using System.Threading;

namespace NFlog.Core
{
    public class NFlogMessage
    {
        public NFlogMessage()
        {
            DateTime = DateTime.Now;
            AppName = Assembly.GetEntryAssembly().GetName().Name;
            ThreadID = Thread.CurrentThread.ManagedThreadId;
        }
        public const string MessageSeparator = "\r##NFLOG##\r";
        public int MessageType { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string AppName { get; set; }
        public int ThreadID { get; set; }
        public object Data { get; set; }
    }
}