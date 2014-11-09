using System.Collections.Generic;
using NFlog.Core;
using System;
using System.Linq;
using System.Reflection;

namespace NFlog
{
    public class NFlogDestinationBuilder
    {
        private bool logAsync;

        public NFlogger Build(NFlogger next)
        {
            return new NFlogger
            {
                Serializer = CreateSerializer(),
                Transport = CreateTransport(),
                Next = next
            };
        }

        private INFlogSerializer CreateSerializer()
        {
            return new NFlogSerializer();
        }  

        private INFlogTransport CreateTransport()
        {
            if (!String.IsNullOrEmpty(WebApiUrl))
                return new NFlogHttpTransport(WebApiUrl, logAsync);

            if (InProcessAction != null)
                return new NFlogInProcessTransport(InProcessAction);

            return new NFlogFileTransport(File, !logAsync);
        }

       
        public string WebApiUrl { get; set; }

        public Action<string> InProcessAction { get; set; }

        public string File { get; set; }
    }

    public class NFlogBuilder
    {
        List<NFlogDestinationBuilder> destionationBuilders = new List<NFlogDestinationBuilder>();

        public NFlogBuilder LogUsingHttpAt(string url)
        {
            destionationBuilders.Add(new NFlogDestinationBuilder() { WebApiUrl = url });
            return this;
        }

        public NFlogBuilder LogInMemory(Action<string> onLogMessageReceived)
        {
            destionationBuilders.Add(new NFlogDestinationBuilder() { InProcessAction = onLogMessageReceived });
            return this;
        }

        public NFlogBuilder LogToFile(string file)
        {
            destionationBuilders.Add(new NFlogDestinationBuilder() { File = file });
            return this;
        }

        public NFlogBuilder LogToFile()
        {
            destionationBuilders.Add( new NFlogDestinationBuilder() { File = Assembly.GetEntryAssembly().Location + ".nflog"});
            return this;
        }

        public NFlogger Build()
        {
            NFlogger next = null;
            foreach (var item in destionationBuilders.Reverse<NFlogDestinationBuilder>())
                next = item.Build(next);
            return next;
        }
    }
}
