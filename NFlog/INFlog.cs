using NFlog.Core;

namespace NFlog
{
    public interface INFlog
    {
        INFlogTransport Transport { get; }
        INFlogSerializer Serializer { get; }
    }
}
