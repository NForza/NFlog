using NFlog.Core;

namespace NFlog.Viewer
{
    public class NFlogViewerMessage: NFlogMessage
    {
        public NFlogViewerMessage(NFlogMessage msg)
        {
            AppName = msg.AppName;
            Data = msg.Data;
            DateTime = msg.DateTime;
            Message = msg.Message;
            MessageType = MessageType;
            ThreadID = msg.ThreadID;
        }
        public int IndentLevel { get; set; }
    }
}
