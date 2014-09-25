namespace NFlog.Core
{
    public interface INFlogTransport
    {
        void Transport(string message);
    }
}