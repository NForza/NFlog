using System;
using System.IO;
using System.Reflection;

namespace NFlog.Core
{
    public class NFlogFileTransport : INFlogTransport, IDisposable
    {
        private StreamWriter logfile;

        public void Dispose()
        {
            if (logfile != null)
            {
                logfile.Dispose();
                logfile = null;
            }
        }

        public NFlogFileTransport()
        {
            logfile = File.CreateText(Assembly.GetEntryAssembly().Location + ".nflog");
            logfile.AutoFlush = true;
        }

        public void Transport(string message)
        {
            logfile.WriteLine(message);
            logfile.WriteLine(NFlogMessage.MessageSeparator);
        }
    }
}
