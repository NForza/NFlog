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
            List<NFlogMessage> result = new List<NFlogMessage>();
            List<string> lines = contents.Split('\r', '\n').ToList();

            while (lines.Count > 0)
            {
                int index = lines.FindIndex(s => s == NFlogMessage.MessageSeparator);
                if (index < 0)
                    index = lines.Count - 1;
                var messageLines = lines.Take(index);
                string message = String.Join("\r", messageLines);
                if (!String.IsNullOrEmpty(message))
                    result.Add(JsonConvert.DeserializeObject<NFlogMessage>(message));
                lines.RemoveRange(0, index + 1);
            }
            return result;
        }
    }
}
