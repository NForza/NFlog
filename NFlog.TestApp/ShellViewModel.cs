using System.Collections.Generic;
using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;

namespace NFlog.TestApp
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {

        private NFlogger logger;

        public ShellViewModel()
        {
            InMemoryMessages = new ObservableCollection<string>();
            logger =
               new NFlogBuilder()
                   .LogInMemory(AddMessage)
                   .Build();
        }

        private void AddMessage(string s)
        {
            InMemoryMessages.Add(s);
        }

        public ObservableCollection<string> InMemoryMessages { get; set; }

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

        public void EnterMethod()
        {
            logger.EnterMethod("DoSomething");
        }

        public void ExitMethod()
        {
            logger.ExitMethod("DoSomething");
        }


    }
}