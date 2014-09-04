using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog
{
    public interface INFlogTransport
    {
        void Transport(string message);
    }
}