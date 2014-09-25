using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using NFlog.Core;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        // GET api/message
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // POST api/message
        public void Post([FromBody]string value)
        {
            NFlogMessage msg = JsonConvert.DeserializeObject<NFlogMessage>(value);

        }
    }
}
