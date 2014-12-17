using System;
using NFlog.Core;

namespace NFlog.Viewer
{
    public interface IShell
    {
        Action<NFlogMessage> MessageReceived { get; set; }
    }
}