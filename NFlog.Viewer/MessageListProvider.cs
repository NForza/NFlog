using System.Collections.Generic;
using System.Collections.ObjectModel;
using NFlog.Core;

namespace NFlog.Viewer
{
    class MessageListProvider : IMessageListProvider
    {
        ObservableCollection<NFlogMessage> messages = new ObservableCollection<NFlogMessage>(); 
        public ICollection<NFlogMessage> Messages
        {
            get { return messages; }
        }
    }
}
