using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog
{
    public interface INFlog
    {
        INFlogTransport Transport { get; }
        INFlogSerializer Serializer { get; }
    }
}
