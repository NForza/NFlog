namespace NFlog
{
    public interface INFlogTransport
    {
        void Transport(string message);
    }
}