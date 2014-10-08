using Caliburn.Micro;
using System;

namespace NFlog.TestApp
{
    public class ShellViewModel : PropertyChangedBase, IShell 
    {
        NFlogger logger =
            new NFlogBuilder()
                .LogUsingHttpAt("http://localhost:12349/api/message")
                .Build();

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

        public void LogObject()
        {
            logger.LogObject("Oops", this);
        }


    }
}