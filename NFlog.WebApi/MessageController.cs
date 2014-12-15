using System;
using System.Web.Http;
using NFlog.Core;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        private readonly Action<NFlogMessage> messageReceived = delegate { };

        public MessageController(Action<NFlogMessage> messageReceived)
        {
            this.messageReceived = messageReceived;
        }

        public void Post([FromBody]NFlogMessage message)
        {
            var handler = messageReceived;
            if (handler != null)
                handler(message);
        }
    }
}
