using System;

namespace NFlog.Viewer
{
    public interface IShell
    {
        Action<NFlogViewerMessage> MessageReceived { get; set; }
    }
}