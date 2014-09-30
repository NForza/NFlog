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
            NFlogMessage msg = new NFlogMessage { MessageType = MessageTypes.Message, Message = message };
            Log(nflog, msg);
        }

        public static void LogWarning(this INFlog nflog, string message)
        {
            NFlogMessage msg = new NFlogMessage { MessageType = MessageTypes.Warning, Message = message };
            Log(nflog, msg);
        }

        public static void LogException(this INFlog nflog, string message, Exception exception)
        {
            NFlogMessage msg = new NFlogMessage { MessageType = MessageTypes.Exception, Message = message, Data=exception };
            Log(nflog, msg);
        }
    }
}
