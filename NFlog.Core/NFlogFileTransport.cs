using System;
using System.IO;
using System.Reflection;

namespace NFlog.Core
{
    public class NFlogFileTransport : INFlogTransport, IDisposable
    {
        private StreamWriter logfile = null;

        private string filename = Assembly.GetEntryAssembly().Location + ".nflog";

        public NFlogFileTransport()
        {
        }

        public NFlogFileTransport(string filename)
        {
            this.filename = filename;
        }

        public void Dispose()
        {
            if (logfile != null)
            {
                logfile.Dispose();
                logfile = null;
            }
        }

        public void Transport(string message)
        {
            EnsureStreamWriter();
            logfile.WriteLine(message);
            logfile.WriteLine(NFlogMessage.MessageSeparator);
        }

        private void EnsureStreamWriter()
        {
            if (logfile != null)
            {
                logfile = File.CreateText(filename);
                logfile.AutoFlush = true;
            }
        }
    }
}
