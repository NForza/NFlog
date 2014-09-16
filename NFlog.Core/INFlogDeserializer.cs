using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog.Core
{
    public interface INFlogDeserializer
    {
        IEnumerable<NFlogMessage> Deserialize(string contents);
    }
}
