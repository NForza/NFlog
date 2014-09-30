using NFlog.Core;
using System;

namespace NFlog
{
    public class NFlogger : INFlog
    {
        public INFlogSerializer Serializer { get; set; }
        public INFlogTransport Transport { get; set; }
    }
}
