using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NFlogger logger = new NFlogger();
            logger.LogMessage("hello world");
            logger.LogWarning("Be careful");
        }
    }
}
