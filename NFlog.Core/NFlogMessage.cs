using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace NFlog.Core
{
    public class NFlogMessage
    {
        public static string appName = null;        

        private static void DetermineAppName()
        {
            var result = Assembly.GetEntryAssembly();

            if (result == null)
            {
                MethodBase methodCurrent = null;
                int framestoSkip = 1;

                do
                {
                    StackFrame stackFrame = new StackFrame(framestoSkip);
                    methodCurrent = stackFrame.GetMethod();
                    if (methodCurrent != null)
                    {
                        var typeCurrent = methodCurrent.DeclaringType;
                        if (typeCurrent != typeof (RuntimeMethodHandle))
                        {
                            var assembly = typeCurrent.Assembly;

                            if (!assembly.GlobalAssemblyCache
                                && !assembly.IsDynamic
                                && (assembly.GetCustomAttributes(typeof (GeneratedCodeAttribute), false).Length == 0))
                            {
                                result = assembly;
                            }
                        }
                    }

                    framestoSkip++;
                } while (methodCurrent != null);
                if (result != null)
                    appName = result.GetName().Name;
            }
        }


        public void Initialize()
        {
            if (appName == null)
                DetermineAppName();

            DateTime = DateTime.Now;

            AppName = Assembly.GetEntryAssembly().GetName().Name;
            ThreadID = Thread.CurrentThread.ManagedThreadId;
        }
        public const string MessageSeparator = "\r##NFLOG##\r";
        public int MessageType { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string AppName { get; set; }
        public int ThreadID { get; set; }
        public object Data { get; set; }
    }
}