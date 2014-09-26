using System.Web.Http;
using NFlog.Core;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        public void Post([FromBody]NFlogMessage message)
        {

        }
    }
}
