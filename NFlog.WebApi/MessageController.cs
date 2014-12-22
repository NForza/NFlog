using System;
using System.Web.Http;
using NFlog.Core;

namespace NFlog.WebApi
{
    [Route("nflog/message")]
    public class MessageController : ApiController
    {
        private readonly Action<NFlogMessage> messageReceived = delegate { };

        public MessageController(Action<NFlogMessage> messageReceived)
        {
            this.messageReceived = messageReceived;
        }

        public string Get()
        {
            return "NFlog WebApi";
        }

        public void Post([FromBody]NFlogMessage message)
        {
            if (messageReceived != null)
                messageReceived(message);
        }
    }
}
