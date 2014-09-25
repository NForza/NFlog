namespace NFlog.Core
{
    public interface INFlogSerializer
    {
        string Serialize(NFlogMessage message);
    }
}
