namespace NFlog.Core
{
    public interface INFlogTransport
    {
        void Log(string message);
    }
}