using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog
{
    public class NFlogger : INFlog
    {
        private INFlogSerializer serializer = new NFlogSerializer();
        private INFlogTransport transport = new NFlogTransport();
        
        public INFlogSerializer Serializer
        {
            get
            {
                return serializer;
            }
        }
        
        public INFlogTransport Transport
        {
            get
            {
                return transport;
            }
        }
    }
}
