using NFlog.Core;

namespace NFlog.Viewer.Events
{
    class SelectedMessageChangedEvent
    {
        public NFlogMessage Message { get; set; }
    }
}
