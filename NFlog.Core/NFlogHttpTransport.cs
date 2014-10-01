using System;
using System.Net.Http;
using System.Text;

namespace NFlog.Core
{
    internal class NFlogHttpTransport : INFlogTransport
    {
        private readonly bool logAsync;
        private readonly string url;
        HttpClient client = new HttpClient();

        public NFlogHttpTransport(string url, bool logAsync)
        {
            logAsync = logAsync;
            this.url = url;
        }

        public void Transport(string message)
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
