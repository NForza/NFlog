using NFlog.Core;

namespace NFlog.Viewer.WebApi
{
    public class MessageReceivedEvent
    {
        public MessageReceivedEvent(NFlogMessage message)
        {
            Message = message;
        }

        public NFlogMessage Message { get; set; }
    }
}
