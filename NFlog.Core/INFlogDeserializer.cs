using System.Collections.Generic;

namespace NFlog.Core
{
    public interface INFlogDeserializer
    {
        IEnumerable<NFlogMessage> Deserialize(string contents);
    }
}
