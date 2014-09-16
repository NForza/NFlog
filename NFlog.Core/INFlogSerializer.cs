using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog.Core
{
    public interface INFlogSerializer
    {
        string Serialize(NFlogMessage message);
    }
}
