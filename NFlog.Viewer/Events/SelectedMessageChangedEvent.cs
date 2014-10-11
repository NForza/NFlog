using NFlog.Core;

namespace NFlog.Viewer.Events
{
    class SelectedMessageChangedEvent
    {
        public NFlogViewerMessage Message { get; set; }
    }
}
