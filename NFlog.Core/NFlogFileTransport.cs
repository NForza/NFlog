using System;
using System.IO;
using System.Reflection;

namespace NFlog.Core
{
    internal class NFlogFileTransport : INFlogTransport, IDisposable
    {
        private readonly bool autoflush;
        private StreamWriter logfile;

        private string filename = Assembly.GetEntryAssembly().Location + ".nflog";
       
        public NFlogFileTransport(string filename, bool autoflush)
        {
            this.autoflush = autoflush;
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

        public void Log(string message)
        {
            EnsureStreamWriter();
            logfile.Write(message + NFlogMessage.MessageSeparator);
        }

        private void EnsureStreamWriter()
        {
            if (logfile == null)
            {
                logfile = File.CreateText(filename);
                logfile.AutoFlush = autoflush;
            }
        }
    }
}
