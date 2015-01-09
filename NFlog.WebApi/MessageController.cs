using System;
using System.Web.Http;
using NFlog.Core;

namespace NFlog.WebApi
{
    [Route("nflog/message")]
    public class MessageController : ApiController
    {
        private readonly IMessageReceiver messageReceiver;

        public MessageController(IMessageReceiver messageReceiver)
        {
            this.messageReceiver = messageReceiver;
        }

        public string Get()
        {
            return "NFlog WebApi";
        }

        public void Post([FromBody]NFlogMessage message)
        {
            if (messageReceiver != null)
                messageReceiver.MessageReceived(message);
        }
    }
}
