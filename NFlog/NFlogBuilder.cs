using System.Collections.Generic;
using NFlog.Core;
using System;
using System.Reflection;

namespace NFlog
{
    public class NFlogBuilder
    {        
        private INFlogSerializer serializer;
        private string url = "http://localhost:12349/api/message";
        private string file;
        private bool logAsync;
        private Action<string> onLogMessageReceived;

        public NFlogger Build()
        {
            return new NFlogger
                { 
                    Serializer = CreateSerializer(),
                    Transport = CreateTransport()
                }; 
        }

        private INFlogSerializer CreateSerializer()
        {
            if (serializer == null)
                return new NFlogSerializer();
            return serializer;
        }

        private INFlogTransport CreateTransport()
        {
            if (!String.IsNullOrEmpty(file))
                return new NFlogHttpTransport(url, logAsync);

            if (onLogMessageReceived != null)
                return new NFlogInProcessTransport(onLogMessageReceived);

            return new NFlogFileTransport(file, !logAsync);
        }

        public NFlogBuilder WithSerializer(INFlogSerializer serializer)
        {
            this.serializer = serializer;
            return this;
        }

        public NFlogBuilder LogUsingHttpAt(string url)
        {
            this.url = url;
            return this;
        }

        public NFlogBuilder LogInMemory(Action<string> onLogMessageReceived)
        {
            this.onLogMessageReceived = onLogMessageReceived;
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

        public NFlogBuilder LogToFile(string file)
        {
            this.file = file;
            return this;
        }

        public NFlogBuilder LogToFile()
        {
            file = Assembly.GetEntryAssembly().Location + ".nflog";
            return this;
        }
    }
}
