using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog
{
    public class NFlogSerializer : INFlogSerializer
    {        
        public string Serialize(NFlogMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }
    }
}
