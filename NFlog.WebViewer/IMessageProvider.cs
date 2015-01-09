using System.Collections.Generic;
using NFlog.Core;

namespace NFlog.WebViewer
{
    public interface IMessageProvider
    {
        IEnumerable<NFlogMessage> GetMessagesForApp(string appName);
    }
}