using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFlog
{
    public class NFlogBuilder
    {
        private INFlogSerializer serializer = new NFlogSerializer();
        private INFlogTransport transport = new NFlogHttpTransport("http://localhost:12349/api/message");

        public NFlogger Build()
        {
            return new NFlogger() { Serializer = serializer, Transport = transport }; 
        }

        public NFlogBuilder WithSerializer(INFlogSerializer serializer)
        {
            this.serializer = serializer;
            return this;
        }

        public NFlogBuilder LogMessagesUsingWebApiAt(string url)
        {
            this.transport = new NFlogHttpTransport(url);
            return this;
        }

        public NFlogBuilder LogMessagesToFile(string file)
        {
            this.transport = new NFlogFileTransport(file);
            return this;
        }
    }
}
