using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NFlog.Core;

namespace NFlog.Viewer
{
    class NFlogDeserializer : INFlogDeserializer
    {
        public IEnumerable<NFlogMessage> Deserialize(string contents)
        {
            return contents
                .Split(new [] { NFlogMessage.MessageSeparator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(JsonConvert.DeserializeObject<NFlogViewerMessage>);
        }
    }
}
