using NFlog.Core;

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
    }
}
