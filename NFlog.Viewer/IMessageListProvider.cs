using System.Collections.Generic;
using NFlog.Core;

namespace NFlog.Viewer
{
    public interface IMessageListProvider
    {
        ICollection<NFlogMessage> Messages { get;  } 
    }
}