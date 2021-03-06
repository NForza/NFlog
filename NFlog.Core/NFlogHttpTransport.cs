﻿using System;
using System.Net.Http;
using System.Text;

namespace NFlog.Core
{
    internal class NFlogHttpTransport : INFlogTransport, IDisposable
    {
        private readonly bool logAsync;
        private readonly string url;
        private readonly HttpClient client = new HttpClient();

        public void Dispose()
        {
            if (client != null)
                client.Dispose();
        }

        public NFlogHttpTransport(string url, bool logAsync)
        {
            this.logAsync = logAsync;
            this.url = url;
        }

        public void Log(string message)
        {
            if (logAsync)
            {
                client.PostAsync(url,
                    new StringContent(message, Encoding.UTF8, "application/json")).
                  ContinueWith(t => { if (t.Exception != null) Console.WriteLine(t.Exception); });
            }
            else
                client.PostAsync(url,
                    new StringContent(message, Encoding.UTF8, "application/json")).Wait();
        }
    }
}
