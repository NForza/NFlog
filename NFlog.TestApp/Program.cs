using System;

namespace NFlog.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            NFlogger logger = new NFlogger();
            logger.LogMessage("hello world");
            logger.LogWarning("Be careful");
            Console.ReadKey();
        }
    }
}
