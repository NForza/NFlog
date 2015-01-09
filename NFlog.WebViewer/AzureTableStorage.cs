using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using NFlog.Core;

namespace NFlog.WebViewer
{
    class AzureTableStorageProvider : AzureTableStorage, IMessageProvider
    {
        public IEnumerable<NFlogMessage> GetMessagesForApp(string appName)
        {
            var table = GetCloudTable();

            TableQuery<AzureMessage> query =
                new TableQuery<AzureMessage>()
                .Where(TableQuery.GenerateFilterCondition("AppName", QueryComparisons.Equal, appName));

            return table.ExecuteQuery(query).OrderByDescending(am=>am.DateTime).Select( am =>
                new NFlogMessage()
                {
                    AppName = am.AppName,
                    Data = am.Data,
                    DateTime = am.DateTime,
                    Message = am.Message,
                    MessageType = am.MessageType,
                    ThreadID = am.ThreadID
                });
        }
    }

    class AzureTableStorage
    {
        private CloudTable _table;
        
        protected CloudTable GetCloudTable()
        {
            if (_table == null)
            {
                var storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

                var tableClient = storageAccount.CreateCloudTableClient();
                _table = tableClient.GetTableReference("nflog");
                _table.CreateIfNotExists();
            }
            return _table;
        }
    }
}