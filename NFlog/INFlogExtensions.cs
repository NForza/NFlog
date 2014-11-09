using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NFlog.Core;

namespace NFlog
{
    public static class INFlogExtensions
    {
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

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void EnterMethod(this INFlog nflog, [CallerMemberName] string memberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.EnterMethod, Message = memberName, Data = callerFilePath + ": line " + callerLineNumber });
        }

        [Conditional("TRACE")]
        [Conditional("NFLOG")]
        public static void ExitMethod(this INFlog nflog, [CallerMemberName] string memberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            nflog.Log(new NFlogMessage { MessageType = MessageTypes.ExitMethod, Message = memberName, Data = callerFilePath + ": line " + callerLineNumber });
        }

    }
}
