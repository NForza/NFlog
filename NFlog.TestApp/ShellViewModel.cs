using Caliburn.Micro;
using System;

namespace NFlog.TestApp
{
    public class ShellViewModel : PropertyChangedBase, IShell 
    {
        NFlogger logger = new NFlogger();

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