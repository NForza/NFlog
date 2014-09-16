using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFlog.Viewer
{
    class NFlogDeserializer : INFlogDeserializer
    {
        public IEnumerable<NFlogMessage> Deserialize(string contents)
        {
            return null;
        }
    }
}
