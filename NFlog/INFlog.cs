using NFlog.Core;

namespace NFlog
{
    public interface INFlog
    {
        bool Enabled { get; set; }
        INFlogTransport Transport { get; }
        INFlogSerializer Serializer { get; }
    }
}
