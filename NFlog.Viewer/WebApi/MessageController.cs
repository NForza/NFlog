using System;
using System.Web.Http;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        private readonly Action<NFlogViewerMessage> messageReceived = delegate { };

        public MessageController(Action<NFlogViewerMessage> messageReceived)
        {
            this.messageReceived = messageReceived;
        }

        public void Post([FromBody]NFlogViewerMessage message)
        {
            var handler = messageReceived;
            if (handler != null)
                handler(message);
        }
    }
}
