using Caliburn.Micro;
using System;

namespace NFlog.TestApp
{
    public class ShellViewModel : PropertyChangedBase, IShell 
    {
        NFlogger logger =
            new NFlogBuilder()
                .LogMessagesUsingWebApiAt("http://localhost:12349/api/message")
                .Build();

        //NFlogger logger =
        //      new NFlogBuilder()
        //          .LogMessagesToFile()                  
        //          .Build();

        public void LogMessage()
        {
            logger.LogMessage("Hello World");  
        }

        public void LogWarning()
        {
            logger.LogWarning("Be careful!");  
        }

        public void LogException()
        {
            logger.LogException("Oops", new Exception("Wrong"));
        }
    }
}