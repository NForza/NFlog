using NFlog.Core;

namespace NFlog.WebApi
{
    public interface IMessageReceiver
    {
        void MessageReceived(NFlogMessage message);
    }
}
