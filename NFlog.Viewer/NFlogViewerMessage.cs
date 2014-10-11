using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog.Viewer
{
    public class NFlogViewerMessage: NFlogMessage
    {
        public int IndentLevel { get; set; }
    }
}
