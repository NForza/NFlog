using System;
using System.Net.Http;
using System.Text;

namespace NFlog.Core
{
    public class NFlogHttpTransport : INFlogTransport
    {
        HttpClient client = new HttpClient();
        public void Transport(string message)
        {
            client.PostAsync("http://localhost:12349/api/message",
                new StringContent(message, Encoding.UTF8, "application/json"));
        }
    }
}
