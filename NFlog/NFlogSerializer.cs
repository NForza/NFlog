using Newtonsoft.Json;
using NFlog.Core;

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
