using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFlog.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NFlogger logger = new NFlogger();
            logger.LogMessage("hello world");
        }
    }
}
