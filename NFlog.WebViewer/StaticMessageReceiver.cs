using System;
using System.Collections.Generic;
using NFlog.Core;

namespace NFlog.WebViewer
{
    public class StaticMessageReceiver
    {
        static List<NFlogMessage> messages = new List<NFlogMessage>();

        public static void MessageReceived(NFlogMessage message)
        {
            if( message != null)
                messages.Add(message);    
        }
    }
}