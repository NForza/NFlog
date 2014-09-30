using System;
using System.Net.Http;
using System.Text;

namespace NFlog.Core
{
    public class NFlogHttpTransport : INFlogTransport
    {
        private readonly string url;
        HttpClient client = new HttpClient();

        public NFlogHttpTransport(string url)
        {
            this.url = url;
        }
        public void Transport(string message)
        {
            client.PostAsync(url,
                new StringContent(message, Encoding.UTF8, "application/json")).
              ContinueWith( t => { if (t.Exception != null) Console.WriteLine(t.Exception); } );
        }
    }
}
