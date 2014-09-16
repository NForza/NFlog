using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog
{
    public static class INFlogExtensions
    {
        public static void LogMessage(this INFlog nflog, string message)
        {
            NFlogMessage msg = new NFlogMessage { MessageType = MessageTypes.Message, Message = message };
            string serializedMessage = nflog.Serializer.Serialize(msg);
            nflog.Transport.Transport(serializedMessage);
        }

        public static void LogWarning(this INFlog nflog, string message)
        {
            NFlogMessage msg = new NFlogMessage { MessageType = MessageTypes.Warning, Message = message };
            string serializedMessage = nflog.Serializer.Serialize(msg);
            nflog.Transport.Transport(serializedMessage);
        }

    }
}
