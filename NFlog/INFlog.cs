using NFlog.Core;

namespace NFlog
{
    public interface INFlog
    {
        void Log(NFlogMessage message);
        bool Enabled { get; set; }
        INFlogTransport Transport { get; }
        INFlogSerializer Serializer { get; }
    }
}
