using System.Diagnostics;
using NFlog.Core;
using System;

namespace NFlog
{
    public static class INFlogExtensions
    {
        public static void Log(this INFlog nflog, NFlogMessage msg)
        {
            if (nflog.Enabled)
            {
                string serializedMessage = nflog.Serializer.Serialize(msg);
                nflog.Transport.Transport(serializedMessage);                
            }
        }

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void LogMessage(this INFlog nflog, string message)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.Message, Message = message });
        }

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void LogMessage(this INFlog nflog, string format, params object[] args)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.Message, Message = String.Format(format, args) });
        }

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void LogWarning(this INFlog nflog, string message)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.Warning, Message = message });
        }

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void LogException(this INFlog nflog, string message, Exception exception)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.Exception, Message = message, Data = exception });
        }

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void LogObject(this INFlog nflog, string message, object obj)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.Object, Message = message, Data = obj });
        }
    }
}
