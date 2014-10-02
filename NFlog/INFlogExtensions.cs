using NFlog.Core;
using System;

namespace NFlog
{
    public static class INFlogExtensions
    {
        private static void Log(INFlog nflog, NFlogMessage msg)
        {
            string serializedMessage = nflog.Serializer.Serialize(msg);
            nflog.Transport.Transport(serializedMessage);
        }

        public static void LogMessage(this INFlog nflog, string message)
        {
            Log(nflog, new NFlogMessage { MessageType = MessageTypes.Message, Message = message });
        }

        public static void LogWarning(this INFlog nflog, string message)
        {
            Log(nflog, new NFlogMessage { MessageType = MessageTypes.Warning, Message = message });
        }

        public static void LogException(this INFlog nflog, string message, Exception exception)
        {
            Log(nflog, new NFlogMessage { MessageType = MessageTypes.Exception, Message = message, Data=exception });
        }

        public static void LogObject(this INFlog nflog, string message, object obj)
        {
            Log(nflog, new NFlogMessage { MessageType = MessageTypes.Object, Message = message, Data = obj });
        }
    }
}
