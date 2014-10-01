using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NFlog
{
    public class NFlogBuilder
    {
        private INFlogSerializer serializer;
        private INFlogTransport transport;
        private string url = "http://localhost:12349/api/message";
        private string file;

        private bool logAsync;
        

        public NFlogger Build()
        {
            INFlogTransport transport;

            if (String.IsNullOrEmpty(file))
                transport = new NFlogHttpTransport(url, logAsync);
            else 
                transport = new NFlogFileTransport(file, !logAsync);
                
            if (serializer == null)
                serializer = new NFlogSerializer();

            return new NFlogger() 
                { 
                    Serializer = serializer,
                    Transport = transport
                }; 
        }

        public NFlogBuilder WithSerializer(INFlogSerializer serializer)
        {
            this.serializer = serializer;
            return this;
        }

        public NFlogBuilder LogMessagesUsingWebApiAt(string url)
        {
            this.url = url;
            return this;
        }

        public NFlogBuilder Async
        {
            get
            {
                logAsync = true;
                return this;
            }
        }

        public NFlogBuilder LogMessagesToFile(string file)
        {
            this.file = file;
            return this;
        }

        public NFlogBuilder LogMessagesToFile()
        {
            this.file = Assembly.GetEntryAssembly().Location + ".nflog";
            return this;
        }
    }
}
