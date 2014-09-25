using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace NFlog.Viewer.WebApi
{
    public class MessageController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // POST api/values
        public void Post(string value)
        {
        }
    }
}
