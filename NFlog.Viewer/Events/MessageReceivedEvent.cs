using NFlog.Core;

namespace NFlog.Viewer.Events
{
    public class MessageReceivedEvent
    {
        public MessageReceivedEvent(NFlogViewerMessage message)
        {
            Message = message;
        }

        public NFlogViewerMessage Message { get; set; }
    }
}
