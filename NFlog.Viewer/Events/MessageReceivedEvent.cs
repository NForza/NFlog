using NFlog.Core;

namespace NFlog.Viewer.Events
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
