using System.Web.Http;
using Caliburn.Micro;
using NFlog.Core;
using NFlog.Viewer.Events;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        private readonly IEventAggregator eventAggregator;

        public MessageController(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void Post([FromBody]NFlogMessage message)
        {
           eventAggregator.PublishOnUIThread(new MessageReceivedEvent(message));
        }
    }
}
