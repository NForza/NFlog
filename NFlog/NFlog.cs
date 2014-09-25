using NFlog.Core;

namespace NFlog
{
    public class NFlogger : INFlog
    {
        private INFlogSerializer serializer = new NFlogSerializer();
        private INFlogTransport transport = new NFlogHttpTransport();
        
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
