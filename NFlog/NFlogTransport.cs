using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NFlog
{
    public class NFlogTransport : INFlogTransport, IDisposable
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

        public NFlogTransport()
        {
            logfile = File.CreateText(Assembly.GetEntryAssembly().Location + ".nflog");
            logfile.AutoFlush = true;
        }

        public void Transport(string message)
        {
            logfile.WriteLine(message);
        }
    }
}
