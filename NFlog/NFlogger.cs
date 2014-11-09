using NFlog.Core;
using System;

namespace NFlog
{
    public class NFlogger : INFlog
    {
        public NFlogger()
        {
            Enabled = true;
        }

        public INFlogSerializer Serializer { get; set; }
        public INFlogTransport Transport { get; set; }
        public bool Enabled { get; set; }

        public NFlogger Next { get; set; }

        public void Log(NFlogMessage message)
        {
            if (Enabled)
            {
                var msg = Serializer.Serialize(message);
                Transport.Log(msg);
                if (Next != null)
                    Next.Log(message);
            }
        }
    }
}
