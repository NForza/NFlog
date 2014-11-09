using System;

namespace NFlog.Core
{
    public class NFlogInProcessTransport : INFlogTransport
    {
        private readonly Action<string> onLogMessageRecieved;
        private readonly bool isAsync;

        public NFlogInProcessTransport(Action<string> onLogMessageRecieved, bool isAsync = false)
        {
            this.onLogMessageRecieved = onLogMessageRecieved;
            this.isAsync = isAsync;
        }

        public void Log(string message)
        {
            if (isAsync)
                onLogMessageRecieved.BeginInvoke(message, null, null);
            else
                onLogMessageRecieved(message);
        }
    }
}
