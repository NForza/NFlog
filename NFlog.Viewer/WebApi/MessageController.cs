using System.Web.Http;
using Autofac;
using Caliburn.Micro;
using NFlog.Core;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        private readonly IEventAggregator eventAggregator;

        public MessageController()
        {
            eventAggregator = AppBootstrapper.Container.Resolve<IEventAggregator>();
        }
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
