using System;

namespace NFlog.Core
{
    public class NFlogInMemoryTransport: INFlogTransport
    {
        private Action<string> onLogMessageRecieved;

        public NFlogInMemoryTransport(Action<string> onLogMessageRecieved)
        {
            this.onLogMessageRecieved = onLogMessageRecieved;
        }
        public void Transport(string message)
        {
            onLogMessageRecieved(message);
        }
    }
}
